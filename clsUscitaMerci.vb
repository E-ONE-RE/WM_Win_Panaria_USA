' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 08/11/2011
' DATA MODIFICA     : 20/06/2012
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la funzione di USCITA MERCI per PRODUZIONE
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType
Imports clsSapUtility

Public Class clsUscitaMerci

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsUscitaMerci"

    '*****************************************
    ' >>> TIPI DI DATI
    Public Enum UscitaMerci_DestinationType
        UscitaMerci_DestinationTypeNone = 0
        '        UM_Prod_DestinationTypeMagazzino = 1
        UscitaMerci_DestinationTypeOdP = 2
        UscitaMerci_DestinationTypeOdPAuto = 3
        UscitaMerci_DestinationTypeContoLavoro = 4
        UscitaMerci_DestinationTypeContoVisione = 5
    End Enum

    'OGGETTO DATA TABLE PER VISUALIZZARE DATI NELLE GRIGLIE
    Public Shared objDataTableGiacenzeInfo As New DataTable

    ' OGGETTO DATA TABLE PER VISUALIZZARE DATI NELLE GRIGLIE
    Public Shared objDataTableStockUM As New DataTable
    Public Shared objDataTableStockUM_Moved As New DataTable

    'INDICA LO STOCK SELEZIONATO NELLA VIDEATA [frmUscitaMerci_UMOdP_4]
    Public Shared IndiceStockUM_Selezionato As Long

    Public Shared AbilitaSceltaSingoloStock As Boolean

    Public Shared SourceUbicazione As clsDataType.SapWmUbicazione
    Public Shared DestinationUbicazione As clsDataType.SapWmUbicazione
    Public Shared MaterialeSourceGiacenza As clsDataType.SapWmGiacenza
    Public Shared MaterialeSourceGiacenzeFree() As clsDataType.SapWmGiacenza
    Public Shared UbicazioneDestProposte As clsDataType.SapWmUbicazione()
    Public Shared DescrUbiDestinazione As String
    Public Shared OrdineProduzioneDestinazione As clsDataType.SapOrdineProduzione

    Public Shared UscitaMerciDestinationType As UscitaMerci_DestinationType

    Public Shared SourceForm As Form


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

            UscitaMerciDestinationType = UscitaMerci_DestinationType.UscitaMerci_DestinationTypeNone

            RetCode += clsSapUtility.ResetUbicazioneStruct(SourceUbicazione)
            RetCode += clsSapUtility.ResetUbicazioneStruct(DestinationUbicazione)
            RetCode += clsSapUtility.ResetGiacenzaStruct(MaterialeSourceGiacenza)
            RetCode += clsSapUtility.ResetOrdineProduzioneStruct(OrdineProduzioneDestinazione)

            If (Not MaterialeSourceGiacenzeFree Is Nothing) Then
                ReDim MaterialeSourceGiacenzeFree(0)
                MaterialeSourceGiacenzeFree.Clear(MaterialeSourceGiacenzeFree, 0, 0)
            End If

            If (Not (objDataTableGiacenzeInfo Is Nothing)) Then
                objDataTableGiacenzeInfo.Rows.Clear()
            End If

            AbilitaSceltaSingoloStock = False

            IndiceStockUM_Selezionato = -1

            If (Not (objDataTableStockUM Is Nothing)) Then
                objDataTableStockUM.Rows.Clear()
            End If
            If (Not (objDataTableStockUM_Moved Is Nothing)) Then
                objDataTableStockUM_Moved.Rows.Clear()
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
            RetCode += clsSapUtility.ResetGiacenzaStruct(MaterialeSourceGiacenza)
            RetCode += clsSapUtility.ResetOrdineProduzioneStruct(OrdineProduzioneDestinazione)


            If (Not (objDataTableGiacenzeInfo Is Nothing)) Then
                objDataTableGiacenzeInfo.Rows.Clear()
            End If

            AbilitaSceltaSingoloStock = False


            IndiceStockUM_Selezionato = -1

            If (Not (objDataTableStockUM Is Nothing)) Then
                objDataTableStockUM.Rows.Clear()
            End If
            If (Not (objDataTableStockUM_Moved Is Nothing)) Then
                objDataTableStockUM_Moved.Rows.Clear()
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
    Public Shared Function ClearMaterialeSource() As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ClearMaterialeSource = 1 'init at error

            RetCode += clsSapUtility.ResetGiacenzaStruct(MaterialeSourceGiacenza)

            If (Not MaterialeSourceGiacenzeFree Is Nothing) Then
                ReDim MaterialeSourceGiacenzeFree(0)
                MaterialeSourceGiacenzeFree.Clear(MaterialeSourceGiacenzeFree, 0, 0)
            End If

            If (Not (objDataTableGiacenzeInfo Is Nothing)) Then
                objDataTableGiacenzeInfo.Rows.Clear()
            End If

            AbilitaSceltaSingoloStock = False

            ClearMaterialeSource = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ClearMaterialeSource = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function MoveStockUMFromDataTable(ByVal inIndexGiacenzaTrovata As Long, ByRef inQuantity As Double) As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim WorkRow As DataRow = Nothing
        Dim WorkRowCloned As DataRow = Nothing


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            MoveStockUMFromDataTable = 1 'init at error

            If (inIndexGiacenzaTrovata = -1) Then
                Exit Function
            End If

            If (objDataTableStockUM Is Nothing) Then
                RetCode = 10
                MoveStockUMFromDataTable = RetCode
                Exit Function
            End If
            If (objDataTableStockUM.Rows Is Nothing) Then
                RetCode = 11
                MoveStockUMFromDataTable = RetCode
                Exit Function
            End If
            If (objDataTableStockUM.Rows.Count = 0) Then
                RetCode = 12
                MoveStockUMFromDataTable = RetCode
                Exit Function
            End If
            If (objDataTableStockUM.Rows.Count < (inIndexGiacenzaTrovata)) Then
                RetCode = 13
                MoveStockUMFromDataTable = RetCode
                Exit Function
            End If

            'RECUPERO LA RIGA DELLO STOCK PRELEVATO
            WorkRow = objDataTableStockUM.Rows(inIndexGiacenzaTrovata)
            If (WorkRow Is Nothing) Then
                RetCode = 15
                MoveStockUMFromDataTable = RetCode
                Exit Function
            End If

            WorkRow.Item("GESME") = inQuantity
            WorkRow.Item("VERME") = inQuantity
            WorkRow.EndEdit()

            WorkRowCloned = WorkRow
            objDataTableStockUM_Moved.ImportRow(WorkRow)

            MoveStockUMFromDataTable = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            MoveStockUMFromDataTable = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ImpostaDestinazioniDefault() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ImpostaDestinazioniDefault = 1 'init at error

            If (clsUscitaMerci.UscitaMerciDestinationType = clsUscitaMerci.UscitaMerci_DestinationType.UscitaMerci_DestinationTypeContoLavoro) Then
                clsUscitaMerci.DestinationUbicazione.Divisione = DefaultUscitaMerci_ContoLav_Dest_Divisione
                clsUscitaMerci.DestinationUbicazione.NumeroMagazzino = DefaultUscitaMerci_ContoLav_Dest_NumMag
                clsUscitaMerci.DestinationUbicazione.TipoMagazzino = DefaultUscitaMerci_ContoLav_Dest_TipoMag
                clsUscitaMerci.DestinationUbicazione.Ubicazione = DefaultUscitaMerci_ContoLav_Dest_Ubicazione
            ElseIf (clsUscitaMerci.UscitaMerciDestinationType = clsUscitaMerci.UscitaMerci_DestinationType.UscitaMerci_DestinationTypeContoVisione) Then
                clsUscitaMerci.DestinationUbicazione.Divisione = DefaultUscitaMerci_ContoVis_Dest_Divisione
                clsUscitaMerci.DestinationUbicazione.NumeroMagazzino = DefaultUscitaMerci_ContoVis_Dest_NumMag
                clsUscitaMerci.DestinationUbicazione.TipoMagazzino = DefaultUscitaMerci_ContoVis_Dest_TipoMag
                clsUscitaMerci.DestinationUbicazione.Ubicazione = DefaultUscitaMerci_ContoVis_Dest_Ubicazione
            End If

            ImpostaDestinazioniDefault = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ImpostaDestinazioniDefault = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetGiacenzaInStockUM(ByRef inUMGiacenza As clsDataType.SapWmGiacenza, ByRef inIndexGiacenzaTrovata As Long) As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim WorkRow As DataRow = Nothing
        Dim WorkValue As String = ""
        Dim IndexRow As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetGiacenzaInStockUM = 1 'init at error

            inIndexGiacenzaTrovata = -1 'INIT AT NOT FOUND

            If (objDataTableStockUM Is Nothing) Then
                RetCode = 10
                GetGiacenzaInStockUM = RetCode
                Exit Function
            End If

            If (objDataTableStockUM.Rows Is Nothing) Then
                RetCode = 11
                GetGiacenzaInStockUM = RetCode
                Exit Function
            End If

            If (objDataTableStockUM.Rows.Count = 0) Then
                RetCode = 12
                GetGiacenzaInStockUM = RetCode
                Exit Function
            End If

            For Each WorkRow In objDataTableStockUM.Rows
                WorkValue = clsUtility.GetDataRowItem(WorkRow, "MATNR", "", False)
                If (UCase(WorkValue) = UCase(inUMGiacenza.CodiceMateriale)) Then
                    WorkValue = clsUtility.GetDataRowItem(WorkRow, "CHARG", "", False)
                    If (UCase(WorkValue) = UCase(inUMGiacenza.Partita)) Then
                        WorkValue = clsUtility.GetDataRowItem(WorkRow, "LGNUM", "", False)
                        If (UCase(WorkValue) = UCase(inUMGiacenza.UbicazioneInfo.NumeroMagazzino)) Then
                            WorkValue = clsUtility.GetDataRowItem(WorkRow, "LGTYP", "", False)
                            If (UCase(WorkValue) = UCase(inUMGiacenza.UbicazioneInfo.TipoMagazzino)) Then
                                WorkValue = clsUtility.GetDataRowItem(WorkRow, "LENUM", "", False)
                                If (UCase(WorkValue) = UCase(clsSapUtility.FormattaStringaUnitaMagazzino(inUMGiacenza.UbicazioneInfo.UnitaMagazzino))) Then
                                    inIndexGiacenzaTrovata = IndexRow
                                    Exit For
                                End If
                            End If
                        End If
                    End If
                End If
                IndexRow += 1
            Next

            GetGiacenzaInStockUM = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetGiacenzaInStockUM = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CreateDateTableForStockUM() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForStockUM = 1 'init at error

            Dim WorkWERKS As DataColumn = New DataColumn("WERKS") 'declaring a column named Name
            WorkWERKS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM.Columns.Add(WorkWERKS) 'adding the column to table

            Dim WorkLGNUM As DataColumn = New DataColumn("LGNUM") 'declaring a column named Name
            WorkLGNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM.Columns.Add(WorkLGNUM) 'adding the column to table

            Dim WorkLGTYP As DataColumn = New DataColumn("LGTYP") 'declaring a column named Name
            WorkLGTYP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM.Columns.Add(WorkLGTYP) 'adding the column to table

            Dim WorkLGPLA As DataColumn = New DataColumn("LGPLA") 'declaring a column named Name
            WorkLGPLA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM.Columns.Add(WorkLGPLA) 'adding the column to table

            Dim WorkLQNUM As DataColumn = New DataColumn("LQNUM") 'declaring a column named Name
            WorkLQNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM.Columns.Add(WorkLQNUM) 'adding the column to table

            Dim WorkMATNR As DataColumn = New DataColumn("MATNR") 'declaring a column named Name
            WorkMATNR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM.Columns.Add(WorkMATNR) 'adding the column to table

            Dim WorkCHARG As DataColumn = New DataColumn("CHARG") 'declaring a column named Name
            WorkCHARG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM.Columns.Add(WorkCHARG) 'adding the column to table

            Dim WorkBESTQ As DataColumn = New DataColumn("BESTQ") 'declaring a column named Name
            WorkBESTQ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM.Columns.Add(WorkBESTQ) 'adding the column to table

            Dim WorkMEINS As DataColumn = New DataColumn("MEINS") 'declaring a column named Name
            WorkMEINS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM.Columns.Add(WorkMEINS) 'adding the column to table

            Dim WorkGESME As DataColumn = New DataColumn("GESME") 'declaring a column named Name
            WorkGESME.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM.Columns.Add(WorkGESME) 'adding the column to table

            Dim WorkVERME As DataColumn = New DataColumn("VERME") 'declaring a column named Name
            WorkVERME.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM.Columns.Add(WorkVERME) 'adding the column to table

            Dim WorkLENUM As DataColumn = New DataColumn("LENUM") 'declaring a column named Name
            WorkLENUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM.Columns.Add(WorkLENUM) 'adding the column to table

            Dim WorkSOBKZ As DataColumn = New DataColumn("SOBKZ") 'declaring a column named Name
            WorkSOBKZ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM.Columns.Add(WorkSOBKZ) 'adding the column to table

            Dim WorkSONUM As DataColumn = New DataColumn("SONUM") 'declaring a column named Name
            WorkSONUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM.Columns.Add(WorkSONUM) 'adding the column to table

            Dim WorkLGORT As DataColumn = New DataColumn("LGORT") 'declaring a column named Name
            WorkLGORT.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM.Columns.Add(WorkLGORT) 'adding the column to table

            CreateDateTableForStockUM = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForStockUM = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function CreateDateTableForStockUM_Moved() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForStockUM_Moved = 1 'init at error

            Dim WorkWERKS As DataColumn = New DataColumn("WERKS") 'declaring a column named Name
            WorkWERKS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM_Moved.Columns.Add(WorkWERKS) 'adding the column to table

            Dim WorkLGNUM As DataColumn = New DataColumn("LGNUM") 'declaring a column named Name
            WorkLGNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM_Moved.Columns.Add(WorkLGNUM) 'adding the column to table

            Dim WorkLGTYP As DataColumn = New DataColumn("LGTYP") 'declaring a column named Name
            WorkLGTYP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM_Moved.Columns.Add(WorkLGTYP) 'adding the column to table

            Dim WorkLGPLA As DataColumn = New DataColumn("LGPLA") 'declaring a column named Name
            WorkLGPLA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM_Moved.Columns.Add(WorkLGPLA) 'adding the column to table

            Dim WorkLQNUM As DataColumn = New DataColumn("LQNUM") 'declaring a column named Name
            WorkLQNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM_Moved.Columns.Add(WorkLQNUM) 'adding the column to table

            Dim WorkMATNR As DataColumn = New DataColumn("MATNR") 'declaring a column named Name
            WorkMATNR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM_Moved.Columns.Add(WorkMATNR) 'adding the column to table

            Dim WorkCHARG As DataColumn = New DataColumn("CHARG") 'declaring a column named Name
            WorkCHARG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM_Moved.Columns.Add(WorkCHARG) 'adding the column to table

            Dim WorkBESTQ As DataColumn = New DataColumn("BESTQ") 'declaring a column named Name
            WorkBESTQ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM_Moved.Columns.Add(WorkBESTQ) 'adding the column to table

            Dim WorkMEINS As DataColumn = New DataColumn("MEINS") 'declaring a column named Name
            WorkMEINS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM_Moved.Columns.Add(WorkMEINS) 'adding the column to table

            Dim WorkGESME As DataColumn = New DataColumn("GESME") 'declaring a column named Name
            WorkGESME.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM_Moved.Columns.Add(WorkGESME) 'adding the column to table

            Dim WorkVERME As DataColumn = New DataColumn("VERME") 'declaring a column named Name
            WorkVERME.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM_Moved.Columns.Add(WorkVERME) 'adding the column to table

            Dim WorkLENUM As DataColumn = New DataColumn("LENUM") 'declaring a column named Name
            WorkLENUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM_Moved.Columns.Add(WorkLENUM) 'adding the column to table

            Dim WorkSOBKZ As DataColumn = New DataColumn("SOBKZ") 'declaring a column named Name
            WorkSOBKZ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM_Moved.Columns.Add(WorkSOBKZ) 'adding the column to table

            Dim WorkSONUM As DataColumn = New DataColumn("SONUM") 'declaring a column named Name
            WorkSONUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM_Moved.Columns.Add(WorkSONUM) 'adding the column to table

            Dim WorkLGORT As DataColumn = New DataColumn("LGORT") 'declaring a column named Name
            WorkLGORT.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableStockUM_Moved.Columns.Add(WorkLGORT) 'adding the column to table

            CreateDateTableForStockUM_Moved = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForStockUM_Moved = 1000 'IL THREAD E' USCITO DAL LOOP
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

            Dim WorkWERKS As DataColumn = New DataColumn("WERKS") 'declaring a column named Name
            WorkWERKS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkWERKS) 'adding the column to table

            Dim WorkLGNUM As DataColumn = New DataColumn("LGNUM") 'declaring a column named Name
            WorkLGNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkLGNUM) 'adding the column to table

            Dim WorkLGTYP As DataColumn = New DataColumn("LGTYP") 'declaring a column named Name
            WorkLGTYP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkLGTYP) 'adding the column to table

            Dim WorkLGPLA As DataColumn = New DataColumn("LGPLA") 'declaring a column named Name
            WorkLGPLA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkLGPLA) 'adding the column to table

            Dim WorkLQNUM As DataColumn = New DataColumn("LQNUM") 'declaring a column named Name
            WorkLQNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkLQNUM) 'adding the column to table

            Dim WorkMATNR As DataColumn = New DataColumn("MATNR") 'declaring a column named Name
            WorkMATNR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkMATNR) 'adding the column to table

            Dim WorkCHARG As DataColumn = New DataColumn("CHARG") 'declaring a column named Name
            WorkCHARG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkCHARG) 'adding the column to table

            Dim WorkBESTQ As DataColumn = New DataColumn("BESTQ") 'declaring a column named Name
            WorkBESTQ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkBESTQ) 'adding the column to table

            Dim WorkMEINS As DataColumn = New DataColumn("MEINS") 'declaring a column named Name
            WorkMEINS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkMEINS) 'adding the column to table

            Dim WorkGESME As DataColumn = New DataColumn("GESME") 'declaring a column named Name
            WorkGESME.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkGESME) 'adding the column to table

            Dim WorkVERME As DataColumn = New DataColumn("VERME") 'declaring a column named Name
            WorkVERME.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkVERME) 'adding the column to table

            Dim WorkLENUM As DataColumn = New DataColumn("LENUM") 'declaring a column named Name
            WorkLENUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkLENUM) 'adding the column to table

            Dim WorkSOBKZ As DataColumn = New DataColumn("SOBKZ") 'declaring a column named Name
            WorkSOBKZ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkSOBKZ) 'adding the column to table

            Dim WorkSONUM As DataColumn = New DataColumn("SONUM") 'declaring a column named Name
            WorkSONUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkSONUM) 'adding the column to table

            Dim WorkLGORT As DataColumn = New DataColumn("LGORT") 'declaring a column named Name
            WorkLGORT.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkLGORT) 'adding the column to table

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
                RetCode = clsNavigation.Show_Mnu_Main_UscitaMerci(inSourceForm, True)
                Go_To_Original_Menu = RetCode
                Exit Function
            End If

            Select Case SourceForm.GetType.Name
                Case frmMenuUscitaMerciMain.GetType.Name
                    RetCode = clsNavigation.Show_Mnu_Main_UscitaMerci(inSourceForm, True)
                    Go_To_Original_Menu = RetCode
                    Exit Function
                Case Else
                    RetCode = clsNavigation.Show_Mnu_Main_UscitaMerci(inSourceForm, True)
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

End Class
