
Imports clsSapWS
Imports clsNavigation

Public Class frmMenuDisaccantonamento
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmMenuDisaccantonamento"
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

    Private Sub frmMenuTrasferDisaccantonamento_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmMenuDisaccantonamento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.D1)) Then
                'SU PRESSIONE DEL TASTO ATTTIVO AUTOMATICAMENTE UNA FUNZIONE
                Call Me.btnListaMissioniDisaccantonamento_Click(Me, e)
                Exit Sub
            End If
            If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.D2)) Then
                'SU PRESSIONE DEL TASTO ATTTIVO AUTOMATICAMENTE UNA FUNZIONE
                Call Me.btnEseguiMissioneDisaccantonamento_Click(Me, e)
                Exit Sub
            End If
            If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.D9)) Then
                'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
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

    Private Sub frmMenuDisaccantonamento_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            btnListaMissioniDisaccantonamento.Text = clsAppTranslation.GetSingleParameterValue(35, btnListaMissioniDisaccantonamento.Text, "1 - Lista Miss. Disaccantonamenti")
            btnEseguiMissioneDisaccantonamento.Text = clsAppTranslation.GetSingleParameterValue(36, btnEseguiMissioneDisaccantonamento.Text, "2 - Disaccantonamento-Esegui Miss.")
            btnVisualizzaInfo.Text = clsAppTranslation.GetSingleParameterValue(14, btnVisualizzaInfo.Text, "9 - Visualizza Info")

            btnCloseForm.Text = clsAppTranslation.GetSingleParameterValue(252, btnCloseForm.Text, "Chiudi")

            Me.Text = clsAppTranslation.GetSingleParameterValue(29, Me.Text, "Menu Trasferimenti")

            btnHome.Text = clsAppTranslation.GetSingleParameterValue(264, btnHome.Text, "Home")

            '**************************************    


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
        Dim RetCode As Long = 0
        Dim ErrDescription As String = ""
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


    Private Sub btnVisualizzaInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizzaInfo.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim ErrDescription As String = ""
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

    Private Sub btnListaMissioniDisaccantonamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListaMissioniDisaccantonamento.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnListaMissioniDisaccantonamento.Tag) = False) Then Exit Sub

            RetCode = clsNavigation.Show_Ope_DisaccantonamentoMerci(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, clsWmsJob.Disaccantonamento_SourceType.Disaccantonamento_SourceTypeManualSelection, True)
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

    Private Sub btnEseguiMissioneDisaccantonamento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEseguiMissioneDisaccantonamento.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnEseguiMissioneDisaccantonamento.Tag) = False) Then Exit Sub

            RetCode = clsNavigation.Show_Ope_DisaccantonamentoMerci(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, clsWmsJob.Disaccantonamento_SourceType.Disaccantonamento_SourceTypeJobsGroup, True)
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

    Private Sub btnCloseForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseForm.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim ErrDescription As String = ""
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
End Class