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
        Me.temp2Box = New System.Windows.Forms.TextBox()
        Me.temp1Box = New System.Windows.Forms.TextBox()
        Me.tempNumBox = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnReference = New System.Windows.Forms.Button()
        Me.formatTextBox = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.hyoukaBox = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.adlBox = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.saveDirPathBox = New System.Windows.Forms.TextBox()
        Me.fileNameBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.namBox = New System.Windows.Forms.TextBox()
        Me.btnCreateExcelFile = New System.Windows.Forms.Button()
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
        Me.byo1TextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.byo1TextBox.Location = New System.Drawing.Point(96, 118)
        Me.byo1TextBox.Name = "byo1TextBox"
        Me.byo1TextBox.Size = New System.Drawing.Size(398, 19)
        Me.byo1TextBox.TabIndex = 12
        '
        'byo2TextBox
        '
        Me.byo2TextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.byo2TextBox.Location = New System.Drawing.Point(96, 136)
        Me.byo2TextBox.Name = "byo2TextBox"
        Me.byo2TextBox.Size = New System.Drawing.Size(398, 19)
        Me.byo2TextBox.TabIndex = 13
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnCreateExcelFile)
        Me.GroupBox2.Controls.Add(Me.namBox)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.temp2Box)
        Me.GroupBox2.Controls.Add(Me.temp1Box)
        Me.GroupBox2.Controls.Add(Me.tempNumBox)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.btnReference)
        Me.GroupBox2.Controls.Add(Me.formatTextBox)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.hyoukaBox)
        Me.GroupBox2.Controls.Add(Me.Label11)
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
        Me.GroupBox2.Size = New System.Drawing.Size(510, 352)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "計画書エクセル作成用"
        '
        'temp2Box
        '
        Me.temp2Box.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.temp2Box.Location = New System.Drawing.Point(96, 242)
        Me.temp2Box.Name = "temp2Box"
        Me.temp2Box.Size = New System.Drawing.Size(352, 19)
        Me.temp2Box.TabIndex = 31
        '
        'temp1Box
        '
        Me.temp1Box.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.temp1Box.Location = New System.Drawing.Point(96, 224)
        Me.temp1Box.Name = "temp1Box"
        Me.temp1Box.Size = New System.Drawing.Size(352, 19)
        Me.temp1Box.TabIndex = 30
        '
        'tempNumBox
        '
        Me.tempNumBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tempNumBox.FormattingEnabled = True
        Me.tempNumBox.Items.AddRange(New Object() {"", "1", "2", "3", "4", "5"})
        Me.tempNumBox.Location = New System.Drawing.Point(252, 196)
        Me.tempNumBox.Name = "tempNumBox"
        Me.tempNumBox.Size = New System.Drawing.Size(32, 20)
        Me.tempNumBox.TabIndex = 29
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(96, 200)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(89, 12)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "テンプレ文章挿入"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(27, 200)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(36, 12)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "その他"
        '
        'btnReference
        '
        Me.btnReference.Location = New System.Drawing.Point(399, 85)
        Me.btnReference.Name = "btnReference"
        Me.btnReference.Size = New System.Drawing.Size(58, 23)
        Me.btnReference.TabIndex = 26
        Me.btnReference.Text = "参照"
        Me.btnReference.UseVisualStyleBackColor = True
        '
        'formatTextBox
        '
        Me.formatTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.formatTextBox.Location = New System.Drawing.Point(286, 28)
        Me.formatTextBox.Name = "formatTextBox"
        Me.formatTextBox.Size = New System.Drawing.Size(106, 19)
        Me.formatTextBox.TabIndex = 25
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(230, 31)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 12)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "日付表記"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(195, 169)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 12)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "状態"
        '
        'hyoukaBox
        '
        Me.hyoukaBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.hyoukaBox.Location = New System.Drawing.Point(226, 165)
        Me.hyoukaBox.Name = "hyoukaBox"
        Me.hyoukaBox.Size = New System.Drawing.Size(268, 19)
        Me.hyoukaBox.TabIndex = 22
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(96, 169)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 12)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "ADL得点"
        '
        'adlBox
        '
        Me.adlBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.adlBox.Location = New System.Drawing.Point(149, 165)
        Me.adlBox.MaxLength = 2
        Me.adlBox.Name = "adlBox"
        Me.adlBox.Size = New System.Drawing.Size(34, 19)
        Me.adlBox.TabIndex = 20
        Me.adlBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(5, 169)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 12)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "全身状態の評価"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(17, 139)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 12)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "(枠に収めて)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(34, 121)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 12)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "病名"
        '
        'saveDirPathBox
        '
        Me.saveDirPathBox.Location = New System.Drawing.Point(96, 87)
        Me.saveDirPathBox.Name = "saveDirPathBox"
        Me.saveDirPathBox.ReadOnly = True
        Me.saveDirPathBox.Size = New System.Drawing.Size(296, 19)
        Me.saveDirPathBox.TabIndex = 16
        '
        'fileNameBox
        '
        Me.fileNameBox.Location = New System.Drawing.Point(96, 57)
        Me.fileNameBox.Name = "fileNameBox"
        Me.fileNameBox.Size = New System.Drawing.Size(128, 19)
        Me.fileNameBox.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 12)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "保存先フォルダ"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 12)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "ファイル名"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(210, 200)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 12)
        Me.Label16.TabIndex = 29
        Me.Label16.Text = "パターン"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(19, 31)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 12)
        Me.Label17.TabIndex = 15
        Me.Label17.Text = "患者氏名"
        '
        'namBox
        '
        Me.namBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.namBox.Location = New System.Drawing.Point(96, 28)
        Me.namBox.Name = "namBox"
        Me.namBox.Size = New System.Drawing.Size(87, 19)
        Me.namBox.TabIndex = 26
        '
        'btnCreateExcelFile
        '
        Me.btnCreateExcelFile.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnCreateExcelFile.Location = New System.Drawing.Point(385, 282)
        Me.btnCreateExcelFile.Name = "btnCreateExcelFile"
        Me.btnCreateExcelFile.Size = New System.Drawing.Size(109, 47)
        Me.btnCreateExcelFile.TabIndex = 32
        Me.btnCreateExcelFile.Text = "エクセル作成"
        Me.btnCreateExcelFile.UseVisualStyleBackColor = True
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
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents hyoukaBox As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents formatTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnReference As System.Windows.Forms.Button
    Friend WithEvents tempNumBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents temp2Box As System.Windows.Forms.TextBox
    Friend WithEvents temp1Box As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents namBox As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnCreateExcelFile As System.Windows.Forms.Button

End Class
