' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 18/07/2011
' DATA MODIFICA     : 18/07/2011
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la funzione di TRASFERIMENTO MATERIALE
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType
Imports clsSapUtility
Imports clsBusinessLogic

Public Class clsTrasfMat


    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsTrasfMat"

    'OGGETTO DATA TABLE PER VISUALIZZARE DATI NELLE GRIGLIE
    Public Shared objDataTableGiacenzeInfo As New DataTable

    Public Shared SourceUbicazione As clsDataType.SapWmUbicazione
    Public Shared DestinationUbicazione As clsDataType.SapWmUbicazione
    Public Shared MaterialeGiacenza As clsDataType.SapWmGiacenza
    Public Shared UdMTrasfList() As clsDataType.SapWmGiacenza

    Public Shared GiacenzeUbiDestinazione() As clsDataType.SapWmGiacenza

    Public Shared SourceForm As Form

    'MI INDICA CHE TIPO DI TRASFERIMENTO E' ATTIVO : NORMALE, TRASFERIMENTO PER INVENTARIO, ECC
    Public Shared FunctionTransferMaterialType As clsDataType.FunctionTransferMaterialType

    Private Shared SapFunctionError As clsBusinessLogic.SapFunctionError

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

            FunctionTransferMaterialType = clsDataType.FunctionTransferMaterialType.FunctionTransferMaterialTypeNone

            RetCode += clsSapUtility.ResetUbicazioneStruct(SourceUbicazione)
            RetCode += clsSapUtility.ResetUbicazioneStruct(DestinationUbicazione)

            RetCode += clsSapUtility.ResetGiacenzaStruct(MaterialeGiacenza)

            RetCode += ClearGiacenzeInfo()

            If (Not UdMTrasfList Is Nothing) Then
                ReDim UdMTrasfList(0)
                UdMTrasfList.Clear(UdMTrasfList, 0, 0)
                UdMTrasfList = Nothing
            End If

            If (Not GiacenzeUbiDestinazione Is Nothing) Then
                ReDim GiacenzeUbiDestinazione(0)
                GiacenzeUbiDestinazione.Clear(GiacenzeUbiDestinazione, 0, 0)
                GiacenzeUbiDestinazione = Nothing
            End If

            SourceForm = Nothing

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

            RetCode += ClearGiacenzeInfo()


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
    Public Shared Function Go_To_Original_Menu(ByRef inSourceForm As Form) As Long
        ' ************************************************************
        ' DESCRIZIONE : ritorna al menu chiamante
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Go_To_Original_Menu = 1 'init at error

            If (SourceForm Is Nothing) Then
                RetCode = clsNavigation.Show_Mnu_Main_Trasfer(inSourceForm, True)
                Go_To_Original_Menu = RetCode
                Exit Function
            End If

            Select Case SourceForm.GetType.Name
                Case frmMenuUscitaMerciMain.GetType.Name
                    RetCode = clsNavigation.Show_Mnu_Main_UscitaMerci(inSourceForm, True)
                    Go_To_Original_Menu = RetCode
                    Exit Function
                Case frmMenuTrasferMain.GetType.Name
                    RetCode = clsNavigation.Show_Mnu_Main_Trasfer(inSourceForm, True)
                    Go_To_Original_Menu = RetCode
                    Exit Function
                Case Else
                    RetCode = clsNavigation.Show_Mnu_Main_Trasfer(inSourceForm, True)
                    Go_To_Original_Menu = RetCode
                    Exit Function
            End Select

            Go_To_Original_Menu = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Go_To_Original_Menu = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function ExexQueryOfSourceMaterials() As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim ErrDescription As String
        Dim GetDataGiacenzeOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ExexQueryOfSourceMaterials = 1 'init at error

            'VERIFICO LE GIACENZE DELLO STESSO MATERIALE SE POSSO AVERE AMBIGUITA
            RetCode = clsSapWS.Call_ZWS_MB_GET_LQUA_GIACENZE(SourceUbicazione, MaterialeGiacenza, False, 0, clsUser.SapWmsUser.LANGUAGE, GetDataGiacenzeOk, clsTrasfMat.objDataTableGiacenzeInfo, Nothing, Nothing, Nothing, Nothing, SapFunctionError, False)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(291, "", "Errore in estrazione dati giacenza (GET_LQUA).") & vbCrLf & clsAppTranslation.GetSingleParameterValue(292, "", "Verificare filtri e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If
            If (GetDataGiacenzeOk <> True) Or (clsTrasfMat.objDataTableGiacenzeInfo Is Nothing) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(293, "", "Giacenza non presente in STOCK.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(294, "", "Verificare dati e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If

            ExexQueryOfSourceMaterials = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ExexQueryOfSourceMaterials = 1000 'IL THREAD E' USCITO DAL LOOP
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
    Public Shared Function FromTrasfMatStrucToString(Optional ByVal inShowMode As Long = 0) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim tmpString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            FromTrasfMatStrucToString = ""

            Select inShowMode
                Case 0
                    tmpString += clsAppTranslation.GetSingleParameterValue(952, "", "MAT:")
                    tmpString += UCase(MaterialeGiacenza.CodiceMateriale) + " - "
                    tmpString += UCase(MaterialeGiacenza.DescrizioneMateriale)
                    tmpString += vbCrLf

                    If (clsUtility.IsStringValid(MaterialeGiacenza.FormatoDescrizione, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(953, "", "FORMATO:")
                        tmpString += UCase(MaterialeGiacenza.FormatoDescrizione)
                        tmpString += vbCrLf
                    End If

                    If (clsUtility.IsStringValid(MaterialeGiacenza.Partita, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(851, "", "PARTITA:")
                        tmpString += UCase(MaterialeGiacenza.Partita) + ""
                        tmpString += vbCrLf
                    End If
                    If (clsUtility.IsStringValid(MaterialeGiacenza.TipoStock, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(896, "", "TIPO STOCK:") + MaterialeGiacenza.TipoStock
                        tmpString += vbCrLf
                    End If

                    If (clsUtility.IsStringValid(MaterialeGiacenza.CdStockSpeciale, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(944, "", "ST.SPEC.:") + MaterialeGiacenza.CdStockSpeciale + " - " + MaterialeGiacenza.NumeroStockSpeciale
                        tmpString += vbCrLf
                    End If

                    tmpString += clsAppTranslation.GetSingleParameterValue(847, "", "DIV:")
                    tmpString += UCase(SourceUbicazione.Divisione) + " - " + UCase(clsAppTranslation.GetSingleParameterValue(960, "", "NUM.MAG:"))
                    tmpString += UCase(SourceUbicazione.NumeroMagazzino)
                    tmpString += vbCrLf

                    tmpString += clsAppTranslation.GetSingleParameterValue(954, "", "PREL.UBI:")
                    If (clsUtility.IsStringValid(SourceUbicazione.TipoMagazzino, True) = True) Then
                        tmpString += UCase(SourceUbicazione.TipoMagazzino) + " - " + UCase(SourceUbicazione.Ubicazione)
                    Else
                        tmpString += UCase(MaterialeGiacenza.UbicazioneInfo.TipoMagazzino) + " - " + UCase(MaterialeGiacenza.UbicazioneInfo.Ubicazione)
                    End If
                    tmpString += vbCrLf

                    If (clsUtility.IsStringValid(SourceUbicazione.UnitaMagazzino, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(955, "", "PREL.UM:")
                        tmpString += UCase(SourceUbicazione.UnitaMagazzino)
                        tmpString += vbCrLf
                    ElseIf (clsUtility.IsStringValid(MaterialeGiacenza.UbicazioneInfo.UnitaMagazzino, True) = True) Then
                        'tmpString += clsAppTranslation.GetSingleParameterValue(956, "", "UM:")
                        tmpString += UCase(clsAppTranslation.GetSingleParameterValue(943, "", "Pallet ID:"))
                        tmpString += UCase(MaterialeGiacenza.UbicazioneInfo.UnitaMagazzino)
                        tmpString += vbCrLf
                    End If

                    tmpString += clsAppTranslation.GetSingleParameterValue(957, "", "QTA DISPO.:")
                    tmpString += UCase(MaterialeGiacenza.QtaTotaleLquaDispoUdMAcq) + " "
                    tmpString += UCase(MaterialeGiacenza.UnitaDiMisuraAcquisizione) + ""
                    'FORMATTAZZIONE QTA COMPLETA PER UTENTE
                    tmpString += clsShowUtility.ShowOnStockQtyCompleteForUserString(MaterialeGiacenza)
                    tmpString += vbCrLf


                    If (MaterialeGiacenza.VarianteImballo.ScatolePerPallet > 0) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(1217, "", "SCATOLE x PL:") + Trim(Val(MaterialeGiacenza.VarianteImballo.ScatolePerPallet)) + " " + UCase(MaterialeGiacenza.UnitaDiMisuraAcquisizione) + " - "
                        tmpString += clsAppTranslation.GetSingleParameterValue(1472, "", "PZ x SC:") + Trim(Val(MaterialeGiacenza.VarianteImballo.PezziPerScatola)) + " " + UCase(MaterialeGiacenza.UnitaDiMisuraPezzo)
                        'tmpString += clsAppTranslation.GetSingleParameterValue(959, "", "QTA X PALLET:")
                        'tmpString += UCase(MaterialeGiacenza.VarianteImballo.ScatolePerPallet) + " "
                        'tmpString += UCase(MaterialeGiacenza.UnitaDiMisuraAcquisizione) + ""
                        tmpString += vbCrLf
                    End If
                Case 1
                    'CASO IN CUI VISUALIZZO ANCHE LA  QTA CONFERMATA
                    tmpString += FromTrasfMatStrucToString(0)
                    If (MaterialeGiacenza.QuantitaConfermataOperatore > 0) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(958, "", "QTA CONF.:")
                        tmpString += UCase(MaterialeGiacenza.QuantitaConfermataOperatore) + " "
                        tmpString += UCase(MaterialeGiacenza.UnitaDiMisuraAcquisizione) + ""
                        tmpString += vbCrLf
                    End If

            End Select

            FromTrasfMatStrucToString = tmpString

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            FromTrasfMatStrucToString = ""
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function ShowTransferSingleUMInfo(ByVal inSapWmGiacenza As clsDataType.SapWmGiacenza, ByVal inDocumentoMaterialeBEM As clsDataType.SapWmDocumentoMateriale, Optional ByVal inShowMode As Long = 0) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim tmpString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ShowTransferSingleUMInfo = ""


            'inShowMode = 6 
            ' >>>> U.MAG.:[UnitaMagazzino]
            ' >>>> MAT: [CODICE MATERIALE]  QTA:(UdM BASE): [QtaTotaleDispoUdMAcq] - (UdM) [UnitaDiMisuraAcquisizione]        
            ' >>>> UBI.:[TIPO MAGAZZINO] - [UBICAZIONE]


            If (clsUtility.IsStringValid(inSapWmGiacenza.UbicazioneInfo.UnitaMagazzino, True) = True) Then
                'tmpString += "U.MAG.:" + clsSapUtility.FormattaStringaUnitaMagazzino(inSapWmGiacenza.UbicazioneInfo.UnitaMagazzino)
                tmpString += clsAppTranslation.GetSingleParameterValue(943, "", "Pallet ID:") + clsSapUtility.FormattaStringaUnitaMagazzino(inSapWmGiacenza.UbicazioneInfo.UnitaMagazzino)
                tmpString += vbCrLf
            End If
            tmpString += clsAppTranslation.GetSingleParameterValue(952, "", "MAT: ")
            If (clsUtility.IsStringValid(inSapWmGiacenza.CodiceMateriale, True) = True) Then
                tmpString += UCase(clsSapUtility.FormattaStringaCodiceMateriale(inSapWmGiacenza.CodiceMateriale))
            End If
            tmpString += "  "
            tmpString += clsAppTranslation.GetSingleParameterValue(853, "", "QTA: ") + UCase(inSapWmGiacenza.QtaTotaleLquaDispoUdMAcq) + " " + UCase(inSapWmGiacenza.UnitaDiMisuraAcquisizione)
            tmpString += vbCrLf

            tmpString += clsAppTranslation.GetSingleParameterValue(949, "", "UBI.:") + UCase(inSapWmGiacenza.UbicazioneInfo.TipoMagazzino) + " - " + UCase(inSapWmGiacenza.UbicazioneInfo.Ubicazione)
            tmpString += vbCrLf


            ShowTransferSingleUMInfo = tmpString

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ShowTransferSingleUMInfo = ""
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

End Class
