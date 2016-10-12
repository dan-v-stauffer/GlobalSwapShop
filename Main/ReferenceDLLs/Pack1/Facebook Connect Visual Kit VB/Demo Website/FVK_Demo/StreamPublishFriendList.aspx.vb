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
Imports System.Collections.Generic
Imports Facebook
Imports Facebook.Web
Imports FVK

Namespace FVK_Demo
    Partial Public Class StreamPublishFriendList
        Inherits System.Web.UI.Page
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Dim fbWebContext = FacebookWebContext.Current
            If Not fbWebContext.IsAuthorized() Then
                ErrorLabel.Visible = True
                loginbutton1.Visible = True
            Else
                ErrorLabel.Visible = False
                loginbutton1.Visible = False

                ' set friend list
                Dim friends As IList(Of FriendData) = New List(Of FriendData)()
                Dim count As Integer = 0
                Dim facebook = New FacebookWebClient(fbWebContext)
                Dim friendsData As JsonObject = DirectCast(facebook.[Get]("me/friends"), JsonObject)
                Dim friendsList As JsonArray = DirectCast(friendsData("data"), JsonArray)
                For Each f As JsonObject In friendsList
                    Dim id As Long = Int64.Parse(DirectCast(f("id"), String))
                    Dim name As String = DirectCast(f("name"), String)
                    friends.Add(New FriendData(id, name))
                    count += 1
                    If count = 4 Then
                        Exit For
                    End If
                Next
                streampublish1.Friends = friends
            End If

            If Not Page.IsPostBack Then
                streampublish1.Visible = True
                streampublish1.BoxText = "Want to inform your friends about Facebook Visual Kit. " & "Make sure they see the info by posting it on their wall."
                streampublish1.MainImageUrl = "http://images.vatlab.net/logo.png"
                streampublish1.Name = "Facebook Visual Kit for ASP.NET"
                streampublish1.Href = FVKConfig.AppUrl
                streampublish1.Caption = "{*actor*} is trying Facebook Visual Kit Demo."
                streampublish1.Description = "Facebook Visual Kit is a set of ASP.NET user controls that facilitate the use of common and popular Facebook features by wrapping and hiding the complexity of underlying implementation from the user. This set of controls makes development of Facebook iFrame applications, both in C# and VB.NET programing languages, significantly easier, faster and more organized."
                streampublish1.UserMessage = "ASP.NET library for Facebook development"

                Dim properties As New List(Of IJSONSerialize)()
                properties.Add(New PropertyData("Text Property", "This is property description"))
                properties.Add(New LinkedPropertyData("Link Property", "This is property link", FVKConfig.AppUrl))
                streampublish1.Properties = properties

                streampublish1.Media = New ImageData("http://images.vatlab.net/logo.png", FVKConfig.AppUrl)
            End If
        End Sub

        Protected Sub OnPublishStory(ByVal sender As Object, ByVal e As EventArgs)
            ' stream publish popup is open
        End Sub

        Protected Sub OnConfirmStory(ByVal sender As Object, ByVal e As EventArgs)
            Dim postId As String = streampublish1.ReturnedPostId
            If postId IsNot Nothing Then
                PublishLabel.Text = "Story is published"
            Else
                PublishLabel.Text = "Publishing Canceled"
            End If
        End Sub
    End Class
End Namespace
