Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Facebook
Imports Facebook.Web
Imports FVK

Namespace FacebookStart
    Partial Public Class _Default
        Inherits Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                Dim auth = New CanvasAuthorizer() With {.Permissions = New String() {"email"}}

                If auth.Authorize() Then
                    Dim facebook = New FacebookWebClient()

                    ' check if facebook session is valid
                    Try
                        Dim basicData As JsonObject = DirectCast(facebook.[Get]("me?fields=id,name"), JsonObject)
                    Catch generatedExceptionName As Exception
                        Session.Clear()
                        auth.HandleUnauthorizedRequest()
                        Return
                    End Try
                End If
            End If
        End Sub
    End Class
End Namespace
