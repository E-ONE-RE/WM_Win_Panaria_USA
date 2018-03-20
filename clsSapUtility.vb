' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 19/09/2011
' DATA MODIFICA     : 19/09/2011
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa diverse function di UTILITY di SAP
' *****************************************************************************************

Imports System.Web.Services
Imports System.Xml.Schema.XmlSchemaForm
Imports System.Data
Imports System.Windows.Forms
Imports clsSapWS
Imports WS_MB_CHECK_DOCMAT
Imports WS_MB_EXEC_WM_TO
Imports clsBusinessLogic
Imports clsDataType

#If APPLICAZIONE_WIN32 = "SI" Then
Imports SAP.Middleware.Connector
Imports clsSAPNetConn
#End If

Public Class clsSapUtility

    '*****************************************
    'MANAGE OF CODE VERSION 
    Private Const CodeClassObjectName As String = "clsSapUtility"

    Public Const cstSapTipoMagProduzione As String = "100"
    Public Const cstSapTipoMagUscitaMerci As String = "916"
    Public Const cstSapTipoMagPronto As String = "Z01"
    Public Const cstSapTipoMagWork As String = "w01"
    Public Const cstSapTipoMagDisaccantonamento As String = "Z08"
    Public Const cstSapUbicazioneDisaccantonamento As String = "RIENTRO"
    Public Const cstSapTipoDocumentoReso As String = "ZRE"

    Public Shared Function ResetJobsQueueWeightInfoStruct(ByRef inStrctToReset As clsDataType.JobsQueueWeightInfoStruct) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ResetJobsQueueWeightInfoStruct = 1 'init at error

            inStrctToReset.PesoTotaleCoda_Kg = 0
            inStrctToReset.PesoRimanenteCoda_Kg = 0
            inStrctToReset.UdmPesoKg = ""
            inStrctToReset.PesoTotaleCoda_Lb = 0
            inStrctToReset.PesoRimanenteCoda_Lb = 0
            inStrctToReset.UdmPesoLb = ""

            ResetJobsQueueWeightInfoStruct = RetCode  'se tutto ok = 0

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ResetJobsQueueWeightInfoStruct = 1000 'catch error
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ResetSapAnagraficaClienteStruct(ByRef inStrctToReset As clsDataType.SapAnagraficaCliente) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ResetSapAnagraficaClienteStruct = 1 'init at error

            inStrctToReset.CAP = ""
            inStrctToReset.CodiceCliente = ""
            inStrctToReset.CodiceIndirizzo = ""
            inStrctToReset.CodicePaese = 0
            inStrctToReset.Localita = ""
            inStrctToReset.Nome1 = ""
            inStrctToReset.Nome2 = ""
            inStrctToReset.Regione = ""
            inStrctToReset.Telefono = ""


            ResetSapAnagraficaClienteStruct = RetCode  'se tutto ok = 0

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ResetSapAnagraficaClienteStruct = 1000 'catch error
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Public Shared Function ResetSapBemOtInfoStruct(ByRef inStrctToReset As StrctSapWMSOtInfo) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ResetSapBemOtInfoStruct = 1 'init at error

            inStrctToReset.Info = ""

#If Not APPLICAZIONE_WIN32 = "SI" Then

            inStrctToReset.SapOtInfo_Rec.IAblad = ""
            inStrctToReset.SapOtInfo_Rec.IAltme = ""
            inStrctToReset.SapOtInfo_Rec.IAnfme = 0
            inStrctToReset.SapOtInfo_Rec.IBenum = ""
            inStrctToReset.SapOtInfo_Rec.IBestq = ""
            inStrctToReset.SapOtInfo_Rec.IBetyp = ""
            inStrctToReset.SapOtInfo_Rec.IBwlvs = ""
            inStrctToReset.SapOtInfo_Rec.ICharg = ""
            inStrctToReset.SapOtInfo_Rec.IElaborationType = ""
            inStrctToReset.SapOtInfo_Rec.IEnableDebug = ""
            inStrctToReset.SapOtInfo_Rec.ILanguage = ""
            inStrctToReset.SapOtInfo_Rec.ILetyp = ""
            inStrctToReset.SapOtInfo_Rec.ILgnum = ""
            inStrctToReset.SapOtInfo_Rec.ILgort = ""
            inStrctToReset.SapOtInfo_Rec.IMatnr = ""
            inStrctToReset.SapOtInfo_Rec.IMblnr = ""
            inStrctToReset.SapOtInfo_Rec.IMessageId = ""
            inStrctToReset.SapOtInfo_Rec.IMjahr = ""
            inStrctToReset.SapOtInfo_Rec.INlber = ""
            inStrctToReset.SapOtInfo_Rec.INlenr = ""
            inStrctToReset.SapOtInfo_Rec.INlpla = ""
            inStrctToReset.SapOtInfo_Rec.INltyp = ""
            inStrctToReset.SapOtInfo_Rec.INppos = ""
            inStrctToReset.SapOtInfo_Rec.IReceiverId = ""
            inStrctToReset.SapOtInfo_Rec.ISenderId = ""
            inStrctToReset.SapOtInfo_Rec.ISobkz = ""
            inStrctToReset.SapOtInfo_Rec.ISonum = ""
            inStrctToReset.SapOtInfo_Rec.ISquit = ""
            inStrctToReset.SapOtInfo_Rec.ITbnum = ""
            inStrctToReset.SapOtInfo_Rec.ITbpos = ""
            inStrctToReset.SapOtInfo_Rec.ITestrun = ""
            inStrctToReset.SapOtInfo_Rec.IUserId = ""
            inStrctToReset.SapOtInfo_Rec.IVlber = ""
            inStrctToReset.SapOtInfo_Rec.IVlenr = ""
            inStrctToReset.SapOtInfo_Rec.IVlpla = ""
            inStrctToReset.SapOtInfo_Rec.IVlqnr = ""
            inStrctToReset.SapOtInfo_Rec.IVltyp = ""
            inStrctToReset.SapOtInfo_Rec.IVppos = ""
            inStrctToReset.SapOtInfo_Rec.IWerks = ""

            inStrctToReset.SapOtInfo_Rec.IBemActDurata = 0
            inStrctToReset.SapOtInfo_Rec.IBemActEnDt = ""
            inStrctToReset.SapOtInfo_Rec.IBemActEnTm = ""
            inStrctToReset.SapOtInfo_Rec.IBemActStDt = ""
            inStrctToReset.SapOtInfo_Rec.IBemActStTm = ""

            inStrctToReset.SapOtInfo_Rec.ILgtypSpunta = ""
            inStrctToReset.SapOtInfo_Rec.IUseridRf = ""

#Else

            inStrctToReset.rfcSapOtInfo_Rec.IAblad = ""
            inStrctToReset.rfcSapOtInfo_Rec.IAltme = ""
            inStrctToReset.rfcSapOtInfo_Rec.IAnfme = 0
            inStrctToReset.rfcSapOtInfo_Rec.IBenum = ""
            inStrctToReset.rfcSapOtInfo_Rec.IBestq = ""
            inStrctToReset.rfcSapOtInfo_Rec.IBetyp = ""
            inStrctToReset.rfcSapOtInfo_Rec.IBwlvs = ""
            inStrctToReset.rfcSapOtInfo_Rec.ICharg = ""
            inStrctToReset.rfcSapOtInfo_Rec.IElaborationType = ""
            inStrctToReset.rfcSapOtInfo_Rec.IEnableDebug = ""
            inStrctToReset.rfcSapOtInfo_Rec.ILanguage = ""
            inStrctToReset.rfcSapOtInfo_Rec.ILetyp = ""
            inStrctToReset.rfcSapOtInfo_Rec.ILgnum = ""
            inStrctToReset.rfcSapOtInfo_Rec.ILgort = ""
            inStrctToReset.rfcSapOtInfo_Rec.IMatnr = ""
            inStrctToReset.rfcSapOtInfo_Rec.IMblnr = ""
            inStrctToReset.rfcSapOtInfo_Rec.IMessageId = ""
            inStrctToReset.rfcSapOtInfo_Rec.IMjahr = ""
            inStrctToReset.rfcSapOtInfo_Rec.INlber = ""
            inStrctToReset.rfcSapOtInfo_Rec.INlenr = ""
            inStrctToReset.rfcSapOtInfo_Rec.INlpla = ""
            inStrctToReset.rfcSapOtInfo_Rec.INltyp = ""
            inStrctToReset.rfcSapOtInfo_Rec.INppos = ""
            inStrctToReset.rfcSapOtInfo_Rec.IReceiverId = ""
            inStrctToReset.rfcSapOtInfo_Rec.ISenderId = ""
            inStrctToReset.rfcSapOtInfo_Rec.ISobkz = ""
            inStrctToReset.rfcSapOtInfo_Rec.ISonum = ""
            inStrctToReset.rfcSapOtInfo_Rec.ISquit = ""
            inStrctToReset.rfcSapOtInfo_Rec.ITbnum = ""
            inStrctToReset.rfcSapOtInfo_Rec.ITbpos = ""
            inStrctToReset.rfcSapOtInfo_Rec.ITestrun = ""
            inStrctToReset.rfcSapOtInfo_Rec.IUserId = ""
            inStrctToReset.rfcSapOtInfo_Rec.IVlber = ""
            inStrctToReset.rfcSapOtInfo_Rec.IVlenr = ""
            inStrctToReset.rfcSapOtInfo_Rec.IVlpla = ""
            inStrctToReset.rfcSapOtInfo_Rec.IVlqnr = ""
            inStrctToReset.rfcSapOtInfo_Rec.IVltyp = ""
            inStrctToReset.rfcSapOtInfo_Rec.IVppos = ""
            inStrctToReset.rfcSapOtInfo_Rec.IWerks = ""

            inStrctToReset.rfcSapOtInfo_Rec.IBemActDurata = 0
            inStrctToReset.rfcSapOtInfo_Rec.IBemActEnDt = ""
            inStrctToReset.rfcSapOtInfo_Rec.IBemActEnTm = ""
            inStrctToReset.rfcSapOtInfo_Rec.IBemActStDt = ""
            inStrctToReset.rfcSapOtInfo_Rec.IBemActStTm = ""

            inStrctToReset.rfcSapOtInfo_Rec.ILgtypSpunta = ""
            inStrctToReset.rfcSapOtInfo_Rec.IUseridRf = ""

#End If


            ResetSapBemOtInfoStruct = RetCode  'se tutto ok = 0

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ResetSapBemOtInfoStruct = 1000 'catch error
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ResetSapOtInfoStruct(ByRef inStrctToReset As StrctSapWMSOtInfo) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ResetSapOtInfoStruct = 1 'init at error

            inStrctToReset.Info = ""

#If Not APPLICAZIONE_WIN32 = "SI" Then

            inStrctToReset.SapOtInfo_Rec.IAblad = ""
            inStrctToReset.SapOtInfo_Rec.IAltme = ""
            inStrctToReset.SapOtInfo_Rec.IAnfme = 0
            inStrctToReset.SapOtInfo_Rec.IBenum = ""
            inStrctToReset.SapOtInfo_Rec.IBestq = ""
            inStrctToReset.SapOtInfo_Rec.IBetyp = ""
            inStrctToReset.SapOtInfo_Rec.IBwlvs = ""
            inStrctToReset.SapOtInfo_Rec.ICharg = ""
            inStrctToReset.SapOtInfo_Rec.IElaborationType = ""
            inStrctToReset.SapOtInfo_Rec.IEnableDebug = ""
            inStrctToReset.SapOtInfo_Rec.ILanguage = ""
            inStrctToReset.SapOtInfo_Rec.ILetyp = ""
            inStrctToReset.SapOtInfo_Rec.ILgnum = ""
            inStrctToReset.SapOtInfo_Rec.ILgort = ""
            inStrctToReset.SapOtInfo_Rec.IMatnr = ""
            inStrctToReset.SapOtInfo_Rec.IMblnr = ""
            inStrctToReset.SapOtInfo_Rec.IMessageId = ""
            inStrctToReset.SapOtInfo_Rec.IMjahr = ""
            inStrctToReset.SapOtInfo_Rec.INlber = ""
            inStrctToReset.SapOtInfo_Rec.INlenr = ""
            inStrctToReset.SapOtInfo_Rec.INlpla = ""
            inStrctToReset.SapOtInfo_Rec.INltyp = ""
            inStrctToReset.SapOtInfo_Rec.INppos = ""
            inStrctToReset.SapOtInfo_Rec.IReceiverId = ""
            inStrctToReset.SapOtInfo_Rec.ISenderId = ""
            inStrctToReset.SapOtInfo_Rec.ISobkz = ""
            inStrctToReset.SapOtInfo_Rec.ISonum = ""
            inStrctToReset.SapOtInfo_Rec.ISquit = ""
            inStrctToReset.SapOtInfo_Rec.ITbnum = ""
            inStrctToReset.SapOtInfo_Rec.ITbpos = ""
            inStrctToReset.SapOtInfo_Rec.ITestrun = ""
            inStrctToReset.SapOtInfo_Rec.IUserId = ""
            inStrctToReset.SapOtInfo_Rec.IVlber = ""
            inStrctToReset.SapOtInfo_Rec.IVlenr = ""
            inStrctToReset.SapOtInfo_Rec.IVlpla = ""
            inStrctToReset.SapOtInfo_Rec.IVlqnr = ""
            inStrctToReset.SapOtInfo_Rec.IVltyp = ""
            inStrctToReset.SapOtInfo_Rec.IVppos = ""
            inStrctToReset.SapOtInfo_Rec.IWerks = ""

#Else

            inStrctToReset.rfcSapOtInfo_Rec.IAblad = ""
            inStrctToReset.rfcSapOtInfo_Rec.IAltme = ""
            inStrctToReset.rfcSapOtInfo_Rec.IAnfme = 0
            inStrctToReset.rfcSapOtInfo_Rec.IBenum = ""
            inStrctToReset.rfcSapOtInfo_Rec.IBestq = ""
            inStrctToReset.rfcSapOtInfo_Rec.IBetyp = ""
            inStrctToReset.rfcSapOtInfo_Rec.IBwlvs = ""
            inStrctToReset.rfcSapOtInfo_Rec.ICharg = ""
            inStrctToReset.rfcSapOtInfo_Rec.IElaborationType = ""
            inStrctToReset.rfcSapOtInfo_Rec.IEnableDebug = ""
            inStrctToReset.rfcSapOtInfo_Rec.ILanguage = ""
            inStrctToReset.rfcSapOtInfo_Rec.ILetyp = ""
            inStrctToReset.rfcSapOtInfo_Rec.ILgnum = ""
            inStrctToReset.rfcSapOtInfo_Rec.ILgort = ""
            inStrctToReset.rfcSapOtInfo_Rec.IMatnr = ""
            inStrctToReset.rfcSapOtInfo_Rec.IMblnr = ""
            inStrctToReset.rfcSapOtInfo_Rec.IMessageId = ""
            inStrctToReset.rfcSapOtInfo_Rec.IMjahr = ""
            inStrctToReset.rfcSapOtInfo_Rec.INlber = ""
            inStrctToReset.rfcSapOtInfo_Rec.INlenr = ""
            inStrctToReset.rfcSapOtInfo_Rec.INlpla = ""
            inStrctToReset.rfcSapOtInfo_Rec.INltyp = ""
            inStrctToReset.rfcSapOtInfo_Rec.INppos = ""
            inStrctToReset.rfcSapOtInfo_Rec.IQtaExecutedSfusi = 0
            inStrctToReset.rfcSapOtInfo_Rec.IReceiverId = ""
            inStrctToReset.rfcSapOtInfo_Rec.ISenderId = ""
            inStrctToReset.rfcSapOtInfo_Rec.ISobkz = ""
            inStrctToReset.rfcSapOtInfo_Rec.ISonum = ""
            inStrctToReset.rfcSapOtInfo_Rec.ISquit = ""
            inStrctToReset.rfcSapOtInfo_Rec.ITbnum = ""
            inStrctToReset.rfcSapOtInfo_Rec.ITbpos = ""
            inStrctToReset.rfcSapOtInfo_Rec.ITestrun = ""
            inStrctToReset.rfcSapOtInfo_Rec.IUserId = ""
            inStrctToReset.rfcSapOtInfo_Rec.IVlber = ""
            inStrctToReset.rfcSapOtInfo_Rec.IVlenr = ""
            inStrctToReset.rfcSapOtInfo_Rec.IVlpla = ""
            inStrctToReset.rfcSapOtInfo_Rec.IVlqnr = ""
            inStrctToReset.rfcSapOtInfo_Rec.IVltyp = ""
            inStrctToReset.rfcSapOtInfo_Rec.IVppos = ""
            inStrctToReset.rfcSapOtInfo_Rec.IWerks = ""

