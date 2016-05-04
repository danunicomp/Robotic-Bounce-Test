<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.btnStart = New System.Windows.Forms.Button()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.btnDiagnose = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.cboTestFile = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grpTest = New System.Windows.Forms.GroupBox()
        Me.prgTest = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstFailedKeys = New System.Windows.Forms.ListBox()
        Me.btnConfig = New System.Windows.Forms.Button()
        Me.btnTestLights = New System.Windows.Forms.Button()
        Me.grpTest.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.Location = New System.Drawing.Point(175, 306)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 43)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'lblResult
        '
        Me.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblResult.Font = New System.Drawing.Font("Arial Black", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResult.ForeColor = System.Drawing.Color.Green
        Me.lblResult.Location = New System.Drawing.Point(16, 27)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(341, 138)
        Me.lblResult.TabIndex = 1
        Me.lblResult.Text = "PASS"
        Me.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnDiagnose
        '
        Me.btnDiagnose.Font = New System.Drawing.Font("Arial Black", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDiagnose.Location = New System.Drawing.Point(448, 356)
        Me.btnDiagnose.Name = "btnDiagnose"
        Me.btnDiagnose.Size = New System.Drawing.Size(77, 25)
        Me.btnDiagnose.TabIndex = 2
        Me.btnDiagnose.Text = "Diagnose"
        Me.btnDiagnose.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Location = New System.Drawing.Point(61, 306)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(75, 43)
        Me.btnReset.TabIndex = 6
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'cboTestFile
        '
        Me.cboTestFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTestFile.FormattingEnabled = True
        Me.cboTestFile.Location = New System.Drawing.Point(404, 35)
        Me.cboTestFile.Name = "cboTestFile"
        Me.cboTestFile.Size = New System.Drawing.Size(121, 28)
        Me.cboTestFile.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(393, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 20)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Select Test File:"
        '
        'grpTest
        '
        Me.grpTest.Controls.Add(Me.prgTest)
        Me.grpTest.Controls.Add(Me.Label1)
        Me.grpTest.Controls.Add(Me.lstFailedKeys)
        Me.grpTest.Controls.Add(Me.lblResult)
        Me.grpTest.Controls.Add(Me.btnReset)
        Me.grpTest.Controls.Add(Me.btnStart)
        Me.grpTest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTest.Location = New System.Drawing.Point(12, 12)
        Me.grpTest.Name = "grpTest"
        Me.grpTest.Size = New System.Drawing.Size(375, 369)
        Me.grpTest.TabIndex = 10
        Me.grpTest.TabStop = False
        Me.grpTest.Text = "Test"
        '
        'prgTest
        '
        Me.prgTest.Location = New System.Drawing.Point(16, 180)
        Me.prgTest.Name = "prgTest"
        Me.prgTest.Size = New System.Drawing.Size(342, 10)
        Me.prgTest.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 193)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 20)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Failed Keys:"
        '
        'lstFailedKeys
        '
        Me.lstFailedKeys.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstFailedKeys.FormattingEnabled = True
        Me.lstFailedKeys.ItemHeight = 16
        Me.lstFailedKeys.Location = New System.Drawing.Point(16, 216)
        Me.lstFailedKeys.Name = "lstFailedKeys"
        Me.lstFailedKeys.Size = New System.Drawing.Size(341, 84)
        Me.lstFailedKeys.TabIndex = 7
        '
        'btnConfig
        '
        Me.btnConfig.Font = New System.Drawing.Font("Arial Black", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfig.Location = New System.Drawing.Point(448, 318)
        Me.btnConfig.Name = "btnConfig"
        Me.btnConfig.Size = New System.Drawing.Size(77, 25)
        Me.btnConfig.TabIndex = 11
        Me.btnConfig.Text = "Configure"
        Me.btnConfig.UseVisualStyleBackColor = True
        '
        'btnTestLights
        '
        Me.btnTestLights.Location = New System.Drawing.Point(448, 269)
        Me.btnTestLights.Name = "btnTestLights"
        Me.btnTestLights.Size = New System.Drawing.Size(75, 23)
        Me.btnTestLights.TabIndex = 12
        Me.btnTestLights.Text = "LED Test"
        Me.btnTestLights.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTestLights.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(539, 393)
        Me.Controls.Add(Me.btnTestLights)
        Me.Controls.Add(Me.btnConfig)
        Me.Controls.Add(Me.grpTest)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboTestFile)
        Me.Controls.Add(Me.btnDiagnose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Unicomp FKT v3.x"
        Me.grpTest.ResumeLayout(False)
        Me.grpTest.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents btnDiagnose As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents cboTestFile As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grpTest As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lstFailedKeys As System.Windows.Forms.ListBox
    Friend WithEvents prgTest As System.Windows.Forms.ProgressBar
    Friend WithEvents btnConfig As System.Windows.Forms.Button
    Friend WithEvents btnTestLights As Button
End Class
