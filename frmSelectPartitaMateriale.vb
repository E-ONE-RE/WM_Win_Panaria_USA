
Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports System.Data

Public Class frmSelectPartitaMateriale
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmSelectPartitaMateriale"

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

    Private Sub frmSelectPartitaMateriale_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            Me.Text = clsAppTranslation.GetSingleParameterValue(188, Me.Text, "Selezione Partita Materiale")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            btnOK.Text = clsAppTranslation.GetSingleParameterValue(8, btnOK.Text, "OK")

            '************************************** 


            If (clsSelezionePartitaMateriale.SelezionePartitaMaterialeType = clsDataType.SelezionePartitaMaterialeType.SelezionePartitaMaterialeTypeGeneric) Then
                If Not (clsSelezionePartitaMateriale.objDataTableSelectPartite Is Nothing) Then
                    clsSelezionePartitaMateriale.objDataTableSelectPartite.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                    Me.DtGridInfo.DataSource = clsSelezionePartitaMateriale.objDataTableSelectPartite
                End If
            Else
                If Not (clsSelezionePartitaMateriale.objDataTableSelectPartiteGiacenze Is Nothing) Then
                    clsSelezionePartitaMateriale.objDataTableSelectPartiteGiacenze.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                    Me.DtGridInfo.DataSource = clsSelezionePartitaMateriale.objDataTableSelectPartiteGiacenze
                End If
            End If


                'imposto la formattazione delle colonne
                RetCode += SetDataGridColumnStyles()

                If (Not (clsSelezionePartitaMateriale.objDataTableSelectPartite Is Nothing)) Then
                    Me.Text = "Selezione Partita" & " - " & clsSelezionePartitaMateriale.objDataTableSelectPartite.Rows.Count
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
            If (clsSelezionePartitaMateriale.SelezionePartitaMaterialeType = clsDataType.SelezionePartitaMaterialeType.SelezionePartitaMaterialeTypeGeneric) Then
                WorkDataRow = clsSelezionePartitaMateriale.objDataTableSelectPartite.Rows(Me.DtGridInfo.CurrentRowIndex)
            Else
                WorkDataRow = clsSelezionePartitaMateriale.objDataTableSelectPartiteGiacenze.Rows(Me.DtGridInfo.CurrentRowIndex)
            End If


            If (WorkDataRow Is Nothing) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(445, "", "Attenzione!") & vbCrLf & "Oggetto selezionato non valido (Nothing)."
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'IMPOSTO I DATI DELL'UBICAZIONE SELEZIONATA
            clsSelezionePartitaMateriale.CodicePartitaSelezionato = WorkDataRow.Item("CHARG")

            RetCode = clsSelezionePartitaMateriale.ConfermaSelezione(Me)

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
                If (clsSelezionePartitaMateriale.SelezionePartitaMaterialeType = clsDataType.SelezionePartitaMaterialeType.SelezionePartitaMaterialeTypeForUbicazione) Then
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "LGNUM", clsAppTranslation.GetSingleParameterValue(569, "", "Num."), True, DefDtGridCol_NumeroMagazzino, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "LGTYP", clsAppTranslation.GetSingleParameterValue(304, "", "Tipo"), True, DefDtGridCol_TipoMagazzino, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "LGPLA", clsAppTranslation.GetSingleParameterValue(4, "", "Ubicazione"), True, DefDtGridCol_Ubicazione, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "MATNR", clsAppTranslation.GetSingleParameterValue(306, "", "Cod.Materiale"), True, DefDtGridCol_CodiceMateriale, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "CHARG", clsAppTranslation.GetSingleParameterValue(307, "", "Partita"), True, DefDtGridCol_PartitaMateriale, True)

                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "MEINS", clsAppTranslation.GetSingleParameterValue(86, "", "UdM"), True, DefDtGridCol_UnitaDiMisura, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "GESME", clsAppTranslation.GetSingleParameterValue(781, "", "Qta Totale"), True, DefDtGridCol_QtaTotale, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "VERME", clsAppTranslation.GetSingleParameterValue(782, "", "Qta Disponibile"), True, DefDtGridCol_QtaDisponibile, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "LENUM", clsAppTranslation.GetSingleParameterValue(315, "", "Unità Magazzino"), True, DefDtGridCol_UnitaMagazzino, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "SOBKZ", clsAppTranslation.GetSingleParameterValue(783, "", "Stock Spec."), True, DefDtGridCol_CdStockSpeciale, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "SONUM", clsAppTranslation.GetSingleParameterValue(784, "", "N.Stock Sp."), True, DefDtGridCol_NumeroStockSpeciale, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "BESTQ", clsAppTranslation.GetSingleParameterValue(380, "", "Tipo Stock"), True, DefDtGridCol_TipoStock, True)
                Else
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "WERKS", clsAppTranslation.GetSingleParameterValue(6, "", "Divisione"), False, DefDtGridCol_Divisione, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "MATNR", clsAppTranslation.GetSingleParameterValue(306, "", "Cod.Materiale"), True, DefDtGridCol_CodiceMateriale + 20, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "CHARG", clsAppTranslation.GetSingleParameterValue(82, "", "Partita Materiale"), True, 200, True)
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