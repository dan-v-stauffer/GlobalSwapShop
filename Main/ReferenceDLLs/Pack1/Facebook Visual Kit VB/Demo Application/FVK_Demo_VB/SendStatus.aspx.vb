Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Facebook.Web

Namespace FVK_Demo
    Partial Public Class SendStatus
        Inherits Page
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        End Sub

        Protected Sub OnSendStatus(ByVal sender As Object, ByVal e As EventArgs)
            SendStatusHandlerLabel.Text = "Send Status Handler Executed"
        End Sub
    End Class
End Namespace

