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

Namespace FVK
    ''' <summary>
    ''' Send user status control uses to publish user messages on user wall directly from Facebook iFrame 
    ''' Application. Before publishing user has to enable sending of status by pressing a link on the control.
    ''' </summary>
    Partial Public Class SendUserStatus
        Inherits System.Web.UI.UserControl
        ''' <summary>
        ''' Inform client about sent status
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Public Delegate Sub SendStatusHandler(ByVal sender As Object, ByVal e As EventArgs)
        Public Event SendStatusCalled As SendStatusHandler


        ''' <summary>
        ''' Page Load
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                Dim id As String = StatusSentButton.ClientID + "Control"
                ButtonSpan.InnerHtml = "<input ID=""" & id & """ value=""Post"" type=""button"" onclick=""OnSendStatus(this)"" class=""button"" style=""width:60px"" />"
            End If
        End Sub

        ''' <summary>
        ''' Status sent
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub StatusSent(ByVal sender As Object, ByVal e As EventArgs)
            SendStatusText.Text = "Successful Post"
            SendStatusText.ForeColor = System.Drawing.Color.Green

            ' call event on page
            RaiseEvent SendStatusCalled(Me, Nothing)
        End Sub

        ''' <summary>
        ''' Status cannot be sent
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub StatusCannotBeSent(ByVal sender As Object, ByVal e As EventArgs)
            SendStatusText.Text = "The same status is already post or send status is not allowed."
            SendStatusText.ForeColor = System.Drawing.Color.Red
        End Sub
    End Class
End Namespace
