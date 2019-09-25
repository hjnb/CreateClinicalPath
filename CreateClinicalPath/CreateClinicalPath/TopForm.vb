Imports System.Data.OleDb

Public Class TopForm
    'エクセルのパス
    Public excelFilePass As String = My.Application.Info.DirectoryPath & "\CreateClinicalPath.xls"

    '.iniファイルのパス
    Public iniFilePath As String = My.Application.Info.DirectoryPath & "\CreateClinicalPath.ini"

    '画像パス
    'Public imageFilePath As String = My.Application.Info.DirectoryPath & "\Contact.PNG"

    'Patientのデータベースパス
    Public dbPatientFilePath As String = Util.getIniString("System", "PatientDir", iniFilePath) & "\Patient.mdb"
    Public DB_Patient As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPatientFilePath

    'Sanatoのデータベースパス
    Public dbSanatoFilePath As String = Util.getIniString("System", "SanatoDir", iniFilePath) & "\Sanato.mdb"
    Public DB_Sanato As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbSanatoFilePath

    '計画書のエクセルを作成するフォルダパス
    Public targetDirPath As String = Util.getIniString("System", "TargetDir", iniFilePath)

    '選択している患者名、患者コード
    Private selectedNam As String
    Private selectedCod As Integer

    '喀痰吸引
    Private Const KAKUTAN As String = "1日8回以上の喀痰吸引を必要とする状態"
    '中心静脈栄養
    Private Const TYUSINJYOMYAKU As String = "中心静脈栄養を実施している状態"

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        InitializeComponent()

        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MinimizeBox = False
        Me.MaximizeBox = False
    End Sub

    ''' <summary>
    ''' loadイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TopForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'データベース、エクセル、構成ファイルの存在チェック
        If Not System.IO.File.Exists(iniFilePath) Then
            MsgBox("構成ファイルが存在しません。ファイルを配置して下さい。", MsgBoxStyle.Exclamation)
            Me.Close()
            Exit Sub
        End If
        If Not System.IO.File.Exists(dbPatientFilePath) Then
            MsgBox("Patientデータベースファイルが存在しません。" & Environment.NewLine & "iniファイルのPatientDirに適切なパスを設定して下さい。", MsgBoxStyle.Exclamation)
            Me.Close()
            Exit Sub
        End If
        If Not System.IO.File.Exists(dbSanatoFilePath) Then
            MsgBox("Sanatoデータベースファイルが存在しません。" & Environment.NewLine & "iniファイルのSanatoDirに適切なパスを設定して下さい。", MsgBoxStyle.Exclamation)
            Me.Close()
            Exit Sub
        End If
        If Not System.IO.Directory.Exists(targetDirPath) Then
            MsgBox("ファイル作成場所のフォルダが存在しません。" & Environment.NewLine & "iniファイルのTargetDirに適切なパスを設定して下さい。", MsgBoxStyle.Exclamation)
            Me.Close()
            Exit Sub
        End If

        'If Not System.IO.File.Exists(excelFilePass) Then
        '    MsgBox("エクセルファイルが存在しません。ファイルを配置して下さい。", MsgBoxStyle.Exclamation)
        '    Me.Close()
        '    Exit Sub
        'End If

        'データグリッドビュー初期設定
        initDgv()

        '患者リスト表示
        displayPatientList()
    End Sub

    ''' <summary>
    ''' データグリッドビュー初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initDgv()
        '患者リスト
        Util.EnableDoubleBuffering(dgvPatientList)
        With dgvPatientList
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False '行削除禁止
            .BorderStyle = BorderStyle.FixedSingle
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersVisible = False
            .RowHeadersVisible = False
            .RowTemplate.Height = 18
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .ShowCellToolTips = False
            .EnableHeadersVisualStyles = False
            .Font = New Font("ＭＳ Ｐゴシック", 9)
            .ReadOnly = True
        End With

        '病名テキスト
        Util.EnableDoubleBuffering(dgvText)
        With dgvText
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False '行削除禁止
            .BorderStyle = BorderStyle.FixedSingle
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersVisible = False
            .RowHeadersVisible = False
            .RowTemplate.Height = 18
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .ShowCellToolTips = False
            .EnableHeadersVisualStyles = False
            .Font = New Font("ＭＳ Ｐゴシック", 9)
            .ReadOnly = True
            .ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        End With
        '空行6行追加
        Dim dt As New DataTable
        dt.Columns.Add("Text", GetType(String))
        For i As Integer = 0 To 5
            Dim row As DataRow = dt.NewRow()
            row("Text") = ""
            dt.Rows.Add(row)
        Next
        dgvText.DataSource = dt
        dgvText.ClearSelection()
        With dgvText.Columns("Text")
            .Width = 385
        End With

    End Sub

    ''' <summary>
    ''' テキストクリア
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clearText()
        '病名テキストのクリア
        For Each row As DataGridViewRow In dgvText.Rows
            row.Cells("Text").Value = ""
        Next
        dgvText.ClearSelection()

        '喀痰吸引、中心静脈栄養チェックのクリア
        chkKakutan.Checked = False
        chkTyusin.Checked = False

        'ADL得点のクリア
        adlLabel.Text = ""

        'ファイル名
        fileNameBox.Text = ""

        '保存先フォルダパス
        saveDirPathBox.Text = ""

        '全身状態の評価
        adlBox.Text = ""
    End Sub

    ''' <summary>
    ''' 患者リスト表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub displayPatientList()
        'データ取得
        Dim cn As New ADODB.Connection()
        cn.Open(DB_Patient)
        Dim sql As String = "SELECT Nam, Cod FROM UsrM where Sanato = 1 ORDER BY Kana"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockOptimistic)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter()
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, rs, "UsrM")
        Dim dt As DataTable = ds.Tables("UsrM")

        '表示
        dgvPatientList.DataSource = dt
        dgvPatientList.ClearSelection()
        cn.Close()

        '幅設定等
        With dgvPatientList
            '非表示
            .Columns("Cod").Visible = False

            With .Columns("Nam")
                .Width = 85
            End With
            If dgvPatientList.Rows.Count <= 30 Then
                dgvPatientList.Size = New Size(88, 542)
            Else
                dgvPatientList.Size = New Size(105, 542)
            End If
        End With
    End Sub

    ''' <summary>
    ''' 患者リストCellMouseClickイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvPatientList_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvPatientList.CellMouseClick
        If e.RowIndex >= 0 Then
            Dim nam As String = Util.checkDBNullValue(dgvPatientList("Nam", e.RowIndex).Value)
            Dim cod As Integer = dgvPatientList("Cod", e.RowIndex).Value
            selectedNam = nam
            selectedCod = cod

            '日付リスト表示
            displayDateList()

            'テキストクリア
            clearText()
        End If
    End Sub

    ''' <summary>
    ''' 診療録日付リスト表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub displayDateList()
        dateList.Items.Clear()
        Dim cn As New ADODB.Connection()
        cn.Open(DB_Sanato)
        Dim sql As String = "SELECT distinct Ymd FROM Sin2 where Cod = " & selectedCod & " ORDER BY Ymd Desc"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockOptimistic)
        While Not rs.EOF
            Dim ymd As String = Util.checkDBNullValue(rs.Fields("Ymd").Value)
            dateList.Items.Add(ymd)
            rs.MoveNext()
        End While
        rs.Close()
        cn.Close()
    End Sub

    ''' <summary>
    ''' 日付リスト選択値変更時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dateList_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles dateList.SelectedIndexChanged
        If dateList.Text = "" Then
            Return
        End If

        'クリア
        clearText()

        '選択日付
        Dim selectedDate As String = dateList.Text 'yyyy/MM/dd
        Dim dd As String = CInt(selectedDate.Split("/")(2)).ToString()

        '診療録データ(Sin2テーブル)から病名テキスト取得
        Dim cn As New ADODB.Connection()
        cn.Open(DB_Sanato)
        Dim sql As String = "SELECT Gyo, [Text] FROM Sin2 where Cod = " & selectedCod & " and Ymd = '" & selectedDate & "' order by Gyo"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockOptimistic)
        While Not rs.EOF
            Dim gyo As Integer = rs.Fields("Gyo").Value
            If 83 <= gyo AndAlso gyo <= 88 Then
                Dim txt As String = Util.checkDBNullValue(rs.Fields("Text").Value) '病名テキスト
                txt = txt.Replace("/", "、")
                dgvText("Text", gyo - 83).Value = txt
            End If
            rs.MoveNext()
        End While
        rs.Close()

        '評価表データ(Hyoテーブル)から喀痰吸引有無、中心静脈栄養有無、ADL得点を取得
        sql = "select * from Hyo where Cod = " & selectedCod & " and Ymd = '" & selectedDate & "'"
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount <= 0 Then
            MsgBox("日付：" & selectedDate & "の評価表データが存在しません。", MsgBoxStyle.Exclamation)
            rs.Close()
            cn.Close()
            Return
        End If
        '中心静脈栄養(Kbn="1"でGyo=3)
        rs.Filter = "Kbn = '1' and Gyo = 3"
        If rs.RecordCount > 0 Then
            Dim val As Integer = rs.Fields("D" & dd).Value
            If val = 1 Then
                chkTyusin.Checked = True
            End If
        End If
        '喀痰吸引(Kbn="2"でGyo=25)
        rs.Filter = "Kbn = '2' and Gyo = 25"
        If rs.RecordCount > 0 Then
            Dim val As Integer = rs.Fields("D" & dd).Value
            If val = 1 Then
                chkKakutan.Checked = True
            End If
        End If
        'ADL(Kbn="3"でGyo=5)
        rs.Filter = "Kbn = '3' and Gyo = 5"
        If rs.RecordCount > 0 Then
            Dim val As Integer = rs.Fields("D" & dd).Value
            adlLabel.Text = val
        End If
        rs.Close()
        cn.Close()

        'エクセル作成用部分
        'ファイル名
        fileNameBox.Text = selectedDate.Replace("/", "") & selectedNam.Replace("　", "").Replace(" ", "")
        '保存先フォルダ
        saveDirPathBox.Text = targetDirPath
        '全身状態の評価
        Dim adlText As String = If(chkKakutan.Checked, KAKUTAN, If(chkTyusin.Checked, TYUSINJYOMYAKU, ""))
        adlBox.Text = "ADL" & adlLabel.Text & "　" & adlText

    End Sub
End Class
