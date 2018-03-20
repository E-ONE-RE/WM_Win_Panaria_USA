' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 24/10/2011
' DATA MODIFICA     : 24/10/2011
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la funzione di selezione di un CODICE MATERIALE
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility

Public Class clsSelezioneCodiceMateriale


    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsSelezioneCodiceMateriale"


    'VALORI DI FILTRO PER LA VISUALIZZAZIONE DEI TIPI MAGAZZINO
    Public Shared FilterDivisione As String
    Public Shared FilterNumMag As String
    Public Shared FilterTipiMag As String
    Public Shared FilterUbicazione As String
    Public Shared FilterUnitaMagazzino As String
    Public Shared FilterCodiceMateriale As String

    Public Shared FilterSKU As String

    Public Shared objDataTableSelectCodMateriale As New DataTable
    Public Shared objDataTableSelectCodMatGiacenza As New DataTable

    Public Shared CodiceMaterialeSelezionato As String
    Public Shared GiacenzaSelezionata As clsDataType.SapWmGiacenza
    Public Shared UbicazioneSelezionata As clsDataType.SapWmUbicazione

    Public Shared SourceForm As Form

    Public Shared SelezioneCodiceMaterialeType As clsDataType.SelezioneCodiceMaterialeType
    Public Shared SelectionOnRun As Boolean

    Private Shared SapFunctionError As clsBusinessLogic.SapFunctionError
    Private Shared ErrDescription As String

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

            SelectionOnRun = False

            FilterDivisione = ""
            FilterNumMag = ""
            FilterTipiMag = ""
            FilterUbicazione = ""
            FilterUnitaMagazzino = ""
            FilterCodiceMateriale = ""

            clsSapUtility.ResetGiacenzaStruct(GiacenzaSelezionata)
            clsSapUtility.ResetUbicazioneStruct(UbicazioneSelezionata)

            SelezioneCodiceMaterialeType = clsDataType.SelezioneCodiceMaterialeType.SelezioneCodiceMaterialeTypeGeneric

            If (Not (objDataTableSelectCodMateriale Is Nothing)) Then
                objDataTableSelectCodMateriale.Rows.Clear()
            End If

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
    Public Shared Function ConfermaSelezione(ByRef inSelectForm As Form) As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim MethodRetval As Object
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ConfermaSelezione = 1 'init at error

            If (Not inSelectForm Is Nothing) And (Not SourceForm Is Nothing) Then
#If Not APPLICAZIONE_WIN32 = "SI" Then
                SourceForm.Visible = False
