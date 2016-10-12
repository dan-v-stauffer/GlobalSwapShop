' WARNING: 
' The source code of this class can be used and modified to your particular needs. 
' Sharing the class with unregistered users or using it with unregistered websites 
' or Facebook applications is not allowed and violates the rights of intellectual 
' property. 

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Text

Namespace FVK
    ''' <summary>
    ''' Comment box control uses to enable user of Facebook Connect web site to put comments about a web site 
    ''' or some article on the web site.
    ''' </summary>
    Partial Public Class Comments
        Inherits System.Web.UI.UserControl
        ''' <summary>
        ''' unique id. Should be set if there are more comment box for the same web site
        ''' </summary>
        Public WriteOnly Property Xid() As String
            Set(ByVal value As String)
                m_xid = value
            End Set
        End Property

        ''' <summary>
        ''' The max number of posts to display. Default is 10.
        ''' </summary>
        Public WriteOnly Property PostsNum() As Integer
            Set(ByVal value As Integer)
                m_postsNum = value
            End Set
        End Property

        ''' <summary>
        ''' Width of the control. Default is 550.
        ''' </summary>
        Public WriteOnly Property Width() As Integer
            Set(ByVal value As Integer)
                m_width = value
            End Set
        End Property

        ''' <summary>
        ''' URL of custom CSS style of the control
        ''' </summary>
        Public WriteOnly Property CssUrl() As String
            Set(ByVal value As String)
                m_cssUrl = value
            End Set
        End Property

        ''' <summary>
        ''' title of feed story published when comment is made. Default is title of page.
        ''' </summary>
        Public WriteOnly Property Title() As String
            Set(ByVal value As String)
                m_title = value
            End Set
        End Property

        ''' <summary>
        ''' The URL of page where comment is made.
        ''' </summary>
        Public WriteOnly Property Url() As String
            Set(ByVal value As String)
                m_url = value
            End Set
        End Property

        ''' <summary>
        ''' a rounded box does not appear around each post on a site. Default is false.
        ''' </summary>
        Public WriteOnly Property IsSimple() As Boolean
            Set(ByVal value As Boolean)
                m_isSimple = value
            End Set
        End Property

        ''' <summary>
        ''' if true comments are shown in reverse order. Dafault is false.
        ''' </summary>
        Public WriteOnly Property IsReverse() As Boolean
            Set(ByVal value As Boolean)
                m_isReverse = value
            End Set
        End Property

        ''' <summary>
        ''' if true posting comments will not any notifications. Default is false.
        ''' </summary>
        Public WriteOnly Property IsQuiet() As Boolean
            Set(ByVal value As Boolean)
                m_isQuiet = value
            End Set
        End Property


        ''' <summary>
        ''' Page Load
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                Dim s As New StringBuilder()
                s.Append("<fb:comments ")
                If m_xid IsNot Nothing Then
                    s.Append("xid='")
                    s.Append(m_xid)
                    s.Append("' ")
                End If
                s.Append("numposts='")
                s.Append(m_postsNum.ToString())
                s.Append("' ")

                s.Append("width='")
                s.Append(m_width.ToString())
                s.Append("' ")

                If m_cssUrl IsNot Nothing Then
                    s.Append("css='")
                    s.Append(m_cssUrl)
                    s.Append("' ")
                End If

                If m_title IsNot Nothing Then
                    s.Append("title='")
                    s.Append(m_title)
                    s.Append("' ")
                End If

                If m_url IsNot Nothing Then
                    s.Append("url='")
                    s.Append(m_url)
                    s.Append("' ")
                End If

                If m_isSimple Then
                    s.Append("simple='1' ")
                End If

                If m_isReverse Then
                    s.Append("reverse='1' ")
                End If

                If m_isQuiet Then
                    s.Append("quiet='1' ")
                End If

                s.Append("></fb:comments>")

                commentsSpan.InnerHtml = s.ToString()
            End If
        End Sub




        ''' <summary>
        ''' Private members
        ''' </summary>

        Private m_xid As String = Nothing
        Private m_postsNum As Integer = 10
        Private m_width As Integer = 550
        Private m_cssUrl As String = Nothing
        Private m_title As String = Nothing
        Private m_url As String = Nothing
        Private m_isSimple As Boolean = False
        Private m_isReverse As Boolean = False
        Private m_isQuiet As Boolean = False
    End Class
End Namespace
