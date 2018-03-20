' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 14/10/2011
' DATA MODIFICA     : 14/10/2011
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la funzione di visualizzare le informazioni delle GIACENZE
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType

Public Class clsInfoGiacenze


    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsInfoGiacenze"

    ' OGGETTO DATA TABLE PER VISUALIZZARE DATI NELLE GRIGLIE
    Public Shared objDataTableGiacenzeInfo As New DataTable
    Public Shared objDataTableDetailsGiacenza As New DataTable

    Public Shared objDataTableSpedizioniInfo As New DataTable
    Public Shared objDataTableDetailsSpedizioni As New DataTable


    'OGGETTO ROW PER LA VISUALIZZAZIONE DEL DETTAGLIO DEI DATI
    Public Shared objDetailsDataRow As Data.DataRow
    Public Shared objSpedDataRow As Data.DataRow

    Public Shared RowIndex As Long
    Public Shared NrUDC As Long


    'VALORI DI FILTRO PER LA VISUALIZZAZIONE DEI TIPI MAGAZZINO
    Public Shared FilterDivisione As String
    Public Shared FilterNumMag As String
    Public Shared FilterTipiMag As String
    Public Shared FilterUbicazione As String

    Public Shared FilterCodiceMateriale As String
    Public Shared FilterPartitaMateriale As String
    Public Shared FilterSKU As String
    Public Shared FilterUnitaMagazzino As String


    'MI INDICA SE STO ESEGUENDO LE INFORMAZIONI GIACENZE (GENERALE) O LE INFORMAZIONI UBICAZIONE
    Public Shared InfoGiacenzeType As clsDataType.InfoGiacenzeType


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

            FilterDivisione = ""
            FilterNumMag = ""
            FilterTipiMag = ""
            FilterUbicazione = ""
            FilterCodiceMateriale = ""
            FilterPartitaMateriale = ""
            FilterSKU = ""
            FilterUnitaMagazzino = ""
            NrUDC = 0

            If (Not (objDataTableGiacenzeInfo Is Nothing)) Then
                objDataTableGiacenzeInfo.Rows.Clear()
            End If

            If (Not (objDataTableSpedizioniInfo Is Nothing)) Then
                objDataTableSpedizioniInfo.Rows.Clear()
            End If

            'If (Not (objDataTableDetailsGiacenza Is Nothing)) Then
            '    objDataTableDetailsGiacenza.Rows.Clear()
            'End If

            'If (Not (objDataTableDetailsSpedizioni Is Nothing)) Then
            '    objDataTableDetailsSpedizioni.Rows.Clear()
            'End If

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

    Public Shared Function CreateDateTableForSpedizioni() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForSpedizioni = 1 'init at error

            Dim WorkWERKS As DataColumn = New DataColumn("WERKS") 'declaring a column named Name
            WorkWERKS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkWERKS) 'adding the column to table

            Dim WorkLGNUM As DataColumn = New DataColumn("LGNUM") 'declaring a column named Name
            WorkLGNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkLGNUM) 'adding the column to table

            Dim WorkLGTYP As DataColumn = New DataColumn("LGTYP") 'declaring a column named Name
            WorkLGTYP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkLGTYP) 'adding the column to table

            Dim WorkLGPLA As DataColumn = New DataColumn("LGPLA") 'declaring a column named Name
            WorkLGPLA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkLGPLA) 'adding the column to table

            Dim WorkLQNUM As DataColumn = New DataColumn("LQNUM") 'declaring a column named Name
            WorkLQNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkLQNUM) 'adding the column to table

            Dim WorkMATNR As DataColumn = New DataColumn("MATNR") 'declaring a column named Name
            WorkMATNR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkMATNR) 'adding the column to table

            Dim WorkCHARG As DataColumn = New DataColumn("CHARG") 'declaring a column named Name
            WorkCHARG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkCHARG) 'adding the column to table

            Dim WorkBESTQ As DataColumn = New DataColumn("BESTQ") 'declaring a column named Name
            WorkBESTQ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkBESTQ) 'adding the column to table

            Dim WorkVrkme As DataColumn = New DataColumn("VRKME") 'declaring a column named Name
            WorkVrkme.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkVrkme) 'adding the column to table

            Dim WorkMEINS_PAL As DataColumn = New DataColumn("MEINS_PAL") 'declaring a column named Name
            WorkMEINS_PAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkMEINS_PAL) 'adding the column to table

            Dim WorkGESME_PAL As DataColumn = New DataColumn("GESME_PAL") 'declaring a column named Name
            WorkGESME_PAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkGESME_PAL) 'adding the column to table

            Dim WorkVERME_PAL As DataColumn = New DataColumn("VERME_PAL") 'declaring a column named Name
            WorkVERME_PAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkVERME_PAL) 'adding the column to table

            Dim WorkVerme_cons As DataColumn = New DataColumn("VERME_CONS") 'declaring a column named Name
            WorkVerme_cons.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkVerme_cons) 'adding the column to table

            Dim WorkGesme_cons As DataColumn = New DataColumn("GESME_CONS") 'declaring a column named Name
            WorkGesme_cons.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkGesme_cons) 'adding the column to table

            Dim WorkGESME_PARTIAL As DataColumn = New DataColumn("GESME_PARTIAL") 'declaring a column named Name
            WorkGESME_PARTIAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkGESME_PARTIAL) 'adding the column to table

            Dim WorkVERME_PARTIAL As DataColumn = New DataColumn("VERME_PARTIAL") 'declaring a column named Name
            WorkVERME_PARTIAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkVERME_PARTIAL) 'adding the column to table

            Dim WorkGesme_SF As DataColumn = New DataColumn("GESME_SF") 'declaring a column named Name
            WorkGesme_SF.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkGesme_SF) 'adding the column to table

            Dim WorkVerme_SF As DataColumn = New DataColumn("VERME_SF") 'declaring a column named Name
            WorkVerme_SF.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkVerme_SF) 'adding the column to table

            Dim WorkGesme_pz As DataColumn = New DataColumn("GESME_PZ") 'declaring a column named Name
            WorkGesme_pz.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkGesme_pz) 'adding the column to table

            Dim WorkVerme_pz As DataColumn = New DataColumn("VERME_PZ") 'declaring a column named Name
            WorkVerme_pz.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkVerme_pz) 'adding the column to table

            Dim WorkMEINS As DataColumn = New DataColumn("MEINS") 'declaring a column named Name
            WorkMEINS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkMEINS) 'adding the column to table

            Dim WorkMEINS_PZ As DataColumn = New DataColumn("MEINS_PZ") 'declaring a column named Name
            WorkMEINS_PZ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkMEINS_PZ) 'adding the column to table

            Dim WorkGESME As DataColumn = New DataColumn("GESME") 'declaring a column named Name
            WorkGESME.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkGESME) 'adding the column to table

            Dim WorkVERME As DataColumn = New DataColumn("VERME") 'declaring a column named Name
            WorkVERME.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkVERME) 'adding the column to table

            Dim WorkLENUM As DataColumn = New DataColumn("LENUM") 'declaring a column named Name
            WorkLENUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkLENUM) 'adding the column to table

            Dim WorkSOBKZ As DataColumn = New DataColumn("SOBKZ") 'declaring a column named Name
            WorkSOBKZ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkSOBKZ) 'adding the column to table

            Dim WorkSONUM As DataColumn = New DataColumn("SONUM") 'declaring a column named Name
            WorkSONUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkSONUM) 'adding the column to table

            Dim WorkTBNUM As DataColumn = New DataColumn("TBNUM") 'declaring a column named Name
            WorkTBNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkTBNUM) 'adding the column to table

            Dim WorkLGORT As DataColumn = New DataColumn("LGORT") 'declaring a column named Name
            WorkLGORT.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkLGORT) 'adding the column to table

            Dim WorkMaktg As DataColumn = New DataColumn("MAKTG") 'declaring a column named Name
            WorkMaktg.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(WorkMaktg) 'adding the column to table

            Dim Imballo As DataColumn = New DataColumn("IMBALLO") 'declaring a column named Name
            Imballo.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(Imballo) 'adding the column to table

            Dim PzXSc As DataColumn = New DataColumn("PZ_X_SC") 'declaring a column named Name
            PzXSc.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(PzXSc) 'adding the column to table

            Dim ScXPal As DataColumn = New DataColumn("SC_X_PAL") 'declaring a column named Name
            ScXPal.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(ScXPal) 'adding the column to table

            Dim M2XPal As DataColumn = New DataColumn("M2_X_PAL") 'declaring a column named Name
            M2XPal.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(M2XPal) 'adding the column to table

            Dim LagpLkapv As DataColumn = New DataColumn("LAGP_LKAPV") 'declaring a column named Name
            LagpLkapv.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(LagpLkapv) 'adding the column to table

            Dim NumPallet As DataColumn = New DataColumn("NUM_PALLET") 'declaring a column named Name
            NumPallet.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(NumPallet) 'adding the column to table

            Dim ZFLAG_UDS As DataColumn = New DataColumn("ZFLAG_UDS") 'declaring a column named Name
            ZFLAG_UDS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(ZFLAG_UDS) 'adding the column to table

            Dim ODV_VBELN As DataColumn = New DataColumn("ODV_VBELN") 'declaring a column named Name
            ODV_VBELN.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(ODV_VBELN) 'adding the column to table

            Dim ODV_POSNR As DataColumn = New DataColumn("ODV_POSNR") 'declaring a column named Name
            ODV_POSNR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(ODV_POSNR) 'adding the column to table

            Dim ODV_KUNNR_AG As DataColumn = New DataColumn("ODV_KUNNR_AG") 'declaring a column named Name
            ODV_KUNNR_AG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(ODV_KUNNR_AG) 'adding the column to table

            Dim ODV_KUNNR_WE As DataColumn = New DataColumn("ODV_KUNNR_WE") 'declaring a column named Name
            ODV_KUNNR_WE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(ODV_KUNNR_WE) 'adding the column to table

            Dim ODV_LIFNR_SP As DataColumn = New DataColumn("ODV_LIFNR_SP") 'declaring a column named Name
            ODV_LIFNR_SP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(ODV_LIFNR_SP) 'adding the column to table

            Dim ODV_KUNNR_AG_NAME1 As DataColumn = New DataColumn("ODV_KUNNR_AG_NAME1") 'declaring a column named Name
            ODV_KUNNR_AG_NAME1.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(ODV_KUNNR_AG_NAME1) 'adding the column to table

            Dim ODV_KUNNR_WE_NAME1 As DataColumn = New DataColumn("ODV_KUNNR_WE_NAME1") 'declaring a column named Name
            ODV_KUNNR_WE_NAME1.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(ODV_KUNNR_WE_NAME1) 'adding the column to table

            Dim ODV_LIFNR_SP_NAME1 As DataColumn = New DataColumn("ODV_LIFNR_SP_NAME1") 'declaring a column named Name
            ODV_LIFNR_SP_NAME1.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(ODV_LIFNR_SP_NAME1) 'adding the column to table

            Dim ZNR_WMS_JOBS As DataColumn = New DataColumn("ZNR_WMS_JOBS") 'declaring a column named Name
            ZNR_WMS_JOBS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(ZNR_WMS_JOBS) 'adding the column to table

            Dim ZNR_WMS_JOBSGRP As DataColumn = New DataColumn("ZNR_WMS_JOBSGRP") 'declaring a column named Name
            ZNR_WMS_JOBSGRP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(ZNR_WMS_JOBSGRP) 'adding the column to table

            Dim ZNRPICK As DataColumn = New DataColumn("ZNRPICK") 'declaring a column named Name
            ZNRPICK.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(ZNRPICK) 'adding the column to table

            Dim ZPOSPK As DataColumn = New DataColumn("ZPOSPK") 'declaring a column named Name
            ZPOSPK.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableSpedizioniInfo.Columns.Add(ZPOSPK) 'adding the column to table


            CreateDateTableForSpedizioni = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForSpedizioni = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CreateDateTableDetailsGiacenza() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per griglia DETTAGLI MATERIALE
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim WorkRow As DataRow = Nothing

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableDetailsGiacenza = 1 'init at error

            If objDataTableDetailsGiacenza.Columns("PropertyId") Is Nothing Then
                Dim WorkPropertyId As DataColumn = New DataColumn("PropertyId") 'declaring a column named Name
                WorkPropertyId.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
                objDataTableDetailsGiacenza.Columns.Add(WorkPropertyId) 'adding the column to table
            End If

            If objDataTableDetailsGiacenza.Columns("PropertyText") Is Nothing Then
                Dim WorkPropertyText As DataColumn = New DataColumn("PropertyText") 'declaring a column named Name
                WorkPropertyText.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
                objDataTableDetailsGiacenza.Columns.Add(WorkPropertyText) 'adding the column to table
            End If

            If objDataTableDetailsGiacenza.Columns("PropertyValue") Is Nothing Then
                Dim WorkPropertyValue As DataColumn = New DataColumn("PropertyValue") 'declaring a column named Name
                WorkPropertyValue.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
                objDataTableDetailsGiacenza.Columns.Add(WorkPropertyValue) 'adding the column to table
            End If

            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "WERKS"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(6, "", "Divisione")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "LGNUM"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(119, "", "Num.Mag.")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "LGTYP"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(883, "", "Tipo Mag.")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "LGPLA"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(4, "", "Ubicazione")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "LENUM"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(315, "", "Unità Magazzino")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "MATNR"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(306, "", "Cod.Materiale")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "CHARG"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1, "", "Partita")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga


            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "ZWMS_SKU_PALLET"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1646, "", "SKU")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "ZZCDLEGACY"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1647, "", "Code Legacy")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga



            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "GESME_QTY_USER"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1585, "", "Qtà Tot.(PL/CT/PZ)")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "VERME_QTY_USER"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1586, "", "Qtà Avail. Tot.(PL/CT/PZ)")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga




            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "VRKME"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(309, "", "UdM(Cons)")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "GESME_CONS"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(884, "", "Q.Tot.(Cons.)")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "VERME_CONS"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(885, "", "Q.Dispo.(Cons.)")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga


            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "MEINS_PZ"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1716, "", "UdM(Pezzo)")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga


            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "GESME_PZ"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1179, "", "Q.Tot.Sfusi")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "VERME_PZ"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1180, "", "Q.Disp.Sfusi")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga


            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "GESME_SF"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1717, "", "Q.Tot.Pezzi Sfusi")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "VERME_SF"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1718, "", "Q.Disp.Pezzi Sfusi")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga


            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "MEINS_PAL"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1584, "", "UdM(Pallet)")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga


            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "GESME_PAL"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1719, "", "Q.Tot.Pallet")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "VERME_PAL"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1720, "", "Q.Disp.Pallet")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "GESME_PARTIAL"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1721, "", "Q.Tot.Parziali (Consegna)")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "VERME_PARTIAL"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1722, "", "Q.Disp.Parziali (Consegna)")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga



            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "MEINS"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(312, "", "UdM(Base)")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "GESME"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(313, "", "Q.Tot.(Base)")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "VERME"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(886, "", "Q.Dispo.(Base)")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga


            'GESTIONE RIGHE Metri Quadri (Ita) / Square Feet (Usa)

            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "GESME_M2"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1712, "", "Qtà M2")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "MEINS_M2"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1713, "", "Udm M2")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "GESME_SQF"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1714, "", "Qtà SF")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "MEINS_SQF"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1715, "", "Udm SF")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga



            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "BESTQ"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(380, "", "Tipo Stock")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "SOBKZ"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(887, "", "Cd.St.Speciale")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "SONUM"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(888, "", "Numero Stock Speciale")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "TBNUM"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(889, "", "Numero Fabbisogno Di Trasporto")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "LQNUM"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(890, "", "Id Quant")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "LGORT"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(891, "", "Mag.Logico")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsGiacenza.NewRow()
            WorkRow.Item("PropertyId") = "MAKTG"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(368, "", "Descr.Mat.")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsGiacenza.Rows.Add(WorkRow) 'aggiungo la riga


            CreateDateTableDetailsGiacenza = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableDetailsGiacenza = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CreateDateTableDetailsSped() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per griglia DETTAGLI MATERIALE
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim WorkRow As DataRow = Nothing

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableDetailsSped = 1 'init at error

            If objDataTableDetailsSpedizioni.Columns("PropertyId") Is Nothing Then
                Dim WorkPropertyId As DataColumn = New DataColumn("PropertyId") 'declaring a column named Name
                WorkPropertyId.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
                objDataTableDetailsSpedizioni.Columns.Add(WorkPropertyId) 'adding the column to table
            End If

            If objDataTableDetailsSpedizioni.Columns("PropertyText") Is Nothing Then
                Dim WorkPropertyText As DataColumn = New DataColumn("PropertyText") 'declaring a column named Name
                WorkPropertyText.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
                objDataTableDetailsSpedizioni.Columns.Add(WorkPropertyText) 'adding the column to table
            End If

            If objDataTableDetailsSpedizioni.Columns("PropertyValue") Is Nothing Then
                Dim WorkPropertyValue As DataColumn = New DataColumn("PropertyValue") 'declaring a column named Name
                WorkPropertyValue.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
                objDataTableDetailsSpedizioni.Columns.Add(WorkPropertyValue) 'adding the column to table
            End If

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "ODV_VBELN"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1181, "", "Num.OdV")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "ODV_POSNR"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1182, "", "Pos.OdV")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "ODV_KUNNR_AG"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1183, "", "Cod.AG")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "ODV_KUNNR_AG_NAME1"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1184, "", "Descr.AG")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "ODV_KUNNR_WE"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1185, "", "Cod.WE")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "ODV_KUNNR_WE_NAME1"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1186, "", "Descr.WE")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "ODV_LIFNR_SP"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1187, "", "Cod.SP")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "ODV_LIFNR_SP_NAME1"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1188, "", "Descr.SP")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "ZNR_WMS_JOBS"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1189, "", "Missione")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "ZNR_WMS_JOBSGRP"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1190, "", "Cod.Lista")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "LGNUM"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(119, "", "Num.Mag.")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "WERKS"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(6, "", "Divisione")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga


            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "LGTYP"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(883, "", "Tipo Mag.")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "LGPLA"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(4, "", "Ubicazione")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "LENUM"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(315, "", "Unità Magazzino")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "MATNR"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(306, "", "Cod.Materiale")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "CHARG"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1, "", "Partita")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "VRKME"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(309, "", "UdM(Cons)")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "GESME_CONS"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(884, "", "Q.Tot.(Cons.)")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "VERME_CONS"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(885, "", "Q.Dispo.(Cons.)")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga


            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "GESME_PZ"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1179, "", "Q.Tot.Sfusi")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "VERME_PZ"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1180, "", "Q.Disp.Sfusi")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "MEINS"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(312, "", "UdM(Base)")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "GESME"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(313, "", "Q.Tot.(Base)")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "VERME"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(886, "", "Q.Dispo.(Base)")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "BESTQ"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(380, "", "Tipo Stock")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "SOBKZ"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(887, "", "Cd.St.Speciale")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "SONUM"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(888, "", "Numero Stock Speciale")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "TBNUM"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(889, "", "Numero Fabbisogno Di Trasporto")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "LQNUM"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(890, "", "Id Quant")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "LGORT"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(891, "", "Mag.Logico")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsSpedizioni.NewRow()
            WorkRow.Item("PropertyId") = "MAKTG"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(368, "", "Descr.Mat.")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsSpedizioni.Rows.Add(WorkRow) 'aggiungo la riga

            CreateDateTableDetailsSped = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableDetailsSped = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function RefreshDateTableDetailsInfo() As Long
        ' ************************************************************
        ' DESCRIZIONE : ESEGUE IL REFRESH DEI DATI DELLE USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim WorkRow As DataRow
        Dim WorkPropertyId As String = ""
        Dim WorkPropertyValue As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RefreshDateTableDetailsInfo = 1 'init at error

            If (objDataTableDetailsGiacenza Is Nothing) Then Exit Function

            If (objDataTableDetailsGiacenza.Rows.Count = 0) Then Exit Function

            If (objDetailsDataRow Is Nothing) Then Exit Function

            For Each WorkRow In objDataTableDetailsGiacenza.Rows
                WorkPropertyId = WorkRow.Item("PropertyId")
                Select Case UCase(WorkPropertyId)
                    Case "ODV_VBELN"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ODV_VBELN")
                    Case "ODV_POSNR"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ODV_POSNR")
                    Case "ODV_KUNNR_AG"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ODV_KUNNR_AG")
                    Case "ODV_KUNNR_AG_NAME1"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ODV_KUNNR_AG_NAME1")
                    Case "ODV_KUNNR_WE"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ODV_KUNNR_WE")
                    Case "ODV_KUNNR_WE_NAME1"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ODV_KUNNR_WE_NAME1")
                    Case "ODV_LIFNR_SP"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ODV_LIFNR_SP")
                    Case "ODV_LIFNR_SP_NAME1"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ODV_LIFNR_SP_NAME1")
                    Case "ZNR_WMS_JOBS"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZNR_WMS_JOBS")
                    Case "ZNR_WMS_JOBSGRP"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZNR_WMS_JOBSGRP")
                    Case "LGNUM"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LGNUM")
                    Case "WERKS"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "WERKS")
                    Case "LGTYP"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LGTYP")
                    Case "LGPLA"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LGPLA")
                    Case "LENUM"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LENUM")
                        WorkPropertyValue = clsSapUtility.FormattaStringaUnitaMagazzino(WorkPropertyValue)
                    Case "MATNR"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "MATNR")
                        WorkPropertyValue = clsSapUtility.FormattaStringaCodiceMateriale(WorkPropertyValue)
                    Case "CHARG"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "CHARG")

                    Case "ZWMS_SKU_PALLET"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZWMS_SKU_PALLET")
                    Case "ZZCDLEGACY"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZZCDLEGACY")


                    Case "GESME_QTY_USER"
                        WorkPropertyValue = Trim(Str(Int(clsUtility.GetDataRowItem(objDetailsDataRow, "GESME_PAL")))) + " " + Trim(clsUtility.GetDataRowItem(objDetailsDataRow, "MEINS_PAL")) + " / " + Trim(Str(Int(clsUtility.GetDataRowItem(objDetailsDataRow, "GESME_PARTIAL")))) + " " + Trim(clsUtility.GetDataRowItem(objDetailsDataRow, "VRKME")) + " / " + Trim(Str(Int(clsUtility.GetDataRowItem(objDetailsDataRow, "GESME_SF")))) + " " + Trim(clsUtility.GetDataRowItem(objDetailsDataRow, "MEINS_PZ"))
                    Case "VERME_QTY_USER"
                        WorkPropertyValue = Trim(Str(Int(clsUtility.GetDataRowItem(objDetailsDataRow, "VERME_PAL")))) + " " + Trim(clsUtility.GetDataRowItem(objDetailsDataRow, "MEINS_PAL")) + " / " + Trim(Str(Int(clsUtility.GetDataRowItem(objDetailsDataRow, "VERME_PARTIAL")))) + " " + Trim(clsUtility.GetDataRowItem(objDetailsDataRow, "VRKME")) + " / " + Trim(Str(Int(clsUtility.GetDataRowItem(objDetailsDataRow, "VERME_SF")))) + " " + Trim(clsUtility.GetDataRowItem(objDetailsDataRow, "MEINS_PZ"))


                    Case "VRKME"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "VRKME")
                    Case "GESME_CONS"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "GESME_CONS")
                    Case "VERME_CONS"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "VERME_CONS")
                    Case "VERME_PZ"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "VERME_PZ")
                    Case "GESME_PZ"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "GESME_PZ")
                    Case "VERME_SF"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "VERME_SF")
                    Case "GESME_SF"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "GESME_SF")
                    Case "MEINS_PZ"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "MEINS_PZ")
                    Case "VERME_PAL"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "VERME_PAL")
                    Case "GESME_PAL"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "GESME_PAL")
                    Case "MEINS_PAL"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "MEINS_PAL")
                    Case "VERME_PARTIAL"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "VERME_PARTIAL")
                    Case "GESME_PARTIAL"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "GESME_PARTIAL")

                    Case "MEINS"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "MEINS")
                    Case "GESME"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "GESME")
                    Case "VERME"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "VERME")
                    Case "BESTQ"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "BESTQ")


                        'GESTIONE RIGHE Metri Quadri (Ita) / Square Feet (Usa)

                    Case "GESME_M2"
                            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "GESME_M2")
                    Case "MEINS_M2"
                            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "MEINS_M2")
                    Case "GESME_SQF"
                            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "GESME_SQF")
                    Case "MEINS_SQF"
                            WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "MEINS_SQF")


                    Case "SOBKZ"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "SOBKZ")
                    Case "SONUM"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "SONUM")
                    Case "TBNUM"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "TBNUM")
                    Case "LQNUM"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LQNUM")
                    Case "LGORT"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LGORT")
                    Case "MAKTG"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "MAKTG")


                    Case Else
                        WorkPropertyValue = "NO DATA"
                End Select
                WorkRow.Item("PropertyValue") = WorkPropertyValue
            Next

            RefreshDateTableDetailsInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            RefreshDateTableDetailsInfo = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    'Public Shared Function RefreshDateTableDetailsPropertyText() As Long
    '    ' ************************************************************
    '    ' DESCRIZIONE : ESEGUE IL REFRESH DEI DATI DELLE USER INFORMATION
    '    ' ************************************************************

    '    '**************************************
    '    'HERE PUT DECLARATION OF LOCAL VARIABLE
    '    Dim RetCode As Long
    '    Dim WorkRow As DataRow
    '    Dim WorkPropertyId As String = ""
    '    Dim WorkPropertyText As String = ""
    '    '**************************************
    '    Try 'HERE PUT NORMAL EXECUTION CODE
    '        '**************************************

    '        RefreshDateTableDetailsPropertyText = 1 'init at error

    '        If (objDataTableDetailsGiacenza Is Nothing) Then Exit Function

    '        If (objDataTableDetailsGiacenza.Rows.Count = 0) Then Exit Function


    '        For Each WorkRow In objDataTableDetailsGiacenza.Rows
    '            WorkPropertyId = WorkRow.Item("PropertyId")
    '            Select Case UCase(WorkPropertyId)
    '                Case "ODV_VBELN"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(1181, "", "Num.OdV")
    '                Case "ODV_POSNR"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(1182, "", "Pos.OdV")
    '                Case "ODV_KUNNR_AG"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(1183, "", "Cod.AG")
    '                Case "ODV_KUNNR_AG_NAME1"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(1184, "", "Descr.AG")
    '                Case "ODV_KUNNR_WE"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(1185, "", "Cod.WE")
    '                Case "ODV_KUNNR_WE_NAME1"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(1186, "", "Descr.WE")
    '                Case "ODV_LIFNR_SP"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(1187, "", "Cod.SP")
    '                Case "ODV_LIFNR_SP_NAME1"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(1188, "", "Descr.SP")
    '                Case "ZNR_WMS_JOBS"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(1189, "", "Missione")
    '                Case "ZNR_WMS_JOBSGRP"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(1190, "", "Cod.Lista")
    '                Case "LGNUM"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(119, "", "Num.Mag.")
    '                Case "LGTYP"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(883, "", "Tipo Mag.")
    '                Case "LGPLA"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(4, "", "Ubicazione")
    '                Case "LENUM"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(315, "", "Unità Magazzino")
    '                Case "MATNR"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(306, "", "Cod.Materiale")
    '                Case "CHARG"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(1, "", "Partita")
    '                Case "VRKME"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(309, "", "UdM(Cons)")
    '                Case "GESME_CONS"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(884, "", "Q.Tot.(Cons.)")
    '                Case "VERME_CONS"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(885, "", "Q.Dispo.(Cons.)")
    '                Case "VERME_PZ"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(1179, "", "Q.Tot.Sfusi")
    '                Case "GESME_PZ"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(1180, "", "Q.Disp.Sfusi")
    '                Case "MEINS"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(312, "", "UdM(Base)")
    '                Case "GESME"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(313, "", "Q.Tot.(Base)")
    '                Case "VERME"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(886, "", "Q.Dispo.(Base)")
    '                Case "BESTQ"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(380, "", "Tipo Stock")
    '                Case "SOBKZ"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(887, "", "Cd.St.Speciale")
    '                Case "SONUM"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(888, "", "Numero Stock Speciale")
    '                Case "TBNUM"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(889, "", "Numero Fabbisogno Di Trasporto")
    '                Case "LQNUM"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(890, "", "Id Quant")
    '                Case "LGORT"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(891, "", "Mag.Logico")
    '                Case "MAKTG"
    '                    WorkPropertyText = clsAppTranslation.GetSingleParameterValue(368, "", "Descr.Mat.")
    '                Case Else
    '                    WorkPropertyText = "NO DATA"
    '            End Select
    '            WorkRow.Item("PropertyText") = WorkPropertyText
    '        Next

    '        RefreshDateTableDetailsPropertyText = RetCode

    '        '**************************************
    '    Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
    '        RefreshDateTableDetailsPropertyText = 1000 'IL THREAD E' USCITO DAL LOOP
    '        'LOG ERROR CONDITION
    '        clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
    '        '**************************************
    '    Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

    '    End Try
    'End Function

    Public Shared Function RefreshDateTableSpedInfo() As Long
        ' ************************************************************
        ' DESCRIZIONE : ESEGUE IL REFRESH DEI DATI DELLE USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim WorkRow As DataRow
        Dim WorkPropertyId As String = ""
        Dim WorkPropertyValue As String
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RefreshDateTableSpedInfo = 1 'init at error

            If (objDataTableDetailsSpedizioni Is Nothing) Then Exit Function

            If (objDataTableDetailsSpedizioni.Rows.Count = 0) Then Exit Function

            If (objSpedDataRow Is Nothing) Then Exit Function

            For Each WorkRow In objDataTableDetailsSpedizioni.Rows
                WorkPropertyId = WorkRow.Item("PropertyId")
                Select Case UCase(WorkPropertyId)
                    Case "LGNUM"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "LGNUM")
                    Case "WERKS"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "WERKS")
                    Case "LGTYP"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "LGTYP")
                    Case "LGPLA"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "LGPLA")
                    Case "LENUM"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "LENUM")
                        WorkPropertyValue = clsSapUtility.FormattaStringaUnitaMagazzino(WorkPropertyValue)
                    Case "MATNR"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "MATNR")
                        WorkPropertyValue = clsSapUtility.FormattaStringaCodiceMateriale(WorkPropertyValue)
                    Case "CHARG"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "CHARG")
                    Case "VRKME"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "VRKME")
                    Case "GESME_CONS"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "GESME_CONS")
                    Case "VERME_CONS"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "VERME_CONS")
                    Case "VERME_PZ"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "VERME_PZ")
                    Case "GESME_PZ"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "GESME_PZ")
                    Case "MEINS"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "MEINS")
                    Case "GESME"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "GESME")
                    Case "VERME"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "VERME")
                    Case "BESTQ"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "BESTQ")
                    Case "SOBKZ"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "SOBKZ")
                    Case "SONUM"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "SONUM")
                    Case "TBNUM"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "TBNUM")
                    Case "LQNUM"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "LQNUM")
                    Case "LGORT"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "LGORT")
                    Case "MAKTG"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "MAKTG")

                    Case "ODV_VBELN"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "ODV_VBELN")
                    Case "ODV_POSNR"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "ODV_POSNR")
                    Case "ODV_KUNNR_AG"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "ODV_KUNNR_AG")
                    Case "ODV_KUNNR_AG_NAME1"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "ODV_KUNNR_AG_NAME1")
                    Case "ODV_KUNNR_WE"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "ODV_KUNNR_WE")
                    Case "ODV_KUNNR_WE_NAME1"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "ODV_KUNNR_WE_NAME1")
                    Case "ODV_LIFNR_SP"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "ODV_LIFNR_SP")
                    Case "ODV_LIFNR_SP_NAME1"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "ODV_LIFNR_SP_NAME1")
                    Case "ZNR_WMS_JOBS"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "ZNR_WMS_JOBS")
                    Case "ZNR_WMS_JOBSGRP"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objSpedDataRow, "ZNR_WMS_JOBSGRP")
                    Case Else
                        WorkPropertyValue = "NO DATA"
                End Select
                WorkRow.Item("PropertyValue") = WorkPropertyValue
            Next

            RefreshDateTableSpedInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            RefreshDateTableSpedInfo = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


End Class
