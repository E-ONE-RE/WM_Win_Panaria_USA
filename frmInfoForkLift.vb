
Imports clsSapWS
Imports clsNavigation


Public Class frmInfoForkLift
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmInfoForkLift"
    Private SapFunctionError As clsBusinessLogic.SapFunctionError

    Public ErrDescription As String


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

    Private Sub frmInfoForkLift_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.btnHome.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.btnHome_Click(Me, e)
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

    Private Sub frmInfoForkLift_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            Me.Text = clsAppTranslation.GetSingleParameterValue(1160, Me.Text, "Info Carrelli")

            btnHome.Text = clsAppTranslation.GetSingleParameterValue(264, btnHome.Text, "Home")

            '**************************************   

            'CHIAMO WEB SERVICE ANAGRAFICA CARRELLISTI
            RetCode = clsSapWS.Call_ZWS_GET_FORKLIFT(clsUser.SapWmsUser.LGNUM, clsUser.SapWmsUser.WERKS, "", "", "", False, clsForkLift.objDataTableForkLift, clsForkLift.objDataTableForkLiftWH, SapFunctionError, False)


            If Not (clsForkLift.objDataTableForkLift Is Nothing) Then
                clsForkLift.objDataTableForkLift.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridForkLiftInfo.DataSource = clsForkLift.objDataTableForkLift
            End If


            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()

            'refresh dei dati
            'RetCode += clsForkLift.RefreshDateTableForForkLift()

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
    Private Sub btnHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHome.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RetCode = clsNavigation.Show_Mnu_Home(Me, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(281, "", "Errore nell'apertura della form. Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

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
            If (Me.DtGridForkLiftInfo.TableStyles.Count = 0) Then
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridForkLiftInfo, "", "LGNUM", clsAppTranslation.GetSingleParameterValue(1165, "", "NMg"), False, DefDtGridCol_NumeroMagazzino, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridForkLiftInfo, "", "ZID_WMS_FORKLIFT", clsAppTranslation.GetSingleParameterValue(1162, "", "Cod.Mulet."), True, DefDtGridCol_ZID_WMS_FORKLIFT + 20, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridForkLiftInfo, "", "ZDESCR_WMS_FORKLIFT", clsAppTranslation.GetSingleParameterValue(1163, "", "Desc.Mulet."), True, DefDtGridCol_ZDESCR_WMS_FORKLIFT, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridForkLiftInfo, "", "ZFORKLIFT_MAX_PESO", clsAppTranslation.GetSingleParameterValue(1164, "", "Max Peso"), True, DefDtGridCol_ZFORKLIFT_MAX_PESO, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridForkLiftInfo, "", "GEWEI", clsAppTranslation.GetSingleParameterValue(70, "", "UM"), True, DefDtGridCol_GEWEI, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridForkLiftInfo, "", "LGTYP", clsAppTranslation.GetSingleParameterValue(1166, "", "Cat"), True, DefDtGridCol_TipoMagazzino + 10, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridForkLiftInfo, "", "LGPLA", clsAppTranslation.GetSingleParameterValue(1167, "", "Ubic."), True, 100, True)
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

End Class