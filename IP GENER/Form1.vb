Public Class Form1
    ' u will understand later
    Dim a As String = "."
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' pass on the start ip and end ip to a counter function upon the page load

        '
        'ReadVal()
    End Sub
    'main function ro recognize the values change and update it accordingly
    Private Sub ReadVal() 
        'take in the box values for IP Range 1
        Dim a As String = NumericUpDown4.Value.ToString()
        Dim b As String = NumericUpDown3.Value.ToString()
        Dim c As String = NumericUpDown2.Value.ToString()
        Dim d As String = NumericUpDown1.Value.ToString()
        'Console.WriteLine(a)
        Dim IP1 As String = d + "." + c + "." + b + "." + a
        'Console.WriteLine(IP1)
        'take in the box values for IP Range 2
        Dim a1 As String = NumericUpDown5.Value.ToString()
        Dim b1 As String = NumericUpDown6.Value.ToString()
        Dim c1 As String = NumericUpDown7.Value.ToString()
        Dim d1 As String = NumericUpDown8.Value.ToString()
        'Console.WriteLine(a)
        Dim IP2 As String = d1 + "." + c1 + "." + b1 + "." + a1
        'Console.WriteLine(IP2)
        Counter(IP1, IP2)
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

    Private Sub LoadDifference(a As Double)
        TextBox3.Text = a
        Button1.Enabled = True
    End Sub
    Private Sub LoadDifference2(a As Double)
        'If Form1
        'TextBox3.Text = ""
        'Console.WriteLine(TextBox3.Text)
        'Dim b As Double = CDbl(TextBox3.Text)
        'Console.WriteLine(b)
        'a = a * -1
        'If a < 0 Then
        If a < 0 Then
            TextBox3.Text = a
            Button1.Enabled = False
            Dim btn = Button1()
            btn.BackColor = SystemColors.GradientActiveCaption
        End If
    End Sub

    ' found the count and now after that display it on the counter
    ' Create a function with 2 params as Strings that is the conjoined value of 4 boxes
    Private Sub Counter(IP1 As String, IP2 As String)
        Dim startiprange As Net.IPAddress = Net.IPAddress.Parse(IP1)
        Dim endiprange As Net.IPAddress = Net.IPAddress.Parse(IP2)

        'reverse address bytes for conversion to integer
        Dim strtip() As Byte = startiprange.GetAddressBytes
        Array.Reverse(strtip)
        Dim endip() As Byte = endiprange.GetAddressBytes
        Array.Reverse(endip)

        'convert
        Dim ips As UInt32 = BitConverter.ToUInt32(strtip, 0)
        Dim ipe As UInt32 = BitConverter.ToUInt32(endip, 0)
        Dim c As Double = 0
        Dim k1 As Double = Convert.ToDouble(ips)
        Dim k2 As Double = Convert.ToDouble(ipe)
        'Dim Diff As UInt32 = ips - ipe
        Console.WriteLine(ips)
        Console.WriteLine(ipe)
        If ips > ipe Then
            Console.WriteLine("Smaller")
            Dim c1 As Double = Convert.ToDouble(ips)
            Dim c2 As Double = Convert.ToDouble(ipe)
            Console.WriteLine(c2 - c1)
            LoadDifference2(c2 - c1)
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
    Private Sub NumericUpDown5_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown5.ValueChanged
        ReadVal()
    End Sub
End Class