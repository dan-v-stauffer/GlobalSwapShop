Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace FVK
    ''' <summary>
    ''' This class uses to store data about Facebook user for SelectFriends control
    ''' </summary>
    <Serializable()> _
    Public Class SelectedFriend
        Inherits FriendData
        Implements IComparable(Of SelectedFriend)
        ''' <summary>
        ''' Create and define new SelectedFriend object
        ''' </summary>
        ''' <param name="id">User Id</param>
        ''' <param name="name">User Name</param>
        ''' <param name="selected">Is user selected</param>
        ''' <param name="isAppUser">Is user application user</param>
        ''' <param name="isInList">Is user currently in the filtered list</param>
        Public Sub New(ByVal id As Long, ByVal name As String, ByVal selected As Boolean, ByVal isAppUser As Boolean, ByVal isInList As Boolean)
            MyBase.New(id, name)
            Me.m_selected = selected
            Me.m_isAppUser = isAppUser
            Me.m_isInList = isInList
        End Sub

        ''' <summary>
        ''' Is user selected
        ''' </summary>
        Public Property Selected() As Boolean
            Get
                Return m_selected
            End Get
            Set(ByVal value As Boolean)
                m_selected = value
            End Set
        End Property

        ''' <summary>
        ''' Is user application user
        ''' </summary>
        Public ReadOnly Property IsAppUser() As Boolean
            Get
                Return m_isAppUser
            End Get
        End Property

        ''' <summary>
        ''' Is user currently in the list
        ''' </summary>
        Public Property IsInList() As Boolean
            Get
                Return m_isInList
            End Get
            Set(ByVal value As Boolean)
                m_isInList = value
            End Set
        End Property

        ''' <summary>
        ''' Compare SelectedFriend objects
        ''' </summary>
        ''' <param name="other">other SelectedFriend object</param>
        ''' <returns>Look at CompareTo .NET documetation</returns>
        Public Overloads Function CompareTo(ByVal other As SelectedFriend) As Integer _
            Implements IComparable(Of FVK.SelectedFriend).CompareTo
            Return Name.CompareTo(other.Name)
        End Function


        ''' <summary>
        ''' Private members
        ''' </summary>
        Private m_selected As Boolean
        Private m_isAppUser As Boolean
        Private m_isInList As Boolean

    End Class
End Namespace
