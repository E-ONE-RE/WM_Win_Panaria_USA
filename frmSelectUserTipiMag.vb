
Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports System.Data

Public Class frmSelectUserTipiMag
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmSelectUserTipiMag"
    Private SapFunctionError As clsBusinessLogic.SapFunctionError

    Private ErrDescription As String

    Public Shared SourceForm As Form


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

    Private Sub frmSelectUserTipiMag_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            Me.Text = clsAppTranslation.GetSingleParameterValue(1176, Me.Text, "Seleziona Magazzini Utente")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            btnOK.Text = clsAppTranslation.GetSingleParameterValue(8, btnOK.Text, "OK")

            '************************************** 

            'CHIAMO WEB SERVICE ANAGRAFICA CARRELLISTI
            RetCode = clsSapWS.Call_ZWS_GET_USERS_PROF_LGTYP(clsUser.SapWmsUser.USERID, False, clsDataType.Operation_Type.Operation_Type_All, "", False, clsUser.objDataTableUsersProfLgtyp, SapFunctionError, False)


            If Not (clsUser.objDataTableUsersProfLgtyp Is Nothing) Then
                clsUser.objDataTableUsersProfLgtyp.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridInfo.DataSource = clsUser.objDataTableUsersProfLgtyp
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
            WorkDataRow = clsUser.objDataTableUsersProfLgtyp.Rows(Me.DtGridInfo.CurrentRowIndex)

            'DEVONO ESSER PRESENTI DATI NEL RECORD
            If (WorkDataRow Is Nothing) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(445, "", "Attenzione!") & vbCrLf & "Oggetto selezionato non valido (Nothing)."
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'IMPOSTO I DATI DEL CARRELLO SELEZIONATO
            clsUser.UsersProfLgtyp.LGTYP = WorkDataRow.Item("LGTYP")


            'Aggiorno dati form
#If Not APPLICAZIONE_WIN32 = "SI" Then
            frmMainHomeMenuForm.RefreshForm()
#Else

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
#If Not APPLICAZIONE_WIN32 = "SI" Then
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "LGNUM", clsAppTranslation.GetSingleParameterValue(1165, "", "NMg"), True, DefDtGridCol_NumeroMagazzino + 10, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "LGTYP", clsAppTranslation.GetSingleParameterValue(1166, "", "Cat"), True, DefDtGridCol_TipoMagazzino + 10, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "LTYPT", clsAppTranslation.GetSingleParameterValue(776, "", "Desc."), True, 100, True)
#Else
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "LGNUM", clsAppTranslation.GetSingleParameterValue(1165, "", "NMg"), True, DefDtGridCol_NumeroMagazzino + 30, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "LGTYP", clsAppTranslation.GetSingleParameterValue(1166, "", "Cat"), True, DefDtGridCol_TipoMagazzino + 30, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "LTYPT", clsAppTranslation.GetSingleParameterValue(776, "", "Desc."), True, 600, True)
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