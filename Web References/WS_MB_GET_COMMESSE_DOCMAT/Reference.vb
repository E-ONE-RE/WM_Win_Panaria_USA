﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.34014
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.34014.
'
Namespace WS_MB_GET_COMMESSE_DOCMAT
    
    'CODEGEN: The optional WSDL extension element 'Policy' from namespace 'http://schemas.xmlsoap.org/ws/2004/09/policy' was not handled.
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="ZWS_MB_GET_COMMESSE_DOCMAT", [Namespace]:="urn:sap-com:document:sap:soap:functions:mc-style")>  _
    Partial Public Class ZWS_MB_GET_COMMESSE_DOCMAT
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private ZwmMbGetCommesseDocmatOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.WM_Win_PanariaUSA.My.MySettings.Default.WM_Win_PanariaUSA_WS_MB_GET_COMMESSE_DOCMAT_ZWS_MB_GET_COMMESSE_DOCMAT
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event ZwmMbGetCommesseDocmatCompleted As ZwmMbGetCommesseDocmatCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:sap-com:document:sap:soap:functions:mc-style:ZWS_MB_GET_COMMESSE_DOCMAT:ZwmMb"& _ 
            "GetCommesseDocmatRequest", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Bare)>  _
        Public Function ZwmMbGetCommesseDocmat(<System.Xml.Serialization.XmlElementAttribute("ZwmMbGetCommesseDocmat", [Namespace]:="urn:sap-com:document:sap:soap:functions:mc-style")> ByVal ZwmMbGetCommesseDocmat1 As ZwmMbGetCommesseDocmat) As <System.Xml.Serialization.XmlElementAttribute("ZwmMbGetCommesseDocmatResponse", [Namespace]:="urn:sap-com:document:sap:soap:functions:mc-style")> ZwmMbGetCommesseDocmatResponse
            Dim results() As Object = Me.Invoke("ZwmMbGetCommesseDocmat", New Object() {ZwmMbGetCommesseDocmat1})
            Return CType(results(0),ZwmMbGetCommesseDocmatResponse)
        End Function
        
        '''<remarks/>
        Public Overloads Sub ZwmMbGetCommesseDocmatAsync(ByVal ZwmMbGetCommesseDocmat1 As ZwmMbGetCommesseDocmat)
            Me.ZwmMbGetCommesseDocmatAsync(ZwmMbGetCommesseDocmat1, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub ZwmMbGetCommesseDocmatAsync(ByVal ZwmMbGetCommesseDocmat1 As ZwmMbGetCommesseDocmat, ByVal userState As Object)
            If (Me.ZwmMbGetCommesseDocmatOperationCompleted Is Nothing) Then
                Me.ZwmMbGetCommesseDocmatOperationCompleted = AddressOf Me.OnZwmMbGetCommesseDocmatOperationCompleted
            End If
            Me.InvokeAsync("ZwmMbGetCommesseDocmat", New Object() {ZwmMbGetCommesseDocmat1}, Me.ZwmMbGetCommesseDocmatOperationCompleted, userState)
        End Sub
        
        Private Sub OnZwmMbGetCommesseDocmatOperationCompleted(ByVal arg As Object)
            If (Not (Me.ZwmMbGetCommesseDocmatCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent ZwmMbGetCommesseDocmatCompleted(Me, New ZwmMbGetCommesseDocmatCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="urn:sap-com:document:sap:soap:functions:mc-style")>  _
    Partial Public Class ZwmMbGetCommesseDocmat
        
        Private iElaborationTypeField As String
        
        Private iEnableDebugField As String
        
        Private iLanguageField As String
        
        Private iMblnrField As String
        
        Private iMjahrField As String
        
        Private iZeileField As String
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property IElaborationType() As String
            Get
                Return Me.iElaborationTypeField
            End Get
            Set(value As String)
                Me.iElaborationTypeField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property IEnableDebug() As String
            Get
                Return Me.iEnableDebugField
            End Get
            Set(value As String)
                Me.iEnableDebugField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property ILanguage() As String
            Get
                Return Me.iLanguageField
            End Get
            Set(value As String)
                Me.iLanguageField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property IMblnr() As String
            Get
                Return Me.iMblnrField
            End Get
            Set(value As String)
                Me.iMblnrField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property IMjahr() As String
            Get
                Return Me.iMjahrField
            End Get
            Set(value As String)
                Me.iMjahrField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property IZeile() As String
            Get
                Return Me.iZeileField
            End Get
            Set(value As String)
                Me.iZeileField = value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="urn:sap-com:document:sap:soap:functions:mc-style")> _
    Partial Public Class Bapiret2

        Private typeField As String

        Private idField As String

        Private numberField As String

        Private messageField As String

        Private logNoField As String

        Private logMsgNoField As String

        Private messageV1Field As String

        Private messageV2Field As String

        Private messageV3Field As String

        Private messageV4Field As String

        Private parameterField As String

        Private rowField As Integer

        Private fieldField As String

        Private systemField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property Type() As String
            Get
                Return Me.typeField
            End Get
            Set(value As String)
                Me.typeField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property Id() As String
            Get
                Return Me.idField
            End Get
            Set(value As String)
                Me.idField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property Number() As String
            Get
                Return Me.numberField
            End Get
            Set(value As String)
                Me.numberField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property Message() As String
            Get
                Return Me.messageField
            End Get
            Set(value As String)
                Me.messageField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property LogNo() As String
            Get
                Return Me.logNoField
            End Get
            Set(value As String)
                Me.logNoField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property LogMsgNo() As String
            Get
                Return Me.logMsgNoField
            End Get
            Set(value As String)
                Me.logMsgNoField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property MessageV1() As String
            Get
                Return Me.messageV1Field
            End Get
            Set(value As String)
                Me.messageV1Field = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property MessageV2() As String
            Get
                Return Me.messageV2Field
            End Get
            Set(value As String)
                Me.messageV2Field = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property MessageV3() As String
            Get
                Return Me.messageV3Field
            End Get
            Set(value As String)
                Me.messageV3Field = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property MessageV4() As String
            Get
                Return Me.messageV4Field
            End Get
            Set(value As String)
                Me.messageV4Field = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property Parameter() As String
            Get
                Return Me.parameterField
            End Get
            Set(value As String)
                Me.parameterField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property Row() As Integer
            Get
                Return Me.rowField
            End Get
            Set(value As Integer)
                Me.rowField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property Field() As String
            Get
                Return Me.fieldField
            End Get
            Set(value As String)
                Me.fieldField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property System() As String
            Get
                Return Me.systemField
            End Get
            Set(value As String)
                Me.systemField = value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="urn:sap-com:document:sap:soap:functions:mc-style")> _
    Partial Public Class ZcommesseDocmatTab

        Private mblnrField As String

        Private mjahrField As String

        Private zeileField As String

        Private codiceCommessaField As String

        Private mengeField As Decimal

        Private meinsField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property Mblnr() As String
            Get
                Return Me.mblnrField
            End Get
            Set(value As String)
                Me.mblnrField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property Mjahr() As String
            Get
                Return Me.mjahrField
            End Get
            Set(value As String)
                Me.mjahrField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property Zeile() As String
            Get
                Return Me.zeileField
            End Get
            Set(value As String)
                Me.zeileField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property CodiceCommessa() As String
            Get
                Return Me.codiceCommessaField
            End Get
            Set(value As String)
                Me.codiceCommessaField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property Menge() As Decimal
            Get
                Return Me.mengeField
            End Get
            Set(value As Decimal)
                Me.mengeField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property Meins() As String
            Get
                Return Me.meinsField
            End Get
            Set(value As String)
                Me.meinsField = value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="urn:sap-com:document:sap:soap:functions:mc-style")> _
    Partial Public Class ZwmMbGetCommesseDocmatResponse

        Private eCommDocmatTabField() As ZcommesseDocmatTab

        Private eErrorCodeField As String

        Private eErrorDescriptionField As String

        Private eErrorSubrcField As Integer

        Private eReturnField() As Bapiret2

        Private eSuccessField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified), _
         System.Xml.Serialization.XmlArrayItemAttribute("item", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)> _
        Public Property ECommDocmatTab() As ZcommesseDocmatTab()
            Get
                Return Me.eCommDocmatTabField
            End Get
            Set(value As ZcommesseDocmatTab())
                Me.eCommDocmatTabField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property EErrorCode() As String
            Get
                Return Me.eErrorCodeField
            End Get
            Set(value As String)
                Me.eErrorCodeField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property EErrorDescription() As String
            Get
                Return Me.eErrorDescriptionField
            End Get
            Set(value As String)
                Me.eErrorDescriptionField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property EErrorSubrc() As Integer
            Get
                Return Me.eErrorSubrcField
            End Get
            Set(value As Integer)
                Me.eErrorSubrcField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified), _
         System.Xml.Serialization.XmlArrayItemAttribute("item", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)> _
        Public Property EReturn() As Bapiret2()
            Get
                Return Me.eReturnField
            End Get
            Set(value As Bapiret2())
                Me.eReturnField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=Xml.Schema.XmlSchemaForm.Unqualified)> _
        Public Property ESuccess() As String
            Get
                Return Me.eSuccessField
            End Get
            Set(value As String)
                Me.eSuccessField = Value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")>  _
    Public Delegate Sub ZwmMbGetCommesseDocmatCompletedEventHandler(ByVal sender As Object, ByVal e As ZwmMbGetCommesseDocmatCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class ZwmMbGetCommesseDocmatCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As ZwmMbGetCommesseDocmatResponse
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),ZwmMbGetCommesseDocmatResponse)
            End Get
        End Property
    End Class
End Namespace
