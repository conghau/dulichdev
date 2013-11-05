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
using DuLichDLL.ExceptionType;
using WebDuLichDev.Enum;

namespace WebDuLichDev.Controllers
{
    public class PlaceController : Controller
    {
        //
        // GET: /Place/
        private static List<DL_ImagePlace> listImagePlaceOld = new List<DL_ImagePlace>();

        public ActionResult ListNicePlace()
        {
            vm_Pagination pagination = new vm_Pagination
            {
                Page = MvcApplication.pageDefault,
                PageSize = MvcApplication.pageSizeDefault,
                OrderBy = DL_PlaceColumns.CreatedDate.ToString(),
                OrderDirection = "DESC",

            };
            long totalRecords = 0;

            DL_PlaceBAL dlPlaceBAL = new DL_PlaceBAL();
            var model = dlPlaceBAL.GetListWithFilter(0, "", "", 0, pagination.Page.Value, pagination.PageSize.Value, pagination.OrderBy, pagination.OrderDirection, out totalRecords);
            common.LoadPagingData(this, pagination.Page ?? MvcApplication.pageDefault, pagination.PageSize ?? MvcApplication.pageSizeDefault, totalRecords);
            ViewData["OrderBy"] = pagination.OrderBy;
            ViewData["OrderDirection"] = pagination.OrderDirection;

            return View(model);
        }

        [HttpPost]
        public ActionResult ListNicePlace(vm_Pagination pagination, vm_Search dataSearch)
        {

            long totalRecords = 0;

            DL_PlaceBAL dlPlaceBAL = new DL_PlaceBAL();
            var model = dlPlaceBAL.GetListWithFilter(dataSearch.cityId ?? 0, dataSearch.placename ?? "", dataSearch.address ?? "", 0, pagination.Page.Value, pagination.PageSize.Value, pagination.OrderBy, pagination.OrderDirection, out totalRecords);
            common.LoadPagingData(this, pagination.Page ?? MvcApplication.pageDefault, pagination.PageSize ?? MvcApplication.pageSizeDefault, totalRecords);
            ViewData["OrderBy"] = pagination.OrderBy;
            ViewData["OrderDirection"] = pagination.OrderDirection;

            return View(model);
        }

