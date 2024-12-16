Imports System.Data.OleDb

Public Class Motor2Edit
    Private Sub Motor2Edit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SambungData()
        TampilGrid()
    End Sub

    Sub TampilGrid()
        DA = New OleDbDataAdapter("Select * From Motor", CONN)
        DS = New DataSet
        DA.Fill(DS)
        dgvMotor.DataSource = DS.Tables(0)
        dgvMotor.ReadOnly = True
    End Sub

    Sub Kosong()
        txtKoMot.Text = ""
        txtMotor.Text = ""
        txtCC.Text = ""
        txtWarna.Text = ""
        txtMerk.Text = ""
        txtHarga.Text = ""
        txtTipe.Text = ""
    End Sub

    Private Sub dgvMotor_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMotor.CellContentClick
        txtKoMot.Text = dgvMotor.Rows(e.RowIndex).Cells(0).Value
        txtMotor.Text = dgvMotor.Rows(e.RowIndex).Cells(1).Value
        txtCC.Text = dgvMotor.Rows(e.RowIndex).Cells(2).Value
        txtWarna.Text = dgvMotor.Rows(e.RowIndex).Cells(3).Value
        txtTipe.Text = dgvMotor.Rows(e.RowIndex).Cells(4).Value
        txtMerk.Text = dgvMotor.Rows(e.RowIndex).Cells(5).Value
        txtHarga.Text = dgvMotor.Rows(e.RowIndex).Cells(6).Value
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim SQL As String
        If txtKoMot.Text = "" Then
            ' Insert data baru
            SQL = "INSERT INTO Motor (Motor, CC, Warna, Tipe, Merk, Harga) VALUES ('" & txtMotor.Text & "','" & txtCC.Text & "','" & txtWarna.Text & "','" & txtTipe.Text & "','" & txtMerk.Text & "','" & txtHarga.Text & "')"
        Else
            ' Update data yang sudah ada
            SQL = "UPDATE Motor SET Motor = '" & txtMotor.Text & "', CC='" & txtCC.Text & "', Warna='" & txtWarna.Text & "', Tipe='" & txtTipe.Text & "', Merk='" & txtMerk.Text & "', Harga='" & txtHarga.Text & "' WHERE IdMotor='" & txtKoMot.Text & "'"
        End If
        CMD = New OleDbCommand(SQL, CONN)
        CMD.ExecuteNonQuery()
        TampilGrid()
        dgvMotor.Refresh()
        MessageBox.Show("Data Sudah Disimpan", "Lanjut", MessageBoxButtons.OK)
        Kosong()
    End Sub

    Private Sub btSelesai_Click(sender As Object, e As EventArgs) Handles btSelesai.Click
        MessageBox.Show("Yakin hendak Keluar?", "Lanjut", MessageBoxButtons.OK)
        Close()
    End Sub

    Private Sub btKosong_Click(sender As Object, e As EventArgs) Handles btKosong.Click
        Kosong()
    End Sub
End Class
