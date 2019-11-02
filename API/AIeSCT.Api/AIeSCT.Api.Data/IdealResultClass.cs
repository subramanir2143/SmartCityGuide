using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIeSCT.Api.Data
{
    public class IdealResultClass
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public bool Availability { get; set; }

        public double PredictionPerc { get; set; }
    }
}
