Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Facebook
Imports Facebook.Web

Namespace FVK_Demo
    Partial Public Class InvitedFriends
        Inherits System.Web.UI.Page
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Dim fbWebContext = FacebookWebContext.Current
            If Not fbWebContext.IsAuthorized() Then
                ErrorLabel.Visible = True
                ErrorLabel.Text = "Facebook session is not established. Please login by pressing login button:"
                loginbutton1.Visible = True
                Return
            Else
                ErrorLabel.Visible = False
                loginbutton1.Visible = False
            End If

            If Not Page.IsPostBack Then
                Dim friendIds As String = Request.QueryString("ids[]")
                If friendIds IsNot Nothing Then
                    FriendIdsLabel.Text = friendIds
                    FriendsNamesLabel.Text = ""
                    Try
                        Dim facebook = New FacebookWebClient(fbWebContext)
                        Dim friendsArray As JsonArray = DirectCast(facebook.Query("select name from user where uid in (" & friendIds & ")"), JsonArray)
                        For Each f As JsonObject In friendsArray
                            FriendsNamesLabel.Text += DirectCast(f("name"), String) & ", "
                        Next
                    Catch generatedExceptionName As Exception
                        ErrorLabel.Text = "Error on getting friends' names by calling FQL"
                        ErrorLabel.Visible = True
                    End Try
                Else
                    ErrorLabel.Text = "No one of friends are invited"
                    ErrorLabel.Visible = True
                End If
            End If
        End Sub
    End Class
End Namespace
