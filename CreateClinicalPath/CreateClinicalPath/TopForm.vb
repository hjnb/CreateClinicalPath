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

        '患者リスト表示
        displayPatientList()
    End Sub

    ''' <summary>
    ''' 患者リスト読み込み
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub displayPatientList()
        'dgv初期設定
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

        'データ読み込み
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
                dgvPatientList.Size = New Size(88, 537)
            Else
                dgvPatientList.Size = New Size(105, 537)
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
        End If
    End Sub

    ''' <summary>
    ''' 診療録日付リスト表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub displayDateList()

    End Sub

End Class