        public ActionResult NicePlaceByCity(long cityId)
        {
            DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
            long totalRecords = 0;
            vm_Pagination pagination = new vm_Pagination
            {
                Page = MvcApplication.pageDefault,
                PageSize = MvcApplication.pageSizeDefault,
                OrderBy = DL_PlaceColumns.CreatedDate.ToString(),
                OrderDirection = "DESC",

            };

            var model = dlPlaceBal.GetListWithFilter(cityId,"","",(long)DL_PlaceTypeId.Places,pagination.Page.Value,pagination.PageSize.Value,pagination.OrderBy,pagination.OrderDirection,out totalRecords);
            //DuLichDLL.Model.DL_Place model1 = new DuLichDLL.Model.DL_Place();
            common.LoadPagingData(this, pagination.Page ?? MvcApplication.pageDefault, pagination.PageSize ?? MvcApplication.pageSizeDefault, totalRecords);
            ViewData["OrderBy"] = pagination.OrderBy;
            ViewData["OrderDirection"] = pagination.OrderDirection;
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

        [HttpPost]
        public ActionResult reLoadPage(long cityId, vm_Pagination pagination)
        {
            DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
            long totalRecords = 0;
            //var model = dlPlaceBal.GetListNicePlaceByCity(cityId).Take(4).ToList();
            var model = dlPlaceBal.GetListWithFilter(cityId, "", "", (long)DL_PlaceTypeId.Places, pagination.Page.Value, pagination.PageSize.Value, pagination.OrderBy, pagination.OrderDirection, out totalRecords);
            common.LoadPagingData(this, pagination.Page ?? MvcApplication.pageDefault, pagination.PageSize ?? MvcApplication.pageSizeDefault, totalRecords);
            ViewData["OrderBy"] = pagination.OrderBy;
            ViewData["OrderDirection"] = pagination.OrderDirection;
            //DuLichDLL.Model.DL_Place model1 = new DuLichDLL.Model.DL_Place();
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

        public ActionResult UpdateNicePlace(long dlPlaceId)
        {
            DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
            DL_NicePlaceInfoDetailBAL dlNicePlaceDetailBal = new DL_NicePlaceInfoDetailBAL();
            DL_ImagePlaceBAL dlImagePlaceBal = new DL_ImagePlaceBAL();
            NicePlace model = new NicePlace();
            model.dlPlace = dlPlaceBal.GetByID(dlPlaceId);
            model.listImageCity = dlImagePlaceBal.GetByDLPlaceID(dlPlaceId);
            model.dlNicePlaceInfoDetail = dlNicePlaceDetailBal.GetByPlaceId(dlPlaceId);
            listImagePlaceOld = model.listImageCity;
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateNicePlace(NicePlace dataRequest, long[] listIdImagePresent, string[] listImageAddNew)
        {
            try
            {
                bool result = false;
                DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
                DL_NicePlaceInfoDetailBAL dlNicePlaceDetailBal = new DL_NicePlaceInfoDetailBAL();
                DL_ImagePlaceBAL dlImagePlaceBal = new DL_ImagePlaceBAL();

                var listImageDeleted = listImagePlaceOld.Select(m => m.ID).ToArray().Except(listIdImagePresent).ToArray();
                
                //update status image
                /////////////////

                List<DL_ImagePlace> listImagePlaceNew = new List<DL_ImagePlace>();
                if (null != listImageAddNew)
                {
                    for (int index = 0; index < listImageAddNew.Count(); index++)
                    {
                        DL_ImagePlace temp = new DL_ImagePlace();
                        temp.DL_PlaceID = dataRequest.dlPlace.ID;
                        temp.LinkImage = listImageAddNew[index];
                        temp.Status = 0;
                        listImagePlaceNew.Add(temp);
                    }
                }

                result = dlPlaceBal.UpdateNicePlace(dataRequest.dlPlace, dataRequest.dlNicePlaceInfoDetail, listImagePlaceNew);

                if (true == result)
                {
                    TempData["Message"] = ResultMessage.SUC_Update;
                    return RedirectToAction("ListNicePlace");
                }
                else
                {
                    TempData["Message"] = ResultMessage.ERR_Update;
                    return RedirectToAction("ListNicePlace");
                }

            }
            catch (DataAccessException ex)
            {
                TempData[PageInfo.Message.ToString()] = ex.Message;
                return RedirectToAction("Error", "Home");
            }
            catch (Exception ex)
            {
                //LogBAL.LogEx("BLM_ERR_Common", ex);
                TempData[PageInfo.Message.ToString()] = "BLM_ERR_Common";
                return RedirectToAction("Error", "Home");
            }

           // return View();
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

        #region
        public ActionResult ListHotel()
        {
            vm_Pagination pagination = new vm_Pagination
            {
                Page = MvcApplication.pageDefault,
                PageSize = MvcApplication.pageSizeDefault,
                OrderBy = DL_PlaceColumns.CreatedDate.ToString(),
                OrderDirection = "DESC",

            };
            long totalRecords = 0;

            DL_PlaceBAL dlPlaceBAL = new DL_PlaceBAL();
            var model = dlPlaceBAL.GetListWithFilter(0, "", "", (long)DL_PlaceTypeId.Hotels, pagination.Page.Value, pagination.PageSize.Value, pagination.OrderBy, pagination.OrderDirection, out totalRecords);

            common.LoadPagingData(this, pagination.Page ?? MvcApplication.pageDefault, pagination.PageSize ?? MvcApplication.pageSizeDefault, totalRecords);
            ViewData["OrderBy"] = pagination.OrderBy;
            ViewData["OrderDirection"] = pagination.OrderDirection;

            return View(model);
        }

        [HttpPost]
        public ActionResult ListHotel(vm_Pagination pagination, vm_Search dataSearch)
        {
            long totalRecords = 0;

            DL_PlaceBAL dlPlaceBAL = new DL_PlaceBAL();
            var model = dlPlaceBAL.GetListWithFilter(0, "", "", (long)DL_PlaceTypeId.Hotels, pagination.Page.Value, pagination.PageSize.Value, pagination.OrderBy, pagination.OrderDirection, out totalRecords);

            common.LoadPagingData(this, pagination.Page ?? MvcApplication.pageDefault, pagination.PageSize ?? MvcApplication.pageSizeDefault, totalRecords);
            ViewData["OrderBy"] = pagination.OrderBy;
            ViewData["OrderDirection"] = pagination.OrderDirection;

            return View(model);
        }


        public ActionResult HotelByCity(long cityId)
        {
            DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
            var model = dlPlaceBal.GetListHotelByCity(

                cityId);
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
        #endregion
    }
}
