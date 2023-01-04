



Public Class Form1
    Dim sql As String
    Dim cmd As New OleDb.OleDbCommand
    Dim con As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Lenovo\Documents\Database4.accdb")
    Public dr As OleDb.OleDbDataReader
    Dim Gender As Integer


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ConnectionState.Open Then
            con.Close()
        End If
        If Radio1.Checked = True Then
            Gender = 1
        End If
        If Radio2.Checked = True Then
            Gender = 2
        End If
        If Radio3.Checked = True Then
            Gender = 3
        End If

        If txtf.Text = "" Or txtm.Text = "" Or txtl.Text = "" Or cmbst.Text = "" Or txtay.Text = "" Or txta.Text = "" Or dtpd.Text = "" Or txtpl.Text = "" Or txtn.Text = "" Or txtrc.Text = "" Or txtmt.Text = "" Or txtfn.Text = "" Or txtfa.Text = "" Or txtmad.Text = "" Or txtfno.Text = "" Or cmbfe.Text = "" Or txtfoc.Text = "" Or txtman.Text = "" Or txtmn.Text = "" Or txtma.Text = "" Or txtfadd.Text = "" Or txtmno.Text = "" Or cmbme.Text = "" Or txtmoc.Text = "" Or txtfan.Text = "" Then


            MsgBox("enter Info ")
        Else
            con.Open()
            Dim sqlQry As String = "INSERT INTO [stinfo] ([fname],[mname],[lname],[std],[adyear],[adhar],[gender],[bod],[place],[nation],[caste],[mtounge],[ffname],[fage],[fadd],[fmono],[fedu],[foccu],[fanu],[mfname],[mage],[madd],[mmono],[medu],[moccu],[manu]) VALUES (@txtf,@txtm,@txtl,@cmbst,@txtay,@txta,@Gender,@dtpd,@txtpl,@txtn,@txtrc,@txtmt,@txtfn,@txtfa,@txtfadd,@txtfno,@cmbfe,@txtfoc,@txtfan,@txtmn,@txtma,@txtmad,@txtmno,@cmbme,@txtmoc,@txtman)"

            Using cmd As New OleDb.OleDbCommand(sqlQry, con)
                cmd.Parameters.AddWithValue("fname", txtf.Text)
                cmd.Parameters.AddWithValue("mname", txtm.Text)
                cmd.Parameters.AddWithValue("lname", txtl.Text)
                cmd.Parameters.AddWithValue("std", cmbst.Text)
                cmd.Parameters.AddWithValue("adyear", txtay.Text)
                cmd.Parameters.AddWithValue("adhar", txta.Text)
                cmd.Parameters.AddWithValue("Gender", Gender)
                cmd.Parameters.AddWithValue("bod", dtpd.Value.Date)
                cmd.Parameters.AddWithValue("place", txtpl.Text)
                cmd.Parameters.AddWithValue("nation", txtn.Text)
                cmd.Parameters.AddWithValue("caste", txtrc.Text)
                cmd.Parameters.AddWithValue("mtounge", txtmt.Text)
                cmd.Parameters.AddWithValue("ffname", txtfn.Text)
                cmd.Parameters.AddWithValue("fage", txtfa.Text)
                cmd.Parameters.AddWithValue("fadd", txtfadd.Text)
                cmd.Parameters.AddWithValue("fmono", txtfno.Text)
                cmd.Parameters.AddWithValue("fedu", cmbfe.Text)
                cmd.Parameters.AddWithValue("foccu", txtfoc.Text)
                cmd.Parameters.AddWithValue("fanu", txtfan.Text)
                cmd.Parameters.AddWithValue("mfname", txtmn.Text)
                cmd.Parameters.AddWithValue("mage", txtma.Text)
                cmd.Parameters.AddWithValue("madd", txtmad.Text)
                cmd.Parameters.AddWithValue("mmono", txtmno.Text)
                cmd.Parameters.AddWithValue("medu", cmbme.Text)
                cmd.Parameters.AddWithValue("moccu", txtmoc.Text)
                cmd.Parameters.AddWithValue("manu", txtman.Text)
                cmd.ExecuteNonQuery()

            End Using
            MsgBox("Data Added Successfuly")
            txtf.Text = ""
            txtm.Text = ""
            txtl.Text = ""
            cmbst.Text = ""
            txtay.Text = ""
            txta.Text = ""
            dtpd.Text = ""
            txtpl.Text = ""
            txtn.Text = ""
            txtrc.Text = ""
            txtmt.Text = ""
            txtfn.Text = ""
            txtfa.Text = ""
            txtmad.Text = ""
            txtfno.Text = ""
            cmbfe.Text = ""
            txtfoc.Text = ""
            txtman.Text = ""
            txtmn.Text = ""
            txtma.Text = ""
            txtfadd.Text = ""
            txtmno.Text = ""
            cmbme.Text = ""
            txtmoc.Text = ""
            txtfan.Text = ""

            con.Close()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ConnectionState.Open Then
            con.Close()
        End If
        con.Open()

        Dim str As String
        Dim fname = ComboBox1.Text

        str = "select * from stinfo where fname = '" & fname & "'"

        Dim amd As OleDb.OleDbCommand = New OleDb.OleDbCommand(str, con)
        dr = amd.ExecuteReader

        While dr.Read()
            txtf.Text = dr("fname").ToString
            txtm.Text = dr("mname").ToString
            txtl.Text = dr("lname").ToString
            cmbst.Text = dr("std").ToString
            txtay.Text = dr("adyear").ToString
            txta.Text = dr("adhar").ToString
            dtpd.Text = dr("bod").ToString
            txtpl.Text = dr("place").ToString
            txtn.Text = dr("nation").ToString
            txtrc.Text = dr("caste").ToString
            txtmt.Text = dr("mtounge").ToString
            txtfn.Text = dr("ffname").ToString
            txtfa.Text = dr("fage").ToString
            txtfadd.Text = dr("fadd").ToString
            txtfno.Text = dr("fmono").ToString
            cmbfe.Text = dr("fedu").ToString
            txtfoc.Text = dr("foccu").ToString
            txtman.Text = dr("fanu").ToString
            txtmn.Text = dr("mfname").ToString
            txtma.Text = dr("mage").ToString
            txtmad.Text = dr("madd").ToString
            txtmno.Text = dr("mmono").ToString
            cmbme.Text = dr("medu").ToString
            txtmoc.Text = dr("moccu").ToString
            txtfan.Text = dr("manu").ToString
            If dr("gender").ToString = "1" Then
                Radio1.Checked = True
            End If
            If dr("gender").ToString = "2" Then
                Radio2.Checked = True
            End If
            If dr("gender").ToString = "3" Then
                Radio3.Checked = True
            End If
        End While
        con.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If ConnectionState.Open Then
            con.Close()
        End If
        con.Open()

        Dim aas As String
        Dim fname = ComboBox1.Text

        aas = "delete * from stinfo where fname = '" & fname & "'"
        Dim amd As New OleDb.OleDbCommand(aas, con)
        dr = amd.ExecuteReader
        con.Close()
        MsgBox("Info of selected student is deleted")

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        If Radio1.Checked = True Then
            Gender = 1
        End If
        If Radio2.Checked = True Then
            Gender = 2
        End If
        If Radio3.Checked = True Then
            Gender = 3
        End If

        Dim asd As String
        asd = " update [stinfo] set fname = '" & txtf.Text & "' , mname = '" & txtm.Text & "' , lname = '" & txtl.Text & "' , std = '" & cmbst.Text & "' , adyear = '" & txtay.Text & "' , adhar = '" & txta.Text & "' , gender = '" & Gender & "' ,  bod = '" & dtpd.Value.Date & "' , place = '" & txtpl.Text & "' , nation = '" & txtn.Text & "' , caste = '" & txtrc.Text & "' , mtounge = '" & txtmt.Text & "' , ffname = '" & txtfn.Text & "' , fage = '" & txtfa.Text & "' , fadd = '" & txtfadd.Text & "' , fmono = '" & txtfno.Text & "' , fedu = '" & cmbfe.Text & "' , foccu = '" & txtfoc.Text & "' , fanu = '" & txtman.Text & "' , mfname = '" & txtmn.Text & "' , mage = '" & txtma.Text & "' , madd = '" & txtmad.Text & "' , mmono = '" & txtmno.Text & "' , medu = '" & cmbme.Text & "' , moccu = '" & txtmoc.Text & "' , manu= '" & txtfan.Text & "' where fname = '" & ComboBox1.Text & "'"
        Dim amd As OleDb.OleDbCommand = New OleDb.OleDbCommand(asd, con)
        amd.ExecuteNonQuery()
        con.Close()
        MsgBox("Info Updated successfully")
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim cmd As New OleDb.OleDbCommand("Select * from [stinfo]", con)

        Dim adapter As New OleDb.OleDbDataAdapter(cmd)

        Dim table As New DataTable

        adapter.Fill(table)

        ComboBox1.DataSource = table
        ComboBox1.DisplayMember = table.Columns(1).ToString
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        txtf.Text = ""
        txtm.Text = ""
        txtl.Text = ""
        cmbst.Text = ""
        txtay.Text = ""
        txta.Text = ""
        dtpd.Text = ""
        txtpl.Text = ""
        txtn.Text = ""
        txtrc.Text = ""
        txtmt.Text = ""
        txtfn.Text = ""
        txtfa.Text = ""
        txtmad.Text = ""
        txtfno.Text = ""
        cmbfe.Text = ""
        txtfoc.Text = ""
        txtman.Text = ""
        txtmn.Text = ""
        txtma.Text = ""
        txtfadd.Text = ""
        txtmno.Text = ""
        cmbme.Text = ""
        txtmoc.Text = ""
        txtfan.Text = ""
    End Sub
End Class

