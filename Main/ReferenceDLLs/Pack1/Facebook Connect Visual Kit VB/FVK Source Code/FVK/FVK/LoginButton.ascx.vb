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
    ''' Facebook Connect Login Button control uses to connect web site on Facebook and share data using 
    ''' Facebook API. It also enable that once user is logged all controls from the library work without 
    ''' requiring for logging.
    ''' </summary>
    Partial Public Class LoginButton
        Inherits System.Web.UI.UserControl
        Public Delegate Sub OnConnectHandler(ByVal sender As Object, ByVal e As EventArgs)

        ''' <summary>
        ''' Inform client that connection on Facebook is established
        ''' </summary>
        Public Event ConnectCalled As OnConnectHandler

        ''' <summary>
        ''' of the control. Possible values: icon, small, medium, large, xlarge
        ''' </summary>
        Public WriteOnly Property Size() As String
            Set(ByVal value As String)
                m_size = value
            End Set
        End Property

        ''' <summary>
        ''' text inside login button
        ''' </summary>
        Public WriteOnly Property Title() As String
            Set(ByVal value As String)
                m_title = value
            End Set
        End Property

        ''' <summary>
        ''' Add permissions as comma separaded values string
        ''' </summary>
        Public WriteOnly Property Permissions() As String
            Set(ByVal value As String)
                m_permissions = value
            End Set
        End Property


        ''' <summary>
        ''' Page Load
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                Dim s As New StringBuilder()
                s.Append("<fb:login-button ")
                s.Append("onlogin=""")
                s.Append("document.getElementById('")
                s.Append(ConnectButton.ClientID)
                s.Append("').click()"" ")
                If m_size IsNot Nothing Then
                    s.Append("size=""")
                    s.Append(m_size)
                    s.Append(""" ")
                End If
                If m_permissions IsNot Nothing Then
                    s.Append(" perms=""")
                    s.Append(m_permissions)
                    s.Append("""")
                End If

                s.Append(" >")
                If m_title IsNot Nothing Then
                    s.Append(m_title)
                End If
                s.Append("</fb:login-button>")
                ConnectSpan.InnerHtml = s.ToString()
            End If
        End Sub

        ''' <summary>
        ''' Login button is pressed
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub ConnectButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            RaiseEvent ConnectCalled(sender, e)
        End Sub

        ''' <summary>
        ''' Private members
        ''' </summary>

        Private m_size As String = Nothing
        Private m_title As String = Nothing
        Private m_permissions As String = Nothing
    End Class
End Namespace
