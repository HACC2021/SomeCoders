using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetPickupSolution.Models
{
    public class PetPickupModel
    {
        [Key]
        public int PetID { get; set; }
        public int PetMicroChipID { get; set; }
        public string PetName { get; set; }
        public string OwnerPhoneNumber { get; set; }

        //considering adding multiple phone number objects, since it seems I can't use a list or array

        public PetPickupModel()
        {

        }

    }
}
