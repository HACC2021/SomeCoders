using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HACC_PetPickupNotifications.Models
{
    public class PetModel
    {
        public int PetId { get; set; }
        public int MicroChipID { get; set; }
        public string PetName { get; set; }
        public List<string> PetOwnerPhoneNumber { get; set; }
    }
}
