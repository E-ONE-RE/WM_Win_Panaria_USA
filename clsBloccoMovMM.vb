' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 10/04/2013
' DATA MODIFICA     : 10/04/2013
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa i MOVIMENTI MM di BLOCCO / SBLOCCO DI UNA GIACENZA
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType
Imports clsSapUtility
Imports clsBusinessLogic

Public Class clsBloccoMovMM


    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsBloccoMovMM"


    '>>> TIPO DI BLOCCO
    Public Enum Blocco_Mov_MM_Type
        BloccoMovMM_Type_None = 0
        BloccoMovMM_Type_StockQ = 1
        BloccoMovMM_Type_StockE = 2
        BloccoMovMM_Type_StockR = 3
        BloccoMovMM_Type_StockO = 4
        BloccoMovMM_Type_StockS = 5
    End Enum

    '>>> TIPO DI OPERAZIONE
    Public Enum Blocco_Mov_MM_Operation_Type
        BloccoMovMMOperationType_None = 0
        BloccoMovMMOperationType_Metti = 1
        BloccoMovMMOperationType_Togli = 2
    End Enum

    '>>> TIPO DI RICERCA
    Public Enum Blocco_Mov_MM_Find_Type
        BloccoMovMMFindType_None = 0
        BloccoMovMMFindType_UnitaMagazzino = 1
        BloccoMovMMFindType_Ubicazione = 2
        BloccoMovMMFindType_Materiale = 3
        BloccoMovMMFindType_UbicazioneMateriale = 4
    End Enum


    '*****************************************
    ' >>> PROPRIETA E VARIABILI
    Public Shared SourceUbicazione As clsDataType.SapWmUbicazione
    Public Shared MaterialeGiacenza As clsDataType.SapWmGiacenza

    Public Shared FirstLoadExecuted_Step_1 As Boolean = False
    Public Shared FirstLoadExecuted_Step_2 As Boolean = False
    Public Shared FirstLoadExecuted_Step_3 As Boolean = False
    Public Shared FirstLoadExecuted_Step_4 As Boolean = False
    Public Shared FirstLoadExecuted_Step_5 As Boolean = False

    Public Shared BloccoMovMMOperationType As Blocco_Mov_MM_Operation_Type
    Public Shared BloccoMovMMType As Blocco_Mov_MM_Type
    Public Shared BloccoMovMMFindType As Blocco_Mov_MM_Find_Type

    'OGGETTO DATA TABLE PER VISUALIZZARE DATI NELLE GRIGLIE
    Public Shared objDataTableGiacenzeInfo As New DataTable

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

            RetCode += clsSapUtility.ResetUbicazioneStruct(SourceUbicazione)
            RetCode += clsSapUtility.ResetGiacenzaStruct(MaterialeGiacenza)

            FirstLoadExecuted_Step_1 = False
            FirstLoadExecuted_Step_2 = False
            FirstLoadExecuted_Step_3 = False
            FirstLoadExecuted_Step_4 = False
            FirstLoadExecuted_Step_5 = False

            BloccoMovMMOperationType = Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_None
            BloccoMovMMType = Blocco_Mov_MM_Type.BloccoMovMM_Type_None
            BloccoMovMMFindType = Blocco_Mov_MM_Find_Type.BloccoMovMMFindType_None

            If (Not (objDataTableGiacenzeInfo Is Nothing)) Then
                objDataTableGiacenzeInfo.Rows.Clear()
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
    Public Shared Function ClearForNewPositionRead() As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim MemoCodMateriale As String = ""
        Dim MemoUbicazione As clsDataType.SapWmUbicazione
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ClearForNewPositionRead = 1 'init at error

            FirstLoadExecuted_Step_3 = False
            FirstLoadExecuted_Step_4 = False
            FirstLoadExecuted_Step_5 = False

            MemoUbicazione.Divisione = SourceUbicazione.Divisione
            MemoUbicazione.NumeroMagazzino = SourceUbicazione.NumeroMagazzino

            Select Case clsBloccoMovMM.BloccoMovMMFindType
                Case Blocco_Mov_MM_Find_Type.BloccoMovMMFindType_Materiale
                    MemoCodMateriale = MaterialeGiacenza.CodiceMateriale
                Case Blocco_Mov_MM_Find_Type.BloccoMovMMFindType_Ubicazione
                    MemoUbicazione.Ubicazione = SourceUbicazione.Ubicazione
                Case Blocco_Mov_MM_Find_Type.BloccoMovMMFindType_UnitaMagazzino
                    MemoUbicazione.UnitaMagazzino = SourceUbicazione.UnitaMagazzino
                Case Blocco_Mov_MM_Find_Type.BloccoMovMMFindType_UbicazioneMateriale
                    MemoCodMateriale = MaterialeGiacenza.CodiceMateriale
                    MemoUbicazione.Ubicazione = SourceUbicazione.Ubicazione
            End Select

            RetCode += clsSapUtility.ResetUbicazioneStruct(SourceUbicazione)
            RetCode += clsSapUtility.ResetGiacenzaStruct(MaterialeGiacenza)

            SourceUbicazione.Divisione = MemoUbicazione.Divisione
            SourceUbicazione.NumeroMagazzino = MemoUbicazione.NumeroMagazzino
            SourceUbicazione.Ubicazione = MemoUbicazione.Ubicazione
            SourceUbicazione.UnitaMagazzino = MemoUbicazione.UnitaMagazzino

            MaterialeGiacenza.CodiceMateriale = MemoCodMateriale

            If (Not (objDataTableGiacenzeInfo Is Nothing)) Then
                objDataTableGiacenzeInfo.Rows.Clear()
            End If


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
    Public Shared Function GetNumRecTableGiacenzeInfo() As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetNumRecTableGiacenzeInfo = 0 'init

            If (objDataTableGiacenzeInfo Is Nothing) Then Exit Function

            If (objDataTableGiacenzeInfo.Rows Is Nothing) Then Exit Function

            GetNumRecTableGiacenzeInfo = objDataTableGiacenzeInfo.Rows.Count

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetNumRecTableGiacenzeInfo = 0 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetGiacenzaFromDataRowTableGiacenze(ByVal inIndex As Long) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim WorkDataRow As DataRow
        Dim WorkGiacenza As clsDataType.SapWmGiacenza
        Dim ErrDescription As String
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetGiacenzaFromDataRowTableGiacenze = 1 'init

            If (objDataTableGiacenzeInfo.Rows.Count <= 0) Then
                RetCode = 10
                GetGiacenzaFromDataRowTableGiacenze = RetCode
                Exit Function
            End If

            If (inIndex >= objDataTableGiacenzeInfo.Rows.Count) Then
                RetCode = 20
                GetGiacenzaFromDataRowTableGiacenze = RetCode
                Exit Function
            End If
            WorkDataRow = objDataTableGiacenzeInfo.Rows(inIndex) '>>> usato lo 0
            If (WorkDataRow Is Nothing) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(790, "", "Errore in estrazione dati Giacenza (objDataTableGiacenzeInfo.Rows(0)).") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If
            'RECUPERO I DATI DELLA GIACENZA SELEZIONATA
            RetCode = clsSapUtility.FromGiacenzaDataRowToSapWmGiacenza(WorkDataRow, WorkGiacenza, False)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(605, "", "Errore in estrazione dati Giacenza (FromLquaToWmGiacenza).") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If
            'MEMORIZZO DATI GIACENZA NEI DATI DEL TRASFERIMENTO IN CORSO IMPOSTO I DATI DEL MATERIALE
            MaterialeGiacenza = WorkGiacenza
            SourceUbicazione = WorkGiacenza.UbicazioneInfo

            GetGiacenzaFromDataRowTableGiacenze = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetGiacenzaFromDataRowTableGiacenze = 0 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Public Shared Function CreateDateTableForGiacenze() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForGiacenze = 1 'init at error

            clsDataType.CreateDateTableForGiacenze(objDataTableGiacenzeInfo)

            CreateDateTableForGiacenze = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForGiacenze = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Public Shared Function ExexQueryOfSourceMaterials() As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim ErrDescription As String
        Dim GetDataGiacenzeOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ExexQueryOfSourceMaterials = 1 'init at error

            'VERIFICO LE GIACENZE DELLO STESSO MATERIALE SE POSSO AVERE AMBIGUITA
            RetCode = clsSapWS.Call_ZWS_MB_GET_LQUA_GIACENZE(SourceUbicazione, MaterialeGiacenza, False, 0, clsUser.SapWmsUser.LANGUAGE, GetDataGiacenzeOk, objDataTableGiacenzeInfo, Nothing, Nothing, Nothing, Nothing, SapFunctionError, False)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(291, "", "Errore in estrazione dati giacenza (GET_LQUA).") & vbCrLf & clsAppTranslation.GetSingleParameterValue(292, "", "Verificare filtri e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If
            If (GetDataGiacenzeOk <> True) Or (objDataTableGiacenzeInfo Is Nothing) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(293, "", "Giacenza non presente in STOCK.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(294, "", "Verificare dati e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If

            ExexQueryOfSourceMaterials = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ExexQueryOfSourceMaterials = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
End Class
