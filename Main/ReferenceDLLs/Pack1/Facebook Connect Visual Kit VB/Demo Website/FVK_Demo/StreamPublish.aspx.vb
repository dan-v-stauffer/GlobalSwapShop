Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Facebook
Imports Facebook.Web
Imports FVK

Namespace FVK_Demo
    Partial Public Class StreamPublish
        Inherits System.Web.UI.Page
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Dim fbWebContext = FacebookWebContext.Current
            If Not fbWebContext.IsAuthorized() Then
                ErrorLabel.Visible = True
                loginbutton1.Visible = True
            Else
                ErrorLabel.Visible = False
                loginbutton1.Visible = False
            End If

            If Not Page.IsPostBack Then
                streampublish1.Name = "Facebook Visual Kit for ASP.NET"
                streampublish1.Href = FVKConfig.AppUrl
                streampublish1.Caption = "{*actor*} is trying Facebook Visual Kit Demo."
                streampublish1.Description = "Facebook Visual Kit is a set of ASP.NET user controls that facilitate the use of common and popular Facebook features by wrapping and hiding the complexity of underlying implementation from the user. This set of controls makes development of Facebook iFrame applications, both in C# and VB.NET programing languages, significantly easier, faster and more organized."
                streampublish1.UserMessage = "ASP.NET library for Facebook development"
                streampublish1.TargetId = Nothing
                '  set to user id to publish on friends' wall (ActorId should be null)
                streampublish1.ActorId = Nothing
                ' page id if user is admin of the page (TargetId should be null)
                Dim properties As New List(Of IJSONSerialize)()
                properties.Add(New PropertyData("Text Property", "This is property description"))
                properties.Add(New LinkedPropertyData("Link Property", "This is property link", FVKConfig.AppUrl))
                streampublish1.Properties = properties

                streampublish1.Media = New ImageData("http://images.vatlab.net/logo.png", FVKConfig.AppUrl)

                Dim linkList As New List(Of LinkData)()
                linkList.Add(New LinkData("action link", FVKConfig.AppUrl))
                linkList.Add(New LinkData("action link2", FVKConfig.AppUrl))
                streampublish1.ActionLinkList = linkList
            End If
        End Sub

        Protected Sub OnPublishStory(ByVal sender As Object, ByVal e As EventArgs)
            ' check if all data are set to publish a story
        End Sub

        Protected Sub OnConfirmStory(ByVal sender As Object, ByVal e As EventArgs)
            Dim postId As String = streampublish1.ReturnedPostId

            If postId IsNot Nothing Then
                PublishLabel.Text = "Story is published"
            Else
                PublishLabel.Text = "Publishing Canceled"
            End If
        End Sub

        Protected Sub MediaDropDown_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            Select Case MediaDropDown.SelectedValue
                Case "Image"
                    streampublish1.Media = New ImageData("http://images.vatlab.net/logo.png", FVKConfig.AppUrl)
                    Exit Select
                Case "Video"
                    streampublish1.Media = New VideoData("http://www.youtube.com/v/fzzjgBAaWZw&hl=en&fs=1", "http://icanhascheezburger.files.wordpress.com/2009/04/funny-pictures-hairless-cat-phones-home.jpg", "http://icanhascheezburger.com", "kitty")
                    Exit Select
                Case "Flash"
                    streampublish1.Media = New FlashData("http://images.vatlab.net/flashiness_fz.swf", "http://images.vatlab.net/flashimage.png", 250, 250, 750, 550)
                    Exit Select

                Case "Mp3"
                    streampublish1.Media = New MP3Data("http://www.looptvandfilm.com/blog/Radiohead%20-%20In%20Rainbows/01%20-%20Radiohead%20-%2015%20Step.MP3", "20 Step", "Radiohead", "In Rainbows")
                    Exit Select
            End Select
        End Sub
    End Class
End Namespace
