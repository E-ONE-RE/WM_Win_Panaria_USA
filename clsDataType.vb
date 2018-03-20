Imports System
'class for manage custom data type
Public Class clsDataType
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsDataType"

    '************************
    'DATA TYPE

    Public Enum UbicaOrUnitaMagEnteredEnum
        UbicaOrUnitaMagEnteredNone = 0
        UbicaOrUnitaMagEnteredUbicazione = 1
        UbicaOrUnitaMagEnteredUnitaMagazzino = 2
    End Enum
    Public Enum SkuOrUnitaMagEnteredEnum
        SkuOrUnitaMagEnteredNone = 0
        SkuOrUnitaMagEnteredSku = 1
        SkuOrUnitaMagEnteredUnitaMagazzino = 2
    End Enum

    Public Enum SapConnectionStatusEnum
        SapConnectionStatusNone = 0
        SapConnectionStatusOk = 1
        SapConnectionStatusError = 2
    End Enum

    Public Enum GenericDbDataTypeEnum
        GenericDbDataTypeNone = 0
        GenericDbDataTypeString = 1
        GenericDbDataTypeNumeric = 2
        GenericDbDataTypeDate = 3
    End Enum

    Public Enum GenericFormatControlDataTypeEnum
        GenericFormatControlDataTypeNone = 0
        GenericFormatControlDataTypeString = 1
        GenericFormatControlDataTypeNumeric = 2
        GenericFormatControlDataTypeNumericDecimal = 3
        GenericFormatControlDataTypeNumericInteger = 4
        GenericFormatControlDataTypeGeneralDate = 10
        GenericFormatControlDataTypeLongDate = 11
        GenericFormatControlDataTypeMediumDate = 12
        GenericFormatControlDataTypeShortDate = 13
        GenericFormatControlDataTypeLongTime = 20
        GenericFormatControlDataTypeMediumTime = 21
        GenericFormatControlDataTypeShortTime = 22
        GenericFormatControlDataTypeUserDefined = 100
    End Enum


    '**************************************************************************
    '>>>> TIPI DATI E STRUTTURA DI SAP
    Public Enum WizardDirectionStepType
        WizardDirectionStepTypeNone = 0
        WizardDirectionStepTypeNext = 1
        WizardDirectionStepTypePrevious = 2
        WizardDirectionStepTypeDetails = 3
        WizardDirectionStepTypeStartSeq = 4
        WizardDirectionStepTypeStartGroupSeq = 5
        WizardDirectionStepTypeInitSeq = 6
        WizardDirectionStepTypeCloseGroupSeq = 8
        WizardDirectionStepTypeSped = 9
        WizardDirectionStepTypeStartNewUDS = 20
        WizardDirectionStepTypeDropUDS = 30
    End Enum

    Public Enum FunctionTransferMaterialType
        FunctionTransferMaterialTypeNone = 0
        FunctionTransferMaterialTypeGeneric = 1
        FunctionTransferMaterialTypeForUMPrintLabel = 3
        FunctionTransferMaterialTypeForUMTransfer = 4
        FunctionTransferMaterialTypeForUMChangeLabel = 5
    End Enum

    Public Enum FunctionChangeUDSType
        FunctionChnageUDSTypeNone = 0
        FunctionChnageUDSTypeAdd = 1
        FunctionChnageUDSTypeMinus = 3
        FunctionChnageUDSTypeUnion = 4
    End Enum

    Public Enum FunctionRegModStockEType
        FunctionRegModStockETypeNone = 0
        FunctionRegModStockETypeAddStockE = 1
        FunctionRegModStockETypeRemoveStockE = 2
        FunctionRegModStockETypeTransferStockE = 2
        FunctionRegModStockETypeAddStockECustom = 10
        FunctionRegModStockETypeRemoveStockECustom = 11
        FunctionRegModStockETypeTransferStockECustom = 12
    End Enum

    Public Enum InfoGiacenzeType
        InfoGiacenzeTypeNone = 0
        InfoGiacenzeTypeGeneric = 1
        InfoGiacenzeTypeForUbicazione = 2
        InfoGiacenzeTypeForCodMateriale = 3
        InfoGiacenzeTypeForUnitaMagazzino = 4
    End Enum

    Public Enum Operation_Type
        Operation_Type_None = 0
        Operation_Type_Inbound = 1
        Operation_Type_Picking = 2
        Operation_Type_All = 9
    End Enum

    Public Enum EM_TipoProceduraType
        EM_TipoProceduraNone = 0
        EM_TipoProceduraPalletizzaeStoccaggio = 1
        EM_TipoProceduraPalletizzaDestSpunta = 2
        EM_TipoProceduraStoccaggioDirettoUMSconosciuta = 3
        EM_TipoProceduraStoccaggioDirettoUMConosciuta = 3
    End Enum

    Public Enum SelezioneCodiceMaterialeType
        SelezioneCodiceMaterialeTypeNone = 0
        SelezioneCodiceMaterialeTypeGeneric = 1
        SelezioneCodiceMaterialeTypeForUbicazione = 2
    End Enum

    Public Enum SelezionePartitaMaterialeType
        SelezionePartitaMaterialeTypeNone = 0
        SelezionePartitaMaterialeTypeGeneric = 1
        SelezionePartitaMaterialeTypeForUbicazione = 2
    End Enum

    Public Enum SelezionePrintLabelType
        SelezionePrintLabelTypeNone = 0
        SelezionePrintLabelTypeGeneric = 1
        SelezionePrintLabelTypePrintUDC = 2
        SelezionePrintLabelTypePrintUDS = 3
        SelezionePrintLabelTypePrintKTAG = 4
        SelezionePrintLabelTypeRePrintUDC = 5
        SelezionePrintLabelTypeRePrintUDS = 6
        SelezionePrintLabelTypeRePrintKTAG = 7
    End Enum

    Public Structure SapWmTipoMagazzino
        Public Divisione As String
        Public NumeroMagazzino As String
        Public TipoMagazzino As String
    End Structure

    Public Structure FlagErrorSkuElaborationStruct
        Public FlagErrorSku_MATNR As Boolean
        Public FlagErrorSku_CHARG As Boolean
        Public FlagErrorSku_ShadeNotFound As Boolean
        Public FlagErrorSku_DiffMatnr As Boolean
        Public FlagErrorSku_MatnrClass001 As Boolean
        Public FlagErrorSku_DiffClass001 As Boolean
        Public FlagErrorSku_DiffTono As Boolean
        Public FlagErrorSku_DiffCalibro As Boolean

        Public EChargExpected As String
        Public EChargAlteSku As String
        Public EChargSku As String
    End Structure

    Public Structure FlagCheckLocationStruct
        Public FlagCHECK_LOC_OCCUPATION As Boolean
        Public FlagCHECK_MIX_LOCATION As Boolean
        Public FlagCHECK_MIX_MATERIAL_CODE As String
        Public FlagCHECK_MIX_CHARG As String
        Public Quantity As Double
        Public UdMQuantity As String
    End Structure

    Public Structure FlagCheckLenum
        Public FlagE_PRD_FLAG_MB31 As Boolean
        Public FlagE_PRD_FLAG_ON_TRASFER As Boolean
        Public FlagE_PRD_FLAG_OT1_DONE As Boolean
        Public FlagE_PRD_FLAG_TRASFER_OK As Boolean
        Public FlagE_PRD_FLAG_SET_CQ As Boolean
        Public FlagE_PRD_FLAG_REJECT As Boolean
        Public FlagE_PRD_FLAG_PUTAWAY As Boolean
        Public FlagE_PRD_FLAG_SKIPUNLOAD As Boolean

        Public FlagE_PRD_FLAG_MODIFICA As Boolean
        Public FlagE_PRD_FLAG_CANCELLAZIO As Boolean
        Public FlagE_PRD_FLAG_RISCELTA As Boolean
        Public FlagE_PRD_FLAG_LOCK_ATTIVO As Boolean

        Public FlagE_PRD_FLAG_ERROR_PUTAWAY As Boolean

        Public StrE_PRD_FLAG_ERR_PUTAWAY_DESCR As String

        Public Flag_UM_BLOCKED As Boolean
        Public Flag_UM_SPECIAL_STOCK As Boolean

    End Structure

    Public Structure SapTaskLinesInfo
        Public NrWmsJobs As Long
        Public TotalTaskLines As Double
        Public TotalTaskLinesFull As Double
        Public TotalTaskLinesPartial As Double
        Public TotalTaskLinesDone As Double
        Public TotalTaskLinesDoneFull As Double
        Public TotalTaskLinesDonePartial As Double
        Public TotalTaskLineOpen As Double
        Public TotalTaskLinesOpenFull As Double
        Public TotalTaskLinesOpenPartial As Double
    End Structure

    Public Structure SapTaskLinesSingle
        Public NrWmsJobs As Long
        Public NrTaskLines As String
        Public TaskLinesSequence As Long
        Public PickFullPartialType As String
        Public IdTaskLinesStatus As Long
        Public DataCreazione As Date
        Public OraCreazione As Date

        Public QtaJobRichiestaInUdmBase As Double
        Public UnitaDiMisuraBase As String
        Public QtaJobRichiestaInUdmConsegna As Double
        Public UnitaDiMisuraConsegna As String

        Public QtaPrelevataInUdMBase As Double
        Public UdmQtaPrelevataInUdMBase As String
        Public QtaPrelevataInUdMConsegna As Double
        Public UdmQtaPrelevataInUdMConsegna As String
        Public QtaJobRichiestaFullPallet As Double
        Public QtaJobRichiestaPartialPallet As Double
        Public QtaJobRichiestaSfusiInPZ As Double

        Public QtaPrelevataFullPallet As Double
        Public QtaPrelevataPartialPallet As Double
        Public QtaPrelevataSfusi As Double
        Public QtaPrelevataInUdMPezzo As Double
        Public UnitaDiMisuraPezzo As String
        Public PesoTotaleMaterialeTaskLine_Kg As Long
        Public UdmPesoKg As String
        Public PesoTotaleMaterialeTaskLine_Lb As Long
        Public UdmPesoLb As String
        Public IdCarrellistaEsecuzione As String
    End Structure

    Public Structure SapForkLiftStruct
        Public Divisione As String
        Public NumeroMagazzino As String
        Public TipoMagazzino As String
        Public Ubicazione As String
        Public IdForkLift As String
        Public DescrizioneForkLift As String
        Public ForkLiftMaxPesoCarico As Long
        Public UdmPeso As String
        Public NumUdsOnForklift As Long
        Public DropUdsFromForklift As String

        Public UdsOnForkDiffUser As String

    End Structure

    Public Structure UDS_WeightInfoStruct
        Public PesoTotaleUDS_Kg As Long
        Public UdmPesoKg As String
        Public PesoTotaleUDS_Lb As Long
        Public UdmPesoLb As String
    End Structure

    Public Structure JobsQueueWeightInfoStruct
        Public PesoTotaleCoda_Kg As Long
        Public PesoRimanenteCoda_Kg As Long
        Public UdmPesoKg As String
        Public PesoTotaleCoda_Lb As Long
        Public PesoRimanenteCoda_Lb As Long
        Public UdmPesoLb As String
    End Structure

    Public Structure SapWmJobGroupExecRec
        Public NrWmsJobs As Long
        Public QtaTotaleDaPrelevare As Double
        Public QtaTotaleDaPrelevareRimanente As Double
        Public UdmQtaTotaleDaPrelevare As String
        Public QtaPrelevataInUdMBase As Double
        Public UdmQtaPrelevataInUdMBase As String
        Public QtaPrelevataInUdMConsegna As Double
        Public UdmQtaPrelevataInUdMConsegna As String
        Public NumeroOrdineVendita As String
        Public NumeroPosizioneOrdineVendita As String
        Public QuantitaConfermataOperatore As Double
    End Structure

    Public Structure SapWmJobsGroupExecTab
        Public ExecGroupFound As Boolean
        Public QtaGroupTotaleDaPrelevare As Double
        Public JobsGroupExecTab() As SapWmJobGroupExecRec
    End Structure

    Public Structure StructSapWmsUser
        Dim MANDT As String
        Dim MODULE_AREA As String
        Dim PROGNAME As String
        Dim USERID As String
        Dim PASSWORD As String
        Dim PROFID As String
        Dim NAME_FIRST As String
        Dim NAME_LAST As String
        Dim LANGUAGE As String
        Dim BCDA1 As String
        Dim MOB_NUMBER As String
        Dim EMAIL As String
        Dim DESCRIPTION As String
        Dim ZCARR As String
        Dim WERKS As String
        Dim LGNUM As String
        Dim LGTYP As String
        Dim ZID_WMS_FORKLIFT As String
        Dim ZID_PICK_QUEUE As String
        Dim ZPICK_QUEUE_DESC As String
        Dim ZNR_WMS_JOBS As String
    End Structure

    Public Structure StructUsersProfLgtyp
        Dim LGNUM As String
        Dim LGTYP As String
        Dim LTYPT As String
    End Structure

    Public Structure SapWmWmsJob
        Public NrWmsJobs As Long
        Public DataCreazione As Date
        Public OraCreazione As Date
        Public PickDbTabName As String
        Public PickDbNumero As String
        Public PickDbPosizione As Long
        Public NumeroTrasporto As String
        Public ConsegnaNumero As String
        Public ConsegnaPosizione As Long
        Public StopSequence As String
        Public DropSequence As String
        Public CodiceGruppoMissioni As String
        Public CodiceRaggruppoEsecuzione As String
        Public Sequence As Long
        Public CurrentStep As String
        Public NumeroStepTotali As Long
        Public IdWmsJobStatus As Long
        Public IdWmsJobStatusDescription As String
        Public IdWmsJobType As String
        Public IdWmsJobTypeDescription As String
        Public NumeroOrdineVendita As String
        Public NumeroPosizioneOrdineVendita As String
        Public TipoDocumento As String
        Public CodiceFornitore As String
        Public CodiceClienteAG As String
        Public DescrizioneClienteAG As String
        Public CodiceClienteWE As String
        Public DescrizioneClienteWE As String
        Public CodiceClienteRG As String
        Public DescrizioneClienteRG As String
        Public Priorita As Long
        Public Urgente As Boolean
        Public CondizioneDiReso As Boolean
        Public FlagRilevanteWM As String
        Public FlagPartitaTassativa As String
        Public FlagPalletInteri As Boolean
        Public FlagScatoleIntere As Boolean
        Public IdCarrellistaProposto As String
        Public IdCarrellistaEsecuzione As String
        Public IdCarrellistaEsecuzioneFullPallet As String
        Public IdCarrellistaEsecuzioneSfusi As String

        '* GESTIONE CAMPI ERRORE
        Public ZWMS_ERROR_CODE As String
        Public ZWMS_ROW_STA_DES As String


        Public MaterialeGiacenzaOrigine As clsDataType.SapWmGiacenza
        Public UbicazioneOrigine As clsDataType.SapWmUbicazione
        Public UbicazionePropostaOrigine As clsDataType.SapWmUbicazione
        Public MaterialeGiacenzaDestinazione As clsDataType.SapWmGiacenza
        Public UbicazioneDestinazione As clsDataType.SapWmUbicazione
        Public UbicazionePropostaDestinazione As clsDataType.SapWmUbicazione
        Public UbicazioneStaging As clsDataType.SapWmUbicazione
        Public UbicazioneDoor As clsDataType.SapWmUbicazione
        Public InfoPrelievo As String
        Public DistintaDiCarico As String
        Public Memo As String

        Public PickFullPartial As String

        Public DocumentoMaterialeAnno As String
        Public DocumentoMaterialeNumero As String
        Public DocumentoMaterialePosizione As String

        Public NumeroOrdineDiProduzione As String

        Public TipoDirezioneMissioneKZEAR As String
        Public DataStart As String
        Public OraStart As String
        Public DataFine As String
        Public OraFine As String

        'FLAG CHE MI CONDIZIONANO IL COMPORTAMENTO DEGLI STEP DELLE VIDEATE DI ESECUZIONE DELLA MISSIONE
        Public ForcedConfirmUbicazioneSpunta As Boolean  'SE TRUE INDICA CHE NELLA MISSIONE DI ENTRATA MERCE SI DEVE DICHIARARE LA BAIA DI SPUNTA ALL'INIZIO DELLA PROCEDURA
        Public ForcedFinalDestination As Boolean  'SE TRUE INDICA CHE LA DESTINAZIONE E' FISSA E NON PUO' ESSERE CAMBIATA DALL'OPERATORE
        Public EMTipoProceduraType As EM_TipoProceduraType

        Public TruckDayNr As String
        Public TrasfNumPallet As Long

        Public TaskLinesList() As clsDataType.TaskLines

    End Structure

    Public Structure TaskLines
        Public ZNR_TASK_LINES As Long
        Public DATA_CREAZIONE As String
        Public ORA_CREAZIONE As String
        Public ZNR_WMS_JOBS As Long
        Public ZTASK_LINES_SEQ As Long
        Public ZPICKFULLPARTIAL As String
        Public IDSTATUS As Long
        Public ZQTAPK_ORI_CONS As Double
        Public MEINS_CONS As String
        Public ZQTA_PREL_CONS As Double
        Public UDM_QTAPR_CONS As String
        Public ZWMS_PESOMAT_EU As Double
        Public GEWEI_EU As String
        Public ZWMS_PESOMAT_USA As Double
        Public GEWEI_USA As String
        Public USERID_RF As String
    End Structure

    Public Structure SapWmUbicazione
        Public Divisione As String
        Public NumeroMagazzino As String
        Public TipoMagazzino As String
        Public Ubicazione As String
        Public DescUbicazione As String
        Public UnitaMagazzino As String
        Public TipoUnitaMagazzino As String
        Public AbilitaUnitaMagazzino As Boolean
        Public NumeroQuantWmSap As Long
        Public NumeroUdcInUbicazione As Long
        Public CapacitaUdcUbicazione As Long
        Public FlagLocationDoor As Boolean
        Public FlagLocationStagingDoor As Boolean
        Public FlagLocationWrapping As Boolean
        Public FlagLocationEquipment As Boolean
        Public FlagLocationOperator As Boolean
        Public FlagLocation_P_D As Boolean
        Public FlagFinalWarehouseLocation As Boolean
        Public FlagLocationWithDifferentMaterialCode As Boolean
        Public FlagLocationWithDifferentBatch As Boolean
        Public FlagLocationFull As Boolean
        Public FlagLocationAllowMixedMaterialCode As Boolean
        Public FlagLocationAllowMixedBatch As Boolean
        Public FlagCheckLocationInfo As FlagCheckLocationStruct

        Public QtyStockProposal As String
        Public QtyLocationProposal As String

    End Structure

    Public Structure SapOrdineVendita
        Public NumeroOrdineVendita As String
        Public PosizioneOrdineVendita As String
        Public TipoOrdineVendita As String
        Public CodiceMateriale As String
        Public DescrizioneMateriale As String
        Public Partita As String
        Public QuantitaTotaleOrdineUdMVendita As Double
        Public QuantitaConfermataUdMVendita As Double
        Public QuantitaConfermataUdMBase As Double
        Public UnitaDiMisuraVendita As String
        Public UnitaDiMisuraBase As String
    End Structure

    Public Structure SapDatiProduzioneScelta
        Public Divisione As String
        Public UnitaMagazzino As String
        Public DataProduzione As String
        Public OraProduzione As String
        Public NumeroMagazzino As String
        Public NumeroOrdineProduzione As String
        Public CodiceMateriale As String
        Public CodiceMaterialeAlternativo As String
        Public Scelta As String
        Public Tono As String
        Public Calibro As String
        Public Qualita As String
        Public ProgressivoProd As String
        Public CodiceVarianteImballo As String
        Public Lotto As String
        Public OperatoreProd As String
    End Structure

    Public Structure SapOrdineProduzione
        Public NumeroOrdineProduzione As String
        Public TipoOrdineProduzione As String
        Public CodiceMateriale As String
        Public DescrizioneMateriale As String
        Public Partita As String
        Public QuantitaDaProdurre As Double
        Public QuantitaConsegnata As Double
        Public QuantitaScarto As Double
        Public UnitaDiMisura As String
        Public RifNumeroOrdineCliente As String
        Public RifPosizioneOrdineCliente As String
        Public DataAcquisizione As Date
        Public QtaPalettaPiena As Double
        Public UdMQtaPalettaPiena As String
    End Structure

    Public Structure SapComponenteOrdineProduzione
        Public NumeroOrdineProduzione As String
        Public CodiceMateriale As String
        Public DescrizioneMateriale As String
        Public Partita As String
        Public QtaSingolaPartita As Double
        Public QtaTotaleComponente As Double
        Public UdMQtaSingolaPartita As String
        Public EccessoQtaSingolaPartita As Boolean
        Public EccessoQtaTotaleComponente As Boolean
    End Structure

    Public Structure SapAnagraficaCliente
        Public CodiceCliente As String
        Public CodicePaese As String
        Public Nome1 As String
        Public Nome2 As String
        Public CAP As String
        Public Localita As String
        Public Regione As String
        Public CodiceIndirizzo As String
        Public Telefono As String
    End Structure

    Public Structure SapWmDocumentoMateriale
        Public AnnoEsercizio As String
        Public NumeroDocumento As String
        Public PosizioneDocumento As String
        Public SkipMovimentoPerQtaNonDisponibile As Boolean
        Public QtaNonDisponibile As Double
    End Structure

    Public Structure SapWmDocumentoMaterialeFull
        Public AnnoEsercizio As String
        Public NumeroDocumento As String
        Public PosizioneDocumento As String
        Public PosizioneInfo As SapWmDocumentoMaterialePos
        Public PosizioniInfo() As SapWmDocumentoMaterialePos
    End Structure

    Public Structure SapWmDocumentoMaterialePos
        Public AnnoEsercizio As String
        Public NumeroDocumento As String
        Public PosizioneDocumento As String
        Public MaterialeInfo As clsDataType.SapWmGiacenza
        Public OrdineAcquistoNum As String
        Public OrdineAcquistoPos As String
        Public Divisione As String
        Public CodiceFornitore As String
        Public CodiceIncoterms As String
        Public CodiceMagazzinoLogico As String
        Public TipoMovimento As String
        Public CodiceCommessa As String
        Public NumeroFabbisognoTrasporto As Long
        Public PosizioneFabbisognoTrasporto As Long
        Public PosizioneGiaElaborata As Boolean
        Public QtaTotaleUdMBase As Double
        Public QtaGiaPrelevataUdMBase As Double
        Public QtaDaPrelevareUdMBase As Double
        Public UnitaDiMisuraBase As String
        Public QtaTotaleUdMCons As Double
        Public QtaGiaPrelevataUdMCons As Double
        Public QtaDaPrelevareUdMCons As Double
        Public UnitaDiMisuraVendita As String
        Public PrelievoTerminato As Boolean
    End Structure

    Public Structure SapVarianteImballo
        Public CodiceMateriale As String
        Public VarianteImballo As String
        Public PezziPerScatola As Double
        Public ScatolePerPallet As Double
        Public M2PerPallet As Double
        Public CodiceEAN11_Scatola As String
        Public CodiceEAN11_Pallet As String
        Public CodiceImballo As String
        Public PalletLarghezza As Double
        Public PalletProfondita As Double
        Public PalletAltezza As Double
        Public PalletAltezzaSingoloPiano As Double
        Public PalletAltezzaPianale As Double
        Public PalletNumeroColliPerPiano As Double
        Public Testo As String
        Public CodiceMaterialeAlternativo As String
    End Structure
    Public Structure SapPartnerKNA1
        Public KUNNR As String
        Public NAME1 As String
        Public NAME2 As String
        Public ORT01 As String
        Public PSTLZ As String
        Public REGIO As String
        Public STRAS As String
    End Structure
    Public Structure SapFornitoreLFA1
        Public LIFNR As String
        Public NAME1 As String
        Public NAME2 As String
        Public ORT01 As String
        Public PSTLZ As String
        Public REGIO As String
        Public STRAS As String
    End Structure

    Public Structure SapJobsGroupInfo
        Public NumAccorpamenti As Long
        Public NumeroJobsGroup As String
        Public NumeroOrdinePicking As String
        Public JobsGroupDescription As String
        Public TipoDocumento As String
        Public NumeroDocumento As String
        Public RiferimentoOdA As String
        Public RiferimentoOdV As String
        Public PartnerAGInfo As SapPartnerKNA1
        Public PartnerWEInfo As SapPartnerKNA1
        Public FornitoreInfo As SapFornitoreLFA1
        Public DivisioneDestinazione As String
        Public MagLogicoDestinazione As String
        Public IdCarrellistaProposto As String
        Public IdCarrellistaEsecuzione As String
        Public NumTotaleScatole As Double
        Public NumTotaleM2 As Double
        Public NumTotalePezzi As Double
        Public NumTotaleOthers As Double

        Public NumPickTotaleScatole As Double
        Public NumPickTotaleM2 As Double
        Public NumPickTotalePezzi As Double
        Public NumPickTotaleOthers As Double

        Public FoundGroupDeleted As Boolean
        Public FoundRowsDeleted As Long

        Public JobsGroupClosed As Boolean
        Public CheckMaterialePronto As String
    End Structure
    Public Structure SapJobUdsChange
        Public GiacenzaOrigine As SapWmGiacenza
        Public GiacenzaDestinazione As SapWmGiacenza
    End Structure
    Public Structure SapWmGiacenza
        Public CodiceMateriale As String
        Public DescrizioneMateriale As String
        Public Partita As String
        Public SKU As String
        Public CodiceMaterialeLegacy As String

        Public ZZWAREHOUSE_CODE As String
        Public ZZSTORAGE_CODE As String

        Public ZFLAG_SKIPUNLOAD As String
        Public ZSKIPUNLOAD_DESC As String

        Public CdStockSpeciale As String
        Public NumeroStockSpeciale As String
        Public TipoStock As String
        Public NumeroFabbisognoDiTrasporto As Long

        Public FormatoCodice As String
        Public FormatoDescrizione As String

        '>>>> TUTTE QUESTE QTA SONO IN UDM BASE ( CAMPI STANDARD DELLA LQUA )
        Public QtaTotaleLquaInStock As Double
        Public QtaTotaleLquaDisponibile As Double
        Public QtaTotaleLquaDaImmagazzinare As Double
        Public QtaTotaleLquaDaPrelevare As Double

        '>>>> TUTTE QUESTE QTA SONO IN UDM  CONSEGNA ( CAMPI STANDARD DELLA LQUA )
        Public QtaTotaleLquaInStockUdMAcq As Double
        Public QtaTotaleLquaDispoUdMAcq As Double
        Public QtaTotaleLquaDaImmaUdMAcq As Double
        Public QtaTotaleLquaDaPrelUdMAcq As Double

        '>>> QTA RELATIVE ALLO STOCK NELLE UDM JOB
        Public QtaTotaleLquaInStocFullPallet As Double
        Public QtaTotaleLquaDispoFullPallet As Double
        Public QtaTotaleLquaInStocPartialPallet As Double
        Public QtaTotaleLquaDispoPartialPallet As Double
        Public QtaTotaleInStockInUdmPZ As Double
        Public QtaTotaleInStockSfusi As Double
        Public QtaTotaleDispoInUdmPZ As Double
        Public QtaTotaleDispoSfusi As Double


        '>>> QTA TOTALI DELLO STOCK DELL'UBICAZIONE
        Public QtaTotaleLocationUdBase As Double
        Public QtaTotaleLocationUdMAcq As Double
        Public QtaTotaleLocationUdMSC As Double
        Public QtaTotaleLocationFullPallet As Double
        Public QtaTotaleLocationPartialPallet As Double
        Public QtaTotaleLocationSfusi As Double
        Public NumeroUDCLocation As Double

        Public QuantitaConfermataOperatore As Double
        Public QuantitaConfermataSfusiOperatore As Double
        Public QuantitaConfermataRettificaPositiva As Double
        Public QuantitaConfermataRettificaNegativa As Double

        Public QuantitaInUdMBase As Double
        Public UnitaDiMisuraBase As String

        Public QuantitaInUdMAcquisizione As Double
        Public UnitaDiMisuraAcquisizione As String

        Public UnitaDiMisuraPezzo As String
        Public UnitaDiMisuraScatole As String
        Public UnitaDiMisuraPallet As String


        'QTA ASSOCIATE ALLA MISSIONE
        Public UdmQtaJobRichiesta As String
        Public QtaJobRichiestaInUdmOriginale As Double
        Public QtaJobRichiestaInUdmBase As Double
        Public QtaJobRichiestaInUdmConsegna As Double
        Public QtaJobRichiestaInUdmPZ As Double
        Public QtaJobRichiestaInUdmSC As Double
        Public QtaJobRichiestaInUdmPL As Double
        Public QtaJobRichiestaFullPallet As Double
        Public QtaJobRichiestaPartialPallet As Double
        Public QtaJobRichiestaSfusiInPZ As Double
        Public QtaPrelevataInUdMBase As Double
        Public UdmQtaPrelevataInUdMBase As String
        Public QtaPrelevataInUdMConsegna As Double
        Public UdmQtaPrelevataInUdMConsegna As String
        Public QtaPrelevataFullPallet As Double
        Public QtaPrelevataPartialPallet As Double
        Public QtaPrelevataSfusi As Double
        Public QtaPrelevataInUdMPezzo As Double
        Public UdmQtaPrelevataInUdMPezzo As String

        Public NumeroDocumentoVendita As String
        Public PosizioneDocumentoVendita As String
        Public QtaPosizioneDocumentoVenditaUdMConsegna As Double
        Public UnitaDiMisuraQtaPosizioneDocumentoVendita As String

        Public NumeroConsegna As String
        Public PosizioneConsegna As String

        Public MagazzinoLogico As String
        Public PickSUCompleto As Boolean
        Public UbicazioneInfo As clsDataType.SapWmUbicazione
        Public PickOrigineInfo As SapStrateOutputOrigineInfo
        Public PickDestinazioneInfo As SapStrateOutputDestinazioneInfo
        Public OdaInputDestInfo As SapStrateInputDestInfo
        Public VarianteImballo As SapVarianteImballo

        Public MultipleUnitaMagazzino() As String

        Public DataScadenza As String
        Public DataCarico As String
        Public CodiceFornitore As String
        Public DocumentoMaterialeNum As String
        Public DocumentoMaterialeAnno As String
        Public DocumentoMaterialePos As String

        Public NumeroOrdineTrasferimento As Long

        '>>>> INFO PER GESTIONE TRASFERIMENTO NAVETTA
        Public NrWmsJobs As Long
        Public CodiceGruppoMissioni As String
        Public TruckDayNr As String
        Public TrasfNumPallet As Long

        Public UbiUserQtyTotal As String
        Public GesmeQtyUser As String

        Public ZGestione_PZ_Attiva As String

    End Structure

    Public Structure SapUDSInfo
        Public Divisione As String
        Public NumeroMagazzino As String
        Public TipoMagazzino As String
        Public Ubicazione As String
        Public DescUbicazione As String
        Public UnitaMagazzino As String
        Public TipoUnitaMagazzino As String 'LETYP

        Public CodiceMateriale As String
        Public DescrizioneMateriale As String
        Public SKU As String

        Public CdStockSpeciale As String
        Public NumeroStockSpeciale As String
        Public TipoStock As String
        Public NumeroFabbisognoDiTrasporto As Long

        Public Partita As String
        Public NrWmsJobs As Long
        Public NrTrasporto As Long
        Public Consegna As String
        Public PosConsegna As String
        Public CodiceGruppoMissioni As String
        Public StopSequence As String
        Public DropSequence As String


        Public QtaPrelevataInUdMBase As Double
        Public UdmQtaPrelevataInUdMBase As String
        Public QtaPrelevataInUdMConsegna As Double
        Public UdmQtaPrelevataInUdMConsegna As String
        Public QtaPrelevataInUdMPezzo As Double
        Public UdmQtaPrelevataInUdMPezzo As String

        Public PesoMaterialeNettoEU As Double
        Public UnitaDiPesoMatEU As String
        Public PesoMaterialeNettoUSA As Double
        Public UnitaDiPesoMatUSA As String

        Public DataCreazione As String
        Public OraCreazione As String
        Public DataModifica As String
        Public OraModifica As String
        Public UserIdRFCrea As String
        Public UserIdRFMod As String
        Public UserId As String

        'DATI PER COMPLESSIVO ( INFORMAZIONI )
        Public CodiceMaterialeComplessivo As String
        Public NrTotComponenti As Long
        Public TotQtaPalletInUdMBase As Double
        Public TotQtaPalletInUdMConsegna As Double

        Public MagazzinoLogico As String
        Public PickSUCompleto As Boolean
        Public UbicazioneInfo As clsDataType.SapWmUbicazione
        Public VarianteImballo As SapVarianteImballo

        Public CodicePartnerAg As String
        Public ZAG_NAME As String
        Public CodicePartnerWE As String
        Public ZWE_NAME As String
        Public LGNUM_STAG_DOOR As String
        Public LGTYP_STAG_DOOR As String
        Public LGPLA_STAG_DOOR As String
        Public LGNUM_DOCK_DOOR As String
        Public LGTYP_DOCK_DOOR As String
        Public LGPLA_DOCK_DOOR As String

        '>>>> INFO PER GESTIONE UDS TRUCK LOAD INFO
        Public UDSTruckPalLoad As Long
        Public UDSTruckPalToLoad As Long
        Public UDSTruckNumPallet As Long
        Public UDSTruckLoadMerci As String

        '>>>> INFO PER GESTIONE TRASFERIMENTO NAVETTA
        Public TruckDayNr As String
        Public TrasfNumPallet As Long

        Public Componenti() As SapWmGiacenza


    End Structure

    Public Structure SapWmGiacenzaLqua
        Public CodiceMateriale As String
        Public DescrizioneMateriale As String
        Public Partita As String
        Public CdStockSpeciale As String
        Public NumeroStockSpeciale As String
        Public TipoStock As String

        '>>>> TUTTE QUESTE QTA SONO IN UDM BASE
        Public QuantitaInStock As Double
        Public QtaTotaleDisponibile As Double
        Public QtaTotaleDaImmagazzinare As Double
        Public QtaTotaleDaPrelevare As Double
        Public QuantitaConfermataOperatore As Double
        Public QuantitaInUdMBase As Double
        Public UnitaDiMisuraBase As String

        Public QuantitaInStockUdMAcq As Double
        Public QtaTotaleDispoUdMAcq As Double
        Public QtaTotaleDaImmaUdMAcq As Double
        Public QtaTotaleDaPrelUdMAcq As Double
        Public QuantitaInUdMAcquisizione As Double
        Public UnitaDiMisuraAcquisizione As String

        Public NumeroFabbisognoDiTrasporto As Long
        Public MagazzinoLogico As String
        Public PickSUCompleto As Boolean
        Public UbicazioneInfo As clsDataType.SapWmUbicazione
        Public VarianteImballo As SapVarianteImballo
    End Structure

    Public Structure SapStrateOutputOrigineInfo
        Public DescrPickOrigine As String
        Public DescrPickCausale As String
        Public FoundAreaEntrataMerceProd As Boolean
        Public FoundAreaEntrataMerceOdA As Boolean
        Public FoundAreaProd As Boolean
        Public FoundMagGeneric As Boolean
    End Structure
    Public Structure SapStrateOutputDestinazioneInfo
        Public DescrPickDestinazione As String
        Public DescrPickCausale As String
        Public FoundAreaPronto As Boolean
        Public FoundAreaContoLavoro As Boolean
        Public FoundAreaProd As Boolean
        Public FoundArea916 As Boolean
        Public FoundMagProduzione As Boolean
    End Structure


    Public Structure SapStrateInputDestInfo
        Public CodiceCommessa As String
        Public NumeroOrdineProduzione As String
        Public DescrUbicDestinazione As String
        Public DescrizioneCausale As String
        Public NumDocumentoAcquisto As String
        Public PosizioneDocumentoAcquisto As String
        Public UbicazioneInfo As clsDataType.SapWmUbicazione
        Public GiacenzeCompatibiliInfo() As clsDataType.SapWmGiacenzaLqua
        Public GiacenzeCompatibiliAggiunta() As clsDataType.SapWmGiacenzaLqua

        Public QtaRichiesta As Single
        Public UnitaDiMisuraBase As String
        Public FoundMancanteOdp As Boolean
        Public FoundMagProd As Boolean
        Public FoundAreaProd As Boolean
        Public FoundMagGeneric As Boolean
        Public FoundMagEmpty As Boolean
        Public FoundForcedDestination As Boolean
    End Structure

    Public Structure SapWmsMobileCfg
        Public MobileName As String
        Public IdWmsDevices As String
        Public Enable As Boolean
        Public Divisione As String
        Public NumeroMagazzino As String
    End Structure

    Public Structure SapWmOtInfo
        Public NumeroOrdineDiTrasferimento As String
    End Structure

    Public Structure SapWmRetStepExecuted
        Public NumeroOrdineDiTrasferimento As String
        Public DocumentoMaterialeInfo As SapWmDocumentoMateriale
        Public DescrOpeExecuted As String
    End Structure

    Public Shared SelPrintLabelType As clsDataType.SelezionePrintLabelType


    Public Shared Function CreateDateTableForTaskLines(ByRef outDataTable As DataTable) As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia ForkLift
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForTaskLines = 1 'init at error


            Dim WorkMANDT As DataColumn = New DataColumn("MANDT") 'declaring a column named Name
            WorkMANDT.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkMANDT) 'adding the column to table

            Dim WorkZNR_TASK_LINES As DataColumn = New DataColumn("ZNR_TASK_LINES") 'declaring a column named Name
            WorkZNR_TASK_LINES.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZNR_TASK_LINES) 'adding the column to table

            Dim WorkDATA_CREAZIONE As DataColumn = New DataColumn("DATA_CREAZIONE") 'declaring a column named Name
            WorkDATA_CREAZIONE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkDATA_CREAZIONE) 'adding the column to table

            Dim WorkORA_CREAZIONE As DataColumn = New DataColumn("ORA_CREAZIONE") 'declaring a column named Name
            WorkORA_CREAZIONE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkORA_CREAZIONE) 'adding the column to table

            Dim WorkZNR_WMS_JOBS As DataColumn = New DataColumn("ZNR_WMS_JOBS") 'declaring a column named Name
            WorkZNR_WMS_JOBS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZNR_WMS_JOBS) 'adding the column to table

            Dim WorkZFORKLIFT_MAX_PESO As DataColumn = New DataColumn("ZFORKLIFT_MAX_PESO") 'declaring a column named Name
            WorkZFORKLIFT_MAX_PESO.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZFORKLIFT_MAX_PESO) 'adding the column to table

            Dim WorkZTASK_LINES_SEQ As DataColumn = New DataColumn("ZTASK_LINES_SEQ") 'declaring a column named Name
            WorkZTASK_LINES_SEQ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZTASK_LINES_SEQ) 'adding the column to table

            Dim WorkZPICKFULLPARTIAL As DataColumn = New DataColumn("ZPICKFULLPARTIAL") 'declaring a column named Name
            WorkZPICKFULLPARTIAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZPICKFULLPARTIAL) 'adding the column to table

            Dim WorkZID_PICK_QUEUE As DataColumn = New DataColumn("ZID_PICK_QUEUE") 'declaring a column named Name
            WorkZID_PICK_QUEUE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZID_PICK_QUEUE) 'adding the column to table

            Dim WorkIDSTATUS As DataColumn = New DataColumn("IDSTATUS") 'declaring a column named Name
            WorkIDSTATUS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkIDSTATUS) 'adding the column to table

            Dim WorkSTATUS As DataColumn = New DataColumn("STATUS") 'declaring a column named Name
            WorkSTATUS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkSTATUS) 'adding the column to table

            Dim WorkMEINS_PZ As DataColumn = New DataColumn("MEINS_PZ") 'declaring a column named Name
            WorkMEINS_PZ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkMEINS_PZ) 'adding the column to table

            Dim WorkZQTAPK_ORI_BASE As DataColumn = New DataColumn("ZQTAPK_ORI_BASE") 'declaring a column named Name
            WorkZQTAPK_ORI_BASE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTAPK_ORI_BASE) 'adding the column to table

            Dim WorkMEINS_BASE As DataColumn = New DataColumn("MEINS_BASE") 'declaring a column named Name
            WorkMEINS_BASE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkMEINS_BASE) 'adding the column to table

            Dim WorkZQTAPK_ORI_CONS As DataColumn = New DataColumn("ZQTAPK_ORI_CONS") 'declaring a column named Name
            WorkZQTAPK_ORI_CONS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTAPK_ORI_CONS) 'adding the column to table

            Dim WorkMEINS_CONS As DataColumn = New DataColumn("MEINS_CONS") 'declaring a column named Name
            WorkMEINS_CONS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkMEINS_CONS) 'adding the column to table

            Dim WorkZQTAPK_FULL_PALL As DataColumn = New DataColumn("ZQTAPK_FULL_PALL") 'declaring a column named Name
            WorkZQTAPK_FULL_PALL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTAPK_FULL_PALL) 'adding the column to table

            Dim WorkZQTAPK_PARTIAL As DataColumn = New DataColumn("ZQTAPK_PARTIAL") 'declaring a column named Name
            WorkZQTAPK_PARTIAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTAPK_PARTIAL) 'adding the column to table

            Dim WorkZQTAPK_SFUSI_PZ As DataColumn = New DataColumn("ZQTAPK_SFUSI_PZ") 'declaring a column named Name
            WorkZQTAPK_SFUSI_PZ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTAPK_SFUSI_PZ) 'adding the column to table

            Dim WorkZQTA_PREL_BASE As DataColumn = New DataColumn("ZQTA_PREL_BASE") 'declaring a column named Name
            WorkZQTA_PREL_BASE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_PREL_BASE) 'adding the column to table

            Dim WorkUDM_QTAPR_BASE As DataColumn = New DataColumn("UDM_QTAPR_BASE") 'declaring a column named Name
            WorkUDM_QTAPR_BASE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkUDM_QTAPR_BASE) 'adding the column to table

            Dim WorkZQTA_PREL_CONS As DataColumn = New DataColumn("ZQTA_PREL_CONS") 'declaring a column named Name
            WorkZQTA_PREL_CONS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_PREL_CONS) 'adding the column to table

            Dim WorkUDM_QTAPR_CONS As DataColumn = New DataColumn("UDM_QTAPR_CONS") 'declaring a column named Name
            WorkUDM_QTAPR_CONS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkUDM_QTAPR_CONS) 'adding the column to table

            Dim WorkZQTA_PREL_PZ As DataColumn = New DataColumn("ZQTA_PREL_PZ") 'declaring a column named Name
            WorkZQTA_PREL_PZ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_PREL_PZ) 'adding the column to table

            Dim WorkZQTA_PREL_SC As DataColumn = New DataColumn("ZQTA_PREL_SC") 'declaring a column named Name
            WorkZQTA_PREL_SC.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_PREL_SC) 'adding the column to table

            Dim WorkZQTA_PREL_PAL As DataColumn = New DataColumn("ZQTA_PREL_PAL") 'declaring a column named Name
            WorkZQTA_PREL_PAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_PREL_PAL) 'adding the column to table

            Dim WorkZQTA_PREL_FULL As DataColumn = New DataColumn("ZQTA_PREL_FULL") 'declaring a column named Name
            WorkZQTA_PREL_FULL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_PREL_FULL) 'adding the column to table

            Dim WorkZQTA_PREL_PARTIA As DataColumn = New DataColumn("ZQTA_PREL_PARTIA") 'declaring a column named Name
            WorkZQTA_PREL_PARTIA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_PREL_PARTIA) 'adding the column to table

            Dim WorkZQTA_PREL_SF As DataColumn = New DataColumn("ZQTA_PREL_SF") 'declaring a column named Name
            WorkZQTA_PREL_SF.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_PREL_SF) 'adding the column to table

            Dim WorkZWMS_PESOMAT_EU As DataColumn = New DataColumn("ZWMS_PESOMAT_EU") 'declaring a column named Name
            WorkZWMS_PESOMAT_EU.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZWMS_PESOMAT_EU) 'adding the column to table

            Dim WorkGEWEI_EU As DataColumn = New DataColumn("GEWEI_EU") 'declaring a column named Name
            WorkGEWEI_EU.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkGEWEI_EU) 'adding the column to table

            Dim WorkZWMS_PESOMAT_USA As DataColumn = New DataColumn("ZWMS_PESOMAT_USA") 'declaring a column named Name
            WorkZWMS_PESOMAT_USA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZWMS_PESOMAT_USA) 'adding the column to table

            Dim WorkGEWEI_USA As DataColumn = New DataColumn("GEWEI_USA") 'declaring a column named Name
            WorkGEWEI_USA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkGEWEI_USA) 'adding the column to table

            Dim WorkUSERID_RF As DataColumn = New DataColumn("USERID_RF") 'declaring a column named Name
            WorkUSERID_RF.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkUSERID_RF) 'adding the column to table

            Dim WorkZPICK_QUEUE_DESC As DataColumn = New DataColumn("ZPICK_QUEUE_DESC") 'declaring a column named Name
            WorkZPICK_QUEUE_DESC.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZPICK_QUEUE_DESC) 'adding the column to table


            CreateDateTableForTaskLines = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForTaskLines = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CreateDateTableForGiacenze(ByRef outDataTable As DataTable) As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia le informazioni delle GIACENZE
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForGiacenze = 1 'init at error

            Dim WorkWERKS As DataColumn = New DataColumn("WERKS") 'declaring a column named Name
            WorkWERKS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkWERKS) 'adding the column to table

            Dim WorkLGNUM As DataColumn = New DataColumn("LGNUM") 'declaring a column named Name
            WorkLGNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGNUM) 'adding the column to table

            Dim WorkLGTYP As DataColumn = New DataColumn("LGTYP") 'declaring a column named Name
            WorkLGTYP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGTYP) 'adding the column to table

            Dim WorkLGPLA As DataColumn = New DataColumn("LGPLA") 'declaring a column named Name
            WorkLGPLA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGPLA) 'adding the column to table

            Dim WorkLQNUM As DataColumn = New DataColumn("LQNUM") 'declaring a column named Name
            WorkLQNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLQNUM) 'adding the column to table

            Dim WorkMATNR As DataColumn = New DataColumn("MATNR") 'declaring a column named Name
            WorkMATNR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkMATNR) 'adding the column to table

            Dim WorkCHARG As DataColumn = New DataColumn("CHARG") 'declaring a column named Name
            WorkCHARG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkCHARG) 'adding the column to table




            Dim WorkGESME_QTY_USER As DataColumn = New DataColumn("GESME_QTY_USER") 'declaring a column named Name
            WorkGESME_QTY_USER.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkGESME_QTY_USER) 'adding the column to table

            Dim WorkVERME_QTY_USER As DataColumn = New DataColumn("VERME_QTY_USER") 'declaring a column named Name
            WorkVERME_QTY_USER.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkVERME_QTY_USER) 'adding the column to table




            Dim WorkBESTQ As DataColumn = New DataColumn("BESTQ") 'declaring a column named Name
            WorkBESTQ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkBESTQ) 'adding the column to table

            Dim WorkVrkme As DataColumn = New DataColumn("VRKME") 'declaring a column named Name
            WorkVrkme.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkVrkme) 'adding the column to table

            Dim WorkVerme_cons As DataColumn = New DataColumn("VERME_CONS") 'declaring a column named Name
            WorkVerme_cons.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkVerme_cons) 'adding the column to table

            Dim WorkGesme_cons As DataColumn = New DataColumn("GESME_CONS") 'declaring a column named Name
            WorkGesme_cons.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkGesme_cons) 'adding the column to table


            Dim WorkMEINS_PAL As DataColumn = New DataColumn("MEINS_PAL") 'declaring a column named Name
            WorkMEINS_PAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkMEINS_PAL) 'adding the column to table


            Dim WorkGESME_PAL As DataColumn = New DataColumn("GESME_PAL") 'declaring a column named Name
            WorkGESME_PAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkGESME_PAL) 'adding the column to table

            Dim WorkVERME_PAL As DataColumn = New DataColumn("VERME_PAL") 'declaring a column named Name
            WorkVERME_PAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkVERME_PAL) 'adding the column to table

            Dim WorkGESME_PARTIAL As DataColumn = New DataColumn("GESME_PARTIAL") 'declaring a column named Name
            WorkGESME_PARTIAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkGESME_PARTIAL) 'adding the column to table

            Dim WorkVERME_PARTIAL As DataColumn = New DataColumn("VERME_PARTIAL") 'declaring a column named Name
            WorkVERME_PARTIAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkVERME_PARTIAL) 'adding the column to table

            Dim WorkGesme_pz As DataColumn = New DataColumn("GESME_PZ") 'declaring a column named Name
            WorkGesme_pz.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkGesme_pz) 'adding the column to table

            Dim WorkVerme_pz As DataColumn = New DataColumn("VERME_PZ") 'declaring a column named Name
            WorkVerme_pz.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkVerme_pz) 'adding the column to table

            Dim WorkGesme_SF As DataColumn = New DataColumn("GESME_SF") 'declaring a column named Name
            WorkGesme_SF.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkGesme_SF) 'adding the column to table

            Dim WorkVerme_SF As DataColumn = New DataColumn("VERME_SF") 'declaring a column named Name
            WorkVerme_SF.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkVerme_SF) 'adding the column to table

            Dim WorkMEINS As DataColumn = New DataColumn("MEINS") 'declaring a column named Name
            WorkMEINS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkMEINS) 'adding the column to table

            Dim WorkMEINS_PZ As DataColumn = New DataColumn("MEINS_PZ") 'declaring a column named Name
            WorkMEINS_PZ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkMEINS_PZ) 'adding the column to table

            Dim WorkGESME As DataColumn = New DataColumn("GESME") 'declaring a column named Name
            WorkGESME.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkGESME) 'adding the column to table

            Dim WorkVERME As DataColumn = New DataColumn("VERME") 'declaring a column named Name
            WorkVERME.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkVERME) 'adding the column to table

            Dim WorkLENUM As DataColumn = New DataColumn("LENUM") 'declaring a column named Name
            WorkLENUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLENUM) 'adding the column to table

            Dim WorkSOBKZ As DataColumn = New DataColumn("SOBKZ") 'declaring a column named Name
            WorkSOBKZ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkSOBKZ) 'adding the column to table

            Dim WorkSONUM As DataColumn = New DataColumn("SONUM") 'declaring a column named Name
            WorkSONUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkSONUM) 'adding the column to table

            Dim WorkTBNUM As DataColumn = New DataColumn("TBNUM") 'declaring a column named Name
            WorkTBNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkTBNUM) 'adding the column to table

            Dim WorkLGORT As DataColumn = New DataColumn("LGORT") 'declaring a column named Name
            WorkLGORT.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGORT) 'adding the column to table

            Dim WorkMaktg As DataColumn = New DataColumn("MAKTG") 'declaring a column named Name
            WorkMaktg.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkMaktg) 'adding the column to table

            Dim Imballo As DataColumn = New DataColumn("IMBALLO") 'declaring a column named Name
            Imballo.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(Imballo) 'adding the column to table

            Dim PzXSc As DataColumn = New DataColumn("PZ_X_SC") 'declaring a column named Name
            PzXSc.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(PzXSc) 'adding the column to table

            Dim ScXPal As DataColumn = New DataColumn("SC_X_PAL") 'declaring a column named Name
            ScXPal.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(ScXPal) 'adding the column to table

            Dim M2XPal As DataColumn = New DataColumn("M2_X_PAL") 'declaring a column named Name
            M2XPal.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(M2XPal) 'adding the column to table

            Dim LagpLkapv As DataColumn = New DataColumn("LAGP_LKAPV") 'declaring a column named Name
            LagpLkapv.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(LagpLkapv) 'adding the column to table

            Dim NumPallet As DataColumn = New DataColumn("NUM_PALLET") 'declaring a column named Name
            NumPallet.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(NumPallet) 'adding the column to table

            Dim ZFLAG_UDS As DataColumn = New DataColumn("ZFLAG_UDS") 'declaring a column named Name
            ZFLAG_UDS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(ZFLAG_UDS) 'adding the column to table

            Dim ODV_VBELN As DataColumn = New DataColumn("ODV_VBELN") 'declaring a column named Name
            ODV_VBELN.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(ODV_VBELN) 'adding the column to table

            Dim ODV_POSNR As DataColumn = New DataColumn("ODV_POSNR") 'declaring a column named Name
            ODV_POSNR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(ODV_POSNR) 'adding the column to table

            Dim ODV_KUNNR_AG As DataColumn = New DataColumn("ODV_KUNNR_AG") 'declaring a column named Name
            ODV_KUNNR_AG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(ODV_KUNNR_AG) 'adding the column to table

            Dim ODV_KUNNR_WE As DataColumn = New DataColumn("ODV_KUNNR_WE") 'declaring a column named Name
            ODV_KUNNR_WE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(ODV_KUNNR_WE) 'adding the column to table

            Dim ODV_LIFNR_SP As DataColumn = New DataColumn("ODV_LIFNR_SP") 'declaring a column named Name
            ODV_LIFNR_SP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(ODV_LIFNR_SP) 'adding the column to table

            Dim ODV_KUNNR_AG_NAME1 As DataColumn = New DataColumn("ODV_KUNNR_AG_NAME1") 'declaring a column named Name
            ODV_KUNNR_AG_NAME1.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(ODV_KUNNR_AG_NAME1) 'adding the column to table

            Dim ODV_KUNNR_WE_NAME1 As DataColumn = New DataColumn("ODV_KUNNR_WE_NAME1") 'declaring a column named Name
            ODV_KUNNR_WE_NAME1.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(ODV_KUNNR_WE_NAME1) 'adding the column to table

            Dim ODV_LIFNR_SP_NAME1 As DataColumn = New DataColumn("ODV_LIFNR_SP_NAME1") 'declaring a column named Name
            ODV_LIFNR_SP_NAME1.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(ODV_LIFNR_SP_NAME1) 'adding the column to table

            Dim ZNR_WMS_JOBS As DataColumn = New DataColumn("ZNR_WMS_JOBS") 'declaring a column named Name
            ZNR_WMS_JOBS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(ZNR_WMS_JOBS) 'adding the column to table

            Dim ZNR_WMS_JOBSGRP As DataColumn = New DataColumn("ZNR_WMS_JOBSGRP") 'declaring a column named Name
            ZNR_WMS_JOBSGRP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(ZNR_WMS_JOBSGRP) 'adding the column to table

            Dim ZNRPICK As DataColumn = New DataColumn("ZNRPICK") 'declaring a column named Name
            ZNRPICK.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(ZNRPICK) 'adding the column to table

            Dim ZPOSPK As DataColumn = New DataColumn("ZPOSPK") 'declaring a column named Name
            ZPOSPK.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(ZPOSPK) 'adding the column to table

            Dim ZWMS_SKU_PALLET As DataColumn = New DataColumn("ZWMS_SKU_PALLET") 'declaring a column named Name
            ZWMS_SKU_PALLET.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(ZWMS_SKU_PALLET) 'adding the column to table

            Dim ZZCDLEGACY As DataColumn = New DataColumn("ZZCDLEGACY") 'declaring a column named Name
            ZZCDLEGACY.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(ZZCDLEGACY) 'adding the column to table


            'Nuovi campi per Gestire Unità di Misura Metri Quadri in IT e EN
            Dim WorkGesmeM2_cons As DataColumn = New DataColumn("GESME_M2") 'declaring a column named Name
            WorkGesmeM2_cons.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkGesmeM2_cons) 'adding the column to table

            Dim WorkGesmeSQF_cons As DataColumn = New DataColumn("GESME_SQF") 'declaring a column named Name
            WorkGesmeSQF_cons.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkGesmeSQF_cons) 'adding the column to table

            Dim WorkMEINSM2 As DataColumn = New DataColumn("MEINS_M2") 'declaring a column named Name
            WorkMEINSM2.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkMEINSM2) 'adding the column to table

            Dim WorkMEINSSQF As DataColumn = New DataColumn("MEINS_SQF") 'declaring a column named Name
            WorkMEINSSQF.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkMEINSSQF) 'adding the column to table


            'AGGIUNTA CAMPI GESTIONE QTA' TOTALI DELLE UBICAZIONI
            Dim WorkUBI_USER_QTY_TOTAL As DataColumn = New DataColumn("UBI_USER_QTY_TOTAL") 'declaring a column named Name
            WorkUBI_USER_QTY_TOTAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkUBI_USER_QTY_TOTAL) 'adding the column to table

            Dim WorkZGESTIONE_PZ_ATTIVA As DataColumn = New DataColumn("ZGESTIONE_PZ_ATTIVA") 'declaring a column named Name
            WorkZGESTIONE_PZ_ATTIVA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZGESTIONE_PZ_ATTIVA) 'adding the column to table

            'AGGIUNTA GESTIONE PEZZI ATTIVA
            Dim WorkGESTIONE_UM_ATTIVA As DataColumn = New DataColumn("GESTIONE_UM_ATTIVA") 'declaring a column named Name
            WorkGESTIONE_UM_ATTIVA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkGESTIONE_UM_ATTIVA) 'adding the column to table


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

    Public Shared Function CreateDateTableForUDSInfo(ByRef outDataTable As DataTable) As Long
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

            Dim WorkWERKS As DataColumn = New DataColumn("WERKS") 'declaring a column named Name
            WorkWERKS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkWERKS) 'adding the column to table

            Dim WorkLGNUM As DataColumn = New DataColumn("LGNUM") 'declaring a column named Name
            WorkLGNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGNUM) 'adding the column to table

            Dim WorkLENUM As DataColumn = New DataColumn("LENUM") 'declaring a column named Name
            WorkLENUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLENUM) 'adding the column to table

            Dim WorkMATNR As DataColumn = New DataColumn("MATNR") 'declaring a column named Name
            WorkMATNR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkMATNR) 'adding the column to table

            Dim WorkCHARG As DataColumn = New DataColumn("CHARG") 'declaring a column named Name
            WorkCHARG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkCHARG) 'adding the column to table

            Dim ZNR_WMS_JOBS As DataColumn = New DataColumn("ZNR_WMS_JOBS") 'declaring a column named Name
            ZNR_WMS_JOBS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(ZNR_WMS_JOBS) 'adding the column to table

            Dim WorkLETYP As DataColumn = New DataColumn("LETYP") 'declaring a column named Name
            WorkLETYP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLETYP) 'adding the column to table

            Dim WorkZQTA_PREL_BASE As DataColumn = New DataColumn("ZQTA_PREL_BASE") 'declaring a column named Name
            WorkZQTA_PREL_BASE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_PREL_BASE) 'adding the column to table

            Dim WorkUDM_QTAPR_MEINS As DataColumn = New DataColumn("UDM_QTAPR_MEINS") 'declaring a column named Name
            WorkUDM_QTAPR_MEINS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkUDM_QTAPR_MEINS) 'adding the column to table

            Dim WorkZQTA_PREL_CONS As DataColumn = New DataColumn("ZQTA_PREL_CONS") 'declaring a column named Name
            WorkZQTA_PREL_CONS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_PREL_CONS) 'adding the column to table

            Dim WorkUDM_QTAPR_CONS As DataColumn = New DataColumn("UDM_QTAPR_CONS") 'declaring a column named Name
            WorkUDM_QTAPR_CONS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkUDM_QTAPR_CONS) 'adding the column to table

            Dim WorkZQTA_PREL_PZ As DataColumn = New DataColumn("ZQTA_PREL_PZ") 'declaring a column named Name
            WorkZQTA_PREL_PZ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_PREL_PZ) 'adding the column to table

            Dim WorkUDM_QTAPR_PZ As DataColumn = New DataColumn("UDM_QTAPR_PZ") 'declaring a column named Name
            WorkUDM_QTAPR_PZ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkUDM_QTAPR_PZ) 'adding the column to table


            Dim WorkZQTA_PREL_SF As DataColumn = New DataColumn("ZQTA_PREL_SF") 'declaring a column named Name
            WorkZQTA_PREL_SF.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_PREL_SF) 'adding the column to table


            Dim WorkZWMS_PESOMAT_EU As DataColumn = New DataColumn("ZWMS_PESOMAT_EU") 'declaring a column named Name
            WorkZWMS_PESOMAT_EU.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZWMS_PESOMAT_EU) 'adding the column to table

            Dim WorkGEWEI_EU As DataColumn = New DataColumn("GEWEI_EU") 'declaring a column named Name
            WorkGEWEI_EU.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkGEWEI_EU) 'adding the column to table

            Dim WorkZWMS_PESOMAT_USA As DataColumn = New DataColumn("ZWMS_PESOMAT_USA") 'declaring a column named Name
            WorkZWMS_PESOMAT_USA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZWMS_PESOMAT_USA) 'adding the column to table

            Dim WorkGEWEI_USA As DataColumn = New DataColumn("GEWEI_USA") 'declaring a column named Name
            WorkGEWEI_USA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkGEWEI_USA) 'adding the column to table

            Dim WorkDATA_CREAZIONE As DataColumn = New DataColumn("DATA_CREAZIONE") 'declaring a column named Name
            WorkDATA_CREAZIONE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkDATA_CREAZIONE) 'adding the column to table

            Dim WorkORA_CREAZIONE As DataColumn = New DataColumn("ORA_CREAZIONE") 'declaring a column named Name
            WorkORA_CREAZIONE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkORA_CREAZIONE) 'adding the column to table

            Dim WorkDATA_MODIFICA As DataColumn = New DataColumn("DATA_MODIFICA") 'declaring a column named Name
            WorkDATA_MODIFICA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkDATA_MODIFICA) 'adding the column to table

            Dim WorkORA_MODIFICA As DataColumn = New DataColumn("ORA_MODIFICA") 'declaring a column named Name
            WorkORA_MODIFICA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkORA_MODIFICA) 'adding the column to table

            Dim WorkUSERID_RF_CREA As DataColumn = New DataColumn("USERID_RF_CREA") 'declaring a column named Name
            WorkUSERID_RF_CREA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkUSERID_RF_CREA) 'adding the column to table

            Dim WorkUSERID_RF_MOD As DataColumn = New DataColumn("USERID_RF_MOD") 'declaring a column named Name
            WorkUSERID_RF_MOD.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkUSERID_RF_MOD) 'adding the column to table

            Dim WorkUSERID As DataColumn = New DataColumn("USERID") 'declaring a column named Name
            WorkUSERID.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkUSERID) 'adding the column to table


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

    Public Shared Function CreateDateTableForUDCInfo(ByRef outDataTable As DataTable) As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForUDCInfo = 1 'init at error

            Dim WorkWERKS As DataColumn = New DataColumn("WERKS") 'declaring a column named Name
            WorkWERKS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkWERKS) 'adding the column to table

            Dim WorkLGNUM As DataColumn = New DataColumn("LGNUM") 'declaring a column named Name
            WorkLGNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGNUM) 'adding the column to table

            Dim WorkICON_ID As DataColumn = New DataColumn("ICON_ID") 'declaring a column named Name
            WorkICON_ID.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkICON_ID) 'adding the column to table

            Dim WorkZNR_WMS_JOBSGRP As DataColumn = New DataColumn("ZNR_WMS_JOBSGRP") 'declaring a column named Name
            WorkZNR_WMS_JOBSGRP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZNR_WMS_JOBSGRP) 'adding the column to table

            Dim WorkNUM_CONS_VBELV As DataColumn = New DataColumn("NUM_CONS_VBELV") 'declaring a column named Name
            WorkNUM_CONS_VBELV.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkNUM_CONS_VBELV) 'adding the column to table

            Dim WorkPOS_CONS_POSNV As DataColumn = New DataColumn("POS_CONS_POSNV") 'declaring a column named Name
            WorkPOS_CONS_POSNV.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkPOS_CONS_POSNV) 'adding the column to table

            Dim WorkTKNUM As DataColumn = New DataColumn("TKNUM") 'declaring a column named Name
            WorkTKNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkTKNUM) 'adding the column to table

            Dim WorkZWMS_STOP_SEQ As DataColumn = New DataColumn("ZWMS_STOP_SEQ") 'declaring a column named Name
            WorkZWMS_STOP_SEQ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZWMS_STOP_SEQ) 'adding the column to table

            Dim WorkZWMS_DROP_SEQ As DataColumn = New DataColumn("ZWMS_DROP_SEQ") 'declaring a column named Name
            WorkZWMS_DROP_SEQ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZWMS_DROP_SEQ) 'adding the column to table

            Dim WorkLENUM As DataColumn = New DataColumn("LENUM") 'declaring a column named Name
            WorkLENUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLENUM) 'adding the column to table

            Dim WorkMATNR As DataColumn = New DataColumn("MATNR") 'declaring a column named Name
            WorkMATNR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkMATNR) 'adding the column to table

            Dim WorkCHARG As DataColumn = New DataColumn("CHARG") 'declaring a column named Name
            WorkCHARG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkCHARG) 'adding the column to table

            Dim ZNR_WMS_JOBS As DataColumn = New DataColumn("ZNR_WMS_JOBS") 'declaring a column named Name
            ZNR_WMS_JOBS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(ZNR_WMS_JOBS) 'adding the column to table

            Dim WorkLETYP As DataColumn = New DataColumn("LETYP") 'declaring a column named Name
            WorkLETYP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLETYP) 'adding the column to table

            Dim WorkLGTYP As DataColumn = New DataColumn("LGTYP") 'declaring a column named Name
            WorkLGTYP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGTYP) 'adding the column to table

            Dim WorkLGPLA As DataColumn = New DataColumn("LGPLA") 'declaring a column named Name
            WorkLGPLA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGPLA) 'adding the column to table

            Dim WorkLGNUM_DOOCK_DOOR As DataColumn = New DataColumn("LGNUM_DOOCK_DOOR") 'declaring a column named Name
            WorkLGNUM_DOOCK_DOOR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGNUM_DOOCK_DOOR) 'adding the column to table

            Dim WorkLGTYP_DOOCK_DOOR As DataColumn = New DataColumn("LGTYP_DOOCK_DOOR") 'declaring a column named Name
            WorkLGTYP_DOOCK_DOOR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGTYP_DOOCK_DOOR) 'adding the column to table

            Dim WorkLGPLA_DOOCK_DOOR As DataColumn = New DataColumn("LGPLA_DOOCK_DOOR") 'declaring a column named Name
            WorkLGPLA_DOOCK_DOOR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGPLA_DOOCK_DOOR) 'adding the column to table

            Dim WorkLGNUM_STAG_DOOR As DataColumn = New DataColumn("LGNUM_STAG_DOOR") 'declaring a column named Name
            WorkLGNUM_STAG_DOOR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGNUM_STAG_DOOR) 'adding the column to table

            Dim WorkLGTYP_STAG_DOOR As DataColumn = New DataColumn("LGTYP_STAG_DOOR") 'declaring a column named Name
            WorkLGTYP_STAG_DOOR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGTYP_STAG_DOOR) 'adding the column to table

            Dim WorkLGPLA_STAG_DOOR As DataColumn = New DataColumn("LGPLA_STAG_DOOR") 'declaring a column named Name
            WorkLGPLA_STAG_DOOR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGPLA_STAG_DOOR) 'adding the column to table

            Dim WorkZQTA_PREL_BASE As DataColumn = New DataColumn("ZQTA_PREL_BASE") 'declaring a column named Name
            WorkZQTA_PREL_BASE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_PREL_BASE) 'adding the column to table

            Dim WorkUDM_QTAPR_MEINS As DataColumn = New DataColumn("UDM_QTAPR_MEINS") 'declaring a column named Name
            WorkUDM_QTAPR_MEINS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkUDM_QTAPR_MEINS) 'adding the column to table

            Dim WorkZQTA_PREL_CONS As DataColumn = New DataColumn("ZQTA_PREL_CONS") 'declaring a column named Name
            WorkZQTA_PREL_CONS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_PREL_CONS) 'adding the column to table

            Dim WorkUDM_QTAPR_CONS As DataColumn = New DataColumn("UDM_QTAPR_CONS") 'declaring a column named Name
            WorkUDM_QTAPR_CONS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkUDM_QTAPR_CONS) 'adding the column to table

            Dim WorkZQTA_PREL_PZ As DataColumn = New DataColumn("ZQTA_PREL_PZ") 'declaring a column named Name
            WorkZQTA_PREL_PZ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_PREL_PZ) 'adding the column to table

            Dim WorkUDM_QTAPR_PZ As DataColumn = New DataColumn("UDM_QTAPR_PZ") 'declaring a column named Name
            WorkUDM_QTAPR_PZ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkUDM_QTAPR_PZ) 'adding the column to table

            Dim WorkZWMS_PESOMAT_EU As DataColumn = New DataColumn("ZWMS_PESOMAT_EU") 'declaring a column named Name
            WorkZWMS_PESOMAT_EU.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZWMS_PESOMAT_EU) 'adding the column to table

            Dim WorkGEWEI_EU As DataColumn = New DataColumn("GEWEI_EU") 'declaring a column named Name
            WorkGEWEI_EU.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkGEWEI_EU) 'adding the column to table

            Dim WorkZWMS_PESOMAT_USA As DataColumn = New DataColumn("ZWMS_PESOMAT_USA") 'declaring a column named Name
            WorkZWMS_PESOMAT_USA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZWMS_PESOMAT_USA) 'adding the column to table

            Dim WorkGEWEI_USA As DataColumn = New DataColumn("GEWEI_USA") 'declaring a column named Name
            WorkGEWEI_USA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkGEWEI_USA) 'adding the column to table

            Dim WorkDATA_CREAZIONE As DataColumn = New DataColumn("DATA_CREAZIONE") 'declaring a column named Name
            WorkDATA_CREAZIONE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkDATA_CREAZIONE) 'adding the column to table

            Dim WorkORA_CREAZIONE As DataColumn = New DataColumn("ORA_CREAZIONE") 'declaring a column named Name
            WorkORA_CREAZIONE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkORA_CREAZIONE) 'adding the column to table

            Dim WorkDATA_MODIFICA As DataColumn = New DataColumn("DATA_MODIFICA") 'declaring a column named Name
            WorkDATA_MODIFICA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkDATA_MODIFICA) 'adding the column to table

            Dim WorkORA_MODIFICA As DataColumn = New DataColumn("ORA_MODIFICA") 'declaring a column named Name
            WorkORA_MODIFICA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkORA_MODIFICA) 'adding the column to table

            Dim WorkUSERID_RF_CREA As DataColumn = New DataColumn("USERID_RF_CREA") 'declaring a column named Name
            WorkUSERID_RF_CREA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkUSERID_RF_CREA) 'adding the column to table

            Dim WorkUSERID_RF_MOD As DataColumn = New DataColumn("USERID_RF_MOD") 'declaring a column named Name
            WorkUSERID_RF_MOD.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkUSERID_RF_MOD) 'adding the column to table

            Dim WorkUSERID_RF_LOAD As DataColumn = New DataColumn("USERID_RF_LOAD") 'declaring a column named Name
            WorkUSERID_RF_LOAD.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkUSERID_RF_LOAD) 'adding the column to table

            Dim WorkZUDS_CHECK As DataColumn = New DataColumn("ZUDS_CHECK") 'declaring a column named Name
            WorkZUDS_CHECK.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZUDS_CHECK) 'adding the column to table

            Dim WorkZQTA_PREL_BASE_CHK As DataColumn = New DataColumn("ZQTA_PREL_BASE_CHK") 'declaring a column named Name
            WorkZQTA_PREL_BASE_CHK.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_PREL_BASE_CHK) 'adding the column to table

            Dim WorkZQTA_PREL_CONS_CHK As DataColumn = New DataColumn("ZQTA_PREL_CONS_CHK") 'declaring a column named Name
            WorkZQTA_PREL_CONS_CHK.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_PREL_CONS_CHK) 'adding the column to table

            Dim WorkZWMS_LOAD_MERCI As DataColumn = New DataColumn("ZWMS_LOAD_MERCI") 'declaring a column named Name
            WorkZWMS_LOAD_MERCI.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZWMS_LOAD_MERCI) 'adding the column to table

            Dim WorkZLOADSTATUS_DESCR As DataColumn = New DataColumn("ZLOADSTATUS_DESCR") 'declaring a column named Name
            WorkZLOADSTATUS_DESCR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZLOADSTATUS_DESCR) 'adding the column to table

            Dim WorkDATA_LOAD As DataColumn = New DataColumn("DATA_LOAD") 'declaring a column named Name
            WorkDATA_LOAD.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkDATA_LOAD) 'adding the column to table

            Dim WorkORA_LOAD As DataColumn = New DataColumn("ORA_LOAD") 'declaring a column named Name
            WorkORA_LOAD.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkORA_LOAD) 'adding the column to table

            Dim WorkUSERID As DataColumn = New DataColumn("USERID") 'declaring a column named Name
            WorkUSERID.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkUSERID) 'adding the column to table


            Dim WorkMBLNR As DataColumn = New DataColumn("MBLNR") 'declaring a column named Name
            WorkMBLNR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkMBLNR) 'adding the column to table

            Dim WorkMJAHR As DataColumn = New DataColumn("MJAHR") 'declaring a column named Name
            WorkMJAHR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkMJAHR) 'adding the column to table

            Dim WorkZEILE As DataColumn = New DataColumn("ZEILE") 'declaring a column named Name
            WorkZEILE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZEILE) 'adding the column to table



            CreateDateTableForUDCInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForUDCInfo = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CreateDateTableForUDS(ByRef outDataTable As DataTable) As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForUDS = 1 'init at error

            Dim WorkWERKS As DataColumn = New DataColumn("WERKS") 'declaring a column named Name
            WorkWERKS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkWERKS) 'adding the column to table

            Dim WorkLGNUM As DataColumn = New DataColumn("LGNUM") 'declaring a column named Name
            WorkLGNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGNUM) 'adding the column to table

            Dim WorkLENUM As DataColumn = New DataColumn("LENUM") 'declaring a column named Name
            WorkLENUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLENUM) 'adding the column to table

            Dim WorkVBELN As DataColumn = New DataColumn("VBELN") 'declaring a column named Name
            WorkVBELN.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkVBELN) 'adding the column to table

            Dim ZNR_WMS_JOBSGRP As DataColumn = New DataColumn("ZNR_WMS_JOBSGRP") 'declaring a column named Name
            ZNR_WMS_JOBSGRP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(ZNR_WMS_JOBSGRP) 'adding the column to table

            Dim ZUDS_BARCODE As DataColumn = New DataColumn("ZUDS_BARCODE") 'declaring a column named Name
            ZUDS_BARCODE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(ZUDS_BARCODE) 'adding the column to table

            Dim WorkLETYP As DataColumn = New DataColumn("LETYP") 'declaring a column named Name
            WorkLETYP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLETYP) 'adding the column to table

            Dim WorkLGTYP As DataColumn = New DataColumn("LGTYP") 'declaring a column named Name
            WorkLGTYP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGTYP) 'adding the column to table

            Dim WorkLGPLA As DataColumn = New DataColumn("LGPLA") 'declaring a column named Name
            WorkLGPLA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGPLA) 'adding the column to table

            Dim WorkZUDS_LOADED_TRUC As DataColumn = New DataColumn("ZUDS_LOADED_TRUC") 'declaring a column named Name
            WorkZUDS_LOADED_TRUC.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZUDS_LOADED_TRUC) 'adding the column to table

            Dim WorkDATA_TRUCK_LOAD As DataColumn = New DataColumn("DATA_TRUCK_LOAD") 'declaring a column named Name
            WorkDATA_TRUCK_LOAD.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkDATA_TRUCK_LOAD) 'adding the column to table

            Dim WorkORA_TRUCK_LOAD As DataColumn = New DataColumn("ORA_TRUCK_LOAD") 'declaring a column named Name
            WorkORA_TRUCK_LOAD.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkORA_TRUCK_LOAD) 'adding the column to table

            Dim WorkUSERID_RF_TRUCLD As DataColumn = New DataColumn("USERID_RF_TRUCLD") 'declaring a column named Name
            WorkUSERID_RF_TRUCLD.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkUSERID_RF_TRUCLD) 'adding the column to table

            Dim WorkUSERID As DataColumn = New DataColumn("USERID") 'declaring a column named Name
            WorkUSERID.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkUSERID) 'adding the column to table


            CreateDateTableForUDS = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForUDS = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CreateDateTableForWmsJobs(ByRef outDataTable As DataTable) As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con JOB INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForWmsJobs = 1 'init at error

            '>>> QUESTO CAMPO E' SOLO VIRTUALE PER INDICARE L'ESECUZIONE DEL JOB NELLE GRIGLIE DELL'OPERATORE
            Dim WorkGRID_EXECUTED As DataColumn = New DataColumn("GRID_EXECUTED") 'declaring a column named Name
            WorkGRID_EXECUTED.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkGRID_EXECUTED) 'adding the column to table

            Dim WorkZNR_WMS_JOBS As DataColumn = New DataColumn("ZNR_WMS_JOBS") 'declaring a column named Name
            WorkZNR_WMS_JOBS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZNR_WMS_JOBS) 'adding the column to table

            Dim WorkZNR_WMS_JOBSGRP As DataColumn = New DataColumn("ZNR_WMS_JOBSGRP") 'declaring a column named Name
            WorkZNR_WMS_JOBSGRP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZNR_WMS_JOBSGRP) 'adding the column to table

            Dim WorkZNR_WMS_GRPEXEC As DataColumn = New DataColumn("ZNR_WMS_GRPEXEC") 'declaring a column named Name
            WorkZNR_WMS_GRPEXEC.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZNR_WMS_GRPEXEC) 'adding the column to table

            Dim WorkIDSTATUS As DataColumn = New DataColumn("IDSTATUS") 'declaring a column named Name
            WorkIDSTATUS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkIDSTATUS) 'adding the column to table

            Dim WorkSTATUS As DataColumn = New DataColumn("STATUS") 'declaring a column named Name
            WorkSTATUS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkSTATUS) 'adding the column to table

            Dim WorkSTATUS_DESCR As DataColumn = New DataColumn("STATUS_DESCR") 'declaring a column named Name
            WorkSTATUS_DESCR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkSTATUS_DESCR) 'adding the column to table

            Dim WorkMAKTG As DataColumn = New DataColumn("MAKTG") 'declaring a column named Name
            WorkMAKTG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkMAKTG) 'adding the column to table

            ' >>>> ORIGINE INFO
            Dim WorkWERKS_ORI As DataColumn = New DataColumn("WERKS_ORI") 'declaring a column named Name
            WorkWERKS_ORI.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkWERKS_ORI) 'adding the column to table

            Dim WorkLGORT_ORI As DataColumn = New DataColumn("LGORT_ORI") 'declaring a column named Name
            WorkLGORT_ORI.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGORT_ORI) 'adding the column to table

            Dim WorkMATNR_ORI As DataColumn = New DataColumn("MATNR_ORI") 'declaring a column named Name
            WorkMATNR_ORI.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkMATNR_ORI) 'adding the column to table

            Dim WorkCHARG_ORI As DataColumn = New DataColumn("CHARG_ORI") 'declaring a column named Name
            WorkCHARG_ORI.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkCHARG_ORI) 'adding the column to table

            Dim WorkBESTQ_ORI As DataColumn = New DataColumn("BESTQ_ORI") 'declaring a column named Name
            WorkBESTQ_ORI.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkBESTQ_ORI) 'adding the column to table

            Dim WorkSOBKZ_ORI As DataColumn = New DataColumn("SOBKZ_ORI") 'declaring a column named Name
            WorkSOBKZ_ORI.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkSOBKZ_ORI) 'adding the column to table

            Dim WorkSONUM_ORI As DataColumn = New DataColumn("SONUM_ORI") 'declaring a column named Name
            WorkSONUM_ORI.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkSONUM_ORI) 'adding the column to table

            Dim WorkLGNUM_ORI As DataColumn = New DataColumn("LGNUM_ORI") 'declaring a column named Name
            WorkLGNUM_ORI.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGNUM_ORI) 'adding the column to table

            Dim WorkLGTYP_ORI As DataColumn = New DataColumn("LGTYP_ORI") 'declaring a column named Name
            WorkLGTYP_ORI.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGTYP_ORI) 'adding the column to table

            Dim WorkLGPLA_ORI As DataColumn = New DataColumn("LGPLA_ORI") 'declaring a column named Name
            WorkLGPLA_ORI.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGPLA_ORI) 'adding the column to table

            Dim WorkLENUM_ORI As DataColumn = New DataColumn("LENUM_ORI") 'declaring a column named Name
            WorkLENUM_ORI.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLENUM_ORI) 'adding the column to table

            ' >>>> QTA DA PRELEVARE ( UDM ORIGINALE )
            Dim WorkMEINS_ORI As DataColumn = New DataColumn("MEINS_ORI") 'declaring a column named Name
            WorkMEINS_ORI.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkMEINS_ORI) 'adding the column to table

            Dim WorkZQTAPK_ORI As DataColumn = New DataColumn("ZQTAPK_ORI") 'declaring a column named Name
            WorkZQTAPK_ORI.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTAPK_ORI) 'adding the column to table

            Dim WorkMEINS_PZ As DataColumn = New DataColumn("MEINS_PZ") 'declaring a column named Name
            WorkMEINS_PZ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkMEINS_PZ) 'adding the column to table

            Dim WorkMEINS_SC As DataColumn = New DataColumn("MEINS_SC") 'declaring a column named Name
            WorkMEINS_SC.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkMEINS_SC) 'adding the column to table

            Dim WorkMEINS_PAL As DataColumn = New DataColumn("MEINS_PAL") 'declaring a column named Name
            WorkMEINS_PAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkMEINS_PAL) 'adding the column to table

            Dim WorkZQTAPK_ORI_BASE As DataColumn = New DataColumn("ZQTAPK_ORI_BASE") 'declaring a column named Name
            WorkZQTAPK_ORI_BASE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTAPK_ORI_BASE) 'adding the column to table

            Dim WorkZQTAPK_ORI_CONS As DataColumn = New DataColumn("ZQTAPK_ORI_CONS") 'declaring a column named Name
            WorkZQTAPK_ORI_CONS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTAPK_ORI_CONS) 'adding the column to table

            Dim WorkZQTAPK_ORI_PZ As DataColumn = New DataColumn("ZQTAPK_ORI_PZ") 'declaring a column named Name
            WorkZQTAPK_ORI_PZ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTAPK_ORI_PZ) 'adding the column to table

            Dim WorkZQTAPK_ORI_SC As DataColumn = New DataColumn("ZQTAPK_ORI_SC") 'declaring a column named Name
            WorkZQTAPK_ORI_SC.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTAPK_ORI_SC) 'adding the column to table

            Dim WorkZQTAPK_ORI_PL As DataColumn = New DataColumn("ZQTAPK_ORI_PL") 'declaring a column named Name
            WorkZQTAPK_ORI_PL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTAPK_ORI_PL) 'adding the column to table

            Dim WorkZQTAPK_FULL_PALL As DataColumn = New DataColumn("ZQTAPK_FULL_PALL") 'declaring a column named Name
            WorkZQTAPK_FULL_PALL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTAPK_FULL_PALL) 'adding the column to table

            Dim WorkZQTAPK_PARTIAL As DataColumn = New DataColumn("ZQTAPK_PARTIAL") 'declaring a column named Name
            WorkZQTAPK_PARTIAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTAPK_PARTIAL) 'adding the column to table

            Dim WorkZQTAPK_SFUSI_PZ As DataColumn = New DataColumn("ZQTAPK_SFUSI_PZ") 'declaring a column named Name
            WorkZQTAPK_SFUSI_PZ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTAPK_SFUSI_PZ) 'adding the column to table

            Dim WorkZQTA_PREL_BASE As DataColumn = New DataColumn("ZQTA_PREL_BASE") 'declaring a column named Name
            WorkZQTA_PREL_BASE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_PREL_BASE) 'adding the column to table

            Dim WorkUDM_QTAPR_MEINS As DataColumn = New DataColumn("UDM_QTAPR_MEINS") 'declaring a column named Name
            WorkUDM_QTAPR_MEINS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkUDM_QTAPR_MEINS) 'adding the column to table

            Dim WorkZQTA_PREL_CONS As DataColumn = New DataColumn("ZQTA_PREL_CONS") 'declaring a column named Name
            WorkZQTA_PREL_CONS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_PREL_CONS) 'adding the column to table

            Dim WorkUDM_QTAPR_CONS As DataColumn = New DataColumn("UDM_QTAPR_CONS") 'declaring a column named Name
            WorkUDM_QTAPR_CONS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkUDM_QTAPR_CONS) 'adding the column to table

            Dim WorkZQTA_PREL_FULL As DataColumn = New DataColumn("ZQTA_PREL_FULL") 'declaring a column named Name
            WorkZQTA_PREL_FULL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_PREL_FULL) 'adding the column to table

            Dim WorkZQTA_PREL_PARTIA As DataColumn = New DataColumn("ZQTA_PREL_PARTIA") 'declaring a column named Name
            WorkZQTA_PREL_PARTIA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_PREL_PARTIA) 'adding the column to table

            Dim WorkZQTA_PREL_SF As DataColumn = New DataColumn("ZQTA_PREL_SF") 'declaring a column named Name
            WorkZQTA_PREL_SF.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_PREL_SF) 'adding the column to table

            Dim WorkZQTA_PREL_PZ As DataColumn = New DataColumn("ZQTA_PREL_PZ") 'declaring a column named Name
            WorkZQTA_PREL_PZ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_PREL_PZ) 'adding the column to table

            'Dim WorkUDM_QTAPR_PZ As DataColumn = New DataColumn("UDM_QTAPR_PZ") 'declaring a column named Name
            'WorkUDM_QTAPR_PZ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            'outDataTable.Columns.Add(WorkUDM_QTAPR_PZ) 'adding the column to table

            ' >>>> DESTINAZIONE INFO
            Dim WorkWERKS_DEST As DataColumn = New DataColumn("WERKS_DEST") 'declaring a column named Name
            WorkWERKS_DEST.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkWERKS_DEST) 'adding the column to table

            Dim WorkLGORT_DEST As DataColumn = New DataColumn("LGORT_DEST") 'declaring a column named Name
            WorkLGORT_DEST.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGORT_DEST) 'adding the column to table

            Dim WorkMATNR_DEST As DataColumn = New DataColumn("MATNR_DEST") 'declaring a column named Name
            WorkMATNR_DEST.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkMATNR_DEST) 'adding the column to table

            Dim WorkCHARG_DEST As DataColumn = New DataColumn("CHARG_DEST") 'declaring a column named Name
            WorkCHARG_DEST.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkCHARG_DEST) 'adding the column to table

            Dim WorkBESTQ_DEST As DataColumn = New DataColumn("BESTQ_DEST") 'declaring a column named Name
            WorkBESTQ_DEST.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkBESTQ_DEST) 'adding the column to table

            Dim WorkSOBKZ_DEST As DataColumn = New DataColumn("SOBKZ_DEST") 'declaring a column named Name
            WorkSOBKZ_DEST.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkSOBKZ_DEST) 'adding the column to table

            Dim WorkSONUM_DEST As DataColumn = New DataColumn("SONUM_DEST") 'declaring a column named Name
            WorkSONUM_DEST.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkSONUM_DEST) 'adding the column to table

            Dim WorkLGNUM_DEST As DataColumn = New DataColumn("LGNUM_DEST") 'declaring a column named Name
            WorkLGNUM_DEST.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGNUM_DEST) 'adding the column to table

            Dim WorkLGTYP_DEST As DataColumn = New DataColumn("LGTYP_DEST") 'declaring a column named Name
            WorkLGTYP_DEST.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGTYP_DEST) 'adding the column to table

            Dim WorkLGPLA_DEST As DataColumn = New DataColumn("LGPLA_DEST") 'declaring a column named Name
            WorkLGPLA_DEST.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGPLA_DEST) 'adding the column to table

            Dim WorkLENUM_DEST As DataColumn = New DataColumn("LENUM_DEST") 'declaring a column named Name
            WorkLENUM_DEST.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLENUM_DEST) 'adding the column to table

            Dim WorkZPICKFULLPARTIAL As DataColumn = New DataColumn("ZPICKFULLPARTIAL") 'declaring a column named Name
            WorkZPICKFULLPARTIAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZPICKFULLPARTIAL) 'adding the column to table

            '>>> CAMPI PROPOSTE
            Dim WorkLGNUM_PROP_ORI As DataColumn = New DataColumn("LGNUM_PROP_ORI") 'declaring a column named Name
            WorkLGNUM_PROP_ORI.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGNUM_PROP_ORI) 'adding the column to table

            Dim WorkLGTYP_PROP_ORI As DataColumn = New DataColumn("LGTYP_PROP_ORI") 'declaring a column named Name
            WorkLGTYP_PROP_ORI.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGTYP_PROP_ORI) 'adding the column to table

            Dim WorkLGPLA_PROP_ORI As DataColumn = New DataColumn("LGPLA_PROP_ORI") 'declaring a column named Name
            WorkLGPLA_PROP_ORI.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGPLA_PROP_ORI) 'adding the column to table



            Dim WorkLENUM_PROP_ORI As DataColumn = New DataColumn("LENUM_PROP_ORI") 'declaring a column named Name
            WorkLENUM_PROP_ORI.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLENUM_PROP_ORI) 'adding the column to table

            Dim WorkOK_QTA_PROP_ORI As DataColumn = New DataColumn("OK_QTA_PROP_ORI") 'declaring a column named Name
            WorkOK_QTA_PROP_ORI.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkOK_QTA_PROP_ORI) 'adding the column to table

            Dim WorkLGNUM_PROP_ORIFL As DataColumn = New DataColumn("LGNUM_PROP_ORIFL") 'declaring a column named Name
            WorkLGNUM_PROP_ORIFL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGNUM_PROP_ORIFL) 'adding the column to table

            Dim WorkLGTYP_PROP_ORIFL As DataColumn = New DataColumn("LGTYP_PROP_ORIFL") 'declaring a column named Name
            WorkLGTYP_PROP_ORIFL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGTYP_PROP_ORIFL) 'adding the column to table

            Dim WorkLGPLA_PROP_ORIFL As DataColumn = New DataColumn("LGPLA_PROP_ORIFL") 'declaring a column named Name
            WorkLGPLA_PROP_ORIFL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGPLA_PROP_ORIFL) 'adding the column to table

            Dim WorkLENUM_PROP_ORIFL As DataColumn = New DataColumn("LENUM_PROP_ORIFL") 'declaring a column named Name
            WorkLENUM_PROP_ORIFL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLENUM_PROP_ORIFL) 'adding the column to table

            Dim WorkOK_QTA_PROPORIFL As DataColumn = New DataColumn("OK_QTA_PROPORIFL") 'declaring a column named Name
            WorkOK_QTA_PROPORIFL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkOK_QTA_PROPORIFL) 'adding the column to table



            Dim WorkLGNUM_PROP_DEST As DataColumn = New DataColumn("LGNUM_PROP_DEST") 'declaring a column named Name
            WorkLGNUM_PROP_DEST.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGNUM_PROP_DEST) 'adding the column to table

            Dim WorkLGTYP_PROP_DEST As DataColumn = New DataColumn("LGTYP_PROP_DEST") 'declaring a column named Name
            WorkLGTYP_PROP_DEST.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGTYP_PROP_DEST) 'adding the column to table

            Dim WorkLGPLA_PROP_DEST As DataColumn = New DataColumn("LGPLA_PROP_DEST") 'declaring a column named Name
            WorkLGPLA_PROP_DEST.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGPLA_PROP_DEST) 'adding the column to table

            ' >>> ALTRE INFO MISSIONE
            Dim WorkSEQUENCE As DataColumn = New DataColumn("SEQUENCE") 'declaring a column named Name
            WorkSEQUENCE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkSEQUENCE) 'adding the column to table

            Dim WorkCURRENT_STEP As DataColumn = New DataColumn("CURRENT_STEP") 'declaring a column named Name
            WorkCURRENT_STEP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkCURRENT_STEP) 'adding the column to table

            Dim WorNUM_STEPS_TOTAL As DataColumn = New DataColumn("NUM_STEPS_TOTAL") 'declaring a column named Name
            WorNUM_STEPS_TOTAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorNUM_STEPS_TOTAL) 'adding the column to table

            Dim WorkDATA_CREAZIONE As DataColumn = New DataColumn("DATA_CREAZIONE") 'declaring a column named Name
            WorkDATA_CREAZIONE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkDATA_CREAZIONE) 'adding the column to table

            Dim WorkORA_CREAZIONE As DataColumn = New DataColumn("ORA_CREAZIONE") 'declaring a column named Name
            WorkORA_CREAZIONE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkORA_CREAZIONE) 'adding the column to table

            Dim WorkDATA_START As DataColumn = New DataColumn("DATA_START") 'declaring a column named Name
            WorkDATA_START.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkDATA_START) 'adding the column to table

            Dim WorkORA_START As DataColumn = New DataColumn("ORA_START") 'declaring a column named Name
            WorkORA_START.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkORA_START) 'adding the column to table

            Dim WorkDATA_FINE As DataColumn = New DataColumn("DATA_FINE") 'declaring a column named Name
            WorkDATA_FINE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkDATA_FINE) 'adding the column to table

            Dim WorkORA_FINE As DataColumn = New DataColumn("ORA_FINE") 'declaring a column named Name
            WorkORA_FINE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkORA_FINE) 'adding the column to table

            Dim WorkPICK_DBTABNAME As DataColumn = New DataColumn("PICK_DBTABNAME") 'declaring a column named Name
            WorkPICK_DBTABNAME.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkPICK_DBTABNAME) 'adding the column to table

            Dim WorkZNRPICK As DataColumn = New DataColumn("ZNRPICK") 'declaring a column named Name
            WorkZNRPICK.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZNRPICK) 'adding the column to table

            Dim WorkZPOSPK As DataColumn = New DataColumn("ZPOSPK") 'declaring a column named Name
            WorkZPOSPK.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZPOSPK) 'adding the column to table

            Dim WorkVBELN As DataColumn = New DataColumn("VBELN") 'declaring a column named Name
            WorkVBELN.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkVBELN) 'adding the column to table

            Dim WorkPOSNR As DataColumn = New DataColumn("POSNR") 'declaring a column named Name
            WorkPOSNR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkPOSNR) 'adding the column to table

            Dim WorkTKNUM As DataColumn = New DataColumn("TKNUM") 'declaring a column named Name
            WorkTKNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkTKNUM) 'adding the column to table

            Dim WorkNUM_CONS_VBELV As DataColumn = New DataColumn("NUM_CONS_VBELV") 'declaring a column named Name
            WorkNUM_CONS_VBELV.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkNUM_CONS_VBELV) 'adding the column to table

            Dim WorkPOS_CONS_POSNV As DataColumn = New DataColumn("POS_CONS_POSNV") 'declaring a column named Name
            WorkPOS_CONS_POSNV.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkPOS_CONS_POSNV) 'adding the column to table

            Dim WorkZWMS_STOP_SEQ As DataColumn = New DataColumn("ZWMS_STOP_SEQ") 'declaring a column named Name
            WorkZWMS_STOP_SEQ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZWMS_STOP_SEQ) 'adding the column to table

            Dim WorkZWMS_DROP_SEQ As DataColumn = New DataColumn("ZWMS_DROP_SEQ") 'declaring a column named Name
            WorkZWMS_DROP_SEQ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZWMS_DROP_SEQ) 'adding the column to table

            Dim WorkEBELN As DataColumn = New DataColumn("EBELN") 'declaring a column named Name
            WorkEBELN.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkEBELN) 'adding the column to table

            Dim WorkEBELP As DataColumn = New DataColumn("EBELP") 'declaring a column named Name
            WorkEBELP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkEBELP) 'adding the column to table

            Dim WorkKUNNR_AG As DataColumn = New DataColumn("KUNNR_AG") 'declaring a column named Name
            WorkKUNNR_AG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkKUNNR_AG) 'adding the column to table

            Dim WorkNAME_AG As DataColumn = New DataColumn("NAME_AG") 'declaring a column named Name
            WorkNAME_AG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkNAME_AG) 'adding the column to table

            Dim WorkKUNNR_WE As DataColumn = New DataColumn("KUNNR_WE") 'declaring a column named Name
            WorkKUNNR_WE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkKUNNR_WE) 'adding the column to table

            Dim WorkNAME_WE As DataColumn = New DataColumn("NAME_WE") 'declaring a column named Name
            WorkNAME_WE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkNAME_WE) 'adding the column to table

            Dim WorkKUNNR_RG As DataColumn = New DataColumn("KUNNR_RG") 'declaring a column named Name
            WorkKUNNR_RG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkKUNNR_RG) 'adding the column to table

            Dim WorkNAME_RG As DataColumn = New DataColumn("NAME_RG") 'declaring a column named Name
            WorkNAME_RG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkNAME_RG) 'adding the column to table

            Dim WorkZZCDLEGACY As DataColumn = New DataColumn("ZZCDLEGACY") 'declaring a column named Name
            WorkZZCDLEGACY.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZZCDLEGACY) 'adding the column to table

            Dim WorkZWMS_SKU_PALLET As DataColumn = New DataColumn("ZWMS_SKU_PALLET") 'declaring a column named Name
            WorkZWMS_SKU_PALLET.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZWMS_SKU_PALLET) 'adding the column to table

            Dim WorkMJAHR As DataColumn = New DataColumn("MJAHR") 'declaring a column named Name
            WorkMJAHR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkMJAHR) 'adding the column to table

            Dim WorkMBLNR As DataColumn = New DataColumn("MBLNR") 'declaring a column named Name
            WorkMBLNR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkMBLNR) 'adding the column to table

            Dim WorkZEILE As DataColumn = New DataColumn("ZEILE") 'declaring a column named Name
            WorkZEILE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZEILE) 'adding the column to table

            Dim WorkID_JOBS_TYPE As DataColumn = New DataColumn("ID_JOBS_TYPE") 'declaring a column named Name
            WorkID_JOBS_TYPE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkID_JOBS_TYPE) 'adding the column to table

            Dim WorkDESCR_JOBS_TYPE As DataColumn = New DataColumn("DESCR_JOBS_TYPE") 'declaring a column named Name
            WorkDESCR_JOBS_TYPE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkDESCR_JOBS_TYPE) 'adding the column to table

            Dim WorkJOBS_TYPE_KZEAR As DataColumn = New DataColumn("JOBS_TYPE_KZEAR") 'declaring a column named Name
            WorkJOBS_TYPE_KZEAR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkJOBS_TYPE_KZEAR) 'adding the column to table

            Dim WorkPRIORITA As DataColumn = New DataColumn("PRIORITA") 'declaring a column named Name
            WorkPRIORITA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkPRIORITA) 'adding the column to table

            Dim WorkURGENTE As DataColumn = New DataColumn("URGENTE") 'declaring a column named Name
            WorkURGENTE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkURGENTE) 'adding the column to table

            Dim WorkZFLAWM As DataColumn = New DataColumn("ZFLAWM") 'declaring a column named Name
            WorkZFLAWM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZFLAWM) 'adding the column to table

            Dim WorkPALLET_INTERI As DataColumn = New DataColumn("PALLET_INTERI") 'declaring a column named Name
            WorkPALLET_INTERI.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkPALLET_INTERI) 'adding the column to table

            Dim WorkSCATOLE_INTERE As DataColumn = New DataColumn("SCATOLE_INTERE") 'declaring a column named Name
            WorkSCATOLE_INTERE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkSCATOLE_INTERE) 'adding the column to table

            Dim WorkZTIPO_ENTMERCE As DataColumn = New DataColumn("ZTIPO_ENTMERCE") 'declaring a column named Name
            WorkZTIPO_ENTMERCE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZTIPO_ENTMERCE) 'adding the column to table

            Dim WorkZFORCEDDEST As DataColumn = New DataColumn("ZFORCEDDEST") 'declaring a column named Name
            WorkZFORCEDDEST.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZFORCEDDEST) 'adding the column to table

            Dim WorkZFORCSPUNTACONF As DataColumn = New DataColumn("ZFORCSPUNTACONF") 'declaring a column named Name
            WorkZFORCSPUNTACONF.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZFORCSPUNTACONF) 'adding the column to table

            Dim WorkCHARG_TASSATIVA As DataColumn = New DataColumn("CHARG_TASSATIVA") 'declaring a column named Name
            WorkCHARG_TASSATIVA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkCHARG_TASSATIVA) 'adding the column to table

            Dim WorkLGNUM_STAG_DOOR As DataColumn = New DataColumn("LGNUM_STAG_DOOR") 'declaring a column named Name
            WorkLGNUM_STAG_DOOR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGNUM_STAG_DOOR) 'adding the column to table

            Dim WorkLGTYP_STAG_DOOR As DataColumn = New DataColumn("LGTYP_STAG_DOOR") 'declaring a column named Name
            WorkLGTYP_STAG_DOOR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGTYP_STAG_DOOR) 'adding the column to table

            Dim WorkLGPLA_STAG_DOOR As DataColumn = New DataColumn("LGPLA_STAG_DOOR") 'declaring a column named Name
            WorkLGPLA_STAG_DOOR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGPLA_STAG_DOOR) 'adding the column to table

            Dim WorkLGNUM_DOOCK_DOOR As DataColumn = New DataColumn("LGNUM_DOOCK_DOOR") 'declaring a column named Name
            WorkLGNUM_DOOCK_DOOR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGNUM_DOOCK_DOOR) 'adding the column to table

            Dim WorkLGTYP_DOOCK_DOOR As DataColumn = New DataColumn("LGTYP_DOOCK_DOOR") 'declaring a column named Name
            WorkLGTYP_DOOCK_DOOR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGTYP_DOOCK_DOOR) 'adding the column to table

            Dim WorkLGPLA_DOOCK_DOOR As DataColumn = New DataColumn("LGPLA_DOOCK_DOOR") 'declaring a column named Name
            WorkLGPLA_DOOCK_DOOR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGPLA_DOOCK_DOOR) 'adding the column to table

            Dim WorkZCARR_PROP As DataColumn = New DataColumn("ZCARR_PROP") 'declaring a column named Name
            WorkZCARR_PROP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZCARR_PROP) 'adding the column to table

            Dim WorkZCARR_EXEC As DataColumn = New DataColumn("ZCARR_EXEC") 'declaring a column named Name
            WorkZCARR_EXEC.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZCARR_EXEC) 'adding the column to table



            Dim WorkZCARR_EXEC_FL As DataColumn = New DataColumn("ZCARR_EXEC_FL") 'declaring a column named Name
            WorkZCARR_EXEC_FL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZCARR_EXEC_FL) 'adding the column to table

            Dim WorkZCARR_EXEC_SF As DataColumn = New DataColumn("ZCARR_EXEC_SF") 'declaring a column named Name
            WorkZCARR_EXEC_SF.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZCARR_EXEC_SF) 'adding the column to table



            Dim WorkZDOC As DataColumn = New DataColumn("ZDOC") 'declaring a column named Name
            WorkZDOC.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZDOC) 'adding the column to table

            Dim WorkFORNITORE_LIFNR As DataColumn = New DataColumn("FORNITORE_LIFNR") 'declaring a column named Name
            WorkFORNITORE_LIFNR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkFORNITORE_LIFNR) 'adding the column to table

            Dim WorkMEMO As DataColumn = New DataColumn("MEMO") 'declaring a column named Name
            WorkMEMO.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkMEMO) 'adding the column to table

            Dim WorkZZ_NDIS As DataColumn = New DataColumn("ZZ_NDIS") 'declaring a column named Name
            WorkZZ_NDIS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZZ_NDIS) 'adding the column to table

            Dim WorkINFO_PRELIEVO As DataColumn = New DataColumn("INFO_PRELIEVO") 'declaring a column named Name
            WorkINFO_PRELIEVO.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkINFO_PRELIEVO) 'adding the column to table


            '>>> GESTIONE ERRORE CODA
            Dim WorkZWMS_ERROR_CODE As DataColumn = New DataColumn("ZWMS_ERROR_CODE") 'declaring a column named Name
            WorkZWMS_ERROR_CODE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZWMS_ERROR_CODE) 'adding the column to table

            Dim WorkZWMS_ROW_STA_DES As DataColumn = New DataColumn("ZWMS_ROW_STA_DES") 'declaring a column named Name
            WorkZWMS_ROW_STA_DES.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZWMS_ROW_STA_DES) 'adding the column to table


            '>>> GESTIONE VARIANTE IMBALLO
            Dim WorkIMBALLO As DataColumn = New DataColumn("IMBALLO") 'declaring a column named Name
            WorkIMBALLO.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkIMBALLO) 'adding the column to table

            Dim WorkPZ_X_SC As DataColumn = New DataColumn("PZ_X_SC") 'declaring a column named Name
            WorkPZ_X_SC.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkPZ_X_SC) 'adding the column to table

            Dim WorkSC_X_PAL As DataColumn = New DataColumn("SC_X_PAL") 'declaring a column named Name
            WorkSC_X_PAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkSC_X_PAL) 'adding the column to table

            Dim WorkM2_X_PAL As DataColumn = New DataColumn("M2_X_PAL") 'declaring a column named Name
            WorkM2_X_PAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkM2_X_PAL) 'adding the column to table


            '
            'TEST COLONNA QTA' PER UTENTE SCORPORATE...non esiste come parametro di ritorno dalla rfc...ma è valorizzata manualmente
            '
            Dim WorkZPICK_QUEUE_USER As DataColumn = New DataColumn("ZPICK_QUEUE_USER") 'declaring a column named Name
            WorkZPICK_QUEUE_USER.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZPICK_QUEUE_USER) 'adding the column to table


            Dim WorkZWMS_PESO_PAL_US As DataColumn = New DataColumn("ZWMS_PESO_PAL_US") 'declaring a column named Name
            WorkZWMS_PESO_PAL_US.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZWMS_PESO_PAL_US) 'adding the column to table


            CreateDateTableForWmsJobs = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForWmsJobs = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Public Shared Function CreateDateTableForLockStock(ByRef outDataTable As DataTable) As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia le informazioni delle GIACENZE
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForLockStock = 1 'init at error


            Dim WorkZQTA_LOCSTOCK_BASE As DataColumn = New DataColumn("ZQTA_LOCSTOCK_BASE") 'declaring a column named Name
            WorkZQTA_LOCSTOCK_BASE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_LOCSTOCK_BASE) 'adding the column to table

            Dim WorkZQTA_LOCSTOCK_CONS As DataColumn = New DataColumn("ZQTA_LOCSTOCK_CONS") 'declaring a column named Name
            WorkZQTA_LOCSTOCK_CONS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_LOCSTOCK_CONS) 'adding the column to table

            Dim WorkZQTA_LOCSTOCK_PZ As DataColumn = New DataColumn("ZQTA_LOCSTOCK_PZ") 'declaring a column named Name
            WorkZQTA_LOCSTOCK_PZ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_LOCSTOCK_PZ) 'adding the column to table

            Dim WorkZQTA_LOCSTOCK_SC As DataColumn = New DataColumn("ZQTA_LOCSTOCK_SC") 'declaring a column named Name
            WorkZQTA_LOCSTOCK_SC.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_LOCSTOCK_SC) 'adding the column to table

            Dim WorkZQTA_LOCSTOCK_PAL As DataColumn = New DataColumn("ZQTA_LOCSTOCK_PAL") 'declaring a column named Name
            WorkZQTA_LOCSTOCK_PAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_LOCSTOCK_PAL) 'adding the column to table

            Dim WorkZQTA_LOCSTOCK_FULL As DataColumn = New DataColumn("ZQTA_LOCSTOCK_FULL") 'declaring a column named Name
            WorkZQTA_LOCSTOCK_FULL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_LOCSTOCK_FULL) 'adding the column to table

            Dim WorkZQTA_LOCSTOCK_PARTIA As DataColumn = New DataColumn("ZQTA_LOCSTOCK_PARTIA") 'declaring a column named Name
            WorkZQTA_LOCSTOCK_PARTIA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_LOCSTOCK_PARTIA) 'adding the column to table

            Dim WorkZQTA_LOCSTOCK_SF As DataColumn = New DataColumn("ZQTA_LOCSTOCK_SF") 'declaring a column named Name
            WorkZQTA_LOCSTOCK_SF.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_LOCSTOCK_SF) 'adding the column to table


            CreateDateTableForLockStock = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForLockStock = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Public Shared Function CreateDateTableForUbicazioni(ByRef outDataTable As DataTable) As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia le informazioni delle GIACENZE
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForUbicazioni = 1 'init at error


            Dim WorkWERKS As DataColumn = New DataColumn("WERKS") 'declaring a column named Name
            WorkWERKS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkWERKS) 'adding the column to table

            Dim WorkLGNUM As DataColumn = New DataColumn("LGNUM") 'declaring a column named Name
            WorkLGNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGNUM) 'adding the column to table

            Dim WorkLGTYP As DataColumn = New DataColumn("LGTYP") 'declaring a column named Name
            WorkLGTYP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGTYP) 'adding the column to table

            Dim WorkLGPLA As DataColumn = New DataColumn("LGPLA") 'declaring a column named Name
            WorkLGPLA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLGPLA) 'adding the column to table


            Dim WorkKZLER As DataColumn = New DataColumn("KZLER") 'declaring a column named Name
            WorkKZLER.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkKZLER) 'adding the column to table

            Dim WorkKZVOL As DataColumn = New DataColumn("KZVOL") 'declaring a column named Name
            WorkKZVOL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkKZVOL) 'adding the column to table

            Dim WorkUBI_PIENA As DataColumn = New DataColumn("UBI_PIENA") 'declaring a column named Name
            WorkUBI_PIENA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkUBI_PIENA) 'adding the column to table

            Dim WorkLKAPV As DataColumn = New DataColumn("LKAPV") 'declaring a column named Name
            WorkLKAPV.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkLKAPV) 'adding the column to table


            Dim WorkZWMS_UOM_CAP As DataColumn = New DataColumn("ZWMS_UOM_CAP") 'declaring a column named Name
            WorkZWMS_UOM_CAP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZWMS_UOM_CAP) 'adding the column to table


            Dim WorkZQTA_LGPLA As DataColumn = New DataColumn("ZQTA_LGPLA") 'declaring a column named Name
            WorkZQTA_LGPLA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            outDataTable.Columns.Add(WorkZQTA_LGPLA) 'adding the column to table


            CreateDateTableForUbicazioni = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForUbicazioni = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


End Class
