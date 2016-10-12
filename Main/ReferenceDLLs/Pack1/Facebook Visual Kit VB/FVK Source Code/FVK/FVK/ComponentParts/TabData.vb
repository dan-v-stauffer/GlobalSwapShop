Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace FVK
    ''' <summary>
    ''' This class uses to provide data about one tab inside TabControl control
    ''' </summary>
    Public Class TabData
        ''' <summary>
        ''' Create and define new tab data
        ''' </summary>
        ''' <param name="name">Tab Name</param>
        ''' <param name="url">Tab Url</param>
        ''' <param name="width">Tab Width</param>
        Public Sub New(ByVal name As String, ByVal url As String, ByVal width As Integer)
            Me.m_name = name
            Me.m_url = url
            Me.m_width = width
        End Sub

        ''' <summary>
        ''' Tab Name
        ''' </summary>
        Public ReadOnly Property Name() As String
            Get
                Return m_name
            End Get
        End Property

        ''' <summary>
        ''' Tab Url
        ''' </summary>
        Public ReadOnly Property Url() As String
            Get
                Return m_url
            End Get
        End Property

        ''' <summary>
        ''' Tab Width
        ''' </summary>
        Public ReadOnly Property Width() As Integer
            Get
                Return m_width
            End Get
        End Property


        ''' <summary>
        ''' Private members
        ''' </summary>
        Private m_name As String
        Private m_url As String
        Private m_width As Integer
    End Class
End Namespace
