<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Diagnose
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSolenoid = New System.Windows.Forms.TextBox()
        Me.chkCycle = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnFireSolenoid = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnHook = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnLoadConfig = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.cmbSelectSolenoid = New System.Windows.Forms.ComboBox()
        Me.btnUnhook = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Extend Solenoid:"
        '
        'txtSolenoid
        '
        Me.txtSolenoid.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSolenoid.Location = New System.Drawing.Point(141, 10)
        Me.txtSolenoid.Name = "txtSolenoid"
        Me.txtSolenoid.Size = New System.Drawing.Size(48, 26)
        Me.txtSolenoid.TabIndex = 1
        '
        'chkCycle
        '
        Me.chkCycle.AutoSize = True
        Me.chkCycle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCycle.Location = New System.Drawing.Point(70, 39)
        Me.chkCycle.Name = "chkCycle"
        Me.chkCycle.Size = New System.Drawing.Size(61, 20)
        Me.chkCycle.TabIndex = 2
        Me.chkCycle.Text = "Cycle"
        Me.chkCycle.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnFireSolenoid)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.chkCycle)
        Me.GroupBox1.Controls.Add(Me.txtSolenoid)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(195, 75)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'btnFireSolenoid
        '
        Me.btnFireSolenoid.Location = New System.Drawing.Point(141, 42)
        Me.btnFireSolenoid.Name = "btnFireSolenoid"
        Me.btnFireSolenoid.Size = New System.Drawing.Size(48, 23)
        Me.btnFireSolenoid.TabIndex = 4
        Me.btnFireSolenoid.Text = "OK"
        Me.btnFireSolenoid.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(162, 100)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(75, 23)
        Me.btnReset.TabIndex = 4
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnHook
        '
        Me.btnHook.Location = New System.Drawing.Point(22, 230)
        Me.btnHook.Name = "btnHook"
        Me.btnHook.Size = New System.Drawing.Size(75, 42)
        Me.btnHook.TabIndex = 5
        Me.btnHook.Text = "Hook Keyboard"
        Me.btnHook.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(22, 129)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(319, 95)
        Me.ListBox1.TabIndex = 6
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(266, 230)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnLoadConfig
        '
        Me.btnLoadConfig.Location = New System.Drawing.Point(12, 288)
        Me.btnLoadConfig.Name = "btnLoadConfig"
        Me.btnLoadConfig.Size = New System.Drawing.Size(75, 23)
        Me.btnLoadConfig.TabIndex = 8
        Me.btnLoadConfig.Text = "Load COnfig"
        Me.btnLoadConfig.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(163, 288)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 9
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'cmbSelectSolenoid
        '
        Me.cmbSelectSolenoid.FormattingEnabled = True
        Me.cmbSelectSolenoid.Items.AddRange(New Object() {"48", "AE", "AD", "46", "4C"})
        Me.cmbSelectSolenoid.Location = New System.Drawing.Point(238, 27)
        Me.cmbSelectSolenoid.Name = "cmbSelectSolenoid"
        Me.cmbSelectSolenoid.Size = New System.Drawing.Size(66, 21)
        Me.cmbSelectSolenoid.TabIndex = 10
        '
        'btnUnhook
        '
        Me.btnUnhook.Location = New System.Drawing.Point(118, 230)
        Me.btnUnhook.Name = "btnUnhook"
        Me.btnUnhook.Size = New System.Drawing.Size(75, 42)
        Me.btnUnhook.TabIndex = 11
        Me.btnUnhook.Text = "UnHook Keyboard"
        Me.btnUnhook.UseVisualStyleBackColor = True
        '
        'Diagnose
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(353, 323)
        Me.Controls.Add(Me.btnUnhook)
        Me.Controls.Add(Me.cmbSelectSolenoid)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.btnLoadConfig)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.btnHook)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Diagnose"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Diagnose"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSolenoid As System.Windows.Forms.TextBox
    Friend WithEvents chkCycle As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnFireSolenoid As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnHook As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnLoadConfig As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents cmbSelectSolenoid As ComboBox
    Friend WithEvents btnUnhook As Button
End Class
