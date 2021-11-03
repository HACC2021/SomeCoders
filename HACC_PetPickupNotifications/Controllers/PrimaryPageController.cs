using HACC_PetPickupNotifications.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HACC_PetPickupNotifications.Controllers
{
    public class PrimaryPageController : Controller
    {
        // GET: PrimaryPageController
        public ActionResult Index()
        {
            PetDataService petDataService = new PetDataService();
            return View();
        }
    }
}
