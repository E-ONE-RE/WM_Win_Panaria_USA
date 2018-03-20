' *************************************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 12/09/2011
' DATA MODIFICA     : 12/09/2011
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la funzione di ENTRATA MERCE da MISSIONW DI ENTRATA MERCE
' *************************************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType
Imports clsSapUtility
Imports clsSapWS
Imports clsBusinessLogic
Imports clsNavigation

Public Class clsEMFromJob


    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsEMFromJob"


    Public Enum EM_FromJob_SourceType
        EM_FromJob_SourceTypeNone = 0
        EM_FromJob_SourceTypeDocMat = 1
        EM_FromJob_SourceTypeJobGroup = 2
        EM_FromJob_SourceTypeJobList = 3
    End Enum

    'OGGETTO DATA TABLE PER VISUALIZZARE GIACENZE CON STESSA PARTITA NELLE GRIGLIE DI STOCK INFO
    Public Shared objDataTableGiacSameMatPartInfo As New DataTable

    Public Shared EM_SourceType As EM_FromJob_SourceType

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

            ClearGiacSameMatPart()

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
    Public Shared Function CheckStockTypeByUser(ByRef outCheckStockTypeOk As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim WorkString As String
        Dim UserAnswer As DialogResult = DialogResult.No
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CheckStockTypeByUser = 1 'init at error

            outCheckStockTypeOk = True

            'CASO LEGATO AL FLUSSO CON DOCUMENTO MATERIALE
            If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.TipoStock = "") Then
                CheckStockTypeByUser = RetCode 'TUTTO OK
                Exit Function
            End If
            If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.TipoStock = cstTipoStockQ) Then
                WorkString = clsAppTranslation.GetSingleParameterValue(838, "", "Attenzione! Giacenza in STOCK 'Q', si desidera continuare ? (SI/NO)")
                UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                    outCheckStockTypeOk = False
                    CheckStockTypeByUser = RetCode 'TUTTO OK
                    Exit Function
                End If
            End If

            CheckStockTypeByUser = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckStockTypeByUser = 1000 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function CheckStockForOrdineDiVendita(ByRef outCheckStockOk As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim WorkString As String
        Dim UserAnswer As DialogResult = DialogResult.No
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CheckStockForOrdineDiVendita = 1 'init at error

            outCheckStockOk = True

            If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.NumeroDocumentoVendita = "") Then
                CheckStockForOrdineDiVendita = RetCode 'TUTTO OK
                Exit Function
            End If
            '??? sistemare WorkString = clsAppTranslation.GetSingleParameterValue(839, "", "Attenzione! Merce dell'ordine di vendita:") & clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.NumeroDocumentoVendita & vbCrLf & clsAppTranslation.GetSingleParameterValue(438, "", "Qta:") & clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaPosizioneDocumentoVenditaUdMConsegna & " " & clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione & vbCrLf & clsAppTranslation.GetSingleParameterValue(840, "", "Verificare approntabilità.")
            UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

            CheckStockForOrdineDiVendita = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckStockForOrdineDiVendita = 1000 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CheckQtyConfirmedByUser(ByRef inQtaConfermata As Double, ByRef inQtaPrevista As Double, ByRef inQtaConfermataSfusi As Double, ByRef inQtaPrevistaSfusi As Double, ByVal inUserConfirmItemEnded As Boolean, ByRef outCheckQtyOk As Boolean, ByRef outQtyConfermataRettificaPositiva As Double, ByRef outQtyConfermataRettificaNegativa As Double) As Long
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim QtaResiduaDaPrelevare As Double
        Dim QtaResiduaSfusiDaPrelevare As Double
        Dim ShowMessageWarningQtyDifferent As Boolean = False
        Dim ShowMessageWarningQtyGreater As Boolean = False
        Dim ShowMessageWarningQtySmaller As Boolean = False
        Dim WorkString As String
        Dim UserAnswer As DialogResult = DialogResult.No
        Dim WorkQtyConfermataRettificaPositiva As Double = 0
        Dim WorkQtyConfermataRettificaNegativa As Double = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CheckQtyConfirmedByUser = 1 'init at error

            outCheckQtyOk = False 'init at error

            If (inQtaConfermata <= 0) And (inQtaConfermataSfusi <= 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(795, "", "La Qtà Confermata deve essere positiva.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(568, "", "Verificare i dati immessi e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If

            'RECUPERO LA QTA ANCORA DA PRELEVARE PER LA MISSIONE
            QtaResiduaDaPrelevare = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDaPrelUdMAcq - clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna
            QtaResiduaSfusiDaPrelevare = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaSfusiInPZ - clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataSfusi

            'CASI IN CUI LA QUANTITA CONFERMATA NON PUO' ESSERE SUPERIORE A QUELLA PREVISTA 
            If (BemEnableConfirmQtyGreater = False) And (inQtaConfermata > QtaResiduaDaPrelevare) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(842, "", "Qtà Confermata superiore a quella rimasta da prelevare") & clsAppTranslation.GetSingleParameterValue(843, "", " del DOCUMENTO MATERIALE.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If
            If (BemEnableConfirmQtyGreater = False) And (inQtaConfermataSfusi > QtaResiduaSfusiDaPrelevare) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1473, "", "Qtà Confermata Sfusi superiore a quella rimasta da prelevare") & clsAppTranslation.GetSingleParameterValue(843, "", " del DOCUMENTO MATERIALE.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If

            'CASO IN CUI LA QUANTITA CONFERMATA PUO' ESSERE SUPERIORE A QUELLA PREVISTA 
            If (BemEnableConfirmQtyGreater = True) And (inQtaConfermata > QtaResiduaDaPrelevare) Then
                ShowMessageWarningQtyGreater = True
                WorkQtyConfermataRettificaPositiva = inQtaConfermata - clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaInUdMAcquisizione
            End If

            'CASO IN CUI LA QUANTITA CONFERMATA PUO' ESSERE INFERIORE A QUELLA PREVISTA 
            If (BemEnableConfirmQtySmaller = True) And (inUserConfirmItemEnded = True) And (inQtaConfermata < QtaResiduaDaPrelevare) Then
                ShowMessageWarningQtySmaller = True
                WorkQtyConfermataRettificaNegativa = QtaResiduaDaPrelevare - inQtaConfermata
            End If


            '>>> CONFERMO QTA CONFERMATA DIVERSA DA QUELLA DELLA POSIZIONE
            ShowMessageWarningQtyDifferent = False
            If (inQtaConfermata <> QtaResiduaDaPrelevare) Then
                If (inQtaConfermata <> inQtaPrevista) Then
                    If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet > 0) Then
                        If (inQtaConfermata <> clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet) Then
                            ShowMessageWarningQtyDifferent = True
                        End If
                    Else
                        ShowMessageWarningQtyDifferent = True
                    End If
                End If
            End If

            If (inQtaConfermataSfusi <> QtaResiduaSfusiDaPrelevare) Then
                If (inQtaConfermataSfusi <> inQtaPrevistaSfusi) Then
                    ShowMessageWarningQtyDifferent = True
                End If
            End If

            'MESSAGGIO DI CONFERMA CONTEGGIO QTA DIFFERENTE PER OPERATORE
            If (ShowMessageWarningQtyDifferent = True) And (ShowMessageWarningQtyGreater = False) And (ShowMessageWarningQtySmaller = False) Then
                WorkString = clsAppTranslation.GetSingleParameterValue(482, "", "Si desidera veramente confermare una QTA' diversa da quella prevista ? ") & clsAppTranslation.GetSingleParameterValue(322, "", "(SI/NO)")
                UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                    Exit Function
                End If
            End If

            'MESSAGGIO DI CONFERMA CONTEGGIO QTA MAGGIORE DEL PREVISTO PER OPERATORE
            If (ShowMessageWarningQtyGreater = True) Then
                WorkString = clsAppTranslation.GetSingleParameterValue(844, "", "Si desidera veramente confermare una QTA' MAGGIORE di quella prevista ?") & clsAppTranslation.GetSingleParameterValue(322, "", "(SI/NO)")
                UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                    Exit Function
                End If
                'RITORNO QTA DI RETTIFICA CONFERMATA DA OPERATORE
                outQtyConfermataRettificaPositiva = WorkQtyConfermataRettificaPositiva
            End If

            'MESSAGGIO DI CONFERMA CONTEGGIO QTA MINORE DEL PREVISTO PER OPERATORE
            If (ShowMessageWarningQtySmaller = True) Then
                WorkString = clsAppTranslation.GetSingleParameterValue(845, "", "Si desidera veramente confermare una QTA' MINORE di quella prevista ?") & clsAppTranslation.GetSingleParameterValue(322, "", "(SI/NO)")
                UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                    Exit Function
                End If
                'RITORNO QTA DI RETTIFICA CONFERMATA DA OPERATORE
                outQtyConfermataRettificaNegativa = WorkQtyConfermataRettificaNegativa
            End If


            'SE ARRIVO QUI TUTTI I CONTROLLI SONO STATI POSITIVI
            outCheckQtyOk = True

            CheckQtyConfirmedByUser = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckQtyConfirmedByUser = 1000 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetEntrataMerceUnitaMagDaConfermare(ByRef outUnitaMagDestDaConfermare As String) As Long
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetEntrataMerceUnitaMagDaConfermare = 1 'init at error

            outUnitaMagDestDaConfermare = "" 'init

            If (clsWmsJob.WmsJob.UbicazioneDestinazione.AbilitaUnitaMagazzino = True) Then

                'IN QUESTO CASO HO SPECIFICATO A MONTE UNA UM
                If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.PickSUCompleto = True) And (clsUtility.IsStringValid(clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.UnitaMagazzino, True) = True) Then
                    'CASO IN CUI HO PRELEVATO TUTTA L'UNITA DI MAGAZZINO E PROPONGO LA STESSA UDM
                    outUnitaMagDestDaConfermare = clsSapUtility.FormattaStringaUnitaMagazzino(clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.UnitaMagazzino)
                End If

                'SE HO GIA' IMPOSTATO UNA UDM LA RITORNO (CASO CONFERMA UBICAZIONE FINALE)
                If (clsUtility.IsStringValid(clsWmsJob.WmsJob.UbicazioneDestinazione.UnitaMagazzino, True) = True) Then
                    outUnitaMagDestDaConfermare = clsSapUtility.FormattaStringaUnitaMagazzino(clsWmsJob.WmsJob.UbicazioneDestinazione.UnitaMagazzino)
                Else
                    '???? SISTEMARE E VEDERE SE SERVE
                    ''VERIFICO SE HO TROVATO UNA PALLETTA A CUI AGGIUNGERE IL MATERIALE (CASO MOLTO PARTICOLARE)
                    'If (Not clsEMFromJob.UbicazioneDestOnWork.GiacenzeCompatibiliAggiunta Is Nothing) Then
                    '    If (clsEMFromJob.UbicazioneDestOnWork.GiacenzeCompatibiliAggiunta.Length > 0) Then
                    '        If (clsUtility.IsStringValid(clsEMFromJob.UbicazioneDestOnWork.GiacenzeCompatibiliAggiunta(0).UbicazioneInfo.UnitaMagazzino, True) = True) Then
                    '            outUnitaMagDestDaConfermare = clsSapUtility.FormattaStringaUnitaMagazzino(clsEMFromJob.UbicazioneDestOnWork.GiacenzeCompatibiliAggiunta(0).UbicazioneInfo.UnitaMagazzino)
                    '        End If
                    '    End If
                    'End If
                End If
            End If


            GetEntrataMerceUnitaMagDaConfermare = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetEntrataMerceUnitaMagDaConfermare = 1000 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetJobcConfirmQtyProposal(ByRef outPickQtyProposal As Double, ByRef outPickSfusiQtyProposal As Double, ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim QtaResiduaDaPrelevare As Double = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetJobcConfirmQtyProposal = 0 'init


            'RECUPERO LA QTA ANCORA DA PRELEVARE PER LA MISSIONE
            If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDaPrelUdMAcq > clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna) Then
                QtaResiduaDaPrelevare = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDaPrelUdMAcq - clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna
            Else
                QtaResiduaDaPrelevare = 0
            End If

            outPickSfusiQtyProposal = 0
            If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaSfusiInPZ > clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataSfusi) Then
                outPickSfusiQtyProposal = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaSfusiInPZ - clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataSfusi
            End If

            '>>> VERIFICO SE HO IL LIMITE DELLA QTA DI PALLETIZZAZIONE
            If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet > 0) And (QtaResiduaDaPrelevare > clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet) Then
                outPickQtyProposal = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet
            Else
                outPickQtyProposal = QtaResiduaDaPrelevare
            End If


            GetJobcConfirmQtyProposal = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetJobcConfirmQtyProposal = 1000 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
End Class