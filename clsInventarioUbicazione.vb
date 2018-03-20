' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 03/10/2011
' DATA MODIFICA     : 03/10/2011
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la funzione di INVENTARIO PER UBICAZIONE
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType
Imports clsSapUtility
Imports clsNavigation
Imports clsBusinessLogic
Imports System.Math

Public Class clsInventarioUbicazione

    '*****************************************
    ' >>> TIPI DI DATI
    Public Enum EnumInventoryType
        EnumInventoryTypeNone = 0
        EnumInventoryTypeUbicazione = 1
        EnumInventoryTypeUnitaMagazzino = 2
        EnumInventoryTypeRottamazione = 8
        EnumInventoryTypeCentroCosto = 9
    End Enum


    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsInventarioUbicazione"

    'OGGETTO DATA TABLE PER VISUALIZZARE DATI NELLE GRIGLIE
    Public Shared objDataTableGiacenzeInfo As New DataTable

    '*****************************************
    ' >>> PROPRIETA E VARIABILI
    Public Shared SourceUbicazione As clsDataType.SapWmUbicazione
    Public Shared DestinationUbicazione As clsDataType.SapWmUbicazione
    Public Shared MaterialeGiacenza As clsDataType.SapWmGiacenza

    Public Shared MovimentoPositivo As Boolean
    Public Shared QtOtDaInventario As Double
    Public Shared ConfermataQtaConteggiata As Boolean = False

    Public Shared QtOtSfusiDaInventario As Double
    Public Shared ConfermataQtaSfusiConteggiata As Boolean = False

    Public Shared InventoryType As EnumInventoryType

    Public Shared SapFunctionError As clsBusinessLogic.SapFunctionError
    Public Shared ErrDescription As String


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
            RetCode += clsSapUtility.ResetUbicazioneStruct(DestinationUbicazione)
            RetCode += clsSapUtility.ResetGiacenzaStruct(MaterialeGiacenza)

            MovimentoPositivo = False

            QtOtDaInventario = 0
            ConfermataQtaConteggiata = False
            QtOtSfusiDaInventario = 0
            ConfermataQtaSfusiConteggiata = False

            InventoryType = EnumInventoryType.EnumInventoryTypeNone

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

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ClearForNewPositionRead = 1 'init at error

            RetCode += clsSapUtility.ResetUbicazioneStruct(DestinationUbicazione)
            RetCode += clsSapUtility.ResetGiacenzaStruct(MaterialeGiacenza)

            QtOtDaInventario = 0
            ConfermataQtaConteggiata = False
            QtOtSfusiDaInventario = 0
            ConfermataQtaSfusiConteggiata = False

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
    Public Shared Function ClearGiacenzeInfo() As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ClearGiacenzeInfo = 1 'init at error

            If (Not (objDataTableGiacenzeInfo Is Nothing)) Then
                objDataTableGiacenzeInfo.Rows.Clear()
            End If

            ClearGiacenzeInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ClearGiacenzeInfo = 1000 'IL THREAD E' USCITO DAL LOOP
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
    Public Shared Function AskExecuteOtherInventorySameLocation(ByRef inSourceForm As Form, ByRef outExitFormDone As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE :
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim ErrDescription As String
        Dim UserAnswer As DialogResult
        Dim WorkUbicazione As clsDataType.SapWmUbicazione
        Dim WorkGiacenza As clsDataType.SapWmGiacenza
        Dim GetDataGiacenzeOk As Boolean = False

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            AskExecuteOtherInventorySameLocation = 1 'init at error

            outExitFormDone = False 'init

            Select Case clsInventarioUbicazione.InventoryType
                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUbicazione
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(892, "", "Si desidera eseguire un'altro CONTEGGIO nella stessa UBICAZIONE ?") & clsAppTranslation.GetSingleParameterValue(322, "", "SI/NO")
                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUnitaMagazzino
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(893, "", "Si desidera eseguire un'altro CONTEGGIO nella stessa UNITA DI MAGAZZINO ?") & clsAppTranslation.GetSingleParameterValue(322, "", "SI/NO")
                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeRottamazione
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(894, "", "Si desidera eseguire un'altra ROTTAMAZIONE nella stessa UBICAZIONE ?") & clsAppTranslation.GetSingleParameterValue(322, "", "SI/NO")
                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeCentroCosto
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(895, "", "Si desidera eseguire un'altro CONSUMO nella stessa UBICAZIONE / PALETTA ?") & clsAppTranslation.GetSingleParameterValue(322, "", "SI/NO")
                Case Else
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(599, "", "Tipo Inventario non corretto.(InventoryType)")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Function
            End Select
            UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer = DialogResult.Yes) Then
                RetCode += clsInventarioUbicazione.ClearForNewPositionRead()
                '*******************************************************************************************
                '>>> ESTRAGGO LE GIACENZE CHE CORRISPONDONO AI FILTRI IMMESSI (UBICAZIONE / UNITA MAGAZZINO)
                '*******************************************************************************************
                clsSapUtility.ResetUbicazioneStruct(WorkUbicazione) 'init
                clsSapUtility.ResetGiacenzaStruct(WorkGiacenza) 'init
                Select Case clsInventarioUbicazione.InventoryType
                    Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUbicazione
                        WorkUbicazione = clsInventarioUbicazione.SourceUbicazione
                        WorkUbicazione.UnitaMagazzino = ""
                    Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUnitaMagazzino
                        WorkUbicazione = clsInventarioUbicazione.SourceUbicazione
                    Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeRottamazione, EnumInventoryType.EnumInventoryTypeCentroCosto
                        WorkUbicazione = clsInventarioUbicazione.SourceUbicazione
                        If (clsUtility.IsStringValid(WorkUbicazione.Ubicazione, True) = True) Then
                            WorkUbicazione.UnitaMagazzino = ""
                        End If
                End Select
                RetCode = clsInventarioUbicazione.GetStockGiacenzaInfo(WorkUbicazione, WorkGiacenza, True, GetDataGiacenzeOk)
                If (RetCode <> 0) Or (GetDataGiacenzeOk <> True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(592, "", "Giacenza non trovata.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Function
                End If

                'PARTO NUOVAMENTE DALLO STEP CHE CHIDE IL MATERIALE PER CONTINUARE LA PROCEDURA
                Call clsNavigation.Show_Ope_InventarioUbicazione(inSourceForm, clsInventarioUbicazione.InventoryType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartSeq, True)
                outExitFormDone = True
                Exit Function
            Else
                'ESCO DALLA PROCEDURA => TORNO AL MENU CONTESTUALE
                RetCode = clsNavigation.Show_Mnu_Main_Inventario(inSourceForm, True)
                outExitFormDone = True
                Exit Function
            End If


            AskExecuteOtherInventorySameLocation = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            AskExecuteOtherInventorySameLocation = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function FromInventarioStructsToString(Optional ByVal inShowMode As Long = 0) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim tmpString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            FromInventarioStructsToString = ""

            'inShowMode = 0 (DEFAULT)
            Select Case inShowMode
                Case 0
                    tmpString += clsAppTranslation.GetSingleParameterValue(847, "", "DIV:")
                    tmpString += UCase(SourceUbicazione.Divisione) + "-"
                    tmpString += clsAppTranslation.GetSingleParameterValue(848, "", "UBI:")
                    tmpString += UCase(SourceUbicazione.TipoMagazzino) + "-"
                    tmpString += UCase(SourceUbicazione.Ubicazione)
                    tmpString += vbCrLf


                    tmpString += clsAppTranslation.GetSingleParameterValue(850, "", "COD.MAT.:")
                    tmpString += UCase(MaterialeGiacenza.CodiceMateriale)

                    tmpString += " - "

                    tmpString += clsAppTranslation.GetSingleParameterValue(860, "", "DES:") + UCase(MaterialeGiacenza.DescrizioneMateriale)

                    tmpString += vbCrLf

                    If (clsUtility.IsStringValid(MaterialeGiacenza.Partita, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(851, "", "PARTITA:")
                        tmpString += UCase(MaterialeGiacenza.Partita)
                        tmpString += vbCrLf
                    End If

                    If (clsUtility.IsStringValid(MaterialeGiacenza.TipoStock, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(896, "", "TIPO STOCK:")
                        tmpString += UCase(MaterialeGiacenza.TipoStock)
                        tmpString += vbCrLf
                    End If

                    tmpString += clsAppTranslation.GetSingleParameterValue(897, "", "QTA DISPO:") + UCase(MaterialeGiacenza.QtaTotaleLquaDispoUdMAcq) + " " + UCase(MaterialeGiacenza.UnitaDiMisuraAcquisizione)

                    tmpString += " - ( " + MaterialeGiacenza.GesmeQtyUser + " ) "

                    'If (MaterialeGiacenza.VarianteImballo.ScatolePerPallet > 0) Then
                    '    tmpString += clsAppTranslation.GetSingleParameterValue(854, "", " - Q.PAL:") + Str(MaterialeGiacenza.VarianteImballo.ScatolePerPallet) + " " + UCase(MaterialeGiacenza.UnitaDiMisuraAcquisizione)
                    'End If

                    tmpString += vbCrLf

                    If (MaterialeGiacenza.VarianteImballo.ScatolePerPallet > 0) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(1217, "", "SCATOLE x PL:") + Trim(Val(MaterialeGiacenza.VarianteImballo.ScatolePerPallet)) + " " + UCase(MaterialeGiacenza.UnitaDiMisuraAcquisizione) + " - "
                        tmpString += clsAppTranslation.GetSingleParameterValue(1472, "", "PZ x SC:") + Trim(Val(MaterialeGiacenza.VarianteImballo.PezziPerScatola)) + " " + UCase(MaterialeGiacenza.UnitaDiMisuraPezzo)
                        tmpString += vbCrLf
                    End If

                    If (clsUtility.IsStringValid(SourceUbicazione.UnitaMagazzino, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(857, "", "UM ORI:")
                        tmpString += UCase(SourceUbicazione.UnitaMagazzino)
                        tmpString += vbCrLf
                    End If

            End Select

            FromInventarioStructsToString = tmpString

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            FromInventarioStructsToString = ""
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function ExecTrasferimentoPerInventario(ByRef inSourceForm As Form, ByVal inCodMotiviMovimento As String, ByVal inShowMessageBox As Boolean, ByRef outFlagErroreAttivo As Boolean, ByRef outMessageDescription As String) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim OT_Info As New StrctSapWMSOtInfo
        Dim OT_Executed_Ok As Boolean = False
        Dim OT_Da_Inv_Executed_Number As String = ""
        Dim Mov_Executed_Ok As Boolean = False
        Dim InfoLocazioneMovimento As String = ""
        Dim outDocumentoMateriale As clsDataType.SapWmDocumentoMateriale
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ExecTrasferimentoPerInventario = 1

            '**************************************************************************************************************
            '>>> VERIFICO PER SICUREZZA SE HO UNA DIFFERENZA DI INVENTARIO
            '**************************************************************************************************************
            RetCode = clsSapUtility.ResetSapOtInfoStruct(OT_Info)
            If ((clsInventarioUbicazione.QtOtDaInventario = 0) And (clsInventarioUbicazione.QtOtSfusiDaInventario = 0)) Then
                Exit Function
            End If

            outMessageDescription = ""


            '**************************************************************************************************************
            '>>> PREPARO LE INFORMAZIONI PER ESEGUIRE L'OT DA INVENTARIO (CONTEGGIO MAGGIORE O MINORE DEL REALE)
            '**************************************************************************************************************
#If Not APPLICAZIONE_WIN32 = "SI" Then

            OT_Info.SapOtInfo_Rec.IAnfme = Abs(clsInventarioUbicazione.QtOtDaInventario) 'QUANTITA DA TRASFERIRE
            OT_Info.SapOtInfo_Rec.IAltme = clsInventarioUbicazione.MaterialeGiacenza.UnitaDiMisuraAcquisizione  'UDM
            'IMPOSTO TIPO MOVIMENTO
            OT_Info.SapOtInfo_Rec.IBwlvs = "999"
            OT_Info.SapOtInfo_Rec.ISquit = "X" '>>> OT CONFERMATO
            OT_Info.SapOtInfo_Rec.ILgnum = clsInventarioUbicazione.SourceUbicazione.NumeroMagazzino
            OT_Info.SapOtInfo_Rec.IWerks = clsInventarioUbicazione.SourceUbicazione.Divisione
            OT_Info.SapOtInfo_Rec.IMatnr = clsInventarioUbicazione.MaterialeGiacenza.CodiceMateriale
            OT_Info.SapOtInfo_Rec.ICharg = clsInventarioUbicazione.MaterialeGiacenza.Partita
            OT_Info.SapOtInfo_Rec.ILetyp = clsInventarioUbicazione.SourceUbicazione.TipoUnitaMagazzino

            '>>> GESTIONE EVENTUALE STOCK SPECIALE 'E'
            OT_Info.SapOtInfo_Rec.IBestq = clsInventarioUbicazione.MaterialeGiacenza.TipoStock
            OT_Info.SapOtInfo_Rec.ISobkz = clsInventarioUbicazione.MaterialeGiacenza.CdStockSpeciale
            OT_Info.SapOtInfo_Rec.ISonum = clsInventarioUbicazione.MaterialeGiacenza.NumeroStockSpeciale

            Select Case clsInventarioUbicazione.InventoryType
                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUbicazione, clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUnitaMagazzino
                    If (clsInventarioUbicazione.QtOtDaInventario > 0) Then
                        '*********************************************************************
                        '>>> SE HO QTA > 0 DEVO PRENDERE IL MATERIALE DAL MAGAZZINO INVENTARIO

                        '>>>> IMPOSTO DATI UBICAZIONE ORIGINE (LI PRENDO DALL'INVENTARIO RETTIFICA/ROTTAMAZIONE)
                        OT_Info.SapOtInfo_Rec.IVltyp = DefaultTipoMagInvRettifica
                        OT_Info.SapOtInfo_Rec.IVlpla = DefaultUbicazioneInvRettifica
                        OT_Info.SapOtInfo_Rec.IVlenr = "" '>>> IN UBICAZIONE INVENTARIO NON E' GESTITA L'UNITA MAGAZZINO

                        '>>>> IMPOSTO DATI UBICAZIONE DESTINAZIONE CHE E' L'UBICAZIONE INVENTARIATA
                        OT_Info.SapOtInfo_Rec.INltyp = clsInventarioUbicazione.SourceUbicazione.TipoMagazzino
                        OT_Info.SapOtInfo_Rec.INlpla = clsInventarioUbicazione.SourceUbicazione.Ubicazione
                        OT_Info.SapOtInfo_Rec.INlenr = clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(clsInventarioUbicazione.SourceUbicazione.UnitaMagazzino)
                    Else
                        '*********************************************************************
                        '>>> SE HO QTA < 0 DEVO PRENDERE IL MATERIALE DAL MAGAZZINO MERCI

                        '>>>> IMPOSTO DATI UBICAZIONE ORIGINE (LI PRENDO DALL'INVENTARIO RETTIFICA)
                        OT_Info.SapOtInfo_Rec.IVltyp = clsInventarioUbicazione.SourceUbicazione.TipoMagazzino
                        OT_Info.SapOtInfo_Rec.IVlpla = clsInventarioUbicazione.SourceUbicazione.Ubicazione
                        OT_Info.SapOtInfo_Rec.IVlenr = clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(clsInventarioUbicazione.SourceUbicazione.UnitaMagazzino)

                        OT_Info.SapOtInfo_Rec.INltyp = DefaultTipoMagInvRettifica
                        OT_Info.SapOtInfo_Rec.INlpla = DefaultUbicazioneInvRettifica
                        OT_Info.SapOtInfo_Rec.INlenr = "" '>>> IN UBICAZIONE INVENTARIO NON E' GESTITA L'UNITA MAGAZZINO
                    End If
                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeRottamazione
                    '*********************************************************************
                    '>>> NELLA ROTTAMAZIONE DEVO PRENDERE IL MATERIALE DAL MAGAZZINO MERCI

                    '>>>> IMPOSTO DATI UBICAZIONE ORIGINE (LI PRENDO DALL'INVENTARIO RETTIFICA/ROTTAMAZIONE)
                    OT_Info.SapOtInfo_Rec.IVltyp = clsInventarioUbicazione.SourceUbicazione.TipoMagazzino
                    OT_Info.SapOtInfo_Rec.IVlpla = clsInventarioUbicazione.SourceUbicazione.Ubicazione
                    OT_Info.SapOtInfo_Rec.IVlenr = clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(clsInventarioUbicazione.SourceUbicazione.UnitaMagazzino)

                    OT_Info.SapOtInfo_Rec.INltyp = DefaultTipoMagInvRottamazione
                    OT_Info.SapOtInfo_Rec.INlpla = DefaultUbicazioneInvRottamazione
                    OT_Info.SapOtInfo_Rec.INlenr = "" '>>> IN UBICAZIONE INVENTARIO NON E' GESTITA L'UNITA MAGAZZINO
                Case Else
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(599, "", "Tipo Inventario non corretto.(InventoryType)")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Function
            End Select

#Else

            OT_Info.rfcSapOtInfo_Rec.IAnfme = Abs(clsInventarioUbicazione.QtOtDaInventario) 'QUANTITA DA TRASFERIRE PER INVENTARIO IN UDM CONSEGNA
            OT_Info.rfcSapOtInfo_Rec.IAltme = clsInventarioUbicazione.MaterialeGiacenza.UnitaDiMisuraAcquisizione  'UDM
            OT_Info.rfcSapOtInfo_Rec.IQtaExecutedSfusi = Abs(clsInventarioUbicazione.QtOtSfusiDaInventario) 'QUANTITA SFUSI DA TRASFERIRE PER INVENTARIO IN UDM PEZZO

            If (Abs(clsInventarioUbicazione.QtOtSfusiDaInventario) > 0) Then
                OT_Info.rfcSapOtInfo_Rec.IAltme = clsInventarioUbicazione.MaterialeGiacenza.UnitaDiMisuraPezzo
            End If


            'IMPOSTO TIPO MOVIMENTO
            OT_Info.rfcSapOtInfo_Rec.IBwlvs = "999"
            OT_Info.rfcSapOtInfo_Rec.ISquit = "X" '>>> OT CONFERMATO
            OT_Info.rfcSapOtInfo_Rec.ILgort = clsInventarioUbicazione.MaterialeGiacenza.MagazzinoLogico
            OT_Info.rfcSapOtInfo_Rec.ILgnum = clsInventarioUbicazione.SourceUbicazione.NumeroMagazzino
            OT_Info.rfcSapOtInfo_Rec.IWerks = clsInventarioUbicazione.SourceUbicazione.Divisione
            OT_Info.rfcSapOtInfo_Rec.IMatnr = clsInventarioUbicazione.MaterialeGiacenza.CodiceMateriale
            OT_Info.rfcSapOtInfo_Rec.ICharg = clsInventarioUbicazione.MaterialeGiacenza.Partita
            OT_Info.rfcSapOtInfo_Rec.ILetyp = clsInventarioUbicazione.SourceUbicazione.TipoUnitaMagazzino

            '>>> GESTIONE EVENTUALE STOCK SPECIALE 'E'
            OT_Info.rfcSapOtInfo_Rec.IBestq = clsInventarioUbicazione.MaterialeGiacenza.TipoStock
            OT_Info.rfcSapOtInfo_Rec.ISobkz = clsInventarioUbicazione.MaterialeGiacenza.CdStockSpeciale
            OT_Info.rfcSapOtInfo_Rec.ISonum = clsInventarioUbicazione.MaterialeGiacenza.NumeroStockSpeciale

            Select Case clsInventarioUbicazione.InventoryType
                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUbicazione, clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUnitaMagazzino
                    If (clsInventarioUbicazione.MovimentoPositivo = True) Then
                        '***********************************************************************************
                        '>>> SE HO QTA > 0 DEVO PRENDERE IL MATERIALE DAL MAGAZZINO INVENTARIO
                        '***********************************************************************************

                        '>>>> IMPOSTO DATI UBICAZIONE ORIGINE (LI PRENDO DALL'INVENTARIO RETTIFICA/ROTTAMAZIONE)
                        OT_Info.rfcSapOtInfo_Rec.IVltyp = DefaultTipoMagInvRettifica
                        OT_Info.rfcSapOtInfo_Rec.IVlpla = DefaultUbicazioneInvRettifica
                        OT_Info.rfcSapOtInfo_Rec.IVlenr = "" '>>> IN UBICAZIONE INVENTARIO NON E' GESTITA L'UNITA MAGAZZINO

                        '>>>> IMPOSTO DATI UBICAZIONE DESTINAZIONE CHE E' L'UBICAZIONE INVENTARIATA
                        OT_Info.rfcSapOtInfo_Rec.INltyp = clsInventarioUbicazione.SourceUbicazione.TipoMagazzino
                        OT_Info.rfcSapOtInfo_Rec.INlpla = clsInventarioUbicazione.SourceUbicazione.Ubicazione
                        OT_Info.rfcSapOtInfo_Rec.INlenr = clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(clsInventarioUbicazione.SourceUbicazione.UnitaMagazzino)

                        InfoLocazioneMovimento = clsInventarioUbicazione.SourceUbicazione.TipoMagazzino & "-" & clsInventarioUbicazione.SourceUbicazione.Ubicazione 'IMPOSTO INFO UBICAZIONE PER MAIL MOVIMENTO
                    Else
                        '***********************************************************************************
                        '>>> SE HO QTA < 0 DEVO PRENDERE IL MATERIALE DAL MAGAZZINO MERCI
                        '***********************************************************************************

                        '>>>> IMPOSTO DATI UBICAZIONE ORIGINE (LI PRENDO DALL'INVENTARIO RETTIFICA)
                        OT_Info.rfcSapOtInfo_Rec.IVltyp = clsInventarioUbicazione.SourceUbicazione.TipoMagazzino
                        OT_Info.rfcSapOtInfo_Rec.IVlpla = clsInventarioUbicazione.SourceUbicazione.Ubicazione
                        OT_Info.rfcSapOtInfo_Rec.IVlenr = clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(clsInventarioUbicazione.SourceUbicazione.UnitaMagazzino)

                        OT_Info.rfcSapOtInfo_Rec.INltyp = DefaultTipoMagInvRettifica
                        OT_Info.rfcSapOtInfo_Rec.INlpla = DefaultUbicazioneInvRettifica
                        OT_Info.rfcSapOtInfo_Rec.INlenr = "" '>>> IN UBICAZIONE INVENTARIO NON E' GESTITA L'UNITA MAGAZZINO

                        InfoLocazioneMovimento = clsInventarioUbicazione.SourceUbicazione.TipoMagazzino & "-" & clsInventarioUbicazione.SourceUbicazione.Ubicazione 'IMPOSTO INFO UBICAZIONE PER MAIL MOVIMENTO
                    End If
                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeRottamazione
                    '***********************************************************************************
                    '>>> NELLA ROTTAMAZIONE DEVO PRENDERE IL MATERIALE DAL MAGAZZINO MERCI
                    '***********************************************************************************

                    '>>>> IMPOSTO DATI UBICAZIONE ORIGINE (LI PRENDO DALL'INVENTARIO RETTIFICA/ROTTAMAZIONE)
                    OT_Info.rfcSapOtInfo_Rec.IVltyp = clsInventarioUbicazione.SourceUbicazione.TipoMagazzino
                    OT_Info.rfcSapOtInfo_Rec.IVlpla = clsInventarioUbicazione.SourceUbicazione.Ubicazione
                    OT_Info.rfcSapOtInfo_Rec.IVlenr = clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(clsInventarioUbicazione.SourceUbicazione.UnitaMagazzino)

                    OT_Info.rfcSapOtInfo_Rec.INltyp = DefaultTipoMagInvRottamazione
                    OT_Info.rfcSapOtInfo_Rec.INlpla = DefaultUbicazioneInvRottamazione
                    OT_Info.rfcSapOtInfo_Rec.INlenr = "" '>>> IN UBICAZIONE INVENTARIO NON E' GESTITA L'UNITA MAGAZZINO

                    InfoLocazioneMovimento = clsInventarioUbicazione.SourceUbicazione.TipoMagazzino & "-" & clsInventarioUbicazione.SourceUbicazione.Ubicazione 'IMPOSTO INFO UBICAZIONE PER MAIL MOVIMENTO

                Case Else
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(599, "", "Tipo Inventario non corretto.(InventoryType)")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Function
            End Select


#End If


            ErrDescription = ""
            RetCode = clsBusinessLogic.InitSapFunctionError(SapFunctionError)
            'ESEGUO OT IN SAP (OT PER TRASFERIMENTO NORMALE)
            RetCode = clsSapWS.Call_ZWS_MB_EXEC_WM_WMS_TO(OT_Info, False, OT_Executed_Ok, SapFunctionError, OT_Da_Inv_Executed_Number, False)
            If (RetCode <> 0) Then
                outFlagErroreAttivo = True '>>> CONDIZIONE DI ERRORE => SETTO IL FLAG
                outMessageDescription = outMessageDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(803, "", "Attenzione!Errore nel trasferimento da Inventario.")
            Else
                outFlagErroreAttivo = False
                '>>> TUTTO OK
                outMessageDescription = outMessageDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(804, "", "Trasferimento inventario eseguito con successo. OT NUM:") & OT_Da_Inv_Executed_Number
            End If

            '**************************************************************************************************************
            '>>> SE ABILITATO ESEGUO ANCHE IL MOVIMENTO LOGICO DI INVENTARIO ( SOLO SE OT E' STATO ESEGUITO OK )
            '**************************************************************************************************************
            Mov_Executed_Ok = False
            If (Default_Inventario_EnableExecMovimentoLogico = True) And (outFlagErroreAttivo = False) Then
                RetCode = ExecMovimentoLogicoPerInventario(inSourceForm, inCodMotiviMovimento, InfoLocazioneMovimento, False, Mov_Executed_Ok, outFlagErroreAttivo, outMessageDescription, outDocumentoMateriale)
                If (RetCode <> 0) Or (Mov_Executed_Ok = False) Then
                    'VISUALIZZO FINESTRA PER MESSAGGI OPERATORE
                    frmMessageForUserForm = New frmMessageForUser
                    frmMessageForUserForm.SourceForm = inSourceForm 'setto riferimento a FORM per ricaricarla prima di chiudere la finestra del messaggio.
                    frmMessageForUserForm.ShowMessage(outMessageDescription)
                    Exit Function
                End If
            End If


            'VISUALIZZO FINESTRA PER MESSAGGI OPERATORE
            frmMessageForUserForm = New frmMessageForUser
            frmMessageForUserForm.SourceForm = inSourceForm 'setto riferimento a FORM per ricaricarla prima di chiudere la finestra del messaggio.
            frmMessageForUserForm.ShowMessage(outMessageDescription)


            ExecTrasferimentoPerInventario = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ExecTrasferimentoPerInventario = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function ExecMovimentoLogicoPerInventario(ByRef inSourceForm As Form, ByVal inCodMotiviMovimento As String, ByVal inInfoLocazioneMovimento As String, ByVal inShowMessageBox As Boolean, ByRef outMov_Executed_Ok As Boolean, ByRef outFlagErroreAttivo As Boolean, ByRef outMessageDescription As String, ByRef outDocumentoMateriale As clsDataType.SapWmDocumentoMateriale) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim Mov_InfoStock As New StrctGoodMovMB11CreateStock

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ExecMovimentoLogicoPerInventario = 1

#If Not APPLICAZIONE_WIN32 = "SI" Then

            outFlagErroreAttivo = False
            outMov_Executed_Ok = False

            '>>> IMPOSTO DATI DI TESTATA
            Mov_InfoStock.BILL_OF_LADING = ""
            'Mov_InfoStockQ.DOC_DATE = ""
            Mov_InfoStock.GR_GI_SLIP_NO = ""
            Mov_InfoStock.LGNUM = clsInventarioUbicazione.SourceUbicazione.NumeroMagazzino
            Mov_InfoStock.LQNUM = ""
            'Mov_InfoStock.PSTNG_DATE = ""
            Mov_InfoStock.REF_DOC_NO = ""
            Mov_InfoStock.SOBKZ = clsInventarioUbicazione.MaterialeGiacenza.CdStockSpeciale
            Mov_InfoStock.SONUM = clsInventarioUbicazione.MaterialeGiacenza.NumeroStockSpeciale
            Mov_InfoStock.LENUM = ""

            '>>> IMPOSTO DATI DI ITEM DEL MOVIMENTO
            Mov_InfoStock.SapMovCreateItem_Rec.Material = clsInventarioUbicazione.MaterialeGiacenza.CodiceMateriale
            Mov_InfoStock.SapMovCreateItem_Rec.Batch = clsInventarioUbicazione.MaterialeGiacenza.Partita
            Mov_InfoStock.SapMovCreateItem_Rec.Plant = clsInventarioUbicazione.SourceUbicazione.Divisione
            Mov_InfoStock.SapMovCreateItem_Rec.StgeLoc = clsInventarioUbicazione.MaterialeGiacenza.MagazzinoLogico  '">>> MAGAZZINO LOGICO


            If (Default_Inventario_EnableExecMotiviMovimentoLogico = True) Then

                'Motivi Movimenti dinamici inseriti dall'utente 

                Select Case clsInventarioUbicazione.InventoryType

                    Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUbicazione, clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUnitaMagazzino
                        Mov_InfoStock.LGTYP = DefaultTipoMagInvRettifica
                        Mov_InfoStock.LGPLA = DefaultUbicazioneInvRettifica
                        If (clsInventarioUbicazione.QtOtDaInventario > 0) Then
                            '>>> RETTIFICA POSITIVA (561)
                            Mov_InfoStock.SapMovCreateItem_Rec.MoveType = Default_Inventario_TipoMov_RettificaPositiva
                            Mov_InfoStock.HEADER_TEXT = clsAppTranslation.GetSingleParameterValue(898, "", "RETT.UBI/UM POSITIVA")
                            Mov_InfoStock.SapMovCreateItem_Rec.MoveReas = inCodMotiviMovimento
                        Else
                            '>>> RETTIFICA POSITIVA (562)
                            Mov_InfoStock.SapMovCreateItem_Rec.MoveType = Default_Inventario_TipoMov_RettificaNegativa
                            Mov_InfoStock.HEADER_TEXT = clsAppTranslation.GetSingleParameterValue(899, "", "RETT.UBI/UM NEGATIVA")
                            Mov_InfoStock.SapMovCreateItem_Rec.MoveReas = inCodMotiviMovimento
                        End If
                    Case EnumInventoryType.EnumInventoryTypeRottamazione
                        Mov_InfoStock.LGTYP = DefaultTipoMagInvRettifica
                        Mov_InfoStock.LGPLA = DefaultUbicazioneInvRottamazione
                        Mov_InfoStock.SapMovCreateItem_Rec.MoveType = Default_Inventario_TipoMov_Rottamazione
                        Mov_InfoStock.HEADER_TEXT = clsAppTranslation.GetSingleParameterValue(900, "", "RETT. X ROTTAMAZIONE")
                        Mov_InfoStock.SapMovCreateItem_Rec.MoveReas = inCodMotiviMovimento
                    Case EnumInventoryType.EnumInventoryTypeCentroCosto

                    Case Else
                        outFlagErroreAttivo = True '>>> SETTO FLAG DI ERRORE RILEVATO
                        outMessageDescription = clsAppTranslation.GetSingleParameterValue(901, "", "Attenzione, Tipo movimento INVENTARIO errato.")
                        If (inShowMessageBox = True) Then
                            MessageBox.Show(outMessageDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        End If
                        Exit Function
                End Select

            Else

                'Motivi Movimenti fissi nel codice

                Select Case clsInventarioUbicazione.InventoryType

                    Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUbicazione, clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUnitaMagazzino
                        Mov_InfoStock.LGTYP = DefaultTipoMagInvRettifica
                        Mov_InfoStock.LGPLA = DefaultUbicazioneInvRettifica
                        If (clsInventarioUbicazione.QtOtDaInventario > 0) Then
                            '>>> RETTIFICA POSITIVA (561)
                            Mov_InfoStock.SapMovCreateItem_Rec.MoveType = Default_Inventario_TipoMov_RettificaPositiva
                            Mov_InfoStock.HEADER_TEXT = clsAppTranslation.GetSingleParameterValue(898, "", "RETT.UBI/UM POSITIVA")
                            Mov_InfoStock.SapMovCreateItem_Rec.MoveReas = "5611"
                        Else
                            '>>> RETTIFICA POSITIVA (562)
                            Mov_InfoStock.SapMovCreateItem_Rec.MoveType = Default_Inventario_TipoMov_RettificaNegativa
                            Mov_InfoStock.HEADER_TEXT = clsAppTranslation.GetSingleParameterValue(899, "", "RETT.UBI/UM NEGATIVA")
                            Mov_InfoStock.SapMovCreateItem_Rec.MoveReas = "5621"
                        End If
                    Case EnumInventoryType.EnumInventoryTypeRottamazione
                        Mov_InfoStock.LGTYP = DefaultTipoMagInvRettifica
                        Mov_InfoStock.LGPLA = DefaultUbicazioneInvRottamazione
                        Mov_InfoStock.SapMovCreateItem_Rec.MoveType = Default_Inventario_TipoMov_Rottamazione
                        Mov_InfoStock.HEADER_TEXT = clsAppTranslation.GetSingleParameterValue(900, "", "RETT. X ROTTAMAZIONE")
                        Mov_InfoStock.SapMovCreateItem_Rec.MoveReas = "5511"
                    Case EnumInventoryType.EnumInventoryTypeCentroCosto

                    Case Else
                        outFlagErroreAttivo = True '>>> SETTO FLAG DI ERRORE RILEVATO
                        outMessageDescription = clsAppTranslation.GetSingleParameterValue(901, "", "Attenzione, Tipo movimento INVENTARIO errato.")
                        If (inShowMessageBox = True) Then
                            MessageBox.Show(outMessageDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        End If
                        Exit Function
                End Select

            End If


            Mov_InfoStock.SapMovCreateItem_Rec.StckType = clsInventarioUbicazione.MaterialeGiacenza.TipoStock
            Mov_InfoStock.SapMovCreateItem_Rec.SpecStock = clsInventarioUbicazione.MaterialeGiacenza.CdStockSpeciale
            Mov_InfoStock.SapMovCreateItem_Rec.EntryQnt = Abs(clsInventarioUbicazione.QtOtDaInventario)
            Mov_InfoStock.SapMovCreateItem_Rec.EntryUom = clsInventarioUbicazione.MaterialeGiacenza.UnitaDiMisuraAcquisizione

            Mov_InfoStock.SapMovCreateItem_Rec.PoNumber = ""
            Mov_InfoStock.SapMovCreateItem_Rec.PoItem = ""

            'Mov_InfoStock.SapMovCreateItem_Rec.RefDocYr = Now.Year
            Mov_InfoStock.SapMovCreateItem_Rec.RefDoc = ""
            Mov_InfoStock.SapMovCreateItem_Rec.RefDocIt = ""

            Mov_InfoStock.SapMovCreateItem_Rec.ValSalesOrd = ""
            Mov_InfoStock.SapMovCreateItem_Rec.ValSOrdItem = ""

#Else

            outFlagErroreAttivo = False
            outMov_Executed_Ok = False

            '>>> IMPOSTO DATI DI TESTATA
            Mov_InfoStock.BILL_OF_LADING = ""
            'Mov_InfoStockQ.DOC_DATE = ""
            Mov_InfoStock.GR_GI_SLIP_NO = ""
            Mov_InfoStock.LGNUM = clsInventarioUbicazione.SourceUbicazione.NumeroMagazzino
            Mov_InfoStock.LQNUM = ""
            'Mov_InfoStock.PSTNG_DATE = ""
            Mov_InfoStock.REF_DOC_NO = ""
            Mov_InfoStock.SOBKZ = clsInventarioUbicazione.MaterialeGiacenza.CdStockSpeciale
            Mov_InfoStock.SONUM = clsInventarioUbicazione.MaterialeGiacenza.NumeroStockSpeciale
            Mov_InfoStock.LENUM = ""
            Mov_InfoStock.InfoLocazioneMovimento = inInfoLocazioneMovimento

            '>>> IMPOSTO DATI DI ITEM DEL MOVIMENTO
            Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.materialField = clsInventarioUbicazione.MaterialeGiacenza.CodiceMateriale
            Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.batchField = clsInventarioUbicazione.MaterialeGiacenza.Partita
            Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.plantField = clsInventarioUbicazione.SourceUbicazione.Divisione
            Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.stgeLocField = clsInventarioUbicazione.MaterialeGiacenza.MagazzinoLogico  '">>> MAGAZZINO LOGICO


            If (Default_Inventario_EnableExecMotiviMovimentoLogico = True) Then

                'Motivi Movimenti dinamici inseriti dall'utente 

                Select Case clsInventarioUbicazione.InventoryType

                    Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUbicazione, clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUnitaMagazzino
                        Mov_InfoStock.LGTYP = DefaultTipoMagInvRettifica
                        Mov_InfoStock.LGPLA = DefaultUbicazioneInvRettifica
                        If (clsInventarioUbicazione.MovimentoPositivo = True) Then
                            '>>> RETTIFICA POSITIVA (561)
                            Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.moveTypeField = Default_Inventario_TipoMov_RettificaPositiva
                            Mov_InfoStock.HEADER_TEXT = clsAppTranslation.GetSingleParameterValue(898, "", "RETT.UBI/UM POSITIVA")
                            Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.moveReasField = inCodMotiviMovimento
                            Mov_InfoStock.EnableCheckAvailableQty = False
                        Else
                            '>>> RETTIFICA NEGATIVA (562)
                            Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.moveTypeField = Default_Inventario_TipoMov_RettificaNegativa
                            Mov_InfoStock.HEADER_TEXT = clsAppTranslation.GetSingleParameterValue(899, "", "RETT.UBI/UM NEGATIVA")
                            Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.moveReasField = inCodMotiviMovimento
                            Mov_InfoStock.EnableCheckAvailableQty = True
                        End If
                    Case EnumInventoryType.EnumInventoryTypeRottamazione
                        Mov_InfoStock.LGTYP = DefaultTipoMagInvRettifica
                        Mov_InfoStock.LGPLA = DefaultUbicazioneInvRottamazione
                        Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.moveTypeField = Default_Inventario_TipoMov_Rottamazione
                        Mov_InfoStock.HEADER_TEXT = clsAppTranslation.GetSingleParameterValue(900, "", "RETT. X ROTTAMAZIONE")
                        Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.moveReasField = inCodMotiviMovimento
                        Mov_InfoStock.EnableCheckAvailableQty = True
                    Case EnumInventoryType.EnumInventoryTypeCentroCosto

                    Case Else
                        outFlagErroreAttivo = True '>>> SETTO FLAG DI ERRORE RILEVATO
                        outMessageDescription = clsAppTranslation.GetSingleParameterValue(901, "", "Attenzione, Tipo movimento INVENTARIO errato.")
                        If (inShowMessageBox = True) Then
                            MessageBox.Show(outMessageDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        End If
                        Exit Function
                End Select

            Else

                'Motivi Movimenti fissi nel codice

                Select Case clsInventarioUbicazione.InventoryType

                    Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUbicazione, clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUnitaMagazzino
                        Mov_InfoStock.LGTYP = DefaultTipoMagInvRettifica
                        Mov_InfoStock.LGPLA = DefaultUbicazioneInvRettifica
                        If (clsInventarioUbicazione.MovimentoPositivo = True) Then
                            '>>> RETTIFICA POSITIVA (561)
                            Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.moveTypeField = Default_Inventario_TipoMov_RettificaPositiva
                            Mov_InfoStock.HEADER_TEXT = clsAppTranslation.GetSingleParameterValue(898, "", "RETT.UBI/UM POSITIVA")
                            Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.moveReasField = "5611"
                        Else
                            '>>> RETTIFICA NEGATIVA (562)
                            Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.moveTypeField = Default_Inventario_TipoMov_RettificaNegativa
                            Mov_InfoStock.HEADER_TEXT = clsAppTranslation.GetSingleParameterValue(899, "", "RETT.UBI/UM NEGATIVA")
                            Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.moveReasField = "5621"
                        End If
                    Case EnumInventoryType.EnumInventoryTypeRottamazione
                        Mov_InfoStock.LGTYP = DefaultTipoMagInvRettifica
                        Mov_InfoStock.LGPLA = DefaultUbicazioneInvRottamazione
                        Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.moveTypeField = Default_Inventario_TipoMov_Rottamazione
                        Mov_InfoStock.HEADER_TEXT = clsAppTranslation.GetSingleParameterValue(900, "", "RETT. X ROTTAMAZIONE")
                        Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.moveReasField = "5511"
                    Case EnumInventoryType.EnumInventoryTypeCentroCosto

                    Case Else
                        outFlagErroreAttivo = True '>>> SETTO FLAG DI ERRORE RILEVATO
                        outMessageDescription = clsAppTranslation.GetSingleParameterValue(901, "", "Attenzione, Tipo movimento INVENTARIO errato.")
                        If (inShowMessageBox = True) Then
                            MessageBox.Show(outMessageDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        End If
                        Exit Function
                End Select

            End If


            Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.stckTypeField = clsInventarioUbicazione.MaterialeGiacenza.TipoStock
            Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.specStockField = clsInventarioUbicazione.MaterialeGiacenza.CdStockSpeciale
            Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.entryQntField = Abs(clsInventarioUbicazione.QtOtDaInventario)
            Mov_InfoStock.QTA_EXECUTED_SFUSI = Abs(clsInventarioUbicazione.QtOtSfusiDaInventario)
            Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.entryUomField = clsInventarioUbicazione.MaterialeGiacenza.UnitaDiMisuraAcquisizione

            If (Abs(clsInventarioUbicazione.QtOtSfusiDaInventario) > 0) Then
                Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.entryUomField = clsInventarioUbicazione.MaterialeGiacenza.UnitaDiMisuraPezzo
            End If


            Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.poNumberField = ""
            Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.poItemField = ""

            'Mov_InfoStock.SapMovCreateItem_Rec.RefDocYr = Now.Year
            Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.refDocField = ""
            Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.refDocItField = ""

            Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.valSalesOrdField = ""
            Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.valSOrdItemField = ""


#End If

            'ESEGUO MOVIMENTO IN SAP (MOVIMENTO DI MM IN QUESTO CASO PER RETTIFICA)
            RetCode = clsSapWS.Call_ZWS_MB_GOODSMVT_CREATE_MB11(Mov_InfoStock, outMov_Executed_Ok, SapFunctionError, outDocumentoMateriale, False)
            If (RetCode <> 0) Then
                If (outDocumentoMateriale.SkipMovimentoPerQtaNonDisponibile = True) Then
                    'CASO IN CUI NON HO FATTO IL MOVIMENTO PER QTA NON DISPONIBILE ( TUTTA IMPEGNATA )
                    outMessageDescription = outMessageDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(1784, "", "Attenzione!Movimento NON ESEGUITO causa QTA IMPEGNATA.")
                Else
                    If (outDocumentoMateriale.QtaNonDisponibile > 0) Then
                        'NEL CASO DI QTA NON DISPONIBILE NON GENERO ERRORE IN QUANTO IL SISTEMA COMUNQUE HA FATTO L'OT
                        outMessageDescription = outMessageDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(1785, "", "Attenzione! Verificata una QTA impegnata:") & Trim(Str(outDocumentoMateriale.QtaNonDisponibile))
                    Else
                        outFlagErroreAttivo = True '>>> SETTO FLAG DI ERRORE RILEVATO
                    End If
                    outMessageDescription = outMessageDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(902, "", "Attenzione!Errore nel Movimento di INVENTARIO.")
                End If
            Else
                '>>> TUTTO OK
                outMessageDescription = outMessageDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(903, "", "Movimento INVENTARIO eseguito con successo. DOC.MAT:") & outDocumentoMateriale.NumeroDocumento
                If (outDocumentoMateriale.QtaNonDisponibile > 0) Then
                    outMessageDescription = outMessageDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(1785, "", "Attenzione! Verificata una QTA impegnata:") & Trim(Str(outDocumentoMateriale.QtaNonDisponibile))
                End If
            End If

            ExecMovimentoLogicoPerInventario = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ExecMovimentoLogicoPerInventario = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function SetStockMaterialGiacenzaOri(ByVal inShowMessageBox As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            SetStockMaterialGiacenzaOri = 1

            '>>> LA GIACENZA SELEZIONATA DIVENTA L'UBICAZIONE DI ORIGINE
            SourceUbicazione = MaterialeGiacenza.UbicazioneInfo
            Select Case clsInventarioUbicazione.InventoryType
                Case EnumInventoryType.EnumInventoryTypeUbicazione, EnumInventoryType.EnumInventoryTypeUnitaMagazzino
                    '>>> IN QUESTO CASO PROPONGO LA STESSA QTA IN GIACENZA
                    MaterialeGiacenza.QuantitaConfermataOperatore = MaterialeGiacenza.QtaTotaleLquaDispoUdMAcq
                Case EnumInventoryType.EnumInventoryTypeRottamazione, EnumInventoryType.EnumInventoryTypeCentroCosto
                    'IN QUESTO CASO NON PROPONGO NULLA
                    MaterialeGiacenza.QuantitaConfermataOperatore = 0
            End Select

            SetStockMaterialGiacenzaOri = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            SetStockMaterialGiacenzaOri = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetStockGiacenzaInfo(ByRef inFilterUbicazione As clsDataType.SapWmUbicazione, ByRef inFilterGiacenza As clsDataType.SapWmGiacenza, ByVal inShowMessageBox As Boolean, ByRef outGetDataGiacenzeOk As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkDataRow As DataRow
        Dim WorkGiacenza As clsDataType.SapWmGiacenza
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetStockGiacenzaInfo = 1

            outGetDataGiacenzeOk = False 'init

            RetCode = clsInventarioUbicazione.ClearGiacenzeInfo() 'init
            'VERIFICO LE GIACENZE DELLO STESSO MATERIALE SE POSSO AVERE AMBIGUITA
            RetCode = clsSapWS.Call_ZWS_MB_GET_LQUA_GIACENZE(inFilterUbicazione, inFilterGiacenza, False, 0, clsUser.SapWmsUser.LANGUAGE, outGetDataGiacenzeOk, clsInventarioUbicazione.objDataTableGiacenzeInfo, Nothing, Nothing, Nothing, Nothing, SapFunctionError, False)
            If (RetCode <> 0) Then
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(291, "", "Errore in estrazione dati giacenza (GET_LQUA).") & vbCrLf & clsAppTranslation.GetSingleParameterValue(292, "", "Verificare filtri e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If
            If (outGetDataGiacenzeOk <> True) Or (clsInventarioUbicazione.objDataTableGiacenzeInfo Is Nothing) Then
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(293, "", "Giacenza non presente in STOCK.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(415, "", "Verificare i dati inseriti e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If
            If (clsInventarioUbicazione.objDataTableGiacenzeInfo.Rows.Count <= 0) Then
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(375, "", "Nessuna Giacenza in STOCK con i FILTRI immessi.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(415, "", "Verificare i dati inseriti e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            RetCode = clsSapUtility.ResetGiacenzaStruct(WorkGiacenza)
            If (clsInventarioUbicazione.objDataTableGiacenzeInfo.Rows.Count = 1) Then
                WorkDataRow = clsInventarioUbicazione.objDataTableGiacenzeInfo.Rows(0)
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
                clsInventarioUbicazione.MaterialeGiacenza = WorkGiacenza
                RetCode = clsInventarioUbicazione.SetStockMaterialGiacenzaOri(False)
                If (RetCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(612, "", "Attenzione! Errore in impostazione dati stock.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(568, "", "Verificare i dati immessi e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Function
                End If
            End If

            GetStockGiacenzaInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetStockGiacenzaInfo = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

End Class
