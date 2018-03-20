
Imports clsSapWS
Imports clsNavigation

Public Class frmMenuUscitaMerciMain
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmMenuUscitaMerciMain"

    Public FormLoaded As Boolean = False
    Private ErrDescription As String = ""


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

    Private Sub frmMenuUscitaMerciMain_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
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

    Private Sub frmMenuUscitaMerciMain_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.D1)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.NumPad1)) Then
                'SU PRESSIONE DEL TASTO ATTTIVO AUTOMATICAMENTE UNA FUNZIONE
                Call Me.btnListaMissioniDiPicking_Click(Me, e)
                Exit Sub
            End If
            If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.D2)) Then
                'SU PRESSIONE DEL TASTO ATTTIVO AUTOMATICAMENTE UNA FUNZIONE
                Call Me.btnMissioneDiPicking_Click(Me, e)
                Exit Sub
            End If
            If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.D3)) Then
                'SU PRESSIONE DEL TASTO ATTTIVO AUTOMATICAMENTE UNA FUNZIONE
                Call Me.btnPrintPalletCard_Click(Me, e)
                Exit Sub
            End If
            If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.D4)) Then
                'SU PRESSIONE DEL TASTO ATTTIVO AUTOMATICAMENTE UNA FUNZIONE
                Call Me.btnTrasfRietichettaUnitaMagazzino_Click(Me, e)
                Exit Sub
            End If
            If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.D5)) Then
                'SU PRESSIONE DEL TASTO ATTTIVO AUTOMATICAMENTE UNA FUNZIONE

                Exit Sub
            End If
            If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.D6)) Then
                'SU PRESSIONE DEL TASTO ATTTIVO AUTOMATICAMENTE UNA FUNZIONE

                Exit Sub
            End If
            If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.D7)) Then
                'SU PRESSIONE DEL TASTO ATTTIVO AUTOMATICAMENTE UNA FUNZIONE

                Exit Sub
            End If
            If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.D9)) Then
                'SU PRESSIONE DEL TASTO ATTTIVO AUTOMATICAMENTE UNA FUNZIONE
                Call Me.btnVisualizzaInfo_Click(Me, e)
                Exit Sub
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmMenuUscitaMerciMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            btnListaMissioniDiPicking.Text = clsAppTranslation.GetSingleParameterValue(22, btnListaMissioniDiPicking.Text, "1 - Lista Picking Approntamento")
            btnMissioneDiPicking.Text = clsAppTranslation.GetSingleParameterValue(23, btnMissioneDiPicking.Text, "2 - Picking - Esegui Missione")
            btnPrintPalletCard.Text = clsAppTranslation.GetSingleParameterValue(24, btnPrintPalletCard.Text, "3 - Stampa Pallet Card")
            btnTrasfRietichettaUnitaMagazzino.Text = clsAppTranslation.GetSingleParameterValue(25, btnTrasfRietichettaUnitaMagazzino.Text, "4 - Ri-etichettatura Unita Magazzino")
            btnUscitaMerciOdP.Text = clsAppTranslation.GetSingleParameterValue(28, btnUscitaMerciOdP.Text, "7 - Prelievo Merci x OdP")
            btnVisualizzaInfo.Text = clsAppTranslation.GetSingleParameterValue(14, btnVisualizzaInfo.Text, "9 - Visualizza Info")

            Me.Text = clsAppTranslation.GetSingleParameterValue(21, Me.Text, "Uscita/Picking Menu")

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


    Private Sub btnListaMissioniDiPicking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListaMissioniDiPicking.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnListaMissioniDiPicking.Tag) = False) Then Exit Sub

            RetCode = clsNavigation.Show_PickingMerci_JobGroupList(Me, True)
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
    Private Sub btnMissioneDiPicking_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMissioneDiPicking.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnMissioneDiPicking.Tag) = False) Then Exit Sub

            RetCode = clsNavigation.Show_Ope_PickingMerci_Approntamento(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)
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

    Private Sub btnPrintPalletCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPalletCard.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnPrintPalletCard.Tag) = False) Then Exit Sub

            frmPrintPalletCard_1_UMForm = New frmPrintPalletCard_1_UM
            frmPrintPalletCard_1_UMForm.Show()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub btnTrasfRietichettaUnitaMagazzino_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrasfRietichettaUnitaMagazzino.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnTrasfRietichettaUnitaMagazzino.Tag) = False) Then Exit Sub

            RetCode = clsNavigation.Show_Ope_TRASF_UnitaMagazzino(Me, clsDataType.FunctionTransferMaterialType.FunctionTransferMaterialTypeForUMPrintLabel, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)
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

    Private Sub btnUscitaMerciOdP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUscitaMerciOdP.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnUscitaMerciOdP.Tag) = False) Then Exit Sub

            RetCode = clsNavigation.Show_Ope_UscitaMerci_x_OdP(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)
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

End Class