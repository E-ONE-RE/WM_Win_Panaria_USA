' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 14/10/2011
' DATA MODIFICA     : 14/10/2011
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la funzione di selezione di una ubicazione
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility

Public Class clsSelezioneUnitaMagazzino


    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsSelezioneUnitaMagazzino"


    'VALORI DI FILTRO PER LA VISUALIZZAZIONE DEI TIPI MAGAZZINO
    Public Shared FilterDivisione As String
    Public Shared FilterNumMag As String
    Public Shared FilterTipiMag As String
    Public Shared FilterUbicazione As String
    Public Shared FilterMateriale As String
    Public Shared FilterPartita As String

    Public Shared objDataTableSelectUnitaMagazzino As New DataTable
    Public Shared UnitaMagazzinoSelezionata As clsDataType.SapWmUbicazione
    Public Shared SourceForm As Form

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
            FilterMateriale = ""
            FilterPartita = ""

            If (Not (objDataTableSelectUnitaMagazzino Is Nothing)) Then
                objDataTableSelectUnitaMagazzino.Rows.Clear()
            End If

            clsSapUtility.ResetUbicazioneStruct(UnitaMagazzinoSelezionata)

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
    Public Shared Function ConfermaSelezioneElemento(ByRef inSelectForm As Form) As Long
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

            ConfermaSelezioneElemento = 1 'init at error

            If (Not inSelectForm Is Nothing) And (Not SourceForm Is Nothing) Then
#If Not APPLICAZIONE_WIN32 = "SI" Then
                SourceForm.Visible = False
#End If
                RetCode = clsUtility.ExecuteObjectMethod(SourceForm, "ConfermaSelezioneUnitaMagazzino", MethodRetval, Nothing)
                RetCode = clsUtility.ExecuteObjectMethod(SourceForm, "Show", MethodRetval, Nothing)
                inSelectForm.Close()
            End If

            SelectionOnRun = False

            ConfermaSelezioneElemento = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ConfermaSelezioneElemento = 1000 'IL THREAD E' USCITO DAL LOOP
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
        Dim WorkUbicazione As clsDataType.SapWmUbicazione
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            SelezionaElemento = 1 'init at error

            If (inSourceForm Is Nothing) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(925, "", "Finestra origine non corretta.(Nothing)")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If

            'If (FilterDivisione = "") Then
            '    ErrDescription = "Divisione di filtro non corretta."
            '    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    Exit Function
            'End If

            If (FilterNumMag = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(928, "", "Numero Magazzino di filtro non corretto.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If

            clsSapUtility.ResetUbicazioneStruct(WorkUbicazione) 'init

            WorkUbicazione.NumeroMagazzino = FilterNumMag
            WorkUbicazione.TipoMagazzino = FilterTipiMag
            WorkUbicazione.Ubicazione = FilterUbicazione

            'CHIAMO IL WS PER OTTENELE LE UBICAZIONI CON IL FILTRO ATTIVO
            RetCode = clsSapWS.Call_ZWS_MB_GET_UBICAZIONI_INFO(WorkUbicazione, "", False, clsUser.SapWmsUser.LANGUAGE, GetOk, clsSelezioneUbicazione.objDataTableSelectUbicazione, Val(DefaultEM_List_MaxNumRowReturned), SapFunctionError, True)
            If ((GetOk <> True) Or (RetCode <> 0)) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(912, "", "Errore in ") & " " & clsAppTranslation.GetSingleParameterValue(1156, "", "estrazione dati (GET_MATERIAL_LIST).Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If

            SelectionOnRun = True

            SourceForm = inSourceForm

            frmSelectUbicazioneForm = New frmSelectUbicazione
            frmSelectUbicazioneForm.Show()

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

            Dim WorkLENUM As DataColumn = New DataColumn("LENUM") 'declaring a column named Name
            WorkLENUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectUnitaMagazzino.Columns.Add(WorkLENUM) 'adding the column to table

            Dim WorkWERKS As DataColumn = New DataColumn("WERKS") 'declaring a column named Name
            WorkWERKS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectUnitaMagazzino.Columns.Add(WorkWERKS) 'adding the column to table

            Dim WorkLGNUM As DataColumn = New DataColumn("LGNUM") 'declaring a column named Name
            WorkLGNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectUnitaMagazzino.Columns.Add(WorkLGNUM) 'adding the column to table

            Dim WorkLGTYP As DataColumn = New DataColumn("LGTYP") 'declaring a column named Name
            WorkLGTYP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectUnitaMagazzino.Columns.Add(WorkLGTYP) 'adding the column to table

            Dim WorkLGPLA As DataColumn = New DataColumn("LGPLA") 'declaring a column named Name
            WorkLGPLA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectUnitaMagazzino.Columns.Add(WorkLGPLA) 'adding the column to table


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
End Class
