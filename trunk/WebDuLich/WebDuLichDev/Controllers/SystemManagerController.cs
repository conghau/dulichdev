using DuLichDLL.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDuLichDev.Controllers
{
    public class SystemManagerController : Controller
    {
        //
        // GET: /SystemManager/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CityManager()
        {
            DL_CityBAL dlcityBal=new DL_CityBAL();
            var model = dlcityBal.GetList();
            return View(model);
        }


    }
}
