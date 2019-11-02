using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIeSCT.Web.ViewModels
{
    public class ParkingPlaceViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Availability { get; set; }
    }
}