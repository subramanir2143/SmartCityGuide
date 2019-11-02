using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIeSCT.Web.Models
{
    public class IdealIntentResult
    {
        public IEnumerable<IdealResultClass> IdealResult { get; set; }

        public string Intent { get; set; }
    }
}