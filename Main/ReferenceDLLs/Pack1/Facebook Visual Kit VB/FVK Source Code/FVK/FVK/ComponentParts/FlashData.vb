Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Text

Namespace FVK
    ''' <summary>
    ''' FlashData class uses to store data about flash media for stream publishing
    ''' </summary>
    Public Class FlashData
        Implements IJSONSerialize
        ''' <summary>
        ''' Create new undefined Flash data object
        ''' </summary>
        Public Sub New()
        End Sub

        ''' <summary>
        ''' Create amd define new Flash data object
        ''' </summary>
        ''' <param name="swfSrc">URL of SWF file</param>
        ''' <param name="imgSrc">URL of Image file</param>
        ''' <param name="width">Width</param>
        ''' <param name="height">Height</param>
        ''' <param name="expandedWidth">Extended width</param>
        ''' <param name="expandedHeight">Extended height</param>
        Public Sub New(ByVal swfSrc As String, ByVal imgSrc As String, ByVal width As Integer, ByVal height As Integer, ByVal expandedWidth As Integer, ByVal expandedHeight As Integer)
            Me.m_swfSrc = swfSrc
            Me.m_imgSrc = imgSrc
            Me.m_width = width
            Me.m_height = height
            Me.m_expandedWidth = expandedWidth
            Me.m_expandedHeight = expandedHeight
        End Sub

        ''' <summary>
        ''' URL of SWF file
        ''' </summary>
        Public Property SwfSrc() As String
            Get
                Return m_swfSrc
            End Get
            Set(ByVal value As String)
                m_swfSrc = value
            End Set
        End Property

        ''' <summary>
        ''' URL of Image file
        ''' </summary>
        Public Property ImgSrc() As String
            Get
                Return m_imgSrc
            End Get
            Set(ByVal value As String)
                m_imgSrc = value
            End Set
        End Property

        ''' <summary>
        ''' Widht
        ''' </summary>
        Public Property Width() As Integer
            Get
                Return m_width
            End Get
            Set(ByVal value As Integer)
                m_width = value
            End Set
        End Property

        ''' <summary>
        ''' Height
        ''' </summary>
        Public Property Height() As Integer
            Get
                Return m_height
            End Get
            Set(ByVal value As Integer)
                m_height = value
            End Set
        End Property

        ''' <summary>
        ''' Expanded Widht
        ''' </summary>
        Public Property ExpandedWidth() As Integer
            Get
                Return m_expandedWidth
            End Get
            Set(ByVal value As Integer)
                m_expandedWidth = value
            End Set
        End Property

        ''' <summary>
        ''' Expanded Height
        ''' </summary>
        Public Property ExpandedHeight() As Integer
            Get
                Return m_expandedHeight
            End Get
            Set(ByVal value As Integer)
                m_expandedHeight = value
            End Set
        End Property

        ''' <summary>
        ''' Serialize Flash data in JSON formated string
        ''' </summary>
        ''' <returns>JSON formated string</returns>
        Public Function JSONSerialize() As String _
            Implements IJSONSerialize.JSONSerialize
            Return ((((("{""type"":""flash"",""swfsrc"":""" & m_swfSrc & """,""imgsrc"":""") + m_imgSrc & """," & """width"":""") + m_width.ToString() & """, ""height"":""") + m_height.ToString() & """,""expanded_width"":""") + m_expandedWidth.ToString() & """, ""expanded_height"":""") + m_expandedHeight.ToString() & """}"
        End Function


        ''' <summary>
        ''' Private members
        ''' </summary>
        Private m_swfSrc As String
        Private m_imgSrc As String
        Private m_width As Integer
        Private m_height As Integer
        Private m_expandedWidth As Integer
        Private m_expandedHeight As Integer
    End Class
End Namespace
