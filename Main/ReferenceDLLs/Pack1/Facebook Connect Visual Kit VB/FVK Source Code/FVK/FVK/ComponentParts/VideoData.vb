Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace FVK
    ''' <summary>
    ''' VideoData class uses to store data about Video media for stream publishing
    ''' </summary>
    Public Class VideoData
        Implements IJSONSerialize
        ''' <summary>
        ''' Create new undefined VideoData object
        ''' </summary>
        Public Sub New()
        End Sub

        ''' <summary>
        ''' Create and define new VideaData object
        ''' </summary>
        ''' <param name="videoSrc">URL of video file</param>
        ''' <param name="previewImg">URL of preview image</param>
        ''' <param name="videoLink">Destination URL when video is clicked</param>
        ''' <param name="videoTitle">Video Title</param>
        Public Sub New(ByVal videoSrc As String, ByVal previewImg As String, ByVal videoLink As String, ByVal videoTitle As String)
            Me.m_videoSrc = videoSrc
            Me.m_previewImg = previewImg
            Me.m_videoLink = videoLink
            Me.m_videoTitle = videoTitle
        End Sub

        ''' <summary>
        ''' URL of video file
        ''' </summary>
        Public Property VideoSrc() As String
            Get
                Return m_videoSrc
            End Get
            Set(ByVal value As String)
                m_videoSrc = value
            End Set
        End Property

        ''' <summary>
        ''' URL of preview image
        ''' </summary>
        Public Property PreviewImg() As String
            Get
                Return m_previewImg
            End Get
            Set(ByVal value As String)
                m_previewImg = value
            End Set
        End Property

        ''' <summary>
        ''' Destination URL when video is clicked
        ''' </summary>
        Public Property VideoLink() As String
            Get
                Return m_videoLink
            End Get
            Set(ByVal value As String)
                m_videoLink = value
            End Set
        End Property

        ''' <summary>
        ''' Video Title
        ''' </summary>
        Public Property VideoTitle() As String
            Get
                Return m_videoTitle
            End Get
            Set(ByVal value As String)
                m_videoTitle = value
            End Set
        End Property

        ''' <summary>
        ''' Serialize Video data in JSON format
        ''' </summary>
        ''' <returns>JSON formated string</returns>
        Public Function JSONSerialize() As String _
            Implements IJSONSerialize.JSONSerialize
            Return ((("{""type"":""video"",""video_src"":""" & m_videoSrc & """,""preview_img"":""") + m_previewImg & """," & """video_link"":""") + m_videoLink & """, ""video_title"":""") + m_videoTitle & """}"
        End Function


        ''' <summary>
        ''' Private members
        ''' </summary>
        Private m_videoSrc As String
        Private m_previewImg As String
        Private m_videoLink As String
        Private m_videoTitle As String
    End Class
End Namespace
