Public Class Form1
    Public firstrun As Boolean = False
    Public uninstall As Boolean = False
    Public NewIp As String, OldIp As String '战网ip（新ip）新，d2gsip（旧ip）

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '检查服务是否存在
        'chkserver()
        '初始化程序
        chushi()

        '获得动态域名ip地址赋值到oldip
        'OldIp = System.Net.Dns.GetHostEntry(textbox_bnet_domain_name.Text).AddressList(0).ToString
        '测试调用
        'cipprun() '调试用
        'modify_conf()

    End Sub

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        '保存设置
        If uninstall = True Then
        Else
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\cipp\", "pvpgn_directory", textbox_pvpgn_directory.Text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\cipp\", "bnet_domain_name", textbox_bnet_domain_name.Text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\cipp\", "modify_conf", checkbox_modify_conf.Checked)
        End If
    End Sub

    Private Sub cipprun()
        OldIp = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\D2Server\D2GS\", "d2csip", 0)
        'My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\D2Server\D2GS\", "d2csip", "22222")
        'MsgBox(OldIp)
        NewIp = System.Net.Dns.GetHostEntry(textbox_bnet_domain_name.Text).AddressList(0).ToString
        'MsgBox(NewIp)
        If NewIp <> OldIp Then
            If checkbox_modify_conf.Checked = True Then
                '修改conf
                modify_conf（)
            End If
            '重启服务
            restserver()
        End If

    End Sub

    '此子程序为调试测试
    'Private Sub chkserver()
    'Dim serveron As Boolean = False
    '
    '       If serveron = False Then
    '          MsgBox("某些服务不存在， 请检查pvpgn及d2gs配置！")
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
            MsgBox("某些服务不存在， 请检查pvpgn及d2gs配置！")
            End
        End If
    End Sub



    Private Sub restserver()
        Shell("restpvpgn.bat", AppWinStyle.Hide, True)
    End Sub

    Private Sub chushi()
        If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\cipp\", "pvpgn_directory", Nothing) Is Nothing Or My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\cipp\", "bnet_domain_name", Nothing) Is Nothing Or My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\cipp\", "modify_conf", Nothing) Is Nothing Then
            firstrun = True
        End If

        If firstrun Then
            Button_save_or_uninstall.Text = "保存退出"
            Label3.Text = "首次运行请设置pvpgn目录、动态域名、模式后点保存退出"
            textbox_pvpgn_directory.Text = "d: \pvpgn"
            textbox_bnet_domain_name.Text = "tybh.vicp.net"
            checkbox_modify_conf.Checked = True
        Else
            Button_save_or_uninstall.Text = "卸载"
            Label3.Text = "正在运行，需要卸载请点卸载按钮"
            textbox_pvpgn_directory.Text = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\cipp\", "pvpgn_directory", "d:\pvpgndir")
            textbox_bnet_domain_name.Text = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\cipp\", "bnet_domain_name", "tybh.vicp.net")
            checkbox_modify_conf.Checked  = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\cipp\", "modify_conf", "True") = "True"
            Timer1.Enabled = True
        End If
    End Sub



    Private Sub Button_help_Click(sender As Object, e As EventArgs) Handles Button_help.Click
        MsgBox("帮助")
    End Sub

    Private Sub Button_save_or_uninstall_Click(sender As Object, e As EventArgs) Handles Button_save_or_uninstall.Click
        If firstrun = True Then
        Else
            Timer1.Enabled = False
            uninstall = True
            My.Computer.Registry.LocalMachine.DeleteSubKey("SOFTWARE\cipp")
            'My.Computer.Registry.CurrentUser.DeleteSubKey("HKEY_LOCAL_MACHINE\SOFTWARE\cipp\pvpgndir")
        End If
        Application.Exit()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        cipprun()
    End Sub



    Private Sub modify_conf()
        'Dim bnetd As String, 
        Dim d2cs As String, d2dbs As String, realm As String    'bnetd.conf ,d2cs.conf d2dbs.conf realm.conf
        '修改d2gs配置
        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\D2Server\D2GS\", "d2csip", NewIp)
        'MsgBox(NewIp)
        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\D2Server\D2GS\", "d2dbsip", NewIp)

        '修改pvpgn配置,bnetd.conf 可以不修改
        'bnetd.conf
        'bnetd = My.Computer.FileSystem.ReadAllText(pvpgndir.Text & "\conf\bnetd.conf", System.Text.Encoding.Default)
        'bnetd = Replace(bnetd, OldIp, NewIp)
        'My.Computer.FileSystem.WriteAllText(pvpgndir.Text & "\conf\bnetd.conf", bnetd, False, System.Text.Encoding.Default)

        'd2cs.conf()
        d2cs = My.Computer.FileSystem.ReadAllText(textbox_pvpgn_directory.Text & "\conf\d2cs.conf", System.Text.Encoding.Default)
        d2cs = Replace(d2cs, OldIp, NewIp)
        My.Computer.FileSystem.WriteAllText(textbox_pvpgn_directory.Text & "\conf\d2cs.conf", d2cs, False, System.Text.Encoding.Default)

        'd2dbs.conf()
        d2dbs = My.Computer.FileSystem.ReadAllText(textbox_pvpgn_directory.Text & "\conf\d2dbs.conf", System.Text.Encoding.Default)
        d2dbs = Replace(d2dbs, OldIp, NewIp)
        My.Computer.FileSystem.WriteAllText(textbox_pvpgn_directory.Text & "\conf\d2dbs.conf", d2dbs, False, System.Text.Encoding.Default)

        'realm.conf()
        realm = My.Computer.FileSystem.ReadAllText(textbox_pvpgn_directory.Text & "\conf\realm.conf", System.Text.Encoding.Default)
        realm = Replace(realm, OldIp, NewIp)
        My.Computer.FileSystem.WriteAllText(textbox_pvpgn_directory.Text & "\conf\realm.conf", realm, False, System.Text.Encoding.Default)
    End Sub

End Class
