' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 30/04/2012
' DATA MODIFICA     : 30/04/2012
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la funzione di selezione di un NUMERO CONSEGNA
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility

Public Class clsSelezioneNumeroConsegna


    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsSelezioneNumeroConsegna"


    'VALORI DI FILTRO PER LA VISUALIZZAZIONE DEI TIPI MAGAZZINO
    Public Shared FilterTipoConsegna As String
    Public Shared FilterOrgCommerciale As String
    Public Shared FilterDivisione As String
    Public Shared FilterDestinatarioMerci As String
    Public Shared FilterCommittente As String
    Public Shared FilterDaDataCreazione As Date = Date.MinValue
    Public Shared FilterADataCreazione As Date = Date.MinValue
    Public Shared FilterDaDataCarico As Date = Date.MinValue
    Public Shared FilterADataCarico As Date = Date.MinValue
    Public Shared FilterNumMag As String
    Public Shared FilterTipiMag As String
    Public Shared FilterUbicazione As String
    Public Shared FilterUnitaMagazzino As String
    Public Shared FilterCodiceMateriale As String

    Public Shared objDataTableSelectNumConsegna As New DataTable

    Public Shared NumeroConsegnaSelezionato As String
    Public Shared GiacenzaSelezionata As clsDataType.SapWmGiacenza

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
            FilterUnitaMagazzino = ""
            FilterCodiceMateriale = ""

            clsSapUtility.ResetGiacenzaStruct(GiacenzaSelezionata)


            If (Not (objDataTableSelectNumConsegna Is Nothing)) Then
                objDataTableSelectNumConsegna.Rows.Clear()
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

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ConfermaSelezione = 1 'init at error

            If (Not inSelectForm Is Nothing) Then
#If Not APPLICAZIONE_WIN32 = "SI" Then
                SourceForm.Visible = False
#End If
                Select Case SourceForm.GetType.Name
                    Case frmInfoGiacenze_1_CodiceMateriale.Name
                        frmInfoGiacenze_1_CodiceMaterialeForm.ConfermaSelezioneCodiceMateriale()
                        frmInfoGiacenze_1_CodiceMaterialeForm.Show()
                End Select
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
        'Dim GetOk As Boolean = False
        'Dim GetDataOk As Boolean = False
        'Dim WorkUbicazione As clsDataType.SapWmUbicazione
        'Dim WorkGiacenza As clsDataType.SapWmGiacenza
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


            'clsSapUtility.ResetUbicazioneStruct(WorkUbicazione) 'init
            'clsSapUtility.ResetGiacenzaStruct(WorkGiacenza) 'init
            'WorkUbicazione.Divisione = FilterDivisione
            'WorkUbicazione.NumeroMagazzino = FilterNumMag
            'WorkUbicazione.TipoMagazzino = FilterTipiMag
            'WorkUbicazione.Ubicazione = FilterUbicazione
            'WorkUbicazione.UnitaMagazzino = FilterUnitaMagazzino
            'WorkGiacenza.CodiceMateriale = FilterCodiceMateriale

            'WorkGiacenza.Partita = clsInfoGiacenze.FilterPartitaMateriale

            ''CHIAMO WS PER OTTENERE I DATI DELLE GIACENZE CON I FILTRI IMPOSTATO
            'RetCode = clsSapWS.Call_ZWS_MB_GET_GET_LQUA(WorkUbicazione, WorkGiacenza, DefaultSapUserLanguage, GetDataOk, objDataTableSelectCodMatGiacenza, SapFunctionError, True)
            'If ((GetDataOk <> True) Or (RetCode <> 0)) Then
            '    ErrDescription = clsAppTranslation.GetSingleParameterValue(497, "", "Errore in estrazione dati (GET_GET_LQUA).Verificare e riprovare.")
            '    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    Exit Function
            'End If


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
            objDataTableSelectNumConsegna.Columns.Add(WorkWERKS) 'adding the column to table

            Dim WorkMATNR As DataColumn = New DataColumn("MATNR") 'declaring a column named Name
            WorkMATNR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectNumConsegna.Columns.Add(WorkMATNR) 'adding the column to table

            Dim WorkMAKTG As DataColumn = New DataColumn("MAKTG") 'declaring a column named Name
            WorkMAKTG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectNumConsegna.Columns.Add(WorkMAKTG) 'adding the column to table

            Dim WorkMTART As DataColumn = New DataColumn("MTART") 'declaring a column named Name
            WorkMTART.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectNumConsegna.Columns.Add(WorkMTART) 'adding the column to table

            Dim WorkMATKL As DataColumn = New DataColumn("MATKL") 'declaring a column named Name
            WorkMATKL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectNumConsegna.Columns.Add(WorkMATKL) 'adding the column to table

            Dim WorkMEINS As DataColumn = New DataColumn("MEINS") 'declaring a column named Name
            WorkMEINS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectNumConsegna.Columns.Add(WorkMEINS) 'adding the column to table

            Dim WorkGEWEI As DataColumn = New DataColumn("GEWEI") 'declaring a column named Name
            WorkGEWEI.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectNumConsegna.Columns.Add(WorkGEWEI) 'adding the column to table

            Dim WorkEKGRP As DataColumn = New DataColumn("EKGRP") 'declaring a column named Name
            WorkEKGRP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSelectNumConsegna.Columns.Add(WorkEKGRP) 'adding the column to table


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
