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
    ''' This control is used to allow users of the web site to become fan of the Facebook page, 
    ''' see messages from the page wall and people who are fans of the page.
    ''' </summary>
    Partial Public Class LikeBox
        Inherits System.Web.UI.UserControl
        ''' <summary>
        ''' Facebook Page ID.
        ''' </summary>
        Public WriteOnly Property PageId() As String
            Set(ByVal value As String)
                m_pageId = value
            End Set
        End Property

        ''' <summary>
        ''' Width of the like box in pixels. Default value is 292.
        ''' </summary>
        Public WriteOnly Property Width() As Integer
            Set(ByVal value As Integer)
                m_width = value
            End Set
        End Property

        ''' <summary>
        ''' Height of the like box in pixels. Default value is 556.
        ''' </summary>
        Public WriteOnly Property Height() As Integer
            Set(ByVal value As Integer)
                m_height = value
            End Set
        End Property

        ''' <summary>
        ''' Number of fans to display. Default value is 10.
        ''' </summary>
        Public WriteOnly Property FansCount() As Integer
            Set(ByVal value As Integer)
                m_fansCount = value
            End Set
        End Property

        ''' <summary>
        ''' Set to true to show the massages from the Page Wall.
        ''' </summary>
        Public WriteOnly Property ShowStream() As Boolean
            Set(ByVal value As Boolean)
                m_showStream = value
            End Set
        End Property

        ''' <summary>
        ''' Set to true to show the header.
        ''' </summary>
        Public WriteOnly Property ShowHeader() As Boolean
            Set(ByVal value As Boolean)
                m_showHeader = value
            End Set
        End Property

        ''' <summary>
        ''' Page Load
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Refresh()
        End Sub

        '*
        '         * string renders component on the web page, depending on defined settings.
        '         

        Private Sub Refresh()
            Dim html As New StringBuilder()
            If m_pageId Is Nothing Then
                m_pageId = FVKConfig.AppId
            End If
            html.Append("<fb:like-box profile_id='" & m_pageId & "' ")
            If m_width <> 292 Then
                html.Append("width='" & m_width.ToString() & "' ")
            End If
            If m_height <> 556 Then
                html.Append("height='" & m_height.ToString() & "' ")
            End If
            If m_fansCount <> 10 Then
                html.Append("connections='" & m_fansCount.ToString() & "' ")
            End If
            If m_showStream = False Then
                html.Append("stream='false' ")
            End If
            If m_showHeader = False Then
                html.Append("header='false' ")
            End If
            html.Append("></fb:like-box>" & vbLf)

            likeSpan.InnerHtml = html.ToString()
        End Sub


        'private members
        Private m_pageId As String = Nothing
        Private m_width As Integer = 292
        Private m_height As Integer = 556
        Private m_fansCount As Integer = 10
        Private m_showStream As Boolean = True
        Private m_showHeader As Boolean = True
    End Class
End Namespace
