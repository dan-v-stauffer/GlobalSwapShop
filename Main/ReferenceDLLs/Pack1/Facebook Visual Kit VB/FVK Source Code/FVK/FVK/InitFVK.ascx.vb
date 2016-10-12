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
    Partial Public Class InitFVK
        Inherits System.Web.UI.UserControl
        ''' <summary>
        ''' Set Language code of all XFBML based controls. Default value is 'en_US'.
        ''' You can find all language codes at: http://www.facebook.com/translations/FacebookLocales.xml
        ''' </summary>
        Public WriteOnly Property Language() As String
            Set(ByVal value As String)
                m_language = value
            End Set
        End Property

        ''' <summary>
        ''' Check login status. Default is true
        ''' </summary>
        Public WriteOnly Property CheckLoginStatus() As Boolean
            Set(ByVal value As Boolean)
                m_checkLoginStatus = value
            End Set
        End Property

        ''' <summary>
        ''' User Cookie. Default is true
        ''' </summary>
        Public WriteOnly Property UseCookie() As Boolean
            Set(ByVal value As Boolean)
                m_useCookie = value
            End Set
        End Property

        ''' <summary>
        ''' Page Load
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Dim html As New StringBuilder()
            html.Append("<div id='fb-root'></div>" & vbLf)
            html.Append("<script>" & vbLf)
            html.Append("var graphApiInitialized = false;" & vbLf)
            html.Append("  window.fbAsyncInit = function() {" & vbLf)
            html.Append("    FB.init({" & vbLf)
            html.Append("      appId  : '" + FVKConfig.AppId & "'," & vbLf)
            html.Append("      status : " & m_checkLoginStatus.ToString().ToLower() & "," & vbLf)
            html.Append("      cookie : " & m_useCookie.ToString().ToLower() & "," & vbLf)
            html.Append("      xfbml  : true" & vbLf)
            html.Append("    });" & vbLf)
            html.Append("    graphApiInitialized = true;" & vbLf)
            html.Append("  };" & vbLf)
            html.Append("  (function() {" & vbLf)
            html.Append("    var e = document.createElement('script');" & vbLf)
            html.Append("    e.src = document.location.protocol + '//connect.facebook.net/" & m_language & "/all.js';" & vbLf)
            html.Append("    e.async = true;" & vbLf)
            html.Append("    document.getElementById('fb-root').appendChild(e);" & vbLf)
            html.Append("  }());" & vbLf)

            html.Append("</script>" & vbLf)

            contentSpan.InnerHtml = html.ToString()
        End Sub

        Private m_language As String = "en_US"
        Private m_checkLoginStatus As Boolean = True
        Private m_useCookie As Boolean = True
    End Class
End Namespace
