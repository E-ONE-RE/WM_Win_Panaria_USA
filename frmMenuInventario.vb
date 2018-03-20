
Imports clsSapWS
Imports clsNavigation

Public Class frmMenuInventario
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmMenuInventario"
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

    Private Sub frmMenuInventario_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
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

    Private Sub frmMenuInventario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.D1)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.NumPad1)) Then
                'SU PRESSIONE DEL TASTO ATTTIVO AUTOMATICAMENTE UNA FUNZIONE
                Call Me.btnInventarioUbicazione_Click(Me, e)
                Exit Sub
            End If
            If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.D2)) Then
                'SU PRESSIONE DEL TASTO ATTTIVO AUTOMATICAMENTE UNA FUNZIONE
                Call Me.btnInventarioUnitaMagazzino_Click(Me, e)
                Exit Sub
            End If
            If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.D3)) Then
                'SU PRESSIONE DEL TASTO ATTTIVO AUTOMATICAMENTE UNA FUNZIONE
                Call Me.btnInventarioRottamazione_Click(Me, e)
                Exit Sub
            End If
            If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.D4)) Then
                'SU PRESSIONE DEL TASTO ATTTIVO AUTOMATICAMENTE UNA FUNZIONE
                Call Me.btnInventarioCentroCosto_Click(Me, e)
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

    Private Sub frmMenuInventario_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            btnInventarioUbicazione.Text = clsAppTranslation.GetSingleParameterValue(46, btnInventarioUbicazione.Text, "1 - Inventario/Conta Ubicazione")
            btnInventarioUnitaMagazzino.Text = clsAppTranslation.GetSingleParameterValue(47, btnInventarioUnitaMagazzino.Text, "2-Inventario/Conta Unità Magazzino")
            btnInventarioRottamazione.Text = clsAppTranslation.GetSingleParameterValue(48, btnInventarioRottamazione.Text, "3 - Rottura / Rottamazione")
            btnInventarioCentroCosto.Text = clsAppTranslation.GetSingleParameterValue(49, btnInventarioCentroCosto.Text, "4 - Consumo per Centro Costo")
            btnVisualizzaInfo.Text = clsAppTranslation.GetSingleParameterValue(14, btnVisualizzaInfo.Text, "Visualizza Info")

            Me.Text = clsAppTranslation.GetSingleParameterValue(45, Me.Text, "Menu Inventario")

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

    Private Sub btnInventarioUbicazione_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInventarioUbicazione.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnInventarioUbicazione.Tag) = False) Then Exit Sub

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

    Private Sub btnInventarioRottamazione_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInventarioRottamazione.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnInventarioRottamazione.Tag) = False) Then Exit Sub

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
    Private Sub btnInventarioCentroCosto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInventarioCentroCosto.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnInventarioCentroCosto.Tag) = False) Then Exit Sub

            'VERIFICA SE LA FUNZIONE E' ABILITATA PER LO USER
            If (MenuEnableInvenCostCentreConsume = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(634, "", "Attenzione! Funzione non abilitata per l'utente attivo.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            RetCode = clsNavigation.Show_Ope_InventarioUbicazione(Me, clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeCentroCosto, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)
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

    Private Sub btnInventarioUnitaMagazzino_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInventarioUnitaMagazzino.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnInventarioUnitaMagazzino.Tag) = False) Then Exit Sub

            RetCode = clsNavigation.Show_Ope_InventarioUbicazione(Me, clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUnitaMagazzino, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)
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