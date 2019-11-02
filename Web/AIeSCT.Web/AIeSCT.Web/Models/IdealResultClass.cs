using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIeSCT.Web.Models
{
    public class IdealResultClass
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Availability { get; set; }

        public string Description { get; set; }

        public double PredictionPerc { get; set; }
    }
}