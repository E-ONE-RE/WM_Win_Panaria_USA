
Imports System.Data
Imports clsSapWS
Imports clsNavigation
Imports clsBusinessLogic
Imports clsDataType
Imports clsSapUtility

Public Class frmTRASF_MAT_Part_3_SelStock

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmTRASF_MAT_Part_3_SelStock"

    Private ErrDescription As String


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
        Dim RetCode As Long
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

            RetCode = clsNavigation.Show_Mnu_Main_Trasfer(Me, True)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdPreviousScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreviousScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'PASSO ALLO VIDEATA DELLO STEP PRECEDENTE
            Call clsNavigation.Show_Ope_TRASF_MAT(Me, clsTrasfMat.FunctionTransferMaterialType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

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

            'SE L'OPERATORE E' UNO USER NORMALE GLI IMPEDISCO DI SPOSTARE LE PALLETTE DALLA ZONA DI PRONTO
            If (clsUser.SapWmsUser.PROFID = "") And (clsTrasfMat.MaterialeGiacenza.UbicazioneInfo.TipoMagazzino = clsSapUtility.cstSapTipoMagPronto) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(787, "", "Il materiale non puo' essere trasferito dal TIP.MAG:Pronto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'IMPOSTO I DATI DELLA GIACENZA SELEZIONATA
            clsTrasfMat.SourceUbicazione = clsTrasfMat.MaterialeGiacenza.UbicazioneInfo

            'IMPOSTO QTA CONFERMATA DELL'OPERATORE = A QUELLA DISPONIBILE
            clsTrasfMat.MaterialeGiacenza.QuantitaConfermataOperatore = clsTrasfMat.MaterialeGiacenza.QtaTotaleLquaDispoUdMAcq

            If (clsTrasfMat.MaterialeGiacenza.QuantitaConfermataOperatore > clsTrasfMat.MaterialeGiacenza.QtaTotaleLquaDispoUdMAcq) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(382, "", "Attenzione, il traferimento è  limitato alla sola QTA disponibile.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                clsTrasfMat.MaterialeGiacenza.QuantitaConfermataOperatore = clsTrasfMat.MaterialeGiacenza.QtaTotaleLquaDisponibile
            End If

            'IN BASE AL CONTESTO PROSEGUO NEL WIZARD CORRISPONDENTE
            Call clsNavigation.Show_Ope_TRASF_MAT(Me, clsTrasfMat.FunctionTransferMaterialType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmTRASF_MAT_Part_3_SelStock_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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

            If ((Me.cmdNextScreen.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
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

    Private Sub frmTRASF_MAT_Part_3_SelStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            Me.Text = clsAppTranslation.GetSingleParameterValue(193, Me.Text, "TRASF - Mat. (3)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
			cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdNextScreen.Text, ">")
#Else
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, cmdNextScreen.Text, ">")
#End If

            '**************************************    


            If Not (clsTrasfMat.objDataTableGiacenzeInfo Is Nothing) Then
                clsTrasfMat.objDataTableGiacenzeInfo.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridStockInfo.DataSource = clsTrasfMat.objDataTableGiacenzeInfo
            End If


            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()

            RetCode = GetSelectedStockInfo(UserSelezioneOk)
            'VISUALIZZO DATI CORRENTI
            RetCode = RefreshMaterialeInfo()

            Me.Text = clsAppTranslation.GetSingleParameterValue(794, "", "TRASF-Mat.(3)")
            If (Not (clsTrasfMat.objDataTableGiacenzeInfo Is Nothing)) Then
                Me.Text = Me.Text & "-" & clsTrasfMat.objDataTableGiacenzeInfo.Rows.Count
            End If

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
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "LGTYP", clsAppTranslation.GetSingleParameterValue(304, "", "Tipo"), True, DefDtGridCol_TipoMagazzino + 20, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "LGPLA", clsAppTranslation.GetSingleParameterValue(305, "", "Ubica."), True, DefDtGridCol_Ubicazione, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "MATNR", clsAppTranslation.GetSingleParameterValue(306, "", "Cod.Materiale"), True, DefDtGridCol_CodiceMateriale + 20, True)
                If (DefaultEnablePartita = True) Then
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "CHARG", clsAppTranslation.GetSingleParameterValue(307, "", "Partita"), True, DefDtGridCol_PartitaMateriale + 20, True)
                Else
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "CHARG", clsAppTranslation.GetSingleParameterValue(307, "", "Partita"), False, DefDtGridCol_PartitaMateriale + 20, True)
                End If

                If (DefaultEnableShowQtyInUdmCons = True) Then
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "VRKME", clsAppTranslation.GetSingleParameterValue(309, "", "UdM(Cons)"), True, DefDtGridCol_UnitaDiMisura, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "GESME_CONS", clsAppTranslation.GetSingleParameterValue(310, "", "Q.Tot.(Cons)"), True, DefDtGridCol_QtaTotale, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "VERME_CONS", clsAppTranslation.GetSingleParameterValue(311, "", "Q.Disp.(Cons)"), True, DefDtGridCol_QtaDisponibile, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "MEINS", clsAppTranslation.GetSingleParameterValue(312, "", "UdM(Base)"), False, 0, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "GESME", clsAppTranslation.GetSingleParameterValue(313, "", "Q.Tot.(Base)"), False, 0, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "VERME", clsAppTranslation.GetSingleParameterValue(314, "", "Q.Disp.(Base)"), False, 0, True)
                Else
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "VRKME", clsAppTranslation.GetSingleParameterValue(309, "", "UdM(Cons)"), False, DefDtGridCol_UnitaDiMisura, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "GESME_CONS", clsAppTranslation.GetSingleParameterValue(310, "", "Q.Tot.(Cons)"), False, DefDtGridCol_QtaTotale, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "VERME_CONS", clsAppTranslation.GetSingleParameterValue(311, "", "Q.Disp.(Cons)"), False, DefDtGridCol_QtaDisponibile, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "MEINS", clsAppTranslation.GetSingleParameterValue(312, "", "UdM(Base)"), True, DefDtGridCol_UnitaDiMisura, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "GESME", clsAppTranslation.GetSingleParameterValue(313, "", "Q.Tot.(Base)"), True, DefDtGridCol_QtaTotale, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "VERME", clsAppTranslation.GetSingleParameterValue(314, "", "Q.Disp.(Base)"), True, DefDtGridCol_QtaDisponibile, True)
                End If
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "LENUM", clsAppTranslation.GetSingleParameterValue(315, "", "Unità Magazzino"), True, DefDtGridCol_UnitaMagazzino, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "SONUM", clsAppTranslation.GetSingleParameterValue(316, "", "Num.Stock spec."), True, DefDtGridCol_UnitaMagazzino, True)
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
        Dim WorkDataRow As DataRow
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetSelectedStockInfo = 1 'INIT AT ERROR

            outSelezioneOk = False 'init

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO QUESTA UBICAZIONE COME
            If (Not (clsTrasfMat.objDataTableGiacenzeInfo Is Nothing)) Then
                If (clsTrasfMat.objDataTableGiacenzeInfo.Rows.Count > 0) Then
                    'SE HO SELEZIONATO UNA RIGA
                    If Me.DtGridStockInfo.CurrentRowIndex >= 0 Then
                        'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
                        WorkDataRow = clsTrasfMat.objDataTableGiacenzeInfo.Rows(Me.DtGridStockInfo.CurrentRowIndex)
                        If (Not (WorkDataRow Is Nothing)) Then
                            'SETTO I DATI DELLA GIACENZA SELEZIONATA
                            RetCode = clsSapUtility.FromGiacenzaDataRowToSapWmGiacenza(WorkDataRow, clsTrasfMat.MaterialeGiacenza, False)
                            If (RetCode = 0) Then
                                outSelezioneOk = True 'UNICO CASO DI SELEZIONE OK
                                'VISUALIZZO DATI CORRENTI
                                RetCode = RefreshMaterialeInfo()
                            End If
                        End If
                    End If
                End If
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
            Me.txtInfoJobSelezionato.Text = clsTrasfMat.FromTrasfMatStrucToString(0)

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
End Class