<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TopForm
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvPatientList = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dateList = New System.Windows.Forms.ListBox()
        Me.chkKakutan = New System.Windows.Forms.CheckBox()
        Me.chkTyusin = New System.Windows.Forms.CheckBox()
        Me.dgvText = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.adlLabel = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.byo1TextBox = New System.Windows.Forms.TextBox()
        Me.byo2TextBox = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.fileNameBox = New System.Windows.Forms.TextBox()
        Me.saveDirPathBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.adlBox = New System.Windows.Forms.TextBox()
        CType(Me.dgvPatientList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvText, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "療養入院患者"
        '
        'dgvPatientList
        '
        Me.dgvPatientList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPatientList.Location = New System.Drawing.Point(15, 31)
        Me.dgvPatientList.Name = "dgvPatientList"
        Me.dgvPatientList.RowTemplate.Height = 21
        Me.dgvPatientList.Size = New System.Drawing.Size(105, 542)
        Me.dgvPatientList.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "診療録作成日"
        '
        'dateList
        '
        Me.dateList.FormattingEnabled = True
        Me.dateList.ItemHeight = 12
        Me.dateList.Location = New System.Drawing.Point(15, 41)
        Me.dateList.Name = "dateList"
        Me.dateList.Size = New System.Drawing.Size(75, 112)
        Me.dateList.TabIndex = 4
        '
        'chkKakutan
        '
        Me.chkKakutan.AutoCheck = False
        Me.chkKakutan.AutoSize = True
        Me.chkKakutan.Location = New System.Drawing.Point(111, 163)
        Me.chkKakutan.Name = "chkKakutan"
        Me.chkKakutan.Size = New System.Drawing.Size(84, 16)
        Me.chkKakutan.TabIndex = 5
        Me.chkKakutan.Text = "喀痰吸引有"
        Me.chkKakutan.UseVisualStyleBackColor = True
        '
        'chkTyusin
        '
        Me.chkTyusin.AutoCheck = False
        Me.chkTyusin.AutoSize = True
        Me.chkTyusin.Location = New System.Drawing.Point(210, 163)
        Me.chkTyusin.Name = "chkTyusin"
        Me.chkTyusin.Size = New System.Drawing.Size(108, 16)
        Me.chkTyusin.TabIndex = 6
        Me.chkTyusin.Text = "中心静脈栄養有"
        Me.chkTyusin.UseVisualStyleBackColor = True
        '
        'dgvText
        '
        Me.dgvText.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvText.Location = New System.Drawing.Point(111, 41)
        Me.dgvText.Name = "dgvText"
        Me.dgvText.RowTemplate.Height = 21
        Me.dgvText.Size = New System.Drawing.Size(388, 111)
        Me.dgvText.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(112, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "病名テキスト"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(352, 164)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 12)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "ADL得点："
        '
        'adlLabel
        '
        Me.adlLabel.AutoSize = True
        Me.adlLabel.ForeColor = System.Drawing.Color.Blue
        Me.adlLabel.Location = New System.Drawing.Point(410, 164)
        Me.adlLabel.Name = "adlLabel"
        Me.adlLabel.Size = New System.Drawing.Size(0, 12)
        Me.adlLabel.TabIndex = 10
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.adlLabel)
        Me.GroupBox1.Controls.Add(Me.dateList)
        Me.GroupBox1.Controls.Add(Me.chkKakutan)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.chkTyusin)
        Me.GroupBox1.Controls.Add(Me.dgvText)
        Me.GroupBox1.Location = New System.Drawing.Point(126, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(510, 191)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "診療録、評価表データ（読み取り専用）"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(182, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 12)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Ctrl + C でコピー可"
        '
        'byo1TextBox
        '
        Me.byo1TextBox.Location = New System.Drawing.Point(96, 93)
        Me.byo1TextBox.Name = "byo1TextBox"
        Me.byo1TextBox.Size = New System.Drawing.Size(398, 19)
        Me.byo1TextBox.TabIndex = 12
        '
        'byo2TextBox
        '
        Me.byo2TextBox.Location = New System.Drawing.Point(96, 111)
        Me.byo2TextBox.Name = "byo2TextBox"
        Me.byo2TextBox.Size = New System.Drawing.Size(398, 19)
        Me.byo2TextBox.TabIndex = 13
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.adlBox)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.saveDirPathBox)
        Me.GroupBox2.Controls.Add(Me.fileNameBox)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.byo2TextBox)
        Me.GroupBox2.Controls.Add(Me.byo1TextBox)
        Me.GroupBox2.Location = New System.Drawing.Point(126, 221)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(510, 284)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "入院診療計画書エクセル作成用"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 12)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "ファイル名"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 12)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "保存先フォルダ"
        '
        'fileNameBox
        '
        Me.fileNameBox.Location = New System.Drawing.Point(96, 32)
        Me.fileNameBox.Name = "fileNameBox"
        Me.fileNameBox.ReadOnly = True
        Me.fileNameBox.Size = New System.Drawing.Size(116, 19)
        Me.fileNameBox.TabIndex = 15
        '
        'saveDirPathBox
        '
        Me.saveDirPathBox.Location = New System.Drawing.Point(96, 62)
        Me.saveDirPathBox.Name = "saveDirPathBox"
        Me.saveDirPathBox.ReadOnly = True
        Me.saveDirPathBox.Size = New System.Drawing.Size(296, 19)
        Me.saveDirPathBox.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(34, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 12)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "病名"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(17, 114)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 12)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "(枠に収めて)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(5, 144)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 12)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "全身状態の評価"
        '
        'adlBox
        '
        Me.adlBox.Location = New System.Drawing.Point(96, 141)
        Me.adlBox.Name = "adlBox"
        Me.adlBox.Size = New System.Drawing.Size(264, 19)
        Me.adlBox.TabIndex = 20
        '
        'TopForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 592)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvPatientList)
        Me.Controls.Add(Me.Label1)
        Me.Name = "TopForm"
        Me.Text = "入院診療計画作成"
        CType(Me.dgvPatientList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvText, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvPatientList As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dateList As System.Windows.Forms.ListBox
    Friend WithEvents chkKakutan As System.Windows.Forms.CheckBox
    Friend WithEvents chkTyusin As System.Windows.Forms.CheckBox
    Friend WithEvents dgvText As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents adlLabel As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents byo1TextBox As System.Windows.Forms.TextBox
    Friend WithEvents byo2TextBox As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents saveDirPathBox As System.Windows.Forms.TextBox
    Friend WithEvents fileNameBox As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents adlBox As System.Windows.Forms.TextBox

End Class
