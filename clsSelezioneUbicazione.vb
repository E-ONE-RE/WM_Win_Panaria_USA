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

Public Class clsSelezioneUbicazione


    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsSelezioneUbicazione"


    'VALORI DI FILTRO PER LA VISUALIZZAZIONE DEI TIPI MAGAZZINO
    Public Shared FilterDivisione As String
    Public Shared FilterNumMag As String
    Public Shared FilterTipiMag As String
    Public Shared FilterUbicazione As String

    Public Shared objDataTableSelectUbicazione As New DataTable
    Public Shared objDataTableSelectUbicazioneDropUDS As New DataTable
    Public Shared objDataTableSelectUbicazioneSpecial As New DataTable
    Public Shared UbicazioneSelezionata As clsDataType.SapWmUbicazione
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

            If (Not (objDataTableSelectUbicazione Is Nothing)) Then
                objDataTableSelectUbicazione.Rows.Clear()
            End If

            If (Not (objDataTableSelectUbicazioneDropUDS Is Nothing)) Then
                objDataTableSelectUbicazioneDropUDS.Rows.Clear()
            End If

            If (Not (objDataTableSelectUbicazioneSpecial Is Nothing)) Then
                objDataTableSelectUbicazioneSpecial.Rows.Clear()
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

    Public Shared Function SelezionaUbicazione(ByRef inSourceForm As Form, Optional ByVal inStringTxtUbicazione As String = "", Optional ByVal inFilterDivisione As String = "", Optional ByVal inFilterNumMag As String = "", Optional ByVal inFilterTipiMag As String = "", Optional ByVal inExcludeClearAllData As Boolean = True) As Long
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

            SelezionaUbicazione = 1 'init at error

            If (inExcludeClearAllData = False) Then
                RetCode = ClearAllData() 'INIT
            End If

            If (clsUtility.IsStringValid(inFilterDivisione, True) = True) Then
                FilterDivisione = inFilterDivisione
            End If
            If (clsUtility.IsStringValid(inFilterNumMag, True) = True) Then
                FilterNumMag = inFilterNumMag
            End If
            If (clsUtility.IsStringValid(inFilterTipiMag, True) = True) Then
                FilterTipiMag = inFilterTipiMag
            End If



            If (clsUtility.IsStringValid(inFilterDivisione, True) = False) Then
                '>>>> INPOSTO FITRI DI DEFAULT SE NON SPECIFICATO
                FilterDivisione = clsUser.GetUserDivisionToUse() '>>> RITORNO LA DIVISIONE DA USARE
            End If
            If (clsUtility.IsStringValid(inFilterNumMag, True) = False) Then
                '>>>> INPOSTO FITRI DI DEFAULT SE NON SPECIFICATO
                FilterNumMag = clsUser.GetUserNumeroMagazzinoToUse() '>>> RITORNO IL NUMERO MAGAZZINO DA USARE
            End If
            If (clsUtility.IsStringValid(FilterTipiMag, True) = False) Then
                FilterTipiMag = DefaultSelectUbicazioni_TipoMag
            End If

            If (clsUtility.IsStringValid(FilterUbicazione, True) = False) Then
                If (inStringTxtUbicazione = "") Then
                    FilterUbicazione = DefaultSelectUbicazione_Ubicazione
                Else
                    If (InStr(1, inStringTxtUbicazione, "*") > 0) Then
                        '>>> CASO ASTERISCO GIA CONTENUTO
                        FilterUbicazione = inStringTxtUbicazione
                    Else
                        FilterUbicazione = inStringTxtUbicazione & "*"
                    End If
                End If
            Else
                'se ho immesso una ubicazione nel caso che ho la lunghezza minima aggiungo il carattere di ricerca "*"
                If (Len(FilterUbicazione) <= MinNumCaratteriPerHelpUbicazione) Then
                    If (InStr(1, inStringTxtUbicazione, "*") <= 0) Then
                        FilterUbicazione = FilterUbicazione & "*"
                    End If
                End If
            End If

            If (inSourceForm Is Nothing) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(925, "", "Finestra origine non corretta.(Nothing)")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If

            If (FilterNumMag = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(928, "", "Numero Magazzino di filtro non corretto.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If

            clsSapUtility.ResetUbicazioneStruct(WorkUbicazione) 'init

            'IMPOSTO I FILTRI PER LA SELEZIONE DI UNA UBICAZIONE TRA QUELLE DISPONIBILI
            WorkUbicazione.NumeroMagazzino = FilterNumMag
            WorkUbicazione.TipoMagazzino = FilterTipiMag
            WorkUbicazione.Ubicazione = FilterUbicazione

            'CHIAMO IL WS PER OTTENERE LE UBICAZIONI CON IL FILTRO ATTIVO
            RetCode = clsSapWS.Call_ZWS_MB_GET_UBICAZIONI_INFO(WorkUbicazione, "", True, clsUser.SapWmsUser.LANGUAGE, GetOk, clsSelezioneUbicazione.objDataTableSelectUbicazione, Val(DefaultEM_List_MaxNumRowReturned), SapFunctionError, False)
            If ((GetOk <> True) Or (RetCode <> 0)) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1155, "", "Nessuna UBICAZIONE trovata.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(568, "", "Verificare i dati immessi e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If

            SelectionOnRun = True

            SourceForm = inSourceForm

            frmSelectUbicazioneForm = New frmSelectUbicazione
            frmSelectUbicazioneForm.Show()

            SelezionaUbicazione = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            SelezionaUbicazione = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function SelezionaUbicazioneDropUDS(ByRef inSourceForm As Form, Optional ByVal inStringTxtUbicazione As String = "", Optional ByVal inFilterDivisione As String = "", Optional ByVal inFilterNumMag As String = "", Optional ByVal inFilterTipiMag As String = "", Optional ByVal inExcludeClearAllData As Boolean = True) As Long
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

            SelezionaUbicazioneDropUDS = 1 'init at error

            If (inExcludeClearAllData = False) Then
                RetCode = ClearAllData() 'INIT
            End If

            If (clsUtility.IsStringValid(inFilterDivisione, True) = True) Then
                FilterDivisione = inFilterDivisione
            End If
            If (clsUtility.IsStringValid(inFilterNumMag, True) = True) Then
                FilterNumMag = inFilterNumMag
            End If
            If (clsUtility.IsStringValid(inFilterTipiMag, True) = True) Then
                FilterTipiMag = inFilterTipiMag
            End If



            If (clsUtility.IsStringValid(inFilterDivisione, True) = False) Then
                '>>>> INPOSTO FITRI DI DEFAULT SE NON SPECIFICATO
                FilterDivisione = clsUser.GetUserDivisionToUse() '>>> RITORNO LA DIVISIONE DA USARE
            End If
            If (clsUtility.IsStringValid(inFilterNumMag, True) = False) Then
                '>>>> INPOSTO FITRI DI DEFAULT SE NON SPECIFICATO
                FilterNumMag = clsUser.GetUserNumeroMagazzinoToUse() '>>> RITORNO IL NUMERO MAGAZZINO DA USARE
            End If
            If (clsUtility.IsStringValid(FilterTipiMag, True) = False) Then
                FilterTipiMag = DefaultSelectUbicazioni_TipoMag
            End If

            If (clsUtility.IsStringValid(FilterUbicazione, True) = False) Then
                If (inStringTxtUbicazione = "") Then
                    FilterUbicazione = DefaultSelectUbicazione_Ubicazione
                Else
                    If (InStr(1, inStringTxtUbicazione, "*") > 0) Then
                        '>>> CASO ASTERISCO GIA CONTENUTO
                        FilterUbicazione = inStringTxtUbicazione
                    Else
                        FilterUbicazione = inStringTxtUbicazione & "*"
                    End If
                End If
            Else
                'se ho immesso una ubicazione nel caso che ho la lunghezza minima aggiungo il carattere di ricerca "*"
                If (Len(FilterUbicazione) <= MinNumCaratteriPerHelpUbicazione) Then
                    If (InStr(1, inStringTxtUbicazione, "*") <= 0) Then
                        FilterUbicazione = FilterUbicazione & "*"
                    End If
                End If
            End If

            If (inSourceForm Is Nothing) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(925, "", "Finestra origine non corretta.(Nothing)")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If

            If (FilterNumMag = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(928, "", "Numero Magazzino di filtro non corretto.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If

            clsSapUtility.ResetUbicazioneStruct(WorkUbicazione) 'init

            'IMPOSTO I FILTRI PER LA SELEZIONE DI UNA UBICAZIONE TRA QUELLE DISPONIBILI
            WorkUbicazione.NumeroMagazzino = FilterNumMag
            WorkUbicazione.TipoMagazzino = FilterTipiMag
            WorkUbicazione.Ubicazione = FilterUbicazione

            'CHIAMO IL WS PER OTTENERE LE UBICAZIONI CON IL FILTRO ATTIVO
            RetCode = clsSapWS.Call_ZWS_GET_UBI_DROP(WorkUbicazione.NumeroMagazzino, clsUser.SapWmsUser.LANGUAGE, GetOk, clsSelezioneUbicazione.objDataTableSelectUbicazioneDropUDS, SapFunctionError, False)
            If ((GetOk <> True) Or (RetCode <> 0)) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1155, "", "Nessuna UBICAZIONE trovata.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(568, "", "Verificare i dati immessi e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If

            SelectionOnRun = True

            SourceForm = inSourceForm

            frmSelectUbicazioneDropUDSForm = New frmSelectUbicazioneDropUDS
            frmSelectUbicazioneDropUDSForm.Show()

            SelezionaUbicazioneDropUDS = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            SelezionaUbicazioneDropUDS = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CreateDateTableSelezioneUbicazione() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableSelezioneUbicazione = 1 'init at error


            clsDataType.CreateDateTableForUbicazioni(objDataTableSelectUbicazione)


            CreateDateTableSelezioneUbicazione = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableSelezioneUbicazione = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CreateDateTableDropUDS() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableDropUDS = 1 'init at error

            Dim WorkWERKS As DataColumn = New DataColumn("WERKS") 'declaring a column named Name
            WorkWERKS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectUbicazioneDropUDS.Columns.Add(WorkWERKS) 'adding the column to table

            Dim WorkLGNUM As DataColumn = New DataColumn("LGNUM") 'declaring a column named Name
            WorkLGNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectUbicazioneDropUDS.Columns.Add(WorkLGNUM) 'adding the column to table

            Dim WorkLGTYP As DataColumn = New DataColumn("LGTYP") 'declaring a column named Name
            WorkLGTYP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectUbicazioneDropUDS.Columns.Add(WorkLGTYP) 'adding the column to table

            Dim WorkLGPLA As DataColumn = New DataColumn("LGPLA") 'declaring a column named Name
            WorkLGPLA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectUbicazioneDropUDS.Columns.Add(WorkLGPLA) 'adding the column to table

            Dim WorkZWMSUBI_DESCR As DataColumn = New DataColumn("ZWMSUBI_DESCR") 'declaring a column named Name
            WorkZWMSUBI_DESCR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectUbicazioneDropUDS.Columns.Add(WorkZWMSUBI_DESCR) 'adding the column to table


            CreateDateTableDropUDS = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableDropUDS = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Public Shared Function CreateDateTableSpecial() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableSpecial = 1 'init at error

            Dim WorkWERKS As DataColumn = New DataColumn("WERKS") 'declaring a column named Name
            WorkWERKS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectUbicazioneSpecial.Columns.Add(WorkWERKS) 'adding the column to table

            Dim WorkLGNUM As DataColumn = New DataColumn("LGNUM") 'declaring a column named Name
            WorkLGNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectUbicazioneSpecial.Columns.Add(WorkLGNUM) 'adding the column to table

            Dim WorkLGTYP As DataColumn = New DataColumn("LGTYP") 'declaring a column named Name
            WorkLGTYP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectUbicazioneSpecial.Columns.Add(WorkLGTYP) 'adding the column to table

            Dim WorkLGPLA As DataColumn = New DataColumn("LGPLA") 'declaring a column named Name
            WorkLGPLA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectUbicazioneSpecial.Columns.Add(WorkLGPLA) 'adding the column to table

            Dim WorkZWMSUBI_DESCR As DataColumn = New DataColumn("ZWMSUBI_DESCR") 'declaring a column named Name
            WorkZWMSUBI_DESCR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectUbicazioneSpecial.Columns.Add(WorkZWMSUBI_DESCR) 'adding the column to table

            CreateDateTableSpecial = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableSpecial = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


End Class
