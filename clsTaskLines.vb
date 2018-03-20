' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI & LUCA BELLEI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 18/10/2011
' DATA MODIFICA     : 18/10/2011
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la funzione di visualizzare le informazioni dei Carrelli
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType

Public Class clsTaskLines

    '*****************************************
    ' >>> COSTANTI PER TIPO DI TASK LINES
    '*****************************************
    Public Const cstTaskLinesPickType_FullPallet = "PF"
    Public Const cstTaskLinesPickType_PartialPallet = "PP"
    Public Const cstTaskLinesPickType_PickPieces = "PZ"



    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsTaskLines"


    Public Shared TaskLinesInfo As clsDataType.SapTaskLinesInfo
    Public Shared TaskLinesOnWork As clsDataType.SapTaskLinesSingle
    Public Shared IndexTaskLinesOnWork As Long

    ' OGGETTO DATA TABLE PER VISUALIZZARE DATI NELLE GRIGLIE
    Public Shared objDataTableJobTaskLines As New DataTable

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



            If (Not (objDataTableJobTaskLines Is Nothing)) Then
                objDataTableJobTaskLines.Rows.Clear()
            End If

            RetCode += clsSapUtility.ResetSapTaskLinesInfoStruct(TaskLinesInfo)
            RetCode += clsSapUtility.ResetSapTaskLinesSingleStruct(TaskLinesOnWork)

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
    Public Shared Function CreateDateTableForJobTaskLines() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia ForkLift
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            CreateDateTableForJobTaskLines = 1 'init at error

            clsDataType.CreateDateTableForTaskLines(objDataTableJobTaskLines)

            CreateDateTableForJobTaskLines = RetCode


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForJobTaskLines = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetTotalNumberOfTaskLines() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetTotalNumberOfTaskLines = 0 'INIT 

            If (objDataTableJobTaskLines Is Nothing) Then
                Exit Function
            End If
            If (objDataTableJobTaskLines.Rows Is Nothing) Then
                Exit Function
            End If

            GetTotalNumberOfTaskLines = objDataTableJobTaskLines.Rows.Count

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetTotalNumberOfTaskLines = 0
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetNumOfJobActiveTaskLines(ByRef inNrWmsJobs As String) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        Dim WorkDataRow As DataRow
        Dim WorkNrWmsJobs As String
        Dim NumOfJobActiveTaskLines As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetNumOfJobActiveTaskLines = 0 'INIT 

            If (objDataTableJobTaskLines Is Nothing) Then
                Exit Function
            End If
            If (objDataTableJobTaskLines.Rows Is Nothing) Then
                Exit Function
            End If

            If (clsUtility.IsStringValid(inNrWmsJobs, True) = False) Then
                Exit Function
            End If

            For Each WorkDataRow In objDataTableJobTaskLines.Rows()

                'SE PASSATO UN JOB DEVO CARICARE LA PRIMA  TASK LINES DEL JOB
                If (clsUtility.IsStringValid(inNrWmsJobs, True) = True) Then
                    WorkNrWmsJobs = clsUtility.GetDataRowItem(WorkDataRow, "ZNR_WMS_JOBS", "0")
                    If (UCase(inNrWmsJobs) = UCase(WorkNrWmsJobs)) Then
                        NumOfJobActiveTaskLines = NumOfJobActiveTaskLines + 1
                    End If
                End If

            Next

            GetNumOfJobActiveTaskLines = NumOfJobActiveTaskLines

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetNumOfJobActiveTaskLines = 0
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function SetCurrentTaskLinesOnWork(ByRef inNrWmsJobs As String, ByRef outSetTaskLinesOk As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkNrWmsJobs As String = ""
        Dim WorkDataRow As DataRow
        Dim WorkSapTaskLinesSingle As clsDataType.SapTaskLinesSingle
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            SetCurrentTaskLinesOnWork = 1 'INIT AT ERROR

            outSetTaskLinesOk = False 'init

            If (objDataTableJobTaskLines Is Nothing) Then
                SetCurrentTaskLinesOnWork = RetCode
                Exit Function
            End If

            If (objDataTableJobTaskLines.Rows.Count <= 0) Then
                SetCurrentTaskLinesOnWork = RetCode
                Exit Function
            End If

            IndexTaskLinesOnWork = 0
            For Each WorkDataRow In objDataTableJobTaskLines.Rows()

                'SE PASSATO UN JOB DEVO CARICARE LA PRIMA  TASK LINES DEL JOB
                If (clsUtility.IsStringValid(inNrWmsJobs, True) = True) Then
                    WorkNrWmsJobs = clsUtility.GetDataRowItem(WorkDataRow, "ZNR_WMS_JOBS", "0")
                    If (UCase(inNrWmsJobs) <> UCase(WorkNrWmsJobs)) Then
                        Continue For
                    End If
                End If

                'RECUPERO  I DATI NELLA STRUTTURA
                RetCode = FromTaskLinesDataRowToSapTaskLinesSingle(WorkDataRow, WorkSapTaskLinesSingle, False)
                If (RetCode <> 0) Then Continue For

                IndexTaskLinesOnWork = IndexTaskLinesOnWork + 1
                If (WorkSapTaskLinesSingle.IdTaskLinesStatus < clsWmsJob.cstIdJobStatus_Terminato) And (WorkSapTaskLinesSingle.QtaJobRichiestaInUdmBase > WorkSapTaskLinesSingle.QtaPrelevataInUdMBase) Then
                    TaskLinesOnWork = WorkSapTaskLinesSingle
                    outSetTaskLinesOk = True
                    Exit For
                End If
            Next

            SetCurrentTaskLinesOnWork = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            SetCurrentTaskLinesOnWork = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetAllTaskLinesYetToExecute(ByRef inNrWmsJobs As String, ByRef outFoundSomeTaskLines As Boolean, ByRef outDataTableTaskLinesYetToExecute As DataTable) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkNrWmsJobs As String = ""
        Dim WorkDataRow As DataRow
        Dim WorkSapTaskLinesSingle As clsDataType.SapTaskLinesSingle
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetAllTaskLinesYetToExecute = 1 'INIT AT ERROR

            outFoundSomeTaskLines = False 'init

            If (objDataTableJobTaskLines Is Nothing) Then
                GetAllTaskLinesYetToExecute = RetCode
                Exit Function
            End If

            If (objDataTableJobTaskLines.Rows Is Nothing) Then
                GetAllTaskLinesYetToExecute = RetCode
                Exit Function
            End If

            If (objDataTableJobTaskLines.Rows.Count <= 0) Then
                GetAllTaskLinesYetToExecute = RetCode
                Exit Function
            End If

            outDataTableTaskLinesYetToExecute = objDataTableJobTaskLines.Clone
            outDataTableTaskLinesYetToExecute.Rows.Clear()

            IndexTaskLinesOnWork = 0
            For Each WorkDataRow In objDataTableJobTaskLines.Rows()

                'SE PASSATO UN JOB DEVO CARICARE LA PRIMA  TASK LINES DEL JOB
                If (clsUtility.IsStringValid(inNrWmsJobs, True) = True) Then
                    WorkNrWmsJobs = clsUtility.GetDataRowItem(WorkDataRow, "ZNR_WMS_JOBS", "0")
                    If (UCase(inNrWmsJobs) <> UCase(WorkNrWmsJobs)) Then
                        Continue For
                    End If
                End If

                'RECUPERO  I DATI NELLA STRUTTURA
                RetCode = FromTaskLinesDataRowToSapTaskLinesSingle(WorkDataRow, WorkSapTaskLinesSingle, False)
                If (RetCode <> 0) Then Continue For

                IndexTaskLinesOnWork = IndexTaskLinesOnWork + 1
                If (WorkSapTaskLinesSingle.IdTaskLinesStatus < clsWmsJob.cstIdJobStatus_Terminato) And (WorkSapTaskLinesSingle.QtaJobRichiestaInUdmBase > WorkSapTaskLinesSingle.QtaPrelevataInUdMBase) Then

                    outFoundSomeTaskLines = True

                    'RITORNO IL DATA  TABLE CON LE TASK LINES ANCORA DA ESEGUIRE
                    outDataTableTaskLinesYetToExecute.ImportRow(WorkDataRow)
                End If
            Next

            GetAllTaskLinesYetToExecute = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetAllTaskLinesYetToExecute = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Public Shared Function GetTaskLinesOnWorkQtyToPick(ByRef outQtyToPick As Double, ByRef outQtaJobRichiestaTaskLine As Double, ByRef outQtaPrelevataTaskLine As Double) As Long
        ' ************************************************************
        ' DESCRIZIONE : RITORNA LA  QTA  DI MATERIALE  ANCORA DA PRELEVARE 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            GetTaskLinesOnWorkQtyToPick = 1 'init at error

            outQtyToPick = 0
            outQtaJobRichiestaTaskLine = 0
            outQtaPrelevataTaskLine = 0

            If (TaskLinesOnWork.NrTaskLines <= 0) Or (TaskLinesOnWork.NrWmsJobs <= 0) Then
                Exit Function
            End If

            Select Case TaskLinesOnWork.PickFullPartialType
                Case cstTaskLinesPickType_FullPallet
                    outQtaJobRichiestaTaskLine = TaskLinesOnWork.QtaJobRichiestaInUdmConsegna
                    outQtaPrelevataTaskLine = TaskLinesOnWork.QtaPrelevataInUdMConsegna
                    If (TaskLinesOnWork.QtaJobRichiestaInUdmConsegna >= TaskLinesOnWork.QtaPrelevataInUdMConsegna) Then
                        outQtyToPick = TaskLinesOnWork.QtaJobRichiestaInUdmConsegna - TaskLinesOnWork.QtaPrelevataInUdMConsegna
                    Else
                        outQtyToPick = 0
                    End If
                Case cstTaskLinesPickType_PartialPallet
                    outQtaJobRichiestaTaskLine = TaskLinesOnWork.QtaJobRichiestaPartialPallet
                    outQtaPrelevataTaskLine = TaskLinesOnWork.QtaPrelevataPartialPallet
                    If (TaskLinesOnWork.QtaJobRichiestaPartialPallet >= TaskLinesOnWork.QtaPrelevataPartialPallet) Then
                        outQtyToPick = TaskLinesOnWork.QtaJobRichiestaPartialPallet - TaskLinesOnWork.QtaPrelevataPartialPallet
                    Else
                        outQtyToPick = 0
                    End If
                Case cstTaskLinesPickType_PickPieces
                    outQtaJobRichiestaTaskLine = TaskLinesOnWork.QtaJobRichiestaSfusiInPZ
                    outQtaPrelevataTaskLine = TaskLinesOnWork.QtaPrelevataSfusi
                    If (TaskLinesOnWork.QtaJobRichiestaSfusiInPZ >= TaskLinesOnWork.QtaPrelevataSfusi) Then
                        outQtyToPick = TaskLinesOnWork.QtaJobRichiestaSfusiInPZ - TaskLinesOnWork.QtaPrelevataSfusi
                    Else
                        outQtyToPick = 0
                    End If
            End Select

            GetTaskLinesOnWorkQtyToPick = RetCode


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetTaskLinesOnWorkQtyToPick = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetIndexDataRowTaskListOnWork(ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : ritorna un DATASET con un ELENCO DI JOBSGROUPS
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        Dim WorkDataRow As DataRow
        Dim IndexDataRow As Long
        Dim WorkZNR_TASK_LINES As String
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetIndexDataRowTaskListOnWork = -1 'init at error

            If (objDataTableJobTaskLines Is Nothing) Then
                Exit Function
            End If
            If (objDataTableJobTaskLines.Rows Is Nothing) Then
                Exit Function
            End If
            If (objDataTableJobTaskLines.Rows.Count <= 0) Then
                Exit Function
            End If

            If (clsUtility.IsStringValid(TaskLinesOnWork.NrTaskLines, True) = False) Then
                Exit Function
            End If

            IndexDataRow = -1
            For Each WorkDataRow In objDataTableJobTaskLines.Rows
                IndexDataRow = IndexDataRow + 1
                WorkZNR_TASK_LINES = clsUtility.GetDataRowItem(WorkDataRow, "ZNR_TASK_LINES", "")
                If (WorkZNR_TASK_LINES = TaskLinesOnWork.NrTaskLines) Then
                    GetIndexDataRowTaskListOnWork = IndexDataRow
                    Exit Function
                End If
            Next

            GetIndexDataRowTaskListOnWork = -1

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetIndexDataRowTaskListOnWork = -1 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function FromTaskLinesDataRowToSapTaskLinesSingle(ByRef inDataRow As DataRow, ByRef outSapTaskLinesSingle As clsDataType.SapTaskLinesSingle, ByVal inShowMessageBox As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            FromTaskLinesDataRowToSapTaskLinesSingle = 1 'INIT AT ERROR

            If (inDataRow Is Nothing) Then
                RetCode = 10
                FromTaskLinesDataRowToSapTaskLinesSingle = RetCode
                Exit Function
            End If

            outSapTaskLinesSingle.NrWmsJobs = clsUtility.GetDataRowItem(inDataRow, "ZNR_WMS_JOBS", "0")
            outSapTaskLinesSingle.NrTaskLines = clsUtility.GetDataRowItem(inDataRow, "ZNR_TASK_LINES", "")
            outSapTaskLinesSingle.TaskLinesSequence = clsUtility.GetDataRowItem(inDataRow, "ZTASK_LINES_SEQ", "")
            outSapTaskLinesSingle.PickFullPartialType = clsUtility.GetDataRowItem(inDataRow, "ZPICKFULLPARTIAL", "")
            outSapTaskLinesSingle.IdTaskLinesStatus = clsUtility.GetDataRowItem(inDataRow, "IDSTATUS", "0")
            'outSapTaskLinesSingle.DataCreazione = clsUtility.GetDataRowItem(inDataRow, "Charg", "")
            'outSapTaskLinesSingle.OraCreazione = clsUtility.GetDataRowItem(inDataRow, "Verme", "")

            outSapTaskLinesSingle.QtaJobRichiestaInUdmBase = clsUtility.GetDataRowItem(inDataRow, "ZQTAPK_ORI_BASE", "0")
            outSapTaskLinesSingle.UnitaDiMisuraBase = clsUtility.GetDataRowItem(inDataRow, "MEINS_BASE", "")

            outSapTaskLinesSingle.QtaJobRichiestaInUdmConsegna = clsUtility.GetDataRowItem(inDataRow, "ZQTAPK_ORI_CONS", "0")
            outSapTaskLinesSingle.UnitaDiMisuraConsegna = clsUtility.GetDataRowItem(inDataRow, "MEINS_CONS", "")

            outSapTaskLinesSingle.QtaJobRichiestaFullPallet = clsUtility.GetDataRowItem(inDataRow, "ZQTAPK_FULL_PALL", "0")
            outSapTaskLinesSingle.QtaJobRichiestaPartialPallet = clsUtility.GetDataRowItem(inDataRow, "ZQTAPK_PARTIAL", "0")
            outSapTaskLinesSingle.QtaJobRichiestaSfusiInPZ = clsUtility.GetDataRowItem(inDataRow, "ZQTAPK_SFUSI_PZ", "0")

            outSapTaskLinesSingle.QtaPrelevataInUdMBase = clsUtility.GetDataRowItem(inDataRow, "ZQTA_PREL_BASE", "0")
            outSapTaskLinesSingle.UdmQtaPrelevataInUdMBase = clsUtility.GetDataRowItem(inDataRow, "UDM_QTAPR_BASE", "")
            outSapTaskLinesSingle.QtaPrelevataInUdMConsegna = clsUtility.GetDataRowItem(inDataRow, "ZQTA_PREL_CONS", "0")
            outSapTaskLinesSingle.UdmQtaPrelevataInUdMConsegna = clsUtility.GetDataRowItem(inDataRow, "UDM_QTAPR_CONS", "")
            outSapTaskLinesSingle.QtaPrelevataFullPallet = clsUtility.GetDataRowItem(inDataRow, "ZQTA_PREL_FULL", "0")
            outSapTaskLinesSingle.QtaPrelevataPartialPallet = clsUtility.GetDataRowItem(inDataRow, "ZQTA_PREL_PARTIA", "0")
            outSapTaskLinesSingle.QtaPrelevataSfusi = clsUtility.GetDataRowItem(inDataRow, "ZQTA_PREL_SF", "0")
            outSapTaskLinesSingle.QtaPrelevataInUdMPezzo = clsUtility.GetDataRowItem(inDataRow, "ZQTA_PREL_PZ", "0")
            outSapTaskLinesSingle.PesoTotaleMaterialeTaskLine_Kg = clsUtility.GetDataRowItem(inDataRow, "ZWMS_PESOMAT_EU", "0")
            outSapTaskLinesSingle.UdmPesoKg = clsUtility.GetDataRowItem(inDataRow, "GEWEI_EU", "")
            outSapTaskLinesSingle.PesoTotaleMaterialeTaskLine_Lb = clsUtility.GetDataRowItem(inDataRow, "ZWMS_PESOMAT_USA", "0")
            outSapTaskLinesSingle.UdmPesoLb = clsUtility.GetDataRowItem(inDataRow, "GEWEI_USA", "")
            outSapTaskLinesSingle.IdCarrellistaEsecuzione = clsUtility.GetDataRowItem(inDataRow, "USERID_RF", "")
            outSapTaskLinesSingle.UnitaDiMisuraPezzo = clsUtility.GetDataRowItem(inDataRow, "MEINS_PZ", "")


            FromTaskLinesDataRowToSapTaskLinesSingle = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ShowTaskLinesLabelInfoForUserString() As String

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ShowTaskLinesLabelInfoForUserString = ""

            ShowTaskLinesLabelInfoForUserString = clsAppTranslation.GetSingleParameterValue(1484, "", "TASK") + " (" + Trim(Str(IndexTaskLinesOnWork)) + "/" + Trim(Str(GetNumOfJobActiveTaskLines(clsWmsJob.WmsJob.NrWmsJobs))) + ") "
            ShowTaskLinesLabelInfoForUserString = ShowTaskLinesLabelInfoForUserString + clsAppTranslation.GetSingleParameterValue(1515, "", "TASK#:") + " "

            'If (TaskLinesOnWork.NrTaskLines <= 0) Or (TaskLinesOnWork.NrWmsJobs <= 0) Then
            If (clsUtility.IsStringValid(TaskLinesOnWork.NrTaskLines, True) = False) Or (TaskLinesOnWork.NrWmsJobs <= 0) Then
                ShowTaskLinesLabelInfoForUserString = ShowTaskLinesLabelInfoForUserString + clsAppTranslation.GetSingleParameterValue(1480, "", "NESSUNO")
                Exit Function
            End If

            ShowTaskLinesLabelInfoForUserString = ShowTaskLinesLabelInfoForUserString + Trim(Str(TaskLinesOnWork.NrTaskLines))

            Select Case TaskLinesOnWork.PickFullPartialType
                Case "PF"
                    ShowTaskLinesLabelInfoForUserString = ShowTaskLinesLabelInfoForUserString + " - " + clsAppTranslation.GetSingleParameterValue(1503, "", "FULL PALLET")
                    ShowTaskLinesLabelInfoForUserString = ShowTaskLinesLabelInfoForUserString + " " + " (" + Trim(Str(TaskLinesOnWork.QtaJobRichiestaFullPallet)) + " PL/" + Trim(Str(TaskLinesOnWork.QtaJobRichiestaPartialPallet)) + " " + UCase(TaskLinesOnWork.UnitaDiMisuraConsegna) + "/" + Trim(Str(TaskLinesOnWork.QtaJobRichiestaSfusiInPZ)) + " " + TaskLinesOnWork.UnitaDiMisuraPezzo + ") "
                Case "PP"
                    ShowTaskLinesLabelInfoForUserString = ShowTaskLinesLabelInfoForUserString + " " + clsAppTranslation.GetSingleParameterValue(1511, "", "PARTIAL PALLET")
                    ShowTaskLinesLabelInfoForUserString = ShowTaskLinesLabelInfoForUserString + " " + " (" + Trim(Str(TaskLinesOnWork.QtaJobRichiestaFullPallet)) + " PL/" + Trim(Str(TaskLinesOnWork.QtaJobRichiestaPartialPallet)) + " " + UCase(TaskLinesOnWork.UnitaDiMisuraConsegna) + "/" + Trim(Str(TaskLinesOnWork.QtaJobRichiestaSfusiInPZ)) + " " + TaskLinesOnWork.UnitaDiMisuraPezzo + ") "
                Case "PZ"
                    ShowTaskLinesLabelInfoForUserString = ShowTaskLinesLabelInfoForUserString + " " + clsAppTranslation.GetSingleParameterValue(1486, "", "SFUSI")
                    ShowTaskLinesLabelInfoForUserString = ShowTaskLinesLabelInfoForUserString + " " + " (" + Trim(Str(TaskLinesOnWork.QtaJobRichiestaFullPallet)) + " PL/" + Trim(Str(TaskLinesOnWork.QtaJobRichiestaPartialPallet)) + " " + UCase(TaskLinesOnWork.UnitaDiMisuraConsegna) + "/" + Trim(Str(TaskLinesOnWork.QtaJobRichiestaSfusiInPZ)) + " " + TaskLinesOnWork.UnitaDiMisuraPezzo + ") "
            End Select

            ShowTaskLinesLabelInfoForUserString = ShowTaskLinesLabelInfoForUserString + " - " + clsAppTranslation.GetSingleParameterValue(1504, "", "PESO MATERIALE") + ":" + Trim(Str(TaskLinesOnWork.PesoTotaleMaterialeTaskLine_Lb)) + " " + Trim(TaskLinesOnWork.UdmPesoLb)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ShowTaskLinesLabelInfoForUserString = "" 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function CheckIfAllTaskLinesAreFinish(ByRef inNrWmsJobs As String, ByRef outAllTaskLinesAreFinish As Boolean, ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : verifica se la missione richiede l'immissione della conferma della QTA di prodotto prelevato
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim WorkNrWmsJobs As String = ""
        Dim WorkDataRow As DataRow
        Dim WorkIdTaskLinesStatus As String = ""
        Dim FlagOneTaskNotFinish As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            CheckIfAllTaskLinesAreFinish = 1 'init at error

            outAllTaskLinesAreFinish = False


            If (objDataTableJobTaskLines Is Nothing) Then
                outAllTaskLinesAreFinish = True
                RetCode = 0 '>>> CONDIZIONE DI NESSUN ERRORE
                CheckIfAllTaskLinesAreFinish = RetCode
                Exit Function
            End If
            If (objDataTableJobTaskLines.Rows Is Nothing) Then
                outAllTaskLinesAreFinish = True
                RetCode = 0 '>>> CONDIZIONE DI NESSUN ERRORE
                CheckIfAllTaskLinesAreFinish = RetCode
                Exit Function
            End If

            If (objDataTableJobTaskLines.Rows.Count <= 0) Then
                outAllTaskLinesAreFinish = True
                RetCode = 0 '>>> CONDIZIONE DI NESSUN ERRORE
                CheckIfAllTaskLinesAreFinish = RetCode
                Exit Function
            End If

            FlagOneTaskNotFinish = False
            For Each WorkDataRow In objDataTableJobTaskLines.Rows
                'SE PASSATO UN JOB DEVO VERIFICARE SOLO LE TASK LINES DEL JOB
                If (clsUtility.IsStringValid(inNrWmsJobs, True) = True) Then
                    WorkNrWmsJobs = clsUtility.GetDataRowItem(WorkDataRow, "ZNR_WMS_JOBS", "0")
                    If (UCase(inNrWmsJobs) <> UCase(WorkNrWmsJobs)) Then
                        Continue For
                    End If
                End If

                WorkIdTaskLinesStatus = clsUtility.GetDataRowItem(WorkDataRow, "IDSTATUS", "")
                If (WorkIdTaskLinesStatus < clsWmsJob.cstIdJobStatus_Terminato) Then
                    FlagOneTaskNotFinish = True
                    Exit For
                End If
            Next

            'SE TUTTI TERMINATI SETTO IL FLAG
            If (FlagOneTaskNotFinish = False) Then
                outAllTaskLinesAreFinish = True
                RetCode = 0 '>>> CONDIZIONE DI NESSUN ERRORE
                CheckIfAllTaskLinesAreFinish = RetCode
                Exit Function
            End If

            CheckIfAllTaskLinesAreFinish = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckIfAllTaskLinesAreFinish = 1000 'CASO DI CATCH
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CheckIfTaskLinesOnWorkIsFinish(ByRef outTaskLinesOnWorkIsFinish As Boolean, ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : verifica se la TASK LINE attiva e' terminata
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            CheckIfTaskLinesOnWorkIsFinish = 1 'init at error

            outTaskLinesOnWorkIsFinish = False


            If (TaskLinesOnWork.NrTaskLines <= 0) Then
                outTaskLinesOnWorkIsFinish = True
                RetCode = 0 '>>> CONDIZIONE DI NESSUN ERRORE
                CheckIfTaskLinesOnWorkIsFinish = RetCode
                Exit Function
            End If

            If (TaskLinesOnWork.NrTaskLines > 0) Then
                If (TaskLinesOnWork.IdTaskLinesStatus >= clsWmsJob.cstIdJobStatus_Terminato) Then
                    outTaskLinesOnWorkIsFinish = True
                    RetCode = 0 '>>> CONDIZIONE DI NESSUN ERRORE
                    CheckIfTaskLinesOnWorkIsFinish = RetCode
                    Exit Function
                End If
            End If

            CheckIfTaskLinesOnWorkIsFinish = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckIfTaskLinesOnWorkIsFinish = 1000 'CASO DI CATCH
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function CheckIfTaskLinesOnWorkIsStarted(ByRef outTaskLinesOnWorkIsStarted As Boolean, ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : verifica se la TASK LINE attiva e' terminata
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            CheckIfTaskLinesOnWorkIsStarted = 1 'init at error

            outTaskLinesOnWorkIsStarted = False


            If (TaskLinesOnWork.NrTaskLines <= 0) Then
                outTaskLinesOnWorkIsStarted = False
                RetCode = 0 '>>> CONDIZIONE DI NESSUN ERRORE
                CheckIfTaskLinesOnWorkIsStarted = RetCode
                Exit Function
            End If

            If (TaskLinesOnWork.NrTaskLines > 0) Then
                If (TaskLinesOnWork.IdTaskLinesStatus < clsWmsJob.cstIdJobStatus_Terminato) Then
                    If (TaskLinesOnWork.QtaPrelevataInUdMConsegna > 0) Then
                        outTaskLinesOnWorkIsStarted = True
                        RetCode = 0 '>>> CONDIZIONE DI NESSUN ERRORE
                        CheckIfTaskLinesOnWorkIsStarted = RetCode
                        Exit Function
                    End If
                End If
            End If

            CheckIfTaskLinesOnWorkIsStarted = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckIfTaskLinesOnWorkIsStarted = 1000 'CASO DI CATCH
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CheckIfTaskLinesFullPalletNeedDrop(ByRef outTaskLinesOnWorkNeedDrop As Boolean, ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : verifica se la TASK LINE attiva e' terminata
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            CheckIfTaskLinesFullPalletNeedDrop = 1 'init at error

            outTaskLinesOnWorkNeedDrop = False


            If (TaskLinesOnWork.NrTaskLines <= 0) Then
                outTaskLinesOnWorkNeedDrop = False
                RetCode = 0 '>>> CONDIZIONE DI NESSUN ERRORE
                CheckIfTaskLinesFullPalletNeedDrop = RetCode
                Exit Function
            End If

            If (TaskLinesOnWork.NrTaskLines > 0) Then
                If (TaskLinesOnWork.PickFullPartialType = cstTaskLinesPickType_FullPallet) Then
                    outTaskLinesOnWorkNeedDrop = True
                    RetCode = 0 '>>> CONDIZIONE DI NESSUN ERRORE
                    CheckIfTaskLinesFullPalletNeedDrop = RetCode
                    Exit Function
                End If
            End If

            CheckIfTaskLinesFullPalletNeedDrop = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckIfTaskLinesFullPalletNeedDrop = 1000 'CASO DI CATCH
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    'Public Shared Function RefreshDateTableForForkLiftInfo() As Long
    '    ' ************************************************************
    '    ' DESCRIZIONE : ESEGUE IL REFRESH DEI DATI DELLE USER INFORMATION
    '    ' ************************************************************

    '    '**************************************
    '    'HERE PUT DECLARATION OF LOCAL VARIABLE
    '    Dim RetCode As Long
    '    Dim WorkRow As DataRow
    '    Dim WorkPropertyId As String = ""
    '    Dim WorkPropertyValue As String
    '    '**************************************
    '    Try 'HERE PUT NORMAL EXECUTION CODE
    '        '**************************************

    '        RefreshDateTableForForkLiftInfo = 1 'init at error

    '        If (objDataTableForkLift Is Nothing) Then Exit Function

    '        If (objDataTableForkLift.Rows.Count = 0) Then Exit Function

    '        For Each WorkRow In objDataTableForkLift.Rows
    '            WorkPropertyId = WorkRow.Item("PropertyId")
    '            Select Case UCase(WorkPropertyId)
    '                Case "MANDT"
    '                    WorkPropertyValue = SapWmsUser.MANDT
    '                Case "MODULE_AREA"
    '                    WorkPropertyValue = SapWmsUser.MODULE_AREA
    '                Case "PROGNAME"
    '                    WorkPropertyValue = SapWmsUser.PROGNAME
    '                Case "USERID"
    '                    WorkPropertyValue = SapWmsUser.USERID
    '                Case "PROFID"
    '                    WorkPropertyValue = SapWmsUser.PROFID
    '                Case "NAME_FIRST"
    '                    WorkPropertyValue = SapWmsUser.NAME_FIRST
    '                Case "NAME_LAST"
    '                    WorkPropertyValue = SapWmsUser.NAME_LAST
    '                Case "BCDA1"
    '                    WorkPropertyValue = SapWmsUser.BCDA1
    '                Case "MOB_NUMBER"
    '                    WorkPropertyValue = SapWmsUser.MOB_NUMBER
    '                Case "EMAIL"
    '                    WorkPropertyValue = SapWmsUser.EMAIL
    '                Case "DESCRIPTION"
    '                    WorkPropertyValue = SapWmsUser.DESCRIPTION
    '                Case "ZCARR"
    '                    WorkPropertyValue = SapWmsUser.DESCRIPTION
    '                Case "SPEC1"
    '                    'WorkPropertyValue = SapWmsUser.Spec1
    '                Case "SPEC2"
    '                    'WorkPropertyValue = SapWmsUser.Spec2
    '                Case "SPEC3"
    '                    'WorkPropertyValue = SapWmsUser.Spec3
    '                Case "SPEC4"
    '                    'WorkPropertyValue = SapWmsUser.Spec4
    '                Case "SPEC5"
    '                    'WorkPropertyValue = SapWmsUser.Spec5
    '                Case Else
    '                    WorkPropertyValue = "NO DATA"
    '            End Select
    '            WorkRow.Item("PropertyValue") = WorkPropertyValue
    '        Next

    '        RefreshDateTableForForkLiftInfo = RetCode

    '        '**************************************
    '    Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
    '        RefreshDateTableForForkLiftInfo = 1000 'IL THREAD E' USCITO DAL LOOP
    '        'LOG ERROR CONDITION
    '        clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
    '        '**************************************
    '    Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

    '    End Try
    'End Function


End Class
