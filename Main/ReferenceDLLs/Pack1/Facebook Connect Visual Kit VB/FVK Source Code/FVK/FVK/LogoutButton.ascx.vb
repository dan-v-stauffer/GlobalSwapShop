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
    ''' Logout Button is used to log out from Facebook. If user is already logged on Facebook, pressing 
    ''' on the Login Button will result in executing of event handler where additional code can be executed
    ''' </summary>
    Partial Public Class LogoutButton
        Inherits System.Web.UI.UserControl
        ''' <summary>
        ''' Inform client about logout
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Public Delegate Sub LogoutHandler(ByVal sender As Object, ByVal e As EventArgs)
        Public Event LogoutCalled As LogoutHandler

        ''' <summary>
        ''' Button Title
        ''' </summary>
        Public WriteOnly Property Title() As String
            Set(ByVal value As String)
                m_title = value
            End Set
        End Property

        ''' <summary>
        ''' CSS class of the button
        ''' </summary>
        Public WriteOnly Property CssClass() As String
            Set(ByVal value As String)
                m_cssClass = value
            End Set
        End Property

        ''' <summary>
        ''' CSS style of the style
        ''' </summary>
        Public WriteOnly Property CssStyle() As String
            Set(ByVal value As String)
                m_cssStyle = value
            End Set
        End Property

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Dim html As New StringBuilder()
            Dim spanId As String = logoutSpan.ClientID
            html.Append("<script>" & vbLf)
            html.Append("  function DoLogout" & spanId & "() {" & vbLf)
            html.Append("    FB.logout(function(response) {" & vbLf)
            html.Append("      var button = document.getElementById('" + OnLogoutButton1.ClientID & "');" & vbLf)
            html.Append("      button.click();" & vbLf)
            html.Append("    });" & vbLf)
            html.Append("  }" & vbLf)
            html.Append("</script>" & vbLf)
            html.Append("<input type=""button"" class=""" & m_cssClass & """ onclick=""DoLogout" & spanId & "()"" value=""" & m_title & """ style=""" & m_cssStyle & "; cursor:pointer"" />" & vbLf)
            logoutSpan.InnerHtml = html.ToString()
        End Sub

        Protected Sub OnLogoutButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
            RaiseEvent LogoutCalled(sender, e)
        End Sub

        Private m_cssClass As String = "button"
        Private m_cssStyle As String = "font-weight:bold"
        Private m_title As String = "Logout"
    End Class
End Namespace
