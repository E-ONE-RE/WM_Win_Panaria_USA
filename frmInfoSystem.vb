
Imports clsSapWS
Imports clsNavigation

Public Class frmInfoSystem
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmInfoSystem"

    Public ErrDescription As String


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmInfoSystem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.btnHome.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.btnHome_Click(Me, e)
                    Exit Sub
                End If
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmInfoSystem_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkVersion As Version
        Dim WorkVersion_str As String
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            hook.Start(Me)
#End If

            '**************************************
            'Traduzioni

            lblAssemblyVersion.Text = clsAppTranslation.GetSingleParameterValue(260, lblAssemblyVersion.Text, "Versione Applicazione")
            lblAssemblyFolder.Text = clsAppTranslation.GetSingleParameterValue(1578, lblAssemblyFolder.Text, "Folder Applicazione")

            Me.Text = clsAppTranslation.GetSingleParameterValue(1171, Me.Text, "Info Sistema")

            btnAggiorna.Text = clsAppTranslation.GetSingleParameterValue(280, btnAggiorna.Text, "Agg.")
            btnHome.Text = clsAppTranslation.GetSingleParameterValue(264, btnHome.Text, "Home")

            '**************************************   


            'Imposto il DataSource per la griglia UserInfo
            If Not (clsInfoSystem.objDataTableInfo Is Nothing) Then
                clsInfoSystem.objDataTableInfo.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridUserInfo.DataSource = clsInfoSystem.objDataTableInfo
            End If


            'Imposto il DataSource per la griglia AppParam
            If Not (clsAppParameters.objDataTableAppParamsInfo Is Nothing) Then
                clsAppParameters.objDataTableAppParamsInfo.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridAppParam.DataSource = clsAppParameters.objDataTableAppParamsInfo
            End If


            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()

            'refresh dei dati
            RetCode += clsInfoSystem.RefreshDateTableForSystemInfo()


            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGUO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            'RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)


#If Not APPLICAZIONE_WIN32 = "SI" Then
            btnAggiorna.Visible = True  
#Else
            'VALORIZZO IL CAMPO APPLICATION FOLDER
            txtAssemblyFolder.Text = System.IO.Path.GetDirectoryName(Application.ExecutablePath)

            btnAggiorna.Visible = False
#End If


            'Ricavo la versione dell'assembly
#If APPLICAZIONE_WIN32 = "SI" Then

            WorkVersion_str = clsUtility.GetAssemblyApplicationVersion("", "")
            Me.txtAssemblyVersion.Text = WorkVersion_str

#Else
            WorkVersion = clsUtility.GetAssemblyApplicationVersion()

            If (Not WorkVersion Is Nothing) Then
                Me.txtAssemblyVersion.Text = WorkVersion.ToString
            Else
                Me.txtAssemblyVersion.Text = ""
            End If

