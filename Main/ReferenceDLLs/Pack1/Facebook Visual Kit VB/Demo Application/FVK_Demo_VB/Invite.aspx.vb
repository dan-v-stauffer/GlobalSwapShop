Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Facebook.Web
Imports FVK

Namespace FVK_Demo
    Partial Public Class Invite
        Inherits Page
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            invite1.ActionUrl = FVKConfig.AppUrl + "InvitedFriends.aspx"
        End Sub
    End Class
End Namespace
