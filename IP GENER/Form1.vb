Public Class Form1
    ' u will understand later
    Dim a As String = "."

    'main function ro recognize the values change and update it accordingly
    Private Sub ReadVal() 
        'take in the box values for IP Range 1
        Dim a As String = NumericUpDown4.Value.ToString()
        Dim b As String = NumericUpDown3.Value.ToString()
        Dim cs As String = NumericUpDown2.Value.ToString()
        Dim d As String = NumericUpDown1.Value.ToString()
        'Console.WriteLine(a)
        Dim IP1 As String = d + "." + cs + "." + b + "." + a

        'Console.WriteLine(IP1)
        'take in the box values for IP Range 2
        Dim ass As String = NumericUpDown5.Value.ToString()
        Dim bs As String = NumericUpDown6.Value.ToString()
        Dim css As String = NumericUpDown7.Value.ToString()
        Dim ds As String = NumericUpDown8.Value.ToString()
        'Console.WriteLine(a)
        Dim IP2 As String = ds + "." + css + "." + bs + "." + ass
        'Console.WriteLine(IP2)
        'Console.WriteLine(ass + bs + css + ds)
        If IP1 = "" Then
            IP1 = "198.198.1.0"
            IP2 = "198.198.1.255"
        ElseIf IP2 = "0.0.0.255" Or IP2 = "0.0.0.0" Then
            IP2 = "198.198.1.255"
        End If


        Dim startiprange As Net.IPAddress = Net.IPAddress.Parse(IP1)
        Dim endiprange As Net.IPAddress = Net.IPAddress.Parse(IP2)
        'Console.WriteLine(startiprange)
        'Console.WriteLine(endiprange)
        'Console.WriteLine(IP1)
        'Console.WriteLine(IP2)
        'reverse address bytes for conversion to integer
        Dim strtip() As Byte = startiprange.GetAddressBytes
        Array.Reverse(strtip)
        Dim endip() As Byte = endiprange.GetAddressBytes
        Array.Reverse(endip)
        ' found the count and now after that display it on the counter
        'convert
        Dim ips As UInt32 = BitConverter.ToUInt32(strtip, 0)
        Dim ipe As UInt32 = BitConverter.ToUInt32(endip, 0)
        Dim c As Double = 0
        Dim k1 As Double = Convert.ToDouble(ips)
        Dim k2 As Double = Convert.ToDouble(ipe)
        If TextBox3.Text = "" Then
            TextBox3.Text = "0"
        End If


        'Dim Diff As UInt32 = ips - ipe
        'Console.WriteLine(ips)
        'Console.WriteLine(ipe)
        If ips > ipe Then
            'Console.WriteLine("Smaller")
            Dim c1 As Double = Convert.ToDouble(ips)
            Dim c2 As Double = Convert.ToDouble(ipe)
            'Console.WriteLine(c2 - c1)
            Dim cont As Double = Convert.ToDouble(TextBox3.Text)
            LoadDifference(c2 - c1)
            'MsgBox("NEGATIVE COUNT")
            If (k1 > k2) Then

                MsgBox("Count In The Negative Range")
            End If
        ElseIf k1 = k2 Then
            LoadDifference(0)
        Else
            For anip As UInt32 = ips To ipe
                Dim ipbyt() As Byte = BitConverter.GetBytes(anip)
                'reverse and create ip address
                Array.Reverse(ipbyt)
                Dim ipaddr As New Net.IPAddress(ipbyt)
                'Debug.WriteLine(ipaddr.ToString)
                c = c + 1
            Next
            'Console.WriteLine(c)
            'c = c
            LoadDifference(c)
        End If

    End Sub

    ' display the difference into the counter before adding the subnet
    Private Sub NumericUpDown4_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown4.ValueChanged
        'take in the box values for IP Range 1

        ReadVal()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub

    'Add On Later
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Update into Database
        Console.WriteLine("CLICKED THE SAVE BUTTON")
    End Sub

    Private Sub NumericUpDown5_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown5.ValueChanged
        ReadVal()
    End Sub
    'the number of IP in the ranges
    Private Sub LoadDifference(a As Double)
        Try
            If a <= 0 Then
                TextBox3.Text = a
                Button1.Enabled = False
            Else
                TextBox3.Text = a
                Button1.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub NumericUpDown8_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown8.ValueChanged

    End Sub

    Private Sub NumericUpDown7_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown7.ValueChanged

    End Sub

    Private Sub NumericUpDown6_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown6.ValueChanged

    End Sub
End Class