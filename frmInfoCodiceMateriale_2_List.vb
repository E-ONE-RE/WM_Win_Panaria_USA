Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility


Public Class frmInfoCodiceMateriale_2_List

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmInfoCodiceMateriale_2_List"


    Private ErrDescription As String


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmInfoCodiceMateriale_2_List_KeyPress(Me, e)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmInfoCodiceMateriale_2_List_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'If ((Me.txtNumMag.Focused = True) And (Me.txtNumMag.Text <> "")) Then
            '    If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then

            '    End If
            'End If

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
            Call clsNavigation.Show_Info_Anagrafica_Materiale(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub btnHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHome.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Call clsNavigation.Show_Mnu_Main_Informazioni(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNone, True)

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
            If (Me.DtGridShowInfo.TableStyles.Count = 0) Then
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "Werks", clsAppTranslation.GetSingleParameterValue(6, "", "Divisione"), False, DefDtGridCol_Divisione, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "MATNR", clsAppTranslation.GetSingleParameterValue(306, "", "Cod.Materiale"), True, DefDtGridCol_CodiceMateriale + 100, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "MAKTG", clsAppTranslation.GetSingleParameterValue(534, "", "Descr.Materiale"), True, 220, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "MTART", clsAppTranslation.GetSingleParameterValue(534, "", "Tipo Materiale"), True, 90, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "MATKL", clsAppTranslation.GetSingleParameterValue(536, "", "Gruppo Merci"), True, 80, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "MEINS", clsAppTranslation.GetSingleParameterValue(86, "", "UdM"), True, DefDtGridCol_UnitaDiMisura - 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "GEWEI", clsAppTranslation.GetSingleParameterValue(537, "", "U.Peso"), True, 46, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "EKGRP", clsAppTranslation.GetSingleParameterValue(538, "", "Gruppo Acquisti"), True, 80, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "ZZSTORAGE_CODE", clsAppTranslation.GetSingleParameterValue(1463, "", "Storage Cod."), True, 80, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "ZWAREHOUSE_CODE", clsAppTranslation.GetSingleParameterValue(1464, "", "Warehouse Cod."), True, 80, True)

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

    Private Sub frmInfoCodiceMateriale_2_List_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Me.Text = clsAppTranslation.GetSingleParameterValue(113, Me.Text, "Info Ana.Materiale(2)")
            Me.btnDetails.Text = clsAppTranslation.GetSingleParameterValue(254, Me.btnDetails.Text, "Dettagli")
            Me.btnHome.Text = clsAppTranslation.GetSingleParameterValue(252, Me.btnHome.Text, "Chiudi")

#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
#Else
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
#End If

            '**************************************   

            If Not (clsInfoCodiceMateriale.objDataTableCodiceMaterialeInfo Is Nothing) Then
                clsInfoCodiceMateriale.objDataTableCodiceMaterialeInfo.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridShowInfo.DataSource = clsInfoCodiceMateriale.objDataTableCodiceMaterialeInfo
            End If


            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()

            If (Not (clsInfoCodiceMateriale.objDataTableCodiceMaterialeInfo Is Nothing)) Then
                Me.Text = "Info Ana.Materiale(2)" & "-" & clsInfoCodiceMateriale.objDataTableCodiceMaterialeInfo.Rows.Count
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

    Private Sub btnDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (clsInfoCodiceMateriale.objDataTableCodiceMaterialeInfo Is Nothing) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(539, "", "DataTable non valido.(Nothing)")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (clsInfoCodiceMateriale.objDataTableCodiceMaterialeInfo.Rows.Count = 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(540, "", "DataTable senza dati.(Rows=0)")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'DEVO AVERE SELEZIONATO UNA RIGA
            If (Me.DtGridShowInfo.CurrentRowIndex < 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(445, "", "Attenzione!") & vbCrLf & clsAppTranslation.GetSingleParameterValue(541, "", "Selezionare una riga della griglia.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
            clsInfoCodiceMateriale.RowIndex = Me.DtGridShowInfo.CurrentRowIndex
            clsInfoCodiceMateriale.objDetailsDataRow = clsInfoCodiceMateriale.objDataTableCodiceMaterialeInfo.Rows(Me.DtGridShowInfo.CurrentRowIndex)
            clsInfoCodiceMateriale.RefreshDateTableDetailsInfo()

            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Info_Anagrafica_Materiale(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class