Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Facebook

Namespace FVK_Demo
    Partial Public Class InvitedFriends
        Inherits System.Web.UI.Page
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                Dim friendIds As String = Request.QueryString("ids[]")
                If friendIds IsNot Nothing Then
                    FriendIdsLabel.Text = friendIds
                    FriendsNamesLabel.Text = ""
                    Try
                        Dim facebook As New FacebookApp()
                        Dim friendsArray As JsonArray = DirectCast(facebook.Query("select name from user where uid in (" & friendIds & ")"), JsonArray)
                        For Each f As JsonObject In friendsArray
                            FriendsNamesLabel.Text += DirectCast(f("name"), String) & ", "
                        Next
                    Catch generatedExceptionName As Exception
                        FriendsNamesLabel.Text = "Error on getting friends' names by calling FQL"
                    End Try
                Else
                    FriendIdsLabel.Text = "No one of friends are invited"
                End If
            End If
        End Sub
    End Class
End Namespace
