Imports System.Data
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Xml.Linq
Imports Facebook
Imports Facebook.Web
Imports FVK

Namespace FVK_Demo
    Partial Public Class Permissions
        Inherits System.Web.UI.Page
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Dim fbWebContext = FacebookWebContext.Current
            If Not fbWebContext.IsAuthorized() Then
                ErrorLabel.Visible = True
                loginbutton1.Visible = True
            Else
                ErrorLabel.Visible = False
                loginbutton1.Visible = False
            End If

        End Sub

        Protected Sub OnAddPermission(ByVal sender As Object, ByVal e As EventArgs)
            PermAddedLabel.Text = "Permissions Added: "
            For Each perm As PermissionEnum In permissions1.ConfirmedPermissions
                PermAddedLabel.Text += perm.ToString() & " "
            Next
        End Sub
    End Class
End Namespace
