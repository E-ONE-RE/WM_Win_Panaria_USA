
Imports clsSapWS
Imports clsNavigation

Public Class frmInfoUser
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmInfoUser"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError

    Public ErrDescription As String


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmInfoUser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.btnHome.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.btnHome_Click(Me, e)
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

    Private Sub frmInfoUser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            Me.Text = clsAppTranslation.GetSingleParameterValue(59, Me.Text, "Info Utente")

            btnHome.Text = clsAppTranslation.GetSingleParameterValue(264, btnHome.Text, "Home")

            '**************************************   

            'Imposto il DataSource per la griglia DtGridUserMag
            RetCode += clsSapWS.Call_ZWS_GET_USERS_PROF_LGTYP(clsUser.SapWmsUser.USERID, True, clsDataType.Operation_Type.Operation_Type_All, "", False, clsUser.objDataTableUsersProfLgtyp, SapFunctionError, False)


            If Not (clsUser.objDataTableUsersProfLgtyp Is Nothing) Then
                clsUser.objDataTableUsersProfLgtyp.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridUserMag.DataSource = clsUser.objDataTableUsersProfLgtyp
            End If


            'Imposto il DataSource per la griglia DtGridUserInfo
            If Not (clsUser.objDataTableUserInfo Is Nothing) Then
                clsUser.objDataTableUserInfo.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridUserInfo.DataSource = clsUser.objDataTableUserInfo
            End If


            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()

            'refresh dei dati
            RetCode += clsUser.RefreshDateTableForUserInfo()

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

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
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RetCode = clsNavigation.Show_Mnu_Home(Me, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(281, "", "Errore nell'apertura della form. Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

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
            If (Me.DtGridUserInfo.TableStyles.Count = 0) Then
#If Not APPLICAZIONE_WIN32 = "SI" Then
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridUserInfo, "", "PropertyId", clsAppTranslation.GetSingleParameterValue(542, "", "Proprietà"), True, 100, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridUserInfo, "", "PropertyValue", clsAppTranslation.GetSingleParameterValue(543, "", "Valore"), True, 300, True)
#Else
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridUserInfo, "", "PropertyId", clsAppTranslation.GetSingleParameterValue(542, "", "Proprietà"), True, 200, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridUserInfo, "", "PropertyValue", clsAppTranslation.GetSingleParameterValue(543, "", "Valore"), True, 300, True)
#End If
            End If


            'creo la formattazione solo la prima volta
            If (Me.DtGridUserMag.TableStyles.Count = 0) Then
#If Not APPLICAZIONE_WIN32 = "SI" Then
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridUserMag, "", "PROFID", clsAppTranslation.GetSingleParameterValue(1177, "", "Id Prof."), True, 60, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridUserMag, "", "LGNUM", clsAppTranslation.GetSingleParameterValue(1165, "", "NMg"), True, DefDtGridCol_NumeroMagazzino + 10, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridUserMag, "", "LGTYP", clsAppTranslation.GetSingleParameterValue(1166, "", "Cat"), True, DefDtGridCol_TipoMagazzino + 10, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridUserMag, "", "LTYPT", clsAppTranslation.GetSingleParameterValue(776, "", "Desc."), True, 100, True)
#Else
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridUserMag, "", "PROFID", clsAppTranslation.GetSingleParameterValue(1177, "", "Id Prof."), True, 60, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridUserMag, "", "LGNUM", clsAppTranslation.GetSingleParameterValue(1165, "", "NMg"), True, DefDtGridCol_NumeroMagazzino + 10, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridUserMag, "", "LGTYP", clsAppTranslation.GetSingleParameterValue(1166, "", "Cat"), True, DefDtGridCol_TipoMagazzino + 10, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridUserMag, "", "LTYPT", clsAppTranslation.GetSingleParameterValue(776, "", "Desc."), True, 300, True)
#End If
            End If

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

End Class