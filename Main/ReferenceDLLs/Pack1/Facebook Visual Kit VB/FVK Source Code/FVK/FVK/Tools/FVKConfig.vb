' WARNING: 
' The source code of this class can be used and modified to your particular needs. 
' Sharing the class with unregistered users or using it with unregistered websites 
' or Facebook applications is not allowed and violates the rights of intellectual 
' property. 

Imports System.Data
Imports System.Configuration
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Xml.Linq

Namespace FVK
    Public NotInheritable Class FVKConfig
        Private Sub New()
        End Sub
        Public Shared Property AppId() As String
            Get
                Return m_appId
            End Get
            Set(ByVal value As String)
                m_appId = value
            End Set
        End Property
        Public Shared Property AppSecret() As String
            Get
                Return m_appSecret
            End Get
            Set(ByVal value As String)
                m_appSecret = value
            End Set
        End Property
        Public Shared Property AppName() As String
            Get
                Return m_appName
            End Get
            Set(ByVal value As String)
                m_appName = value
            End Set
        End Property
        Public Shared Property AppUrl() As String
            Get
                Return m_appUrl
            End Get
            Set(ByVal value As String)
                m_appUrl = value
            End Set
        End Property

        Shared Sub New()
            ' Initialization
            m_appId = ConfigurationManager.AppSettings("appId")
            m_appSecret = ConfigurationManager.AppSettings("appSecret")
            m_appName = ConfigurationManager.AppSettings("appName")
            m_appUrl = ConfigurationManager.AppSettings("appUrl")

            ' checking
            If m_appId Is Nothing OrElse m_appId = "" Then
                Throw New Exception("AppId is not defined in Web.config")
            End If

            If m_appSecret Is Nothing OrElse m_appSecret = "" Then
                Throw New Exception("Secret is not defined in Web.config")
            End If

            If m_appName Is Nothing OrElse m_appName = "" Then
                Throw New Exception("AppName is not defined in Web.config")
            End If

            If m_appUrl Is Nothing OrElse m_appUrl = "" Then
                Throw New Exception("AppCanvasUrl is not defined in Web.config")
            Else
                If Not m_appUrl.EndsWith("/") Then
                    m_appUrl += "/"
                End If
            End If
        End Sub

        Private Shared m_appId As String
        Private Shared m_appSecret As String
        Private Shared m_appName As String
        Private Shared m_appUrl As String
    End Class
End Namespace
