
Imports System.Data
Imports clsSapWS
Imports clsNavigation
Imports clsDataType


Public Class frmSelectUbicazione
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmSelectUbicazione"

    Private ErrDescription As String
    Private Shared SapFunctionError As clsBusinessLogic.SapFunctionError


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
            Me.btnEmptyOnly.Text = clsAppTranslation.GetSingleParameterValue(1746, Me.btnEmptyOnly.Text, "Filtra Vuote")
            '**************************************


            If Not (clsSelezioneUbicazione.objDataTableSelectUbicazione Is Nothing) Then
                clsSelezioneUbicazione.objDataTableSelectUbicazione.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridInfo.DataSource = clsSelezioneUbicazione.objDataTableSelectUbicazione
            End If


            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()

            If (Not (clsSelezioneUbicazione.objDataTableSelectUbicazione Is Nothing)) Then
                Me.Text = clsAppTranslation.GetSingleParameterValue(190, "", "Selezione Ubicazione") & " - " & clsSelezioneUbicazione.objDataTableSelectUbicazione.Rows.Count
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
            WorkDataRow = clsSelezioneUbicazione.objDataTableSelectUbicazione.Rows(Me.DtGridInfo.CurrentRowIndex)

            'IMPOSTO I DATI DELL'UBICAZIONE SELEZIONATA
            'clsSelezioneUbicazione.UbicazioneSelezionata.Divisione = WorkDataRow.Item("WERKS")
            clsSelezioneUbicazione.UbicazioneSelezionata.NumeroMagazzino = WorkDataRow.Item("LGNUM")
            clsSelezioneUbicazione.UbicazioneSelezionata.TipoMagazzino = WorkDataRow.Item("LGTYP")
            clsSelezioneUbicazione.UbicazioneSelezionata.Ubicazione = WorkDataRow.Item("LGPLA")


            RetCode = clsSelezioneUbicazione.ConfermaSelezioneUbicazione(Me)

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

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "KZLER", clsAppTranslation.GetSingleParameterValue(1579, "", "Ubi. vuota"), True, DefDtGridCol_NumeroMagazzino + 60, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "KZVOL", clsAppTranslation.GetSingleParameterValue(1580, "", "Ubi. piena"), True, DefDtGridCol_NumeroMagazzino + 60, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "UBI_PIENA", clsAppTranslation.GetSingleParameterValue(1580, "", "Ubi. piena"), True, DefDtGridCol_NumeroMagazzino + 60, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "LKAPV", clsAppTranslation.GetSingleParameterValue(1581, "", "Cap. Ubi."), True, DefDtGridCol_NumeroMagazzino + 60, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "ZQTA_LGPLA", clsAppTranslation.GetSingleParameterValue(1738, "", "Quantità Ubi."), True, DefDtGridCol_NumeroMagazzino + 120, True)

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

            clsSelezioneUbicazione.ClearAllData()

            Me.Close()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub btnEmptyOnly_Click(sender As Object, e As EventArgs) Handles btnEmptyOnly.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim GetOk As Boolean = False
        Dim WorkUbicazione As clsDataType.SapWmUbicazione
        Dim WorkDataRow As DataRow

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'FILTRO SOLO UBICAZIONI VUOTE

            clsSapUtility.ResetUbicazioneStruct(WorkUbicazione) 'init

            'IMPOSTO I FILTRI PER LA SELEZIONE DI UNA UBICAZIONE TRA QUELLE DISPONIBILI
            WorkUbicazione.NumeroMagazzino = clsSelezioneUbicazione.FilterNumMag


            If (clsUtility.IsStringValid(clsSelezioneUbicazione.FilterTipiMag, True) = True) And (clsSelezioneUbicazione.FilterTipiMag <> "*") Then
                WorkUbicazione.TipoMagazzino = clsSelezioneUbicazione.FilterTipiMag
            Else
                'SELEZIONO TIPO MAGAZZINO DELLA RIGA SELEZIONATA DALL'OPERATORE
                If (Not clsSelezioneUbicazione.objDataTableSelectUbicazione Is Nothing) Then
                    If (Not clsSelezioneUbicazione.objDataTableSelectUbicazione.Rows Is Nothing) Then
                        If (Me.DtGridInfo.CurrentRowIndex >= 0) Then
                            WorkDataRow = clsSelezioneUbicazione.objDataTableSelectUbicazione.Rows(Me.DtGridInfo.CurrentRowIndex)
                            If (Not WorkDataRow Is Nothing) Then
                                WorkUbicazione.TipoMagazzino = clsUtility.GetDataRowItem(WorkDataRow, "LGTYP")
                            End If
                        End If
                    End If
                End If
            End If


            WorkUbicazione.Ubicazione = ""

            'CHIAMO IL WS PER OTTENERE LE UBICAZIONI CON IL FILTRO ATTIVO
            RetCode = clsSapWS.Call_ZWS_MB_GET_UBICAZIONI_INFO(WorkUbicazione, "E", True, clsUser.SapWmsUser.LANGUAGE, GetOk, clsSelezioneUbicazione.objDataTableSelectUbicazione, Val(DefaultEM_List_MaxNumRowReturned), SapFunctionError, False)
            If ((GetOk <> True) Or (RetCode <> 0)) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1155, "", "Nessuna UBICAZIONE trovata.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(568, "", "Verificare i dati immessi e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            If Not (clsSelezioneUbicazione.objDataTableSelectUbicazione Is Nothing) Then
                clsSelezioneUbicazione.objDataTableSelectUbicazione.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridInfo.DataSource = clsSelezioneUbicazione.objDataTableSelectUbicazione
            End If


            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub


End Class