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
    Partial Public Class SendButton
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
            html.Append("<fb:send ")
            If m_url IsNot Nothing Then
                html.Append("href='" & m_url & "' ")
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
            html.Append("></fb:send>" & vbLf)
            sendSpan.InnerHtml = html.ToString()
        End Sub

        ' Private members
        Private m_url As String = Nothing
        Private m_font As String = Nothing
        Private m_colorScheme As String = Nothing
        Private m_reference As String = Nothing
    End Class
End Namespace
