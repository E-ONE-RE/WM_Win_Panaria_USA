' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 30/05/2013
' DATA MODIFICA     : 30/05/2013
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa le funzioni di gestione delle missioni [ZWMS_JOBS] 
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType
Imports clsSapUtility
Imports clsSapWS
Imports clsNavigation
Imports clsBusinessLogic
Imports clsUDS
Imports clsTASKLINES

Public Class clsWmsJob

    '*****************************************
    ' >>> COSTANTI PER STATO JOB
    Public Const cstIdJobStatus_Nullo = 0
    Public Const cstIdJobStatus_Nuovo = 1
    Public Const cstIdJobStatus_Pianificato = 2
    Public Const cstIdJobStatus_Assegnato = 5
    Public Const cstIdJobStatus_Iniziato = 10
    Public Const cstIdJobStatus_Sospeso = 90
    Public Const cstIdJobStatus_Cancellato = 95
    Public Const cstIdJobStatus_Verificato = 96
    Public Const cstIdJobStatus_Terminato = 99

    '*****************************************
    ' >>> COSTANTI PER TIPO JOB
    Public Const cstIdJobType_CheckMaterial = "001"
    Public Const cstIdJobType_PickPronto = "010"
    Public Const cstIdJobType_PickPronto1S = "020"
    Public Const cstIdJobType_Pick_To_916 = "030"
    Public Const cstIdJobType_PickLogicoPrt = "040"
    Public Const cstIdJobType_DisaccantonaZ08 = "300"
    Public Const cstIdJobType_DisaccantonaLog = "301"


    '*****************************************
    ' >>> TIPI DI DATI
    Public Enum PickingMerci_JobDestinationType
        PickingMerci_JobDestinationTypeNone = 0
        PickingMerci_JobDestinationTypeMagPronto = 1
        PickingMerci_JobDestinationTypeUscitaWm916 = 2
        PickingMerci_JobDestinationTypeMagIntermedio = 3
        PickingMerci_JobDestinationTypeVerificaCaricoCamion = 10
    End Enum
    Public Enum PickingMerci_DestinationType
        PickingMerci_DestinationTypeNone = 0
        PickingMerci_DestinationTypeUbicazioneEnter = 1
        PickingMerci_DestinationTypeUMEnter = 2
        PickingMerci_DestinationTypeUbieUMEnter = 3
    End Enum

    Public Enum PickingMerci_SourceType
        PickingMerci_SourceTypeNone = 0
        PickingMerci_SourceTypeCodMatEnter = 1
        PickingMerci_SourceTypeUbicazioneEnter = 2
        PickingMerci_SourceTypeUMEnter = 3
        PickingMerci_SourceTypeUbieUMEnter = 10
        PickingMerci_SourceTypeManualSelection = 99
    End Enum

    Public Enum Disaccantonamento_SourceType
        Disaccantonamento_SourceTypeNone = 0
        Disaccantonamento_SourceTypeJobsGroup = 1
        Disaccantonamento_SourceTypeManualSelection = 99
    End Enum


    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsWmsJob"

    'OGGETTO DATA TABLE PER VISUALIZZARE DATI NELLE GRIGLIE
    Public Shared objDataTableWmsJobsList As New DataTable
    Public Shared objDataTableWmsJobsAutoTransferList As New DataTable

    Public Shared objDataTableDetailsWmsJobList As New DataTable

    Public Shared objDetailsDataRow As Data.DataRow

    Public Shared RowIndex As Long

    Public Shared WmsJob As clsDataType.SapWmWmsJob
    Public Shared WmsJobsGroupExecInfo As clsDataType.SapWmJobsGroupExecTab

    Public Shared WmOtInfo() As clsDataType.SapWmOtInfo

    Public Shared FlagForcedStepEnded As Boolean
    Public Shared FlagOutDestFoundAreaPD As Boolean

    Public Shared DestinationUbicazione As clsDataType.SapWmUbicazione

    'INFORMAZIONI CON LE GIACENZE CONFERMATE DELL'OPERATORE
    Public Shared MaterialeGiacenzeConfirmed() As clsDataType.SapWmGiacenza

    'INFORMAZIONI CON LE UBICAZIONI DI ORIGINE PROPOSTE PER IL PRELIEVO
    Public Shared DescrUbicOriPick As String
    Public Shared MaterialePickOriGiacenze() As clsDataType.SapWmGiacenza

    'INFORMAZIONI CON LE UBICAZIONI DI DESTINAZIONE PROPOSTE PER IL PRELIEVO
    Public Shared DescrUbicDestPick As String
    Public Shared MaterialePickDestinations() As clsDataType.SapWmGiacenza
    Public Shared IndexUbiVuotaDest As Long

    'INFO CON LE GIACENZE DI STOCK COMPATIBILE CONFERMATO (PER STEP SELEZIONE STOCK ORIGINE)
    Public Shared MaterialeSelStockGiacenzaOri As clsDataType.SapWmGiacenza

    'INFO GIACENZA SELEZIONATA PER DESTINAZIONE (INFO MANDATARIE SONO L'UBICAZIONE)
    Public Shared MaterialeSelStockGiacenzaDest As clsDataType.SapWmGiacenza

    Public Shared StockSelezionatoUtente As clsDataType.SapWmUbicazione
    Public Shared UbicazioneUltimoPickingCodeOrigine As clsDataType.SapWmUbicazione
    Public Shared UbicazionePDPickingCodeDestinatione As clsDataType.SapWmUbicazione

    Public Shared UDSOnWork As New clsUDS
    Public Shared TaskLines As New clsTaskLines

    Private Shared ErrDescription As String
    Private Shared SapFunctionError As clsBusinessLogic.SapFunctionError

    'OGGETTO DATA TABLE PER VISUALIZZARE DATI NELLE GRIGLIE
    Public Shared objDataTableGiacenzeOriInfo As New DataTable
    Public Shared objDataTableGiacenzeDestInfo As New DataTable

    Public Shared objDataTableForLockStock As New DataTable

    Public Shared objDataTableGiacenzeOriInfoTotStock As New DataTable


    Public Shared DisaccantonamentoSourceType As Disaccantonamento_SourceType
    Public Shared PickingMerciDestinationType As PickingMerci_DestinationType
    Public Shared PickingMerciSourceType As PickingMerci_SourceType

    Public Shared UbicaOrUnitaMagEntered As clsDataType.UbicaOrUnitaMagEnteredEnum
    Public Shared SkuOrUnitaMagEntered As clsDataType.SkuOrUnitaMagEnteredEnum

    Public Shared JobsQueueWeightInfo As clsDataType.JobsQueueWeightInfoStruct
    Public Shared ActionInfo As New clsActionTimeInfo
    Public Shared FlagNeedDrop As Boolean = False
    Public Shared FlagConfirmDone As Boolean = False
    Public Shared FlagStockFoundInOtherWh As Boolean = False
    Public Shared FlagFoundOneStockWithSKU As Boolean = False

    Public Shared Function ClearAllData() As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ClearAllData = 1 'init at error


            UbicaOrUnitaMagEntered = clsDataType.UbicaOrUnitaMagEnteredEnum.UbicaOrUnitaMagEnteredNone
            SkuOrUnitaMagEntered = clsDataType.SkuOrUnitaMagEnteredEnum.SkuOrUnitaMagEnteredNone

            RetCode += clsSapUtility.ResetWmsJobStruct(WmsJob)
            RetCode += clsSapUtility.ResetWmJobsGroupExecTabStruct(WmsJobsGroupExecInfo)

            RetCode += ClearWmsJobsListInfo()
            RetCode += ClearWmsJobsAutoTransferList()

            RetCode += clsSapUtility.ResetUbicazioneStruct(DestinationUbicazione)
            RetCode += clsSapUtility.ResetGiacenzaStruct(MaterialeSelStockGiacenzaOri)
            RetCode += clsSapUtility.ResetGiacenzaStruct(MaterialeSelStockGiacenzaDest)
            RetCode += clsSapUtility.ResetJobsQueueWeightInfoStruct(JobsQueueWeightInfo)
            RetCode += clsSapUtility.ResetUbicazioneStruct(StockSelezionatoUtente)
            RetCode += clsSapUtility.ResetUbicazioneStruct(UbicazioneUltimoPickingCodeOrigine)
            RetCode += clsSapUtility.ResetUbicazioneStruct(UbicazionePDPickingCodeDestinatione)

            If (Not MaterialeGiacenzeConfirmed Is Nothing) Then
                ReDim MaterialeGiacenzeConfirmed(0)
                MaterialeGiacenzeConfirmed.Clear(MaterialeGiacenzeConfirmed, 0, 0)
                MaterialeGiacenzeConfirmed = Nothing
            End If

            If (Not MaterialePickOriGiacenze Is Nothing) Then
                ReDim MaterialePickOriGiacenze(0)
                MaterialePickOriGiacenze.Clear(MaterialePickOriGiacenze, 0, 0)
                MaterialePickOriGiacenze = Nothing
            End If
            If (Not MaterialePickDestinations Is Nothing) Then
                ReDim MaterialePickDestinations(0)
                MaterialePickDestinations.Clear(MaterialePickDestinations, 0, 0)
                MaterialePickDestinations = Nothing
            End If

            RetCode += ActionInfo.ClearAllData()

            RetCode += TaskLines.ClearAllData()

            If (Not UDSOnWork Is Nothing) Then
                RetCode += UDSOnWork.ClearAllData()
            End If

            If (Not (objDataTableGiacenzeOriInfo Is Nothing)) Then
                objDataTableGiacenzeOriInfo.Rows.Clear()
            End If
            If (Not (objDataTableGiacenzeDestInfo Is Nothing)) Then
                objDataTableGiacenzeDestInfo.Rows.Clear()
            End If
            If (Not (objDataTableWmsJobsAutoTransferList Is Nothing)) Then
                objDataTableWmsJobsAutoTransferList.Rows.Clear()
            End If
            If (Not (objDataTableWmsJobsList Is Nothing)) Then
                objDataTableWmsJobsList.Rows.Clear()
            End If

            If (Not (objDataTableForLockStock Is Nothing)) Then
                objDataTableForLockStock.Rows.Clear()
            End If

            If (Not (objDataTableGiacenzeOriInfoTotStock Is Nothing)) Then
                objDataTableGiacenzeOriInfoTotStock.Rows.Clear()
            End If



            If (Not WmOtInfo Is Nothing) Then
                ReDim WmOtInfo(0)
            End If

            FlagNeedDrop = False
            FlagConfirmDone = False
            FlagForcedStepEnded = False
            FlagOutDestFoundAreaPD = False
            FlagFoundOneStockWithSKU = False
            ErrDescription = ""
            DescrUbicOriPick = ""
            DescrUbicDestPick = ""
            IndexUbiVuotaDest = -1
            RowIndex = 0

            DisaccantonamentoSourceType = Disaccantonamento_SourceType.Disaccantonamento_SourceTypeNone

            ClearAllData = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ClearAllData = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function IsValidJobsGroupExec() As Boolean
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        IsValidJobsGroupExec = False
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (WmsJobsGroupExecInfo.ExecGroupFound = True) And (WmsJobsGroupExecInfo.QtaGroupTotaleDaPrelevare > 0) Then
                If (WmsJobsGroupExecInfo.JobsGroupExecTab.Length > 1) Then
                    IsValidJobsGroupExec = True
                End If
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            IsValidJobsGroupExec = False 'CONDIZIONE DI CATCH ERROR
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetElementMaterialePickOriGiacenzaProposte(ByVal inIndex As Long, ByRef inOutSapWmGiacenza As clsDataType.SapWmGiacenza) As Long
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim NumElementi As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetElementMaterialePickOriGiacenzaProposte = 1 'init

            NumElementi = GetNumMaterialePickOriGiacenzaProposte()
            If (inIndex + 1 > NumElementi) Then
                RetCode = 10
                GetElementMaterialePickOriGiacenzaProposte = RetCode
                Exit Function
            End If

            inOutSapWmGiacenza = MaterialePickOriGiacenze(inIndex)

            GetElementMaterialePickOriGiacenzaProposte = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetElementMaterialePickOriGiacenzaProposte = 1000 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetElementMaterialePickDestinationProposte(ByVal inIndex As Long, ByRef inOutSapWmGiacenza As clsDataType.SapWmGiacenza) As Long
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim NumElementi As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetElementMaterialePickDestinationProposte = 1 'init

            NumElementi = GetNumMaterialePickDestinationProposte()
            If (inIndex + 1 > NumElementi) Then
                RetCode = 10
                GetElementMaterialePickDestinationProposte = RetCode
                Exit Function
            End If

            inOutSapWmGiacenza = MaterialePickDestinations(inIndex)

            GetElementMaterialePickDestinationProposte = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetElementMaterialePickDestinationProposte = 1000 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetNumMaterialePickOriGiacenzaProposte() As Long
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetNumMaterialePickOriGiacenzaProposte = 0 'init

            If (MaterialePickOriGiacenze Is Nothing) Then
                GetNumMaterialePickOriGiacenzaProposte = 0
                Exit Function
            End If

            GetNumMaterialePickOriGiacenzaProposte = MaterialePickOriGiacenze.Length

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetNumMaterialePickOriGiacenzaProposte = 0 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetNumRecDataTableWmsJobsAutoTransfer() As Long
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetNumRecDataTableWmsJobsAutoTransfer = 0 'init

            If (objDataTableWmsJobsAutoTransferList Is Nothing) Then
                Exit Function
            End If

            GetNumRecDataTableWmsJobsAutoTransfer = objDataTableWmsJobsAutoTransferList.Rows.Count

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetNumRecDataTableWmsJobsAutoTransfer = 1000 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetNumMaterialePickDestinationProposte() As Long
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetNumMaterialePickDestinationProposte = 0 'init

            If (MaterialePickDestinations Is Nothing) Then
                Exit Function
            End If

            GetNumMaterialePickDestinationProposte = MaterialePickDestinations.Length

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetNumMaterialePickDestinationProposte = 1000 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function ShowUDSOnWorkLabelInfoForUserString() As String

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ShowUDSOnWorkLabelInfoForUserString = ""

            ShowUDSOnWorkLabelInfoForUserString = clsAppTranslation.GetSingleParameterValue(1429, "", "UDS ATTIVO:")

            If (UDSOnWork Is Nothing) Then Exit Function

            If (clsUtility.IsStringValid(UDSOnWork.UnitaMagazzino, True) = True) Then
                ShowUDSOnWorkLabelInfoForUserString = ShowUDSOnWorkLabelInfoForUserString + clsSapUtility.FormattaStringaUnitaMagazzino(UDSOnWork.UnitaMagazzino)
            Else
                ShowUDSOnWorkLabelInfoForUserString = ShowUDSOnWorkLabelInfoForUserString + clsAppTranslation.GetSingleParameterValue(1480, "", "NESSUNA")
            End If

            ShowUDSOnWorkLabelInfoForUserString = ShowUDSOnWorkLabelInfoForUserString + " - " + clsAppTranslation.GetSingleParameterValue(1481, "", "MATERIALI PRELEVATI") + ":" + Trim(Str(UDSOnWork.GetNumComponentiUDS()))

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ShowUDSOnWorkLabelInfoForUserString = "" 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function ShowJobQtyToPickCompleteForUserString(ByRef inTaskLines As clsTaskLines, ByRef inWmsJob As clsDataType.SapWmWmsJob, ByVal inShowQtyOnlyForCurrenteTask As Boolean, Optional inCompressMode As Boolean = False) As String

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ShowJobQtyToPickCompleteForUserString = ""

            If (inShowQtyOnlyForCurrenteTask = True) Then
                'CASO IN CUI DEVO VISUALIZZARE SOLO LA QTA ASSOCIATA AL TASK
                If (inTaskLines.TaskLinesInfo.NrWmsJobs > 0) And (clsUtility.IsStringValid(inTaskLines.TaskLinesOnWork.NrTaskLines, True) = True) Then
                    'CASO DI UN TASK ATTIVO DEVO GESTIRE IL CASO DI PRELIEVO FULL/PARZIALE/SFUSI
                    Select Case inTaskLines.TaskLinesOnWork.PickFullPartialType
                        Case clsTaskLines.cstTaskLinesPickType_FullPallet
                            If (inCompressMode = True) Then
                                'QTA RIMASTA DA PRELEVARE ( CASO FULL PALLET )
                                ShowJobQtyToPickCompleteForUserString = Trim(Str(inWmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaFullPallet)) + " PL/" + Trim(Str(0)) + " " + UCase(inWmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione) + "/" + Trim(Str(0)) + " " + inWmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraPezzo
                            Else
                                'QTA RIMASTA DA PRELEVARE ( CASO FULL PALLET )
                                ShowJobQtyToPickCompleteForUserString = " ( " + Trim(Str(inWmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaFullPallet)) + " PL/ " + Trim(Str(0)) + " " + UCase(inWmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione) + "/ " + Trim(Str(0)) + " " + inWmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraPezzo + " ) "
                            End If
                        Case clsTaskLines.cstTaskLinesPickType_PartialPallet, clsTaskLines.cstTaskLinesPickType_PickPieces
                            'QTA RIMASTA DA PRELEVARE ( CASO PARTIAL PALLET ) / ( CASO SFUSI )
                            If (inCompressMode = True) Then
                                ShowJobQtyToPickCompleteForUserString = Trim(Str(0)) + " PL/" + Trim(Str(inWmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaPartialPallet)) + " " + UCase(inWmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione) + "/" + Trim(Str(inWmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaSfusiInPZ)) + " " + inWmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraPezzo
                            Else
                                ShowJobQtyToPickCompleteForUserString = " ( " + Trim(Str(0)) + " PL/ " + Trim(Str(inWmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaPartialPallet)) + " " + UCase(inWmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione) + "/ " + Trim(Str(inWmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaSfusiInPZ)) + " " + inWmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraPezzo + " ) "
                            End If
                        Case Else
                            If (inCompressMode = True) Then
                                ShowJobQtyToPickCompleteForUserString = "ERROR CONDITION"
                            Else
                                ShowJobQtyToPickCompleteForUserString = " ( " + " ERROR CONDITION " + " )"
                            End If
                    End Select
                Else
                    If (inCompressMode = True) Then
                        'NESSUNA TASK LINES DEFINITA ( CASO DI ERRORE ) ??? VEDERE SE SEGNALARE
                        ShowJobQtyToPickCompleteForUserString = Trim(Str(inWmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaFullPallet)) + " PL/" + Trim(Str(inWmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaPartialPallet)) + " " + UCase(inWmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione) + "/" + Trim(Str(inWmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaSfusiInPZ)) + " " + inWmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraPezzo
                    Else
                        ShowJobQtyToPickCompleteForUserString = " ( " + Trim(Str(inWmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaFullPallet)) + " PL/ " + Trim(Str(inWmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaPartialPallet)) + " " + UCase(inWmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione) + "/ " + Trim(Str(inWmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaSfusiInPZ)) + " " + inWmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraPezzo + " ) "
                    End If

                End If
            Else
                If (inCompressMode = True) Then
                    'CASO IN  CUI VISUALIZZO TUTTE LE QTA ( PIENI/PARZIALI/SFUSI )
                    ShowJobQtyToPickCompleteForUserString = Trim(Str(inWmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaFullPallet)) + " PL/" + Trim(Str(inWmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaPartialPallet)) + " " + UCase(inWmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione) + "/" + Trim(Str(inWmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaSfusiInPZ)) + " " + inWmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraPezzo
                Else
                    ShowJobQtyToPickCompleteForUserString = " ( " + Trim(Str(inWmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaFullPallet)) + " PL/ " + Trim(Str(inWmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaPartialPallet)) + " " + UCase(inWmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione) + "/ " + Trim(Str(inWmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaSfusiInPZ)) + " " + inWmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraPezzo + " ) "
                End If

            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ShowJobQtyToPickCompleteForUserString = "" 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function ShowJobQtyToPutAwayCompleteForUserString() As String

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ShowJobQtyToPutAwayCompleteForUserString = ""


            ShowJobQtyToPutAwayCompleteForUserString = " ( " + Trim(Str(WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaFullPallet)) + " PL/ " + Trim(Str(WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaPartialPallet)) + " " + UCase(WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione) + "/ " + Trim(Str(WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaSfusiInPZ)) + " " + WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraPezzo + " ) "


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ShowJobQtyToPutAwayCompleteForUserString = "" 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function ShowJobQtyPickedCompleteForUserString(ByVal inShowQtyOnlyForCurrenteTask As Boolean) As String

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ShowJobQtyPickedCompleteForUserString = ""

            If (inShowQtyOnlyForCurrenteTask = True) Then
                'CASO IN CUI DEVO VISUALIZZARE SOLO LA QTA ASSOCIATA AL TASK
                If (TaskLines.TaskLinesInfo.NrWmsJobs > 0) And (clsUtility.IsStringValid(TaskLines.TaskLinesOnWork.NrTaskLines, True) = True) Then
                    'CASO DI UN TASK ATTIVO DEVO GESTIRE IL CASO DI PRELIEVO FULL/PARZIALE/SFUSI
                    Select Case TaskLines.TaskLinesOnWork.PickFullPartialType
                        Case clsTaskLines.cstTaskLinesPickType_FullPallet
                            'QTA RIMASTA DA PRELEVARE ( CASO FULL PALLET )
                            ShowJobQtyPickedCompleteForUserString = " ( " + Trim(Str(WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataFullPallet)) + " PL/ " + Trim(Str(0)) + " " + UCase(WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione) + "/ " + Trim(Str(0)) + " " + WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraPezzo + " ) "
                        Case clsTaskLines.cstTaskLinesPickType_PartialPallet, clsTaskLines.cstTaskLinesPickType_PickPieces
                            'QTA RIMASTA DA PRELEVARE ( CASO PARTIAL PALLET ) / ( CASO SFUSI )
                            ShowJobQtyPickedCompleteForUserString = " ( " + Trim(Str(0)) + " PL/ " + Trim(Str(WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataPartialPallet)) + " " + UCase(WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione) + "/ " + Trim(Str(WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataSfusi)) + " " + WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraPezzo + " ) "
                        Case Else
                            ShowJobQtyPickedCompleteForUserString = " ( " + " ERROR CONDITION " + " )"
                    End Select
                Else
                    'NESSUNA TASK LINES DEFINITA ( CASO DI ERRORE ) ??? VEDERE SE SEGNALARE
                    ShowJobQtyPickedCompleteForUserString = " ( " + Trim(Str(WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataFullPallet)) + " PL/ " + Trim(Str(WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataPartialPallet)) + " " + UCase(WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione) + "/ " + Trim(Str(WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataSfusi)) + " " + WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraPezzo + " ) "
                End If
            Else
                'CASO IN  CUI VISUALIZZO TUTTE LE QTA ( PIENI/PARZIALI/SFUSI )
                ShowJobQtyPickedCompleteForUserString = " ( " + Trim(Str(WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataFullPallet)) + " PL/ " + Trim(Str(WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataPartialPallet)) + " " + UCase(WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione) + "/ " + Trim(Str(WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataSfusi)) + " " + WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraPezzo + " ) "
            End If


                '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ShowJobQtyPickedCompleteForUserString = "" 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Public Shared Function GetJobInfoPrelievo(ByRef outInfoPrelievo As String) As Long
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetJobInfoPrelievo = 0 'init

            '>>> CASO DI USCITA MERCI (A) / ENTRATA MERCE (E)
            If (WmsJob.FlagRilevanteWM = "W") And (WmsJob.TipoDirezioneMissioneKZEAR = "A") Then
                outInfoPrelievo = WmsJob.InfoPrelievo
            End If

            GetJobInfoPrelievo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetJobInfoPrelievo = 1000 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetJobPickGroupExecInformation(ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim ExecutionOk As Boolean = False
        Dim ExecGroupFound As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetJobPickGroupExecInformation = 0 'init

            RetCode += clsSapUtility.ResetWmJobsGroupExecTabStruct(WmsJobsGroupExecInfo) 'init

            'VERIFICO SE CI SONO I PRESUPPOSTI PER AVERE IL RAGGRUPPAMENTO
            If (clsUtility.IsStringValid(WmsJob.CodiceGruppoMissioni, True) = False) Then
                '>>> NESSUN GRUPPO MISSIONI ESCO SENZA DARE ERRORE
                RetCode = 0
                GetJobPickGroupExecInformation = RetCode
                Exit Function
            End If

            If (WmsJob.CodiceRaggruppoEsecuzione <= 0) Then
                '>>> NESSUN CODICE DI RAGGRUPPAMENTO PER ESECUZIONE ESCO SENZA DARE ERRORE
                RetCode = 0
                GetJobPickGroupExecInformation = RetCode
                Exit Function
            End If

            If (WmsJob.TipoDirezioneMissioneKZEAR <> "A") Then
                '>>> MISSIONE NON DI USCITA MERCI ESCO SENZA DARE ERRORE
                RetCode = 0
                GetJobPickGroupExecInformation = RetCode
                Exit Function
            End If

            If (IsPickingCheckOnlyPresenceJobs(inShowMessageBox) = True) Then
                '>>> MISSIONE DI VERIFICA PRESENZA MATERIALE
                RetCode = 0
                GetJobPickGroupExecInformation = RetCode
                Exit Function
            End If

            RetCode += clsSapWS.Call_ZWS_GET_JOB_GROUP_EXEC_INFO(WmsJob, ExecutionOk, ExecGroupFound, WmsJobsGroupExecInfo, clsUser.SapWmsUser.LANGUAGE, SapFunctionError, inShowMessageBox)
            If (ExecutionOk = False) Or (RetCode <> 0) Then
                RetCode = 200
                GetJobPickGroupExecInformation = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(962, "", "Attenzione, errore in estrazione dati JOBS GROUP EXEC.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            GetJobPickGroupExecInformation = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetJobPickGroupExecInformation = 1000 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function IsJobPickPartialPickPieces(ByRef outUnitaDiMisuraQtyProposal As String) As Boolean
        ' ************************************************************
        ' DESCRIZIONE : VERIFICA SE SI TRATTA DI UNA MISSIONE DI PICKING PARZIALE CON PRELIEVO DEGLI SFUSI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            IsJobPickPartialPickPieces = False  'init

            If (WmsJob.FlagRilevanteWM = "W") And (WmsJob.TipoDirezioneMissioneKZEAR = "A") Then
                '**********************************************************************************************
                '>>> CASO DI USCITA MERCI (A) / ENTRATA MERCE (E)
                '**********************************************************************************************

                If (TaskLines.TaskLinesOnWork.PickFullPartialType = clsTaskLines.cstTaskLinesPickType_PickPieces) Then
                    '>>> CASO DI PRELIEVO AL PEZZO
                    IsJobPickPartialPickPieces = True

                    'CASO PARTICOLARE IN CUI LA UDM DI CONFERMA E' IL PEZZO
                    outUnitaDiMisuraQtyProposal = WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraPezzo
                End If
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            IsJobPickPartialPickPieces = False 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetJobPickOriQtyProposal(ByRef outPickQtyProposal As Double, ByRef outUnitaDiMisuraQtyProposal As String) As Long
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim QtaRimastaDaPrelevareFullPallet As Double = 0
        Dim QtaRimastaDaPrelevare As Double = 0
        Dim QtaRimastaDaPrelevareTaskOnWork As Double = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetJobPickOriQtyProposal = 0 'init


            If (WmsJob.FlagRilevanteWM = "W") And (WmsJob.TipoDirezioneMissioneKZEAR = "A") Then
                '**********************************************************************************************
                '>>> CASO DI USCITA MERCI (A) / ENTRATA MERCE (E)
                '**********************************************************************************************

                'NELLA MAGGIOR  PARTE DEI CASI LA UDM E' SEMPRE QUELLA  DI CONSEGNA/ACQISIZIONE
                outUnitaDiMisuraQtyProposal = WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione

                '*******************************************************************************************************
                '>>> SE ATTIVA LA GESTIONE DELLE TASK LINES ALLORA DEVO CALCOLARE LA QTA IN BASE AL TASK ATTIVO 
                '*******************************************************************************************************
                If (TaskLines.TaskLinesInfo.NrWmsJobs > 0) And (clsUtility.IsStringValid(TaskLines.TaskLinesOnWork.NrTaskLines, True) = True) Then
                    'CASO DI UN TASK ATTIVO DEVO GESTIRE IL CASO DI PRELIEVO FULL/PARZIALE/SFUSI
                    If (TaskLines.TaskLinesOnWork.PickFullPartialType = clsTaskLines.cstTaskLinesPickType_FullPallet) Then
                        'CALCOLO LA QTA RIMASTA DA PRELEVARE ( CASO FULL PALLET )
                        QtaRimastaDaPrelevareFullPallet = WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaFullPallet - WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataFullPallet
                        QtaRimastaDaPrelevareTaskOnWork = TaskLines.TaskLinesOnWork.QtaJobRichiestaInUdmConsegna - TaskLines.TaskLinesOnWork.QtaPrelevataInUdMConsegna
                        If (QtaRimastaDaPrelevareFullPallet > 0) And (WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet) Then
                            QtaRimastaDaPrelevare = WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet 'DI DEFAULT PROPONGO LA PALETTA INTERA
                            If (QtaRimastaDaPrelevareTaskOnWork > 0) And (WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet > QtaRimastaDaPrelevareTaskOnWork) Then
                                'CASO PARTICOLARE : E' STATA FATTA PER QUALCHE MOTIVO UNA CONFERMA CON UNA QTA MINORE DELLA QTA DELLA PALETTA PER CUI NELLA CONFERMA SUCCESSIVA
                                'DEVO CONFERMARE LA SOLA QTA PER RAGGIUNGERE LA QTA DELLA PALETTA PIENA
                                QtaRimastaDaPrelevare = QtaRimastaDaPrelevareTaskOnWork
                            End If
                        Else
                            QtaRimastaDaPrelevare = 0
                        End If
                    ElseIf (TaskLines.TaskLinesOnWork.PickFullPartialType = clsTaskLines.cstTaskLinesPickType_PartialPallet) Then
                        'CALCOLO LA QTA RIMASTA DA PRELEVARE ( CASO PARTIAL PALLET )
                        QtaRimastaDaPrelevare = WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaPartialPallet - WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataPartialPallet
                    ElseIf (TaskLines.TaskLinesOnWork.PickFullPartialType = clsTaskLines.cstTaskLinesPickType_PickPieces) Then
                        'CALCOLO LA QTA RIMASTA DA PRELEVARE ( CASO SFUSI )
                        QtaRimastaDaPrelevare = WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaSfusiInPZ - WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataSfusi

                        'CASO PARTICOLARE IN CUI LA UDM DI CONFERMA E' IL PEZZO
                        outUnitaDiMisuraQtyProposal = WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraPezzo
                    Else
                        '>>> CASO DI ERRORE ( DATI NON CONGRUENTI )
                        outPickQtyProposal = 0
                        Exit Function
                    End If
                Else
                    If (IsValidJobsGroupExec() = True) Then
                        '>>> CASO CON RAGGRUPPAMENTO
                        QtaRimastaDaPrelevare = WmsJobsGroupExecInfo.QtaGroupTotaleDaPrelevare
                    Else
                        'CALCOLO LA QTA RIMASTA DA PRELEVARE
                        QtaRimastaDaPrelevare = WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaInUdmConsegna - WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna
                    End If
                End If
            ElseIf (WmsJob.FlagRilevanteWM = "") And (WmsJob.TipoDirezioneMissioneKZEAR = "A") Then
                '>>> CASO DI PRELIEVO LOGICO
                outPickQtyProposal = WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaInUdmConsegna - WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna
                Exit Function
            ElseIf (WmsJob.FlagRilevanteWM = "W") And (WmsJob.TipoDirezioneMissioneKZEAR = "E") Then
                '>>> CASO DI ENTRATA MERCE GESTITA A MAGAZZINO (DISACCANTONAMENTO WM )
                outPickQtyProposal = WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaInUdmConsegna - WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna
                'outPickQtyProposal = WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaPartialPallet - WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna
                Exit Function
            ElseIf (WmsJob.FlagRilevanteWM = "") And (WmsJob.TipoDirezioneMissioneKZEAR = "E") Then
                '>>> CASO DI ENTRATA MERCE LOGICA (DISACCANTONAMENTO LOGICO )
                outPickQtyProposal = WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaInUdmConsegna - WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna
                Exit Function
            Else
                '>>> ??? da gestire in futuro
                QtaRimastaDaPrelevare = WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaInUdmConsegna - WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna
            End If

            'CONTROLLO DI SICUREZZA SULLA VALIDITA DEL DATO CALCOLATO
            If (QtaRimastaDaPrelevare < 0) Then
                QtaRimastaDaPrelevare = 0
            End If


            '>>> IN BASE ALLA QTA DA PRELEVARE VERIFICO I DIVERSI LIMITI POSSIBILI ( GIACENZA / PALLETIZZAZIONE
            If (TaskLines.TaskLinesOnWork.PickFullPartialType = clsTaskLines.cstTaskLinesPickType_PickPieces) Then
                outPickQtyProposal = QtaRimastaDaPrelevare
                '>>> NEL CASO DEI PEZZI VERIFICO SOLO ???? SISTEMARE USANDO LA GIACENZA IN PEZZI
                If (QtaRimastaDaPrelevare > clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaTotaleDispoInUdmPZ) Then
                    'LIMITO LA QTA PROPOSTA AL NUMERO DI PEZZI PRESENTI NELLA GIACENZA SELEZIONATA
                    outPickQtyProposal = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaTotaleDispoInUdmPZ
                End If
            Else
                '>>> CASO NORMALE
                If (QtaRimastaDaPrelevare > clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDispoUdMAcq) Then
                    '>>> QUI IL LIMITE E' LA QTA DISPONIBILE
                    If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet > 0) And (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDispoUdMAcq > clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet) Then
                        outPickQtyProposal = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet
                    Else
                        '>>> QTA <= DELLA QTA X PALLET
                        outPickQtyProposal = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDispoUdMAcq
                    End If
                Else
                    '>>> QUI IL LIMITE E' LA QTA DA PRELEVARE ED EVENTUALMENTE LA PALLETIZZAZIONE
                    If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet > 0) And (QtaRimastaDaPrelevare > clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet) Then
                        outPickQtyProposal = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet
                    Else
                        '>>> QTA <= DELLA QTA X PALLET
                        outPickQtyProposal = QtaRimastaDaPrelevare
                    End If
                End If
            End If


            GetJobPickOriQtyProposal = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetJobPickOriQtyProposal = 1000 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetJobTaskTotalQtyToPick(ByRef outJobTaskTotalQtyToPick As Double, ByRef outUdmQty As String) As Long
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim WorkQtaJobRimastaFullPallet As Double = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetJobTaskTotalQtyToPick = 1 'init

            outJobTaskTotalQtyToPick = WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaInUdmOriginale
            outUdmQty = WmsJob.MaterialeGiacenzaOrigine.UdmQtaJobRichiesta
            If (WmsJob.FlagRilevanteWM = "W") And (WmsJob.TipoDirezioneMissioneKZEAR = "A") Then
                '**********************************************************************************************
                '>>> CASO DI USCITA MERCI (A) / ENTRATA MERCE (E)
                '**********************************************************************************************

                '*******************************************************************************************************
                '>>> SE ATTIVA LA GESTIONE DELLE TASK LINES ALLORA DEVO CALCOLARE LA QTA IN BASE AL TASK ATTIVO 
                '*******************************************************************************************************
                If (TaskLines.TaskLinesInfo.NrWmsJobs > 0) And (clsUtility.IsStringValid(TaskLines.TaskLinesOnWork.NrTaskLines, True) = True) Then
                    'CASO DI UN TASK ATTIVO DEVO GESTIRE IL CASO DI PRELIEVO FULL/PARZIALE/SFUSI
                    If (TaskLines.TaskLinesOnWork.PickFullPartialType = clsTaskLines.cstTaskLinesPickType_FullPallet) Then
                        If (WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet > 0) Then
                            WorkQtaJobRimastaFullPallet = WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaFullPallet - WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataFullPallet
                            If (WorkQtaJobRimastaFullPallet > 0) Then
                                If (TaskLines.TaskLinesOnWork.QtaPrelevataFullPallet <= 0) And (TaskLines.TaskLinesOnWork.QtaPrelevataInUdMConsegna > 0) Then
                                    'CASO PARTICOLARE => E' STATA CONFERMATA UNA QTA  MINORE DELLA QTA DI FULL PALLET
                                    outJobTaskTotalQtyToPick = Int(WorkQtaJobRimastaFullPallet * WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet)
                                    If (outJobTaskTotalQtyToPick > TaskLines.TaskLinesOnWork.QtaPrelevataInUdMConsegna) Then
                                        outJobTaskTotalQtyToPick = outJobTaskTotalQtyToPick - TaskLines.TaskLinesOnWork.QtaPrelevataInUdMConsegna
                                    End If
                                Else
                                    'CASO NORMALE : CALCOLO LA QTA RIMASTA DA PRELEVARE ( CASO FULL PALLET )
                                    outJobTaskTotalQtyToPick = Int(WorkQtaJobRimastaFullPallet * WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet)
                                End If
                            Else
                                outJobTaskTotalQtyToPick = 0
                            End If
                            outUdmQty = WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione
                        Else
                            'IN QUESTO CASO LA VISUALIZZO IN PALLET
                            outJobTaskTotalQtyToPick = WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaFullPallet - WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataFullPallet
                            outUdmQty = WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraPallet
                        End If
                    ElseIf (TaskLines.TaskLinesOnWork.PickFullPartialType = clsTaskLines.cstTaskLinesPickType_PartialPallet) Then
                        'CALCOLO LA QTA RIMASTA DA PRELEVARE ( CASO PARTIAL PALLET )
                        outJobTaskTotalQtyToPick = WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaPartialPallet - WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataPartialPallet
                        outUdmQty = WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione
                    ElseIf (TaskLines.TaskLinesOnWork.PickFullPartialType = clsTaskLines.cstTaskLinesPickType_PickPieces) Then
                        'CALCOLO LA QTA RIMASTA DA PRELEVARE ( CASO SFUSI )
                        outJobTaskTotalQtyToPick = WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaSfusiInPZ - WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataSfusi
                        outUdmQty = WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraPezzo
                    End If
                    End If
            End If

            GetJobTaskTotalQtyToPick = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetJobTaskTotalQtyToPick = 1000 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetJobTaskTotalQtyPicked(ByRef outJobTaskTotalQtyPicked As Double, ByRef outUdmQty As String) As Long
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetJobTaskTotalQtyPicked = 1 'init

            outJobTaskTotalQtyPicked = WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna
            outUdmQty = WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione
            If (WmsJob.FlagRilevanteWM = "W") And (WmsJob.TipoDirezioneMissioneKZEAR = "A") Then
                '**********************************************************************************************
                '>>> CASO DI USCITA MERCI (A)
                '**********************************************************************************************

                '*******************************************************************************************************
                '>>> SE ATTIVA LA GESTIONE DELLE TASK LINES ALLORA DEVO CALCOLARE LA QTA IN BASE AL TASK ATTIVO 
                '*******************************************************************************************************
                If (TaskLines.TaskLinesInfo.NrWmsJobs > 0) And (clsUtility.IsStringValid(TaskLines.TaskLinesOnWork.NrTaskLines, True) = True) Then
                    'CASO DI UN TASK ATTIVO DEVO GESTIRE IL CASO DI PRELIEVO FULL/PARZIALE/SFUSI
                    If (TaskLines.TaskLinesOnWork.PickFullPartialType = clsTaskLines.cstTaskLinesPickType_FullPallet) Then
                        'CALCOLO LA QTA PRELEVATA ( CASO FULL PALLET )
                        If (WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet > 0) Then
                            If (TaskLines.TaskLinesOnWork.QtaPrelevataFullPallet <= 0) And (TaskLines.TaskLinesOnWork.QtaPrelevataInUdMConsegna > 0) Then
                                '>>> CASO NORMALE
                                outJobTaskTotalQtyPicked = WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataFullPallet * WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet
                                outJobTaskTotalQtyPicked = outJobTaskTotalQtyPicked + TaskLines.TaskLinesOnWork.QtaPrelevataInUdMConsegna
                            Else
                                '>>> CASO NORMALE
                                outJobTaskTotalQtyPicked = WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataFullPallet * WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet
                            End If
                            outUdmQty = WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione
                        Else
                            'IN QUESTO CASO LA VISUALIZZO IN PALLET
                            outJobTaskTotalQtyPicked = WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataFullPallet
                            outUdmQty = WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraPallet
                        End If
                        ElseIf (TaskLines.TaskLinesOnWork.PickFullPartialType = clsTaskLines.cstTaskLinesPickType_PartialPallet) Then
                            'CALCOLO LA QTA PRELEVATA ( CASO PARTIAL PALLET )
                            outJobTaskTotalQtyPicked = WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataPartialPallet
                            outUdmQty = WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione
                        ElseIf (TaskLines.TaskLinesOnWork.PickFullPartialType = clsTaskLines.cstTaskLinesPickType_PickPieces) Then
                            'CALCOLO LA QTA PRELEVATA ( CASO SFUSI )
                            outJobTaskTotalQtyPicked = WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataSfusi
                            outUdmQty = WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraPezzo
                        End If
                End If
            End If

            GetJobTaskTotalQtyPicked = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetJobTaskTotalQtyPicked = 1000 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetCurrentPickingMerciSourceType() As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim WorkMaterialePickOriGiacenza As clsDataType.SapWmGiacenza
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetCurrentPickingMerciSourceType = 1 'init at error

            If (clsWmsJob.WmsJob.NrWmsJobs <= 0) Then
                RetCode = 10
                GetCurrentPickingMerciSourceType = RetCode
                Exit Function
            End If

            'VERIFICO SE HO DELLE UBICAZIONI DI PRELIEVO PROPOSTE
            If (GetNumMaterialePickOriGiacenzaProposte() <= 0) Then
                If (Default_PickingMerci_SourceTypeEnableManEnter = True) Then
                    PickingMerciSourceType = PickingMerci_SourceType.PickingMerci_SourceTypeManualSelection
                Else
                    PickingMerciSourceType = PickingMerci_SourceType.PickingMerci_SourceTypeUbieUMEnter
                End If
                Exit Function
            End If

            WorkMaterialePickOriGiacenza = clsWmsJob.MaterialePickOriGiacenze(0)

            '>>> SE HO DELLE UBICAZIONI PROPOSTE VERIFICO IL DATI 
            If (WorkMaterialePickOriGiacenza.UbicazioneInfo.AbilitaUnitaMagazzino = True) Then
                '>>> CASO DI TIPO MAGAZZINO CON LE UM
                If (Default_PickingMerci_SourceTypeEnableUbiWithUM = True) Then
                    '>>> IN QUESTO CASO PERMETTO DI SPECIFICARE ANCHE L'UBICAZIONE
                    PickingMerciSourceType = PickingMerci_SourceType.PickingMerci_SourceTypeUbieUMEnter
                Else
                    PickingMerciSourceType = PickingMerci_SourceType.PickingMerci_SourceTypeUMEnter
                End If
            Else
                If (Default_PickingMerci_SourceTypeEnableManEnter = True) Then
                    PickingMerciSourceType = PickingMerci_SourceType.PickingMerci_SourceTypeManualSelection
                Else
                    PickingMerciSourceType = PickingMerci_SourceType.PickingMerci_SourceTypeUbicazioneEnter
                End If
            End If

            GetCurrentPickingMerciSourceType = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetCurrentPickingMerciSourceType = 1000 'CONDIZIONE DI CATCH ERROR
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetCurrentPickingMerciDestinationType() As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim WorkMaterialePickDestGiacenza As clsDataType.SapWmGiacenza
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetCurrentPickingMerciDestinationType = 1 'init at error

            If (clsWmsJob.WmsJob.NrWmsJobs <= 0) Then
                RetCode = 10
                GetCurrentPickingMerciDestinationType = RetCode
                Exit Function
            End If

            'VERIFICO SE HO DELLE UBICAZIONI DI PRELIEVO PROPOSTE
            If (GetNumMaterialePickDestinationProposte() <= 0) Then
                If (Default_PickingMerci_SourceTypeEnableManEnter = True) Then
                    PickingMerciSourceType = PickingMerci_SourceType.PickingMerci_SourceTypeManualSelection
                Else
                    PickingMerciSourceType = PickingMerci_SourceType.PickingMerci_SourceTypeUbieUMEnter
                End If
                Exit Function
            End If

            'RECUPERO LA PRIMA DESTINAZIONE RITORNATA DALLA STRATEGIA
            WorkMaterialePickDestGiacenza = clsWmsJob.MaterialePickDestinations(0)

            '>>> SE HO DELLE UBICAZIONI PROPOSTE VERIFICO IL DATI 
            If (WorkMaterialePickDestGiacenza.UbicazioneInfo.AbilitaUnitaMagazzino = True) Then
                '>>> CASO DI TIPO MAGAZZINO CON LE UM
                If (Default_PickingMerci_DestinationTypeEnableUbiWithUM = True) Then
                    '>>> IN QUESTO CASO PERMETTO DI SPECIFICARE ANCHE L'UBICAZIONE
                    PickingMerciDestinationType = PickingMerci_DestinationType.PickingMerci_DestinationTypeUbieUMEnter
                Else
                    PickingMerciDestinationType = PickingMerci_DestinationType.PickingMerci_DestinationTypeUMEnter
                End If
            Else
                PickingMerciDestinationType = PickingMerci_DestinationType.PickingMerci_DestinationTypeUbicazioneEnter
            End If

            GetCurrentPickingMerciDestinationType = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetCurrentPickingMerciDestinationType = 1000 'CONDIZIONE DI CATCH ERROR
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CheckBeforeExecJobPickIntoUDS(ByRef outCheckOk As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim WorkUdmQty As String = ""

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CheckBeforeExecJobPickIntoUDS = 1 'init at error
            outCheckOk = False

            'VERIFICO DI AVERE UN UDS ATTIVO
            If (UDSOnWork.CheckIsValidUDSActive() = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1529, "", "Nessun UDS attivo.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If

            'VERIFICO SE QUESTA CONFERMA E' GIA STATA FATTA ( FLAG DI SICUREZZA PER ESSERE SICURO CHE NON FACCIO  CONFERMA PIU' DI UNA VOLTA )
            If (clsWmsJob.FlagConfirmDone = True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1618, "", "Attenzione! Operazione di conferma gia eseguita !") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If

            If (clsWmsJob.IsJobPickPartialPickPieces(WorkUdmQty) = True) Then
                '  >>> CASO DI PRELIEVO DI SFUSI

                '>>> VERIFICO LA QTA IN PEZZI CONFERMATA DALL'OPERATORE
                If (WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataSfusiOperatore <= 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1604, "", "Nessuna QTA SFUSI confermata dall'operatore.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Function
                End If
                If (clsUtility.IsStringValid(clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraPezzo, True) = False) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1605, "", "Unita di misura QTA del PEZZO non valida.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Function
                End If

            Else
                '>>> CASO NORMALE

                'VERIFICO SE HO UNA QTA DI MATERIALE DA METTERE NELL'UDS
                If (WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore <= 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1524, "", "Nessuna QTA confermata dall'operatore.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Function
                End If
                If (clsUtility.IsStringValid(WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione, True) = False) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1521, "", "Unita di misura QTA di CONFERMA non valida.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Function
                End If

            End If

            'VERIFICO DI AVERE UN FORKLIFT ATTIVO
            If (clsForkLift.CheckIsValidCurrentForLift() = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1522, "", "Nessun FORKLIFT attivo.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If

            outCheckOk = True '>>> SE ARRIVO QUI CI SONO  LE CONDIZIONI  PER IL PICKING  INTO  UDS

            CheckBeforeExecJobPickIntoUDS = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckBeforeExecJobPickIntoUDS = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function ChecBeforeExecScreenDropUDS(ByRef inSourceForm As Form, ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : ESEGUE I  CONTROLLI  DOPO L'OPERAZIONE DI  PICKING INTO  UDS E DECIDE LA PROSSIMA OPERAZIONE / VIDEATA 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long



        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ChecBeforeExecScreenDropUDS = 1 'init at error

            'VERIFICO SE HO LE CONDIZIONI PER ESEGUIRE IL DROP DELL'UDS ( UDS ATTIVO E CON COMPONENTI )
            If (clsWmsJob.UDSOnWork.CheckUdsOkForDrop() = False) Then
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1517, "", "Nessun UDS attivo per il DROP.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            'RECUPERO LA DESTINAZIONE MIGLIORE PER LA MISSIONE CORRENTE
            '>>> IN CASO DI ERRORE  NON DO NESSUNA SEGNALAZIONE ( IL SISTEMA MOSTRA COMUNQUE LA STAGING )
            RetCode = clsWmsJob.GetJobPickingCodeBestDestination(True, True)


            'VERIFICO DI AVERE DEI COMPONENTI DI CUI ESEGUIRE IL DROP
            If (clsWmsJob.UDSOnWork.GetNumComponentiUDS() <= 0) Then
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1609, "", "Attenzione! Nessun componente nell'UDS attivo. Non c'e niente da DROPPARE.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Function
                End If
            End If


            ChecBeforeExecScreenDropUDS = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ChecBeforeExecScreenDropUDS = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CheckAfterExecJobPickIntoUDS(ByRef inSourceForm As Form) As Long
        ' ************************************************************
        ' DESCRIZIONE : ESEGUE I  CONTROLLI  DOPO L'OPERAZIONE DI  PICKING INTO  UDS E DECIDE LA PROSSIMA OPERAZIONE / VIDEATA 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim FlagTaskLinesOnWorkIsFinish As Boolean = False
        Dim FlagAllTaskLinesAreFinish As Boolean = False
        Dim SetTaskLinesOk As Boolean = False
        Dim FlagStepTypeStartSeq As Boolean = False
        Dim FlagStartStrategy As Boolean = False
        Dim FlagStartNewJobs As Boolean = False
        Dim FlagStartDropUDS As Boolean = False
        Dim FlagAllJobsQueueAreFinished As Boolean = False
        Dim FlagkUdsReachWeightLimitForDrop As Boolean = False
        Dim FlagTaskLinesOnWorkNeedDrop As Boolean = False
        Dim CheckExecutionForceEndJobOk As Boolean = False
        Dim MemoNrWmsJobs As String = ""

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CheckAfterExecJobPickIntoUDS = 1 'init at error

            FlagTaskLinesOnWorkIsFinish = False
            FlagTaskLinesOnWorkNeedDrop = False
            '**************************************************************************************************
            'FACCIO UN CONTROLLO SE IL TASK CORRENTE E' TERMINATO
            '**************************************************************************************************
            RetCode = clsWmsJob.TaskLines.CheckIfTaskLinesOnWorkIsFinish(FlagTaskLinesOnWorkIsFinish, False)
            If (FlagTaskLinesOnWorkIsFinish = True) Then
                'VERIFICO NEL CASO DI UN PRELIEVO DI FULL PALLET ( FORZO A DARE IL DROP A OGNI PRELIEVO IN MODO DA AVERE UN KTAG PER OGNI FULL PALLET)
                RetCode = clsWmsJob.TaskLines.CheckIfTaskLinesFullPalletNeedDrop(FlagTaskLinesOnWorkNeedDrop, False)

                'VERIFICO SE IL JOB  PREVEDE ALTRE TASK LINES
                RetCode = clsWmsJob.TaskLines.CheckIfAllTaskLinesAreFinish(clsWmsJob.WmsJob.NrWmsJobs, FlagAllTaskLinesAreFinish, False)
                If (FlagAllTaskLinesAreFinish = False) Then
                    '>>> IMPOSTO LA NUOVA  TASK LINES SUCCESSIVA DA FARE
                    RetCode = clsWmsJob.TaskLines.SetCurrentTaskLinesOnWork(clsWmsJob.WmsJob.NrWmsJobs, SetTaskLinesOk)
                    FlagStepTypeStartSeq = True
                    FlagStartStrategy = True
                Else
                    'VERIFICO SE TUTTI I JOB ATTIVI SONO TERMINATI
                    RetCode = clsWmsJob.CheckIfAllJobsQueueAreFinished(FlagAllJobsQueueAreFinished, False)
                    If (FlagAllJobsQueueAreFinished = True) Then
                        '>>> HO TERMINATO TUTTI I JOB FORZO IL DROP DELL'UDS
                        FlagStartDropUDS = True
                    Else
                        '>>> PASSO  AL JOB SUCCESSIVO
                        FlagStartNewJobs = True
                    End If
                End If
            Else
                'VERIFICO NEL CASO DI UN PRELIEVO DI FULL PALLET ( FORZO A DARE IL DROP A OGNI PRELIEVO IN MODO DA AVERE UN KTAG PER OGNI FULL PALLET)
                RetCode = clsWmsJob.TaskLines.CheckIfTaskLinesFullPalletNeedDrop(FlagTaskLinesOnWorkNeedDrop, False)

                '>>> CONTINUO LA TASK LINES CORRENTE
                FlagStepTypeStartSeq = True
                FlagStartStrategy = True
            End If


            'VERIFICO SE PER RAGGIUNTO LIMITE DI PESO DEVO ESEGUIRE IL DROP
            RetCode = clsWmsJob.UDSOnWork.CheckUdsReachWeightLimitForDrop(FlagkUdsReachWeightLimitForDrop)
            If (FlagkUdsReachWeightLimitForDrop = True) Or (FlagTaskLinesOnWorkNeedDrop = True) Or (FlagStartDropUDS = True) Then

                'RECUPERO LA STAGING DI DESTINAZIONE PER LA MISSIONE CORRENTE
                RetCode = clsWmsJob.GetJobPickingCodeBestDestination(True, True)

                'HO RAGGIUNTO IL LIMITE DEL PESO DEL FORKLIFT E PROPONGO IL DROP
                Call clsNavigation.Show_Ope_PickingMerci_Code(inSourceForm, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeDropUDS, True)
                Exit Function
            End If

            'VERIFICO SE DEVO RIEEGUIRE LA STRATEGIA PER RILEVARE IL POSTO MIGLIORE PER IL PICKING
            If (FlagStartStrategy = True) Then
                clsWmsJob.FlagConfirmDone = False 'RESETTO FLAG PER NUOVA CONFERMA
                '*********************************************************************************************************************
                'IN BASE ALLA TIPOLOGIA DELLA TASK LINES DA ESEGUIRE ATTIVO LA STRATEGIA PER RICERCARE IL MATERIALE DA PRELEVARE
                '*********************************************************************************************************************
                RetCode = clsWmsJob.JobsActivateTaskLinesOnWorkExecution("", True, True)
                If (RetCode <> 0) And (clsWmsJob.FlagStockFoundInOtherWh = False) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(400, "", "Errore in ATTIVAZIONE MISSIONE:") & clsWmsJob.WmsJob.NrWmsJobs & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    'Exit Sub
                End If

                '*********************************************************************************************************************
                'SE DOPO LA STRATEGIA HO IL CAMBIO CODA DEVO FORZARE IL TERMINA MISSIONE
                '*********************************************************************************************************************
                If (clsWmsJob.FlagStockFoundInOtherWh = True) Then
                    '>>> ESEGUO FORZATURA FINE JOB/MISSIONE
                    RetCode = clsSapWS.Call_ZWS_SET_JOB_STATUS_FORCED_END(clsWmsJob.WmsJob.NrWmsJobs, False, Nothing, clsUser.SapWmsUser.LANGUAGE, CheckExecutionForceEndJobOk, SapFunctionError, True)
                    If (RetCode <> 0) Or (CheckExecutionForceEndJobOk = False) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(748, "", "Errore in FORZA TERMINA MISSIONE.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Function
                    End If
                    clsWmsJob.FlagStockFoundInOtherWh = False

                    MemoNrWmsJobs = clsWmsJob.WmsJob.NrWmsJobs

                    'ESEGUO IL RECUPERO DEI DATI DEL JOB CORRENTE
                    RetCode += clsWmsJob.GetJobSingle(clsWmsJob.WmsJob.NrWmsJobs, Nothing, Nothing, Nothing, Nothing, False, False, True, True)
                    If (RetCode <> 0) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1613, "", "Attenzione, errore in estrazione dati del JOBS.")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Function
                    End If

                    'ESEGUO REFRESH DEI DATI DEL JOB
                    RetCode = clsWmsJob.RefreshJobsSingleStruct(MemoNrWmsJobs, True)
                    If (RetCode <> 0) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(398, "", "Attenzione! Errore in lettura dati JOB")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Function
                    End If

                    'SEGNALO OPERAZIONE ESEGUITA CORRETTAMENTE
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(749, "", "Forzatura TERMINA MISSIONE eseguita con SUCCESSO.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    'RIPARTO DALLA LISTA DELLE MISSIONI ( SE RIMASTO UN JOB )
                    Call clsNavigation.Show_Ope_PickingMerci_Code(inSourceForm, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartGroupSeq, True)
                    Exit Function
                End If
            End If

            'CASO IN CUI ESEGUO ALTRO PICKING PER STESSO TASK/JOB ( STESSO  MATERIALE )
            If (FlagStepTypeStartSeq = True) Then
                clsWmsJob.FlagConfirmDone = False 'RESETTO FLAG PER NUOVA CONFERMA
                'RIESEGUO UN ALTRO PICKING PER TASK/JOB CORRENTE
                Call clsNavigation.Show_Ope_PickingMerci_Code(inSourceForm, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartSeq, True)
                Exit Function
            End If

            If (FlagStartNewJobs = True) Then
                clsWmsJob.FlagConfirmDone = False 'RESETTO FLAG PER NUOVA CONFERMA
                'RIPARTO DALLA LISTA DELLE MISSIONI ( SE RIMASTO UN JOB )
                Call clsNavigation.Show_Ope_PickingMerci_Code(inSourceForm, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartGroupSeq, True)
                Exit Function
            End If


            CheckAfterExecJobPickIntoUDS = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckAfterExecJobPickIntoUDS = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ClearForNewPositionRead() As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ClearForNewPositionRead = 1 'init at error

            RetCode += clsSapUtility.ResetWmsJobStruct(WmsJob)
            RetCode += clsSapUtility.ResetWmJobsGroupExecTabStruct(WmsJobsGroupExecInfo)

            RetCode += ClearWmsJobsListInfo()
            RetCode += clsWmsJobsGroup.ClearWmsJobGroupListInfo()

            ClearForNewPositionRead = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ClearForNewPositionRead = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function ClearWmsJobsAutoTransferList() As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ClearWmsJobsAutoTransferList = 1 'init at error

            If (Not (objDataTableWmsJobsAutoTransferList Is Nothing)) Then
                objDataTableWmsJobsAutoTransferList.Rows.Clear()
            End If

            ClearWmsJobsAutoTransferList = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ClearWmsJobsAutoTransferList = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ClearWmsJobsListInfo() As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ClearWmsJobsListInfo = 1 'init at error

            If (Not (objDataTableWmsJobsList Is Nothing)) Then
                objDataTableWmsJobsList.Rows.Clear()
            End If

            ClearWmsJobsListInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ClearWmsJobsListInfo = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function FromDataRowToWmsJobsInfoStruct(ByRef inDataRow As DataRow, ByRef outSapWmWmsJobInfo As clsDataType.SapWmWmsJob, ByVal inShowMessageBox As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            FromDataRowToWmsJobsInfoStruct = 1 'INIT AT ERROR

            If (inDataRow Is Nothing) Then
                RetCode = 10
                FromDataRowToWmsJobsInfoStruct = RetCode
                Exit Function
            End If

            outSapWmWmsJobInfo.NrWmsJobs = clsUtility.GetDataRowItem(inDataRow, "ZNR_WMS_JOBS", "")
            outSapWmWmsJobInfo.DataCreazione = clsUtility.GetDataRowItem(inDataRow, "DATA_CREAZIONE", Date.MinValue.ToString)
            outSapWmWmsJobInfo.OraCreazione = clsUtility.GetDataRowItem(inDataRow, "ORA_CREAZIONE", "")
            outSapWmWmsJobInfo.PickDbTabName = clsUtility.GetDataRowItem(inDataRow, "PICK_DBTABNAME", "")
            outSapWmWmsJobInfo.PickDbNumero = clsUtility.GetDataRowItem(inDataRow, "ZNRPICK", "")
            outSapWmWmsJobInfo.PickDbPosizione = clsUtility.GetDataRowItem(inDataRow, "ZPOSPK", "0")
            outSapWmWmsJobInfo.NumeroTrasporto = clsUtility.GetDataRowItem(inDataRow, "TKNUM", "")
            outSapWmWmsJobInfo.ConsegnaNumero = clsUtility.GetDataRowItem(inDataRow, "NUM_CONS_VBELV", "")
            outSapWmWmsJobInfo.ConsegnaPosizione = clsUtility.GetDataRowItem(inDataRow, "POS_CONS_POSNV", "")
            outSapWmWmsJobInfo.StopSequence = clsUtility.GetDataRowItem(inDataRow, "ZWMS_STOP_SEQ", "")
            outSapWmWmsJobInfo.DropSequence = clsUtility.GetDataRowItem(inDataRow, "ZWMS_DROP_SEQ", "")

            outSapWmWmsJobInfo.NumeroOrdineVendita = clsUtility.GetDataRowItem(inDataRow, "VBELN", "")
            outSapWmWmsJobInfo.NumeroPosizioneOrdineVendita = clsUtility.GetDataRowItem(inDataRow, "POSNR", "")
            outSapWmWmsJobInfo.DocumentoMaterialeAnno = clsUtility.GetDataRowItem(inDataRow, "MJAHR", "")
            outSapWmWmsJobInfo.DocumentoMaterialeNumero = clsUtility.GetDataRowItem(inDataRow, "MBLNR", "")
            outSapWmWmsJobInfo.DocumentoMaterialePosizione = clsUtility.GetDataRowItem(inDataRow, "ZEILE", "")

            outSapWmWmsJobInfo.CodiceClienteAG = clsUtility.GetDataRowItem(inDataRow, "KUNNR_AG", "")
            outSapWmWmsJobInfo.CodiceClienteWE = clsUtility.GetDataRowItem(inDataRow, "KUNNR_WE", "")
            outSapWmWmsJobInfo.CodiceClienteRG = clsUtility.GetDataRowItem(inDataRow, "KUNNR_RG", "")
            outSapWmWmsJobInfo.DescrizioneClienteAG = clsUtility.GetDataRowItem(inDataRow, "NAME_AG", "")
            outSapWmWmsJobInfo.DescrizioneClienteWE = clsUtility.GetDataRowItem(inDataRow, "NAME_WE", "")
            outSapWmWmsJobInfo.DescrizioneClienteRG = clsUtility.GetDataRowItem(inDataRow, "NAME_RG", "")

            outSapWmWmsJobInfo.CodiceGruppoMissioni = clsUtility.GetDataRowItem(inDataRow, "ZNR_WMS_JOBSGRP", "")
            outSapWmWmsJobInfo.CodiceRaggruppoEsecuzione = clsUtility.GetDataRowItem(inDataRow, "ZNR_WMS_GRPEXEC", "")
            outSapWmWmsJobInfo.Sequence = clsUtility.GetDataRowItem(inDataRow, "SEQUENCE", "")
            outSapWmWmsJobInfo.CurrentStep = clsUtility.GetDataRowItem(inDataRow, "CURRENT_STEP", "")
            outSapWmWmsJobInfo.NumeroStepTotali = clsUtility.GetDataRowItem(inDataRow, "NUM_STEPS_TOTAL", "0")
            outSapWmWmsJobInfo.IdWmsJobStatus = clsUtility.GetDataRowItem(inDataRow, "IDSTATUS", "")
            outSapWmWmsJobInfo.IdWmsJobStatusDescription = clsUtility.GetDataRowItem(inDataRow, "STATUS", "")
            outSapWmWmsJobInfo.IdWmsJobType = clsUtility.GetDataRowItem(inDataRow, "ID_JOBS_TYPE", "")
            outSapWmWmsJobInfo.IdWmsJobTypeDescription = clsUtility.GetDataRowItem(inDataRow, "DESCR_JOBS_TYPE", "")
            outSapWmWmsJobInfo.TipoDirezioneMissioneKZEAR = clsUtility.GetDataRowItem(inDataRow, "JOBS_TYPE_KZEAR", "")
            outSapWmWmsJobInfo.TipoDocumento = clsUtility.GetDataRowItem(inDataRow, "ZDOC", "")
            outSapWmWmsJobInfo.CodiceFornitore = clsUtility.GetDataRowItem(inDataRow, "FORNITORE_LIFNR", "")

            outSapWmWmsJobInfo.Priorita = clsUtility.GetDataRowItem(inDataRow, "PRIORITA", "0")

            If (outSapWmWmsJobInfo.TipoDocumento = clsSapUtility.cstSapTipoDocumentoReso) Then
                outSapWmWmsJobInfo.CondizioneDiReso = True
            Else
                outSapWmWmsJobInfo.CondizioneDiReso = False
            End If

            WorkString = clsUtility.GetDataRowItem(inDataRow, "URGENTE", "")
            If (WorkString = "X") Then
                outSapWmWmsJobInfo.Urgente = True
            Else
                outSapWmWmsJobInfo.Urgente = False
            End If
            outSapWmWmsJobInfo.FlagRilevanteWM = clsUtility.GetDataRowItem(inDataRow, "ZFLAWM", "")
            outSapWmWmsJobInfo.FlagPartitaTassativa = clsUtility.GetDataRowItem(inDataRow, "CHARG_TASSATIVA", "")
            WorkString = clsUtility.GetDataRowItem(inDataRow, "PALLET_INTERI", "")
            If (WorkString = "X") Then
                outSapWmWmsJobInfo.FlagPalletInteri = True
            Else
                outSapWmWmsJobInfo.FlagPalletInteri = False
            End If
            WorkString = clsUtility.GetDataRowItem(inDataRow, "SCATOLE_INTERE", "")
            If (WorkString = "X") Then
                outSapWmWmsJobInfo.FlagScatoleIntere = True
            Else
                outSapWmWmsJobInfo.FlagScatoleIntere = False
            End If

            WorkString = clsUtility.GetDataRowItem(inDataRow, "ZTIPO_ENTMERCE", "")
            Select Case WorkString
                Case "P" ' >>> Entrata Merce Con Palletizzazione e Dest. Spunta
                    outSapWmWmsJobInfo.EMTipoProceduraType = clsDataType.EM_TipoProceduraType.EM_TipoProceduraPalletizzaDestSpunta
                Case "S" ' >>> Entrata Merce Con Passaggio di Spunta e Stoccaggio Finale
                    outSapWmWmsJobInfo.EMTipoProceduraType = clsDataType.EM_TipoProceduraType.EM_TipoProceduraPalletizzaeStoccaggio
                Case "D" ' >>> Entrata Merce Con Stoccaggio Diretto UM Sconosciuta
                    outSapWmWmsJobInfo.EMTipoProceduraType = clsDataType.EM_TipoProceduraType.EM_TipoProceduraStoccaggioDirettoUMSconosciuta
                Case "C" ' >>> Entrata Merce Con Stoccaggio Diretto UM Conosciuta
                    outSapWmWmsJobInfo.EMTipoProceduraType = clsDataType.EM_TipoProceduraType.EM_TipoProceduraStoccaggioDirettoUMConosciuta
                Case Else
                    outSapWmWmsJobInfo.EMTipoProceduraType = clsDataType.EM_TipoProceduraType.EM_TipoProceduraNone
            End Select

            WorkString = clsUtility.GetDataRowItem(inDataRow, "ZFORCEDDEST", "")
            If (WorkString = "X") Then
                outSapWmWmsJobInfo.ForcedFinalDestination = True
            Else
                outSapWmWmsJobInfo.ForcedFinalDestination = False
            End If
            WorkString = clsUtility.GetDataRowItem(inDataRow, "ZFORCSPUNTACONF", "")
            If (WorkString = "X") Then
                outSapWmWmsJobInfo.ForcedConfirmUbicazioneSpunta = True
            Else
                outSapWmWmsJobInfo.ForcedConfirmUbicazioneSpunta = False
            End If

            outSapWmWmsJobInfo.IdCarrellistaProposto = clsUtility.GetDataRowItem(inDataRow, "ZCARR_PROP", "")
            outSapWmWmsJobInfo.IdCarrellistaEsecuzione = clsUtility.GetDataRowItem(inDataRow, "ZCARR_EXEC", "")
            outSapWmWmsJobInfo.IdCarrellistaEsecuzioneFullPallet = clsUtility.GetDataRowItem(inDataRow, "ZCARR_EXEC_FL", "")
            outSapWmWmsJobInfo.IdCarrellistaEsecuzioneSfusi = clsUtility.GetDataRowItem(inDataRow, "ZCARR_EXEC_SF", "")

            outSapWmWmsJobInfo.InfoPrelievo = clsUtility.GetDataRowItem(inDataRow, "INFO_PRELIEVO", "")
            outSapWmWmsJobInfo.DistintaDiCarico = clsUtility.GetDataRowItem(inDataRow, "ZZ_NDIS", "")
            outSapWmWmsJobInfo.Memo = clsUtility.GetDataRowItem(inDataRow, "MEMO", "")
            outSapWmWmsJobInfo.DataStart = clsUtility.GetDataRowItem(inDataRow, "DATA_START", Date.MinValue.ToString)
            outSapWmWmsJobInfo.OraStart = clsUtility.GetDataRowItem(inDataRow, "ORA_START", "")
            outSapWmWmsJobInfo.DataFine = clsUtility.GetDataRowItem(inDataRow, "DATA_FINE", Date.MinValue.ToString)
            outSapWmWmsJobInfo.OraFine = clsUtility.GetDataRowItem(inDataRow, "ORA_FINE", "")

            '>>> IMPOSTO DATI ORIGINE
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.CodiceMateriale = clsUtility.GetDataRowItem(inDataRow, "MATNR_ORI", "")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.DescrizioneMateriale = clsUtility.GetDataRowItem(inDataRow, "MAKTG", "")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.CodiceMaterialeLegacy = clsUtility.GetDataRowItem(inDataRow, "ZZCDLEGACY", "")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.SKU = clsUtility.GetDataRowItem(inDataRow, "ZWMS_SKU_PALLET", "")

            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.Partita = clsUtility.GetDataRowItem(inDataRow, "CHARG_ORI", "")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.MagazzinoLogico = clsUtility.GetDataRowItem(inDataRow, "LGORT_ORI", "")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.TipoStock = clsUtility.GetDataRowItem(inDataRow, "BESTQ_ORI", "")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.CdStockSpeciale = clsUtility.GetDataRowItem(inDataRow, "SOBKZ_ORI", "")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.NumeroStockSpeciale = clsUtility.GetDataRowItem(inDataRow, "SONUM_ORI", "")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.UbicazioneInfo.Divisione = clsUtility.GetDataRowItem(inDataRow, "WERKS_ORI", "")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.UbicazioneInfo.NumeroMagazzino = clsUtility.GetDataRowItem(inDataRow, "LGNUM_ORI", "")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.UbicazioneInfo.TipoMagazzino = clsUtility.GetDataRowItem(inDataRow, "LGTYP_ORI", "")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.UbicazioneInfo.Ubicazione = clsUtility.GetDataRowItem(inDataRow, "LGPLA_ORI", "")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.UbicazioneInfo.UnitaMagazzino = clsUtility.GetDataRowItem(inDataRow, "LENUM_ORI", "")

            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.UnitaDiMisuraBase = clsUtility.GetDataRowItem(inDataRow, "UDM_QTAPR_MEINS", "")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione = clsUtility.GetDataRowItem(inDataRow, "UDM_QTAPR_CONS", "")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.UdmQtaJobRichiesta = clsUtility.GetDataRowItem(inDataRow, "MEINS_ORI", "")

            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.QtaJobRichiestaInUdmBase = clsUtility.GetDataRowItem(inDataRow, "ZQTAPK_ORI_BASE", "0")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.QtaJobRichiestaInUdmConsegna = clsUtility.GetDataRowItem(inDataRow, "ZQTAPK_ORI_CONS", "0")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.QtaJobRichiestaInUdmPZ = clsUtility.GetDataRowItem(inDataRow, "ZQTAPK_ORI_PZ", "0")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.QtaJobRichiestaInUdmSC = clsUtility.GetDataRowItem(inDataRow, "ZQTAPK_ORI_SC", "0")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.QtaJobRichiestaInUdmPL = clsUtility.GetDataRowItem(inDataRow, "ZQTAPK_ORI_PL", "0")

            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.QtaJobRichiestaInUdmOriginale = clsUtility.GetDataRowItem(inDataRow, "ZQTAPK_ORI", "0")
            If (outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.UdmQtaJobRichiesta = outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione) Then
                outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.QtaTotaleLquaDaPrelUdMAcq = clsUtility.GetDataRowItem(inDataRow, "ZQTAPK_ORI", "0")
            Else
                '>>>> CASO VERIFICATO NEL GIRO DEI CAMPIONI IN CUI LA QTA ORIGINALE E' IN PEZZI
                outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.QtaTotaleLquaDaPrelUdMAcq = clsUtility.GetDataRowItem(inDataRow, "ZQTAPK_ORI_CONS", "0")
            End If


            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.UnitaDiMisuraPezzo = clsUtility.GetDataRowItem(inDataRow, "MEINS_PZ", "")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.UnitaDiMisuraScatole = clsUtility.GetDataRowItem(inDataRow, "MEINS_SC", "")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.UnitaDiMisuraPallet = clsUtility.GetDataRowItem(inDataRow, "MEINS_PAL", "")


            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.QtaJobRichiestaFullPallet = clsUtility.GetDataRowItem(inDataRow, "ZQTAPK_FULL_PALL", "0")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.QtaJobRichiestaPartialPallet = clsUtility.GetDataRowItem(inDataRow, "ZQTAPK_PARTIAL", "0")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.QtaJobRichiestaSfusiInPZ = clsUtility.GetDataRowItem(inDataRow, "ZQTAPK_SFUSI_PZ", "0")

            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.QtaPrelevataInUdMBase = clsUtility.GetDataRowItem(inDataRow, "ZQTA_PREL_BASE", "0")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.UdmQtaPrelevataInUdMBase = clsUtility.GetDataRowItem(inDataRow, "UDM_QTAPR_MEINS", "")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna = clsUtility.GetDataRowItem(inDataRow, "ZQTA_PREL_CONS", "0")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.UdmQtaPrelevataInUdMConsegna = clsUtility.GetDataRowItem(inDataRow, "UDM_QTAPR_CONS", "")

            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.QtaPrelevataInUdMPezzo = clsUtility.GetDataRowItem(inDataRow, "ZQTA_PREL_PZ", "0")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.QtaPrelevataFullPallet = clsUtility.GetDataRowItem(inDataRow, "ZQTA_PREL_FULL", "0")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.QtaPrelevataPartialPallet = clsUtility.GetDataRowItem(inDataRow, "ZQTA_PREL_PARTIA", "0")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.QtaPrelevataSfusi = clsUtility.GetDataRowItem(inDataRow, "ZQTA_PREL_SF", "0")

            outSapWmWmsJobInfo.MaterialeGiacenzaDestinazione.CodiceMateriale = clsUtility.GetDataRowItem(inDataRow, "MATNR_DEST", "")
            outSapWmWmsJobInfo.MaterialeGiacenzaDestinazione.Partita = clsUtility.GetDataRowItem(inDataRow, "CHARG_DEST", "")
            outSapWmWmsJobInfo.MaterialeGiacenzaDestinazione.MagazzinoLogico = clsUtility.GetDataRowItem(inDataRow, "LGORT_DEST", "")
            outSapWmWmsJobInfo.MaterialeGiacenzaDestinazione.TipoStock = clsUtility.GetDataRowItem(inDataRow, "BESTQ_DEST", "")
            outSapWmWmsJobInfo.MaterialeGiacenzaDestinazione.CdStockSpeciale = clsUtility.GetDataRowItem(inDataRow, "SOBKZ_DEST", "")
            outSapWmWmsJobInfo.MaterialeGiacenzaDestinazione.NumeroStockSpeciale = clsUtility.GetDataRowItem(inDataRow, "SONUM_DEST", "")
            outSapWmWmsJobInfo.MaterialeGiacenzaDestinazione.UbicazioneInfo.Divisione = clsUtility.GetDataRowItem(inDataRow, "WERKS_DEST", "")
            outSapWmWmsJobInfo.MaterialeGiacenzaDestinazione.UbicazioneInfo.NumeroMagazzino = clsUtility.GetDataRowItem(inDataRow, "LGNUM_DEST", "")
            outSapWmWmsJobInfo.MaterialeGiacenzaDestinazione.UbicazioneInfo.TipoMagazzino = clsUtility.GetDataRowItem(inDataRow, "LGTYP_DEST", "")
            outSapWmWmsJobInfo.MaterialeGiacenzaDestinazione.UbicazioneInfo.Ubicazione = clsUtility.GetDataRowItem(inDataRow, "LGPLA_DEST", "")
            outSapWmWmsJobInfo.MaterialeGiacenzaDestinazione.UbicazioneInfo.UnitaMagazzino = clsUtility.GetDataRowItem(inDataRow, "LENUM_DEST", "")

            outSapWmWmsJobInfo.PickFullPartial = clsUtility.GetDataRowItem(inDataRow, "ZPICKFULLPARTIAL", "")

            outSapWmWmsJobInfo.UbicazioneOrigine = outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.UbicazioneInfo
            outSapWmWmsJobInfo.UbicazioneDestinazione = outSapWmWmsJobInfo.MaterialeGiacenzaDestinazione.UbicazioneInfo

            outSapWmWmsJobInfo.UbicazioneStaging.NumeroMagazzino = clsUtility.GetDataRowItem(inDataRow, "LGNUM_STAG_DOOR", "")
            outSapWmWmsJobInfo.UbicazioneStaging.TipoMagazzino = clsUtility.GetDataRowItem(inDataRow, "LGTYP_STAG_DOOR", "")
            outSapWmWmsJobInfo.UbicazioneStaging.Ubicazione = clsUtility.GetDataRowItem(inDataRow, "LGPLA_STAG_DOOR", "")
            outSapWmWmsJobInfo.UbicazioneDoor.NumeroMagazzino = clsUtility.GetDataRowItem(inDataRow, "LGNUM_DOOCK_DOOR", "")
            outSapWmWmsJobInfo.UbicazioneDoor.TipoMagazzino = clsUtility.GetDataRowItem(inDataRow, "LGTYP_DOOCK_DOOR", "")
            outSapWmWmsJobInfo.UbicazioneDoor.Ubicazione = clsUtility.GetDataRowItem(inDataRow, "LGPLA_DOOCK_DOOR", "")

            outSapWmWmsJobInfo.UbicazionePropostaOrigine.Divisione = clsUtility.GetDataRowItem(inDataRow, "WERKS_ORI", "")
            outSapWmWmsJobInfo.UbicazionePropostaOrigine.NumeroMagazzino = clsUtility.GetDataRowItem(inDataRow, "LGNUM_PROP_ORI", "")
            outSapWmWmsJobInfo.UbicazionePropostaOrigine.TipoMagazzino = clsUtility.GetDataRowItem(inDataRow, "LGTYP_PROP_ORI", "")
            outSapWmWmsJobInfo.UbicazionePropostaOrigine.Ubicazione = clsUtility.GetDataRowItem(inDataRow, "LGPLA_PROP_ORI", "")
            outSapWmWmsJobInfo.UbicazionePropostaOrigine.UnitaMagazzino = ""

            outSapWmWmsJobInfo.UbicazionePropostaDestinazione.Divisione = clsUtility.GetDataRowItem(inDataRow, "WERKS_DEST", "")
            outSapWmWmsJobInfo.UbicazionePropostaDestinazione.NumeroMagazzino = clsUtility.GetDataRowItem(inDataRow, "LGNUM_PROP_DEST", "")
            outSapWmWmsJobInfo.UbicazionePropostaDestinazione.TipoMagazzino = clsUtility.GetDataRowItem(inDataRow, "LGTYP_PROP_DEST", "")
            outSapWmWmsJobInfo.UbicazionePropostaDestinazione.Ubicazione = clsUtility.GetDataRowItem(inDataRow, "LGPLA_PROP_DEST", "")
            outSapWmWmsJobInfo.UbicazionePropostaDestinazione.UnitaMagazzino = ""

            '* GESTIONE CAMPI ERRORE
            outSapWmWmsJobInfo.ZWMS_ERROR_CODE = clsUtility.GetDataRowItem(inDataRow, "ZWMS_ERROR_CODE", "")
            outSapWmWmsJobInfo.ZWMS_ROW_STA_DES = clsUtility.GetDataRowItem(inDataRow, "ZWMS_ROW_STA_DES", "")


            '>>> GESTIONE VARIANTE IMBALLO
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.VarianteImballo.CodiceImballo = clsUtility.GetDataRowItem(inDataRow, "IMBALLO", "")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.VarianteImballo.PezziPerScatola = clsUtility.GetDataRowItem(inDataRow, "PZ_X_SC", "0")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet = clsUtility.GetDataRowItem(inDataRow, "SC_X_PAL", "0")
            outSapWmWmsJobInfo.MaterialeGiacenzaOrigine.VarianteImballo.M2PerPallet = clsUtility.GetDataRowItem(inDataRow, "M2_X_PAL", "0")

            FromDataRowToWmsJobsInfoStruct = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            FromDataRowToWmsJobsInfoStruct = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Public Shared Function FromSapWmWmsJobDataRowToString(ByRef inDataRow As DataRow, Optional ByVal inShowMode As Long = 0) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim tmpString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            FromSapWmWmsJobDataRowToString = ""

            'inShowMode = 0 (DEFAULT)
            ' >>>> MIS:[NrWmsJobs] - [CodiceGruppoMissioni]


            Select Case inShowMode
                Case 0
                    tmpString += clsAppTranslation.GetSingleParameterValue(1005, "", "MIS:")
                    tmpString += UCase(clsUtility.GetDataRowItem(inDataRow, "ZNR_WMS_JOBS", "")) + "-"
                    tmpString += UCase(clsUtility.GetDataRowItem(inDataRow, "ZNR_WMS_JOBSGRP", ""))
                    Select Case UCase(clsUtility.GetDataRowItem(inDataRow, "ID_JOBS_TYPE", ""))
                        Case cstIdJobType_CheckMaterial
                            tmpString += clsAppTranslation.GetSingleParameterValue(1006, "", "-VERIFICA")
                        Case cstIdJobType_DisaccantonaZ08, cstIdJobType_DisaccantonaLog
                            tmpString += clsAppTranslation.GetSingleParameterValue(1007, "", "-DISACC.")
                        Case cstIdJobType_Pick_To_916, cstIdJobType_PickLogicoPrt, cstIdJobType_PickPronto, cstIdJobType_PickPronto1S
                            tmpString += clsAppTranslation.GetSingleParameterValue(1008, "", "-USC.MERCI")
                    End Select
                    If (UCase(clsUtility.GetDataRowItem(inDataRow, "ZFLAWM", "")) = "") Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(1009, "", ">P.LOG.")
                    End If
                    tmpString += vbCrLf

                    tmpString += clsAppTranslation.GetSingleParameterValue(952, "", "MAT:")
                    tmpString += UCase(clsUtility.GetDataRowItem(inDataRow, "MATNR_ORI", "")) + " - "
                    tmpString += UCase(clsUtility.GetDataRowItem(inDataRow, "MAKTG", "")) + " "
                    tmpString += vbCrLf

                    tmpString += clsAppTranslation.GetSingleParameterValue(851, "", "PARTITA:")
                    tmpString += UCase(clsUtility.GetDataRowItem(inDataRow, "CHARG_ORI", "")) + ""
                    tmpString += vbCrLf

                    tmpString += clsAppTranslation.GetSingleParameterValue(853, "", "QTA:")
                    tmpString += UCase(clsUtility.GetDataRowItem(inDataRow, "ZQTAPK_ORI", "0")) + " "
                    tmpString += UCase(clsUtility.GetDataRowItem(inDataRow, "MEINS_ORI", "")) + "-"
                    tmpString += clsAppTranslation.GetSingleParameterValue(1010, "", "PRE:")
                    tmpString += UCase(clsUtility.GetDataRowItem(inDataRow, "ZQTA_PREL_CONS", "0")) + " "
                    tmpString += UCase(clsUtility.GetDataRowItem(inDataRow, "UDM_QTAPR_CONS", "")) + "-"
                    tmpString += clsAppTranslation.GetSingleParameterValue(1011, "", "Q.PL:")
                    tmpString += UCase(clsUtility.GetDataRowItem(inDataRow, "SC_X_PAL", "0")) + " "
                    tmpString += UCase(clsUtility.GetDataRowItem(inDataRow, "UDM_QTAPR_CONS", "")) + ""
                    tmpString += vbCrLf


                    tmpString += clsAppTranslation.GetSingleParameterValue(1012, "", "STATO:")
                    tmpString += UCase(clsUtility.GetDataRowItem(inDataRow, "STATUS", "")) + ""
                    tmpString += vbCrLf

                    tmpString += clsAppTranslation.GetSingleParameterValue(1003, "", "CAR.P:")
                    tmpString += UCase(clsUtility.GetDataRowItem(inDataRow, "ZCARR_PROP", "")) + " "
                    tmpString += clsAppTranslation.GetSingleParameterValue(1004, "", "CAR.E:")
                    tmpString += UCase(clsUtility.GetDataRowItem(inDataRow, "ZCARR_EXEC", "")) + ""
                    tmpString += vbCrLf

                    If (UCase(clsUtility.GetDataRowItem(inDataRow, "PALLET_INTERI", "")) = "X") Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(1013, "", "> FLAG RICH.PALLET INTERI")
                        tmpString += vbCrLf
                    End If

            End Select

            FromSapWmWmsJobDataRowToString = tmpString

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            FromSapWmWmsJobDataRowToString = ""
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function FromMatSelStockGiacenzaOriToString(Optional ByVal inShowMode As Long = 0) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim tmpString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            FromMatSelStockGiacenzaOriToString = ""

            Select Case inShowMode
                Case 0
                    tmpString += clsAppTranslation.GetSingleParameterValue(952, "", "MAT:")
                    tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.CodiceMateriale) + " - "
                    tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.DescrizioneMateriale)
                    tmpString += vbCrLf

                    If (clsUtility.IsStringValid(WmsJob.MaterialeGiacenzaOrigine.FormatoDescrizione, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(953, "", "FORMATO:")
                        tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.FormatoDescrizione)
                        tmpString += vbCrLf
                    End If

                    If (clsUtility.IsStringValid(WmsJob.MaterialeGiacenzaOrigine.Partita, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(851, "", "PARTITA:")
                        tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.Partita) + ""
                        tmpString += vbCrLf
                    End If

                    tmpString += clsAppTranslation.GetSingleParameterValue(950, "", "UBICAZIONE:")
                    tmpString += UCase(MaterialeSelStockGiacenzaOri.UbicazioneInfo.TipoMagazzino) + " - "
                    tmpString += UCase(MaterialeSelStockGiacenzaOri.UbicazioneInfo.Ubicazione) + " "
                    tmpString += vbCrLf

                    tmpString += clsAppTranslation.GetSingleParameterValue(946, "", "QTA DISP.:") + UCase(MaterialeSelStockGiacenzaOri.QtaTotaleLquaDispoUdMAcq) + " " + UCase(MaterialeSelStockGiacenzaOri.UnitaDiMisuraAcquisizione)
                    tmpString += vbCrLf

            End Select

            FromMatSelStockGiacenzaOriToString = tmpString

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            FromMatSelStockGiacenzaOriToString = ""
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ShowJobPickingInfoForUserString(Optional ByVal inShowMode As Long = 0, Optional ByVal inShowQtyOnlyForCurrenteTask As Boolean = False, Optional ByVal inShowQtaDisponibile As Boolean = False) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim tmpString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ShowJobPickingInfoForUserString = ""

            'inShowMode = 0 (DEFAULT)
            ' >>>> MIS:[NrWmsJobs] - [CodiceGruppoMissioni]


            'inShowMode = 1 (CON. INFO UBICAZIONE PRELIEVO)

            Select Case inShowMode
                Case 0
                    If (WmsJob.TipoDirezioneMissioneKZEAR = "A") Then  '>>> VALORIZZATO SOLO PER PRELIEVI E NON PER ALTRE  MISSIONI ( DISACCANTONAMENTO )
                        tmpString += UCase(clsAppTranslation.GetSingleParameterValue(1451, "", "TRASPORTO:")) + " "
                        tmpString += UCase(WmsJob.NumeroTrasporto)
                        tmpString += " - " & UCase(clsAppTranslation.GetSingleParameterValue(1449, "", "STOP:")) + " "
                        tmpString += UCase(WmsJob.StopSequence) & " - "
                        tmpString += UCase(clsAppTranslation.GetSingleParameterValue(1450, "", "DROP:")) + " "
                        tmpString += UCase(WmsJob.DropSequence)
                        tmpString += vbCrLf
                    End If

                    If (clsUtility.IsStringValid(WmsJob.CodiceClienteAG, True) = True) Then
                        tmpString += UCase(clsAppTranslation.GetSingleParameterValue(1530, "", "COMMITTENTE #/NOME")) + ": "
                        tmpString += UCase(WmsJob.CodiceClienteAG) + " - "
                        tmpString += UCase(WmsJob.DescrizioneClienteAG)
                        tmpString += vbCrLf
                    ElseIf (clsUtility.IsStringValid(WmsJob.CodiceFornitore, True) = True) Then
                        tmpString += UCase(clsAppTranslation.GetSingleParameterValue(1483, "", "FORNITORE:")) + " "
                        tmpString += UCase(WmsJob.CodiceFornitore)
                        tmpString += vbCrLf
                    End If

                    If (clsUtility.IsStringValid(WmsJob.CodiceClienteWE, True) = True) Then
                        tmpString += UCase(clsAppTranslation.GetSingleParameterValue(1531, "", "DESTINATARIO #/NOME")) + ": "
                        tmpString += UCase(WmsJob.CodiceClienteWE) + " - "
                        tmpString += UCase(WmsJob.DescrizioneClienteWE)
                        tmpString += vbCrLf
                    End If
                    If (clsUtility.IsStringValid(WmsJob.NumeroOrdineVendita, True) = True) Then
                        tmpString += UCase(clsAppTranslation.GetSingleParameterValue(1077, "", "ORDINE VENDITA:")) + " "
                        tmpString += UCase(WmsJob.NumeroOrdineVendita)
                        tmpString += vbCrLf
                    ElseIf (clsUtility.IsStringValid(WmsJob.NumeroOrdineDiProduzione, True) = True) Then
                        tmpString += UCase(clsAppTranslation.GetSingleParameterValue(1088, "", "ORDINE PRODUZIONE:")) + " "
                        tmpString += UCase(WmsJob.NumeroOrdineDiProduzione)
                        tmpString += vbCrLf
                    End If

                    If (clsUtility.IsStringValid(WmsJob.ConsegnaNumero, True) = True) Then
                        tmpString += UCase(clsAppTranslation.GetSingleParameterValue(1327, "", "CONSEGNA:")) + " "
                        tmpString += UCase(WmsJob.ConsegnaNumero) & " - " & UCase(WmsJob.ConsegnaPosizione)
                        tmpString += vbCrLf
                    End If

                    tmpString += clsAppTranslation.GetSingleParameterValue(1005, "", "MIS:")
                    tmpString += UCase(WmsJob.NrWmsJobs) + "-"
                    tmpString += UCase(WmsJob.CodiceGruppoMissioni)
                    Select Case WmsJob.IdWmsJobType
                        Case cstIdJobType_CheckMaterial
                            tmpString += clsAppTranslation.GetSingleParameterValue(1014, "", "-VERIF.")
                        Case cstIdJobType_DisaccantonaZ08, cstIdJobType_DisaccantonaLog
                            tmpString += clsAppTranslation.GetSingleParameterValue(1015, "", "-DISAC.")
                        Case cstIdJobType_Pick_To_916, cstIdJobType_PickLogicoPrt, cstIdJobType_PickPronto, cstIdJobType_PickPronto1S
                            If (WmsJob.FlagRilevanteWM = "") Then
                                '>>> CASO PRELIEVO LOGICO
                                tmpString += clsAppTranslation.GetSingleParameterValue(1017, "", "-P.LOG.")
                            Else
                                '>>> CASO PRELIEVO NORMALE
                                tmpString += clsAppTranslation.GetSingleParameterValue(1016, "", "-PICK")
                            End If
                    End Select

                    tmpString += vbCrLf

                    tmpString += clsAppTranslation.GetSingleParameterValue(952, "", "MAT:")
                    tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.CodiceMateriale) + " - "
                    tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.DescrizioneMateriale)
                    tmpString += vbCrLf

                    If (clsUtility.IsStringValid(WmsJob.MaterialeGiacenzaOrigine.FormatoDescrizione, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(953, "", "FORMATO:")
                        tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.FormatoDescrizione)
                        tmpString += vbCrLf
                    End If

                    If (clsUtility.IsStringValid(WmsJob.MaterialeGiacenzaOrigine.Partita, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(851, "", "PARTITA:")
                        tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.Partita) + ""

                        If (WmsJob.FlagPartitaTassativa <> "") Then
                            tmpString += " " & clsAppTranslation.GetSingleParameterValue(1742, "", "- MANDATORY") '" - MANDATORY"
                        End If

                        tmpString += vbCrLf
                    End If

                    If (IsValidJobsGroupExec() = True) Then
                        '>>> CASO RAGGRUPPATO
                        For Index_Loop = 0 To UBound(WmsJobsGroupExecInfo.JobsGroupExecTab)
                            tmpString += "M:"
                            tmpString += UCase(WmsJobsGroupExecInfo.JobsGroupExecTab(Index_Loop).NrWmsJobs) + "-"
                            tmpString += "QT:"
                            tmpString += UCase(WmsJobsGroupExecInfo.JobsGroupExecTab(Index_Loop).QtaTotaleDaPrelevareRimanente) + " "
                            tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.UdmQtaJobRichiesta) + "-"
                            tmpString += "PR:"
                            tmpString += UCase(WmsJobsGroupExecInfo.JobsGroupExecTab(Index_Loop).QtaPrelevataInUdMConsegna) + " "
                            tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.UdmQtaPrelevataInUdMConsegna)
                            tmpString += vbCrLf
                        Next
                    Else

                        '************************************************************************************************
                        ' INFO QTA DA PRELEVARE
                        '************************************************************************************************
                        If (inShowQtyOnlyForCurrenteTask = True) Then
                            '>>> VISUALIZZO SOLO LE QTA DA PRELEVARE DEL TASK
                            tmpString += clsAppTranslation.GetSingleParameterValue(1532, "", "QTA DA PRELEVARE") + ":"
                            Dim WorkQtyToPickTask As Double
                            Dim UdmWorkQtyToPickTask As String
                            If (GetJobTaskTotalQtyToPick(WorkQtyToPickTask, UdmWorkQtyToPickTask) = 0) Then
                                tmpString += UCase(Int(WorkQtyToPickTask)) + " "
                                tmpString += UCase(UdmWorkQtyToPickTask)
                            Else
                                tmpString += "0 "
                                tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.UdmQtaJobRichiesta)
                            End If

                            'FORMATTAZZIONE QTA COMPLETA QTA DA PRELEVARE PER UTENTE ( FULL/PARTIAL/SFUSI )
                            tmpString += ShowJobQtyToPickCompleteForUserString(TaskLines, WmsJob, inShowQtyOnlyForCurrenteTask) 'QUI VISUALIZZO SOLO LE QTA DEL TASK
                            tmpString += vbCrLf
                        Else
                            '>>> CASO NORMALE
                            tmpString += clsAppTranslation.GetSingleParameterValue(1532, "", "QTA DA PRELEVARE") + ":"
                            If (WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaInUdmOriginale > 0) Then
                                tmpString += UCase(Int(WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaInUdmOriginale)) + " "
                            Else
                                tmpString += "0 "
                            End If
                            tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.UdmQtaJobRichiesta)
                            tmpString += ShowJobQtyToPickCompleteForUserString(TaskLines, WmsJob, False) 'QUI VISUALIZZO SEMPRE TUTTE LE QTA DELLA MISSIONE
                            tmpString += vbCrLf
                        End If
                    End If

                    '************************************************************************************************
                    '>>> INFO QTA PRELEVATA
                    '************************************************************************************************
                    tmpString += clsAppTranslation.GetSingleParameterValue(1533, "", "QTA PRELEVATA") + ":"
                    If (inShowQtyOnlyForCurrenteTask = True) Then
                        Dim WorkQtyPickedTask As Double
                        Dim UdmWorkQtyPickedTask As String
                        If (GetJobTaskTotalQtyPicked(WorkQtyPickedTask, UdmWorkQtyPickedTask) = 0) Then
                            tmpString += UCase(Int(WorkQtyPickedTask)) + " "
                            tmpString += UCase(UdmWorkQtyPickedTask)
                        Else
                            tmpString += "0 "
                            tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.UdmQtaPrelevataInUdMConsegna)
                        End If
                    Else
                        '>>> QUANDO NON SONO NEL TASK VISUALIZZO TUTTA LA QTA PRELEVATA DEL JOB
                        If (WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna > 0) Then
                            tmpString += UCase(Trim(Int(Val(WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna)))) + " "
                        Else
                            tmpString += "0 "
                        End If
                        tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.UdmQtaPrelevataInUdMConsegna)
                    End If

                    ' >>> VISUALIZZO QTA PRELEVATA IN FORMATO ( PIENI / PARZIALI / SFUSI )
                    tmpString += ShowJobQtyPickedCompleteForUserString(inShowQtyOnlyForCurrenteTask)
                    tmpString += vbCrLf

                    If (WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet > 0) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(1217, "", "SCATOLE x PL:") + Trim(Val(WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet)) + " " + UCase(WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione) + " - "
                        tmpString += clsAppTranslation.GetSingleParameterValue(1472, "", "PZ x SC:") + Trim(Val(WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.PezziPerScatola)) + " " + UCase(WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraPezzo)
                        tmpString += vbCrLf
                    End If

                    '*********************************************************************************************
                    '>>> SE ATTIVA LA GESTIONE DELLE TASK LINES
                    '*********************************************************************************************
                    If (TaskLines.TaskLinesInfo.NrWmsJobs > 0) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(1484, "", "TASK: ") + Trim(Val(TaskLines.TaskLinesInfo.TotalTaskLines)) + " - " + UCase(clsAppTranslation.GetSingleParameterValue(1500, "", "OPEN: ")) + Trim(Str(TaskLines.TaskLinesInfo.TotalTaskLineOpen)) + " ( " + clsAppTranslation.GetSingleParameterValue(1485, "", "FULL: ") + Trim(Val(TaskLines.TaskLinesInfo.TotalTaskLinesOpenFull)) + " / " + clsAppTranslation.GetSingleParameterValue(1486, "", "PARTIAL: ") + Trim(Val(TaskLines.TaskLinesInfo.TotalTaskLinesOpenPartial)) + " )"
                        tmpString += vbCrLf
                    End If

                    'SE RICHIESTO VISUALIZZO QTA DISPONIBILE
                    If (inShowQtaDisponibile = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(1020, "", "QTA DISPON.:")
                        If (WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDispoUdMAcq > 0) Then
                            tmpString += UCase(Trim(Int(Val(WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDispoUdMAcq)))) + " " + WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione
                        Else
                            tmpString += "0 "
                        End If
                        tmpString += vbCrLf
                    End If

                    tmpString += clsAppTranslation.GetSingleParameterValue(1012, "", "STATO:")
                    tmpString += UCase(WmsJob.IdWmsJobStatusDescription) + ""
                    tmpString += vbCrLf

                    If (clsUtility.IsStringValid(WmsJob.PickDbNumero, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(1021, "", "ORD.PIK:")
                        tmpString += UCase(WmsJob.PickDbNumero) + "/" + "POS:" + Trim(WmsJob.PickDbPosizione)
                        tmpString += vbCrLf
                    End If

                    If (clsUtility.IsStringValid(WmsJob.IdCarrellistaProposto, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(1003, "", "CAR.P:")
                        tmpString += UCase(WmsJob.IdCarrellistaProposto) + " "
                        tmpString += vbCrLf
                    End If

                    If (TaskLines.TaskLinesInfo.NrWmsJobs > 0) Then
                        Select Case clsWmsJob.TaskLines.TaskLinesOnWork.PickFullPartialType

                            Case clsTaskLines.cstTaskLinesPickType_FullPallet
                                tmpString += clsAppTranslation.GetSingleParameterValue(1593, "", "CAR.FULL:")
                                tmpString += UCase(WmsJob.IdCarrellistaEsecuzioneFullPallet) + " "
                            Case clsTaskLines.cstTaskLinesPickType_PartialPallet
                                tmpString += clsAppTranslation.GetSingleParameterValue(1594, "", "CAR.PARZIALI:")
                                tmpString += UCase(WmsJob.IdCarrellistaEsecuzione) + " "
                                tmpString += clsAppTranslation.GetSingleParameterValue(1595, "", "CAR.SFUSI:")
                                tmpString += UCase(WmsJob.IdCarrellistaEsecuzioneSfusi) + " "
                            Case clsTaskLines.cstTaskLinesPickType_PickPieces
                                tmpString += clsAppTranslation.GetSingleParameterValue(1595, "", "CAR.SFUSI:")
                                tmpString += UCase(WmsJob.IdCarrellistaEsecuzioneSfusi) + " "
                                tmpString += clsAppTranslation.GetSingleParameterValue(1594, "", "CAR.PARZIALI:")
                                tmpString += UCase(WmsJob.IdCarrellistaEsecuzione) + " "
                            Case Else
                                tmpString += clsAppTranslation.GetSingleParameterValue(1594, "", "CAR.PARZIALI:")
                                tmpString += UCase(WmsJob.IdCarrellistaEsecuzione) + " "
                                tmpString += clsAppTranslation.GetSingleParameterValue(1593, "", "CAR.FULL:")
                                tmpString += UCase(WmsJob.IdCarrellistaEsecuzioneFullPallet) + " "
                                tmpString += clsAppTranslation.GetSingleParameterValue(1595, "", "CAR.SFUSI:")
                                tmpString += UCase(WmsJob.IdCarrellistaEsecuzioneSfusi) + " "
                        End Select
                        tmpString += vbCrLf
                    End If

                    If (WmsJob.FlagPalletInteri = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(1013, "", "> FLAG RICH.PALLET INTERI")
                        tmpString += vbCrLf
                    End If

                    If (clsUtility.IsStringValid(WmsJob.InfoPrelievo, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(1336, "", "INFO:")
                        tmpString += UCase(WmsJob.InfoPrelievo)
                        tmpString += vbCrLf
                    End If

                    tmpString += clsAppTranslation.GetSingleParameterValue(1694, "", "WARNING:")
                    tmpString += UCase(WmsJob.ZWMS_ERROR_CODE) & " - " & UCase(WmsJob.ZWMS_ROW_STA_DES)
                    tmpString += vbCrLf

                Case 1
                        tmpString += ShowJobPickingInfoForUserString(0, inShowQtyOnlyForCurrenteTask, inShowQtaDisponibile)

                        tmpString += clsAppTranslation.GetSingleParameterValue(1022, "", "PRE.UBI:")
                        tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.TipoMagazzino) + "-"
                        tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.Ubicazione) + ""
                        tmpString += vbCrLf

                        If (clsUtility.IsStringValid(WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.UnitaMagazzino, True) = True) Then
                            tmpString += clsAppTranslation.GetSingleParameterValue(1024, "", "PRE.UM:")
                            tmpString += UCase(clsSapUtility.FormattaStringaUnitaMagazzino(WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.UnitaMagazzino))
                            tmpString += vbCrLf
                        End If

                Case 2 '>>> ULTIMI STEP MISSIONI DI PREIEVO CON INDICAZIONE QTA CONFERMATA
                        tmpString += ShowJobPickingInfoForUserString(1, inShowQtaDisponibile)

                        tmpString += clsAppTranslation.GetSingleParameterValue(1025, "", "QTA CONF:")
                        tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore) + "-"
                        tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione) + ""
                        tmpString += vbCrLf

                Case 3 '>>> CASO RIETICHETTATURA CON INDICAZIONE QTA RESIDUA
                        tmpString += ShowJobPickingInfoForUserString(1, inShowQtyOnlyForCurrenteTask, inShowQtaDisponibile)

                        tmpString += clsAppTranslation.GetSingleParameterValue(1026, "", "QTA CON:")
                        tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore) + " "
                        tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione) + " "

                        tmpString += clsAppTranslation.GetSingleParameterValue(1027, "", "QTA RES:")
                        Dim WorkQtàResidua As Double
                        WorkQtàResidua = WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDispoUdMAcq - WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore
                        tmpString += UCase(WorkQtàResidua) + " "
                        tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione) + ""
                        tmpString += vbCrLf

            End Select

            ShowJobPickingInfoForUserString = tmpString

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ShowJobPickingInfoForUserString = ""
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function ShowJobPutAwayInfoForUserString(Optional ByVal inShowMode As Long = 0, Optional ByVal inShowQtaDisponibile As Boolean = False) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim tmpString As String = ""
        Dim QtaResiduaDaPrelevare As Double
        Dim QtaResiduaSfusiDaPrelevare As Double
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ShowJobPutAwayInfoForUserString = ""

            Select Case inShowMode
                Case 0

                    tmpString += clsAppTranslation.GetSingleParameterValue(1005, "", "MIS:")
                    tmpString += UCase(WmsJob.NrWmsJobs) + "-"
                    tmpString += UCase(WmsJob.CodiceGruppoMissioni)
                    Select Case WmsJob.IdWmsJobType
                        Case cstIdJobType_CheckMaterial
                            tmpString += clsAppTranslation.GetSingleParameterValue(1014, "", "-VERIF.")
                        Case cstIdJobType_DisaccantonaZ08, cstIdJobType_DisaccantonaLog
                            tmpString += clsAppTranslation.GetSingleParameterValue(1015, "", "-DISAC.")
                        Case cstIdJobType_Pick_To_916, cstIdJobType_PickLogicoPrt, cstIdJobType_PickPronto, cstIdJobType_PickPronto1S
                            If (WmsJob.FlagRilevanteWM = "") Then
                                '>>> CASO PRELIEVO LOGICO
                                tmpString += clsAppTranslation.GetSingleParameterValue(1017, "", "-P.LOG.")
                            Else
                                '>>> CASO PRELIEVO NORMALE
                                tmpString += clsAppTranslation.GetSingleParameterValue(1016, "", "-PICK")
                            End If
                    End Select
                    tmpString += vbCrLf

                    tmpString += clsAppTranslation.GetSingleParameterValue(847, "", "DIV:")
                    tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.Divisione) + "-"
                    tmpString += clsAppTranslation.GetSingleParameterValue(848, "", "UBI:")
                    tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.TipoMagazzino) + "-"
                    tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.Ubicazione)
                    tmpString += vbCrLf

                    If (clsUtility.IsStringValid(WmsJob.DocumentoMaterialeNumero, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(849, "", "DOC.MAT.:")
                        tmpString += UCase(WmsJob.DocumentoMaterialeNumero)
                        If (clsUtility.IsStringValid(WmsJob.DocumentoMaterialePosizione, True) = True) Then
                            tmpString += "-" + UCase(WmsJob.DocumentoMaterialePosizione)
                        End If
                        tmpString += vbCrLf
                    End If

                    If (clsUtility.IsStringValid(WmsJob.NumeroOrdineVendita, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(858, "", "ORD.VEN:") + UCase(WmsJob.NumeroOrdineVendita) + "/" + UCase(WmsJob.NumeroPosizioneOrdineVendita)
                        tmpString += vbCrLf
                        ' ???? da sistemare tmpString += clsAppTranslation.GetSingleParameterValue(859, "", "QTA ODV:") + UCase(Trim(DocumentoMaterialeBEM.PosizioneInfo.MaterialeInfo.QtaPosizioneDocumentoVenditaUdMConsegna)) + " " + UCase(DocumentoMaterialeBEM.PosizioneInfo.MaterialeInfo.UnitaDiMisuraQtaPosizioneDocumentoVendita)
                        tmpString += vbCrLf
                    End If

                    tmpString += clsAppTranslation.GetSingleParameterValue(952, "", "MAT:")
                    tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.CodiceMateriale) + " - "
                    tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.DescrizioneMateriale)
                    tmpString += vbCrLf

                    If (clsUtility.IsStringValid(WmsJob.MaterialeGiacenzaOrigine.FormatoDescrizione, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(953, "", "FORMATO:")
                        tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.FormatoDescrizione)
                        tmpString += vbCrLf
                    End If

                    If (clsUtility.IsStringValid(WmsJob.MaterialeGiacenzaOrigine.Partita, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(851, "", "PARTITA:")
                        tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.Partita) + ""
                        tmpString += vbCrLf
                    End If

                    'VISUALIZZO QTA
                    tmpString += clsAppTranslation.GetSingleParameterValue(1200, "", "QTA RICH:") '853
                    If (WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDaPrelUdMAcq > 0) Then
                        tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDaPrelUdMAcq) + " "
                    Else
                        tmpString += "0 "
                    End If
                    tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione)

                    'FORMATTAZZIONE QTA COMPLETA PER UTENTE
                    tmpString += ShowJobQtyToPutAwayCompleteForUserString()
                    tmpString += vbCrLf


                    tmpString += clsAppTranslation.GetSingleParameterValue(1201, "", "QTA IDEN:") '1018
                    If (WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna > 0) Then
                        tmpString += UCase(Trim(Val(WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna))) + " "
                    Else
                        tmpString += "0 "
                    End If
                    tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.UdmQtaPrelevataInUdMConsegna)
                    tmpString += ShowJobQtyPickedCompleteForUserString(False)
                    tmpString += vbCrLf


                    If (WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet > 0) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(1217, "", "SCATOLE x PL:") + Trim(Val(WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet)) + " " + UCase(WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione) + " - "
                        tmpString += clsAppTranslation.GetSingleParameterValue(1472, "", "PZ x SC::") + Trim(Val(WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.PezziPerScatola)) + " " + UCase(WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraPezzo)
                        tmpString += vbCrLf
                    End If



                    'SE RICHIESTO VISUALIZZO QTA DISPONIBILE
                    If (inShowQtaDisponibile = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(1020, "", "QTA DISPO:")  '1020
                        If (WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDispoUdMAcq > 0) Then
                            tmpString += UCase(Trim(Val(WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDispoUdMAcq))) + " " + WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione
                        Else
                            tmpString += "0 "
                        End If
                        tmpString += vbCrLf
                    End If

                    tmpString += clsAppTranslation.GetSingleParameterValue(1012, "", "STATO:")
                    tmpString += UCase(WmsJob.IdWmsJobStatusDescription) + ""
                    tmpString += vbCrLf

                    If (clsUtility.IsStringValid(WmsJob.IdCarrellistaProposto, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(1003, "", "CAR.P:")
                        tmpString += UCase(WmsJob.IdCarrellistaProposto) + " "
                    End If
                    If (clsUtility.IsStringValid(WmsJob.IdCarrellistaEsecuzione, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(1004, "", "CAR.E:")
                        tmpString += UCase(WmsJob.IdCarrellistaEsecuzione) + ""
                        tmpString += vbCrLf
                    End If

                Case 1
                    'STEP CONFERMA DELLA QTA DELLA PALETTA
                    tmpString += ShowJobPutAwayInfoForUserString(0, inShowQtaDisponibile)
                    If (clsUtility.IsStringValid(WmsJob.InfoPrelievo, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(1203, "", "NOTE:")
                        tmpString += UCase(WmsJob.InfoPrelievo)
                        tmpString += vbCrLf
                    End If
                    If (clsUtility.IsStringValid(WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.UnitaMagazzino, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(1024, "", "PRE.UM:")
                        tmpString += UCase(clsSapUtility.FormattaStringaUnitaMagazzino(WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.UnitaMagazzino))
                        tmpString += vbCrLf
                    End If

                Case 2 '>>> CASO DI VIDEATA DI CONFERMA FINALE DELL'OPERAZIONE

                    tmpString += ShowJobPutAwayInfoForUserString(1, inShowQtaDisponibile)

                    tmpString += clsAppTranslation.GetSingleParameterValue(1025, "", "QTA CONF:")
                    tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore) + " "
                    tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione) + " / "
                    tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataSfusiOperatore) + " "
                    tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraPezzo) + ""
                    tmpString += vbCrLf


                    'CALCOLO LE QTA RESIDUE DA PRELEVARE
                    QtaResiduaDaPrelevare = WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDaPrelUdMAcq - (WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna + WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore)
                    If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaSfusiInPZ > 0) Then
                        'NEL CASO DI PEZZI TOLGO EVENNTUALI DECIMALI NELLE SCATOLE
                        QtaResiduaDaPrelevare = Int(QtaResiduaDaPrelevare)
                    End If
                    QtaResiduaSfusiDaPrelevare = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaSfusiInPZ - (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataSfusi + WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataSfusiOperatore)
                    tmpString += clsAppTranslation.GetSingleParameterValue(1027, "", "QTA.RES:") '1027
                    tmpString += UCase(QtaResiduaDaPrelevare) + " "
                    tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione) + " / "
                    tmpString += UCase(QtaResiduaSfusiDaPrelevare) + " "
                    tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraPezzo)
                    tmpString += vbCrLf

                    If (clsWmsJob.WmsJob.ForcedConfirmUbicazioneSpunta = True) Or (clsWmsJob.WmsJob.ForcedFinalDestination = True) Then
                        If (clsUtility.IsStringValid(WmsJob.UbicazioneDestinazione.Ubicazione, True) = True) Then
                            tmpString += clsAppTranslation.GetSingleParameterValue(1204, "", "UBI DEST:")
                            tmpString += UCase(WmsJob.UbicazioneDestinazione.TipoMagazzino) + "-"
                            tmpString += UCase(WmsJob.UbicazioneDestinazione.Ubicazione)

                        Else
                            clsAppTranslation.GetSingleParameterValue(451, "", ">UBIC.NON TROVATA")
                        End If
                        tmpString += vbCrLf
                    End If

                    If (clsUtility.IsStringValid(clsWmsJob.DescrUbicDestPick, True) = True) Then
                        '>>> DESCRIZIONE UBICAZIONE
                        tmpString += clsWmsJob.DescrUbicDestPick  '>>> imposto descrizione ubicazione per help operatore
                        tmpString += vbCrLf
                    End If


                Case 3 'INFORMAZIONI GENERALI SULLA MISSIONE ( ES: VIDEATA CHIUSURA LISTA O FUNZIONI VARIE )
                    tmpString += clsAppTranslation.GetSingleParameterValue(1005, "", "MIS:")
                    tmpString += UCase(WmsJob.NrWmsJobs) + "-"
                    tmpString += UCase(WmsJob.CodiceGruppoMissioni)
                    Select Case WmsJob.IdWmsJobType
                        Case cstIdJobType_CheckMaterial
                            tmpString += clsAppTranslation.GetSingleParameterValue(1014, "", "-VERIF.")
                        Case cstIdJobType_DisaccantonaZ08, cstIdJobType_DisaccantonaLog
                            tmpString += clsAppTranslation.GetSingleParameterValue(1015, "", "-DISAC.")
                        Case cstIdJobType_Pick_To_916, cstIdJobType_PickLogicoPrt, cstIdJobType_PickPronto, cstIdJobType_PickPronto1S
                            If (WmsJob.FlagRilevanteWM = "") Then
                                '>>> CASO PRELIEVO LOGICO
                                tmpString += clsAppTranslation.GetSingleParameterValue(1017, "", "-P.LOG.")
                            Else
                                '>>> CASO PRELIEVO NORMALE
                                tmpString += clsAppTranslation.GetSingleParameterValue(1016, "", "-PICK")
                            End If
                    End Select

                    tmpString += vbCrLf

                    tmpString += clsAppTranslation.GetSingleParameterValue(952, "", "MAT:")
                    tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.CodiceMateriale) + " - "
                    tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.DescrizioneMateriale)
                    tmpString += vbCrLf

                    If (clsUtility.IsStringValid(WmsJob.MaterialeGiacenzaOrigine.FormatoDescrizione, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(953, "", "FORMATO:")
                        tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.FormatoDescrizione)
                        tmpString += vbCrLf
                    End If

                    If (clsUtility.IsStringValid(WmsJob.MaterialeGiacenzaOrigine.Partita, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(851, "", "PARTITA:")
                        tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.Partita) + ""
                        tmpString += vbCrLf
                    End If

                    '>>> CASO NORMALE
                    tmpString += clsAppTranslation.GetSingleParameterValue(853, "", "QTA:")
                    If (WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaInUdmOriginale > 0) Then
                        tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaInUdmOriginale) + " "
                    Else
                        tmpString += "0 "
                    End If
                    tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.UdmQtaJobRichiesta) + "-"

                    tmpString += clsAppTranslation.GetSingleParameterValue(1018, "", "PRE.:")
                    If (WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna > 0) Then
                        tmpString += UCase(Trim(Val(WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna))) + " "
                    Else
                        tmpString += "0 "
                    End If
                    tmpString += UCase(WmsJob.MaterialeGiacenzaOrigine.UdmQtaPrelevataInUdMConsegna)
                    If (WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet > 0) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(1218, "", "-PL:") + Trim(Val(WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet)) + " " + UCase(WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione) '1019
                    End If
                    tmpString += vbCrLf


                    tmpString += clsAppTranslation.GetSingleParameterValue(1012, "", "STATO:")
                    tmpString += UCase(WmsJob.IdWmsJobStatusDescription) + ""
                    tmpString += vbCrLf

                    'INFO SUL DOCUMENTO DI SAP
                    If (clsUtility.IsStringValid(WmsJob.PickDbNumero, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(1021, "", "ORD.PIK:")
                        tmpString += UCase(WmsJob.PickDbNumero) + "/" + "POS:" + Trim(WmsJob.PickDbPosizione)
                        tmpString += vbCrLf
                    End If
                    If (clsUtility.IsStringValid(WmsJob.DocumentoMaterialeNumero, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(849, "", "DOC.MAT.:")
                        tmpString += UCase(WmsJob.DocumentoMaterialeNumero) + "/" + "POS:" + Trim(WmsJob.DocumentoMaterialePosizione)
                        tmpString += vbCrLf
                    End If


                    tmpString += clsAppTranslation.GetSingleParameterValue(1003, "", "CAR.P:")
                    tmpString += UCase(WmsJob.IdCarrellistaProposto) + " "
                    tmpString += clsAppTranslation.GetSingleParameterValue(1004, "", "CAR.E:")
                    tmpString += UCase(WmsJob.IdCarrellistaEsecuzione) + ""
                    tmpString += vbCrLf

            End Select


            ShowJobPutAwayInfoForUserString = tmpString

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ShowJobPutAwayInfoForUserString = ""
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function IsPickingLogicJobs(ByVal inShowMessageBox As Boolean) As Boolean
        ' ************************************************************
        ' DESCRIZIONE : ritorna un DATASET con un ELENCO DI JOBSGROUPS
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            IsPickingLogicJobs = False 'init at error

            '>>> CASO DI USCITA MERCI (A) / ENTRATA MERCE (E)
            If (WmsJob.FlagRilevanteWM = "") And (WmsJob.TipoDirezioneMissioneKZEAR = "A") Then
                '>>> CASO DI PICKING LOGICO
                IsPickingLogicJobs = True
            End If
            If (WmsJob.FlagRilevanteWM = "") And (WmsJob.TipoDirezioneMissioneKZEAR = "E") Then
                '>>> CASO DI PICKING LOGICO
                IsPickingLogicJobs = True
            End If



            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            IsPickingLogicJobs = False 'CASO DI CATCH
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function IsPickingCheckOnlyPresenceJobs(ByVal inShowMessageBox As Boolean) As Boolean
        ' ************************************************************
        ' DESCRIZIONE : ritorna un DATASET con un ELENCO DI JOBSGROUPS
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            IsPickingCheckOnlyPresenceJobs = False 'init at error

            '>>> CASO DI USCITA MERCI (A) / ENTRATA MERCE (E)
            If (WmsJob.IdWmsJobType = cstIdJobType_CheckMaterial) And (WmsJob.TipoDirezioneMissioneKZEAR = "A") Then
                '>>> CASO DI PICKING LOGICO
                IsPickingCheckOnlyPresenceJobs = True
            End If



            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            IsPickingCheckOnlyPresenceJobs = False 'CASO DI CATCH
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function IsJobsOkForExecution(ByVal inShowMessageBox As Boolean) As Boolean
        ' ************************************************************
        ' DESCRIZIONE : ritorna un DATASET con un ELENCO DI JOBSGROUPS
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim QtaRimastaDaPrelevare As Double
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            IsJobsOkForExecution = False 'init at error

            If (WmsJob.NrWmsJobs <= 0) Then
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1028, "", "Attenzione, Numero JOBS non valido.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            If (WmsJob.IdWmsJobStatus >= cstIdJobStatus_Verificato) Then
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1029, "", "Attenzione, STATO JOBS già TERMINATO.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If
            If (WmsJob.IdWmsJobStatus = cstIdJobStatus_Sospeso) Then
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1030, "", "Attenzione, STATO JOBS in SOSPESO.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If
            If (WmsJob.IdWmsJobStatus = cstIdJobStatus_Cancellato) Then
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1031, "", "Attenzione, STATO JOBS in CANCELLATO.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If
            If (WmsJob.IdWmsJobStatus < cstIdJobStatus_Pianificato) Then
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1032, "", "Attenzione, STATO JOBS non PIANIFICATO.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            '>>> CASO DI USCITA MERCI (A) / ENTRATA MERCE (E)
            If (WmsJob.FlagRilevanteWM = "W") And (WmsJob.TipoDirezioneMissioneKZEAR = "A") Then

                'RECUPERO LE INFO SUL POSTO OTTIMALE DI PRELIEVO DELLA MERCE
                QtaRimastaDaPrelevare = WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDaPrelUdMAcq - WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna

                'VERIFICARE SE HO PRELEVATO TUTTA LA QTA
                If (QtaRimastaDaPrelevare <= 0) Then
                    If (inShowMessageBox = True) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(418, "", "Attenzione! Nessuna QTA da prelevare. QTA Da Prelevare:") & WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDaPrelUdMAcq & clsAppTranslation.GetSingleParameterValue(419, "", " Qta Prelevata:") & WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If
                    Exit Function
                End If

            ElseIf (WmsJob.FlagRilevanteWM = "W") And (WmsJob.TipoDirezioneMissioneKZEAR = "E") Then
                '>>> CASO DI ENTRATA MERCE (E)

            End If

            'SE ARRIVO QUI TUTTI I CONTROLLI SONO OK
            IsJobsOkForExecution = True

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            IsJobsOkForExecution = False 'CASO DI CATCH
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function CheckIfAllJobsQueueAreFinished(ByRef outFlagAllJobsQueueAreFinished As Boolean, ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : verifica se TUTTI I JOB SONO TERMINATI ( PICKING FATTO PER TUTTE LE SUE TASK LINES)
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        '**************************************
        Dim RetCode As Long = 0
        Dim WorkDataRow As DataRow
        Dim WorkJobTaskLinesAreNotFinished As Boolean = False


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            CheckIfAllJobsQueueAreFinished = 1 'init at error

            outFlagAllJobsQueueAreFinished = True

            If (objDataTableWmsJobsList Is Nothing) Then
                Exit Function
            End If

            If (objDataTableWmsJobsList.Rows Is Nothing) Then
                Exit Function
            End If

            '********************************************************************************************
            ' >>> CONTROLLO LO STATO DEI DIVERSI JOB PRESENTI NELLA CODA IN LAVORAZIONE
            '********************************************************************************************
            For Each WorkDataRow In objDataTableWmsJobsList.Rows

                WorkJobTaskLinesAreNotFinished = False  'INIT

                RetCode = CheckIfJobTaskLinesAreNotFinished(WorkDataRow, WorkJobTaskLinesAreNotFinished)
                If (WorkJobTaskLinesAreNotFinished = False) Then
                    Continue For
                End If

                'SE ARRIVO QUI UN JOB HA ANCORA QUALCOSA DA PRELEVARE
                outFlagAllJobsQueueAreFinished = False

            Next

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckIfAllJobsQueueAreFinished = 1000 'CASO DI CATCH
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function CheckIfJobTaskLinesAreNotFinished(ByRef inWmsJobDataRow As DataRow, ByRef outJobTaskLinesAreNotFinished As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : verifica se tutte le task lines di un JOB NON sono terminate
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        '**************************************
        Dim WorkZNR_WMS_JOBS As String = ""
        Dim WorkIdWmsJobStatus As String
        Dim WorkQtaJobRichiestaInUdmBase As Double = 0
        Dim WorkQtaJobRichiestaSfusiInPZ As Double = 0
        Dim WorkQtaPrelevataSfusi As Double = 0
        Dim WorkQtaPrelevataInUdMBase As Double = 0
        Dim WorkDataRowsTaskLines() As DataRow
        Dim WorkQtaJobRichiestaFullPallet As Double = 0
        Dim WorkQtaPrelevataFullPallet As Double = 0
        Dim WorkQtaJobRichiestaPartialPallet As Double = 0
        Dim WorkQtaPrelevataPartialPallet As Double = 0
        Dim WorkPickFullPartialType As String = ""

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CheckIfJobTaskLinesAreNotFinished = 1

            outJobTaskLinesAreNotFinished = False           'init

            If (inWmsJobDataRow Is Nothing) Then
                Exit Function
            End If

            WorkIdWmsJobStatus = clsUtility.GetDataRowItem(inWmsJobDataRow, "IDSTATUS", "")
            If (WorkIdWmsJobStatus = cstIdJobStatus_Terminato) Then
                Exit Function
            End If


            WorkZNR_WMS_JOBS = clsUtility.GetDataRowItem(inWmsJobDataRow, "ZNR_WMS_JOBS", "0")
            WorkQtaJobRichiestaInUdmBase = clsUtility.GetDataRowItem(inWmsJobDataRow, "ZQTAPK_ORI_BASE", "0")
            WorkQtaJobRichiestaSfusiInPZ = clsUtility.GetDataRowItem(inWmsJobDataRow, "ZQTAPK_SFUSI_PZ", "0")
            WorkQtaPrelevataInUdMBase = clsUtility.GetDataRowItem(inWmsJobDataRow, "ZQTA_PREL_BASE", "0")
            WorkQtaPrelevataSfusi = clsUtility.GetDataRowItem(inWmsJobDataRow, "ZQTA_PREL_SF", "0")

            'SE HO PRELEVATO TUTTO IL JOB PER L'ESECUZIONE NELLA CODA E' "TERMINATO"
            If (WorkQtaPrelevataInUdMBase >= WorkQtaJobRichiestaInUdmBase) And (WorkQtaJobRichiestaInUdmBase > 0) Then
                'PRELEVATO TUTTA LA QTA
                Exit Function
            End If

            WorkDataRowsTaskLines = TaskLines.objDataTableJobTaskLines.Select("ZNR_WMS_JOBS=" & WorkZNR_WMS_JOBS)
            If (WorkDataRowsTaskLines Is Nothing) Then
                Exit Function
            End If

            '>>> VERIFICO LO STATO DEL PRELIEVO DI OGNI TASK LINES DELLA CODA ( PRENDO LE QTA DEL JOB PER COMODITA )
            For Each WorkDataRowTaskLine In WorkDataRowsTaskLines

                WorkPickFullPartialType = clsUtility.GetDataRowItem(WorkDataRowTaskLine, "ZPICKFULLPARTIAL", "")

                WorkQtaJobRichiestaFullPallet = clsUtility.GetDataRowItem(WorkDataRowTaskLine, "ZQTAPK_FULL_PALL", "0")
                WorkQtaPrelevataFullPallet = clsUtility.GetDataRowItem(WorkDataRowTaskLine, "ZQTA_PREL_FULL", "0")
                WorkQtaJobRichiestaPartialPallet = clsUtility.GetDataRowItem(WorkDataRowTaskLine, "ZQTAPK_PARTIAL", "0")
                WorkQtaPrelevataPartialPallet = clsUtility.GetDataRowItem(WorkDataRowTaskLine, "ZQTA_PREL_PARTIA", "0")
                WorkQtaJobRichiestaSfusiInPZ = clsUtility.GetDataRowItem(WorkDataRowTaskLine, "ZQTAPK_SFUSI_PZ", "0")
                WorkQtaPrelevataSfusi = clsUtility.GetDataRowItem(WorkDataRowTaskLine, "ZQTA_PREL_SF", "0")

                'CASO DI UN TASK ATTIVO DEVO GESTIRE IL CASO DI PRELIEVO FULL/PARZIALE/SFUSI
                If (WorkPickFullPartialType = clsTaskLines.cstTaskLinesPickType_FullPallet) Then
                    If (WorkQtaPrelevataFullPallet >= WorkQtaJobRichiestaFullPallet) And (WorkQtaJobRichiestaFullPallet > 0) Then
                        'PRELEVATO TUTTA LA QTA
                        Continue For
                    End If
                End If
                If (WorkPickFullPartialType = clsTaskLines.cstTaskLinesPickType_PartialPallet) Then
                    If (WorkQtaPrelevataPartialPallet >= WorkQtaJobRichiestaPartialPallet) And (WorkQtaJobRichiestaPartialPallet > 0) Then
                        'PRELEVATO TUTTA LA QTA
                        Continue For
                    End If
                End If
                If (WorkPickFullPartialType = clsTaskLines.cstTaskLinesPickType_PickPieces) Then
                    If (WorkQtaPrelevataSfusi >= WorkQtaJobRichiestaSfusiInPZ) And (WorkQtaPrelevataSfusi > 0) Then
                        'PRELEVATO TUTTA LA QTA
                        Continue For
                    End If
                End If

                'SE ARRIVO QUI UN JOB HA ANCORA QUALCOSA DA PRELEVARE
                outJobTaskLinesAreNotFinished = True
            Next

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckIfJobTaskLinesAreNotFinished = 1000 'CASO DI CATCH
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function
    Public Shared Function GetTotalWeightItemspPickedAllJobsQueue(ByRef outTotalWeightItemspPickedAllJobsQueue As Double, ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : verifica se TUTTI I JOB SONO TERMINATI ( PICKING FATTO )
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        '**************************************
        Dim WorkDataRow As DataRow
        Dim WorkIdWmsJobStatus As String
        Dim WorkQtaJobRichiestaInUdmBase As Double = 0
        Dim WorkQtaJobRichiestaSfusiInPZ As Double = 0
        Dim WorkQtaPrelevataSfusi As Double = 0
        Dim WorkQtaPrelevataInUdMBase As Double = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            GetTotalWeightItemspPickedAllJobsQueue = 1 'init at error

            outTotalWeightItemspPickedAllJobsQueue = 0

            If (objDataTableWmsJobsList Is Nothing) Then
                Exit Function
            End If

            If (objDataTableWmsJobsList.Rows Is Nothing) Then
                Exit Function
            End If

            'CONTROLLO LO STATO DEI DIVERSI JOB PRESENTI
            For Each WorkDataRow In objDataTableWmsJobsList.Rows
                WorkIdWmsJobStatus = clsUtility.GetDataRowItem(WorkDataRow, "IDSTATUS", "")
                If (WorkIdWmsJobStatus = cstIdJobStatus_Terminato) Then
                    Continue For
                End If

                'SE HO PRELEVATO TUTTO IL JOB PER LA CODA E' TERMINATO

                WorkQtaJobRichiestaInUdmBase = clsUtility.GetDataRowItem(WorkDataRow, "ZQTAPK_ORI_BASE", "0")
                WorkQtaJobRichiestaSfusiInPZ = clsUtility.GetDataRowItem(WorkDataRow, "ZQTAPK_SFUSI_PZ", "0")
                WorkQtaPrelevataInUdMBase = clsUtility.GetDataRowItem(WorkDataRow, "ZQTA_PREL_BASE", "0")
                WorkQtaPrelevataSfusi = clsUtility.GetDataRowItem(WorkDataRow, "ZQTA_PREL_SF", "0")
                If (WorkQtaPrelevataInUdMBase >= WorkQtaJobRichiestaInUdmBase) And (WorkQtaJobRichiestaInUdmBase > 0) Then
                    'PRELEVATO TUTTA LA QTA
                    Continue For
                End If
                If (WorkQtaPrelevataSfusi >= WorkQtaJobRichiestaSfusiInPZ) And (WorkQtaJobRichiestaSfusiInPZ > 0) Then
                    'PRELEVATO TUTTA LA QTA
                    Continue For
                End If

            Next

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetTotalWeightItemspPickedAllJobsQueue = 1000 'CASO DI CATCH
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CheckQtyForFlagOnlyFullPallet(ByVal inEnteredQty As Double, ByRef outFlagOnlyFullPalletActive As Boolean, ByVal inShowMessageBox As Boolean) As Boolean
        ' ************************************************************
        ' DESCRIZIONE : verifica se ci sono le condizioni di PALLET INTERO
        ' ************************************************************
        Dim WorkUdmQty As String = ""
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            CheckQtyForFlagOnlyFullPallet = False 'init at error

            outFlagOnlyFullPalletActive = False


            If (WmsJob.NrWmsJobs <= 0) Then
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1028, "", "Attenzione, Numero JOBS non valido.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            If (clsWmsJob.IsJobPickPartialPickPieces(WorkUdmQty) = True) Then
                'CASO DI PRELIEVO DI SFUSI, SALTO QUESTO CONTROLLO
                Exit Function
            End If

            'IMPOSTO IL FLAG DI RITORNO PER GESTIONE PALLET ATTIVI
            outFlagOnlyFullPalletActive = WmsJob.FlagPalletInteri

            If (WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet > 0) Then
                If (inEnteredQty <> WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet) Then
                    '>>> CASO QTA CONFERMATA DIVERSA DALLA PALLETIZZAZIONE
                    If (inShowMessageBox = True) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1033, "", "Attenzione! Qtà diversa da quella di un pallet intero.")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If
                    CheckQtyForFlagOnlyFullPallet = False 'qta confermata diversa dalla palletizzazione
                Else
                    CheckQtyForFlagOnlyFullPallet = True 'QTA CONF = QTA PALLETIZZAZIONE
                End If
            Else
                'CASO IN CUI NON E' GESTITA LA PALLETIZZAZIONE PER CUI TORNO OK
                CheckQtyForFlagOnlyFullPallet = True
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckQtyForFlagOnlyFullPallet = False 'CASO DI CATCH
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function CheckPickingNeedConfirmQty(ByRef outPickingNeedConfirmQty As Boolean, ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : verifica se la missione richiede l'immissione della conferma della QTA di prodotto prelevato
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim ScatolePerPallet As Double = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            CheckPickingNeedConfirmQty = 1 'init at error

            outPickingNeedConfirmQty = True

            If (WmsJob.NrWmsJobs <= 0) Then
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1028, "", "Attenzione, Numero JOBS non valido.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                RetCode = 10
                CheckPickingNeedConfirmQty = RetCode
                Exit Function
            End If

            '>>> CASO DI USCITA MERCI (A) / ENTRATA MERCE (E)
            If (WmsJob.FlagRilevanteWM <> "W") Then
                RetCode = 0 '>>> CONDIZIONE DI NESSUN ERRORE
                CheckPickingNeedConfirmQty = RetCode
                Exit Function
            End If

            If (WmsJob.TipoDirezioneMissioneKZEAR <> "A") Then
                RetCode = 0 '>>> CONDIZIONE DI NESSUN ERRORE
                CheckPickingNeedConfirmQty = RetCode
                Exit Function
            End If

            If (clsWmsJob.TaskLines Is Nothing) Then
                RetCode = 0 '>>> CONDIZIONE DI NESSUN ERRORE
                CheckPickingNeedConfirmQty = RetCode
                Exit Function
            End If

            If (TaskLines.TaskLinesOnWork.NrTaskLines <= 0) Then
                RetCode = 0 '>>> CONDIZIONE DI NESSUN ERRORE
                CheckPickingNeedConfirmQty = RetCode
                Exit Function
            End If

            If (TaskLines.TaskLinesOnWork.NrTaskLines > 0) And (TaskLines.TaskLinesOnWork.PickFullPartialType = clsTaskLines.cstTaskLinesPickType_FullPallet) Then
                'VERIFICO SE LA QTA PRELEVATA E' = ALLA PALETTA INTERA ( QUESTO E' L'UNICO CASO IN CUI NON CHIEDO CONFERMA DELLA QTA )
                ScatolePerPallet = clsWmsJob.MaterialeSelStockGiacenzaOri.VarianteImballo.ScatolePerPallet
                If (clsWmsJob.MaterialeSelStockGiacenzaOri.QtaTotaleLquaInStockUdMAcq = ScatolePerPallet) And (ScatolePerPallet > 0) Then
                    'CASO DI PALETTA INTERA CONFERMATA PER  CUI  NON CHIEDO CONFERMA DELLA QTA
                    outPickingNeedConfirmQty = False
                    RetCode = 0 '>>> CONDIZIONE DI NESSUN ERRORE
                    CheckPickingNeedConfirmQty = RetCode
                    Exit Function
                End If
            End If

            CheckPickingNeedConfirmQty = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckPickingNeedConfirmQty = 1000 'CASO DI CATCH
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function IsJobsYetEnded(ByVal inShowMessageBox As Boolean) As Boolean
        ' ************************************************************
        ' DESCRIZIONE : verifica se un JOB è TERMINATO
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            IsJobsYetEnded = False 'init at error

            If (WmsJob.NrWmsJobs <= 0) Then
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1028, "", "Attenzione, Numero JOBS non valido.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            If (WmsJob.IdWmsJobStatus >= cstIdJobStatus_Verificato) Then
                IsJobsYetEnded = True
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1034, "", " STATO JOBS = TERMINATO.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            IsJobsYetEnded = False 'CASO DI CATCH
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function IsLastStepJobDecori(ByRef inJobDataRow As DataRow, ByVal inShowMessageBox As Boolean) As Boolean
        ' ************************************************************
        ' DESCRIZIONE : verifica se un JOB è dei DECORI E ALL'ULTIMO STEP
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim WorkFieldValue As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            IsLastStepJobDecori = False 'init at error

            WorkFieldValue = clsUtility.GetDataRowItem(inJobDataRow, "ZNR_WMS_JOBS", "")
            If (clsUtility.IsStringValid(WorkFieldValue, True) = False) Then
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1028, "", "Attenzione, Numero JOBS non valido.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            WorkFieldValue = clsUtility.GetDataRowItem(inJobDataRow, "IDSTATUS", "0")
            If (Val(WorkFieldValue) <> cstIdJobStatus_Iniziato) Then
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1035, "", " STATO JOBS non INIZIATO.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            If (Val(WorkFieldValue) <> cstIdJobType_PickPronto1S) Then
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1036, "", " TIPO JOBS non del tipo PICK PRONTO 1S.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            WorkFieldValue = clsUtility.GetDataRowItem(inJobDataRow, "SEQUENCE", "0")
            If (Val(WorkFieldValue) <= 1) Then
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1037, "", " Numero sequenza non finale.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            '>>> CONDIZIONE DI JOB DI PRELIEVO DECORI ALL'ULTIMO STEP
            IsLastStepJobDecori = True

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            IsLastStepJobDecori = False 'CASO DI CATCH
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function IsJobsSuspended(ByVal inShowMessageBox As Boolean) As Boolean
        ' ************************************************************
        ' DESCRIZIONE : verifica se un JOB è SOSPESO
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            IsJobsSuspended = False 'init at error

            If (WmsJob.NrWmsJobs <= 0) Then
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1028, "", "Attenzione, Numero JOBS non valido.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            If (WmsJob.IdWmsJobStatus = cstIdJobStatus_Sospeso) Then
                IsJobsSuspended = True
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1038, "", " STATO JOBS = SOSPESO.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            IsJobsSuspended = False 'CASO DI CATCH
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function IsJobsCancelled(ByVal inShowMessageBox As Boolean) As Boolean
        ' ************************************************************
        ' DESCRIZIONE : verifica se un JOB è CANCELLATO
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            IsJobsCancelled = False 'init at error

            If (WmsJob.NrWmsJobs <= 0) Then
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1028, "", "Attenzione, Numero JOBS non valido.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            If (WmsJob.IdWmsJobStatus = cstIdJobStatus_Cancellato) Then
                IsJobsCancelled = True
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1039, "", " STATO JOBS = CANCELLATO.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            IsJobsCancelled = False 'CASO DI CATCH
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function JobsActivateExecution(ByVal inIdCarrellistaEsecuzione As String, ByVal inCheckJobOkForAction As Boolean, ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : ritorna un DATASET con un ELENCO DI JOBSGROUPS
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim GetPickLocationOk As Boolean = False
        Dim GetPickQtyOk As Boolean = False
        Dim CheckExecutionOk As Boolean = False
        Dim CheckWarningFlag As Boolean = False
        Dim WarningDescription As String = ""
        Dim QtaRimastaDaPrelevare As Double
        Dim WorkUbicazione As clsDataType.SapWmUbicazione
        Dim UserAnswer As DialogResult
        Dim IdCarrellistaEsecuzione As String = ""
        Dim IdCarrellistaEsecuzioneFullPallet As String = ""
        Dim IdCarrellistaEsecuzioneSfusi As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            JobsActivateExecution = 1 'init at error

            '>>> VERIFICO SE IL JOB E' OK PER L'ESECUZIONE
            If (IsJobsOkForExecution(inShowMessageBox) = False) Then
                RetCode = 10
                JobsActivateExecution = RetCode
                Exit Function
            End If

            '>>> CASO DI PRELIEVO LOGICO
            If (IsPickingLogicJobs(inShowMessageBox) = True) Then
                'IMPOSTO DATI DELLO STOCK SCELTO COME STOCK DI PRELIEVO PER PICKING
                RetCode = clsWmsJob.SetJobPickMaterialGiacenzaOri(True)
                If (RetCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(377, "", "Errore in impostazione dati giacenza.") & vbCrLf & "[SetJobPickMaterialGiacenzaOri]" & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Function
                End If
            End If
            If (IsPickingCheckOnlyPresenceJobs(inShowMessageBox) = True) Then
                'IMPOSTO DATI DELLO STOCK SCELTO COME STOCK DI PRELIEVO PER PICKING
                RetCode = clsWmsJob.SetJobPickMaterialGiacenzaOri(True)
                If (RetCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(377, "", "Errore in impostazione dati giacenza.") & vbCrLf & "[SetJobPickMaterialGiacenzaOri]" & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Function
                End If
            End If

            '>>> VERIFICO SE CI SONO LE CONDIZIONI DI ESECUZIONE
            If (inCheckJobOkForAction = True) Then
                RetCode += clsSapWS.Call_ZWS_CHECK_JOBS_OK_FOR_ACTION(WmsJob, CheckExecutionOk, CheckWarningFlag, WarningDescription, clsUser.SapWmsUser.LANGUAGE, SapFunctionError, False)
                If (CheckExecutionOk = False) Then
                    RetCode = 100
                    JobsActivateExecution = RetCode
                    If (inShowMessageBox = True) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1040, "", "Missione non OK per esecuzione.") & vbCrLf & SapFunctionError.ERROR_DESCRIPTION & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If
                    Exit Function
                End If
                If (CheckWarningFlag = True) Then
                    '>>> CASO DI SEGNALAZIONE DI ESECUZIONE CHE NON RISPETTA LA SEQUENZA
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1041, "", "Sequenza ESECUZIONE missioni non rispettata.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1042, "", "Si desidera comunque continuare ? (Si / No )")
                    UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                        RetCode = 200
                        JobsActivateExecution = RetCode
                        Exit Function
                    End If
                End If
            End If

            IdCarrellistaEsecuzione = clsUser.SapWmsUser.ZCARR

            '>>> VERIFICO SE MISSIONE DI CASO DI USCITA MERCI (A) / ENTRATA MERCE (E)
            If (WmsJob.FlagRilevanteWM = "W") And (WmsJob.TipoDirezioneMissioneKZEAR = "A") And (IsPickingCheckOnlyPresenceJobs(inShowMessageBox) = False) Then
                '>>> CASO DI USCITA MERCI (A)

                'RECUPERO LE INFO SULLA QTA RIMASTA DA PRELEVARE ( DEVE ESSERE CON UDM UGUALE A QUELLA RICHIESTA )

                If (WmsJob.MaterialeGiacenzaOrigine.UdmQtaJobRichiesta = WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione) Then
                    QtaRimastaDaPrelevare = WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDaPrelUdMAcq - WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna
                ElseIf (WmsJob.MaterialeGiacenzaOrigine.UdmQtaJobRichiesta = WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraBase) Then
                    QtaRimastaDaPrelevare = WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaInUdmBase - WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMBase
                Else
                    '>>> CASO DI SICUREZZA
                    QtaRimastaDaPrelevare = WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDaPrelUdMAcq - WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna
                End If
                'VERIFICARE SE HO PRELEVATO TUTTA LA QTA
                If (QtaRimastaDaPrelevare <= 0) Then
                    RetCode = 300
                    JobsActivateExecution = RetCode
                    If (inShowMessageBox = True) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(418, "", "Attenzione! Nessuna QTA da prelevare. QTA Da Prelevare:") & WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDaPrelUdMAcq & clsAppTranslation.GetSingleParameterValue(419, "", " Qta Prelevata:") & WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If
                    Exit Function
                End If
                '>>> CASO DI USCITA MERCI (A)
                RetCode += clsSapWS.Call_ZWS_MB_GET_WM_OUT_ORI_BASIC(WmsJob.MaterialeGiacenzaOrigine, WmsJob, QtaRimastaDaPrelevare, WorkUbicazione, Nothing, "", GetPickLocationOk, GetPickQtyOk, MaterialePickOriGiacenze, DescrUbicOriPick, Nothing, SapFunctionError, False)
                If (GetPickLocationOk = False) Then
                    RetCode = 320
                    JobsActivateExecution = RetCode
                    If (inShowMessageBox = True) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1487, "", "Attenzione, materiale da prelevare non trovato tra i disponibili.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If
                    Exit Function
                End If

                '>>> SE SI TRATTA DI UN RESO AD UN FORNITORE SEGNALO QUESTA CONDIZIONE DOVE OCCORRE PRELEVARE UNO SPECIFICO OGGETTO
                If (WmsJob.CondizioneDiReso = True) Then
                    '>>> SOLO SEGNALAZIONE PER OPERATORE, NO ERRORE
                    If (inShowMessageBox = True) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1043, "", "Attenzione, attivata una MISSIONE DI RESO.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1044, "", "Verificare e identificare correttamente la merce da prelevare.")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If
                End If

                'VERIFICO IN CHE VIDEATA DEVO ANDARE PRINCIPALMENTE IN BASE AL TIPO MAGAZZINO 
                RetCode = GetCurrentPickingMerciSourceType()

            ElseIf (WmsJob.FlagRilevanteWM = "W") And (WmsJob.TipoDirezioneMissioneKZEAR = "E") And (IsPickingCheckOnlyPresenceJobs(inShowMessageBox) = False) Then
                '>>> CASO DI ENTRATA MERCE (E)

                'RECUPERO LE INFO SULLA QTA RIMASTA DA PRELEVARE
                QtaRimastaDaPrelevare = WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDaPrelUdMAcq - WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna


            End If

            '*********************************************************************
            'CASO DI UNA MISSIONE DI DISACCANTONAMENTO
            '*********************************************************************
            If (WmsJob.IdWmsJobType = cstIdJobType_DisaccantonaZ08) And (WmsJob.FlagRilevanteWM = "W") And (WmsJob.TipoDirezioneMissioneKZEAR = "E") Then
                'RECUPERO LE INFO SULLA QTA RIMASTA DA PRELEVARE
                QtaRimastaDaPrelevare = WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDaPrelUdMAcq - WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna

                ReDim MaterialePickOriGiacenze(0)
                MaterialePickOriGiacenze(0).UbicazioneInfo.Divisione = WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.Divisione
                MaterialePickOriGiacenze(0).UbicazioneInfo.NumeroMagazzino = WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.NumeroMagazzino
                If (clsUtility.IsStringValid(WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.TipoMagazzino, True) = True) Then
                    MaterialePickOriGiacenze(0).UbicazioneInfo.TipoMagazzino = WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.TipoMagazzino
                Else
                    '>>> SE L'INFORMAZONE NON E' PRESENTE FORZO QUELLA DI DEFAULT
                    MaterialePickOriGiacenze(0).UbicazioneInfo.TipoMagazzino = clsSapUtility.cstSapTipoMagDisaccantonamento
                End If
                If (clsUtility.IsStringValid(WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.Ubicazione, True) = True) Then
                    MaterialePickOriGiacenze(0).UbicazioneInfo.Ubicazione = WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.Ubicazione
                Else
                    '>>> SE L'INFORMAZONE NON E' PRESENTE FORZO QUELLA DI DEFAULT
                    MaterialePickOriGiacenze(0).UbicazioneInfo.Ubicazione = clsSapUtility.cstSapUbicazioneDisaccantonamento
                End If
                If (clsUtility.IsStringValid(WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.UnitaMagazzino, True) = True) Then
                    MaterialePickOriGiacenze(0).UbicazioneInfo.UnitaMagazzino = clsSapUtility.FormattaStringaUnitaMagazzino(WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.UnitaMagazzino)
                Else
                    MaterialePickOriGiacenze(0).UbicazioneInfo.UnitaMagazzino = ""
                End If
                MaterialePickOriGiacenze(0).UbicazioneInfo.AbilitaUnitaMagazzino = False
            End If

            ''IMPOSTO L'ORARIO DI START DELLA MISSIONE
            'RetCode += ActionInfo.ActionStart()

            ''SE ARRIVO QUI POSSO IMPOSTARE IL CARRELLISTA SE NON ERA IMPOSTATO
            'If (clsUtility.IsStringValid(WmsJob.IdCarrellistaEsecuzione, True) = False) And (WmsJob.IdWmsJobStatus < clsWmsJob.cstIdJobStatus_Iniziato) Then
            '    '>>> IMPOSTO IL CARRELLISTA
            '    RetCode = SetJobCarrellista(WmsJob.NrWmsJobs, "", IdCarrellistaEsecuzione, IdCarrellistaEsecuzioneFullPallet, IdCarrellistaEsecuzioneSfusi, True)
            '    If (RetCode <> 0) Then
            '        RetCode = 820
            '        JobsActivateExecution = RetCode
            '        If (inShowMessageBox = True) Then
            '            ErrDescription = clsAppTranslation.GetSingleParameterValue(1045, "", "Attenzione, errore in scrittura CARRELLISTA della MISSIONE.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
            '            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '        End If
            '    End If
            'End If

            JobsActivateExecution = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            JobsActivateExecution = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function SetJobCarrellistaEsecuzioneMissione(ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : IMPOSTA IL CARRELLISTA CHE ESEGUE LA MISSIONE
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim IdCarrellistaEsecuzione As String = ""
        Dim IdCarrellistaEsecuzioneFullPallet As String = ""
        Dim IdCarrellistaEsecuzioneSfusi As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            SetJobCarrellistaEsecuzioneMissione = 1 'init at error


            'IMPOSTO L'ORARIO DI START DELLA MISSIONE
            RetCode += ActionInfo.ActionStart()

            '>>> CASO GENERICO  ( IMPOSTO IL NONE DEL CARRELLISTA BASE )
            IdCarrellistaEsecuzione = clsUser.SapWmsUser.ZCARR

            '*******************************************************************************************************
            '>>> SE ATTIVA LA GESTIONE DELLE TASK LINES ALLORA DEVO CALCOLARE LA QTA IN BASE AL TASK ATTIVO 
            '*******************************************************************************************************
            If (TaskLines.TaskLinesInfo.NrWmsJobs > 0) And (clsUtility.IsStringValid(TaskLines.TaskLinesOnWork.NrTaskLines, True) = True) Then
                'CASO DI UN TASK ATTIVO DEVO GESTIRE IL CASO DI PRELIEVO FULL/PARZIALE/SFUSI
                If (TaskLines.TaskLinesOnWork.PickFullPartialType = clsTaskLines.cstTaskLinesPickType_FullPallet) Then
                    IdCarrellistaEsecuzione = ""
                    IdCarrellistaEsecuzioneFullPallet = clsUser.SapWmsUser.ZCARR
                    IdCarrellistaEsecuzioneSfusi = ""
                ElseIf (TaskLines.TaskLinesOnWork.PickFullPartialType = clsTaskLines.cstTaskLinesPickType_PartialPallet) Then
                    IdCarrellistaEsecuzione = clsUser.SapWmsUser.ZCARR
                    IdCarrellistaEsecuzioneFullPallet = ""
                    IdCarrellistaEsecuzioneSfusi = ""
                ElseIf (TaskLines.TaskLinesOnWork.PickFullPartialType = clsTaskLines.cstTaskLinesPickType_PickPieces) Then
                    IdCarrellistaEsecuzione = ""
                    IdCarrellistaEsecuzioneFullPallet = ""
                    IdCarrellistaEsecuzioneSfusi = clsUser.SapWmsUser.ZCARR
                End If
            End If

            'SE ARRIVO QUI POSSO IMPOSTARE IL CARRELLISTA SE NON ERA IMPOSTATO
            If (clsUtility.IsStringValid(WmsJob.IdCarrellistaEsecuzione, True) = False) And (WmsJob.IdWmsJobStatus < clsWmsJob.cstIdJobStatus_Sospeso) Then
                '>>> IMPOSTO IL CARRELLISTA
                RetCode = SetJobCarrellista(WmsJob.NrWmsJobs, "", IdCarrellistaEsecuzione, IdCarrellistaEsecuzioneFullPallet, IdCarrellistaEsecuzioneSfusi, True)
                If (RetCode <> 0) Then
                    RetCode = 820
                    SetJobCarrellistaEsecuzioneMissione = RetCode
                    If (inShowMessageBox = True) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1045, "", "Attenzione, errore in scrittura CARRELLISTA della MISSIONE.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If
                End If
            End If

            SetJobCarrellistaEsecuzioneMissione = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            SetJobCarrellistaEsecuzioneMissione = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ShowJobsCheckMaterialWarning(ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : ritorna un DATASET con un ELENCO DI JOBSGROUPS
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ShowJobsCheckMaterialWarning = 1 'init at error

            If (WmsJob.IdWmsJobType = cstIdJobType_CheckMaterial) Then
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(445, "", "Attenzione!") & clsAppTranslation.GetSingleParameterValue(1046, "", "Questa è una missione di SOLA VERIFICA della presenza del materiale.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1047, "", "Nessuno spostamento fisico e logico deve essere eseguito.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
            End If

            ShowJobsCheckMaterialWarning = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ShowJobsCheckMaterialWarning = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetJobPickingBestDestination(ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : ritorna un DATASET con un ELENCO DI JOBSGROUPS
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim GetDataOk As Boolean = False
        Dim QtaRimastaDaPrelevare As Double
        Dim WorkUbicazione As clsDataType.SapWmUbicazione
        Dim GetPickDestLocationOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetJobPickingBestDestination = 1 'init at error


            If (WmsJob.NrWmsJobs <= 0) Then
                RetCode = 10
                GetJobPickingBestDestination = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1028, "", "Attenzione, Numero JOBS non valido.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            If (WmsJob.IdWmsJobStatus >= cstIdJobStatus_Verificato) Then
                RetCode = 20
                GetJobPickingBestDestination = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1029, "", "Attenzione, STATO JOBS già TERMINATO.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If
            If (WmsJob.IdWmsJobStatus = cstIdJobStatus_Sospeso) Then
                RetCode = 21
                GetJobPickingBestDestination = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1030, "", "Attenzione, STATO JOBS in SOSPESO.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If
            If (WmsJob.IdWmsJobStatus = cstIdJobStatus_Cancellato) Then
                RetCode = 22
                GetJobPickingBestDestination = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1031, "", "Attenzione, STATO JOBS in CANCELLATO.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If
            If (WmsJob.IdWmsJobStatus < cstIdJobStatus_Pianificato) Then
                RetCode = 23
                GetJobPickingBestDestination = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1032, "", "Attenzione, STATO JOBS non PIANIFICATO.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If



            '>>> CASO DI USCITA MERCI (A) / ENTRATA MERCE (E)
            If (WmsJob.FlagRilevanteWM = "W") And (WmsJob.TipoDirezioneMissioneKZEAR = "A") Then
                '******************************************************************
                '>>> OTTENGO LE INFO SUL POSTO OTTIMALE DI PRELIEVO DELLA MERCE
                '******************************************************************

                'CALCOLO LA QTA RESIDUA DELLA MISSIONE
                QtaRimastaDaPrelevare = WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDaPrelUdMAcq - WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna

                'VERIFICARE SE HO PRELEVATO TUTTA LA QTA
                If (QtaRimastaDaPrelevare <= 0) Then
                    RetCode = 90
                    GetJobPickingBestDestination = RetCode
                    If (inShowMessageBox = True) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(418, "", "Attenzione! Nessuna QTA da prelevare. QTA Da Prelevare:") & WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDaPrelUdMAcq & clsAppTranslation.GetSingleParameterValue(419, "", " Qta Prelevata:") & WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If
                    Exit Function
                End If
                '>>> CASO DI USCITA MERCI (A)
                FlagOutDestFoundAreaPD = False
                RetCode += clsSapWS.Call_ZWS_MB_GET_WM_OUT_DEST_BASIC(WmsJob.MaterialeGiacenzaOrigine, WmsJob, WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore, WorkUbicazione, GetPickDestLocationOk, MaterialePickDestinations, DescrUbicDestPick, FlagOutDestFoundAreaPD, SapFunctionError, inShowMessageBox)
                If (GetPickDestLocationOk = False) Then
                    RetCode = 100
                    GetJobPickingBestDestination = RetCode
                    If (inShowMessageBox = True) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(693, "", "Attenzione, errore in ricerca materiale da prelevare.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If
                    Exit Function
                End If
                'VERIFICO IN CHE VIDEATA DEVO ANDARE PRINCIPALMENTE IN BASE AL TIPO MAGAZZINO 
                RetCode = GetCurrentPickingMerciDestinationType()

            ElseIf (WmsJob.FlagRilevanteWM = "W") And (WmsJob.TipoDirezioneMissioneKZEAR = "E") Then
                '>>> CASO DI ENTRATA MERCE (E)

                '******************************************************************
                '>>> OTTENGO LE INFO SUL POSTO OTTIMALE DI DEPOSITO DELLA MERCE
                '******************************************************************

                'CALCOLO LA QTA RESIDUA DELLA MISSIONE
                QtaRimastaDaPrelevare = WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDaPrelUdMAcq - WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna

                'VERIFICARE SE HO PRELEVATO TUTTA LA QTA PREVISTA DALLA MISSIONE
                If (QtaRimastaDaPrelevare <= 0) Then
                    RetCode = 90
                    GetJobPickingBestDestination = RetCode
                    If (inShowMessageBox = True) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(418, "", "Attenzione! Nessuna QTA da prelevare. QTA Da Prelevare:") & WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDaPrelUdMAcq & clsAppTranslation.GetSingleParameterValue(419, "", " Qta Prelevata:") & WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If
                    Exit Function
                End If

                '>>> CASO DI ENTRATA MERCI (A)
                RetCode += clsSapWS.Call_ZWS_MB_GET_WM_INPUT_DEST_BASIC(WmsJob.MaterialeGiacenzaOrigine, WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo, WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore, WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione, WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataSfusiOperatore, Nothing, False, GetPickDestLocationOk, MaterialePickDestinations, DescrUbicDestPick, SapFunctionError, inShowMessageBox)
                If (GetPickDestLocationOk = False) Then
                    RetCode = 100
                    GetJobPickingBestDestination = RetCode
                    If (inShowMessageBox = True) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(693, "", "Attenzione, errore in ricerca materiale da prelevare.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If
                    Exit Function
                End If
                'VERIFICO IN CHE VIDEATA DEVO ANDARE PRINCIPALMENTE IN BASE AL TIPO MAGAZZINO 
                RetCode = GetCurrentPickingMerciDestinationType()

            End If


            GetJobPickingBestDestination = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetJobPickingBestDestination = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetJobPickingCodeBestDestination(ByVal inCheckForDropExecution As Boolean, ByVal inShowMessageBox As Boolean) As Long
        ' **********************************************************************************
        ' DESCRIZIONE : ritorna la migliore destinazione dei JOB legati alle WORK QUEUE
        ' **********************************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim GetDataOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetJobPickingCodeBestDestination = 1 'init at error


            If (WmsJob.NrWmsJobs <= 0) Then
                RetCode = 10
                GetJobPickingCodeBestDestination = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1028, "", "Attenzione, Numero JOBS non valido.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If


            '>>> NEL CASO DELL'OPERAZIONE DI DROP DEVO PERMETTERE DI FARLO ANCHE SE IL JOB E' TERMINATO A CAUSA DI UNO ZERO PICK
            If (WmsJob.IdWmsJobStatus >= cstIdJobStatus_Verificato) And (inCheckForDropExecution = False) Then
                RetCode = 20
                GetJobPickingCodeBestDestination = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1029, "", "Attenzione, STATO JOBS già TERMINATO.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If
            If (WmsJob.IdWmsJobStatus = cstIdJobStatus_Sospeso) And (inCheckForDropExecution = False) Then
                RetCode = 21
                GetJobPickingCodeBestDestination = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1030, "", "Attenzione, STATO JOBS in SOSPESO.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If
            If (WmsJob.IdWmsJobStatus = cstIdJobStatus_Cancellato) Then
                RetCode = 22
                GetJobPickingCodeBestDestination = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1031, "", "Attenzione, STATO JOBS in CANCELLATO.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If
            If (WmsJob.IdWmsJobStatus < cstIdJobStatus_Pianificato) Then
                RetCode = 23
                GetJobPickingCodeBestDestination = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1032, "", "Attenzione, STATO JOBS non PIANIFICATO.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If


            '>>> CASO DI USCITA MERCI (A)
            FlagOutDestFoundAreaPD = False
            RetCode = clsSapUtility.ResetUbicazioneStruct(UbicazionePDPickingCodeDestinatione)
            RetCode += clsSapWS.Call_ZWM_MB_GET_DEST_PD_FROM_LOC(UbicazioneUltimoPickingCodeOrigine, WmsJob, FlagOutDestFoundAreaPD, UbicazionePDPickingCodeDestinatione, SapFunctionError, inShowMessageBox)


            GetJobPickingCodeBestDestination = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetJobPickingCodeBestDestination = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetJobsGroupsList(ByVal inJobTypeFamily As String, ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : ritorna un DATASET con un ELENCO DI JOBSGROUPS
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim GetDataOk As Boolean = False
        Dim WorkDivisione As String = ""
        Dim WorkNumeroMagazzino As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetJobsGroupsList = 1 'init at error

            clsWmsJob.ClearAllData() '>>> init

            WorkDivisione = clsUser.GetUserDivisionToUse() '>>> RITORNO LA DIVISIONE DA USARE
            WorkNumeroMagazzino = clsUser.GetUserNumeroMagazzinoToUse() '>>> RITORNO IL NUMERO MAGAZZINO DA USARE
            RetCode += clsSapWS.Call_ZWS_GET_JOBS_GROUP_LIST(WorkDivisione, WorkNumeroMagazzino, inJobTypeFamily, clsUser.SapWmsUser.ZCARR, clsUser.SapWmsUser.ZCARR, clsUser.SapWmsUser.USERID, True, clsUser.SapWmsUser.LANGUAGE, GetDataOk, clsWmsJobsGroup.objDataTableWmsJobGroupList, SapFunctionError, False)
            If (GetDataOk = False) Then
                RetCode = 200
                GetJobsGroupsList = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(962, "", "Attenzione, errore in estrazione dati JOBS GROUP.") & vbCrLf & "DIVISIONE:" & WorkDivisione
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If
            If (clsWmsJobsGroup.GetRowCountWmsJobGroupList(inShowMessageBox) <= 0) Then
                RetCode = 0
                GetJobsGroupsList = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1048, "", "Attenzione, nessun GRUPPO MISSIONI trovato.") & vbCrLf & "DIVISIONE:" & WorkDivisione
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            GetJobsGroupsList = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetJobsGroupsList = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetJobSingleDisaccantonamento(ByVal inZnrWmsJobs As String, ByVal inShowMessageBox As Boolean) As Long
        ' ****************************************************************************
        ' DESCRIZIONE : ritorna un DATASET con un ELENCO DI JOBS DI DISACCANTONAMENTO
        ' ****************************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim MemoSapJobsGroupInfo As clsDataType.SapJobsGroupInfo
        Dim MemoDisaccantonamentoSourceType As Disaccantonamento_SourceType
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetJobSingleDisaccantonamento = 1 'init at error

            MemoSapJobsGroupInfo = clsWmsJobsGroup.WmsJobsGroupInfo 'SALVO DATI PERCHE' LA [GetJobsList] LI CANCELLA
            MemoDisaccantonamentoSourceType = DisaccantonamentoSourceType

            'ESEGUO REFRESH DATI DEL JOB CORRENTE
            RetCode = clsWmsJob.GetJobSingle(inZnrWmsJobs, Nothing, Nothing, Nothing, Nothing, False, inShowMessageBox, False, False)

            clsWmsJobsGroup.WmsJobsGroupInfo = MemoSapJobsGroupInfo
            DisaccantonamentoSourceType = MemoDisaccantonamentoSourceType

            GetJobSingleDisaccantonamento = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetJobSingleDisaccantonamento = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetJobsDisaccantonamentoList(ByVal inShowOnlyActive As Boolean, ByVal inAccorpaMatnr_Charg As Boolean, ByVal inShowMessageBox As Boolean) As Long
        ' ****************************************************************************
        ' DESCRIZIONE : ritorna un DATASET con un ELENCO DI JOBS DI DISACCANTONAMENTO
        ' ****************************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim wkSapWmWmsJob As clsDataType.SapWmWmsJob
        Dim MemoSapJobsGroupInfo As clsDataType.SapJobsGroupInfo
        Dim MemoDisaccantonamentoSourceType As Disaccantonamento_SourceType
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetJobsDisaccantonamentoList = 1 'init at error

            'LEGGO IL DATASET DA VISUALIZZARE
            wkSapWmWmsJob.IdWmsJobType = "30*" '>>> FILTRO LA 300 e la 301
            wkSapWmWmsJob.IdCarrellistaProposto = clsUser.SapWmsUser.ZCARR
            wkSapWmWmsJob.IdCarrellistaEsecuzione = clsUser.SapWmsUser.ZCARR

            'SE HO SPECIFICATO IL JOBS GROUP (CON BARCODE) LO FILTRO PER VEDERE SOLO I JOB DI QUESTO GRUPPO
            MemoSapJobsGroupInfo = clsWmsJobsGroup.WmsJobsGroupInfo 'SALVO DATI PERCHE' LA [GetJobsList] LI CANCELLA
            MemoDisaccantonamentoSourceType = DisaccantonamentoSourceType
            If (DisaccantonamentoSourceType = Disaccantonamento_SourceType.Disaccantonamento_SourceTypeJobsGroup) Then
                wkSapWmWmsJob.CodiceGruppoMissioni = clsWmsJobsGroup.WmsJobsGroupInfo.NumeroJobsGroup
            End If
            RetCode += clsWmsJob.GetJobsList(wkSapWmWmsJob, inShowOnlyActive, inAccorpaMatnr_Charg, inShowMessageBox)
            clsWmsJobsGroup.WmsJobsGroupInfo = MemoSapJobsGroupInfo
            DisaccantonamentoSourceType = MemoDisaccantonamentoSourceType

            GetJobsDisaccantonamentoList = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetJobsDisaccantonamentoList = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetJobsList(ByVal inFilterSapWmWmsJob As clsDataType.SapWmWmsJob, ByVal inShowOnlyActive As Boolean, ByVal inAccorpaMatnr_Charg As Boolean, ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : ritorna un DATASET con un ELENCO DI JOBSGROUPS
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim GetDataOk As Boolean = False
        Dim WorkDivisione As String = ""
        Dim WorkNumeroMagazzino As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetJobsList = 1 'init at error

            clsWmsJob.ClearAllData() '>>> init

            WorkDivisione = clsUser.GetUserDivisionToUse() '>>> RITORNO LA DIVISIONE DA USARE
            WorkNumeroMagazzino = clsUser.GetUserNumeroMagazzinoToUse() '>>> RITORNO IL NUMERO MAGAZZINO DA USARE

            RetCode += clsSapWS.Call_ZWS_GET_JOBS_LIST(WorkDivisione, WorkNumeroMagazzino, Nothing, inFilterSapWmWmsJob, inShowOnlyActive, inAccorpaMatnr_Charg, clsUser.SapWmsUser.LANGUAGE, GetDataOk, clsWmsJob.objDataTableWmsJobsList, SapFunctionError, inShowMessageBox)
            If (RetCode <> 0) Or (GetDataOk = False) Then
                RetCode = 200
                GetJobsList = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1049, "", "Attenzione, errore in estrazione dati JOBS LIST.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If
            If (clsWmsJob.objDataTableWmsJobsList.Rows.Count <= 0) Then
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(445, "", "Attenzione!") & " " & clsAppTranslation.GetSingleParameterValue(478, "", "Nessun dato trovato") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1050, "", "Verificare la condizione e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            GetJobsList = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetJobsList = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetJobSingle(ByVal inZnrWmsJobs As String, ByVal inNumeroConsegna As String, ByVal inPosizioneConsegna As String, ByVal inNumeroOrdPicking As String, ByVal inPosizioneOrdPicking As String, ByVal inGetTaskLines As Boolean, ByVal inShowMessageBox As Boolean, ByRef inUpdateDataTable As Boolean, ByVal inNoClear As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : ritorna un DATASET con un ELENCO DI JOBSGROUPS
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim GetDataOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetJobSingle = 1 'init at error

            If (inNoClear = False) Then
                clsWmsJob.ClearAllData() '>>> init
            End If
            If (inUpdateDataTable = True) Then
                RetCode += clsSapWS.Call_ZWS_GET_JOBS_SINGLE(inZnrWmsJobs, inNumeroConsegna, inPosizioneConsegna, inNumeroOrdPicking, inPosizioneOrdPicking, inGetTaskLines, clsUser.SapWmsUser.LANGUAGE, GetDataOk, objDataTableWmsJobsList, WmsJob, Nothing, Nothing, SapFunctionError, inShowMessageBox)
            Else
                RetCode += clsSapWS.Call_ZWS_GET_JOBS_SINGLE(inZnrWmsJobs, inNumeroConsegna, inPosizioneConsegna, inNumeroOrdPicking, inPosizioneOrdPicking, inGetTaskLines, clsUser.SapWmsUser.LANGUAGE, GetDataOk, Nothing, WmsJob, Nothing, Nothing, SapFunctionError, inShowMessageBox)
            End If
            If (GetDataOk = False) Then
                RetCode = 200
                GetJobSingle = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1049, "", "Attenzione, errore in estrazione dati JOBS LIST.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            GetJobSingle = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetJobSingle = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetJobCodaPerRefresh(ByVal inFilterSapWmWmsJob As clsDataType.SapWmWmsJob, ByVal inShowMessageBox As Boolean, ByVal inNoClear As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : ritorna un DATASET con un ELENCO DI JOBSGROUPS
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim GetDataOk As Boolean = False
        Dim JobIdList() As String
        Dim WorkJobIdStatus As Long = 0
        Dim NumJobIdList As Long = 0
        Dim WorkJobIdNum As String = ""
        Dim WorkDataTableWmsJobsListRefreshed As DataTable
        Dim WorkDataRowCollection() As DataRow
        Dim WorkOriginalDataRowCollection() As DataRow
        Dim WorkDataRow As DataRow
        Dim WorkOriginalDataRow As DataRow
        Dim LoopIndex As Long = 0
        Dim IndexRowToUpdate As Long = 0
        Dim IndexFiled As Integer = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetJobCodaPerRefresh = 1 'init at error

            If (inNoClear = False) Then
                clsWmsJob.ClearAllData() '>>> init
            End If

            If (clsWmsJob.objDataTableWmsJobsList Is Nothing) Then
                GetJobCodaPerRefresh = RetCode
                Exit Function
            End If

            If (clsWmsJob.objDataTableWmsJobsList.Rows Is Nothing) Then
                GetJobCodaPerRefresh = RetCode
                Exit Function
            End If

            NumJobIdList = -1
            For Each WorkDataRow In clsWmsJob.objDataTableWmsJobsList.Rows
                If (WorkDataRow Is Nothing) Then
                    Continue For
                End If
                WorkJobIdStatus = clsUtility.GetDataRowItem(WorkDataRow, "IDSTATUS", "0", False)
                WorkJobIdNum = clsUtility.GetDataRowItem(WorkDataRow, "ZNR_WMS_JOBS", "", False)
                If (WorkJobIdStatus = cstIdJobStatus_Terminato) Or (WorkJobIdNum = "") Then
                    Continue For
                End If
                NumJobIdList = NumJobIdList + 1
                ReDim Preserve JobIdList(NumJobIdList)
                JobIdList(NumJobIdList) = WorkJobIdNum
            Next

            If (JobIdList Is Nothing) Then
                GetJobCodaPerRefresh = RetCode
                Exit Function
            End If

            If (JobIdList.Count <= 0) Then
                GetJobCodaPerRefresh = RetCode
                Exit Function
            End If

            'DATA TABLE DI APPOGGIO CHE VIENE RINFRESCATO
            WorkDataTableWmsJobsListRefreshed = clsWmsJob.objDataTableWmsJobsList.Clone

            RetCode += clsSapWS.Call_ZWS_GET_JOBS_LIST(clsUser.GetUserDivisionToUse, clsUser.GetUserNumeroMagazzinoToUse, JobIdList, inFilterSapWmWmsJob, False, False, clsUser.SapWmsUser.LANGUAGE, GetDataOk, WorkDataTableWmsJobsListRefreshed, SapFunctionError, inShowMessageBox)
            If (RetCode <> 0) Or (GetDataOk = False) Then
                RetCode = 200
                GetJobCodaPerRefresh = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1049, "", "Attenzione, errore in estrazione dati JOBS LIST.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If
            If (WorkDataTableWmsJobsListRefreshed.Rows.Count <= 0) Then
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(445, "", "Attenzione!") & " " & clsAppTranslation.GetSingleParameterValue(478, "", "Nessun dato trovato") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1050, "", "Verificare la condizione e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            Dim WorkSelectFilter As String = ""
            'RINFRESCO IL DATA TABLE ORIGINALE DEI JOB RILETTI CON LA FUNZIONE
            For LoopIndex = 0 To (JobIdList.Count - 1)
                If (JobIdList(LoopIndex) = "") Then
                    Continue For
                End If
                WorkSelectFilter = "ZNR_WMS_JOBS = " & JobIdList(LoopIndex)
                WorkDataRowCollection = WorkDataTableWmsJobsListRefreshed.Select(WorkSelectFilter)
                If (WorkDataRowCollection Is Nothing) Then
                    Continue For
                End If
                WorkDataRow = WorkDataRowCollection(0)

                WorkOriginalDataRowCollection = objDataTableWmsJobsList.Select(WorkSelectFilter)
                If (WorkOriginalDataRowCollection Is Nothing) Then
                    Continue For
                End If

                WorkOriginalDataRow = WorkOriginalDataRowCollection(0)

                IndexRowToUpdate = objDataTableWmsJobsList.Rows.IndexOf(WorkOriginalDataRow)

                For IndexFiled = 0 To (objDataTableWmsJobsList.Columns.Count - 1)
                    objDataTableWmsJobsList.Rows(IndexRowToUpdate).Item(IndexFiled) = WorkDataRow.Item(IndexFiled)
                Next
            Next

            GetJobCodaPerRefresh = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetJobCodaPerRefresh = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetIndexDataRowJobOfTaskListOnWor(ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : ritorna un DATASET con un ELENCO DI JOBSGROUPS
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        Dim WorkDataRow As DataRow
        Dim IndexDataRow As Long
        Dim WorkZNR_WMS_JOBS As String
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetIndexDataRowJobOfTaskListOnWor = -1 'init at error

            If (objDataTableWmsJobsList Is Nothing) Then
                Exit Function
            End If
            If (objDataTableWmsJobsList.Rows Is Nothing) Then
                Exit Function
            End If
            If (objDataTableWmsJobsList.Rows.Count <= 0) Then
                Exit Function
            End If

            If (clsUtility.IsStringValid(TaskLines.TaskLinesOnWork.NrWmsJobs, True) = False) Then
                Exit Function
            End If

            IndexDataRow = -1
            For Each WorkDataRow In objDataTableWmsJobsList.Rows
                IndexDataRow = IndexDataRow + 1
                WorkZNR_WMS_JOBS = clsUtility.GetDataRowItem(WorkDataRow, "ZNR_WMS_JOBS", "")
                If (WorkZNR_WMS_JOBS = TaskLines.TaskLinesOnWork.NrWmsJobs) Then
                    GetIndexDataRowJobOfTaskListOnWor = IndexDataRow
                    Exit Function
                End If
            Next

            GetIndexDataRowJobOfTaskListOnWor = -1

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetIndexDataRowJobOfTaskListOnWor = -1 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function IsFirstJobConfirmed() As Boolean
        ' ****************************************************************************
        ' DESCRIZIONE : ritorna l'elenco dei JOBS di cui fare l'OT automaticamente
        ' ****************************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim WorkDataRow As DataRow
        Dim IdWmsJobType As String = ""
        Dim NrWmsJobs As String = ""
        Dim WorkWmsJob As clsDataType.SapWmWmsJob
        Dim WorkFoundMissioneIniziata As Boolean = False

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            IsFirstJobConfirmed = False 'init at not FIRST

            For Each WorkDataRow In clsWmsJob.objDataTableWmsJobsList.Rows()
                IdWmsJobType = clsUtility.GetDataRowItem(WorkDataRow, "ID_JOBS_TYPE", "")
                NrWmsJobs = clsUtility.GetDataRowItem(WorkDataRow, "ZNR_WMS_JOBS", "")
                If (clsUtility.IsStringValid(IdWmsJobType, True) = True) And (clsUtility.IsStringValid(NrWmsJobs, True) = True) Then
                    '>>> SE E' UN JOB DEL TIPO FILTRATO VERIFICO RECUPERO TUTTI I SUOI CAMPI
                    RetCode = clsWmsJob.FromDataRowToWmsJobsInfoStruct(WorkDataRow, WorkWmsJob, False)
                    If (RetCode = 0) Then
                        '>>> CONSIDERO SOLO MISSIONI ATTIVE PER IL WM
                        If (WorkWmsJob.FlagRilevanteWM = "W") And (WorkWmsJob.IdWmsJobStatus >= cstIdJobStatus_Iniziato) And (WorkWmsJob.IdWmsJobStatus <> cstIdJobStatus_Sospeso) And (WorkWmsJob.IdWmsJobStatus <> cstIdJobStatus_Cancellato) Then
                            WorkFoundMissioneIniziata = True
                            Exit For
                        End If
                    End If
                End If
            Next

            If (WorkFoundMissioneIniziata = False) Then
                'SOLO SE NON HO NESSUNA MISSIONE INIZIATA SETTO IL FLAG
                IsFirstJobConfirmed = True
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            IsFirstJobConfirmed = False  'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetDataTableJobsTypeNotEndedForAutoTransfer(ByVal inJobTypeFilter As String, ByVal inShowMessageBox As Boolean) As Long
        ' ****************************************************************************
        ' DESCRIZIONE : ritorna l'elenco dei JOBS di cui fare l'OT automaticamente
        ' ****************************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim WorkDataRow As DataRow
        Dim IdWmsJobType As String = ""
        Dim NrWmsJobs As String = ""
        Dim WorkWmsJob As clsDataType.SapWmWmsJob
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetDataTableJobsTypeNotEndedForAutoTransfer = 0 'init at error

            If (objDataTableWmsJobsList Is Nothing) Then
                Exit Function
            End If
            If (objDataTableWmsJobsList.Rows.Count = 0) Then
                Exit Function
            End If

            'RESETTO DATA TABLE CON JOBS PER TRASFERIMENTI AUTOMATICI
            RetCode = ClearWmsJobsAutoTransferList()

            'IMPOSTO LA STRUTTURA DEI JOBS DA TRASFERIRE AUTOMATICAMENTE
            objDataTableWmsJobsAutoTransferList = objDataTableWmsJobsList.Clone()

            For Each WorkDataRow In clsWmsJob.objDataTableWmsJobsList.Rows()
                IdWmsJobType = clsUtility.GetDataRowItem(WorkDataRow, "ID_JOBS_TYPE", "")
                NrWmsJobs = clsUtility.GetDataRowItem(WorkDataRow, "ZNR_WMS_JOBS", "")
                If (inJobTypeFilter = IdWmsJobType) And (NrWmsJobs <> WmsJob.NrWmsJobs) Then
                    '>>> SE E' UN JOB DEL TIPO FILTRATO VERIFICO RECUPERO TUTTI I SUOI CAMPI
                    RetCode = clsWmsJob.FromDataRowToWmsJobsInfoStruct(WorkDataRow, WorkWmsJob, False)
                    If (RetCode = 0) Then
                        '>>> CONSIDERO SOLO MISSIONI ATTIVE PER IL WM
                        If (WorkWmsJob.FlagRilevanteWM = "W") And (WorkWmsJob.CurrentStep > 1) And (WorkWmsJob.IdWmsJobStatus >= cstIdJobStatus_Iniziato) And (WorkWmsJob.IdWmsJobStatus < cstIdJobStatus_Sospeso) Then
                            objDataTableWmsJobsAutoTransferList.ImportRow(WorkDataRow)
                        End If
                    End If
                End If
            Next

            '>>> RITORNO IL NUMERO DI MISSIONI CON DECORI TROVATE
            GetDataTableJobsTypeNotEndedForAutoTransfer = GetNumRecDataTableWmsJobsAutoTransfer()


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetDataTableJobsTypeNotEndedForAutoTransfer = 0 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ReloadDataOfSameJobForNewPick(ByRef inSourceForm As Form, ByRef outExitFormDone As Boolean, ByVal inEnableChangeForm As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE :
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim ErrDescription As String
        Dim UserAnswer As DialogResult
        Dim MemoNrWmsJobs As Long
        Dim wkJobsOkForExecution As Boolean
        Dim OkFineLetturaDati As Boolean = False
        Dim NumTentativiLetturaDati As Long = 0
        Dim ExecutionOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ReloadDataOfSameJobForNewPick = 1 'init at error

            '>>> ESEGUO RESET STRUTTURA SAP PER SELEZIONE  UBICAZIONE FORZATA SELEZIONATA DA OPERATORE 
            RetCode = clsSapUtility.ResetUbicazioneStruct(StockSelezionatoUtente)

            'SALVO CHIAVE JOB CORRENTE
            MemoNrWmsJobs = clsWmsJob.WmsJob.NrWmsJobs

            'RECUPERO TUTTI I DATI DEL JOBGROUP (PER EVITARE PROBLEMI DI COMUNICAZIONE CI PROVO "N" VOLTE)
            OkFineLetturaDati = False
            NumTentativiLetturaDati = 0
            Do Until OkFineLetturaDati
                RetCode = clsWmsJobsGroup.GetJobsGroupSingle(clsWmsJob.WmsJob.CodiceGruppoMissioni, Nothing, Nothing, ExecutionOk, False)
                If (RetCode = 0) Or (NumTentativiLetturaDati > 3) Then
                    OkFineLetturaDati = True
                Else
                    NumTentativiLetturaDati = NumTentativiLetturaDati + 1
                End If
            Loop
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1051, "", "Attenzione! Errore in lettura dati JOBGROUP")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                If (inEnableChangeForm = True) Then
                    'CASO DI ERRORE => TORNO AL MENU DI ENTRATA MERCI
                    RetCode = clsNavigation.Show_Mnu_Main_UscitaMerci(inSourceForm, True)
                    outExitFormDone = True
                End If
                Exit Function
            End If

            'ESEGUO REFRESH DATI DEL JOB CORRENTE
            RetCode = clsWmsJob.RefreshJobsSingleStruct(MemoNrWmsJobs, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(398, "", "Attenzione! Errore in lettura dati JOB")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                If (inEnableChangeForm = True) Then
                    'CASO DI ERRORE => TORNO AL MENU DI ENTRATA MERCI
                    RetCode = clsNavigation.Show_Mnu_Main_UscitaMerci(inSourceForm, True)
                    outExitFormDone = True
                End If
                Exit Function
            End If

            'VERIFICO SE IL JOB E' OK PER UNA NUOVA ESECUZIONE
            wkJobsOkForExecution = clsWmsJob.IsJobsOkForExecution(True)
            If (wkJobsOkForExecution = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(399, "", "Missione non OK per esecuziome. MIS:") & clsWmsJob.WmsJob.NrWmsJobs & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

            ReloadDataOfSameJobForNewPick = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ReloadDataOfSameJobForNewPick = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function SetJobCarrellista(ByVal inZnrWmsJobs As String, ByVal inIdCarrellistaProposto As String, ByVal inIdCarrellistaEsecuzione As String, ByVal inIdCarrellistaEsecuzioneFullPallet As String, ByVal inIdCarrellistaEsecuzioneSfusi As String, ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : ritorna un DATASET con un ELENCO DI JOBSGROUPS
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim SetDataOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            SetJobCarrellista = 1 'init at error

            RetCode += clsSapWS.Call_ZWS_SET_JOB_CARRELLISTA(inZnrWmsJobs, inIdCarrellistaProposto, inIdCarrellistaEsecuzione, inIdCarrellistaEsecuzioneFullPallet, inIdCarrellistaEsecuzioneSfusi, clsUser.SapWmsUser.LANGUAGE, SetDataOk, Nothing, Nothing, SapFunctionError, inShowMessageBox)
            If (SetDataOk = False) Then
                RetCode = 200
                SetJobCarrellista = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1052, "", "Attenzione, errore in scrittura CARRELLISTA del JOBS.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            SetJobCarrellista = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            SetJobCarrellista = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetRowCountWmsJobsList(ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        GetRowCountWmsJobsList = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Not (objDataTableWmsJobsList Is Nothing)) Then
                GetRowCountWmsJobsList = objDataTableWmsJobsList.Rows.Count
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetRowCountWmsJobsList = 0 'CATCH ERROR
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetRowCountGiacenzeOriInfo(ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        GetRowCountGiacenzeOriInfo = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Not (objDataTableGiacenzeOriInfo Is Nothing)) Then
                GetRowCountGiacenzeOriInfo = objDataTableGiacenzeOriInfo.Rows.Count
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetRowCountGiacenzeOriInfo = 0 'CATCH ERROR
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetRowCountGiacenzeDestInfo(ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        GetRowCountGiacenzeDestInfo = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Not (objDataTableGiacenzeDestInfo Is Nothing)) Then
                GetRowCountGiacenzeDestInfo = objDataTableGiacenzeDestInfo.Rows.Count
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetRowCountGiacenzeDestInfo = 0 'CATCH ERROR
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetUdcProcessedInfoForUser() As String
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************
        Dim NumUdcPrelevati As Long
        Dim NumUdcDaPrelevare As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        GetUdcProcessedInfoForUser = "0"
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDaPrelUdMAcq <= 0) Then
                Exit Function
            End If

            If (WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet <= 0) Then
                Exit Function
            End If

            NumUdcPrelevati = Math.Ceiling(WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna / WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet)
            NumUdcDaPrelevare = Math.Ceiling(WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDaPrelUdMAcq / WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet)

            If NumUdcDaPrelevare > 1 Then
                GetUdcProcessedInfoForUser = Trim(Str(NumUdcPrelevati + 1)) & " / " & Trim(Str(NumUdcDaPrelevare))
            Else
                GetUdcProcessedInfoForUser = Trim(Str(NumUdcPrelevati)) & " / " & Trim(Str(NumUdcDaPrelevare))
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetUdcProcessedInfoForUser = "" 'CATCH ERROR
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function SetJobPickMaterialGiacenzaOri(ByVal inShowMessageBox As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkQtaProposta As Double = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            SetJobPickMaterialGiacenzaOri = 1

            If ((IsPickingLogicJobs(True) = True) Or (IsPickingCheckOnlyPresenceJobs(True) = True)) Then
                WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDisponibile = WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaInUdmOriginale
                WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDispoUdMAcq = WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaInUdmOriginale
                '>>> CASO DI PRELIEVO LOGICO
                RetCode = GetJobPickOriQtyProposal(WorkQtaProposta, Nothing)
                If (RetCode = 0) Then
                    WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore = WorkQtaProposta
                End If
            Else
                '>>> CASO NORMALE DI PRELIEVO PER WM
                WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo = clsWmsJob.MaterialeSelStockGiacenzaOri.UbicazioneInfo
                WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDisponibile = clsWmsJob.MaterialeSelStockGiacenzaOri.QtaTotaleLquaDisponibile
                WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDispoUdMAcq = clsWmsJob.MaterialeSelStockGiacenzaOri.QtaTotaleLquaDispoUdMAcq
                WmsJob.MaterialeGiacenzaOrigine.QtaTotaleDispoInUdmPZ = clsWmsJob.MaterialeSelStockGiacenzaOri.QtaTotaleDispoInUdmPZ
                WmsJob.MaterialeGiacenzaOrigine.QtaTotaleInStockInUdmPZ = clsWmsJob.MaterialeSelStockGiacenzaOri.QtaTotaleInStockInUdmPZ
                WmsJob.MaterialeGiacenzaOrigine.QtaTotaleDispoSfusi = clsWmsJob.MaterialeSelStockGiacenzaOri.QtaTotaleDispoSfusi
                WmsJob.MaterialeGiacenzaOrigine.QtaTotaleInStockSfusi = clsWmsJob.MaterialeSelStockGiacenzaOri.QtaTotaleInStockSfusi
                RetCode = GetJobPickOriQtyProposal(WorkQtaProposta, Nothing)
                If (RetCode = 0) Then
                    WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore = WorkQtaProposta
                End If

                If (clsUtility.IsStringValid(WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraBase, True) = False) Then
                    WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraBase = clsWmsJob.MaterialeSelStockGiacenzaOri.UnitaDiMisuraBase
                End If
                If (clsUtility.IsStringValid(WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione, True) = False) Then
                    WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione = clsWmsJob.MaterialeSelStockGiacenzaOri.UnitaDiMisuraAcquisizione
                End If
            End If


            SetJobPickMaterialGiacenzaOri = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            SetJobPickMaterialGiacenzaOri = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function SetJobPickMaterialGiacenzaDest() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            SetJobPickMaterialGiacenzaDest = 1

            WmsJob.MaterialeGiacenzaDestinazione.UbicazioneInfo = clsWmsJob.MaterialeSelStockGiacenzaDest.UbicazioneInfo

            '>>> SE NON IMPOSTATO IMPOSTO IL TIPO UNITA DI MAGAZZINO
            If (WmsJob.MaterialeGiacenzaDestinazione.UbicazioneInfo.AbilitaUnitaMagazzino = True) And (clsUtility.IsStringValid(WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.TipoUnitaMagazzino, True) = False) Then
                WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.TipoUnitaMagazzino = Default_TipoUnitaMagazzino
            End If
            If (clsUtility.IsStringValid(WmsJob.MaterialeGiacenzaDestinazione.UbicazioneInfo.UnitaMagazzino, True) = True) And (clsUtility.IsStringValid(WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.TipoUnitaMagazzino, True) = False) Then
                WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.TipoUnitaMagazzino = Default_TipoUnitaMagazzino
            End If

            SetJobPickMaterialGiacenzaDest = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            SetJobPickMaterialGiacenzaDest = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function SetJobPickQtyMaterialGiacenzaOri(ByVal inConfirmedQty As Double, ByVal inFlagForcedStepEnded As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkUdmQty As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            SetJobPickQtyMaterialGiacenzaOri = 1

            If (IsJobPickPartialPickPieces(WorkUdmQty) = True) Then
                'CASO PARTICOLARE DI PRELIEVO DEGLI SFUSI
                WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataSfusiOperatore = inConfirmedQty
            Else
                '>>> CASO NORMALE
                WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore = inConfirmedQty
            End If

            FlagForcedStepEnded = inFlagForcedStepEnded

            SetJobPickQtyMaterialGiacenzaOri = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            SetJobPickQtyMaterialGiacenzaOri = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function ExecJobStepExecuted(ByRef outCheckExecutionOk As Boolean, ByRef outMessageDescription As String, ByRef outRetInfoSapWmWmsJob As clsDataType.SapWmWmsJob) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim QtaConfermataJob As Double = 0
        Dim QtaTotaleDaPrelevareRimanenteJob As Double = 0
        Dim FineOperazioni As Boolean = False
        Dim IndexJob As Long = 0
        Dim QtaConfermataTotale As Double = 0
        Dim MemoNrWmsJobs As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ExecJobStepExecuted = 1


            outMessageDescription = ""
            outCheckExecutionOk = False
            IndexJob = 0

            'NELLA LOGICA DI ACCORPAMENTO MI DEVO SALVARE IL JOB ATTIVO
            MemoNrWmsJobs = clsWmsJob.WmsJob.NrWmsJobs

            QtaConfermataTotale = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore
            '>>> NEL CASO DI ACCORPAMENTO ESEGUO QUESTA CHIAMATA PER OGNI JOB
            Do Until (FineOperazioni = True)
                If (IsValidJobsGroupExec() = True) Then
                    QtaTotaleDaPrelevareRimanenteJob = clsWmsJob.WmsJobsGroupExecInfo.JobsGroupExecTab(IndexJob).QtaTotaleDaPrelevareRimanente

                    'MI IMPOSTO IL JOB RAGGRUPPATO CORRENTE
                    clsWmsJob.WmsJob.NrWmsJobs = clsWmsJob.WmsJobsGroupExecInfo.JobsGroupExecTab(IndexJob).NrWmsJobs

                    If (QtaConfermataTotale >= QtaTotaleDaPrelevareRimanenteJob) Then
                        'CASO CONFERMO TUTTA LA QTA PREVISTA DAL JOB
                        QtaConfermataJob = QtaTotaleDaPrelevareRimanenteJob
                        QtaConfermataTotale = QtaConfermataTotale - QtaTotaleDaPrelevareRimanenteJob
                    Else
                        'CONFERMO SOLO UNA PARTE 
                        QtaConfermataJob = QtaConfermataTotale
                        QtaConfermataTotale = 0
                        FineOperazioni = True 'FLAG USCITA DAL LOOP
                    End If
                    If (QtaConfermataTotale <= 0) Then
                        FineOperazioni = True 'FLAG USCITA DAL LOOP
                    End If
                Else
                    '>>> CASO NON ACCORPATO => UNA UNICA CHIAMATA
                    FineOperazioni = True
                    QtaConfermataJob = QtaConfermataTotale
                End If
                '>>> ESEGUO AZIONE PREVISTA DAL JOB ( PICKING IN QUESTO CASO)
                RetCode = clsSapWS.Call_ZWS_JOB_STEPS_EXECUTED(clsWmsJob.WmsJob, QtaConfermataJob, Nothing, clsWmsJob.FlagForcedStepEnded, clsWmsJob.WmsJob.InfoPrelievo, clsUser.SapWmsUser.LANGUAGE, outCheckExecutionOk, clsWmsJob.WmOtInfo, outRetInfoSapWmWmsJob, SapFunctionError, False)
                If (RetCode <> 0) Or (outCheckExecutionOk = False) Then
                    outMessageDescription += clsAppTranslation.GetSingleParameterValue(1053, "", "Errore in esecuzione Missione:") & clsWmsJob.WmsJob.NrWmsJobs & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare") & vbCrLf & clsAppTranslation.GetSingleParameterValue(494, "", "Err.Descr:") & SapFunctionError.ERROR_DESCRIPTION
                Else
                    '>>> TUTTO OK
                    outMessageDescription += clsAppTranslation.GetSingleParameterValue(1054, "", "Missione:") & clsWmsJob.WmsJob.NrWmsJobs & clsAppTranslation.GetSingleParameterValue(1055, "", " eseguita con successo.") & vbCrLf
                    Dim MaxArrayIndex As Long
                    Dim IndexFor As Long
                    MaxArrayIndex = UBound(clsWmsJob.WmOtInfo)
                    For IndexFor = 0 To MaxArrayIndex
                        outMessageDescription += clsAppTranslation.GetSingleParameterValue(393, "", " OT NUM:") & clsWmsJob.WmOtInfo(IndexFor).NumeroOrdineDiTrasferimento & vbCrLf
                    Next
                End If
                IndexJob = IndexJob + 1
            Loop

            'SE HO AVUTO ACCORPAMENTO RICARICO IL JOB CORRENTE
            If (IsValidJobsGroupExec() = True) Then
                clsWmsJob.WmsJob.NrWmsJobs = MemoNrWmsJobs
                'ESEGUO REFRESH DATI DEL JOB CORRENTE
                RetCode += clsWmsJob.GetJobSingle(clsWmsJob.WmsJob.NrWmsJobs, Nothing, Nothing, Nothing, Nothing, False, False, False, False)
                If (RetCode <> 0) Then
                    outMessageDescription += vbCrLf & clsAppTranslation.GetSingleParameterValue(1056, "", "Attenzione! Errore in lettura dati MISSIONE:") & clsWmsJob.WmsJob.NrWmsJobs & vbCrLf
                End If
            End If

            ExecJobStepExecuted = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ExecJobStepExecuted = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function NavigationExecJobPickIntoUDS(ByRef inSourceForm As Form, ByRef outNavigationDoneOk As Boolean, ByRef outFlagErroreAttivo As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim PickIntoUDSOk As Boolean = False
        Dim CheckOKBeforeExecJobPickIntoUDS As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            NavigationExecJobPickIntoUDS = 1 'init

            '*****************************************************************************************************
            '>>> ESEGUO VERIFICHE PRIMA DELL'ESECUZIONE DEL PICKING INTO UDS
            '*****************************************************************************************************
            RetCode = CheckBeforeExecJobPickIntoUDS(CheckOKBeforeExecJobPickIntoUDS)
            If (RetCode <> 0) Or (CheckOKBeforeExecJobPickIntoUDS = False) Then
                Exit Function
            End If

            '*****************************************************************************************************
            '>>> ESEGUO CHIAMATA  PER PICK DEL MATERIALE DENTRO A UDS ( NEL FORKLIFT )
            '*****************************************************************************************************
            RetCode = clsWmsJob.ExecJobPickIntoUDS(PickIntoUDSOk, ErrDescription, Nothing)
            If (RetCode <> 0) Or (PickIntoUDSOk = False) Then
                outFlagErroreAttivo = True
            Else
                'NEL CASO DI UNA ESECUZIONE CORRETTA SETTO IL FLAG DI "CONFERMA ESEGUITA"
                clsWmsJob.FlagConfirmDone = True
            End If

            'VISUALIZZO FINESTRA PER MESSAGGI OPERATORE SOLO IN CASO DI ERRORE
            If (outFlagErroreAttivo = True) Then
                frmMessageForUserForm = New frmMessageForUser
                frmMessageForUserForm.SourceForm = inSourceForm 'setto riferimento a FORM per ricaricarla prima di chiudere la finestra del messaggio.
                frmMessageForUserForm.ShowMessage(ErrDescription)
                Exit Function
            End If


            '*****************************************************************************************************
            '>>> ESEGUO VERIFICHE DOPO ESECUZIONE DEL PICKING INTO UDS PER DECIDERE PROSSIMA OPERAZIONE
            '*****************************************************************************************************
            RetCode = clsWmsJob.CheckAfterExecJobPickIntoUDS(inSourceForm)

            NavigationExecJobPickIntoUDS = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            NavigationExecJobPickIntoUDS = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ExecJobPickIntoUDS(ByRef outPickExecutionOk As Boolean, ByRef outMessageDescription As String, ByRef outRetInfoSapWmWmsJob As clsDataType.SapWmWmsJob) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkUbicazioneDestinazione As clsDataType.SapWmUbicazione
        Dim ArrayGiacenze(0) As clsDataType.SapWmGiacenza
        Dim IndexDataRowJob As Long = 0
        Dim IndexDataRowTaskLines As Long = 0
        Dim MemoNrWmsJobs As Long = 0

        Dim WorkUdmQty As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ExecJobPickIntoUDS = 1


            outMessageDescription = ""
            outPickExecutionOk = False

            'LA  DESTINAZIONE DIVENTA  L'UBICAZIONE DEL  FORKLIFT
            WorkUbicazioneDestinazione.Divisione = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.Divisione
            WorkUbicazioneDestinazione.NumeroMagazzino = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.NumeroMagazzino
            WorkUbicazioneDestinazione.TipoMagazzino = clsSapUtility.cstSapTipoMagWork 'VEDERE DI TROVARE QUALCOSA DI PIU' ELEGANTE
            WorkUbicazioneDestinazione.Ubicazione = clsForkLift.CurrentForLift.IdForkLift
            WorkUbicazioneDestinazione.UnitaMagazzino = clsWmsJob.UDSOnWork.UnitaMagazzino
            If (clsUtility.IsStringValid(clsWmsJob.UDSOnWork.UDSInfo.UbicazioneInfo.TipoUnitaMagazzino, True) = False) Then
                WorkUbicazioneDestinazione.TipoUnitaMagazzino = "PP"
            End If

            'MI SALVO IL JOB ATTIVO IN ESECUZIONE
            MemoNrWmsJobs = clsWmsJob.WmsJob.NrWmsJobs

            clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.NrWmsJobs = clsWmsJob.WmsJob.NrWmsJobs 'SE NO VALORIZZATO LO IMPOSTO

            '**************************************************************
            'RECUPERO INDICE PER  AGGIORNAMENTO DATA ROW DEL JOB
            '**************************************************************
            IndexDataRowJob = GetIndexDataRowJobOfTaskListOnWor(False)
            If (IndexDataRowJob < 0) Then
                '????? ERRORE
            End If

            '**************************************************************
            'RECUPERO INDICE PER  AGGIORNAMENTO DATA ROW DEL TASK LINES
            '**************************************************************
            IndexDataRowTaskLines = clsTaskLines.GetIndexDataRowTaskListOnWork(False)
            If (IndexDataRowTaskLines < 0) Then
                '????? ERRORE
            End If

            ArrayGiacenze(0) = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine

            If (IsJobPickPartialPickPieces(WorkUdmQty) = True) Then
                '>>> CASO PARTICOLARE DI PRELIEVO SFUSI
                ArrayGiacenze(0).QuantitaConfermataOperatore = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataSfusiOperatore
                ArrayGiacenze(0).UnitaDiMisuraAcquisizione = WorkUdmQty

            Else
                '>>> CASO DI PRELIEVO NORMALE
                ArrayGiacenze(0).QuantitaConfermataOperatore = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore
                ArrayGiacenze(0).UnitaDiMisuraAcquisizione = UCase(clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione)
            End If

            '>>> ESEGUO PICK NELL'UDS ( E' MESSO NEL FORKLIFT )
            RetCode = clsSapWS.Call_ZWMS_JOB_PICK_INTO_UDS(ArrayGiacenze, clsWmsJob.FlagForcedStepEnded, clsWmsJob.WmsJob, clsWmsJob.TaskLines.TaskLinesInfo, clsWmsJob.TaskLines.TaskLinesOnWork, clsWmsJob.UDSOnWork, clsUser.GetUserDivisionToUse, clsUser.GetUserNumeroMagazzinoToUse, clsForkLift.CurrentForLift, WorkUbicazioneDestinazione, clsUser.SapWmsUser.LANGUAGE, WmOtInfo, outPickExecutionOk, clsWmsJob.WmsJob, objDataTableWmsJobsList.Rows(IndexDataRowJob), TaskLines.objDataTableJobTaskLines(IndexDataRowTaskLines), SapFunctionError, False)
            If (RetCode <> 0) Or (outPickExecutionOk = False) Then
                outMessageDescription += clsAppTranslation.GetSingleParameterValue(1516, "", "Errore in esecuzione Task / Missione:") & clsWmsJob.TaskLines.TaskLinesOnWork.NrTaskLines & " / " & clsWmsJob.WmsJob.NrWmsJobs & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare") & vbCrLf & clsAppTranslation.GetSingleParameterValue(494, "", "Err.Descr:") & SapFunctionError.ERROR_DESCRIPTION
            Else

                '>>> ESEGUO RESET STRUTTURA SAP PER SELEZIONE UBICAZIONE FORZATA SELEZIONATA DA OPERATORE 
                RetCode = clsSapUtility.ResetUbicazioneStruct(StockSelezionatoUtente)

                '>>> MEMORIZZO ULTIMA UBICAZIONE DI PRELIEVO ( PER POI ELABORARE L'EVENTUALE PD DI DESTINAZIONE NEL DROP )
                UbicazioneUltimoPickingCodeOrigine = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo

                '>>> TUTTO OK
                outMessageDescription += clsAppTranslation.GetSingleParameterValue(1484, "", "Task:") & Trim(clsWmsJob.TaskLines.TaskLinesOnWork.NrTaskLines) & " " & clsAppTranslation.GetSingleParameterValue(1054, "", "Missione:") & clsWmsJob.WmsJob.NrWmsJobs & clsAppTranslation.GetSingleParameterValue(1055, "", " eseguita con successo.") & vbCrLf
                Dim MaxArrayIndex As Long
                Dim IndexFor As Long
                MaxArrayIndex = UBound(clsWmsJob.WmOtInfo)
                For IndexFor = 0 To MaxArrayIndex
                    outMessageDescription += clsAppTranslation.GetSingleParameterValue(393, "", " OT NUM:") & clsWmsJob.WmOtInfo(IndexFor).NumeroOrdineDiTrasferimento & vbCrLf
                Next
            End If

            ''SE HO AVUTO ACCORPAMENTO RICARICO IL JOB CORRENTE
            'If (IsValidJobsGroupExec() = True) Then
            '    clsWmsJob.WmsJob.NrWmsJobs = MemoNrWmsJobs
            '    'ESEGUO REFRESH DATI DEL JOB CORRENTE
            '    RetCode += clsWmsJob.GetJobSingle(clsWmsJob.WmsJob.NrWmsJobs, Nothing, Nothing, Nothing, Nothing, False)
            '    If (RetCode <> 0) Then
            '        outMessageDescription += vbCrLf & clsAppTranslation.GetSingleParameterValue(1056, "", "Attenzione! Errore in lettura dati MISSIONE:") & clsWmsJob.WmsJob.NrWmsJobs & vbCrLf
            '    End If
            'End If

            ExecJobPickIntoUDS = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ExecJobPickIntoUDS = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetElementDataTableGiacenzeOri(ByVal inCurrentRowIndex As Long, ByRef outSelezioneOk As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkDataRow As DataRow
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetElementDataTableGiacenzeOri = 1 'INIT AT ERROR

            outSelezioneOk = False 'init

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO QUESTA UBICAZIONE COME
            If (inCurrentRowIndex >= 0) And (inCurrentRowIndex <= GetNumMaterialePickOriGiacenzaProposte()) Then
                'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
                WorkDataRow = objDataTableGiacenzeOriInfo.Rows(inCurrentRowIndex)
                'SETTO I DATI DELLA GIACENZA SELEZIONATA
                RetCode = clsSapUtility.FromGiacenzaDataRowToSapWmGiacenza(WorkDataRow, MaterialeSelStockGiacenzaOri, False)
                If (RetCode = 0) Then
                    outSelezioneOk = True 'UNICO CASO DI SELEZIONE OK
                End If
            End If

            GetElementDataTableGiacenzeOri = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetElementDataTableGiacenzeOri = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetElementDataTableGiacenzeDest(ByVal inCurrentRowIndex As Long, ByRef outSelezioneOk As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkDataRow As DataRow
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetElementDataTableGiacenzeDest = 1 'INIT AT ERROR

            outSelezioneOk = False 'init

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO QUESTA UBICAZIONE COME
            If (inCurrentRowIndex >= 0) And (inCurrentRowIndex <= GetNumMaterialePickDestinationProposte()) Then
                'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
                WorkDataRow = objDataTableGiacenzeDestInfo.Rows(inCurrentRowIndex)
                'SETTO I DATI DELLA GIACENZA SELEZIONATA
                RetCode = clsSapUtility.FromGiacenzaDataRowToSapWmGiacenza(WorkDataRow, MaterialeSelStockGiacenzaDest, False)
                If (RetCode = 0) Then
                    outSelezioneOk = True 'UNICO CASO DI SELEZIONE OK
                End If
            End If

            GetElementDataTableGiacenzeDest = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetElementDataTableGiacenzeDest = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetElementDataTableWmsJobsAutoTransferList(ByVal inCurrentRowIndex As Long, ByRef outGetOk As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkDataRow As DataRow
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetElementDataTableWmsJobsAutoTransferList = 1 'INIT AT ERROR

            outGetOk = False 'init

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO QUESTA UBICAZIONE COME
            If (inCurrentRowIndex >= 0) And (inCurrentRowIndex <= GetNumMaterialePickDestinationProposte()) Then
                'RECUPERO IL DATAROW DELL'ELEMENTO RICHIESTO
                WorkDataRow = objDataTableWmsJobsAutoTransferList.Rows(inCurrentRowIndex)
                'RECUPERO I DATI NELLA STRUTTURA
                RetCode = clsWmsJob.FromDataRowToWmsJobsInfoStruct(WorkDataRow, WmsJob, False)
                If (RetCode = 0) Then
                    outGetOk = True 'UNICO CASO DI SELEZIONE OK
                End If
            End If

            GetElementDataTableWmsJobsAutoTransferList = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetElementDataTableWmsJobsAutoTransferList = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function RefreshJobsSingleStruct(ByVal inNrWmsJobs As String, ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : ritorna un DATASET con un ELENCO DI JOBS (STESSO GRUPPO)
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim WorkDataRows() As DataRow
        Dim WorkDataRow As DataRow

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RefreshJobsSingleStruct = 1 'init at error

            If (clsUtility.IsStringValid(inNrWmsJobs, True) = False) Then
                RetCode = 20
                RefreshJobsSingleStruct = RetCode
                Exit Function
            End If
            WorkDataRows = objDataTableWmsJobsList.Select(" ZNR_WMS_JOBS = " & inNrWmsJobs)

            If (WorkDataRows.GetLength(0) <> 1) Then
                RetCode = 20
                RefreshJobsSingleStruct = RetCode
                Exit Function
            End If

            WorkDataRow = WorkDataRows(0)

            'SETTO I DATI DAL DATA ROW ALLA STRUTTURA
            RetCode = clsWmsJob.FromDataRowToWmsJobsInfoStruct(WorkDataRow, clsWmsJob.WmsJob, False)

            RefreshJobsSingleStruct = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            RefreshJobsSingleStruct = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Public Shared Function CreateDateTableForWmsJobsList() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con JOB INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForWmsJobsList = 1 'init at error

            'CREO IL DATA TABLE PER GESTIORE  TUTTE LE INFORMAZIONI DEI  JOB
            RetCode = clsDataType.CreateDateTableForWmsJobs(objDataTableWmsJobsList)

            CreateDateTableForWmsJobsList = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForWmsJobsList = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function CreateDateTableForGiacenzeOri() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForGiacenzeOri = 1 'init at error

            clsDataType.CreateDateTableForGiacenze(objDataTableGiacenzeOriInfo)

            CreateDateTableForGiacenzeOri = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForGiacenzeOri = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CreateDateTableForGiacenzeOriTotStock() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForGiacenzeOriTotStock = 1 'init at error

            clsDataType.CreateDateTableForGiacenze(objDataTableGiacenzeOriInfoTotStock)

            CreateDateTableForGiacenzeOriTotStock = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForGiacenzeOriTotStock = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CreateDateTableForGiacenzeDest() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForGiacenzeDest = 1 'init at error

            clsDataType.CreateDateTableForGiacenze(objDataTableGiacenzeDestInfo)

            CreateDateTableForGiacenzeDest = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForGiacenzeDest = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetJobPutawayBestDestination(ByRef inDatiRicercaStock As clsDataType.SapWmGiacenza, ByVal inShowMessageBox As Boolean, ByRef outCheckStockOk As Boolean, ByRef outFoundOneDestination As Boolean, ByRef outCatchErrorHappened As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : ritorna un DATASET con un ELENCO DI JOBSGROUPS
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim Index As Long
        Dim NumDestinazioni As Long = 0
        Dim EntrataMerceDaOdp As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetJobPutawayBestDestination = 1 'init at error

            outCheckStockOk = False             'init
            outFoundOneDestination = False      'init at error


            'IMPOSTO FLAG PER CASO DI ENTRATA MERCE DA ODP (PER PRODUZIONE)
            If (clsUtility.IsStringValid(WmsJob.NumeroOrdineDiProduzione, True) = True) Then
                EntrataMerceDaOdp = True
            Else
                EntrataMerceDaOdp = False
            End If
            'RECUPERO LE POSSIBILI DESTINAZIONI IN BASE ALLA LOGICA DI STRATEGIA
            RetCode = clsSapWS.Call_ZWS_CHECK_STOCK_AND_GET_DEST(inDatiRicercaStock, clsUser.SapWmsUser.LANGUAGE, Nothing, EntrataMerceDaOdp, outCheckStockOk, Nothing, MaterialeSelStockGiacenzaDest, MaterialePickOriGiacenze, outFoundOneDestination, MaterialePickDestinations, DescrUbicDestPick, SapFunctionError, False, outCatchErrorHappened)
            If (RetCode <> 0) Or (outFoundOneDestination = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(437, "", "Ubicazione destinazione non trovata.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If

            'RECUPERO L'INDICE DELLA DESTINAZIONE VUOTA
            NumDestinazioni = GetNumMaterialePickDestinationProposte()
            If (NumDestinazioni > 0) Then
                For Index = 0 To NumDestinazioni - 1
                    If (MaterialePickDestinations(Index).OdaInputDestInfo.FoundMagEmpty = True) Then
                        IndexUbiVuotaDest = Index
                    End If
                Next
            End If


            GetJobPutawayBestDestination = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetJobPutawayBestDestination = 1000 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Public Shared Function CreateDateTableDetails() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per griglia DETTAGLI MATERIALE
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim WorkRow As DataRow = Nothing

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableDetails = 1 'init at error


            If objDataTableDetailsWmsJobList.Columns("PropertyId") Is Nothing Then
                Dim WorkPropertyId As DataColumn = New DataColumn("PropertyId") 'declaring a column named Name
                WorkPropertyId.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
                objDataTableDetailsWmsJobList.Columns.Add(WorkPropertyId) 'adding the column to table
            End If

            If objDataTableDetailsWmsJobList.Columns("PropertyText") Is Nothing Then
                Dim WorkPropertyText As DataColumn = New DataColumn("PropertyText") 'declaring a column named Name
                WorkPropertyText.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
                objDataTableDetailsWmsJobList.Columns.Add(WorkPropertyText) 'adding the column to table
            End If

            If objDataTableDetailsWmsJobList.Columns("PropertyValue") Is Nothing Then
                Dim WorkPropertyValue As DataColumn = New DataColumn("PropertyValue") 'declaring a column named Name
                WorkPropertyValue.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
                objDataTableDetailsWmsJobList.Columns.Add(WorkPropertyValue) 'adding the column to table
            End If


            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "GRID_EXECUTED"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1435, "", "GRID_EXECUTED")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "ZNR_WMS_JOBS"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(761, "", "Grup.Miss.")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "MATNR_ORI"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(362, "", "Cod.Mat.")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "CHARG_ORI"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(307, "", "Partita")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "ZQTAPK_ORI"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(363, "", "Q.Da Pr.")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "MEINS_ORI"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(86, "", "UdM")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "ZQTA_PREL_CONS"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(364, "", "Q.Prep.")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "UDM_QTAPR_CONS"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(86, "", "UdM")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "ZQTA_PREL_PZ"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(364, "", "Sfusi")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "UDM_QTAPR_PZ"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(86, "", "UdM")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "STATUS"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(365, "", "Stato")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "ZCARR_EXEC"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(367, "", "Ope.Esec.")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "MAKTG"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(368, "", "Descr.Mat.")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "SEQUENCE"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(369, "", "Seq.")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "PRIORITA"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(370, "", "Pri.")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "URGENTE"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(371, "", "Urg.")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "ZNRPICK"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(658, "", "N°Ord.Pic.")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "ZPOSPK"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1436, "", "PARTNER_AG_STRAS")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "ZNR_WMS_GRPEXEC"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1399, "", "ZDOC")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga


            '' #################### ''
            '' CAMPI DA GESTIRE !!! ''
            '' #################### ''


            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "ZNR_WMS_JOBSGRP"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(761, "", "ZNR_WMS_JOBSGRP")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            'WorkRow = objDataTableDetailsWmsJobList.NewRow()
            'WorkRow.Item("PropertyId") = "ZWMS_JOBSGRP_DESCR"
            'WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1488, "", "ZWMS_JOBSGRP_DESCR")
            'WorkRow.Item("PropertyValue") = ""
            'objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "IDSTATUS"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1337, "", "IDSTATUS")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "STATUS_DESCR"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1338, "", "STATUS_DESCR")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "WERKS_ORI"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1339, "", "WERKS_ORI")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "LGORT_ORI"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1340, "", "LGORT_ORI")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "BESTQ_ORI"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1341, "", "BESTQ_ORI")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "SOBKZ_ORI"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1342, "", "SOBKZ_ORI")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "SONUM_ORI"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1343, "", "SONUM_ORI")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "LGNUM_ORI"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1344, "", "LGNUM_ORI")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "LGTYP_ORI"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1345, "", "LGTYP_ORI")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "LGPLA_ORI"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1346, "", "LGPLA_ORI")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "LENUM_ORI"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1347, "", "LENUM_ORI")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "MEINS_PZ"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1348, "", "MEINS_PZ")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "ZQTAPK_ORI_PZ"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1349, "", "ZQTAPK_ORI_PZ")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "ZQTAPK_ORI_SC"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1350, "", "ZQTAPK_ORI_SC")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "ZQTAPK_ORI_PL"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1351, "", "ZQTAPK_ORI_PL")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "ZQTAPK_SFUSI_PZ"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1352, "", "ZQTAPK_SFUSI_PZ")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "ZQTA_PREL_BASE"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1353, "", "ZQTA_PREL_BASE")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "UDM_QTAPR_MEINS"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1354, "", "UDM_QTAPR_MEINS")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "ZCARR_PROP"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1355, "", "ZCARR_PROP")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "WERKS_DEST"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1356, "", "WERKS_DEST")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "LGORT_DEST"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1357, "", "LGORT_DEST")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "MATNR_DEST"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1358, "", "MATNR_DEST")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "CHARG_DEST"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1359, "", "CHARG_DEST")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "BESTQ_DEST"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1360, "", "BESTQ_DEST")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "SOBKZ_DEST"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1361, "", "SOBKZ_DEST")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "SONUM_DEST"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1362, "", "SONUM_DEST")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "LGNUM_DEST"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1363, "", "LGNUM_DEST")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "LGTYP_DEST"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1364, "", "LGTYP_DEST")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "LGPLA_DEST"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1365, "", "LGPLA_DEST")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "LENUM_DEST"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1366, "", "LENUM_DEST")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "LGNUM_PROP_ORI"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1367, "", "LGNUM_PROP_ORI")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "LGTYP_PROP_ORI"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1368, "", "LGTYP_PROP_ORI")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "LGPLA_PROP_ORI"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1369, "", "LGPLA_PROP_ORI")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "LGNUM_PROP_DEST"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1370, "", "LGNUM_PROP_DEST")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "LGTYP_PROP_DEST"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1371, "", "LGTYP_PROP_DEST")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "LGPLA_PROP_DEST"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1372, "", "LGPLA_PROP_DEST")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "CURRENT_STEP"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1373, "", "CURRENT_STEP")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "NUM_STEPS_TOTAL"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1374, "", "NUM_STEPS_TOTAL")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "DATA_CREAZIONE"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1375, "", "DATA_CREAZIONE")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "ORA_CREAZIONE"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1376, "", "ORA_CREAZIONE")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "DATA_START"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1377, "", "DATA_START")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "ORA_START"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1378, "", "ORA_START")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "DATA_FINE"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1379, "", "DATA_FINE")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "ORA_FINE"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1380, "", "ORA_FINE")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "PICK_DBTABNAME"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1381, "", "PICK_DBTABNAME")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "VBELN"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1382, "", "VBELN")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "POSNR"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1383, "", "POSNR")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "NUM_CONS_VBELV"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1384, "", "NUM_CONS_VBELV")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "POS_CONS_POSNV"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1385, "", "POS_CONS_POSNV")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "MJAHR"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1386, "", "MJAHR")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "MBLNR"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1387, "", "MBLNR")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "ZEILE"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1388, "", "ZEILE")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "ID_JOBS_TYPE"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1389, "", "ID_JOBS_TYPE")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "DESCR_JOBS_TYPE"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1390, "", "DESCR_JOBS_TYPE")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "JOBS_TYPE_KZEAR"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1391, "", "JOBS_TYPE_KZEAR")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "ZFLAWM"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1392, "", "ZFLAWM")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "PALLET_INTERI"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1393, "", "PALLET_INTERI")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "SCATOLE_INTERE"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1394, "", "SCATOLE_INTERE")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "ZTIPO_ENTMERCE"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1395, "", "ZTIPO_ENTMERCE")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "ZFORCEDDEST"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1396, "", "ZFORCEDDEST")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "ZFORCSPUNTACONF"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1397, "", "ZFORCSPUNTACONF")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "CHARG_TASSATIVA"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1398, "", "CHARG_TASSATIVA")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "ZDOC"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1399, "", "ZDOC")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "FORNITORE_LIFNR"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1400, "", "FORNITORE_LIFNR")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "MEMO"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1401, "", "MEMO")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "ZZ_NDIS"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1402, "", "ZZ_NDIS")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "INFO_PRELIEVO"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1403, "", "INFO_PRELIEVO")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "IMBALLO"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1404, "", "IMBALLO")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "PZ_X_SC"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1405, "", "PZ_X_SC")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "SC_X_PAL"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1406, "", "SC_X_PAL")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobList.NewRow()
            WorkRow.Item("PropertyId") = "M2_X_PAL"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1407, "", "M2_X_PAL")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobList.Rows.Add(WorkRow) 'aggiungo la riga

            CreateDateTableDetails = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableDetails = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Public Shared Function RefreshDateTableDetailsInfo() As Long
        ' ************************************************************
        ' DESCRIZIONE : ESEGUE IL REFRESH DEI DATI DELLE USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim WorkRow As DataRow
        Dim WorkPropertyId As String = ""
        Dim WorkPropertyValue As String
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RefreshDateTableDetailsInfo = 1 'init at error

            If (objDataTableDetailsWmsJobList Is Nothing) Then Exit Function

            If (objDataTableDetailsWmsJobList.Rows.Count = 0) Then Exit Function

            If (objDetailsDataRow Is Nothing) Then Exit Function

            For Each WorkRow In objDataTableDetailsWmsJobList.Rows
                WorkPropertyId = WorkRow.Item("PropertyId")
                Select Case UCase(WorkPropertyId)
                    Case "GRID_EXECUTED"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "GRID_EXECUTED", "")
                    Case "ZNR_WMS_JOBS"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZNR_WMS_JOBS", "")
                    Case "ZNR_WMS_JOBSGRP"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZNR_WMS_JOBSGRP", "")
                        'Case "ZWMS_JOBSGRP_DESCR"
                        '    WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZWMS_JOBSGRP_DESCR", "")
                    Case "ZNR_WMS_GRPEXEC"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZNR_WMS_GRPEXEC", "")
                    Case "IDSTATUS"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "IDSTATUS", "")
                    Case "STATUS"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "STATUS", "")
                    Case "STATUS_DESCR"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "STATUS_DESCR", "")
                    Case "MAKTG"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "MAKTG", "")
                    Case "WERKS_ORI"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "WERKS_ORI", "")
                    Case "LGORT_ORI"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LGORT_ORI", "")
                    Case "CHARG_ORI"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "CHARG_ORI", "")
                    Case "BESTQ_ORI"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "BESTQ_ORI", "")
                    Case "SOBKZ_ORI"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "SOBKZ_ORI", "")
                    Case "SONUM_ORI"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "SONUM_ORI", "")
                    Case "LGNUM_ORI"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LGNUM_ORI", "")
                    Case "LGTYP_ORI"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LGTYP_ORI", "")
                    Case "LGPLA_ORI"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LGPLA_ORI", "")
                    Case "LENUM_ORI"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LENUM_ORI", "")
                    Case "MEINS_ORI"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "MEINS_ORI", "")
                    Case "ZQTAPK_ORI"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZQTAPK_ORI", "")
                    Case "MEINS_PZ"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "MEINS_PZ", "")
                    Case "ZQTAPK_ORI_PZ"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZQTAPK_ORI_PZ", "")
                    Case "ZQTAPK_ORI_SC"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZQTAPK_ORI_SC", "")
                    Case "ZQTAPK_ORI_PL"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZQTAPK_ORI_PL", "")
                    Case "ZQTAPK_SFUSI_PZ"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZQTAPK_SFUSI_PZ", "")
                    Case "ZQTA_PREL_BASE"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZQTA_PREL_BASE", "")
                    Case "UDM_QTAPR_MEINS"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "UDM_QTAPR_MEINS", "")
                    Case "ZQTA_PREL_CONS"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZQTA_PREL_CONS", "")
                    Case "UDM_QTAPR_CONS"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "UDM_QTAPR_CONS", "")
                    Case "ZQTA_PREL_PZ"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZQTA_PREL_PZ", "")
                    Case "UDM_QTAPR_PZ"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "UDM_QTAPR_PZ", "")
                    Case "WERKS_DEST"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "WERKS_DEST", "")
                    Case "LGORT_DEST"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LGORT_DEST", "")
                    Case "MATNR_DEST"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "MATNR_DEST", "")
                    Case "CHARG_DEST"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "CHARG_DEST", "")
                    Case "BESTQ_DEST"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "BESTQ_DEST", "")
                    Case "SOBKZ_DEST"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "SOBKZ_DEST", "")
                    Case "SONUM_DEST"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "SONUM_DEST", "")
                    Case "LGNUM_DEST"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LGNUM_DEST", "")
                    Case "LGTYP_DEST"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LGTYP_DEST", "")
                    Case "LGPLA_DEST"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LGPLA_DEST", "")
                    Case "LENUM_DEST"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LENUM_DEST", "")
                    Case "LGNUM_PROP_ORI"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LGNUM_PROP_ORI", "")
                    Case "LGTYP_PROP_ORI"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LGTYP_PROP_ORI", "")
                    Case "LGPLA_PROP_ORI"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LGPLA_PROP_ORI", "")
                    Case "LGNUM_PROP_DEST"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LGNUM_PROP_DEST", "")
                    Case "LGTYP_PROP_DEST"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LGTYP_PROP_DEST", "")
                    Case "LGPLA_PROP_DEST"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LGPLA_PROP_DEST", "")
                    Case "SEQUENCE"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "SEQUENCE", "")
                    Case "CURRENT_STEP"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "CURRENT_STEP", "")
                    Case "NUM_STEPS_TOTAL"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "NUM_STEPS_TOTAL", "")
                    Case "DATA_CREAZIONE"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "DATA_CREAZIONE", "")
                    Case "ORA_CREAZIONE"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ORA_CREAZIONE", "")
                    Case "DATA_START"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "DATA_START", "")
                    Case "ORA_START"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ORA_START", "")
                    Case "DATA_FINE"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "DATA_FINE", "")
                    Case "PICK_DBTABNAME"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "PICK_DBTABNAME", "")
                    Case "ZNRPICK"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZNRPICK", "")
                    Case "ZPOSPK"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZPOSPK", "")
                    Case "VBELN"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "VBELN", "")
                    Case "POSNR"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "POSNR", "")
                    Case "NUM_CONS_VBELV"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "NUM_CONS_VBELV", "")
                    Case "POS_CONS_POSNV"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "POS_CONS_POSNV", "")
                    Case "MJAHR"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "MJAHR", "")
                    Case "MBLNR"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "MBLNR", "")
                    Case "ZEILE"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZEILE", "")
                    Case "ID_JOBS_TYPE"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ID_JOBS_TYPE", "")
                    Case "DESCR_JOBS_TYPE"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "DESCR_JOBS_TYPE", "")
                    Case "JOBS_TYPE_KZEAR"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "JOBS_TYPE_KZEAR", "")
                    Case "PRIORITA"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "PRIORITA", "")
                    Case "URGENTE"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "URGENTE", "")
                    Case "ZFLAWM"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZFLAWM", "")
                    Case "PALLET_INTERI"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "PALLET_INTERI", "")
                    Case "SCATOLE_INTERE"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "SCATOLE_INTERE", "")
                    Case "ZTIPO_ENTMERCE"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZTIPO_ENTMERCE", "")
                    Case "ZFORCEDDEST"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZFORCEDDEST", "")
                    Case "ZFORCSPUNTACONF"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZFORCSPUNTACONF", "")
                    Case "CHARG_TASSATIVA"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "CHARG_TASSATIVA", "")
                    Case "ZCARR_PROP"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZCARR_PROP", "")
                    Case "ZCARR_EXEC"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZCARR_EXEC", "")
                    Case "ZDOC"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZDOC", "")
                    Case "FORNITORE_LIFNR"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "FORNITORE_LIFNR", "")
                    Case "MEMO"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "MEMO", "")
                    Case "ZZ_NDIS"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZZ_NDIS", "")
                    Case "INFO_PRELIEVO"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "INFO_PRELIEVO", "")
                    Case "IMBALLO"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "IMBALLO", "")
                    Case "PZ_X_SC"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "PZ_X_SC", "")
                    Case "SC_X_PAL"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "SC_X_PAL", "")
                    Case "M2_X_PAL"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "M2_X_PAL", "")
                    Case Else
                        WorkPropertyValue = "NO DATA"
                End Select
                WorkRow.Item("PropertyValue") = WorkPropertyValue
            Next

            RefreshDateTableDetailsInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            RefreshDateTableDetailsInfo = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ShowJobWeightInfoForUserString(Optional ByVal inShowMode As Long = 0) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim tmpString As String = ""
        Dim WorkPesoRimanente As Double = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ShowJobWeightInfoForUserString = ""


            'inShowMode = 0 : usato per la videate PICKING UDS ( VIDEATE ESECUZIONE SINGOLO PICKING )

            Select Case inShowMode
                Case 0

                    tmpString += clsAppTranslation.GetSingleParameterValue(1489, "", "PESO MASSIMO CARRELLO: ") + Trim(Str(clsForkLift.CurrentForLift.ForkLiftMaxPesoCarico)) + " " + clsForkLift.CurrentForLift.UdmPeso
                    tmpString += vbCrLf


                    'CALCOLO PESO RIMANENTE
                    WorkPesoRimanente = 0
                    If (clsForkLift.CurrentForLift.ForkLiftMaxPesoCarico >= UDSOnWork.UDSWeightInfo.PesoTotaleUDS_Lb) And (UCase(clsForkLift.CurrentForLift.UdmPeso) = UCase(UDSOnWork.UDSWeightInfo.UdmPesoLb)) Then
                        WorkPesoRimanente = clsForkLift.CurrentForLift.ForkLiftMaxPesoCarico - UDSOnWork.UDSWeightInfo.PesoTotaleUDS_Lb

                        tmpString += clsAppTranslation.GetSingleParameterValue(1490, "", "PESO UDS ATTIVO") + ": " + Trim(Str(UDSOnWork.UDSWeightInfo.PesoTotaleUDS_Lb)) + " " + UDSOnWork.UDSWeightInfo.UdmPesoLb
                        tmpString += vbCrLf

                        tmpString += clsAppTranslation.GetSingleParameterValue(1491, "", "PESO RIMANENTE") + ": " + Trim(Str(WorkPesoRimanente)) + " " + UDSOnWork.UDSWeightInfo.UdmPesoLb
                        tmpString += vbCrLf
                    ElseIf (clsForkLift.CurrentForLift.ForkLiftMaxPesoCarico >= UDSOnWork.UDSWeightInfo.PesoTotaleUDS_Lb) And (UCase(clsForkLift.CurrentForLift.UdmPeso) = UCase(UDSOnWork.UDSWeightInfo.UdmPesoKg)) Then
                        WorkPesoRimanente = clsForkLift.CurrentForLift.ForkLiftMaxPesoCarico - UDSOnWork.UDSWeightInfo.PesoTotaleUDS_Kg

                        tmpString += clsAppTranslation.GetSingleParameterValue(1490, "", "PESO UDS ATTIVO") + ": " + Trim(Str(UDSOnWork.UDSWeightInfo.PesoTotaleUDS_Kg)) + " " + UDSOnWork.UDSWeightInfo.UdmPesoKg
                        tmpString += vbCrLf

                        tmpString += clsAppTranslation.GetSingleParameterValue(1491, "", "PESO RIMANENTE") + ": " + Trim(Str(WorkPesoRimanente)) + " " + UDSOnWork.UDSWeightInfo.UdmPesoKg
                        tmpString += vbCrLf

                    End If
                Case 1

                    'INFORMAZIONI CON IL PESO DI TUTTO IL MATERIALE DELLA CODA
                    tmpString += clsAppTranslation.GetSingleParameterValue(1492, "", "PESO TOT.MIS.: ") + Trim(Str(clsWmsJob.JobsQueueWeightInfo.PesoTotaleCoda_Lb)) + " " + clsWmsJob.JobsQueueWeightInfo.UdmPesoLb
                    tmpString += vbCrLf
                    tmpString += clsAppTranslation.GetSingleParameterValue(1493, "", "PESO MIS.RIM.") + ": " + Trim(Str(clsWmsJob.JobsQueueWeightInfo.PesoRimanenteCoda_Lb)) + " " + clsWmsJob.JobsQueueWeightInfo.UdmPesoLb
                    tmpString += vbCrLf

                    'CALCOLO PESO RIMANENTE
                    WorkPesoRimanente = 0
                    If (clsForkLift.CurrentForLift.ForkLiftMaxPesoCarico >= UDSOnWork.UDSWeightInfo.PesoTotaleUDS_Lb) And (UCase(clsForkLift.CurrentForLift.UdmPeso) = UCase(UDSOnWork.UDSWeightInfo.UdmPesoLb)) Then
                        WorkPesoRimanente = clsForkLift.CurrentForLift.ForkLiftMaxPesoCarico - UDSOnWork.UDSWeightInfo.PesoTotaleUDS_Lb

                        tmpString += clsAppTranslation.GetSingleParameterValue(1494, "", "PESO UDS") + ": " + Trim(Str(UDSOnWork.UDSWeightInfo.PesoTotaleUDS_Lb)) + " " + UDSOnWork.UDSWeightInfo.UdmPesoLb
                        tmpString += clsAppTranslation.GetSingleParameterValue(1495, "", " - PESO RIM.: ") + Trim(Str(WorkPesoRimanente)) + " " + UDSOnWork.UDSWeightInfo.UdmPesoLb
                        tmpString += vbCrLf
                    ElseIf (clsForkLift.CurrentForLift.ForkLiftMaxPesoCarico >= UDSOnWork.UDSWeightInfo.PesoTotaleUDS_Lb) And (UCase(clsForkLift.CurrentForLift.UdmPeso) = UCase(UDSOnWork.UDSWeightInfo.UdmPesoKg)) Then
                        WorkPesoRimanente = clsForkLift.CurrentForLift.ForkLiftMaxPesoCarico - UDSOnWork.UDSWeightInfo.PesoTotaleUDS_Kg

                        tmpString += clsAppTranslation.GetSingleParameterValue(1494, "", "PESO UDS") + ": " + Trim(Str(UDSOnWork.UDSWeightInfo.PesoTotaleUDS_Kg)) + " " + UDSOnWork.UDSWeightInfo.UdmPesoKg
                        tmpString += clsAppTranslation.GetSingleParameterValue(1495, "", " - PESO RIM.: ") + Trim(Str(WorkPesoRimanente)) + " " + UDSOnWork.UDSWeightInfo.UdmPesoKg
                        tmpString += vbCrLf

                    End If

            End Select

            ShowJobWeightInfoForUserString = tmpString

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ShowJobWeightInfoForUserString = ""
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try


    End Function

    Public Shared Function JobsActivateTaskLinesOnWorkExecution(ByVal inIdCarrellistaEsecuzione As String, ByVal inCheckJobOkForAction As Boolean, ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : ritorna un DATASET con un ELENCO DI JOBSGROUPS
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim GetPickLocationOk As Boolean = False
        Dim GetPickQtyOk As Boolean = False
        Dim CheckExecutionOk As Boolean = False
        Dim CheckWarningFlag As Boolean = False
        Dim WarningDescription As String = ""
        Dim QtaRimastaDaPrelevare As Double = 0
        Dim QtaJobRichiestaTaskLine As Double = 0
        Dim QtaPrelevataTaskLine As Double = 0
        Dim WorkUbicazione As clsDataType.SapWmUbicazione
        Dim UserAnswer As DialogResult
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            JobsActivateTaskLinesOnWorkExecution = 1 'init at error

            '>>> VERIFICO SE IL JOB E' OK PER L'ESECUZIONE
            If (IsJobsOkForExecution(inShowMessageBox) = False) Then
                RetCode = 10
                JobsActivateTaskLinesOnWorkExecution = RetCode
                Exit Function
            End If

            '>>> CASO DI PRELIEVO LOGICO
            If (IsPickingLogicJobs(inShowMessageBox) = True) Then
                'IMPOSTO DATI DELLO STOCK SCELTO COME STOCK DI PRELIEVO PER PICKING
                RetCode = clsWmsJob.SetJobPickMaterialGiacenzaOri(True)
                If (RetCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(377, "", "Errore in impostazione dati giacenza.") & vbCrLf & "[SetJobPickMaterialGiacenzaOri]" & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Function
                End If
            End If
            If (IsPickingCheckOnlyPresenceJobs(inShowMessageBox) = True) Then
                'IMPOSTO DATI DELLO STOCK SCELTO COME STOCK DI PRELIEVO PER PICKING
                RetCode = clsWmsJob.SetJobPickMaterialGiacenzaOri(True)
                If (RetCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(377, "", "Errore in impostazione dati giacenza.") & vbCrLf & "[SetJobPickMaterialGiacenzaOri]" & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Function
                End If
            End If

            '>>> VERIFICO SE CI SONO LE CONDIZIONI DI ESECUZIONE
            If (inCheckJobOkForAction = True) Then
                RetCode += clsSapWS.Call_ZWS_CHECK_JOBS_OK_FOR_ACTION(WmsJob, CheckExecutionOk, CheckWarningFlag, WarningDescription, clsUser.SapWmsUser.LANGUAGE, SapFunctionError, False)
                If (CheckExecutionOk = False) Then
                    RetCode = 100
                    JobsActivateTaskLinesOnWorkExecution = RetCode
                    If (inShowMessageBox = True) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1040, "", "Missione non OK per esecuzione.") & vbCrLf & SapFunctionError.ERROR_DESCRIPTION & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If
                    Exit Function
                End If
                If (CheckWarningFlag = True) Then
                    '>>> CASO DI SEGNALAZIONE DI ESECUZIONE CHE NON RISPETTA LA SEQUENZA
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1041, "", "Sequenza ESECUZIONE missioni non rispettata.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1042, "", "Si desidera comunque continuare ? (Si / No )")
                    UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                        RetCode = 200
                        JobsActivateTaskLinesOnWorkExecution = RetCode
                        Exit Function
                    End If
                End If
            End If

            '********************************************************************************
            'RECUPERO LE INFO SULLA QTA RIMASTA DA PRELEVARE
            '********************************************************************************
            RetCode = TaskLines.GetTaskLinesOnWorkQtyToPick(QtaRimastaDaPrelevare, QtaJobRichiestaTaskLine, QtaPrelevataTaskLine)
            If (RetCode <> 0) Then
                RetCode = 290
                JobsActivateTaskLinesOnWorkExecution = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1505, "", "Attenzione, errore nel recupero  della QTA da prelevare della TASK LINE.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If


            'VERIFICARE SE HO PRELEVATO TUTTA LA QTA
            If (QtaRimastaDaPrelevare <= 0) Then
                RetCode = 300
                JobsActivateTaskLinesOnWorkExecution = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(418, "", "Attenzione! Nessuna QTA da prelevare. QTA Da Prelevare:") & Trim(Str(QtaJobRichiestaTaskLine)) & clsAppTranslation.GetSingleParameterValue(419, "", " Qta Prelevata:") & Trim(Str(QtaPrelevataTaskLine)) & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If


            '>>> RILANCIO LA STRATEGIA PER  TROVARE IL MATERIALE MIGLIORE PER ESEGUIRE LA TASK LINE ATTIVA
            RetCode += clsSapWS.Call_ZWS_MB_GET_WM_OUT_ORI_BASIC(WmsJob.MaterialeGiacenzaOrigine, WmsJob, QtaRimastaDaPrelevare, WorkUbicazione, TaskLines.TaskLinesOnWork, clsUser.SapWmsUser.ZID_PICK_QUEUE, GetPickLocationOk, GetPickQtyOk, MaterialePickOriGiacenze, DescrUbicOriPick, FlagStockFoundInOtherWh, SapFunctionError, False)
            If (FlagStockFoundInOtherWh = True) Then
                RetCode = 318
                JobsActivateTaskLinesOnWorkExecution = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1814, "", "Attenzione, materiale da prelevare presente solo in altre code.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1815, "", "La missione viene terminata automaticamente.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If
            If (GetPickLocationOk = False) Then
                RetCode = 320
                JobsActivateTaskLinesOnWorkExecution = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1487, "", "Attenzione, materiale da prelevare non trovato tra i disponibili.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            '>>> SE SI TRATTA DI UN RESO AD UN FORNITORE SEGNALO QUESTA CONDIZIONE DOVE OCCORRE PRELEVARE UNO SPECIFICO OGGETTO
            If (WmsJob.CondizioneDiReso = True) Then
                '>>> SOLO SEGNALAZIONE PER OPERATORE, NO ERRORE
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1043, "", "Attenzione, attivata una MISSIONE DI RESO.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1044, "", "Verificare e identificare correttamente la merce da prelevare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
            End If

            'VERIFICO IN CHE VIDEATA DEVO ANDARE PRINCIPALMENTE IN BASE AL TIPO MAGAZZINO 
            RetCode = GetCurrentPickingMerciSourceType()

            'IMPOSTO L'ORARIO DI START DELLA MISSIONE
            RetCode += ActionInfo.ActionStart()


            JobsActivateTaskLinesOnWorkExecution = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            JobsActivateTaskLinesOnWorkExecution = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CreateDateTableForLockStock() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForLockStock = 1 'init at error

            clsDataType.CreateDateTableForLockStock(objDataTableForLockStock)

            CreateDateTableForLockStock = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForLockStock = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

End Class
