using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIeSCT.Api.Data
{
   public class IdealIntentResult
    {
        public IEnumerable<IdealResultClass> IdealResult { get; set; }

        public string Intent { get; set; }
    }
}
