
Imports clsSapWS
Imports clsNavigation

Public Class frmMenuBloccoMerci
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmMenuBloccoMerci"
    Private ErrDescription As String
    Public FormLoaded As Boolean = False


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

    Private Sub frmMenuBloccoMerci_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            FormLoaded = False

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmMenuBloccoMerci_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            btnBloccoGiacenza.Text = clsAppTranslation.GetSingleParameterValue(37, btnBloccoGiacenza.Text, "Blocco/Sblocco Giacenza")
            btnBloccoUbicazione.Text = clsAppTranslation.GetSingleParameterValue(38, btnBloccoUbicazione.Text, "Blocco/Sblocco Ubicazione")
            btnAggiungiRimuoviStockQ.Text = clsAppTranslation.GetSingleParameterValue(39, btnAggiungiRimuoviStockQ.Text, "Aggiungi/Rimuovi Stock Q")
            btnAggiungiRimuoviStockS.Text = clsAppTranslation.GetSingleParameterValue(40, btnAggiungiRimuoviStockS.Text, "Aggiungi/Rimuovi Stock S")
            btnAggiungiRimuoviStockE.Text = clsAppTranslation.GetSingleParameterValue(41, btnAggiungiRimuoviStockE.Text, "Aggiungi/Rimuovi Stock E")
            btnAggiungiRimuoviStockR.Text = clsAppTranslation.GetSingleParameterValue(42, btnAggiungiRimuoviStockR.Text, "Rimuovi Stock R")
            btnAggiungiRimuoviStockO.Text = clsAppTranslation.GetSingleParameterValue(43, btnAggiungiRimuoviStockO.Text, "Aggiungi/Rimuovi O")
            btnVisualizzaInfo.Text = clsAppTranslation.GetSingleParameterValue(14, btnVisualizzaInfo.Text, "Visualizza Info")

            Me.Text = clsAppTranslation.GetSingleParameterValue(44, Me.Text, "Menu Blocchi Merce")

            btnHome.Text = clsAppTranslation.GetSingleParameterValue(264, btnHome.Text, "Home")

            '**************************************


            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            FormLoaded = True

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
        Dim RetCode As Long = 0
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

    Private Sub btnInventarioUbicazione_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBloccoGiacenza.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnBloccoGiacenza.Tag) = False) Then Exit Sub

            'VERIFICA SE LA FUNZIONE E' ABILITATA PER LO USER
            If (MenuEnableBloccoGiacenza = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(634, "", "Attenzione! Funzione non abilitata per l'utente attivo.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            RetCode = clsNavigation.Show_Ope_InventarioUbicazione(Me, clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUbicazione, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)
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

    Private Sub btnInventarioRottamazione_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBloccoUbicazione.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnBloccoUbicazione.Tag) = False) Then Exit Sub

            RetCode = clsNavigation.Show_Ope_InventarioUbicazione(Me, clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeRottamazione, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)
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

    Private Sub btnVisualizzaInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizzaInfo.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnVisualizzaInfo.Tag) = False) Then Exit Sub

            RetCode = clsNavigation.Show_Mnu_Main_Informazioni(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNone, True)
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

    Private Sub btnAggiungiRimuoviStockQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAggiungiRimuoviStockQ.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim retcode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnAggiungiRimuoviStockQ.Tag) = False) Then Exit Sub

            retcode = clsNavigation.Show_Ope_Blocco_Mov_MM(Me, clsBloccoMovMM.Blocco_Mov_MM_Type.BloccoMovMM_Type_StockQ, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)
            If (retcode <> 0) Then
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

    Private Sub btnAggiungiRimuoviStockE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAggiungiRimuoviStockE.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim retcode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnAggiungiRimuoviStockE.Tag) = False) Then Exit Sub

            retcode = clsNavigation.Show_Ope_Blocco_Mov_MM(Me, clsBloccoMovMM.Blocco_Mov_MM_Type.BloccoMovMM_Type_StockE, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)
            If (retcode <> 0) Then
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

    Private Sub btnAggiungiRimuoviStockR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAggiungiRimuoviStockR.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim retcode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnAggiungiRimuoviStockR.Tag) = False) Then Exit Sub

            retcode = clsNavigation.Show_Ope_Blocco_Mov_MM(Me, clsBloccoMovMM.Blocco_Mov_MM_Type.BloccoMovMM_Type_StockR, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)
            If (retcode <> 0) Then
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

    Private Sub btnAggiungiRimuoviStockO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAggiungiRimuoviStockO.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim retcode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnAggiungiRimuoviStockO.Tag) = False) Then Exit Sub

            retcode = clsNavigation.Show_Ope_Blocco_Mov_MM(Me, clsBloccoMovMM.Blocco_Mov_MM_Type.BloccoMovMM_Type_StockO, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)
            If (retcode <> 0) Then
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

    Private Sub btnAggiungiRimuoviStockS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAggiungiRimuoviStockS.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim retcode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnAggiungiRimuoviStockS.Tag) = False) Then Exit Sub

            retcode = clsNavigation.Show_Ope_Blocco_Mov_MM(Me, clsBloccoMovMM.Blocco_Mov_MM_Type.BloccoMovMM_Type_StockS, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)
            If (retcode <> 0) Then
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
End Class