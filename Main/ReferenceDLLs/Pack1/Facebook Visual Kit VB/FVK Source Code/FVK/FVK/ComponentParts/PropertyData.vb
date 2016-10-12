Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace FVK
    ''' <summary>
    ''' The class contains data of Property for stream publishing
    ''' </summary>
    Public Class PropertyData
        Implements IJSONSerialize
        ''' <summary>
        ''' Create new undefined PropertyData object
        ''' </summary>
        Public Sub New()
        End Sub

        ''' <summary>
        ''' Create and define new PropertyData object
        ''' </summary>
        ''' <param name="name">Property name</param>
        ''' <param name="text">Propery text</param>
        Public Sub New(ByVal name As String, ByVal text As String)
            Me.m_name = name
            Me.m_text = text
        End Sub

        ''' <summary>
        ''' Propery name
        ''' </summary>
        Public Property Name() As String
            Get
                Return m_name
            End Get
            Set(ByVal value As String)
                m_name = value
            End Set
        End Property

        ''' <summary>
        ''' Property text
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
        ''' Serialize Propery data in JSON format
        ''' </summary>
        ''' <returns>JSON formated string</returns>
        Public Function JSONSerialize() As String _
            Implements IJSONSerialize.JSONSerialize
            Return ("""" & m_name & """:""") + m_text & """"
        End Function


        ''' <summary>
        ''' Protected members
        ''' </summary>
        Protected m_name As String
        Protected m_text As String
    End Class
End Namespace
