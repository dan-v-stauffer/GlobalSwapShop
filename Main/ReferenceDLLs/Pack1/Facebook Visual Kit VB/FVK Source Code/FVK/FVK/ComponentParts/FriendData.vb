Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace FVK
    ''' <summary>
    ''' FriendData class contains Id and Name of Facebook user and support for comparing
    ''' </summary>
    <Serializable()> _
    Public Class FriendData
        Implements IComparable(Of FriendData)
        ''' <summary>
        ''' Create undefined FriendData object
        ''' </summary>
        Public Sub New()
        End Sub

        ''' <summary>
        ''' Create and define FriendData object
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="name"></param>
        Public Sub New(ByVal id As Long, ByVal name As String)
            Me.m_id = id
            Me.m_name = name
        End Sub

        ''' <summary>
        ''' Id
        ''' </summary>
        Public Property Id() As Long
            Get
                Return m_id
            End Get
            Set(ByVal value As Long)
                m_id = value
            End Set
        End Property

        ''' <summary>
        ''' Name
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
        ''' Compare FriendData objects
        ''' </summary>
        ''' <param name="other">other FriendData object</param>
        ''' <returns>Look at CompareTo .NET documetation</returns>
        Public Function CompareTo(ByVal other As FriendData) As Integer _
            Implements IComparable(Of FVK.FriendData).CompareTo
            Return Me.Name.CompareTo(other.Name)
        End Function


        ''' <summary>
        ''' Private members
        ''' </summary>
        ''' 
        Private m_id As Long
        Private m_name As String
    End Class
End Namespace
