using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuLichDLL.BAL;
using DuLichDLL.Model;
using System.IO;
using DuLichDLL.TOOLS;

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
            return PartialView("p_niceplace", model);
        }

        public ActionResult AddPlace()
        {
            DL_Place dlPlace = new DL_Place();
            return View(dlPlace);
        }

        [HttpPost]
        public ActionResult AddPlace(DL_Place dataRequest)
        {
            DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();

            dataRequest.DL_PlaceTypeId = (long)DL_PlaceTypeId.Places;
            dlPlaceBal.Insert(dataRequest);           
            return View(dataRequest);
        }

        public ActionResult UploadImage(IEnumerable<HttpPostedFileBase> fileUpload)
        {
            var serserPath = Server.MapPath("~/Data/Images/Place/");
            //foreach (var pathFile in filemap1)
            //{

            // The Name of the Upload component is "attachments" 

            foreach (var file in fileUpload)
            {
                // Some browsers send file names with full path. We only care about the file name.


                var fileName = Path.GetFileName(file.FileName);
                //if (Path.GetExtension(file.FileName) != ".*")
                //    return Content("Khong dung dinh dang");
                var destinationPath = Path.Combine(Server.MapPath("~/Data/Images/Place/"), fileName);

                file.SaveAs(destinationPath);

                //db.bq_Quiz_UpdateCompanyIcon(quizId, fileName);
            }

            // Return an empty string to signify success      

            return Json(new { status = "OK" }, "text/plain");

        }

        public ActionResult RemoveImage(string fileNames)
        {
            ProcessWithFiles processfile = new ProcessWithFiles();
            var destinationPath = Path.Combine(Server.MapPath("~/Data/Images/Place/"), fileNames);

            processfile.DeleteFile(destinationPath);

            return Json(new { status = "OK" }, "text/plain");

        }

    }
}
