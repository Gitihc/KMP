Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim rzt As Boolean = KMPSearch("BBC ABCDAB ABCDABCDABDE", "ABCDABD")
    End Sub

#Region "获得匹配表"
    Public Function GetMatchTableValue(ByVal str As String) As String()
        Try
            Dim arry(str.Length - 1) As String

            For i As Integer = 0 To arry.Length - 1
                arry(i) = GetMatchValue(str.Substring(0, i + 1))
            Next
            Dim a = 1
            Return arry
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetMatchValue(ByVal str As String)
        Try
            If str.Length = 0 Then Return 0
            Dim pre(str.Length - 2) As String
            Dim lst(str.Length - 2) As String
            Dim sameCount As Integer = 0
            For i As Integer = 0 To str.Length - 2
                pre(i) = str.Substring(0, i + 1)
                lst(i) = str.Substring(i + 1)
            Next

            For Each itm In pre
                For Each litm In lst
                    If itm.Equals(litm) Then
                        Return itm.Length
                    End If
                Next
            Next
            Return 0
        Catch ex As Exception
            Return 0
        End Try
    End Function
#End Region

#Region "KMP 字符串匹配算法"
    Public Function KMPSearch(ByVal SourceString As String, ByVal Key As String) As Boolean
        Try
            Dim MatchTableValue() As String = GetMatchTableValue(Key)
            Dim matchStr As String = ""
            Dim kStart As Integer = 0
            For i As Integer = 0 To SourceString.Length - 1
                Dim sChar As String = SourceString.Substring(i, 1)
                For j As Integer = kStart To Key.Length - 1
                    Dim kChar As String = Key.Substring(j, 1)
                    If Not sChar.Equals(kChar) Then
                        If matchStr.Length > 0 Then
                            i += matchStr.Length - MatchTableValue(matchStr.Length - 1) - 1
                        End If
                        matchStr = ""
                        kStart = 0
                        Exit For
                    Else
                        matchStr += sChar
                        If Key.Equals(matchStr) Then
                            Return True
                        End If
                        kStart = j + 1
                        Exit For
                    End If
                Next
            Next
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region


End Class
