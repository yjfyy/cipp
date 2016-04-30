<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.textbox_bnet_domain_name = New System.Windows.Forms.TextBox()
        Me.textbox_pvpgn_directory = New System.Windows.Forms.TextBox()
        Me.checkbox_modify_conf = New System.Windows.Forms.CheckBox()
        Me.Button_save_or_uninstall = New System.Windows.Forms.Button()
        Me.Button_help = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "战网动态域名："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "PVPGN安装目录："
        '
        'textbox_bnet_domain_name
        '
        Me.textbox_bnet_domain_name.Location = New System.Drawing.Point(107, 12)
        Me.textbox_bnet_domain_name.Name = "textbox_bnet_domain_name"
        Me.textbox_bnet_domain_name.Size = New System.Drawing.Size(100, 21)
        Me.textbox_bnet_domain_name.TabIndex = 2
        '
        'textbox_pvpgn_directory
        '
        Me.textbox_pvpgn_directory.Location = New System.Drawing.Point(107, 39)
        Me.textbox_pvpgn_directory.Name = "textbox_pvpgn_directory"
        Me.textbox_pvpgn_directory.Size = New System.Drawing.Size(100, 21)
        Me.textbox_pvpgn_directory.TabIndex = 3
        '
        'checkbox_modify_conf
        '
        Me.checkbox_modify_conf.AutoSize = True
        Me.checkbox_modify_conf.Location = New System.Drawing.Point(14, 66)
        Me.checkbox_modify_conf.Name = "checkbox_modify_conf"
        Me.checkbox_modify_conf.Size = New System.Drawing.Size(192, 16)
        Me.checkbox_modify_conf.TabIndex = 4
        Me.checkbox_modify_conf.Text = "修改CONF文件（直接拨号方式）"
        Me.checkbox_modify_conf.UseVisualStyleBackColor = True
        '
        'Button_save_or_uninstall
        '
        Me.Button_save_or_uninstall.Location = New System.Drawing.Point(61, 88)
        Me.Button_save_or_uninstall.Name = "Button_save_or_uninstall"
        Me.Button_save_or_uninstall.Size = New System.Drawing.Size(125, 23)
        Me.Button_save_or_uninstall.TabIndex = 5
        Me.Button_save_or_uninstall.Text = "保存设置或卸载程序"
        Me.Button_save_or_uninstall.UseVisualStyleBackColor = True
        '
        'Button_help
        '
        Me.Button_help.Location = New System.Drawing.Point(86, 117)
        Me.Button_help.Name = "Button_help"
        Me.Button_help.Size = New System.Drawing.Size(75, 23)
        Me.Button_help.TabIndex = 1
        Me.Button_help.Text = "帮助"
        Me.Button_help.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoEllipsis = True
        Me.Label3.Location = New System.Drawing.Point(12, 145)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(223, 50)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Label3"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 180000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(247, 204)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button_help)
        Me.Controls.Add(Me.Button_save_or_uninstall)
        Me.Controls.Add(Me.checkbox_modify_conf)
        Me.Controls.Add(Me.textbox_pvpgn_directory)
        Me.Controls.Add(Me.textbox_bnet_domain_name)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents textbox_bnet_domain_name As TextBox
    Friend WithEvents textbox_pvpgn_directory As TextBox
    Friend WithEvents checkbox_modify_conf As CheckBox
    Friend WithEvents Button_save_or_uninstall As Button
    Friend WithEvents Button_help As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Timer1 As Timer
End Class
