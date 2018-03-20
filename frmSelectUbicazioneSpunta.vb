
Imports System.Data
Imports clsSapWS
Imports clsNavigation
Imports clsDataType


Public Class frmSelectUbicazioneSpunta
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmSelectUbicazioneSpunta"

    Private ErrDescription As String


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

    Private Sub frmSelectUbicazione_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Me.Text = clsAppTranslation.GetSingleParameterValue(189, Me.Text, "Selezione Ubicazione")
            Me.cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, Me.cmdAbortScreen.Text, "Annulla")
            Me.btnOK.Text = clsAppTranslation.GetSingleParameterValue(8, Me.btnOK.Text, "OK")
            '************************************** 


            If Not (clsSelezioneUbicazioneSpunta.objDataTableUbiSpunta Is Nothing) Then
                clsSelezioneUbicazioneSpunta.objDataTableUbiSpunta.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridInfo.DataSource = clsSelezioneUbicazioneSpunta.objDataTableUbiSpunta
            End If


            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()

            If (Not (clsSelezioneUbicazioneSpunta.objDataTableUbiSpunta Is Nothing)) Then
                Me.Text = clsAppTranslation.GetSingleParameterValue(190, "", "Selezione Ubicazione") & " - " & clsSelezioneUbicazioneSpunta.objDataTableUbiSpunta.Rows.Count
            End If

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
        Dim RetCode As Long = 0
        Dim WorkDataRow As DataRow

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'DEVO AVERE SELEZIONATO UNA RIGA
            If (Me.DtGridInfo.CurrentRowIndex < 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(445, "", "Attenzione!") & vbCrLf & clsAppTranslation.GetSingleParameterValue(541, "", "Selezionare una riga della griglia.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
            WorkDataRow = clsSelezioneUbicazioneSpunta.objDataTableUbiSpunta.Rows(Me.DtGridInfo.CurrentRowIndex)

            'IMPOSTO I DATI DELL'UBICAZIONE SELEZIONATA
            'clsSelezioneUbicazione.UbicazioneSelezionata.Divisione = WorkDataRow.Item("WERKS")
            clsSelezioneUbicazioneSpunta.UbicazioneSpuntaSelezionata.NumeroMagazzino = WorkDataRow.Item("LGNUM")
            clsSelezioneUbicazioneSpunta.UbicazioneSpuntaSelezionata.TipoMagazzino = WorkDataRow.Item("LGTYP")
            clsSelezioneUbicazioneSpunta.UbicazioneSpuntaSelezionata.Ubicazione = WorkDataRow.Item("LGPLA")
            clsSelezioneUbicazioneSpunta.UbicazioneSpuntaSelezionata.DescUbicazione = WorkDataRow.Item("ZWMSUBI_DESCR")

            RetCode = clsSelezioneUbicazioneSpunta.ConfermaSelezioneUbicazione(Me)

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
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "LGNUM", clsAppTranslation.GetSingleParameterValue(119, "", "Num.Mag."), True, DefDtGridCol_NumeroMagazzino + 40, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "LGTYP", clsAppTranslation.GetSingleParameterValue(206, "", "Tip.Mag."), True, DefDtGridCol_TipoMagazzino + 60, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "LGPLA", clsAppTranslation.GetSingleParameterValue(4, "", "Ubicazione"), True, DefDtGridCol_Ubicazione + 100, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "ZWMSUBI_DESCR", clsAppTranslation.GetSingleParameterValue(1251, "", "Descrizione Ubic."), True, DefDtGridCol_Ubicazione + 200, True)
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

            WorkString = clsAppTranslation.GetSingleParameterValue(752, "", "Si desidera veramente abbandonare la selezione ? (SI/NO)")
            UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                Exit Sub
            End If

            clsSelezioneUbicazioneSpunta.ClearAllData()

            Me.Close()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class