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
    ''' Stream publish friend list uses to enable publishing stories on friends' wall on easy way by selection 
    ''' friend from a list and press publish button.This ASP.NET control is wrapper around Facebook stream 
    ''' publish popup control. It provides a box with friend list which can be defined through source code. 
    ''' By selecting a friend and pressing a publish button stream publish popup is shown.
    ''' </summary>
    Partial Public Class StreamPublishFriendList
        Inherits System.Web.UI.UserControl
        Public Delegate Sub PublishCalledHandler(ByVal sender As Object, ByVal e As EventArgs)
        Public Delegate Sub ConfirmCalledHandler(ByVal sender As Object, ByVal e As EventArgs)

        ''' <summary>
        ''' Inform client when  popup is displayed
        ''' </summary>
        Public Event PublishCalled As PublishCalledHandler

        ''' <summary>
        ''' Inform client when story is published or popup is closed
        ''' </summary>
        Public Event ConfirmCalled As ConfirmCalledHandler

        ''' <summary>
        ''' Set title of publish button
        ''' </summary>
        Public WriteOnly Property PostBtnTitle() As String
            Set(ByVal value As String)
                streampublishpopup1.CommandTitle = value
            End Set
        End Property

        ''' <summary>
        ''' Set title of hide button
        ''' </summary>
        Public WriteOnly Property HideBtnTitle() As String
            Set(ByVal value As String)
                HideButton.Text = value
            End Set
        End Property

        ''' <summary>
        ''' Set url of image inside the Box
        ''' </summary>
        Public WriteOnly Property MainImageUrl() As String
            Set(ByVal value As String)
                SelectedImage.ImageUrl = value
            End Set
        End Property

        ''' <summary>
        ''' Title of the box
        ''' </summary>
        Public WriteOnly Property Title() As String
            Set(ByVal value As String)
                titleLabel.Text = value
            End Set
        End Property

        ''' <summary>
        ''' Set text inside box the Box
        ''' </summary>
        Public WriteOnly Property BoxText() As String
            Set(ByVal value As String)
                BoxTextLabel.Text = value
            End Set
        End Property

        ''' <summary>
        ''' Name of story
        ''' </summary>
        Public WriteOnly Property Name() As String
            Set(ByVal value As String)
                streampublishpopup1.Name = value
            End Set
        End Property

        ''' <summary>
        ''' Destination URL linked on name
        ''' </summary>
        Public WriteOnly Property Href() As String
            Set(ByVal value As String)
                streampublishpopup1.Href = value
            End Set
        End Property

        ''' <summary>
        ''' Caption of the story
        ''' </summary>
        Public WriteOnly Property Caption() As String
            Set(ByVal value As String)
                streampublishpopup1.Caption = value
            End Set
        End Property

        ''' <summary>
        ''' Description of story
        ''' </summary>
        Public WriteOnly Property Description() As String
            Set(ByVal value As String)
                streampublishpopup1.Description = value
            End Set
        End Property

        ''' <summary>
        ''' Message Prompt of story
        ''' </summary>
        Public WriteOnly Property MessagePrompt() As String
            Set(ByVal value As String)
                streampublishpopup1.MessagePrompt = value
            End Set
        End Property

        ''' <summary>
        ''' Predefined user message
        ''' </summary>
        Public WriteOnly Property UserMessage() As String
            Set(ByVal value As String)
                streampublishpopup1.UserMessage = value
            End Set
        End Property

        ''' <summary>
        ''' If publishing is enabled for an app, story is publish without displaying popup
        ''' </summary>
        <Obsolete("Does not work anymore.")> _
        Public WriteOnly Property AutoPublish() As Boolean
            Set(ByVal value As Boolean)


            End Set
        End Property

        ''' <summary>
        ''' Set properties of story
        ''' </summary>
        Public WriteOnly Property Properties() As IList(Of IJSONSerialize)
            Set(ByVal value As IList(Of IJSONSerialize))
                streampublishpopup1.Properties = value
            End Set
        End Property

        ''' <summary>
        ''' Set media object (ImageData, VideoData, MP3Data, FlashData)
        ''' </summary>
        Public WriteOnly Property Media() As IJSONSerialize
            Set(ByVal value As IJSONSerialize)
                streampublishpopup1.Media = value
            End Set
        End Property

        ''' <summary>
        ''' Set list of media objects. Currenty there are just images (ImageData) supported.
        ''' </summary>
        Public WriteOnly Property MediaList() As IList(Of IJSONSerialize)
            Set(ByVal value As IList(Of IJSONSerialize))
                streampublishpopup1.MediaList = value
            End Set
        End Property

        ''' <summary>
        ''' Set list of action links
        ''' </summary>
        Public WriteOnly Property ActionLinkList() As IList(Of LinkData)
            Set(ByVal value As IList(Of LinkData))
                streampublishpopup1.ActionLinkList = value
            End Set
        End Property

        ''' <summary>
        ''' Set action link
        ''' </summary>
        Public WriteOnly Property ActionLink() As LinkData
            Set(ByVal value As LinkData)
                streampublishpopup1.ActionLink = value
            End Set
        End Property

        ''' <summary>
        ''' Get retuned post id. If it is not set publishing is canceled by user
        ''' </summary>
        Public ReadOnly Property ReturnedPostId() As String
            Get
                Return streampublishpopup1.ReturnedPostId
            End Get
        End Property


        ''' <summary>
        ''' Set list of friends which have to be displayed in the box
        ''' </summary>
        Public WriteOnly Property Friends() As IList(Of FriendData)
            Set(ByVal value As IList(Of FriendData))
                If value.Count > 0 Then
                    Dim sortedList As New List(Of FriendData)(value)
                    sortedList.Sort()

                    Dim html As New StringBuilder()
                    html.Append("<table>" & vbLf)

                    Dim index As Integer = 0
                    Dim parentId As String = RadioItemsSpan.ClientID
                    For Each f As FriendData In value
                        html.Append("  <tr>" & vbLf)
                        html.Append("    <td>" & vbLf)
                        html.Append("      <input type='radio' id='")
                        html.Append(parentId)
                        html.Append("Item")
                        html.Append(index.ToString())
                        html.Append("' value='")
                        html.Append(f.Id.ToString())
                        html.Append("' name='")
                        html.Append(parentId)
                        html.Append("List")
                        html.Append("' onclick='SelectTarget(""")
                        html.Append(streampublishpopup1.ClientID)
                        html.Append("_TargetIdHiddenField"", this)' />" & vbLf)
                        html.Append("      <label for='")
                        html.Append(parentId)
                        html.Append("Item' >")
                        html.Append(f.Name)
                        html.Append("</label>" & vbLf)
                        html.Append("    </td>" & vbLf)
                        html.Append("  </tr>" & vbLf)
                    Next
                    html.Append("</table>" & vbLf)
                    RadioItemsSpan.InnerHtml = html.ToString()
                Else
                    RadioItemsSpan.InnerHtml = ""
                End If
            End Set
        End Property


        ''' <summary>
        ''' Page Load
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                streampublishpopup1.Enabled = False
            End If
        End Sub

        ''' <summary>
        ''' Inform cliend when popup is open
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub PublishButtonHandler(ByVal sender As Object, ByVal e As EventArgs)
            streampublishpopup1.TargetId = Nothing
            RaiseEvent PublishCalled(Me, e)
        End Sub

        ''' <summary>
        ''' Inform client when story is published of popup is closed
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub ConfirmedSendButtonHandler(ByVal sender As Object, ByVal e As EventArgs)
            streampublishpopup1.TargetId = Nothing
            RaiseEvent ConfirmCalled(Me, e)
        End Sub



        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub HideButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Visible = False
        End Sub


        ''' <summary>
        ''' Private members
        ''' </summary>
        Private WriteOnly Property TargetId() As String
            Set(ByVal value As String)
                streampublishpopup1.TargetId = value
            End Set
        End Property
    End Class
End Namespace
