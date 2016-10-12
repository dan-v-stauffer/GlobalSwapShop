Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace FVK
    ''' <summary>
    ''' ImageData class uses to store data about image media for stream publishing
    ''' </summary>
    Public Class ImageData
        Implements IJSONSerialize
        ''' <summary>
        ''' Create new undefined ImageData object
        ''' </summary>
        Public Sub New()
        End Sub

        ''' <summary>
        ''' Create and define new ImageData object
        ''' </summary>
        ''' <param name="imageUrl">URL of image</param>
        ''' <param name="destUrl">URL of destionation when image is clicked</param>
        Public Sub New(ByVal imageUrl As String, ByVal destUrl As String)
            Me.m_imageUrl = imageUrl
            Me.m_destUrl = destUrl
        End Sub

        ''' <summary>
        ''' URL of image
        ''' </summary>
        Public Property ImageUrl() As String
            Get
                Return m_imageUrl
            End Get
            Set(ByVal value As String)
                m_imageUrl = value
            End Set
        End Property

        ''' <summary>
        ''' URL of destionation when image is clicked
        ''' </summary>
        Public Property DestUrl() As String
            Get
                Return m_destUrl
            End Get
            Set(ByVal value As String)
                m_destUrl = value
            End Set
        End Property

        ''' <summary>
        ''' Serialize Image data in JSON format
        ''' </summary>
        ''' <returns>JSON formated string</returns>
        Public Function JSONSerialize() As String _
            Implements IJSONSerialize.JSONSerialize
            Return ("{""type"":""image"",""src"":""" & m_imageUrl & """,""href"":""") + DestUrl & """}"
        End Function


        ''' <summary>
        ''' Private members
        ''' </summary>
        Private m_imageUrl As String
        Private m_destUrl As String
    End Class
End Namespace
