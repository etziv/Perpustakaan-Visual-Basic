Imports MySql.Data.MySqlClient
Public Class mybook

    Sub tampil_data()
        cmd = New MySqlCommand("Select * from dpinjam where judul like '%" & TxtUserid.Text & "%'", cn)
        rd = cmd.ExecuteReader
        DataGridView1.Rows.Clear()
        Do While rd.Read = True
            DataGridView1.Rows.Add(rd(1), rd(2))
        Loop
    End Sub
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
        login.Close()
    End Sub

    Private Sub BtnKmblkn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKmblkn.Click
        peminjaman.Show()
        peminjaman.TxtUserid.Text = TxtUserid.Text
        peminjaman.LblPnjmn.Text = "Pengembalian"
        peminjaman.BtnPinjam.Text = "Kembalikan"
        login.Close()
    End Sub

    Private Sub mybook_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call connect()
        cmd = New MySqlCommand("Select * from dpinjam where userid like '%" & login.TxtUsername.Text & "%'", cn)
        rd = cmd.ExecuteReader
        DataGridView1.Rows.Clear()
        Do While rd.Read = True
            DataGridView1.Rows.Add(rd(1), rd(2))
        Loop
    End Sub

    Private Sub BtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click
        Call connect()
        cmd = New MySqlCommand("Select * from dpinjam where userid like '%" & TxtUserid.Text & "%'", cn)
        rd = cmd.ExecuteReader
        DataGridView1.Rows.Clear()
        Do While rd.Read = True
            DataGridView1.Rows.Add(rd(1), rd(2))
        Loop
    End Sub
End Class