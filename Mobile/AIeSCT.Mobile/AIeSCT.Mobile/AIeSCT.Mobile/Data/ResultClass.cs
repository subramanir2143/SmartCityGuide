using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIeSCT.Mobile.Data
{
    public class ResultClass
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Availability { get; set; }

        public string AvialableText { get; set; }

        public double PredictionPerc { get; set; }
    }
}
