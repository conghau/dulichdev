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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(PlaceController).Name);
        string version = "Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " ";
        //
        // GET: /Place/
        private static List<DL_ImagePlace> listImagePlaceOld = new List<DL_ImagePlace>();

        public ActionResult ListNicePlace()
        {
            try
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
            catch (BusinessException bx)
            {
                log.Error(bx.Message);
                TempData[PageInfo.Message.ToString()] = bx.Message;
                return RedirectToAction("Error", "Home");
            }
            catch (Exception ex)
            {
                //LogBAL.LogEx("BLM_ERR_Common", ex);
                log.Error(ex.Message);
                TempData[PageInfo.Message.ToString()] = "BLM_ERR_Common";
                return RedirectToAction("Error", "Home");
            }
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

            var model = dlPlaceBal.GetListWithFilter(cityId, "", "", (long)DL_PlaceTypeId.Places, pagination.Page.Value, pagination.PageSize.Value, pagination.OrderBy, pagination.OrderDirection, out totalRecords);
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
            try
            {
                bool result = false;
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
                result = dlPlaceBal.InsertNicePlace(dataRequest.dlPlace, dataRequest.dlNicePlaceInfoDetail, dataRequest.listImageCity);
                //dlPlaceBal.Insert(dataRequest);           
                if (true == result)
                {
                    TempData["Message"] = ResultMessage.SUC_Insert;
                    return RedirectToAction("ListNicePlace");
                }
                else
                {
                    TempData["Message"] = ResultMessage.ERR_Insert;
                    return RedirectToAction("ListNicePlace");
                }
            }
            catch (BusinessException bx)
            {
                log.Error(bx.Message);
                TempData[PageInfo.Message.ToString()] = bx.Message;
                return RedirectToAction("Error", "Home");
            }
            catch (Exception ex)
            {
                //LogBAL.LogEx("BLM_ERR_Common", ex);
                log.Error(ex.Message);
                TempData[PageInfo.Message.ToString()] = "BLM_ERR_Common";
                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult UpdateNicePlace(long dlPlaceId)
        {
            try
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
            catch (BusinessException bx)
            {
                log.Error(bx.Message);
                TempData[PageInfo.Message.ToString()] = bx.Message;
                return RedirectToAction("Error", "Home");
            }
            catch (Exception ex)
            {
                //LogBAL.LogEx("BLM_ERR_Common", ex);
                log.Error(ex.Message);
                TempData[PageInfo.Message.ToString()] = "BLM_ERR_Common";
                return RedirectToAction("Error", "Home");
            }
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
                //long[] listImageDeleted = new long[]{};
                //update status image
                if (null != listImagePlaceOld)
                {
                    if (listIdImagePresent != null)
                    { 
                        var listImageDeleted = listImagePlaceOld.Select(m => m.ID).ToArray().Except(listIdImagePresent).ToArray();
                        if (null != listImageDeleted)
                            for (int index = 0; index < listImageDeleted.Count(); index++)
                                dlImagePlaceBal.Delete(listImageDeleted[index]);
                    }
                    if (listIdImagePresent == null)
                    {
                        for (int index = 0; index < listImagePlaceOld.Count(); index++)
                        {
                            dlImagePlaceBal.Delete(listImagePlaceOld[index].ID);
                        }
                    }
                }

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
            catch (BusinessException bx)
            {
                log.Error(bx.Message);
                TempData[PageInfo.Message.ToString()] = bx.Message;
                return RedirectToAction("Error", "Home");
            }
            catch (Exception ex)
            {
                //LogBAL.LogEx("BLM_ERR_Common", ex);
                log.Error(ex.Message);
                TempData[PageInfo.Message.ToString()] = "BLM_ERR_Common";
                return RedirectToAction("Error", "Home");
            }

            // return View();
        }

        #region

        #endregion
    }
}
