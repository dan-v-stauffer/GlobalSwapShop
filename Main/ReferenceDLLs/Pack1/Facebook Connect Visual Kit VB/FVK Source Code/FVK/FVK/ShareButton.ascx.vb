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
    ''' Facebook Share Button uses to share some interesting links or link of your Facebook application, 
    ''' your Facebook Connect web site or Facebook Page with user friends. Using a share button a new 
    ''' story is published on user wall with link defined with share button.
    ''' </summary>

    <Obsolete("You should use Facebook Like Button control instead")> _
    Partial Public Class ShareButton
        Inherits System.Web.UI.UserControl
        ''' <summary>
        ''' Type of share button (icon, icon_link, button, button_count, box_count), default = icon_link
        ''' </summary>
        Public WriteOnly Property Type() As String
            Set(ByVal value As String)
                If value <> "icon" AndAlso value <> "icon_link" AndAlso value <> "button" AndAlso value <> "button_count" AndAlso value <> "box_count" Then
                    Throw New Exception("Share Button type is invalid. Valid values are icon, icon_link, button, button_count and box_count")
                End If
                m_type = value
            End Set
        End Property

        ''' <summary>
        ''' Set title of Share button
        ''' </summary>
        Public WriteOnly Property Title() As String
            Set(ByVal value As String)
                m_title = value
            End Set
        End Property

        ''' <summary>
        ''' Set Url
        ''' </summary>
        Public WriteOnly Property Url() As String
            Set(ByVal value As String)
                m_url = value
            End Set
        End Property

        ''' <summary>
        ''' Refresh dispay of the control
        ''' </summary>
        Public Sub Refresh()
            Dim str As New StringBuilder()
            str.Append("<a name=""fb_share"" ")
            str.Append("type=""")
            str.Append(m_type)
            str.Append(""" href=""http://www.facebook.com/sharer.php""")
            If m_url IsNot Nothing Then
                str.Append(" share_url=""")
                str.Append(m_url)
                str.Append(""">")
            End If
            str.Append(m_title)
            str.Append("</a><script src=""http://static.ak.fbcdn.net/connect.php/js/FB.Share"" type=""text/javascript""></script>")
            sharebuttonspan.InnerHtml = str.ToString()
        End Sub

        ''' <summary>
        ''' Page Load
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub Page_Prerender(ByVal sender As Object, ByVal e As EventArgs) Handles Me.PreRender
            If Not Page.IsPostBack Then
                Refresh()
            End If
        End Sub


        ''' <summary>
        ''' Private members
        ''' </summary>
        Private m_url As String = Nothing
        Private m_type As String = "icon_link"
        Private m_title As String = "Share"
    End Class
End Namespace
