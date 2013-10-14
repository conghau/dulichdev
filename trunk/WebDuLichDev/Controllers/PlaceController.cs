using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuLichDLL.BAL;

namespace WebDuLichDev.Controllers
{
    public class PlaceController : Controller
    {
        //
        // GET: /Place/

        public ActionResult Index()
        {
            DL_PlaceBAL dlPlaceBAL = new DL_PlaceBAL();
            var model = dlPlaceBAL.GetList();
            return View(model);
        }

    }
}
