
Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports System.Data

Public Class frmSelectCodiceMateriale
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmSelectCodiceMateriale"

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

    Private Sub frmSelectCodiceMateriale_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            Me.Text = clsAppTranslation.GetSingleParameterValue(187, Me.Text, "Selezione Cod.Mat.")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            btnOK.Text = clsAppTranslation.GetSingleParameterValue(8, btnOK.Text, "OK")

            '************************************** 


            If (clsSelezioneCodiceMateriale.SelezioneCodiceMaterialeType = clsDataType.SelezioneCodiceMaterialeType.SelezioneCodiceMaterialeTypeForUbicazione) Then
                If Not (clsSelezioneCodiceMateriale.objDataTableSelectCodMatGiacenza Is Nothing) Then
                    clsSelezioneCodiceMateriale.objDataTableSelectCodMatGiacenza.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                    Me.DtGridInfo.DataSource = clsSelezioneCodiceMateriale.objDataTableSelectCodMatGiacenza
                End If
            Else
                If Not (clsSelezioneCodiceMateriale.objDataTableSelectCodMateriale Is Nothing) Then
                    clsSelezioneCodiceMateriale.objDataTableSelectCodMateriale.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                    Me.DtGridInfo.DataSource = clsSelezioneCodiceMateriale.objDataTableSelectCodMateriale
                End If
            End If


                'imposto la formattazione delle colonne
                RetCode += SetDataGridColumnStyles()

                If (Not (clsSelezioneCodiceMateriale.objDataTableSelectCodMateriale Is Nothing)) Then
                    If (clsSelezioneCodiceMateriale.SelezioneCodiceMaterialeType = clsDataType.SelezioneCodiceMaterialeType.SelezioneCodiceMaterialeTypeForUbicazione) Then
                        Me.Text = clsAppTranslation.GetSingleParameterValue(187, "", "Selezione Cod.Mat.") & " - " & clsSelezioneCodiceMateriale.objDataTableSelectCodMatGiacenza.Rows.Count
                    Else
                        Me.Text = clsAppTranslation.GetSingleParameterValue(187, "", "Selezione Cod.Mat.") & " - " & clsSelezioneCodiceMateriale.objDataTableSelectCodMateriale.Rows.Count
                    End If
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
            If Me.DtGridInfo.CurrentRowIndex < 0 Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(445, "", "Attenzione!") & vbCrLf & clsAppTranslation.GetSingleParameterValue(541, "", "Selezionare una riga della griglia.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
            If (clsSelezioneCodiceMateriale.SelezioneCodiceMaterialeType = clsDataType.SelezioneCodiceMaterialeType.SelezioneCodiceMaterialeTypeForUbicazione) Then
                WorkDataRow = clsSelezioneCodiceMateriale.objDataTableSelectCodMatGiacenza.Rows(Me.DtGridInfo.CurrentRowIndex)
            Else
                WorkDataRow = clsSelezioneCodiceMateriale.objDataTableSelectCodMateriale.Rows(Me.DtGridInfo.CurrentRowIndex)
            End If


            If (WorkDataRow Is Nothing) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(445, "", "Attenzione!") & vbCrLf & "Oggetto selezionato non valido (Nothing)."
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'IMPOSTO I DATI DELL'UBICAZIONE SELEZIONATA
            clsSelezioneCodiceMateriale.CodiceMaterialeSelezionato = WorkDataRow.Item("MATNR")
            If (clsSelezioneCodiceMateriale.SelezioneCodiceMaterialeType = clsDataType.SelezioneCodiceMaterialeType.SelezioneCodiceMaterialeTypeForUbicazione) Then
                clsSelezioneCodiceMateriale.GiacenzaSelezionata.CodiceMateriale = WorkDataRow.Item("MATNR")
                clsSelezioneCodiceMateriale.GiacenzaSelezionata.DescrizioneMateriale = ""
                clsSelezioneCodiceMateriale.GiacenzaSelezionata.Partita = WorkDataRow.Item("CHARG")
                clsSelezioneCodiceMateriale.GiacenzaSelezionata.QtaTotaleLquaDisponibile = WorkDataRow.Item("VERME")
                clsSelezioneCodiceMateriale.GiacenzaSelezionata.QtaTotaleLquaInStock = WorkDataRow.Item("GESME")
                clsSelezioneCodiceMateriale.GiacenzaSelezionata.TipoStock = WorkDataRow.Item("BESTQ")
                clsSelezioneCodiceMateriale.GiacenzaSelezionata.CdStockSpeciale = WorkDataRow.Item("SOBKZ")
                clsSelezioneCodiceMateriale.GiacenzaSelezionata.NumeroStockSpeciale = WorkDataRow.Item("SONUM")

                clsSelezioneCodiceMateriale.UbicazioneSelezionata.Divisione = WorkDataRow.Item("WERKS")
                clsSelezioneCodiceMateriale.UbicazioneSelezionata.NumeroMagazzino = WorkDataRow.Item("LGNUM")
                clsSelezioneCodiceMateriale.UbicazioneSelezionata.TipoMagazzino = WorkDataRow.Item("LGTYP")
                clsSelezioneCodiceMateriale.UbicazioneSelezionata.Ubicazione = WorkDataRow.Item("LGPLA")
                clsSelezioneCodiceMateriale.UbicazioneSelezionata.UnitaMagazzino = WorkDataRow.Item("LENUM")

                clsSelezioneCodiceMateriale.GiacenzaSelezionata.UbicazioneInfo = clsSelezioneCodiceMateriale.UbicazioneSelezionata
            End If

            RetCode = clsSelezioneCodiceMateriale.ConfermaSelezione(Me)

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
                If (clsSelezioneCodiceMateriale.SelezioneCodiceMaterialeType = clsDataType.SelezioneCodiceMaterialeType.SelezioneCodiceMaterialeTypeForUbicazione) Then
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "LGNUM", clsAppTranslation.GetSingleParameterValue(569, "", "Num."), True, DefDtGridCol_NumeroMagazzino, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "LGTYP", clsAppTranslation.GetSingleParameterValue(304, "", "Tipo"), True, DefDtGridCol_TipoMagazzino, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "LGPLA", clsAppTranslation.GetSingleParameterValue(4, "", "Ubicazione"), True, DefDtGridCol_Ubicazione, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "MATNR", clsAppTranslation.GetSingleParameterValue(306, "", "Cod.Materiale"), True, DefDtGridCol_CodiceMateriale, True)
                    If (DefaultEnablePartita = True) Then
                        RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "CHARG", clsAppTranslation.GetSingleParameterValue(307, "", "Partita"), True, DefDtGridCol_PartitaMateriale, True)
                    Else
                        RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "CHARG", clsAppTranslation.GetSingleParameterValue(307, "", "Partita"), False, DefDtGridCol_PartitaMateriale, True)
                    End If
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "MEINS", clsAppTranslation.GetSingleParameterValue(86, "", "UdM"), True, DefDtGridCol_UnitaDiMisura, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "GESME", clsAppTranslation.GetSingleParameterValue(781, "", "Qta Totale"), True, DefDtGridCol_QtaTotale, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "VERME", clsAppTranslation.GetSingleParameterValue(782, "", "Qta Disponibile"), True, DefDtGridCol_QtaDisponibile, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "LENUM", clsAppTranslation.GetSingleParameterValue(315, "", "Unità Magazzino"), True, DefDtGridCol_UnitaMagazzino, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "SOBKZ", clsAppTranslation.GetSingleParameterValue(783, "", "Stock Spec."), True, DefDtGridCol_CdStockSpeciale, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "SONUM", clsAppTranslation.GetSingleParameterValue(784, "", "N.Stock Sp."), True, DefDtGridCol_NumeroStockSpeciale, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "BESTQ", clsAppTranslation.GetSingleParameterValue(380, "", "Tipo Stock"), True, DefDtGridCol_TipoStock, True)
                Else
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "Werks", clsAppTranslation.GetSingleParameterValue(6, "", "Divisione"), False, DefDtGridCol_Divisione, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "MATNR", clsAppTranslation.GetSingleParameterValue(306, "", "Cod.Materiale"), True, DefDtGridCol_CodiceMateriale, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "MAKTG", clsAppTranslation.GetSingleParameterValue(534, "", "Descr.Materiale"), True, 120, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "MTART", clsAppTranslation.GetSingleParameterValue(535, "", "Tipo Materiale"), True, 90, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "MATKL", clsAppTranslation.GetSingleParameterValue(536, "", "Gruppo Merci"), True, 80, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "MEINS", clsAppTranslation.GetSingleParameterValue(86, "", "UdM"), True, DefDtGridCol_UnitaDiMisura, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "GEWEI", clsAppTranslation.GetSingleParameterValue(537, "", "U.Peso"), True, 46, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "EKGRP", clsAppTranslation.GetSingleParameterValue(538, "", "Gruppo Acquisti"), True, 80, True)
                End If
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