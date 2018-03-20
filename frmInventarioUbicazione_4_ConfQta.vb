Imports clsSapWS
Imports clsNavigation
Imports clsBusinessLogic
Imports clsDataType
Imports System.Math

Public Class frmInventarioUbicazione_4_ConfQta

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmInventarioUbicazione_4_ConfQta"

    Private ErrDescription As String
    Private SapFunctionError As clsBusinessLogic.SapFunctionError


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmInventarioUbicazione_4_ConfQta_KeyPress(Me, e)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdAbortScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbortScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim UserAnswer As DialogResult = DialogResult.No
        Dim WorkString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            WorkString = clsAppTranslation.GetSingleParameterValue(282, "", "Si desidera veramente abbandonare la procedura ? (SI/NO)")
            UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                Exit Sub
            End If

            RetCode = clsNavigation.Show_Mnu_Main_Inventario(Me, True)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdPreviousScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreviousScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'PASSO ALLO VIDEATA DELLO STEP PRECEDENTE
            Call clsNavigation.Show_Ope_InventarioUbicazione(Me, clsInventarioUbicazione.InventoryType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdNextScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        Dim DatiRicercaUbicazione As clsDataType.SapWmUbicazione
        Dim InfoUbicazione As clsDataType.SapWmUbicazione
        Dim UserAnswer As DialogResult
        Dim OkEseguiOtInventario As Boolean = False
        Dim wkExitFormDone As Boolean = False
        Dim FlagErroreAttivo As Boolean
        Dim wkQtaConfermata As Double = 0
        Dim wkQtaSfusiConfermata As Double = 0
        Dim ValoreAssolutoQtOtDaInventario As Double
        Dim wkCodMotiviMov As String = ""
        Dim DeltaQtaTotaleConfermata As Double = 0
        Dim MaxQtaRettificabile As Double = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'VERIFICO SE LA QTA E' CORRETTA
            If (Me.txtQtaConfermata.Text = "") And (Me.txtQtaSfusiConfermata.Text = "") And (Me.txtQtaPezziConfermata.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(614, "", "Qtà Conteggiata non corretta.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.txtQtaConfermata.Focus()
                Exit Sub
            End If


            If (Me.txtQtaConfermata.Text <> "") Then
                If (Not (IsNumeric(Me.txtQtaConfermata.Text))) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(318, "", "Qtà Confermata non valida.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If


            If (Me.txtQtaSfusiConfermata.Text <> "") Then
                If (Not (IsNumeric(Me.txtQtaSfusiConfermata.Text))) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(318, "", "Qtà Confermata non valida.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If


            If (Me.txtQtaPezziConfermata.Text <> "") Then
                If (Not (IsNumeric(Me.txtQtaPezziConfermata.Text))) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(318, "", "Qtà Confermata non valida.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If


            'NECESSARIO PER EVENTUALI DECIMALI
            If (Me.txtQtaConfermata.Text <> "") Then
                wkQtaConfermata = System.Convert.ToDouble(Me.txtQtaConfermata.Text)
                If (wkQtaConfermata < 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(615, "", "La Qtà deve essere positiva.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            If (Me.txtQtaSfusiConfermata.Text <> "") Or (Me.txtQtaPezziConfermata.Text <> "") Then

                If (Me.txtQtaPrevistaSfusi.Text <> Me.txtQtaSfusiConfermata.Text) Then
                    wkQtaSfusiConfermata = System.Convert.ToDouble(Me.txtQtaSfusiConfermata.Text)
                End If

                If (Me.txtQtaPrevistaPezzi.Text <> Me.txtQtaPezziConfermata.Text) Then
                    wkQtaSfusiConfermata = System.Convert.ToDouble(Me.txtQtaPezziConfermata.Text) - System.Convert.ToDouble(Me.txtQtaPrevistaPezzi.Text)
                End If

                'If (wkQtaSfusiConfermata < 0) Then
                '    ErrDescription = clsAppTranslation.GetSingleParameterValue(615, "", "La Qtà deve essere positiva.")
                '    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                '    Exit Sub
                'End If
                '>>> SE HO MESSO LA QTA IN PEZZI NON PUO' ESSERE SUPERIORE AI PEZZI DI UNA SCATOLA
                If (clsInventarioUbicazione.MaterialeGiacenza.VarianteImballo.PezziPerScatola > 0) And (wkQtaSfusiConfermata >= clsInventarioUbicazione.MaterialeGiacenza.VarianteImballo.PezziPerScatola) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1755, "", "La Qtà SFUSI immessa deve essere inferore ai pezzi di una SCATOLA.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            'VERIFICO SE E' STATO SPECIFICATO UN MOTIVO MOVIMENTO 
            If (Me.txtQtaConfermata.Text <> Me.txtQtaInStock.Text) Or (Me.txtQtaSfusiConfermata.Text <> Me.txtQtaPrevistaSfusi.Text) Or (Me.txtQtaPezziConfermata.Text <> Me.txtQtaPrevistaPezzi.Text) Then
                wkCodMotiviMov = Me.txtNumMov.SelectedValue
                If (wkCodMotiviMov = "") Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1662, "", "Motivi Movimento non inseriti.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtNumMov.Focus()
                    Exit Sub
                End If
            End If


            'VERIFICO SE L'OPERATORE HA SPECIFICATO UNA MODIFICA DELLA QTA
            OkEseguiOtInventario = False
            clsInventarioUbicazione.QtOtDaInventario = 0 'INIT
            clsInventarioUbicazione.QtOtSfusiDaInventario = 0 'INIT

            Select Case clsInventarioUbicazione.InventoryType
                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUbicazione, clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUnitaMagazzino

                    '>>> CONTROLLO QTA UDM CONSEGNA
                    If (Int(clsInventarioUbicazione.MaterialeGiacenza.QtaTotaleLquaDispoUdMAcq) <> wkQtaConfermata) Then
                        If (clsInventarioUbicazione.ConfermataQtaConteggiata = False) Then
                            'NEL TRASFERIMENTO PER INVENTARIO SEGNALO LA GIACENZA DIVERSA MA L'OPERATORE PUO' FORZARE A PROSEGUIRE
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(607, "", "Qtà CONTEGGIATA diversa dallo stock.") & vbCrLf
                            ErrDescription = ErrDescription & clsAppTranslation.GetSingleParameterValue(608, "", "Proseguire con una rettifica ? (Si/No)")
                            UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                                Exit Sub
                            End If
                            clsInventarioUbicazione.ConfermataQtaConteggiata = True
                        End If
                        '>>>> OTTENGO LA DIFFERENZA TRA LA GIACENZA E LA QTA CONTEGGIATA
                        clsInventarioUbicazione.QtOtDaInventario = wkQtaConfermata - Int(clsInventarioUbicazione.MaterialeGiacenza.QtaTotaleLquaDispoUdMAcq)
                        OkEseguiOtInventario = True
                    End If

                    '>>> CONTROLLO QTA SFUSI UDM PEZZO
                    If (Int(clsInventarioUbicazione.MaterialeGiacenza.QtaTotaleInStockSfusi) <> wkQtaSfusiConfermata) And (Me.txtQtaSfusiConfermata.Text <> "") Then
                        If (clsInventarioUbicazione.ConfermataQtaSfusiConteggiata = False) Then
                            'NEL TRASFERIMENTO PER INVENTARIO SEGNALO LA GIACENZA DIVERSA MA L'OPERATORE PUO' FORZARE A PROSEGUIRE
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(1756, "", "Qtà SFUSI CONTEGGIATA diversa dallo stock.") & vbCrLf
                            ErrDescription = ErrDescription & clsAppTranslation.GetSingleParameterValue(608, "", "Proseguire con una rettifica ? (Si/No)")
                            UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                                Exit Sub
                            End If
                            clsInventarioUbicazione.ConfermataQtaSfusiConteggiata = True
                        End If
                        '>>>> OTTENGO LA DIFFERENZA TRA LA GIACENZA E LA QTA CONTEGGIATA
                        clsInventarioUbicazione.QtOtSfusiDaInventario = wkQtaSfusiConfermata '- Int(clsInventarioUbicazione.MaterialeGiacenza.QtaTotaleInStockSfusi)
                        OkEseguiOtInventario = True
                    End If

                    '>>> CONTROLLO QTA PEZZI UDM PEZZO
                    If (Int(clsInventarioUbicazione.MaterialeGiacenza.QtaTotaleLquaDisponibile) <> wkQtaSfusiConfermata) And (Me.txtQtaPezziConfermata.Text <> "") Then
                        If (clsInventarioUbicazione.ConfermataQtaSfusiConteggiata = False) Then
                            'NEL TRASFERIMENTO PER INVENTARIO SEGNALO LA GIACENZA DIVERSA MA L'OPERATORE PUO' FORZARE A PROSEGUIRE
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(1756, "", "Qtà SFUSI CONTEGGIATA diversa dallo stock.") & vbCrLf
                            ErrDescription = ErrDescription & clsAppTranslation.GetSingleParameterValue(608, "", "Proseguire con una rettifica ? (Si/No)")
                            UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                                Exit Sub
                            End If
                            clsInventarioUbicazione.ConfermataQtaSfusiConteggiata = True
                        End If
                        '>>>> OTTENGO LA DIFFERENZA TRA LA GIACENZA E LA QTA CONTEGGIATA
                        clsInventarioUbicazione.QtOtSfusiDaInventario = wkQtaSfusiConfermata '- Int(clsInventarioUbicazione.MaterialeGiacenza.QtaTotaleInStockSfusi)
                        OkEseguiOtInventario = True
                    End If


                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeRottamazione
                    If (clsInventarioUbicazione.ConfermataQtaConteggiata = False) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(609, "", "E' stata inserire una QTA da ROTTAMARE.") & vbCrLf
                        ErrDescription = ErrDescription & clsAppTranslation.GetSingleParameterValue(608, "", "Proseguire con una rettifica ? (Si/No)")
                        UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                            Exit Sub
                        End If
                        clsInventarioUbicazione.ConfermataQtaConteggiata = True
                    End If
                    clsInventarioUbicazione.QtOtDaInventario = wkQtaConfermata
                    OkEseguiOtInventario = True
                Case Else
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(599, "", "Tipo Inventario non corretto.(InventoryType)")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
            End Select


            '*********************************************************************************************
            '>>> VERIFICO SE SONO IMPOSTATI DEI LIMITI SUL NUMERO MASSIMO DI MODIFICHE CHE SI POSSONO FARE
            '*********************************************************************************************
            ValoreAssolutoQtOtDaInventario = Abs(clsInventarioUbicazione.QtOtDaInventario)
            Select Case clsInventarioUbicazione.InventoryType
                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUbicazione
                    If (clsInventarioUbicazione.MaterialeGiacenza.UnitaDiMisuraAcquisizione = clsInventarioUbicazione.MaterialeGiacenza.UnitaDiMisuraPezzo) And (clsInventarioUbicazione.MaterialeGiacenza.VarianteImballo.PezziPerScatola > 0) Then
                        'CASO IN CUI LA QTA E' IN PEZZI  PER CUI VA MOLTIPLICATA PER I PEZZI PER SCATOLA
                        MaxQtaRettificabile = Default_Inventario_Ubi_Max_Qty_Change * clsInventarioUbicazione.MaterialeGiacenza.VarianteImballo.PezziPerScatola
                    Else
                        MaxQtaRettificabile = Default_Inventario_Ubi_Max_Qty_Change
                    End If
                    If (MaxQtaRettificabile > 0) And (ValoreAssolutoQtOtDaInventario > MaxQtaRettificabile) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(616, "", "Attenzione! La QTA massima modificabile è di:") & Trim(Str(MaxQtaRettificabile)) & " " & Me.txtUDMQuantità.Text & vbCrLf & clsAppTranslation.GetSingleParameterValue(617, "", ".Verificare i dati immessi e riprovare.")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUnitaMagazzino
                    If (clsInventarioUbicazione.MaterialeGiacenza.UnitaDiMisuraAcquisizione = clsInventarioUbicazione.MaterialeGiacenza.UnitaDiMisuraPezzo) And (clsInventarioUbicazione.MaterialeGiacenza.VarianteImballo.PezziPerScatola > 0) Then
                        'CASO IN CUI LA QTA E' IN PEZZI  PER CUI VA MOLTIPLICATA PER I PEZZI PER SCATOLA
                        MaxQtaRettificabile = Default_Inventario_UbiUM_Max_Qty_Change * clsInventarioUbicazione.MaterialeGiacenza.VarianteImballo.PezziPerScatola
                    Else
                        MaxQtaRettificabile = Default_Inventario_UbiUM_Max_Qty_Change
                    End If
                    If (MaxQtaRettificabile > 0) And (ValoreAssolutoQtOtDaInventario > MaxQtaRettificabile) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(616, "", "Attenzione! La QTA massima modificabile è di:") & Trim(Str(MaxQtaRettificabile)) & " " & Me.txtUDMQuantità.Text & vbCrLf & clsAppTranslation.GetSingleParameterValue(617, "", ".Verificare i dati immessi e riprovare.")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeRottamazione
                    If (clsInventarioUbicazione.MaterialeGiacenza.UnitaDiMisuraAcquisizione = clsInventarioUbicazione.MaterialeGiacenza.UnitaDiMisuraPezzo) And (clsInventarioUbicazione.MaterialeGiacenza.VarianteImballo.PezziPerScatola > 0) Then
                        'CASO IN CUI LA QTA E' IN PEZZI  PER CUI VA MOLTIPLICATA PER I PEZZI PER SCATOLA
                        MaxQtaRettificabile = Default_Inventario_Rottama_Max_Qty_Change * clsInventarioUbicazione.MaterialeGiacenza.VarianteImballo.PezziPerScatola
                    Else
                        MaxQtaRettificabile = Default_Inventario_Rottama_Max_Qty_Change
                    End If
                    If (MaxQtaRettificabile > 0) And (ValoreAssolutoQtOtDaInventario > MaxQtaRettificabile) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(616, "", "Attenzione! La QTA massima modificabile è di:") & Trim(Str(MaxQtaRettificabile)) & " " & Me.txtUDMQuantità.Text & vbCrLf & clsAppTranslation.GetSingleParameterValue(617, "", ".Verificare i dati immessi e riprovare.")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeCentroCosto
                    If (clsInventarioUbicazione.MaterialeGiacenza.UnitaDiMisuraAcquisizione = clsInventarioUbicazione.MaterialeGiacenza.UnitaDiMisuraPezzo) And (clsInventarioUbicazione.MaterialeGiacenza.VarianteImballo.PezziPerScatola > 0) Then
                        'CASO IN CUI LA QTA E' IN PEZZI  PER CUI VA MOLTIPLICATA PER I PEZZI PER SCATOLA
                        MaxQtaRettificabile = Default_Inventario_CentroCosto_Max_Qty_Change * clsInventarioUbicazione.MaterialeGiacenza.VarianteImballo.PezziPerScatola
                    Else
                        MaxQtaRettificabile = Default_Inventario_CentroCosto_Max_Qty_Change
                    End If
                    If (MaxQtaRettificabile > 0) And (ValoreAssolutoQtOtDaInventario > MaxQtaRettificabile) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(616, "", "Attenzione! La QTA massima modificabile è di:") & Trim(Str(MaxQtaRettificabile)) & " " & Me.txtUDMQuantità.Text & vbCrLf & clsAppTranslation.GetSingleParameterValue(617, "", ".Verificare i dati immessi e riprovare.")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
            End Select

            '*************************************************************************************************************************************
            '>>> IN BASE ALLE QTA CONFERMATE DETERMINO SE HO UN INVENTARIO POSITIVO O NEGATIVO E OTTENGO UNA UNICA QTA  SE HO SEGNI DIFFERENTI
            '*************************************************************************************************************************************
            clsInventarioUbicazione.MovimentoPositivo = False
            Select Case clsInventarioUbicazione.InventoryType
                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUbicazione, clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUnitaMagazzino
                    If (clsInventarioUbicazione.MaterialeGiacenza.UnitaDiMisuraAcquisizione <> clsInventarioUbicazione.MaterialeGiacenza.UnitaDiMisuraPezzo) And (clsInventarioUbicazione.MaterialeGiacenza.VarianteImballo.PezziPerScatola > 0) Then
                        'CASO IN CUI HO PEZZI PER SCATOLA
                        DeltaQtaTotaleConfermata = (clsInventarioUbicazione.QtOtDaInventario * clsInventarioUbicazione.MaterialeGiacenza.VarianteImballo.PezziPerScatola) + clsInventarioUbicazione.QtOtSfusiDaInventario
                    Else
                        DeltaQtaTotaleConfermata = clsInventarioUbicazione.QtOtDaInventario + clsInventarioUbicazione.QtOtSfusiDaInventario
                    End If
                    If (DeltaQtaTotaleConfermata > 0) Then
                        clsInventarioUbicazione.MovimentoPositivo = True 'CASO DI RETTIFICA POSITIVA
                    End If
                    'NEL CASO CHE HO ENTRAMBE LE QTA IMPOSTATE DEVO OTTENERE UNA UNICA QTA IN PEZZI
                    If (clsInventarioUbicazione.QtOtDaInventario <> 0) And (clsInventarioUbicazione.QtOtSfusiDaInventario <> 0) Then
                        clsInventarioUbicazione.QtOtDaInventario = 0
                        clsInventarioUbicazione.QtOtSfusiDaInventario = DeltaQtaTotaleConfermata
                    End If
                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeRottamazione
                    clsInventarioUbicazione.MovimentoPositivo = False 'NON USATO IN QUESTO TIPO DI INVENTARIO
            End Select


            If (OkEseguiOtInventario = True) Then
                If (Me.txtQtaConfermata.Text = Me.txtQtaInStock.Text) And (Me.txtQtaSfusiConfermata.Text = Me.txtQtaPrevistaSfusi.Text) And (Me.txtQtaPezziConfermata.Text = Me.txtQtaSfusiConfermata.Text) Then
                    'MANDO IL MESSAGGIO CHE AVVISA OPERATORE DI S
                    '>>>> SEGNALO CHE NON SI ESEGUE NESSUNA OPERAZIONE ESEGUITA
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(618, "", "ATTENZIONE!!! Nessuna rettifica eseguita.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(619, "", "Nessuna giacenza modificata.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            If (Me.txtQtaPrevistaPezzi.Text <> Me.txtQtaPezziConfermata.Text) And (clsInventarioUbicazione.InventoryType = clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeRottamazione) Then
                clsInventarioUbicazione.QtOtSfusiDaInventario = Me.txtQtaPezziConfermata.Text
                OkEseguiOtInventario = True
            End If


            '***************************************************************************************
            '>>> SE HO CONFERMATO LE QTA NON DEVO ESEGUIRE NESSUN CAMBIAMENTO
            '***************************************************************************************
            If (OkEseguiOtInventario <> True) And (clsInventarioUbicazione.QtOtDaInventario = 0) And (clsInventarioUbicazione.QtOtSfusiDaInventario = 0) Then
                '>>> CASO DI NESSUNA MODIFICA DI QTA DICHIARATA ( NESSUNA OPERAZIONE DA FARE A SISTEMA )

                '>>> CHIEDO AD OPERATORE SE VUOLE PROSEGUIRE L'INVENTARIO DELLO STESSO OGGETTO
                RetCode = clsInventarioUbicazione.AskExecuteOtherInventorySameLocation(Me, wkExitFormDone)
                If (wkExitFormDone = True) Then
                    Exit Sub
                End If
            End If

            '*********************************************************************************************************
            '>>> ESEGUO TRASFERIMENTO PER L'INVENTARIO
            '*********************************************************************************************************
            If (OkEseguiOtInventario = True) And ((clsInventarioUbicazione.QtOtDaInventario <> 0) Or (clsInventarioUbicazione.QtOtSfusiDaInventario <> 0)) Then
                RetCode = clsInventarioUbicazione.ExecTrasferimentoPerInventario(Me, wkCodMotiviMov, True, FlagErroreAttivo, ErrDescription)
            End If
            '**************************************************************************************************************
            '**************************************************************************************************************


            '************************************************************************************************
            '>>> SE HO AVUTO UN ERRORE VISUALIZZO UNA MESSAGE BOX PER RICHIEDERE SE RIPROVARE
            '************************************************************************************************
            If (FlagErroreAttivo = True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(468, "", "Si è verificato un errore si desidera abbandonare ? (Si / No )")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                    '>>> DEVO RIPORTARE IL FOCUS SULLA FINESTRA, MA OCCORRE RICARICARLA
                    System.Windows.Forms.Application.DoEvents()
                    Me.Close()
                    System.Windows.Forms.Application.DoEvents()
                    frmInventarioUbicazione_4_ConfQtaForm = New frmInventarioUbicazione_4_ConfQta
                    frmInventarioUbicazione_4_ConfQtaForm.Show()
                    frmInventarioUbicazione_4_ConfQtaForm.cmdNextScreen.Focus()
                    Exit Sub
                End If
            End If

            '******************************************************************************************
            '>>> CHIEDO AD OPERATORE SE VUOLE PROSEGUIRE L'INVENTARIO DELLO STESSO OGGETTO
            '******************************************************************************************
            RetCode = clsInventarioUbicazione.AskExecuteOtherInventorySameLocation(Me, wkExitFormDone)
            If (wkExitFormDone = True) Then
                Exit Sub
            End If


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmInventarioUbicazione_4_ConfQta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtQtaConfermata.Focused = True) And (Me.txtQtaConfermata.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtQtaConfermata.Text = UCase(Me.txtQtaConfermata.Text)
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdNextScreen_Click(Me, e)
                    Exit Sub
                End If
            End If

            If ((Me.cmdNextScreen.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdNextScreen_Click(Me, e)
                    Exit Sub
                End If
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmInventarioUbicazione_4_ConfQta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        Dim EnableGestioneSfusi As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            hook.Start(Me)
#End If

            '**************************************
            'Traduzioni
            'Me.lblQtaInStock.Text = clsAppTranslation.GetSingleParameterValue(67, lblQtaInStock.Text, "Qta Prev.")
            Me.lblQtaInStock.Text = clsAppTranslation.GetSingleParameterValue(1733, lblQtaInStock.Text, "Qta A Sistema")
            Me.lblQtaConfermata.Text = clsAppTranslation.GetSingleParameterValue(129, lblQtaConfermata.Text, "Qta Confermata")
            Me.lblUDMQuantita.Text = clsAppTranslation.GetSingleParameterValue(69, lblUDMQuantita.Text, "Udm")
            Me.Text = clsAppTranslation.GetSingleParameterValue(128, Me.Text, "Invent.Ubicazione (4)")
            Me.cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            Me.lblNumMov.Text = clsAppTranslation.GetSingleParameterValue(1687, lblNumMov.Text, "Motivo Movimento")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
			cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdNextScreen.Text, ">")
#Else
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, cmdNextScreen.Text, ">")
#End If

            '**************************************  


            'VISUALIZZO INFO DATI GIACENZA
            Me.txtInfoJobSelezionato.Text = clsInventarioUbicazione.FromInventarioStructsToString(0)

            Me.txtQtaInStock.Text = Int(clsInventarioUbicazione.MaterialeGiacenza.QtaTotaleLquaInStockUdMAcq)
            Me.txtUDMQuantità.Text = clsInventarioUbicazione.MaterialeGiacenza.UnitaDiMisuraAcquisizione

            Select Case clsInventarioUbicazione.InventoryType
                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUbicazione
                    Me.Text = clsAppTranslation.GetSingleParameterValue(128, Me.Text, "Invent.Ubicazione (4)")
                    Me.lblQtaConfermata.Text = clsAppTranslation.GetSingleParameterValue(620, "", "Qtà Conteggiata")
                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeRottamazione
                    Me.Text = clsAppTranslation.GetSingleParameterValue(621, "", "Invent.Rottamazione (4)")
                    Me.lblQtaConfermata.Text = clsAppTranslation.GetSingleParameterValue(598, "", "Qtà Rottamata")
                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUnitaMagazzino
                    Me.Text = clsAppTranslation.GetSingleParameterValue(126, "", "Invent.Unità Mag. (4)")
                    Me.lblQtaConfermata.Text = clsAppTranslation.GetSingleParameterValue(620, "", "Qtà Conteggiata")
                Case Else
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(599, "", "Tipo Inventario non corretto.(InventoryType)")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
            End Select

            If (clsInventarioUbicazione.MaterialeGiacenza.QuantitaConfermataOperatore > 0) Then
                Me.txtQtaConfermata.Text = Int(clsInventarioUbicazione.MaterialeGiacenza.QuantitaConfermataOperatore)
            End If

            'SE HO UN DECIMALE NELLA QTA ALLORA DEVO ABILITARE LA GESTIONE DELLA CASELLA "SFUSI"
            If (clsInventarioUbicazione.MaterialeGiacenza.QtaTotaleInStockSfusi > 0) And (clsInventarioUbicazione.MaterialeGiacenza.UnitaDiMisuraAcquisizione <> clsInventarioUbicazione.MaterialeGiacenza.UnitaDiMisuraPezzo) Then
                EnableGestioneSfusi = True
            End If


            'Check Visibilità campi

            If (clsInventarioUbicazione.MaterialeGiacenza.ZGestione_PZ_Attiva <> "X") Then

                Me.txtQtaInStock.Visible = True
                Me.txtUDMQuantità.Visible = True
                Me.txtQtaConfermata.Visible = True

                If (EnableGestioneSfusi = True) Then

                    Me.txtQtaPrevistaSfusi.Visible = True
                    Me.txtQtaPrevistaSfusi.Text = Int(clsInventarioUbicazione.MaterialeGiacenza.QtaTotaleInStockSfusi)

                    Me.txtUDMQuantitaSfusi.Visible = True
                    Me.txtUDMQuantitaSfusi.Text = clsInventarioUbicazione.MaterialeGiacenza.UnitaDiMisuraPezzo

                    Me.txtQtaSfusiConfermata.Visible = True
                    Me.txtQtaSfusiConfermata.Text = Int(clsInventarioUbicazione.MaterialeGiacenza.QtaTotaleInStockSfusi)

                End If

                Me.txtQtaPrevistaPezzi.Visible = False
                Me.txtUDMQuantitaPezzi.Visible = False
                Me.txtQtaPezziConfermata.Visible = False

            Else

                Me.txtQtaInStock.Visible = False
                Me.txtUDMQuantità.Visible = False
                Me.txtQtaConfermata.Visible = False

                Me.txtQtaPrevistaSfusi.Visible = False
                Me.txtUDMQuantitaSfusi.Visible = False
                Me.txtQtaSfusiConfermata.Visible = False

                Me.txtQtaPrevistaPezzi.Visible = True
                Me.txtUDMQuantitaPezzi.Visible = True
                Me.txtQtaPezziConfermata.Visible = True

                Me.txtQtaPrevistaPezzi.Text = Int(clsInventarioUbicazione.MaterialeGiacenza.QtaTotaleInStockInUdmPZ)
                Me.txtUDMQuantitaPezzi.Text = clsInventarioUbicazione.MaterialeGiacenza.UnitaDiMisuraPezzo
                Me.txtQtaPezziConfermata.Text = Int(clsInventarioUbicazione.MaterialeGiacenza.QtaTotaleInStockInUdmPZ)

            End If



            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)


            Me.txtQtaConfermata.Focus()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Public Shared Function SetComboBoxElement(txtNumMov As ComboBox, CodMotMovimneto As String) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim GetOk As Boolean = False
        Dim ErrDescription As String = ""
        Dim SapFunctionError As New clsBusinessLogic.SapFunctionError
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            SetComboBoxElement = 0

            'CHIAMO RFC PER VALORIZZARE LA COMBO "MOTIVI MOVIMENTO"
            RetCode = clsSapWS.Call_ZMB_GET_T157E_MOT_MOVIMENTI(CodMotMovimneto, clsUser.GetUserDivisionToUse(), clsUser.SapWmsUser.LANGUAGE, GetOk, clsInfoMotiviMov.objDataTableMotiviMovInfo, SapFunctionError, False)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(554, "", "Nessun dato trovato.Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If


            If clsInfoMotiviMov.objDataTableMotiviMovInfo.Rows.Count > 0 Then
                txtNumMov.ValueMember = "GRUND"
                txtNumMov.DisplayMember = "GRTXT"
                txtNumMov.DataSource = clsInfoMotiviMov.objDataTableMotiviMovInfo
            End If


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            SetComboBoxElement = 100
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Private Sub txtNumMov_DropDown(sender As Object, e As EventArgs) Handles txtNumMov.DropDown
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim CodMotMovimneto As String = ""
        Dim wkQtaConfermata As Double = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            Select Case clsInventarioUbicazione.InventoryType
                Case (clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUbicazione), (clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUnitaMagazzino)


                    'VERIFICO SE LA QTA E' CORRETTA
                    If (Me.txtQtaConfermata.Text <> Me.txtQtaInStock.Text) Then

                        If (Me.txtQtaConfermata.Text = "") Then
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(614, "", "Qtà Conteggiata non corretta.")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            Me.txtQtaConfermata.Focus()
                            Exit Sub
                        End If

                        If (Not (IsNumeric(Me.txtQtaConfermata.Text))) Then
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(318, "", "Qtà Confermata non valida.")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If

                        'NECESSARIO PER EVENTUALI DECIMALI
                        wkQtaConfermata = System.Convert.ToDouble(Me.txtQtaConfermata.Text)
                        If (wkQtaConfermata < 0) Then
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(615, "", "La Qtà deve essere positiva.")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If


                        'Determino Tipo di rettifica
                        If Val(txtQtaInStock.Text) < Val(txtQtaConfermata.Text) Then
                            'Rettifica Positiva

                            'Valorizzo gli elementi della ComboBox MotivMovimenti
                            RetCode = SetComboBoxElement(Me.txtNumMov, Default_Inventario_TipoMov_RettificaPositiva)

                        Else
                            'Rettifica Negativa

                            'Valorizzo gli elementi della ComboBox MotivMovimenti
                            RetCode = SetComboBoxElement(Me.txtNumMov, Default_Inventario_TipoMov_RettificaNegativa)

                        End If

                    End If



                    'VERIFICO SE LA QTA SFUSI E' CORRETTA
                    If (Me.txtQtaSfusiConfermata.Text <> Me.txtQtaPrevistaSfusi.Text) Then

                        If (Me.txtQtaSfusiConfermata.Text = "") Then
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(614, "", "Qtà Conteggiata non corretta.")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            Me.txtQtaConfermata.Focus()
                            Exit Sub
                        End If

                        If (Not (IsNumeric(Me.txtQtaSfusiConfermata.Text))) Then
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(318, "", "Qtà Confermata non valida.")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If

                        'NECESSARIO PER EVENTUALI DECIMALI
                        wkQtaConfermata = System.Convert.ToDouble(Me.txtQtaSfusiConfermata.Text)
                        If (wkQtaConfermata < 0) Then
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(615, "", "La Qtà deve essere positiva.")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If


                        'Determino Tipo di rettifica
                        If Val(Me.txtQtaPrevistaSfusi.Text) < Val(Me.txtQtaSfusiConfermata.Text) Then
                            'Rettifica Positiva

                            'Valorizzo gli elementi della ComboBox MotivMovimenti
                            RetCode = SetComboBoxElement(Me.txtNumMov, Default_Inventario_TipoMov_RettificaPositiva)

                        Else
                            'Rettifica Negativa

                            'Valorizzo gli elementi della ComboBox MotivMovimenti
                            RetCode = SetComboBoxElement(Me.txtNumMov, Default_Inventario_TipoMov_RettificaNegativa)

                        End If

                    End If



                    'VERIFICO SE LA QTA PEZZI E' CORRETTA
                    If (Me.txtQtaPezziConfermata.Text <> Me.txtQtaPrevistaPezzi.Text) Then

                        If (Me.txtQtaPezziConfermata.Text = "") Then
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(614, "", "Qtà Conteggiata non corretta.")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            Me.txtQtaConfermata.Focus()
                            Exit Sub
                        End If

                        If (Not (IsNumeric(Me.txtQtaPezziConfermata.Text))) Then
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(318, "", "Qtà Confermata non valida.")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If

                        'NECESSARIO PER EVENTUALI DECIMALI
                        wkQtaConfermata = System.Convert.ToDouble(Me.txtQtaPezziConfermata.Text)
                        If (wkQtaConfermata < 0) Then
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(615, "", "La Qtà deve essere positiva.")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If


                        'Determino Tipo di rettifica
                        If Val(Me.txtQtaPrevistaPezzi.Text) < Val(Me.txtQtaPezziConfermata.Text) Then
                            'Rettifica Positiva

                            'Valorizzo gli elementi della ComboBox MotivMovimenti
                            RetCode = SetComboBoxElement(Me.txtNumMov, Default_Inventario_TipoMov_RettificaPositiva)

                        Else
                            'Rettifica Negativa

                            'Valorizzo gli elementi della ComboBox MotivMovimenti
                            RetCode = SetComboBoxElement(Me.txtNumMov, Default_Inventario_TipoMov_RettificaNegativa)

                        End If

                    End If


                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeRottamazione
                    Me.Text = clsAppTranslation.GetSingleParameterValue(621, "", "Invent.Rottamazione (4)")
                    Me.lblQtaConfermata.Text = clsAppTranslation.GetSingleParameterValue(598, "", "Qtà Rottamata")
                    Me.lblQtaInStock.Text = clsAppTranslation.GetSingleParameterValue(126, "", "Qta Stock")

                    'Valorizzo gli elementi della ComboBox MotivMovimenti
                    RetCode = SetComboBoxElement(Me.txtNumMov, Default_Inventario_TipoMov_Rottamazione)

                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUnitaMagazzino
                    Me.Text = clsAppTranslation.GetSingleParameterValue(126, "", "Invent.Unità Mag. (4)")
                    Me.lblQtaConfermata.Text = clsAppTranslation.GetSingleParameterValue(620, "", "Qtà Conteggiata")
                    Me.lblQtaInStock.Text = clsAppTranslation.GetSingleParameterValue(67, "", "Qta Prev.")

                Case Else
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(599, "", "Tipo Inventario non corretto.(InventoryType)")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
            End Select


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

End Class