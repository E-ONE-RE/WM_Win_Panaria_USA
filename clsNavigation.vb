' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 18/08/2011
' DATA MODIFICA     : 20/06/2012
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la navigazione tra le diverse form dell'applicazione
' *****************************************************************************************

Imports System.Web.Services
Imports System.Windows.Forms
Imports clsDataType
Imports clsWmsJob
Imports WM_Win_PanariaUSA.clsDataType


Public Class clsNavigation

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsNavigation"
    Private Shared ErrDescription As String

    Public Shared Function Show_Mnu_Main_Trasfer(ByRef inSourceForm As Form, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Mnu_Main_Trasfer = 1 'INIT AT ERROR


            frmMenuTrasferMainForm = New frmMenuTrasferMain
            frmMenuTrasferMainForm.Show()

#If Not APPLICAZIONE_WIN32 = "SI" Then
            Call inSourceForm.Hide()
#End If

            frmMenuTrasferMainForm.Focus()

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Mnu_Main_Trasfer = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Mnu_Main_Trasfer = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function


    Public Shared Function Show_PickingMerci_Fork_DropUDS(ByRef inSourceForm As Form, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_PickingMerci_Fork_DropUDS = 1 'INIT AT ERROR


            frmPickingMerci_Fork_DropUDSForm = New frmPickingMerci_Fork_DropUDS
            frmPickingMerci_Fork_DropUDSForm.Show()

#If Not APPLICAZIONE_WIN32 = "SI" Then
            Call inSourceForm.Hide()
#End If

            frmPickingMerci_Fork_DropUDSForm.Focus()

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_PickingMerci_Fork_DropUDS = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_PickingMerci_Fork_DropUDS = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function


    Public Shared Function Show_PickingMerci_JobGroupList(ByRef inSourceForm As Form, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_PickingMerci_JobGroupList = 1 'INIT AT ERROR


            frmPickingMerci_JobGroupListForm = New frmPickingMerci_JobGroupList
            frmPickingMerci_JobGroupListForm.Show()

#If Not APPLICAZIONE_WIN32 = "SI" Then
            Call inSourceForm.Hide()
#End If

            frmPickingMerci_JobGroupListForm.Focus()

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_PickingMerci_JobGroupList = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_PickingMerci_JobGroupList = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Public Shared Function Show_JobGroup_Details(ByVal inNumeroJobsGroup As String, ByRef inSourceForm As Form, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim ExecutionOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_JobGroup_Details = 1 'INIT AT ERROR

            If (clsUtility.IsStringValid(inNumeroJobsGroup, True) = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(911, "", "Numero Gruppo Missioni non valido.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If

            RetCode = clsWmsJobsGroup.GetJobsGroupSingle(inNumeroJobsGroup, Nothing, Nothing, ExecutionOk, inShowMessageBox)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(912, "", "Errore in ") & "[GetJobsGroupSingle]." & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If

            frmPickingMerci_JobGroupDetailsForm = New frmPickingMerci_JobGroupDetails
            frmPickingMerci_JobGroupDetailsForm.SourceForm = inSourceForm
            frmPickingMerci_JobGroupDetailsForm.Show()

#If Not APPLICAZIONE_WIN32 = "SI" Then
            Call inSourceForm.Hide()
#End If

            frmPickingMerci_JobGroupDetailsForm.Focus()

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_JobGroup_Details = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_JobGroup_Details = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Public Shared Function Show_Mnu_Main_EntrataMerci(ByRef inSourceForm As Form, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Mnu_Main_EntrataMerci = 1 'INIT AT ERROR


            frmMenuEntrataMerciForm = New frmMenuEntrataMerci
            frmMenuEntrataMerciForm.Show()

#If Not APPLICAZIONE_WIN32 = "SI" Then
            Call inSourceForm.Hide()
#End If

            frmMenuEntrataMerciForm.Focus()

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Mnu_Main_EntrataMerci = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Mnu_Main_EntrataMerci = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function
    Public Shared Function Show_Mnu_Main_UscitaMerci(ByRef inSourceForm As Form, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Mnu_Main_UscitaMerci = 1 'INIT AT ERROR

#If APPLICAZIONE_WIN32 = "SI" Then
            frmMenuUscitaMerciMainWinForm = New frmMenuUscitaMerciMainWin
            frmMenuUscitaMerciMainWinForm.Show()
#Else
            frmMenuUscitaMerciMainForm = New frmMenuUscitaMerciMain
            frmMenuUscitaMerciMainForm.Show()
#End If

#If Not APPLICAZIONE_WIN32 = "SI" Then
            Call inSourceForm.Hide()
#End If

#If APPLICAZIONE_WIN32 = "SI" Then
            frmMenuUscitaMerciMainWinForm.Focus()
#Else
            frmMenuUscitaMerciMainForm.Focus()
#End If

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Mnu_Main_UscitaMerci = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Mnu_Main_UscitaMerci = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function
    Public Shared Function Show_Mnu_Main_Inventario(ByRef inSourceForm As Form, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Mnu_Main_Inventario = 1 'INIT AT ERROR


            frmMenuInventarioForm = New frmMenuInventario
            frmMenuInventarioForm.Show()

#If Not APPLICAZIONE_WIN32 = "SI" Then
            Call inSourceForm.Hide()
#End If

            frmMenuInventarioForm.Focus()

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Mnu_Main_Inventario = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Mnu_Main_Inventario = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function
    Public Shared Function Show_Mnu_Main_BloccoMerci(ByRef inSourceForm As Form, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Mnu_Main_BloccoMerci = 1 'INIT AT ERROR


            frmMenuBloccoMerciForm = New frmMenuBloccoMerci
            frmMenuBloccoMerciForm.Show()

#If Not APPLICAZIONE_WIN32 = "SI" Then
            Call inSourceForm.Hide()
#End If

            frmMenuBloccoMerciForm.Focus()

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Mnu_Main_BloccoMerci = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Mnu_Main_BloccoMerci = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Public Shared Function Show_Mnu_Main_Informazioni(ByRef inSourceForm As Form, ByVal inWizardDirectionStep As clsDataType.WizardDirectionStepType, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Mnu_Main_Informazioni = 1 'INIT AT ERROR

            Select Case inWizardDirectionStep
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext
                    Select Case inSourceForm.GetType.Name
                        Case frmMenuInformazioni_1.GetType.Name
                            frmMenuInformazioni_2Form = New frmMenuInformazioni_2
                            frmMenuInformazioni_2Form.Show()

#If Not APPLICAZIONE_WIN32 = "SI" Then
                            Call inSourceForm.Hide()
#End If

                            frmMenuInformazioni_2Form.Focus()
                        Case Else
                            'IN TUTTI GLI ALTRI CASI VADO ALLA PRIMA VIDEATA
                            frmMenuInformazioni_1Form = New frmMenuInformazioni_1
                            frmMenuInformazioni_1Form.Show()

#If Not APPLICAZIONE_WIN32 = "SI" Then
                            Call inSourceForm.Hide()
#End If

                            frmMenuInformazioni_1Form.Focus()
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious
                    Select Case inSourceForm.GetType.Name
                        Case frmMenuInformazioni_2.GetType.Name
                            frmMenuInformazioni_1Form = New frmMenuInformazioni_1
                            frmMenuInformazioni_1Form.Show()

#If Not APPLICAZIONE_WIN32 = "SI" Then
                            Call inSourceForm.Hide()
#End If

                            frmMenuInformazioni_1Form.Focus()
                        Case Else


                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNone
                    frmMenuInformazioni_1Form = New frmMenuInformazioni_1
                    frmMenuInformazioni_1Form.Show()

#If Not APPLICAZIONE_WIN32 = "SI" Then
                    Call inSourceForm.Hide()
#End If

                    frmMenuInformazioni_1Form.Focus()
                Case Else

            End Select

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Mnu_Main_Informazioni = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Mnu_Main_Informazioni = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Public Shared Function Show_Mnu_Main_Utilita(ByRef inSourceForm As Form, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Mnu_Main_Utilita = 1 'INIT AT ERROR


            frmMenuUtilita_1Form = New frmMenuUtilita_1
            frmMenuUtilita_1Form.Show()

#If Not APPLICAZIONE_WIN32 = "SI" Then
            Call inSourceForm.Hide()
#End If

            frmMenuUtilita_1Form.Focus()

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Mnu_Main_Utilita = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Mnu_Main_Utilita = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Public Shared Function Show_Mnu_Main_Disaccantonamento(ByRef inSourceForm As Form, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Mnu_Main_Disaccantonamento = 1 'INIT AT ERROR


            frmMenuDisaccantonamentoForm = New frmMenuDisaccantonamento
            frmMenuDisaccantonamentoForm.Show()

#If Not APPLICAZIONE_WIN32 = "SI" Then
            Call inSourceForm.Hide()
#End If

            frmMenuDisaccantonamentoForm.Focus()

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Mnu_Main_Disaccantonamento = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Mnu_Main_Disaccantonamento = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Public Shared Function Show_Ope_EntrataMerci_FromJob(ByRef inSourceForm As Form, ByVal inEM_BEM_SourceType As clsEMFromJob.EM_FromJob_SourceType, ByVal inWizardDirectionStep As clsDataType.WizardDirectionStepType, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Ope_EntrataMerci_FromJob = 1 'INIT AT ERROR

            Select Case inWizardDirectionStep
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext
                    Select Case inSourceForm.GetType.Name
                        Case frmMenuEntrataMerci.GetType.Name '>>>> VADO ALLO STEP 1
                            If (EntrataMerceAbilitaSceltaUbicazioneLavoro = True) Then
                                frmEM_FromJob_Part_1_SelUbiSpuntaForm = New frmEM_FromJob_Part_1_SelUbiSpunta
                                clsEMFromJob.ClearAllData() 'INIT
                                clsEMFromJob.EM_SourceType = inEM_BEM_SourceType
                                frmEM_FromJob_Part_1_SelUbiSpuntaForm.Show()
                            Else
                                Select Case inEM_BEM_SourceType
                                    Case clsEMFromJob.EM_FromJob_SourceType.EM_FromJob_SourceTypeDocMat
                                        frmEM_FromJob_Part_2_DocMatForm = New frmEM_FromJob_Part_2_DocMat
                                        clsEMFromJob.EM_SourceType = inEM_BEM_SourceType
                                        frmEM_FromJob_Part_2_DocMatForm.Show()
                                    Case clsEMFromJob.EM_FromJob_SourceType.EM_FromJob_SourceTypeJobGroup
                                        frmEM_FromJob_Part_2_CodMisForm = New frmEM_FromJob_Part_2_CodMis
                                        clsEMFromJob.EM_SourceType = inEM_BEM_SourceType
                                        frmEM_FromJob_Part_2_CodMisForm.Show()
                                    Case Else
                                        '>>> SE NON SPECIFICATO USO COME DEFAULT L'EM CON DOC.MAT
                                        frmEM_FromJob_Part_2_DocMatForm = New frmEM_FromJob_Part_2_DocMat
                                        clsEMFromJob.EM_SourceType = clsEMFromJob.EM_FromJob_SourceType.EM_FromJob_SourceTypeDocMat
                                        frmEM_FromJob_Part_2_DocMatForm.Show()
                                End Select
                            End If
                        Case frmEM_FromJob_Part_1_SelUbiSpunta.GetType.Name
                            Select Case inEM_BEM_SourceType
                                Case clsEMFromJob.EM_FromJob_SourceType.EM_FromJob_SourceTypeDocMat
                                    frmEM_FromJob_Part_2_DocMatForm = New frmEM_FromJob_Part_2_DocMat
                                    clsEMFromJob.EM_SourceType = inEM_BEM_SourceType
                                    frmEM_FromJob_Part_2_DocMatForm.Show()
                                Case clsEMFromJob.EM_FromJob_SourceType.EM_FromJob_SourceTypeJobGroup
                                    frmEM_FromJob_Part_2_CodMisForm = New frmEM_FromJob_Part_2_CodMis
                                    clsEMFromJob.EM_SourceType = inEM_BEM_SourceType
                                    frmEM_FromJob_Part_2_CodMisForm.Show()
                                Case clsEMFromJob.EM_FromJob_SourceType.EM_FromJob_SourceTypeJobList
                                    frmEM_FromJobList_Part_1_FilterForm = New frmEM_FromJobList_Part_1_Filter
                                    clsEMFromJob.EM_SourceType = inEM_BEM_SourceType
                                    frmEM_FromJobList_Part_1_FilterForm.Show()
                                Case Else
                                    '>>> SE NON SPECIFICATO USO COME DEFAULT L'EM CON DOC.MAT
                                    frmEM_FromJob_Part_2_DocMatForm = New frmEM_FromJob_Part_2_DocMat
                                    clsEMFromJob.EM_SourceType = clsEMFromJob.EM_FromJob_SourceType.EM_FromJob_SourceTypeDocMat
                                    frmEM_FromJob_Part_2_DocMatForm.Show()
                            End Select
                        Case frmEM_FromJobList_Part_1_Filter.GetType.Name
                            frmEM_FromJobList_Part_2_ListJobsGroupForm = New frmEM_FromJobList_Part_2_JobGroupList
                            frmEM_FromJobList_Part_2_ListJobsGroupForm.Show()
                        Case frmEM_FromJobList_Part_2_JobGroupList.GetType.Name
                            'HO SCELTO LA LISTA  DALL'ELENCO E VADO ALL'ESECUZIONE DELLA SINGOLA LISTA DI PRELIEVO
                            frmEM_FromJob_Part_3_SelMisForm = New frmEM_FromJob_Part_3_SelMis
                            frmEM_FromJob_Part_3_SelMisForm.Show()
                        Case frmEM_FromJob_Part_2_DocMat.GetType.Name '>>>> VADO ALLO STEP 2
                            frmEM_FromJob_Part_3_SelMisForm = New frmEM_FromJob_Part_3_SelMis
                            frmEM_FromJob_Part_3_SelMisForm.Show()
                        Case frmEM_FromJob_Part_2_CodMis.GetType.Name '>>>> VADO ALLO STEP 2
                            frmEM_FromJob_Part_3_SelMisForm = New frmEM_FromJob_Part_3_SelMis
                            frmEM_FromJob_Part_3_SelMisForm.Show()
                        Case frmEM_FromJob_Part_3_SelMis.Name
                            Select Case clsWmsJob.WmsJob.EMTipoProceduraType
                                Case clsDataType.EM_TipoProceduraType.EM_TipoProceduraPalletizzaeStoccaggio, clsDataType.EM_TipoProceduraType.EM_TipoProceduraPalletizzaDestSpunta
                                    '>>> CONFERMARE LA QTA DA UBICARE ( PER PROCESSO DI PALLETIZZAZIONE )
                                    frmEM_FromJob_Part_4_ConfQtaForm = New frmEM_FromJob_Part_4_ConfQta
                                    frmEM_FromJob_Part_4_ConfQtaForm.Show()
                                Case clsDataType.EM_TipoProceduraType.EM_TipoProceduraStoccaggioDirettoUMSconosciuta
                                    frmEM_FromJob_Part_5_FinalUMUbiConfirmForm = New frmEM_FromJob_Part_5_FinalUMUbiConfirm
                                    frmEM_FromJob_Part_5_FinalUMUbiConfirmForm.Show()
                                Case clsDataType.EM_TipoProceduraType.EM_TipoProceduraStoccaggioDirettoUMConosciuta
                                    frmEM_FromJob_Part_5_FinalUbiConfirmForm = New frmEM_FromJob_Part_5_FinalUbiConfirm
                                    frmEM_FromJob_Part_5_FinalUbiConfirmForm.Show()
                                Case Else
                                    frmEM_FromJob_Part_5_FinalUMUbiConfirmForm = New frmEM_FromJob_Part_5_FinalUMUbiConfirm
                                    frmEM_FromJob_Part_5_FinalUMUbiConfirmForm.Show()
                            End Select
                        Case frmEM_FromJob_Part_4_ConfQta.GetType.Name  '>>>> VADO ALLO STEP 3
                            Select Case clsWmsJob.WmsJob.EMTipoProceduraType
                                Case clsDataType.EM_TipoProceduraType.EM_TipoProceduraPalletizzaDestSpunta
                                    'DEVO DIGITARE SOLO UM
                                    frmEM_FromJob_Part_5_FinalUMConfirmForm = New frmEM_FromJob_Part_5_FinalUMConfirm
                                    frmEM_FromJob_Part_5_FinalUMConfirmForm.Show()
                                Case clsDataType.EM_TipoProceduraType.EM_TipoProceduraPalletizzaeStoccaggio
                                    frmEM_FromJob_Part_5_FinalUMUbiConfirmForm = New frmEM_FromJob_Part_5_FinalUMUbiConfirm
                                    frmEM_FromJob_Part_5_FinalUMUbiConfirmForm.Show()
                                Case clsDataType.EM_TipoProceduraType.EM_TipoProceduraStoccaggioDirettoUMConosciuta
                                    'DEVO DIGITARE SOLO UBICAZIONE
                                    frmEM_FromJob_Part_5_FinalUbiConfirmForm = New frmEM_FromJob_Part_5_FinalUbiConfirm
                                    frmEM_FromJob_Part_5_FinalUbiConfirmForm.Show()
                                Case clsDataType.EM_TipoProceduraType.EM_TipoProceduraStoccaggioDirettoUMSconosciuta
                                    'DEVO DIGITARE UM E UBICAZIONE
                                    frmEM_FromJob_Part_5_FinalUMUbiConfirmForm = New frmEM_FromJob_Part_5_FinalUMUbiConfirm
                                    frmEM_FromJob_Part_5_FinalUMUbiConfirmForm.Show()
                            End Select

                        Case frmEM_FromJob_Part_5_FinalUbiConfirm.GetType.Name '>>>> VADO ALLO STEP SUCCESSIVO
                            '???? GESTIRE SCENARIO CON CONFERMA SPUNTA E POI CONFERMA DESTINAZIONE FINALE ( NON USATO IN PANARIA )
                            frmEM_FromJob_Part_5_FinalUbiConfirmForm = New frmEM_FromJob_Part_5_FinalUbiConfirm
                            frmEM_FromJob_Part_5_FinalUbiConfirmForm.Show()
                        Case frmEM_FromJob_Part_ShowStock.GetType.Name '>>>> VADO ALLO STEP SUCCESSIVO
                            '???? GESTIRE SCENARIO CON CONFERMA SPUNTA E POI CONFERMA DESTINAZIONE FINALE ( NON USATO IN PANARIA )
                            frmEM_FromJob_Part_5_FinalUMUbiConfirmForm = New frmEM_FromJob_Part_5_FinalUMUbiConfirm
                            frmEM_FromJob_Part_5_FinalUMUbiConfirmForm.Show()
                            frmEM_FromJob_Part_5_FinalUMUbiConfirmForm.ConfermaSelezioneStock() '>>> IMPOSTO UBICAZIONE SELEZIONATA
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious
                    Select Case inSourceForm.GetType.Name
                        Case frmEM_FromJob_Part_2_DocMat.GetType.Name
                            If (EntrataMerceAbilitaSceltaUbicazioneLavoro = True) Then
                                frmEM_FromJob_Part_1_SelUbiSpuntaForm = New frmEM_FromJob_Part_1_SelUbiSpunta
                                frmEM_FromJob_Part_1_SelUbiSpuntaForm.Show()
                            End If
                        Case frmEM_FromJob_Part_2_CodMis.GetType.Name
                            If (EntrataMerceAbilitaSceltaUbicazioneLavoro = True) Then
                                frmEM_FromJob_Part_1_SelUbiSpuntaForm = New frmEM_FromJob_Part_1_SelUbiSpunta
                                frmEM_FromJob_Part_1_SelUbiSpuntaForm.Show()
                            End If
                        Case frmEM_FromJob_Part_3_SelMis.GetType.Name
                            Select Case inEM_BEM_SourceType
                                Case clsEMFromJob.EM_FromJob_SourceType.EM_FromJob_SourceTypeDocMat
                                    frmEM_FromJob_Part_2_DocMatForm = New frmEM_FromJob_Part_2_DocMat
                                    clsEMFromJob.EM_SourceType = inEM_BEM_SourceType
                                    frmEM_FromJob_Part_2_DocMatForm.Show()
                                Case clsEMFromJob.EM_FromJob_SourceType.EM_FromJob_SourceTypeJobGroup
                                    frmEM_FromJob_Part_2_CodMisForm = New frmEM_FromJob_Part_2_CodMis
                                    clsEMFromJob.EM_SourceType = inEM_BEM_SourceType
                                    frmEM_FromJob_Part_2_CodMisForm.Show()
                                Case clsEMFromJob.EM_FromJob_SourceType.EM_FromJob_SourceTypeJobList
                                    frmEM_FromJobList_Part_2_ListJobsGroupForm = New frmEM_FromJobList_Part_2_JobGroupList
                                    frmEM_FromJobList_Part_2_ListJobsGroupForm.Show()
                                Case Else
                                    '>>> SE NON SPECIFICATO USO COME DEFAULT L'EM CON DOC.MAT
                                    frmEM_FromJob_Part_2_DocMatForm = New frmEM_FromJob_Part_2_DocMat
                                    clsEMFromJob.EM_SourceType = clsEMFromJob.EM_FromJob_SourceType.EM_FromJob_SourceTypeDocMat
                                    frmEM_FromJob_Part_2_DocMatForm.Show()
                            End Select
                        Case frmEM_FromJob_Part_4_ConfQta.GetType.Name '>>>> TORNO ALLO STEP 2 DA SCELTA COMMESSA
                            Select Case clsEMFromJob.EM_SourceType
                                Case clsEMFromJob.EM_FromJob_SourceType.EM_FromJob_SourceTypeDocMat
                                    frmEM_FromJob_Part_3_SelMisForm = New frmEM_FromJob_Part_3_SelMis
                                    frmEM_FromJob_Part_3_SelMisForm.Show()
                            End Select
                        Case frmEM_FromJob_Part_5_FinalUMUbiConfirm.GetType.Name '>>>> TORNO ALLO STEP PRECEDENTE
                            frmEM_FromJob_Part_4_ConfQtaForm = New frmEM_FromJob_Part_4_ConfQta
                            frmEM_FromJob_Part_4_ConfQtaForm.Show()
                        Case frmEM_FromJob_Part_5_FinalUMConfirm.GetType.Name '>>>> TORNO ALLO STEP PRECEDENTE
                            frmEM_FromJob_Part_4_ConfQtaForm = New frmEM_FromJob_Part_4_ConfQta
                            frmEM_FromJob_Part_4_ConfQtaForm.Show()
                        Case frmEM_FromJob_Part_5_FinalUbiConfirm.GetType.Name '>>>> TORNO ALLO STEP PRECEDENTE
                            frmEM_FromJob_Part_4_ConfQtaForm = New frmEM_FromJob_Part_4_ConfQta
                            frmEM_FromJob_Part_4_ConfQtaForm.Show()
                        Case frmEM_FromJob_Part_ChiudiLista.GetType.Name
                            frmEM_FromJob_Part_3_SelMisForm = New frmEM_FromJob_Part_3_SelMis
                            frmEM_FromJob_Part_3_SelMisForm.Show()
                        Case frmEM_FromJobList_Part_2_JobGroupList.GetType.Name
                            frmEM_FromJobList_Part_1_FilterForm = New frmEM_FromJobList_Part_1_Filter
                            frmEM_FromJobList_Part_1_FilterForm.Show()
                        Case frmInfoJobGroup_Details.GetType.Name
                            frmEM_FromJobList_Part_2_ListJobsGroupForm = New frmEM_FromJobList_Part_2_JobGroupList
                            frmEM_FromJobList_Part_2_ListJobsGroupForm.Show()
                        Case frmInfoJob_Details.GetType.Name
                            frmEM_FromJob_Part_3_SelMisForm = New frmEM_FromJob_Part_3_SelMis
                            frmEM_FromJob_Part_3_SelMisForm.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartGroupSeq
                    '>>> CASO IN CUI RITORNO ALL'ELENCO DELLE RIGHE E NE POSSO SELEZIONARE UNA NUOVA
                    Select Case inSourceForm.GetType.Name
                        Case frmEM_FromJob_Part_5_FinalUMUbiConfirm.GetType.Name, frmEM_FromJob_Part_5_FinalUbiConfirm.GetType.Name, frmEM_FromJob_Part_5_FinalUMConfirm.GetType.Name '>>>> VADO ALLO STEP 2 (RIMANGO NELLO STESSO DOC.MATERIALE => LEGGO NUOVO MATERIALE PER DETERINARE LA RIGA)
                            frmEM_FromJob_Part_3_SelMisForm = New frmEM_FromJob_Part_3_SelMis
                            frmEM_FromJob_Part_3_SelMisForm.Show()
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartSeq
                    '>>> CASO IN CUI CONTINUO L'ESECUZIONE DELLA RIGA IN LAVORO
                    Select Case inSourceForm.GetType.Name
                        Case frmEM_FromJob_Part_5_FinalUMUbiConfirm.GetType.Name, frmEM_FromJob_Part_5_FinalUbiConfirm.GetType.Name, frmEM_FromJob_Part_5_FinalUMConfirm.GetType.Name    '>>>> VADO ALLO STEP 2 (RIMANGO NELLO STESSA RIGA DEL DOC.MATERIALE)
                            Select Case inEM_BEM_SourceType
                                Case clsEMFromJob.EM_FromJob_SourceType.EM_FromJob_SourceTypeDocMat
                                    frmEM_FromJob_Part_4_ConfQtaForm = New frmEM_FromJob_Part_4_ConfQta
                                    frmEM_FromJob_Part_4_ConfQtaForm.Show()
                            End Select
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeCloseGroupSeq
                    frmEM_FromJob_Part_ChiudiListaForm = New frmEM_FromJob_Part_ChiudiLista
                    frmEM_FromJob_Part_ChiudiListaForm.Show()
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeInitSeq
                    'HO CHIUSO LA LISTA E RIPARTO LEGGENDO IL CODICE DEL GRUPPO MISSIONI
                    Select Case inEM_BEM_SourceType
                        Case clsEMFromJob.EM_FromJob_SourceType.EM_FromJob_SourceTypeDocMat
                            frmEM_FromJob_Part_2_DocMatForm = New frmEM_FromJob_Part_2_DocMat
                            clsEMFromJob.EM_SourceType = inEM_BEM_SourceType
                            frmEM_FromJob_Part_2_DocMatForm.Show()
                        Case clsEMFromJob.EM_FromJob_SourceType.EM_FromJob_SourceTypeJobGroup
                            frmEM_FromJob_Part_2_CodMisForm = New frmEM_FromJob_Part_2_CodMis
                            clsEMFromJob.EM_SourceType = inEM_BEM_SourceType
                            frmEM_FromJob_Part_2_CodMisForm.Show()
                        Case Else
                            '>>> SE NON SPECIFICATO USO COME DEFAULT L'EM CON DOC.MAT
                            frmEM_FromJob_Part_2_DocMatForm = New frmEM_FromJob_Part_2_DocMat
                            clsEMFromJob.EM_SourceType = clsEMFromJob.EM_FromJob_SourceType.EM_FromJob_SourceTypeDocMat
                            frmEM_FromJob_Part_2_DocMatForm.Show()
                    End Select

                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeDetails
                    Select Case inEM_BEM_SourceType
                        Case clsEMFromJob.EM_FromJob_SourceType.EM_FromJob_SourceTypeJobGroup
                            frmInfoJobGroup_DetailsForm = New frmInfoJobGroup_Details
                            frmInfoJobGroup_DetailsForm.SourceForm = inSourceForm
                            frmInfoJobGroup_DetailsForm.Show()
                        Case Else
                            frmInfoJob_DetailsForm = New frmInfoJob_Details
                            frmInfoJob_DetailsForm.SourceForm = inSourceForm
                            frmInfoJob_DetailsForm.Show()
                    End Select

                Case Else
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(913, "", "Direzione Step Non prevista (WizardDirectionStep).")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
            End Select

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Ope_EntrataMerci_FromJob = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Ope_EntrataMerci_FromJob = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function
    Public Shared Function Show_Ope_DisaccantonamentoMerci(ByRef inSourceForm As Form, ByVal inWizardDirectionStep As clsDataType.WizardDirectionStepType, ByVal inDisaccantonamento_SourceType As clsWmsJob.Disaccantonamento_SourceType, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Ope_DisaccantonamentoMerci = 1 'INIT AT ERROR

            Select Case inWizardDirectionStep
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext
                    Select Case inSourceForm.GetType.Name
                        Case frmMenuDisaccantonamento.GetType.Name '>>>> VADO ALLO STEP 1
                            clsWmsJobsGroup.ClearAllData()
                            clsWmsJob.ClearAllData()
                            clsWmsJob.DisaccantonamentoSourceType = inDisaccantonamento_SourceType
                            Select Case inDisaccantonamento_SourceType
                                Case clsWmsJob.Disaccantonamento_SourceType.Disaccantonamento_SourceTypeJobsGroup
                                    frmDisaccantonaMerci_1_CodMisForm = New frmDisaccantonaMerci_1_CodMis
                                    frmDisaccantonaMerci_1_CodMisForm.Show()
                                Case clsWmsJob.Disaccantonamento_SourceType.Disaccantonamento_SourceTypeManualSelection
                                    frmDisaccantonaMerci_1_SelMisForm = New frmDisaccantonaMerci_1_SelMis
                                    frmDisaccantonaMerci_1_SelMisForm.Show()
                                Case Else
                                    frmDisaccantonaMerci_1_SelMisForm = New frmDisaccantonaMerci_1_SelMis
                                    frmDisaccantonaMerci_1_SelMisForm.Show()
                            End Select
                        Case frmDisaccantonaMerci_1_CodMis.GetType.Name
                            frmDisaccantonaMerci_1_SelMisForm = New frmDisaccantonaMerci_1_SelMis
                            frmDisaccantonaMerci_1_SelMisForm.Show()
                        Case frmDisaccantonaMerci_1_SelMis.GetType.Name
                            If (clsWmsJob.IsPickingLogicJobs(True) = True) Then
                                'CASO PRELIEVO LOGICO
                                frmDisaccantonaMerci_X_PickLogicForm = New frmDisaccantonaMerci_X_PickLogic
                                frmDisaccantonaMerci_X_PickLogicForm.Show()
                            Else
                                frmDisaccantonaMerci_2_Ubi_e_UM_OrigineForm = New frmDisaccantonaMerci_2_Ubi_e_UM_Origine
                                frmDisaccantonaMerci_2_Ubi_e_UM_OrigineForm.Show()
                            End If
                        Case frmDisaccantonaMerci_2_Ubi_e_UM_Origine.GetType.Name
                            If (clsWmsJob.GetRowCountGiacenzeOriInfo(False) > 1) Then
                                frmDisaccantonaMerci_3_SelStockForm = New frmDisaccantonaMerci_3_SelStock
                                frmDisaccantonaMerci_3_SelStockForm.Show()
                            Else
                                frmDisaccantonaMerci_4_ConfQtaForm = New frmDisaccantonaMerci_4_ConfQta
                                frmDisaccantonaMerci_4_ConfQtaForm.Show()
                            End If
                        Case frmDisaccantonaMerci_3_SelStock.GetType.Name
                            frmDisaccantonaMerci_4_ConfQtaForm = New frmDisaccantonaMerci_4_ConfQta
                            frmDisaccantonaMerci_4_ConfQtaForm.Show()
                        Case frmDisaccantonaMerci_4_ConfQta.GetType.Name
                            Select Case clsWmsJob.PickingMerciDestinationType
                                Case clsWmsJob.PickingMerci_DestinationType.PickingMerci_DestinationTypeUbieUMEnter
                                    frmDisaccantonaMerci_5_Ubi_UM_DestForm = New frmDisaccantonaMerci_5_Ubi_UM_Dest
                                    frmDisaccantonaMerci_5_Ubi_UM_DestForm.Show()
                                Case clsWmsJob.PickingMerci_DestinationType.PickingMerci_DestinationTypeUbicazioneEnter
                                    frmDisaccantonaMerci_5_Sel_UbiDestinazioneForm = New frmDisaccantonaMerci_5_Sel_UbiDestinazione
                                    frmDisaccantonaMerci_5_Sel_UbiDestinazioneForm.Show()
                                Case Else
                                    ErrDescription = clsAppTranslation.GetSingleParameterValue(914, "", "Caso ") & clsAppTranslation.GetSingleParameterValue(916, "", "SouceForm Non prevista ") & "(PickingMerciSourceType)."
                                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                            End Select
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious
                    Select Case inSourceForm.GetType.Name
                        Case frmDisaccantonaMerci_2_Ubi_e_UM_Origine.GetType.Name '>>>> TORNO ALLO STEP PRECENDENTE
                            frmDisaccantonaMerci_1_SelMisForm = New frmDisaccantonaMerci_1_SelMis
                            frmDisaccantonaMerci_1_SelMisForm.Show()
                        Case frmDisaccantonaMerci_3_SelStock.GetType.Name
                            frmDisaccantonaMerci_2_Ubi_e_UM_OrigineForm = New frmDisaccantonaMerci_2_Ubi_e_UM_Origine
                            frmDisaccantonaMerci_2_Ubi_e_UM_OrigineForm.Show()
                        Case frmDisaccantonaMerci_4_ConfQta.GetType.Name
                            If (clsWmsJob.GetRowCountGiacenzeOriInfo(False) > 1) Then
                                frmDisaccantonaMerci_3_SelStockForm = New frmDisaccantonaMerci_3_SelStock
                                frmDisaccantonaMerci_3_SelStockForm.Show()
                            Else
                                frmDisaccantonaMerci_2_Ubi_e_UM_OrigineForm = New frmDisaccantonaMerci_2_Ubi_e_UM_Origine
                                frmDisaccantonaMerci_2_Ubi_e_UM_OrigineForm.Show()
                            End If
                        Case frmDisaccantonaMerci_5_Sel_UbiDestinazione.GetType.Name, frmDisaccantonaMerci_5_Ubi_UM_Dest.GetType.Name
                            frmDisaccantonaMerci_4_ConfQtaForm = New frmDisaccantonaMerci_4_ConfQta
                            frmDisaccantonaMerci_4_ConfQtaForm.Show()
                        Case frmDisaccantonaMerci_X_PickLogic.GetType.Name
                            frmDisaccantonaMerci_1_SelMisForm = New frmDisaccantonaMerci_1_SelMis
                            frmDisaccantonaMerci_1_SelMisForm.Show()
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeInitSeq
                    clsWmsJobsGroup.ClearAllData()
                    clsWmsJob.ClearAllData()
                    clsWmsJob.DisaccantonamentoSourceType = inDisaccantonamento_SourceType
                    Select Case inDisaccantonamento_SourceType
                        Case clsWmsJob.Disaccantonamento_SourceType.Disaccantonamento_SourceTypeJobsGroup
                            frmDisaccantonaMerci_1_CodMisForm = New frmDisaccantonaMerci_1_CodMis
                            frmDisaccantonaMerci_1_CodMisForm.Show()
                        Case clsWmsJob.Disaccantonamento_SourceType.Disaccantonamento_SourceTypeManualSelection
                            frmDisaccantonaMerci_1_SelMisForm = New frmDisaccantonaMerci_1_SelMis
                            frmDisaccantonaMerci_1_SelMisForm.Show()
                        Case Else
                            frmDisaccantonaMerci_1_SelMisForm = New frmDisaccantonaMerci_1_SelMis
                            frmDisaccantonaMerci_1_SelMisForm.Show()
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartSeq
                    Select Case inSourceForm.GetType.Name
                        Case frmDisaccantonaMerci_5_Sel_UbiDestinazione.GetType.Name, frmDisaccantonaMerci_5_Ubi_UM_Dest.GetType.Name      '>>>> TORNO ALLO STEP DI SCELTA DEL MATERIALE DA PRELEVARE
                            frmDisaccantonaMerci_2_Ubi_e_UM_OrigineForm = New frmDisaccantonaMerci_2_Ubi_e_UM_Origine
                            frmDisaccantonaMerci_2_Ubi_e_UM_OrigineForm.Show()
                        Case frmDisaccantonaMerci_X_PickLogic.GetType.Name
                            'CASO PRELIEVO LOGICO
                            frmDisaccantonaMerci_X_PickLogicForm = New frmDisaccantonaMerci_X_PickLogic
                            frmDisaccantonaMerci_X_PickLogicForm.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartGroupSeq
                    Select Case inSourceForm.GetType.Name
                        Case frmDisaccantonaMerci_5_Sel_UbiDestinazione.GetType.Name, frmDisaccantonaMerci_5_Ubi_UM_Dest.GetType.Name, frmDisaccantonaMerci_X_PickLogic.GetType.Name  '>>>> TORNO ALLO STEP DI SELEZIONE DELLA SINGOLA MISSIONE
                            frmDisaccantonaMerci_1_SelMisForm = New frmDisaccantonaMerci_1_SelMis
                            frmDisaccantonaMerci_1_SelMisForm.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case Else
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(913, "", "Direzione Step Non prevista (WizardDirectionStep).")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
            End Select

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Ope_DisaccantonamentoMerci = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Ope_DisaccantonamentoMerci = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Public Shared Function Show_Ope_PickingMerci_Approntamento(ByRef inSourceForm As Form, ByVal inWizardDirectionStep As clsDataType.WizardDirectionStepType, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Ope_PickingMerci_Approntamento = 1 'INIT AT ERROR

            Select Case inWizardDirectionStep
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext
                    Select Case inSourceForm.GetType.Name
                        Case frmMenuUscitaMerciMain.GetType.Name '>>>> VADO ALLO STEP 1
                            clsWmsJob.ClearAllData()
                            clsWmsJobsGroup.ClearAllData()
                            frmPickingMerci_Appr_1_CodMisForm = New frmPickingMerci_Appr_1_CodMis
                            frmPickingMerci_Appr_1_CodMisForm.Show()
                        Case frmPickingMerci_JobGroupList.GetType.Name
                            If (clsWmsJobsGroup.IsValidJobsGroup() = True) Then
                                frmPickingMerci_Appr_2_SelMisForm = New frmPickingMerci_Appr_2_SelMis
                                frmPickingMerci_Appr_2_SelMisForm.SourceForm = frmPickingMerci_JobGroupListForm
                                frmPickingMerci_Appr_2_SelMisForm.Show()
                            Else
                                frmPickingMerci_Appr_1_CodMisForm = New frmPickingMerci_Appr_1_CodMis
                                frmPickingMerci_Appr_1_CodMisForm.Show()
                            End If
                        Case frmPickingMerci_Appr_1_CodMis.GetType.Name '>>>> VADO ALLO STEP SUCCESSIVO
                            frmPickingMerci_Appr_2_SelMisForm = New frmPickingMerci_Appr_2_SelMis
                            frmPickingMerci_Appr_2_SelMisForm.SourceForm = frmPickingMerci_Appr_1_CodMisForm
                            frmPickingMerci_Appr_2_SelMisForm.Show()
                        Case frmPickingMerci_Appr_2_SelMis.GetType.Name, frmPickingMerci_Appr_3_SelTipoOrigine.GetType.Name   '>>>> VADO ALLO STEP SUCCESSIVO
                            If (clsWmsJob.IsPickingLogicJobs(True) = True) Or (clsWmsJob.IsPickingCheckOnlyPresenceJobs(True) = True) Then
                                'CASO PRELIEVO LOGICO
                                frmPickingMerci_Appr_X_PickLogicForm = New frmPickingMerci_Appr_X_PickLogic
                                frmPickingMerci_Appr_X_PickLogicForm.Show()
                            Else
                                'CASO PRELIEVO NORMALE (WM)
                                Select Case clsWmsJob.PickingMerciSourceType
                                    Case clsWmsJob.PickingMerci_SourceType.PickingMerci_SourceTypeCodMatEnter
                                        frmPickingMerci_Appr_4_Sel_MatnrOrigineForm = New frmPickingMerci_Appr_4_Sel_MatnrOrigine
                                        frmPickingMerci_Appr_4_Sel_MatnrOrigineForm.Show()
                                    Case clsWmsJob.PickingMerci_SourceType.PickingMerci_SourceTypeUbicazioneEnter
                                        frmPickingMerci_Appr_4_Sel_UbiOrigineForm = New frmPickingMerci_Appr_4_Sel_UbiOrigine
                                        frmPickingMerci_Appr_4_Sel_UbiOrigineForm.Show()
                                    Case clsWmsJob.PickingMerci_SourceType.PickingMerci_SourceTypeUbieUMEnter
                                        frmPickingMerci_Appr_4_Ubi_e_UM_OrigineForm = New frmPickingMerci_Appr_4_Ubi_e_UM_Origine
                                        frmPickingMerci_Appr_4_Ubi_e_UM_OrigineForm.Show()
                                    Case clsWmsJob.PickingMerci_SourceType.PickingMerci_SourceTypeUMEnter
                                        frmPickingMerci_Appr_4_Sel_UMOrigine = New frmPickingMerci_Appr_4_Sel_UMOrigine
                                        frmPickingMerci_Appr_4_Sel_UMOrigine.Show()
                                    Case clsWmsJob.PickingMerci_SourceType.PickingMerci_SourceTypeManualSelection
                                        frmPickingMerci_Appr_3_SelTipoOrigineForm = New frmPickingMerci_Appr_3_SelTipoOrigine
                                        frmPickingMerci_Appr_3_SelTipoOrigineForm.Show()
                                    Case Else
                                        ErrDescription = clsAppTranslation.GetSingleParameterValue(914, "", "Caso ") & clsAppTranslation.GetSingleParameterValue(916, "", "SouceForm Non prevista ") & "(PickingMerciSourceType)."
                                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                        RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                                End Select
                            End If
                        Case frmPickingMerci_Appr_4_Sel_MatnrOrigine.GetType.Name, frmPickingMerci_Appr_4_Sel_UbiOrigine.GetType.Name, frmPickingMerci_Appr_4_Ubi_e_UM_Origine.GetType.Name, frmPickingMerci_Appr_4_Sel_UMOrigine.GetType.Name
                            If (clsWmsJob.GetRowCountGiacenzeOriInfo(False) > 1) Then
                                '>>> CASO DI PIU' GIACENZE, DEVO SCEGLIERE QUELLA DA PRELEVARE
                                frmPickingMerci_Appr_5_SelStockForm = New frmPickingMerci_Appr_5_SelStock
                                frmPickingMerci_Appr_5_SelStockForm.Show()
                            Else
                                '>>> CASO DI UNA UNICA GIACENZA PASSO ALLA CONFERMA DELLA QTA
                                frmPickingMerci_Appr_6_ConfQtaForm = New frmPickingMerci_Appr_6_ConfQta
                                frmPickingMerci_Appr_6_ConfQtaForm.Show()
                            End If
                        Case frmPickingMerci_Appr_5_SelStock.GetType.Name '>>>> VADO ALLO STEP SUCCESSIVO
                            frmPickingMerci_Appr_6_ConfQtaForm = New frmPickingMerci_Appr_6_ConfQta
                            frmPickingMerci_Appr_6_ConfQtaForm.Show()
                        Case frmPickingMerci_Appr_6_ConfQta.GetType.Name '>>>> VADO ALLO STEP SUCCESSIVO
                            Select Case clsWmsJob.PickingMerciDestinationType
                                Case clsWmsJob.PickingMerci_DestinationType.PickingMerci_DestinationTypeUbieUMEnter
                                    frmPickingMerci_Appr_7_Ubi_UM_DestForm = New frmPickingMerci_Appr_7_Ubi_UM_Dest
                                    frmPickingMerci_Appr_7_Ubi_UM_DestForm.Show()
                                Case clsWmsJob.PickingMerci_DestinationType.PickingMerci_DestinationTypeUbicazioneEnter
                                    frmPickingMerci_Appr_7_Sel_UbiDestinazioneForm = New frmPickingMerci_Appr_7_Sel_UbiDestinazione
                                    frmPickingMerci_Appr_7_Sel_UbiDestinazioneForm.Show()
                                Case clsWmsJob.PickingMerci_DestinationType.PickingMerci_DestinationTypeUMEnter
                                    frmPickingMerci_Appr_7_Sel_UMDestinazioneForm = New frmPickingMerci_Appr_7_Sel_UMDestinazione
                                    frmPickingMerci_Appr_7_Sel_UMDestinazioneForm.Show()
                                Case Else
                                    ErrDescription = clsAppTranslation.GetSingleParameterValue(914, "", "Caso ") & clsAppTranslation.GetSingleParameterValue(916, "", "SouceForm Non prevista ") & "(PickingMerciSourceType)."
                                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                            End Select
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious
                    Select Case inSourceForm.GetType.Name
                        Case frmPickingMerci_Appr_2_SelMis.GetType.Name '>>>> TORNO ALLO STEP PRECENDENTE
                            If (frmPickingMerci_Appr_2_SelMisForm.SourceForm Is Nothing) Then
                                frmPickingMerci_Appr_1_CodMisForm = New frmPickingMerci_Appr_1_CodMis
                                frmPickingMerci_Appr_1_CodMisForm.Show()
                            Else
                                Select Case frmPickingMerci_Appr_2_SelMisForm.SourceForm.GetType.Name
                                    Case frmPickingMerci_Appr_1_CodMis.GetType.Name
                                        frmPickingMerci_Appr_1_CodMisForm = New frmPickingMerci_Appr_1_CodMis
                                        frmPickingMerci_Appr_1_CodMisForm.Show()
                                    Case frmPickingMerci_JobGroupList.GetType.Name
                                        frmPickingMerci_JobGroupListForm = New frmPickingMerci_JobGroupList
                                        frmPickingMerci_JobGroupListForm.Show()
                                    Case Else
                                        ErrDescription = clsAppTranslation.GetSingleParameterValue(914, "", "Caso ") & clsAppTranslation.GetSingleParameterValue(916, "", "SouceForm Non prevista ") & "(frmPickingMerci_Appr_2_SelMisForm.SourceForm)."
                                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                        RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                                End Select
                            End If
                        Case frmPickingMerci_Appr_3_SelTipoOrigine.GetType.Name
                            frmPickingMerci_Appr_2_SelMisForm = New frmPickingMerci_Appr_2_SelMis
                            frmPickingMerci_Appr_2_SelMisForm.Show()
                        Case frmPickingMerci_Appr_4_Sel_MatnrOrigine.GetType.Name, frmPickingMerci_Appr_4_Sel_UbiOrigine.GetType.Name, frmPickingMerci_Appr_4_Ubi_e_UM_Origine.GetType.Name, frmPickingMerci_Appr_4_Sel_UMOrigine.GetType.Name
                            frmPickingMerci_Appr_2_SelMisForm = New frmPickingMerci_Appr_2_SelMis
                            frmPickingMerci_Appr_2_SelMisForm.Show()
                        Case frmPickingMerci_Appr_5_SelStock.GetType.Name '>>>> TORNO ALLO STEP PRECENDENTE
                            Select Case clsWmsJob.PickingMerciSourceType
                                Case clsWmsJob.PickingMerci_SourceType.PickingMerci_SourceTypeCodMatEnter
                                    frmPickingMerci_Appr_4_Sel_MatnrOrigineForm = New frmPickingMerci_Appr_4_Sel_MatnrOrigine
                                    frmPickingMerci_Appr_4_Sel_MatnrOrigineForm.Show()
                                Case clsWmsJob.PickingMerci_SourceType.PickingMerci_SourceTypeUbicazioneEnter
                                    frmPickingMerci_Appr_4_Sel_UbiOrigineForm = New frmPickingMerci_Appr_4_Sel_UbiOrigine
                                    frmPickingMerci_Appr_4_Sel_UbiOrigineForm.Show()
                                Case clsWmsJob.PickingMerci_SourceType.PickingMerci_SourceTypeUbieUMEnter
                                    frmPickingMerci_Appr_4_Ubi_e_UM_OrigineForm = New frmPickingMerci_Appr_4_Ubi_e_UM_Origine
                                    frmPickingMerci_Appr_4_Ubi_e_UM_OrigineForm.Show()
                                Case clsWmsJob.PickingMerci_SourceType.PickingMerci_SourceTypeUMEnter
                                    frmPickingMerci_Appr_4_Sel_UMOrigine = New frmPickingMerci_Appr_4_Sel_UMOrigine
                                    frmPickingMerci_Appr_4_Sel_UMOrigine.Show()
                                Case clsWmsJob.PickingMerci_SourceType.PickingMerci_SourceTypeManualSelection
                                    frmPickingMerci_Appr_3_SelTipoOrigineForm = New frmPickingMerci_Appr_3_SelTipoOrigine
                                    frmPickingMerci_Appr_3_SelTipoOrigineForm.Show()
                                Case Else
                                    ErrDescription = clsAppTranslation.GetSingleParameterValue(914, "", "Caso ") & clsAppTranslation.GetSingleParameterValue(916, "", "SouceForm Non prevista ") & "(PickingMerciSourceType)."
                                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                            End Select
                        Case frmPickingMerci_Appr_6_ConfQta.GetType.Name '>>>> TORNO ALLO STEP PRECENDENTE
                            If (clsWmsJob.GetRowCountGiacenzeOriInfo(False) > 1) Then
                                '>>> CASO DI PIU' GIACENZE
                                frmPickingMerci_Appr_5_SelStockForm = New frmPickingMerci_Appr_5_SelStock
                                frmPickingMerci_Appr_5_SelStockForm.Show()
                            Else
                                '>>> CASO DI UNA UNICA GIACENZA
                                Select Case clsWmsJob.PickingMerciSourceType
                                    Case clsWmsJob.PickingMerci_SourceType.PickingMerci_SourceTypeCodMatEnter
                                        frmPickingMerci_Appr_4_Sel_MatnrOrigineForm = New frmPickingMerci_Appr_4_Sel_MatnrOrigine
                                        frmPickingMerci_Appr_4_Sel_MatnrOrigineForm.Show()
                                    Case clsWmsJob.PickingMerci_SourceType.PickingMerci_SourceTypeUbicazioneEnter
                                        frmPickingMerci_Appr_4_Sel_UbiOrigineForm = New frmPickingMerci_Appr_4_Sel_UbiOrigine
                                        frmPickingMerci_Appr_4_Sel_UbiOrigineForm.Show()
                                    Case clsWmsJob.PickingMerci_SourceType.PickingMerci_SourceTypeUbieUMEnter
                                        frmPickingMerci_Appr_4_Ubi_e_UM_OrigineForm = New frmPickingMerci_Appr_4_Ubi_e_UM_Origine
                                        frmPickingMerci_Appr_4_Ubi_e_UM_OrigineForm.Show()
                                    Case clsWmsJob.PickingMerci_SourceType.PickingMerci_SourceTypeUMEnter
                                        frmPickingMerci_Appr_4_Sel_UMOrigine = New frmPickingMerci_Appr_4_Sel_UMOrigine
                                        frmPickingMerci_Appr_4_Sel_UMOrigine.Show()
                                    Case clsWmsJob.PickingMerci_SourceType.PickingMerci_SourceTypeManualSelection
                                        frmPickingMerci_Appr_3_SelTipoOrigineForm = New frmPickingMerci_Appr_3_SelTipoOrigine
                                        frmPickingMerci_Appr_3_SelTipoOrigineForm.Show()
                                    Case Else
                                        ErrDescription = clsAppTranslation.GetSingleParameterValue(914, "", "Caso ") & clsAppTranslation.GetSingleParameterValue(916, "", "SouceForm Non prevista ") & "(PickingMerciSourceType)."
                                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                        RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                                End Select
                            End If
                        Case frmPickingMerci_Appr_7_Sel_UbiDestinazione.GetType.Name, frmPickingMerci_Appr_7_Sel_UMDestinazione.GetType.Name, frmPickingMerci_Appr_7_Ubi_UM_Dest.GetType.Name '>>>> TORNO ALLO STEP PRECENDENTE
                            frmPickingMerci_Appr_6_ConfQtaForm = New frmPickingMerci_Appr_6_ConfQta
                            frmPickingMerci_Appr_6_ConfQtaForm.Show()
                        Case frmPickingMerci_Appr_X_PickLogic.GetType.Name
                            frmPickingMerci_Appr_2_SelMisForm = New frmPickingMerci_Appr_2_SelMis
                            frmPickingMerci_Appr_2_SelMisForm.Show()
                        Case frmPickingMerci_Appr_ChiudiLista.GetType.Name
                            frmPickingMerci_Appr_2_SelMisForm = New frmPickingMerci_Appr_2_SelMis
                            frmPickingMerci_Appr_2_SelMisForm.SourceForm = frmPickingMerci_JobGroupListForm
                            frmPickingMerci_Appr_2_SelMisForm.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartSeq
                    Select Case inSourceForm.GetType.Name
                        Case frmPickingMerci_Appr_7_Sel_UbiDestinazione.GetType.Name, frmPickingMerci_Appr_7_Sel_UMDestinazione.GetType.Name, frmPickingMerci_Appr_7_Ubi_UM_Dest.GetType.Name, frmPickingMerci_Appr_8_Rietichettatura.GetType.Name       '>>>> TORNO ALLO STEP DI SCELTA DEL MATERIALE DA PRELEVARE
                            Select Case clsWmsJob.PickingMerciSourceType
                                Case clsWmsJob.PickingMerci_SourceType.PickingMerci_SourceTypeCodMatEnter
                                    frmPickingMerci_Appr_4_Sel_MatnrOrigineForm = New frmPickingMerci_Appr_4_Sel_MatnrOrigine
                                    frmPickingMerci_Appr_4_Sel_MatnrOrigineForm.Show()
                                Case clsWmsJob.PickingMerci_SourceType.PickingMerci_SourceTypeUbicazioneEnter
                                    frmPickingMerci_Appr_4_Sel_UbiOrigineForm = New frmPickingMerci_Appr_4_Sel_UbiOrigine
                                    frmPickingMerci_Appr_4_Sel_UbiOrigineForm.Show()
                                Case clsWmsJob.PickingMerci_SourceType.PickingMerci_SourceTypeUbieUMEnter
                                    frmPickingMerci_Appr_4_Ubi_e_UM_OrigineForm = New frmPickingMerci_Appr_4_Ubi_e_UM_Origine
                                    frmPickingMerci_Appr_4_Ubi_e_UM_OrigineForm.Show()
                                Case clsWmsJob.PickingMerci_SourceType.PickingMerci_SourceTypeUMEnter
                                    frmPickingMerci_Appr_4_Sel_UMOrigine = New frmPickingMerci_Appr_4_Sel_UMOrigine
                                    frmPickingMerci_Appr_4_Sel_UMOrigine.Show()
                                Case clsWmsJob.PickingMerci_SourceType.PickingMerci_SourceTypeManualSelection
                                    frmPickingMerci_Appr_3_SelTipoOrigineForm = New frmPickingMerci_Appr_3_SelTipoOrigine
                                    frmPickingMerci_Appr_3_SelTipoOrigineForm.Show()
                                Case Else
                                    ErrDescription = clsAppTranslation.GetSingleParameterValue(914, "", "Caso ") & clsAppTranslation.GetSingleParameterValue(916, "", "SouceForm Non prevista ") & "(PickingMerciSourceType)."
                                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                            End Select
                        Case frmPickingMerci_Appr_X_PickLogic.GetType.Name
                            frmPickingMerci_Appr_X_PickLogicForm = New frmPickingMerci_Appr_X_PickLogic
                            frmPickingMerci_Appr_X_PickLogicForm.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartGroupSeq
                    Select Case inSourceForm.GetType.Name
                        Case frmPickingMerci_Appr_7_Sel_UbiDestinazione.GetType.Name, frmPickingMerci_Appr_7_Sel_UMDestinazione.GetType.Name, frmPickingMerci_Appr_7_Ubi_UM_Dest.GetType.Name, frmPickingMerci_Appr_X_PickLogic.GetType.Name, frmPickingMerci_Appr_8_Rietichettatura.GetType.Name, frmPickingMerci_Appr_ChiudiLista.GetType.Name   '>>>> TORNO ALLO STEP DI SELEZIONE DELLA SINGOLA MISSIONE
                            frmPickingMerci_Appr_2_SelMisForm = New frmPickingMerci_Appr_2_SelMis
                            frmPickingMerci_Appr_2_SelMisForm.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeInitSeq
                    clsWmsJob.ClearAllData()
                    clsWmsJobsGroup.ClearAllData()
                    frmPickingMerci_Appr_1_CodMisForm = New frmPickingMerci_Appr_1_CodMis
                    frmPickingMerci_Appr_1_CodMisForm.Show()
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeCloseGroupSeq
                    frmPickingMerci_Appr_ChiudiListaForm = New frmPickingMerci_Appr_ChiudiLista
                    frmPickingMerci_Appr_ChiudiListaForm.Show()
                Case Else
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(913, "", "Direzione Step Non prevista (WizardDirectionStep).")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
            End Select

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Ope_PickingMerci_Approntamento = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Ope_PickingMerci_Approntamento = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Public Shared Function Show_Ope_PickingMerci_Code(ByRef inSourceForm As Form, ByVal inWizardDirectionStep As clsDataType.WizardDirectionStepType, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkSourceForm As Form
        Dim PickingNeedConfirmQty As Boolean = False
        Dim AllTaskLinesAreFinish As Boolean = False
        Dim FlagErroreAttivo As Boolean = False
        Dim NavigationDoneOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Ope_PickingMerci_Code = 1 'INIT AT ERROR

            Select Case inWizardDirectionStep
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext
                    Select Case inSourceForm.GetType.Name
                        Case frmMenuUscitaMerciMainWin.GetType.Name '>>>> VADO ALLO STEP 1
                            clsWmsJob.ClearAllData()
                            clsWmsJobsGroup.ClearAllData()
                            frmPickingMerci_Code_1_SettingsForm = New frmPickingMerci_Code_1_Settings
                            frmPickingMerci_Code_1_SettingsForm.Show()
                        Case frmPickingMerci_Code_1_Settings.GetType.Name '>>>> VADO ALLO STEP 2
                            frmPickingMerci_Code_2_SelMisForm = New frmPickingMerci_Code_2_SelMis
                            frmPickingMerci_Code_2_SelMisForm.Show()
                        Case frmPickingMerci_Code_2_SelMis.GetType.Name '>>>> VADO ALLO STEP 3
                            frmPickingMerci_Code_3_SelUDSForm = New frmPickingMerci_Code_3_SelUDS
                            frmPickingMerci_Code_3_SelUDSForm.Show()
                        Case frmPickingMerci_Code_3_SelUDS.GetType.Name '>>>> VADO ALLO STEP 4
                            frmPickingMerci_Code_4_Sel_UMOrigineForm = New frmPickingMerci_Code_4_Sel_UMOrigine
                            frmPickingMerci_Code_4_Sel_UMOrigineForm.Show()
                        Case frmPickingMerci_Code_4_Sel_UMOrigine.GetType.Name '>>>> VADO ALLO STEP 5
                            If (clsWmsJob.UbicaOrUnitaMagEntered = clsDataType.UbicaOrUnitaMagEnteredEnum.UbicaOrUnitaMagEnteredUnitaMagazzino) Then
                                'CASO IN CUI L'OPERATORE HA DIGITATO IL CODICE DELLA PALETTA
                                RetCode = clsWmsJob.CheckPickingNeedConfirmQty(PickingNeedConfirmQty, False)
                                If (PickingNeedConfirmQty = True) Then
                                    'PALETTA NON INTERA , DEVO CONFERMARA LA QTA
                                    frmPickingMerci_Code_7_ConfQtaForm = New frmPickingMerci_Code_7_ConfQta
                                    frmPickingMerci_Code_7_ConfQtaForm.Show()
                                Else
                                    'PALETTA INTERA , NON DEVO CONFERMARE LA QTA , POSSO FARE IL MOVIMENTO DI PICK INTO UDS ( LO METTO NEL  FORKLIFT )
                                    clsWmsJob.NavigationExecJobPickIntoUDS(inSourceForm, NavigationDoneOk, FlagErroreAttivo)
                                    'frmPickingMerci_Code_DropUDSForm = New frmPickingMerci_Code_DropUDS
                                    'frmPickingMerci_Code_DropUDSForm.SourceForm = inSourceForm
                                    'frmPickingMerci_Code_DropUDSForm.Show()
                                End If
                            ElseIf (clsWmsJob.UbicaOrUnitaMagEntered = clsDataType.UbicaOrUnitaMagEnteredEnum.UbicaOrUnitaMagEnteredUbicazione) Then
                                'CASO IN CUI L'OPERATORE HA DIGITATO L'UBICAZIONE 
                                frmPickingMerci_Code_5_Sel_CodMatOrigineForm = New frmPickingMerci_Code_5_Sel_CodMatOrigine
                                frmPickingMerci_Code_5_Sel_CodMatOrigineForm.Show()
                            Else
                                'CASO NON PREVISTO
                                frmPickingMerci_Code_5_Sel_CodMatOrigineForm = New frmPickingMerci_Code_5_Sel_CodMatOrigine
                                frmPickingMerci_Code_5_Sel_CodMatOrigineForm.Show()
                            End If
                        Case frmPickingMerci_Code_5_Sel_CodMatOrigine.GetType.Name '>>>> VADO ALLO STEP 6
                            If (clsWmsJob.SkuOrUnitaMagEntered = clsDataType.SkuOrUnitaMagEnteredEnum.SkuOrUnitaMagEnteredUnitaMagazzino) Then
                                'CASO IN CUI L'OPERATORE HA DIGITATO IL CODICE DELLA PALETTA
                                RetCode = clsWmsJob.CheckPickingNeedConfirmQty(PickingNeedConfirmQty, False)
                                If (PickingNeedConfirmQty = True) Then
                                    'PALETTA NON INTERA , DEVO CONFERMARA LA QTA
                                    frmPickingMerci_Code_7_ConfQtaForm = New frmPickingMerci_Code_7_ConfQta
                                    frmPickingMerci_Code_7_ConfQtaForm.Show()
                                Else
                                    'PALETTA INTERA , NON DEVO CONFERMARE LA QTA , POSSO FARE IL MOVIMENTO DI PICK INTO UDS ( LO METTO NEL  FORKLIFT )
                                    clsWmsJob.NavigationExecJobPickIntoUDS(inSourceForm, NavigationDoneOk, FlagErroreAttivo)
                                End If
                            Else
                                If (clsWmsJob.SkuOrUnitaMagEntered = clsDataType.SkuOrUnitaMagEnteredEnum.SkuOrUnitaMagEnteredSku) And (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.AbilitaUnitaMagazzino = False) Then
                                    'PALETTA NON INTERA , DEVO CONFERMARA LA QTA
                                    frmPickingMerci_Code_7_ConfQtaForm = New frmPickingMerci_Code_7_ConfQta
                                    frmPickingMerci_Code_7_ConfQtaForm.Show()
                                Else
                                    If (clsWmsJob.FlagFoundOneStockWithSKU = True) Then
                                        'CASO IN CUI L'OPERATORE HA DIGITATO IL CODICE SKU E HO SOLO UNA PALLET ID
                                        frmPickingMerci_Code_7_ConfQtaForm = New frmPickingMerci_Code_7_ConfQta
                                        frmPickingMerci_Code_7_ConfQtaForm.Show()
                                    Else
                                        'CASO IN CUI L'OPERATORE HA DIGITATO IL CODICE SKU E HO PIU' DI UNA GIACENZA (DEVO SPECIFICARE LA PALLET ID) 
                                        frmPickingMerci_Code_6_Sel_UMOrigineForm = New frmPickingMerci_Code_6_Sel_UMOrigine
                                        frmPickingMerci_Code_6_Sel_UMOrigineForm.Show()
                                    End If
                                End If
                            End If
                        Case frmPickingMerci_Code_6_Sel_UMOrigine.GetType.Name '>>>> VADO ALLO STEP 7
                            'CASO IN CUI L'OPERATORE HA DIGITATO IL CODICE DELLA PALETTA
                            RetCode = clsWmsJob.CheckPickingNeedConfirmQty(PickingNeedConfirmQty, False)
                            If (PickingNeedConfirmQty = True) Then
                                'PALETTA NON INTERA , DEVO CONFERMARA LA QTA
                                frmPickingMerci_Code_7_ConfQtaForm = New frmPickingMerci_Code_7_ConfQta
                                frmPickingMerci_Code_7_ConfQtaForm.Show()
                            Else
                                'PALETTA INTERA , NON DEVO CONFERMARE LA QTA , POSSO FARE IL MOVIMENTO DI PICK INTO UDS ( LO METTO NEL  FORKLIFT )
                                clsWmsJob.NavigationExecJobPickIntoUDS(inSourceForm, NavigationDoneOk, FlagErroreAttivo)
                            End If
                        Case frmPickingMerci_Code_7_ConfQta.GetType.Name
                            frmPickingMerci_Code_DropUDSForm = New frmPickingMerci_Code_DropUDS
                            frmPickingMerci_Code_DropUDSForm.SourceForm = inSourceForm
                            frmPickingMerci_Code_DropUDSForm.Show()
                        Case frmPickingMerci_Code_DropUDS.GetType.Name
                            RetCode = clsWmsJob.TaskLines.CheckIfAllTaskLinesAreFinish(clsWmsJob.WmsJob.NrWmsJobs, AllTaskLinesAreFinish, False)
                            If (AllTaskLinesAreFinish = True) Then
                                'CASO NON NORMALE, RITORNO ALL'ELENCO  DELLE MISSIONI
                                frmPickingMerci_Code_2_SelMisForm = New frmPickingMerci_Code_2_SelMis
                                frmPickingMerci_Code_2_SelMisForm.Show()
                            Else
                                'SE LE TASK LINES SONO TERMINATE ALLORA VADO ALLA PROSSIMA MISSIONE
                                frmPickingMerci_Code_3_SelUDSForm = New frmPickingMerci_Code_3_SelUDS
                                frmPickingMerci_Code_3_SelUDSForm.Show()
                            End If
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious
                    Select Case inSourceForm.GetType.Name
                        Case frmPickingMerci_Code_DropUDS.GetType.Name
                            WorkSourceForm = Nothing
                            If (Not frmPickingMerci_Code_DropUDS.SourceForm Is Nothing) Then
                                WorkSourceForm = frmPickingMerci_Code_DropUDS.SourceForm
                            End If
                            If (WorkSourceForm Is Nothing) Then
                                'CASO NON NORMALE, RITORNO ALL'ELENCO  DELLE MISSIONI
                                frmPickingMerci_Code_2_SelMisForm = New frmPickingMerci_Code_2_SelMis
                                frmPickingMerci_Code_2_SelMisForm.Show()
                            ElseIf (WorkSourceForm.GetType.Name = frmPickingMerci_Code_3_SelUDS.Name) Then
                                frmPickingMerci_Code_3_SelUDSForm = New frmPickingMerci_Code_3_SelUDS
                                frmPickingMerci_Code_3_SelUDSForm.Show()
                            ElseIf (WorkSourceForm.GetType.Name = frmPickingMerci_Code_4_Sel_UMOrigine.Name) Then
                                frmPickingMerci_Code_4_Sel_UMOrigineForm = New frmPickingMerci_Code_4_Sel_UMOrigine
                                frmPickingMerci_Code_4_Sel_UMOrigineForm.Show()
                            ElseIf (WorkSourceForm.GetType.Name = frmPickingMerci_Code_5_Sel_CodMatOrigine.Name) Then
                                frmPickingMerci_Code_5_Sel_CodMatOrigineForm = New frmPickingMerci_Code_5_Sel_CodMatOrigine
                                frmPickingMerci_Code_5_Sel_CodMatOrigineForm.Show()
                            ElseIf (WorkSourceForm.GetType.Name = frmPickingMerci_Code_6_Sel_UMOrigine.Name) Then
                                frmPickingMerci_Code_6_Sel_UMOrigineForm = New frmPickingMerci_Code_6_Sel_UMOrigine
                                frmPickingMerci_Code_6_Sel_UMOrigineForm.Show()
                            ElseIf (WorkSourceForm.GetType.Name = frmPickingMerci_Code_7_ConfQta.Name) Then
                                frmPickingMerci_Code_7_ConfQtaForm = New frmPickingMerci_Code_7_ConfQta
                                frmPickingMerci_Code_7_ConfQtaForm.Show()
                            End If
                        Case frmPickingMerci_Code_7_ConfQta.GetType.Name
                            frmPickingMerci_Code_6_Sel_UMOrigineForm = New frmPickingMerci_Code_6_Sel_UMOrigine
                            frmPickingMerci_Code_6_Sel_UMOrigineForm.Show()
                        Case frmPickingMerci_Code_6_Sel_UMOrigine.GetType.Name
                            frmPickingMerci_Code_5_Sel_CodMatOrigineForm = New frmPickingMerci_Code_5_Sel_CodMatOrigine
                            frmPickingMerci_Code_5_Sel_CodMatOrigineForm.Show()
                        Case frmPickingMerci_Code_5_Sel_CodMatOrigine.GetType.Name
                            frmPickingMerci_Code_4_Sel_UMOrigineForm = New frmPickingMerci_Code_4_Sel_UMOrigine
                            frmPickingMerci_Code_4_Sel_UMOrigineForm.Show()
                        Case frmPickingMerci_Code_4_Sel_UMOrigine.GetType.Name
                            frmPickingMerci_Code_3_SelUDSForm = New frmPickingMerci_Code_3_SelUDS
                            frmPickingMerci_Code_3_SelUDSForm.Show()
                        Case frmPickingMerci_Code_3_SelUDS.GetType.Name
                            frmPickingMerci_Code_2_SelMisForm = New frmPickingMerci_Code_2_SelMis
                            frmPickingMerci_Code_2_SelMisForm.Show()
                        Case frmPickingMerci_Code_2_SelMis.GetType.Name
                            frmPickingMerci_Code_1_SettingsForm = New frmPickingMerci_Code_1_Settings
                            frmPickingMerci_Code_1_SettingsForm.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select

                Case WizardDirectionStepType.WizardDirectionStepTypeStartNewUDS
                    ' >>> CASO IN CUI HO DROPPATO LA UDS E NE DEVO LEGGERE UNA NUOVA
                    Select Case inSourceForm.GetType.Name
                        Case frmPickingMerci_Code_3_SelUDS.GetType.Name, frmPickingMerci_Code_4_Sel_UMOrigine.GetType.Name, frmPickingMerci_Code_5_Sel_CodMatOrigine.GetType.Name, frmPickingMerci_Code_7_ConfQta.GetType.Name, frmPickingMerci_Code_DropUDS.GetType.Name       '>>>> TORNO ALLO STEP DI SCELTA DEL MATERIALE DA PRELEVARE
                            frmPickingMerci_Code_3_SelUDSForm = New frmPickingMerci_Code_3_SelUDS
                            frmPickingMerci_Code_3_SelUDSForm.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case WizardDirectionStepType.WizardDirectionStepTypeDropUDS
                    frmPickingMerci_Code_DropUDSForm = New frmPickingMerci_Code_DropUDS
                    frmPickingMerci_Code_DropUDSForm.SourceForm = inSourceForm
                    frmPickingMerci_Code_DropUDSForm.Show()
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartSeq
                    ' >>> CASO IN CUI HO FINITO LA SINGOLA TASK LINES - O DEVO INIZIARE UN NUOVO PRELIEVO
                    If (clsWmsJob.IsPickingLogicJobs(False) = True) Then
                        'CASO PRELEVO ROBA NON WM ( SOLO CONFERMA QTA )
                        frmPickingMerci_Appr_X_PickLogicForm = New frmPickingMerci_Appr_X_PickLogic
                        frmPickingMerci_Appr_X_PickLogicForm.Show()
                    Else
                        'CASO NORMALE : PRELIEVO ROBA WM
                        frmPickingMerci_Code_4_Sel_UMOrigineForm = New frmPickingMerci_Code_4_Sel_UMOrigine
                        frmPickingMerci_Code_4_Sel_UMOrigineForm.Show()
                    End If
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartGroupSeq
                    '>>> CASO IN CUI HO FINITO LE TASK LINES DEL JOB E SELEZIONO UN NUOVO JOB DA ESEGUIRE
                    frmPickingMerci_Code_2_SelMisForm = New frmPickingMerci_Code_2_SelMis
                    frmPickingMerci_Code_2_SelMisForm.Show()
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeInitSeq
                    clsWmsJob.ClearAllData()
                    clsWmsJobsGroup.ClearAllData()
                    frmPickingMerci_Code_1_SettingsForm = New frmPickingMerci_Code_1_Settings
                    frmPickingMerci_Code_1_SettingsForm.Show()
                Case Else
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(913, "", "Direzione Step Non prevista (WizardDirectionStep).")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
            End Select

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Ope_PickingMerci_Code = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Ope_PickingMerci_Code = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function


    Public Shared Function Show_Ope_PickingMerci_MoveUDS(ByRef inSourceForm As Form, ByVal inWizardDirectionStep As clsDataType.WizardDirectionStepType, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Ope_PickingMerci_MoveUDS = 1 'INIT AT ERROR

            Select Case inWizardDirectionStep
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext
                    Select Case inSourceForm.GetType.Name
                        Case frmMenuUscitaMerciMainWin.GetType.Name '>>>> VADO ALLO STEP 1
                            clsMoveUDS.ClearAllData()
                            frmPickingMerci_MoveUDS_1_UM_OriForm = New frmPickingMerci_MoveUDS_1_UM_Ori
                            frmPickingMerci_MoveUDS_1_UM_OriForm.Show()
                        Case frmPickingMerci_MoveUDS_1_UM_Ori.GetType.Name '>>>> VADO ALLO STEP 2
                            'clsMoveUDS.ClearAllData()
                            frmPickingMerci_MoveUDS_2_UBI_DestForm = New frmPickingMerci_MoveUDS_2_UBI_Dest
                            frmPickingMerci_MoveUDS_2_UBI_DestForm.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious
                    Select Case inSourceForm.GetType.Name
                        Case frmPickingMerci_MoveUDS_2_UBI_Dest.GetType.Name
                            clsMoveUDS.ClearAllData()
                            frmPickingMerci_MoveUDS_1_UM_OriForm = New frmPickingMerci_MoveUDS_1_UM_Ori
                            frmPickingMerci_MoveUDS_1_UM_OriForm.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select

            End Select

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Ope_PickingMerci_MoveUDS = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Ope_PickingMerci_MoveUDS = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Public Shared Function Show_Ope_PickingMerci_ChangeUDS(ByRef inSourceForm As Form, ByVal inFunctionChangeUDSType As FunctionChangeUDSType, ByVal inWizardDirectionStep As clsDataType.WizardDirectionStepType, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Ope_PickingMerci_ChangeUDS = 1 'INIT AT ERROR

            Select Case inWizardDirectionStep
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext
                    Select Case inSourceForm.GetType.Name
                        Case frmMenuUscitaMerciMainWin.GetType.Name '>>>> VADO ALLO STEP 1
                            clsChangeUDS.ClearAllData()
                            frmPickingMerci_ChangeUDS_1_UM_OriForm = New frmPickingMerci_ChangeUDS_1_UM_Ori
                            frmPickingMerci_ChangeUDS_1_UM_OriForm.Show()
                        Case frmPickingMerci_ChangeUDS_1_UM_Ori.GetType.Name '>>>> VADO ALLO STEP 2
                            'clsMoveUDS.ClearAllData()
                            frmPickingMerci_ChangeUDS_2_UM_OperForm = New frmPickingMerci_ChangeUDS_2_UM_Oper
                            frmPickingMerci_ChangeUDS_2_UM_OperForm.Show()
                        Case frmPickingMerci_ChangeUDS_2_UM_Oper.GetType.Name '>>>> VADO ALLO STEP 3
                            'clsMoveUDS.ClearAllData()
                            Select Case inFunctionChangeUDSType
                                Case clsChangeUDS.FunctionChangeUDSType.FunctionChnageUDSTypeAdd
                                    frmPickingMerci_ChangeUDS_Add_UM_SelForm = New frmPickingMerci_ChangeUDS_Add_UM_Sel
                                    frmPickingMerci_ChangeUDS_Add_UM_SelForm.Show()
                                Case clsChangeUDS.FunctionChangeUDSType.FunctionChnageUDSTypeMinus
                                    frmPickingMerci_ChangeUDS_Minus_UM_SelForm = New frmPickingMerci_ChangeUDS_Minus_UM_Sel
                                    frmPickingMerci_ChangeUDS_Minus_UM_SelForm.Show()
                                Case clsChangeUDS.FunctionChangeUDSType.FunctionChnageUDSTypeUnion
                                    frmPickingMerci_ChangeUDS_Union_UMForm = New frmPickingMerci_ChangeUDS_Union_UM
                                    frmPickingMerci_ChangeUDS_Union_UMForm.Show()
                                Case Else
                                    ErrDescription = clsAppTranslation.GetSingleParameterValue(914, "", "Caso ") & clsAppTranslation.GetSingleParameterValue(916, "", "SouceForm Non prevista ") & "(PickingMerciSourceType)."
                                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE	
                            End Select
                        Case frmPickingMerci_ChangeUDS_Union_UM.GetType.Name
                            frmPickingMerci_ChangeUDS_2_UM_OperForm = New frmPickingMerci_ChangeUDS_2_UM_Oper
                            frmPickingMerci_ChangeUDS_2_UM_OperForm.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select

                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious
                    Select Case inSourceForm.GetType.Name
                        Case frmPickingMerci_ChangeUDS_Union_UM.GetType.Name '>>>> VADO ALLO STEP ...
                            'clsMoveUDS.ClearAllData()
                            frmPickingMerci_ChangeUDS_2_UM_OperForm = New frmPickingMerci_ChangeUDS_2_UM_Oper
                            frmPickingMerci_ChangeUDS_2_UM_OperForm.Show()
                        Case frmPickingMerci_ChangeUDS_Add_UM_Sel.GetType.Name '>>>> VADO ALLO STEP ...
                            'clsMoveUDS.ClearAllData()
                            frmPickingMerci_ChangeUDS_2_UM_OperForm = New frmPickingMerci_ChangeUDS_2_UM_Oper
                            frmPickingMerci_ChangeUDS_2_UM_OperForm.Show()
                        Case frmPickingMerci_ChangeUDS_Minus_UM_Sel.GetType.Name '>>>> VADO ALLO STEP ...
                            'clsMoveUDS.ClearAllData()
                            frmPickingMerci_ChangeUDS_2_UM_OperForm = New frmPickingMerci_ChangeUDS_2_UM_Oper
                            frmPickingMerci_ChangeUDS_2_UM_OperForm.Show()
                        Case frmPickingMerci_ChangeUDS_2_UM_Oper.GetType.Name '>>>> VADO ALLO STEP ...
                            'clsMoveUDS.ClearAllData()
                            frmPickingMerci_ChangeUDS_1_UM_OriForm = New frmPickingMerci_ChangeUDS_1_UM_Ori
                            frmPickingMerci_ChangeUDS_1_UM_OriForm.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select

            End Select

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Ope_PickingMerci_ChangeUDS = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Ope_PickingMerci_ChangeUDS = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Public Shared Function Show_Ope_PickingMerci_TruckLoad(ByRef inSourceForm As Form, ByVal inWizardDirectionStep As clsDataType.WizardDirectionStepType, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Ope_PickingMerci_TruckLoad = 1 'INIT AT ERROR

            Select Case inWizardDirectionStep
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext
                    Select Case inSourceForm.GetType.Name
                        Case frmMenuUscitaMerciMainWin.GetType.Name '>>>> VADO ALLO STEP 1
                            clsTruckLoad.ClearAllData()
                            frmTruckLoad_1_UM_SelForm = New frmTruckLoad_1_UM_Sel
                            frmTruckLoad_1_UM_SelForm.Show()
                        Case frmTruckLoad_1_UM_Sel.GetType.Name '>>>> VADO ALLO STEP 2
                            'clsTruckLoad.ClearAllData()
                            frmTruckLoad_2_UBI_DestForm = New frmTruckLoad_2_UBI_Dest
                            frmTruckLoad_2_UBI_DestForm.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious
                    Select Case inSourceForm.GetType.Name
                        Case frmTruckLoad_2_UBI_Dest.GetType.Name
                            clsTruckLoad.ClearAllData()
                            frmTruckLoad_1_UM_SelForm = New frmTruckLoad_1_UM_Sel
                            frmTruckLoad_1_UM_SelForm.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select

            End Select

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Ope_PickingMerci_TruckLoad = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Ope_PickingMerci_TruckLoad = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function


    Public Shared Function Show_Ope_TRASF_MAT(ByRef inSourceForm As Form, ByVal inFunctionTransferType As clsDataType.FunctionTransferMaterialType, ByVal inWizardDirectionStep As clsDataType.WizardDirectionStepType, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Ope_TRASF_MAT = 1 'INIT AT ERROR

            Select Case inWizardDirectionStep
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext
                    Select Case inSourceForm.GetType.Name
                        Case frmMenuTrasferMain.GetType.Name '>>>> VADO ALLO STEP 1
                            frmTRASF_MAT_Part_1Form = New frmTRASF_MAT_Part_1
                            clsTrasfMat.ClearAllData() 'INIT
                            clsTrasfMat.FunctionTransferMaterialType = inFunctionTransferType
                            frmTRASF_MAT_Part_1Form.Show()
                        Case frmTRASF_MAT_Part_1.GetType.Name '>>>> VADO ALLO STEP 2
                            If (Default_TRASF_EnableConfCodMat = True) Then
                                frmTRASF_MAT_Part_2_ConfCodMatForm = New frmTRASF_MAT_Part_2_ConfCodMat
                                frmTRASF_MAT_Part_2_ConfCodMatForm.Show()
                            Else
                                If (clsTrasfMat.GetNumRecTableGiacenzeInfo() > 1) Then
                                    frmTRASF_MAT_Part_3_SelStockForm = New frmTRASF_MAT_Part_3_SelStock
                                    frmTRASF_MAT_Part_3_SelStockForm.Show()
                                Else
                                    frmTRASF_MAT_Part_4_ConfQtaForm = New frmTRASF_MAT_Part_4_ConfQta
                                    frmTRASF_MAT_Part_4_ConfQtaForm.Show()
                                End If
                            End If
                        Case frmTRASF_MAT_Part_2_ConfCodMat.GetType.Name '>>>> VADO ALLO STEP 3/4
                            If (clsTrasfMat.GetNumRecTableGiacenzeInfo() > 1) Then
                                'CASO IN CUI DEVO SPECIFICARE IL QUANT
                                frmTRASF_MAT_Part_3_SelStockForm = New frmTRASF_MAT_Part_3_SelStock
                                frmTRASF_MAT_Part_3_SelStockForm.Show()
                            Else
                                '>>> CASO DI TRASFERIMENTO GENERICO
                                frmTRASF_MAT_Part_4_ConfQtaForm = New frmTRASF_MAT_Part_4_ConfQta
                                frmTRASF_MAT_Part_4_ConfQtaForm.Show()
                            End If
                        Case frmTRASF_MAT_Part_3_SelStock.GetType.Name
                            frmTRASF_MAT_Part_4_ConfQtaForm = New frmTRASF_MAT_Part_4_ConfQta
                            frmTRASF_MAT_Part_4_ConfQtaForm.Show()
                        Case frmTRASF_MAT_Part_4_ConfQta.GetType.Name
                            frmTRASF_MAT_Part_6_Final_ConfirmForm = New frmTRASF_MAT_Part_6_Final_Confirm
                            frmTRASF_MAT_Part_6_Final_ConfirmForm.Show()
                        Case frmTRASF_MAT_Part_ShowStock.GetType.Name
                            frmTRASF_MAT_Part_6_Final_ConfirmForm = New frmTRASF_MAT_Part_6_Final_Confirm
                            frmTRASF_MAT_Part_6_Final_ConfirmForm.ConfermaSelezioneStock()
                            frmTRASF_MAT_Part_6_Final_ConfirmForm.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious
                    Select Case inSourceForm.GetType.Name
                        Case frmTRASF_MAT_Part_2_ConfCodMat.GetType.Name '>>>> TORNO ALLO STEP 1
                            frmTRASF_MAT_Part_1Form = New frmTRASF_MAT_Part_1
                            frmTRASF_MAT_Part_1Form.Show()
                        Case frmTRASF_MAT_Part_3_SelStock.GetType.Name
                            If (Default_TRASF_EnableConfCodMat = True) Then
                                frmTRASF_MAT_Part_2_ConfCodMatForm = New frmTRASF_MAT_Part_2_ConfCodMat
                                frmTRASF_MAT_Part_2_ConfCodMatForm.Show()
                            Else
                                frmTRASF_MAT_Part_1Form = New frmTRASF_MAT_Part_1
                                frmTRASF_MAT_Part_1Form.Show()
                            End If
                        Case frmTRASF_MAT_Part_ShowStock.GetType.Name '>>>> TORNO ALLO STEP 2
                            frmTRASF_MAT_Part_6_Final_ConfirmForm = New frmTRASF_MAT_Part_6_Final_Confirm
                            frmTRASF_MAT_Part_6_Final_ConfirmForm.Show()
                        Case frmTRASF_MAT_Part_4_ConfQta.GetType.Name '>>>> TORNO ALLO STEP 2/3
                            If (clsTrasfMat.GetNumRecTableGiacenzeInfo() > 1) Then
                                frmTRASF_MAT_Part_3_SelStockForm = New frmTRASF_MAT_Part_3_SelStock
                                frmTRASF_MAT_Part_3_SelStockForm.Show()
                            Else
                                If (Default_TRASF_EnableConfCodMat = True) Then
                                    frmTRASF_MAT_Part_2_ConfCodMatForm = New frmTRASF_MAT_Part_2_ConfCodMat
                                    frmTRASF_MAT_Part_2_ConfCodMatForm.Show()
                                Else
                                    frmTRASF_MAT_Part_1Form = New frmTRASF_MAT_Part_1
                                    frmTRASF_MAT_Part_1Form.Show()
                                End If
                            End If
                        Case frmTRASF_MAT_Part_6_Final_Confirm.GetType.Name '>>>> TORNO ALLO STEP 2/3
                            frmTRASF_MAT_Part_4_ConfQtaForm = New frmTRASF_MAT_Part_4_ConfQta
                            frmTRASF_MAT_Part_4_ConfQtaForm.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartSeq
                    Select Case inSourceForm.GetType.Name
                        Case frmTRASF_MAT_Part_6_Final_Confirm.GetType.Name '>>>> TORNO ALLO STEP 2/3
                            clsTrasfMat.ClearForNewPositionRead() '>>> ESEGUO RESET PER PARTIRE CON NUOVA LETTURA MATERIALE 
                            If (Default_TRASF_EnableConfCodMat = True) Then
                                frmTRASF_MAT_Part_2_ConfCodMatForm = New frmTRASF_MAT_Part_2_ConfCodMat
                                frmTRASF_MAT_Part_2_ConfCodMatForm.Show()
                            Else
                                'ESEGUO QUERY PER RICARICARE LE GIACENZE FILTRATE (AGGIORNATE)
                                If (clsTrasfMat.GetNumRecTableGiacenzeInfo() > 1) Then
                                    RetCode = clsTrasfMat.ExexQueryOfSourceMaterials()
                                    frmTRASF_MAT_Part_3_SelStockForm = New frmTRASF_MAT_Part_3_SelStock
                                    frmTRASF_MAT_Part_3_SelStockForm.Show()
                                Else
                                    frmTRASF_MAT_Part_1Form = New frmTRASF_MAT_Part_1
                                    frmTRASF_MAT_Part_1Form.Show()
                                End If
                            End If
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case Else
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(913, "", "Direzione Step Non prevista (WizardDirectionStep).")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
            End Select

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Ope_TRASF_MAT = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Ope_TRASF_MAT = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Public Shared Function Show_Ope_Blocco_Mov_MM(ByRef inSourceForm As Form, ByVal inBloccoMovMMType As clsBloccoMovMM.Blocco_Mov_MM_Type, ByVal inWizardDirectionStep As clsDataType.WizardDirectionStepType, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Ope_Blocco_Mov_MM = 1 'INIT AT ERROR

            '***********************************************************************************
            '>>>> CASO AGGIUNTA PEZZO A CESTA (UNITA MAGAZZINO)
            Select Case inWizardDirectionStep
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext
                    Select Case inSourceForm.GetType.Name
                        Case frmMenuBloccoMerci.GetType.Name '>>>> VADO ALLO STEP 1
                            frmBloccoMovMM_Part_1Form = New frmBloccoMovMM_Part_1
                            clsBloccoMovMM.ClearAllData() 'INIT
                            clsBloccoMovMM.BloccoMovMMType = inBloccoMovMMType
                            frmBloccoMovMM_Part_1Form.Show()
                        Case frmBloccoMovMM_Part_1.GetType.Name '>>>> VADO ALLO STEP 2
                            frmBloccoMovMM_Part_2Form = New frmBloccoMovMM_Part_2
                            frmBloccoMovMM_Part_2Form.Show()
                        Case frmBloccoMovMM_Part_2.GetType.Name '>>>> VADO ALLO STEP 3
                            Select Case clsBloccoMovMM.BloccoMovMMFindType
                                Case clsBloccoMovMM.Blocco_Mov_MM_Find_Type.BloccoMovMMFindType_UnitaMagazzino
                                    frmBloccoMovMM_Part_3_UMForm = New frmBloccoMovMM_Part_3_UM
                                    frmBloccoMovMM_Part_3_UMForm.Show()
                                Case clsBloccoMovMM.Blocco_Mov_MM_Find_Type.BloccoMovMMFindType_Ubicazione
                                    frmBloccoMovMM_Part_3_UbicazioneForm = New frmBloccoMovMM_Part_3_Ubicazione
                                    frmBloccoMovMM_Part_3_UbicazioneForm.Show()
                                Case clsBloccoMovMM.Blocco_Mov_MM_Find_Type.BloccoMovMMFindType_Materiale
                                    frmBloccoMovMM_Part_3_MaterialeForm = New frmBloccoMovMM_Part_3_Materiale
                                    frmBloccoMovMM_Part_3_MaterialeForm.Show()
                                Case clsBloccoMovMM.Blocco_Mov_MM_Find_Type.BloccoMovMMFindType_UbicazioneMateriale
                                    frmBloccoMovMM_Part_3_MaterialeUbicazioneForm = New frmBloccoMovMM_Part_3_MaterialeUbicazione
                                    frmBloccoMovMM_Part_3_MaterialeUbicazioneForm.Show()
                                Case Else
                                    ErrDescription = clsAppTranslation.GetSingleParameterValue(914, "", "Caso ") & " Tipo Ricerca Non previsto (BloccoMovMMFindType)."
                                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                            End Select
                        Case frmBloccoMovMM_Part_3_Ubicazione.GetType.Name '>>>> VADO ALLO STEP SUCCESSIVO
                            If (clsBloccoMovMM.GetNumRecTableGiacenzeInfo = 1) Then
                                frmBloccoMovMM_Part_5Form = New frmBloccoMovMM_Part_5
                                frmBloccoMovMM_Part_5Form.Show()
                            Else
                                frmBloccoMovMM_Part_4_SelStockForm = New frmBloccoMovMM_Part_4_SelStock
                                frmBloccoMovMM_Part_4_SelStockForm.Show()
                            End If
                        Case frmBloccoMovMM_Part_3_UM.GetType.Name '>>>> VADO ALLO STEP SUCCESSIVO
                            If (clsBloccoMovMM.GetNumRecTableGiacenzeInfo = 1) Then
                                frmBloccoMovMM_Part_5Form = New frmBloccoMovMM_Part_5
                                frmBloccoMovMM_Part_5Form.Show()
                            Else
                                frmBloccoMovMM_Part_4_SelStockForm = New frmBloccoMovMM_Part_4_SelStock
                                frmBloccoMovMM_Part_4_SelStockForm.Show()
                            End If
                        Case frmBloccoMovMM_Part_3_Materiale.GetType.Name '>>>> VADO ALLO STEP SUCCESSIVO
                            If (clsBloccoMovMM.GetNumRecTableGiacenzeInfo = 1) Then
                                frmBloccoMovMM_Part_5Form = New frmBloccoMovMM_Part_5
                                frmBloccoMovMM_Part_5Form.Show()
                            Else
                                frmBloccoMovMM_Part_4_SelStockForm = New frmBloccoMovMM_Part_4_SelStock
                                frmBloccoMovMM_Part_4_SelStockForm.Show()
                            End If
                        Case frmBloccoMovMM_Part_3_MaterialeUbicazione.GetType.Name '>>>> VADO ALLO STEP SUCCESSIVO
                            If (clsBloccoMovMM.GetNumRecTableGiacenzeInfo = 1) Then
                                frmBloccoMovMM_Part_5Form = New frmBloccoMovMM_Part_5
                                frmBloccoMovMM_Part_5Form.Show()
                            Else
                                frmBloccoMovMM_Part_4_SelStockForm = New frmBloccoMovMM_Part_4_SelStock
                                frmBloccoMovMM_Part_4_SelStockForm.Show()
                            End If
                        Case frmBloccoMovMM_Part_4_SelStock.GetType.Name '>>>> VADO ALLO STEP SUCCESSIVO
                            frmBloccoMovMM_Part_5Form = New frmBloccoMovMM_Part_5
                            frmBloccoMovMM_Part_5Form.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious
                    Select Case inSourceForm.GetType.Name
                        Case frmBloccoMovMM_Part_2.GetType.Name '>>>> TORNO ALLO STEP PRECEDENTE
                            frmBloccoMovMM_Part_1Form = New frmBloccoMovMM_Part_1
                            frmBloccoMovMM_Part_1Form.Show()
                        Case frmBloccoMovMM_Part_3_UM.GetType.Name '>>>> VADO ALLO STEP PRECEDENTE
                            frmBloccoMovMM_Part_2Form = New frmBloccoMovMM_Part_2
                            frmBloccoMovMM_Part_2Form.Show()
                        Case frmBloccoMovMM_Part_3_Ubicazione.GetType.Name '>>>> TORNO ALLO STEP PRECEDENTE
                            frmBloccoMovMM_Part_2Form = New frmBloccoMovMM_Part_2
                            frmBloccoMovMM_Part_2Form.Show()
                        Case frmBloccoMovMM_Part_3_Materiale.GetType.Name '>>>> TORNO ALLO STEP PRECEDENTE
                            frmBloccoMovMM_Part_2Form = New frmBloccoMovMM_Part_2
                            frmBloccoMovMM_Part_2Form.Show()
                        Case frmBloccoMovMM_Part_3_MaterialeUbicazione.GetType.Name '>>>> TORNO ALLO STEP PRECEDENTE
                            frmBloccoMovMM_Part_2Form = New frmBloccoMovMM_Part_2
                            frmBloccoMovMM_Part_2Form.Show()
                        Case frmBloccoMovMM_Part_4_SelStock.GetType.Name '>>>> TORNO ALLO STEP 2
                            Select Case clsBloccoMovMM.BloccoMovMMFindType
                                Case clsBloccoMovMM.Blocco_Mov_MM_Find_Type.BloccoMovMMFindType_UnitaMagazzino
                                    frmBloccoMovMM_Part_3_UMForm = New frmBloccoMovMM_Part_3_UM
                                    frmBloccoMovMM_Part_3_UMForm.Show()
                                Case clsBloccoMovMM.Blocco_Mov_MM_Find_Type.BloccoMovMMFindType_Ubicazione
                                    frmBloccoMovMM_Part_3_UbicazioneForm = New frmBloccoMovMM_Part_3_Ubicazione
                                    frmBloccoMovMM_Part_3_UbicazioneForm.Show()
                                Case clsBloccoMovMM.Blocco_Mov_MM_Find_Type.BloccoMovMMFindType_Materiale
                                    frmBloccoMovMM_Part_3_MaterialeForm = New frmBloccoMovMM_Part_3_Materiale
                                    frmBloccoMovMM_Part_3_MaterialeForm.Show()
                                Case clsBloccoMovMM.Blocco_Mov_MM_Find_Type.BloccoMovMMFindType_UbicazioneMateriale
                                    frmBloccoMovMM_Part_3_MaterialeUbicazioneForm = New frmBloccoMovMM_Part_3_MaterialeUbicazione
                                    frmBloccoMovMM_Part_3_MaterialeUbicazioneForm.Show()
                                Case Else
                                    ErrDescription = clsAppTranslation.GetSingleParameterValue(914, "", "Caso ") & " Tipo Ricerca Non previsto (BloccoMovMMFindType)."
                                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                            End Select
                        Case frmBloccoMovMM_Part_5.GetType.Name '>>>> VADO ALLO STEP PRECEDENTE
                            frmBloccoMovMM_Part_4_SelStockForm = New frmBloccoMovMM_Part_4_SelStock
                            frmBloccoMovMM_Part_4_SelStockForm.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartSeq
                    Select Case inSourceForm.GetType.Name
                        Case frmBloccoMovMM_Part_5.GetType.Name '>>>> TORNO ALLO STEP 2 DOVE RICHIEDO IL CODICE DEL MATERIALE (NON ESCO DALLA PROCEDURA PER ESEGUIRE UNA NUOVA OPERAZIONE)
                            clsBloccoMovMM.ClearForNewPositionRead() 'RESET PER POTERE LEGGERE UN NUOVO CODICE MATERIALE
                            Select Case clsBloccoMovMM.BloccoMovMMFindType
                                Case clsBloccoMovMM.Blocco_Mov_MM_Find_Type.BloccoMovMMFindType_UnitaMagazzino
                                    frmBloccoMovMM_Part_3_UMForm = New frmBloccoMovMM_Part_3_UM
                                    frmBloccoMovMM_Part_3_UMForm.Show()
                                Case clsBloccoMovMM.Blocco_Mov_MM_Find_Type.BloccoMovMMFindType_Ubicazione
                                    frmBloccoMovMM_Part_3_UbicazioneForm = New frmBloccoMovMM_Part_3_Ubicazione
                                    frmBloccoMovMM_Part_3_UbicazioneForm.Show()
                                Case clsBloccoMovMM.Blocco_Mov_MM_Find_Type.BloccoMovMMFindType_Materiale
                                    frmBloccoMovMM_Part_3_MaterialeForm = New frmBloccoMovMM_Part_3_Materiale
                                    frmBloccoMovMM_Part_3_MaterialeForm.Show()
                                Case clsBloccoMovMM.Blocco_Mov_MM_Find_Type.BloccoMovMMFindType_UbicazioneMateriale
                                    frmBloccoMovMM_Part_3_MaterialeUbicazioneForm = New frmBloccoMovMM_Part_3_MaterialeUbicazione
                                    frmBloccoMovMM_Part_3_MaterialeUbicazioneForm.Show()
                                Case Else
                                    ErrDescription = clsAppTranslation.GetSingleParameterValue(914, "", "Caso ") & " Tipo Ricerca Non previsto (BloccoMovMMFindType)."
                                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                            End Select
                            'clsBloccoMovMM.ClearForNewPositionRead() 'RESET PER POTERE LEGGERE UN NUOVO CODICE MATERIALE
                            'clsBloccoMovMM.ExexQueryOfSourceMaterials()
                            'frmBloccoMovMM_Part_4_SelStockForm = New frmBloccoMovMM_Part_4_SelStock
                            'frmBloccoMovMM_Part_4_SelStockForm.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case Else
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(913, "", "Direzione Step Non prevista (WizardDirectionStep).")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
            End Select

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Ope_Blocco_Mov_MM = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Ope_Blocco_Mov_MM = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Public Shared Function Show_Ope_Reg_Modifica_Stock_E(ByRef inSourceForm As Form, ByVal inWizardDirectionStep As clsDataType.WizardDirectionStepType, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Ope_Reg_Modifica_Stock_E = 1 'INIT AT ERROR

            '***********************************************************************************
            '>>>> CASO AGGIUNTA PEZZO A CESTA (UNITA MAGAZZINO)
            Select Case inWizardDirectionStep
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext
                    Select Case inSourceForm.GetType.Name
                        Case frmMenuTrasferMain.GetType.Name '>>>> VADO ALLO STEP 1
                            frmMovimento_StockE_Part_1Form = New frmMovimento_StockE_Part_1
                            clsRegModStockE.ClearAllData() 'INIT
                            frmMovimento_StockE_Part_1Form.Show()
                        Case frmMovimento_StockE_Part_1.GetType.Name '>>>> VADO ALLO STEP 2
                            frmMovimento_StockE_Part_2Form = New frmMovimento_StockE_Part_2
                            frmMovimento_StockE_Part_2Form.Show()
                        Case frmMovimento_StockE_Part_2.GetType.Name '>>>> VADO ALLO STEP 3
                            frmMovimento_StockE_Part_3Form = New frmMovimento_StockE_Part_3
                            frmMovimento_StockE_Part_3Form.Show()
                        Case frmMovimento_StockE_Part_3.GetType.Name '>>>> VADO ALLO STEP 2
                            Select Case clsRegModStockE.FunctionRegModStockEType
                                Case clsDataType.FunctionRegModStockEType.FunctionRegModStockETypeAddStockE, clsDataType.FunctionRegModStockEType.FunctionRegModStockETypeAddStockECustom
                                    frmMovimento_StockE_Part_4_InsertStockEForm = New frmMovimento_StockE_Part_4_InsertStockE
                                    frmMovimento_StockE_Part_4_InsertStockEForm.Show()
                                Case clsDataType.FunctionRegModStockEType.FunctionRegModStockETypeRemoveStockE, clsDataType.FunctionRegModStockEType.FunctionRegModStockETypeRemoveStockECustom
                                    frmMovimento_StockE_Part_4_SelStockForm = New frmMovimento_StockE_Part_4_SelStock
                                    frmMovimento_StockE_Part_4_SelStockForm.Show()
                            End Select
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious
                    Select Case inSourceForm.GetType.Name
                        Case frmMovimento_StockE_Part_2.GetType.Name '>>>> TORNO ALLO STEP 1
                            frmMovimento_StockE_Part_1Form = New frmMovimento_StockE_Part_1
                            frmMovimento_StockE_Part_1Form.Show()
                        Case frmMovimento_StockE_Part_3.GetType.Name '>>>> VADO ALLO STEP 2
                            frmMovimento_StockE_Part_2Form = New frmMovimento_StockE_Part_2
                            frmMovimento_StockE_Part_2Form.Show()
                        Case frmMovimento_StockE_Part_4_InsertStockE.GetType.Name '>>>> TORNO ALLO STEP 3
                            frmMovimento_StockE_Part_3Form = New frmMovimento_StockE_Part_3
                            frmMovimento_StockE_Part_3Form.Show()
                        Case frmMovimento_StockE_Part_4_InsertStockEForm.GetType.Name '>>>> TORNO ALLO STEP 3
                            frmMovimento_StockE_Part_3Form = New frmMovimento_StockE_Part_3
                            frmMovimento_StockE_Part_3Form.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartSeq
                    Select Case inSourceForm.GetType.Name
                        Case frmMovimento_StockE_Part_4_InsertStockE.GetType.Name '>>>> TORNO ALLO STEP 2 DOVE RICHIEDO IL CODICE DEL MATERIALE (NON ESCO DALLA PROCEDURA PER ESEGUIRE UNA NUOVA OPERAZIONE)
                            clsRegModStockE.ClearForNewPositionRead() 'RESET PER POTERE LEGGERE UN NUOVO CODICE MATERIALE
                            frmMovimento_StockE_Part_3Form = New frmMovimento_StockE_Part_3
                            frmMovimento_StockE_Part_3Form.Show()
                        Case frmMovimento_StockE_Part_4_SelStock.GetType.Name '>>>> TORNO ALLO STEP 2 DOVE RICHIEDO IL CODICE DEL MATERIALE (NON ESCO DALLA PROCEDURA PER ESEGUIRE UNA NUOVA OPERAZIONE)
                            clsRegModStockE.ClearForNewPositionRead() 'RESET PER POTERE LEGGERE UN NUOVO CODICE MATERIALE
                            frmMovimento_StockE_Part_3Form = New frmMovimento_StockE_Part_3
                            frmMovimento_StockE_Part_3Form.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case Else
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(913, "", "Direzione Step Non prevista (WizardDirectionStep).")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
            End Select

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Ope_Reg_Modifica_Stock_E = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Ope_Reg_Modifica_Stock_E = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Public Shared Function Show_Ope_InventarioUbicazione(ByRef inSourceForm As Form, ByVal inEnumInventoryType As clsInventarioUbicazione.EnumInventoryType, ByVal inWizardDirectionStep As clsDataType.WizardDirectionStepType, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Ope_InventarioUbicazione = 1 'INIT AT ERROR

            Select Case inWizardDirectionStep
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext
                    Select Case inSourceForm.GetType.Name
                        Case frmMenuInventario.GetType.Name '>>>> VADO ALLO STEP 1
                            clsInventarioUbicazione.ClearAllData() 'INIT
                            clsInventarioUbicazione.InventoryType = inEnumInventoryType
                            Select Case clsInventarioUbicazione.InventoryType
                                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUbicazione
                                    frmInventarioUbicazione_1_UbicazioneForm = New frmInventarioUbicazione_1_Ubicazione
                                    frmInventarioUbicazione_1_UbicazioneForm.Show()
                                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUnitaMagazzino
                                    frmInventarioUbicazione_1_UMForm = New frmInventarioUbicazione_1_UM
                                    frmInventarioUbicazione_1_UMForm.Show()
                                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeRottamazione, clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeCentroCosto
                                    frmInventarioUbicazione_1_UbicazioneUMForm = New frmInventarioUbicazione_1_UbicazioneUM
                                    frmInventarioUbicazione_1_UbicazioneUMForm.Show()
                                Case Else
                                    frmInventarioUbicazione_1_UbicazioneUMForm = New frmInventarioUbicazione_1_UbicazioneUM
                                    frmInventarioUbicazione_1_UbicazioneUMForm.Show()
                            End Select
                        Case frmInventarioUbicazione_1_Ubicazione.GetType.Name, frmInventarioUbicazione_1_UM.GetType.Name, frmInventarioUbicazione_1_UbicazioneUM.GetType.Name, frmInventarioUbicazione_1_UbicazioneUM.GetType.Name   '>>>> VADO ALLO STEP 2
                            If (Default_Inventario_EnableConfCodMat = True) Then
                                frmInventarioUbicazione_2_ConfCodMatForm = New frmInventarioUbicazione_2_ConfCodMat
                                frmInventarioUbicazione_2_ConfCodMatForm.Show()
                            Else
                                If (clsInventarioUbicazione.GetNumRecTableGiacenzeInfo > 1) Then
                                    '>>> CASO DI GIACENZA AMBIGUA IN CUI INSERISCO UNO STEP DI SCELTA DELLO STOCK SU CUI AGIRE
                                    frmInventarioUbicazione_3_SelStockForm = New frmInventarioUbicazione_3_SelStock
                                    frmInventarioUbicazione_3_SelStockForm.Show()
                                Else
                                    '>>> CASO IN CUI HO UNA SOLA GIACENZA
                                    Select Case clsInventarioUbicazione.InventoryType
                                        Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUbicazione, clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUnitaMagazzino, clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeRottamazione
                                            frmInventarioUbicazione_4_ConfQtaForm = New frmInventarioUbicazione_4_ConfQta
                                            frmInventarioUbicazione_4_ConfQtaForm.Show()
                                        Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeCentroCosto
                                            frmInventarioUbicazione_4_ConsumoCentroCostoForm = New frmInventarioUbicazione_4_ConsumoCentroCosto
                                            frmInventarioUbicazione_4_ConsumoCentroCostoForm.Show()
                                        Case Else
                                            frmInventarioUbicazione_4_ConfQtaForm = New frmInventarioUbicazione_4_ConfQta
                                            frmInventarioUbicazione_4_ConfQtaForm.Show()
                                    End Select
                                End If
                            End If
                        Case frmInventarioUbicazione_2_ConfCodMat.GetType.Name '>>>> VADO ALLO STEP 3/4
                            If (clsInventarioUbicazione.GetNumRecTableGiacenzeInfo > 1) Then
                                '>>> CASO DI GIACENZA AMBIGUA IN CUI INSERISCO UNO STEP DI SCELTA DELLO STOCK SU CUI AGIRE
                                frmInventarioUbicazione_3_SelStockForm = New frmInventarioUbicazione_3_SelStock
                                frmInventarioUbicazione_3_SelStockForm.Show()
                            Else
                                '>>> CASO IN CUI HO UNA SOLA GIACENZA
                                Select Case clsInventarioUbicazione.InventoryType
                                    Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUbicazione, clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUnitaMagazzino, clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeRottamazione
                                        frmInventarioUbicazione_4_ConfQtaForm = New frmInventarioUbicazione_4_ConfQta
                                        frmInventarioUbicazione_4_ConfQtaForm.Show()
                                    Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeCentroCosto
                                        frmInventarioUbicazione_4_ConsumoCentroCostoForm = New frmInventarioUbicazione_4_ConsumoCentroCosto
                                        frmInventarioUbicazione_4_ConsumoCentroCostoForm.Show()
                                    Case Else
                                        frmInventarioUbicazione_4_ConfQtaForm = New frmInventarioUbicazione_4_ConfQta
                                        frmInventarioUbicazione_4_ConfQtaForm.Show()
                                End Select
                            End If
                        Case frmInventarioUbicazione_3_SelStock.GetType.Name '>>>> VADO ALLO STEP 4
                            Select Case clsInventarioUbicazione.InventoryType
                                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUbicazione, clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUnitaMagazzino, clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeRottamazione
                                    frmInventarioUbicazione_4_ConfQtaForm = New frmInventarioUbicazione_4_ConfQta
                                    frmInventarioUbicazione_4_ConfQtaForm.Show()
                                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeCentroCosto
                                    frmInventarioUbicazione_4_ConsumoCentroCostoForm = New frmInventarioUbicazione_4_ConsumoCentroCosto
                                    frmInventarioUbicazione_4_ConsumoCentroCostoForm.Show()
                                Case Else
                                    frmInventarioUbicazione_4_ConfQtaForm = New frmInventarioUbicazione_4_ConfQta
                                    frmInventarioUbicazione_4_ConfQtaForm.Show()
                            End Select
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious
                    Select Case inSourceForm.GetType.Name
                        Case frmInventarioUbicazione_2_ConfCodMat.GetType.Name '>>>> TORNO ALLO STEP 1
                            frmInventarioUbicazione_1_UbicazioneForm = New frmInventarioUbicazione_1_Ubicazione
                            frmInventarioUbicazione_1_UbicazioneForm.Show()
                        Case frmInventarioUbicazione_3_SelStock.GetType.Name '>>>> TORNO ALLO STEP 2
                            If (Default_Inventario_EnableConfCodMat = True) Then
                                frmInventarioUbicazione_2_ConfCodMatForm = New frmInventarioUbicazione_2_ConfCodMat
                                frmInventarioUbicazione_2_ConfCodMatForm.Show()
                            Else
                                '>>> IN BASE AL TIPO DI INVENTARIO RITORNO ALLA VIDEATA DI ORIGINE
                                Select Case clsInventarioUbicazione.InventoryType
                                    Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUbicazione
                                        frmInventarioUbicazione_1_UbicazioneForm = New frmInventarioUbicazione_1_Ubicazione
                                        frmInventarioUbicazione_1_UbicazioneForm.Show()
                                    Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUnitaMagazzino
                                        frmInventarioUbicazione_1_UMForm = New frmInventarioUbicazione_1_UM
                                        frmInventarioUbicazione_1_UMForm.Show()
                                    Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeRottamazione, clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeCentroCosto
                                        frmInventarioUbicazione_1_UbicazioneUMForm = New frmInventarioUbicazione_1_UbicazioneUM
                                        frmInventarioUbicazione_1_UbicazioneUMForm.Show()
                                End Select
                            End If
                        Case frmInventarioUbicazione_4_ConfQta.GetType.Name '>>>> TORNO ALLO STEP 2/3
                            If (clsInventarioUbicazione.GetNumRecTableGiacenzeInfo > 1) Then
                                frmInventarioUbicazione_3_SelStockForm = New frmInventarioUbicazione_3_SelStock
                                frmInventarioUbicazione_3_SelStockForm.Show()
                            Else
                                If (Default_Inventario_EnableConfCodMat = True) Then
                                    frmInventarioUbicazione_2_ConfCodMatForm = New frmInventarioUbicazione_2_ConfCodMat
                                    frmInventarioUbicazione_2_ConfCodMatForm.Show()
                                Else
                                    '>>> IN BASE AL TIPO DI INVENTARIO RITORNO ALLA VIDEATA DI ORIGINE
                                    Select Case clsInventarioUbicazione.InventoryType
                                        Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUbicazione
                                            frmInventarioUbicazione_1_UbicazioneForm = New frmInventarioUbicazione_1_Ubicazione
                                            frmInventarioUbicazione_1_UbicazioneForm.Show()
                                        Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUnitaMagazzino
                                            frmInventarioUbicazione_1_UMForm = New frmInventarioUbicazione_1_UM
                                            frmInventarioUbicazione_1_UMForm.Show()
                                        Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeRottamazione, clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeCentroCosto
                                            frmInventarioUbicazione_1_UbicazioneUMForm = New frmInventarioUbicazione_1_UbicazioneUM
                                            frmInventarioUbicazione_1_UbicazioneUMForm.Show()
                                    End Select
                                End If
                            End If
                        Case frmInventarioUbicazione_4_ConsumoCentroCosto.GetType.Name
                            If (clsInventarioUbicazione.GetNumRecTableGiacenzeInfo > 1) Then
                                frmInventarioUbicazione_3_SelStockForm = New frmInventarioUbicazione_3_SelStock
                                frmInventarioUbicazione_3_SelStockForm.Show()
                            Else
                                If (Default_Inventario_EnableConfCodMat = True) Then
                                    frmInventarioUbicazione_2_ConfCodMatForm = New frmInventarioUbicazione_2_ConfCodMat
                                    frmInventarioUbicazione_2_ConfCodMatForm.Show()
                                Else
                                    '>>> IN BASE AL TIPO DI INVENTARIO RITORNO ALLA VIDEATA DI ORIGINE
                                    Select Case clsInventarioUbicazione.InventoryType
                                        Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUbicazione
                                            frmInventarioUbicazione_1_UbicazioneForm = New frmInventarioUbicazione_1_Ubicazione
                                            frmInventarioUbicazione_1_UbicazioneForm.Show()
                                        Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUnitaMagazzino
                                            frmInventarioUbicazione_1_UMForm = New frmInventarioUbicazione_1_UM
                                            frmInventarioUbicazione_1_UMForm.Show()
                                        Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeRottamazione, clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeCentroCosto
                                            frmInventarioUbicazione_1_UbicazioneUMForm = New frmInventarioUbicazione_1_UbicazioneUM
                                            frmInventarioUbicazione_1_UbicazioneUMForm.Show()
                                    End Select
                                End If
                            End If
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartSeq
                    Select Case inSourceForm.GetType.Name
                        Case frmInventarioUbicazione_4_ConfQta.GetType.Name '>>>> VADO ALLO STEP 2 (RIMANGO NELLO STESSA UBICAZIONE => LEGGO NUOVO MATERIALE)                            
                            frmInventarioUbicazione_3_SelStockForm = New frmInventarioUbicazione_3_SelStock
                            frmInventarioUbicazione_3_SelStockForm.Show()
                    End Select
                Case Else
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(913, "", "Direzione Step Non prevista (WizardDirectionStep).")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
            End Select

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Ope_InventarioUbicazione = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Ope_InventarioUbicazione = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function


    Public Shared Function Show_Mnu_Home(ByRef inSourceForm As Form, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Mnu_Home = 1 'init at error


#If Not APPLICAZIONE_WIN32 = "SI" Then

            If (frmMainHomeMenuForm Is Nothing) Then
                frmMainHomeMenuForm = New frmMainHomeMenu
            End If

            'ATTENZIONE!!! QUESTA FORM E' SEMPRE CARICATA (TIENE ATTIVA L'APPLICAZIONE)
            frmMainHomeMenuForm.Visible = True


            If (Not inSourceForm Is Nothing) Then
                If (inSourceForm.Name <> frmMainHomeMenuForm.Name) Then
                    RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)
                End If
            End If

#Else

            If (frmMainHomeMenuWinForm Is Nothing) Then
                frmMainHomeMenuWinForm = New frmMainHomeMenuWin
            End If

            'ATTENZIONE!!! QUESTA FORM E' SEMPRE CARICATA (TIENE ATTIVA L'APPLICAZIONE)
            frmMainHomeMenuWinForm.Visible = True

            If (Not inSourceForm Is Nothing) Then
                If (inSourceForm.Name <> frmMainHomeMenuWinForm.Name) Then
                    RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)
                End If
            End If

            'AGGIORNO LE INFO NELLA FORM
            frmMainHomeMenuWinForm.RefreshForm()

#End If


            Show_Mnu_Home = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function
    Public Shared Function Show_Info_User(ByRef inSourceForm As Form, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Info_User = 1 'init at error

            frmInfoUserForm = New frmInfoUser
            frmInfoUserForm.Show()

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Info_User = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function
    Public Shared Function Show_Info_System(ByRef inSourceForm As Form, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Info_System = 1 'init at error

            frmInfoSystemForm = New frmInfoSystem
            frmInfoSystemForm.Show()

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Info_System = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Public Shared Function Show_Print_Label_Menu(ByRef inSourceForm As Form, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Print_Label_Menu = 1 'init at error

            frmMenuStampaLabelForm = New frmMenuStampaLabel
            frmMenuStampaLabelForm.Show()

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Print_Label_Menu = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Public Shared Function Show_Info_Giacenze(ByRef inSourceForm As Form, ByVal inInfoGiacenzeType As clsDataType.InfoGiacenzeType, ByVal inWizardDirectionStep As clsDataType.WizardDirectionStepType, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Info_Giacenze = 1 'INIT AT ERROR

            Select Case inWizardDirectionStep
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext
                    Select Case inSourceForm.GetType.Name
                        Case frmMenuInformazioni_1.GetType.Name  '>>>> VADO ALLO STEP 1
                            clsInfoGiacenze.ClearAllData() 'INIT
                            clsInfoGiacenze.InfoGiacenzeType = inInfoGiacenzeType
                            If (clsInfoGiacenze.InfoGiacenzeType = clsDataType.InfoGiacenzeType.InfoGiacenzeTypeForCodMateriale) Then
                                frmInfoGiacenze_1_CodiceMaterialeForm = New frmInfoGiacenze_1_CodiceMateriale
                                frmInfoGiacenze_1_CodiceMaterialeForm.Show()
                            ElseIf (clsInfoGiacenze.InfoGiacenzeType = clsDataType.InfoGiacenzeType.InfoGiacenzeTypeForUnitaMagazzino) Then
                                frmInfoGiacenze_1_UMForm = New frmInfoGiacenze_1_UM
                                frmInfoGiacenze_1_UMForm.Show()
                            Else
                                frmInfoGiacenze_1Form = New frmInfoGiacenze_1_Ubicazione
                                frmInfoGiacenze_1Form.Show()
                            End If
                        Case frmInfoGiacenze_1_Ubicazione.GetType.Name '>>>> VADO ALLO STEP 2
                            If (clsInfoGiacenze.InfoGiacenzeType = clsDataType.InfoGiacenzeType.InfoGiacenzeTypeForUbicazione) Then
                                'IN QUESTO CASO PASSO DIRETTAMENTE A VISUALIZZARE I DATI ALLO STEP 3
                                frmInfoGiacenze_3_ListForm = New frmInfoGiacenze_3_List
                                frmInfoGiacenze_3_ListForm.Show()
                            Else
                                frmInfoGiacenze_2Form = New frmInfoGiacenze_2
                                frmInfoGiacenze_2Form.Show()
                            End If
                        Case frmInfoGiacenze_1_CodiceMateriale.GetType.Name '>>>> VADO ALLO STEP 2
                            If (clsInfoGiacenze.InfoGiacenzeType = clsDataType.InfoGiacenzeType.InfoGiacenzeTypeForCodMateriale) Then
                                'IN QUESTO CASO PASSO DIRETTAMENTE A VISUALIZZARE I DATI ALLO STEP 3
                                frmInfoGiacenze_3_ListForm = New frmInfoGiacenze_3_List
                                frmInfoGiacenze_3_ListForm.Show()
                            Else
                                frmInfoGiacenze_2Form = New frmInfoGiacenze_2
                                frmInfoGiacenze_2Form.Show()
                            End If
                        Case frmInfoGiacenze_1_UM.GetType.Name '>>>> VADO ALLO STEP 2
                            If (clsInfoGiacenze.InfoGiacenzeType = clsDataType.InfoGiacenzeType.InfoGiacenzeTypeForUnitaMagazzino) Then
                                'IN QUESTO CASO PASSO DIRETTAMENTE A VISUALIZZARE I DATI ALLO STEP 3
                                frmInfoGiacenze_3_ListForm = New frmInfoGiacenze_3_List
                                frmInfoGiacenze_3_ListForm.Show()
                            Else
                                frmInfoGiacenze_2Form = New frmInfoGiacenze_2
                                frmInfoGiacenze_2Form.Show()
                            End If
                        Case frmInfoGiacenze_2.GetType.Name '>>>> VADO ALLO STEP 3
                            frmInfoGiacenze_3_ListForm = New frmInfoGiacenze_3_List
                            frmInfoGiacenze_3_ListForm.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious
                    Select Case inSourceForm.GetType.Name
                        Case frmInfoGiacenze_2.GetType.Name '>>>> TORNO ALLO STEP 1
                            frmInfoGiacenze_1Form = New frmInfoGiacenze_1_Ubicazione
                            frmInfoGiacenze_1Form.Show()
                        Case frmInfoGiacenze_3_List.GetType.Name '>>>> TORNO ALLO STEP 2
                            If (clsInfoGiacenze.InfoGiacenzeType = clsDataType.InfoGiacenzeType.InfoGiacenzeTypeForUbicazione) Then
                                frmInfoGiacenze_1Form = New frmInfoGiacenze_1_Ubicazione
                                frmInfoGiacenze_1Form.Show()
                            ElseIf (clsInfoGiacenze.InfoGiacenzeType = clsDataType.InfoGiacenzeType.InfoGiacenzeTypeForCodMateriale) Then
                                frmInfoGiacenze_1_CodiceMaterialeForm = New frmInfoGiacenze_1_CodiceMateriale
                                frmInfoGiacenze_1_CodiceMaterialeForm.Show()
                            ElseIf (clsInfoGiacenze.InfoGiacenzeType = clsDataType.InfoGiacenzeType.InfoGiacenzeTypeForUnitaMagazzino) Then
                                frmInfoGiacenze_1_UMForm = New frmInfoGiacenze_1_UM
                                frmInfoGiacenze_1_UMForm.Show()
                            Else
                                frmInfoGiacenze_2Form = New frmInfoGiacenze_2
                                frmInfoGiacenze_2Form.Show()
                            End If
                        Case frmInfoDatiGiacenza.GetType.Name, frmInfoDatiSpedizione.GetType.Name
                            frmInfoGiacenze_3_ListForm = New frmInfoGiacenze_3_List
                            frmInfoGiacenze_3_ListForm.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeDetails
                    frmInfoDatiGiacenzaForm = New frmInfoDatiGiacenza
                    frmInfoDatiGiacenzaForm.Show()
                    frmInfoDatiGiacenzaForm.SourceForm = inSourceForm
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeSped
                    frmInfoDatiSpedizioneForm = New frmInfoDatiSpedizione
                    frmInfoDatiSpedizioneForm.Show()
                    frmInfoDatiSpedizioneForm.SourceForm = inSourceForm
                Case Else
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(913, "", "Direzione Step Non prevista (WizardDirectionStep).")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
            End Select

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Info_Giacenze = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Info_Giacenze = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function
    Public Shared Function Show_Info_Anagrafica_Materiale(ByRef inSourceForm As Form, ByVal inWizardDirectionStep As clsDataType.WizardDirectionStepType, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Info_Anagrafica_Materiale = 1 'INIT AT ERROR

            Select Case inWizardDirectionStep
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext
                    Select Case inSourceForm.GetType.Name
                        Case frmMenuInformazioni_1.GetType.Name  '>>>> VADO ALLO STEP 1
                            clsInfoCodiceMateriale.ClearAllData() 'INIT
                            frmInfoCodiceMateriale_1Form = New frmInfoCodiceMateriale_1
                            frmInfoCodiceMateriale_1Form.Show()
                        Case frmInfoCodiceMateriale_1.GetType.Name '>>>> VADO ALLO STEP 2
                            frmInfoCodiceMateriale_2_ListForm = New frmInfoCodiceMateriale_2_List
                            frmInfoCodiceMateriale_2_ListForm.Show()
                        Case frmInfoCodiceMateriale_2_List.GetType.Name '>>>> VADO ALLO STEP 3
                            frmInfoCodiceMateriale_3_DetailsForm = New frmInfoCodiceMateriale_3_Details
                            frmInfoCodiceMateriale_3_DetailsForm.Show()
                            frmInfoCodiceMateriale_3_DetailsForm.SourceForm = inSourceForm
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious
                    Select Case inSourceForm.GetType.Name
                        Case frmInfoCodiceMateriale_2_List.GetType.Name '>>>> TORNO ALLO STEP 1
                            frmInfoCodiceMateriale_1Form = New frmInfoCodiceMateriale_1
                            frmInfoCodiceMateriale_1Form.Show()
                        Case frmInfoCodiceMateriale_3_Details.GetType.Name '>>>> TORNO ALLO STEP 2
                            frmInfoCodiceMateriale_2_ListForm = New frmInfoCodiceMateriale_2_List
                            frmInfoCodiceMateriale_2_ListForm.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeDetails
                    frmInfoCodiceMateriale_3_DetailsForm = New frmInfoCodiceMateriale_3_Details
                    frmInfoCodiceMateriale_3_DetailsForm.Show()
                    frmInfoCodiceMateriale_3_DetailsForm.SourceForm = inSourceForm
                Case Else
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(913, "", "Direzione Step Non prevista (WizardDirectionStep).")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
            End Select

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Info_Anagrafica_Materiale = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Info_Anagrafica_Materiale = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function
    Public Shared Function Show_Info_Disponibilita_Materiale(ByRef inSourceForm As Form, ByVal inWizardDirectionStep As clsDataType.WizardDirectionStepType, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Info_Disponibilita_Materiale = 1 'INIT AT ERROR

            Select Case inWizardDirectionStep
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext
                    Select Case inSourceForm.GetType.Name
                        Case frmMenuInformazioni_1.GetType.Name  '>>>> VADO ALLO STEP 1
                            clsInfoDisponibilitaMateriale.ClearAllData() 'INIT
                            frmInfoDisponibilitaMateriale_1Form = New frmInfoDisponibilitaMateriale_1
                            frmInfoDisponibilitaMateriale_1Form.Show()
                        Case frmInfoDisponibilitaMateriale_1.GetType.Name '>>>> VADO ALLO STEP 2
                            frmInfoDisponibilitaMateriale_2_ListForm = New frmInfoDisponibilitaMateriale_2_List
                            frmInfoDisponibilitaMateriale_2_ListForm.Show()
                        Case frmInfoDisponibilitaMateriale_2_List.GetType.Name '>>>> VADO ALLO STEP 3
                            frmInfoDisponibilitaMateriale_3_DetailsForm = New frmInfoDisponibilitaMateriale_3_Details
                            frmInfoDisponibilitaMateriale_3_DetailsForm.Show()
                            frmInfoDisponibilitaMateriale_3_DetailsForm.SourceForm = inSourceForm
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious
                    Select Case inSourceForm.GetType.Name
                        Case frmInfoDisponibilitaMateriale_2_List.GetType.Name '>>>> TORNO ALLO STEP 1
                            frmInfoDisponibilitaMateriale_1Form = New frmInfoDisponibilitaMateriale_1
                            frmInfoDisponibilitaMateriale_1Form.Show()
                        Case frmInfoDisponibilitaMateriale_3_Details.GetType.Name '>>>> TORNO ALLO STEP 2
                            frmInfoDisponibilitaMateriale_2_ListForm = New frmInfoDisponibilitaMateriale_2_List
                            frmInfoDisponibilitaMateriale_2_ListForm.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeDetails
                    frmInfoDisponibilitaMateriale_3_DetailsForm = New frmInfoDisponibilitaMateriale_3_Details
                    frmInfoDisponibilitaMateriale_3_DetailsForm.Show()
                    frmInfoDisponibilitaMateriale_3_DetailsForm.SourceForm = inSourceForm
                Case Else
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(913, "", "Direzione Step Non prevista (WizardDirectionStep).")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
            End Select

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Info_Disponibilita_Materiale = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Info_Disponibilita_Materiale = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Public Shared Function Show_Info_Tipi_Magazzino(ByRef inSourceForm As Form, ByVal inWizardDirectionStep As clsDataType.WizardDirectionStepType, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Info_Tipi_Magazzino = 1 'INIT AT ERROR

            Select Case inWizardDirectionStep
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext
                    Select Case inSourceForm.Name
                        Case frmMenuInformazioni_1.GetType.Name, frmMenuInformazioni_2.GetType.Name '>>>> VADO ALLO STEP 1
                            frmInfoTipiMag_1Form = New frmInfoTipiMag_1
                            clsInfoTipiMagazzino.ClearAllData() 'INIT
                            frmInfoTipiMag_1Form.Show()
                        Case frmInfoTipiMag_1.GetType.Name '>>>> VADO ALLO STEP 2
                            frmInfoTipiMag_2Form = New frmInfoTipiMag_2
                            frmInfoTipiMag_2Form.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious
                    Select Case inSourceForm.Name
                        Case frmInfoTipiMag_2.GetType.Name '>>>> TORNO ALLO STEP 1
                            frmInfoTipiMag_1Form = New frmInfoTipiMag_1
                            frmInfoTipiMag_1Form.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case Else
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(913, "", "Direzione Step Non prevista (WizardDirectionStep).")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
            End Select

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Info_Tipi_Magazzino = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Info_Tipi_Magazzino = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Public Shared Function Show_Info_Mappa_Ubicazioni(ByRef inSourceForm As Form, ByVal inWizardDirectionStep As clsDataType.WizardDirectionStepType, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Info_Mappa_Ubicazioni = 1 'INIT AT ERROR

            Select Case inWizardDirectionStep
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext
                    Select Case inSourceForm.GetType.Name
                        Case frmMenuInformazioni_1.GetType.Name, frmMenuInformazioni_2.GetType.Name '>>>> VADO ALLO STEP 1
                            frmInfoMappaUbicazioni_1Form = New frmInfoMappaUbicazioni_1
                            clsInfoMappaUbicazioni.ClearAllData() 'INIT
                            frmInfoMappaUbicazioni_1Form.Show()
                        Case frmInfoMappaUbicazioni_1.GetType.Name '>>>> VADO ALLO STEP 2
                            frmInfoMappaUbicazioni_2Form = New frmInfoMappaUbicazioni_2
                            frmInfoMappaUbicazioni_2Form.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious
                    Select Case inSourceForm.GetType.Name
                        Case frmInfoMappaUbicazioni_2.GetType.Name '>>>> TORNO ALLO STEP 1
                            frmInfoMappaUbicazioni_1Form = New frmInfoMappaUbicazioni_1
                            frmInfoMappaUbicazioni_1Form.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case Else
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(913, "", "Direzione Step Non prevista (WizardDirectionStep).")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
            End Select

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Info_Mappa_Ubicazioni = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Info_Mappa_Ubicazioni = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Public Shared Function User_Action_CloseForm(ByRef inForm As Form, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            User_Action_CloseForm = 1 'init at error

            RetCode = CloseSourceForm(inForm, inShowMessageBox)

            User_Action_CloseForm = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Public Shared Function CloseSourceForm(ByRef inSourceForm As Form, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (inSourceForm Is Nothing) Then
                Exit Function
            End If

#If Not APPLICAZIONE_WIN32 = "SI" Then

            If (inSourceForm.Name = "frmMainHomeMenu") Then
                'SE E' LA FINESTRA PRINCIPALE NON DEVO CHIUDERLA ALTRIMENTI
                'TERMINA TUTTA L'APPLICAZIONE
                'inSourceForm.SendToBack()
                'inSourceForm.Visible = False
                Exit Function
            End If

#Else

            If (inSourceForm.Name = "frmMainHomeMenuWin") Then
                'SE E' LA FINESTRA PRINCIPALE NON DEVO CHIUDERLA ALTRIMENTI
                'TERMINA TUTTA L'APPLICAZIONE
                'inSourceForm.SendToBack()
                'inSourceForm.Visible = False
                Exit Function
            End If

#End If


            inSourceForm.Dispose()


            CloseSourceForm = RetCode 'SE = 0 TUTTO OK


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CloseSourceForm = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function


    Public Shared Function Show_Ope_UscitaMerci_x_OdP(ByRef inSourceForm As Form, ByVal inWizardDirectionStep As clsDataType.WizardDirectionStepType, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Ope_UscitaMerci_x_OdP = 1 'INIT AT ERROR

            Select Case inWizardDirectionStep
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext
                    Select Case inSourceForm.GetType.Name
                        Case frmMenuUscitaMerciMain.GetType.Name '>>>> VADO ALLO STEP 1
                            frmPickingOdp_Odp_1Form = New frmPickingOdP_OdP_1
                            clsPickCompOdP.ClearAllData() 'INIT
                            frmPickingOdp_Odp_1Form.Show()
                        Case frmPickingOdP_OdP_1.GetType.Name '>>>> VADO ALLO STEP 2
                            frmPickingOdp_UM_2Form = New frmPickingOdP_UM_2
                            frmPickingOdp_UM_2Form.Show()
                            'Case frmUscitaMerci_Consegna_2.GetType.Name '>>>> VADO ALLO STEP 3
                            'frmUscitaMerci_OdP_4_OdPForm = New frmUscitaMerci_5_OdP
                            'frmUscitaMerci_OdP_4_OdPForm.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious
                    Select Case inSourceForm.GetType.Name
                        Case frmPickingOdP_UM_2.GetType.Name '>>>> TORNO ALLO STEP 1
                            frmPickingOdp_Odp_1Form = New frmPickingOdP_OdP_1
                            frmPickingOdp_Odp_1Form.Show()
                        Case frmPickingOdP_OdP_1.GetType.Name '>>>> TORNO ALLO STEP 2
                            frmMenuUscitaMerciMainForm = frmMenuUscitaMerciMain
                            frmMenuUscitaMerciMainForm.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartSeq
                    Select Case inSourceForm.GetType.Name
                        Case frmPickingOdP_UM_2.GetType.Name '>>>> TORNO ALLO STEP 1
                            frmPickingOdp_Odp_1Form = New frmPickingOdP_OdP_1
                            frmPickingOdp_Odp_1Form.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case Else
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(913, "", "Direzione Step Non prevista (WizardDirectionStep).")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
            End Select

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Ope_UscitaMerci_x_OdP = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Ope_UscitaMerci_x_OdP = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function


    Public Shared Function Show_Ope_TRASF_UBI(ByRef inSourceForm As Form, ByVal inWizardDirectionStep As clsDataType.WizardDirectionStepType, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Ope_TRASF_UBI = 1 'INIT AT ERROR

            Select Case inWizardDirectionStep
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext
                    Select Case inSourceForm.GetType.Name
                        Case frmMenuTrasferMain.GetType.Name    '>>>> VADO ALLO STEP 1
                            frmTRASF_UBI_Part_1Form = New frmTRASF_UBI_Part_1
                            clsTrasfUbi.ClearAllData() 'INIT
                            clsTrasfUbi.SourceForm = inSourceForm
                            frmTRASF_UBI_Part_1Form.Show()
                        Case frmTRASF_UBI_Part_1.GetType.Name   '>>>> VADO ALLO STEP 2
                            frmTRASF_UBI_Part_2Form = New frmTRASF_UBI_Part_2
                            frmTRASF_UBI_Part_2Form.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(914, "", "Caso ") & " [FunctionTransferUMType] Non previsto."
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious
                    Select Case inSourceForm.GetType.Name
                        Case frmTRASF_UBI_Part_2.GetType.Name '>>>> TORNO ALLO STEP 1
                            frmTRASF_UBI_Part_1Form = New frmTRASF_UBI_Part_1
                            frmTRASF_UBI_Part_1Form.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartSeq 'INIZIO UNA NUOVA SEQUENZA OPERATIVA
                    Select Case inSourceForm.GetType.Name
                        Case frmTRASF_UBI_Part_2.GetType.Name '>>>> TORNO ALLO STEP 1
                            frmTRASF_UBI_Part_1Form = New frmTRASF_UBI_Part_1
                            clsTrasfUbi.ClearAllData() 'INIT
                            clsTrasfUbi.SourceForm = inSourceForm
                            frmTRASF_UBI_Part_1Form.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case Else
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(913, "", "Direzione Step Non prevista (WizardDirectionStep).")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
            End Select

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Ope_TRASF_UBI = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Ope_TRASF_UBI = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function


    Public Shared Function Show_Ope_TRASF_UnitaMagazzino(ByRef inSourceForm As Form, ByVal inFunctionTransferUMType As clsDataType.FunctionTransferMaterialType, ByVal inWizardDirectionStep As clsDataType.WizardDirectionStepType, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Ope_TRASF_UnitaMagazzino = 1 'INIT AT ERROR

            Select Case inWizardDirectionStep
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext
                    Select Case inSourceForm.GetType.Name
                        Case frmMenuTrasferMain.GetType.Name, frmMenuUscitaMerciMain.GetType.Name    '>>>> VADO ALLO STEP 1
                            frmTRASF_UM_Part_1_UM_OriForm = New frmTRASF_UM_Part_1_UM_Ori
                            clsTrasfMat.ClearAllData() 'INIT
                            clsTrasfMat.SourceForm = inSourceForm
                            clsTrasfMat.FunctionTransferMaterialType = inFunctionTransferUMType
                            frmTRASF_UM_Part_1_UM_OriForm.Show()
                        Case frmTRASF_UM_Part_1_UM_Ori.GetType.Name '>>>> VADO ALLO STEP 2
                            Select Case inFunctionTransferUMType
                                Case clsDataType.FunctionTransferMaterialType.FunctionTransferMaterialTypeForUMTransfer
                                    frmTRASF_UM_Part_2_Ubi_DestForm = New frmTRASF_UM_Part_2_Ubi_Dest
                                    frmTRASF_UM_Part_2_Ubi_DestForm.Show()
                                Case clsDataType.FunctionTransferMaterialType.FunctionTransferMaterialTypeForUMChangeLabel
                                    frmTRASF_UM_Part_2_UM_DestForm = New frmTRASF_UM_Part_2_UM_Dest
                                    frmTRASF_UM_Part_2_UM_DestForm.Show()
                                Case Else
                                    ErrDescription = clsAppTranslation.GetSingleParameterValue(914, "", "Caso ") & " [FunctionTransferUMType] Non previsto."
                                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                            End Select
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious
                    Select Case inSourceForm.GetType.Name
                        Case frmTRASF_UM_Part_2_Ubi_Dest.GetType.Name '>>>> TORNO ALLO STEP 1
                            frmTRASF_UM_Part_1_UM_OriForm = New frmTRASF_UM_Part_1_UM_Ori
                            frmTRASF_UM_Part_1_UM_OriForm.Show()
                        Case frmTRASF_UM_Part_2_UM_Dest.GetType.Name '>>>> TORNO ALLO STEP 1
                            frmTRASF_UM_Part_1_UM_OriForm = New frmTRASF_UM_Part_1_UM_Ori
                            frmTRASF_UM_Part_1_UM_OriForm.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartSeq 'INIZIO UNA NUOVA SEQUENZA OPERATIVA
                    Select Case inSourceForm.GetType.Name
                        Case frmTRASF_UM_Part_2_Ubi_Dest.GetType.Name, frmTRASF_UM_Part_2_UM_Dest.GetType.Name '>>>> TORNO ALLO STEP 1
                            frmTRASF_UM_Part_1_UM_OriForm = New frmTRASF_UM_Part_1_UM_Ori
                            clsTrasfMat.ClearAllData() 'INIT
                            clsTrasfMat.SourceForm = inSourceForm
                            clsTrasfMat.FunctionTransferMaterialType = inFunctionTransferUMType
                            frmTRASF_UM_Part_1_UM_OriForm.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case Else
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(913, "", "Direzione Step Non prevista (WizardDirectionStep).")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
            End Select

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Ope_TRASF_UnitaMagazzino = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Ope_TRASF_UnitaMagazzino = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Public Shared Function Show_Ope_EntrataMerci_FromStock(ByRef inSourceForm As Form, ByVal inEM_Prod_SourceType As clsEMFromStock.EM_Stock_SourceType, ByVal inWizardDirectionStep As clsDataType.WizardDirectionStepType, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Ope_EntrataMerci_FromStock = 1 'INIT AT ERROR

            Select Case inWizardDirectionStep
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext
                    Select Case inSourceForm.GetType.Name
                        Case frmMenuEntrataMerci.GetType.Name    '>>>> VADO ALLO STEP 1
                            Select Case inEM_Prod_SourceType
                                Case clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeStockList
                                    frmEM_StockList_Part_1_FilterForm = New frmEM_StockList_Part_1_Filter
                                    clsEMFromStock.ClearAllData() 'INIT
                                    frmEM_StockList_Part_1_FilterForm.Show()
                                Case clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeOdP
                                    frmEM_FromStock_Part_1_OdpForm = New frmEM_FromStock_Part_1_Odp
                                    clsEMFromStock.ClearAllData() 'INIT
                                    clsEMFromStock.EM_StockSourceType = inEM_Prod_SourceType
                                    frmEM_FromStock_Part_1_OdpForm.Show()
                                Case clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUM_Generic, clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUM_FromOdp, clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUM_MovTransfLoad
                                    frmEM_FromStock_Part_1_UMForm = New frmEM_FromStock_Part_1_UM
                                    clsEMFromStock.ClearAllData() 'INIT
                                    clsEMFromStock.EM_StockSourceType = inEM_Prod_SourceType
                                    clsEMFromStock.SourceForm = inSourceForm
                                    frmEM_FromStock_Part_1_UMForm.Show()
                                Case clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUM_MovTransfUnLoad
                                    frmEM_FromStock_Part_1_Trasf_SelUbiSpuntaForm = New frmEM_FromStock_Part_1_Trasf_SelUbiSpunta
                                    clsEMFromStock.ClearAllData() 'INIT
                                    clsEMFromStock.SourceForm = inSourceForm
                                    frmEM_FromStock_Part_1_Trasf_SelUbiSpuntaForm.Show()
                                Case clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUDCJobsMoveList
                                    frmUDCJobsMoveListForm = New frmUDCJobsMoveList
                                    clsEMFromStock.ClearAllData() 'INIT
                                    clsEMFromStock.SourceForm = inSourceForm
                                    frmUDCJobsMoveListForm.Show()
                            End Select
                        Case frmEM_StockList_Part_1_Filter.GetType.Name
                            frmEM_List_Part_2_List_GiacenzeForm = New frmEM_StockList_Part_2_List_Giacenze
                            frmEM_List_Part_2_List_GiacenzeForm.Show()
                        Case frmEM_StockList_Part_2_List_Giacenze.GetType.Name
                            frmEM_List_Part_3_ConfQtaForm = New frmEM_FromStock_Part_3_ConfQta
                            frmEM_List_Part_3_ConfQtaForm.Show()
                        Case frmEM_FromStock_Part_3_ConfQta.GetType.Name
                            frmEM_List_Part_5_FinalConfirmForm = New frmEM_FromStock_Part_4_ConfirmUM
                            frmEM_List_Part_5_FinalConfirmForm.Show()
                        Case frmEM_FromStock_Part_1_UM.GetType.Name   '>>>> VADO ALLO STEP 2
                            If Not (inEM_Prod_SourceType = clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUM_MovTransfLoad) Then
                                frmEM_FromStock_Part_4_ConfirmUbiDestForm = New frmEM_FromStock_Part_4_ConfirmUbiDest
                                frmEM_FromStock_Part_4_ConfirmUbiDestForm.Show()
                            Else
                                frmEM_FromStock_Part_4_ConfirmMovTrasfForm = New frmEM_FromStock_Part_4_ConfirmMovTrasf
                                clsEMFromStock.SourceForm = inSourceForm
                                frmEM_FromStock_Part_4_ConfirmMovTrasfForm.Show()
                            End If
                        Case frmEM_FromStock_Part_1_Trasf_SelUbiSpunta.GetType.Name   '>>>> VADO ALLO STEP 2
                            frmEM_FromStock_Part_1_Trasf_UMForm = New frmEM_FromStock_Part_1_Trasf_UM
                            clsEMFromStock.ClearAllData() 'INIT
                            clsEMFromStock.SourceForm = inSourceForm
                            frmEM_FromStock_Part_1_Trasf_UM.Show()
                        Case frmEM_FromStock_Part_1_Trasf_UM.GetType.Name   '>>>> VADO ALLO STEP 2
                            frmEM_FromStock_Part_4_TrasfConfirmMovForm = New frmEM_FromStock_Part_4_TrasfConfirmMov
                            clsEMFromStock.SourceForm = inSourceForm
                            frmEM_FromStock_Part_4_TrasfConfirmMovForm.Show()
                        Case frmUDCJobsMoveList.GetType.Name
                            frmEM_FromStock_Part_1_UMForm = New frmEM_FromStock_Part_1_UM
                            clsEMFromStock.ClearAllData() 'INIT
                            clsEMFromStock.SourceForm = inSourceForm
                            frmEM_FromStock_Part_1_UMForm.Show()
                        Case frmEM_FromJob_Part_ShowStock.GetType.Name '>>>> VADO ALLO STEP SUCCESSIVO
                            frmEM_FromStock_Part_4_ConfirmUbiDestForm = New frmEM_FromStock_Part_4_ConfirmUbiDest
                            frmEM_FromStock_Part_4_ConfirmUbiDestForm.Show()
                            frmEM_FromStock_Part_4_ConfirmUbiDestForm.ConfermaSelezioneStock() '>>> IMPOSTO UBICAZIONE SELEZIONATA
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(914, "", "Caso ") & " [FunctionTransferUMType] Non previsto."
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious
                    Select Case inSourceForm.GetType.Name
                        Case frmEM_StockList_Part_2_List_Giacenze.GetType.Name
                            frmEM_StockList_Part_1_FilterForm = New frmEM_StockList_Part_1_Filter
                            frmEM_StockList_Part_1_FilterForm.Show()
                        Case frmEM_FromStock_Part_3_ConfQta.GetType.Name '>>>> TORNO ALLO STEP PRECEDENTE IN BASE AL FLUSSO
                            Select Case inEM_Prod_SourceType
                                Case clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeStockList
                                    frmEM_List_Part_2_List_GiacenzeForm = New frmEM_StockList_Part_2_List_Giacenze
                                    frmEM_List_Part_2_List_GiacenzeForm.Show()
                                Case clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeOdP
                                    frmEM_FromStock_Part_1_OdpForm = New frmEM_FromStock_Part_1_Odp
                                    frmEM_FromStock_Part_1_OdpForm.Show()
                                Case clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUM_FromOdp, clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUM_Generic
                                    frmEM_FromStock_Part_1_UMForm = New frmEM_FromStock_Part_1_UM
                                    frmEM_FromStock_Part_1_UMForm.Show()
                            End Select
                        Case frmEM_FromStock_Part_4_ConfirmUbiDest.GetType.Name '>>>> TORNO ALLO STEP 1
                            frmEM_FromStock_Part_1_UMForm = New frmEM_FromStock_Part_1_UM
                            frmEM_FromStock_Part_1_UMForm.Show()
                        Case frmEM_FromStock_Part_4_ConfirmUM.GetType.Name '>>>> TORNO ALLO STEP 2 DA SCELTA COMMESSA
                            Select Case inEM_Prod_SourceType
                                Case clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeStockList
                                    '???? DA VEDERE 
                                    frmEM_List_Part_2_List_GiacenzeForm = New frmEM_StockList_Part_2_List_Giacenze
                                    frmEM_List_Part_2_List_GiacenzeForm.Show()
                                Case clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeOdP
                                    frmEM_FromStock_Part_1_OdpForm = New frmEM_FromStock_Part_1_Odp
                                    frmEM_FromStock_Part_1_OdpForm.Show()
                                Case clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUM_FromOdp, clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUM_Generic
                                    frmEM_FromStock_Part_1_UMForm = New frmEM_FromStock_Part_1_UM
                                    frmEM_FromStock_Part_1_UMForm.Show()
                            End Select
                        Case frmEM_FromStock_Part_4_ConfirmMovTrasf.GetType.Name
                            frmEM_FromStock_Part_1_UMForm = New frmEM_FromStock_Part_1_UM
                            frmEM_FromStock_Part_1_UMForm.Show()
                        Case frmEM_FromStock_Part_4_TrasfConfirmMov.GetType.Name
                            frmEM_FromStock_Part_1_Trasf_UMForm = New frmEM_FromStock_Part_1_Trasf_UM
                            frmEM_FromStock_Part_1_Trasf_UMForm.Show()
                        Case frmUDCJobsMoveList.GetType.Name
                            frmMenuEntrataMerciForm = New frmMenuEntrataMerci
                            frmMenuEntrataMerciForm.Show()
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SouceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select

                Case clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartSeq 'INIZIO UNA NUOVA SEQUENZA OPERATIVA

                    Select Case inSourceForm.GetType.Name

                        Case frmEM_FromStock_Part_4_ConfirmUbiDest.GetType.Name '>>>> TORNO ALLO STEP 1

                            Select Case inEM_Prod_SourceType

                                Case clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeStockList
                                    frmEM_List_Part_2_List_GiacenzeForm = New frmEM_StockList_Part_2_List_Giacenze
                                    frmEM_List_Part_2_List_GiacenzeForm.Show()
                                Case clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeOdP
                                    frmEM_FromStock_Part_1_OdpForm = New frmEM_FromStock_Part_1_Odp
                                    clsEMFromStock.ClearAllData() 'INIT
                                    clsEMFromStock.EM_StockSourceType = inEM_Prod_SourceType
                                    frmEM_FromStock_Part_1_OdpForm.Show()
                                Case clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUM_FromOdp, clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUM_Generic
                                    frmEM_FromStock_Part_1_UMForm = New frmEM_FromStock_Part_1_UM
                                    clsEMFromStock.ClearAllData() 'INIT
                                    clsEMFromStock.SourceForm = inSourceForm
                                    frmEM_FromStock_Part_1_UMForm.Show()
                                Case Else
                                    frmEM_FromStock_Part_1_UMForm = New frmEM_FromStock_Part_1_UM
                                    clsEMFromStock.ClearAllData() 'INIT
                                    clsEMFromStock.SourceForm = inSourceForm
                                    frmEM_FromStock_Part_1_UMForm.Show()
                            End Select

                        Case frmEM_FromStock_Part_4_ConfirmMovTrasf.GetType.Name
                            frmEM_FromStock_Part_1_UMForm = New frmEM_FromStock_Part_1_UM
                            clsEMFromStock.ClearAllData() 'INIT
                            clsEMFromStock.SourceForm = inSourceForm
                            frmEM_FromStock_Part_1_UMForm.Show()

                        Case frmEM_FromStock_Part_4_TrasfConfirmMov.GetType.Name
                            frmEM_FromStock_Part_1_Trasf_UMForm = New frmEM_FromStock_Part_1_Trasf_UM
                            clsEMFromStock.ClearAllData() 'INIT
                            clsEMFromStock.SourceForm = inSourceForm
                            frmEM_FromStock_Part_1_Trasf_UMForm.Show()

                        Case frmEM_FromStock_Part_5_Trasf_ConfirmSKU.GetType.Name
                            frmEM_FromStock_Part_1_Trasf_UMForm = New frmEM_FromStock_Part_1_Trasf_UM
                            clsEMFromStock.ClearAllData() 'INIT
                            clsEMFromStock.SourceForm = inSourceForm
                            frmEM_FromStock_Part_1_Trasf_UMForm.Show()

                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(570, "", "Caso SourceForm Non prevista (SourceForm.Name).")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE

                    End Select
                Case Else
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(913, "", "Direzione Step Non prevista (WizardDirectionStep).")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
            End Select

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Ope_EntrataMerci_FromStock = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Ope_EntrataMerci_FromStock = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Public Shared Function Show_Info_ForkLift(ByRef inSourceForm As Form, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Info_ForkLift = 1 'init at error

            frmInfoForkLiftForm = New frmInfoForkLift
            frmInfoForkLiftForm.Show()

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Info_ForkLift = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Public Shared Function Show_Select_ForkLift(ByRef inSourceForm As Form, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Select_ForkLift = 1 'init at error

            frmSelectForkLiftForm = New frmSelectForkLift
            frmSelectForkLiftForm.Show()
            frmSelectForkLiftForm.SourceForm = inSourceForm

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Select_ForkLift = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Public Shared Function Show_SelectUbicazioneSpecial(ByRef inSourceForm As Form, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_SelectUbicazioneSpecial = 1 'init at error

            frmSelectUbicazioneSpecialForm = New frmSelectUbicazioneSpecial
            frmSelectUbicazioneSpecialForm.Show()
            frmSelectUbicazioneSpecialForm.SourceForm = inSourceForm

            'RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_SelectUbicazioneSpecial = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Public Shared Function Show_SelectUserTipiMag(ByRef inSourceForm As Form, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_SelectUserTipiMag = 1 'init at error

            frmSelectUserTipiMagForm = New frmSelectUserTipiMag
            frmSelectUserTipiMagForm.Show()
            frmSelectUserTipiMagForm.SourceForm = inSourceForm

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_SelectUserTipiMag = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Public Shared Function Show_Select_UserPickQueue(ByRef inSourceForm As Form, ByVal inEscludeEmptyQueue As Boolean, ByVal inGetOnlyOpenJobs As Boolean, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Select_UserPickQueue = 1 'init at error

            frmSelectUserPickQueuesForm = New frmSelectUserPickQueues

            frmSelectUserPickQueuesForm.EscludeEmptyQueue = inEscludeEmptyQueue
            frmSelectUserPickQueuesForm.GetOnlyOpenJobs = inGetOnlyOpenJobs
            frmSelectUserPickQueuesForm.Show()
            frmSelectUserPickQueuesForm.SourceForm = inSourceForm

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Select_UserPickQueue = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function


    Public Shared Function Show_Select_UserTaskLinesAssigned(ByRef inSourceForm As Form, ByVal inEscludeEmptyQueue As Boolean, ByVal inGetOnlyOpenJobs As Boolean, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Select_UserTaskLinesAssigned = 1 'init at error

            frmPickingMerci_TaskLinesAssignedForm = New frmPickingMerci_TaskLinesAssigned

            'frmPickingMerci_TaskLinesAssignedForm.EscludeEmptyQueue = inEscludeEmptyQueue
            'frmPickingMerci_TaskLinesAssignedForm.GetOnlyOpenJobs = inGetOnlyOpenJobs
            frmPickingMerci_TaskLinesAssignedForm.Show()
            frmPickingMerci_TaskLinesAssignedForm.SourceForm = inSourceForm

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Select_UserTaskLinesAssigned = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function


    Public Shared Function Show_Ope_PrintLabelUdC(ByRef inSourceForm As Form, ByVal SelezionePrintLabelType As clsDataType.SelezionePrintLabelType, ByVal inWizardDirectionStep As WizardDirectionStepType, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Ope_PrintLabelUdC = 1 'INIT AT ERROR

            Select Case inWizardDirectionStep
                Case WizardDirectionStepType.WizardDirectionStepTypeNext
                    Select Case inSourceForm.GetType.Name
                        Case frmMenuStampaLabel.GetType.Name    '>>>> VADO ALLO STEP 1
                            clsDataType.SelPrintLabelType = SelezionePrintLabelType.SelezionePrintLabelTypeNone
                            frmPrintLabelUdcForm = New frmPrintLabelUdc
                            frmPrintLabelUdcForm.Show()
                        Case frmEM_FromJob_Part_ChiudiLista.GetType.Name    '>>>> VADO ALLO STEP 1
                            clsDataType.SelPrintLabelType = SelezionePrintLabelType.SelezionePrintLabelTypePrintUDC
                            frmPrintLabelUdcForm = New frmPrintLabelUdc
                            frmPrintLabelUdcForm.Show()
                        Case Else
                            ErrDescription = "Caso SourceForm Non prevista (SourceForm.Name)."
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case WizardDirectionStepType.WizardDirectionStepTypePrevious
                    Select Case clsDataType.SelPrintLabelType
                        Case clsDataType.SelezionePrintLabelType.SelezionePrintLabelTypePrintUDC
                            clsDataType.SelPrintLabelType = SelezionePrintLabelType.SelezionePrintLabelTypeNone
                            frmEM_FromJob_Part_ChiudiListaForm = New frmEM_FromJob_Part_ChiudiLista
                            frmEM_FromJob_Part_ChiudiLista.Show()
                        Case clsDataType.SelezionePrintLabelType.SelezionePrintLabelTypeNone
                            Select Case inSourceForm.GetType.Name
                                Case frmPrintLabelUdcForm.GetType.Name '>>>> TORNO ALLO STEP 1
                                    clsDataType.SelPrintLabelType = SelezionePrintLabelType.SelezionePrintLabelTypeNone
                                    frmMenuStampaLabelForm = New frmMenuStampaLabel
                                    frmMenuStampaLabelForm.Show()
                                Case Else
                                    ErrDescription = "Caso SourceForm Non prevista (SourceForm.Name)."
                                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                            End Select
                    End Select
                Case Else
                    ErrDescription = "Direzione Step Non prevista (WizardDirectionStep)."
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
            End Select

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Ope_PrintLabelUdC = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Ope_PrintLabelUdC = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function


    Public Shared Function Show_Ope_PrintLabelUdS(ByRef inSourceForm As Form, ByVal inWizardDirectionStep As WizardDirectionStepType, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Ope_PrintLabelUdS = 1 'INIT AT ERROR

            Select Case inWizardDirectionStep
                Case WizardDirectionStepType.WizardDirectionStepTypeNext
                    Select Case inSourceForm.GetType.Name
                        Case frmMenuStampaLabel.GetType.Name    '>>>> VADO ALLO STEP 1
                            frmPrintLabelUdsForm = New frmPrintLabelUds
                            frmPrintLabelUdsForm.Show()
                        Case Else
                            ErrDescription = "Caso SourceForm Non prevista (SourceForm.Name)."
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case WizardDirectionStepType.WizardDirectionStepTypePrevious
                    Select Case inSourceForm.GetType.Name
                        Case frmPrintLabelUdsForm.GetType.Name '>>>> TORNO ALLO STEP 1
                            frmMenuStampaLabelForm = New frmMenuStampaLabel
                            frmMenuStampaLabelForm.Show()
                        Case Else
                            ErrDescription = "Caso SourceForm Non prevista (SourceForm.Name)."
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select

                Case Else
                    ErrDescription = "Direzione Step Non prevista (WizardDirectionStep)."
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
            End Select

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Ope_PrintLabelUdS = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Ope_PrintLabelUdS = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function


    Public Shared Function Show_Ope_PrintLabelKTag(ByRef inSourceForm As Form, ByVal inWizardDirectionStep As WizardDirectionStepType, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Ope_PrintLabelKTag = 1 'INIT AT ERROR

            Select Case inWizardDirectionStep
                Case WizardDirectionStepType.WizardDirectionStepTypeNext
                    Select Case inSourceForm.GetType.Name
                        Case frmMenuStampaLabel.GetType.Name    '>>>> VADO ALLO STEP 1
                            frmPrintLabelKTagForm = New frmPrintLabelKTag
                            frmPrintLabelKTagForm.Show()
                        Case Else
                            ErrDescription = "Caso SourceForm Non prevista (SourceForm.Name)."
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case WizardDirectionStepType.WizardDirectionStepTypePrevious
                    Select Case inSourceForm.GetType.Name
                        Case frmPrintLabelKTagForm.GetType.Name '>>>> TORNO ALLO STEP 1
                            frmMenuStampaLabelForm = New frmMenuStampaLabel
                            frmMenuStampaLabelForm.Show()
                        Case Else
                            ErrDescription = "Caso SourceForm Non prevista (SourceForm.Name)."
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select

                Case Else
                    ErrDescription = "Direzione Step Non prevista (WizardDirectionStep)."
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
            End Select

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Ope_PrintLabelKTag = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Ope_PrintLabelKTag = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Public Shared Function Show_Ope_InsPalletId(ByRef inSourceForm As Form, ByVal inWizardDirectionStep As WizardDirectionStepType, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Ope_InsPalletId = 1 'INIT AT ERROR

            Select Case inWizardDirectionStep
                Case WizardDirectionStepType.WizardDirectionStepTypeNext
                    Select Case inSourceForm.GetType.Name
                        Case frmPickingMerci_Code_5_Sel_CodMatOrigine.GetType.Name    '>>>> VADO ALLO STEP 1
                            frmPickingMerci_Code_InsPalletIdForm = New frmPickingMerci_Code_InsPalletId
                            frmPickingMerci_Code_InsPalletIdForm.Show()
                        Case Else
                            ErrDescription = "Caso SourceForm Non prevista (SourceForm.Name)."
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case WizardDirectionStepType.WizardDirectionStepTypePrevious
                    Select Case inSourceForm.GetType.Name
                        Case frmPickingMerci_Code_InsPalletId.GetType.Name '>>>> TORNO ALLO STEP 1
                            frmPickingMerci_Code_5_Sel_CodMatOrigineForm = New frmPickingMerci_Code_5_Sel_CodMatOrigine
                            frmPickingMerci_Code_5_Sel_CodMatOrigineForm.Show()
                        Case Else
                            ErrDescription = "Caso SourceForm Non prevista (SourceForm.Name)."
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select

                Case Else
                    ErrDescription = "Direzione Step Non prevista (WizardDirectionStep)."
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    frmPickingMerci_Code_5_Sel_CodMatOrigineForm = New frmPickingMerci_Code_5_Sel_CodMatOrigine
                    frmPickingMerci_Code_5_Sel_CodMatOrigineForm.Show() '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
            End Select

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Ope_InsPalletId = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Ope_InsPalletId = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Public Shared Function Show_Ope_InsLocation(ByRef inSourceForm As Form, ByVal inWizardDirectionStep As WizardDirectionStepType, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Show_Ope_InsLocation = 1 'INIT AT ERROR

            Select Case inWizardDirectionStep
                Case WizardDirectionStepType.WizardDirectionStepTypeNext
                    Select Case inSourceForm.GetType.Name
                        Case frmPickingMerci_Code_4_Sel_UMOrigine.GetType.Name    '>>>> VADO ALLO STEP 1
                            frmPickingMerci_Code_InsLocationForm = New frmPickingMerci_Code_InsLocation
                            frmPickingMerci_Code_InsLocationForm.Show()
                        Case Else
                            ErrDescription = "Caso SourceForm Non prevista (SourceForm.Name)."
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select
                Case WizardDirectionStepType.WizardDirectionStepTypePrevious
                    Select Case inSourceForm.GetType.Name
                        Case frmPickingMerci_Code_InsLocation.GetType.Name '>>>> TORNO ALLO STEP 1
                            frmPickingMerci_Code_4_Sel_UMOrigineForm = New frmPickingMerci_Code_4_Sel_UMOrigine
                            frmPickingMerci_Code_4_Sel_UMOrigineForm.Show()
                        Case Else
                            ErrDescription = "Caso SourceForm Non prevista (SourceForm.Name)."
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
                    End Select

                Case Else
                    ErrDescription = "Direzione Step Non prevista (WizardDirectionStep)."
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    frmPickingMerci_Code_4_Sel_UMOrigineForm = New frmPickingMerci_Code_4_Sel_UMOrigine
                    frmPickingMerci_Code_4_Sel_UMOrigineForm.Show() '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
            End Select

            RetCode = CloseSourceForm(inSourceForm, inShowMessageBox)

            Show_Ope_InsLocation = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Show_Ope_InsLocation = 1000 'CATCH ERROR CONDITION
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            RetCode = Show_Mnu_Home(inSourceForm, True) '>>> IN CASO DI ERRORE TORNO AL MENU PRINCIPALE
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function


End Class