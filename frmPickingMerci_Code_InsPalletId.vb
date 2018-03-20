Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility


Public Class frmPickingMerci_Code_InsPalletId

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingMerci_Code_InsPalletId"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String
    Public objDataTableGiacenzeInfo As DataTable

    Private FlagPartialPallet As Boolean = False
    Private FlagWrongPallet As Boolean = False

    Public Shared SourceForm As Form

    Public ErrorSelectQueue As Boolean = False


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


            'PASSO ALLO VIDEATA DELLO STEP PRECEDENTE
            'Call clsNavigation.Show_Ope_InsPalletId(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)
            Me.Close()


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdNextScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim GetDataOk As Boolean = False

        Dim OutEOkLenum As String
        Dim OutESelectPartial As String
        Dim OutEErrorCode As String

        Dim WorkDataRow As DataRow
        Dim InILenumSelected As String

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONVERTO TUTTI I CARATTERI IN MAIUSCOLO 
            Me.txtUM01.Text = Trim(UCase(Me.txtUM01.Text))
            Me.txtUM02.Text = Trim(UCase(Me.txtUM02.Text))
            Me.txtSKU01.Text = Trim(UCase(Me.txtSKU01.Text))
            Me.txtSKU02.Text = Trim(UCase(Me.txtSKU02.Text))


            'VERIFICO SE I DATI ESSENZIALI SONO CORRETTI
            If (Me.txtUM01.Text <> Me.txtUM02.Text) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1818, "", "Specificare stesso PALLET ID.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.txtUM01.Text = ""
                Me.txtUM02.Text = ""
                Me.txtUM01.Focus()
                Exit Sub
            End If


            'VERIFICO SE I DATI ESSENZIALI SONO CORRETTI
            If (Me.txtSKU01.Text <> Me.txtSKU02.Text) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1819, "", "Specificare stesso Codice SKU.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.txtSKU01.Text = ""
                Me.txtSKU02.Text = ""
                Me.txtSKU01.Focus()
                Exit Sub
            End If



            '... INIZIO check dati ...

            'Gestione caso nessun inserimento : Errore!
            If (FlagPartialPallet = False) And (FlagWrongPallet = False) And ((Me.txtUM01.Text = "") Or (Me.txtUM02.Text = "")) And ((Me.txtSKU01.Text = "") Or (Me.txtSKU02.Text = "")) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1818, "", "Specificare stesso PALLET ID.") & " OR " & clsAppTranslation.GetSingleParameterValue(1819, "", "Specificare stesso Codice SKU.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.txtUM01.Focus()
                Exit Sub
            End If


            'Gestione casi di errore selezione
            If (FlagPartialPallet = True) And ((Me.txtUM01.Text <> "") Or (Me.txtUM02.Text <> "")) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1824, "", "Errore Partial Pallet e Pallet Id selezionati contemporaneamente.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.txtUM01.Focus()
                Exit Sub
            End If


            'DEVO AVERE SELEZIONATO UNA RIGA
            If (FlagPartialPallet = True) And (Me.DtGridStockInfo.CurrentRowIndex < 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(445, "", "Attenzione!") & vbCrLf & clsAppTranslation.GetSingleParameterValue(541, "", "Selezionare una riga della griglia.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (FlagPartialPallet = True) Then 'And (ErrorSelectQueue = True) Then
                'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
                WorkDataRow = objDataTableGiacenzeInfo.Rows(Me.DtGridStockInfo.CurrentRowIndex)

                'IMPOSTO I DATI DELLA PALLET ID SELEZIONATA
                InILenumSelected = WorkDataRow.Item("LENUM")
            Else

                'IMPOSTO I DATI DELLA PALLET ID SELEZIONATA
                InILenumSelected = ""

            End If



            'CHECK DATI IMMESSI ZWMS_JOB_PICK_UDC_ISSUE

            If (FlagPartialPallet = True) Or (FlagWrongPallet = True) Then


                If (FlagWrongPallet = True) And ((Me.txtUM01.Text = "") Or (Me.txtUM02.Text = "")) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1818, "", "Specificare stesso PALLET ID.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtUM01.Focus()
                    Exit Sub
                End If


                RetCode = clsSapWS.Call_ZWMS_JOB_PICK_UDC_ISSUE(clsWmsJob.WmsJob.NrWmsJobs, FlagPartialPallet, FlagWrongPallet, clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.TipoMagazzino, clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.Ubicazione, Me.txtUM01.Text, Me.txtSKU01.Text, InILenumSelected, clsUser.SapWmsUser.LANGUAGE, GetDataOk, OutEOkLenum, OutESelectPartial, OutEErrorCode, SapFunctionError, False)

                'GESTIONE DEL CASO DI SCELTA CODA FORZATA
                If (OutESelectPartial = "X") Then
                    ErrorSelectQueue = True
                    'Attenzione!Rilevata piu' di una paletta parziale.Selezionare dalla griglia quella prelevata.
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1822, "", "Attenzione!Rilevata piu' di una paletta parziale.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1823, "", "Selezionare dalla griglia quella prelevata.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                If ((GetDataOk <> True) Or (RetCode <> 0)) Then
                    ErrDescription = "ERROR:" & SapFunctionError.ERROR_CODE & "-" & SapFunctionError.ERROR_DESCRIPTION
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

            End If

            '... FINE check dati ...


            'PASSO ALLO VIDEATA DELLO STEP PRECEDENTE
            If (FlagPartialPallet = True) And (OutEOkLenum <> "") Then
                clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.UnitaMagazzino = OutEOkLenum
            ElseIf (FlagWrongPallet = True) And (OutEOkLenum <> "") Then
                clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.UnitaMagazzino = OutEOkLenum
            Else

                'Se l'operatore non ha dichiarato errore ma ha impostato correttamente Pallet Id
                If (Me.txtUM01.Text <> "") Then
                    clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.UnitaMagazzino = Me.txtUM01.Text
                End If

                'Se l'operatore non ha dichiarato errore ma ha impostato correttamente Sku
                If (Me.txtSKU01.Text <> "") Then
                    clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.UnitaMagazzino = Me.txtSKU01.Text
                End If

            End If

            RetCode = clsSelezioneUnitaMagazzino.ConfermaSelezioneElemento(Me)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmPickingMerci_Code_InsPalletId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            If ((Me.txtUM01.Focused = True) And (Me.txtUM01.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Me.txtUM02.Focus()
                    Exit Sub
                End If
            End If

            If ((Me.txtUM02.Focused = True) And (Me.txtUM02.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdNextScreen_Click(Me, e)
                    Exit Sub
                End If
            End If


            If ((Me.txtSKU01.Focused = True) And (Me.txtSKU01.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Me.txtSKU02.Focus()
                    Exit Sub
                End If
            End If

            If ((Me.txtSKU02.Focused = True) And (Me.txtSKU02.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdNextScreen_Click(Me, e)
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

    Private Sub frmPickingMerci_Code_InsPalletId_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            lblUM01.Text = clsAppTranslation.GetSingleParameterValue(1736, lblUM01.Text, "Pallet ID")

            lblUM02.Text = clsAppTranslation.GetSingleParameterValue(1736, lblUM01.Text, "Pallet ID")


            Me.Text = clsAppTranslation.GetSingleParameterValue(1820, Me.Text, "Select Pallet Id")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")

#If Not APPLICAZIONE_WIN32 = "SI" Then

			cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdNextScreen.Text, ">")
#Else
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, cmdNextScreen.Text, ">")
#End If

            '**************************************   



            If Not (objDataTableGiacenzeInfo Is Nothing) Then
                objDataTableGiacenzeInfo.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridStockInfo.DataSource = objDataTableGiacenzeInfo
            End If


            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()



            If (clsInfoGiacenze.FilterUnitaMagazzino <> "") Then
                'NEL CASO DI BACK VISUALIZZO I DATI CHE ERANO STATI IMPOSTATI
                'IN CASO DI PRIMO LOAD CARICO I DATI DI DEFAULT
                Me.txtUM01.Text = clsInfoGiacenze.FilterUnitaMagazzino
            Else
                '>>> LA PRIMA VOLTA VISUALIZZO I FILTRI DI DEFAULT
                Me.txtUM01.Text = DefaultInfoGiacenze_UnitaMagazzino
            End If

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            'RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            'Aggiorno dati Pallet Id
            SelectedRow()

            Me.txtUM01.Focus()

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
            If (Me.DtGridStockInfo.TableStyles.Count = 0) Then

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "LENUM", clsAppTranslation.GetSingleParameterValue(315, "", "Unità Magazzino"), True, 180, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "LGNUM", clsAppTranslation.GetSingleParameterValue(303, "", "N.Mag."), DefDtGridCol_ShowNumeroMagazzino, 60, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "LGTYP", clsAppTranslation.GetSingleParameterValue(304, "", "Tipo"), True, 70, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "LGPLA", clsAppTranslation.GetSingleParameterValue(305, "", "Ubica."), True, 160, True)
                'POSSO NASCONDERE LA COLONNA
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "MATNR", clsAppTranslation.GetSingleParameterValue(306, "", "Cod.Materiale"), False, 100, True)
                If (DefaultEnablePartita = True) Then
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "CHARG", clsAppTranslation.GetSingleParameterValue(307, "", "Partita"), True, 160, True)
                Else
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "CHARG", clsAppTranslation.GetSingleParameterValue(307, "", "Partita"), False, 160, True)
                End If
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "GESME", clsAppTranslation.GetSingleParameterValue(379, "", "Qta Tot."), True, 90, True)
                'RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "VERME", clsAppTranslation.GetSingleParameterValue(85, "", "Qta Disp."), True, DefDtGridCol_QtaDisponibile, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "MEINS", clsAppTranslation.GetSingleParameterValue(86, "", "UdM"), True, 90, True)

                'RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "SONUM", clsAppTranslation.GetSingleParameterValue(316, "", "Num.Stock spec."), True, DefDtGridCol_UnitaMagazzino, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "BESTQ", clsAppTranslation.GetSingleParameterValue(380, "", "Tipo Stock"), True, 90, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "ZWMS_SKU_PALLET", clsAppTranslation.GetSingleParameterValue(1646, "", "SKU"), True, 190, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "ZZCDLEGACY", clsAppTranslation.GetSingleParameterValue(1647, "", "Cod.Legacy"), True, 240, True)


                objDataTableGiacenzeInfo.DefaultView.AllowNew = False 'DISABILITO POSSIBILITA DI CREARE UNA  NUOVA RIGA
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


    Private Sub txtUM_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUM01.LostFocus
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Me.txtUM01.Text = "") Then Exit Sub

            Me.txtUM01.Text = UCase(Me.txtUM01.Text)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub


    Private Sub btnPartialPallet_Click(sender As Object, e As EventArgs) Handles btnPartialPallet.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'GESTIONE Button e Flag Partial Pallet
            If Me.btnPartialPallet.BackColor = Color.Red Then

                Me.btnPartialPallet.BackColor = Color.Lavender
                FlagPartialPallet = False
                Me.txtUM01.Visible = True
                Me.txtUM02.Visible = True
                Me.txtSKU01.Visible = True
                Me.txtSKU02.Visible = True
                Me.lblUM01.Visible = True
                Me.lblUM02.Visible = True
                Me.lblSKU01.Visible = True
                Me.lblSKU02.Visible = True

                Refresh(False)

            Else

                Me.btnPartialPallet.BackColor = Color.Red
                FlagPartialPallet = True
                Me.txtUM01.Text = ""
                Me.txtUM02.Text = ""
                Me.txtSKU01.Text = ""
                Me.txtSKU02.Text = ""
                Me.txtUM01.Visible = False
                Me.txtUM02.Visible = False
                Me.txtSKU01.Visible = False
                Me.txtSKU02.Visible = False
                Me.lblUM01.Visible = False
                Me.lblUM02.Visible = False
                Me.lblSKU01.Visible = False
                Me.lblSKU02.Visible = False

                Refresh(True)

            End If


            Me.btnWrongPallet.BackColor = Color.Lavender
            FlagWrongPallet = False


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub


    Private Sub btnWrongPallet_Click(sender As Object, e As EventArgs) Handles btnWrongPallet.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'GESTIONE Button e Flag Wrong Pallet
            If Me.btnWrongPallet.BackColor = Color.Red Then
                Me.btnWrongPallet.BackColor = Color.Lavender
                FlagWrongPallet = False
                Me.txtUM01.Visible = True
                Me.txtUM02.Visible = True
                Me.txtSKU01.Visible = True
                Me.txtSKU02.Visible = True
                Me.lblUM01.Visible = True
                Me.lblUM02.Visible = True
                Me.lblSKU01.Visible = True
                Me.lblSKU02.Visible = True
            Else
                Me.btnWrongPallet.BackColor = Color.Red
                FlagWrongPallet = True
                Me.txtUM01.Visible = True
                Me.txtUM02.Visible = True
                Me.txtSKU01.Visible = False
                Me.txtSKU02.Visible = False
                Me.lblUM01.Visible = True
                Me.lblUM02.Visible = True
                Me.lblSKU01.Visible = False
                Me.lblSKU02.Visible = False
            End If

            Me.btnPartialPallet.BackColor = Color.Lavender
            FlagPartialPallet = False

            Refresh(False)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub


    Private Function SelectedRow() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkDataRow As DataRow
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNO STOCK DI GIANCENZA 
            If (Not (objDataTableGiacenzeInfo Is Nothing)) Then
                If (objDataTableGiacenzeInfo.Rows.Count > 0) Then
                    'SE HO SELEZIONATO UNA RIGA
                    If (Me.DtGridStockInfo.CurrentRowIndex >= 0) Then
                        'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
                        WorkDataRow = objDataTableGiacenzeInfo.Rows(Me.DtGridStockInfo.CurrentRowIndex)

                        Me.lblCodiceUM.Text = "PALLET ID :" & WorkDataRow.Item("LENUM") & " - QTY : " & WorkDataRow.Item("GESME") & " " & WorkDataRow.Item("MEINS")

                    End If
                End If
            End If

            SelectedRow = RetCode


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            SelectedRow = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Private Function Refresh(ByVal inIGetOnlyPartialPal As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkStrategyGiacenza As clsDataType.SapWmGiacenza
        Dim WorkUbicazione As clsDataType.SapWmUbicazione
        Dim WorkGiacenza As clsDataType.SapWmGiacenza
        Dim WorkExcludeUbicazioni() As clsDataType.SapWmUbicazione
        Dim GetDataGiacenzeOk As Boolean = False
        Dim GetDataOk As Boolean = False
        Dim WorkDataRow As DataRow
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'RI-VISUALIZZO SOLO GLI STOCK DELLA CODA

            clsSapUtility.ResetUbicazioneStruct(WorkUbicazione) 'init
            clsSapUtility.ResetGiacenzaStruct(WorkGiacenza) 'init
            WorkUbicazione.Divisione = WorkStrategyGiacenza.OdaInputDestInfo.UbicazioneInfo.Divisione
            WorkUbicazione.NumeroMagazzino = WorkStrategyGiacenza.OdaInputDestInfo.UbicazioneInfo.NumeroMagazzino
            WorkUbicazione.TipoMagazzino = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.TipoMagazzino
            WorkUbicazione.Ubicazione = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.Ubicazione

            WorkGiacenza.CodiceMateriale = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.CodiceMateriale
            WorkGiacenza.Partita = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.Partita
            WorkGiacenza.MagazzinoLogico = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.MagazzinoLogico


            'MOSTRO LE GIACENZE DELLO STESSO MATERIALE ESCLUDENDO L'UBICAZIONE DI ORIGINE
            RetCode = clsSapWS.Call_ZWS_MB_GET_LQUA_GIACENZE(WorkUbicazione, WorkGiacenza, False, Val(DefaultEM_List_MaxNumRowReturned), clsUser.SapWmsUser.LANGUAGE, GetDataOk, clsWmsJob.objDataTableGiacenzeOriInfo, Nothing, Nothing, Nothing, Nothing, SapFunctionError, False, , inIGetOnlyPartialPal)
            If ((GetDataOk <> True) Or (RetCode <> 0)) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(474, "", "Nessuna altra giacenza presente con lo stesso MATERIALE/PARTITA.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If


            If Not (objDataTableGiacenzeInfo Is Nothing) Then
                objDataTableGiacenzeInfo.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridStockInfo.DataSource = objDataTableGiacenzeInfo
            End If

            'Imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()

            'Aggiorno dati Pallet Id
            SelectedRow()


            Refresh = RetCode


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Refresh = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Private Sub DtGridStockInfo_CurrentCellChanged(sender As Object, e As EventArgs) Handles DtGridStockInfo.CurrentCellChanged

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim UserSelezioneOk As Boolean = False
        Dim WorkDataRow As DataRow
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'Aggiorno dati Pallet Id
            SelectedRow()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Sub

End Class