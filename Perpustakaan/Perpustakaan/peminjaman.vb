Imports MySql.Data.MySqlClient
Public Class peminjaman
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
        login.Close()
    End Sub

    Private Sub BtnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCari.Click
        If TxtNoBuku.Text = "" Then
            MessageBox.Show("Masukan Nomor Buku !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf LblPnjmn.Text = "Peminjaman" Then
            Call connect()
            cmd = New MySqlCommand("Select * from dbook where nobuku= '" & TxtNoBuku.Text & "'", cn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows = True Then
                TxtJudul.Text = rd.Item("judul")
                TxtThn.Text = rd.Item("tahun")
                TxtPengarang.Text = rd.Item("pengarang")
                TxtPenerbit.Text = rd.Item("penerbit")
            Else
                MessageBox.Show("Anda tidak meminjam Buku dengan No.Buku ini !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        ElseIf LblPnjmn.Text = "Pengembalian" Then
            Call connect()
            cmd = New MySqlCommand("Select * from dpinjam where nobuku= '" & TxtNoBuku.Text & "'", cn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows = True Then
                TxtJudul.Text = rd.Item("judul")
                Call connect()
                cmd = New MySqlCommand("Select * from dbook where nobuku= '" & TxtNoBuku.Text & "'", cn)
                rd = cmd.ExecuteReader
                rd.Read()
                If rd.HasRows = True Then
                    TxtThn.Text = rd.Item("tahun")
                    TxtPengarang.Text = rd.Item("pengarang")
                    TxtPenerbit.Text = rd.Item("penerbit")
                End If
            Else
                MessageBox.Show("Tidak ada No.Buku yang sesuai !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If
    End Sub

    Private Sub BtnPinjam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPinjam.Click
        If BtnPinjam.Text = "Pinjam" Then
            If MessageBox.Show("Apa anda yakin ingin meminjam buku ini?", "Pinjam", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                Call connect()
                cmd = New MySqlCommand("Select * from dpinjam where userid = '" & TxtUserid.Text & "'", cn)
                rd = cmd.ExecuteReader
                rd.Read()
                If rd.HasRows = True Then
                    Call connect()
                    cmd = New MySqlCommand("Select * from dpinjam where nobuku = '" & TxtNoBuku.Text & "'", cn)
                    rd = cmd.ExecuteReader
                    rd.Read()
                    If rd.HasRows = False Then
                        Call connect()
                        cmd = New MySqlCommand("insert into dpinjam values('" & TxtUserid.Text & _
                                               "', '" & TxtNoBuku.Text & _
                                               "', '" & TxtJudul.Text & "')", cn)
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Buku Berhasil Dipinjam", "Peminjaman", MessageBoxButtons.OK)
                        TxtNoBuku.Clear()
                        TxtJudul.Clear()
                        TxtPengarang.Clear()
                        TxtThn.Clear()
                        TxtPenerbit.Clear()
                    Else
                        MessageBox.Show("Anda sudah meminjam buku ini !", "Peminjaman", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    Call connect()
                    cmd = New MySqlCommand("Select * from dpinjam where nobuku = '" & TxtNoBuku.Text & "'", cn)
                    rd = cmd.ExecuteReader
                    rd.Read()
                    If rd.HasRows = True Then
                        Call connect()
                        cmd = New MySqlCommand("insert into dpinjam values('" & TxtUserid.Text & _
                                               "', '" & TxtNoBuku.Text & _
                                               "', '" & TxtJudul.Text & "')", cn)
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Buku Berhasil Dipinjam", "Peminjaman", MessageBoxButtons.OK)
                        TxtNoBuku.Clear()
                        TxtJudul.Clear()
                        TxtPengarang.Clear()
                        TxtThn.Clear()
                        TxtPenerbit.Clear()
                    Else
                        MessageBox.Show("Anda sudah meminjam buku ini !", "Peminjaman", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        ElseIf BtnPinjam.Text = "Kembalikan" Then
            Call connect()
            If MessageBox.Show("Apakah anda ingin mengembalikan buku ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                MessageBox.Show("Konfirmasi Ke-Admin untuk melanjutkan proses ini", "Konfirmasi Admin", MessageBoxButtons.OK)
                login.Show()
                login.LblLog.Text = "Konfirmasi Admin"
            End If
        End If
    End Sub
End Class