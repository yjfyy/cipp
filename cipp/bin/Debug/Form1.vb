Public Class Form1
    Public firstrun As Boolean = False
    Public uninstall As Boolean = False
    Public NewIp As String, OldIp As String '战网ip（新ip）新，d2gsip（旧ip）

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'chkserver()
        chushi()
        OldIp = System.Net.Dns.GetHostEntry(bnetdn.Text).AddressList(0).ToString
        'cipprun()
    End Sub

    Private Sub cipprun()

        'Dim NewIp As String, OldIp As String '战网ip（新ip）新，d2gsip（旧ip）
        Dim bnetd As String, d2cs As String, d2dbs As String, realm As String    'bnetd.conf ,d2cs.conf d2dbs.conf realm.conf
        If emod.Checked Then
            NewIp = System.Net.Dns.GetHostEntry(bnetdn.Text).AddressList(0).ToString
            If NewIp = OldIp Then
            Else
                OldIp = NewIp
                restserver()
            End If
        Else
            NewIp = System.Net.Dns.GetHostEntry(bnetdn.Text).AddressList(0).ToString
            OldIp = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\D2Server\D2GS\", "d2csip", 0)
            If NewIp = OldIp Then

            Else
                '修改d2gs配置
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\D2Server\D2GS\", "d2csip", NewIp)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\D2Server\D2GS\", "d2dbsip", NewIp)

                '修改pvpgn配置
                'bnetd.conf
                bnetd = My.Computer.FileSystem.ReadAllText(pvpgndir.Text & "\conf\bnetd.conf", System.Text.Encoding.Default)
                bnetd = Replace(bnetd, OldIp, NewIp)
                My.Computer.FileSystem.WriteAllText(pvpgndir.Text & "\conf\bnetd.conf", bnetd, False, System.Text.Encoding.Default)

                'd2cs.conf()
                d2cs = My.Computer.FileSystem.ReadAllText(pvpgndir.Text & "\conf\d2cs.conf", System.Text.Encoding.Default)
                d2cs = Replace(d2cs, OldIp, NewIp)
                My.Computer.FileSystem.WriteAllText(pvpgndir.Text & "\conf\d2cs.conf", d2cs, False, System.Text.Encoding.Default)

                'd2dbs.conf()
                d2dbs = My.Computer.FileSystem.ReadAllText(pvpgndir.Text & "\conf\d2dbs.conf", System.Text.Encoding.Default)
                d2dbs = Replace(d2dbs, OldIp, NewIp)
                My.Computer.FileSystem.WriteAllText(pvpgndir.Text & "\conf\d2dbs.conf", d2dbs, False, System.Text.Encoding.Default)

                'realm.conf()
                realm = My.Computer.FileSystem.ReadAllText(pvpgndir.Text & "\conf\realm.conf", System.Text.Encoding.Default)
                realm = Replace(realm, OldIp, NewIp)
                My.Computer.FileSystem.WriteAllText(pvpgndir.Text & "\conf\realm.conf", realm, False, System.Text.Encoding.Default)
                restserver()
            End If
        End If
    End Sub

    '此子程序为调试测试
    'Private Sub chkserver()
    'Dim serveron As Boolean = False
    '
    '       If serveron = False Then
    '          MsgBox("某些服务不存在，请检查pvpgn及d2gs配置！")
    '         End
    '    End If
    'End Sub

    Private Sub chkserver()
        Dim ServerList As System.ServiceProcess.ServiceController() = System.ServiceProcess.ServiceController.GetServices()
        '判断服务是否存在
        Dim i As Integer
        Dim serveron As Boolean = True
        For i = 0 To ServerList.Length - 1
            If ServerList(i).ServiceName = "pvpgn" Then
                Exit For
            ElseIf i = ServerList.Length - 1 Then
                MsgBox("pvpgn不存在")
                serveron = False
            End If
        Next

        For i = 0 To ServerList.Length - 1
            If ServerList(i).ServiceName = "d2cs" Then
                Exit For
            ElseIf i = ServerList.Length - 1 Then
                MsgBox("d2cs不存在")
                serveron = False
            End If
        Next

        For i = 0 To ServerList.Length - 1
            If ServerList(i).ServiceName = "d2dbs" Then
                Exit For
            ElseIf i = ServerList.Length - 1 Then
                MsgBox("d2dbs不存在")
                serveron = False
            End If
        Next

        For i = 0 To ServerList.Length - 1
            If ServerList(i).ServiceName = "D2GS" Then
                Exit For
            ElseIf i = ServerList.Length - 1 Then
                MsgBox("D2GS不存在")
                serveron = False
            End If
        Next

        If serveron = False Then
            MsgBox("某些服务不存在，请检查pvpgn及d2gs配置！")
            End
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        cipprun()
    End Sub

    Private Sub restserver()
        Shell("restpvpgn.bat", AppWinStyle.Hide, True)
    End Sub

    Private Sub chushi()
        If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\cipp\", "pvpgndir", Nothing) Is Nothing Or My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\cipp\", "bnetdn", Nothing) Is Nothing Or My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\cipp\", "emod", Nothing) Is Nothing Then
            firstrun = True
        End If

        If firstrun Then
            Button1.Text = "保存退出"
            Label3.Text = "首次运行请设置pvpgn目录、动态域名、模式后点保存退出"
            pvpgndir.Text = "d:\pvpgn"
            bnetdn.Text = "tybh.vicp.net"
            emod.Checked = True
        Else
            Button1.Text = "卸载"
            Label3.Text = "正在运行，需要卸载请点卸载按钮"
            pvpgndir.Text = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\cipp\", "pvpgndir", "d:\pvpgndir")
            bnetdn.Text = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\cipp\", "bnetdn", "tybh.vicp.net")
            emod.Checked = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\cipp\", "emod", "True") = "True"

            Timer1.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If firstrun = True Then
        Else
            Timer1.Enabled = False
            uninstall = True
            My.Computer.Registry.LocalMachine.DeleteSubKey("SOFTWARE\cipp")
            'My.Computer.Registry.CurrentUser.DeleteSubKey("HKEY_LOCAL_MACHINE\SOFTWARE\cipp\pvpgndir")
        End If
        Application.Exit()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If firstrun Then
            '如果是第一次运行，并且不选择保存的话直接退出。
            End
        Else
            Application.Exit()
        End If
    End Sub

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If uninstall = True Then
        Else
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\cipp\", "pvpgndir", pvpgndir.Text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\cipp\", "bnetdn", bnetdn.Text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\cipp\", "emod", emod.Checked)
        End If
    End Sub


    Private Sub about_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles about.Click
        ' Display frmAbout as a modal dialog
        AboutBox1.ShowDialog()
    End Sub

    Private Sub help_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help.Click


    End Sub

End Class
