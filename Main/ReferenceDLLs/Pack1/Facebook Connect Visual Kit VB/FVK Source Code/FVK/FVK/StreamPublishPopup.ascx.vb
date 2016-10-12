' WARNING: 
' The source code of this class can be used and modified to your particular needs. 
' Sharing the class with unregistered users or using it with unregistered websites 
' or Facebook applications is not allowed and violates the rights of intellectual 
' property. 

Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Text

Namespace FVK
    ''' <summary>
    ''' Facebook Stream publish popup uses to publish stories on user wall, friends' wall or on page wall if user 
    ''' is admin.This ASP.NET control is wrapper around JavaScript method FB.Connect.streamPublish which hide all 
    ''' underlaying stuff as conversion to JSON format and packaging media attachments.
    ''' </summary>
    Partial Public Class StreamPublishPopup
        Inherits System.Web.UI.UserControl
        Public Delegate Sub PublishCalledHandler(ByVal sender As Object, ByVal e As EventArgs)
        Public Delegate Sub ConfirmCalledHandler(ByVal sender As Object, ByVal e As EventArgs)

        ''' <summary>
        ''' Set type of command control(link, button, auto_open). If auto_open is
        ''' set permission popup is open on page load. Default = button.
        ''' </summary>
        Public WriteOnly Property CommandType() As String
            Set(ByVal value As String)
                Select Case value
                    Case "link"
                        m_commandType = CommandTypeEnum.Link
                        Exit Select
                    Case "button"
                        m_commandType = CommandTypeEnum.Button
                        Exit Select
                    Case "auto_open"
                        m_commandType = CommandTypeEnum.AutoOpen
                        Exit Select
                    Case Else
                        Throw New Exception("Invalid command type, supported values are link, button and auto_open")
                End Select
            End Set
        End Property

        ''' <summary>
        ''' Set title of publish button/link
        ''' </summary>
        Public WriteOnly Property CommandTitle() As String
            Set(ByVal value As String)
                m_commandTitle = value
            End Set
        End Property

        ''' <summary>
        ''' Inform client when  popup is displayed
        ''' </summary>
        Public Event PublishCalled As PublishCalledHandler

        ''' <summary>
        ''' Inform client when story is published or popup is closed
        ''' </summary>
        Public Event ConfirmCalled As ConfirmCalledHandler

        ''' <summary>
        ''' If true, publish button does not work, default = false
        ''' </summary>
        Public WriteOnly Property Enabled() As Boolean
            Set(ByVal value As Boolean)
                PublishButton.Enabled = value
            End Set
        End Property

        ''' <summary>
        ''' Name of story
        ''' </summary>
        Public WriteOnly Property Name() As String
            Set(ByVal value As String)
                NameHiddenField.Value = value
            End Set
        End Property

        ''' <summary>
        ''' Destination URL linked on name
        ''' </summary>
        Public WriteOnly Property Href() As String
            Set(ByVal value As String)
                HrefHiddenField.Value = value
            End Set
        End Property

        ''' <summary>
        ''' Caption of the story
        ''' </summary>
        Public WriteOnly Property Caption() As String
            Set(ByVal value As String)
                CaptionHiddenField.Value = value
            End Set
        End Property

        ''' <summary>
        ''' Description of story
        ''' </summary>
        Public WriteOnly Property Description() As String
            Set(ByVal value As String)
                DescriptionHiddenField.Value = value
            End Set
        End Property

        ''' <summary>
        ''' Message Prompt of story
        ''' </summary>
        Public WriteOnly Property MessagePrompt() As String
            Set(ByVal value As String)
                MessagePromptHiddenField.Value = value
            End Set
        End Property

        ''' <summary>
        ''' Predefined user message
        ''' </summary>
        Public WriteOnly Property UserMessage() As String
            Set(ByVal value As String)
                UserMessageHiddenField.Value = value
            End Set
        End Property

        ''' <summary>
        ''' If publishing is enabled for an app, story is publish without displaying popup
        ''' </summary>
        Public WriteOnly Property TargetId() As String
            Set(ByVal value As String)
                TargetIdHiddenField.Value = value
            End Set
        End Property

        ''' <summary>
        ''' Page Id if user is admin of the page, story is published as it is published by the page
        ''' </summary>
        Public WriteOnly Property ActorId() As String
            Set(ByVal value As String)
                ActorIdHiddenField.Value = value
            End Set
        End Property

        ''' <summary>
        ''' Set properties of story (PropertyData and LinkedProperyData objects)
        ''' </summary>
        Public WriteOnly Property Properties() As IList(Of IJSONSerialize)
            Set(ByVal value As IList(Of IJSONSerialize))
                PropertiesHiddenField.Value = "{" & Conversions.JSONListToJSONString(value) & "}"
            End Set
        End Property

        ''' <summary>
        ''' Set media object (ImageData, VideoData, MP3Data, FlashData)
        ''' </summary>
        Public WriteOnly Property Media() As IJSONSerialize
            Set(ByVal value As IJSONSerialize)
                MediaHiddenField.Value = "[" & value.JSONSerialize() & "]"
            End Set
        End Property

        ''' <summary>
        ''' Set list of media objects. Currenty there are just images (ImageData) supported.
        ''' </summary>
        Public WriteOnly Property MediaList() As IList(Of IJSONSerialize)
            Set(ByVal value As IList(Of IJSONSerialize))
                MediaHiddenField.Value = "[" & Conversions.JSONListToJSONString(value) & "]"
            End Set
        End Property

        ''' <summary>
        ''' Set list of action links
        ''' </summary>
        Public WriteOnly Property ActionLinkList() As IList(Of LinkData)
            Set(ByVal value As IList(Of LinkData))
                ActionLinksHiddenField.Value = "[" & Conversions.LinkListToJSONString(value) & "]"
            End Set
        End Property

        ''' <summary>
        ''' Set action link
        ''' </summary>
        Public WriteOnly Property ActionLink() As LinkData
            Set(ByVal value As LinkData)
                ActionLinksHiddenField.Value = "[" & value.JSONSerialize() & "]"
            End Set
        End Property

        ''' <summary>
        ''' Get retuned post id. If it is not set publishing is canceled by user
        ''' </summary>
        Public ReadOnly Property ReturnedPostId() As String
            Get
                Dim postId As String = ReturnedPostIdHiddenField.Value
                If postId = "null" Then
                    Return Nothing
                End If
                Return postId
            End Get
        End Property


        ''' <summary>
        ''' Page Load
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub Page_Prerender(ByVal sender As Object, ByVal e As EventArgs) Handles Me.PreRender
            Dim html As New StringBuilder()
            Select Case m_commandType
                Case CommandTypeEnum.Link
                    html.Append("<a style=""cursor:pointer;"" onclick=""StreamPublish(this)"" id=""")
                    html.Append(PublishButton.ClientID)
                    html.Append("Control")
                    html.Append(""" >")
                    html.Append(m_commandTitle)
                    html.Append("</a>")
                    Exit Select
                Case CommandTypeEnum.Button
                    html.Append("<input type=""button"" style=""cursor:pointer"" class=""button"" onclick=""StreamPublish(this)"" id=""")
                    html.Append(PublishButton.ClientID)
                    html.Append("Control")
                    html.Append(""" value=""")
                    html.Append(m_commandTitle)
                    html.Append(""" />")
                    Exit Select
                Case CommandTypeEnum.AutoOpen
                    html.Append("<script type=""text/javascript"">")
                    html.Append("btn = document.getElementById('")
                    html.Append(PublishButton.ClientID)
                    html.Append("');")
                    html.Append("btn.click();</script>")
                    Exit Select
            End Select
            streamPublishSpan.InnerHtml = html.ToString()
        End Sub

        ''' <summary>
        ''' Inform cliend when popup is open
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub PublishButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            RaiseEvent PublishCalled(Me, e)
        End Sub

        ''' <summary>
        ''' Inform client when story is published of popup is closed
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub ConfirmedSendButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            RaiseEvent ConfirmCalled(Me, e)
        End Sub

        Private m_commandType As CommandTypeEnum = CommandTypeEnum.Button
        Private m_commandTitle As String = "Publish"
    End Class
End Namespace
