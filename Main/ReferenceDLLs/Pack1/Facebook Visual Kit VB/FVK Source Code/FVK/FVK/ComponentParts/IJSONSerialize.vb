Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace FVK
    ''' <summary>
    ''' This interface uses for convesion from object data to JSON format
    ''' </summary>
    Public Interface IJSONSerialize
        ''' <summary>
        ''' Serialize object to JSON format
        ''' </summary>
        ''' <returns>JSON format string</returns>
        Function JSONSerialize() As String
    End Interface
End Namespace

