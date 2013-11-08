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
using DuLichDLL.Model;


namespace WebDuLichDev.Controllers
{
    public class RestaurantController : Controller
    {
        //
        // GET: /Restaurant/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddRestaurant()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult AddRestaurant(RestaurantInfo restaurantinfo, string[] imagePlace)
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
            restaurantinfo.dlPlace.DL_PlaceTypeId = (long)DL_PlaceTypeId.Restaurants;
            restaurantinfo.listImagePlace = listdlImangePlace;
            restaurantinfo.dlPlace.TotalPointRating = "0";
            restaurantinfo.dlPlace.TotalUserRating = "0";
            dlPlaceBal.InsertRestaurant(restaurantinfo.dlPlace, restaurantinfo.dlRestaurantInfoDetail, restaurantinfo.listImagePlace);
            return Redirect("./UpdateRestaurant/" + restaurantinfo.dlPlace.ID);
        }
        public ActionResult UpdateRestaurant(long ID)
        {
            RestaurantInfo restaurantinfo = new RestaurantInfo();
            DL_RestaurantInfoDetailBAL restaurantInfoBal = new DL_RestaurantInfoDetailBAL();
            DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
            DL_ImagePlaceBAL dlImagePlaceBal = new DL_ImagePlaceBAL();
            List<DL_ImagePlace> listdlImangePlace = new List<DL_ImagePlace>();
            restaurantinfo.dlRestaurantInfoDetail = restaurantInfoBal.GetByDLPlaceID(ID);
            restaurantinfo.dlPlace = dlPlaceBal.GetByID(ID);
            listdlImangePlace = dlImagePlaceBal.GetByDLPlaceID(ID);
            restaurantinfo.listImagePlace = listdlImangePlace;
            var model = restaurantinfo;

            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateRestaurant(RestaurantInfo restaurantinfo, string[] imagePlace)
        {
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
            listdlImangePlace = dlImageBal.GetByDLPlaceID(restaurantinfo.dlPlace.ID);
            foreach (var i in restaurantinfo.listImagePlace)
            {
                if (i.Status == 1)
                    dlImageBal.Update(i);
                else
                {
                    i.Status = 0;
                    dlImageBal.Update(i);
                }
            }
            restaurantinfo.dlPlace.DL_PlaceTypeId = (long)DL_PlaceTypeId.Restaurants;
            dlPlaceBal.UpdateRestaurant(restaurantinfo.dlPlace, restaurantinfo.dlRestaurantInfoDetail, listdlImangePlaceTempNew);
            return View(restaurantinfo);
        }
 
    }
}
