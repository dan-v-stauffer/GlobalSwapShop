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
    ''' Bookmark button uses to enable to users an easy way to bookmark a Facebook Connect website inside 
    ''' Facebook environement. 
    ''' </summary>
    Partial Public Class BookmarkButton
        Inherits System.Web.UI.UserControl
        ''' <summary>
        ''' Inform client about bookmarked application/website
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Public Delegate Sub AddBookmarkHandler(ByVal sender As Object, ByVal e As EventArgs)
        Public Event AddedBookmark As AddBookmarkHandler

        ''' <summary>
        ''' Set to true if bookmark button is used on externan website
        ''' </summary>
        Public WriteOnly Property OffFacebook() As Boolean
            Set(ByVal value As Boolean)
                m_offFacebook = value
            End Set
        End Property

        ''' <summary>
        ''' Page Load
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Dim html As New StringBuilder()
            html.Append("<fb:bookmark type=""")
            If m_offFacebook Then
                html.Append("off-facebook""")
            Else
                html.Append("on-facebook""")
            End If
            If True Then ' cannot check if event handler is set like in C#
                html.Append(" onadd=""document.getElementById('")
                html.Append(BookmarkAddedButton.ClientID)
                html.Append("').click()""")
            End If
            html.Append("></fb:bookmark>")
            bookmarkSpan.InnerHtml = html.ToString()
        End Sub

        Protected Sub BookmarkAddedButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            RaiseEvent AddedBookmark(sender, e)
        End Sub

        Private m_offFacebook As Boolean = False
    End Class
End Namespace