#End If


            ResetSapOtInfoStruct = RetCode  'se tutto ok = 0

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ResetSapOtInfoStruct = 1000 'catch error
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function ResetSapForkLiftStuct(ByRef inStrctToReset As clsDataType.SapForkLiftStruct) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ResetSapForkLiftStuct = 1 'init at error

            inStrctToReset.Divisione = ""
            inStrctToReset.NumeroMagazzino = ""
            inStrctToReset.TipoMagazzino = ""
            inStrctToReset.Ubicazione = ""
            inStrctToReset.IdForkLift = ""
            inStrctToReset.DescrizioneForkLift = ""
            inStrctToReset.ForkLiftMaxPesoCarico = 0
            inStrctToReset.UdmPeso = ""
            inStrctToReset.NumUdsOnForklift = 0

            ResetSapForkLiftStuct = RetCode  'se tutto ok = 0

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ResetSapForkLiftStuct = 1000 'catch error
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Public Shared Function ResetSapTaskLinesSingleStuct(ByRef inStrctToReset As clsDataType.SapTaskLinesSingle) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ResetSapTaskLinesSingleStuct = 1 'init at error

            inStrctToReset.NrWmsJobs = 0
            inStrctToReset.NrTaskLines = ""
            inStrctToReset.TaskLinesSequence = 0
            inStrctToReset.PickFullPartialType = ""
            inStrctToReset.IdTaskLinesStatus = 0
            inStrctToReset.DataCreazione = Date.MinValue
            inStrctToReset.OraCreazione = Date.MinValue

            inStrctToReset.QtaJobRichiestaInUdmBase = 0
            inStrctToReset.UnitaDiMisuraBase = ""
            inStrctToReset.QtaJobRichiestaInUdmConsegna = 0
            inStrctToReset.UnitaDiMisuraConsegna = ""
            inStrctToReset.QtaJobRichiestaFullPallet = 0
            inStrctToReset.QtaJobRichiestaPartialPallet = 0
            inStrctToReset.QtaJobRichiestaSfusiInPZ = 0

            inStrctToReset.QtaPrelevataInUdMBase = 0
            inStrctToReset.UdmQtaPrelevataInUdMBase = ""
            inStrctToReset.QtaPrelevataInUdMConsegna = 0
            inStrctToReset.UdmQtaPrelevataInUdMConsegna = ""
            inStrctToReset.QtaPrelevataFullPallet = 0
            inStrctToReset.QtaPrelevataPartialPallet = 0

            inStrctToReset.QtaPrelevataSfusi = 0
            inStrctToReset.QtaPrelevataInUdMPezzo = 0
            inStrctToReset.IdCarrellistaEsecuzione = ""

            ResetSapTaskLinesSingleStuct = RetCode  'se tutto ok = 0

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ResetSapTaskLinesSingleStuct = 1000 'catch error
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ResetSapTaskLinesSingleStruct(ByRef inStrctToReset As clsDataType.SapTaskLinesSingle) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ResetSapTaskLinesSingleStruct = 1 'init at error

            inStrctToReset.NrWmsJobs = 0
            inStrctToReset.NrTaskLines = ""
            inStrctToReset.TaskLinesSequence = 0
            inStrctToReset.PickFullPartialType = ""
            inStrctToReset.IdTaskLinesStatus = 0
            inStrctToReset.DataCreazione = Date.MinValue
            inStrctToReset.OraCreazione = Date.MinValue

            inStrctToReset.QtaJobRichiestaInUdmBase = 0
            inStrctToReset.UnitaDiMisuraBase = ""
            inStrctToReset.QtaJobRichiestaInUdmConsegna = 0
            inStrctToReset.UnitaDiMisuraConsegna = ""

            inStrctToReset.QtaPrelevataInUdMBase = 0
            inStrctToReset.UdmQtaPrelevataInUdMBase = ""
            inStrctToReset.QtaPrelevataInUdMConsegna = 0
            inStrctToReset.UdmQtaPrelevataInUdMConsegna = ""
            inStrctToReset.QtaJobRichiestaFullPallet = 0
            inStrctToReset.QtaJobRichiestaPartialPallet = 0
            inStrctToReset.QtaJobRichiestaSfusiInPZ = 0

            inStrctToReset.QtaPrelevataFullPallet = 0
            inStrctToReset.QtaPrelevataPartialPallet = 0
            inStrctToReset.QtaPrelevataSfusi = 0
            inStrctToReset.QtaPrelevataInUdMPezzo = 0
            inStrctToReset.UnitaDiMisuraPezzo = ""
            inStrctToReset.PesoTotaleMaterialeTaskLine_Kg = 0
            inStrctToReset.UdmPesoKg = ""
            inStrctToReset.PesoTotaleMaterialeTaskLine_Lb = 0
            inStrctToReset.UdmPesoLb = ""
            inStrctToReset.IdCarrellistaEsecuzione = ""


            ResetSapTaskLinesSingleStruct = RetCode  'se tutto ok = 0

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ResetSapTaskLinesSingleStruct = 1000 'catch error
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ResetSapTaskLinesInfoStruct(ByRef inStrctToReset As clsDataType.SapTaskLinesInfo) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ResetSapTaskLinesInfoStruct = 1 'init at error

            inStrctToReset.NrWmsJobs = 0
            inStrctToReset.TotalTaskLines = 0
            inStrctToReset.TotalTaskLinesFull = 0
            inStrctToReset.TotalTaskLinesPartial = 0
            inStrctToReset.TotalTaskLinesDone = 0
            inStrctToReset.TotalTaskLinesDoneFull = 0
            inStrctToReset.TotalTaskLinesDoneFull = 0
            inStrctToReset.TotalTaskLinesDonePartial = 0
            inStrctToReset.TotalTaskLineOpen = 0
            inStrctToReset.TotalTaskLinesOpenFull = 0
            inStrctToReset.TotalTaskLinesOpenPartial = 0

            ResetSapTaskLinesInfoStruct = RetCode  'se tutto ok = 0

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ResetSapTaskLinesInfoStruct = 1000 'catch error
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ResetSapVarianteImballoStruct(ByRef inStrctToReset As clsDataType.SapVarianteImballo) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ResetSapVarianteImballoStruct = 1 'init at error

            inStrctToReset.CodiceMateriale = ""
            inStrctToReset.VarianteImballo = ""
            inStrctToReset.PezziPerScatola = 0
            inStrctToReset.ScatolePerPallet = 0
            inStrctToReset.M2PerPallet = 0
            inStrctToReset.CodiceEAN11_Scatola = ""
            inStrctToReset.CodiceEAN11_Pallet = ""
            inStrctToReset.CodiceImballo = ""
            inStrctToReset.PalletLarghezza = 0
            inStrctToReset.PalletProfondita = 0
            inStrctToReset.PalletAltezza = 0
            inStrctToReset.PalletAltezzaSingoloPiano = 0
            inStrctToReset.PalletAltezzaPianale = 0
            inStrctToReset.PalletNumeroColliPerPiano = 0
            inStrctToReset.Testo = ""
            inStrctToReset.CodiceMaterialeAlternativo = ""

            ResetSapVarianteImballoStruct = RetCode  'se tutto ok = 0

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ResetSapVarianteImballoStruct = 1000 'catch error
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ResetUDS_WeightInfoStruct(ByRef inStrctToReset As clsDataType.UDS_WeightInfoStruct) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ResetUDS_WeightInfoStruct = 1 'init at error

            inStrctToReset.PesoTotaleUDS_Kg = 0
            inStrctToReset.UdmPesoKg = ""
            inStrctToReset.PesoTotaleUDS_Lb = 0
            inStrctToReset.UdmPesoLb = ""

            ResetUDS_WeightInfoStruct = RetCode  'se tutto ok = 0

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ResetUDS_WeightInfoStruct = 1000 'catch error
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function ResetSapUDSInfoStruct(ByRef inStrctToReset As clsDataType.SapUDSInfo) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ResetSapUDSInfoStruct = 1 'init at error

            inStrctToReset.Divisione = ""
            inStrctToReset.NumeroMagazzino = ""
            inStrctToReset.TipoMagazzino = ""
            inStrctToReset.Ubicazione = ""
            inStrctToReset.DescUbicazione = ""
            inStrctToReset.UnitaMagazzino = ""
            inStrctToReset.TipoUnitaMagazzino = ""
            inStrctToReset.CodiceMateriale = ""
            inStrctToReset.DescrizioneMateriale = ""
            inStrctToReset.SKU = ""
            inStrctToReset.CdStockSpeciale = ""
            inStrctToReset.NumeroStockSpeciale = ""
            inStrctToReset.TipoStock = ""
            inStrctToReset.NumeroFabbisognoDiTrasporto = 0
            inStrctToReset.Partita = ""
            inStrctToReset.NrWmsJobs = 0
            inStrctToReset.NrTrasporto = 0
            inStrctToReset.Consegna = ""
            inStrctToReset.PosConsegna = ""
            inStrctToReset.CodiceGruppoMissioni = ""
            inStrctToReset.StopSequence = ""
            inStrctToReset.DropSequence = ""

            inStrctToReset.QtaPrelevataInUdMBase = 0
            inStrctToReset.UdmQtaPrelevataInUdMBase = ""
            inStrctToReset.QtaPrelevataInUdMConsegna = 0
            inStrctToReset.UdmQtaPrelevataInUdMConsegna = ""
            inStrctToReset.QtaPrelevataInUdMPezzo = 0
            inStrctToReset.UdmQtaPrelevataInUdMPezzo = ""
            inStrctToReset.PesoMaterialeNettoEU = 0
            inStrctToReset.UnitaDiPesoMatEU = ""
            inStrctToReset.PesoMaterialeNettoUSA = 0
            inStrctToReset.UnitaDiPesoMatUSA = ""
            inStrctToReset.DataCreazione = ""
            inStrctToReset.OraCreazione = ""
            inStrctToReset.DataModifica = ""
            inStrctToReset.OraModifica = ""
            inStrctToReset.UserIdRFCrea = ""
            inStrctToReset.UserIdRFMod = ""
            inStrctToReset.UserId = ""


            inStrctToReset.CodiceMaterialeComplessivo = ""
            inStrctToReset.NrTotComponenti = 0
            inStrctToReset.TotQtaPalletInUdMBase = 0
            inStrctToReset.TotQtaPalletInUdMConsegna = 0
            inStrctToReset.MagazzinoLogico = ""
            inStrctToReset.PickSUCompleto = False

            ResetUbicazioneStruct(inStrctToReset.UbicazioneInfo)
            ResetSapVarianteImballoStruct(inStrctToReset.VarianteImballo)

            inStrctToReset.CodicePartnerAg = ""
            inStrctToReset.ZAG_NAME = ""
            inStrctToReset.CodicePartnerWE = ""
            inStrctToReset.ZWE_NAME = ""
            inStrctToReset.LGNUM_STAG_DOOR = ""
            inStrctToReset.LGTYP_STAG_DOOR = ""
            inStrctToReset.LGPLA_STAG_DOOR = ""
            inStrctToReset.LGNUM_DOCK_DOOR = ""
            inStrctToReset.LGTYP_DOCK_DOOR = ""
            inStrctToReset.LGPLA_DOCK_DOOR = ""

            inStrctToReset.UDSTruckPalLoad = 0
            inStrctToReset.UDSTruckPalToLoad = 0
            inStrctToReset.UDSTruckNumPallet = 0
            inStrctToReset.UDSTruckLoadMerci = ""

            '>>>> INFO PER GESTIONE TRASFERIMENTO NAVETTA
            inStrctToReset.TruckDayNr = ""
            inStrctToReset.TrasfNumPallet = 0

            If (Not inStrctToReset.Componenti Is Nothing) Then
                If (inStrctToReset.Componenti.GetLength(0) > 0) Then
                    ReDim inStrctToReset.Componenti(0)
                    inStrctToReset.Componenti.Clear(inStrctToReset.Componenti, 0, 0)
                    inStrctToReset.Componenti = Nothing
                End If
            End If

            ResetSapUDSInfoStruct = RetCode  'se tutto ok = 0

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ResetSapUDSInfoStruct = 1000 'catch error
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ResetFlagErrorSkuElaborationStruct(ByRef inStrctToReset As clsDataType.FlagErrorSkuElaborationStruct) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ResetFlagErrorSkuElaborationStruct = 1 'init at error

            inStrctToReset.FlagErrorSku_MATNR = False
            inStrctToReset.FlagErrorSku_CHARG = False
            inStrctToReset.FlagErrorSku_ShadeNotFound = False
            inStrctToReset.FlagErrorSku_DiffMatnr = False
            inStrctToReset.FlagErrorSku_MatnrClass001 = False
            inStrctToReset.FlagErrorSku_DiffClass001 = False
            inStrctToReset.FlagErrorSku_DiffTono = False
            inStrctToReset.FlagErrorSku_DiffCalibro = False

            ResetFlagErrorSkuElaborationStruct = RetCode  'se tutto ok = 0

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ResetFlagErrorSkuElaborationStruct = 1000 'catch error
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ResetFlagCheckLenum(ByRef inStrctToReset As clsDataType.FlagCheckLenum) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ResetFlagCheckLenum = 1 'init at error

            inStrctToReset.FlagE_PRD_FLAG_MB31 = False
            inStrctToReset.FlagE_PRD_FLAG_ON_TRASFER = False
            inStrctToReset.FlagE_PRD_FLAG_OT1_DONE = False
            inStrctToReset.FlagE_PRD_FLAG_PUTAWAY = False
            inStrctToReset.FlagE_PRD_FLAG_REJECT = False
            inStrctToReset.FlagE_PRD_FLAG_SET_CQ = False
            inStrctToReset.FlagE_PRD_FLAG_SKIPUNLOAD = False
            inStrctToReset.FlagE_PRD_FLAG_TRASFER_OK = False

            ResetFlagCheckLenum = RetCode  'se tutto ok = 0

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ResetFlagCheckLenum = 1000 'catch error
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Public Shared Function ResetSapWmDocumentoMateriale(ByRef inStrctToReset As clsDataType.SapWmDocumentoMateriale) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ResetSapWmDocumentoMateriale = 1 'init at error

            inStrctToReset.AnnoEsercizio = ""
            inStrctToReset.NumeroDocumento = ""
            inStrctToReset.PosizioneDocumento = ""
            inStrctToReset.SkipMovimentoPerQtaNonDisponibile = False
            inStrctToReset.QtaNonDisponibile = 0

            ResetSapWmDocumentoMateriale = RetCode  'se tutto ok = 0

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ResetSapWmDocumentoMateriale = 1000 'catch error
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Public Shared Function ResetDocMatStruct(ByRef inStrctToReset As clsDataType.SapWmDocumentoMaterialeFull) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ResetDocMatStruct = 1 'init at error

            inStrctToReset.AnnoEsercizio = ""
            inStrctToReset.NumeroDocumento = ""
            inStrctToReset.PosizioneDocumento = ""

            ResetDocumentoMaterialePosStruct(inStrctToReset.PosizioneInfo)

            If (Not inStrctToReset.PosizioniInfo Is Nothing) Then
                ReDim inStrctToReset.PosizioniInfo(0)
                ResetDocumentoMaterialePosStruct(inStrctToReset.PosizioniInfo(0))
                inStrctToReset.PosizioniInfo.Clear(inStrctToReset.PosizioniInfo, 0, 0)
            End If

            ResetDocMatStruct = RetCode  'se tutto ok = 0

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ResetDocMatStruct = 1000 'catch error
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function ResetSapFornitoreLFA1Struct(ByVal inStrctToReset As clsDataType.SapFornitoreLFA1) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ResetSapFornitoreLFA1Struct = 1

            inStrctToReset.LIFNR = ""
            inStrctToReset.NAME1 = ""
            inStrctToReset.NAME2 = ""
            inStrctToReset.ORT01 = ""
            inStrctToReset.PSTLZ = ""
            inStrctToReset.REGIO = ""
            inStrctToReset.STRAS = ""

            ResetSapFornitoreLFA1Struct = RetCode
            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ResetSapFornitoreLFA1Struct = 1000
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function ResetSapPartnerKNA1Struct(ByVal inStrctToReset As clsDataType.SapPartnerKNA1) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ResetSapPartnerKNA1Struct = 1

            inStrctToReset.KUNNR = ""
            inStrctToReset.NAME1 = ""
            inStrctToReset.NAME2 = ""
            inStrctToReset.ORT01 = ""
            inStrctToReset.PSTLZ = ""
            inStrctToReset.REGIO = ""
            inStrctToReset.STRAS = ""

            ResetSapPartnerKNA1Struct = RetCode
            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ResetSapPartnerKNA1Struct = 1000
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function ResetWmsJobsGroupInfoStruct(ByRef inStrctToReset As clsDataType.SapJobsGroupInfo) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ResetWmsJobsGroupInfoStruct = 1

            inStrctToReset.NumAccorpamenti = 0
            inStrctToReset.NumeroJobsGroup = ""
            inStrctToReset.NumeroOrdinePicking = ""
            inStrctToReset.JobsGroupDescription = ""
            inStrctToReset.TipoDocumento = ""
            inStrctToReset.NumeroDocumento = ""
            inStrctToReset.RiferimentoOdA = ""
            inStrctToReset.RiferimentoOdV = ""

            ResetSapPartnerKNA1Struct(inStrctToReset.PartnerAGInfo)
            ResetSapPartnerKNA1Struct(inStrctToReset.PartnerWEInfo)

            ResetSapFornitoreLFA1Struct(inStrctToReset.FornitoreInfo)

            inStrctToReset.DivisioneDestinazione = ""
            inStrctToReset.MagLogicoDestinazione = ""

            inStrctToReset.IdCarrellistaProposto = ""
            inStrctToReset.IdCarrellistaEsecuzione = ""

            inStrctToReset.NumTotaleScatole = 0
            inStrctToReset.NumTotaleM2 = 0
            inStrctToReset.NumTotalePezzi = 0
            inStrctToReset.NumTotaleOthers = 0

            inStrctToReset.NumPickTotaleScatole = 0
            inStrctToReset.NumPickTotaleM2 = 0
            inStrctToReset.NumPickTotalePezzi = 0
            inStrctToReset.NumPickTotaleOthers = 0

            inStrctToReset.FoundGroupDeleted = False
            inStrctToReset.FoundRowsDeleted = 0

            inStrctToReset.JobsGroupClosed = False
            inStrctToReset.CheckMaterialePronto = ""

            ResetWmsJobsGroupInfoStruct = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ResetWmsJobsGroupInfoStruct = 1000
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function ResetWmJobGroupExecRecStruct(ByRef inStrctToReset As clsDataType.SapWmJobGroupExecRec) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ResetWmJobGroupExecRecStruct = 1

            inStrctToReset.NrWmsJobs = 0
            inStrctToReset.QtaTotaleDaPrelevare = 0
            inStrctToReset.QtaTotaleDaPrelevareRimanente = 0
            inStrctToReset.UdmQtaTotaleDaPrelevare = ""
            inStrctToReset.QtaPrelevataInUdMBase = 0
            inStrctToReset.UdmQtaPrelevataInUdMBase = ""
            inStrctToReset.QtaPrelevataInUdMConsegna = 0
            inStrctToReset.UdmQtaPrelevataInUdMConsegna = ""
            inStrctToReset.NumeroOrdineVendita = ""
            inStrctToReset.NumeroPosizioneOrdineVendita = ""
            inStrctToReset.QuantitaConfermataOperatore = 0

            ResetWmJobGroupExecRecStruct = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ResetWmJobGroupExecRecStruct = 1000
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ResetWmJobsGroupExecTabStruct(ByRef inStrctToReset As clsDataType.SapWmJobsGroupExecTab) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ResetWmJobsGroupExecTabStruct = 1

            inStrctToReset.ExecGroupFound = False
            inStrctToReset.QtaGroupTotaleDaPrelevare = 0
            ReDim inStrctToReset.JobsGroupExecTab(0)

            ResetWmJobsGroupExecTabStruct = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ResetWmJobsGroupExecTabStruct = 1000
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ResetWmsJobStruct(ByRef inStrctToReset As clsDataType.SapWmWmsJob) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ResetWmsJobStruct = 1

            inStrctToReset.NrWmsJobs = 0
            inStrctToReset.DataCreazione = Date.MinValue
            inStrctToReset.OraCreazione = Date.MinValue
            inStrctToReset.PickDbTabName = ""
            inStrctToReset.PickDbNumero = ""
            inStrctToReset.PickDbPosizione = 0
            inStrctToReset.NumeroTrasporto = ""
            inStrctToReset.ConsegnaNumero = ""
            inStrctToReset.ConsegnaPosizione = 0
            inStrctToReset.StopSequence = ""
            inStrctToReset.DropSequence = ""
            inStrctToReset.CodiceGruppoMissioni = ""
            inStrctToReset.CodiceRaggruppoEsecuzione = ""
            inStrctToReset.Sequence = 0
            inStrctToReset.CurrentStep = ""
            inStrctToReset.NumeroStepTotali = 0
            inStrctToReset.IdWmsJobStatus = 0
            inStrctToReset.IdWmsJobStatusDescription = ""
            inStrctToReset.IdWmsJobType = ""
            inStrctToReset.IdWmsJobTypeDescription = ""
            inStrctToReset.NumeroOrdineVendita = ""
            inStrctToReset.NumeroPosizioneOrdineVendita = ""
            inStrctToReset.TipoDocumento = ""

            inStrctToReset.CodiceFornitore = ""
            inStrctToReset.CodiceClienteAG = ""
            inStrctToReset.DescrizioneClienteAG = ""
            inStrctToReset.CodiceClienteWE = ""
            inStrctToReset.DescrizioneClienteWE = ""

            inStrctToReset.Priorita = 0
            inStrctToReset.Urgente = False
            inStrctToReset.CondizioneDiReso = False
            inStrctToReset.FlagRilevanteWM = ""
            inStrctToReset.FlagPartitaTassativa = ""
            inStrctToReset.FlagPalletInteri = False
            inStrctToReset.FlagScatoleIntere = False
            inStrctToReset.IdCarrellistaProposto = ""
            inStrctToReset.IdCarrellistaEsecuzione = ""
            inStrctToReset.IdCarrellistaEsecuzioneFullPallet = ""
            inStrctToReset.IdCarrellistaEsecuzioneSfusi = ""

            RetCode += clsSapUtility.ResetGiacenzaStruct(inStrctToReset.MaterialeGiacenzaOrigine)
            RetCode += clsSapUtility.ResetUbicazioneStruct(inStrctToReset.UbicazioneOrigine)
            RetCode += clsSapUtility.ResetUbicazioneStruct(inStrctToReset.UbicazionePropostaOrigine)

            RetCode += clsSapUtility.ResetGiacenzaStruct(inStrctToReset.MaterialeGiacenzaDestinazione)
            RetCode += clsSapUtility.ResetUbicazioneStruct(inStrctToReset.UbicazioneDestinazione)
            RetCode += clsSapUtility.ResetUbicazioneStruct(inStrctToReset.UbicazionePropostaDestinazione)
            RetCode += clsSapUtility.ResetUbicazioneStruct(inStrctToReset.UbicazioneStaging)
            RetCode += clsSapUtility.ResetUbicazioneStruct(inStrctToReset.UbicazioneDoor)

            inStrctToReset.InfoPrelievo = ""
            inStrctToReset.DistintaDiCarico = ""
            inStrctToReset.Memo = ""

            inStrctToReset.DocumentoMaterialeAnno = ""
            inStrctToReset.DocumentoMaterialeNumero = ""
            inStrctToReset.DocumentoMaterialePosizione = ""
            inStrctToReset.NumeroOrdineDiProduzione = ""


            inStrctToReset.TipoDirezioneMissioneKZEAR = ""
            inStrctToReset.DataStart = ""
            inStrctToReset.OraStart = ""
            inStrctToReset.DataFine = ""
            inStrctToReset.OraFine = ""

            inStrctToReset.TruckDayNr = ""
            inStrctToReset.TrasfNumPallet = 0

            inStrctToReset.ZWMS_ERROR_CODE = ""
            inStrctToReset.ZWMS_ROW_STA_DES = ""


            ResetWmsJobStruct = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ResetWmsJobStruct = 1000
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ResetUbicazioneStruct(ByRef inStrctToReset As clsDataType.SapWmUbicazione) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            inStrctToReset.AbilitaUnitaMagazzino = False
            inStrctToReset.Divisione = ""
            inStrctToReset.NumeroMagazzino = ""
            inStrctToReset.TipoMagazzino = ""
            inStrctToReset.Ubicazione = ""
            inStrctToReset.UnitaMagazzino = ""
            inStrctToReset.TipoUnitaMagazzino = ""
            inStrctToReset.NumeroQuantWmSap = 0
            inStrctToReset.NumeroUdcInUbicazione = 0
            inStrctToReset.CapacitaUdcUbicazione = 0
            inStrctToReset.FlagLocationDoor = False
            inStrctToReset.FlagLocationStagingDoor = False
            inStrctToReset.FlagLocationWrapping = False
            inStrctToReset.FlagLocationEquipment = False
            inStrctToReset.FlagLocationOperator = False
            inStrctToReset.FlagLocation_P_D = False

            inStrctToReset.FlagFinalWarehouseLocation = False
            inStrctToReset.FlagLocationWithDifferentMaterialCode = False
            inStrctToReset.FlagLocationWithDifferentBatch = False
            inStrctToReset.FlagLocationFull = False
            inStrctToReset.FlagLocationAllowMixedMaterialCode = False
            inStrctToReset.FlagLocationAllowMixedBatch = False

            inStrctToReset.FlagCheckLocationInfo.FlagCHECK_LOC_OCCUPATION = False
            inStrctToReset.FlagCheckLocationInfo.FlagCHECK_MIX_LOCATION = False
            inStrctToReset.FlagCheckLocationInfo.FlagCHECK_MIX_MATERIAL_CODE = ""
            inStrctToReset.FlagCheckLocationInfo.FlagCHECK_MIX_CHARG = ""

            inStrctToReset.FlagCheckLocationInfo.Quantity = 0
            inStrctToReset.FlagCheckLocationInfo.UdMQuantity = ""


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function ResetDocumentoMaterialePosStruct(ByRef inStrctToReset As clsDataType.SapWmDocumentoMaterialePos) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            inStrctToReset.AnnoEsercizio = ""
            inStrctToReset.NumeroDocumento = ""
            inStrctToReset.PosizioneDocumento = ""

            inStrctToReset.CodiceCommessa = ""
            inStrctToReset.CodiceFornitore = ""
            inStrctToReset.CodiceIncoterms = ""
            inStrctToReset.CodiceMagazzinoLogico = ""
            inStrctToReset.Divisione = ""
            clsSapUtility.ResetGiacenzaStruct(inStrctToReset.MaterialeInfo)

            inStrctToReset.NumeroFabbisognoTrasporto = 0
            inStrctToReset.PosizioneFabbisognoTrasporto = 0
            inStrctToReset.OrdineAcquistoNum = ""
            inStrctToReset.OrdineAcquistoPos = ""
            inStrctToReset.TipoMovimento = ""

            inStrctToReset.PosizioneGiaElaborata = False

            inStrctToReset.QtaTotaleUdMBase = 0

            inStrctToReset.QtaGiaPrelevataUdMBase = 0
            inStrctToReset.QtaDaPrelevareUdMBase = 0
            inStrctToReset.UnitaDiMisuraBase = 0
            inStrctToReset.QtaTotaleUdMCons = 0
            inStrctToReset.QtaGiaPrelevataUdMCons = 0
            inStrctToReset.QtaDaPrelevareUdMCons = 0
            inStrctToReset.UnitaDiMisuraVendita = ""
            inStrctToReset.PrelievoTerminato = False


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ResetSapFunctionError(ByRef inStrctToReset As clsBusinessLogic.SapFunctionError) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************
            ResetSapFunctionError = 1 'INIT AT ERROR

            inStrctToReset.ERROR_CODE = ""
            inStrctToReset.ERROR_DESCRIPTION = ""
            inStrctToReset.ERROR_SUBRC = 0

            ResetSapFunctionError = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function FormattaStringaUnitaMagazzinoPerSap(ByVal inUnitaMagazzino As String) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        Dim WorkString As String
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            WorkString = inUnitaMagazzino
            If (Len(WorkString) > 0) And (Len(WorkString) <> 20) Then
                WorkString = WorkString.PadLeft(20, "0")
            End If

            FormattaStringaUnitaMagazzinoPerSap = WorkString


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            FormattaStringaUnitaMagazzinoPerSap = inUnitaMagazzino
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Public Shared Function MascheraStringaUnitaMagazzino(ByVal inUnitaMagazzino As String) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            inUnitaMagazzino = UCase(inUnitaMagazzino)

            MascheraStringaUnitaMagazzino = inUnitaMagazzino 'init

            inUnitaMagazzino = inUnitaMagazzino.Replace("M", "80")

            MascheraStringaUnitaMagazzino = inUnitaMagazzino.Replace("C", "00")


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function SeparaStringaDocumentoMateriale(ByVal inDocumentoMaterialeTotale As String, ByRef outAnnoDocumento As String, ByRef outNumeroDocumentoMateriale As String, ByRef outPosizioneDocumentoMateriale As String) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            SeparaStringaDocumentoMateriale = 1 'init at error


            If (Len(inDocumentoMaterialeTotale) = 14) Then
                outAnnoDocumento = Left(inDocumentoMaterialeTotale, 4)
                outNumeroDocumentoMateriale = Right(inDocumentoMaterialeTotale, 10)
            ElseIf (Len(inDocumentoMaterialeTotale) = 18) Then
                outAnnoDocumento = Left(inDocumentoMaterialeTotale, 4)
                outNumeroDocumentoMateriale = Mid(inDocumentoMaterialeTotale, 4, 10)
                outPosizioneDocumentoMateriale = Right(inDocumentoMaterialeTotale, 4)
            Else
                SeparaStringaDocumentoMateriale = 100 'condizione di errore
                Exit Function
            End If

            SeparaStringaDocumentoMateriale = RetCode 'se = 0 tutto ok


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function FormattaStringaUnitaMagazzino(ByVal inUnitaMagazzino As String) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        Dim WorkString As String
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            FormattaStringaUnitaMagazzino = inUnitaMagazzino 'init
            WorkString = inUnitaMagazzino

            If (Len(WorkString) = 8) Then
                WorkString = Right(WorkString, 10)
            ElseIf (Len(WorkString) > 10) Then
                WorkString = Right(WorkString, 10)
            End If

            FormattaStringaUnitaMagazzino = WorkString


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function FormattaStringaCodiceMateriale(ByVal inCodiceMateriale As String) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        Dim WorkString As String
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            FormattaStringaCodiceMateriale = inCodiceMateriale 'init
            WorkString = inCodiceMateriale

            If (IsNumeric(inCodiceMateriale) = True) Then
                'SE IL CODICE E' SOLO NUMERICO ELIMINO GLI "0" PRIMA DEL CODICE
                WorkString = Trim(Str(Val(WorkString)))
            End If

            FormattaStringaCodiceMateriale = WorkString


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function FormattaStringaNumeroOrdineProduzione(ByVal inNumeroOrdineProduzione As String) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        Dim WorkString As String
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            FormattaStringaNumeroOrdineProduzione = inNumeroOrdineProduzione 'init
            WorkString = inNumeroOrdineProduzione

            If (IsNumeric(inNumeroOrdineProduzione) = True) Then
                'SE IL CODICE E' SOLO NUMERICO ELIMINO GLI "0" PRIMA DEL CODICE
                WorkString = Trim(Str(Val(WorkString)))
            End If

            FormattaStringaNumeroOrdineProduzione = WorkString


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ResetGiacenzaStruct(ByRef inStrctToReset As clsDataType.SapWmGiacenza) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ResetGiacenzaStruct = 10

            inStrctToReset.CodiceMateriale = ""
            inStrctToReset.DescrizioneMateriale = ""
            inStrctToReset.Partita = ""
            inStrctToReset.SKU = ""
            inStrctToReset.CodiceMaterialeLegacy = ""
            inStrctToReset.CdStockSpeciale = ""
            inStrctToReset.NumeroStockSpeciale = ""
            inStrctToReset.TipoStock = ""
            inStrctToReset.FormatoCodice = ""
            inStrctToReset.FormatoDescrizione = ""
            inStrctToReset.QtaTotaleLquaDaImmagazzinare = 0
            inStrctToReset.QtaTotaleLquaDaImmaUdMAcq = 0
            inStrctToReset.QtaTotaleLquaDaPrelevare = 0
            inStrctToReset.QtaTotaleLquaDaPrelUdMAcq = 0
            inStrctToReset.QtaTotaleLquaDisponibile = 0
            inStrctToReset.QtaTotaleLquaDispoUdMAcq = 0
            inStrctToReset.QtaTotaleInStockInUdmPZ = 0
            inStrctToReset.QtaTotaleInStockSfusi = 0
            inStrctToReset.QtaTotaleDispoInUdmPZ = 0
            inStrctToReset.QtaTotaleDispoSfusi = 0


            inStrctToReset.QtaJobRichiestaInUdmOriginale = 0
            inStrctToReset.QtaJobRichiestaInUdmBase = 0
            inStrctToReset.QtaJobRichiestaInUdmConsegna = 0
            inStrctToReset.QtaJobRichiestaInUdmPZ = 0
            inStrctToReset.QtaJobRichiestaInUdmSC = 0
            inStrctToReset.QtaJobRichiestaInUdmPL = 0
            inStrctToReset.QtaJobRichiestaFullPallet = 0
            inStrctToReset.QtaJobRichiestaPartialPallet = 0
            inStrctToReset.QtaJobRichiestaSfusiInPZ = 0
            inStrctToReset.QtaPrelevataInUdMBase = 0
            inStrctToReset.UdmQtaPrelevataInUdMBase = ""
            inStrctToReset.QtaPrelevataInUdMConsegna = 0
            inStrctToReset.UdmQtaPrelevataInUdMConsegna = ""
            inStrctToReset.QtaPrelevataFullPallet = 0
            inStrctToReset.QtaPrelevataPartialPallet = 0
            inStrctToReset.QtaPrelevataSfusi = 0
            inStrctToReset.QtaPrelevataInUdMPezzo = 0
            inStrctToReset.UdmQtaPrelevataInUdMPezzo = ""

            inStrctToReset.QuantitaConfermataOperatore = 0
            inStrctToReset.QuantitaConfermataSfusiOperatore = 0
            inStrctToReset.QuantitaConfermataRettificaPositiva = 0
            inStrctToReset.QuantitaConfermataRettificaNegativa = 0
            inStrctToReset.QtaTotaleLquaInStock = 0

            inStrctToReset.QtaTotaleLocationUdBase = 0
            inStrctToReset.QtaTotaleLocationUdMAcq = 0
            inStrctToReset.QtaTotaleLocationUdMSC = 0
            inStrctToReset.QtaTotaleLocationFullPallet = 0
            inStrctToReset.QtaTotaleLocationPartialPallet = 0
            inStrctToReset.QtaTotaleLocationSfusi = 0
            inStrctToReset.NumeroUDCLocation = 0

            inStrctToReset.UdmQtaJobRichiesta = ""
            inStrctToReset.UnitaDiMisuraAcquisizione = ""
            inStrctToReset.UnitaDiMisuraBase = ""
            inStrctToReset.UnitaDiMisuraPezzo = ""
            inStrctToReset.UnitaDiMisuraScatole = ""
            inStrctToReset.UnitaDiMisuraPallet = ""

            inStrctToReset.NumeroFabbisognoDiTrasporto = 0
            inStrctToReset.PickSUCompleto = False

            inStrctToReset.NumeroDocumentoVendita = ""
            inStrctToReset.PosizioneDocumentoVendita = ""
            inStrctToReset.QtaPosizioneDocumentoVenditaUdMConsegna = 0
            inStrctToReset.UnitaDiMisuraQtaPosizioneDocumentoVendita = ""
            inStrctToReset.NumeroConsegna = ""
            inStrctToReset.PosizioneConsegna = ""

            clsSapUtility.ResetUbicazioneStruct(inStrctToReset.UbicazioneInfo)

            ResetSapVarianteImballoStruct(inStrctToReset.VarianteImballo)
            ResetStrateInputDestInfo(inStrctToReset.OdaInputDestInfo)

            If (Not inStrctToReset.MultipleUnitaMagazzino Is Nothing) Then
                ReDim inStrctToReset.MultipleUnitaMagazzino(0)
                inStrctToReset.MultipleUnitaMagazzino(0) = ""
            End If
            ResetGiacenzaStruct = RetCode

            inStrctToReset.NrWmsJobs = 0
            inStrctToReset.CodiceGruppoMissioni = ""
            inStrctToReset.TruckDayNr = ""
            inStrctToReset.TrasfNumPallet = 0

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ResetGiacenzaStruct = 1000
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    'Public Shared Function ResetVarianteImballoStruct(ByRef inStrctToReset As clsDataType.SapVarianteImballo) As Long
    '    '**************************************
    '    'HERE PUT DECLARATION OF LOCAL VARIABLE
    '    Dim RetCode As Long = 0

    '    '**************************************
    '    Try 'HERE PUT NORMAL EXECUTION CODE
    '        '**************************************

    '        ResetVarianteImballoStruct = 10

    '        inStrctToReset.CodiceMateriale = ""
    '        inStrctToReset.VarianteImballo = ""
    '        inStrctToReset.PezziPerScatola = 0
    '        inStrctToReset.ScatolePerPallet = 0
    '        inStrctToReset.M2PerPallet = 0
    '        inStrctToReset.CodiceEAN11_Scatola = ""
    '        inStrctToReset.CodiceEAN11_Pallet = ""
    '        inStrctToReset.CodiceImballo = ""
    '        inStrctToReset.PalletLarghezza = 0
    '        inStrctToReset.PalletProfondita = 0
    '        inStrctToReset.PalletAltezza = 0
    '        inStrctToReset.PalletAltezzaSingoloPiano = 0
    '        inStrctToReset.PalletAltezzaPianale = 0
    '        inStrctToReset.PalletNumeroColliPerPiano = 0
    '        inStrctToReset.Testo = ""
    '        inStrctToReset.CodiceMaterialeAlternativo = ""

    '        ResetVarianteImballoStruct = RetCode

    '        '**************************************
    '    Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
    '        ResetVarianteImballoStruct = 1000
    '        Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
    '        'LOG ERROR CONDITION
    '        clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
    '        '**************************************
    '    Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

    '    End Try
    'End Function
    Public Shared Function ResetStrateInputDestInfo(ByRef inStrctToReset As clsDataType.SapStrateInputDestInfo) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ResetStrateInputDestInfo = 1 'init at error

            inStrctToReset.CodiceCommessa = ""
            inStrctToReset.DescrUbicDestinazione = ""
            inStrctToReset.DescrizioneCausale = ""
            inStrctToReset.NumDocumentoAcquisto = ""
            inStrctToReset.PosizioneDocumentoAcquisto = ""
            inStrctToReset.NumeroOrdineProduzione = ""
            inStrctToReset.QtaRichiesta = 0
            inStrctToReset.UnitaDiMisuraBase = ""
            inStrctToReset.FoundAreaProd = False
            inStrctToReset.FoundMagEmpty = False
            inStrctToReset.FoundMagGeneric = False
            inStrctToReset.FoundMagProd = False
            inStrctToReset.FoundMancanteOdp = False

            ResetStrateInputDestInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ResetStrateInputDestInfo = 1000
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ResetOrdineProduzioneStruct(ByRef inStrctToReset As clsDataType.SapOrdineProduzione) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ResetOrdineProduzioneStruct = 1 'init at error

            inStrctToReset.NumeroOrdineProduzione = ""
            inStrctToReset.TipoOrdineProduzione = ""
            inStrctToReset.CodiceMateriale = ""
            inStrctToReset.DescrizioneMateriale = ""
            inStrctToReset.Partita = ""
            inStrctToReset.QuantitaConsegnata = 0
            inStrctToReset.QuantitaDaProdurre = 0
            inStrctToReset.QuantitaScarto = 0
            inStrctToReset.UnitaDiMisura = ""
            inStrctToReset.DataAcquisizione = Date.MinValue

            ResetOrdineProduzioneStruct = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ResetOrdineProduzioneStruct = 10000
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function ResetOrdineVenditaStruct(ByRef inStrctToReset As clsDataType.SapOrdineVendita) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ResetOrdineVenditaStruct = 1 'init at error

            inStrctToReset.NumeroOrdineVendita = ""
            inStrctToReset.PosizioneOrdineVendita = ""
            inStrctToReset.TipoOrdineVendita = ""
            inStrctToReset.CodiceMateriale = ""
            inStrctToReset.DescrizioneMateriale = ""
            inStrctToReset.Partita = ""
            inStrctToReset.QuantitaConfermataUdMBase = 0
            inStrctToReset.QuantitaConfermataUdMVendita = 0
            inStrctToReset.QuantitaTotaleOrdineUdMVendita = 0
            inStrctToReset.UnitaDiMisuraBase = ""
            inStrctToReset.UnitaDiMisuraVendita = ""

            ResetOrdineVenditaStruct = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ResetOrdineVenditaStruct = 10000
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CheckUbicazioneString(ByRef inUbicazione As String, Optional ByVal inPadLen As Boolean = False) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim LenghtString As Long = 0
        Dim StartIndex As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CheckUbicazioneString = 1 'inti at error

            If (Len(inUbicazione) > 10) Then
                LenghtString = Len(inUbicazione)
                StartIndex = LenghtString - 10
                inUbicazione = inUbicazione.Substring(StartIndex, 10)
            End If

            If (inPadLen = True) Then
                inUbicazione = inUbicazione.PadLeft(10, "0")
            End If

            CheckUbicazioneString = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckUbicazioneString = 10000
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CopyDocMatStruct(ByRef inStructSource As clsDataType.SapWmDocumentoMaterialeFull, ByRef inStructDestination As clsDataType.SapWmDocumentoMaterialeFull) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            inStructDestination.AnnoEsercizio = inStructSource.AnnoEsercizio
            inStructDestination.NumeroDocumento = inStructSource.NumeroDocumento
            inStructDestination.PosizioneDocumento = inStructSource.PosizioneDocumento

            inStructDestination.PosizioneInfo = inStructSource.PosizioneInfo
            inStructDestination.PosizioniInfo = inStructSource.PosizioniInfo

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function TrasfDocMatPosSapStruct(ByVal inDocMatPosSapStruct As StructGenericTableMSEG, ByRef outDocMatPos As clsDataType.SapWmDocumentoMaterialePos) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            TrasfDocMatPosSapStruct = 1 '>>> INIT AT ERROR

            outDocMatPos.AnnoEsercizio = inDocMatPosSapStruct.MSEG_Rec.Mjahr
            outDocMatPos.NumeroDocumento = inDocMatPosSapStruct.MSEG_Rec.Mblnr
            outDocMatPos.PosizioneDocumento = inDocMatPosSapStruct.MSEG_Rec.Zeile
            outDocMatPos.CodiceFornitore = inDocMatPosSapStruct.MSEG_Rec.Lifnr
            'outDocMatPos.CodiceIncoterms = inDocMatPosSapStruct.i
            outDocMatPos.CodiceMagazzinoLogico = inDocMatPosSapStruct.MSEG_Rec.Lgort
            outDocMatPos.Divisione = inDocMatPosSapStruct.MSEG_Rec.Werks
            outDocMatPos.OrdineAcquistoNum = inDocMatPosSapStruct.MSEG_Rec.Ebeln
            outDocMatPos.OrdineAcquistoPos = inDocMatPosSapStruct.MSEG_Rec.Ebelp
            outDocMatPos.TipoMovimento = inDocMatPosSapStruct.MSEG_Rec.Bwart
            outDocMatPos.CodiceCommessa = ""
            outDocMatPos.NumeroFabbisognoTrasporto = inDocMatPosSapStruct.MSEG_Rec.Tbnum
            outDocMatPos.PosizioneFabbisognoTrasporto = inDocMatPosSapStruct.MSEG_Rec.Tbpos

            '>>> MEMORIZZO DATI DEL MATERIALE
            outDocMatPos.MaterialeInfo.CodiceMateriale = inDocMatPosSapStruct.MSEG_Rec.Matnr
            outDocMatPos.MaterialeInfo.DescrizioneMateriale = inDocMatPosSapStruct.MSEG_Rec.Sgtxt
            outDocMatPos.MaterialeInfo.Partita = inDocMatPosSapStruct.MSEG_Rec.Charg
            outDocMatPos.MaterialeInfo.QuantitaInUdMBase = inDocMatPosSapStruct.MSEG_Rec.Menge
            outDocMatPos.MaterialeInfo.UnitaDiMisuraBase = inDocMatPosSapStruct.MSEG_Rec.Meins
            outDocMatPos.MaterialeInfo.QuantitaInUdMAcquisizione = inDocMatPosSapStruct.MSEG_Rec.Erfmg
            outDocMatPos.MaterialeInfo.UnitaDiMisuraAcquisizione = inDocMatPosSapStruct.MSEG_Rec.Erfme
            outDocMatPos.MaterialeInfo.CdStockSpeciale = inDocMatPosSapStruct.MSEG_Rec.Sobkz
            outDocMatPos.MaterialeInfo.NumeroStockSpeciale = ""
            outDocMatPos.MaterialeInfo.TipoStock = inDocMatPosSapStruct.MSEG_Rec.Bestq
            outDocMatPos.MaterialeInfo.MagazzinoLogico = inDocMatPosSapStruct.MSEG_Rec.Lgort

            '>>> MEMORIZZO DATI UBICAZIONE
            outDocMatPos.MaterialeInfo.UbicazioneInfo.Divisione = inDocMatPosSapStruct.MSEG_Rec.Werks
            outDocMatPos.MaterialeInfo.UbicazioneInfo.NumeroMagazzino = inDocMatPosSapStruct.MSEG_Rec.Lgnum
            outDocMatPos.MaterialeInfo.UbicazioneInfo.TipoMagazzino = inDocMatPosSapStruct.MSEG_Rec.Lgtyp
            outDocMatPos.MaterialeInfo.UbicazioneInfo.Ubicazione = inDocMatPosSapStruct.MSEG_Rec.Lgpla

            TrasfDocMatPosSapStruct = RetCode '>>> SE 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            TrasfDocMatPosSapStruct = 1000 '>>> CATCH ERROR!
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function TrasfDocMatZmsegInfoPosToSapStruct(ByVal inDocMatPosSapStruct As WS_MB_GET_DOCMAT.ZmsegInfo, ByRef outDocMatPos As clsDataType.SapWmDocumentoMaterialePos) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            TrasfDocMatZmsegInfoPosToSapStruct = 1 '>>> INIT AT ERROR

            outDocMatPos.AnnoEsercizio = inDocMatPosSapStruct.Mseg.Mjahr
            outDocMatPos.NumeroDocumento = inDocMatPosSapStruct.Mseg.Mblnr
            outDocMatPos.PosizioneDocumento = inDocMatPosSapStruct.Mseg.Zeile
            outDocMatPos.CodiceFornitore = inDocMatPosSapStruct.Mseg.Lifnr
            'outDocMatPos.CodiceIncoterms = inDocMatPosSapStruct.i
            outDocMatPos.CodiceMagazzinoLogico = inDocMatPosSapStruct.Mseg.Lgort
            outDocMatPos.Divisione = inDocMatPosSapStruct.Mseg.Werks
            outDocMatPos.OrdineAcquistoNum = inDocMatPosSapStruct.Mseg.Ebeln
            outDocMatPos.OrdineAcquistoPos = inDocMatPosSapStruct.Mseg.Ebelp
            outDocMatPos.TipoMovimento = inDocMatPosSapStruct.Mseg.Bwart
            outDocMatPos.CodiceCommessa = ""
            outDocMatPos.NumeroFabbisognoTrasporto = inDocMatPosSapStruct.Mseg.Tbnum
            outDocMatPos.PosizioneFabbisognoTrasporto = inDocMatPosSapStruct.Mseg.Tbpos

            '>>> MEMORIZZO DATI DEL MATERIALE
            outDocMatPos.MaterialeInfo.CodiceMateriale = inDocMatPosSapStruct.Mseg.Matnr
            outDocMatPos.MaterialeInfo.DescrizioneMateriale = inDocMatPosSapStruct.Maktg
            outDocMatPos.MaterialeInfo.Partita = inDocMatPosSapStruct.Mseg.Charg
            outDocMatPos.MaterialeInfo.QuantitaInUdMBase = inDocMatPosSapStruct.Mseg.Menge
            outDocMatPos.MaterialeInfo.UnitaDiMisuraBase = inDocMatPosSapStruct.Mseg.Meins
            outDocMatPos.MaterialeInfo.QuantitaInUdMAcquisizione = inDocMatPosSapStruct.ConfirmQtyInfo.QtaTotaleCons
            outDocMatPos.MaterialeInfo.UnitaDiMisuraAcquisizione = inDocMatPosSapStruct.ConfirmQtyInfo.Vrkme

            outDocMatPos.MaterialeInfo.QtaPrelevataInUdMConsegna = inDocMatPosSapStruct.ConfirmQtyInfo.QtaGiaConfermataCons
            outDocMatPos.MaterialeInfo.QtaTotaleLquaDaPrelUdMAcq = inDocMatPosSapStruct.ConfirmQtyInfo.QtaAncoraDaConfermareCons
            outDocMatPos.MaterialeInfo.QtaTotaleLquaDispoUdMAcq = inDocMatPosSapStruct.ConfirmQtyInfo.QtaTotaleCons
            outDocMatPos.MaterialeInfo.QtaTotaleLquaInStockUdMAcq = inDocMatPosSapStruct.ConfirmQtyInfo.QtaTotaleCons

            outDocMatPos.MaterialeInfo.QtaPrelevataInUdMBase = inDocMatPosSapStruct.ConfirmQtyInfo.QtaGiaConfermataBase
            outDocMatPos.MaterialeInfo.QtaJobRichiestaInUdmOriginale = inDocMatPosSapStruct.ConfirmQtyInfo.QtaAncoraDaConfermareBase
            outDocMatPos.MaterialeInfo.QtaTotaleLquaDisponibile = inDocMatPosSapStruct.ConfirmQtyInfo.QtaTotaleBase
            outDocMatPos.MaterialeInfo.QtaTotaleLquaInStock = inDocMatPosSapStruct.ConfirmQtyInfo.QtaTotaleBase

            '>>> IMPOSTO RIFERIMENTO ALL'ODV (NEL CASO DEI TRASFERIMENTI)
            outDocMatPos.MaterialeInfo.NumeroDocumentoVendita = inDocMatPosSapStruct.Zpickmm.Vbeln
            outDocMatPos.MaterialeInfo.PosizioneDocumentoVendita = inDocMatPosSapStruct.Zpickmm.Posnr
            outDocMatPos.MaterialeInfo.QtaPosizioneDocumentoVenditaUdMConsegna = inDocMatPosSapStruct.Zpickmm.Zqtapk
            outDocMatPos.MaterialeInfo.UnitaDiMisuraQtaPosizioneDocumentoVendita = inDocMatPosSapStruct.Zpickmm.Meins

            '>>> IMPOSTO RIFERIMENTO ALLA CONSEGNA (NEL CASO DI BEM DA CONSEGNA)
            outDocMatPos.MaterialeInfo.NumeroConsegna = inDocMatPosSapStruct.Zpickmm.Vbelv
            outDocMatPos.MaterialeInfo.PosizioneConsegna = inDocMatPosSapStruct.Zpickmm.Posnv

            'RECUPERO INFO DEI PRELIEVI GIA' FATTI
            outDocMatPos.QtaGiaPrelevataUdMCons = inDocMatPosSapStruct.ConfirmQtyInfo.QtaGiaConfermataCons
            outDocMatPos.QtaDaPrelevareUdMCons = inDocMatPosSapStruct.ConfirmQtyInfo.QtaAncoraDaConfermareCons
            outDocMatPos.QtaTotaleUdMCons = inDocMatPosSapStruct.ConfirmQtyInfo.QtaTotaleCons
            outDocMatPos.UnitaDiMisuraVendita = inDocMatPosSapStruct.ConfirmQtyInfo.Vrkme
            outDocMatPos.QtaGiaPrelevataUdMBase = inDocMatPosSapStruct.ConfirmQtyInfo.QtaGiaConfermataBase
            outDocMatPos.QtaDaPrelevareUdMBase = inDocMatPosSapStruct.ConfirmQtyInfo.QtaAncoraDaConfermareBase
            outDocMatPos.QtaTotaleUdMBase = inDocMatPosSapStruct.ConfirmQtyInfo.QtaTotaleBase
            outDocMatPos.UnitaDiMisuraBase = inDocMatPosSapStruct.ConfirmQtyInfo.Meins

            outDocMatPos.MaterialeInfo.CdStockSpeciale = inDocMatPosSapStruct.Mseg.Sobkz
            If (inDocMatPosSapStruct.Mseg.Sobkz <> "") And (clsUtility.IsStringValid(inDocMatPosSapStruct.Mseg.Kdauf, True) = True) And (clsUtility.IsStringValid(inDocMatPosSapStruct.Mseg.Kdpos, True) = True) Then
                outDocMatPos.MaterialeInfo.NumeroStockSpeciale = inDocMatPosSapStruct.Mseg.Kdauf & inDocMatPosSapStruct.Mseg.Kdpos
            Else
                outDocMatPos.MaterialeInfo.NumeroStockSpeciale = ""
            End If
            outDocMatPos.MaterialeInfo.TipoStock = inDocMatPosSapStruct.Mseg.Bestq
            outDocMatPos.MaterialeInfo.MagazzinoLogico = inDocMatPosSapStruct.Mseg.Lgort

            '>>> MEMORIZZO DATI UBICAZIONE
            outDocMatPos.MaterialeInfo.UbicazioneInfo.Divisione = inDocMatPosSapStruct.Mseg.Werks
            outDocMatPos.MaterialeInfo.UbicazioneInfo.NumeroMagazzino = inDocMatPosSapStruct.Mseg.Lgnum
            outDocMatPos.MaterialeInfo.UbicazioneInfo.TipoMagazzino = inDocMatPosSapStruct.Mseg.Lgtyp
            outDocMatPos.MaterialeInfo.UbicazioneInfo.Ubicazione = inDocMatPosSapStruct.Mseg.Lgpla

            'IMPOSTO FLAG PER DETERMINARE SE PRELIEVO DOC.MATERIALE E' TERMINATO
            If (outDocMatPos.QtaGiaPrelevataUdMCons >= outDocMatPos.QtaTotaleUdMCons) Then
                outDocMatPos.PosizioneGiaElaborata = True
                outDocMatPos.PrelievoTerminato = True
            Else
                outDocMatPos.PosizioneGiaElaborata = False
                outDocMatPos.PrelievoTerminato = False
            End If

            If (clsUtility.IsStringValid(inDocMatPosSapStruct.Maktg, True) = True) Then
                'SE NON AVEVO UNA DESCRIZIONE MATERIALE VALIDA LA AGGIORNO
                If (clsUtility.IsStringValid(outDocMatPos.MaterialeInfo.DescrizioneMateriale, True) = False) Then
                    outDocMatPos.MaterialeInfo.DescrizioneMateriale = inDocMatPosSapStruct.Maktg
                End If
            End If

            '>>> RITORNO DATI VARIANTE IMBALLO
            RetCode = clsSapUtility.ResetSapVarianteImballoStruct(outDocMatPos.MaterialeInfo.VarianteImballo)
            RetCode = TrasfVarianteImballoSapStruct(inDocMatPosSapStruct.VarianteImballo, outDocMatPos.MaterialeInfo.VarianteImballo, False)

            TrasfDocMatZmsegInfoPosToSapStruct = RetCode '>>> SE 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            TrasfDocMatZmsegInfoPosToSapStruct = 1000 '>>> CATCH ERROR!
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function TrasfOrdineVenditaSapStruct(ByVal inDocSapStruct As StructGenericTableVBAP, ByRef outOrdineVenditaPos As clsDataType.SapOrdineVendita) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            outOrdineVenditaPos.CodiceMateriale = inDocSapStruct.VBAP_Rec.Matnr
            outOrdineVenditaPos.DescrizioneMateriale = "" '??? ricaricare in qualche modo
            outOrdineVenditaPos.Partita = inDocSapStruct.VBAP_Rec.Charg
            outOrdineVenditaPos.NumeroOrdineVendita = inDocSapStruct.VBAP_Rec.Vbeln
            outOrdineVenditaPos.PosizioneOrdineVendita = inDocSapStruct.VBAP_Rec.Posnr
            outOrdineVenditaPos.TipoOrdineVendita = ""
            outOrdineVenditaPos.QuantitaConfermataUdMBase = inDocSapStruct.VBAP_Rec.Klmeng
            outOrdineVenditaPos.QuantitaConfermataUdMVendita = inDocSapStruct.VBAP_Rec.Kbmeng
            outOrdineVenditaPos.QuantitaTotaleOrdineUdMVendita = inDocSapStruct.VBAP_Rec.Kwmeng
            outOrdineVenditaPos.UnitaDiMisuraBase = inDocSapStruct.VBAP_Rec.Meins
            outOrdineVenditaPos.UnitaDiMisuraVendita = inDocSapStruct.VBAP_Rec.Vrkme


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function TrasfGiacenzaSapStruct(ByVal inSapStruct As StructGenericTableLQUA, ByRef outDatiGiacenza As clsDataType.SapWmGiacenza) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (clsUtility.IsStringValid(inSapStruct.LQUA_Rec.Matnr, True) = True) Then
                outDatiGiacenza.CodiceMateriale = inSapStruct.LQUA_Rec.Matnr
                outDatiGiacenza.Partita = inSapStruct.LQUA_Rec.Charg
                outDatiGiacenza.DescrizioneMateriale = ""
                outDatiGiacenza.QtaTotaleLquaInStock = inSapStruct.LQUA_Rec.Gesme
                outDatiGiacenza.QtaTotaleLquaDisponibile = inSapStruct.LQUA_Rec.Verme
                outDatiGiacenza.QtaTotaleLquaDaImmagazzinare = inSapStruct.LQUA_Rec.Einme
                outDatiGiacenza.QtaTotaleLquaDaPrelevare = inSapStruct.LQUA_Rec.Ausme
                outDatiGiacenza.UnitaDiMisuraBase = inSapStruct.LQUA_Rec.Meins
                outDatiGiacenza.UbicazioneInfo.Divisione = inSapStruct.LQUA_Rec.Werks
                outDatiGiacenza.UbicazioneInfo.NumeroMagazzino = inSapStruct.LQUA_Rec.Lgnum
                outDatiGiacenza.UbicazioneInfo.TipoMagazzino = inSapStruct.LQUA_Rec.Lgtyp
                outDatiGiacenza.UbicazioneInfo.Ubicazione = inSapStruct.LQUA_Rec.Lgpla
                outDatiGiacenza.UbicazioneInfo.UnitaMagazzino = inSapStruct.LQUA_Rec.Lenum
                outDatiGiacenza.CdStockSpeciale = inSapStruct.LQUA_Rec.Sobkz
                outDatiGiacenza.NumeroStockSpeciale = inSapStruct.LQUA_Rec.Sonum
                outDatiGiacenza.TipoStock = inSapStruct.LQUA_Rec.Bestq
                outDatiGiacenza.NumeroFabbisognoDiTrasporto = inSapStruct.LQUA_CHECK_Rec.Tbnum
            ElseIf (clsUtility.IsStringValid(inSapStruct.LQUA_CHECK_Rec.Matnr, True) = True) Then
                outDatiGiacenza.CodiceMateriale = inSapStruct.LQUA_CHECK_Rec.Matnr
                outDatiGiacenza.Partita = inSapStruct.LQUA_CHECK_Rec.Charg
                outDatiGiacenza.DescrizioneMateriale = ""
                outDatiGiacenza.QtaTotaleLquaInStock = inSapStruct.LQUA_CHECK_Rec.Gesme
                outDatiGiacenza.QtaTotaleLquaDisponibile = inSapStruct.LQUA_CHECK_Rec.Verme
                outDatiGiacenza.QtaTotaleLquaDaImmagazzinare = inSapStruct.LQUA_CHECK_Rec.Einme
                outDatiGiacenza.QtaTotaleLquaDaPrelevare = inSapStruct.LQUA_CHECK_Rec.Ausme
                outDatiGiacenza.UnitaDiMisuraBase = inSapStruct.LQUA_CHECK_Rec.Meins
                outDatiGiacenza.UbicazioneInfo.Divisione = inSapStruct.LQUA_CHECK_Rec.Werks
                outDatiGiacenza.UbicazioneInfo.NumeroMagazzino = inSapStruct.LQUA_CHECK_Rec.Lgnum
                outDatiGiacenza.UbicazioneInfo.TipoMagazzino = inSapStruct.LQUA_CHECK_Rec.Lgtyp
                outDatiGiacenza.UbicazioneInfo.Ubicazione = inSapStruct.LQUA_CHECK_Rec.Lgpla
                outDatiGiacenza.UbicazioneInfo.UnitaMagazzino = inSapStruct.LQUA_CHECK_Rec.Lenum
                outDatiGiacenza.CdStockSpeciale = inSapStruct.LQUA_CHECK_Rec.Sobkz
                outDatiGiacenza.NumeroStockSpeciale = inSapStruct.LQUA_CHECK_Rec.Sonum
                outDatiGiacenza.TipoStock = inSapStruct.LQUA_CHECK_Rec.Bestq
                outDatiGiacenza.NumeroFabbisognoDiTrasporto = inSapStruct.LQUA_CHECK_Rec.Tbnum
            End If


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function FromSapWmGiacenzaArrayToDataRow(ByRef inGiacenzeStrucArray() As clsDataType.SapWmGiacenza, ByRef outDataTable As DataTable) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkRow As DataRow
        Dim WorkGiacenzaStruc As clsDataType.SapWmGiacenza
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            FromSapWmGiacenzaArrayToDataRow = 1 'INIT AT ERROR

            RetCode += clsUtility.InitDataTable(outDataTable)

            For Index = 0 To inGiacenzeStrucArray.Length - 1
                WorkGiacenzaStruc = inGiacenzeStrucArray(Index)
                WorkRow = outDataTable.NewRow()
                WorkRow.Item("Werks") = WorkGiacenzaStruc.UbicazioneInfo.Divisione
                WorkRow.Item("Lgnum") = WorkGiacenzaStruc.UbicazioneInfo.NumeroMagazzino
                WorkRow.Item("Lgtyp") = WorkGiacenzaStruc.UbicazioneInfo.TipoMagazzino
                WorkRow.Item("Lgpla") = WorkGiacenzaStruc.UbicazioneInfo.Ubicazione
                WorkRow.Item("Matnr") = WorkGiacenzaStruc.CodiceMateriale
                WorkRow.Item("Charg") = WorkGiacenzaStruc.Partita
                WorkRow.Item("Verme") = WorkGiacenzaStruc.QtaTotaleLquaDisponibile
                WorkRow.Item("Gesme") = WorkGiacenzaStruc.QtaTotaleLquaInStock
                WorkRow.Item("Meins") = WorkGiacenzaStruc.UnitaDiMisuraBase
                WorkRow.Item("Lenum") = FormattaStringaUnitaMagazzino(WorkGiacenzaStruc.UbicazioneInfo.UnitaMagazzino)
                WorkRow.Item("Sobkz") = WorkGiacenzaStruc.CdStockSpeciale
                WorkRow.Item("Sonum") = WorkGiacenzaStruc.NumeroStockSpeciale
                WorkRow.Item("Bestq") = WorkGiacenzaStruc.TipoStock
                WorkRow.Item("Lgort") = WorkGiacenzaStruc.MagazzinoLogico
                WorkRow.Item("LQNUM") = WorkGiacenzaStruc.UbicazioneInfo.NumeroQuantWmSap
                WorkRow.Item("VERME_CONS") = WorkGiacenzaStruc.QtaTotaleLquaDispoUdMAcq
                WorkRow.Item("GESME_CONS") = WorkGiacenzaStruc.QtaTotaleLquaInStockUdMAcq
                WorkRow.Item("VRKME") = WorkGiacenzaStruc.UnitaDiMisuraAcquisizione
                WorkRow.Item("MAKTG") = WorkGiacenzaStruc.DescrizioneMateriale
                outDataTable.Rows.Add(WorkRow) 'aggiungo la riga
            Next

            FromSapWmGiacenzaArrayToDataRow = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            FromSapWmGiacenzaArrayToDataRow = 1000
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetQtyForUserInfoFromDataRow(ByRef inDataRow As DataRow, ByRef outSapWmGiacenza As clsDataType.SapWmGiacenza, ByRef outQtyForUser As String, ByVal inShowMessageBox As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetQtyForUserInfoFromDataRow = 1 'INIT AT ERROR

            If (inDataRow Is Nothing) Then
                RetCode = 10
                GetQtyForUserInfoFromDataRow = RetCode
                Exit Function
            End If


            'RITORNO I CAMPI DELLA QTA CHE INTERESSANO LO USER
            outSapWmGiacenza.QtaTotaleLquaDispoUdMAcq = clsUtility.GetDataRowItem(inDataRow, "Verme_Cons", "")
            outSapWmGiacenza.QtaTotaleLquaInStockUdMAcq = clsUtility.GetDataRowItem(inDataRow, "Gesme_Cons", "")
            outSapWmGiacenza.UnitaDiMisuraAcquisizione = clsUtility.GetDataRowItem(inDataRow, "Vrkme", "")
            outSapWmGiacenza.QtaTotaleDispoInUdmPZ = clsUtility.GetDataRowItem(inDataRow, "Verme_PZ", "")
            outSapWmGiacenza.QtaTotaleInStockInUdmPZ = clsUtility.GetDataRowItem(inDataRow, "Gesme_PZ", "")

            'outQtyForUser = " " & outSapWmGiacenza.UnitaDiMisuraAcquisizione & ":" & Trim(Str(outSapWmGiacenza.QtaTotaleLquaInStockUdMAcq)) & " - PZ:" & Trim(Str(outSapWmGiacenza.QtaTotaleInStockInUdmPZ))
            outQtyForUser = " " & outSapWmGiacenza.UnitaDiMisuraAcquisizione & ":" & Trim(Str(outSapWmGiacenza.QtaTotaleLquaInStockUdMAcq)) & " - " & clsAppTranslation.GetSingleParameterValue(990, "", "PZ:") & Trim(Str(outSapWmGiacenza.QtaTotaleInStockInUdmPZ)) ' & " - " & outSapWmGiacenza.DescrizioneMateriale

            GetQtyForUserInfoFromDataRow = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function FromGiacenzaDataRowToSapWmGiacenza(ByRef inDataRow As DataRow, ByRef outSapWmGiacenza As clsDataType.SapWmGiacenza, ByVal inShowMessageBox As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkString As String
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            FromGiacenzaDataRowToSapWmGiacenza = 1 'INIT AT ERROR

            If (inDataRow Is Nothing) Then
                RetCode = 10
                FromGiacenzaDataRowToSapWmGiacenza = RetCode
                Exit Function
            End If

            outSapWmGiacenza.UbicazioneInfo.Divisione = clsUtility.GetDataRowItem(inDataRow, "Werks", "")
            outSapWmGiacenza.UbicazioneInfo.NumeroMagazzino = clsUtility.GetDataRowItem(inDataRow, "Lgnum", "")
            outSapWmGiacenza.UbicazioneInfo.TipoMagazzino = clsUtility.GetDataRowItem(inDataRow, "Lgtyp", "")
            outSapWmGiacenza.UbicazioneInfo.Ubicazione = clsUtility.GetDataRowItem(inDataRow, "Lgpla", "")

            'FLAG CHE INDICA SE ATTIVA LA GESTIONE DELLE UNITA MAGAZZINO
            WorkString = clsUtility.GetDataRowItem(inDataRow, "GESTIONE_UM_ATTIVA", "")
            If (WorkString = "X") Then
                outSapWmGiacenza.UbicazioneInfo.AbilitaUnitaMagazzino = True
            Else
                outSapWmGiacenza.UbicazioneInfo.AbilitaUnitaMagazzino = False
            End If

            outSapWmGiacenza.CodiceMateriale = clsUtility.GetDataRowItem(inDataRow, "Matnr", "")
            outSapWmGiacenza.Partita = clsUtility.GetDataRowItem(inDataRow, "Charg", "")
            outSapWmGiacenza.QtaTotaleLquaDisponibile = clsUtility.GetDataRowItem(inDataRow, "Verme", "")
            outSapWmGiacenza.QtaTotaleLquaInStock = clsUtility.GetDataRowItem(inDataRow, "Gesme", "")
            outSapWmGiacenza.UnitaDiMisuraBase = clsUtility.GetDataRowItem(inDataRow, "Meins", "")
            outSapWmGiacenza.UbicazioneInfo.UnitaMagazzino = clsUtility.GetDataRowItem(inDataRow, "LENUM", "")
            outSapWmGiacenza.CdStockSpeciale = clsUtility.GetDataRowItem(inDataRow, "Sobkz", "")
            outSapWmGiacenza.NumeroStockSpeciale = clsUtility.GetDataRowItem(inDataRow, "Sonum", "")
            outSapWmGiacenza.TipoStock = clsUtility.GetDataRowItem(inDataRow, "Bestq", "")
            outSapWmGiacenza.MagazzinoLogico = clsUtility.GetDataRowItem(inDataRow, "LGORT", "")

            outSapWmGiacenza.QtaTotaleLquaDispoUdMAcq = clsUtility.GetDataRowItem(inDataRow, "Verme_Cons", "")
            outSapWmGiacenza.QtaTotaleLquaInStockUdMAcq = clsUtility.GetDataRowItem(inDataRow, "Gesme_Cons", "")

            outSapWmGiacenza.QtaTotaleLquaInStocFullPallet = clsUtility.GetDataRowItem(inDataRow, "GESME_PAL", "")
            outSapWmGiacenza.QtaTotaleLquaDispoFullPallet = clsUtility.GetDataRowItem(inDataRow, "VERME_PAL", "")
            outSapWmGiacenza.QtaTotaleLquaInStocPartialPallet = clsUtility.GetDataRowItem(inDataRow, "GESME_PARTIAL", "")
            outSapWmGiacenza.QtaTotaleLquaDispoPartialPallet = clsUtility.GetDataRowItem(inDataRow, "VERME_PARTIAL", "")

            outSapWmGiacenza.QtaTotaleDispoInUdmPZ = clsUtility.GetDataRowItem(inDataRow, "VERME_PZ", "")
            outSapWmGiacenza.QtaTotaleInStockInUdmPZ = clsUtility.GetDataRowItem(inDataRow, "GESME_PZ", "")
            outSapWmGiacenza.QtaTotaleDispoSfusi = clsUtility.GetDataRowItem(inDataRow, "VERME_SF", "")
            outSapWmGiacenza.QtaTotaleInStockSfusi = clsUtility.GetDataRowItem(inDataRow, "GESME_SF", "")
            outSapWmGiacenza.UnitaDiMisuraPezzo = clsUtility.GetDataRowItem(inDataRow, "MEINS_PZ", "")


            outSapWmGiacenza.UnitaDiMisuraAcquisizione = clsUtility.GetDataRowItem(inDataRow, "Vrkme", "")
            outSapWmGiacenza.DescrizioneMateriale = clsUtility.GetDataRowItem(inDataRow, "MAKTG", "")

            outSapWmGiacenza.VarianteImballo.VarianteImballo = clsUtility.GetDataRowItem(inDataRow, "IMBALLO", "")
            outSapWmGiacenza.VarianteImballo.PezziPerScatola = clsUtility.GetDataRowItem(inDataRow, "PZ_X_SC", "")
            outSapWmGiacenza.VarianteImballo.ScatolePerPallet = clsUtility.GetDataRowItem(inDataRow, "SC_X_PAL", "")
            outSapWmGiacenza.VarianteImballo.M2PerPallet = clsUtility.GetDataRowItem(inDataRow, "M2_X_PAL", "")

            outSapWmGiacenza.SKU = clsUtility.GetDataRowItem(inDataRow, "ZWMS_SKU_PALLET", "")
            outSapWmGiacenza.CodiceMaterialeLegacy = clsUtility.GetDataRowItem(inDataRow, "ZZCDLEGACY", "")

            outSapWmGiacenza.GesmeQtyUser = clsUtility.GetDataRowItem(inDataRow, "GESME_QTY_USER", "")
            outSapWmGiacenza.UbiUserQtyTotal = clsUtility.GetDataRowItem(inDataRow, "UBI_USER_QTY_TOTAL", "")

            outSapWmGiacenza.ZGestione_PZ_Attiva = clsUtility.GetDataRowItem(inDataRow, "ZGESTIONE_PZ_ATTIVA", "")


            FromGiacenzaDataRowToSapWmGiacenza = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetDataOraDaSystemTimeDiSap(ByRef outDateAndTimeSap As Date, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkAnno As Integer
        Dim WorkMese As Integer
        Dim WorkGiorno As Integer
        Dim WorkOra As Integer
        Dim WorkMinuti As Integer
        Dim WorkSecondi As Integer

        Dim WorkTimeString As String
        Dim IndexStartOrario As Integer


        Dim IndexStartPM As Integer
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetDataOraDaSystemTimeDiSap = 1

            WorkAnno = Mid(SapSystemInfo.SystInfo_Rec.Datum, 1, 4)
            WorkMese = Mid(SapSystemInfo.SystInfo_Rec.Datum, 5, 2)
            WorkGiorno = Mid(SapSystemInfo.SystInfo_Rec.Datum, 7, 2)

            WorkTimeString = SapSystemInfo.SystInfo_Rec.Uzeit.ToString
            IndexStartOrario = WorkTimeString.IndexOf(" ")

            WorkOra = Now.Hour
            WorkMinuti = Now.Minute
            WorkSecondi = Now.Second

            'Caso in cui non e' presente data
            If (IndexStartOrario = -1) Then
                IndexStartOrario = 1
            End If

            WorkOra = Mid(SapSystemInfo.SystInfo_Rec.Uzeit, IndexStartOrario, 2)
            WorkMinuti = Mid(SapSystemInfo.SystInfo_Rec.Uzeit, IndexStartOrario + 2, 2)
            WorkSecondi = Mid(SapSystemInfo.SystInfo_Rec.Uzeit, IndexStartOrario + 4, 2)


            IndexStartPM = WorkTimeString.IndexOf("PM")
            If (IndexStartPM > 0) Then
                If (WorkOra < 12) Then
                    WorkOra = WorkOra + 12
                End If
            End If

            'Create a DateTime from date and time  
            outDateAndTimeSap = New DateTime(WorkAnno, WorkMese, WorkGiorno, WorkOra, WorkMinuti, WorkSecondi)

            GetDataOraDaSystemTimeDiSap = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetDataOraDaSystemTimeDiSap = 1000
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function FromDocMatStrigToStruct(ByVal inDocMatString As String, ByRef outDocMatStruct As clsDataType.SapWmDocumentoMaterialeFull, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            FromDocMatStrigToStruct = 1 'INIT AT ERROR


            '>>> VERIFICO VALIDITA' DEI DATI OBBLIGATORI
            If (Len(inDocMatString) <> 18) And (Len(inDocMatString) <> 14) Then
                RetCode = 10
                If (inShowMessageBox = True) Then
                    MessageBox.Show(clsAppTranslation.GetSingleParameterValue(923, "", "Lunghezza stringa DOC.MATERIALE non valida (<>18 e <>14)"), AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                FromDocMatStrigToStruct = RetCode
                Exit Function
            End If

            RetCode += ResetDocMatStruct(outDocMatStruct)

            'LA STRUTTURA DELLA STRINGA E' DEL TIPO [ANNO ESERCIZIO]+[NUM.DOC.MAT.]+[POSIZIONE DOC.MAT]

            outDocMatStruct.AnnoEsercizio = Left(inDocMatString, 4)
            outDocMatStruct.NumeroDocumento = Mid(inDocMatString, 5, 10)
            If (Len(inDocMatString) = 18) Then
                outDocMatStruct.PosizioneDocumento = Right(inDocMatString, 4)
            End If

            FromDocMatStrigToStruct = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


#If APPLICAZIONE_WIN32 = "SI" Then

    Public Shared Function GetRFCParameterToString(ByRef inRfcFunction As IRfcFunction, ByRef inParameterName As String, Optional ByVal inDefaultValueIfEmptyString As String = "") As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************

        GetRFCParameterToString = ""

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (inRfcFunction Is Nothing) Then
                Exit Function
            End If

            If (inRfcFunction.GetObject(inParameterName) Is Nothing) Then
                Exit Function
            End If

            GetRFCParameterToString = inRfcFunction.GetObject(inParameterName).ToString()


        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetRFCParameterToString = "" 'CONDIZIONE VALORE INIT
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetRFCStructParamToString(ByRef inRfcStructure As IRfcStructure, ByRef inParameterName As String, Optional ByVal inDefaultValueIfEmptyString As String = "") As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************

        GetRFCStructParamToString = ""

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (inRfcStructure Is Nothing) Then
                Exit Function
            End If

            If (inRfcStructure.GetObject(inParameterName) Is Nothing) Then
                Exit Function
            End If

            GetRFCStructParamToString = inRfcStructure.GetObject(inParameterName).ToString()


        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetRFCStructParamToString = "" 'CONDIZIONE VALORE INIT
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetRFCStructParamToLong(ByRef inRfcStructure As IRfcStructure, ByRef inParameterName As String, Optional ByVal inDefaultValueIfEmptyLong As Long = 0) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************

        GetRFCStructParamToLong = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (inRfcStructure Is Nothing) Then
                Exit Function
            End If

            GetRFCStructParamToLong = inRfcStructure.GetValue(inParameterName)


        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetRFCStructParamToLong = 0 'CONDIZIONE VALORE INIT
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetRFCStructParamToFloat(ByRef inRfcStructure As IRfcStructure, ByRef inParameterName As String, Optional ByVal inDefaultValueIfEmptyFloat As Double = 0.0) As Double
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************

        GetRFCStructParamToFloat = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (inRfcStructure Is Nothing) Then
                Exit Function
            End If

            GetRFCStructParamToFloat = inRfcStructure.GetValue(inParameterName)


        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetRFCStructParamToFloat = 0 'CONDIZIONE VALORE INIT
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetRFCParameterToInt(ByRef inRfcFunction As IRfcFunction, ByRef inParameterName As String, Optional ByVal inDefaultValueIfEmptyLong As Integer = 0) As Integer
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************

        GetRFCParameterToInt = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (inRfcFunction Is Nothing) Then
                Exit Function
            End If

            GetRFCParameterToInt = inRfcFunction.GetValue(inParameterName)


        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetRFCParameterToInt = 0 'CONDIZIONE VALORE INIT
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetRFCParameterToLong(ByRef inRfcFunction As IRfcFunction, ByRef inParameterName As String, Optional ByVal inDefaultValueIfEmptyLong As Long = 0) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************

        GetRFCParameterToLong = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (inRfcFunction Is Nothing) Then
                Exit Function
            End If

            GetRFCParameterToLong = inRfcFunction.GetValue(inParameterName)


        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetRFCParameterToLong = 0 'CONDIZIONE VALORE INIT
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetRFCParameterToFloat(ByRef inRfcFunction As IRfcFunction, ByRef inParameterName As String, Optional ByVal inDefaultValueIfEmptyFloat As Double = 0.0) As Double
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************

        GetRFCParameterToFloat = 0.0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (inRfcFunction Is Nothing) Then
                Exit Function
            End If

            GetRFCParameterToFloat = inRfcFunction.GetValue(inParameterName)


        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetRFCParameterToFloat = "" 'CONDIZIONE VALORE INIT
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

#End If


    'Public Shared Function TrasfVarianteImballoSapStruct(ByVal inStructGenericVarianteImballo As StructGenericVarianteImballo, ByRef outSapVarianteImballo As SapVarianteImballo, ByVal inShowMessageBox As Boolean) As Long

    '    '**************************************
    '    'HERE PUT DECLARATION OF LOCAL VARIABLE
    '    Dim RetCode As Long = 0

    '    '**************************************
    '    Try 'HERE PUT NORMAL EXECUTION CODE
    '        '**************************************

    '        TrasfVarianteImballoSapStruct = 1 'INIT AT ERROR

    '        If (clsUtility.IsStringValid(inStructGenericVarianteImballo.VarianteImballoRec.Matnr, True) = True) Then
    '            '>>> CASO PER WS [WS_MB_CHECK_STOCK_FREE_EXTRA]
    '            outSapVarianteImballo.CodiceMateriale = inStructGenericVarianteImballo.VarianteImballoRec.Matnr
    '            outSapVarianteImballo.VarianteImballo = inStructGenericVarianteImballo.VarianteImballoRec.Imballo
    '            outSapVarianteImballo.PezziPerScatola = inStructGenericVarianteImballo.VarianteImballoRec.PzXSc
    '            outSapVarianteImballo.ScatolePerPallet = inStructGenericVarianteImballo.VarianteImballoRec.ScXPal
    '            outSapVarianteImballo.M2PerPallet = inStructGenericVarianteImballo.VarianteImballoRec.M2XPal
    '            outSapVarianteImballo.CodiceEAN11_Scatola = inStructGenericVarianteImballo.VarianteImballoRec.Ean11Sc
    '            outSapVarianteImballo.CodiceEAN11_Pallet = inStructGenericVarianteImballo.VarianteImballoRec.Ean11Pal
    '            outSapVarianteImballo.CodiceImballo = inStructGenericVarianteImballo.VarianteImballoRec.CodImb
    '            outSapVarianteImballo.PalletLarghezza = inStructGenericVarianteImballo.VarianteImballoRec.PallLarg
    '            outSapVarianteImballo.PalletProfondita = inStructGenericVarianteImballo.VarianteImballoRec.PallProf
    '            outSapVarianteImballo.PalletAltezza = inStructGenericVarianteImballo.VarianteImballoRec.PallAlt
    '            outSapVarianteImballo.PalletAltezzaSingoloPiano = inStructGenericVarianteImballo.VarianteImballoRec.PallAltP
    '            outSapVarianteImballo.PalletAltezzaPianale = inStructGenericVarianteImballo.VarianteImballoRec.PallPian
    '            outSapVarianteImballo.PalletNumeroColliPerPiano = inStructGenericVarianteImballo.VarianteImballoRec.PallColPia
    '            outSapVarianteImballo.Testo = inStructGenericVarianteImballo.VarianteImballoRec.Testo
    '            outSapVarianteImballo.CodiceMaterialeAlternativo = inStructGenericVarianteImballo.VarianteImballoRec.ImballoAlterna
    '        ElseIf (clsUtility.IsStringValid(inStructGenericVarianteImballo.VImballoGetConfQtyRec.Matnr, True) = True) Then
    '            '>>> CASO PER WS [ZWS_MB_GET_DOCMAT_CONFIRM_QTY]
    '            outSapVarianteImballo.CodiceMateriale = inStructGenericVarianteImballo.VImballoGetConfQtyRec.Matnr
    '            outSapVarianteImballo.VarianteImballo = inStructGenericVarianteImballo.VImballoGetConfQtyRec.Imballo
    '            outSapVarianteImballo.PezziPerScatola = inStructGenericVarianteImballo.VImballoGetConfQtyRec.PzXSc
    '            outSapVarianteImballo.ScatolePerPallet = inStructGenericVarianteImballo.VImballoGetConfQtyRec.ScXPal
    '            outSapVarianteImballo.M2PerPallet = inStructGenericVarianteImballo.VImballoGetConfQtyRec.M2XPal
    '            outSapVarianteImballo.CodiceEAN11_Scatola = inStructGenericVarianteImballo.VImballoGetConfQtyRec.Ean11Sc
    '            outSapVarianteImballo.CodiceEAN11_Pallet = inStructGenericVarianteImballo.VImballoGetConfQtyRec.Ean11Pal
    '            outSapVarianteImballo.CodiceImballo = inStructGenericVarianteImballo.VImballoGetConfQtyRec.CodImb
    '            outSapVarianteImballo.PalletLarghezza = inStructGenericVarianteImballo.VImballoGetConfQtyRec.PallLarg
    '            outSapVarianteImballo.PalletProfondita = inStructGenericVarianteImballo.VImballoGetConfQtyRec.PallProf
    '            outSapVarianteImballo.PalletAltezza = inStructGenericVarianteImballo.VImballoGetConfQtyRec.PallAlt
    '            outSapVarianteImballo.PalletAltezzaSingoloPiano = inStructGenericVarianteImballo.VImballoGetConfQtyRec.PallAltP
    '            outSapVarianteImballo.PalletAltezzaPianale = inStructGenericVarianteImballo.VImballoGetConfQtyRec.PallPian
    '            outSapVarianteImballo.PalletNumeroColliPerPiano = inStructGenericVarianteImballo.VImballoGetConfQtyRec.PallColPia
    '            outSapVarianteImballo.Testo = inStructGenericVarianteImballo.VImballoGetConfQtyRec.Testo
    '            outSapVarianteImballo.CodiceMaterialeAlternativo = inStructGenericVarianteImballo.VImballoGetConfQtyRec.ImballoAlterna
    '        ElseIf (clsUtility.IsStringValid(inStructGenericVarianteImballo.VImballoGetDocMatRec.Matnr, True) = True) Then
    '            '>>> CASO PER WS [ZWS_MB_GET_DOCMAT]
    '            outSapVarianteImballo.CodiceMateriale = inStructGenericVarianteImballo.VImballoGetDocMatRec.Matnr
    '            outSapVarianteImballo.VarianteImballo = inStructGenericVarianteImballo.VImballoGetDocMatRec.Imballo
    '            outSapVarianteImballo.PezziPerScatola = inStructGenericVarianteImballo.VImballoGetDocMatRec.PzXSc
    '            outSapVarianteImballo.ScatolePerPallet = inStructGenericVarianteImballo.VImballoGetDocMatRec.ScXPal
    '            outSapVarianteImballo.M2PerPallet = inStructGenericVarianteImballo.VImballoGetDocMatRec.M2XPal
    '            outSapVarianteImballo.CodiceEAN11_Scatola = inStructGenericVarianteImballo.VImballoGetDocMatRec.Ean11Sc
    '            outSapVarianteImballo.CodiceEAN11_Pallet = inStructGenericVarianteImballo.VImballoGetDocMatRec.Ean11Pal
    '            outSapVarianteImballo.CodiceImballo = inStructGenericVarianteImballo.VImballoGetDocMatRec.CodImb
    '            outSapVarianteImballo.PalletLarghezza = inStructGenericVarianteImballo.VImballoGetDocMatRec.PallLarg
    '            outSapVarianteImballo.PalletProfondita = inStructGenericVarianteImballo.VImballoGetDocMatRec.PallProf
    '            outSapVarianteImballo.PalletAltezza = inStructGenericVarianteImballo.VImballoGetDocMatRec.PallAlt
    '            outSapVarianteImballo.PalletAltezzaSingoloPiano = inStructGenericVarianteImballo.VImballoGetDocMatRec.PallAltP
    '            outSapVarianteImballo.PalletAltezzaPianale = inStructGenericVarianteImballo.VImballoGetDocMatRec.PallPian
    '            outSapVarianteImballo.PalletNumeroColliPerPiano = inStructGenericVarianteImballo.VImballoGetDocMatRec.PallColPia
    '            outSapVarianteImballo.Testo = inStructGenericVarianteImballo.VImballoGetDocMatRec.Testo
    '            outSapVarianteImballo.CodiceMaterialeAlternativo = inStructGenericVarianteImballo.VImballoGetDocMatRec.ImballoAlterna
    '        ElseIf (clsUtility.IsStringValid(inStructGenericVarianteImballo.VImballoCheckLenumRec.Matnr, True) = True) Then
    '            '>>> CASO PER WS [ZWS_MB_GET_DOCMAT]
    '            outSapVarianteImballo.CodiceMateriale = inStructGenericVarianteImballo.VImballoCheckLenumRec.Matnr
    '            outSapVarianteImballo.VarianteImballo = inStructGenericVarianteImballo.VImballoCheckLenumRec.Imballo
    '            outSapVarianteImballo.PezziPerScatola = inStructGenericVarianteImballo.VImballoCheckLenumRec.PzXSc
    '            outSapVarianteImballo.ScatolePerPallet = inStructGenericVarianteImballo.VImballoCheckLenumRec.ScXPal
    '            outSapVarianteImballo.M2PerPallet = inStructGenericVarianteImballo.VImballoCheckLenumRec.M2XPal
    '            outSapVarianteImballo.CodiceEAN11_Scatola = inStructGenericVarianteImballo.VImballoCheckLenumRec.Ean11Sc
    '            outSapVarianteImballo.CodiceEAN11_Pallet = inStructGenericVarianteImballo.VImballoCheckLenumRec.Ean11Pal
    '            outSapVarianteImballo.CodiceImballo = inStructGenericVarianteImballo.VImballoCheckLenumRec.CodImb
    '            outSapVarianteImballo.PalletLarghezza = inStructGenericVarianteImballo.VImballoCheckLenumRec.PallLarg
    '            outSapVarianteImballo.PalletProfondita = inStructGenericVarianteImballo.VImballoCheckLenumRec.PallProf
    '            outSapVarianteImballo.PalletAltezza = inStructGenericVarianteImballo.VImballoCheckLenumRec.PallAlt
    '            outSapVarianteImballo.PalletAltezzaSingoloPiano = inStructGenericVarianteImballo.VImballoCheckLenumRec.PallAltP
    '            outSapVarianteImballo.PalletAltezzaPianale = inStructGenericVarianteImballo.VImballoCheckLenumRec.PallPian
    '            outSapVarianteImballo.PalletNumeroColliPerPiano = inStructGenericVarianteImballo.VImballoCheckLenumRec.PallColPia
    '            outSapVarianteImballo.Testo = inStructGenericVarianteImballo.VImballoCheckLenumRec.Testo
    '            outSapVarianteImballo.CodiceMaterialeAlternativo = inStructGenericVarianteImballo.VImballoCheckLenumRec.ImballoAlterna
    '        End If


    '        TrasfVarianteImballoSapStruct = RetCode 'SE = 0 TUTTO OK

    '        '**************************************
    '    Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
    '        TrasfVarianteImballoSapStruct = 1000
    '        Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
    '        'LOG ERROR CONDITION
    '        clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
    '        '**************************************
    '    Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

    '    End Try
    'End Function


    Public Shared Function TrasfVarianteImballoSapStruct(ByVal inVarianteImballoRec As Object, ByRef outSapVarianteImballo As clsDataType.SapVarianteImballo, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            TrasfVarianteImballoSapStruct = 1 'INIT AT ERROR

#If Not APPLICAZIONE_WIN32 = "SI" Then

            outSapVarianteImballo.CodiceMateriale = inVarianteImballoRec.Matnr
            outSapVarianteImballo.VarianteImballo = inVarianteImballoRec.Imballo
            outSapVarianteImballo.PezziPerScatola = inVarianteImballoRec.PzXSc
            outSapVarianteImballo.ScatolePerPallet = inVarianteImballoRec.ScXPal
            outSapVarianteImballo.M2PerPallet = inVarianteImballoRec.M2XPal
            outSapVarianteImballo.CodiceEAN11_Scatola = inVarianteImballoRec.Ean11Sc
            outSapVarianteImballo.CodiceEAN11_Pallet = inVarianteImballoRec.Ean11Pal
            outSapVarianteImballo.CodiceImballo = inVarianteImballoRec.CodImb
            outSapVarianteImballo.PalletLarghezza = inVarianteImballoRec.PallLarg
            outSapVarianteImballo.PalletProfondita = inVarianteImballoRec.PallProf
            outSapVarianteImballo.PalletAltezza = inVarianteImballoRec.PallAlt
            outSapVarianteImballo.PalletAltezzaSingoloPiano = inVarianteImballoRec.PallAltP
            outSapVarianteImballo.PalletAltezzaPianale = inVarianteImballoRec.PallPian
            outSapVarianteImballo.PalletNumeroColliPerPiano = inVarianteImballoRec.PallColPia
            outSapVarianteImballo.Testo = inVarianteImballoRec.Testo
            outSapVarianteImballo.CodiceMaterialeAlternativo = inVarianteImballoRec.ImballoAlterna

#Else

            outSapVarianteImballo.CodiceMateriale = inVarianteImballoRec.item("Matnr").GetString
            outSapVarianteImballo.VarianteImballo = inVarianteImballoRec.item("Imballo").GetString
            outSapVarianteImballo.PezziPerScatola = inVarianteImballoRec.item("Pz_X_Sc").GetLong
            outSapVarianteImballo.ScatolePerPallet = inVarianteImballoRec.item("Sc_X_Pal").GetLong
            outSapVarianteImballo.M2PerPallet = inVarianteImballoRec.item("M2_X_Pal").GetLong
            outSapVarianteImballo.CodiceEAN11_Scatola = inVarianteImballoRec.item("Ean11_Sc").GetString
            outSapVarianteImballo.CodiceEAN11_Pallet = inVarianteImballoRec.item("Ean11_Pal").GetString
            outSapVarianteImballo.CodiceImballo = inVarianteImballoRec.item("Cod_Imb").GetString
            outSapVarianteImballo.PalletLarghezza = inVarianteImballoRec.item("Pall_Larg").GetLong
            outSapVarianteImballo.PalletProfondita = inVarianteImballoRec.item("Pall_Prof").GetLong
            outSapVarianteImballo.PalletAltezza = inVarianteImballoRec.item("Pall_Alt").GetLong
            outSapVarianteImballo.PalletAltezzaSingoloPiano = inVarianteImballoRec.item("Pall_Alt_P").GetLong
            outSapVarianteImballo.PalletAltezzaPianale = inVarianteImballoRec.item("Pall_Pian").GetLong
            outSapVarianteImballo.PalletNumeroColliPerPiano = inVarianteImballoRec.item("Pall_Col_Pia").GetLong
            outSapVarianteImballo.Testo = inVarianteImballoRec.item("Testo").GetString
            outSapVarianteImballo.CodiceMaterialeAlternativo = inVarianteImballoRec.item("Imballo_Alterna").GetString

#End If


            TrasfVarianteImballoSapStruct = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            TrasfVarianteImballoSapStruct = 1000
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    'Public Shared Function TrasfVarianteImballoSapStruct(ByVal inVarianteImballoRec As WS_MB_CHECK_STOCK_GIACENZA.Ze1Mt00015, ByRef outSapVarianteImballo As clsDataType.SapVarianteImballo, ByVal inShowMessageBox As Boolean) As Long

    '    '**************************************
    '    'HERE PUT DECLARATION OF LOCAL VARIABLE
    '    Dim RetCode As Long = 0

    '    '**************************************
    '    Try 'HERE PUT NORMAL EXECUTION CODE
    '        '**************************************

    '        TrasfVarianteImballoSapStruct = 1 'INIT AT ERROR

    '        outSapVarianteImballo.CodiceMateriale = inVarianteImballoRec.Matnr
    '        outSapVarianteImballo.VarianteImballo = inVarianteImballoRec.Imballo
    '        outSapVarianteImballo.PezziPerScatola = inVarianteImballoRec.PzXSc
    '        outSapVarianteImballo.ScatolePerPallet = inVarianteImballoRec.ScXPal
    '        outSapVarianteImballo.M2PerPallet = inVarianteImballoRec.M2XPal
    '        outSapVarianteImballo.CodiceEAN11_Scatola = inVarianteImballoRec.Ean11Sc
    '        outSapVarianteImballo.CodiceEAN11_Pallet = inVarianteImballoRec.Ean11Pal
    '        outSapVarianteImballo.CodiceImballo = inVarianteImballoRec.CodImb
    '        outSapVarianteImballo.PalletLarghezza = inVarianteImballoRec.PallLarg
    '        outSapVarianteImballo.PalletProfondita = inVarianteImballoRec.PallProf
    '        outSapVarianteImballo.PalletAltezza = inVarianteImballoRec.PallAlt
    '        outSapVarianteImballo.PalletAltezzaSingoloPiano = inVarianteImballoRec.PallAltP
    '        outSapVarianteImballo.PalletAltezzaPianale = inVarianteImballoRec.PallPian
    '        outSapVarianteImballo.PalletNumeroColliPerPiano = inVarianteImballoRec.PallColPia
    '        outSapVarianteImballo.Testo = inVarianteImballoRec.Testo
    '        outSapVarianteImballo.CodiceMaterialeAlternativo = inVarianteImballoRec.ImballoAlterna


    '        TrasfVarianteImballoSapStruct = RetCode 'SE = 0 TUTTO OK

    '        '**************************************
    '    Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
    '        TrasfVarianteImballoSapStruct = 1000
    '        Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
    '        'LOG ERROR CONDITION
    '        clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
    '        '**************************************
    '    Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

    '    End Try
    'End Function
    'Public Shared Function TrasfVarianteImballoSapStruct(ByVal inVarianteImballoRec As WS_CHECK_STOCK_AND_GET_DEST.Ze1Mt00015, ByRef outSapVarianteImballo As clsDataType.SapVarianteImballo, ByVal inShowMessageBox As Boolean) As Long

    '    '**************************************
    '    'HERE PUT DECLARATION OF LOCAL VARIABLE
    '    Dim RetCode As Long = 0

    '    '**************************************
    '    Try 'HERE PUT NORMAL EXECUTION CODE
    '        '**************************************

    '        TrasfVarianteImballoSapStruct = 1 'INIT AT ERROR

    '        outSapVarianteImballo.CodiceMateriale = inVarianteImballoRec.Matnr
    '        outSapVarianteImballo.VarianteImballo = inVarianteImballoRec.Imballo
    '        outSapVarianteImballo.PezziPerScatola = inVarianteImballoRec.PzXSc
    '        outSapVarianteImballo.ScatolePerPallet = inVarianteImballoRec.ScXPal
    '        outSapVarianteImballo.M2PerPallet = inVarianteImballoRec.M2XPal
    '        outSapVarianteImballo.CodiceEAN11_Scatola = inVarianteImballoRec.Ean11Sc
    '        outSapVarianteImballo.CodiceEAN11_Pallet = inVarianteImballoRec.Ean11Pal
    '        outSapVarianteImballo.CodiceImballo = inVarianteImballoRec.CodImb
    '        outSapVarianteImballo.PalletLarghezza = inVarianteImballoRec.PallLarg
    '        outSapVarianteImballo.PalletProfondita = inVarianteImballoRec.PallProf
    '        outSapVarianteImballo.PalletAltezza = inVarianteImballoRec.PallAlt
    '        outSapVarianteImballo.PalletAltezzaSingoloPiano = inVarianteImballoRec.PallAltP
    '        outSapVarianteImballo.PalletAltezzaPianale = inVarianteImballoRec.PallPian
    '        outSapVarianteImballo.PalletNumeroColliPerPiano = inVarianteImballoRec.PallColPia
    '        outSapVarianteImballo.Testo = inVarianteImballoRec.Testo
    '        outSapVarianteImballo.CodiceMaterialeAlternativo = inVarianteImballoRec.ImballoAlterna


    '        TrasfVarianteImballoSapStruct = RetCode 'SE = 0 TUTTO OK

    '        '**************************************
    '    Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
    '        TrasfVarianteImballoSapStruct = 1000
    '        Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
    '        'LOG ERROR CONDITION
    '        clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
    '        '**************************************
    '    Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

    '    End Try
    'End Function
    'Public Shared Function TrasfVarianteImballoSapStruct(ByVal inVarianteImballoRec As WS_MB_CHECK_MULTIPLE_LENUM.Ze1Mt00015, ByRef outSapVarianteImballo As clsDataType.SapVarianteImballo, ByVal inShowMessageBox As Boolean) As Long

    '    '**************************************
    '    'HERE PUT DECLARATION OF LOCAL VARIABLE
    '    Dim RetCode As Long = 0

    '    '**************************************
    '    Try 'HERE PUT NORMAL EXECUTION CODE
    '        '**************************************

    '        TrasfVarianteImballoSapStruct = 1 'INIT AT ERROR

    '        outSapVarianteImballo.CodiceMateriale = inVarianteImballoRec.Matnr
    '        outSapVarianteImballo.VarianteImballo = inVarianteImballoRec.Imballo
    '        outSapVarianteImballo.PezziPerScatola = inVarianteImballoRec.PzXSc
    '        outSapVarianteImballo.ScatolePerPallet = inVarianteImballoRec.ScXPal
    '        outSapVarianteImballo.M2PerPallet = inVarianteImballoRec.M2XPal
    '        outSapVarianteImballo.CodiceEAN11_Scatola = inVarianteImballoRec.Ean11Sc
    '        outSapVarianteImballo.CodiceEAN11_Pallet = inVarianteImballoRec.Ean11Pal
    '        outSapVarianteImballo.CodiceImballo = inVarianteImballoRec.CodImb
    '        outSapVarianteImballo.PalletLarghezza = inVarianteImballoRec.PallLarg
    '        outSapVarianteImballo.PalletProfondita = inVarianteImballoRec.PallProf
    '        outSapVarianteImballo.PalletAltezza = inVarianteImballoRec.PallAlt
    '        outSapVarianteImballo.PalletAltezzaSingoloPiano = inVarianteImballoRec.PallAltP
    '        outSapVarianteImballo.PalletAltezzaPianale = inVarianteImballoRec.PallPian
    '        outSapVarianteImballo.PalletNumeroColliPerPiano = inVarianteImballoRec.PallColPia
    '        outSapVarianteImballo.Testo = inVarianteImballoRec.Testo
    '        outSapVarianteImballo.CodiceMaterialeAlternativo = inVarianteImballoRec.ImballoAlterna


    '        TrasfVarianteImballoSapStruct = RetCode 'SE = 0 TUTTO OK

    '        '**************************************
    '    Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
    '        TrasfVarianteImballoSapStruct = 1000
    '        Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
    '        'LOG ERROR CONDITION
    '        clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
    '        '**************************************
    '    Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

    '    End Try
    'End Function
    'Public Shared Function TrasfVarianteImballoSapStruct(ByVal inVarianteImballoRec As WS_MB_GET_DOCMAT.Ze1Mt00015, ByRef outSapVarianteImballo As clsDataType.SapVarianteImballo, ByVal inShowMessageBox As Boolean) As Long

    '    '**************************************
    '    'HERE PUT DECLARATION OF LOCAL VARIABLE
    '    Dim RetCode As Long = 0

    '    '**************************************
    '    Try 'HERE PUT NORMAL EXECUTION CODE
    '        '**************************************

    '        TrasfVarianteImballoSapStruct = 1 'INIT AT ERROR

    '        outSapVarianteImballo.CodiceMateriale = inVarianteImballoRec.Matnr
    '        outSapVarianteImballo.VarianteImballo = inVarianteImballoRec.Imballo
    '        outSapVarianteImballo.PezziPerScatola = inVarianteImballoRec.PzXSc
    '        outSapVarianteImballo.ScatolePerPallet = inVarianteImballoRec.ScXPal
    '        outSapVarianteImballo.M2PerPallet = inVarianteImballoRec.M2XPal
    '        outSapVarianteImballo.CodiceEAN11_Scatola = inVarianteImballoRec.Ean11Sc
    '        outSapVarianteImballo.CodiceEAN11_Pallet = inVarianteImballoRec.Ean11Pal
    '        outSapVarianteImballo.CodiceImballo = inVarianteImballoRec.CodImb
    '        outSapVarianteImballo.PalletLarghezza = inVarianteImballoRec.PallLarg
    '        outSapVarianteImballo.PalletProfondita = inVarianteImballoRec.PallProf
    '        outSapVarianteImballo.PalletAltezza = inVarianteImballoRec.PallAlt
    '        outSapVarianteImballo.PalletAltezzaSingoloPiano = inVarianteImballoRec.PallAltP
    '        outSapVarianteImballo.PalletAltezzaPianale = inVarianteImballoRec.PallPian
    '        outSapVarianteImballo.PalletNumeroColliPerPiano = inVarianteImballoRec.PallColPia
    '        outSapVarianteImballo.Testo = inVarianteImballoRec.Testo
    '        outSapVarianteImballo.CodiceMaterialeAlternativo = inVarianteImballoRec.ImballoAlterna

    '        TrasfVarianteImballoSapStruct = RetCode 'SE = 0 TUTTO OK

    '        '**************************************
    '    Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
    '        TrasfVarianteImballoSapStruct = 1000
    '        Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
    '        'LOG ERROR CONDITION
    '        clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
    '        '**************************************
    '    Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

    '    End Try
    'End Function
    'Public Shared Function TrasfVarianteImballoSapStruct(ByVal inVarianteImballoRec As WS_MB_CHECK_LENUM_GIACENZA.Ze1Mt00015, ByRef outSapVarianteImballo As clsDataType.SapVarianteImballo, ByVal inShowMessageBox As Boolean) As Long

    '    '**************************************
    '    'HERE PUT DECLARATION OF LOCAL VARIABLE
    '    Dim RetCode As Long = 0

    '    '**************************************
    '    Try 'HERE PUT NORMAL EXECUTION CODE
    '        '**************************************

    '        TrasfVarianteImballoSapStruct = 1 'INIT AT ERROR

    '        outSapVarianteImballo.CodiceMateriale = inVarianteImballoRec.Matnr
    '        outSapVarianteImballo.VarianteImballo = inVarianteImballoRec.Imballo
    '        outSapVarianteImballo.PezziPerScatola = inVarianteImballoRec.PzXSc
    '        outSapVarianteImballo.ScatolePerPallet = inVarianteImballoRec.ScXPal
    '        outSapVarianteImballo.M2PerPallet = inVarianteImballoRec.M2XPal
    '        outSapVarianteImballo.CodiceEAN11_Scatola = inVarianteImballoRec.Ean11Sc
    '        outSapVarianteImballo.CodiceEAN11_Pallet = inVarianteImballoRec.Ean11Pal
    '        outSapVarianteImballo.CodiceImballo = inVarianteImballoRec.CodImb
    '        outSapVarianteImballo.PalletLarghezza = inVarianteImballoRec.PallLarg
    '        outSapVarianteImballo.PalletProfondita = inVarianteImballoRec.PallProf
    '        outSapVarianteImballo.PalletAltezza = inVarianteImballoRec.PallAlt
    '        outSapVarianteImballo.PalletAltezzaSingoloPiano = inVarianteImballoRec.PallAltP
    '        outSapVarianteImballo.PalletAltezzaPianale = inVarianteImballoRec.PallPian
    '        outSapVarianteImballo.PalletNumeroColliPerPiano = inVarianteImballoRec.PallColPia
    '        outSapVarianteImballo.Testo = inVarianteImballoRec.Testo
    '        outSapVarianteImballo.CodiceMaterialeAlternativo = inVarianteImballoRec.ImballoAlterna

    '        TrasfVarianteImballoSapStruct = RetCode 'SE = 0 TUTTO OK

    '        '**************************************
    '    Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
    '        TrasfVarianteImballoSapStruct = 1000
    '        Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
    '        'LOG ERROR CONDITION
    '        clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
    '        '**************************************
    '    Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

    '    End Try
    'End Function
End Class