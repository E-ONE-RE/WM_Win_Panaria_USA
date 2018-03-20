Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility


Public Class frmInfoGiacenze_3_List

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmInfoGiacenze_3_List"

    Private ErrDescription As String
    Private QtyForUserActiveRow As String
    Private LocationQtyForUserActiveRow As String
    Private LocationCapacityForUserActiveRow As String
    Private ItemDescriptionActiveRow As String


    Public Sub New()
        InitializeComponent()

        Try

            'Dim dataGridTableStyle1 As New System.Windows.Forms.DataGridTableStyle
            'dataGridTableStyle1.MappingName = "MyDataSource"
            'DtGridShowInfo.TableStyles.Add(dataGridTableStyle1)


            ''Formatto le Colonne
            'ZFLAG_UDSColumn.MappingName = "ZFLAG_UDS"
            'ZFLAG_UDSColumn.HeaderText = clsAppTranslation.GetSingleParameterValue(1195, "", "S")
            'ZFLAG_UDSColumn.Width = DefDtGridCol_FlagUDS
            'dataGridTableStyle1.GridColumnStyles.Add(ZFLAG_UDSColumn)
            'AddHandler ZFLAG_UDSColumn.SetCellFormat, AddressOf ColumnSetCellFormat

            'LGTYPColumn.MappingName = "LGTYP"
            'LGTYPColumn.HeaderText = clsAppTranslation.GetSingleParameterValue(304, "", "Tipo")
            'LGTYPColumn.Width = DefDtGridCol_TipoMagazzino + 20
            'dataGridTableStyle1.GridColumnStyles.Add(LGTYPColumn)
            'AddHandler LGTYPColumn.SetCellFormat, AddressOf ColumnSetCellFormat

            'LGPLAColumn.MappingName = "LGPLA"
            'LGPLAColumn.HeaderText = clsAppTranslation.GetSingleParameterValue(305, "", "Ubica.")
            'LGPLAColumn.Width = DefDtGridCol_Ubicazione
            'dataGridTableStyle1.GridColumnStyles.Add(LGPLAColumn)
            'AddHandler LGPLAColumn.SetCellFormat, AddressOf ColumnSetCellFormat

            'MATNRColumn.MappingName = "MATNR"
            'MATNRColumn.HeaderText = clsAppTranslation.GetSingleParameterValue(243, "", "Mat.")
            'MATNRColumn.Width = DefDtGridCol_DescrMateriale - 90
            'dataGridTableStyle1.GridColumnStyles.Add(MATNRColumn)
            'AddHandler MATNRColumn.SetCellFormat, AddressOf ColumnSetCellFormat

            'CHARGColumn.MappingName = "CHARG"
            'CHARGColumn.HeaderText = clsAppTranslation.GetSingleParameterValue(307, "", "Partita")
            'CHARGColumn.Width = DefDtGridCol_PartitaMateriale - 20
            'dataGridTableStyle1.GridColumnStyles.Add(CHARGColumn)
            'AddHandler CHARGColumn.SetCellFormat, AddressOf ColumnSetCellFormat


            'GESME_QTY_USERColumn.MappingName = "GESME_QTY_USER"
            'GESME_QTY_USERColumn.HeaderText = clsAppTranslation.GetSingleParameterValue(1585, "", "Qtà Tot.(PL/CT/PZ)")
            'GESME_QTY_USERColumn.Width = DefDtGridCol_QtaTotale + 60
            'dataGridTableStyle1.GridColumnStyles.Add(GESME_QTY_USERColumn)
            'AddHandler GESME_QTY_USERColumn.SetCellFormat, AddressOf ColumnSetCellFormat

            ''VERME_QTY_USERColumn.MappingName = "VERME_QTY_USER"
            ''VERME_QTY_USERColumn.HeaderText = clsAppTranslation.GetSingleParameterValue(-1, "", "Qty VERME User")
            ''VERME_QTY_USERColumn.Width = DefDtGridCol_QtaDisponibile
            ''dataGridTableStyle1.GridColumnStyles.Add(VERME_QTY_USERColumn)
            ''AddHandler VERME_QTY_USERColumn.SetCellFormat, AddressOf ColumnSetCellFormat


            'VRKMEColumn.MappingName = "VRKME"
            'VRKMEColumn.HeaderText = clsAppTranslation.GetSingleParameterValue(309, "", "UdM(Cons)")
            'VRKMEColumn.Width = DefDtGridCol_UnitaDiMisura - 75
            'dataGridTableStyle1.GridColumnStyles.Add(VRKMEColumn)
            'AddHandler VRKMEColumn.SetCellFormat, AddressOf ColumnSetCellFormat

            'GESME_CONSColumn.MappingName = "GESME_CONS"
            'GESME_CONSColumn.HeaderText = clsAppTranslation.GetSingleParameterValue(310, "", "Q.Tot.(Cons)")
            'GESME_CONSColumn.Width = DefDtGridCol_QtaTotale - 100
            'dataGridTableStyle1.GridColumnStyles.Add(GESME_CONSColumn)
            'AddHandler GESME_CONSColumn.SetCellFormat, AddressOf ColumnSetCellFormat

            'VERME_CONSColumn.MappingName = "VERME_CONS"
            'VERME_CONSColumn.HeaderText = clsAppTranslation.GetSingleParameterValue(311, "", "Q.Disp.(Cons)")
            'VERME_CONSColumn.Width = DefDtGridCol_QtaDisponibile - 100
            'dataGridTableStyle1.GridColumnStyles.Add(VERME_CONSColumn)
            'AddHandler VERME_CONSColumn.SetCellFormat, AddressOf ColumnSetCellFormat

            'BESTQColumn.MappingName = "BESTQ"
            'BESTQColumn.HeaderText = clsAppTranslation.GetSingleParameterValue(558, "", "T.St.")
            'BESTQColumn.Width = DefDtGridCol_TipoStock - 70
            'dataGridTableStyle1.GridColumnStyles.Add(BESTQColumn)
            'AddHandler BESTQColumn.SetCellFormat, AddressOf ColumnSetCellFormat

            'LENUMColumn.MappingName = "LENUM"
            'LENUMColumn.HeaderText = clsAppTranslation.GetSingleParameterValue(315, "", "Unità Magazzino")
            'LENUMColumn.Width = DefDtGridCol_UnitaMagazzino - 50
            'dataGridTableStyle1.GridColumnStyles.Add(LENUMColumn)
            'AddHandler LENUMColumn.SetCellFormat, AddressOf ColumnSetCellFormat

            'SONUMColumn.MappingName = "SONUM"
            'SONUMColumn.HeaderText = clsAppTranslation.GetSingleParameterValue(316, "", "Num.Stock spec.")
            'SONUMColumn.Width = DefDtGridCol_UnitaMagazzino - 20
            'dataGridTableStyle1.GridColumnStyles.Add(SONUMColumn)
            'AddHandler SONUMColumn.SetCellFormat, AddressOf ColumnSetCellFormat

            'MAKTGColumn.MappingName = "MAKTG"
            'MAKTGColumn.HeaderText = clsAppTranslation.GetSingleParameterValue(368, "", "Descr.Mat.")
            'MAKTGColumn.Width = DefDtGridCol_DescrMateriale
            'dataGridTableStyle1.GridColumnStyles.Add(MAKTGColumn)
            'AddHandler MAKTGColumn.SetCellFormat, AddressOf ColumnSetCellFormat


            'ZZCDLEGACYColumn.MappingName = "ZZCDLEGACY"
            'ZZCDLEGACYColumn.HeaderText = clsAppTranslation.GetSingleParameterValue(1647, "", "Legacy")
            'ZZCDLEGACYColumn.Width = DefDtGridCol_DescrMateriale - 70
            'dataGridTableStyle1.GridColumnStyles.Add(ZZCDLEGACYColumn)
            'AddHandler ZZCDLEGACYColumn.SetCellFormat, AddressOf ColumnSetCellFormat


            'If clsUser.SapWmsUser.LANGUAGE = "I" Then

            '    GESME_M2Column.MappingName = "GESME_M2"
            '    GESME_M2Column.HeaderText = clsAppTranslation.GetSingleParameterValue(1712, "", "Qtà M2")
            '    GESME_M2Column.Width = DefDtGridCol_QtaTotale - 50
            '    dataGridTableStyle1.GridColumnStyles.Add(GESME_M2Column)
            '    AddHandler GESME_M2Column.SetCellFormat, AddressOf ColumnSetCellFormat

            '    MEINS_M2Column.MappingName = "MEINS_M2"
            '    MEINS_M2Column.HeaderText = clsAppTranslation.GetSingleParameterValue(1713, "", "Udm M2")
            '    MEINS_M2Column.Width = DefDtGridCol_UnitaDiMisura - 30
            '    dataGridTableStyle1.GridColumnStyles.Add(MEINS_M2Column)
            '    AddHandler MEINS_M2Column.SetCellFormat, AddressOf ColumnSetCellFormat

            'Else

            '    GESME_SQFColumn.MappingName = "GESME_SQF"
            '    GESME_SQFColumn.HeaderText = clsAppTranslation.GetSingleParameterValue(1714, "", "Qtà SF")
            '    GESME_SQFColumn.Width = DefDtGridCol_QtaTotale - 50
            '    dataGridTableStyle1.GridColumnStyles.Add(GESME_SQFColumn)
            '    AddHandler GESME_SQFColumn.SetCellFormat, AddressOf ColumnSetCellFormat

            '    MEINS_SQFColumn.MappingName = "MEINS_SQF"
            '    MEINS_SQFColumn.HeaderText = clsAppTranslation.GetSingleParameterValue(1715, "", "Udm SF")
            '    MEINS_SQFColumn.Width = DefDtGridCol_UnitaDiMisura - 30
            '    dataGridTableStyle1.GridColumnStyles.Add(MEINS_SQFColumn)
            '    AddHandler MEINS_SQFColumn.SetCellFormat, AddressOf ColumnSetCellFormat

            'End If


            'LAGP_LKAPVColumn.MappingName = "LAGP_LKAPV"
            'LAGP_LKAPVColumn.HeaderText = clsAppTranslation.GetSingleParameterValue(1581, "", "Cap. Ubi.")
            'LAGP_LKAPVColumn.Width = DefDtGridCol_QtaTotale
            'dataGridTableStyle1.GridColumnStyles.Add(LAGP_LKAPVColumn)
            'AddHandler LAGP_LKAPVColumn.SetCellFormat, AddressOf ColumnSetCellFormat

            'UBI_GESMEColumn.MappingName = "UBI_GESME"
            'UBI_GESMEColumn.HeaderText = clsAppTranslation.GetSingleParameterValue(1738, "", "Quantità Ubi.")
            'UBI_GESMEColumn.Width = DefDtGridCol_QtaTotale
            'dataGridTableStyle1.GridColumnStyles.Add(UBI_GESMEColumn)
            'AddHandler UBI_GESMEColumn.SetCellFormat, AddressOf ColumnSetCellFormat



            'Dim peopleDataSource As New BindingSource()
            'peopleDataSource.DataSource = clsInfoGiacenze.objDataTableGiacenzeInfo
            'dataGridTableStyle1.MappingName = peopleDataSource.GetListName(Nothing)
            'DtGridShowInfo.DataSource = peopleDataSource

        Catch ex As Exception
            MessageBox.Show("Problem!!" & ex.ToString())

        End Try

    End Sub

    '' I'll cache this brush in the form, just make sure to dispose it (see designer.cs disposing)
    'Private highlightBrush As New SolidBrush(Color.Yellow)

    '' here is the event you can handle to determine the color of your row!
    'Private Sub ColumnSetCellFormat(ByVal sender As Object, ByVal e As DataGridTest.DataGrid.DataGridFormatCellEventArgs)

    '    Dim i As Integer
    '    Dim WorkRow As DataRow

    '    i = 0

    '    'MARCHIO LE RIGHE DI SPEDIZIONE
    '    For Each WorkRow In clsInfoGiacenze.objDataTableGiacenzeInfo.Rows

    '        If WorkRow("ZFLAG_UDS").ToString = "X" Then

    '            If e.Row = i Then
    '                e.BackBrush = highlightBrush
    '            End If

    '        End If

    '        i = i + 1

    '    Next

    'End Sub


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmInfoGiacenze_3_List_KeyPress(Me, e)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmInfoGiacenze_3_List_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'If ((Me.txtNumMag.Focused = True) And (Me.txtNumMag.Text <> "")) Then
            '    If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then

            '    End If
            'End If

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
            Call clsNavigation.Show_Info_Giacenze(Me, clsInfoGiacenze.InfoGiacenzeType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub btnHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHome.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Call clsNavigation.Show_Mnu_Main_Informazioni(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNone, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Function SetDataGridColumnStyles() As Long
        '**************************************
        'imposta la visualizzazione di tutte le colonne della DATA GRID
        '**************************************

        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'creo la formattazione solo la prima volta

            Me.DtGridShowInfo.Columns.Clear()

            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "ZFLAG_UDS", clsAppTranslation.GetSingleParameterValue(1195, "", "S"), True, DefDtGridCol_FlagUDS, True)
            'RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "LGTYP", clsAppTranslation.GetSingleParameterValue(304, "", "Tipo"), True, DefDtGridCol_FlagUDS + 40, True)

            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "LGNUM", clsAppTranslation.GetSingleParameterValue(303, "", "N.Mag."), DefDtGridCol_ShowNumeroMagazzino, DefDtGridCol_NumeroMagazzino, True)
            Select Case clsInfoGiacenze.InfoGiacenzeType
                Case clsDataType.InfoGiacenzeType.InfoGiacenzeTypeForCodMateriale
                    RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "LGTYP", clsAppTranslation.GetSingleParameterValue(304, "", "Tipo"), True, DefDtGridCol_TipoMagazzino, True)
                    RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "LGPLA", clsAppTranslation.GetSingleParameterValue(305, "", "Ubica."), True, DefDtGridCol_Ubicazione, True)
                Case clsDataType.InfoGiacenzeType.InfoGiacenzeTypeForUbicazione
                    RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "LGTYP", clsAppTranslation.GetSingleParameterValue(304, "", "Tipo"), False, DefDtGridCol_TipoMagazzino, True)
                    RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "LGPLA", clsAppTranslation.GetSingleParameterValue(305, "", "Ubica."), True, DefDtGridCol_Ubicazione, True)
                Case clsDataType.InfoGiacenzeType.InfoGiacenzeTypeForUnitaMagazzino
                    RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "LGTYP", clsAppTranslation.GetSingleParameterValue(304, "", "Tipo"), False, DefDtGridCol_TipoMagazzino, True)
                    RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "LGPLA", clsAppTranslation.GetSingleParameterValue(305, "", "Ubica."), True, DefDtGridCol_Ubicazione, True)
                Case clsDataType.InfoGiacenzeType.InfoGiacenzeTypeGeneric
                    RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "LGTYP", clsAppTranslation.GetSingleParameterValue(304, "", "Tipo"), True, DefDtGridCol_TipoMagazzino, True)
                    RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "LGPLA", clsAppTranslation.GetSingleParameterValue(305, "", "Ubica."), True, DefDtGridCol_Ubicazione, True)
            End Select
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "LQNUM", clsAppTranslation.GetSingleParameterValue(557, "", "Quant"), False, DefDtGridCol_Quant, True)
            'SE HO IL FILTRO SUL CODICE MATERIALE NASCONDO LA COLONNA
            If (clsUtility.IsStringValidWithoutWildChars(clsInfoGiacenze.FilterCodiceMateriale) = True) Then
                RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "MATNR", clsAppTranslation.GetSingleParameterValue(306, "", "Cod.Materiale"), False, DefDtGridCol_CodiceMateriale + 30, True)
            Else
                RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "MATNR", clsAppTranslation.GetSingleParameterValue(306, "", "Cod.Materiale"), True, DefDtGridCol_CodiceMateriale + 30, True)
            End If
            If (DefaultEnablePartita = True) Then
                RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "CHARG", clsAppTranslation.GetSingleParameterValue(307, "", "Partita"), True, DefDtGridCol_PartitaMateriale - 20, True)
            Else
                RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "CHARG", clsAppTranslation.GetSingleParameterValue(307, "", "Partita"), False, DefDtGridCol_PartitaMateriale - 20, True)
            End If


            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "GESME_QTY_USER", clsAppTranslation.GetSingleParameterValue(1585, "", "Qtà Tot.(PL/CT/PZ)"), True, DefDtGridCol_UnitaDiMisura + 50, True)
            'RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "VERME_QTY_USER", clsAppTranslation.GetSingleParameterValue(-1, "", "Qty VERME USER"), True, DefDtGridCol_UnitaDiMisura, True)


            If (DefaultEnableShowQtyInUdmCons = True) Then
                RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "VRKME", clsAppTranslation.GetSingleParameterValue(309, "", "UdM(Cons)"), True, DefDtGridCol_UnitaDiMisura - 90, True)
                RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "GESME_CONS", clsAppTranslation.GetSingleParameterValue(310, "", "Q.Tot.(Cons)"), True, DefDtGridCol_QtaTotale - 40, True)
                RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "VERME_CONS", clsAppTranslation.GetSingleParameterValue(311, "", "Q.Disp.(Cons)"), True, DefDtGridCol_QtaDisponibile - 40, True)
                RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "GESME_PZ", clsAppTranslation.GetSingleParameterValue(1179, "", "Q.Tot.Sfusi"), True, DefDtGridCol_QtaTotale - 40, True)
                RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "VERME_PZ", clsAppTranslation.GetSingleParameterValue(1180, "", "Q.Disp.Sfusi"), True, DefDtGridCol_QtaDisponibile - 40, True)
                RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "MEINS", clsAppTranslation.GetSingleParameterValue(312, "", "UdM(Base)"), False, 0, True)
                RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "GESME", clsAppTranslation.GetSingleParameterValue(313, "", "Q.Tot.(Base)"), False, 0, True)
                RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "VERME", clsAppTranslation.GetSingleParameterValue(314, "", "Q.Disp.(Base)"), False, 0, True)
            Else
                RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "VRKME", clsAppTranslation.GetSingleParameterValue(309, "", "UdM(Cons)"), False, DefDtGridCol_UnitaDiMisura - 90, True)
                RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "GESME_CONS", clsAppTranslation.GetSingleParameterValue(310, "", "Q.Tot.(Cons)"), False, DefDtGridCol_QtaTotale - 40, True)
                RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "VERME_CONS", clsAppTranslation.GetSingleParameterValue(311, "", "Q.Disp.(Cons)"), False, DefDtGridCol_QtaDisponibile - 40, True)
                RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "GESME_PZ", clsAppTranslation.GetSingleParameterValue(1179, "", "Q.Tot.Sfusi"), True, DefDtGridCol_QtaTotale - 40, True)
                RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "VERME_PZ", clsAppTranslation.GetSingleParameterValue(1180, "", "Q.Disp.Sfusi"), True, DefDtGridCol_QtaDisponibile - 40, True)
                RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "MEINS", clsAppTranslation.GetSingleParameterValue(312, "", "UdM(Base)"), True, DefDtGridCol_UnitaDiMisura - 80, True)
                RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "GESME", clsAppTranslation.GetSingleParameterValue(313, "", "Q.Tot.(Base)"), True, DefDtGridCol_QtaTotale - 40, True)
                RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "VERME", clsAppTranslation.GetSingleParameterValue(314, "", "Q.Disp.(Base)"), True, DefDtGridCol_QtaDisponibile - 40, True)
            End If

            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "BESTQ", clsAppTranslation.GetSingleParameterValue(558, "", "T.St."), True, DefDtGridCol_Divisione - 20, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "LENUM", clsAppTranslation.GetSingleParameterValue(315, "", "Unità Magazzino"), True, DefDtGridCol_Divisione + 60, True)

            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "WERKS", clsAppTranslation.GetSingleParameterValue(556, "", "Divis."), True, DefDtGridCol_Divisione + 10, True)

            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "LAGP_LKAPV", clsAppTranslation.GetSingleParameterValue(1581, "", "Cap. Ubi."), True, DefDtGridCol_QtaDisponibile, True)

            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "UBI_USER_QTY_TOTAL", clsAppTranslation.GetSingleParameterValue(1738, "", "Quantità Ubi."), True, DefDtGridCol_QtaDisponibile, True)

            'RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "BESTQ", clsAppTranslation.GetSingleParameterValue(558, "", "T.St."), True, DefDtGridCol_TipoStock, True)
            'RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "LENUM", clsAppTranslation.GetSingleParameterValue(315, "", "Unità Magazzino"), True, DefDtGridCol_UnitaMagazzino, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "SONUM", clsAppTranslation.GetSingleParameterValue(316, "", "Num.Stock spec."), True, DefDtGridCol_NumeroStockSpeciale, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "TBNUM", clsAppTranslation.GetSingleParameterValue(559, "", "Num.Fab."), False, 0, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "LGORT", clsAppTranslation.GetSingleParameterValue(560, "", "Mag.Log."), False, DefDtGridCol_MagazzinoLogico, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridShowInfo, "", "MAKTG", clsAppTranslation.GetSingleParameterValue(368, "", "Descr.Mat."), True, DefDtGridCol_DescrMateriale, True)


            SetDataGridColumnStyles = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            SetDataGridColumnStyles = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function
    'Private Function RefreshInfoVideata() As Long
    '    '**************************************
    '    'imposta la visualizzazione di tutte le colonne della DATA GRID
    '    '**************************************

    '    'HERE PUT DECLARATION OF LOCAL VARIABLE
    '    Dim RetCode As Long
    '    '**************************************
    '    Try 'HERE PUT NORMAL EXECUTION CODE
    '        '**************************************

    '        RefreshInfoVideata = 1

    '        RetCode = GetSelectedStockInfo(False)

    '        Me.lblInfoUDC.Text = clsAppTranslation.GetSingleParameterValue(1241, "", "N° UDC/S: ") & clsInfoGiacenze.NrUDC & " - ROWS:" & clsInfoGiacenze.objDataTableGiacenzeInfo.Rows.Count
    '        Me.lblInfoUDC.Text = Me.lblInfoUDC.Text & vbCrLf & UCase(clsAppTranslation.GetSingleParameterValue(306, "", "Cod.Materiale")) & ":" & ItemDescriptionActiveRow & QtyForUserActiveRow
    '        Me.lblInfoUDC.Text = Me.lblInfoUDC.Text & vbCrLf & UCase(clsAppTranslation.GetSingleParameterValue(1738, "", "Quantità Ubi.")) & ": (" & LocationQtyForUserActiveRow & ") - " & UCase(clsAppTranslation.GetSingleParameterValue(1581, "", "Cap. Ubi.")) & ":" & LocationCapacityForUserActiveRow

    '        RefreshInfoVideata = RetCode

    '        '**************************************
    '    Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
    '        RefreshInfoVideata = 1000
    '        'LOG ERROR CONDITION
    '        clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
    '        '**************************************
    '    Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

    '    End Try

    'End Function

    Private Sub frmInfoGiacenze_3_List_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            hook.Start(Me)
