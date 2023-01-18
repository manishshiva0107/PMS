using Microsoft.AspNetCore.Mvc;
using PMS.AuthenticateService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.Controllers.UserAdmin
{
    [CustomAuthenticate]
    public class DashboardController : Controller
    {
        public IActionResult GetDashboard()
        {
            return View("~/Views/Home/Dashboard.cshtml");
        }
    }
}
