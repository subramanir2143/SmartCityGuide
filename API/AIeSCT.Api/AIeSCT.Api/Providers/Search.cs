using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using AIeSCT.Api.Data;
using System.Web.Helpers;

namespace AIeSCT.Api.Providers
{
    public class Search
    {
        public Rootobject GetIntent(string text)
        {
            string url = string.Format("https://api.projectoxford.ai/luis/v2.0/apps/1e048f7e-453d-4264-8766-47ee6aff2cbf?subscription-key=e0bf730f2d654fb79b3fc221f9a3fd7e&q={0}&verbose=true", text);
            WebClient request = new WebClient();
            var response = request.DownloadString(url);

            Rootobject result = Json.Decode<Rootobject>(response);

            return result;
        }
    }
}