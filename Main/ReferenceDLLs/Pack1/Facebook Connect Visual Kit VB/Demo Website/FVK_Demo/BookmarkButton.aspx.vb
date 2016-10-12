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
    Partial Public Class BookmarkButton
        Inherits System.Web.UI.Page
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        End Sub

        Protected Sub BookmarkAdded(ByVal sender As Object, ByVal e As EventArgs)
            BookmarkedLabel.Visible = True
        End Sub
    End Class
End Namespace
