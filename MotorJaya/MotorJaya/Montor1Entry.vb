Imports System.Data.OleDb
Public Class Montor1Entry
    Private Sub Montor1Entry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SambungData()
        TampilGrid()
    End Sub

    Sub Kosong()
        txtKoMot.Clear()
        txtMotor.Clear()
        txtCC.Clear()
        txtWarna.Clear()
        txtTipe.Clear()
        txtMerk.Clear()
        txtHarga.Clear()
        picGambar.ImageLocation = Nothing
    End Sub

    Sub TampilGrid()
        DA = New OleDbDataAdapter("Select * From Motor", CONN)
        DS = New DataSet
        DA.Fill(DS)
        dgvMotor.DataSource = DS.Tables(0)
        dgvMotor.ReadOnly = True
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim SQL As String
        SQL = "Insert Into Motor Values ('" & txtKoMot.Text & "','" & txtMotor.Text & "','" & txtCC.Text & "'"
        SQL += ",'" & txtWarna.Text & "','" & txtTipe.Text & "','" & txtMerk.Text & "','" & txtHarga.Text & "')"
        CMD = New OleDbCommand(SQL, CONN)
        CMD.ExecuteNonQuery()
        MessageBox.Show("Penyimpanan Data Berhasil", "SAVE", MessageBoxButtons.OK)
        TampilGrid()
        Kosong()
    End Sub

    Private Sub dgvMotor_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMotor.CellContentClick
        txtKoMot.Text = dgvMotor.Rows(e.RowIndex).Cells(0).Value
        txtMotor.Text = dgvMotor.Rows(e.RowIndex).Cells(1).Value
        txtCC.Text = dgvMotor.Rows(e.RowIndex).Cells(2).Value
        txtWarna.Text = dgvMotor.Rows(e.RowIndex).Cells(3).Value
        txtTipe.Text = dgvMotor.Rows(e.RowIndex).Cells(4).Value
        txtMerk.Text = dgvMotor.Rows(e.RowIndex).Cells(5).Value
        txtHarga.Text = dgvMotor.Rows(e.RowIndex).Cells(6).Value
        picGambar.ImageLocation = "C:\Users\achmadrifan\Documents\semester3\basis-data\ProjectMotor\GambarJavaProg\" & txtKoMot.Text & ".PNG"
    End Sub

    Private Sub btSelesai_Click(sender As Object, e As EventArgs) Handles btSelesai.Click
        If MessageBox.Show("Yakin hendak Keluar?", "Konfirmasi", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub btKosong_Click(sender As Object, e As EventArgs) Handles btKosong.Click
        If MessageBox.Show("Yakin hendak Mengkosongkan?", "Konfirmasi", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Kosong()
        End If
    End Sub

    Private Sub txtKoMot_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKoMot.KeyPress
        If e.KeyChar = Chr(13) Then ' Tombol Enter ditekan
            Try
                Dim SQL As String = "SELECT * FROM Motor WHERE IdMotor = '" & txtKoMot.Text & "'"
                CMD = New OleDbCommand(SQL, CONN)
                DR = CMD.ExecuteReader()

                If DR.HasRows Then
                    DR.Read()
                    txtMotor.Text = DR("Motor").ToString()
                    txtCC.Text = DR("CC").ToString()
                    txtWarna.Text = DR("Warna").ToString()
                    txtTipe.Text = DR("Tipe").ToString()
                    txtMerk.Text = DR("Merk").ToString()
                    txtHarga.Text = DR("Harga").ToString()
                    picGambar.ImageLocation = "C:\Users\achmadrifan\Documents\semester3\basis-data\ProjectMotor\GambarJavaProg\" & txtKoMot.Text & ".PNG"
                Else
                    MessageBox.Show("Data motor tidak ditemukan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Kosong()
                End If
            Catch ex As Exception
                MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub txtMotor_TextChanged(sender As Object, e As EventArgs) Handles txtMotor.TextChanged
        Dim SQL As String = "SELECT * FROM Motor WHERE Motor LIKE '%" & txtMotor.Text & "%'"
        DA = New OleDbDataAdapter(SQL, CONN)
        DS = New DataSet
        DA.Fill(DS)

        ' Tampilkan hasil pencarian di DataGridView
        dgvMotor.DataSource = DS.Tables(0)

        ' Jika hanya satu hasil ditemukan, tampilkan detailnya
        If DS.Tables(0).Rows.Count = 1 Then
            txtKoMot.Text = DS.Tables(0).Rows(0)("IdMotor").ToString()
            txtMotor.Text = DS.Tables(0).Rows(0)("Motor").ToString()
            txtCC.Text = DS.Tables(0).Rows(0)("CC").ToString()
            txtWarna.Text = DS.Tables(0).Rows(0)("Warna").ToString()
            txtTipe.Text = DS.Tables(0).Rows(0)("Tipe").ToString()
            txtMerk.Text = DS.Tables(0).Rows(0)("Merk").ToString()
            txtHarga.Text = DS.Tables(0).Rows(0)("Harga").ToString()

            ' Tampilkan gambar motor
            picGambar.ImageLocation = "C:\Users\achmadrifan\Documents\semester3\basis-data\ProjectMotor\GambarJavaProg" & txtKoMot.Text & ".PNG"
        End If
    End Sub

End Class
