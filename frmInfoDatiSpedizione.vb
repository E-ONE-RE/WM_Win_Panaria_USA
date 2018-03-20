
Imports clsSapWS
Imports clsNavigation
Imports clsDataType


Public Class frmInfoDatiSpedizione
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmInfoDatiSpedizione"


    Private ErrDescription As String

    Public Shared SourceForm As Form


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Select Case inKey
                Case 112 'F1
                    Call Me.cmdPrevious_Click(Me, e)
                    Exit Sub
                Case 113 'F2
                    Call Me.cmdNext_Click(Me, e)
                    Exit Sub
                Case 114 'F3
                    If clsInfoGiacenze.RowIndex > 0 Then
                        Call cmdFirst_Click(Me, e)
                    Else
                        Call cmdLast_Click(Me, e)
                    End If
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

    Private Sub frmInfoDatiSpedizione_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Right)) Then
                'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                Call Me.cmdNext_Click(Me, e)
                Exit Sub
            End If

            If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Left)) Then
                'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                Call Me.cmdPrevious_Click(Me, e)
                Exit Sub
            End If

            If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Up)) Then
                'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                Call Me.cmdLast_Click(Me, e)
                Exit Sub
            End If

            If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Down)) Then
                'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                Call Me.cmdFirst_Click(Me, e)
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


    Private Sub frmInfoDatiSpedizione_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            Me.Text = clsAppTranslation.GetSingleParameterValue(1175, Me.Text, "Spedizioni")

            btnClose.Text = clsAppTranslation.GetSingleParameterValue(252, btnClose.Text, "Chiudi")

            '**************************************  

            If Not (clsInfoGiacenze.objDataTableDetailsSpedizioni Is Nothing) Then
                clsInfoGiacenze.objDataTableDetailsSpedizioni.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridInfo.DataSource = clsInfoGiacenze.objDataTableDetailsSpedizioni
            End If


            RefreshNavBtn(clsUtility.DateTableMoveOpTypeEnum.DateTableMoveOpTypeNone)

            lblIndex.Text = clsInfoGiacenze.RowIndex + 1

            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()

            'refresh dei dati
            RetCode += clsInfoGiacenze.RefreshDateTableSpedInfo()

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
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (SourceForm Is Nothing) Then
                'SE NON HO INFORMAZIONI SUL CHIAMANTE ALLORA TORNO AL MENU PRINCIPALE
                Call clsNavigation.Show_Mnu_Home(Me, True)
            ElseIf (SourceForm.GetType.Name = frmInfoGiacenze_3_List.GetType.Name) Then
                'PASSO ALLO VIDEATA DELLO STEP PRECEDENTE
                Call clsNavigation.Show_Info_Giacenze(Me, clsInfoGiacenze.InfoGiacenzeType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)
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
            If (Me.DtGridInfo.TableStyles.Count = 0) Then
