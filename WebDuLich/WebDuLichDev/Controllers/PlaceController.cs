using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuLichDLL.BAL;
using DuLichDLL.Model;
using System.IO;
using DuLichDLL.TOOLS;
using WebDuLichDev.Models;
using WebDuLichDev.WebUtility;

namespace WebDuLichDev.Controllers
{
    public class PlaceController : Controller
    {
        //
        // GET: /Place/

        public ActionResult Index()
        {
            vm_Pagination pagination = new vm_Pagination{
                Page = MvcApplication.pageDefault,
                PageSize = MvcApplication.pageSizeDefault,
                OrderBy = DL_PlaceColumns.CreatedDate.ToString(),
                OrderDirection ="DESC",

            };
            long totalRecords=0;

            DL_PlaceBAL dlPlaceBAL = new DL_PlaceBAL();
            var model = dlPlaceBAL.GetListWithFilter(0,"",0,pagination.Page.Value, pagination.PageSize.Value,pagination.OrderBy,pagination.OrderDirection, out totalRecords);

            common.LoadPagingData(this, pagination.Page ?? MvcApplication.pageDefault, pagination.PageSize ?? MvcApplication.pageSizeDefault, totalRecords);
            ViewData["OrderBy"] = pagination.OrderBy;
            ViewData["OrderDirection"] = pagination.OrderDirection;

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(vm_Pagination pagination)
        {

            long totalRecords = 0;

            DL_PlaceBAL dlPlaceBAL = new DL_PlaceBAL();
            var model = dlPlaceBAL.GetListWithFilter(0, "",0, pagination.Page.Value, pagination.PageSize.Value, pagination.OrderBy, pagination.OrderDirection, out totalRecords);

            common.LoadPagingData(this, pagination.Page ?? MvcApplication.pageDefault, pagination.PageSize ?? MvcApplication.pageSizeDefault, totalRecords);
            ViewData["OrderBy"] = pagination.OrderBy;
            ViewData["OrderDirection"] = pagination.OrderDirection;

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
            NicePlace model = new NicePlace();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddPlace(NicePlace dataRequest, string[] imagePlace)
        {
            DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
            List<DL_ImagePlace> listImagePlace = new List<DL_ImagePlace>();
            if (null != imagePlace)
            {
                for (int index = 0; index < imagePlace.Count(); index++)
                {
                    DL_ImagePlace temp = new DL_ImagePlace();
                    temp.LinkImage = imagePlace[index];
                    listImagePlace.Add(temp);
                }
            }
            dataRequest.listImageCity = listImagePlace;

            dataRequest.dlPlace.DL_PlaceTypeId = (long)DL_PlaceTypeId.Places;
            dlPlaceBal.InsertNicePlace(dataRequest.dlPlace, dataRequest.dlNicePlaceInfoDetail, dataRequest.listImageCity);
            //dlPlaceBal.Insert(dataRequest);           
            return View(dataRequest);
        }

        public ActionResult UploadAvatar(IEnumerable<HttpPostedFileBase> fileUpload)
        {
            var serserPath = Server.MapPath("~/Data/Avatar/Place/");
            foreach (var file in fileUpload)
            {
                // Some browsers send file names with full path. We only care about the file name.
                var fileName = Path.GetFileName(file.FileName);

                var destinationPath = Path.Combine(serserPath, fileName);

                file.SaveAs(destinationPath);
            }
            return Json(new { status = "OK" }, "text/plain");

        }
        public ActionResult RemoveAvatar(string fileNames)
        {
            ProcessWithFiles processfile = new ProcessWithFiles();
            var destinationPath = Path.Combine(Server.MapPath("~/Data/Avatar/Place/"), fileNames);

            processfile.DeleteFile(destinationPath);

            return Json(new { status = "OK" }, "text/plain");

        }

        public ActionResult UploadImage(IEnumerable<HttpPostedFileBase> fileUpload)
        {
            var serserPath = Server.MapPath("~/Data/Images/Place/");
            foreach (var file in fileUpload)
            {
                // Some browsers send file names with full path. We only care about the file name.
                var fileName = Path.GetFileName(file.FileName);

                var destinationPath = Path.Combine(Server.MapPath("~/Data/Images/Place/"), fileName);

                file.SaveAs(destinationPath);
            }
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
