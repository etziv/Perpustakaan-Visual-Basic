Imports MySql.Data.MySqlClient
Public Class mngbook

    Sub tampil_data()
        cmd = New MySqlCommand("Select * from dbook", cn)
        rd = cmd.ExecuteReader
        DataGridView1.Rows.Clear()
        Do While rd.Read = True
            DataGridView1.Rows.Add(rd(0), rd(1), rd(2), rd(3), rd(4))
        Loop
    End Sub

    Sub bersih()
        TxtNoBuku.Clear()
        TxtJudul.Clear()
        TxtPenerbit.Clear()
        TxtPengarang.Clear()
        TxtThn.Clear()
        TxtNoBuku.Focus()
    End Sub

    Private Sub mngbook_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call connect()
        Call tampil_data()
    End Sub

    Private Sub BtnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCari.Click
        If TxtNoBuku.Text = "" Then
            MessageBox.Show("Masukan Nomor Buku !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Call connect()
            cmd = New MySqlCommand("Select * from dbook where nobuku= '" & TxtNoBuku.Text & "'", cn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows = True Then
                TxtJudul.Text = rd.Item("judul")
                TxtThn.Text = rd.Item("tahun")
                TxtPengarang.Text = rd.Item("pengarang")
                TxtPenerbit.Text = rd.Item("penerbit")
                DataGridView1.Rows.Clear()
                DataGridView1.Rows.Add(rd(0), rd(1), rd(2), rd(3), rd(4))
            Else
                MessageBox.Show("Data Tidak Ada !", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub BtnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClear.Click
        Call connect()
        Call bersih()
        Call tampil_data()
    End Sub

    Private Sub BtnTambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTambah.Click
        If TxtJudul.Text = "" Or TxtNoBuku.Text = "" Or TxtThn.Text = "" Or TxtPengarang.Text = "" Or TxtPenerbit.Text = "" Then
            MessageBox.Show("Kolom Tidak Boleh Kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Call connect()
            cmd = New MySqlCommand("Select * from dbook where nobuku = '%" & TxtNoBuku.Text & "%'", cn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows = False Then
                Call connect()
                cmd = New MySqlCommand("insert into dbook values('" & TxtNoBuku.Text & _
                                       "', '" & TxtJudul.Text & _
                                       "', '" & TxtThn.Text & _
                                       "', '" & TxtPengarang.Text & _
                                       "', '" & TxtPenerbit.Text & "')", cn)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Data Berhasil Ditambah", "Tambah", MessageBoxButtons.OK)
                Call tampil_data()
                Call bersih()
            Else
                MessageBox.Show("ID Buku Sudah Ada !", "Tambah", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub BtnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSimpan.Click
        Call connect()
        cmd = New MySqlCommand("Select * from dbook where nobuku like '%" & TxtNoBuku.Text & "%'", cn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows = True Then
            Call connect()
            cmd = New MySqlCommand("update dbook set judul='" & TxtJudul.Text & _
                                    "',tahun= '" & TxtThn.Text & _
                                    "',pengarang= '" & TxtPengarang.Text & _
                                    "',penerbit= '" & TxtPenerbit.Text & _
                                    "'where nobuku='" & TxtNoBuku.Text & "'", cn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Berhasil Diubah", "Simpan", MessageBoxButtons.OK)
            Call tampil_data()
            Call bersih()
        Else
            MessageBox.Show("Tidak Ada Data Yang Sesuai !", "Simpan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BtnHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHapus.Click
        Call connect()
        If MessageBox.Show("Apakah anda ingin menghapus data ini ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            cmd = New MySqlCommand("delete from dbook where nobuku='" & TxtNoBuku.Text & "'", cn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Berhasil Dihapus !", "Hapus", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call bersih()
            Call tampil_data()
        End If
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
End Class