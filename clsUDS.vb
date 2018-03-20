' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 14/10/2011
' DATA MODIFICA     : 14/10/2011
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la funzione di visualizzare le informazioni delle GIACENZE
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType

Public Class clsUDS


    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsUDS"

    Public Shared UnitaMagazzino As String

    Public Shared UDSInfo As clsDataType.SapUDSInfo

    Public Shared UDSWeightInfo As clsDataType.UDS_WeightInfoStruct


    ' OGGETTO DATA TABLE PER VISUALIZZARE DATI NELLE GRIGLIE
    Public Shared objDataTableUDSInfo As New DataTable

    Public Shared OkUDSMove As Boolean
    Public Shared OkUDSMoveWrapping As Boolean
    Public Shared OkUDSMoveErr As String

    Public Shared OkUDSLoad As Boolean
    Public Shared OkUDSLoadErr As String


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

            UnitaMagazzino = ""

            RetCode = clsSapUtility.ResetUDS_WeightInfoStruct(UDSWeightInfo)

            If (Not (objDataTableUDSInfo Is Nothing)) Then
                objDataTableUDSInfo.Rows.Clear()
            End If

            OkUDSMove = False
            OkUDSMoveWrapping = False
            OkUDSMoveErr = ""

            OkUDSLoad = False
            OkUDSLoadErr = ""

            RetCode = clsSapUtility.ResetSapUDSInfoStruct(UDSInfo)

            'If (Not UDSInfo.Componenti Is Nothing) Then
            '    If (UDSInfo.Componenti.GetLength(0) > 0) Then
            '        ReDim UDSInfo.Componenti(0)
            '        UDSInfo.Componenti.Clear(UDSInfo.Componenti, 0, 0)
            '        UDSInfo.Componenti = Nothing
            '    End If
            'End If

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
    Public Shared Function CreateDateTableForUDSInfo() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForUDSInfo = 1 'init at error

            clsDataType.CreateDateTableForUDSInfo(objDataTableUDSInfo)

            CreateDateTableForUDSInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForUDSInfo = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CheckUdsReachWeightLimitForDrop(ByRef outUdsReachWeightLimitForDrop As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : VERIFICA SE SONO RAGGIUNTI I LIMITI DI PESO
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim PesoRimanenteFromUdsOnWork As Double = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CheckUdsReachWeightLimitForDrop = 1

            outUdsReachWeightLimitForDrop = False

            If (UCase(clsForkLift.CurrentForLift.UdmPeso) = UCase(UDSWeightInfo.UdmPesoLb)) Then
                '>>>> CASO CON PESI IN LIBRE
                If (clsForkLift.CurrentForLift.ForkLiftMaxPesoCarico > UDSWeightInfo.PesoTotaleUDS_Lb) Then
                    PesoRimanenteFromUdsOnWork = clsForkLift.CurrentForLift.ForkLiftMaxPesoCarico - UDSWeightInfo.PesoTotaleUDS_Lb
                Else
                    PesoRimanenteFromUdsOnWork = 0
                End If
            ElseIf (UCase(clsForkLift.CurrentForLift.UdmPeso) = UCase(UDSWeightInfo.UdmPesoKg)) Then
                '>>>> CASO CON PESI IN KG
                If (clsForkLift.CurrentForLift.ForkLiftMaxPesoCarico > UDSWeightInfo.PesoTotaleUDS_Kg) Then
                    PesoRimanenteFromUdsOnWork = clsForkLift.CurrentForLift.ForkLiftMaxPesoCarico - UDSWeightInfo.PesoTotaleUDS_Kg
                Else
                    PesoRimanenteFromUdsOnWork = 0
                End If
            End If

            If (PesoRimanenteFromUdsOnWork <= 0) Then
                outUdsReachWeightLimitForDrop = True
                CheckUdsReachWeightLimitForDrop = RetCode
                Exit Function
            End If

            If (UCase(clsForkLift.CurrentForLift.UdmPeso) = UCase(UDSWeightInfo.UdmPesoLb)) Then
                If (clsWmsJob.TaskLines.TaskLinesOnWork.IdTaskLinesStatus >= clsWmsJob.cstIdJobStatus_Terminato) Then
                    Exit Function
                End If
                If (clsWmsJob.TaskLines.TaskLinesOnWork.PesoTotaleMaterialeTaskLine_Lb > PesoRimanenteFromUdsOnWork) Then
                    outUdsReachWeightLimitForDrop = True
                    CheckUdsReachWeightLimitForDrop = RetCode
                    Exit Function
                End If
            ElseIf (UCase(clsForkLift.CurrentForLift.UdmPeso) = UCase(UDSWeightInfo.UdmPesoKg)) Then
                If (clsWmsJob.TaskLines.TaskLinesOnWork.IdTaskLinesStatus >= clsWmsJob.cstIdJobStatus_Terminato) Then
                    Exit Function
                End If
                If (clsWmsJob.TaskLines.TaskLinesOnWork.PesoTotaleMaterialeTaskLine_Kg > PesoRimanenteFromUdsOnWork) Then
                    outUdsReachWeightLimitForDrop = True
                    CheckUdsReachWeightLimitForDrop = RetCode
                    Exit Function
                End If
            End If

            CheckUdsReachWeightLimitForDrop = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckUdsReachWeightLimitForDrop = 1000 'CATCH
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CheckUdsOkForDrop() As Boolean
        ' ************************************************************
        ' DESCRIZIONE : RITORNA IL CODICE DELL'UDS
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CheckUdsOkForDrop = False

            If (CheckIsValidUDSActive() = True) Then
                CheckUdsOkForDrop = True
            End If


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckUdsOkForDrop = False 'CATCH
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Public Shared Function CheckIsValidUDSActive() As Boolean
        ' ************************************************************
        ' DESCRIZIONE : RITORNA IL CODICE DELL'UDS
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CheckIsValidUDSActive = False

            If (clsUtility.IsStringValid(UnitaMagazzino, True) = True) Then
                CheckIsValidUDSActive = True
            End If


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckIsValidUDSActive = False 'CATCH
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetUnitaMagazzinoUDS() As String
        ' ************************************************************
        ' DESCRIZIONE : RITORNA IL CODICE DELL'UDS
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            GetUnitaMagazzinoUDS = clsSapUtility.FormattaStringaUnitaMagazzino(UnitaMagazzino)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetUnitaMagazzinoUDS = "" 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function RefreshDateTableUDSInfo() As Long
        ' ************************************************************
        ' DESCRIZIONE : ESEGUE IL REFRESH DEI DATI DELLE USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long



        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RefreshDateTableUDSInfo = 1 'init at error

            If (objDataTableUDSInfo Is Nothing) Then Exit Function

            If (objDataTableUDSInfo.Rows.Count = 0) Then Exit Function

            ' If (objDetailsDataRow() Is Nothing) Then Exit Function

            Exit Function

            'For Each WorkRow In objDataTableUDSInfo.Rows
            '    WorkPropertyId = WorkRow.Item("PropertyId")
            '    Select Case UCase(WorkPropertyId)
            '        Case "ODV_VBELN"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ODV_VBELN")
            '        Case "ODV_POSNR"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ODV_POSNR")
            '        Case "ODV_KUNNR_AG"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ODV_KUNNR_AG")
            '        Case "ODV_KUNNR_AG_NAME1"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ODV_KUNNR_AG_NAME1")
            '        Case "ODV_KUNNR_WE"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ODV_KUNNR_WE")
            '        Case "ODV_KUNNR_WE_NAME1"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ODV_KUNNR_WE_NAME1")
            '        Case "ODV_LIFNR_SP"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ODV_LIFNR_SP")
            '        Case "ODV_LIFNR_SP_NAME1"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ODV_LIFNR_SP_NAME1")
            '        Case "ZNR_WMS_JOBS"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZNR_WMS_JOBS")
            '        Case "ZNR_WMS_JOBSGRP"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZNR_WMS_JOBSGRP")
            '        Case "LGNUM"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LGNUM")
            '        Case "LGTYP"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LGTYP")
            '        Case "LGPLA"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LGPLA")
            '        Case "LENUM"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LENUM")
            '            WorkPropertyValue = clsSapUtility.FormattaStringaUnitaMagazzino(WorkPropertyValue)
            '        Case "MATNR"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "MATNR")
            '            WorkPropertyValue = clsSapUtility.FormattaStringaCodiceMateriale(WorkPropertyValue)
            '        Case "CHARG"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "CHARG")
            '        Case "VRKME"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "VRKME")
            '        Case "GESME_CONS"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "GESME_CONS")
            '        Case "VERME_CONS"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "VERME_CONS")
            '        Case "VERME_PZ"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "VERME_PZ")
            '        Case "GESME_PZ"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "GESME_PZ")
            '        Case "MEINS"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "MEINS")
            '        Case "GESME"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "GESME")
            '        Case "VERME"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "VERME")
            '        Case "BESTQ"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "BESTQ")
            '        Case "SOBKZ"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "SOBKZ")
            '        Case "SONUM"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "SONUM")
            '        Case "TBNUM"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "TBNUM")
            '        Case "LQNUM"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LQNUM")
            '        Case "LGORT"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LGORT")
            '        Case "MAKTG"
            '            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "MAKTG")
            '        Case Else
            '            WorkPropertyValue = "NO DATA"
            '    End Select
            '    WorkRow.Item("PropertyValue") = WorkPropertyValue
            'Next

            RefreshDateTableUDSInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            RefreshDateTableUDSInfo = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetNumComponentiUDS() As Long
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetNumComponentiUDS = 0 'init

            If (UDSInfo.Componenti Is Nothing) Then
                Exit Function
            End If

            GetNumComponentiUDS = UDSInfo.Componenti.Length

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetNumComponentiUDS = 0 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Private Shared Function objDetailsDataRow() As Object
        Throw New NotImplementedException
    End Function


End Class
