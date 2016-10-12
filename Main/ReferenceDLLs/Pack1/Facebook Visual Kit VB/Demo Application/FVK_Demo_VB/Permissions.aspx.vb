Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Facebook.Web
Imports FVK

Namespace FVK_Demo
    Partial Public Class Permissions
        Inherits Page
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        End Sub

        Protected Sub OnAddPermission(ByVal sender As Object, ByVal e As EventArgs)
            PermAddedLabel.Text = "Permissions Added: "
            For Each perm As PermissionEnum In permissions1.ConfirmedPermissions
                PermAddedLabel.Text += perm.ToString() & " "
            Next
        End Sub

    End Class
End Namespace

