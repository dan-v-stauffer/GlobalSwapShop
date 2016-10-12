Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace FVK_Demo
    Partial Public Class Components3Master
        Inherits System.Web.UI.MasterPage
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                tab4.AddTab("Bookmark Button", "BookmarkButton.aspx", 120)
                tab4.AddTab("Fan Box", "BecomeFan.aspx", 120)
                tab4.AddTab("Share Button", "ShareButton.aspx", 120)
                tab4.AddTab("Facebook Tabs", "Tabs.aspx", 120)
                tab4.AddTab("Stream Publish to Friends", "StreamPublishFriendList.aspx", 160)
            End If
        End Sub
    End Class
End Namespace