#If Not APPLICAZIONE_WIN32 = "SI" Then
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "PropertyId", clsAppTranslation.GetSingleParameterValue(542, "", "Proprietà"), False, 0, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "PropertyText", clsAppTranslation.GetSingleParameterValue(542, "", "Proprietà"), True, 120, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "PropertyValue", clsAppTranslation.GetSingleParameterValue(543, "", "Valore"), True, 500, True)
#Else
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "PropertyId", clsAppTranslation.GetSingleParameterValue(542, "", "Proprietà"), False, 0, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "PropertyText", clsAppTranslation.GetSingleParameterValue(542, "", "Proprietà"), True, 320, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "PropertyValue", clsAppTranslation.GetSingleParameterValue(543, "", "Valore"), True, 500, True)
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

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        '**************************************
        'imposta la visualizzazione di tutte le colonne della DATA GRID
        '**************************************

        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
            clsInfoGiacenze.objSpedDataRow = clsUtility.ExecDataTableMove(clsInfoGiacenze.objDataTableSpedizioniInfo, clsInfoGiacenze.RowIndex, clsUtility.DateTableMoveOpTypeEnum.DateTableMoveOpTypeNext)
            clsInfoGiacenze.RefreshDateTableSpedInfo()

            lblIndex.Text = clsInfoGiacenze.RowIndex + 1

            RefreshNavBtn(clsUtility.DateTableMoveOpTypeEnum.DateTableMoveOpTypeNext)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Sub

    Private Sub cmdPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevious.Click
        '**************************************
        'imposta la visualizzazione di tutte le colonne della DATA GRID
        '**************************************

        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
            clsInfoGiacenze.objSpedDataRow = clsUtility.ExecDataTableMove(clsInfoGiacenze.objDataTableSpedizioniInfo, clsInfoGiacenze.RowIndex, clsUtility.DateTableMoveOpTypeEnum.DateTableMoveOpTypePrev)
            clsInfoGiacenze.RefreshDateTableSpedInfo()

            lblIndex.Text = clsInfoGiacenze.RowIndex + 1

            RefreshNavBtn(clsUtility.DateTableMoveOpTypeEnum.DateTableMoveOpTypePrev)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Sub

    Private Sub cmdLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLast.Click
        '**************************************
        'imposta la visualizzazione di tutte le colonne della DATA GRID
        '**************************************

        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
            clsInfoGiacenze.objSpedDataRow = clsUtility.ExecDataTableMove(clsInfoGiacenze.objDataTableSpedizioniInfo, clsInfoGiacenze.RowIndex, clsUtility.DateTableMoveOpTypeEnum.DateTableMoveOpTypeLast)
            clsInfoGiacenze.RefreshDateTableSpedInfo()

            lblIndex.Text = clsInfoGiacenze.RowIndex + 1

            RefreshNavBtn(clsUtility.DateTableMoveOpTypeEnum.DateTableMoveOpTypeLast)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFirst.Click
        '**************************************
        'imposta la visualizzazione di tutte le colonne della DATA GRID
        '**************************************

        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
            clsInfoGiacenze.objSpedDataRow = clsUtility.ExecDataTableMove(clsInfoGiacenze.objDataTableSpedizioniInfo, clsInfoGiacenze.RowIndex, clsUtility.DateTableMoveOpTypeEnum.DateTableMoveOpTypeFirst)
            clsInfoGiacenze.RefreshDateTableSpedInfo()

            lblIndex.Text = clsInfoGiacenze.RowIndex + 1

            RefreshNavBtn(clsUtility.DateTableMoveOpTypeEnum.DateTableMoveOpTypeFirst)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub RefreshNavBtn(ByVal inDateTableMoveOpType As clsUtility.DateTableMoveOpTypeEnum)
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            Select Case inDateTableMoveOpType
                Case clsUtility.DateTableMoveOpTypeEnum.DateTableMoveOpTypeFirst
                    cmdLast.Enabled = True
                    cmdNext.Enabled = True
                    cmdPrevious.Enabled = False
                    cmdFirst.Enabled = False
                Case clsUtility.DateTableMoveOpTypeEnum.DateTableMoveOpTypeLast
                    cmdLast.Enabled = False
                    cmdNext.Enabled = False
                    cmdPrevious.Enabled = True
                    cmdFirst.Enabled = True
                Case clsUtility.DateTableMoveOpTypeEnum.DateTableMoveOpTypeNext
                    If clsInfoGiacenze.RowIndex < clsInfoGiacenze.objDataTableSpedizioniInfo.Rows.Count - 1 Then
                        cmdLast.Enabled = True
                        cmdNext.Enabled = True
                        cmdPrevious.Enabled = True
                        cmdFirst.Enabled = True
                    Else
                        cmdLast.Enabled = False
                        cmdNext.Enabled = False
                        cmdPrevious.Enabled = True
                        cmdFirst.Enabled = True
                    End If
                Case clsUtility.DateTableMoveOpTypeEnum.DateTableMoveOpTypePrev
                    If clsInfoGiacenze.RowIndex > 0 Then
                        cmdLast.Enabled = True
                        cmdNext.Enabled = True
                        cmdPrevious.Enabled = True
                        cmdFirst.Enabled = True
                    Else
                        cmdLast.Enabled = True
                        cmdNext.Enabled = True
                        cmdPrevious.Enabled = False
                        cmdFirst.Enabled = False
                    End If
                Case clsUtility.DateTableMoveOpTypeEnum.DateTableMoveOpTypeNone
                    Select Case clsInfoGiacenze.RowIndex
                        Case 0
                            cmdLast.Enabled = True
                            cmdNext.Enabled = True
                            cmdPrevious.Enabled = False
                            cmdFirst.Enabled = False
                        Case clsInfoGiacenze.objDataTableSpedizioniInfo.Rows.Count - 1
                            cmdLast.Enabled = False
                            cmdNext.Enabled = False
                            cmdPrevious.Enabled = True
                            cmdFirst.Enabled = True
                        Case Else
                            cmdLast.Enabled = True
                            cmdNext.Enabled = True
                            cmdPrevious.Enabled = True
                            cmdFirst.Enabled = True
                    End Select
            End Select


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

End Class