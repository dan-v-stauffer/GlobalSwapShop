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
    ''' Facebook Style Tab control uses to make tabs with the same style as Facebook has to make Facebook iFrame 
    ''' applications adapted on Facebook style more easier. The control can be included more then once without 
    ''' interfering on each other.
    ''' </summary>
    Partial Public Class TabControl
        Inherits System.Web.UI.UserControl
        ''' <summary>
        ''' Add new tab
        ''' </summary>
        ''' <param name="name">Name of the tab</param>
        ''' <param name="url">Location of target aspx file</param>
        ''' <param name="width">Width of the tab</param>
        Public Sub AddTab(ByVal name As String, ByVal url As String, ByVal width As Integer)
            If tabs Is Nothing Then
                tabs = New List(Of TabData)()
            End If
            tabs.Add(New TabData(name, url, width))
        End Sub

        ''' <summary>
        ''' Width of whole tab control
        ''' </summary>
        Public WriteOnly Property Width() As Integer
            Set(ByVal value As Integer)
                m_width = value
            End Set
        End Property

        ''' <summary>
        ''' Define how much of tabs are on left side of screen, the rest will be on right side
        ''' </summary>
        Public WriteOnly Property NumOfRightTabs() As Integer
            Set(ByVal value As Integer)
                m_numOfRightTabs = value
            End Set
        End Property

        ''' <summary>
        ''' Distance between tabs
        ''' </summary>
        Public WriteOnly Property Distance() As Integer
            Set(ByVal value As Integer)
                m_distance = value
            End Set
        End Property

        ''' <summary>
        ''' Distance between first tab and begginng of line, between last tab and end of line
        ''' </summary>
        Public WriteOnly Property BorderWidth() As Integer
            Set(ByVal value As Integer)
                m_borderWidth = value
            End Set
        End Property



        ''' <summary>
        ''' Refresh display of control
        ''' </summary>
        Public Sub Refresh()
            If tabs Is Nothing Then
                Throw New Exception("There are no defined tabs !!")
            End If

            Dim tabIndexStr As String = Request.QueryString(TabIndexName)
            If tabIndexStr IsNot Nothing Then
                tabIndex = Int32.Parse(tabIndexStr)
                SavedTabIndex = tabIndex
            Else
                tabIndex = SavedTabIndex
            End If

            Dim str As New StringBuilder()
            'str.Append("<table style=\"padding:0px;\" cellpadding=\"0px\" cellspacing=\"0px\" width=\"" + width + "px\">");
            'str.Append("<tr>");
            str.Append("<div style=""border: solid 1px white; border-bottom-color: #898989; height:20px; width:" & m_width & "px"">" & vbLf)
            str.Append("<div style=""float:left; border: solid 1px white; height:15px; width:" & m_borderWidth & "px""><span style=""width:" & m_borderWidth & "px""></span></div>" & vbLf)

            Dim i As Integer = 0
            For Each t As TabData In tabs
                str.Append("<div style=""float:left; width:" & t.Width.ToString() & "px"" class=""")

                If i <> tabIndex Then
                    str.Append("pagetab""")
                Else
                    str.Append("pagetabactive""")
                End If

                str.Append(" >")
                str.Append("<a href=""" + t.Url & "?" & TabIndexName & "=" & i & RestIndexes & """ style=""color:")

                If i <> tabIndex Then
                    str.Append("Black")
                Else
                    str.Append("White")
                End If

                str.Append(""">" + t.Name & "</a>")
                str.Append("</div>" & vbLf)

                i += 1

                If i = tabs.Count - m_numOfRightTabs Then
                    str.Append("<div style=""border: solid 1px white; height:15px; float:left; width:" & MiddleWidth.ToString() & "px""></div>" & vbLf)
                ElseIf i < tabs.Count Then
                    str.Append("<div style=""border: solid 1px white; height:15px; float:left; width:" & m_distance.ToString() & "px""></div>" & vbLf)


                End If
            Next
            If m_numOfRightTabs = 0 Then
                str.Append("<div style=""float:left; width:" & MiddleWidth.ToString() & "px""></div>" & vbLf)
            End If
            str.Append("<div style=""float:left; width:" & m_borderWidth.ToString() & "px""></div>" & vbLf)


            str.Append("</div>")
            'str.Append("<div style=\"border-style:solid; border-width:1px; border-color:red; border-top-color:#898989; margin-top:0px; width:" + width + "px;\"></div><br />\n");

            TabSpan.InnerHtml = str.ToString()
        End Sub

        ''' <summary>
        ''' Page Load
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                Refresh()
            End If
        End Sub


        ''' <summary>
        ''' Private members
        ''' </summary>

        Private m_width As Integer = 755
        Private m_distance As Integer = 5
        Private m_borderWidth As Integer = 10
        Private m_numOfRightTabs As Integer = 0
        Private tabIndex As Integer = 0
        Private tabs As List(Of TabData)

        Private ReadOnly Property TabsWidth() As Integer
            Get
                Dim width As Integer = 0
                If tabs IsNot Nothing Then
                    For Each t As TabData In tabs
                        width += t.Width + m_distance + 6
                    Next
                End If
                Return width
            End Get
        End Property

        Private ReadOnly Property MiddleWidth() As Integer
            Get
                Return m_width - TabsWidth - 2 * m_borderWidth + m_distance
            End Get
        End Property

        Private ReadOnly Property TabIndexName() As String
            Get
                Return Me.ID & "tabIndex"
            End Get
        End Property

        Private ReadOnly Property TabIndexMap() As Dictionary(Of String, Integer)
            Get
                If HttpContext.Current.Items("TabIndexMap") Is Nothing Then
                    HttpContext.Current.Items("TabIndexMap") = New Dictionary(Of String, Integer)()
                End If
                Return DirectCast(HttpContext.Current.Items("TabIndexMap"), Dictionary(Of String, Integer))
            End Get
        End Property

        Private Property SavedTabIndex() As Integer
            Get
                If TabIndexMap.ContainsKey(TabIndexName) Then
                    Return CInt(TabIndexMap(TabIndexName))
                End If

                Return 0
            End Get
            Set(ByVal value As Integer)
                TabIndexMap(TabIndexName) = value
            End Set
        End Property

        Private ReadOnly Property RestIndexes() As String
            Get
                Dim output As New StringBuilder()
                Dim keyList As IList(Of String) = TabIndexMap.Keys.ToList()
                Dim indexList As IList(Of Integer) = TabIndexMap.Values.ToList()
                For i As Integer = 0 To keyList.Count - 1
                    If keyList(i) <> TabIndexName Then
                        output.Append(keyList(i))
                        output.Append("=")
                        output.Append(indexList(i))
                        output.Append("&")
                    End If
                Next
                If output.Length > 0 Then
                    Return "&" & output.ToString().Substring(0, output.Length - 1)
                End If
                Return ""
            End Get
        End Property
    End Class
End Namespace
