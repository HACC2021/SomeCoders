﻿using HACC_PetPickupNotifications.Models;
using HACC_PetPickupNotifications.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HACC_PetPickupNotifications.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(UserModel userModel)
        {
            SecurityService securityService = new SecurityService();
            if (securityService.IsValidUserLogin(userModel))
            {
                return View("LoginSuccess", userModel);
            } else
            {
                return View("LoginFailure", userModel);
            }
        }

        private bool IsValidUserLogin()
        {
            throw new NotImplementedException();
        }

        //https://www.youtube.com/watch?v=8Cu7Gy-Vm2I - for login info stuff
    }
}
