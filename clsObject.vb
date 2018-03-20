Imports System
Imports System.Object
Imports System.Reflection
Imports System.Reflection.MemberInfo
Imports System.Windows.Forms


Public Class clsObject
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsObject"

    '*****************************************
    'MANAGEMENT OF OBJECT
    Private disposed As Boolean = False ' Track whether Dispose has been called.

    '************************
    'DATA TYPE


    '************************
    'PUBLIC CONSTANT


    '************************
    'PUBLIC ATTRIBUTES


    '************************
    'PUBLIC OBJECTS


    '*****************************************************
    'PRIVATE ATTRIBUTES


    '*****************************************************
    'PRIVATE OBJECTS


    Public Shared Function GetObjectAttributeValue(ByRef inObject As Object, ByVal inAttributeName As String, ByRef outAttributeValue As Object) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim objType As Type
        Dim tmpFieldInfo As FieldInfo
        Dim tmpObject As Object = Nothing
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            outAttributeValue = Nothing 'init

            If (Not (inObject Is Nothing)) Then
                objType = inObject.GetType()
                If (Not (objType Is Nothing)) Then
                    tmpFieldInfo = objType.GetField(inAttributeName)
                    If (Not (tmpFieldInfo Is Nothing)) Then
                        tmpObject = tmpFieldInfo.GetValue(inObject)
                        If (Not (IsNothing(tmpObject))) Then
                            outAttributeValue = tmpObject
                        End If
                    Else
                        RetCode += GetObjectPropertyValue(inObject, inAttributeName, tmpObject)
                        If (RetCode = 0) Then
                            If (Not (IsNothing(tmpObject))) Then
                                outAttributeValue = tmpObject
                            End If
                        End If
                    End If
                End If
            End If

            GetObjectAttributeValue = RetCode

        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetObjectAttributeValue = 1000

            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetObjectPropertyValue(ByRef inObject As Object, ByVal inAttributeName As String, ByRef outAttributeValue As Object) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim objType As Type
        Dim tmpPropertyInfo As PropertyInfo
        Dim tmpObject As Object
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetObjectPropertyValue = Nothing 'init

            If (Not (inObject Is Nothing)) Then
                objType = inObject.GetType()
                If (Not (objType Is Nothing)) Then
                    tmpPropertyInfo = objType.GetProperty(inAttributeName)
                    If (Not (tmpPropertyInfo Is Nothing)) Then
                        tmpObject = tmpPropertyInfo.GetValue(inObject, Nothing)
                        If (Not (IsNothing(tmpObject))) Then
                            outAttributeValue = tmpObject
                        End If
                    End If
                End If
            End If

            GetObjectPropertyValue = RetCode

        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetObjectPropertyValue = 1000

            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetObjectAttribute(ByRef inObject As Object, ByVal inAttributeName As String, ByRef outAttribute As Object) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim objType As Type
        Dim tmpMembers() As MemberInfo

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetObjectAttribute = 1 'init at error

            If (Not (inObject Is Nothing)) Then
                objType = inObject.GetType()
                If (Not (objType Is Nothing)) Then
                    tmpMembers = objType.GetMember(inAttributeName)
                    If (Not (tmpMembers Is Nothing)) Then
                        If (tmpMembers.Length = 1) Then
                            'try catch per esecuzione metodo [Invoke]
                            Try
                                outAttribute = tmpMembers.GetValue(0)

                                '**************************************
                            Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
                                GetObjectAttribute = 1000  'error case
                                'LOG ERROR CONDITION
                                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
                                '**************************************
                            Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

                            End Try
                        End If
                    End If
                End If
            End If

            GetObjectAttribute = RetCode

        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetObjectAttribute = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function SetObjectAttributeValue(ByRef inObject As Object, ByVal inAttributeName As String, ByRef inAttributeValue As Object) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim objType As Type

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************
            If (Not (inObject Is Nothing)) Then
                objType = inObject.GetType()
                If (Not (objType Is Nothing)) Then

                    Dim mytype As Type = inObject.GetType()
                    Dim pInfo As PropertyInfo = mytype.GetProperty(inAttributeName)

                    pInfo.SetValue(inObject, inAttributeValue)

                End If
            End If

            SetObjectAttributeValue = RetCode

        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            SetObjectAttributeValue = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function IsObjectTypeOf(ByRef inObject As Object, ByVal inObjectTypeName As String) As Boolean
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim objType As Type

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            IsObjectTypeOf = False

            If (inObject Is Nothing) Then
                Exit Function
            End If

            objType = inObject.GetType()
            If (Not (objType Is Nothing)) Then

            End If

            IsObjectTypeOf = True

        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            IsObjectTypeOf = False
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function IsFormBasedObject(ByRef inObject As Object) As Boolean
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            IsFormBasedObject = False

            If (inObject Is Nothing) Then
                Exit Function
            End If

            'If inObject.GetType() Is GetType(clsWinFormBaseDb) _
            '    Or inObject.GetType() Is GetType(clsWinFormBase) Then
            '    IsFormBasedObject = True
            'End If

            'Dim tmpObj As Object
            'tmpObj = inObject
            'Do While True
            '    If inObject.GetType() Is GetType(clsWinFormBaseDb) _
            '        Or inObject.GetType() Is GetType(clsWinFormBase) Then

            '        IsFormBasedObject = True
            '        Exit Do
            '    End If
            '    'tmpObj = CType(inObject, System.Windows.Forms.Form).Parent
            '    If tmpObj Is Nothing Then
            '        Exit Do
            '    End If
            'Loop

            IsFormBasedObject = True

        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            IsFormBasedObject = False
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetParamInfoTypeName(ByVal inParamInfo As ParameterInfo) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        '**************************************
        Dim ParamInfoType As Type
        Dim tmpString As String
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetParamInfoTypeName = ""

            If (IsNothing(inParamInfo)) Then
                Exit Function
            End If

            ParamInfoType = inParamInfo.ParameterType
            If (IsNothing(ParamInfoType)) Then
                Exit Function
            End If

            GetParamInfoTypeName = ParamInfoType.Name

            If (ParamInfoType.IsByRef = True) Then
                tmpString = GetParamInfoTypeName
                If (clsUtility.IsStringValid(tmpString, True)) Then
                    If (Right(tmpString, 1) = "&") Then
                        GetParamInfoTypeName = Left(tmpString, tmpString.Length - 1)
                    End If
                End If
            End If


        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetParamInfoTypeName = ""  'error case
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function ExecuteConstructorMethod(ByRef inObjectType As Type, ByRef outRetval As Object, ByRef inParams() As Object) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim tmpConstructorInfo As ConstructorInfo
        Dim tmpNewObject As Object
        Dim tmpObject As Object
        Dim Index As Integer
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ExecuteConstructorMethod = 1 'init at error

            If (Not (inObjectType Is Nothing)) Then
                If (Not (IsNothing(inParams))) Then
                    Dim Types(inParams.Length - 1) As Type
                    If (inParams.Length > 0) Then

                        Dim tmpType As Type
                        Index = 0
                        For Each tmpType In Types
                            tmpObject = inParams(Index)
                            Types(Index) = tmpObject.GetType()
                            Index += 1
                        Next
                    End If
                End If

                Dim tmpCons() As ConstructorInfo = inObjectType.GetConstructors()

                If (IsNothing(tmpCons)) Then
                    RetCode = 100
                    ExecuteConstructorMethod = RetCode
                    Exit Function
                End If

                tmpConstructorInfo = tmpCons(0)

                If (IsNothing(tmpConstructorInfo)) Then
                    RetCode = 100
                    ExecuteConstructorMethod = RetCode
                    Exit Function
                End If

                'try catch per esecuzione metodo [Invoke]
                Try
                    tmpNewObject = tmpConstructorInfo.Invoke(inParams)
                    If (Not (IsNothing(tmpNewObject))) Then
                        outRetval = tmpNewObject
                    End If
                    '**************************************
                Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
                    ExecuteConstructorMethod = 1000  'error case
                    'LOG ERROR CONDITION
                    clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
                    '**************************************
                Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

                End Try
            End If

            ExecuteConstructorMethod = RetCode

        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ExecuteConstructorMethod = 1000  'error case
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function LoadFormControls(ByVal inForm As System.Windows.Forms.Form, ByRef inCollection As Collection) As Long
        LoadFormControls = 1

        Try
            If inForm Is Nothing Then
                Return 20
            End If
            If IsFormBasedObject(inForm) = False Then
                Return 30
            End If
            If inCollection Is Nothing Then
                inCollection = New Collection
            End If

            For Each ctl As Control In inForm.Controls
                Try
                    If Not ctl Is Nothing Then
                        inCollection.Add(ctl)

                        'Ignore LoadChildControls() errors - controls not loaded will not be translated
                        LoadChildControls(ctl, inCollection)
                    End If
                Catch ex As Exception
                    clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
                    'continue...
                End Try
            Next

        Catch ex As Exception
            LoadFormControls = 1000
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
        Finally

        End Try
    End Function

    Private Shared Sub LoadChildControls(ByVal inControl As Control, ByRef inCollection As Collection)
        Try
            For Each ctl As Control In inControl.Controls
                inCollection.Add(ctl)
                LoadChildControls(ctl, inCollection)
            Next
        Catch ex As Exception
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
        Finally

        End Try
    End Sub
    Public Shared Function IsFormClassBased(ByVal inObjForm) As Boolean
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim baseClass As Type = inObjForm.GetType()
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'default returned value
            IsFormClassBased = False

            Do While (True)
                baseClass = baseClass.BaseType()
                If baseClass Is Nothing Then
                    Exit Do
                End If
                If GetType(System.Windows.Forms.Form).FullName = baseClass.FullName Then
                    Return True
                End If
            Loop

        Catch ex As Exception
            IsFormClassBased = 1000 'erorr
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        End Try
    End Function
End Class