#End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
    Private Sub btnHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHome.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RetCode = clsNavigation.Show_Mnu_Home(Me, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(281, "", "Errore nell'apertura della form. Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Function SetDataGridColumnStyles() As Long
        '**************************************
        'imposta la visualizzazione di tutte le colonne della DATA GRID
        '**************************************

        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'creo la formattazione solo la prima volta
            If (Me.DtGridUserInfo.TableStyles.Count = 0) Then
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridUserInfo, "", "PropertyId", clsAppTranslation.GetSingleParameterValue(542, "", "Proprietà"), True, 100, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridUserInfo, "", "PropertyValue", clsAppTranslation.GetSingleParameterValue(543, "", "Valore"), True, 300, True)
            End If


            'creo la formattazione solo la prima volta
            If (Me.DtGridAppParam.TableStyles.Count = 0) Then
#If Not APPLICAZIONE_WIN32 = "SI" Then
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridAppParam, "", "ZidWmsAppParams", clsAppTranslation.GetSingleParameterValue(542, "", "Proprietà"), True, 150, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridAppParam, "", "ZvalueWmsAppParams", clsAppTranslation.GetSingleParameterValue(543, "", "Valore"), True, 300, True)
#Else
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridAppParam, "", "ZidWmsAppParams", clsAppTranslation.GetSingleParameterValue(542, "", "Proprietà"), True, 250, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridAppParam, "", "ZvalueWmsAppParams", clsAppTranslation.GetSingleParameterValue(543, "", "Valore"), True, 400, True)
#End If
            End If


            SetDataGridColumnStyles = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            SetDataGridColumnStyles = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Private Sub btnAggiorna_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAggiorna.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        'Dim RetCode As Long
        'Dim WorkCurrentVersion As Version
        'Dim WorkUpdatedVersion As Version
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'verifico di avere un file valido per eventuale aggiornamento
            'If (clsUtility.IsStringValid(ApplicationAbsoluteFileNameUpdate, True) = False) Then
            '    ErrDescription = "Nessun File di Aggiornamento definito."
            '    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    Exit Sub
            'End If


            'RetCode = clsUtility.NetworkShareConnect(Me, "\\pc-lbellei\palmari")



            'recupero la versione corrente
            'WorkCurrentVersion = clsUtility.GetAssemblyApplicationVersion()
            'If (WorkCurrentVersion Is Nothing) Then
            '    ErrDescription = "Errore nel recupero della versione del programma attivo."
            '    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    Exit Sub
            'End If

            'recupero la versione del programma di UPDATE
            'WorkUpdatedVersion = clsUtility.GetFileExeVersionInfo(ApplicationAbsoluteFileNameUpdate)
            'If (WorkUpdatedVersion Is Nothing) Then
            '    ErrDescription = "Errore nel recupero della versione del programma remoto."
            '    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    Exit Sub
            'End If

            'If (WorkCurrentVersion.Major >= WorkUpdatedVersion.Major) And (WorkCurrentVersion.Minor >= WorkUpdatedVersion.Minor) And (WorkCurrentVersion.Revision >= WorkUpdatedVersion.Revision) Then
            '    ErrDescription = "Il programma non necessita di essere aggiornato." & vbCrLf & "Versione Attivo:" & WorkCurrentVersion.ToString & vbCrLf & "Versione Remoto:" & WorkUpdatedVersion.ToString
            '    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            '    Exit Sub
            'Else
            '    System.IO.File.Copy("\\pc-lbellei\palmari\WM_MobileGRESMALT.exe", "programmi\WM_Mobile_GRESMALT\WM_MobileGRESMALT_tmp.exe")
            'End If


            'recupero la versione corrente
            'WorkCurrentVersion = clsUtility.GetAssemblyApplicationVersion()
            'WorkVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName.Version


            'controllo esistenza file di update
            'If (clsFile.IsFileExisting(ApplicationAbsoluteFileNameUpdate) = False) Then
            '    ErrDescription = "File di Aggiornamento non presente."
            '    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    Exit Sub
            'End If

            'recupero la versione file di update
            'WorkUpdatedVersion = System.Reflection.Assembly.LoadFrom(ApplicationAbsoluteFileNameUpdate).GetName.Version

            'Dim WorkDateCurrent As Date
            'Dim WorkDateUpdateCurrent As Date

            'WorkDateCurrent = System.IO.File.GetLastWriteTime("programmi\WM_Mobile_GRESMALT\WM_MobileGRESMALT.exe")
            'WorkDateUpdateCurrent = System.IO.File.GetLastWriteTime("\\pc-lbellei\palmari\WM_MobileGRESMALT.exe")

            'If WorkDateUpdateCurrent > WorkDateCurrent Then
            '    'COPIA FILE
            '    System.IO.File.Copy("\\pc-lbellei\palmari\WM_MobileGRESMALT.exe", "programmi\WM_Mobile_GRESMALT\WM_MobileGRESMALT_tmp.exe")
            'End If


            'Avvio eseguibile aggiornato
            System.Diagnostics.Process.Start(clsUtility.GetApplicationPath() & "\" & "WM_Starter.exe", "")


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub


    Private Sub TextBox1_DoubleClick(sender As Object, e As EventArgs) Handles txtAssemblyFolder.DoubleClick
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim WorkString As String
        Dim UserAnswer As String
        Dim frmPassRequestForm As New frmPassRequest
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'MessageBox.Show("Directory Exe :  " & System.IO.Path.GetDirectoryName(Application.ExecutablePath), "InfoExe")

            WorkString = clsAppTranslation.GetSingleParameterValue(1577, "", "Si desidera aprire la folder dell'applicazione? ") & clsAppTranslation.GetSingleParameterValue(322, "", "(SI/NO)")
            UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                Exit Sub
            End If


            'Apro form richiesta Password Interna
            frmPassRequestForm = New frmPassRequest
            frmPassRequestForm.Show()


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub


End Class