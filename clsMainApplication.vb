' **********************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 04/03/2009
' DATA MODIFICA     : 12/05/2011
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa il MAIN dell'applicazione
' **********************************************************************

Imports System.Configuration
Imports Microsoft.Win32.Registry
Imports Microsoft.Win32.RegistryKey
Imports System.Xml
Imports clsBusinessLogic
Imports clsUtility
Imports clsXML
Imports System.IO

#If APPLICAZIONE_WIN32 = "SI" Then
Imports System.Collections.Specialized
#End If


'***************************************************************************
'>>>>> ATTENZIONE : MI INDICA SE LAVORO CON L'EMULATORE O IL PALMARE
'#Const EMULAZIONE_PALMARE = "SI"  '>>>> PER LAVORARE CON EMULATORE
#Const EMULAZIONE_PALMARE = "NO"  '>>>> PER LAVORARE CON EMULATORE


Public Class clsMainApplication
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsMainApplication"
    Private ErrDescription As String
    Private SapFunctionError As clsBusinessLogic.SapFunctionError

    Public Function StartApplication(ByVal args() As String) As Long
        ' ************************************************************
        ' DESCRIZIONE : metodo principale che fa partire l'applicativo
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim RetFunctionCode As Long = 0
        Dim AppGiaInEsecuzione As Boolean = False
        'Dim RunningProcess() As String

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            LastStartUpDate = DateTime.MinValue


            'setto nome file per LOG COMANDI SQL
            SqlApplicationLog.GenericLogFileName = True
            SqlApplicationLog.FileName = "SqlLog"


            '*****************************************************************************
            'DEVO VERIFICARE SE L'APPLICATIVO E' IN ESECUZIONE
#If Not APPLICAZIONE_WIN32 = "SI" Then
            RetCode = clsUtility.KillPrevProcess()
            If RetCode <> 0 Then
                'ErrDescription = clsAppTranslation.GetSingleParameterValue(904, "", "Attenzione!Programma già in esecuzione.") & clsAppTranslation.GetSingleParameterValue(905, "", "Verificare nel TASK MANAGER e riprovare.")
                ErrDescription = "Program already running"
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Application.Exit() '>>>> TERMINO PROGRAMMA
                Exit Function
            End If
#End If

            'RetCode = IsProcesOnRunning(ApplMainFormTitle, AppGiaInEsecuzione, 0)
            'If (AppGiaInEsecuzione = True) Then
            '    ErrDescription = clsAppTranslation.GetSingleParameterValue(904, "", "Attenzione!Programma già in esecuzione.") & clsAppTranslation.GetSingleParameterValue(905, "", "Verificare nel TASK MANAGER e riprovare.")
            '    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    Application.Exit() '>>>> TERMINO PROGRAMMA
            '    Exit Function
            'End If


            'RICAVO NOME STAZIONE
#If APPLICAZIONE_WIN32 = "SI" Then
            WorkStationName = clsUtility.GetWorkStationName()
#End If

            '****************************************************************************************************************************************************************************************************
            ' >>> LEGGO FILE CONFIGURAZIONE XML LOCALE PER PARAMETRI CONNESSIONE
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "StartApplication", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeLog, "LOG: before method [LeggiFileAppConfigConn] ", Nothing)
            RetCode += LeggiFileAppConfigConn() 'leggo configurazione applicazione
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "StartApplication", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeLog, "LOG: after method [LeggiFileAppConfigConn] ", Nothing)

            '****************************************************************************************************************************************************************************************************


            '****************************************************************************************************************************************************************************************************
            ' >>> CONTROLLO CONNESSIONE A SISTEMA SAP

            RetCode += CheckSapConnection()
            If RetCode <> 0 Then
                'ErrDescription = clsAppTranslation.GetSingleParameterValue(904, "", "Attenzione!Programma già in esecuzione.") & clsAppTranslation.GetSingleParameterValue(905, "", "Verificare nel TASK MANAGER e riprovare.")
                ErrDescription = "Connection ERROR"
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Application.Exit() '>>>> TERMINO PROGRAMMA
                Exit Function
            End If

            '****************************************************************************************************************************************************************************************************


            '****************************************************************************************************************************************************************************************************
            ' >>> ESEGUO CHIAMATA WEB SERVICES PER OTTENERE PARAMETRI DELL'APPLICAZIONE
            RetCode = clsAppParameters.GetApplicationParameters(clsUser.SapWmsUser.WERKS, clsUser.SapWmsUser.LGNUM, SapFunctionError, clsAppParameters.objDataTableAppParamsInfo)

            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "StartApplication", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeLog, "LOG: before method [LeggiFileAppConfig] ", Nothing)
            RetCode += LeggiAppParameters() 'leggo configurazione applicazione
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "StartApplication", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeLog, "LOG: after method [LeggiFileAppConfig] ", Nothing)

            '****************************************************************************************************************************************************************************************************


            ' >>> ESEGUO CHIAMATA WEB SERVICES PER OTTENERE PARAMETRI DELL'APPLICAZIONE
            RetCode = clsAppTranslation.GetApplicationParameters(SapFunctionError)

            'Dim text As String
            'clsAppTranslation.GetSingleParameterValue(3, text, "testo di prova")