#End If

            '**************************************
            'Traduzioni

            Me.Text = clsAppTranslation.GetSingleParameterValue(121, Me.Text, "Info Giacenze(3)")

            btnDetails.Text = clsAppTranslation.GetSingleParameterValue(254, btnDetails.Text, "Dettagli")
            btnHome.Text = clsAppTranslation.GetSingleParameterValue(252, btnHome.Text, "Chiudi")
            Me.btnSped.Text = clsAppTranslation.GetSingleParameterValue(1497, btnSped.Text, "Sped.")

#If Not APPLICAZIONE_WIN32 = "SI" Then
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
#Else
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
#End If

            '**************************************      


            If Not (clsInfoGiacenze.objDataTableGiacenzeInfo Is Nothing) Then
                clsInfoGiacenze.objDataTableGiacenzeInfo.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridShowInfo.DataSource = clsInfoGiacenze.objDataTableGiacenzeInfo
            End If


            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()

            If (Not (clsInfoGiacenze.objDataTableGiacenzeInfo Is Nothing)) Then
                Me.Text = clsAppTranslation.GetSingleParameterValue(121, "", "Info Giacenze(3)")
            End If

            'AGGIORNO DATI UDC/UDS VISUALIZZATI
            RetCode = RefreshInfoVideata()

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            'RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub btnDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (clsInfoGiacenze.objDataTableGiacenzeInfo Is Nothing) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(539, "", "DataTable non valido.(Nothing)")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (clsInfoGiacenze.objDataTableGiacenzeInfo.Rows.Count = 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(540, "", "DataTable senza dati.(Rows=0)")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'DEVO AVERE SELEZIONATO UNA RIGA
            If Me.DtGridShowInfo.CurrentRow.Index < 0 Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(445, "", "Attenzione!") & vbCrLf & clsAppTranslation.GetSingleParameterValue(541, "", "Selezionare una riga della griglia.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
            clsInfoGiacenze.RowIndex = Me.DtGridShowInfo.CurrentRow.Index
            clsInfoGiacenze.objDetailsDataRow = clsInfoGiacenze.objDataTableGiacenzeInfo.Rows(Me.DtGridShowInfo.CurrentRow.Index)
            'clsInfoGiacenze.RefreshDateTableDetailsInfo()

            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Info_Giacenze(Me, clsInfoGiacenze.InfoGiacenzeType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeDetails, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub btnSped_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSped.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        Dim WorkDataRow As DataRow
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            If (clsInfoGiacenze.objDataTableGiacenzeInfo Is Nothing) And (clsInfoGiacenze.objDataTableSpedizioniInfo Is Nothing) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(539, "", "DataTable non valido.(Nothing)")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (clsInfoGiacenze.objDataTableGiacenzeInfo.Rows.Count = 0) And (clsInfoGiacenze.objDataTableSpedizioniInfo.Rows.Count = 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(540, "", "DataTable senza dati.(Rows=0)")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'DEVO AVERE SELEZIONATO UNA RIGA
            If (Me.DtGridShowInfo.CurrentRow.Index < 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(445, "", "Attenzione!") & vbCrLf & clsAppTranslation.GetSingleParameterValue(541, "", "Selezionare una riga della griglia.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            'DEVO AVERE SELEZIONATO UNA RIGA
            WorkDataRow = clsInfoGiacenze.objDataTableGiacenzeInfo.Rows(Me.DtGridShowInfo.CurrentRow.Index)
            If (clsUtility.GetDataRowItem(WorkDataRow, "ZFLAG_UDS", "") <> "X") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(445, "", "Attenzione!") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1761, "", "La riga selezionata non è un K-TAG.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
            'clsInfoGiacenze.RowIndex = Me.DtGridShowInfo.CurrentRowIndex
            'PER ORA PUNTO SEMPRE AL PRIMO RECORD
            'clsInfoGiacenze.RowIndex = 0
            clsInfoGiacenze.objSpedDataRow = WorkDataRow 'clsInfoGiacenze.objDataTableSpedizioniInfo.Rows(0)
            clsInfoGiacenze.RefreshDateTableSpedInfo()

            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Info_Giacenze(Me, clsInfoGiacenze.InfoGiacenzeType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeSped, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    'Public Function GetSelectedStockInfo(ByRef outSelezioneOk As Boolean) As Long
    '    '**************************************
    '    'HERE PUT DECLARATION OF LOCAL VARIABLE
    '    Dim RetCode As Long = 0
    '    Dim WorkDataRow As DataRow
    '    Dim WorkGiacenza As clsDataType.SapWmGiacenza
    '    '**************************************
    '    Try 'HERE PUT NORMAL EXECUTION CODE
    '        '**************************************

    '        GetSelectedStockInfo = 1 'INIT AT ERROR

    '        outSelezioneOk = False 'init

    '        'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO I DATI DELLA RIGA ATTIVA
    '        If (Not (clsInfoGiacenze.objDataTableGiacenzeInfo Is Nothing)) Then
    '            If (clsInfoGiacenze.objDataTableGiacenzeInfo.Rows.Count > 0) Then
    '                'SE HO SELEZIONATO UNA RIGA
    '                If (Not Me.DtGridShowInfo Is Nothing) Then
    '                    If (Not Me.DtGridShowInfo.CurrentRow Is Nothing) Then
    '                        If (Me.DtGridShowInfo.CurrentRow.Index >= 0) Then
    '                            'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
    '                            WorkDataRow = clsInfoGiacenze.objDataTableGiacenzeInfo.Rows(Me.DtGridShowInfo.CurrentRow.Index)
    '                            If (Not (WorkDataRow Is Nothing)) Then
    '                                'RECUPERO I DATI DELLA GIACENZA SELEZIONATA
    '                                RetCode = clsSapUtility.GetQtyForUserInfoFromDataRow(WorkDataRow, WorkGiacenza, QtyForUserActiveRow, False)
    '                                ItemDescriptionActiveRow = clsUtility.GetDataRowItem(WorkDataRow, "MATNR", "") & " - " & clsUtility.GetDataRowItem(WorkDataRow, "MAKTG", "")
    '                                LocationQtyForUserActiveRow = clsUtility.GetDataRowItem(WorkDataRow, "UBI_USER_QTY_TOTAL", "0")
    '                                LocationCapacityForUserActiveRow = clsUtility.GetDataRowItem(WorkDataRow, "LAGP_LKAPV", "0")
    '                                If (RetCode = 0) Then
    '                                    outSelezioneOk = True 'UNICO CASO DI SELEZIONE OK
    '                                End If
    '                            End If
    '                        End If
    '                    End If
    '                End If
    '            End If
    '        End If

    '        GetSelectedStockInfo = RetCode

    '        '**************************************
    '    Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
    '        'LOG ERROR CONDITION
    '        clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
    '        '**************************************
    '    Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

    '    End Try
    'End Function


    Private Sub DtGridViewInfo_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DtGridShowInfo.CellFormatting
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        Dim WorkZFLAG_UDS As String = ""

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Me.DtGridShowInfo.Rows Is Nothing) Then
                Exit Sub
            End If

            If (Me.DtGridShowInfo.Rows.Count <= 0) Then
                Exit Sub
            End If


            'Gestione colorazione riga per UDS
            For i As Integer = 0 To (clsInfoGiacenze.objDataTableGiacenzeInfo.Rows.Count - 1)
                WorkZFLAG_UDS = clsUtility.GetDataRowItem(clsInfoGiacenze.objDataTableGiacenzeInfo.Rows(i), "ZFLAG_UDS", "", False)
                If (WorkZFLAG_UDS = "X") Then
                    Me.DtGridShowInfo.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                End If
            Next


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub


    Private Function RefreshInfoVideata() As Long
        '**************************************
        'imposta la visualizzazione di tutte le colonne della DATA GRID
        '**************************************

        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RefreshInfoVideata = 1

            RetCode = GetSelectedStockInfo(False)

            Me.lblInfoUDC.Text = clsAppTranslation.GetSingleParameterValue(1241, "", "N° UDC/S: ") & clsInfoGiacenze.NrUDC & " - ROWS:" & clsInfoGiacenze.objDataTableGiacenzeInfo.Rows.Count
            Me.lblInfoUDC.Text = Me.lblInfoUDC.Text & vbCrLf & UCase(clsAppTranslation.GetSingleParameterValue(306, "", "Cod.Materiale")) & ":" & ItemDescriptionActiveRow & QtyForUserActiveRow
            Me.lblInfoUDC.Text = Me.lblInfoUDC.Text & vbCrLf & UCase(clsAppTranslation.GetSingleParameterValue(1738, "", "Quantità Ubi.")) & ": (" & LocationQtyForUserActiveRow & ") - " & UCase(clsAppTranslation.GetSingleParameterValue(1581, "", "Cap. Ubi.")) & ":" & LocationCapacityForUserActiveRow

            RefreshInfoVideata = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            RefreshInfoVideata = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function


    Public Function GetSelectedStockInfo(ByRef outSelezioneOk As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkDataRow As DataRow
        Dim WorkGiacenza As clsDataType.SapWmGiacenza
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetSelectedStockInfo = 1 'INIT AT ERROR


            outSelezioneOk = False 'init

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO I DATI DELLA RIGA ATTIVA
            If (Not (clsInfoGiacenze.objDataTableGiacenzeInfo Is Nothing)) Then
                If (clsInfoGiacenze.objDataTableGiacenzeInfo.Rows.Count > 0) Then
                    'SE HO SELEZIONATO UNA RIGA
                    If (Not Me.DtGridShowInfo Is Nothing) Then
                        If (Not Me.DtGridShowInfo.CurrentRow Is Nothing) Then
                            If (Me.DtGridShowInfo.CurrentRow.Index >= 0) Then
                                'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
                                WorkDataRow = clsInfoGiacenze.objDataTableGiacenzeInfo.Rows(Me.DtGridShowInfo.CurrentRow.Index)
                                If (Not (WorkDataRow Is Nothing)) Then
                                    'RECUPERO I DATI DELLA GIACENZA SELEZIONATA
                                    RetCode = clsSapUtility.GetQtyForUserInfoFromDataRow(WorkDataRow, WorkGiacenza, QtyForUserActiveRow, False)
                                    ItemDescriptionActiveRow = clsUtility.GetDataRowItem(WorkDataRow, "MATNR", "") & " - " & clsUtility.GetDataRowItem(WorkDataRow, "MAKTG", "")
                                    LocationQtyForUserActiveRow = clsUtility.GetDataRowItem(WorkDataRow, "UBI_USER_QTY_TOTAL", "0")
                                    LocationCapacityForUserActiveRow = clsUtility.GetDataRowItem(WorkDataRow, "LAGP_LKAPV", "0")
                                    If (RetCode = 0) Then
                                        outSelezioneOk = True 'UNICO CASO DI SELEZIONE OK
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            GetSelectedStockInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function



    Private Sub DtGridShowInfo_CurrentCellChanged(sender As Object, e As EventArgs) Handles DtGridShowInfo.CurrentCellChanged
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'AGGIORNO DATI UDC/UDS VISUALIZZATI
            If (Not (Me.DtGridShowInfo.CurrentRow Is Nothing)) Then
                RetCode = RefreshInfoVideata()
            End If

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO QUESTA UBICAZIONE COME
            'RetCode = GetSelectedStockInfo(UserSelezioneOk)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub


End Class