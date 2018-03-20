Imports clsSapWS
Imports clsSapUtility
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic


Public Class frmEM_FromStock_Part_4_TrasfConfirmMov
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmEM_FromStock_Part_4_TrasfConfirmMov"

    Private ErrDescription As String
    Private SapFunctionError As clsBusinessLogic.SapFunctionError

    Private UdMTrasfListIndex As Integer = 0


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))


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

            RetCode = clsNavigation.Show_Mnu_Main_EntrataMerci(Me, True)

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
            Call clsNavigation.Show_Ope_EntrataMerci_FromStock(Me, clsEMFromStock.EM_StockSourceType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmEM_FromStock_Part_4_ConfirmUbiDest_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


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

    Private Sub frmEM_FromStock_Part_4_ConfirmUbiDest_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            'hook.Start(Me)
#End If

            '**************************************
            'Traduzioni

            Me.Text = clsAppTranslation.GetSingleParameterValue(233, Me.Text, "EM - Prod. da Trasf. (2)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(8, cmdNextScreen.Text, "OK")


#If Not APPLICAZIONE_WIN32 = "SI" Then
		    cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
#Else
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
#End If

            '**************************************

            'NEL CASO DI "BACK" DEVO RIVISUALIZZARE LE UM CHE ERANO STATO IMMESSE
            Call RefreshDatiMaterialeAttivo()


            '*********************************************************************************************************

            'If (Not clsEMFromStock.UdMTrasfList Is Nothing) Then
            '    'AGGIORNO IL NUMERO DI UDC LETTE
            '    Me.lblInfoUDC.Text = "N° UDC/S: " & clsEMFromStock.UdMTrasfList.GetLength(0)
            'End If

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

    Private Sub cmdNextScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextScreen.Click

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim RetCodeFinal As Long = 0
        Dim OT_Executed_Ok As Boolean = False



        Dim OT_Executed_Number() As String
        Dim Doc_Mat_INFO() As String
        Dim OT_Info As New StrctSapMoveSuParams
        Dim UserAnswer As DialogResult
        Dim Out_JobsGroup As String
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'INIZIALIZZO VARIABILE ESITO
            ErrDescription = ""


            RetCode = clsSapWS.Call_ZWMS_EXEC_ENT_MERCE_PROD_TRASF(clsEMFromStock.UdMTrasfList, clsUser.SapWmsUser.LGNUM, clsUser.SapWmsUser.USERID, clsUser.SapWmsUser.USERID, clsUser.SapWmsUser.LANGUAGE, OT_Executed_Ok, SapFunctionError, OT_Executed_Number, Doc_Mat_INFO, clsEMFromStock.UdMTrasfList, Out_JobsGroup, False)

            If (RetCode <> 0) Then

                ErrDescription += clsAppTranslation.GetSingleParameterValue(1224, "", "Errore nel trasferimento Materiale")

            Else
                '>>> TUTTO OK
                ErrDescription += clsAppTranslation.GetSingleParameterValue(1225, "", "Trasferimento Materiale ") & " " & clsAppTranslation.GetSingleParameterValue(1226, "", " eseguito con successo.") & vbCrLf
                Dim MaxArrayIndex As Long
                Dim IndexFor As Long

                ErrDescription += clsAppTranslation.GetSingleParameterValue(1243, "", " JOBS GROUP:") & Out_JobsGroup & vbCrLf

                If Not (OT_Executed_Number Is Nothing) Then
                    MaxArrayIndex = UBound(OT_Executed_Number)
                    For IndexFor = 0 To MaxArrayIndex
                        ErrDescription += clsAppTranslation.GetSingleParameterValue(1247, "", " OT:") & OT_Executed_Number(IndexFor) & vbCrLf
                    Next
                End If

                If Not (Doc_Mat_INFO Is Nothing) Then
                    MaxArrayIndex = UBound(Doc_Mat_INFO)
                    For IndexFor = 0 To MaxArrayIndex
                        ErrDescription += clsAppTranslation.GetSingleParameterValue(1227, "", " DOC MAT. INFO:") & Doc_Mat_INFO(IndexFor) & vbCrLf
                    Next
                End If

                End If

                'AGGIORNO CONTATORE Errori
                RetCodeFinal += RetCode


                '************************************************************************************************
                ' >>> SE ABILITATO VISUALIZZO RISULTATO OPERAZIONE
                '************************************************************************************************
            If (EntrataMerceAbilitaMsgConfermaSuccesso = True) Or (RetCodeFinal <> 0) Then
                'If (RetCodeFinal = 0) Then
                'VISUALIZZO FINESTRA PER MESSAGGI OPERATORE
                frmMessageForUserForm = New frmMessageForUser
                frmMessageForUserForm.SourceForm = Me 'setto riferimento a FORM per ricaricarla prima di chiudere la finestra del messaggio.
                frmMessageForUserForm.ShowMessage(ErrDescription)
            End If

            '************************************************************************************************
            '>>> SE HO AVUTO UN ERRORE VISUALIZZO UNA MESSAGE BOX PER RICHIEDERE SE RIPROVARE
            '************************************************************************************************
            If (RetCodeFinal <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(394, "", "Si è verificato un errore.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(395, "", "Si desidera abbandonare ? (Si / No )")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then

                    '>>> DEVO RIPORTARE IL FOCUS SULLA FINESTRA, MA OCCORRE RICARICARLA

                    System.Windows.Forms.Application.DoEvents()

                    Me.Close()
                    System.Windows.Forms.Application.DoEvents()

                    If Not (clsEMFromStock.EM_StockSourceType = clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUM_MovTransfUnLoad) Then
                        frmEM_FromStock_Part_1_Trasf_SelUbiSpuntaForm = New frmEM_FromStock_Part_1_Trasf_SelUbiSpunta
                        frmEM_FromStock_Part_1_Trasf_SelUbiSpuntaForm.Show()
                        frmEM_FromStock_Part_1_Trasf_SelUbiSpuntaForm.cmdNextScreen.Focus()
                    Else
                        frmEM_FromStock_Part_4_TrasfConfirmMovForm = New frmEM_FromStock_Part_4_TrasfConfirmMov
                        frmEM_FromStock_Part_4_TrasfConfirmMovForm.Show()
                        frmEM_FromStock_Part_4_TrasfConfirmMovForm.cmdNextScreen.Focus()
                    End If

                    Exit Sub

                End If

            End If


            'PER VELOCIZZARE ATTIVITA OPERATORE PASSO DIRETTAMENTE ALLA VIDEATA INIZIALE DELLA SEQUENZA OPERATIVA
            'PARTO NUOVAMENTE DALLO STEP CHE CHIEDE LA UM DA TRASFERIRE
            Call clsNavigation.Show_Ope_EntrataMerci_FromStock(Me, clsEMFromStock.EM_StockSourceType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartSeq, True)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Sub

    Private Sub txtUMDestConfermata_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'If Me.txtUMDestConfermata.Text <> "" Then
            '    Me.txtUMDestConfermata.Text = UCase(Me.txtUMDestConfermata.Text)
            'End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Function RefreshDatiMaterialeAttivo() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RefreshDatiMaterialeAttivo = 1 'INIT AT ERROR

            Me.txtInfoUMSelezionata.Text = ""

            If (clsEMFromStock.UdMTrasfList Is Nothing) Then
                RefreshDatiMaterialeAttivo = 0
                Me.txtInfoUMSelezionata.Text = ""
                Exit Function
            End If
            If (clsEMFromStock.UdMTrasfList.GetLength(0) = 0) Then
                RefreshDatiMaterialeAttivo = 0
                Me.txtInfoUMSelezionata.Text = ""
                Exit Function
            End If

            'AGGIORNO LA LISTA CON LE INFORMAZIONI DELLE PALETTE LETTE DALL'OPERATORE
            Me.txtInfoUMSelezionata.Text = clsEMFromStock.ShowJobPutAwayInfoForUserString(2)

            If (Not clsEMFromStock.UdMTrasfList Is Nothing) Then
                'AGGIORNO IL NUMERO DI UDC LETTE
                Me.lblInfoUDC.Text = clsAppTranslation.GetSingleParameterValue(1241, "", "N° UDC/S: ") & clsEMFromStock.UdMTrasfList.GetLength(0) & vbCrLf & _
                                     clsAppTranslation.GetSingleParameterValue(1242, "", "MISSIONE: ") & clsEMFromStock.UdMTrasfList(0).NrWmsJobs & "  " & _
                                     clsAppTranslation.GetSingleParameterValue(1243, "", "JOBS GROUP: ") & clsEMFromStock.UdMTrasfList(0).CodiceGruppoMissioni & vbCrLf & _
                                     clsAppTranslation.GetSingleParameterValue(1244, "", "NR. TRUCK: ") & clsEMFromStock.UdMTrasfList(0).TruckDayNr & "  " & _
                                     clsAppTranslation.GetSingleParameterValue(1245, "", "NR TOT PALLET: ") & clsEMFromStock.UdMTrasfList(0).TrasfNumPallet & "  " & _
                                     clsAppTranslation.GetSingleParameterValue(1248, "", "NR PALLET RIMANENTI: ") & clsEMFromStock.UdMTrasfList(0).TrasfNumPallet - clsEMFromStock.UdMTrasfList.GetUpperBound(0) - 1
            End If

            RefreshDatiMaterialeAttivo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

End Class
