<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.bnetdn = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pvpgndir = New System.Windows.Forms.TextBox()
        Me.ServiceController1 = New System.ServiceProcess.ServiceController()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.emod = New System.Windows.Forms.CheckBox()
        Me.help = New System.Windows.Forms.Button()
        Me.about = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(33, 170)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(91, 26)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "保存退出或卸载"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'bnetdn
        '
        Me.bnetdn.Location = New System.Drawing.Point(138, 58)
        Me.bnetdn.Name = "bnetdn"
        Me.bnetdn.Size = New System.Drawing.Size(121, 21)
        Me.bnetdn.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "战网动态域名址:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "pvpgn安装目录:"
        '
        'pvpgndir
        '
        Me.pvpgndir.Location = New System.Drawing.Point(138, 96)
        Me.pvpgndir.Name = "pvpgndir"
        Me.pvpgndir.Size = New System.Drawing.Size(121, 21)
        Me.pvpgndir.TabIndex = 4
        '
        'Timer1
        '
        Me.Timer1.Interval = 120000
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Location = New System.Drawing.Point(31, 199)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(228, 43)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "提示"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(166, 170)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(91, 26)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "退出"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'emod
        '
        Me.emod.AutoSize = True
        Me.emod.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.emod.Location = New System.Drawing.Point(31, 133)
        Me.emod.Name = "emod"
        Me.emod.Size = New System.Drawing.Size(204, 16)
        Me.emod.TabIndex = 8
        Me.emod.Text = "简单模式（不修改pvpgn配置文件)"
        Me.emod.UseVisualStyleBackColor = True
        '
        'help
        '
        Me.help.Location = New System.Drawing.Point(33, 245)
        Me.help.Name = "help"
        Me.help.Size = New System.Drawing.Size(91, 26)
        Me.help.TabIndex = 9
        Me.help.Text = "帮助"
        Me.help.UseVisualStyleBackColor = True
        '
        'about
        '
        Me.about.Location = New System.Drawing.Point(166, 245)
        Me.about.Name = "about"
        Me.about.Size = New System.Drawing.Size(91, 26)
        Me.about.TabIndex = 10
        Me.about.Text = "关于"
        Me.about.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 287)
        Me.Controls.Add(Me.about)
        Me.Controls.Add(Me.help)
        Me.Controls.Add(Me.emod)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.pvpgndir)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bnetdn)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "cipp 动态ip pvpgn自动配置"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents bnetdn As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pvpgndir As System.Windows.Forms.TextBox
    Friend WithEvents ServiceController1 As System.ServiceProcess.ServiceController
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents emod As System.Windows.Forms.CheckBox
    Friend WithEvents help As System.Windows.Forms.Button
    Friend WithEvents about As System.Windows.Forms.Button

End Class
