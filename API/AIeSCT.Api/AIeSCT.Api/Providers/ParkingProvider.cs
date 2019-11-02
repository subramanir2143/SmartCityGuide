using AIeSCT.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIeSCT.Api.Providers
{
    public class ParkingProvider
    {
        AISCT context;
        public ParkingProvider()
        {
            context = new AISCT();
        }

        public void ToggleStatus(Guid id)
        {
            ParkingPlace selectedplace = this.context.ParkingPlaces.FirstOrDefault(x => x.Id == id);
            selectedplace.Availability = !selectedplace.Availability;
            this.context.SaveChanges();
        }
    }
}