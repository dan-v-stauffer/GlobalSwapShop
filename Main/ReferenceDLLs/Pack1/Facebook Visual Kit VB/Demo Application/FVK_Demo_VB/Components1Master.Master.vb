Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace FVK_Demo
    Partial Public Class Components1Master
        Inherits System.Web.UI.MasterPage

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                tab2.AddTab("Request Dialog", "RequestDialog.aspx", 100)
                tab2.AddTab("Stream Publish", "StreamPublish.aspx", 120)
                tab2.AddTab("Permissions", "Permissions.aspx", 100)
                tab2.AddTab("Like Box", "LikeBox.aspx", 100)
                tab2.AddTab("Like Button", "LikeButton.aspx", 100)
                tab2.AddTab("Send Button", "SendButton.aspx", 100)

                tab2.Distance = 5
                tab2.BorderWidth = 10
            End If
        End Sub

    End Class
End Namespace
