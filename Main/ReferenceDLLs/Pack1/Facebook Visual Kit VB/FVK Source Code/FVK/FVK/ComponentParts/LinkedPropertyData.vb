Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace FVK
    Public Class LinkedPropertyData
        Inherits PropertyData
        Implements IJSONSerialize
        Private m_href As String

        Public Sub New(ByVal name As String, ByVal text As String, ByVal href As String)
            MyBase.New(name, text)
            Me.m_href = href
        End Sub

        Public Property Href() As String
            Get
                Return m_href
            End Get
            Set(ByVal value As String)
                m_href = value
            End Set
        End Property

        Public Shadows Function JSONSerialize() As String _
            Implements IJSONSerialize.JSONSerialize
            Return (("""" & name & """:{""text"":""") + Text & """,""href"":""") + m_href & """}"
        End Function
    End Class
End Namespace
