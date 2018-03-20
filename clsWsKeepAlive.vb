'Namespace YourNamespace
'{
'    using System.Diagnostics;
'    using System.Web.Services;
'    using System.ComponentModel;
'    using System.Web.Services.Protocols;
'    using System;
'    using System.Xml.Serialization;

'    /// <summary>
'    /// This partial class makes it so all requests specify
'    /// "Connection: Close" instead of "Connection: KeepAlive" in the HTTP headers.
'    /// </summary>
'    public partial class YourServiceNameWse : Microsoft.Web.Services3.WebServicesClientProtocol
'    {
'        protected override System.Net.WebRequest GetWebRequest(Uri uri)
'        {
'            System.Net.HttpWebRequest webRequest = (System.Net.HttpWebRequest)base.GetWebRequest(uri);
'            webRequest.KeepAlive = false;
'            return webRequest;
'        }
'    }
'}
