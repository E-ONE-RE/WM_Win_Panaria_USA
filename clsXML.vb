' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : 
' DATA CREAZIONE    : 10/03/2009
' DATA MODIFICA     : 10/03/2009
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa tutti i metodi base per la gestione dei documenti XML
' *****************************************************************************************

Imports System.Xml

Public Class clsXML
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsXML"


    Public Shared XmlErrorsList As New ArrayList

    Public Shared Function IsReceivedXMLFileOK(ByVal inFullFileName As String, ByRef outXmlDocument As XmlDocument) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim retCode As Long
        Dim FileOk As Boolean = False
        Dim CounterLock As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            IsReceivedXMLFileOK = 100 ' INIT AT NOT OK

            XmlErrorsList.Clear() 'init error list 

            Do Until FileOk
                If (clsUtility.FileIsLocked(inFullFileName) = False) Then
                    FileOk = True
                    Exit Do
                Else
                    System.Threading.Thread.Sleep(100)
                    CounterLock += 1
                End If
                If (CounterLock > 500) Then
                    FileOk = True
                    Exit Do
                End If
            Loop

            'CHECK PARSE (SINTAX).NESSUNA VALIDAZIONE NECESSARIA PERCHE' NON CI SONO SCHEMI DEFINITI
            retCode = LoadXMLFile(inFullFileName, outXmlDocument)
            If ((retCode <> 0) Or (outXmlDocument Is Nothing)) Then
                IsReceivedXMLFileOK = 200 + retCode
                '>>> log error
                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "IsReceivedXMLFileOK", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Error on method [LoadXMLFile]!", Nothing)
                Exit Function
            End If

            IsReceivedXMLFileOK = 0 'THE FILE IS OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "IsReceivedXMLFileOK", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function LoadXMLFile(ByVal inFullFileName As String, ByRef outXMLDoc As XmlDocument) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim WorkXmlDocument As New XmlDocument
        Dim FileOk As Boolean = False
        Dim CounterLock As Long = 0

        RetCode = 0
        LoadXMLFile = RetCode ' INIT AT NOT OK

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Do Until FileOk
                If (clsUtility.FileIsLocked(inFullFileName) = False) Then
                    FileOk = True
                    Exit Do
                Else
                    System.Threading.Thread.Sleep(100)
                    CounterLock += 1
                End If
                If (CounterLock > 500) Then
                    FileOk = True
                    Exit Do
                End If
            Loop

            WorkXmlDocument.Load(inFullFileName)

            '**************************************
        Catch xmlEx As XmlException
            RetCode = 1000
            XmlErrorsList.Add(xmlEx.Message)
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LoadXMLFile", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch error (xmlEx)!" & xmlEx.Message, xmlEx)

        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            RetCode = 10000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LoadXMLFile", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch error (ex)!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION
            If (RetCode = 0) Then
                'se non ho avuto errori torno il documento XML
                outXMLDoc = WorkXmlDocument
            End If
            LoadXMLFile = RetCode
            WorkXmlDocument = Nothing
        End Try
    End Function
    Public Shared Function LoadXMLString(ByVal inXmlStringToLoad As String, ByRef outXMLDoc As XmlDocument, ByVal inCheckReservedCharacters As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim WorkXmlDocument As New XmlDocument

        RetCode = 0
        LoadXMLString = RetCode ' INIT AT NOT OK

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (inCheckReservedCharacters = True) Then
                inXmlStringToLoad = Replace(inXmlStringToLoad, "&", "&amp;")
                inXmlStringToLoad = Replace(inXmlStringToLoad, "%", "&#37;")
            End If

            WorkXmlDocument.LoadXml(inXmlStringToLoad)

            '**************************************
        Catch xmlEx As XmlException
            RetCode = 1000
            XmlErrorsList.Add(xmlEx.Message)
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LoadXMLString", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch error!" & xmlEx.Message, xmlEx)

        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            RetCode = 10000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "LoadXMLString", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION
            If (RetCode = 0) Then
                'se non ho avuto errori torno il documento XML
                outXMLDoc = WorkXmlDocument
            End If
            LoadXMLString = RetCode
            WorkXmlDocument = Nothing
        End Try
    End Function
    Public Shared Function SaveXmlToFile(ByRef inXMLDoc As XmlDocument, ByVal inAbsoluteFileName As String) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        RetCode = 0
        SaveXmlToFile = RetCode ' INIT AT NOT OK

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            inXMLDoc.Save(inAbsoluteFileName)

            '**************************************
        Catch xmlEx As XmlException
            RetCode = 1000
            XmlErrorsList.Add(xmlEx.Message)
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "SaveXmlToFile", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch error!" & xmlEx.Message, xmlEx)

        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            RetCode = 10000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "SaveXmlToFile", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION
            SaveXmlToFile = RetCode
        End Try
    End Function

    Public Shared Function ValidateXMLDocument(ByRef inXMLDocument As XmlDocument) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim ErrorListCount As Long

        RetCode = 10
        ValidateXMLDocument = RetCode ' INIT AT NOT OK

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (inXMLDocument Is Nothing) Then
                ValidateXMLDocument = 20
                Exit Function
            End If

            ErrorListCount = XmlErrorsList.Count

            inXMLDocument.XmlResolver = Nothing

            inXMLDocument.Validate(AddressOf ValidationCallBack)

            If (XmlErrorsList.Count > ErrorListCount) Then
                'sono stati generati errori di validazione
                ValidateXMLDocument = 30
                Exit Function
            End If

        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            RetCode = 10000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "ValidateXMLDocument", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Shared Sub ValidationCallBack(ByVal sender As Object, ByVal e As System.Xml.Schema.ValidationEventArgs)
        XmlErrorsList.Add(e.Message)
        clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "ValidationCallBack", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Validation error!" & e.Message, Nothing)
    End Sub
    Public Shared Function GetXMLSingleElementNode(ByRef inXmlDocument As XmlDocument, ByVal inSingleNodeElementName As String, Optional ByVal inItemIndexNode As Long = 0) As XmlNode
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim WorkNodeList As XmlNodeList
        '**************************************

        GetXMLSingleElementNode = Nothing

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (inXmlDocument Is Nothing) Then
                Exit Function
            End If

            WorkNodeList = inXmlDocument.GetElementsByTagName(inSingleNodeElementName)
            If (WorkNodeList.Count >= (inItemIndexNode + 1)) Then
                If (Not (WorkNodeList.Item(inItemIndexNode).FirstChild Is Nothing)) Then
                    GetXMLSingleElementNode = WorkNodeList.Item(inItemIndexNode)
                End If
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetXMLSingleElementNode = Nothing 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "GetXMLSingleElementNodeValue", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetXMLSingleElementNodeValue(ByRef inXmlDocument As XmlDocument, ByVal inSingleNodeElementName As String, Optional ByVal inItemIndexNode As Long = 0) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim WorkNodeList As XmlNodeList
        '**************************************

        GetXMLSingleElementNodeValue = ""

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (inXmlDocument Is Nothing) Then
                Exit Function
            End If

            WorkNodeList = inXmlDocument.GetElementsByTagName(inSingleNodeElementName)
            If (WorkNodeList.Count >= (inItemIndexNode + 1)) Then
                If (Not (WorkNodeList.Item(inItemIndexNode).FirstChild Is Nothing)) Then
                    GetXMLSingleElementNodeValue = WorkNodeList.Item(inItemIndexNode).FirstChild.Value
                End If
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetXMLSingleElementNodeValue = "" 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "GetXMLSingleElementNodeValue", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function SelectSingleNode(ByRef inXmlNode As XmlNode, ByVal inXPathString As String) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim WorkNode As XmlNode
        '**************************************

        SelectSingleNode = ""

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (inXmlNode Is Nothing) Then
                Exit Function
            End If

            WorkNode = inXmlNode.SelectSingleNode(inXPathString)
            If (Not (WorkNode Is Nothing)) Then
                If (WorkNode.HasChildNodes) Then
                    SelectSingleNode = WorkNode.FirstChild.Value 
                End If
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            SelectSingleNode = "" 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "SelectSingleNode", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

End Class
