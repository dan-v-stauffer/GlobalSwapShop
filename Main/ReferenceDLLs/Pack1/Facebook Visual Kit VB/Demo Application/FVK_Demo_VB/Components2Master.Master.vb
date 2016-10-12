Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace FVK_Demo
    Partial Public Class Components2Master
        Inherits System.Web.UI.MasterPage
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                tab3.AddTab("Invite Friends", "Invite.aspx", 120)
                tab3.AddTab("Invite F. Small", "InviteSmall.aspx", 120)
                tab3.AddTab("Comments", "Comments.aspx", 120)
                tab3.AddTab("Select Friends", "SelectFriends.aspx", 120)
                tab3.AddTab("Send Status", "SendStatus.aspx", 120)

                tab3.Distance = 5
                tab3.BorderWidth = 10
            End If
        End Sub
    End Class
End Namespace
