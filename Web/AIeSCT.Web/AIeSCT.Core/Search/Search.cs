using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AIeSCT.Core.Search
{
    public class Search
    {

        public void GetIntent(string text)
        {
            string url = string.Format("https://api.projectoxford.ai/luis/v2.0/apps/1e048f7e-453d-4264-8766-47ee6aff2cbf?subscription-key=e0bf730f2d654fb79b3fc221f9a3fd7e&q={0}&verbose=true",text);
            WebClient request = new WebClient();
            var response = request.DownloadString(url);
        }
    }
}
