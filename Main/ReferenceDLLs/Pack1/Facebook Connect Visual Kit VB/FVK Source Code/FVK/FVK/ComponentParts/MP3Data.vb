Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace FVK
    ''' <summary>
    ''' MP3Data class uses to store data about MP3 media for stream publishing
    ''' </summary>
    Public Class MP3Data
        Implements IJSONSerialize
        ''' <summary>
        ''' Create new undefined MP3Data object
        ''' </summary>
        Public Sub New()
        End Sub

        ''' <summary>
        ''' Create and define new MP3Data object
        ''' </summary>
        ''' <param name="src">URL of MP3 file</param>
        ''' <param name="title">Title</param>
        ''' <param name="artist">Artist name</param>
        ''' <param name="album">Album name</param>
        Public Sub New(ByVal src As String, ByVal title As String, ByVal artist As String, ByVal album As String)
            Me.m_src = src
            Me.m_title = title
            Me.m_artist = artist
            Me.m_album = album
        End Sub

        ''' <summary>
        ''' URL of mp3 file
        ''' </summary>
        Public Property Src() As String
            Get
                Return m_src
            End Get
            Set(ByVal value As String)
                m_src = value
            End Set
        End Property

        ''' <summary>
        ''' Title
        ''' </summary>
        Public Property Title() As String
            Get
                Return m_title
            End Get
            Set(ByVal value As String)
                m_title = value
            End Set
        End Property

        ''' <summary>
        ''' Artist name
        ''' </summary>
        Public Property Artist() As String
            Get
                Return m_artist
            End Get
            Set(ByVal value As String)
                m_artist = value
            End Set
        End Property

        ''' <summary>
        ''' Album name
        ''' </summary>
        Public Property Album() As String
            Get
                Return m_album
            End Get
            Set(ByVal value As String)
                m_album = value
            End Set
        End Property

        ''' <summary>
        ''' Serialize MP3 data in JSON format
        ''' </summary>
        ''' <returns>JSON formated string</returns>
        Public Function JSONSerialize() As String _
            Implements IJSONSerialize.JSONSerialize
            Return ((("{""type"":""mp3"",""src"":""" & m_src & """,""title"":""") + m_title & """," & """artist"":""") + m_artist & """, ""album"":""") + m_album & """}"
        End Function


        ''' <summary>
        ''' Private members
        ''' </summary>
        Private m_src As String
        Private m_title As String
        Private m_artist As String
        Private m_album As String
    End Class
End Namespace
