Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Text

Namespace FVK
    Partial Public Class RequestDialog
        Inherits System.Web.UI.UserControl
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
        ''' Set message of request dialog
        ''' </summary>
        Public WriteOnly Property Message() As String
            Set(ByVal value As String)
                m_message = value
            End Set
        End Property

        ''' <summary>
        ''' Set title of request dialog
        ''' </summary>
        Public WriteOnly Property Title() As String
            Set(ByVal value As String)
                m_title = value
            End Set
        End Property

        ''' <summary>
        ''' Set id of friend to which request has to be sent. If omited, friend selector is shown
        ''' </summary>
        Public WriteOnly Property FriedId() As String
            Set(ByVal value As String)
                friendId = value
            End Set
        End Property

        ''' <summary>
        ''' Optional data which is sent with request
        ''' </summary>
        Public WriteOnly Property AdditionalData() As String
            Set(ByVal value As String)
                m_additionalData = value
            End Set
        End Property

        ''' <summary>
        ''' Page Load
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Refresh()
        End Sub

        Private Sub Refresh()
            Dim functionName As String = "ShowRequestDialog" & Me.ClientID
            Dim html As New StringBuilder()
            html.Append("<script>" & vbLf)
            html.Append("function " & functionName & "() {" & vbLf)
            html.Append("  if (graphApiInitialized != true) {" & vbLf)
            html.Append("    setTimeout('" & functionName & "()', 100);" & vbLf)
            html.Append("    return;" & vbLf)
            html.Append("  }" & vbLf)
            html.Append("  FB.ui({method: 'apprequests', message: '")
            html.Append(m_message & "'")
            If m_title IsNot Nothing Then
                html.Append(", title: '" & m_title & "'")
            End If
            If friendId IsNot Nothing Then
                html.Append(", to: '" & friendId & "'")
            End If
            If m_additionalData IsNot Nothing Then
                html.Append(", data: '" & m_additionalData & "'")
            End If
            html.Append("});" & vbLf)
            html.Append("}" & vbLf)

            html.Append("</script>" & vbLf)

            Select Case m_commandType
                Case CommandTypeEnum.Link
                    html.Append("<a style=""cursor:pointer;"" onclick=""" & functionName & "()"" >")
                    html.Append(m_commandTitle)
                    html.Append("</a>" & vbLf)
                    Exit Select
                Case CommandTypeEnum.Button
                    html.Append("<input type=""button"" style=""cursor:pointer"" class=""button"" onclick=""" & functionName & "()""  value=""")
                    html.Append(m_commandTitle)
                    html.Append(""" />" & vbLf)
                    Exit Select
                Case CommandTypeEnum.AutoOpen
                    html.Append("<script type=""text/javascript"">")
                    html.Append(functionName & "();" & vbLf)
                    html.Append("</script>" & vbLf)
                    Exit Select
            End Select
            requestSpan.InnerHtml = html.ToString()
        End Sub



        ' Private members
        Private m_message As String
        Private m_title As String
        Private friendId As String
        Private m_additionalData As String
        Private m_commandType As CommandTypeEnum = CommandTypeEnum.Button
        Private m_commandTitle As String = "Send Request"

    End Class
End Namespace
