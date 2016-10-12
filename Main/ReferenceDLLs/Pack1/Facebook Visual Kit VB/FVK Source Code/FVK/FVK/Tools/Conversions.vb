Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports FVK
Imports System.Text

Namespace FVK
    ''' <summary>
    ''' Conversions class provide several static methods to converts among several types,
    ''' mostly conversions among familiar lists of different types
    ''' </summary>
    Public Module Conversions
        ''' <summary>
        ''' Make conversion from list of FriendData class to list of friends Ids
        ''' </summary>
        ''' <param name="friends">IList of FriendData</param>
        ''' <returns>IList of friend Ids</returns>
        Public Function FriendDataListToIdList(ByVal friends As IList(Of FriendData)) As IList(Of Long)
            Dim ids As IList(Of Long) = New List(Of Long)()
            For Each f As FriendData In friends
                ids.Add(f.Id)
            Next
            Return ids
        End Function

        ''' <summary>
        ''' Make conversion from list of FriendData to list of friends names
        ''' </summary>
        ''' <param name="friends">IList of FriendData</param>
        ''' <returns>Ilist of friends names</returns>
        Public Function FriendDataListToNameList(ByVal friends As IList(Of FriendData)) As IList(Of String)
            Dim ids As IList(Of String) = New List(Of String)()
            For Each f As FriendData In friends
                ids.Add(f.Name)
            Next
            Return ids
        End Function

        ''' <summary>
        ''' Make conversion from list of FriendData to string contained of comma separated list of friends Ids
        ''' </summary>
        ''' <param name="friends">IList of FriendData</param>
        ''' <returns>String contained of comma separated list of friends Ids</returns>
        Public Function FriendsDataListToStringIds(ByVal friends As IList(Of FriendData)) As String
            Dim s As New StringBuilder()
            Dim i As Integer = 0
            Dim count As Integer = friends.Count
            For Each f As FriendData In friends
                i += 1
                s.Append(f.Id)
                If i < count Then
                    s.Append(",")
                End If
            Next
            Return s.ToString()
        End Function

        ''' <summary>
        ''' Make conversion from list of FriendData to string contained of comma separated list of friends names
        ''' </summary>
        ''' <param name="friends">IList of FriendData</param>
        ''' <returns>String contained of comma separated list of friends names</returns>
        Public Function FriendsDataListToNamesString(ByVal friends As IList(Of FriendData)) As String
            Dim s As New StringBuilder()
            Dim i As Integer = 0
            Dim count As Integer = friends.Count
            For Each f As FriendData In friends
                i += 1
                s.Append(f.Name)
                If i < count Then
                    s.Append(",")
                End If
            Next
            Return s.ToString()
        End Function

        ''' <summary>
        ''' Make conversion from list of JSON serializable objects to string which represents list in JSON format
        ''' </summary>
        ''' <param name="list">IList of JSON serializable objects</param>
        ''' <returns>String which represents list in JSON format</returns>
        Public Function JSONListToJSONString(ByVal list As IList(Of IJSONSerialize)) As String
            Dim str As New StringBuilder()
            If list.Count > 0 Then
                Dim i As Integer = 0
                For Each v As IJSONSerialize In list
                    str.Append(v.JSONSerialize())
                    i += 1
                    If i < list.Count Then
                        str.Append(",")
                    End If
                Next
            End If
            Return str.ToString()
        End Function

        ''' <summary>
        ''' Make conversion from list of LinkData objects to string which represents list in JSON format
        ''' </summary>
        ''' <param name="list">IList of LinkDat objects</param>
        ''' <returns>string which represents list in JSON format</returns>
        Public Function LinkListToJSONString(ByVal list As IList(Of LinkData)) As String
            Dim list2 As IList(Of IJSONSerialize) = New List(Of IJSONSerialize)()
            For Each ld As LinkData In list
                list2.Add(ld)
            Next
            Return JSONListToJSONString(list2)
        End Function
    End Module
End Namespace

