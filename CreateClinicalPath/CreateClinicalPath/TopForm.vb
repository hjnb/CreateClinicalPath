Imports System.Data.OleDb
Imports System.IO
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop

Public Class TopForm
    'エクセルのパス
    Public excelFilePath As String = My.Application.Info.DirectoryPath & "\CreateClinicalPath.xls"

    '.iniファイルのパス
    Public iniFilePath As String = My.Application.Info.DirectoryPath & "\CreateClinicalPath.ini"

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

    'テンプレ文章
    Private Const TEMP1_1 As String = "療養生活に不安なく過ごし、現在の機能低下予防に向けて"
    Private Const TEMP1_2 As String = "援助させて頂きます。"
    Private Const TEMP2_1 As String = "誤嚥性肺炎の予防、加齢に伴う異常の観察を行い"
    Private Const TEMP2_2 As String = "療養中の苦痛の緩和に努めさせて頂きます。"
    Private Const TEMP3_1 As String = "呼吸管理を行い、全身状態の変化に注意をし、療養生活が"
    Private Const TEMP3_2 As String = "円滑に過ごせる様に努めさせて頂きます。"
    Private Const TEMP4_1 As String = "転落やチューブの自抜去等の予防に努め療養生活が安心して送れる様、"
    Private Const TEMP4_2 As String = "援助させて頂きます。"
    Private Const TEMP5_1 As String = "ターミナルを迎えている状況にあり、静かに尊厳死を迎えられるよう"
    Private Const TEMP5_2 As String = "ターミナルケアに努めさせて頂きます。"
    Private tempDic As New Dictionary(Of String, String()) From {{"", {"", ""}}, {"1", {TEMP1_1, TEMP1_2}}, {"2", {TEMP2_1, TEMP2_2}}, {"3", {TEMP3_1, TEMP3_2}}, {"4", {TEMP4_1, TEMP4_2}}, {"5", {TEMP5_1, TEMP5_2}}}

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

        If Not System.IO.File.Exists(excelFilePath) Then
            MsgBox("エクセルファイルが存在しません。ファイルを配置して下さい。", MsgBoxStyle.Exclamation)
            Me.Close()
            Exit Sub
        End If

        'データグリッドビュー初期設定
        initDgv()

        '患者リスト表示
        displayPatientList()

        'テキスト等初期化
        clearText()
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

        '患者氏名
        namBox.Text = ""
        '日付表記
        formatTextBox.Text = ""
        'ファイル名
        fileNameBox.Text = ""
        '保存先フォルダパス
        saveDirPathBox.Text = targetDirPath
        '全身状態の評価
        adlBox.Text = "" 'ADL得点
        hyoukaBox.Text = "" '状態
        'テンプレ文章挿入
        tempNumBox.Text = ""
        temp1Box.Text = ""
        temp2Box.Text = ""
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
            MsgBox("日付：" & selectedDate & "の評価表データが存在しません。" & Environment.NewLine & "喀痰吸引有無、中心静脈栄養有無、ADL得点は取得できませんでした。", MsgBoxStyle.Exclamation)
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
        '患者氏名
        namBox.Text = selectedNam
        '日付表記
        formatTextBox.Text = formatDateStr(selectedDate)
        'ファイル名
        fileNameBox.Text = selectedDate.Replace("/", "") & selectedNam.Replace("　", "").Replace(" ", "")
        '保存先フォルダ
        saveDirPathBox.Text = targetDirPath
        '全身状態の評価
        Dim hyouka As String = If(chkKakutan.Checked, KAKUTAN, If(chkTyusin.Checked, TYUSINJYOMYAKU, ""))
        adlBox.Text = adlLabel.Text
        hyoukaBox.Text = hyouka

    End Sub

    ''' <summary>
    ''' 和暦表記にフォーマット
    ''' </summary>
    ''' <param name="adStr">西暦(yyyy/MM/dd)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function formatDateStr(adStr As String) As String
        If adStr = "" Then
            Return ""
        End If

        Dim warekiStr As String = Util.convADStrToWarekiStr(adStr)
        Dim kanji As String = Util.getKanji(warekiStr)
        Dim eraNum As String = CInt(warekiStr.Substring(1, 2))
        Dim monthNum As String = CInt(warekiStr.Substring(4, 2))
        Dim dateNum As String = CInt(warekiStr.Substring(7, 2))
        Return kanji & eraNum & "年" & monthNum & "月" & dateNum & "日"
    End Function

    ''' <summary>
    ''' テンプレパターン値変更時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tempNumBox_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles tempNumBox.SelectedValueChanged
        Dim tempType As String = tempNumBox.Text
        'テキストボックスへ文章設定
        temp1Box.Text = tempDic(tempType)(0)
        temp2Box.Text = tempDic(tempType)(1)
    End Sub

    ''' <summary>
    ''' 参照ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnReference_Click(sender As System.Object, e As System.EventArgs) Handles btnReference.Click
        Dim fbd As New FolderBrowserDialog
        fbd.Description = "保存先フォルダを指定してください。"
        fbd.RootFolder = Environment.SpecialFolder.Desktop
        fbd.ShowNewFolderButton = True

        'フォルダ選択済みの場合はそこをデフォルトに
        If Directory.Exists(saveDirPathBox.Text) Then
            fbd.SelectedPath = saveDirPathBox.Text
        End If

        'ダイアログ表示
        If fbd.ShowDialog() = DialogResult.OK Then
            '選択されたフォルダパスを表示
            saveDirPathBox.Text = fbd.SelectedPath
        End If
    End Sub

    ''' <summary>
    ''' エクセル作成ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCreateExcelFile_Click(sender As System.Object, e As System.EventArgs) Handles btnCreateExcelFile.Click
        '患者氏名
        Dim nam As String = namBox.Text
        If nam = "" Then
            MsgBox("患者氏名を入力して下さい。", MsgBoxStyle.Exclamation)
            namBox.Focus()
            Return
        End If
        '日付表記
        Dim formatDate As String = formatTextBox.Text
        If formatDate = "" Then
            MsgBox("日付表記を入力して下さい。", MsgBoxStyle.Exclamation)
            formatTextBox.Focus()
            Return
        End If
        'ファイル名
        Dim fileName As String = fileNameBox.Text
        If fileName = "" Then
            MsgBox("ファイル名を入力して下さい。", MsgBoxStyle.Exclamation)
            fileNameBox.Focus()
            Return
        End If
        '保存先フォルダパス
        Dim saveDirPath As String = saveDirPathBox.Text
        If Not Directory.Exists(saveDirPath) Then
            MsgBox("正しい保存先フォルダを指定して下さい。", MsgBoxStyle.Exclamation)
            fileNameBox.Focus()
            Return
        End If

        'エクセルが作成済みかチェック
        Dim createExcelFileName1 As String = fileName & ".xls"
        Dim createExcelFileName2 As String = fileName & "完了.xls"
        Dim createExcelFilePath1 As String = saveDirPath & "\" & createExcelFileName1
        Dim createExcelFilePath2 As String = saveDirPath & "\" & createExcelFileName2
        If File.Exists(createExcelFilePath1) OrElse File.Exists(createExcelFilePath2) Then
            MsgBox(createExcelFileName1 & " または" & Environment.NewLine & createExcelFileName2 & " は既に作成されています。", MsgBoxStyle.Exclamation)
            Return
        End If

        '病名テキスト
        Dim byo1 As String = byo1TextBox.Text
        Dim byo2 As String = byo2TextBox.Text
        'ADL得点
        Dim adl As String = adlBox.Text
        '状態
        Dim jyo As String = hyoukaBox.Text
        'テンプレテキスト
        Dim temp1 As String = temp1Box.Text
        Dim temp2 As String = temp2Box.Text

        '原本エクセルをコピー
        Try
            System.IO.File.Copy(excelFilePath, createExcelFilePath1)
        Catch ex As Exception
            MsgBox("原本エクセルコピーでエラーが発生しました。" & Environment.NewLine & ex.Message, MsgBoxStyle.Exclamation)
            Return
        End Try

        'コピーしたエクセルへ書き込み
        Dim objExcel As Excel.Application = CreateObject("Excel.Application")
        Dim objWorkBooks As Excel.Workbooks = objExcel.Workbooks
        Dim objWorkBook As Excel.Workbook = objWorkBooks.Open(createExcelFilePath1)
        Dim oSheet As Excel.Worksheet = objWorkBook.Worksheets("計画書")
        objExcel.Calculation = Excel.XlCalculation.xlCalculationManual
        objExcel.ScreenUpdating = False

        '患者氏名
        oSheet.Range("D8").Value = selectedNam
        '日付
        oSheet.Range("T9").Value = formatDate
        '病名
        oSheet.Range("G13").Value = byo1
        oSheet.Range("G14").Value = byo2
        '全身状態の評価
        'ADL得点
        oSheet.Range("G22").Value = "ADL" & adl
        '状態
        oSheet.Range("I22").Value = jyo
        'その他
        oSheet.Range("G46").Value = temp1
        oSheet.Range("G47").Value = temp2

        objExcel.Calculation = Excel.XlCalculation.xlCalculationAutomatic
        objExcel.ScreenUpdating = True

        '保存
        objWorkBook.Save()

        ' EXCEL解放
        objExcel.Quit()
        Marshal.ReleaseComObject(objWorkBook)
        Marshal.ReleaseComObject(objExcel)
        oSheet = Nothing
        objWorkBook = Nothing
        objExcel = Nothing

        MsgBox(createExcelFilePath1 & Environment.NewLine & "エクセルファイルを作成しました。", MsgBoxStyle.Information)
    End Sub

    Private Sub btnAddComma1_Click(sender As System.Object, e As System.EventArgs) Handles btnAddComma1.Click
        byo1TextBox.Text &= "、"
    End Sub

    Private Sub btnAddComma2_Click(sender As System.Object, e As System.EventArgs) Handles btnAddComma2.Click
        byo2TextBox.Text &= "、"
    End Sub

    ''' <summary>
    ''' 保存先フォルダ開くボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDirOpen_Click(sender As System.Object, e As System.EventArgs) Handles btnDirOpen.Click
        Dim saveDirPath As String = saveDirPathBox.Text
        If Not Directory.Exists(saveDirPath) Then
            MsgBox("正しい保存先フォルダを指定して下さい。", MsgBoxStyle.Exclamation)
            fileNameBox.Focus()
            Return
        End If
        System.Diagnostics.Process.Start(saveDirPathBox.Text)
        Me.Close()
    End Sub
End Class
