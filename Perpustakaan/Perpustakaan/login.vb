Imports MySql.Data.MySqlClient
Public Class login

    Private Sub login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TxtUsername.Focus()
        TxtPass.UseSystemPasswordChar = True
    End Sub
    Private Sub BtnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLogin.Click
        If LblLog.Text = "Administrator Access" Then
            Call connect()
            cmd = New MySqlCommand("Select * from dadmin where userid = '" & TxtUsername.Text & "' and pass = '" & TxtPass.Text & "'", cn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows = True Then
                MessageBox.Show("Login Berhasil", "Login", MessageBoxButtons.OK)
                Me.Close()
                main_menu.Show()
                main_menu.PnlMng.Visible = True
                main_menu.PnlLbry.Visible = False
                main_menu.PnlUser.Visible = False
                main_menu.Lbl1.Visible = False
                main_menu.Lbl2.Visible = False
                main_menu.Lbl3.Visible = True
                main_menu.LblX.Text = "Administrator"
            Else
                MessageBox.Show("Username Atau Password Salah !!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        ElseIf LblLog.Text = "MyProfile" Then
            Call connect()
            cmd = New MySqlCommand("Select * from duser where userid = '" & TxtUsername.Text & "' and pass = '" & TxtPass.Text & "'", cn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows = True Then
                MessageBox.Show("Login Berhasil", "Login", MessageBoxButtons.OK)
                Me.Hide()
                myprofile.Show()
                myprofile.TxtUserid.Text = rd.Item("userid")
                myprofile.TxtNama.Text = rd.Item("nama")
                myprofile.TxtNoTlp.Text = rd.Item("notlp")
                myprofile.TxtTtl.Text = rd.Item("tgl_lahir")
                myprofile.TxtGndr.Text = rd.Item("gender")
                myprofile.TxtAlamat.Text = rd.Item("alamat")
            Else
                MessageBox.Show("Username Atau Password Salah !!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        ElseIf LblLog.Text = "MyBook" Then
            Call connect()
            cmd = New MySqlCommand("Select * from duser where userid = '" & TxtUsername.Text & "' and pass = '" & TxtPass.Text & "'", cn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows = True Then
                MessageBox.Show("Login Berhasil", "Login", MessageBoxButtons.OK)
                Me.Hide()
                mybook.Show()
                mybook.TxtUserid.Text = TxtUsername.Text
            Else
                MessageBox.Show("Username Atau Password Salah !!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        ElseIf LblLog.Text = "Peminjaman" Then
            Call connect()
            cmd = New MySqlCommand("Select * from duser where userid = '" & TxtUsername.Text & "' and pass = '" & TxtPass.Text & "'", cn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows = True Then
                MessageBox.Show("Login Berhasil", "Login", MessageBoxButtons.OK)
                Me.Hide()
                peminjaman.Show()
                peminjaman.TxtUserid.Text = rd.Item("userid")
            End If
        ElseIf LblLog.Text = "Konfirmasi Admin" Then
            Call connect()
            cmd = New MySqlCommand("Select * from dadmin where userid = '" & TxtUsername.Text & "' and pass = '" & TxtPass.Text & "'", cn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows = True Then
                MessageBox.Show("Konfirmasi Berhasil", "Konfirmasi Admin", MessageBoxButtons.OK)
                Me.Hide()
                Call connect()
                cmd = New MySqlCommand("delete from dpinjam where nobuku='" & peminjaman.TxtNoBuku.Text & "'", cn)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Pengembalian dikonfirmasi !", "Konfirmasi Admin", MessageBoxButtons.OK, MessageBoxIcon.Information)
                peminjaman.TxtNoBuku.Clear()
                peminjaman.TxtJudul.Clear()
                peminjaman.TxtPenerbit.Clear()
                peminjaman.TxtPengarang.Clear()
                peminjaman.TxtThn.Clear()
                peminjaman.TxtNoBuku.Focus()
            End If
        End If
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnEye_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnEye.MouseDown
        TxtPass.UseSystemPasswordChar = False
        BtnEye.BackColor = Color.Silver
    End Sub

    Private Sub BtnEye_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnEye.MouseUp
        TxtPass.UseSystemPasswordChar = True
        BtnEye.BackColor = Color.Empty
    End Sub


End Class