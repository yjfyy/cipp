Public Class Form1
    Public firstrun As Boolean = False
    Public uninstall As Boolean = False
    Public NewIp As String, OldIp As String 'ս��ip����ip���£�d2gsip����ip��

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'chkserver()
        chushi()
        OldIp = System.Net.Dns.GetHostEntry(bnetdn.Text).AddressList(0).ToString
        'cipprun()
    End Sub

    Private Sub cipprun()

        'Dim NewIp As String, OldIp As String 'ս��ip����ip���£�d2gsip����ip��
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
                '�޸�d2gs����
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\D2Server\D2GS\", "d2csip", NewIp)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\D2Server\D2GS\", "d2dbsip", NewIp)

                '�޸�pvpgn����
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

    '���ӳ���Ϊ���Բ���
    'Private Sub chkserver()
    'Dim serveron As Boolean = False
    '
    '       If serveron = False Then
    '          MsgBox("ĳЩ���񲻴��ڣ�����pvpgn��d2gs���ã�")
    '         End
    '    End If
    'End Sub

    Private Sub chkserver()
        Dim ServerList As System.ServiceProcess.ServiceController() = System.ServiceProcess.ServiceController.GetServices()
        '�жϷ����Ƿ����
        Dim i As Integer
        Dim serveron As Boolean = True
        For i = 0 To ServerList.Length - 1
            If ServerList(i).ServiceName = "pvpgn" Then
                Exit For
            ElseIf i = ServerList.Length - 1 Then
                MsgBox("pvpgn������")
                serveron = False
            End If
        Next

        For i = 0 To ServerList.Length - 1
            If ServerList(i).ServiceName = "d2cs" Then
                Exit For
            ElseIf i = ServerList.Length - 1 Then
                MsgBox("d2cs������")
                serveron = False
            End If
        Next

        For i = 0 To ServerList.Length - 1
            If ServerList(i).ServiceName = "d2dbs" Then
                Exit For
            ElseIf i = ServerList.Length - 1 Then
                MsgBox("d2dbs������")
                serveron = False
            End If
        Next

        For i = 0 To ServerList.Length - 1
            If ServerList(i).ServiceName = "D2GS" Then
                Exit For
            ElseIf i = ServerList.Length - 1 Then
                MsgBox("D2GS������")
                serveron = False
            End If
        Next

        If serveron = False Then
            MsgBox("ĳЩ���񲻴��ڣ�����pvpgn��d2gs���ã�")
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
            Button1.Text = "�����˳�"
            Label3.Text = "�״�����������pvpgnĿ¼����̬������ģʽ��㱣���˳�"
            pvpgndir.Text = "d:\pvpgn"
            bnetdn.Text = "tybh.vicp.net"
            emod.Checked = True
        Else
            Button1.Text = "ж��"
            Label3.Text = "�������У���Ҫж�����ж�ذ�ť"
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
            '����ǵ�һ�����У����Ҳ�ѡ�񱣴�Ļ�ֱ���˳���
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
