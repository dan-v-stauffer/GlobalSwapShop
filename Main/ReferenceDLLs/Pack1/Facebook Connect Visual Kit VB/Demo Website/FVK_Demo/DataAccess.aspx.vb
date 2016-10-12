Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Facebook
Imports Facebook.Web

Namespace FVK_Demo
    Partial Public Class DataAccess
        Inherits System.Web.UI.Page
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Dim fbWebContext = FacebookWebContext.Current
            If Not fbWebContext.IsAuthorized() Then
                ErrorLabel.Text = "Facebook session is not established. Please login by pressing login button:"
                ErrorLabel.Visible = True
                loginbutton1.Visible = True
                Return
            End If
            ErrorLabel.Visible = False
            loginbutton1.Visible = False

            Dim facebook = New FacebookWebClient(fbWebContext)

            ' get user object
            Try

                Dim user As JsonObject = DirectCast(facebook.[Get]("me"), JsonObject)
                UserIdLabel.Text = DirectCast(user("id"), String)
                UserNameLabel.Text = DirectCast(user("name"), String)
                UserEmailLabel.Text = DirectCast(user("email"), String)
            Catch generatedExceptionName As Exception
                ErrorLabel.Text = "Error accessing user object"
                ErrorLabel.Visible = True
            End Try

            ' get friend list
            Try
                Dim friends As JsonObject = DirectCast(facebook.[Get]("me/friends"), JsonObject)
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
                ErrorLabel.Text = "Error accession friends list"
                ErrorLabel.Visible = True
            End Try
        End Sub
    End Class
End Namespace
