Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace FVK
    Public Class TabData
        Private m_name As String
        Private m_url As String
        Private m_width As Integer

        Public Sub New(ByVal name As String, ByVal url As String, ByVal width As Integer)
            Me.m_name = name
            Me.m_url = url
            Me.m_width = width
        End Sub

        Public ReadOnly Property Name() As String
            Get
                Return m_name
            End Get
        End Property
        Public ReadOnly Property Url() As String
            Get
                Return m_url
            End Get
        End Property
        Public ReadOnly Property Width() As Integer
            Get
                Return m_width
            End Get
        End Property
    End Class
End Namespace
