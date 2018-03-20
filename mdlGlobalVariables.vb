Imports System.Data
Imports clsDataType
Imports clsSapWS


Module mdlGlobalVariables


    'CODICE PER INTERCETTARE PRESSIONE TASTI
    Public hook As New clsHookKeys

    '**********************************************************************
    '********************* FLAG PER DEBUG *********************************
    '**********************************************************************
    Public SkipLogin As Boolean = False

    '**********************************************************************
    '********************* CREDENZIALI PER WEB SERVICES *******************
    '**********************************************************************
    Public objNetworkCredential As New System.Net.NetworkCredential
    Public UserRfcWs As String = ""
    Public PswUserRfcWs As String = ""
    Public WorkStationName As String = ""

    Public WmPsw As String = "WMRF"                                             ' GESTIONE APERTURA FOLDER APPLICAZIONE

    '**********************************************************************************
    '********************* VARIABILI PER ABILITAZIONE FUNZIONI MENU *******************
    '**********************************************************************************
    Public MenuEnableInvenCostCentreConsume As Boolean = False
    Public MenuEnableBloccoGiacenza As Boolean = False
    Public EntrataMerceAbilitaSceltaUbicazioneLavoro As Boolean = True          '??? GESTIRE COME PARAMETRO
    Public EntrataMerceAbilitaSpuntaTerminaJob As Boolean = False               '??? GESTIRE COME PARAMETRO
    Public EntrataMerceAbilitaMsgConfermaSuccesso As Boolean = False            '??? GESTIRE COME PARAMETRO
    Public EntrataMerceAbilitaDigitazioneResiduo As Boolean = True              '??? GESTIRE COME PARAMETRO
    Public EntrataMerceAbilitaListaElencoMissioni As Boolean = True             '??? GESTIRE COME PARAMETRO

    Public CodiceUbicazioneAbilitaReverse As Boolean = True                     '??? GESTIRE COME PARAMETRO

    Public BloccoMovAbilitaMsgConfermaSuccesso As Boolean = False            '??? GESTIRE COME PARAMETRO


    Public RangeInternoUnitaMagazzinoStart As Long = 9000000000
    Public RangeInternoUnitaMagazzinoEnd As Long = 9999999999

    '**********************************************************************
    '********************* VARIABILI PER GESIONE COLONNE DATA GRID ********
    '**********************************************************************
    Public DefDtGridCol_ShowNumeroMagazzino As Boolean = False


    Public DefDtGridCol_GridExecuted As Long = 24
    Public DefDtGridCol_NumeroMissione As Long = 130
    Public DefDtGridCol_NumGruppoMissioni As Long = 130
    Public DefDtGridCol_NumGruppoExecMissioni As Long = 130
    Public DefDtGridCol_DescrGruppoMissioni As Long = 250
    Public DefDtGridCol_NumOrdinePicking As Long = 130
    Public DefDtGridCol_PosNumOrdinePicking As Long = 90
    Public DefDtGridCol_NumRigheMissioni As Long = 90
    Public DefDtGridCol_NumTotScatoleGruppoMissioni As Long = 90
    Public DefDtGridCol_NumTotM2GruppoMissioni As Long = 90
    Public DefDtGridCol_NumTotPezziGruppoMissioni As Long = 90
    Public DefDtGridCol_NumTotAltriGruppoMissioni As Long = 90

    Public DefDtGridCol_CodiceMateriale As Long = 110
    Public DefDtGridCol_DescrMateriale As Long = 260
    Public DefDtGridCol_SKU As Long = 90
    Public DefDtGridCol_CodiceMaterialeLegacy As Long = 110
    Public DefDtGridCol_CodiceCommessa As Long = 60
    Public DefDtGridCol_FlagUDS As Long = 20
    Public DefDtGridCol_Divisione As Long = 40
    Public DefDtGridCol_NumeroMagazzino As Long = 30
    Public DefDtGridCol_TipoMagazzino As Long = 38
    Public DefDtGridCol_Ubicazione As Long = 110
    Public DefDtGridCol_Quant As Long = 50
    Public DefDtGridCol_PartitaMateriale As Long = 130
    Public DefDtGridCol_NumeroUDS As Long = 30


#If Not APPLICAZIONE_WIN32 = "SI" Then
    Public DefDtGridCol_UnitaMagazzino As Long = 140
    Public DefDtGridCol_UnitaDiMisura As Long = 60
    Public DefDtGridCol_QtaTotale As Long = 90
    Public DefDtGridCol_QtaDisponibile As Long = 90
#Else
    Public DefDtGridCol_UnitaMagazzino As Long = 180
    Public DefDtGridCol_UnitaDiMisura As Long = 120
    Public DefDtGridCol_QtaTotale As Long = 140
    Public DefDtGridCol_QtaDisponibile As Long = 140
#End If

    Public DefDtGridCol_QtaDaPrelevare As Long = 130
    Public DefDtGridCol_QtaPrelevata As Long = 130
    Public DefDtGridCol_TipoStock As Long = 90
    Public DefDtGridCol_CdStockSpeciale As Long = 90
    Public DefDtGridCol_NumeroStockSpeciale As Long = 160
    Public DefDtGridCol_NumeroDocMat As Long = 40
    Public DefDtGridCol_AnnoDocMat As Long = 40
    Public DefDtGridCol_PosDocMat As Long = 60
    Public DefDtGridCol_MagazzinoLogico As Long = 50
    Public DefDtGridCol_DescrSatoMissione As Long = 110

#If Not APPLICAZIONE_WIN32 = "SI" Then
    Public DefDtGridCol_CarrelistaProposto As Long = 150
    Public DefDtGridCol_CarrelistaEsecuzione As Long = 150
#Else
    Public DefDtGridCol_CarrelistaProposto As Long = 100
    Public DefDtGridCol_CarrelistaEsecuzione As Long = 100
#End If

    Public DefDtGridCol_Sequenza As Long = 90
    Public DefDtGridCol_Urgente As Long = 90
    Public DefDtGridCol_Priorita As Long = 120

#If Not APPLICAZIONE_WIN32 = "SI" Then
    Public DefDtGridCol_ZID_WMS_FORKLIFT As Long = 40
    Public DefDtGridCol_ZDESCR_WMS_FORKLIFT As Long = 80
