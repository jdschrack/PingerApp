Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Net
Imports System.Text
Module Module1
    Dim s As New StreamReader("C:\temp\servers.txt")
    Sub Main()
        Dim o As New StreamWriter("c:\temp\servers_out.csv", False)
        Dim line As String
        line = s.ReadLine

        Do While (Not line Is Nothing)
            Dim host As String = line
            PingMachine(host)
            line = s.ReadLine
        Loop
        o.Close()


    End Sub
    Private Sub PingMachine(ByVal System As String)

        'At every tick of the timer (depending on what you set the timer to)
        'it executes this code
        Dim hostString As String = System
        Dim pingResults As String
        Dim i As Integer = 0
        Try

            'ping the host and set the results variabl
            pingResults = My.Computer.Network.Ping(hostString, 300)

            If pingResults = True Then

                'if it was a previously dead host, alert the user it's back online
                'and reset the dead variable back to 0
                Console.WriteLine(System & " - Is Online")
            Else
                Console.WriteLine(System & " - Did not respond")
            End If
        Catch Ex As Exception

        End Try

    End Sub

End Module
