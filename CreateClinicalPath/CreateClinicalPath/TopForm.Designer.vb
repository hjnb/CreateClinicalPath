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
        Me.dgvDateList = New System.Windows.Forms.DataGridView()
        CType(Me.dgvPatientList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDateList, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.dgvPatientList.Location = New System.Drawing.Point(15, 37)
        Me.dgvPatientList.Name = "dgvPatientList"
        Me.dgvPatientList.RowTemplate.Height = 21
        Me.dgvPatientList.Size = New System.Drawing.Size(105, 537)
        Me.dgvPatientList.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(138, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "診療録作成日"
        '
        'dgvDateList
        '
        Me.dgvDateList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDateList.Location = New System.Drawing.Point(140, 37)
        Me.dgvDateList.Name = "dgvDateList"
        Me.dgvDateList.RowTemplate.Height = 21
        Me.dgvDateList.Size = New System.Drawing.Size(89, 61)
        Me.dgvDateList.TabIndex = 4
        '
        'TopForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 586)
        Me.Controls.Add(Me.dgvDateList)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvPatientList)
        Me.Controls.Add(Me.Label1)
        Me.Name = "TopForm"
        Me.Text = "入院診療計画作成"
        CType(Me.dgvPatientList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDateList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvPatientList As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvDateList As System.Windows.Forms.DataGridView

End Class
