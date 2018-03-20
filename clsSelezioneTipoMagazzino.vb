' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 20/10/2011
' DATA MODIFICA     : 20/10/2011
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la funzione di selezione di un TIPO MAGAZZINO
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility

Public Class clsSelezioneTipoMagazzino


    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsSelezioneTipoMagazzino"


    'VALORI DI FILTRO PER LA VISUALIZZAZIONE DEI TIPI MAGAZZINO
    Public Shared FilterDivisione As String
    Public Shared FilterNumMag As String
    Public Shared FilterTipiMag As String

    Public Shared objDataTableSelectTipoMag As New DataTable
    Public Shared TipoMagazzinoSelezionato As clsDataType.SapWmTipoMagazzino
    Public Shared SourceForm As Form

    Public Shared SelectionTipoMagazzinoOnRun As Boolean

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

            SelectionTipoMagazzinoOnRun = False

            FilterDivisione = ""
            FilterNumMag = ""
            FilterTipiMag = ""


            If (Not (objDataTableSelectTipoMag Is Nothing)) Then
                objDataTableSelectTipoMag.Rows.Clear()
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
                RetCode = clsUtility.ExecuteObjectMethod(SourceForm, "ConfermaSelezioneTipoMagazzino", MethodRetval, Nothing)
                RetCode = clsUtility.ExecuteObjectMethod(SourceForm, "Show", MethodRetval, Nothing)
                inSelectForm.Close()
            End If

            SelectionTipoMagazzinoOnRun = False

            ConfermaSelezione = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ConfermaSelezione = 1000 'IL THREAD E' USCITO DAL LOOP
            SelectionTipoMagazzinoOnRun = False
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
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            SelezionaElemento = 1 'init at error

            If (inSourceForm Is Nothing) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(925, "", "Finestra origine non corretta.(Nothing)")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If

            If (FilterNumMag = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(928, "", "Numero Magazzino di filtro non corretta.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If

            'CHIAMO IL WS PER OTTENELE LE UBICAZIONI CON IL FILTRO ATTIVO
            RetCode = clsSapWS.Call_ZWS_MB_GET_LGTYP_LIST(FilterNumMag, FilterTipiMag, clsUser.SapWmsUser.LANGUAGE, GetOk, objDataTableSelectTipoMag, SapFunctionError, True)
            If ((GetOk <> True) Or (RetCode <> 0)) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(912, "", "Errore in ") & " " & clsAppTranslation.GetSingleParameterValue(1157, "", "estrazione dati (GET_LGTYP_LIST).Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If

            SelectionTipoMagazzinoOnRun = True

            SourceForm = inSourceForm

            frmSelectTipoMagazzinoForm = New frmSelectTipoMagazzino
            frmSelectTipoMagazzinoForm.Show()

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
            objDataTableSelectTipoMag.Columns.Add(WorkWERKS) 'adding the column to table

            Dim WorkLGNUM As DataColumn = New DataColumn("LGNUM") 'declaring a column named Name
            WorkLGNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectTipoMag.Columns.Add(WorkLGNUM) 'adding the column to table

            Dim WorkLGTYP As DataColumn = New DataColumn("LGTYP") 'declaring a column named Name
            WorkLGTYP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectTipoMag.Columns.Add(WorkLGTYP) 'adding the column to table

            Dim WorkLTYPT As DataColumn = New DataColumn("LTYPT") 'declaring a column named Name
            WorkLTYPT.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectTipoMag.Columns.Add(WorkLTYPT) 'adding the column to table


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
