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
    ''' Like button allows users to share some content from the website with their friends. Pressing on 
    ''' the Like button will result in publishing of a story on user's profile, with link to the website.
    ''' </summary>
    Partial Public Class LikeButton
        Inherits System.Web.UI.UserControl
        ''' <summary>
        ''' URL of the like button. If it's not set, current page URL is used.
        ''' </summary>
        Public WriteOnly Property Url() As String
            Set(ByVal value As String)
                m_url = value
            End Set
        End Property



        ''' <summary>
        ''' Layout type. Available values are 'standard', 'button_count', 'box_count'
        ''' </summary>
        Public WriteOnly Property Layout() As String
            Set(ByVal value As String)
                If value = "button_count" Then
                    m_layout = value
                ElseIf value = "box_count" Then
                    m_layout = value
                ElseIf value <> "standard" Then
                    Throw New Exception("LikeButton Error:  Unsupported layout: " & value)
                End If
            End Set
        End Property

        ''' <summary>
        ''' If set to true, send button will be shown next to the like button
        ''' </summary>
        Public WriteOnly Property Send() As Boolean
            Set(ByVal value As Boolean)
                m_send = value
            End Set
        End Property


        ''' <summary>
        ''' Set to true to show profile picture bellow the like button. Default value is true.
        ''' </summary>
        Public WriteOnly Property ShowFaces() As Boolean
            Set(ByVal value As Boolean)
                m_showFaces = value
            End Set
        End Property


        ''' <summary>
        ''' Width of the like button in pixels. Default value is 450.
        ''' </summary>
        Public WriteOnly Property Width() As Integer
            Set(ByVal value As Integer)
                m_width = value
            End Set
        End Property

        ''' <summary>
        ''' Text of the like button. Available values are 'like' and 'recommend'. 
        ''' Defined text is translated depending on user language settings.
        ''' </summary>
        Public WriteOnly Property Action() As String
            Set(ByVal value As String)
                If value = "recommend" Then
                    m_action = value
                ElseIf value <> "like" Then
                    Throw New Exception("LikeButton Error:  Unsupported action: " & value)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Font inside the like button. Available values are 'arial', 'lucida grande',
        ''' 'segoe ui', 'tahoma', 'trebuchet ms' and 'verdana'.
        ''' </summary>
        Public WriteOnly Property Font() As String
            Set(ByVal value As String)
                If value IsNot Nothing Then
                    Select Case m_font
                        Case "arial", "lucida grande", "segoe ui", "tahoma", "trebuchet ms", "verdana"
                            m_font = value
                            Exit Select
                        Case Else
                            Throw New Exception("Like Button Error:  Unsupported font: " & value)
                    End Select
                End If
            End Set
        End Property

        ''' <summary>
        ''' Color scheme. Available values are 'light' and 'dark'. Deault value is 'light'.
        ''' </summary>
        Public WriteOnly Property ColorScheme() As String
            Set(ByVal value As String)
                If value = "dark" Then
                    m_colorScheme = value
                ElseIf value <> "light" Then
                    Throw New Exception("LikeButton Error:  Unsupported Color Scheme: " & value)
                End If
            End Set
        End Property

        ''' <summary>
        ''' The reference string for tracking referals.
        ''' </summary>
        Public WriteOnly Property Reference() As String
            Set(ByVal value As String)
                m_reference = value
            End Set
        End Property

        ''' <summary>
        ''' Page Load
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub Page_Prerender(ByVal sender As Object, ByVal e As EventArgs) Handles Me.PreRender
            Refresh()
        End Sub

        Private Sub Refresh()
            Dim html As New StringBuilder()
            html.Append("<fb:like ")
            If m_url IsNot Nothing Then
                html.Append("href='" & m_url & "' ")
            End If
            If m_layout IsNot Nothing Then
                html.Append("layout='" & m_layout & "' ")
            End If
            If m_send Then
                html.Append("send='true' ")
            End If
            If m_showFaces = False Then
                html.Append("show_faces='false' ")
            End If
            If m_width <> 450 Then
                html.Append("width='" & m_width.ToString() & "' ")
            End If
            If m_action IsNot Nothing Then
                html.Append("action='" & m_action & "' ")
            End If
            If m_font IsNot Nothing Then
                html.Append("font='" & m_font & "' ")
            End If
            If m_colorScheme IsNot Nothing Then
                html.Append("colorscheme='" & m_colorScheme & "' ")
            End If
            If m_reference IsNot Nothing Then
                html.Append("ref='" & m_reference & "' ")
            End If
            html.Append("></fb:like>" & vbLf)
            likeSpan.InnerHtml = html.ToString()
        End Sub

        ' Private members
        Private m_url As String = Nothing
        Private m_layout As String = Nothing
        Private m_send As Boolean = False
        Private m_showFaces As Boolean = True
        Private m_width As Integer = 450
        Private m_action As String = Nothing
        Private m_font As String = Nothing
        Private m_colorScheme As String = Nothing
        Private m_reference As String = Nothing



        ' Obsolete members/methods

        <Obsolete("You shouldn't use this property anymore. Use ColorScheme instead")> _
        Public WriteOnly Property SetColorScheme() As String
            Set(ByVal value As String)
                If value = "dark" Then
                    m_colorScheme = value
                ElseIf value <> "light" Then
                    Throw New Exception("LikeButton Error:  Unsupported Color Scheme: " & value)
                End If
            End Set
        End Property
    End Class
End Namespace
