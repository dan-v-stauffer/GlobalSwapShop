Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace FacebookStart
    Partial Public Class Master
        Inherits System.Web.UI.MasterPage
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                ' enable third party cookies on IE
                Response.AppendHeader("P3P", "CP=""CAO PSA OUR""")

                ' define tabs
                tab1.AddTab("Home Page", "Default.aspx", 100)
                tab1.AddTab("Second Page", "SecondPage.aspx", 100)
                tab1.AddTab("Invite Friends", "Invite.aspx", 100)

                tab1.NumOfRightTabs = 1
                tab1.Distance = 5
            End If
        End Sub
    End Class
End Namespace
