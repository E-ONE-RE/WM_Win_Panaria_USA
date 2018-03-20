Imports SAP.Middleware.Connector

Public Class clsSAPNetConn
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsSAPNetConn"

    Public Shared SAPRfcDestinationMgr As SAP.Middleware.Connector.RfcDestinationManager
    Public Shared SAPRfcDestination As SAP.Middleware.Connector.RfcDestination


    Public Shared Function SAPDestinationConfiguration() As SAP.Middleware.Connector.RfcConfigParameters
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim SAPRfcParam As New SAP.Middleware.Connector.RfcConfigParameters

            If (clsUtility.IsStringValid(My.Settings.SystemID, True) = False) Then
                Exit Function
            End If

            If (My.Settings.SystemID = DefaultSapSISID_Quality) Then
                '>>>> QUALITY
                SAPRfcParam.Add(SAPRfcParam.Name, "ECQ")
                SAPRfcParam.Add(SAPRfcParam.AppServerHost, My.Settings.WsHostName)
                SAPRfcParam.Add(SAPRfcParam.SystemNumber, SYSTEMNUMBER_TST)
                SAPRfcParam.Add(SAPRfcParam.SystemID, SYSTEMID_TST)
                SAPRfcParam.Add(SAPRfcParam.User, My.Settings.UserRfcWs)
                SAPRfcParam.Add(SAPRfcParam.Password, My.Settings.PswUserRfcWs)
                SAPRfcParam.Add(SAPRfcParam.Client, My.Settings.SapClient)
                SAPRfcParam.Add(SAPRfcParam.Language, clsUser.SapWmsUser.LANGUAGE)
                SAPRfcParam.Add(SAPRfcParam.PoolSize, POOLSIZE)
            ElseIf (My.Settings.SystemID = DefaultSapSISID_Sviluppo) Then
                '>>>> SVILUPPO
                SAPRfcParam.Add(SAPRfcParam.Name, "ECD")
                SAPRfcParam.Add(SAPRfcParam.AppServerHost, My.Settings.WsHostName)
                SAPRfcParam.Add(SAPRfcParam.SystemNumber, SYSTEMNUMBER_DEV)
                SAPRfcParam.Add(SAPRfcParam.SystemID, SYSTEMID_DEV)
                SAPRfcParam.Add(SAPRfcParam.User, My.Settings.UserRfcWs)
                SAPRfcParam.Add(SAPRfcParam.Password, My.Settings.PswUserRfcWs)
                SAPRfcParam.Add(SAPRfcParam.Client, My.Settings.SapClient)
                SAPRfcParam.Add(SAPRfcParam.Language, clsUser.SapWmsUser.LANGUAGE)
                SAPRfcParam.Add(SAPRfcParam.PoolSize, POOLSIZE)

            ElseIf (My.Settings.SystemID = DefaultSapSISID_Produzione) Then
                '>>>> PRODUZIONE
                SAPRfcParam.Add(SAPRfcParam.Name, "ECP")
                SAPRfcParam.Add(SAPRfcParam.AppServerHost, My.Settings.WsHostName)
                SAPRfcParam.Add(SAPRfcParam.SystemNumber, SYSTEMNUMBER_PRD)
                SAPRfcParam.Add(SAPRfcParam.SystemID, SYSTEMID_PRD)
                SAPRfcParam.Add(SAPRfcParam.User, My.Settings.UserRfcWs)
                SAPRfcParam.Add(SAPRfcParam.Password, My.Settings.PswUserRfcWs)
                SAPRfcParam.Add(SAPRfcParam.Client, My.Settings.SapClient)
                SAPRfcParam.Add(SAPRfcParam.Language, clsUser.SapWmsUser.LANGUAGE)
                SAPRfcParam.Add(SAPRfcParam.PoolSize, POOLSIZE)

            End If

            Return SAPRfcParam

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function SAPRfcTestConnection() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            SAPRfcTestConnection = 1

            If (SAPRfcDestination Is Nothing) Then
                SAPRfcDestination = SAPRfcDestinationMgr.GetDestination(SAPDestinationConfiguration())
            End If

            If (Not SAPRfcDestination Is Nothing) Then

                SAPRfcDestination.Ping()
                RetCode = 0
                SAPRfcTestConnection = RetCode
                Exit Function

            End If


        Catch ex As Exception
            'LOG ERROR CONDITION
            RetCode = False
            SAPRfcTestConnection = 1000
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetValidSAPRfcDestination() As SAP.Middleware.Connector.RfcDestination
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetValidSAPRfcDestination = Nothing

            If (SAPRfcDestination Is Nothing) Then
                SAPRfcDestination = SAPRfcDestinationMgr.GetDestination(SAPDestinationConfiguration())
            Else

                If SAPRfcTestConnection() <> 0 Then
                    Exit Function
                End If

            End If

            GetValidSAPRfcDestination = SAPRfcDestination

        Catch ex As Exception
            'LOG ERROR CONDITION
            GetValidSAPRfcDestination = Nothing
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

End Class
