Module mdlConstants


    '**********************************************************************
    '********************* COSTANTI ***************************************
    '**********************************************************************
    Public Const cstTipoMag901 = "901"
    Public Const cstTipoMag902 = "902"
    Public Const cstTipoMag903 = "903"
    Public Const cstTipoMag904 = "904"
    Public Const cstTipoMag905 = "905"
    Public Const cstTipoMag910 = "910"
    Public Const cstTipoMag921 = "921"
    Public Const cstTipoMagZ0S = "Z0S"


    Public Const cstTipoStockQ = "Q"
    Public Const cstTipoStockK = "K"
    Public Const cstTipoStockS = "S"

    Public Const cstIdSenderSAP = 1

    Public Const cstDirectSapToWmm = 1
    Public Const cstDirectWmmToSap = 2

    Public Const cstUbicazioneScaffaleDecori = "SCAFFALE"


#If Not APPLICAZIONE_WIN32 = "SI" Then
    Public Const cstNomeApplicazione = "WM_Mobile_PanariaUSA"
#Else
    Public Const cstNomeApplicazione = "WM_Win_PanariaUSA"
#End If

    Public Const cstPROFID_ADMIN = "ADMIN"

End Module
