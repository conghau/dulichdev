using DuLichDLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDuLichDev.Models;
using DuLichDLL.BAL;
using DuLichDLL.TOOLS;
using WebDuLichDev.WebUtility;
using System.IO;


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
            vm_Pagination pagination = new vm_Pagination
            {
                Page = MvcApplication.pageDefault,
                PageSize = MvcApplication.pageSizeDefault,
                OrderBy = DL_PlaceColumns.CreatedDate.ToString(),
                OrderDirection = "DESC",

            };
            long totalRecords = 0;

            DL_PlaceBAL dlPlaceBAL = new DL_PlaceBAL();
            var model = dlPlaceBAL.GetListWithFilter(cityId, "", "", (long)DL_PlaceTypeId.Hotels, pagination.Page.Value, pagination.PageSize.Value, pagination.OrderBy, pagination.OrderDirection, out totalRecords);

            common.LoadPagingData(this, pagination.Page ?? MvcApplication.pageDefault, pagination.PageSize ?? MvcApplication.pageSizeDefault, totalRecords);
            ViewData["OrderBy"] = pagination.OrderBy;
            ViewData["OrderDirection"] = pagination.OrderDirection;

            return View(model);
        }


        public ActionResult AddHotel()
        {
            //ViewBag.NewPlaceID = ID;
            return View();
        }

        [HttpPost]
        public ActionResult AddHotel(HotelInfo hotelinfo, string[] imagePlace)
        {
            DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
            List<DL_ImagePlace> listdlImangePlace = new List<DL_ImagePlace>();
            if (null != imagePlace)
            {
                for (int index = 0; index < imagePlace.Count(); index++)
                {
                    DL_ImagePlace temp = new DL_ImagePlace();
                    temp.LinkImage = imagePlace[index];
                    listdlImangePlace.Add(temp);
                }
            }
            hotelinfo.dlPlace.DL_PlaceTypeId = (long)DL_PlaceTypeId.Hotels;
            hotelinfo.listImagePlace = listdlImangePlace;
            hotelinfo.dlPlace.TotalPointRating = "0";
            hotelinfo.dlPlace.TotalUserRating = "0";
            dlPlaceBal.InsertHotel(hotelinfo.dlPlace, hotelinfo.dlHotelPlaceInfoDetail, hotelinfo.listImagePlace);
            return Redirect("./UpdateHotel/" + hotelinfo.dlPlace.ID);

        }
        public ActionResult UpdateHotel(long ID)
        {
            HotelInfo hotelinfo = new HotelInfo();
            DL_HotelPlaceInfoDetailBAL hotelInfoBal = new DL_HotelPlaceInfoDetailBAL();
            DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
            DL_ImagePlaceBAL dlImagePlaceBal = new DL_ImagePlaceBAL();
            List<DL_ImagePlace> listdlImangePlace = new List<DL_ImagePlace>();
            hotelinfo.dlHotelPlaceInfoDetail = hotelInfoBal.GetByDLPlaceID(ID);
            hotelinfo.dlPlace = dlPlaceBal.GetByID(ID);
            listdlImangePlace = dlImagePlaceBal.GetByDLPlaceID(ID);
            hotelinfo.listImagePlace = listdlImangePlace;
            var model = hotelinfo;

            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateHotel(HotelInfo hotelinfo, string[] imagePlace)
        {
            //DL_HotelPlaceInfoDetailBAL hotelInfoBal = new DL_HotelPlaceInfoDetailBAL();


            //DL_HotelPlaceInfoDetailBAL hotelInfoBal = new DL_HotelPlaceInfoDetailBAL();
            DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
            List<DL_ImagePlace> listdlImangePlace = new List<DL_ImagePlace>();
            List<DL_ImagePlace> listdlImangePlaceTemp = new List<DL_ImagePlace>();
            List<DL_ImagePlace> listdlImangePlaceTempNew = new List<DL_ImagePlace>();
            DL_ImagePlaceBAL dlImageBal = new DL_ImagePlaceBAL();
            if (null != imagePlace)
            {
                for (int index = 0; index < imagePlace.Count(); index++)
                {
                    DL_ImagePlace temp = new DL_ImagePlace();
                    temp.LinkImage = imagePlace[index];
                    listdlImangePlaceTempNew.Add(temp);
                }
            }
            listdlImangePlace = dlImageBal.GetByDLPlaceID(hotelinfo.dlPlace.ID);
            foreach (var i in hotelinfo.listImagePlace)
            {
                if (i.Status == 1)
                    dlImageBal.Update(i);
                else
                {
                    i.Status = 0;
                    dlImageBal.Update(i);
                }
            }
            hotelinfo.dlPlace.DL_PlaceTypeId = (long)DL_PlaceTypeId.Hotels;
            dlPlaceBal.UpdateHotel(hotelinfo.dlPlace, hotelinfo.dlHotelPlaceInfoDetail, listdlImangePlaceTempNew);
            return View(hotelinfo);
        }
    }
}
