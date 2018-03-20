Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility


Public Class frmInfoTipiMag_2

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmInfoTipiMag_2"


    Private ErrDescription As String
    Private FlagFormLoaded As Boolean = False


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

    Private Sub frmInfoTipiMag_2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (FlagFormLoaded <> True) Then Exit Sub

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
            Call clsNavigation.Show_Info_Tipi_Magazzino(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

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
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "LGNUM", clsAppTranslation.GetSingleParameterValue(569, "", "Num."), True, DefDtGridCol_NumeroMagazzino + 30, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "LGTYP", clsAppTranslation.GetSingleParameterValue(304, "", "Tipo"), True, DefDtGridCol_TipoMagazzino + 40, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "LTYPT", clsAppTranslation.GetSingleParameterValue(584, "", "Descr. Tip.Mag."), True, 400, True)
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

    Private Sub frmInfoTipiMag_2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            Me.Text = clsAppTranslation.GetSingleParameterValue(262, Me.Text, "Info Tipi Mag.(2)")

            btnHome.Text = clsAppTranslation.GetSingleParameterValue(252, btnHome.Text, "Chiudi")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
#Else
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
#End If

            '**************************************   

            If Not (clsInfoTipiMagazzino.objDataTableTipiMagazzinoInfo Is Nothing) Then
                clsInfoTipiMagazzino.objDataTableTipiMagazzinoInfo.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridShowInfo.DataSource = clsInfoTipiMagazzino.objDataTableTipiMagazzinoInfo
            End If


            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()

            If (Not (clsInfoTipiMagazzino.objDataTableTipiMagazzinoInfo Is Nothing)) Then
                Me.Text = clsAppTranslation.GetSingleParameterValue(262, "", "Info Tipi Mag.(2)") & "-" & clsInfoTipiMagazzino.objDataTableTipiMagazzinoInfo.Rows.Count
            End If

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            Me.btnHome.Focus()

            FlagFormLoaded = True 'SETTO FLAG DI FINESTRA CARICATA

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class