#Else
    Public DefDtGridCol_ZID_WMS_FORKLIFT As Long = 100
    Public DefDtGridCol_ZDESCR_WMS_FORKLIFT As Long = 200
#End If

    Public DefDtGridCol_ZFORKLIFT_MAX_PESO As Long = 80
    Public DefDtGridCol_GEWEI As Long = 40


#If Not APPLICAZIONE_WIN32 <> "SI" Then
    Public DefDtGridCol_Show_ZOPEN_ST_KG As Boolean = False
    Public DefDtGridCol_Show_ZOPEN_ST_LB As Boolean = True
    Public DefDtGridCol_Show_ZPICKED_ST_KG As Boolean = False
    Public DefDtGridCol_Show_ZPICKED_ST_LB As Boolean = True
    Public DefDtGridCol_Show_ZSTAGED_ST_KG As Boolean = False
    Public DefDtGridCol_Show_ZSTAGED_ST_LB As Boolean = True
    Public DefDtGridCol_Show_ZLOADED_ST_KG As Boolean = False
    Public DefDtGridCol_Show_ZLOADED_ST_LB As Boolean = True
    Public DefDtGridCol_Show_ZTOTAL_WMS_KG As Boolean = False
    Public DefDtGridCol_Show_ZOPEN_ST_PER As Boolean = False
    Public DefDtGridCol_Show_ZPICKED_ST_PER As Boolean = False
    Public DefDtGridCol_Show_ZSTAGED_ST_PER As Boolean = False
    Public DefDtGridCol_Show_ZLOADED_ST_PER As Boolean = False
#End If



    '**********************************************************************
    '********************* VARIABILI **************************************
    '**********************************************************************
    'TEMPI DI SLEEP DEI DIVERSI THREAD
    Public SleepTimeApplication As Long 'Tempo di SLEEP in MILLISECONDI per THREAD MAIN

    Public AppMsgBoxTitle As String 'stringa usata per il titolo delle message box
    Public ApplMainFormTitle As String 'stringa usata per il titolo della finestra di main
    Public NumRecordMaxListaGriglia As Long
    Public BemOdaEnableCreaUbicazionePerProd As Boolean 'abilita o meno creazione automatica ubicazioni per produzione
    Public BemEnableConfirmQtyGreater As Boolean = False '>>> abilita conteggio di una qta maggiore nella BEM
    Public BemEnableConfirmQtySmaller As Boolean = True '>>> abilita conteggio di una qta minore nella BEM
    Public BemEnableOTRettificaPositiva As Boolean = False '>>> abilita conteggio di una qta maggiore nella BEM
    Public BemEnableOTRettificaNegativa As Boolean = False '>>> abilita conteggio di una qta minore nella BEM


    Public TrasfMatEnableWarningChangeQty As Boolean = False

    Public EnableCheckProdError As Boolean = True  'abilita o meno il Controllo dati Produzione e Anagrafica Materiale ( nella GET_LENUM... )
    Public EnableFormResizeControls As Boolean = False 'abilita o meno il resize delle form e dei controlli (usato quanto l'applicazione gira sui veicolari)
    Public EnableFormResizeDiagnostic As Boolean = False
    Public LastStartUpDate As DateTime
    Public MinNumCaratteriPerHelpUbicazione As Long = 3
    Public DefaultStartupLanguage As String = "EN"

    Public SYSTEMNUMBER_DEV As String = "40"
    Public SYSTEMNUMBER_PRD As String = "00"
    Public SYSTEMNUMBER_TST As String = "20"
    Public SYSTEMID_DEV As String = "ECD"
    Public SYSTEMID_TST As String = "ECQ"
    Public SYSTEMID_PRD As String = "ECP"
    Public POOLSIZE As Integer = 5
    Public MAXPOOLSIZE As Integer = 10
    Public IDLETIMEOUT As Integer = 600

    Public WM_PRN_PLID_GOOD_RECEIPT As String = "ZU02"
    Public WM_PRN_PLID_SHIPPING As String = "ZU04"


    '>>> VARIABILI PER GESTIONE AGGIORNAMENTO APPLICAZIONE
    Public ApplicationAbsoluteFileNameUpdate As String = "WM_MobileGRESMALT_tmp.exe"


#If Not APPLICAZIONE_WIN32 = "SI" Then
    Public DesignerWidth As Integer = 480
    Public DesignerHeight As Integer = 600
    Public PrimaryScreenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
    Public PrimaryScreenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
#Else
    Public DesignerWidth As Integer = 320 '480
    Public DesignerHeight As Integer = 240 '600
    Public PrimaryScreenWidth As Integer = 1024 'Screen.PrimaryScreen.Bounds.Width
    Public PrimaryScreenHeight As Integer = 768 'Screen.PrimaryScreen.Bounds.Height
