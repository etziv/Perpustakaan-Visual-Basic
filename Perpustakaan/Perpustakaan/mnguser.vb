Imports MySql.Data.MySqlClient
Public Class mnguser
    Sub tampil_data()
        cmd = New MySqlCommand("Select * from duser", cn)
        rd = cmd.ExecuteReader
        DataGridView1.Rows.Clear()
        Do While rd.Read = True
            DataGridView1.Rows.Add(rd(0), rd(1), rd(2), rd(3), rd(4), rd(5))
        Loop
    End Sub

    Sub bersih()
        TxtUserid.Clear()
        TxtNama.Clear()
        TxtTtl.Clear()
        TxtNoTlp.Clear()
        CmbGndr.ResetText()
        TxtAlamat.Clear()
        TxtUserid.Focus()
        TxtPass.Clear()
    End Sub

    Private Sub mnguser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call connect()
        Call tampil_data()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnTambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTambah.Click
        If TxtUserid.Text = "" Or TxtNama.Text = "" Or TxtNoTlp.Text = "" Or TxtNoTlp.Text = "" Or TxtAlamat.Text = "" Or TxtPass.Text = "" Or CmbGndr.Text = "Pilih..." Then
            MessageBox.Show("Kolom Tidak Boleh Kosong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Call connect()
            cmd = New MySqlCommand("Select * from duser where userid = '" & TxtUserid.Text & "'", cn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows = False Then
                Call connect()
                cmd = New MySqlCommand("insert into duser values('" & TxtUserid.Text & _
                                       "', '" & TxtNama.Text & _
                                       "', '" & TxtTtl.Text & _
                                       "', '" & CmbGndr.Text & _
                                       "', '" & TxtNoTlp.Text & _
                                       "', '" & TxtAlamat.Text & _
                                       "', '" & TxtPass.Text & "')", cn)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Data Berhasil Ditambahkan", "Tambah", MessageBoxButtons.OK)
                Call tampil_data()
                Call bersih()
            Else
                MessageBox.Show("UserID sudah digunakan !", "Tambah", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub BtnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSimpan.Click
        Call connect()
        cmd = New MySqlCommand("Select * from duser where userid like '%" & TxtUserid.Text & "%'", cn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows = True Then
            Call connect()
            cmd = New MySqlCommand("update duser set nama='" & TxtNama.Text & _
                                       "',tgl_lahir= '" & TxtTtl.Text & _
                                       "',gender= '" & CmbGndr.Text & _
                                       "',notlp= '" & TxtNoTlp.Text & _
                                       "',alamat= '" & TxtAlamat.Text & _
                                       "',pass= '" & TxtPass.Text & _
                                       "'where userid='" & TxtUserid.Text & "'", cn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Berhasil Diubah", "Ubah", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call tampil_data()
            Call bersih()
        Else
            MessageBox.Show("Tidak Ada Data Yang Sesuai !", "Ubah", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BtnHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHapus.Click
        Call connect()
        If MessageBox.Show("Apakah anda ingin menghapus data ini ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            cmd = New MySqlCommand("delete from duser where userid='" & TxtUserid.Text & "'", cn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Berhasil Dihapus !", "Hapus", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call bersih()
            Call tampil_data()
        End If
    End Sub

    Private Sub BtnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClear.Click
        Call connect()
        Call bersih()
        Call tampil_data()
    End Sub

    Private Sub BtnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCari.Click
        If TxtUserid.Text = "" Then
            MessageBox.Show("UserID Kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Call connect()
            cmd = New MySqlCommand("Select * from duser where userid like '" & TxtUserid.Text & "'", cn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows = True Then
                TxtNama.Text = rd.Item("nama")
                TxtTtl.Text = rd.Item("tgl_lahir")
                CmbGndr.Text = rd.Item("gender")
                TxtNoTlp.Text = rd.Item("notlp")
                TxtAlamat.Text = rd.Item("alamat")
                TxtPass.Text = rd.Item("pass")
                DataGridView1.Rows.Clear()
                DataGridView1.Rows.Add(rd(0), rd(1), rd(2), rd(3), rd(4), rd(5))
            Else
                MessageBox.Show("Data Tidak Ada !", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
End Class