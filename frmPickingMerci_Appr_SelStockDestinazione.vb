
Imports System.Data
Imports clsSapWS
Imports clsNavigation
Imports clsBusinessLogic
Imports clsDataType

Public Class frmPickingMerci_Appr_SelStockDestinazione

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingMerci_Appr_SelStockDestinazione"

    Private ErrDescription As String
    Public Shared SourceForm As Form


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmPickingMerci_Appr_SelStockDestinazione_KeyPress(Me, e)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub


    Private Sub frmPickingMerci_Appr_SelStockDestinazione_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.DtGridStockInfo.Focused = True) And (Me.DtGridStockInfo.CurrentRowIndex >= 0)) Then
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

    Private Sub frmPickingMerci_Appr_SelStockDestinazione_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim UserSelezioneOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            hook.Start(Me)
#End If

            '**************************************
            'Traduzioni

            Me.Text = clsAppTranslation.GetSingleParameterValue(179, Me.Text, "Selezione Stock")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(8, cmdNextScreen.Text, "OK")

            '**************************************  

            If Not (clsWmsJob.objDataTableGiacenzeDestInfo Is Nothing) Then
                clsWmsJob.objDataTableGiacenzeDestInfo.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridStockInfo.DataSource = clsWmsJob.objDataTableGiacenzeDestInfo
            End If


            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()

            RetCode = GetSelectedStockInfo(UserSelezioneOk)

            Me.Text = clsAppTranslation.GetSingleParameterValue(750, "", "Picking x Sel.Dest.") & "-" & clsWmsJob.GetRowCountGiacenzeDestInfo(False)

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            Me.DtGridStockInfo.Focus()

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
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "LGNUM", clsAppTranslation.GetSingleParameterValue(303, "", "N.Mag."), DefDtGridCol_ShowNumeroMagazzino, DefDtGridCol_NumeroMagazzino, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "LGTYP", clsAppTranslation.GetSingleParameterValue(304, "", "Tipo"), True, DefDtGridCol_TipoMagazzino, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "LGPLA", clsAppTranslation.GetSingleParameterValue(305, "", "Ubica."), True, DefDtGridCol_Ubicazione, True)
                'POSSO NASCONDERE LA COLONNA
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "MATNR", clsAppTranslation.GetSingleParameterValue(306, "", "Cod.Materiale"), False, DefDtGridCol_CodiceMateriale, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "CHARG", clsAppTranslation.GetSingleParameterValue(307, "", "Partita"), False, DefDtGridCol_PartitaMateriale, True)
                If (DefaultEnableShowQtyInUdmCons = True) Then
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "VRKME", clsAppTranslation.GetSingleParameterValue(309, "", "UdM(Cons)"), False, DefDtGridCol_UnitaDiMisura, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "GESME_CONS", clsAppTranslation.GetSingleParameterValue(310, "", "Q.Tot.(Cons)"), False, DefDtGridCol_QtaTotale, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "VERME_CONS", clsAppTranslation.GetSingleParameterValue(311, "", "Q.Disp.(Cons)"), True, DefDtGridCol_QtaDisponibile + 60, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "MEINS", clsAppTranslation.GetSingleParameterValue(312, "", "UdM(Base)"), False, 0, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "GESME", clsAppTranslation.GetSingleParameterValue(313, "", "Q.Tot.(Base)"), False, 0, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "VERME", clsAppTranslation.GetSingleParameterValue(314, "", "Q.Disp.(Base)"), False, 0, True)
                Else
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "VRKME", clsAppTranslation.GetSingleParameterValue(309, "", "UdM(Cons)"), False, DefDtGridCol_UnitaDiMisura, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "GESME_CONS", clsAppTranslation.GetSingleParameterValue(310, "", "Q.Tot.(Cons)"), False, DefDtGridCol_QtaTotale, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "VERME_CONS", clsAppTranslation.GetSingleParameterValue(311, "", "Q.Disp.(Cons)"), False, DefDtGridCol_QtaDisponibile, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "MEINS", clsAppTranslation.GetSingleParameterValue(312, "", "UdM(Base)"), False, DefDtGridCol_UnitaDiMisura, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "GESME", clsAppTranslation.GetSingleParameterValue(313, "", "Q.Tot.(Base)"), False, DefDtGridCol_QtaTotale, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "VERME", clsAppTranslation.GetSingleParameterValue(314, "", "Q.Disp.(Base)"), True, DefDtGridCol_QtaDisponibile + 60, True)
                End If

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "LENUM", clsAppTranslation.GetSingleParameterValue(315, "", "Unità Magazzino"), False, DefDtGridCol_UnitaMagazzino, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "BESTQ", clsAppTranslation.GetSingleParameterValue(380, "", "Tipo Stock"), False, DefDtGridCol_TipoStock, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "SONUM", clsAppTranslation.GetSingleParameterValue(316, "", "Num.Stock spec."), False, DefDtGridCol_UnitaMagazzino, True)
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
    Public Function GetSelectedStockInfo(ByRef outSelezioneOk As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetSelectedStockInfo = 1 'INIT AT ERROR

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO QUESTA UBICAZIONE COME
            RetCode = clsWmsJob.GetElementDataTableGiacenzeDest(Me.DtGridStockInfo.CurrentRowIndex, outSelezioneOk)
            If (RetCode = 0) And (outSelezioneOk = True) Then
                'VISUALIZZO DATI CORRENTI
                RetCode = RefreshMaterialeInfo()
            End If

            GetSelectedStockInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Function RefreshMaterialeInfo() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RefreshMaterialeInfo = 1 'INIT AT ERROR

            'VISUALIZZO DATI MATERIALE
            Me.txtInfoRowSelected.Text = clsShowUtility.FromSapWmUbicazioneStructToString(clsWmsJob.MaterialeSelStockGiacenzaDest.UbicazioneInfo, 0) & vbCrLf & clsShowUtility.FromSapWmGiacenzaStructToString(clsWmsJob.MaterialeSelStockGiacenzaDest, Nothing, 1)

            RefreshMaterialeInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Private Sub DtGridStockInfo_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtGridStockInfo.CurrentCellChanged
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim UserSelezioneOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO QUESTA UBICAZIONE COME
            RetCode = GetSelectedStockInfo(UserSelezioneOk)

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
        Dim UserSelezioneOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO QUESTA UBICAZIONE COME
            RetCode = GetSelectedStockInfo(UserSelezioneOk)
            If (UserSelezioneOk = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(302, "", "Attenzione, selezione stock non corretta.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            SourceForm.Visible = False
            Select Case SourceForm.GetType.Name
                Case frmPickingMerci_Appr_7_Sel_UbiDestinazione.Name
                    frmPickingMerci_Appr_7_Sel_UbiDestinazioneForm.ConfermaSelezioneLocazione(clsWmsJob.MaterialeSelStockGiacenzaDest.UbicazioneInfo.Ubicazione)
                    frmPickingMerci_Appr_7_Sel_UbiDestinazioneForm.Show()
                Case frmPickingMerci_Appr_7_Ubi_UM_Dest.Name
                    frmPickingMerci_Appr_7_Ubi_UM_DestForm.ConfermaSelezioneLocazione(clsWmsJob.MaterialeSelStockGiacenzaDest.UbicazioneInfo.Ubicazione)
                    frmPickingMerci_Appr_7_Ubi_UM_DestForm.Show()
                Case frmDisaccantonaMerci_5_Sel_UbiDestinazione.Name
                    frmDisaccantonaMerci_5_Sel_UbiDestinazioneForm.ConfermaSelezioneLocazione(clsWmsJob.MaterialeSelStockGiacenzaDest.UbicazioneInfo.Ubicazione)
                    frmDisaccantonaMerci_5_Sel_UbiDestinazioneForm.Show()
                Case frmDisaccantonaMerci_5_Ubi_UM_Dest.Name
                    frmDisaccantonaMerci_5_Ubi_UM_DestForm.ConfermaSelezioneLocazione(clsWmsJob.MaterialeSelStockGiacenzaDest.UbicazioneInfo.Ubicazione)
                    frmDisaccantonaMerci_5_Ubi_UM_DestForm.Show()
                Case Else
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(751, "", "Caso SouceForm Non prevista (Disaccantona. Scelta Destinazione).")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    RetCode = clsNavigation.Show_Mnu_Home(Me, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
            End Select
            Me.Close()


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

            WorkString = clsAppTranslation.GetSingleParameterValue(752, "", "Si desidera veramente abbandonare la selezione ? (SI/NO)")
            UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                Exit Sub
            End If

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