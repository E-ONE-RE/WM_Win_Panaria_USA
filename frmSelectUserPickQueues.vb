
Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports System.Data

Public Class frmSelectUserPickQueues
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmSelectUserPickQueues"
    Private SapFunctionError As clsBusinessLogic.SapFunctionError

    Private ErrDescription As String

    Public Shared SourceForm As Form
    Public Shared EscludeEmptyQueue As Boolean = False
    Public Shared GetOnlyOpenJobs As Boolean = False


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            'Call frmEM_FromJob_Part_1_SelUbiSpunta_KeyPress(Me, e)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmSelectuUserPickQueues_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            hook.Start(Me)
#End If

            '**************************************
            'Traduzioni

            Me.Text = clsAppTranslation.GetSingleParameterValue(1236, Me.Text, "Seleziona Filtro Coda Utente")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            btnOK.Text = clsAppTranslation.GetSingleParameterValue(8, btnOK.Text, "OK")

            '************************************** 

            'CHIAMO WEB SERVICE PER RECUPERARE LE CODE DI PICKING OPERATORE
            RetCode = clsSapWS.Call_ZWS_GET_ZWMS_PICK_QUEUES_ALL(clsUser.SapWmsUser.LANGUAGE, EscludeEmptyQueue, GetOnlyOpenJobs, False, clsUser.objDataTableUserPickQueues, SapFunctionError, False)


            If Not (clsUser.objDataTableUserPickQueues Is Nothing) Then
                clsUser.objDataTableUserPickQueues.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridInfo.DataSource = clsUser.objDataTableUserPickQueues
            End If


            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()


            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        Dim WorkDataRow As DataRow

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'DEVO AVERE SELEZIONATO UNA RIGA
            If Me.DtGridInfo.CurrentRowIndex < 0 Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(445, "", "Attenzione!") & vbCrLf & clsAppTranslation.GetSingleParameterValue(541, "", "Selezionare una riga della griglia.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
            WorkDataRow = clsUser.objDataTableUserPickQueues.Rows(Me.DtGridInfo.CurrentRowIndex)

            'DEVONO ESSER PRESENTI DATI NEL RECORD
            If (WorkDataRow Is Nothing) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(445, "", "Attenzione!") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1651, "", "Oggetto selezionato non valido (Nothing).")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            'WARNING NESSUNA MISSIONE LIBERA NELLA CODA SELEZIONATA
            If (WorkDataRow.Item("ZOPEN_FREE_NUM") <= 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(445, "", "Attenzione!") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1652, "", "La coda selezionata non ha Task liberi.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If


            'IMPOSTO I DATI DEL TIPO CODA SELEZIONATA
            clsUser.SapWmsUser.ZID_PICK_QUEUE = WorkDataRow.Item("ZID_PICK_QUEUE")
            clsUser.SapWmsUser.ZPICK_QUEUE_DESC = WorkDataRow.Item("ZPICK_QUEUE_DESC")


            'Aggiorno dati form
#If Not APPLICAZIONE_WIN32 = "SI" Then
            frmMainHomeMenuForm.RefreshForm()
#Else

            'RESETTO FILTRI E OPZIONI CODE
            EscludeEmptyQueue = False
            GetOnlyOpenJobs = False

            If (SourceForm Is Nothing) Then
                'SE NON HO INFORMAZIONI SUL CHIAMANTE ALLORA TORNO AL MENU PRINCIPALE
                Call clsNavigation.Show_Mnu_Home(Me, True)
            ElseIf (SourceForm.GetType.Name = frmMainHomeMenuWin.GetType.Name) Then
                'PASSO ALLO VIDEATA DELLO STEP PRECEDENTE
                Call clsNavigation.Show_Mnu_Home(Me, True)
            ElseIf (SourceForm.GetType.Name = frmPickingMerci_Code_1_Settings.GetType.Name) Then
                'PASSO ALLO VIDEATA DELLO STEP PRECEDENTE
                frmPickingMerci_Code_1_SettingsForm = New frmPickingMerci_Code_1_Settings
                frmPickingMerci_Code_1_SettingsForm.Show()
                Me.Close()
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
            If (Me.DtGridInfo.TableStyles.Count = 0) Then

#If Not APPLICAZIONE_WIN32 <> "SI" Then
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "ZID_PICK_QUEUE", clsAppTranslation.GetSingleParameterValue(1239, "", "Id"), True, DefDtGridCol_NumeroMagazzino + 30, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "ZPICK_QUEUE_DESC", clsAppTranslation.GetSingleParameterValue(1240, "", "Descrizione Coda"), True, DefDtGridCol_TipoMagazzino + 230, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "ZOPEN_FREE_NUM", clsAppTranslation.GetSingleParameterValue(1649, "", "Free Nr."), True, 100, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "ZOPEN_ST_NUM", clsAppTranslation.GetSingleParameterValue(1294, "", "Open Nr."), True, 150, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "ZOPEN_RSV_NUM", clsAppTranslation.GetSingleParameterValue(1650, "", "Reserved Nr."), True, 150, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "0,0.", "ZTOTAL_WMS_KG", clsAppTranslation.GetSingleParameterValue(1311, "", "Tot.Kg."), DefDtGridCol_Show_ZTOTAL_WMS_KG, 100, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "0,0.", "ZTOTAL_WMS_LB", clsAppTranslation.GetSingleParameterValue(1312, "", "Tot.Lb."), True, 100, True)


                'RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "ZTOTAL_WMSLINES", clsAppTranslation.GetSingleParameterValue(1310, "", "Num.Linee"), True, 100, True)
                'RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "0,0.", "ZTOTAL_WMS_KG", clsAppTranslation.GetSingleParameterValue(1311, "", "Tot.Kg."), DefDtGridCol_Show_ZTOTAL_WMS_KG, 100, True)
                'RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "0,0.", "ZTOTAL_WMS_LB", clsAppTranslation.GetSingleParameterValue(1312, "", "Tot.Lb."), True, 100, True)
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

    Private Sub cmdAbortScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbortScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim UserAnswer As DialogResult = DialogResult.No
        Dim WorkString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            WorkString = clsAppTranslation.GetSingleParameterValue(282, "", "Si desidera veramente abbandonare la procedura ? (SI/NO)")
            UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                Exit Sub
            End If


            'Aggiorno dati form
#If Not APPLICAZIONE_WIN32 = "SI" Then
            frmMainHomeMenuForm.RefreshForm()
#Else

            'RESETTO FILTRI CODE
            EscludeEmptyQueue = False
            GetOnlyOpenJobs = False

            If (SourceForm Is Nothing) Then
                'SE NON HO INFORMAZIONI SUL CHIAMANTE ALLORA TORNO AL MENU PRINCIPALE
                Call clsNavigation.Show_Mnu_Home(Me, True)
            ElseIf (SourceForm.GetType.Name = frmMainHomeMenuWin.GetType.Name) Then
                'PASSO ALLO VIDEATA DELLO STEP PRECEDENTE
                Call clsNavigation.Show_Mnu_Home(Me, True)
            ElseIf (SourceForm.GetType.Name = frmPickingMerci_Code_1_Settings.GetType.Name) Then
                'PASSO ALLO VIDEATA DELLO STEP PRECEDENTE
                frmPickingMerci_Code_1_SettingsForm = New frmPickingMerci_Code_1_Settings
                frmPickingMerci_Code_1_SettingsForm.Show()
                Me.Close()
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
End Class