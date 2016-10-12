Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Facebook
Imports Facebook.Web
Imports System.Configuration
Imports FVK

Namespace FVK_Demo
    Partial Public Class [Default]
        Inherits System.Web.UI.Page
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Dim fbWebContext = FacebookWebContext.Current
            If Not fbWebContext.IsAuthorized() Then
                Label1.Visible = True
                loginbutton1.Visible = True
            Else
                Label1.Visible = False
                loginbutton1.Visible = False
            End If
        End Sub

        Protected Sub OnConnected(ByVal sender As Object, ByVal e As EventArgs)
            Response.Redirect("DataAccess.aspx")
        End Sub
    End Class
End Namespace
