Imports MySql.Data.MySqlClient
Public Class main_menu

    Sub tampil_data()
        cmd = New MySqlCommand("Select * from dbook", cn)
        rd = cmd.ExecuteReader
        DataGridView1.Rows.Clear()
        Do While rd.Read = True
            DataGridView1.Rows.Add(rd(0), rd(1), rd(2), rd(3), rd(4))
        Loop
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call connect()
        PnlLbry.Visible = True
        Lbl1.Visible = True
        Call tampil_data()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnMax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMax.Click
        If Me.WindowState = FormWindowState.Normal = True Then
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub BtnMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BtnUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUser.Click
        Lbl1.Visible = False
        Lbl2.Visible = True
        Lbl3.Visible = False
        PnlUser.Visible = True
        PnlLbry.Visible = False
        PnlMng.Visible = False
    End Sub

    Private Sub BtnLbry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLbry.Click
        Call connect()
        Call tampil_data()
        Lbl1.Visible = True
        Lbl2.Visible = False
        Lbl3.Visible = False
        PnlLbry.Visible = True
        PnlUser.Visible = False
        PnlMng.Visible = False
    End Sub

    Private Sub BtnManage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnManage.Click
        If LblX.Text = "The Reader" Then
            login.Show()
            login.LblLog.Text = "Administrator Access"
        Else
            PnlLbry.Visible = False
            PnlUser.Visible = False
            PnlMng.Visible = True
            Lbl1.Visible = False
            Lbl2.Visible = False
            Lbl3.Visible = True
        End If
    End Sub

    Private Sub BtnLogoutAdmin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLogoutAdmin.Click
        If MessageBox.Show("Apa Anda Yakin Ingin Keluar?", "Logout Admin", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            LblX.Text = "The Reader"
            PnlMng.Visible = False
            PnlLbry.Visible = True
            PnlUser.Visible = True
            Lbl1.Visible = True
            Lbl3.Visible = False
        End If
    End Sub

    Private Sub BtnProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProfile.Click
        If LblX.Text = "Administrator" Then
            MessageBox.Show("Anda Adalah Administrator", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            login.Show()
            login.LblLog.Text = "MyProfile"
        End If
    End Sub

    Private Sub BtnLoan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLoan.Click
        If LblX.Text = "Administrator" Then
            MessageBox.Show("Anda Adalah Administrator", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            login.Show()
            login.LblLog.Text = "MyBook"
        End If
    End Sub

    Private Sub BtnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCari.Click
        Call connect()
        cmd = New MySqlCommand("Select * from dbook where judul like '%" & TxtCari.Text & "%'", cn)
        rd = cmd.ExecuteReader
        DataGridView1.Rows.Clear()
        Do While rd.Read = True
            DataGridView1.Rows.Add(rd(0), rd(1), rd(2), rd(3), rd(4))
        Loop
    End Sub

    Private Sub BtnMngUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMngUser.Click
        mnguser.Show()
    End Sub

    Private Sub BtnMngBook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMngBook.Click
        mngbook.Show()
    End Sub

    Private Sub BtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click
        Call connect()
        Call tampil_data()
        TxtCari.Clear()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        login.Show()
        login.LblLog.Text = "Peminjaman"
    End Sub
End Class
