
Imports System.Data
Imports clsSapWS
Imports clsNavigation
Imports clsBusinessLogic
Imports clsDataType

Public Class frmEM_FromJob_Part_ShowStock

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmEM_FromJob_Part_ShowStock"

    Private ErrDescription As String
    Public objDataTableGiacenzeInfo As DataTable

    Public Shared SourceForm As Form


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

    Private Sub cmdNextScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        Dim WorkDataRow As DataRow
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Select Case SourceForm.GetType.Name

                Case frmEM_FromStock_Part_4_ConfirmUbiDest.GetType.Name

                    'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO QUESTA UBICAZIONE COME DESTINAZIONE PROPOSTA 
                    If (Not objDataTableGiacenzeInfo Is Nothing) Then
                        If (objDataTableGiacenzeInfo.Rows.Count > 0) Then
                            'SE HO SELEZIONATO UNA RIGA
                            If (Me.DtGridStockInfo.CurrentRowIndex >= 0) Then
                                'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
                                WorkDataRow = objDataTableGiacenzeInfo.Rows(Me.DtGridStockInfo.CurrentRowIndex)
                                If (Not WorkDataRow Is Nothing) Then
                                    'IMPOSTO I DATI DELLA UBICAZIONE DI DESTINAZIONE SELEZIONATA ALLO STEP PRECEDENTE
                                    'clsWmsJob.WmsJob.UbicazioneDestinazione.NumeroMagazzino = WorkDataRow.Item("LGNUM")
                                    'clsWmsJob.WmsJob.UbicazioneDestinazione.TipoMagazzino = WorkDataRow.Item("LGTYP")
                                    'clsWmsJob.WmsJob.UbicazioneDestinazione.Ubicazione = WorkDataRow.Item("LGPLA")
                                End If
                            End If
                        End If
                    End If

                    'Call clsNavigation.Show_Ope_EntrataMerci_FromStock(Me, clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUM_Generic, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)

                Case frmEM_FromJob_Part_5_FinalUbiConfirm.GetType.Name

                    'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO QUESTA UBICAZIONE COME DESTINAZIONE PROPOSTA 
                    If (Not objDataTableGiacenzeInfo Is Nothing) Then
                        If (objDataTableGiacenzeInfo.Rows.Count > 0) Then
                            'SE HO SELEZIONATO UNA RIGA
                            If (Me.DtGridStockInfo.CurrentRowIndex >= 0) Then
                                'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
                                WorkDataRow = objDataTableGiacenzeInfo.Rows(Me.DtGridStockInfo.CurrentRowIndex)
                                If (Not WorkDataRow Is Nothing) Then
                                    'IMPOSTO I DATI DELLA UBICAZIONE DI DESTINAZIONE SELEZIONATA ALLO STEP PRECEDENTE
                                    'clsWmsJob.WmsJob.UbicazioneDestinazione.NumeroMagazzino = WorkDataRow.Item("LGNUM")
                                    'clsWmsJob.WmsJob.UbicazioneDestinazione.TipoMagazzino = WorkDataRow.Item("LGTYP")
                                    'clsWmsJob.WmsJob.UbicazioneDestinazione.Ubicazione = WorkDataRow.Item("LGPLA")
                                End If
                            End If
                        End If
                    End If

                    'Call clsNavigation.Show_Ope_EntrataMerci_FromJob(Me, clsEMFromJob.EM_SourceType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)

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

    Private Sub frmEM_FromJob_Part_ShowStock_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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

    Private Sub frmEM_FromJob_Part_ShowStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Me.Text = clsAppTranslation.GetSingleParameterValue(78, Me.Text, "TRASF - Mat. (Stock Info)")
            Me.cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(8, cmdNextScreen.Text, "OK")
            Me.cmdSeleziona.Text = clsAppTranslation.GetSingleParameterValue(1582, cmdSeleziona.Text, "Seleziona")
            '**************************************


            'VISUALIZZO DATI MATERIALE
            Me.txtInfoJobSelezionato.Text = clsShowUtility.FromSapWmUbicazioneStructToString(clsEMFromStock.UdMTrasfList(0).UbicazioneInfo) & vbCrLf & clsShowUtility.FromSapWmGiacenzaStrucToString(clsEMFromStock.UdMTrasfList(0))

            If (Not objDataTableGiacenzeInfo Is Nothing) Then
                objDataTableGiacenzeInfo.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridStockInfo.DataSource = objDataTableGiacenzeInfo
            End If


            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()

            If (Not objDataTableGiacenzeInfo Is Nothing) Then
                Me.Text = "EM Mat." & "-" & objDataTableGiacenzeInfo.Rows.Count
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
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "LGTYP", clsAppTranslation.GetSingleParameterValue(304, "", "Tipo"), True, DefDtGridCol_TipoMagazzino, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "LGPLA", clsAppTranslation.GetSingleParameterValue(305, "", "Ubica."), True, DefDtGridCol_Ubicazione, True)
                'POSSO NASCONDERE LA COLONNA
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "MATNR", clsAppTranslation.GetSingleParameterValue(306, "", "Cod.Materiale"), False, DefDtGridCol_CodiceMateriale, True)
                If (DefaultEnablePartita = True) Then
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "CHARG", clsAppTranslation.GetSingleParameterValue(307, "", "Partita"), True, DefDtGridCol_PartitaMateriale, True)
                Else
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "CHARG", clsAppTranslation.GetSingleParameterValue(307, "", "Partita"), False, DefDtGridCol_PartitaMateriale, True)
                End If
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "GESME", clsAppTranslation.GetSingleParameterValue(379, "", "Qta Tot."), True, DefDtGridCol_QtaTotale, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "VERME", clsAppTranslation.GetSingleParameterValue(85, "", "Qta Disp."), True, DefDtGridCol_QtaDisponibile, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "MEINS", clsAppTranslation.GetSingleParameterValue(86, "", "UdM"), True, DefDtGridCol_UnitaDiMisura, True)
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

    Private Sub cmdSeleziona_Click(sender As Object, e As EventArgs) Handles cmdSeleziona.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        Dim WorkDataRow As DataRow
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ''SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNO STOCK DI GIANCENZA 
            'If (Not (clsTrasfMat.objDataTableGiacenzeInfo Is Nothing)) Then
            '    If (clsTrasfMat.objDataTableGiacenzeInfo.Rows.Count > 0) Then
            '        'SE HO SELEZIONATO UNA RIGA
            '        If (Me.DtGridStockInfo.CurrentRowIndex >= 0) Then
            '            'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
            '            WorkDataRow = clsTrasfMat.objDataTableGiacenzeInfo.Rows(Me.DtGridStockInfo.CurrentRowIndex)


            '            'IMPOSTO I DATI DELLA UBICAZIONE DI DESTINAZIONE SELEZIONATA ALLO STEP PRECEDENTE

            '            clsSelezioneUnitaMagazzino.ClearAllData()

            '            'clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.UnitaMagazzino = WorkDataRow.Item("LENUM")
            '            clsWmsJob.WmsJob.UbicazioneDestinazione.NumeroMagazzino = WorkDataRow.Item("LGNUM")
            '            clsWmsJob.WmsJob.UbicazioneDestinazione.TipoMagazzino = WorkDataRow.Item("LGTYP")
            '            clsWmsJob.WmsJob.UbicazioneDestinazione.Ubicazione = WorkDataRow.Item("LGPLA")

            '        End If
            '    End If
            'End If

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO QUESTA UBICAZIONE COME DESTINAZIONE PROPOSTA 
            If (Not objDataTableGiacenzeInfo Is Nothing) Then
                If (objDataTableGiacenzeInfo.Rows.Count > 0) Then
                    'SE HO SELEZIONATO UNA RIGA
                    If (Me.DtGridStockInfo.CurrentRowIndex >= 0) Then
                        'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
                        WorkDataRow = objDataTableGiacenzeInfo.Rows(Me.DtGridStockInfo.CurrentRowIndex)
                        If (Not WorkDataRow Is Nothing) Then

                            'IMPOSTO I DATI DELLA UBICAZIONE DI DESTINAZIONE SELEZIONATA ALLO STEP PRECEDENTE

                            clsSelezioneUnitaMagazzino.ClearAllData()

                            clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.UnitaMagazzino = WorkDataRow.Item("LENUM")
                            clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.NumeroMagazzino = WorkDataRow.Item("LGNUM")
                            clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.TipoMagazzino = WorkDataRow.Item("LGTYP")
                            clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.Ubicazione = WorkDataRow.Item("LGPLA")

                        End If
                    End If
                End If
            End If

            ConfermaSelezioneStock(Me)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Public Shared Function ConfermaSelezioneStock(ByRef inSelectForm As Form) As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim MethodRetval As Object

        Dim MaterialeGiacenze() As clsDataType.SapWmGiacenza
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ConfermaSelezioneStock = 1 'init at error

            If (Not inSelectForm Is Nothing) And (Not SourceForm Is Nothing) Then
#If Not APPLICAZIONE_WIN32 = "SI" Then
									SourceForm.Visible = False
#End If

                RetCode = clsUtility.ExecuteObjectMethod(SourceForm, "ConfermaSelezioneStock", MethodRetval, Nothing)
                'RetCode = clsUtility.ExecuteObjectMethod(SourceForm, "Show", MethodRetval, Nothing)
                inSelectForm.Close()
            End If


            ConfermaSelezioneStock = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ConfermaSelezioneStock = 1000 'IL THREAD E' USCITO DAL LOOP

            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


End Class