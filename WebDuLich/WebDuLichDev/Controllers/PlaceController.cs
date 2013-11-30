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
using System.Text;

namespace WebDuLichDev.Controllers
{
    public class PlaceController : BaseController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(PlaceController).Name);
        string version = "Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " ";
        //
        // GET: /Place/
        private static List<DL_ImagePlace> listImagePlaceOld = new List<DL_ImagePlace>();

        [Authorize]
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

        [Authorize]
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

        //[Authorize]
        public ActionResult NicePlaceByCity(long ID)
        {
            try
            {
                ViewBag.CityId = ID;
                vm_Pagination pagination = new vm_Pagination { OrderBy = DL_PlaceColumns.CreatedDate.ToString(), OrderDirection = "DESC" };
                DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
                DL_NicePlaceInfoDetailBAL dlNicePlaceInfoDetailBal = new DL_NicePlaceInfoDetailBAL();
                DL_ImagePlaceBAL dlImagePlaceBal = new DL_ImagePlaceBAL();
                var dlPlace = dlPlaceBal.GetListNicePlaceByCity(ID);
                ViewData["OrderBy"] = pagination.OrderBy;
                ViewData["OrderDirection"] = pagination.OrderDirection;
                var nicePlacePage = new List<NicePlace>();
                for (int index = 0; index < dlPlace.Count(); index++)
                {
                    var tmp = new NicePlace();
                    tmp.dlPlace = dlPlace[index];
                    tmp.dlNicePlaceInfoDetail = dlNicePlaceInfoDetailBal.GetByPlaceId(dlPlace[index].ID);
                    tmp.listImageCity = dlImagePlaceBal.GetByDLPlaceID(dlPlace[index].ID);
                    nicePlacePage.Add(tmp);

                }
                return View(nicePlacePage);
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


        public ActionResult ListImagePlace(long placeId)
        {
            DL_ImagePlaceBAL dlImagePlaceBal = new DL_ImagePlaceBAL();
            var model = dlImagePlaceBal.GetByDLPlaceID(placeId);
            return View(model);
        }



        //[HttpPost]
        //public ActionResult reLoadPage(long cityId, vm_Pagination pagination)
        //{
        //    DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
        //    long totalRecords = 0;
        //    //var model = dlPlaceBal.GetListNicePlaceByCity(cityId).Take(4).ToList();
        //    var model = dlPlaceBal.GetListWithFilter(cityId, "", "", (long)DL_PlaceTypeId.Places, pagination.Page.Value, pagination.PageSize.Value, pagination.OrderBy, pagination.OrderDirection, out totalRecords);
        //    common.LoadPagingData(this, pagination.Page ?? MvcApplication.pageDefault, pagination.PageSize ?? MvcApplication.pageSizeDefault, totalRecords);
        //    ViewData["OrderBy"] = pagination.OrderBy;
        //    ViewData["OrderDirection"] = pagination.OrderDirection;
        //    //DuLichDLL.Model.DL_Place model1 = new DuLichDLL.Model.DL_Place();
        //    return PartialView("p_niceplace", model);
        //}

        //[HttpPost]
        //public ActionResult Loaddata(long ID)
        //{
        //    try
        //    {
        //        vm_Pagination pagination = new vm_Pagination { OrderBy = DL_PlaceColumns.CreatedDate.ToString(), OrderDirection = "DESC" };
        //        DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
        //        DL_NicePlaceInfoDetailBAL dlNicePlaceInfoDetailBal = new DL_NicePlaceInfoDetailBAL();
        //        DL_ImagePlaceBAL dlImagePlaceBal = new DL_ImagePlaceBAL();





        //        //var model = dlPlaceBal.GetListNicePlaceByCity(cityId).Take(4).ToList();
        //        //var model = dlPlaceBal.GetListWithFilter(1, "", "", (long)DL_PlaceTypeId.Places, page, pagesize, pagination.OrderBy, pagination.OrderDirection, out totalRecords);
        //        var dlPlace = dlPlaceBal.GetListNicePlaceByCity(ID);//.Take(3).ToList();

        //        //common.LoadPagingData(this, pagination.Page ?? MvcApplication.pageDefault, pagination.PageSize ?? MvcApplication.pageSizeDefault, totalRecords);
        //        ViewData["OrderBy"] = pagination.OrderBy;
        //        ViewData["OrderDirection"] = pagination.OrderDirection;
        //        var nicePlacePage = new List<NicePlace>();
        //        for (int index = 0; index < dlPlace.Count(); index++)
        //        {
        //            var tmp = new NicePlace();
        //            tmp.dlPlace = dlPlace[index];
        //            tmp.dlNicePlaceInfoDetail = dlNicePlaceInfoDetailBal.GetByPlaceId(dlPlace[index].ID);
        //            tmp.listImageCity = dlImagePlaceBal.GetByDLPlaceID(dlPlace[index].ID);
        //            nicePlacePage.Add(tmp);

        //        }
        //        StringBuilder data = new StringBuilder();
        //        data.Append("<article id=\"foreword\"><section class=\"template-start-7 title-foreword page-1\"><div class=\"page\"><div class=\"page-title\"><h2>Foreword to 20 Things</h2></div><div class=\"image1\"><img src=\"\" data-src=\"css/images/cloud01.png\" /></div><div class=\"left\"><p class=\"drop-cap\">Many of us these days depend on the World Wide Web to bring the world’s information to our fingertips, and put us in touch with people and events across the globe instantaneously.</p></div>\"<div class=\"right\"><p class=\"continuation\">These powerful online experiences are possible thanks to an open web that can be accessed by anyone through a web browser, on any Internet-connected device in the world.</p> </div></div></section></article><article id=\"aaaa\">");
        //        int i = 1;
        //        foreach (var item in nicePlacePage)
        //        {
        //            data.Append("<section class=\"title-" + item.dlPlace.FirstChar + " page-" + i + "\"><div class=\"page\"><div class=\"page-title\"><h2>" + item.dlPlace.Name + "</h2></div><div class=\"image1\"><img src=Data\\avatar\\Place\\" + item.dlPlace.Avatar + "/></div><div class=\"left\"><p class=\"drop-cap\">" + item.dlNicePlaceInfoDetail.Info + item.dlNicePlaceInfoDetail.History + "</p> </div></div></section>");
        //            i++;
        //        }
        //        data.Append("<section class=\" title-aaaa page-" + i + "\"><div class=\"page\"><div class=\"page-title\"><h2></h2></div><div class=\"left\"><p class=\"drop-cap\"></p> </div></div></section>");
        //        data.Append("</article>");

        //        //var data1 = "<section class=\"template-start-7 title-what-is-the-internet page-1\"><div class=\"page\"><div class=\"page-title\"><h2>What is the Internet?</h2><h3>or, \"You Say Tomato, I Say TCP/IP\"</h3></div><div class=\"image1\"><img src=\"\" data-src=\"css/images/internet01.png\" /></div> <div class=\"left\"> 	<p class=\"drop-cap\">What is the Internet, exactly? To some of us, the Internet is where we stay in touch with friends, get the news, shop, and play games. To some others, the Internet can mean their local broadband providers, or the underground wires and fiber-optic cables that</p> </div> <div class=\"right\"> 	<p class=\"continuation\">carry data back and forth across cities and oceans. Who is right?</p> 	<p>A helpful place to start is near the Very Beginning: 1974.  That was the year that a few smart computer researchers invented something called the Internet Protocol Suite, or TCP/IP for</p> </div></div></section><section class=\"template-inner-5 title-what-is-the-internet page-2\"><div class=\"page\">﻿<div class=\"left\">	<p class=\"continuation\">short. TCP/IP created a set of rules that allowed computers to “talk” to each other and send information back and forth.</p>	<p>TCP/IP is somewhat like human communication: when we speak to each other, the rules of grammar provide structure to language and ensure that we can understand each other and exchange ideas. Similarly, TCP/IP provides the rules of communication that ensure interconnected devices understand each other so that they can send information back and forth. As that group of interconnected devices grew from one room to many rooms — and then to many buildings, and then to many cities and countries — the Internet was born.</p></div><div class=\"right\"><p>The early creators of the Internet discovered that data and information could be sent more efficiently when broken into smaller chunks, sent separately, and reassembled. Those chunks are called <strong>packets</strong>.  So when you send an email across the Internet, your full email message is broken down into packets, sent to your recipient, and reassembled. The same thing happens when you watch a video on a website like YouTube: the video files are segmented into data packets that can be sent from multiple YouTube servers around the world and reassembled to form the video that you watch through your browser.</p></div></div></section></article>";

        //        return Json(data.ToString(), JsonRequestBehavior.AllowGet);
        //    }
        //    catch (BusinessException bx)
        //    {
        //        log.Error(bx.Message);
        //        TempData[PageInfo.Message.ToString()] = bx.Message;
        //        return RedirectToAction("Error", "Home");
        //    }
        //    catch (Exception ex)
        //    {
        //        //LogBAL.LogEx("BLM_ERR_Common", ex);
        //        log.Error(ex.Message);
        //        TempData[PageInfo.Message.ToString()] = "BLM_ERR_Common";
        //        return RedirectToAction("Error", "Home");
        //    }
        //}

        [Authorize]
        public ActionResult AddPlace()
        {
            NicePlace model = new NicePlace();
            return View(model);
        }

        [Authorize]
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
                dataRequest.dlPlace.TotalPointRating = 0;
                dataRequest.dlPlace.TotalUserRating = 0;
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

        [Authorize]
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

        [Authorize]
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
        public ActionResult DelNicePlace(long ID)
        {
            try
            {
                bool result = false;
                DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
                var status = 1;
                result = dlPlaceBal.UpdateStatusById(ID, status);

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

        }
        #region

        #endregion
    }
}