#End If
                RetCode = clsUtility.ExecuteObjectMethod(SourceForm, "ConfermaSelezioneCodiceMateriale", MethodRetval, Nothing)
                RetCode = clsUtility.ExecuteObjectMethod(SourceForm, "Show", MethodRetval, Nothing)
                inSelectForm.Close()
            End If

            SelectionOnRun = False

            ConfermaSelezione = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ConfermaSelezione = 1000 'IL THREAD E' USCITO DAL LOOP
            SelectionOnRun = False
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function SelezionaElemento(ByRef inSourceForm As Form) As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim GetOk As Boolean = False
        Dim GetDataOk As Boolean = False
        Dim WorkUbicazione As clsDataType.SapWmUbicazione
        Dim WorkGiacenza As clsDataType.SapWmGiacenza
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            SelezionaElemento = 1 'init at error

            If (inSourceForm Is Nothing) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(925, "", "Finestra origine non corretta.(Nothing)")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If

            If (FilterDivisione = "") Then
                FilterDivisione = clsUser.GetUserDivisionToUse()
            End If

            If (SelezioneCodiceMaterialeType = clsDataType.SelezioneCodiceMaterialeType.SelezioneCodiceMaterialeTypeGeneric) Then
                If (FilterCodiceMateriale = "") Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(926, "", "Codice Materiale di filtro non corretto.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Function
                End If
            End If

            If (SelezioneCodiceMaterialeType = clsDataType.SelezioneCodiceMaterialeType.SelezioneCodiceMaterialeTypeForUbicazione) Then
                clsSapUtility.ResetUbicazioneStruct(WorkUbicazione) 'init
                clsSapUtility.ResetGiacenzaStruct(WorkGiacenza) 'init
                WorkUbicazione.Divisione = FilterDivisione
                WorkUbicazione.NumeroMagazzino = FilterNumMag
                WorkUbicazione.TipoMagazzino = FilterTipiMag
                WorkUbicazione.Ubicazione = FilterUbicazione
                WorkUbicazione.UnitaMagazzino = FilterUnitaMagazzino
                WorkGiacenza.CodiceMateriale = FilterCodiceMateriale

                WorkGiacenza.Partita = clsInfoGiacenze.FilterPartitaMateriale

                'CHIAMO WS PER OTTENERE I DATI DELLE GIACENZE CON I FILTRI IMPOSTATO
                RetCode = clsSapWS.Call_ZWS_MB_GET_LQUA_GIACENZE(WorkUbicazione, WorkGiacenza, False, 0, clsUser.SapWmsUser.LANGUAGE, GetDataOk, objDataTableSelectCodMatGiacenza, Nothing, Nothing, Nothing, Nothing, SapFunctionError, True)
                If ((GetDataOk <> True) Or (RetCode <> 0)) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(497, "", "Errore in estrazione dati (GET_GET_LQUA).Verificare e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Function
                End If
            Else
                'CHIAMO IL WS PER OTTENELE LE UBICAZIONI CON IL FILTRO ATTIVO
                RetCode = clsSapWS.Call_ZWS_MB_GET_MATERIAL_LIST(FilterCodiceMateriale, FilterDivisione, "", FilterNumMag, FilterSKU, Val(DefaultInfoCodMat_List_MaxNumRowReturned), clsUser.SapWmsUser.LANGUAGE, GetOk, objDataTableSelectCodMateriale, SapFunctionError, True)
                If ((GetOk <> True) Or (RetCode <> 0)) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(912, "", "Errore in ") & " " & clsAppTranslation.GetSingleParameterValue(1156, "", "estrazione dati (GET_MATERIAL_LIST).Verificare e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Function
                End If
            End If


            SelectionOnRun = True

            SourceForm = inSourceForm

            frmSelectCodiceMaterialeForm = New frmSelectCodiceMateriale
            frmSelectCodiceMaterialeForm.Show()

            SelezionaElemento = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            SelezionaElemento = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function CreateDateTable() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTable = 1 'init at error

            Dim WorkWERKS As DataColumn = New DataColumn("WERKS") 'declaring a column named Name
            WorkWERKS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectCodMateriale.Columns.Add(WorkWERKS) 'adding the column to table

            Dim WorkMATNR As DataColumn = New DataColumn("MATNR") 'declaring a column named Name
            WorkMATNR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectCodMateriale.Columns.Add(WorkMATNR) 'adding the column to table

            Dim WorkMAKTG As DataColumn = New DataColumn("MAKTG") 'declaring a column named Name
            WorkMAKTG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectCodMateriale.Columns.Add(WorkMAKTG) 'adding the column to table

            Dim WorkMTART As DataColumn = New DataColumn("MTART") 'declaring a column named Name
            WorkMTART.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectCodMateriale.Columns.Add(WorkMTART) 'adding the column to table

            Dim WorkMATKL As DataColumn = New DataColumn("MATKL") 'declaring a column named Name
            WorkMATKL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectCodMateriale.Columns.Add(WorkMATKL) 'adding the column to table

            Dim WorkMEINS As DataColumn = New DataColumn("MEINS") 'declaring a column named Name
            WorkMEINS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectCodMateriale.Columns.Add(WorkMEINS) 'adding the column to table

            Dim WorkGEWEI As DataColumn = New DataColumn("GEWEI") 'declaring a column named Name
            WorkGEWEI.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectCodMateriale.Columns.Add(WorkGEWEI) 'adding the column to table

            Dim WorkEKGRP As DataColumn = New DataColumn("EKGRP") 'declaring a column named Name
            WorkEKGRP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectCodMateriale.Columns.Add(WorkEKGRP) 'adding the column to table

            Dim WorkBRGEW As DataColumn = New DataColumn("BRGEW") 'declaring a column named Name
            WorkBRGEW.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectCodMateriale.Columns.Add(WorkBRGEW) 'adding the column to table

            Dim WorkNTGEW As DataColumn = New DataColumn("NTGEW") 'declaring a column named Name
            WorkNTGEW.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectCodMateriale.Columns.Add(WorkNTGEW) 'adding the column to table

            Dim WorkVOLUM As DataColumn = New DataColumn("VOLUM") 'declaring a column named Name
            WorkNTGEW.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectCodMateriale.Columns.Add(WorkVOLUM) 'adding the column to table

            Dim WorkVOLEH As DataColumn = New DataColumn("VOLEH") 'declaring a column named Name
            WorkVOLEH.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectCodMateriale.Columns.Add(WorkVOLEH) 'adding the column to table

            CreateDateTable = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTable = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function CreateDateTableCodMatGiacenze() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableCodMatGiacenze = 1 'init at error

            Dim WorkWERKS As DataColumn = New DataColumn("WERKS") 'declaring a column named Name
            WorkWERKS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectCodMatGiacenza.Columns.Add(WorkWERKS) 'adding the column to table

            Dim WorkLGNUM As DataColumn = New DataColumn("LGNUM") 'declaring a column named Name
            WorkLGNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectCodMatGiacenza.Columns.Add(WorkLGNUM) 'adding the column to table

            Dim WorkLGTYP As DataColumn = New DataColumn("LGTYP") 'declaring a column named Name
            WorkLGTYP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectCodMatGiacenza.Columns.Add(WorkLGTYP) 'adding the column to table

            Dim WorkLGPLA As DataColumn = New DataColumn("LGPLA") 'declaring a column named Name
            WorkLGPLA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectCodMatGiacenza.Columns.Add(WorkLGPLA) 'adding the column to table

            Dim WorkLQNUM As DataColumn = New DataColumn("LQNUM") 'declaring a column named Name
            WorkLQNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectCodMatGiacenza.Columns.Add(WorkLQNUM) 'adding the column to table

            Dim WorkMATNR As DataColumn = New DataColumn("MATNR") 'declaring a column named Name
            WorkMATNR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectCodMatGiacenza.Columns.Add(WorkMATNR) 'adding the column to table

            Dim WorkCHARG As DataColumn = New DataColumn("CHARG") 'declaring a column named Name
            WorkCHARG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectCodMatGiacenza.Columns.Add(WorkCHARG) 'adding the column to table

            Dim WorkBESTQ As DataColumn = New DataColumn("BESTQ") 'declaring a column named Name
            WorkBESTQ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectCodMatGiacenza.Columns.Add(WorkBESTQ) 'adding the column to table

            Dim WorkMEINS As DataColumn = New DataColumn("MEINS") 'declaring a column named Name
            WorkMEINS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectCodMatGiacenza.Columns.Add(WorkMEINS) 'adding the column to table

            Dim WorkGESME As DataColumn = New DataColumn("GESME") 'declaring a column named Name
            WorkGESME.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectCodMatGiacenza.Columns.Add(WorkGESME) 'adding the column to table

            Dim WorkVERME As DataColumn = New DataColumn("VERME") 'declaring a column named Name
            WorkVERME.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectCodMatGiacenza.Columns.Add(WorkVERME) 'adding the column to table

            Dim WorkLENUM As DataColumn = New DataColumn("LENUM") 'declaring a column named Name
            WorkLENUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectCodMatGiacenza.Columns.Add(WorkLENUM) 'adding the column to table

            Dim WorkSOBKZ As DataColumn = New DataColumn("SOBKZ") 'declaring a column named Name
            WorkSOBKZ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectCodMatGiacenza.Columns.Add(WorkSOBKZ) 'adding the column to table

            Dim WorkSONUM As DataColumn = New DataColumn("SONUM") 'declaring a column named Name
            WorkSONUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectCodMatGiacenza.Columns.Add(WorkSONUM) 'adding the column to table

            Dim WorkLGORT As DataColumn = New DataColumn("LGORT") 'declaring a column named Name
            WorkLGORT.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectCodMatGiacenza.Columns.Add(WorkLGORT) 'adding the column to table

            CreateDateTableCodMatGiacenze = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableCodMatGiacenze = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
End Class