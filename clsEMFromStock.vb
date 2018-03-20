' ********************************************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 06/10/2015
' DATA MODIFICA     : 06/10/2015
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la funzione di ENTRATA MERCE da GIACENZA ( TIPO MAGAZZINO 90X o SPUNTA )
' ********************************************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType
Imports clsSapUtility

Public Class clsEMFromStock


    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsEMFromStock"


    '*****************************************
    ' >>> TIPI DI DATI
    Public Enum EM_Prod_DestinationType
        EM_Stock_DestinationTypeNone = 0
        EM_Stock_DestinationTypeMagazzino = 1
        EM_Stock_DestinationTypeContoLavoro = 2
        EM_Stock_DestinationTypeProduzione = 3
        EM_Stock_DestinationTypeMagCommesse = 10
    End Enum

    Public Enum EM_Stock_SourceType
        EM_Stock_SourceTypeNone = 0
        EM_Stock_SourceTypeStockList = 1        '>>> ENTRATA MERCE CON LISTA DELLE GIACENZE
        EM_Stock_SourceTypeOdP = 2              '>>> ENTRATA MERCE DIGITANDO IL NUMERO ODP
        EM_Stock_SourceTypeUM_Generic = 3       '>>> ENTRATA MERCE DIGITANDO IL BARCODE PALLET ( UM )
        EM_Stock_SourceTypeUM_FromOdp = 4       '>>> ENTRATA MERCE DIGITANDO IL BARCODE PALLET ( UM )
        EM_Stock_SourceTypeUM_MovTransfLoad = 5   '>>> ENTRATA MERCE DIGITANDO IL BARCODE PALLET ( UM ) CON MOVIMENTO DI TRASFERIMENTO CARICO NAVETTA
        EM_Stock_SourceTypeUM_MovTransfUnLoad = 6   '>>> ENTRATA MERCE DIGITANDO IL BARCODE PALLET ( UM ) CON MOVIMENTO DI TRASFERIMENTO SCARICO NAVETTA
        EM_Stock_SourceTypeUDCJobsMoveList = 7   '>>> ENTRATA MERCE PARTENDO DAFORM DI SELEZIONE UDC JOBS MOVE LIST
    End Enum

    '*****************************************
    ' >>> PROPRIETA E VARIABILI

    'OGGETTO DATA TABLE PER VISUALIZZARE GIACENZE CON STESSA PARTITA NELLE GRIGLIE DI STOCK INFO
    Public Shared objDataTableGiacSameMatPartInfo As New DataTable

    'OGGETTO DATA TABLE PER VISUALIZZARE DATI NELLE GRIGLIE
    Public Shared objDataTable_EM_List_Info As New DataTable

    Public Shared OrdineProduzioneOrigine As clsDataType.SapOrdineProduzione
    Public Shared OrdineProduzioneDestinazione As clsDataType.SapOrdineProduzione

    Public Shared UbicazioneDestProposte As clsDataType.SapStrateInputDestInfo()
    Public Shared UbicazioneDestOnWork As clsDataType.SapStrateInputDestInfo
    Public Shared SourceUbicazione As clsDataType.SapWmUbicazione
    Public Shared DestinationUbicazione As clsDataType.SapWmUbicazione
    Public Shared MaterialeGiacenza As clsDataType.SapWmGiacenza
    Public Shared DescrUbiDestinazione As String

    Public Shared UdMTrasfList() As clsDataType.SapWmGiacenza

    Public Shared EM_StockSourceType As EM_Stock_SourceType

    Public Shared SourceForm As Form

    Public Shared UserFilterSourceUbicazione As clsDataType.SapWmUbicazione
    Public Shared UserFilterMaterialeGiacenza As clsDataType.SapWmGiacenza
    Public Shared IndexUbiVuotaDest As Long
    Public Shared IndexUbicazioneDestAttiva As Long

    Public Shared WorkGiacenzaUM As clsDataType.SapWmGiacenza


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

            clsSapUtility.ResetOrdineProduzioneStruct(OrdineProduzioneOrigine)
            clsSapUtility.ResetOrdineProduzioneStruct(OrdineProduzioneDestinazione)

            RetCode += clsSapUtility.ResetUbicazioneStruct(SourceUbicazione)
            RetCode += clsSapUtility.ResetUbicazioneStruct(DestinationUbicazione)
            RetCode += clsSapUtility.ResetGiacenzaStruct(MaterialeGiacenza)
            RetCode += clsSapUtility.ResetGiacenzaStruct(WorkGiacenzaUM)

            RetCode += clsSapUtility.ResetUbicazioneStruct(UserFilterSourceUbicazione)
            RetCode += clsSapUtility.ResetGiacenzaStruct(UserFilterMaterialeGiacenza)

            If (Not UdMTrasfList Is Nothing) Then
                ReDim UdMTrasfList(0)
                UdMTrasfList.Clear(UdMTrasfList, 0, 0)
                UdMTrasfList = Nothing
            End If

            If (Not (objDataTable_EM_List_Info Is Nothing)) Then
                objDataTable_EM_List_Info.Rows.Clear()
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
    Public Shared Function ClearGiacSameMatPart() As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ClearGiacSameMatPart = 1 'init at error

            If (Not (objDataTableGiacSameMatPartInfo Is Nothing)) Then
                objDataTableGiacSameMatPartInfo.Rows.Clear()
            End If

            ClearGiacSameMatPart = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ClearGiacSameMatPart = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetNumDestinazioniProposte() As Long
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        'Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetNumDestinazioniProposte = 0 'init

            GetNumDestinazioniProposte = UbicazioneDestProposte.Length

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetNumDestinazioniProposte = 0 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function ClearForNewOperation() As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ClearForNewOperation = 1 'init at error

            RetCode += clsSapUtility.ResetUbicazioneStruct(SourceUbicazione)
            RetCode += clsSapUtility.ResetUbicazioneStruct(DestinationUbicazione)
            RetCode += clsSapUtility.ResetGiacenzaStruct(MaterialeGiacenza)

            If (Not UbicazioneDestProposte Is Nothing) Then
                ReDim UbicazioneDestProposte(0)
                UbicazioneDestProposte.Clear(UbicazioneDestProposte, 0, 0)
            End If

            'IndexUbicazioneDestAttiva = 0
            'IndexUbiVuotaDest = 0
            'DescrUbiDestinazione = ""

            If (Not (objDataTable_EM_List_Info Is Nothing)) Then
                objDataTable_EM_List_Info.Rows.Clear()
            End If

            ClearForNewOperation = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ClearForNewOperation = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function CreateDateTableForGiacSameMatPart() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForGiacSameMatPart = 1 'init at error


            RetCode = clsDataType.CreateDateTableForGiacenze(objDataTableGiacSameMatPartInfo)


            CreateDateTableForGiacSameMatPart = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForGiacSameMatPart = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function CreateDateTableForEM_List() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForEM_List = 1 'init at error

            RetCode = clsDataType.CreateDateTableForGiacenze(objDataTable_EM_List_Info)

            CreateDateTableForEM_List = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForEM_List = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetNumDataTableEMList() As Long
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetNumDataTableEMList = 0 'init

            If (objDataTable_EM_List_Info Is Nothing) Then Exit Function

            GetNumDataTableEMList = objDataTable_EM_List_Info.Rows.Count

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetNumDataTableEMList = 0 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ShowJobPutAwayInfoForUserString(Optional ByVal inShowMode As Long = 0) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim tmpString As String = ""
        Dim WorkSapWmGiacenza As clsDataType.SapWmGiacenza
        Dim WorkSapWmGiacenzaScelta As clsDataType.SapDatiProduzioneScelta
        Dim WorkIndiceLoop As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ShowJobPutAwayInfoForUserString = ""


            'inShowMode = 0 : usato per la videata [frmEM_FromStock_Part_1_UM] 
            'inShowMode = 1 : usato per la visualizzazione della finestra  [frmEM_FromStock_Part_4_Confirm]
            'inShowMode = 2 : usato per la videata [frmEM_FromStock_Part_4_ConfirmMovTrasf]
            'inShowMode = 3 : usato per la videata [frmEM_FromStock_Part_5_ConfirmSKU]

            Select Case inShowMode
                Case 0
                    For Each WorkSapWmGiacenza In clsEMFromStock.UdMTrasfList
                        If (clsUtility.IsStringValid(WorkSapWmGiacenza.UbicazioneInfo.UnitaMagazzino, True) = True) Then
                            tmpString += clsAppTranslation.GetSingleParameterValue(943, "", "U.MAG.:") + clsSapUtility.FormattaStringaUnitaMagazzino(WorkSapWmGiacenza.UbicazioneInfo.UnitaMagazzino)
                            tmpString += vbCrLf
                        End If
                        tmpString += clsAppTranslation.GetSingleParameterValue(952, "", "MAT: ")
                        If (clsUtility.IsStringValid(WorkSapWmGiacenza.CodiceMateriale, True) = True) Then
                            tmpString += UCase(clsSapUtility.FormattaStringaCodiceMateriale(WorkSapWmGiacenza.CodiceMateriale))
                        End If

                        'tmpString += "  "
                        'tmpString += clsAppTranslation.GetSingleParameterValue(853, "", "QTA: ") + UCase(WorkSapWmGiacenza.QtaTotaleLquaDisponibile) + " " + UCase(WorkSapWmGiacenza.UnitaDiMisuraBase)
                        'tmpString += vbCrLf

                        If (clsUtility.IsStringValid(WorkSapWmGiacenza.UnitaDiMisuraAcquisizione, True) = True) Then
                            tmpString += "  "
                            tmpString += clsAppTranslation.GetSingleParameterValue(853, "", "QTA: ") + UCase(WorkSapWmGiacenza.QtaTotaleLquaDispoUdMAcq) + " " + UCase(WorkSapWmGiacenza.UnitaDiMisuraAcquisizione)
                            tmpString += vbCrLf
                        Else
                            tmpString += "  "
                            tmpString += clsAppTranslation.GetSingleParameterValue(853, "", "QTA: ") + UCase(WorkSapWmGiacenza.QtaTotaleLquaDisponibile) + " " + UCase(WorkSapWmGiacenza.UnitaDiMisuraBase)
                            tmpString += vbCrLf
                        End If

                        tmpString += clsAppTranslation.GetSingleParameterValue(1664, "", "WAREHOUSE CODE: ") + UCase(WorkSapWmGiacenza.ZZWAREHOUSE_CODE) + " - "

                        tmpString += clsAppTranslation.GetSingleParameterValue(1663, "", "STORAGE CODE: ") + UCase(WorkSapWmGiacenza.ZZSTORAGE_CODE)
                        tmpString += vbCrLf

                    Next

                Case 1
                    WorkIndiceLoop = 1
                    For Each WorkSapWmGiacenza In clsEMFromStock.UdMTrasfList
                        'NELLA PRIMA RIGA METTO INDICAZIONE DEL MATERIALE / PARTITA
                        If (WorkIndiceLoop = 1) Then
                            tmpString += clsAppTranslation.GetSingleParameterValue(952, "", "MAT: ")
                            If (clsUtility.IsStringValid(WorkSapWmGiacenza.CodiceMateriale, True) = True) Then
                                tmpString += UCase(clsSapUtility.FormattaStringaCodiceMateriale(WorkSapWmGiacenza.CodiceMateriale))
                            End If
                            tmpString += "  "
                            tmpString += clsAppTranslation.GetSingleParameterValue(1252, "", "PAR: ")
                            If (clsUtility.IsStringValid(WorkSapWmGiacenza.Partita, True) = True) Then
                                tmpString += UCase(clsSapUtility.FormattaStringaCodiceMateriale(WorkSapWmGiacenza.Partita))
                            End If
                            tmpString += vbCrLf
                            tmpString += vbCrLf
                        End If
                        If (clsUtility.IsStringValid(WorkSapWmGiacenza.UbicazioneInfo.UnitaMagazzino, True) = True) Then
                            tmpString += clsAppTranslation.GetSingleParameterValue(943, "", "U.MAG.:") + clsSapUtility.FormattaStringaUnitaMagazzino(WorkSapWmGiacenza.UbicazioneInfo.UnitaMagazzino)
                            tmpString += vbCrLf
                        End If
                        tmpString += clsAppTranslation.GetSingleParameterValue(952, "", "MAT: ")
                        If (clsUtility.IsStringValid(WorkSapWmGiacenza.CodiceMateriale, True) = True) Then
                            tmpString += UCase(clsSapUtility.FormattaStringaCodiceMateriale(WorkSapWmGiacenza.CodiceMateriale))
                        End If

                        'tmpString += "  "
                        'tmpString += clsAppTranslation.GetSingleParameterValue(853, "", "QTA: ") + UCase(WorkSapWmGiacenza.QtaTotaleLquaDisponibile) + " " + UCase(WorkSapWmGiacenza.UnitaDiMisuraBase)
                        'tmpString += vbCrLf

                        If (clsUtility.IsStringValid(WorkSapWmGiacenza.UnitaDiMisuraAcquisizione, True) = True) Then
                            tmpString += "  "
                            tmpString += clsAppTranslation.GetSingleParameterValue(853, "", "QTA: ") + UCase(WorkSapWmGiacenza.QtaTotaleLquaDispoUdMAcq) + " " + UCase(WorkSapWmGiacenza.UnitaDiMisuraAcquisizione)
                            tmpString += vbCrLf
                        Else
                            tmpString += "  "
                            tmpString += clsAppTranslation.GetSingleParameterValue(853, "", "QTA: ") + UCase(WorkSapWmGiacenza.QtaTotaleLquaDisponibile) + " " + UCase(WorkSapWmGiacenza.UnitaDiMisuraBase)
                            tmpString += vbCrLf
                        End If

                        tmpString += clsAppTranslation.GetSingleParameterValue(949, "", "UBI.:") + UCase(WorkSapWmGiacenza.UbicazioneInfo.TipoMagazzino) + " - " + UCase(WorkSapWmGiacenza.UbicazioneInfo.Ubicazione)
                        tmpString += vbCrLf
                        'tmpString += vbCrLf

                        tmpString += clsAppTranslation.GetSingleParameterValue(1664, "", "WAREHOUSE CODE: ") + UCase(WorkSapWmGiacenza.ZZWAREHOUSE_CODE) + " - "

                        tmpString += clsAppTranslation.GetSingleParameterValue(1663, "", "STORAGE CODE: ") + UCase(WorkSapWmGiacenza.ZZSTORAGE_CODE)
                        tmpString += vbCrLf

                        WorkIndiceLoop = WorkIndiceLoop + 1
                    Next

                Case 2
                    For Each WorkSapWmGiacenza In clsEMFromStock.UdMTrasfList
                        If (clsUtility.IsStringValid(WorkSapWmGiacenza.UbicazioneInfo.UnitaMagazzino, True) = True) Then
                            tmpString += clsAppTranslation.GetSingleParameterValue(943, "", "U.MAG.:") + clsSapUtility.FormattaStringaUnitaMagazzino(WorkSapWmGiacenza.UbicazioneInfo.UnitaMagazzino)
                            tmpString += vbCrLf
                        End If
                        tmpString += clsAppTranslation.GetSingleParameterValue(952, "", "MAT: ")
                        If (clsUtility.IsStringValid(WorkSapWmGiacenza.CodiceMateriale, True) = True) Then
                            tmpString += UCase(clsSapUtility.FormattaStringaCodiceMateriale(WorkSapWmGiacenza.CodiceMateriale))
                        End If

                        'tmpString += "  "
                        'tmpString += clsAppTranslation.GetSingleParameterValue(853, "", "QTA: ") + UCase(WorkSapWmGiacenza.QtaTotaleLquaDisponibile) + " " + UCase(WorkSapWmGiacenza.UnitaDiMisuraBase)
                        'tmpString += vbCrLf

                        If (clsUtility.IsStringValid(WorkSapWmGiacenza.UnitaDiMisuraAcquisizione, True) = True) Then
                            tmpString += "  "
                            tmpString += clsAppTranslation.GetSingleParameterValue(853, "", "QTA: ") + UCase(WorkSapWmGiacenza.QtaTotaleLquaDispoUdMAcq) + " " + UCase(WorkSapWmGiacenza.UnitaDiMisuraAcquisizione)
                            tmpString += vbCrLf
                        Else
                            tmpString += "  "
                            tmpString += clsAppTranslation.GetSingleParameterValue(853, "", "QTA: ") + UCase(WorkSapWmGiacenza.QtaTotaleLquaDisponibile) + " " + UCase(WorkSapWmGiacenza.UnitaDiMisuraBase)
                            tmpString += vbCrLf
                        End If

                    Next

                Case 3

                    If clsEMFromStock.EM_StockSourceType = clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUM_MovTransfLoad Then
                        WorkSapWmGiacenzaScelta = frmEM_FromStock_Part_5_ConfirmSKUForm.outSapGiacenzaScelta
                    Else
                        WorkSapWmGiacenzaScelta = frmEM_FromStock_Part_5_Trasf_ConfirmSKUForm.outSapGiacenzaScelta
                    End If


                    If (clsUtility.IsStringValid(clsEMFromStock.WorkGiacenzaUM.UbicazioneInfo.UnitaMagazzino, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(943, "", "U.MAG.:") + clsSapUtility.FormattaStringaUnitaMagazzino(clsEMFromStock.WorkGiacenzaUM.UbicazioneInfo.UnitaMagazzino)
                        tmpString += vbCrLf
                    End If
                    tmpString += clsAppTranslation.GetSingleParameterValue(952, "", "MAT: ")
                    If (clsUtility.IsStringValid(clsEMFromStock.WorkGiacenzaUM.CodiceMateriale, True) = True) Then
                        tmpString += UCase(clsSapUtility.FormattaStringaCodiceMateriale(clsEMFromStock.WorkGiacenzaUM.CodiceMateriale))
                    End If

                    'tmpString += "  "
                    'tmpString += clsAppTranslation.GetSingleParameterValue(853, "", "QTA: ") + UCase(clsEMFromStock.WorkGiacenzaUM.QtaTotaleLquaDisponibile) + " " + UCase(clsEMFromStock.WorkGiacenzaUM.UnitaDiMisuraBase)
                    'tmpString += vbCrLf

                    If (clsUtility.IsStringValid(clsEMFromStock.WorkGiacenzaUM.UnitaDiMisuraAcquisizione, True) = True) Then
                        tmpString += "  "
                        tmpString += clsAppTranslation.GetSingleParameterValue(853, "", "QTA: ") + UCase(clsEMFromStock.WorkGiacenzaUM.QtaTotaleLquaDispoUdMAcq) + " " + UCase(clsEMFromStock.WorkGiacenzaUM.UnitaDiMisuraAcquisizione)
                        tmpString += vbCrLf
                    Else
                        tmpString += "  "
                        tmpString += clsAppTranslation.GetSingleParameterValue(853, "", "QTA: ") + UCase(clsEMFromStock.WorkGiacenzaUM.QtaTotaleLquaDisponibile) + " " + UCase(clsEMFromStock.WorkGiacenzaUM.UnitaDiMisuraBase)
                        tmpString += vbCrLf
                    End If


                    tmpString += clsAppTranslation.GetSingleParameterValue(1253, "", "  Mat Alt.: ")
                    If (clsUtility.IsStringValid(WorkSapWmGiacenzaScelta.CodiceMaterialeAlternativo, True) = True) Then
                        tmpString += UCase(clsSapUtility.FormattaStringaCodiceMateriale(WorkSapWmGiacenzaScelta.CodiceMaterialeAlternativo))
                    End If
                    tmpString += vbCrLf
                    tmpString += "  "
                    tmpString += clsAppTranslation.GetSingleParameterValue(1254, "", "Divisione: ") + UCase(WorkSapWmGiacenzaScelta.Divisione) + " " + clsAppTranslation.GetSingleParameterValue(1255, "", "Magazzino: ") + UCase(WorkSapWmGiacenzaScelta.NumeroMagazzino)
                    tmpString += vbCrLf
                    tmpString += "  "
                    tmpString += clsAppTranslation.GetSingleParameterValue(1256, "", "Nr. Ord. Produzione: ") + UCase(WorkSapWmGiacenzaScelta.NumeroOrdineProduzione)
                    tmpString += vbCrLf
                    tmpString += "  "
                    tmpString += clsAppTranslation.GetSingleParameterValue(1257, "", "Scelta: ") + UCase(WorkSapWmGiacenzaScelta.Scelta)
                    tmpString += vbCrLf
                    tmpString += "  "
                    tmpString += clsAppTranslation.GetSingleParameterValue(1258, "", "Tono: ") + UCase(WorkSapWmGiacenzaScelta.Tono)
                    tmpString += vbCrLf
                    tmpString += "  "
                    tmpString += clsAppTranslation.GetSingleParameterValue(1259, "", "Calibro: ") + UCase(WorkSapWmGiacenzaScelta.Calibro)
                    tmpString += vbCrLf
                    tmpString += "  "
                    tmpString += clsAppTranslation.GetSingleParameterValue(1260, "", "Qualità: ") + UCase(WorkSapWmGiacenzaScelta.Qualita)
                    tmpString += vbCrLf
                    tmpString += "  "
                    tmpString += clsAppTranslation.GetSingleParameterValue(1261, "", "Progressivo Prod.: ") + UCase(WorkSapWmGiacenzaScelta.ProgressivoProd)
                    tmpString += vbCrLf
                    tmpString += "  "
                    tmpString += clsAppTranslation.GetSingleParameterValue(1262, "", "Cod. Variante Imballo: ") + UCase(WorkSapWmGiacenzaScelta.CodiceVarianteImballo)
                    tmpString += vbCrLf
                    tmpString += "  "
                    tmpString += clsAppTranslation.GetSingleParameterValue(1263, "", "Lotto: ") + UCase(WorkSapWmGiacenzaScelta.Lotto)
                    tmpString += vbCrLf
                    tmpString += "  "
                    tmpString += clsAppTranslation.GetSingleParameterValue(1264, "", "Op. Produzione: ") + UCase(WorkSapWmGiacenzaScelta.OperatoreProd)
                    tmpString += vbCrLf
                    tmpString += "  "
                    tmpString += clsAppTranslation.GetSingleParameterValue(1265, "", "Data Prod: ") + UCase(WorkSapWmGiacenzaScelta.DataProduzione) + " " + clsAppTranslation.GetSingleParameterValue(1266, "", "Ora Prod: ") + UCase(WorkSapWmGiacenzaScelta.OraProduzione)
                    tmpString += vbCrLf

            End Select

            ShowJobPutAwayInfoForUserString = tmpString

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ShowJobPutAwayInfoForUserString = ""
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try


    End Function

End Class
