Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Facebook.Web
Imports FVK

Namespace FVK_Demo
    Partial Public Class SelectFriends
        Inherits Page
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

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
