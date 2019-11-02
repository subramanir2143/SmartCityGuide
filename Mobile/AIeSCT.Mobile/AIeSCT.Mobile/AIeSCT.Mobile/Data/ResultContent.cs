using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIeSCT.Mobile.Data
{
    public class ResultContent
    {
        public string Intent { get; set; }

        public IEnumerable<ResultClass> Results { get; set; }
    }
}
