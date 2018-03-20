' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 23/02/2016
' DATA MODIFICA     : 13/02/2016
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la funzione di CAMBIO UDS
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType
Imports clsSapUtility
Imports clsBusinessLogic

Public Class clsChangeUDS


    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsChangeUDS"

    Public Shared UnitaMagazzino As String

    'OGGETTO DATA TABLE PER VISUALIZZARE DATI NELLE GRIGLIE
    Public Shared objDataTableUDSInfo As New DataTable
    Public Shared objDataTableUDSChangeInfo As New DataTable

    Public Shared SourceUbicazione As clsDataType.SapWmUbicazione
    Public Shared DestinationUbicazione As clsDataType.SapWmUbicazione
    Public Shared UdMTrasfList() As clsDataType.SapUDSInfo

    Public Shared UDSChange() As clsDataType.SapUDSInfo

    Public Shared UDSOnWork As clsUDS

    Public Shared GiacenzeUbiDestinazione() As clsDataType.SapWmGiacenza

    Public Shared SourceForm As Form

    'MI INDICA CHE TIPO DI CAMBIO E' ATTIVO : ADD, MINUS, UNION...ECC
    Public Shared FunctionChangeUDSType As clsDataType.FunctionChangeUDSType


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

            FunctionChangeUDSType = clsDataType.FunctionChangeUDSType.FunctionChnageUDSTypeNone

            RetCode += clsSapUtility.ResetUbicazioneStruct(SourceUbicazione)
            RetCode += clsSapUtility.ResetUbicazioneStruct(DestinationUbicazione)

            RetCode += ClearUDSInfo()

            If (Not UdMTrasfList Is Nothing) Then
                ReDim UdMTrasfList(0)
                UdMTrasfList.Clear(UdMTrasfList, 0, 0)
                UdMTrasfList = Nothing
            End If

            If (Not UDSChange Is Nothing) Then
                ReDim UDSChange(0)
                UDSChange.Clear(UDSChange, 0, 0)
                UDSChange = Nothing
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
                RetCode = clsNavigation.Show_Mnu_Main_UscitaMerci(inSourceForm, True)
                Go_To_Original_Menu = RetCode
                Exit Function
            End If

            Select Case SourceForm.GetType.Name
                Case frmMenuUscitaMerciMain.GetType.Name
                    RetCode = clsNavigation.Show_Mnu_Main_UscitaMerci(inSourceForm, True)
                    Go_To_Original_Menu = RetCode
                    Exit Function
                Case frmMenuTrasferMain.GetType.Name
                    RetCode = clsNavigation.Show_Mnu_Main_UscitaMerci(inSourceForm, True)
                    Go_To_Original_Menu = RetCode
                    Exit Function
                Case Else
                    RetCode = clsNavigation.Show_Mnu_Main_UscitaMerci(inSourceForm, True)
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

            If (Not (objDataTableUDSChangeInfo Is Nothing)) Then
                objDataTableUDSChangeInfo.Rows.Clear()
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

    Public Shared Function CreateDateTableForUDSChangeInfo() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForUDSChangeInfo = 1 'init at error

            clsDataType.CreateDateTableForUDSInfo(objDataTableUDSChangeInfo)

            CreateDateTableForUDSChangeInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForUDSChangeInfo = 1000 'IL THREAD E' USCITO DAL LOOP
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

            tmpString += clsAppTranslation.GetSingleParameterValue(1325, "", "MAT.:") + inSapWmGiacenza.CodiceMaterialeComplessivo + " - "
            tmpString += clsAppTranslation.GetSingleParameterValue(851, "", "PARTITA:") + inSapWmGiacenza.Partita + " - "
            tmpString += clsAppTranslation.GetSingleParameterValue(1326, "", "QTA':") + inSapWmGiacenza.TotQtaPalletInUdMConsegna.ToString + " " + inSapWmGiacenza.UdmQtaPrelevataInUdMConsegna
            tmpString += vbCrLf

            tmpString += clsAppTranslation.GetSingleParameterValue(1327, "", "CONSEGNA :") + inSapWmGiacenza.Consegna + " - "
            tmpString += clsAppTranslation.GetSingleParameterValue(1328, "", "TRASPORTO :") + inSapWmGiacenza.NrTrasporto.ToString
            tmpString += vbCrLf

            tmpString += clsAppTranslation.GetSingleParameterValue(1329, "", "COMMITTENTE :") + inSapWmGiacenza.ZAG_NAME
            tmpString += vbCrLf
            tmpString += clsAppTranslation.GetSingleParameterValue(1330, "", "DESTINATARIO MERCI :") + inSapWmGiacenza.ZWE_NAME
            tmpString += vbCrLf

            tmpString += clsAppTranslation.GetSingleParameterValue(1242, "", "MISSIONE :") + inSapWmGiacenza.NrWmsJobs.ToString + " - " + inSapWmGiacenza.CodiceGruppoMissioni
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

End Class
