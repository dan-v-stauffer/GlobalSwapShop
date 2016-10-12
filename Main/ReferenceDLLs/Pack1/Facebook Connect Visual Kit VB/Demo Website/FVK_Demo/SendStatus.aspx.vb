Imports System.Collections
Imports System.Configuration
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
    Partial Public Class SendStatus
        Inherits System.Web.UI.Page
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim fbWebContext = FacebookWebContext.Current
            If Not fbWebContext.IsAuthorized() Then
                ErrorLabel.Visible = True
                loginbutton1.Visible = True
            Else
                ErrorLabel.Visible = False
                loginbutton1.Visible = False
            End If
        End Sub

        Protected Sub OnSendStatus(ByVal sender As Object, ByVal e As EventArgs)
            SendStatusHandlerLabel.Text = "Send Status Handler Executed"
        End Sub
    End Class
End Namespace
