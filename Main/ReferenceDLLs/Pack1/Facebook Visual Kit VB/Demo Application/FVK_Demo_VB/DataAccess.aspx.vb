Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Facebook

Namespace FVK_Demo
    Partial Public Class DataAccess
        Inherits Page
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                Dim facebook As New FacebookApp()
                If facebook.Session Is Nothing Then
                    ErrorLabel.Visible = True
                    Return
                End If

                ' get user object
                Try
                    Dim user As JsonObject = DirectCast(facebook.Api("me"), JsonObject)
                    UserIdLabel.Text = DirectCast(user("id"), String)
                    UserNameLabel.Text = DirectCast(user("name"), String)
                    UserEmailLabel.Text = DirectCast(user("email"), String)
                Catch generatedExceptionName As Exception
                    UserIdLabel.Text = "Error accessing user object"
                End Try

                ' get friend list
                Try
                    Dim friends As JsonObject = DirectCast(facebook.Api("me/friends"), JsonObject)
                    Dim friendsList As JsonArray = DirectCast(friends("data"), JsonArray)

                    ' print max 5 friends
                    FriendsLabel.Text = ""
                    Dim counter As Integer = 0
                    For Each f As JsonObject In friendsList
                        FriendsLabel.Text += DirectCast(f("name"), String) & ", "
                        counter += 1
                        If counter = 5 Then
                            Exit For
                        End If
                    Next
                Catch generatedExceptionName As Exception
                    FriendsLabel.Text = "Error accession friends list"

                End Try
            End If
        End Sub
    End Class
End Namespace
