Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Windows.Forms.DataGrid
Imports System.Xml
Imports clsDataType
Imports clsSapUtility
Imports Microsoft.VisualBasic

Public Class clsShowUtility

    Private Const CodeClassObjectName As String = "clsShowUtility"
    '*****************************************

    Private Shared CurrentWidth As Integer = 0 ' Current Width
    Private Shared CurrentHeight As Integer = 0 ' Current Height
    Private Shared InitialWidth As Integer = 0 ' Initial Width
    Private Shared InitialHeight As Integer = 0 ' Initial Height

    '*****************************************
    'MANAGEMENT OF OBJECT

    Public Shared Function DataGrid_ClearSelection(ByRef inDataGrid As DataGrid, ByVal inNumRows As Long, Optional ByVal inSelectedRow As Long = -1) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            DataGrid_ClearSelection = 1

            If (inDataGrid Is Nothing) Then
                DataGrid_ClearSelection = RetCode
                Exit Function
            End If

            If (inNumRows < 1) Then
                DataGrid_ClearSelection = RetCode
                Exit Function
            End If

            For Index = 0 To inNumRows - 1
                If (inSelectedRow > 0) And (inSelectedRow = Index) Then
                    inDataGrid.Select(Index)
                Else
                    inDataGrid.UnSelect(Index)
                End If
            Next

            DataGrid_ClearSelection = RetCode '>> SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            DataGrid_ClearSelection = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CheckUnitaMagazzinoEntered(ByRef inTextEntered As String, ByRef outUnitaMagazzinoOk As Boolean, ByVal inShowMessageBox As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim ErrDescription As String = ""
        Dim UserAnswer As DialogResult
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CheckUnitaMagazzinoEntered = 0
            outUnitaMagazzinoOk = True

            If (inTextEntered = "") Then
                Exit Function
            End If

            '>>> DEVO ELIMINARE EVENTUALI CARATTERI DI SPAZIO INSERITI
            inTextEntered = Trim(inTextEntered)

            If (IsNumeric(inTextEntered) = False) Then
                outUnitaMagazzinoOk = False
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(929, "", "L'Unita Magazzino specificata non è NUMERICA.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(568, "", "Verificare i dati immessi e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
            Else
                If (Val(inTextEntered) >= RangeInternoUnitaMagazzinoStart) And (Val(inTextEntered) <= RangeInternoUnitaMagazzinoEnd) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(930, "", "L'Unita Magazzino specificata e' nel RANGE INTERNO riservato a SAP.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(931, "", "Se e' una nuova palletta e' un errore, se e' una paletta a sistema e' OK.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(932, "", "Continuare ?")
                    UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    If (UserAnswer <> DialogResult.Yes) Then
                        outUnitaMagazzinoOk = False
                    End If
                End If

                If (InStr(inTextEntered, ".") > 0) Or (InStr(inTextEntered, ",") > 0) Then
                    outUnitaMagazzinoOk = False
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(929, "", "L'Unita Magazzino specificata non è NUMERICA.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(568, "", "Verificare i dati immessi e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If

            End If

                If (Len(inTextEntered) > 10) Then
                    outUnitaMagazzinoOk = False
                    If (inShowMessageBox = True) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(933, "", "Lunghezza dell'Unita Magazzino specificata non corretta (>10).") & vbCrLf & clsAppTranslation.GetSingleParameterValue(568, "", "Verificare i dati immessi e riprovare.")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If
                ElseIf (Len(inTextEntered) < 10) Then
                    outUnitaMagazzinoOk = False
                    If (inShowMessageBox = True) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1619, "", "Lunghezza dell'Unita Magazzino specificata non corretta (<10).") & vbCrLf & clsAppTranslation.GetSingleParameterValue(568, "", "Verificare i dati immessi e riprovare.")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If
                End If

                CheckUnitaMagazzinoEntered = RetCode '>> SE = 0 TUTTO OK

                '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckUnitaMagazzinoEntered = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CheckSKUEntered(ByRef inTextEntered As String, ByRef outSKUOk As Boolean, ByVal inShowMessageBox As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim ErrDescription As String = ""

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CheckSKUEntered = 0
            outSKUOk = True

            If (inTextEntered = "") Then
                Exit Function
            End If

            '>>> DEVO ELIMINARE EVENTUALI CARATTERI DI SPAZIO INSERITI
            inTextEntered = Trim(inTextEntered)

            If (Len(inTextEntered) > 9) Then
                outSKUOk = False
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(235, "", "Lunghezza del codice SKU specificata non corretta (>9).") & vbCrLf & clsAppTranslation.GetSingleParameterValue(568, "", "Verificare i dati immessi e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
            End If

            CheckSKUEntered = RetCode '>> SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckSKUEntered = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function SetStandardApplicationFormProperties(ByVal inForm As Form, ByVal inShowMessageBox As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            SetStandardApplicationFormProperties = 1

            If (inForm Is Nothing) Then
                RetCode = 0
                SetStandardApplicationFormProperties = RetCode
                Exit Function
            End If

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CASO CON PALMARE / WIN CE
            inForm.MaximizeBox = False
            inForm.MinimizeBox = False
            inForm.ControlBox = False
#Else
            'CASO APPLICAZIONE WIN 32
            inForm.MaximizeBox = True
            inForm.MinimizeBox = False
            inForm.ControlBox = False
            'inForm.WindowState = FormWindowState.Maximized
            inForm.FormBorderStyle = FormBorderStyle.FixedSingle
            inForm.SetDesktopLocation(0, 0)
#End If


            SetStandardApplicationFormProperties = RetCode '>> SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            SetStandardApplicationFormProperties = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CheckSameStockUbiDestination(ByRef inGiacenzaToTransfer As clsDataType.SapWmGiacenza, ByRef inGiacenzeUbi() As clsDataType.SapWmGiacenza, ByRef outCheckSameStockUbiDestinationOk As Boolean, ByVal inShowMessageBox As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim ErrDescription As String = ""

        Dim WorkIndexLoop As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CheckSameStockUbiDestination = 0

            outCheckSameStockUbiDestinationOk = True

            If (inGiacenzeUbi Is Nothing) Then
                Exit Function
            End If

            If (inGiacenzeUbi.Length <= 0) Then
                Exit Function
            End If

            'VERIFICO SE LA GIACENZA DA TRASFERIRE MATCHA QUELLA DELL'UBICAZIONE DI DESTINAZIONE
            For WorkIndexLoop = 0 To (inGiacenzeUbi.Length - 1)
                If (UCase(Trim(inGiacenzaToTransfer.CodiceMateriale)) <> UCase(Trim(inGiacenzeUbi(WorkIndexLoop).CodiceMateriale))) Then
                    If (inShowMessageBox = True) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1219, "", "Codice Materiale diverso in UBICAZIONE destinazione.")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If
                    outCheckSameStockUbiDestinationOk = False
                    Exit Function
                End If
                If (UCase(inGiacenzaToTransfer.Partita) <> UCase(inGiacenzeUbi(WorkIndexLoop).Partita)) Then
                    If (inShowMessageBox = True) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1220, "", "Partita Materiale diversa in UBICAZIONE destinazione.")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If
                    outCheckSameStockUbiDestinationOk = False
                    Exit Function
                End If
            Next


            CheckSameStockUbiDestination = RetCode '>> SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckSameStockUbiDestination = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CheckDocumentoMaterialeEntered(ByRef inTextEntered As String, ByRef outDocumentoMaterialeOk As Boolean, ByVal inShowMessageBox As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim ErrDescription As String = ""

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CheckDocumentoMaterialeEntered = 0

            outDocumentoMaterialeOk = True

            If (inTextEntered = "") Then
                Exit Function
            End If

            '>>> DEVO ELIMINARE EVENTUALI CARATTERI DI SPAZIO INSERITI
            inTextEntered = Trim(inTextEntered)

            If (IsNumeric(inTextEntered) = False) Then
                outDocumentoMaterialeOk = False
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(934, "", "Il DOCUMENTO MATERIALE specificato non è NUMERICO.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(568, "", "Verificare i dati immessi e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
            End If

            If (Len(inTextEntered) < 14) Then
                outDocumentoMaterialeOk = False
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(935, "", "Lunghezza del DOCUMENTO MATERIALE specificato non corretta (<14).") & vbCrLf & clsAppTranslation.GetSingleParameterValue(568, "", "Verificare i dati immessi e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
            End If

            If (Len(inTextEntered) > 18) Then
                outDocumentoMaterialeOk = False
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(936, "", "Lunghezza del DOCUMENTO MATERIALE specificato non corretta (>18).") & vbCrLf & clsAppTranslation.GetSingleParameterValue(568, "", "Verificare i dati immessi e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
            End If

            If (Len(inTextEntered) > 14) And (Len(inTextEntered) < 18) Then
                outDocumentoMaterialeOk = False
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(937, "", "Lunghezza del DOCUMENTO MATERIALE specificato non corretta (>14).") & vbCrLf & clsAppTranslation.GetSingleParameterValue(568, "", "Verificare i dati immessi e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
            End If

            CheckDocumentoMaterialeEntered = RetCode '>> SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckDocumentoMaterialeEntered = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CheckJobsEnteredString(ByRef inNrJob As String, ByRef outNrJobOk As Boolean, Optional ByVal inShowMessageBox As Boolean = False) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim ErrDescription As String = ""

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CheckJobsEnteredString = 1 'inti at error

            outNrJobOk = True
            If (Len(inNrJob) > 10) Then
                outNrJobOk = False
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1807, "", "Il NUMERO MISSIONE digitato non è corretto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(921, "", "La lunghezza è superiore a 10 caratteri.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            'SE ARRIVO QUI UBICAZIONE OK
            outNrJobOk = True

            CheckJobsEnteredString = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckJobsEnteredString = 10000

#If APPLICAZIONE_WIN32 <> "SI" Then
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
#Else
            Windows.Forms.Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
#End If

            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CheckJobsGroupEnteredString(ByRef inJobsGroup As String, ByRef outJobsGroupOk As Boolean, Optional ByVal inShowMessageBox As Boolean = False) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim ErrDescription As String = ""

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CheckJobsGroupEnteredString = 1 'inti at error

            outJobsGroupOk = True
            If (Len(inJobsGroup) > 10) Then
                outJobsGroupOk = False
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(922, "", "Il GRUPPO MISSIONI digitato non è corretto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(921, "", "La lunghezza è superiore a 10 caratteri.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            'SE ARRIVO QUI UBICAZIONE OK
            outJobsGroupOk = True

            CheckJobsGroupEnteredString = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckJobsGroupEnteredString = 10000

#If APPLICAZIONE_WIN32 <> "SI" Then
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
#Else
            Windows.Forms.Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
#End If

            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function CheckUbicaOrUnitaMagEnteredString(ByRef inUbicaOrUnitaMag As String, ByRef outUbicaOrUnitaMagEntered As clsDataType.UbicaOrUnitaMagEnteredEnum, Optional ByVal inShowMessageBox As Boolean = False) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CheckUbicaOrUnitaMagEnteredString = 1 'inti at error

            outUbicaOrUnitaMagEntered = clsDataType.UbicaOrUnitaMagEnteredEnum.UbicaOrUnitaMagEnteredNone

            If (Len(inUbicaOrUnitaMag) <> 10) Then
                'SE LUNGHEZZA <> 10 ALLORA E' UNA UBICAZIONE
                outUbicaOrUnitaMagEntered = clsDataType.UbicaOrUnitaMagEnteredEnum.UbicaOrUnitaMagEnteredUbicazione
            Else
                'IN QUESTO CASO SE CONTIENE SOLO NUMERI ALLORA E' UNA UNITA MAGAZZINO
                If (IsNumeric(inUbicaOrUnitaMag)) Then
                    outUbicaOrUnitaMagEntered = clsDataType.UbicaOrUnitaMagEnteredEnum.UbicaOrUnitaMagEnteredUnitaMagazzino
                Else
                    outUbicaOrUnitaMagEntered = clsDataType.UbicaOrUnitaMagEnteredEnum.UbicaOrUnitaMagEnteredUbicazione
                End If
            End If


            CheckUbicaOrUnitaMagEnteredString = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckUbicaOrUnitaMagEnteredString = 10000


            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function CheckSkuOrUnitaMagEnteredString(ByRef inUbicaOrUnitaMag As String, ByRef outSkuOrUnitaMagEntered As clsDataType.SkuOrUnitaMagEnteredEnum, Optional ByVal inShowMessageBox As Boolean = False) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CheckSkuOrUnitaMagEnteredString = 1 'inti at error

            outSkuOrUnitaMagEntered = clsDataType.SkuOrUnitaMagEnteredEnum.SkuOrUnitaMagEnteredNone

            If (Len(inUbicaOrUnitaMag) = 9) Then
                'SE LUNGHEZZA = 9 E CONTIENE DEI CARATTERI ALLORA E' UNO SKU
                If (Not IsNumeric(inUbicaOrUnitaMag)) Then
                    outSkuOrUnitaMagEntered = clsDataType.SkuOrUnitaMagEnteredEnum.SkuOrUnitaMagEnteredSku
                End If
            ElseIf (Len(inUbicaOrUnitaMag) = 10) Then
                'IN QUESTO CASO SE CONTIENE SOLO NUMERI ALLORA E' UNA UNITA MAGAZZINO
                If (IsNumeric(inUbicaOrUnitaMag)) Then
                    outSkuOrUnitaMagEntered = clsDataType.SkuOrUnitaMagEnteredEnum.SkuOrUnitaMagEnteredUnitaMagazzino
                End If
            End If


            CheckSkuOrUnitaMagEnteredString = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckSkuOrUnitaMagEnteredString = 10000


            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CheckUbicazioneEnteredString(ByRef inUbicazione As String, ByRef outUbicazioneOk As Boolean, Optional ByVal inShowMessageBox As Boolean = False, Optional ByRef outUbicazione As String = "") As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim ErrDescription As String = ""
        Dim WorkChar As Char

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CheckUbicazioneEnteredString = 1 'inti at error

            outUbicazione = inUbicazione
            outUbicazioneOk = True

            'SE STRINGA UBICAZIONE VUOTA ESCO SENZA FARE NULLA
            If (inUbicazione = "") Then
                CheckUbicazioneEnteredString = RetCode
                Exit Function
            End If

            'SE L'UBICAZIONE CONTIENE SOLO NUMERI NON ESEGUO NESSUN REVERSE
            If (IsNumeric(inUbicazione)) Then
                CheckUbicazioneEnteredString = RetCode
                Exit Function
            End If

            If (Len(inUbicazione) > 10) Then
                outUbicazioneOk = False
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(920, "", "L'Ubicazione digitata non è corretta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(921, "", "La lunghezza è superiore a 10 caratteri.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            If (CodiceUbicazioneAbilitaReverse = True) Then
                If (Len(inUbicazione) = 8) Then
                    WorkChar = GetChar(inUbicazione, 8)
                    If (Not Char.IsNumber(WorkChar)) Then
                        outUbicazione = StrReverse(inUbicazione)
                    End If
                End If

                'CASO PARTICOLARE PER LE UBICAZIONI DI STAGING ( "STGxxx" )
                If ((Len(inUbicazione) = 5) Or (Len(inUbicazione) = 6)) Then
                    If (UCase(Microsoft.VisualBasic.Right(inUbicazione, 3)) = "GTS") Then
                        outUbicazione = StrReverse(inUbicazione)
                    End If
                End If

                'CASO PARTICOLARE PER LE UBICAZIONI DI DOOK DOOR ( "DDxxx" )
                If (Len(inUbicazione) = 4) Or (Len(inUbicazione) = 5) Then
                    If (UCase(Microsoft.VisualBasic.Right(inUbicazione, 2)) = "DD") Then
                        outUbicazione = StrReverse(inUbicazione)
                    End If
                End If

                'CASO PARTICOLARE PER LE UBICAZIONI DI PICK AND DROP ( "PDExxx" )
                If (Len(inUbicazione) = 5) Or (Len(inUbicazione) = 6) Then
                    If (UCase(Microsoft.VisualBasic.Right(inUbicazione, 3)) = "EDP") Then
                        outUbicazione = StrReverse(inUbicazione)
                    End If
                End If

                'CASO PARTICOLARE PER LE UBICAZIONI DI WRAPPING ( "WRx" )
                If (Len(inUbicazione) = 3) Then
                    If (UCase(Microsoft.VisualBasic.Right(inUbicazione, 2)) = "RW") Then
                        outUbicazione = StrReverse(inUbicazione)
                    End If
                End If

                If (UCase(inUbicazione) = "DDSPU") Then
                    outUbicazione = StrReverse(inUbicazione)
                End If
            End If

            'SE ARRIVO QUI UBICAZIONE OK
            outUbicazioneOk = True

            CheckUbicazioneEnteredString = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckUbicazioneEnteredString = 10000

#If APPLICAZIONE_WIN32 <> "SI" Then
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
#Else
            Windows.Forms.Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
#End If

            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function CheckUbicazioneBeforeHelpList(ByRef inTextEntered As String, ByVal inMinCarEntered As Long, ByVal inShowMessageBox As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim ErrDescription As String
        Dim strLen As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CheckUbicazioneBeforeHelpList = 1

            If ((inTextEntered = "") And (inMinCarEntered > 0)) Then
                RetCode = 10
                CheckUbicazioneBeforeHelpList = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(938, "", "Inserire un numero minimo di caratteri") & "(" & Trim(Str(inMinCarEntered)) & ")" & clsAppTranslation.GetSingleParameterValue(939, "", ". Verificare i dati inseriti e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            strLen = Len(inTextEntered)
            If (strLen < inMinCarEntered) Then
                RetCode = 20
                CheckUbicazioneBeforeHelpList = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(938, "", "Inserire un numero minimo di caratteri") & "(" & Trim(Str(inMinCarEntered)) & ")" & clsAppTranslation.GetSingleParameterValue(939, "", ". Verificare i dati inseriti e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            '>>> DEVO ELIMINARE EVENTUALI CARATTERI DI SPAZIO INSERITI
            inTextEntered = Trim(inTextEntered)

            CheckUbicazioneBeforeHelpList = RetCode '>> SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckUbicazioneBeforeHelpList = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function FromSapWmGiacenzaStructToString(ByVal inSapWmGiacenza As clsDataType.SapWmGiacenza, ByVal inDocumentoMaterialeBEM As clsDataType.SapWmDocumentoMateriale, Optional ByVal inShowMode As Long = 0) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim tmpString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            FromSapWmGiacenzaStructToString = ""

            'inShowMode = 0 (DEFAULT)
            ' >>>> COD.MATERIALE: [CODICE MATERIALE]
            ' >>>> PARTITA: [PARTITA]            
            ' >>>> QTA DISP.(UdM BASE): [QtaTotaleDisponibile] - [UnitaDiMisuraBase] 
            ' >>>> QTA DISP.(UdM PICK): [QtaTotaleDispoUdMAcq] - [UnitaDiMisuraAcquisizione]
            ' >>>> DESCR.: [DESCRIZIONE]

            'inShowMode = 1
            ' >>>> COD.MATERIALE: [CODICE MATERIALE]
            ' >>>> PARTITA: [PARTITA]            
            ' >>>> QTA DISP (UDM CONSEGNA): [QtaTotaleDispoUdMAcq] - [UnitaDiMisuraAcquisizione]
            ' >>>> U.MAG.:[UnitaMagazzino]
            ' >>>> ST.SPEC.: [CdStockSpeciale] - [NumeroStockSpeciale]
            ' >>>> DESCR.: [DESCRIZIONE]

            'inShowMode = 2
            ' >>>> DOC.MATERIALE: [NUMERO DOCMAT]
            ' >>>> POS.DOC.MAT.: [POS.DOC.MAT]
            ' >>>> COD.MATERIALE: [CODICE MATERIALE]
            ' >>>> PARTITA: [PARTITA]
            ' >>>> QTA: [QuantitaInUdMAcquisizione] - [UnitaDiMisuraAcquisizione]
            ' >>>> U.MAG.:[UnitaMagazzino]
            ' >>>> ST.SPEC.: [CdStockSpeciale] - [NumeroStockSpeciale]
            ' >>>> DESCR.: [DESCRIZIONE]

            'inShowMode = 3
            ' >>>> COD.MATERIALE: [CODICE MATERIALE]
            ' >>>> PARTITA: [PARTITA]
            ' >>>> QTA DISP (UDM CONSEGNA): [QtaTotaleDispoUdMAcq] - [UnitaDiMisuraAcquisizione]
            ' >>>> UBI.:[TIPO MAGAZZINO] - [UBICAZIONE]
            ' >>>> DESCR.: [DESCRIZIONE]

            'inShowMode = 4 (USANDO LA POSIZIONE DEL DOCUMENTO MATERIALE)
            ' >>>> DOC.MATERIALE: [NUMERO DOCMAT]
            ' >>>> POS.DOC.MAT.: [POS.DOC.MAT]
            ' >>>> COD.MATERIALE: [CODICE MATERIALE]
            ' >>>> PARTITA: [PARTITA]
            ' >>>> QTA (UDM CONSEGNA): [QuantitaInUdMAcquisizione] - [UnitaDiMisuraAcquisizione]
            ' >>>> STOCK SPECIALE:[CdStockSpeciale] - [NumeroStockSpeciale]
            ' >>>> DESCR.: [DESCRIZIONE]

            'inShowMode = 5 (CON QTA CONFERMATA IN CONFERMA EM.DOC.MATERIALE)
            ' >>>> DOC.MATERIALE: [NUMERO DOCMAT]
            ' >>>> POS.DOC.MAT.: [POS.DOC.MAT]
            ' >>>> COD.MATERIALE: [CODICE MATERIALE]
            ' >>>> PARTITA: [PARTITA]
            ' >>>> QTA: [QuantitaTotaleXInfoOperatore] - [UdmQuantitaTotaleXInfoOperatore]  QTA x PAL:[ScatolePerPallet]-[UDM CONSEGNA]
            ' >>>> DESCR.: [DESCRIZIONE]

            'inShowMode = 6 
            ' >>>> U.MAG.:[UnitaMagazzino]
            ' >>>> MAT: [CODICE MATERIALE]  QTA:(UdM BASE): [QtaTotaleDisponibile] - (UdM) [UnitaDiMisuraBase]        

            Select Case inShowMode
                Case 0
                    tmpString += clsAppTranslation.GetSingleParameterValue(940, "", "COD.MATERIALE: ")
                    If (clsUtility.IsStringValid(inSapWmGiacenza.CodiceMateriale, True) = True) Then
                        tmpString += UCase(inSapWmGiacenza.CodiceMateriale)
                    End If
                    tmpString += vbCrLf

                    tmpString += clsAppTranslation.GetSingleParameterValue(851, "", "PARTITA:")
                    If (clsUtility.IsStringValid(inSapWmGiacenza.Partita, True) = True) Then
                        tmpString += UCase(inSapWmGiacenza.Partita)
                    End If
                    tmpString += vbCrLf

                    tmpString += clsAppTranslation.GetSingleParameterValue(941, "", "QTA DISP.(UdM BASE):") + UCase(inSapWmGiacenza.QtaTotaleLquaDisponibile) + " " + UCase(inSapWmGiacenza.UnitaDiMisuraBase)
                    tmpString += vbCrLf

                    tmpString += clsAppTranslation.GetSingleParameterValue(942, "", "QTA DISP.(UdM CONS.):") + UCase(inSapWmGiacenza.QtaTotaleLquaDispoUdMAcq) + " " + UCase(inSapWmGiacenza.UnitaDiMisuraAcquisizione)
                    tmpString += vbCrLf

                    If (clsUtility.IsStringValid(inSapWmGiacenza.UbicazioneInfo.UnitaMagazzino, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(943, "", "U.MAG.:") + clsSapUtility.FormattaStringaUnitaMagazzino(inSapWmGiacenza.UbicazioneInfo.UnitaMagazzino)
                        tmpString += vbCrLf
                    End If

                    If (clsUtility.IsStringValid(inSapWmGiacenza.TipoStock, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(896, "", "TIPO STOCK:") + inSapWmGiacenza.TipoStock
                        tmpString += vbCrLf
                    End If

                    If (clsUtility.IsStringValid(inSapWmGiacenza.CdStockSpeciale, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(944, "", "ST.SPEC.:") + inSapWmGiacenza.CdStockSpeciale + "-" + inSapWmGiacenza.NumeroStockSpeciale
                        tmpString += vbCrLf
                    End If

                    tmpString += clsAppTranslation.GetSingleParameterValue(945, "", "DESCR.:") + UCase(inSapWmGiacenza.DescrizioneMateriale)

                Case 1
                    tmpString += clsAppTranslation.GetSingleParameterValue(940, "", "COD.MATERIALE: ")
                    If (clsUtility.IsStringValid(inSapWmGiacenza.CodiceMateriale, True) = True) Then
                        tmpString += UCase(inSapWmGiacenza.CodiceMateriale)
                    End If

                    tmpString += " - "

                    tmpString += clsAppTranslation.GetSingleParameterValue(945, "", "DESCR.:") + UCase(inSapWmGiacenza.DescrizioneMateriale)

                    tmpString += vbCrLf

                    tmpString += clsAppTranslation.GetSingleParameterValue(851, "", "PARTITA:")
                    If (clsUtility.IsStringValid(inSapWmGiacenza.Partita, True) = True) Then
                        tmpString += UCase(inSapWmGiacenza.Partita)
                    End If
                    tmpString += vbCrLf

                    tmpString += clsAppTranslation.GetSingleParameterValue(946, "", "QTA DISP.:") + UCase(inSapWmGiacenza.QtaTotaleLquaDispoUdMAcq) + " " + UCase(inSapWmGiacenza.UnitaDiMisuraAcquisizione)
                    tmpString += vbCrLf

                    If (inSapWmGiacenza.VarianteImballo.ScatolePerPallet > 0) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(1217, "", "SCATOLE x PL:") + Trim(Val(inSapWmGiacenza.VarianteImballo.ScatolePerPallet)) + " " + UCase(inSapWmGiacenza.UnitaDiMisuraAcquisizione) + " - "
                        tmpString += clsAppTranslation.GetSingleParameterValue(1472, "", "PZ x SC::") + Trim(Val(inSapWmGiacenza.VarianteImballo.PezziPerScatola)) + " " + UCase(inSapWmGiacenza.UnitaDiMisuraPezzo)
                        tmpString += vbCrLf
                    End If

                    If (clsUtility.IsStringValid(inSapWmGiacenza.UbicazioneInfo.UnitaMagazzino, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(943, "", "U.MAG.:") + clsSapUtility.FormattaStringaUnitaMagazzino(inSapWmGiacenza.UbicazioneInfo.UnitaMagazzino)
                        tmpString += vbCrLf
                    End If

                    If (clsUtility.IsStringValid(inSapWmGiacenza.TipoStock, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(896, "", "TIPO STOCK:") + inSapWmGiacenza.TipoStock
                        tmpString += vbCrLf
                    End If

                    If (clsUtility.IsStringValid(inSapWmGiacenza.CdStockSpeciale, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(944, "", "ST.SPEC.:") + inSapWmGiacenza.CdStockSpeciale + "-" + inSapWmGiacenza.NumeroStockSpeciale
                        tmpString += vbCrLf
                    End If

                Case 2
                    tmpString += clsAppTranslation.GetSingleParameterValue(947, "", "NUM.DOC.MAT.: ")
                    If (clsUtility.IsStringValid(inDocumentoMaterialeBEM.NumeroDocumento, True) = True) Then
                        tmpString += UCase(inDocumentoMaterialeBEM.NumeroDocumento)
                    End If
                    tmpString += vbCrLf

                    tmpString += clsAppTranslation.GetSingleParameterValue(948, "", "POS.DOC.MAT.: ")
                    If (clsUtility.IsStringValid(inDocumentoMaterialeBEM.PosizioneDocumento, True) = True) Then
                        tmpString += UCase(inDocumentoMaterialeBEM.PosizioneDocumento)
                    End If
                    tmpString += vbCrLf

                    tmpString += clsAppTranslation.GetSingleParameterValue(940, "", "COD.MATERIALE: ")
                    If (clsUtility.IsStringValid(inSapWmGiacenza.CodiceMateriale, True) = True) Then
                        tmpString += UCase(inSapWmGiacenza.CodiceMateriale)
                    End If
                    tmpString += vbCrLf

                    tmpString += clsAppTranslation.GetSingleParameterValue(851, "", "PARTITA:")
                    If (clsUtility.IsStringValid(inSapWmGiacenza.Partita, True) = True) Then
                        tmpString += UCase(inSapWmGiacenza.Partita)
                    End If
                    tmpString += vbCrLf

                    tmpString += clsAppTranslation.GetSingleParameterValue(853, "", "QTA:") + UCase(inSapWmGiacenza.QtaTotaleLquaDispoUdMAcq) + " " + UCase(inSapWmGiacenza.UnitaDiMisuraAcquisizione)
                    tmpString += vbCrLf

                    tmpString += clsAppTranslation.GetSingleParameterValue(945, "", "DESCR.:") + UCase(inSapWmGiacenza.DescrizioneMateriale)

                Case 3
                    tmpString += clsAppTranslation.GetSingleParameterValue(940, "", "COD.MATERIALE: ")
                    If (clsUtility.IsStringValid(inSapWmGiacenza.CodiceMateriale, True) = True) Then
                        tmpString += UCase(inSapWmGiacenza.CodiceMateriale)
                    End If
                    tmpString += vbCrLf

                    tmpString += clsAppTranslation.GetSingleParameterValue(851, "", "PARTITA:")
                    If (clsUtility.IsStringValid(inSapWmGiacenza.Partita, True) = True) Then
                        tmpString += UCase(inSapWmGiacenza.Partita)
                    End If
                    tmpString += vbCrLf

                    tmpString += clsAppTranslation.GetSingleParameterValue(946, "", "QTA DISP.:") + UCase(inSapWmGiacenza.QtaTotaleLquaDispoUdMAcq) + " " + UCase(inSapWmGiacenza.UnitaDiMisuraAcquisizione)
                    tmpString += vbCrLf

                    tmpString += clsAppTranslation.GetSingleParameterValue(949, "", "UBI.:") + UCase(inSapWmGiacenza.UbicazioneInfo.TipoMagazzino) + " - " + UCase(inSapWmGiacenza.UbicazioneInfo.Ubicazione)
                    tmpString += vbCrLf

                    If (clsUtility.IsStringValid(inSapWmGiacenza.UbicazioneInfo.UnitaMagazzino, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(943, "", "U.MAG.:") + clsSapUtility.FormattaStringaUnitaMagazzino(inSapWmGiacenza.UbicazioneInfo.UnitaMagazzino)
                        tmpString += vbCrLf
                    End If

                    If (clsUtility.IsStringValid(inSapWmGiacenza.TipoStock, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(896, "", "TIPO STOCK:") + inSapWmGiacenza.TipoStock
                        tmpString += vbCrLf
                    End If

                    If (clsUtility.IsStringValid(inSapWmGiacenza.CdStockSpeciale, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(944, "", "ST.SPEC.:") + inSapWmGiacenza.CdStockSpeciale + "-" + inSapWmGiacenza.NumeroStockSpeciale
                        tmpString += vbCrLf
                    End If

                    tmpString += clsAppTranslation.GetSingleParameterValue(945, "", "DESCR.:") + UCase(inSapWmGiacenza.DescrizioneMateriale)


                Case 6
                    If (clsUtility.IsStringValid(inSapWmGiacenza.UbicazioneInfo.UnitaMagazzino, True) = True) Then
                        tmpString += "U.MAG.:" + clsSapUtility.FormattaStringaUnitaMagazzino(inSapWmGiacenza.UbicazioneInfo.UnitaMagazzino)
                        tmpString += vbCrLf
                    End If
                    tmpString += "MAT: "
                    If (clsUtility.IsStringValid(inSapWmGiacenza.CodiceMateriale, True) = True) Then
                        tmpString += UCase(clsSapUtility.FormattaStringaCodiceMateriale(inSapWmGiacenza.CodiceMateriale))
                    End If
                    tmpString += "  "
                    tmpString += "QTA: " + UCase(inSapWmGiacenza.QtaTotaleLquaDisponibile) + " " + UCase(inSapWmGiacenza.UnitaDiMisuraBase)
                    tmpString += vbCrLf

            End Select

            FromSapWmGiacenzaStructToString = tmpString

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            FromSapWmGiacenzaStructToString = ""
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function FromSapWmUbicazioneStructToString(ByVal inSapWmUbicazione As clsDataType.SapWmUbicazione, Optional ByVal inShowMode As Long = 0) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim tmpString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            FromSapWmUbicazioneStructToString = ""

            'inShowMode = 0 (DEFAULT)
            ' >>>> UBICAZIONE:[TIPO MAG] - [UBICAZIONE]

            Select Case inShowMode
                Case 0
                    tmpString += clsAppTranslation.GetSingleParameterValue(950, "", "UBICAZIONE:")
                    If (clsUtility.IsStringValid(inSapWmUbicazione.TipoMagazzino, True) = True) Then
                        tmpString += UCase(inSapWmUbicazione.TipoMagazzino) + " - "
                    Else
                        tmpString += " - "
                    End If

                    If (clsUtility.IsStringValid(inSapWmUbicazione.Ubicazione, True) = True) Then
                        tmpString += UCase(inSapWmUbicazione.Ubicazione) + " "
                    Else
                        tmpString += " "
                    End If
            End Select

            FromSapWmUbicazioneStructToString = tmpString

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            FromSapWmUbicazioneStructToString = ""
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Public Shared Function FormResizeControls(ByRef inFormToResize As Form, ByVal inExecResizeToResolution As Boolean, ByVal sender As Object, ByVal e As System.EventArgs) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim RW As Double = 0
        Dim RH As Double = 0
        Dim InfoScreenResolution As String = ""
        Dim EnableFontIncrease As Boolean = False
        Dim CurrentFont As Font
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'SE NON DEVO ESEGUIRE IL RESIZE ESCO SENZA FARE NULLA
            If (inExecResizeToResolution = False) Then
                RetCode = 0 'CASO CHE NON DEVE GENERARE ERRORE (RESIZE NON ABILITATO)
                FormResizeControls = RetCode
                Exit Function
            End If

            FormResizeControls = 1 'init at error

            'Dim objGraphics As Graphics = inFormToResize.CreateGraphics
            'PrimaryScreenDpiX = objGraphics.DpiX
            'PrimaryScreenDpiY = objGraphics.DpiY
            'objGraphics.Dispose()
            'objGraphics = Nothing

            CurrentWidth = inFormToResize.Width ' Current Width
            CurrentHeight = inFormToResize.Height ' Current Height

            '#If APPLICAZIONE_WIN32 = "SI" Then
            '            '??? FARE PARAMETRI PER DESIGNER WIN [DesignerWinWidth],[DesignerWinHeight]
            '            InitialWidth = 1024 ' Initial Width
            '            InitialHeight = 768  ' Initial Height
            '#Else
            '            InitialWidth = DesignerWidth ' Initial Width
            '            InitialHeight = DesignerHeight  ' Initial Height
            '#End If

            InitialWidth = DesignerWidth ' Initial Width
            InitialHeight = DesignerHeight  ' Initial Height

            If (inExecResizeToResolution = True) Then
                'inFormToResize.Height = PrimaryScreenHeight
                'inFormToResize.Width = PrimaryScreenWidth
                inFormToResize.Size = New Size(PrimaryScreenWidth, PrimaryScreenHeight)

                CurrentWidth = inFormToResize.Width ' Current Width
                CurrentHeight = inFormToResize.Height ' Current Height
            End If

            If (CurrentWidth > InitialWidth) Then
                RW = (CurrentWidth - InitialWidth) / CurrentWidth ' Ratio change of width
#If Not APPLICAZIONE_WIN32 = "SI" Then
                If (CurrentWidth = "800") Then
                    RW = 2.3
                End If
#End If
            Else
                RW = 0
            End If
            If (CurrentHeight > InitialHeight) Then
                RH = (CurrentHeight - InitialHeight) / CurrentHeight ' Ratio change of height
            Else
                If (CurrentHeight = "480") Then
                    RH = 0.5
                Else
                    RH = 0
                End If
            End If

#If Not APPLICAZIONE_WIN32 = "SI" Then
            If (CurrentWidth = "800") And (CurrentHeight = "480") Then
                EnableFontIncrease = True
            end if
#Else
            EnableFontIncrease = True
#End If

            If (EnableFormResizeDiagnostic = True) Then
                InfoScreenResolution = "Pri.Scr.W-H:" & Trim(PrimaryScreenWidth) & "-" & Trim(PrimaryScreenHeight) & vbCrLf
                InfoScreenResolution += "Curr.W-H:" & Trim(CurrentWidth) & "-" & Trim(CurrentHeight) & vbCrLf
                InfoScreenResolution += "Ratio.W-H:" & Trim(RW) & "-" & Trim(RH) & vbCrLf
                MsgBox(InfoScreenResolution, MsgBoxStyle.Information, AppMsgBoxTitle)
            End If
            If (RW > 0) Or (RH > 0) Then

                For Each Ctrl As Control In inFormToResize.Controls


#If Not APPLICAZIONE_WIN32 = "SI" Then
                    If (RW > 0) Then
                        Ctrl.Width += CInt(Ctrl.Width * RW)
                        Ctrl.Left += CInt(Ctrl.Left * RW)
                    End If
                    If (RH > 0) Then
                        Ctrl.Height += CInt(Ctrl.Height * RH)
                        Ctrl.Top += CInt(Ctrl.Top * RH)
                    End If

#Else

                    'Gestione pannello 800x600
                    If (CurrentWidth = "800") And (CurrentHeight = "600") Then

                        If (RW > 0) Then
                            Ctrl.Width += CInt(Ctrl.Width * RW) * 3.8
                            Ctrl.Left += CInt(Ctrl.Left * RW) * 3.8
                        End If
                        If (RH > 0) Then
                            Ctrl.Height += CInt(Ctrl.Height * RH) * 1.4
                            Ctrl.Top += CInt(Ctrl.Top * RH) * 1.4
                        End If

                    Else

                        'Gestione pannello 1024x768
                        If (RW > 0) Then
                            Ctrl.Width += CInt(Ctrl.Width * RW) * 4.6
                            Ctrl.Left += CInt(Ctrl.Left * RW) * 4.6
                        End If
                        If (RH > 0) Then
                            Ctrl.Height += CInt(Ctrl.Height * RH) * 2.2
                            Ctrl.Top += CInt(Ctrl.Top * RH) * 2.2
                        End If

                    End If

#End If


                    If (EnableFontIncrease = True) And ((TypeOf Ctrl Is Label) Or (TypeOf Ctrl Is Button) Or (TypeOf Ctrl Is TextBox)) Then
                        CurrentFont = Ctrl.Font
                        Ctrl.Font = New Font(CurrentFont.Name, CurrentFont.Size + 2, FontStyle.Bold)
                    ElseIf (EnableFontIncrease = True) And ((TypeOf Ctrl Is DataGrid) Or (TypeOf Ctrl Is TextBox)) Then
                        CurrentFont = Ctrl.Font
                        Ctrl.Font = New Font(CurrentFont.Name, CurrentFont.Size + 2, CurrentFont.Style)
                    End If


#If APPLICAZIONE_WIN32 = "SI" Then
                    'Se Soluzione Windows setto le griglie solo in visualizzazione

                    If (TypeOf Ctrl Is DataGrid) Then

                        clsObject.SetObjectAttributeValue(Ctrl, "ReadOnly", True)

                    End If

#End If

                Next

            End If

            'CW = inFormToResize.Width
            'CH = inFormToResize.Height

            FormResizeControls = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            FormResizeControls = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function VaiAllaPrimaRigaDaEseguire(ByRef inDataGridControl As DataGrid) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkDataRow As DataRow
        Dim WorkIndex As Long = 0
        Dim WorkIdWmsJobStatusString As String = ""
        Dim WorkIdWmsJobStatusValue As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            VaiAllaPrimaRigaDaEseguire = 1 'INIT AT ERROR

            If (inDataGridControl Is Nothing) Then
                RetCode = 10 'caso di errore
                VaiAllaPrimaRigaDaEseguire = RetCode
                Exit Function
            End If

            If (clsWmsJob.objDataTableWmsJobsList.Rows.Count = 0) Then
                VaiAllaPrimaRigaDaEseguire = RetCode
                Exit Function
            End If

            'PRIMO TENTATIVO E MI FERMO SE HO UNA MISSIONE INIZIATA
            For WorkIndex = 0 To (clsWmsJob.objDataTableWmsJobsList.Rows.Count - 1)
                WorkDataRow = clsWmsJob.objDataTableWmsJobsList.Rows(WorkIndex)
                WorkIdWmsJobStatusString = clsUtility.GetDataRowItem(WorkDataRow, "IDSTATUS", "")
                If (clsUtility.IsStringValid(WorkIdWmsJobStatusString, True) = True) Then
                    WorkIdWmsJobStatusValue = Val(WorkIdWmsJobStatusString)
                    If (WorkIdWmsJobStatusValue = clsWmsJob.cstIdJobStatus_Iniziato) And (clsUtility.GetDataRowItem(WorkDataRow, "GRID_EXECUTED", "") <> "*") Then
                        inDataGridControl.CurrentRowIndex = WorkIndex
                        inDataGridControl.Focus()
                        Exit Function
                    End If
                End If
            Next

            'SECONDO TENTATIVO E MI FERMO SE HO UNA MISSIONE NUOVA
            For WorkIndex = 0 To (clsWmsJob.objDataTableWmsJobsList.Rows.Count - 1)
                WorkDataRow = clsWmsJob.objDataTableWmsJobsList.Rows(WorkIndex)
                WorkIdWmsJobStatusString = clsUtility.GetDataRowItem(WorkDataRow, "IDSTATUS", "")
                If (clsUtility.IsStringValid(WorkIdWmsJobStatusString, True) = True) Then
                    WorkIdWmsJobStatusValue = Val(WorkIdWmsJobStatusString)
                    If (WorkIdWmsJobStatusValue <= clsWmsJob.cstIdJobStatus_Assegnato) And (clsUtility.GetDataRowItem(WorkDataRow, "GRID_EXECUTED", "") <> "*") Then
                        inDataGridControl.CurrentRowIndex = WorkIndex
                        inDataGridControl.Focus()
                        Exit Function
                    End If
                End If
            Next

            VaiAllaPrimaRigaDaEseguire = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function VaiAllaPrimaRigaDaEseguire(ByRef inDataGridControl As DataGridView) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkDataRow As DataRow
        Dim WorkIndex As Integer = 0
        Dim WorkIdWmsJobStatusString As String = ""
        Dim WorkIdWmsJobStatusValue As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            VaiAllaPrimaRigaDaEseguire = 1 'INIT AT ERROR

            If (inDataGridControl Is Nothing) Then
                RetCode = 10 'caso di errore
                VaiAllaPrimaRigaDaEseguire = RetCode
                Exit Function
            End If

            If (clsWmsJob.objDataTableWmsJobsList.Rows.Count = 0) Then
                VaiAllaPrimaRigaDaEseguire = RetCode
                Exit Function
            End If

            'PRIMO TENTATIVO E MI FERMO SE HO UNA MISSIONE INIZIATA
            For WorkIndex = 0 To (clsWmsJob.objDataTableWmsJobsList.Rows.Count - 1)
                WorkDataRow = clsWmsJob.objDataTableWmsJobsList.Rows(WorkIndex)
                WorkIdWmsJobStatusString = clsUtility.GetDataRowItem(WorkDataRow, "IDSTATUS", "")
                If (clsUtility.IsStringValid(WorkIdWmsJobStatusString, True) = True) Then
                    WorkIdWmsJobStatusValue = Val(WorkIdWmsJobStatusString)
                    If (WorkIdWmsJobStatusValue = clsWmsJob.cstIdJobStatus_Iniziato) And (clsUtility.GetDataRowItem(WorkDataRow, "GRID_EXECUTED", "") <> "*") Then
                        inDataGridControl.CurrentCell = inDataGridControl(0, WorkIndex)
                        inDataGridControl.Focus()
                        Exit Function
                    End If
                End If
            Next

            'SECONDO TENTATIVO E MI FERMO SE HO UNA MISSIONE NUOVA
            For WorkIndex = 0 To (clsWmsJob.objDataTableWmsJobsList.Rows.Count - 1)
                WorkDataRow = clsWmsJob.objDataTableWmsJobsList.Rows(WorkIndex)
                WorkIdWmsJobStatusString = clsUtility.GetDataRowItem(WorkDataRow, "IDSTATUS", "")
                If (clsUtility.IsStringValid(WorkIdWmsJobStatusString, True) = True) Then
                    WorkIdWmsJobStatusValue = Val(WorkIdWmsJobStatusString)
                    If (WorkIdWmsJobStatusValue <= clsWmsJob.cstIdJobStatus_Assegnato) And (clsUtility.GetDataRowItem(WorkDataRow, "GRID_EXECUTED", "") <> "*") Then
                        inDataGridControl.CurrentCell = inDataGridControl(0, WorkIndex)
                        inDataGridControl.Focus()
                        Exit Function
                    End If
                End If
            Next

            VaiAllaPrimaRigaDaEseguire = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ShowOnStockQtyCompleteForUserString(ByRef inMaterialeGiacenzaOrigine As clsDataType.SapWmGiacenza) As String

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ShowOnStockQtyCompleteForUserString = ""


            ShowOnStockQtyCompleteForUserString = " ( " + Trim(Str(inMaterialeGiacenzaOrigine.QtaTotaleLquaInStocFullPallet)) + " PL/ " + Trim(Str(inMaterialeGiacenzaOrigine.QtaTotaleLquaInStocPartialPallet)) + " " + UCase(inMaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione) + "/ " + Trim(Str(inMaterialeGiacenzaOrigine.QtaTotaleInStockSfusi)) + " " + inMaterialeGiacenzaOrigine.UnitaDiMisuraPezzo + " ) "


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ShowOnStockQtyCompleteForUserString = "" 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function FromSapWmGiacenzaStrucToString(ByRef MaterialeGiacenza As clsDataType.SapWmGiacenza, Optional ByVal inShowMode As Long = 0) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim tmpString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            FromSapWmGiacenzaStrucToString = ""

            Select Case inShowMode
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
                    tmpString += UCase(MaterialeGiacenza.UbicazioneInfo.Divisione) + " - " + UCase(clsAppTranslation.GetSingleParameterValue(960, "", "NUM.MAG:"))
                    tmpString += UCase(MaterialeGiacenza.UbicazioneInfo.NumeroMagazzino)
                    tmpString += vbCrLf

                    tmpString += clsAppTranslation.GetSingleParameterValue(848, "", "UBI:")
                    tmpString += UCase(MaterialeGiacenza.UbicazioneInfo.TipoMagazzino) + " - " + UCase(MaterialeGiacenza.UbicazioneInfo.Ubicazione)
                    tmpString += vbCrLf

                    tmpString += UCase(clsAppTranslation.GetSingleParameterValue(943, "", "Pallet ID:"))
                    tmpString += UCase(MaterialeGiacenza.UbicazioneInfo.UnitaMagazzino)
                    tmpString += vbCrLf

                    tmpString += clsAppTranslation.GetSingleParameterValue(957, "", "QTA DISPO.:")
                    tmpString += UCase(MaterialeGiacenza.QtaTotaleLquaDispoUdMAcq) + " "
                    tmpString += UCase(MaterialeGiacenza.UnitaDiMisuraAcquisizione) + ""
                    'FORMATTAZZIONE QTA COMPLETA PER UTENTE
                    tmpString += clsShowUtility.ShowOnStockQtyCompleteForUserString(MaterialeGiacenza)
                    tmpString += vbCrLf


                    If (MaterialeGiacenza.VarianteImballo.ScatolePerPallet > 0) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(1217, "", "SCATOLE x PL:") + Trim(Val(MaterialeGiacenza.VarianteImballo.ScatolePerPallet)) + " " + UCase(MaterialeGiacenza.UnitaDiMisuraAcquisizione) + " - "
                        tmpString += clsAppTranslation.GetSingleParameterValue(1472, "", "PZ x SC:") + Trim(Val(MaterialeGiacenza.VarianteImballo.PezziPerScatola)) + " " + UCase(MaterialeGiacenza.UnitaDiMisuraPezzo)
                        tmpString += vbCrLf
                    End If

                    If (clsUtility.IsStringValid(MaterialeGiacenza.SKU, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(1646, "", "SKU") & ":"
                        tmpString += UCase(MaterialeGiacenza.SKU) + " "
                        If (clsUtility.IsStringValid(MaterialeGiacenza.CodiceMaterialeLegacy, True) = True) Then
                            tmpString += clsAppTranslation.GetSingleParameterValue(1647, "", "Legacy") & ":"
                            tmpString += UCase(MaterialeGiacenza.CodiceMaterialeLegacy) + " "
                        End If
                    End If
                Case 1
                    'CASO IN CUI VISUALIZZO ANCHE LA  QTA CONFERMATA
                    tmpString += FromSapWmGiacenzaStrucToString(MaterialeGiacenza, 0)
                    If (MaterialeGiacenza.QuantitaConfermataOperatore > 0) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(958, "", "QTA CONF.:")
                        tmpString += UCase(MaterialeGiacenza.QuantitaConfermataOperatore) + " "
                        tmpString += UCase(MaterialeGiacenza.UnitaDiMisuraAcquisizione) + ""
                        tmpString += vbCrLf
                    End If

            End Select

            FromSapWmGiacenzaStrucToString = tmpString

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            FromSapWmGiacenzaStrucToString = ""
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

End Class
