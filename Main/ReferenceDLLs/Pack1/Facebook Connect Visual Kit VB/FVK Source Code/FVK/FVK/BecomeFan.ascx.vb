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
Imports System.Configuration
Imports System.Text

Namespace FVK
    ''' <summary>
    ''' This control uses to enable user to became fan of the Facebook application, 
    ''' Facebook Connect web site or Facebook Page. 
    ''' </summary>

    <Obsolete("You should use Facebook Like Box control instead")> _
    Partial Public Class BecomeFan
        Inherits System.Web.UI.UserControl
        ''' <summary>
        ''' Width of control
        ''' </summary>
        Public WriteOnly Property Width() As Integer
            Set(ByVal value As Integer)
                m_width = value
            End Set
        End Property

        ''' <summary>
        ''' Show stories published on wall of application or Facebook page
        ''' </summary>
        Public WriteOnly Property ShowStream() As Boolean
            Set(ByVal value As Boolean)
                m_showStream = value
            End Set
        End Property

        ''' <summary>
        ''' Number of fans to display
        ''' </summary>
        Public WriteOnly Property ConnectionsCount() As Integer
            Set(ByVal value As Integer)
                m_connectionsCount = value
            End Set
        End Property

        ''' <summary>
        ''' Url of custom defined CSS file
        ''' </summary>
        Public WriteOnly Property CssUrl() As String
            Set(ByVal value As String)
                m_cssUrl = value
            End Set
        End Property

        ''' <summary>
        ''' Page Load
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                Dim appId As String = FVKConfig.AppId
                Dim s As New StringBuilder()
                s.Append("<fb:fan profile_id='")
                s.Append(appId.ToString())
                s.Append("' stream='")
                If m_showStream Then
                    s.Append("1")
                Else
                    s.Append("0")
                End If
                s.Append("' connections='")
                s.Append(m_connectionsCount)
                s.Append("' width='")
                s.Append(m_width)
                s.Append("'")
                If m_cssUrl IsNot Nothing Then
                    s.Append(" css='")
                    s.Append(m_cssUrl)
                    s.Append("'")
                End If
                s.Append("></fb:fan>")

                fanspan.InnerHtml = s.ToString()
            End If
        End Sub


        ''' <summary>
        ''' Private members
        ''' </summary>
        Private m_width As Integer = 300
        Private m_showStream As Boolean = False
        Private m_connectionsCount As Integer = 0
        Private m_cssUrl As String = Nothing
    End Class
End Namespace
