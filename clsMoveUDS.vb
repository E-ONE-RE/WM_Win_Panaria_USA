' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 18/07/2011
' DATA MODIFICA     : 18/07/2011
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la funzione di TRASFERIMENTO MATERIALE
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType
Imports clsSapUtility
Imports clsBusinessLogic

Public Class clsMoveUDS


    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsMoveUDS"

    'OGGETTO DATA TABLE PER VISUALIZZARE DATI NELLE GRIGLIE
    Public Shared objDataTableUDSInfo As New DataTable
    Public Shared objDataTableUDCInfo As New DataTable

    Public Shared SourceUbicazione As clsDataType.SapWmUbicazione
    Public Shared DestinationUbicazione As clsDataType.SapWmUbicazione
    Public Shared UdMTrasfList() As clsDataType.SapUDSInfo


    Public Shared UDSOnWork As clsUDS

    Public Shared GiacenzeUbiDestinazione() As clsDataType.SapWmGiacenza

    Public Shared SourceForm As Form

    'MI INDICA CHE TIPO DI TRASFERIMENTO E' ATTIVO : NORMALE, TRASFERIMENTO PER INVENTARIO, ECC
    Public Shared FunctionTransferMaterialType As clsDataType.FunctionTransferMaterialType

    Private Shared SapFunctionError As clsBusinessLogic.SapFunctionError

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

            FunctionTransferMaterialType = clsDataType.FunctionTransferMaterialType.FunctionTransferMaterialTypeNone

            RetCode += clsSapUtility.ResetUbicazioneStruct(SourceUbicazione)
            RetCode += clsSapUtility.ResetUbicazioneStruct(DestinationUbicazione)

            RetCode += ClearUDSInfo()
            RetCode += ClearUDCInfo()


            If (Not UdMTrasfList Is Nothing) Then
                ReDim UdMTrasfList(0)
                UdMTrasfList.Clear(UdMTrasfList, 0, 0)
                UdMTrasfList = Nothing
            End If

            If (Not GiacenzeUbiDestinazione Is Nothing) Then
                ReDim GiacenzeUbiDestinazione(0)
                GiacenzeUbiDestinazione.Clear(GiacenzeUbiDestinazione, 0, 0)
                GiacenzeUbiDestinazione = Nothing
            End If

            SourceForm = Nothing

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

            RetCode += clsSapUtility.ResetUbicazioneStruct(DestinationUbicazione)


            RetCode += ClearUDSInfo()


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
    Public Shared Function Go_To_Original_Menu(ByRef inSourceForm As Form) As Long
        ' ************************************************************
        ' DESCRIZIONE : ritorna al menu chiamante
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Go_To_Original_Menu = 1 'init at error

            If (SourceForm Is Nothing) Then
                RetCode = clsNavigation.Show_Mnu_Main_Trasfer(inSourceForm, True)
                Go_To_Original_Menu = RetCode
                Exit Function
            End If

            Select Case SourceForm.GetType.Name
                Case frmMenuUscitaMerciMain.GetType.Name
                    RetCode = clsNavigation.Show_Mnu_Main_UscitaMerci(inSourceForm, True)
                    Go_To_Original_Menu = RetCode
                    Exit Function
                Case frmMenuTrasferMain.GetType.Name
                    RetCode = clsNavigation.Show_Mnu_Main_Trasfer(inSourceForm, True)
                    Go_To_Original_Menu = RetCode
                    Exit Function
                Case Else
                    RetCode = clsNavigation.Show_Mnu_Main_Trasfer(inSourceForm, True)
                    Go_To_Original_Menu = RetCode
                    Exit Function
            End Select

            Go_To_Original_Menu = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Go_To_Original_Menu = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetNumRecTableGiacenzeInfo() As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetNumRecTableGiacenzeInfo = 0 'init

            If (objDataTableUDSInfo Is Nothing) Then Exit Function

            If (objDataTableUDSInfo.Rows Is Nothing) Then Exit Function

            GetNumRecTableGiacenzeInfo = objDataTableUDSInfo.Rows.Count

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetNumRecTableGiacenzeInfo = 0 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ClearUDSInfo() As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ClearUDSInfo = 1 'init at error

            If (Not (objDataTableUDSInfo Is Nothing)) Then
                objDataTableUDSInfo.Rows.Clear()
            End If

            ClearUDSInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ClearUDSInfo = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ClearUDCInfo() As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ClearUDCInfo = 1 'init at error

            If (Not (objDataTableUDCInfo Is Nothing)) Then
                objDataTableUDCInfo.Rows.Clear()
            End If

            ClearUDCInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ClearUDCInfo = 1000 'IL THREAD E' USCITO DAL LOOP
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

    Public Shared Function CreateDateTableForUDCInfo() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForUDCInfo = 1 'init at error

            clsDataType.CreateDateTableForUDCInfo(objDataTableUDCInfo)

            CreateDateTableForUDCInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForUDCInfo = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ShowSingleUDSInfo(ByVal inSapWmGiacenza As clsDataType.SapUDSInfo, ByVal inDocumentoMaterialeBEM As clsDataType.SapWmDocumentoMateriale, Optional ByVal inShowMode As Long = 0) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim tmpString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ShowSingleUDSInfo = ""

            tmpString += clsAppTranslation.GetSingleParameterValue(1322, "", "UDS:") + clsSapUtility.FormattaStringaUnitaMagazzino(inSapWmGiacenza.UnitaMagazzino)
            tmpString += vbCrLf
 
            tmpString += clsAppTranslation.GetSingleParameterValue(1323, "", "NUM.MAG.:") + inSapWmGiacenza.NumeroMagazzino + " - "
            tmpString += clsAppTranslation.GetSingleParameterValue(1324, "", "UBICAZ.:") + inSapWmGiacenza.TipoMagazzino + " - " + inSapWmGiacenza.Ubicazione
            tmpString += vbCrLf

            tmpString += clsAppTranslation.GetSingleParameterValue(1328, "", "TRASPORTO :") + Trim(Str(inSapWmGiacenza.NrTrasporto)) + " - "
            tmpString += clsAppTranslation.GetSingleParameterValue(1327, "", "CONSEGNA :") + inSapWmGiacenza.Consegna
            tmpString += vbCrLf

            tmpString += clsAppTranslation.GetSingleParameterValue(1449, "", "STOP") + inSapWmGiacenza.StopSequence & "  " & UCase(clsAppTranslation.GetSingleParameterValue(1450, "", "DROP")) + inSapWmGiacenza.DropSequence
            tmpString += vbCrLf


            tmpString += clsAppTranslation.GetSingleParameterValue(1329, "", "COMMITTENTE :") + inSapWmGiacenza.CodicePartnerAg + " - " + inSapWmGiacenza.ZAG_NAME
            tmpString += vbCrLf
            tmpString += clsAppTranslation.GetSingleParameterValue(1330, "", "DESTINATARIO MERCI :") + inSapWmGiacenza.CodicePartnerWE + " - " + inSapWmGiacenza.ZWE_NAME
            tmpString += vbCrLf

            tmpString += clsAppTranslation.GetSingleParameterValue(1242, "", "MISSIONE :") + Trim(Str(inSapWmGiacenza.NrWmsJobs)) + " - " + inSapWmGiacenza.CodiceGruppoMissioni
            tmpString += vbCrLf

            tmpString += clsAppTranslation.GetSingleParameterValue(1659, "", "BAIA STAGING ") + ":" + UCase(inSapWmGiacenza.LGTYP_STAG_DOOR) + " - " + UCase(inSapWmGiacenza.LGPLA_STAG_DOOR)
            tmpString += vbCrLf

            tmpString += clsAppTranslation.GetSingleParameterValue(1536, "", "BAIA DESTINAZIONE ") + ":" + UCase(inSapWmGiacenza.LGTYP_DOCK_DOOR) + " - " + UCase(inSapWmGiacenza.LGPLA_DOCK_DOOR)
            tmpString += vbCrLf


            tmpString += vbCrLf


            ShowSingleUDSInfo = tmpString

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ShowSingleUDSInfo = ""
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function FromDataRowToSapUDSInfoStruct(ByRef inDataRow As DataRow, ByRef outSapUDSInfo As clsDataType.SapUDSInfo, ByVal inShowMessageBox As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            FromDataRowToSapUDSInfoStruct = 1 'INIT AT ERROR

            If (inDataRow Is Nothing) Then
                RetCode = 10
                FromDataRowToSapUDSInfoStruct = RetCode
                Exit Function
            End If

            outSapUDSInfo.Divisione = clsUtility.GetDataRowItem(inDataRow, "WERKS", "")
            outSapUDSInfo.NumeroMagazzino = clsUtility.GetDataRowItem(inDataRow, "LGNUM", "")
            outSapUDSInfo.UnitaMagazzino = clsUtility.GetDataRowItem(inDataRow, "LENUM", "")
            outSapUDSInfo.CodiceMateriale = clsUtility.GetDataRowItem(inDataRow, "MATNR", "")
            outSapUDSInfo.Partita = clsUtility.GetDataRowItem(inDataRow, "CHARG", "")
            outSapUDSInfo.NrWmsJobs = clsUtility.GetDataRowItem(inDataRow, "ZNR_WMS_JOBS", "")
            outSapUDSInfo.TipoMagazzino = clsUtility.GetDataRowItem(inDataRow, "LETYP", "")

            'outSapUDSInfo.QtaPrelevataInUdMBase = clsUtility.GetDataRowItem(inDataRow, "ZQTA_PREL_BASE", "0")
            outSapUDSInfo.UdmQtaPrelevataInUdMBase = clsUtility.GetDataRowItem(inDataRow, "UDM_QTAPR_MEINS", "")
            'outSapUDSInfo.QtaPrelevataInUdMConsegna = clsUtility.GetDataRowItem(inDataRow, "ZQTA_PREL_CONS", "0")
            outSapUDSInfo.UdmQtaPrelevataInUdMConsegna = clsUtility.GetDataRowItem(inDataRow, "UDM_QTAPR_CONS", "")
            'outSapUDSInfo.QtaPrelevataInUdMPezzo = clsUtility.GetDataRowItem(inDataRow, "ZQTA_PREL_PZ", "0")
            outSapUDSInfo.UdmQtaPrelevataInUdMPezzo = clsUtility.GetDataRowItem(inDataRow, "UDM_QTAPR_PZ", "0")

            'outSapUDSInfo.PesoMaterialeNettoEU = clsUtility.GetDataRowItem(inDataRow, "ZWMS_PESOMAT_EU", "0")
            outSapUDSInfo.UnitaDiPesoMatEU = clsUtility.GetDataRowItem(inDataRow, "GEWEI_EU", "0")
            'outSapUDSInfo.PesoMaterialeNettoEU = clsUtility.GetDataRowItem(inDataRow, "ZWMS_PESOMAT_USA", "0")
            outSapUDSInfo.UnitaDiPesoMatEU = clsUtility.GetDataRowItem(inDataRow, "GEWEI_USA", "0")

            outSapUDSInfo.DataCreazione = clsUtility.GetDataRowItem(inDataRow, "DATA_CREAZIONE", Date.MinValue.ToString)
            outSapUDSInfo.OraCreazione = clsUtility.GetDataRowItem(inDataRow, "ORA_CREAZIONE", "")

            outSapUDSInfo.OraCreazione = clsUtility.GetDataRowItem(inDataRow, "DATA_MODIFICA", Date.MinValue.ToString)
            outSapUDSInfo.OraModifica = clsUtility.GetDataRowItem(inDataRow, "ORA_MODIFICA", "")

            outSapUDSInfo.UserIdRFCrea = clsUtility.GetDataRowItem(inDataRow, "USERID_RF_CREA", "")
            outSapUDSInfo.UserIdRFMod = clsUtility.GetDataRowItem(inDataRow, "USERID_RF_MOD", "")
            outSapUDSInfo.UserId = clsUtility.GetDataRowItem(inDataRow, "USERID", "")


            ' !!! DA QUI DA VERIFICARE !!!

            outSapUDSInfo.CodiceGruppoMissioni = clsUtility.GetDataRowItem(inDataRow, "ZNR_WMS_JOBSGRP", "")

            If (clsUtility.GetDataRowItem(inDataRow, "TKNUM", "") = "") Then
                outSapUDSInfo.NrTrasporto = 0
            Else
                outSapUDSInfo.NrTrasporto = Str(clsUtility.GetDataRowItem(inDataRow, "TKNUM", ""))
            End If

            outSapUDSInfo.Consegna = clsUtility.GetDataRowItem(inDataRow, "NUM_CONS_VBELV", "")
            outSapUDSInfo.PosConsegna = clsUtility.GetDataRowItem(inDataRow, "POS_CONS_POSNV", "")
            outSapUDSInfo.StopSequence = clsUtility.GetDataRowItem(inDataRow, "ZWMS_STOP_SEQ", "")
            outSapUDSInfo.DropSequence = clsUtility.GetDataRowItem(inDataRow, "ZWMS_DROP_SEQ", "")

            outSapUDSInfo.Ubicazione = clsUtility.GetDataRowItem(inDataRow, "LGPLA", "")

            outSapUDSInfo.LGNUM_STAG_DOOR = clsUtility.GetDataRowItem(inDataRow, "LGNUM_STAG_DOOR", "")
            outSapUDSInfo.LGTYP_STAG_DOOR = clsUtility.GetDataRowItem(inDataRow, "LGTYP_STAG_DOOR", "")
            outSapUDSInfo.LGPLA_STAG_DOOR = clsUtility.GetDataRowItem(inDataRow, "LGPLA_STAG_DOOR", "")

            outSapUDSInfo.LGNUM_DOCK_DOOR = clsUtility.GetDataRowItem(inDataRow, "LGNUM_DOOCK_DOOR", "")
            outSapUDSInfo.LGTYP_DOCK_DOOR = clsUtility.GetDataRowItem(inDataRow, "LGTYP_DOOCK_DOOR", "")
            outSapUDSInfo.LGPLA_DOCK_DOOR = clsUtility.GetDataRowItem(inDataRow, "LGPLA_DOOCK_DOOR", "")


            'outSapUDSInfo.ZAG_NAME = clsUtility.GetDataRowItem(inDataRow, "ZAG_NAME", "")
            'outSapUDSInfo.ZWE_NAME = clsUtility.GetDataRowItem(inDataRow, "ZWE_NAME", "")

            'outSapUDSInfo.LGPLA_STAG_DOOR = clsUtility.GetDataRowItem(inDataRow, "LGPLA_STAG_DOOR", "")


            FromDataRowToSapUDSInfoStruct = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            FromDataRowToSapUDSInfoStruct = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

End Class
