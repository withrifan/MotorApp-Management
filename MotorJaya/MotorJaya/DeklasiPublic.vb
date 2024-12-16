Imports System.Data.OleDb

Module DeklasiPublic
    Public CONN As OleDbConnection
    Public DA As OleDbDataAdapter
    Public DS As DataSet
    Public DT As DataTable
    Public CMD As OleDbCommand
    Public DR As OleDbDataReader

    Public Sub SambungData()
        Try
            ' Menggunakan provider yang sesuai dengan versi Access
            CONN = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\achmadrifan\Documents\semester3\basis-data\ProjectMotor\MotorJaya\MahaMotor.mdb")
            CONN.Open()
            MsgBox("Data Berhasil Terhubung", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Koneksi Gagal: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Module
