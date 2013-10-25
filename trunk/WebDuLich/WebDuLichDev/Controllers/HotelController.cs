using DuLichDLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDuLichDev.Controllers
{
    public class HotelController : Controller
    {
        //
        // GET: /Hotel/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddHotel()
        {
            DL_Place dlPlace = new DL_Place();
            return View(dlPlace);
        }

        [HttpPost]
        public ActionResult AddHotel(DL_Place data)
        {
            return View(data);
        }
    }
}
