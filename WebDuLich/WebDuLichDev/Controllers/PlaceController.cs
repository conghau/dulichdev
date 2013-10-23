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

        public ActionResult NicePlaceByCity(long cityId)
        {
            DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
            var model = dlPlaceBal.GetListNicePlaceByCity(cityId).Take(2).ToList();
            DuLichDLL.Model.DL_Place model1 = new DuLichDLL.Model.DL_Place();
            ViewBag.pages = 1;
            return View(model);
        }
        [HttpPost]
        public ActionResult NicePlaceByCity(long cityId, int page)
        {
            DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
            var model = dlPlaceBal.GetListNicePlaceByCity(cityId).Take(4).ToList();
            DuLichDLL.Model.DL_Place model1 = new DuLichDLL.Model.DL_Place();
            ViewBag.pages = page;
            return View(model);
        }

        public ActionResult RestaurantsByCity(long cityId)
        {
            DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
            var model = dlPlaceBal.GetListRestaurantsPlaceByCity(cityId);
            return View();
        }

        public ActionResult HotelByCity(long cityId)
        {
            DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
            var model = dlPlaceBal.GetListHotelByCity(
                
                cityId);
            return View();
        }

        [HttpPost]
        public ActionResult reLoadPage(long cityId, int page)
        {
            DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
            var model = dlPlaceBal.GetListNicePlaceByCity(cityId).Take(4).ToList();
            DuLichDLL.Model.DL_Place model1 = new DuLichDLL.Model.DL_Place();
            ViewBag.pages = page;
            return PartialView("p_niceplace",model);
        }

    }
}