#If APPLICAZIONE_WIN32 = "SI" Then

            AppGiaInEsecuzione = clsUtility.PrevInstance()
            If (AppGiaInEsecuzione = True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(904, "", "Attenzione!Programma già in esecuzione.") & clsAppTranslation.GetSingleParameterValue(905, "", "Verificare nel TASK MANAGER e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Application.Exit() '>>>> TERMINO PROGRAMMA
                Exit Function
            End If

#End If


            'CREO LA CARTELLA LOG SE NON ESISTE
            RetFunctionCode = CreateLogFolderForApplication()

            'pulisco directory programma da eventuali file temporanei (non deve generare errore per non bloccare programma)
            RetFunctionCode = CleanTempFilesApplication()

            'elimino file di LOG piu' vecchi di 30 giorni (non deve generare errore per non bloccare programma)
            RetFunctionCode = DeleteOldLogFilesApplication()

            'VERIFICO E IMPOSTO I DATI DEL TCP/IP
            RetFunctionCode = CheckTcPSettingsForApplication()

            'CREO TUTTI I DATA TABLE DEL PROGRAMMA
            RetFunctionCode = CreateDateTableForAllObjects()
            If (RetFunctionCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(906, "", "Errore in creazione DATA TABLE.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

            Dim GetSystemInfoOk As Boolean = False
            'CHIAMO WS PER AVERE INFORMAZIONI DI SYSTEMA
            RetCode = clsSapWS.Call_ZWS_MB_GET_SYSTEM_INFO(SapFunctionError, SapSystemInfo, GetSystemInfoOk, False)
            If (GetSystemInfoOk <> True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(907, "", "Errore in lettura INFO SISTEMA.") & vbCrLf & "WsHostName:" & WsHostName & vbCrLf & "WsPortNumber:" & WsPortNumber & vbCrLf & "SapClient:" & SapClient & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Else
                '>>> SE HO RECUPERATO LE INFORMAZIONI DEL SISTEMA VERIFICO SE LA DATA E L'ORA DEL PALMARE SONO SINCRONIZZATE CON SAP
                If (clsUtility.IsStringValid(SapSystemInfo.SystInfo_Rec.Datlo, True) = True) And (clsUtility.IsStringValid(SapSystemInfo.SystInfo_Rec.Timlo, True) = True) Then
                    Dim WorkDate As Date
                    '**************************************
                    Try 'HERE PUT NORMAL EXECUTION CODE
                        '**************************************

                        RetCode = clsSapUtility.GetDataOraDaSystemTimeDiSap(WorkDate, True)

                        If RetCode = 0 Then
                            clsUtility.SetDeviceTime(WorkDate)
                        End If

                        '**************************************
                    Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
                        'LOG ERROR CONDITION
                        clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "[SetDeviceTime] Catch Error!", ex)
                        '**************************************
                    Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

                    End Try
                End If
            End If


            StartThreadForms()

            LastStartUpDate = Now

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function
    Public Function CreateDateTableForAllObjects() As Long
        ' ************************************************************
        ' DESCRIZIONE : metodo che crea tutti i DATA TABLE delle CLASSI del programma
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            CreateDateTableForAllObjects = 1

            'creo data tables per visualizzazione dati UTENTE
            RetCode += clsUser.CreateDateTableForUserInfo()
            RetCode += clsUser.CreateDateTableForUsersProfLgtyp()
            RetCode += clsUser.CreateDateTableForUserPickQueues()


            RetCode += clsInfoSystem.CreateDateTableForSystemInfo()

            'creo data tables per visualizzazione dati
            RetCode += clsInfoInputDestination.CreateDateTable()

            'creo data tables per visualizzazione INFORMAZIONE UBICAZIONE
            RetCode += clsInfoUbicazione.CreateDateTableForUbicazioneInfo()

            'creo data tables per visualizzazione INFORMAZIONE TIPI MAGAZZINO
            RetCode += clsInfoTipiMagazzino.CreateDateTableForTipiMagazzino()

            'creo data tables per visualizzazione INFORMAZIONE GIACENZE
            RetCode += clsInfoGiacenze.CreateDateTableForGiacenze()
            RetCode += clsInfoGiacenze.CreateDateTableForSpedizioni()
            'RetCode += clsInfoGiacenze.CreateDateTableDetailsGiacenza()
            'RetCode += clsInfoGiacenze.CreateDateTableDetailsSped()


            RetCode += clsBloccoMovMM.CreateDateTableForGiacenze()
            RetCode += clsTrasfMat.CreateDateTableForGiacenze()
            RetCode += clsTrasfUbi.CreateDateTableForGiacenze()
            RetCode += clsRegModStockE.CreateDateTableForGiacenze()

            RetCode += clsInfoMappaUbicazioni.CreateDateTable()


            'creo data tables per gestione UDS
            RetCode += clsUDS.CreateDateTableForUDSInfo()
            RetCode += clsMoveUDS.CreateDateTableForUDSInfo()
            RetCode += clsMoveUDS.CreateDateTableForUDCInfo()
            RetCode += clsTruckLoad.CreateDateTableForUDSInfo()

            RetCode += clsChangeUDS.CreateDateTableForUDSInfo()
            RetCode += clsChangeUDS.CreateDateTableForUDSChangeInfo()


            'creo data tables per visualizzazione INFORMAZIONE ANAGRAFICA MATERIALI
            RetCode += clsInfoCodiceMateriale.CreateDateTableList()
            'RetCode += clsInfoCodiceMateriale.CreateDateTableDetails()

            RetCode += clsInfoDisponibilitaMateriale.CreateDateTableList()
            'RetCode += clsInfoDisponibilitaMateriale.CreateDateTableDetails()

            RetCode += clsWmsJobsGroup.CreateDateTablePickUMInfo()

            RetCode += clsEMFromJob.CreateDateTableForGiacSameMatPart()
            RetCode += clsEMFromStock.CreateDateTableForGiacSameMatPart()
            RetCode += clsEMFromStock.CreateDateTableForEM_List()

            RetCode += clsInventarioUbicazione.CreateDateTableForGiacenze()

            'creo data tables per SELEZIONE OGGETTI
            RetCode += clsSelezioneUbicazione.CreateDateTableSelezioneUbicazione()
            RetCode += clsSelezioneUbicazioneSpunta.CreateDateTableForUbiSpunta()
            RetCode += clsSelezioneTipoMagazzino.CreateDateTable()
            RetCode += clsSelezioneCodiceMateriale.CreateDateTable()
            RetCode += clsSelezioneCodiceMateriale.CreateDateTableCodMatGiacenze()
            RetCode += clsSelezionePartitaMateriale.CreateDateTable()

            RetCode += clsSelezioneUbicazione.CreateDateTableSpecial()


            'creo data tables
            RetCode += clsUscitaMerci.CreateDateTableForGiacenze()
            RetCode += clsUscitaMerci.CreateDateTableForStockUM()
            RetCode += clsUscitaMerci.CreateDateTableForStockUM_Moved()
            RetCode += clsWmsJob.CreateDateTableForGiacenzeOri()
            RetCode += clsWmsJob.CreateDateTableForGiacenzeDest()
            RetCode += clsWmsJob.CreateDateTableForWmsJobsList()
            RetCode += clsWmsJobsGroup.CreateDateTableForWmsJobGroupList()
            RetCode += clsWmsJob.TaskLines.CreateDateTableForJobTaskLines()

            RetCode += clsWmsJob.CreateDateTableForGiacenzeOriTotStock()


            RetCode += clsTaskLinesAssigned.CreateDateTableForTaskLinesAssigned()

            'RetCode += clsAppParameters.CreateDateTableForAppParams()

            RetCode += clsForkLift.CreateDateTableForForkLift
            RetCode += clsForkLift.CreateDateTableForForkLiftWH

            RetCode += clsMonitor.CreateDateTableForMonitorJobs
            RetCode += clsMonitor.CreateDateTableForMonitorQueues

            RetCode += clsInfoMotiviMov.CreateDateTableForMotiviMov


            RetCode += clsWmsJob.CreateDateTableForLockStock()


            CreateDateTableForAllObjects = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetSystemInfoForOperator(ByRef outSystemInfoForOperator As String) As Long
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim workWorkStationName As String
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetSystemInfoForOperator = 0 'init

            workWorkStationName = clsUtility.GetWorkStationName()
            outSystemInfoForOperator = clsAppTranslation.GetSingleParameterValue(1331, Nothing, "Utente:") & clsUser.SapWmsUser.USERID & "-" & clsAppTranslation.GetSingleParameterValue(1332, Nothing, "Dispositivo:") & workWorkStationName
            If (clsUtility.IsStringValid(clsUser.SapWmsUser.ZPICK_QUEUE_DESC, True) = True) Then
                outSystemInfoForOperator = outSystemInfoForOperator + "-" + clsAppTranslation.GetSingleParameterValue(1568, Nothing, "Coda") & ":" & clsUser.SapWmsUser.ZPICK_QUEUE_DESC
            End If
            If (clsUtility.IsStringValid(clsForkLift.CurrentForLift.DescrizioneForkLift, True) = True) Then
                outSystemInfoForOperator = outSystemInfoForOperator + "-" + clsAppTranslation.GetSingleParameterValue(1474, Nothing, "Carrello:") + clsForkLift.CurrentForLift.DescrizioneForkLift + "(MAX:" + Trim(Str(clsForkLift.CurrentForLift.ForkLiftMaxPesoCarico)) + "" + clsForkLift.CurrentForLift.UdmPeso + " #KTAG:" + Trim(Str(clsForkLift.CurrentForLift.NumUdsOnForklift)) + ")"
            End If
            GetSystemInfoForOperator = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetSystemInfoForOperator = 1000 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Function CreateDateTableDetailsForAllObjects() As Long
        ' ************************************************************
        ' DESCRIZIONE : metodo che crea tutti i DATA TABLE delle CLASSI del programma
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableDetailsForAllObjects = 1

            RetCode += clsInfoGiacenze.CreateDateTableDetailsGiacenza()
            RetCode += clsInfoGiacenze.CreateDateTableDetailsSped()
            RetCode += clsInfoCodiceMateriale.CreateDateTableDetails()
            RetCode += clsInfoDisponibilitaMateriale.CreateDateTableDetails()
            RetCode += clsWmsJobsGroup.CreateDateTableDetails()
            RetCode += clsWmsJob.CreateDateTableDetails()

            CreateDateTableDetailsForAllObjects = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableDetailsForAllObjects = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Function DeleteOldLogFilesApplication() As Long
        ' ************************************************************
        ' DESCRIZIONE : metodo che elimina tutti i file di LOG vecchi dalla directory di LOG del programma
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim NumFilesFound As Long = 0
        Dim FilesFound() As IO.FileInfo
        Dim ApplicationLogPath As String
        Dim DateUpperLimit As Date = Date.MinValue

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            DeleteOldLogFilesApplication = 1

            'RECUPERO LA DIRECTORY DEL PROGRAMMA
            ApplicationLogPath = clsUtility.GetApplicationPath()

            ApplicationLogPath = ApplicationLogPath & "\Log"

            'VERIFICO SE IL PATH ESISTE
            If (clsFile.FolderExists(ApplicationLogPath) = False) Then
                DeleteOldLogFilesApplication = RetCode
                Exit Function
            End If

            'CALCOLO LA DATA LIMITE DEI FILE DA CANCELLARE
            DateUpperLimit = Now.Date.AddDays(-30)

            'RECUPERO IL FILE TEMPORANEI
            NumFilesFound = 0
            RetCode = clsFile.GetOldFilesFromDirectory(ApplicationLogPath, DateUpperLimit, FilesFound, NumFilesFound, "*.txt")
            If (RetCode <> 0) Then
                DeleteOldLogFilesApplication = RetCode
                Exit Function
            End If
            If (NumFilesFound > 0) Then
                For Each workFileInfo In FilesFound
                    If (workFileInfo Is Nothing) Then
                        Continue For
                    End If
                    Try
                        RetCode = clsFile.DeleteFile(workFileInfo.FullName, False)
                    Catch ex As Exception

                    End Try
                Next
            End If

            DeleteOldLogFilesApplication = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            DeleteOldLogFilesApplication = 1000  'error case
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function
    Public Function CreateLogFolderForApplication() As Long
        ' ************************************************************
        ' DESCRIZIONE : metodo che crea (se non presente) la cartella di LOG del programma
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim WorkFolder As DirectoryInfo
        Dim ApplicationLogPath As String
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateLogFolderForApplication = 1

            'RECUPERO LA DIRECTORY DEL PROGRAMMA
            ApplicationLogPath = clsUtility.GetApplicationPath()

            ApplicationLogPath = ApplicationLogPath & "\Log"

            'VERIFICO SE IL PATH ESISTE
            If (clsFile.FolderExists(ApplicationLogPath) = True) Then
                CreateLogFolderForApplication = RetCode
                Exit Function
            End If

            'CREO LA DIRECTORY
            Try
                WorkFolder = System.IO.Directory.CreateDirectory(ApplicationLogPath)
            Catch ex As Exception

            End Try



            CreateLogFolderForApplication = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateLogFolderForApplication = 1000  'error case
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function
    Public Function CheckTcPSettingsForApplication() As Long
        ' ************************************************************
        ' DESCRIZIONE : metodo che crea (se non presente) la cartella di LOG del programma
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim regName As String = "\Comm\Tcpip\Parms\"
        Dim tcpipkey As Microsoft.Win32.RegistryKey
        Dim WorkValue As Object
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '************************************** 

            CheckTcPSettingsForApplication = 1

            ' Open the base key for the adapter.
            tcpipkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(regName, True)

            If (tcpipkey Is Nothing) Then
                RetCode = 10
                CheckTcPSettingsForApplication = RetCode
                Exit Function
            End If

            WorkValue = tcpipkey.GetValue("MTU")

            If (WorkValue Is Nothing) Then
                tcpipkey.SetValue("MTU", "750")
                tcpipkey.SetValue("EnablePMTUDiscovery", "0")
            Else
                If (WorkValue <> "750") Then
                    tcpipkey.SetValue("MTU", "750")
                    tcpipkey.SetValue("EnablePMTUDiscovery", "0")
                End If
            End If

            CheckTcPSettingsForApplication = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckTcPSettingsForApplication = 1000  'error case
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function
    Public Function CleanTempFilesApplication() As Long
        ' ************************************************************
        ' DESCRIZIONE : metodo che elimina tutti i file temporanei dalla directory del programma
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim NumFilesFound As Long = 0
        Dim FilesFound() As IO.FileInfo
        Dim ApplicationPath As String
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CleanTempFilesApplication = 1

            'RECUPERO LA DIRECTORY DEL PROGRAMMA
            ApplicationPath = clsUtility.GetApplicationPath()

            'VERIFICO SE IL PATH ESISTE
            If (clsFile.FolderExists(ApplicationPath) = False) Then
                CleanTempFilesApplication = RetCode
                Exit Function
            End If

            'RECUPERO IL FILE TEMPORANEI
            NumFilesFound = 0
            RetCode = clsFile.GetFilesFromDirectory(ApplicationPath, FilesFound, NumFilesFound, "*.tmp")
            If (RetCode <> 0) Then
                CleanTempFilesApplication = RetCode
                Exit Function
            End If
            If (NumFilesFound > 0) Then
                For Each workFileInfo In FilesFound
                    If (workFileInfo Is Nothing) Then
                        Continue For
                    End If
                    Try
                        RetCode = clsFile.DeleteFile(workFileInfo.FullName, False)
                    Catch ex As Exception

                    End Try
                Next
            End If

            'RECUPERO IL FILE TEMPORANEI
            NumFilesFound = 0
            RetCode = clsFile.GetFilesFromDirectory(ApplicationPath, FilesFound, NumFilesFound, "*-*-*-*-*")
            If (RetCode <> 0) Then
                CleanTempFilesApplication = RetCode
                Exit Function
            End If
            If (NumFilesFound > 0) Then
                For Each workFileInfo In FilesFound
                    If (workFileInfo Is Nothing) Then
                        Continue For
                    End If
                    Try
                        RetCode = clsFile.DeleteFile(workFileInfo.FullName, False)
                    Catch ex As Exception

                    End Try
                Next
            End If

            CleanTempFilesApplication = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CleanTempFilesApplication = 1000  'error case
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function
    Public Sub StartThreadForms()
        Try

            If Not frmLoginForm Is Nothing Then
                frmLoginForm.Dispose()
            End If
            frmLoginForm = New frmLogin
            frmLoginForm.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "WsSapAndSwisslogInterface")
        End Try
    End Sub

    Public Function StopApplication(ByVal inAskCloseConfirm As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : metodo principale che fa terminare l'applicativo
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'chiudo le finestre
            If (Not frmMainHomeMenuForm Is Nothing) Then
                frmMainHomeMenuForm.Close()
                frmMainHomeMenuForm = Nothing
            End If

            Application.Exit() '>>>> TERMINO PROGRAMMA

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try


    End Function

    Private Function LeggiFileAppConfigConn() As Long
        ' ************************************************************
        ' DESCRIZIONE : metodo che legge il file [app.config] dell'applicativo
        ' il file contiene tutti i parametri di configurazione dell'applicazione
        ' compresi i parametri di connessione al database
        ' ************************************************************


        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim retCode As Long = 0
        Dim ConfigFullFileName As String = ""
        Dim ConfigXmlDocument As XmlDocument = Nothing
        Dim WorkString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


#If EMULAZIONE_PALMARE = "SI" Then
            SleepTimeThReadMainApplication = 100
            AppMsgBoxTitle = "WM Rf"
            ApplicationMainFormTitle = "eOne-WM Home Menu"
            BemEnableGestioneCommessa = True
            BemOdaEnableSceltaCommessa = True
            BemOdaEnableSceltaDocMatPos = True 
            BemOdaEnableCreaUbicazionePerProd = True
#Else
            'CHECK PARSE (SINTAX).NESSUNA VALIDAZIONE NECESSARIA PERCHE' NON CI SONO SCHEMI DEFINITI
            ConfigFullFileName = clsUtility.GetWorkStationConfigFileName(True)
            retCode = clsXML.LoadXMLFile(ConfigFullFileName, ConfigXmlDocument)
            If ((retCode <> 0) Or (ConfigXmlDocument Is Nothing)) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(908, "", "Attenzione! Non trovato il file di configurazione del programma:") & vbCrLf & "File:" & ConfigFullFileName & vbCrLf & clsAppTranslation.GetSingleParameterValue(909, "", "Verificare la cartella di installazione e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                LeggiFileAppConfigConn = 200 + retCode
                '>>> log error
                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on method [LoadXMLFile]!", Nothing)
                Exit Function
            End If


            Try
#If APPLICAZIONE_WIN32 = "SI" Then
                WorkString = My.Settings.UserRfcWs.ToString
#Else
                WorkString = clsXML.GetXMLSingleElementNodeValue(ConfigXmlDocument, "UserRfcWs")
#End If
                If (WorkString <> "") Then
                    UserRfcWs = WorkString
                Else
                    UserRfcWs = "one"
                End If
            Catch ex As Exception
                UserRfcWs = "one"
                LeggiFileAppConfigConn = 302 + retCode
                '>>> log error
                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on read CONFIG file.Parameter [UserRfcWs]!", Nothing)
            End Try

            Try
#If APPLICAZIONE_WIN32 = "SI" Then
                WorkString = My.Settings.PswUserRfcWs.ToString
#Else
                WorkString = clsXML.GetXMLSingleElementNodeValue(ConfigXmlDocument, "PswUserRfcWs")
#End If
                If (WorkString <> "") Then
                    PswUserRfcWs = WorkString
                Else
                    PswUserRfcWs = "thebest"
                End If
            Catch ex As Exception
                PswUserRfcWs = "thebest"
                LeggiFileAppConfigConn = 303 + retCode
                '>>> log error
                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on read CONFIG file.Parameter [PswUserRfcWs]!", Nothing)
            End Try

            Try
#If APPLICAZIONE_WIN32 = "SI" Then
                WorkString = My.Settings.WsHostName.ToString
#Else
                    WorkString = clsXML.GetXMLSingleElementNodeValue(ConfigXmlDocument, "WsHostName")
#End If
                    If (WorkString <> "") Then
                        WsHostName = WorkString
                    Else
                        WsHostName = "10.126.70.10"
                    End If
            Catch ex As Exception
                WsHostName = "10.126.70.10"
                LeggiFileAppConfigConn = 203 + retCode
                '>>> log error
                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on read CONFIG file.Parameter [ApplicationMainFormTitle]!", Nothing)
            End Try

            Try
#If APPLICAZIONE_WIN32 = "SI" Then
                WorkString = My.Settings.WsPortNumber.ToString
#Else
                WorkString = clsXML.GetXMLSingleElementNodeValue(ConfigXmlDocument, "WsPortNumber")
#End If
                If (WorkString <> "") Then
                    WsPortNumber = WorkString
                Else
                    WsPortNumber = "50040"
                End If
            Catch ex As Exception
                WsPortNumber = "50040"
                LeggiFileAppConfigConn = 204 + retCode
                '>>> log error
                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on read CONFIG file.Parameter [ApplicationMainFormTitle]!", Nothing)
            End Try

            Try
#If APPLICAZIONE_WIN32 = "SI" Then
                WorkString = My.Settings.SapClient.ToString
#Else
                WorkString = clsXML.GetXMLSingleElementNodeValue(ConfigXmlDocument, "SapClient")
#End If
                If (WorkString <> "") Then
                    SapClient = WorkString
                Else
                    SapClient = "100"
                End If
            Catch ex As Exception
                SapClient = "100"
                LeggiFileAppConfigConn = 205 + retCode
                '>>> log error
                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on read CONFIG file.Parameter [ApplicationMainFormTitle]!", Nothing)
            End Try


#End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Private Function LeggiAppParameters() As Long
        ' ************************************************************
        ' DESCRIZIONE : metodo che legge il file [app.config] dell'applicativo
        ' il file contiene tutti i parametri di configurazione dell'applicazione
        ' compresi i parametri di connessione al database
        ' ************************************************************


        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim retCode As Long = 0
        Dim IndexArray As Long = 0
        Dim WorkString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


#If EMULAZIONE_PALMARE = "SI" Then
            SleepTimeThReadMainApplication = 100
            AppMsgBoxTitle = "WM Rf"
            ApplicationMainFormTitle = "eOne-WM Home Menu"
            BemEnableGestioneCommessa = True
            BemOdaEnableSceltaCommessa = True
            BemOdaEnableSceltaDocMatPos = True 
            BemOdaEnableCreaUbicazionePerProd = True
#Else

            Try
                retCode = clsAppParameters.GetSingleParameterValue("SleepTimeApplication", "", "", "", WorkString)
                If (retCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(910, "", "Attenzione! Non trovato il parametro:") & "  SleepTimeApplication" & vbCrLf
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    LeggiAppParameters = 200 + retCode
                    '>>> log error
                    clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on method [LoadXMLFile]!", Nothing)
                    Exit Function
                Else
                    If (Val(WorkString) > 0) Then
                        SleepTimeApplication = Trim(Val(WorkString))
                    Else
                        SleepTimeApplication = 100
                    End If
                End If
            Catch ex As Exception
                SleepTimeApplication = 100
                LeggiAppParameters = 200 + retCode
                '>>> log error
                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on read CONFIG file.Parameter [SleepTimeThReadMainApplication]!", Nothing)
            End Try


            Try
                retCode = clsAppParameters.GetSingleParameterValue("AppMsgBoxTitle", "", "", "", WorkString)
                If (retCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(910, "", "Attenzione! Non trovato il parametro:") & "  AppMsgBoxTitle" & vbCrLf
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    LeggiAppParameters = 200 + retCode
                    '>>> log error
                    clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on method [LoadXMLFile]!", Nothing)
                    Exit Function
                Else
                    If (WorkString <> "") Then
                        AppMsgBoxTitle = WorkString
                    Else
                        AppMsgBoxTitle = "WMS Rf"
                    End If
                End If
            Catch ex As Exception
                AppMsgBoxTitle = "WMS Rf"
                LeggiAppParameters = 201 + retCode
                '>>> log error
                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on read CONFIG file.Parameter [AppMsgBoxTitle]!", Nothing)
            End Try


            Try
                retCode = clsAppParameters.GetSingleParameterValue("ApplMainFormTitle", "", "", "", WorkString)
                If (retCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(910, "", "Attenzione! Non trovato il parametro:") & "  ApplMainFormTitle" & vbCrLf
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    LeggiAppParameters = 200 + retCode
                    '>>> log error
                    clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on method [LoadXMLFile]!", Nothing)
                    Exit Function
                Else
                    If (WorkString <> "") Then
                        ApplMainFormTitle = WorkString
                    Else
                        ApplMainFormTitle = "eOne-WMS Home Menu"
                    End If
                End If
            Catch ex As Exception
                ApplMainFormTitle = "eOne-WM Home Menu"
                LeggiAppParameters = 202 + retCode
                '>>> log error
                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on read CONFIG file.Parameter [ApplicationMainFormTitle]!", Nothing)
            End Try


            Try
                retCode = clsAppParameters.GetSingleParameterValue("NumRecordMaxListaGriglia", "", "", "", WorkString)
                If (retCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(910, "", "Attenzione! Non trovato il parametro:") & "  NumRecordMaxListaGriglia" & vbCrLf
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    LeggiAppParameters = 200 + retCode
                    '>>> log error
                    clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfigConn", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on method [LoadXMLFile]!", Nothing)
                    Exit Function
                Else
                    If (WorkString <> "") Then
                        NumRecordMaxListaGriglia = Val(WorkString)
                    Else
                        NumRecordMaxListaGriglia = 300
                    End If
                End If
            Catch ex As Exception
                NumRecordMaxListaGriglia = 300
                LeggiAppParameters = 206 + retCode
                '>>> log error
                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfigConn", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on read CONFIG file.Parameter [NumRecordMaxListaGriglia]!", Nothing)
            End Try



            Try
                retCode = clsAppParameters.GetSingleParameterValue("BemOdaEnableCreaUbicPerProd", "", "", "", WorkString)
                If (retCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(910, "", "Attenzione! Non trovato il parametro:") & "  BemOdaEnableCreaUbicPerProd" & vbCrLf
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    LeggiAppParameters = 200 + retCode
                    '>>> log error
                    clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on method [LoadXMLFile]!", Nothing)
                    Exit Function
                Else
                    If (WorkString <> "0") Then
                        BemOdaEnableCreaUbicazionePerProd = True
                    Else
                        BemOdaEnableCreaUbicazionePerProd = False
                    End If
                End If
            Catch ex As Exception
                BemOdaEnableCreaUbicazionePerProd = False
                LeggiAppParameters = 220 + retCode
                '>>> log error
                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on read CONFIG file.Parameter [BemOdaEnableCreaUbicazionePerProd]!", Nothing)
            End Try


            Try
                retCode = clsAppParameters.GetSingleParameterValue("EnableFormResizeControls", "", "", "", WorkString)
                If (retCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(910, "", "Attenzione! Non trovato il parametro:") & "  EnableFormResizeControls" & vbCrLf
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    LeggiAppParameters = 200 + retCode
                    '>>> log error
                    clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on method [LoadXMLFile]!", Nothing)
                    Exit Function
                Else
                    If (WorkString = "1") Then
                        EnableFormResizeControls = True
                    Else
                        EnableFormResizeControls = False
                    End If
                End If
            Catch ex As Exception
                EnableFormResizeControls = False
                LeggiAppParameters = 230 + retCode
                '>>> log error
                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on read CONFIG file.Parameter [EnableFormResizeControls]!", Nothing)
            End Try


            Try
                retCode = clsAppParameters.GetSingleParameterValue("EnableFormResizeDiagnostic", "", "", "", WorkString)
                If (retCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(910, "", "Attenzione! Non trovato il parametro:") & "  EnableFormResizeDiagnostic" & vbCrLf
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    LeggiAppParameters = 200 + retCode
                    '>>> log error
                    clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on method [LoadXMLFile]!", Nothing)
                    Exit Function
                Else
                    If (WorkString = "1") Then
                        EnableFormResizeDiagnostic = True
                    Else
                        EnableFormResizeDiagnostic = False
                    End If
                End If
            Catch ex As Exception
                EnableFormResizeDiagnostic = False
                LeggiAppParameters = 231 + retCode
                '>>> log error
                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on read CONFIG file.Parameter [EnableFormResizeDiagnostic]!", Nothing)
            End Try


            Try
                retCode = clsAppParameters.GetSingleParameterValue("SYSTEMNUMBER_TST", "", "", "", WorkString)
                If (retCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(910, "", "Attenzione! Non trovato il parametro:") & "  SYSTEMNUMBER_TST" & vbCrLf
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    LeggiAppParameters = 200 + retCode
                    '>>> log error
                    clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on method [LoadXMLFile]!", Nothing)
                    Exit Function
                Else
                    If (WorkString <> "") Then
                        SYSTEMNUMBER_TST = WorkString
                    Else
                        SYSTEMNUMBER_TST = "40"
                    End If
                End If
            Catch ex As Exception
                SYSTEMNUMBER_TST = 40
                LeggiAppParameters = 200 + retCode
                '>>> log error
                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on read CONFIG file.Parameter [SYSTEMNUMBER_TST]!", Nothing)
            End Try


            Try
                retCode = clsAppParameters.GetSingleParameterValue("SYSTEMNUMBER_PRD", "", "", "", WorkString)
                If (retCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(910, "", "Attenzione! Non trovato il parametro:") & "  SYSTEMNUMBER_PRD" & vbCrLf
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    LeggiAppParameters = 200 + retCode
                    '>>> log error
                    clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on method [LoadXMLFile]!", Nothing)
                    Exit Function
                Else
                    If (WorkString <> "") Then
                        SYSTEMNUMBER_PRD = WorkString
                    Else
                        SYSTEMNUMBER_PRD = "40"
                    End If
                End If
            Catch ex As Exception
                SYSTEMNUMBER_PRD = 40
                LeggiAppParameters = 200 + retCode
                '>>> log error
                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on read CONFIG file.Parameter [SYSTEMNUMBER_PRD]!", Nothing)
            End Try


            Try
                retCode = clsAppParameters.GetSingleParameterValue("SYSTEMID_TST", "", "", "", WorkString)
                If (retCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(910, "", "Attenzione! Non trovato il parametro:") & "  SYSTEMID_TST" & vbCrLf
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    LeggiAppParameters = 200 + retCode
                    '>>> log error
                    clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on method [LoadXMLFile]!", Nothing)
                    Exit Function
                Else
                    If (WorkString <> "") Then
                        SYSTEMID_TST = WorkString
                    Else
                        SYSTEMID_TST = "DEV"
                    End If
                End If
            Catch ex As Exception
                SYSTEMID_TST = "DEV"
                LeggiAppParameters = 200 + retCode
                '>>> log error
                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on read CONFIG file.Parameter [SYSTEMID_TST]!", Nothing)
            End Try


            Try
                retCode = clsAppParameters.GetSingleParameterValue("SYSTEMID_PRD", "", "", "", WorkString)
                If (retCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(910, "", "Attenzione! Non trovato il parametro:") & "  SYSTEMID_PRD" & vbCrLf
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    LeggiAppParameters = 200 + retCode
                    '>>> log error
                    clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on method [LoadXMLFile]!", Nothing)
                    Exit Function
                Else
                    If (WorkString <> "") Then
                        SYSTEMID_PRD = WorkString
                    Else
                        SYSTEMID_PRD = "DEV"
                    End If
                End If
            Catch ex As Exception
                SYSTEMID_PRD = "DEV"
                LeggiAppParameters = 200 + retCode
                '>>> log error
                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on read CONFIG file.Parameter [SYSTEMID_PRD]!", Nothing)
            End Try


            Try
                retCode = clsAppParameters.GetSingleParameterValue("POOLSIZE", "", "", "", WorkString)
                If (retCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(910, "", "Attenzione! Non trovato il parametro:") & "  POOLSIZE" & vbCrLf
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    LeggiAppParameters = 200 + retCode
                    '>>> log error
                    clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on method [LoadXMLFile]!", Nothing)
                    Exit Function
                Else
                    If (Val(WorkString) > 0) Then
                        POOLSIZE = Trim(Val(WorkString))
                    Else
                        POOLSIZE = 5
                    End If
                End If
            Catch ex As Exception
                POOLSIZE = 5
                LeggiAppParameters = 200 + retCode
                '>>> log error
                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on read CONFIG file.Parameter [POOLSIZE]!", Nothing)
            End Try


            Try
                retCode = clsAppParameters.GetSingleParameterValue("MAXPOOLSIZE", "", "", "", WorkString)
                If (retCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(910, "", "Attenzione! Non trovato il parametro:") & "  MAXPOOLSIZE" & vbCrLf
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    LeggiAppParameters = 200 + retCode
                    '>>> log error
                    clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on method [LoadXMLFile]!", Nothing)
                    Exit Function
                Else
                    If (Val(WorkString) > 0) Then
                        MAXPOOLSIZE = Trim(Val(WorkString))
                    Else
                        MAXPOOLSIZE = 10
                    End If
                End If
            Catch ex As Exception
                MAXPOOLSIZE = 10
                LeggiAppParameters = 200 + retCode
                '>>> log error
                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on read CONFIG file.Parameter [MAXPOOLSIZE]!", Nothing)
            End Try


            Try
                retCode = clsAppParameters.GetSingleParameterValue("IDLETIMEOUT", "", "", "", WorkString)
                If (retCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(910, "", "Attenzione! Non trovato il parametro:") & "  IDLETIMEOUT" & vbCrLf
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    LeggiAppParameters = 200 + retCode
                    '>>> log error
                    clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on method [LoadXMLFile]!", Nothing)
                    Exit Function
                Else
                    If (Val(WorkString) > 0) Then
                        IDLETIMEOUT = Trim(Val(WorkString))
                    Else
                        IDLETIMEOUT = 600
                    End If
                End If
            Catch ex As Exception
                IDLETIMEOUT = 600
                LeggiAppParameters = 200 + retCode
                '>>> log error
                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on read CONFIG file.Parameter [IDLETIMEOUT]!", Nothing)
            End Try


            Try
                WorkString = ""
                retCode = clsAppParameters.GetSingleParameterValue("WM_PRN_PLID_GOOD_RECEIPT", "", "", "", WorkString)
                If (retCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(910, "", "Attenzione! Non trovato il parametro:") & "  WM_PRN_PLID_GOOD_RECEIPT" & vbCrLf
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    LeggiAppParameters = 200 + retCode
                    '>>> log error
                    clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on method [LoadXMLFile]!", Nothing)
                    Exit Function
                Else
                    If (WorkString <> "") Then
                        WM_PRN_PLID_GOOD_RECEIPT = WorkString
                    Else
                        WM_PRN_PLID_GOOD_RECEIPT = "ZU02"
                    End If
                End If
            Catch ex As Exception
                IDLETIMEOUT = 600
                LeggiAppParameters = 200 + retCode
                '>>> log error
                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on read CONFIG file.Parameter [WM_PRN_PLID_GOOD_RECEIPT]!", Nothing)
            End Try


            Try
                WorkString = ""
                retCode = clsAppParameters.GetSingleParameterValue("WM_PRN_PLID_SHIPPING", "", "", "", WorkString)
                If (retCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(910, "", "Attenzione! Non trovato il parametro:") & "  WM_PRN_PLID_SHIPPING" & vbCrLf
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    LeggiAppParameters = 200 + retCode
                    '>>> log error
                    clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on method [LoadXMLFile]!", Nothing)
                    Exit Function
                Else
                    If (WorkString <> "") Then
                        WM_PRN_PLID_SHIPPING = WorkString
                    Else
                        WM_PRN_PLID_SHIPPING = "ZU04"
                    End If
                End If
            Catch ex As Exception
                IDLETIMEOUT = 600
                LeggiAppParameters = 200 + retCode
                '>>> log error
                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on read CONFIG file.Parameter [WM_PRN_PLID_SHIPPING]!", Nothing)
            End Try


            Try
                WorkString = ""
                retCode = clsAppParameters.GetSingleParameterValue("EnableCheckProdError", "", "", "", WorkString)
                If (retCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(910, "", "Attenzione! Non trovato il parametro:") & "  EnableCheckProdError" & vbCrLf
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    LeggiAppParameters = 200 + retCode
                    '>>> log error
                    clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on method [LoadXMLFile]!", Nothing)
                    Exit Function
                Else
                    If (WorkString = "1") Then
                        EnableCheckProdError = True
                    Else
                        EnableCheckProdError = False
                    End If
                End If
            Catch ex As Exception
                EnableCheckProdError = False
                LeggiAppParameters = 230 + retCode
                '>>> log error
                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on read CONFIG file.Parameter [EnableCheckProdError]!", Nothing)
            End Try



            'OTTENGO LA RISOLUZIONE DELLO SCHERMO CORRENTE

#If Not APPLICAZIONE_WIN32 = "SI" Then
            PrimaryScreenWidth = Screen.PrimaryScreen.Bounds.Width
            PrimaryScreenHeight = Screen.PrimaryScreen.Bounds.Height
#Else
            'Forzo valori per test
            PrimaryScreenWidth = 1024 '800 'Screen.PrimaryScreen.Bounds.Width
            PrimaryScreenHeight = 768 '600 'Screen.PrimaryScreen.Bounds.Heigh
#End If

            ReDim MagazziniLogiciAvailable01(4)
            MagazziniLogiciAvailable01(0) = "M001"
            MagazziniLogiciAvailable01(1) = "M003"
            MagazziniLogiciAvailable01(2) = "M004"
            MagazziniLogiciAvailable01(3) = "M005"
            MagazziniLogiciAvailable01(4) = "M006"

            ReDim MagazziniLogiciAvailable02(4)
            MagazziniLogiciAvailable02(0) = "M001"
            MagazziniLogiciAvailable02(1) = "M002"
            MagazziniLogiciAvailable02(2) = "M004"
            MagazziniLogiciAvailable02(3) = "M005"
            MagazziniLogiciAvailable02(4) = "M007"

            'LEGGO LE DIVISIONI CONFIGURATE
            For IndexArray = 1 To 5
                ReDim Preserve DivisioniAvailable(UBound(DivisioniAvailable) + 1)
                Try
                    retCode = clsAppParameters.GetSingleParameterValue("DivisioneAvailable" & Trim(IndexArray), "", "", "", WorkString)
                    If (clsUtility.IsStringValid(WorkString, True) = True) Then
                        DivisioniAvailable(IndexArray - 1) = WorkString
                    End If
                Catch ex As Exception
                    LeggiAppParameters = 300 + retCode
                    '>>> log error
                    clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on read CONFIG file.Parameter [DivisioneAvailable]!", Nothing)
                End Try
            Next

            'LEGGO I NUMERI MAGAZZINI CONFIGURATI
            For IndexArray = 1 To 5
                ReDim Preserve NumMagAvailable(UBound(NumMagAvailable) + 1)
                Try
                    retCode = clsAppParameters.GetSingleParameterValue("NumMagAvailable" & Trim(IndexArray), "", "", "", WorkString)
                    If (clsUtility.IsStringValid(WorkString, True) = True) Then
                        NumMagAvailable(IndexArray - 1) = WorkString
                    End If
                Catch ex As Exception
                    LeggiAppParameters = 310 + retCode
                    '>>> log error
                    clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on read CONFIG file.Parameter [NumMagAvailable]!", Nothing)
                End Try
            Next

            'LEGGO LE LINGUE CONFIGURATE
            For IndexArray = 1 To 5
                ReDim Preserve UserLanguageAvailable(UBound(UserLanguageAvailable) + 1)
                Try
                    retCode = clsAppParameters.GetSingleParameterValue("UserLanguage" & Trim(IndexArray), "", "", "", WorkString)
                    If (clsUtility.IsStringValid(WorkString, True) = True) Then
                        UserLanguageAvailable(IndexArray - 1) = WorkString
                    End If
                Catch ex As Exception
                    LeggiAppParameters = 310 + retCode
                    '>>> log error
                    clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LeggiFileAppConfig", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on read CONFIG file.Parameter [UserLanguageAvailable]!", Nothing)
                End Try
            Next




#End If


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Private Function CheckSapConnection() As Long
        ' *******************************************************************************************
        ' DESCRIZIONE : metodo che controlla lo stato della connessione con il database di produzione
        ' ************************************************************
        Dim CheckOk As Boolean = False

        ''**************************************
        ''HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CheckSapConnection = clsSapWS.Call_ZWS_MB_CHECK_CONNECTION("", "", "", "", CheckOk)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Private Function CheckSapRfcConnection() As Long
        ' *******************************************************************************************
        ' DESCRIZIONE : metodo che controlla lo stato della connessione con il database di produzione
        ' ************************************************************
        'Dim RetCode As Long
        'Static MemoLastCheckTime As Long
        'Dim CurrentCheckTime As Long
        'Dim SapConnection As SAP.Connector.SAPConnection = Nothing
        'Dim MemoLastSapConnectionStatus As clsDataType.SapConnectionStatusEnum = clsDataType.SapConnectionStatusEnum.SapConnectionStatusNone
        'Dim DescriptionForMailMessage As String = ""
        ''**************************************
        ''HERE PUT DECLARATION OF LOCAL VARIABLE

        ''**************************************
        'Try 'HERE PUT NORMAL EXECUTION CODE
        '    '**************************************

        '    CurrentCheckTime = System.Environment.TickCount()
        '    If (System.Math.Abs(System.Math.Abs(CurrentCheckTime) - System.Math.Abs(MemoLastCheckTime)) < (DbProductionCheckIntervalTime * 1000)) Then
        '        'clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "CheckDatabaseProductionConnection", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeLog, "CurrentCheckTime:" & CurrentCheckTime & "   MemoLastCheckTime:" & MemoLastCheckTime & "  DbProductionCheckIntervalTime:" & DbProductionCheckIntervalTime, Nothing)
        '        Exit Function
        '    End If

        '    MemoLastCheckTime = CurrentCheckTime

        '    'mi salvo lo stato corrente per vedere se avrà cambiamenti dopo questo controllo
        '    MemoLastSapConnectionStatus = SapConnectionStatus

        '    SapConnection = New SAP.Connector.SAPConnection

        '    SapConnection.ConnectionString = SapConnectionString '"ashost=mnsun202.novellini.it sysnr=66 client=020 passwd=tabata11 user=it-palmar"
        '    If SapConnection.IsOpen = False Then
        '        Try
        '            SapConnection.Open()
        '        Catch ex As Exception
        '            '>>> ERRORE DI CONNESSIONE, SETTO VARIABILE GLOBALE STATO CONNESSIONE
        '            SapConnectionStatus = clsDataType.SapConnectionStatusEnum.SapConnectionStatusError
        '            '>>> log error
        '            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "CheckSapConnection", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error on method [Open] SAP CONNECTION!", Nothing)
        '        End Try
        '    End If

        '    If SapConnection.IsOpen = True Then
        '        SapConnectionStatus = clsDataType.SapConnectionStatusEnum.SapConnectionStatusOk
        '    End If

        '    'nel caso che lo stato della connessione è cambiato allora mando una mail
        '    If (MemoLastSapConnectionStatus <> SapConnectionStatus) And (MemoLastSapConnectionStatus <> clsDataType.SapConnectionStatusEnum.SapConnectionStatusNone) Then
        '        '>>> INVIO MAIL DI SEGNALAZIONE ERRORE AI DIVERSI RESPONSABILI
        '        DescriptionForMailMessage = "Attenzione! Cambio dello stato della comunicazione con SAP." & vbCrLf
        '        Select Case SapConnectionStatus
        '            Case clsDataType.SapConnectionStatusEnum.SapConnectionStatusOk
        '                DescriptionForMailMessage += " CONNESSIONE CON SAP OK "
        '            Case clsDataType.SapConnectionStatusEnum.SapConnectionStatusError
        '                DescriptionForMailMessage += " CONNESSIONE CON SAP IN ERRORE!!! "
        '        End Select
        '        clsUtility.SendMail(ErrorMailFromMailAddressAccount, ErrorMailFromMailAddressDisplayName, ErrorMailToMailAddressArray, "Event On Interface SAP <-> SWISSLOG", DescriptionForMailMessage, ErrorMailSMTP_HostName, ErrorMailUserId, ErrorMailUserPassword)
        '    End If


        '    CheckSapRfcConnection = RetCode

        '    '**************************************
        'Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
        '    'LOG ERROR CONDITION
        '    clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
        '    '**************************************
        'Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION
        '    If (Not (SapConnection Is Nothing)) Then

        '        SapConnectionStatusLastCheckTime = clsUtility.GetDateNowString(False, clsUtility.DateFormatTypeEnum.DateFormatTypeNone, "HH:mm:ss")

        '        SapConnection.Close()

        '        SapConnection = Nothing
        '    End If
        'End Try
    End Function
    Private Function CheckDatabaseProductionConnection() As Long
        '' *******************************************************************************************
        '' DESCRIZIONE : metodo che controlla lo stato della connessione con il database di produzione
        '' ************************************************************
        'Dim RetCode As Long
        'Static MemoLastCheckTime As Long
        'Dim CurrentCheckTime As Long
        'Dim WorkQuery As String
        'Dim WorkDataTable As DataTable = Nothing
        'Dim WorkNumRec As Long
        ''**************************************
        ''HERE PUT DECLARATION OF LOCAL VARIABLE

        ''**************************************
        'Try 'HERE PUT NORMAL EXECUTION CODE
        '    '**************************************

        '    CurrentCheckTime = System.Environment.TickCount()
        '    If (System.Math.Abs(System.Math.Abs(CurrentCheckTime) - System.Math.Abs(MemoLastCheckTime)) < (DbProductionCheckIntervalTime * 1000)) Then
        '        'clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "CheckDatabaseProductionConnection", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeLog, "CurrentCheckTime:" & CurrentCheckTime & "   MemoLastCheckTime:" & MemoLastCheckTime & "  DbProductionCheckIntervalTime:" & DbProductionCheckIntervalTime, Nothing)
        '        Exit Function
        '    End If

        '    MemoLastCheckTime = CurrentCheckTime

        '    'verifico che l'oggetto del DB è valido
        '    If (objDatabaseProductionConnection Is Nothing) Then
        '        clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "CheckDatabaseProductionConnection", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeLog, "LOG: before [OpenDatabaseConnection] method ", Nothing)
        '        RetCode += OpenDatabaseConnection(objDatabaseProductionConnection, DbProductionProviderType, DbDatabaseProductionConnectionString)
        '        clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "CheckDatabaseProductionConnection", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeLog, "LOG: after [OpenDatabaseConnection] method ", Nothing)
        '    End If

        '    'verifico che la connessione è aperta
        '    If (objDatabaseProductionConnection.ConnectionIsOpen = False) Then
        '        clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "CheckDatabaseProductionConnection", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeLog, "LOG: the connection is closed. Now Execute [OpenDatabaseConnection] method ", Nothing)
        '        RetCode += OpenDatabaseConnection(objDatabaseProductionConnection, DbProductionProviderType, DbDatabaseProductionConnectionString)
        '        clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "CheckDatabaseProductionConnection", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeLog, "LOG: the connection is closed. Finish the Execution of [OpenDatabaseConnection] method ", Nothing)
        '    End If

        '    'se arrivo qua devo controllare lo stato della connessione del database
        '    WorkQuery = " SELECT IDKEY FROM T_CHECK_DB_CONNECTION WHERE ROWNUM <= 1 "
        '    RetCode += objDatabaseProductionConnection.ExecuteSelect(WorkQuery, WorkDataTable, WorkNumRec, True)
        '    If (RetCode > 0) Then
        '        '>>>>> ERRORE. SETTO LO STATO AD ERRORE
        '        objDatabaseProductionConnection.DatabaseStatus = clsDb.DbStatus.DbStatusError
        '        objDatabaseProductionConnection.DatabaseStatusLastCheckTime = clsUtility.GetDateNowString(False, clsUtility.DateFormatTypeEnum.DateFormatTypeNone, "HH:mm:ss")
        '        Exit Function
        '    End If
        '    If (WorkNumRec <> 1) Then
        '        '>>>>> ERRORE. SETTO LO STATO AD ERRORE
        '        objDatabaseProductionConnection.DatabaseStatus = clsDb.DbStatus.DbStatusError
        '        objDatabaseProductionConnection.DatabaseStatusLastCheckTime = clsUtility.GetDateNowString(False, clsUtility.DateFormatTypeEnum.DateFormatTypeNone, "HH:mm:ss")
        '        Exit Function
        '    End If

        '    'SE ARRIVO QUA LA CONNESSIONE E' SICURAMENTE FUNZIONANTE
        '    objDatabaseProductionConnection.DatabaseStatus = clsDb.DbStatus.DbStatusOk
        '    objDatabaseProductionConnection.DatabaseStatusLastCheckTime = clsUtility.GetDateNowString(False, clsUtility.DateFormatTypeEnum.DateFormatTypeNone, "HH:mm:ss")

        '    CheckDatabaseProductionConnection = RetCode

        '    '**************************************
        'Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
        '    'LOG ERROR CONDITION
        '    clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
        '    '**************************************
        'Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        'End Try
    End Function

    'Private Function RefreshMonitorFormMainMessage() As Long
    '    ' *****************************************************************
    '    ' DESCRIZIONE : metodo che esegue il refresh delle informazioni di MONITOR
    '    ' delle finestra [frmMainMessages]
    '    ' *****************************************************************

    '    '**************************************
    '    'HERE PUT DECLARATION OF LOCAL VARIABLE
    '    Dim RetCode As Long
    '    Static MemoLastCheckTime As Long
    '    Dim CurrentCheckTime As Long
    '    Dim WorkDbStatusString As String
    '    Dim WorkDbDriveCheckStatusString As String
    '    Dim WorkSapConnectionString As String
    '    Dim ProgresBarValue As Long


    '    '**************************************
    '    Try 'HERE PUT NORMAL EXECUTION CODE
    '        '**************************************

    '        If (frmMainMessagesForm Is Nothing) Then Exit Function
    '        If (frmMainMessagesForm.Visible = False) Then Exit Function


    '        ' >>>>>> REFRESH STATO CONNESSIONE AL DATABASE DI PRODUZIONE
    '        Select Case objDatabaseProductionConnection.DatabaseStatus
    '            Case clsDb.DbStatus.DbStatusOk
    '                WorkDbStatusString = " OK [" & objDatabaseProductionConnection.DatabaseStatusLastCheckTime & "]"
    '                frmMainMessagesForm.txtMonitorDbProductionConnection.Text = WorkDbStatusString
    '                frmMainMessagesForm.txtMonitorDbProductionConnection.ForeColor = Drawing.Color.Lime
    '            Case clsDb.DbStatus.DbStatusError
    '                WorkDbStatusString = " ERROR!!! [" & objDatabaseProductionConnection.DatabaseStatusLastCheckTime & "]"
    '                frmMainMessagesForm.txtMonitorDbProductionConnection.Text = WorkDbStatusString
    '                frmMainMessagesForm.txtMonitorDbProductionConnection.ForeColor = Drawing.Color.Red
    '            Case clsDb.DbStatus.DbStatusNone
    '                WorkDbStatusString = " NONE [" & objDatabaseProductionConnection.DatabaseStatusLastCheckTime & "]"
    '                frmMainMessagesForm.txtMonitorDbProductionConnection.Text = WorkDbStatusString
    '                frmMainMessagesForm.txtMonitorDbProductionConnection.ForeColor = Drawing.Color.White
    '        End Select


    '        ' >>>>>> REFRESH STATO DRIVE DEL DATABASE DI PRODUZIONE
    '        Select Case DbDriveCheckStatus
    '            Case clsDataType.DbDriveCheckEnum.DbDriveCheckOk
    '                WorkDbDriveCheckStatusString = " OK [" & DbDriveCheckStatusLastCheckTime & "]"
    '                frmMainMessagesForm.txtMonitorDbDrive.Text = WorkDbDriveCheckStatusString
    '                frmMainMessagesForm.txtMonitorDbDrive.ForeColor = Drawing.Color.Lime
    '            Case clsDataType.DbDriveCheckEnum.DbDriveCheckError
    '                WorkDbDriveCheckStatusString = " ERROR!!! [" & DbDriveCheckStatusLastCheckTime & "]"
    '                frmMainMessagesForm.txtMonitorDbDrive.Text = WorkDbDriveCheckStatusString
    '                frmMainMessagesForm.txtMonitorDbDrive.ForeColor = Drawing.Color.Red
    '            Case clsDataType.DbDriveCheckEnum.DbDriveCheckNone
    '                WorkDbDriveCheckStatusString = " NONE [" & DbDriveCheckStatusLastCheckTime & "]"
    '                frmMainMessagesForm.txtMonitorDbDrive.Text = WorkDbDriveCheckStatusString
    '                frmMainMessagesForm.txtMonitorDbDrive.ForeColor = Drawing.Color.White
    '        End Select

    '        ' >>>>>> REFRESH STATO CONNESSIONE CON SAP
    '        Select Case SapConnectionStatus
    '            Case clsDataType.SapConnectionStatusEnum.SapConnectionStatusOk
    '                WorkSapConnectionString = " OK [" & DbDriveCheckStatusLastCheckTime & "]"
    '                frmMainMessagesForm.txtMonitorSapConnection.Text = WorkSapConnectionString
    '                frmMainMessagesForm.txtMonitorSapConnection.ForeColor = Drawing.Color.Lime
    '            Case clsDataType.SapConnectionStatusEnum.SapConnectionStatusError
    '                WorkSapConnectionString = " ERROR!!! [" & DbDriveCheckStatusLastCheckTime & "]"
    '                frmMainMessagesForm.txtMonitorSapConnection.Text = WorkSapConnectionString
    '                frmMainMessagesForm.txtMonitorSapConnection.ForeColor = Drawing.Color.Red
    '            Case clsDataType.SapConnectionStatusEnum.SapConnectionStatusNone
    '                WorkSapConnectionString = " NONE [" & DbDriveCheckStatusLastCheckTime & "]"
    '                frmMainMessagesForm.txtMonitorSapConnection.Text = WorkSapConnectionString
    '                frmMainMessagesForm.txtMonitorSapConnection.ForeColor = Drawing.Color.White
    '        End Select



    '        ' >>>>>> FACCIO AVANZAMENTO BARRA RUN >>>>>>>>>>>>>>>>>>>>>>>>>
    '        CurrentCheckTime = System.Environment.TickCount()
    '        If (System.Math.Abs(System.Math.Abs(CurrentCheckTime) - System.Math.Abs(MemoLastCheckTime)) > (0.1 * 1000)) Then
    '            MemoLastCheckTime = CurrentCheckTime
    '            ProgresBarValue = frmMainMessagesForm.prgbarThMainAlive.Value
    '            If (ProgresBarValue < frmMainMessagesForm.prgbarThMainAlive.Maximum) Then
    '                ProgresBarValue += 1
    '            Else
    '                ProgresBarValue = frmMainMessagesForm.prgbarThMainAlive.Minimum
    '            End If
    '            frmMainMessagesForm.prgbarThMainAlive.Value = ProProgresBarValue
    '        End If

    '        If (LastStartUpDate <> DateTime.MinValue) Then
    '            If (frmMainMessagesForm.txtMonitorLastStartup.Text = "") Then
    '                frmMainMessagesForm.txtMonitorLastStartup.Text = Format(LastStartUpDate, "dd/MM/yyyy HH:mm:ss")
    '            End If
    '        End If
    '        RefreshMonitorFormMainMessage = RetCode

    '        '**************************************
    '    Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
    '        'LOG ERROR CONDITION
    '        clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "" , clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
    '        '**************************************
    '    Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

    '    End Try
    'End Function

End Class