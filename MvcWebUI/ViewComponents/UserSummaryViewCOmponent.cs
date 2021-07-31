using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.ViewComponents
{
    public class UserSummaryViewComponent:ViewComponent
    {
        public ViewViewComponentResult Invoke()
        {
           
            UserDatailsViewModel model = new UserDatailsViewModel
            {
                UserName= HttpContext.User.Identity.Name
            };
            return View(model);
        }
    }
}
