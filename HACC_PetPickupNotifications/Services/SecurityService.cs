using HACC_PetPickupNotifications.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HACC_PetPickupNotifications.Services
{
    public class SecurityService
    {
        List<UserModel> knownUsers = new List<UserModel>();

        public SecurityService()
        {
            //This is just a place holder, we need to get these knownUsers from a database.
            //Think we will come back to this later
            knownUsers.Add(new UserModel { Id = 00001, UserName = "Bran", Password = "pass1" });
            knownUsers.Add(new UserModel { Id = 00002, UserName = "Mo", Password = "pass2" });
            knownUsers.Add(new UserModel { Id = 00003, UserName = "Brean", Password = "pass3" });
        }

        public bool IsValidUserLogin( UserModel user)
        {
            return knownUsers.Any(x => x.UserName == user.UserName && x.Password == user.Password);
        }
    }
}
