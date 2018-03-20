Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility


Public Class frmInfoMappaUbicazioni_2

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmInfoMappaUbicazioni_2"


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

    Private Sub frmInfoTipiMag_2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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

    Private Sub cmdPreviousScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreviousScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'PASSO ALLO VIDEATA DELLO STEP PRECEDENTE
            Call clsNavigation.Show_Info_Mappa_Ubicazioni(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

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
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "LGNUM", clsAppTranslation.GetSingleParameterValue(569, "", "Num."), True, DefDtGridCol_NumeroMagazzino + 10, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "LGTYP", clsAppTranslation.GetSingleParameterValue(304, "", "Tipo"), True, DefDtGridCol_TipoMagazzino + 10, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "LGPLA", clsAppTranslation.GetSingleParameterValue(4, "", "Ubicazione"), True, DefDtGridCol_Ubicazione + 80, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "KZLER", clsAppTranslation.GetSingleParameterValue(1579, "", "Ubi. vuota"), True, DefDtGridCol_NumeroMagazzino + 60, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "KZVOL", clsAppTranslation.GetSingleParameterValue(1760, "", "Ubi. Occupata"), True, DefDtGridCol_NumeroMagazzino + 60, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "UBI_PIENA", clsAppTranslation.GetSingleParameterValue(1580, "", "Ubi. piena"), True, DefDtGridCol_NumeroMagazzino + 60, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "LKAPV", clsAppTranslation.GetSingleParameterValue(1581, "", "Cap. Ubi."), True, DefDtGridCol_NumeroMagazzino + 60, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "ZWMS_UOM_CAP", clsAppTranslation.GetSingleParameterValue(86, "", "UdM"), True, DefDtGridCol_UnitaDiMisura - 30, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "ZQTA_LGPLA", clsAppTranslation.GetSingleParameterValue(1738, "", "Quantità Ubi."), True, DefDtGridCol_NumeroMagazzino + 120, True)

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

    Private Sub frmInfoMappaUbicazioni_2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            Me.Text = clsAppTranslation.GetSingleParameterValue(256, Me.Text, "Info Map.Ubicaz.(2)")

            btnHome.Text = clsAppTranslation.GetSingleParameterValue(252, btnHome.Text, "Chiudi")

            '**************************************  

            If Not (clsInfoMappaUbicazioni.objDataTableMappaUbicazioniInfo Is Nothing) Then
                clsInfoMappaUbicazioni.objDataTableMappaUbicazioniInfo.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridShowInfo.DataSource = clsInfoMappaUbicazioni.objDataTableMappaUbicazioniInfo
            End If

            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()

            If (Not (clsInfoMappaUbicazioni.objDataTableMappaUbicazioniInfo Is Nothing)) Then
                Me.Text = clsAppTranslation.GetSingleParameterValue(256, "", "Info Map.Ubicaz.(2)") & "-" & clsInfoMappaUbicazioni.objDataTableMappaUbicazioniInfo.Rows.Count
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
End Class