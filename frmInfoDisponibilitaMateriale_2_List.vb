Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility


Public Class frmInfoDisponibilitaMateriale_2_List

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmInfoDisponibilitaMateriale_2_List"


    Private ErrDescription As String


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

    Private Sub frmInfoDisponibilitaMateriale_2_List_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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

    Private Sub cmdPreviousScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreviousScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'PASSO ALLO VIDEATA DELLO STEP PRECEDENTE
            Call clsNavigation.Show_Info_Disponibilita_Materiale(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

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
                If (clsUtility.IsStringValid(clsInfoDisponibilitaMateriale.FilterDivisione, True) = True) Then
                    'SE HO FILTRATO LA DIVISIONE NASCONDO LA COLONNA
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "WERKS", clsAppTranslation.GetSingleParameterValue(6, "", "Divisione"), False, DefDtGridCol_Divisione, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "MATNR", clsAppTranslation.GetSingleParameterValue(306, "", "Cod.Materiale"), True, DefDtGridCol_CodiceMateriale + 50, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "CHARG", clsAppTranslation.GetSingleParameterValue(307, "", "Partita"), True, DefDtGridCol_PartitaMateriale - 10, True)
                Else
                    'SE NON HO FITRATO LA DIVISIONE VISUALIZZO LA COLONNA IN QUANTO POSSONO ESSERE PRESENTI + DIVISIONI
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "WERKS", clsAppTranslation.GetSingleParameterValue(6, "", "Divisione"), True, DefDtGridCol_Divisione + 18, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "MATNR", clsAppTranslation.GetSingleParameterValue(306, "", "Cod.Materiale"), True, DefDtGridCol_CodiceMateriale - 10, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "CHARG", clsAppTranslation.GetSingleParameterValue(307, "", "Partita"), True, DefDtGridCol_PartitaMateriale - 10, True)
                End If

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "LGORT", clsAppTranslation.GetSingleParameterValue(546, "", "Mag."), True, DefDtGridCol_MagazzinoLogico, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "CLABS", clsAppTranslation.GetSingleParameterValue(1727, "", "Stock"), True, 160, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "DISPO", clsAppTranslation.GetSingleParameterValue(547, "", "Q.Dispo"), True, 160, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "VBMNC", clsAppTranslation.GetSingleParameterValue(548, "", "Q.Impegnata"), True, 160, True)
                'RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "UTA_VIS", clsAppTranslation.GetSingleParameterValue(549, "", "U.d.M."), True, DefDtGridCol_UnitaDiMisura, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "SCELTA", clsAppTranslation.GetSingleParameterValue(550, "", "Scelta"), True, 100, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "NOTA", clsAppTranslation.GetSingleParameterValue(551, "", "Note"), True, 300, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "CINSM", clsAppTranslation.GetSingleParameterValue(1728, "", "Quality"), True, 160, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "BDMNG", clsAppTranslation.GetSingleParameterValue(1729, "", "TempReser"), True, 160, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "VBMNJ", clsAppTranslation.GetSingleParameterValue(1730, "", "Prepar"), True, 160, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "CSPEM", clsAppTranslation.GetSingleParameterValue(1731, "", "Block stock S"), True, 160, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "CLABS_E", clsAppTranslation.GetSingleParameterValue(1732, "", "Cust.reser."), True, 160, True)

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

    Private Sub frmInfoDisponibilitaMateriale_2_List_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            btnDetails.Text = clsAppTranslation.GetSingleParameterValue(254, btnDetails.Text, "Dettagli")
            btnHome.Text = clsAppTranslation.GetSingleParameterValue(252, btnHome.Text, "Chiudi")

#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
#Else
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
#End If

            '**************************************   

            If Not (clsInfoDisponibilitaMateriale.objDataTableDispoMaterialeInfo Is Nothing) Then
                clsInfoDisponibilitaMateriale.objDataTableDispoMaterialeInfo.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridShowInfo.DataSource = clsInfoDisponibilitaMateriale.objDataTableDispoMaterialeInfo
            End If


            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()

            If (Not (clsInfoDisponibilitaMateriale.objDataTableDispoMaterialeInfo Is Nothing)) Then
                Me.Text = clsAppTranslation.GetSingleParameterValue(552, "", "Info Dispo.Mat.(2)") & "-" & clsInfoDisponibilitaMateriale.objDataTableDispoMaterialeInfo.Rows.Count
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

            If (clsInfoDisponibilitaMateriale.objDataTableDispoMaterialeInfo Is Nothing) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(539, "", "DataTable non valido.(Nothing)")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (clsInfoDisponibilitaMateriale.objDataTableDispoMaterialeInfo.Rows.Count = 0) Then
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
            clsInfoDisponibilitaMateriale.RowIndex = Me.DtGridShowInfo.CurrentRowIndex
            clsInfoDisponibilitaMateriale.objDetailsDataRow = clsInfoDisponibilitaMateriale.objDataTableDispoMaterialeInfo.Rows(Me.DtGridShowInfo.CurrentRowIndex)
            clsInfoDisponibilitaMateriale.RefreshDateTableDetailsInfo()

            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Info_Disponibilita_Materiale(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class