#End If


    Public PrimaryScreenDpiX As Single = 0
    Public PrimaryScreenDpiY As Single = 0

    Public WsHostName As String
    Public WsPortNumber As String
    Public SapClient As String

    Public SapSystemInfo As New StructGenericSapTableSyst
    Public AddPezzoUMEnableQuestionMovStockE As Boolean = False

    '>>>> VALORI DI DEFAULT PER LA LOGICA BUSINESS
    Public DataLimitePerGestioneOdPVecchi As Date = DateTime.ParseExact("18-06-2012", "dd-MM-yyyy", Nothing)
    Public DefaultUbicazGestioneVecchiOdP As String = "914-PRO"

    Public DefaultSapUserLanguage As String = "I" '>>> DI DEFAULT USO LA LINGUA ITALIANA
    Public DefaultEnablePartita As Boolean = true
    Public DefaultEnableShowQtyInUdmCons As Boolean = True
    Public DefaultEnableShowPickingOperator As Boolean = False
    Public Default_TipoUnitaMagazzino As String = "PP"

    Public DefaultLunghezzaCodiceUM As Long = 10
    Public DefaultLunghezzaCodiceUMInterna As Long = 20
    Public DefaultLunghezzaCodiceStockEInterna As Long = 16
    Public DefaultLunghezzaCodiceStockERidotta As Long = 11

    Public DefaultTipoMagStaging As String = "Z01"
    Public DefaultTipoMagDockDoor As String = "ZDD"


    Public DefaultTipoMagRegModStockE As String = ""
    Public DefaultUbicazRegModStockE As String = ""


    Public DefaultSapSISID_Produzione As String = "ECP"
    Public DefaultSapSISID_Quality As String = "ECQ"
    Public DefaultSapSISID_Sviluppo As String = "ECD"

    Public DefaultTipoMagInvRettifica As String = "999"
    Public DefaultTipoMagInvRottamazione As String = "999"
    Public DefaultTipoMagInvStornoRottama As String = "999"
    Public DefaultUbicazioneInvRettifica As String = "INVENTORY"
    Public DefaultUbicazioneInvRottamazione As String = "SCRAP"     '"SCHROTT"

    Public DefaultTipoMagAreaProduzione As String = "100"

    Public DefaultInfoTipiMag_NumMag As String = ""
    Public DefaultInfoTipiMag_TipoMag As String = "*"

    Public DefaultInfoMappaUbicazioni_NumMag As String = ""
    Public DefaultInfoMappaUbicazioni_TipoMag As String = "*"
    Public DefaultInfoMappaUbicazioni_Ubicazione As String = "*"

    Public DefaultSelectUbicazioni_TipoMag As String = "*"


    Public DefaultBloccoMovMM_TipoMag As String = "*"

    Public Default_PickingMerci_SourceTypeEnableUbiWithUM As Boolean = True
    Public Default_PickingMerci_DestinationTypeEnableUbiWithUM As Boolean = True
    Public Default_PickingMerci_SourceTypeEnableManEnter As Boolean = False
    Public Default_PickingMerci_Ubicazione_Scaffale As String = "SCAFFALE"


    Public Default_TRASF_EnableConfCodMat As Boolean = False
    Public Default_TRASF_UM_EnableRegistrazioneDiretta As Boolean = True

    Public Default_TRASF_UM_TipoMovNoFt As String = "999"
    Public Default_TRASF_UM_Ori_TipoMag As String = ""
    Public Default_TRASF_UM_Ori_Ubicazione As String = ""

    Public DefaultEM_List_DtGridCol_ShowQtaGesme As Boolean = False
    Public DefaultEM_List_TipoMovimentoPerOT As String = "999"
    Public DefaultEM_List_FtTypePerOT As String = ""
    Public DefaultEM_List_MaxNumRowReturned As String = "120"
    Public DefaultEM_List_EnableFilterLgtyp_Z0S As Boolean = True
    Public DefaultEM_List_EnableFilterLgtyp_901 As Boolean = True
    Public DefaultEM_List_EnableFilterLgtyp_902 As Boolean = True
    Public DefaultEM_List_EnableFilterLgtyp_903 As Boolean = True
    Public DefaultEM_List_EnableFilterLgtyp_904 As Boolean = True
    Public DefaultEM_List_EnableFilterLgtyp_905 As Boolean = True
    Public DefaultEM_List_EnableFilterLgtyp_910 As Boolean = True
    Public DefaultEM_List_EnableFilterLgtyp_921 As Boolean = True


    Public DefaultEM_BEM_TipoMovimentoNoFt As String = "999"
    Public DefaultEM_BEM_TipoMovimentoNoFtToProd As String = "907"
    Public DefaultEM_BEM_TipoMovimentoWithFt As String = "101"
    Public DefaultEM_BEM_FtType As String = "B"
    Public DefaultEM_BEM_TipoMovimentoWithFtToProd As String = "101"
    Public DefaultEM_BEM_FtTypeToProd As String = "B"
    Public DefaultEM_BEM_MovMettiInStockE As String = "412"
    Public DefaultEM_BEM_TipoMagInventario As String = "999"
    Public DefaultEM_BEM_UbicazioneInventario As String = "INVENTARIO"


    Public Default_PickingComp_TipoMag As String = "100"
    Public Default_PickingComp_Ubicazione As String = "PRODUZIONE"


    Public DefaultEM_Prod_Ori_TipoMag As String = "901"
    Public DefaultEM_Prod_Ori_Ubicazione As String = ""
    Public DefaultEM_Prod_MovMettiInStockE As String = "412"



    Public DefaultMovimento_BloccoMovMM_TipoMov_AddStockQ As String = "322"
    Public DefaultMovimento_BloccoMovMM_TipoMov_RemoveStockQ As String = "321"
    Public DefaultMovimento_BloccoMovMM_TipoMov_AddStockS As String = "344"
    Public DefaultMovimento_BloccoMovMM_TipoMov_RemoveStockS As String = "343"
    Public DefaultMovimento_BloccoMovMM_TipoMov_AddStockR As String = "" '>>> NON POSSIBILE
    Public DefaultMovimento_BloccoMovMM_TipoMov_RemoveStockR As String = "453"


    Public DefaultMovimento_StockE_TipoMov_AddStockE As String = "412"
    Public DefaultMovimento_StockE_TipoMov_RemoveStockE As String = "411"
    Public DefaultMovimento_StockE_TipoMov_TransferStockE As String = "413"
    Public DefaultMovimento_StockE_TipoMov_AddStockECustom As String = "998"
    Public DefaultMovimento_StockE_TipoMov_RemoveStockECustom As String = "997"
    Public DefaultMovimento_StockE_TipoMov_TransferStockECustom As String = ""


    Public DefaultEM_Prod_DestContoLavoro_Divisione As String = ""
    Public DefaultEM_Prod_DestContoLavoro_NumMag As String = ""
    Public DefaultEM_Prod_DestContoLavoro_TipoMag As String = "910"
    Public DefaultEM_Prod_DestContoLavoro_Ubicazione As String = "910-CTL"
    Public DefaultEM_Prod_DestContoLavoro_TipoMovNoFt As String = "999"


    Public DefaultEM_Prod_DestMagazzino_Divisione As String = ""
    Public DefaultEM_Prod_DestMagazzino_NumMag As String = ""
    Public DefaultEM_Prod_DestMagazzino_TipoMag As String = ""
    Public DefaultEM_Prod_DestMagazzino_Ubicazione As String = ""
    Public DefaultEM_Prod_DestMagazzino_TipoMovNoFt As String = "999"


    Public DefaultEM_Prod_DestOdp_Divisione As String = ""
    Public DefaultEM_Prod_DestOdp_NumMag As String = ""
    Public DefaultEM_Prod_DestOdp_TipoMag As String = "100"
    Public DefaultEM_Prod_DestOdp_Ubicazione As String = ""
    Public DefaultEM_Prod_DestOdp_TipoUM As String = ""
    Public DefaultEM_Prod_DestOdp_TipoMovNoFt As String = "999"  '>>> "907"


    Public Default_UM_Add_Pezzo_EnableConfCodMat As Boolean = False
    Public DefaultUM_Add_Pezzo_Ori_Divisione As String = ""
    Public DefaultUM_Add_Pezzo_Ori_NumMag As String = ""
    Public DefaultUM_Add_Pezzo_Ori_TipoMag As String = "*"
    Public DefaultUM_Add_Pezzo_Ori_Ubicazione As String = ""

    Public DefaultUM_Add_Pezzo_Dest_Divisione As String = ""
    Public DefaultUM_Add_Pezzo_Dest_NumMag As String = ""
    Public DefaultUM_Add_Pezzo_Dest_TipoMag As String = ""
    Public DefaultUM_Add_Pezzo_Dest_Ubicazione As String = ""
    Public DefaultUM_Add_Pezzo_Dest_TipoUM As String = "PP"

    Public DefaultUM_Delete_Pezzo_Ori_Divisione As String = ""
    Public DefaultUM_Delete_Pezzo_Ori_NumMag As String = ""
    Public DefaultUM_Delete_Pezzo_Ori_TipoMag As String = "*"
    Public DefaultUM_Delete_Pezzo_Ori_Ubicazione As String = ""
    Public DefaultUM_Delete_Pezzo_Ori_UnitaMagazzino As String = ""

    Public DefaultUM_Delete_Pezzo_Dest_Divisione As String = ""
    Public DefaultUM_Delete_Pezzo_Dest_NumMag As String = ""
    Public DefaultUM_Delete_Pezzo_Dest_TipoMag As String = ""
    Public DefaultUM_Delete_Pezzo_Dest_Ubicazione As String = ""
    Public DefaultUM_Delete_Pezzo_Dest_TipoUM As String = ""


    Public DefaultUscitaMerci_Odp_Ori_Divisione As String = ""
    Public DefaultUscitaMerci_Odp_Ori_NumMag As String = ""
    Public DefaultUscitaMerci_Odp_Ori_TipoMag As String = "*"
    Public DefaultUscitaMerci_Odp_Ori_Ubicazione As String = ""

    Public DefaultUscitaMerci_Odp_Dest_Divisione As String = ""
    Public DefaultUscitaMerci_Odp_Dest_NumMag As String = ""
    Public DefaultUscitaMerci_Odp_Dest_TipoMag As String = "100"
    Public DefaultUscitaMerci_Odp_Dest_Ubicazione As String = ""
    Public DefaultUscitaMerci_Odp_Dest_TipoUM As String = ""
    Public DefaultUscitaMerci_Odp_Dest_TipoMov As String = "907"


    Public DefaultDisacMerci_Enable_SelOriUbicazione As Boolean = False
    Public DefaultDisacMerci_Enable_SelUM_Origine As Boolean = False

    Public DefaultPickingMerci_Ori_Exclude_LgtypPronto As Boolean = True
    Public DefaultPickingMerci_Pronto_Dest_Divisione As String = ""
    Public DefaultPickingMerci_Pronto_Dest_NumMag As String = ""
    Public DefaultPickingMerci_Pronto_Dest_TipoMag As String = ""
    Public DefaultPickingMerci_Pronto_Dest_Ubicazione As String = ""
    Public DefaultPickingMerci_Pronto_Dest_TipoUM As String = ""
    Public DefaultPickingMerci_Pronto_Dest_TipoMovFt As String = "999"
    Public DefaultPickingMerci_Pronto_Dest_TipoMovNoFt As String = "999"
    Public DefaultPickingMerci_Pronto_Dest_GestFT As Boolean = False
    Public DefaultPickingMerci_Pronto_Dest_FtType As String = ""
    Public DefaultPickingMerci_Pronto_Dest_EnChangeTipoMag As Boolean = False
    Public DefaultPickingMerci_Pronto_Dest_EnChangeUbicaz As Boolean = False
    Public DefaultPickingMerci_EnableShowDestProposta As Boolean = True

    Public DefaultUscitaMerci_ContoLav_Dest_Divisione As String = ""
    Public DefaultUscitaMerci_ContoLav_Dest_NumMag As String = ""
    Public DefaultUscitaMerci_ContoLav_Dest_TipoMag As String = "910"
    Public DefaultUscitaMerci_ContoLav_Dest_Ubicazione As String = "910-CTL"
    Public DefaultUscitaMerci_ContoLav_Dest_TipoUM As String = ""
    Public DefaultUscitaMerci_ContoLav_Dest_TipoMovNoFt As String = "999"
    Public DefaultUscitaMerci_ContoLav_Dest_EnChangeTipoMag As Boolean = False
    Public DefaultUscitaMerci_ContoLav_Dest_EnChangeUbicaz As Boolean = False

    Public DefaultUscitaMerci_ContoVis_Dest_Divisione As String = ""
    Public DefaultUscitaMerci_ContoVis_Dest_NumMag As String = ""
    Public DefaultUscitaMerci_ContoVis_Dest_TipoMag As String = "921"
    Public DefaultUscitaMerci_ContoVis_Dest_Ubicazione As String = "921-VIS"
    Public DefaultUscitaMerci_ContoVis_Dest_TipoUM As String = ""
    Public DefaultUscitaMerci_ContoVis_Dest_TipoMovFt As String = "999"
    Public DefaultUscitaMerci_ContoVis_Dest_TipoMovNoFt As String = "999"
    Public DefaultUscitaMerci_ContoVis_Dest_GestFT As Boolean = False
    Public DefaultUscitaMerci_ContoVis_Dest_FtType As String = ""
    Public DefaultUscitaMerci_ContoVis_Dest_EnChangeTipoMag As Boolean = False
    Public DefaultUscitaMerci_ContoVis_Dest_EnChangeUbicaz As Boolean = False

    Public DefaultUscitaMerci_UMOdp_Ori_Divisione As String = ""
    Public DefaultUscitaMerci_UMOdp_Ori_NumMag As String = ""
    Public DefaultUscitaMerci_UMOdp_Ori_TipoMag As String = "*"
    Public DefaultUscitaMerci_UMOdp_Ori_Ubicazione As String = ""
    Public DefaultUscitaMerci_UMOdp_Ori_UnitaMagazzino As String = ""

    Public DefaultUscitaMerci_UMOdp_Dest_Divisione As String = ""
    Public DefaultUscitaMerci_UMOdp_Dest_NumMag As String = ""
    Public DefaultUscitaMerci_UMOdp_Dest_TipoMag As String = "100"
    Public DefaultUscitaMerci_UMOdp_Dest_Ubicazione As String = ""
    Public DefaultUscitaMerci_UMOdp_Dest_TipoUM As String = ""
    Public DefaultUscitaMerci_UMOdp_Dest_TipoMov As String = "907"


    Public DefaultUscitaMerci_UMOdp_Dest_TipoMov_Per_SU As String = "999"
    Public DefaultUscitaMerci_UMOdp_UnicoOT_Per_SU As Boolean = True

    Public Default_Inventario_EnableConfCodMat As Boolean = False
    Public Default_Inventario_EnableExecMovimentoLogico As Boolean = True
    Public Default_Inventario_EnableExecMotiviMovimentoLogico As Boolean = True
    'Public Default_Inventario_ParametroMB11CentroDiCosto As String = "CP02"

    Public Default_Inventario_Ori_Divisione As String = ""
    Public Default_Inventario_TipoMov_Rottamazione As String = "551"
    Public Default_Inventario_TipoMov_RettificaPositiva As String = "561"
    Public Default_Inventario_TipoMov_RettificaNegativa As String = "562"

    Public Default_EMFromStock_Max_NumPalletScan As Double = 4
    Public Default_TruckLoad_Max_NumPalletScan As Double = 4

    Public Default_Inventario_Ubi_Max_Qty_Change As Double = 6
    Public Default_Inventario_UbiUM_Max_Qty_Change As Double = 6
    Public Default_Inventario_Rottama_Max_Qty_Change As Double = 6
    Public Default_Inventario_CentroCosto_Max_Qty_Change As Double = 6

    Public Default_UDStoModify_Max_NumPalletScan As Double = 1


    Public DefaultUM_ConsegnaSourceCodeType As String = "2" '>>> 
    '>>> 1= specifico codice CONSEGNA
    '>>> 2= specifico codice ODP

    Public DefaultInfoGiacenze_Divisione As String = ""
    Public DefaultInfoGiacenze_NumMag As String = ""
    Public DefaultInfoGiacenze_TipoMag As String = "*"
    Public DefaultInfoGiacenze_Ubicazione As String = ""
    Public DefaultInfoGiacenze_CodMateriale As String = ""
    Public DefaultInfoGiacenze_UnitaMagazzino As String = ""

    Public DefaultInfoGiacenze_List_MaxNumRowReturned As String = "100"
    Public DefaultInfoCodMat_List_MaxNumRowReturned As String = "120"

    Public DefaultInfoDisponibilita_Divisione As String = ""

    Public DefaultSelectUbicazione_Ubicazione As String = "*"
    Public DefaultSelectTipoMag_TipoMag As String = "*"


    Public Default_PickingMerci_ChangeUDS_UNION As String = "UNION"
    Public Default_PickingMerci_ChangeUDS_ADD As String = "ADD"
    Public Default_PickingMerci_ChangeUDS_MINUS As String = "MINUS"


    '****************************************
    ' GESTIONE STATO CONNESSIONE A SAP
    Public SapConnectionString As String = ""
    Public SapConnectionStatus As clsDataType.SapConnectionStatusEnum = clsDataType.SapConnectionStatusEnum.SapConnectionStatusNone
    Public SapConnectionStatusLastCheckTime As String
    '****************************************

    Public FilterMsgDataGridOnlyTopRecord As Long 'Numero di messaggi visualizzati di default (a partire dall'ultimo)

    '****************************************
    ' VARIABILI VARIE ED ENUMERATE


    '*******************************************************
    '*******************************************************
    ' OGGETTI GLOBALI DELL'APPLICAZIONE
    Public objMainApplication As New clsMainApplication

    Public SqlApplicationLog As New clsFileGenericLog


    '****************************************************
    '****************************************************
    ' DICHIARAZIONE FORMS
    Public frmLoginForm As frmLogin

    '****************************************************
    '>>>> FORM INFORMAZIONI
    Public frmInfoUserForm As frmInfoUser
    Public frmInfoSystemForm As frmInfoSystem
    Public frmInfoTipiMag_1Form As frmInfoTipiMag_1
    Public frmInfoTipiMag_2Form As frmInfoTipiMag_2

    Public frmMenuStampaLabelForm As frmMenuStampaLabel


    Public frmInfoMappaUbicazioni_1Form As frmInfoMappaUbicazioni_1
    Public frmInfoMappaUbicazioni_2Form As frmInfoMappaUbicazioni_2


    Public frmInfoGiacenze_1Form As frmInfoGiacenze_1_Ubicazione
    Public frmInfoGiacenze_1_CodiceMaterialeForm As frmInfoGiacenze_1_CodiceMateriale
    Public frmInfoGiacenze_1_UMForm As frmInfoGiacenze_1_UM
    Public frmInfoGiacenze_2Form As frmInfoGiacenze_2
    Public frmInfoGiacenze_3_ListForm As frmInfoGiacenze_3_List

    Public frmInfoDatiGiacenzaForm As frmInfoDatiGiacenza
    Public frmInfoDatiSpedizioneForm As frmInfoDatiSpedizione

    Public frmInfoCodiceMateriale_1Form As frmInfoCodiceMateriale_1
    Public frmInfoCodiceMateriale_2_ListForm As frmInfoCodiceMateriale_2_List
    Public frmInfoCodiceMateriale_3_DetailsForm As frmInfoCodiceMateriale_3_Details

    Public frmInfoDisponibilitaMateriale_1Form As frmInfoDisponibilitaMateriale_1
    Public frmInfoDisponibilitaMateriale_2_ListForm As frmInfoDisponibilitaMateriale_2_List
    Public frmInfoDisponibilitaMateriale_3_DetailsForm As frmInfoDisponibilitaMateriale_3_Details

    Public frmInfoJobGroup_DetailsForm As frmInfoJobGroup_Details
    Public frmInfoJob_DetailsForm As frmInfoJob_Details

    '****************************************************
    '>>>> FORM SELEZIONE INFORMAZIONI (MATCH CODE)
    Public frmSelectUbicazioneForm As frmSelectUbicazione
    Public frmSelectUbicazioneSpuntaForm As frmSelectUbicazioneSpunta
    Public frmSelectUbicazioneDropUDSForm As frmSelectUbicazioneDropUDS
    Public frmSelectTipoMagazzinoForm As frmSelectTipoMagazzino
    Public frmSelectCodiceMaterialeForm As frmSelectCodiceMateriale
    Public frmSelectPartitaMaterialeForm As frmSelectPartitaMateriale

    Public frmMessageForUserForm As frmMessageForUser

    '>>>> FORM MENU'
    Public frmMainHomeMenuForm As frmMainHomeMenu
    Public frmMainHomeMenuWinForm As frmMainHomeMenuWin
    Public frmMenuTrasferMainForm As frmMenuTrasferMain
    Public frmMenuEntrataMerciForm As frmMenuEntrataMerci
    Public frmMenuUscitaMerciMainForm As frmMenuUscitaMerciMain
    Public frmMenuUscitaMerciMainWinForm As frmMenuUscitaMerciMainWin
    Public frmMenuUscitaMerciOdpForm As frmMenuUscitaMerciOdp
    Public frmMenuInformazioni_1Form As frmMenuInformazioni_1
    Public frmMenuInformazioni_2Form As frmMenuInformazioni_2
    Public frmMenuInventarioForm As frmMenuInventario
    Public frmMenuBloccoMerciForm As frmMenuBloccoMerci

    Public frmMenuUtilita_1Form As frmMenuUtilita_1
    Public frmMenuDisaccantonamentoForm As frmMenuDisaccantonamento
    Public frmInfoForkLiftForm As frmInfoForkLift
    Public frmSelectForkLiftForm As frmSelectForkLift
    Public frmSelectUserTipiMagForm As frmSelectUserTipiMag
    Public frmSelectUserPickQueuesForm As frmSelectUserPickQueues

    Public frmSelectUbicazioneSpecialForm As frmSelectUbicazioneSpecial

    Public frmPickingMerci_TaskLinesAssignedForm As frmPickingMerci_TaskLinesAssigned


    Public frmPrintLabelUdcForm As frmPrintLabelUdc
    Public frmPrintLabelUdsForm As frmPrintLabelUds
    Public frmPrintLabelKTagForm As frmPrintLabelKTag


    '>>>> FORM GESTIONE ENTRATA MERCI DA BEM
    Public frmEM_FromJob_Part_1_SelUbiSpuntaForm As frmEM_FromJob_Part_1_SelUbiSpunta
    Public frmEM_FromJob_Part_2_DocMatForm As frmEM_FromJob_Part_2_DocMat
    Public frmEM_FromJob_Part_2_CodMisForm As frmEM_FromJob_Part_2_CodMis
    Public frmEM_FromJob_Part_3_SelMisForm As frmEM_FromJob_Part_3_SelMis
    Public frmEM_FromJob_Part_4_ConfQtaForm As frmEM_FromJob_Part_4_ConfQta
    Public frmEM_FromJob_Part_5_FinalUMConfirmForm As frmEM_FromJob_Part_5_FinalUMConfirm
    Public frmEM_FromJob_Part_5_FinalUMUbiConfirmForm As frmEM_FromJob_Part_5_FinalUMUbiConfirm
    Public frmEM_FromJob_Part_5_FinalUbiConfirmForm As frmEM_FromJob_Part_5_FinalUbiConfirm
    Public frmEM_FromJob_Part_ChiudiListaForm As frmEM_FromJob_Part_ChiudiLista
    Public frmEM_FromJob_Part_ShowStockForm As frmEM_FromJob_Part_ShowStock
    Public frmEM_FromJob_Part_FunzioniForm As frmEM_FromJob_Part_Funzioni
    Public frmEM_FromJobList_Part_1_FilterForm As frmEM_FromJobList_Part_1_Filter
    Public frmEM_FromJobList_Part_2_ListJobsGroupForm As frmEM_FromJobList_Part_2_JobGroupList

    '>>>> FORM GESTIONE ENTRATA MERCI DA PRODUZIONE
    Public frmEM_FromStock_Part_1_OdpForm As frmEM_FromStock_Part_1_Odp
    Public frmEM_FromStock_Part_1_UMForm As frmEM_FromStock_Part_1_UM
    Public frmEM_FromStock_Part_4_ConfirmUbiDestForm As frmEM_FromStock_Part_4_ConfirmUbiDest
    '>>>> FORM GESTIONE ENTRATA MERCI DA PRODUZIONE CARICO NAVETTA
    Public frmEM_FromStock_Part_4_ConfirmMovTrasfForm As frmEM_FromStock_Part_4_ConfirmMovTrasf
    Public frmEM_FromStock_Part_5_ConfirmSKUForm As frmEM_FromStock_Part_5_ConfirmSKU
    '>>>> FORM GESTIONE ENTRATA MERCI DA PRODUZIONE SCARICO NAVETTA
    Public frmEM_FromStock_Part_1_Trasf_SelUbiSpuntaForm As frmEM_FromStock_Part_1_Trasf_SelUbiSpunta
    Public frmEM_FromStock_Part_1_Trasf_UMForm As frmEM_FromStock_Part_1_Trasf_UM
    Public frmEM_FromStock_Part_4_TrasfConfirmMovForm As frmEM_FromStock_Part_4_TrasfConfirmMov
    Public frmEM_FromStock_Part_5_Trasf_ConfirmSKUForm As frmEM_FromStock_Part_5_Trasf_ConfirmSKU

    '>>>> FORM GESTIONE ENTRATA MERCI (LISTA SELEZIONE GIACENZE)
    Public frmEM_StockList_Part_1_FilterForm As frmEM_StockList_Part_1_Filter
    Public frmEM_List_Part_2_List_GiacenzeForm As frmEM_StockList_Part_2_List_Giacenze
    Public frmEM_List_Part_3_ConfQtaForm As frmEM_FromStock_Part_3_ConfQta
    Public frmEM_List_Part_5_FinalConfirmForm As frmEM_FromStock_Part_4_ConfirmUM



    '>>>> FORM GESTIONE INVENTARIO UBICAZIONE
    Public frmInventarioUbicazione_1_UbicazioneForm As frmInventarioUbicazione_1_Ubicazione
    Public frmInventarioUbicazione_1_UMForm As frmInventarioUbicazione_1_UM
    Public frmInventarioUbicazione_1_UbicazioneUMForm As frmInventarioUbicazione_1_UbicazioneUM
    Public frmInventarioUbicazione_2_ConfCodMatForm As frmInventarioUbicazione_2_ConfCodMat
    Public frmInventarioUbicazione_3_SelStockForm As frmInventarioUbicazione_3_SelStock
    Public frmInventarioUbicazione_4_ConfQtaForm As frmInventarioUbicazione_4_ConfQta
    Public frmInventarioUbicazione_4_ConsumoCentroCostoForm As frmInventarioUbicazione_4_ConsumoCentroCosto

    '>>>> FORM GESTIONE MOVIMENTI DI METTI / TOGLI STOCK SPECIALE (Q,E,R,O)
    Public frmBloccoMovMM_Part_1Form As frmBloccoMovMM_Part_1
    Public frmBloccoMovMM_Part_2Form As frmBloccoMovMM_Part_2
    Public frmBloccoMovMM_Part_3_UMForm As frmBloccoMovMM_Part_3_UM
    Public frmBloccoMovMM_Part_3_UbicazioneForm As frmBloccoMovMM_Part_3_Ubicazione
    Public frmBloccoMovMM_Part_3_MaterialeForm As frmBloccoMovMM_Part_3_Materiale
    Public frmBloccoMovMM_Part_3_MaterialeUbicazioneForm As frmBloccoMovMM_Part_3_MaterialeUbicazione
    Public frmBloccoMovMM_Part_4_SelStockForm As frmBloccoMovMM_Part_4_SelStock
    Public frmBloccoMovMM_Part_5Form As frmBloccoMovMM_Part_5

    '>>>> FORM GESTIONE TRASFERIMENTI GENERICI MATERIALE
    Public frmTRASF_MAT_Part_1Form As frmTRASF_MAT_Part_1
    Public frmTRASF_MAT_Part_2_ConfCodMatForm As frmTRASF_MAT_Part_2_ConfCodMat
    Public frmTRASF_MAT_Part_3_SelStockForm As frmTRASF_MAT_Part_3_SelStock
    Public frmTRASF_MAT_Part_4_ConfQtaForm As frmTRASF_MAT_Part_4_ConfQta
    Public frmTRASF_MAT_Part_6_Final_ConfirmForm As frmTRASF_MAT_Part_6_Final_Confirm
    Public frmTRASF_MAT_Part_ShowStockForm As frmTRASF_MAT_Part_ShowStock

    '>>>> FORM GESTIONE STAMPA PALLET CARD
    Public frmPrintPalletCard_1_UMForm As frmPrintPalletCard_1_UM

    '>>>> FORM GESTIONE TRASFERIMENTI GENERICI UNITA MAGAZZINO
    Public frmTRASF_UM_Part_1_UM_OriForm As frmTRASF_UM_Part_1_UM_Ori
    Public frmTRASF_UM_Part_2_Ubi_DestForm As frmTRASF_UM_Part_2_Ubi_Dest
    Public frmTRASF_UM_Part_2_UM_DestForm As frmTRASF_UM_Part_2_UM_Dest

    Public frmTRASF_UBI_Part_1Form As frmTRASF_UBI_Part_1
    Public frmTRASF_UBI_Part_2Form As frmTRASF_UBI_Part_2




    '>>>> FORM GESTIONE DISACCANTONAMENTO MERCI
    Public frmDisaccantonaMerci_1_SelMisForm As frmDisaccantonaMerci_1_SelMis
    Public frmDisaccantonaMerci_1_CodMisForm As frmDisaccantonaMerci_1_CodMis
    Public frmDisaccantonaMerci_2_Ubi_e_UM_OrigineForm As frmDisaccantonaMerci_2_Ubi_e_UM_Origine
    Public frmDisaccantonaMerci_3_SelStockForm As frmDisaccantonaMerci_3_SelStock
    Public frmDisaccantonaMerci_4_ConfQtaForm As frmDisaccantonaMerci_4_ConfQta
    Public frmDisaccantonaMerci_5_Sel_UbiDestinazioneForm As frmDisaccantonaMerci_5_Sel_UbiDestinazione
    Public frmDisaccantonaMerci_5_Ubi_UM_DestForm As frmDisaccantonaMerci_5_Ubi_UM_Dest
    Public frmDisaccantonaMerci_X_PickLogicForm As frmDisaccantonaMerci_X_PickLogic

    '>>>> FORM GESTIONE PICKING x PRONTO
    Public frmPickingMerci_Appr_1_CodMisForm As frmPickingMerci_Appr_1_CodMis
    Public frmPickingMerci_Appr_2_SelMisForm As frmPickingMerci_Appr_2_SelMis
    Public frmPickingMerci_Appr_3_SelTipoOrigineForm As frmPickingMerci_Appr_3_SelTipoOrigine
    Public frmPickingMerci_Appr_4_Sel_MatnrOrigineForm As frmPickingMerci_Appr_4_Sel_MatnrOrigine
    Public frmPickingMerci_Appr_4_Sel_UbiOrigineForm As frmPickingMerci_Appr_4_Sel_UbiOrigine
    Public frmPickingMerci_Appr_4_Sel_UMOrigineForm As frmPickingMerci_Appr_4_Sel_UMOrigine
    Public frmPickingMerci_Appr_4_Ubi_e_UM_OrigineForm As frmPickingMerci_Appr_4_Ubi_e_UM_Origine
    Public frmPickingMerci_Appr_5_SelStockForm As frmPickingMerci_Appr_5_SelStock
    Public frmPickingMerci_Appr_6_ConfQtaForm As frmPickingMerci_Appr_6_ConfQta
    Public frmPickingMerci_Appr_7_Sel_UbiDestinazioneForm As frmPickingMerci_Appr_7_Sel_UbiDestinazione
    Public frmPickingMerci_Appr_7_Sel_UMDestinazioneForm As frmPickingMerci_Appr_7_Sel_UMDestinazione
    Public frmPickingMerci_Appr_7_Ubi_UM_DestForm As frmPickingMerci_Appr_7_Ubi_UM_Dest
    Public frmPickingMerci_Appr_8_RietichettaturaForm As frmPickingMerci_Appr_8_Rietichettatura
    Public frmPickingMerci_Appr_FunzioniForm As frmPickingMerci_Appr_Funzioni
    Public frmPickingMerci_Appr_X_PickLogicForm As frmPickingMerci_Appr_X_PickLogic
    Public frmPickingMerci_Appr_SelStockOrigineForm As frmPickingMerci_Appr_SelStockOrigine
    Public frmPickingMerci_Appr_SelStockDestinazioneForm As frmPickingMerci_Appr_SelStockDestinazione
    Public frmPickingMerci_Appr_ChiudiListaForm As frmPickingMerci_Appr_ChiudiLista
    Public frmInfoListaPickingForm As frmInfoListaPicking


    '>>>> FORM GESTIONE PICKING
    Public frmPickingMerci_Code_1_SettingsForm As frmPickingMerci_Code_1_Settings
    Public frmPickingMerci_Code_2_SelMisForm As frmPickingMerci_Code_2_SelMis
    Public frmPickingMerci_Code_3_SelUDSForm As frmPickingMerci_Code_3_SelUDS
    Public frmPickingMerci_Code_4_Sel_UMOrigineForm As frmPickingMerci_Code_4_Sel_UMOrigine
    Public frmPickingMerci_Code_5_Sel_CodMatOrigineForm As frmPickingMerci_Code_5_Sel_CodMatOrigine
    Public frmPickingMerci_Code_6_Sel_UMOrigineForm As frmPickingMerci_Code_6_Sel_UMOrigine
    Public frmPickingMerci_Code_7_ConfQtaForm As frmPickingMerci_Code_7_ConfQta
    Public frmPickingMerci_Code_DropUDSForm As frmPickingMerci_Code_DropUDS
    Public frmPickingMerci_ShowStockInfoForm As frmPickingMerci_ShowStockInfo
    Public frmPickingMerci_Code_FunzioniForm As frmPickingMerci_Code_Funzioni
    Public frmPickingMerci_MoveUDS_1_UM_OriForm As frmPickingMerci_MoveUDS_1_UM_Ori
    Public frmPickingMerci_MoveUDS_2_UBI_DestForm As frmPickingMerci_MoveUDS_2_UBI_Dest


    Public frmPickingMerci_Code_InsLocationForm As frmPickingMerci_Code_InsLocation
    Public frmPickingMerci_Code_InsPalletIdForm As frmPickingMerci_Code_InsPalletId


    Public frmUDSJobsMoveListForm As frmUDSJobsMoveList

    Public frmPickingMerci_ChangeUDS_1_UM_OriForm As frmPickingMerci_ChangeUDS_1_UM_Ori
    Public frmPickingMerci_ChangeUDS_2_UM_OperForm As frmPickingMerci_ChangeUDS_2_UM_Oper
    Public frmPickingMerci_ChangeUDS_Add_UM_SelForm As frmPickingMerci_ChangeUDS_Add_UM_Sel
    Public frmPickingMerci_ChangeUDS_Minus_UM_SelForm As frmPickingMerci_ChangeUDS_Minus_UM_Sel
    Public frmPickingMerci_ChangeUDS_Union_UMForm As frmPickingMerci_ChangeUDS_Union_UM


    Public frmTruckLoad_1_UM_SelForm As frmTruckLoad_1_UM_Sel
    Public frmTruckLoad_2_UBI_DestForm As frmTruckLoad_2_UBI_Dest


    '>>>> FORM GESTIONE USCITA MERCI x PICKING
    Public frmPickingMerci_JobGroupListForm As frmPickingMerci_JobGroupList
    Public frmPickingMerci_JobGroupDetailsForm As frmPickingMerci_JobGroupDetails

    Public frmPickingMerci_Fork_DropUDSForm As frmPickingMerci_Fork_DropUDS


    '>>>> FORM GESTIONE USCITA MERCI x ORDINE DI VENDITA
    Public frmPickingOdp_Odp_1Form As frmPickingOdP_OdP_1
    Public frmPickingOdp_UM_2Form As frmPickingOdP_UM_2


    '>>>> FORM GESTIONE AGGIUNGI/ELIMINA STOCK 'E'
    Public frmMovimento_StockE_Part_1Form As frmMovimento_StockE_Part_1
    Public frmMovimento_StockE_Part_2Form As frmMovimento_StockE_Part_2
    Public frmMovimento_StockE_Part_3Form As frmMovimento_StockE_Part_3
    Public frmMovimento_StockE_Part_4_InsertStockEForm As frmMovimento_StockE_Part_4_InsertStockE
    Public frmMovimento_StockE_Part_4_SelStockForm As frmMovimento_StockE_Part_4_SelStock


    '>>>> FORM UDC JOBS MOVE LIST
    Public frmUDCJobsMoveListForm As frmUDCJobsMoveList


    Public DivisioniAvailable(-1) As String
    Public NumMagAvailable(-1) As String
    Public MagazziniLogiciAvailable01(-1) As String
    Public MagazziniLogiciAvailable02(-1) As String
    Public UserLanguageAvailable(-1) As String

    '****************************************************
    ' Gestione mail segnalazione errori del programma
    Public ErrorMailEnable As Boolean = False
    Public ErrorMailFromMailAddressAccount As String
    Public ErrorMailFromMailAddressDisplayName As String
    Public ErrorMailUserId As String
    Public ErrorMailUserPassword As String
    Public ErrorMailToMailAddressArray(-1) As String
    Public ErrorMailSMTP_HostName As String

    Public Sub Main()
        Try
            Dim RetCode As Long
            RetCode += objMainApplication.StartApplication(Nothing)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "WM_Mobile")
        End Try

    End Sub
End Module