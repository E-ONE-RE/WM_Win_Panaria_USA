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

Public Class clsSelezioneUbicazioneSpunta


    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsSelezioneUbicazioneSpunta"


    'ELENCO DELLE UBICAZONI DI SPUNTA SELEZIONABILI DALL'UTENTE
    Public Shared objDataTableUbiSpunta As New DataTable

    'SINGOLA UBICAZONE DI SPUNTA SELEZIONATA DALL'UTENTE
    Public Shared UbicazioneSpuntaSelezionata As clsDataType.SapWmUbicazione

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

            RetCode += clsSapUtility.ResetUbicazioneStruct(UbicazioneSpuntaSelezionata)

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
    Public Shared Function ConfermaSelezioneUbicazione(ByRef inSelectForm As Form) As Long
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

            ConfermaSelezioneUbicazione = 1 'init at error

            If (Not inSelectForm Is Nothing) And (Not SourceForm Is Nothing) Then
#If Not APPLICAZIONE_WIN32 = "SI" Then
                SourceForm.Visible = False
#End If
                RetCode = clsUtility.ExecuteObjectMethod(SourceForm, "ConfermaSelezioneLocazione", MethodRetval, Nothing)
                RetCode = clsUtility.ExecuteObjectMethod(SourceForm, "Show", MethodRetval, Nothing)
                inSelectForm.Close()
            End If

            SelectionOnRun = False

            ConfermaSelezioneUbicazione = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ConfermaSelezioneUbicazione = 1000 'IL THREAD E' USCITO DAL LOOP
            SelectionOnRun = False
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function SelezionaUbicazioneSpunta(ByRef inSourceForm As Form, Optional ByVal inFilterUbicazione As String = "", Optional ByVal inFilterTipiMag As String = "") As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        Dim WorkUbicazione As clsDataType.SapWmUbicazione
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            SelezionaUbicazioneSpunta = 1 'init at error


            clsSapUtility.ResetUbicazioneStruct(WorkUbicazione) 'init

            '>>>> INPOSTO FITRI DI DEFAULT SE NON SPECIFICATO
            WorkUbicazione.Divisione = clsUser.GetUserDivisionToUse() '>>> RITORNO LA DIVISIONE DA USARE


            '>>>> INPOSTO FITRI DI DEFAULT SE NON SPECIFICATO
            WorkUbicazione.NumeroMagazzino = clsUser.GetUserNumeroMagazzinoToUse() '>>> RITORNO IL NUMERO MAGAZZINO DA USARE


            'se ho immesso una ubicazione nel caso che ho la lunghezza minima aggiungo il carattere di ricerca "*"
            If (Len(inFilterUbicazione) <= MinNumCaratteriPerHelpUbicazione) Then
                If (InStr(1, inFilterUbicazione, "*") <= 0) Then
                    WorkUbicazione.Ubicazione = inFilterUbicazione & "*"
                End If
            End If

            If (inSourceForm Is Nothing) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(925, "", "Finestra origine non corretta.(Nothing)")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If




            'CHIAMO IL WS PER OTTENELE LE UBICAZIONI CON IL FILTRO ATTIVO


            SelectionOnRun = True

            SourceForm = inSourceForm

            frmSelectUbicazioneSpuntaForm = New frmSelectUbicazioneSpunta
            frmSelectUbicazioneSpuntaForm.Show()

            SelezionaUbicazioneSpunta = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            SelezionaUbicazioneSpunta = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function CreateDateTableForUbiSpunta() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForUbiSpunta = 1 'init at error


            Dim WorkLGNUM As DataColumn = New DataColumn("LGNUM") 'declaring a column named Name
            WorkLGNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableUbiSpunta.Columns.Add(WorkLGNUM) 'adding the column to table

            Dim WorkLGTYP As DataColumn = New DataColumn("LGTYP") 'declaring a column named Name
            WorkLGTYP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableUbiSpunta.Columns.Add(WorkLGTYP) 'adding the column to table

            Dim WorkLGPLA As DataColumn = New DataColumn("LGPLA") 'declaring a column named Name
            WorkLGPLA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableUbiSpunta.Columns.Add(WorkLGPLA) 'adding the column to table

            'Dim WorkSPRAS As DataColumn = New DataColumn("SPRAS") 'declaring a column named Name
            'WorkSPRAS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            'objDataTableUbiSpunta.Columns.Add(WorkSPRAS) 'adding the column to table

            Dim WorkZWMSUBI_DESCR As DataColumn = New DataColumn("ZWMSUBI_DESCR") 'declaring a column named Name
            WorkZWMSUBI_DESCR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableUbiSpunta.Columns.Add(WorkZWMSUBI_DESCR) 'adding the column to table


            CreateDateTableForUbiSpunta = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForUbiSpunta = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

End Class
