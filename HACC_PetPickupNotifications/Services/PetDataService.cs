using HACC_PetPickupNotifications.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HACC_PetPickupNotifications.Services
{
    public class PetDataService
    {
        List<PetModel> petsInHolding = new List<PetModel>();

        public PetDataService()
        {
            petsInHolding.Add( new PetModel { PetId = 00001, MicroChipID = 111, PetName = "Berry", PetOwnerPhoneNumber = { "8084927514","8084927511"} });
            petsInHolding.Add( new PetModel { PetId = 00002, MicroChipID = 112, PetName = "Pepper", PetOwnerPhoneNumber = { "8084927514", "8084927510" } });
        }
    }
}
