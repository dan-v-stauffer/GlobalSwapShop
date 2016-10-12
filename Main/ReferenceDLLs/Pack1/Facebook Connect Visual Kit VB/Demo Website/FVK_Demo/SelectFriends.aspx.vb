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
    Partial Public Class SelectFriends
        Inherits System.Web.UI.Page
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                selectfriends1.Rows = 4
                selectfriends1.Columns = 3
                selectfriends1.Visible = True
            End If

            Dim fbWebContext = FacebookWebContext.Current
            If Not fbWebContext.IsAuthorized() Then
                ErrorLabel.Visible = True
                loginbutton1.Visible = True
            Else
                ErrorLabel.Visible = False
                loginbutton1.Visible = False
            End If
        End Sub

        Protected Sub OnSelectedFriends(ByVal sender As Object, ByVal e As EventArgs)
            SelectedFriendsLabel.Text = "Selected Friends: " & Conversions.FriendsDataListToNamesString(selectfriends1.GetSelectedFriends())
        End Sub

        Protected Sub FilterIfStartsWithButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            selectfriends1.FilterByNameStartsWith(FilterTextBox.Text)
        End Sub

        Protected Sub FilterIfContainsButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            selectfriends1.FilterByNameContains(FilterTextBox.Text)
        End Sub

        Protected Sub SelectAllButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            selectfriends1.SelectAll()
        End Sub

        Protected Sub UnselectAllButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            selectfriends1.UnselectAll()
        End Sub


    End Class
End Namespace
