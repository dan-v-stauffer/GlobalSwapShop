' WARNING: 
' The source code of this class can be used and modified to your particular needs. 
' Sharing the class with unregistered users or using it with unregistered websites 
' or Facebook applications is not allowed and violates the rights of intellectual 
' property. 

Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Text

Namespace FVK
    ''' <summary>
    ''' This control uses to include possibility to select Facebook frends as easy as possible. The control 
    ''' has 2 types of filter methods and 3 types of selection methods. There are also possibility to change 
    ''' number of rows and columns.
    ''' </summary>
    Partial Public Class SelectFriends
        Inherits System.Web.UI.UserControl
        ''' <summary>
        ''' Inform client about changes in selection
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Public Delegate Sub SelectionChangedHandler(ByVal sender As Object, ByVal e As EventArgs)
        Public Event SelectionChanged As SelectionChangedHandler

        ''' <summary>
        ''' Set num of rows
        ''' </summary>
        Public WriteOnly Property Rows() As Integer
            Set(ByVal value As Integer)
                selectfriendsdiv.Style.Add("height", (value * 25).ToString() & "px")
            End Set
        End Property

        ''' <summary>
        ''' set num of columns
        ''' </summary>
        Public WriteOnly Property Columns() As Integer
            Set(ByVal value As Integer)
                If value > 4 Then
                    Throw New Exception("Number of columns exceed limit (4)")
                End If
                selectfriendsdiv.Style.Add("width", (value * 170 + 20).ToString() & "px")
            End Set
        End Property

        ''' <summary>
        ''' Get selected friend list
        ''' </summary>
        ''' <returns></returns>
        Public Function GetSelectedFriends() As IList(Of FriendData)
            Dim selectedFriends As IList(Of FriendData) = New List(Of FriendData)()
            For Each f As SelectedFriend In Friends
                If f.Selected Then
                    selectedFriends.Add(f)
                End If
            Next
            Return selectedFriends
        End Function

        ''' <summary>
        ''' Filter list by name which starts with parameter
        ''' </summary>
        ''' <param name="namePart"></param>
        Public Sub FilterByNameStartsWith(ByVal namePart As String)
            For Each f As SelectedFriend In Friends
                If f.Name.ToLower().StartsWith(namePart.ToLower()) Then
                    f.IsInList = True
                Else
                    f.IsInList = False
                End If
                f.Selected = False
            Next
            OnSelectionChangedCall()
        End Sub

        ''' <summary>
        ''' Filter list by name which contains parameter
        ''' </summary>
        ''' <param name="namePart"></param>
        Public Sub FilterByNameContains(ByVal namePart As String)
            For Each f As SelectedFriend In Friends
                If f.Name.ToLower().Contains(namePart.ToLower()) Then
                    f.IsInList = True
                Else
                    f.IsInList = False
                End If
                f.Selected = False
            Next
            OnSelectionChangedCall()
        End Sub

        ''' <summary>
        ''' Select all in filtered list
        ''' </summary>
        Public Sub SelectAll()
            For Each f As SelectedFriend In Friends
                If f.IsInList Then
                    f.Selected = True
                End If
            Next
            OnSelectionChangedCall()
        End Sub

        ''' <summary>
        ''' Unselect All
        ''' </summary>
        Public Sub UnselectAll()
            For Each f As SelectedFriend In Friends
                f.Selected = False
            Next
            OnSelectionChangedCall()
        End Sub

        ''' <summary>
        ''' Page Load
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                Dim script As New StringBuilder()
                script.Append("<script>" & vbLf)
                script.Append("function InitFriends() {" & vbLf)
                script.Append("if (graphApiInitialized != true) {" & vbLf)
                script.Append("  setTimeout('" & "InitFriends" & "()', 100);" & vbLf)
                script.Append("  return;" & vbLf)
                script.Append("}" & vbLf)
                script.Append("var friends = FB.api('/me/friends?fields=id, name', function(response) {" & vbLf)
                script.Append("  if (!response || response.error) {" & vbLf)
                script.Append("  } else {" & vbLf)
                script.Append("    var friends = response.data;" & vbLf)
                script.Append("    var stringList = """";" & vbLf)
                script.Append("    for (var i = 0; i < friends.length; i++) {" & vbLf)
                script.Append("       stringList += friends[i].id;" & vbLf)
                script.Append("       stringList += "","";" & vbLf)
                script.Append("       stringList += friends[i].name;" & vbLf)
                script.Append("       stringList += "","";" & vbLf)
                script.Append("    }" & vbLf)
                script.Append("    var tempList = document.getElementById(""" + TempList.ClientID & """);" & vbLf)
                script.Append("    tempList.value = stringList;" & vbLf)
                script.Append("    var initButton = document.getElementById(""" + InitButton.ClientID & """);" & vbLf)
                script.Append("    initButton.click();" & vbLf)
                script.Append("  }" & vbLf)
                script.Append("});" & vbLf)
                script.Append("};")
                script.Append("InitFriends();" & vbLf)
                script.Append("</script>" & vbLf)
                scriptSpan.InnerHtml = script.ToString()
            End If
        End Sub

        ''' <summary>
        ''' Initialize friends list from hidden field created with Java Script SDK. Do not call it directly.
        ''' </summary>
        Protected Sub SelfInitialize(ByVal sender As Object, ByVal e As EventArgs)
            Dim friendsString As String = TempList.Value
            Dim friends__1 As IList(Of SelectedFriend) = New List(Of SelectedFriend)()
            Dim index1 As Integer = 0
            Dim index2 As Integer = 0
            While index1 < friendsString.Length - 1
                index2 = friendsString.IndexOf(",", index1)
                Dim id As String = friendsString.Substring(index1, index2 - index1)
                index1 = index2 + 1
                index2 = friendsString.IndexOf(",", index1)
                Dim name As String = friendsString.Substring(index1, index2 - index1)
                index1 = index2 + 1
                Dim [friend] As New SelectedFriend(Int64.Parse(id), name, False, False, True)
                friends__1.Add([friend])
            End While
            TempList.Value = Nothing
            Friends = friends__1
            FriendsRepeater.DataSource = friends__1
            FriendsRepeater.DataBind()
        End Sub

        ''' <summary>
        ''' One of friend in check box list is selected or unselected
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub FriendCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim friends As IList(Of SelectedFriend) = FilteredList
            Dim friendIndex As Integer = 0
            For Each item As RepeaterItem In FriendsRepeater.Items
                ' read value from checkbox and store it to friend list
                Dim checkBox As CheckBox = DirectCast(item.FindControl("FriendCheckBox"), CheckBox)
                Dim [friend] As SelectedFriend = friends(friendIndex)
                [friend].Selected = checkBox.Checked
                friendIndex += 1
            Next
            OnSelectionChangedCall()
        End Sub


        ''' <summary>
        ''' Get friends from viewstate
        ''' </summary>
        Private Property Friends() As IList(Of SelectedFriend)
            Get
                Return DirectCast(ViewState("SelectedFriends"), List(Of SelectedFriend))
            End Get
            Set(ByVal value As IList(Of SelectedFriend))
                ViewState("SelectedFriends") = value
            End Set
        End Property

        ''' <summary>
        ''' Get filtered list of friends
        ''' </summary>
        Private ReadOnly Property FilteredList() As IList(Of SelectedFriend)
            Get
                Dim filteredList__1 As IList(Of SelectedFriend) = New List(Of SelectedFriend)()
                For Each f As SelectedFriend In Friends
                    If f.IsInList Then
                        filteredList__1.Add(f)
                    End If
                Next
                Return filteredList__1
            End Get
        End Property

        ''' <summary>
        ''' Inform client about changes in selecting
        ''' </summary>
        Private Sub OnSelectionChangedCall()
            FriendsRepeater.DataSource = FilteredList
            FriendsRepeater.DataBind()
            RaiseEvent SelectionChanged(Me, Nothing)
        End Sub
    End Class
End Namespace
