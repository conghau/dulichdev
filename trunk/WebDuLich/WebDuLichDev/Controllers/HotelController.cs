﻿using DuLichDLL.Model;
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

        public ActionResult AddHotel(long ID)
        {
            DL_HotelPlaceInfoDetailBAL hotelInfoBal = new DL_HotelPlaceInfoDetailBAL();

            var model = hotelInfoBal.GetByDLPlaceID(ID);
            
            return View(model);
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
            listdlImangePlace=dlImagePlaceBal.GetByDLPlaceID(ID);
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
            if (null != imagePlace)
            {
                for (int index = 0; index < imagePlace.Count(); index++)
                {
                    DL_ImagePlace temp = new DL_ImagePlace();
                    temp.LinkImage = imagePlace[index];
                    listdlImangePlace.Add(temp);
                }
            }
            hotelinfo.dlPlace.DL_PlaceTypeId = (long)DL_PlaceTypeId.Places;
            hotelinfo.listImagePlace = listdlImangePlace;
            dlPlaceBal.UpdateHotel(hotelinfo.dlPlace, hotelinfo.dlHotelPlaceInfoDetail, hotelinfo.listImagePlace);
            return View(hotelinfo);
        }

        [HttpPost]
        public ActionResult AddHotel(DL_Place data)
        {
            return View(data);
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
        public ActionResult UploadAvatar(IEnumerable<HttpPostedFileBase> fileUpload, int ID)
        {
            //HotelInfo hotelinfo = new HotelInfo();
            DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
            //hotelinfo.dlPlace = dlPlaceBal.GetByID(ID);

            var serserPath = Server.MapPath("~/Data/Avatar/Place/");
            if (System.IO.File.Exists(serserPath + dlPlaceBal.GetByID(ID).Avatar)) //Xóa file có trước nếu đã có trong csdl. Việc up là duy nhất
                System.IO.File.Delete(serserPath + dlPlaceBal.GetByID(ID).Avatar);
            foreach (var file in fileUpload)
            {
                // Some browsers send file names with full path. We only care about the file name.
                var fileName = Path.GetFileName(file.FileName);

                var destinationPath = Path.Combine(serserPath, fileName);

                file.SaveAs(destinationPath);
            }
            return Json(new { status = "OK" }, "text/plain");

        }
        public ActionResult RemoveAvatar(string fileNames, int cityId)
        {
            ProcessWithFiles processfile = new ProcessWithFiles();
            var destinationPath = Path.Combine(Server.MapPath("~/Data/Avatar/Place/"), fileNames);

            processfile.DeleteFile(destinationPath);

            return Json(new { status = "OK" }, "text/plain");

        }

    }
}