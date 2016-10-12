Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace FVK
    ''' <summary>
    ''' Link data class uses to store data of link
    ''' </summary>
    Public Class LinkData
        Implements IJSONSerialize
        ''' <summary>
        ''' Create new undefined LinkData object
        ''' </summary>
        Public Sub New()
        End Sub

        ''' <summary>
        ''' Create and define new LinkData object
        ''' </summary>
        ''' <param name="text">Text of the link</param>
        ''' <param name="href">Destination of the link</param>
        Public Sub New(ByVal text As String, ByVal href As String)
            Me.m_text = text
            Me.m_href = href
        End Sub

        ''' <summary>
        ''' Text of the link
        ''' </summary>
        Public Property Text() As String
            Get
                Return m_text
            End Get
            Set(ByVal value As String)
                m_text = value
            End Set
        End Property

        ''' <summary>
        ''' Destination of the link
        ''' </summary>
        Public Property Href() As String
            Get
                Return m_href
            End Get
            Set(ByVal value As String)
                m_href = value
            End Set
        End Property

        ''' <summary>
        ''' Serialize Link data in JSON format
        ''' </summary>
        ''' <returns>JSON formated string</returns>
        Public Function JSONSerialize() As String _
             Implements IJSONSerialize.JSONSerialize
            Return ("{""text"":""" & m_text & """,""href"":""") + m_href & """}"
        End Function


        ''' <summary>
        ''' Private members
        ''' </summary>
        Private m_text As String
        Private m_href As String

    End Class
End Namespace
