' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI & LUCA BELLEI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 09/10/2015
' DATA MODIFICA     : 09/10/2015
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la funzione di gestione input utente con verifica doppia 
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType

Public Class clsConfUsrInput

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsConfUsrInput"

    ' OGGETTO MEMO PER MEMORIZZARE PRIMO INSERIMENTO OPERATORE
    Public Shared MemoUsrEntry As String = ""
    Public Shared AbilitaControllo As Boolean = True

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

            MemoUsrEntry = ""

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

    Public Shared Function CheckUsrUbicInput(ByVal inTextBox As TextBox, ByRef outUbicConfermata As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CheckUsrUbicInput = 1 'init at error

            If (AbilitaControllo = False) Then
                'OK SENZA CONTROLLO
                ClearAllData()
                outUbicConfermata = True
                RetCode = 0 'NESSUN ERRORE
                CheckUsrUbicInput = RetCode
                Exit Function
            End If


            If (clsUtility.IsStringValid(inTextBox.Text, True) = False) Then
                'STRINGA NULLA , ESCO SENZA FARE NULLA
                RetCode = 0 'NESSUN ERRORE
                CheckUsrUbicInput = RetCode
                Exit Function
            End If

            inTextBox.Text = UCase(inTextBox.Text)

            'CONTROLLO SE E' LA PRIMA IMMISSIONE
            If (MemoUsrEntry = "") Then
                MemoUsrEntry = UCase(Trim(inTextBox.Text))
                outUbicConfermata = False
                inTextBox.Text = ""
                RetCode = 0 'NESSUN ERRORE
                CheckUsrUbicInput = RetCode
                Exit Function
            Else
                'CONTROLLO SE LA SECONDA VOLTA IL TESTO E' IDENTICO AL PRIMO
                If (UCase(Trim(inTextBox.Text)) <> MemoUsrEntry) Then
                    'ERRORE IN RICONFERMA ( SECONDA DIGITAZIONE DIVERSA )
                    ClearAllData()
                    outUbicConfermata = False
                    inTextBox.Text = ""
                    RetCode = 10 'ERRORE ( SECONDA DIGITAZIONE DIVERSA )
                    CheckUsrUbicInput = RetCode
                    Exit Function
                Else
                    'OK RICONFERMA
                    ClearAllData()
                    outUbicConfermata = True
                    RetCode = 0 'NESSUN ERRORE
                    CheckUsrUbicInput = RetCode
                    Exit Function
                End If
            End If

            CheckUsrUbicInput = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckUsrUbicInput = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


End Class
