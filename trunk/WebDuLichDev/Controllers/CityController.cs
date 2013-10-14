using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuLichDLL.BAL;
using DuLichDLL.Model;

namespace WebDuLichDev.Controllers
{
    public class CityController : Controller
    {
        //
        // GET: /City/
        static string pathAvatarCity = "";
        static string pathImageCity = "";

        public ActionResult Index()
        {
            DL_CityBAL dlCityBal = new DL_CityBAL();
            M_SystemSetting_Config mSystemSetting = new M_SystemSetting_Config();
            M_SystemSettingBAL mSystemSettingBal = new M_SystemSettingBAL();

            mSystemSetting = mSystemSettingBal.GetSystemSetting();
            pathAvatarCity = mSystemSetting.PATH_AVATAR_CITY;
            pathImageCity = mSystemSetting.PATH_IMAGE_CITY;

            ViewBag.pathAvatarCity = pathAvatarCity;
            ViewBag.pathImageCity = pathImageCity;

            var model = dlCityBal.GetList();
            return View(model);
        }


        public ActionResult RateProduct(long cityId, int rate)
        {
            long userId = 142; // WebSecurity.CurrentUserId;
            bool success = false;
            string error = "";
            int avg = 0;
            int total = 0;
            try
            {
                DL_CommentCityBAL dlCommentCityBal = new DL_CommentCityBAL();
                DL_CityBAL dlCityBal = new DL_CityBAL();

                DL_City dlCity = new DL_City();
                DL_CommentCity dlCommentCity = new DL_CommentCity
                {
                    UserId = userId,
                    Content ="",
                    Rating=rate,
                    Status=0,
                    DL_CityId = cityId,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                };

                dlCity = dlCityBal.GetByID(cityId);
                dlCity.TotalPointRating = dlCity.TotalPointRating + rate;
                dlCity.TotalUserRating = dlCity.TotalUserRating + 1;
                dlCity.AvgRating = (int)(dlCity.TotalPointRating / dlCity.TotalUserRating);

                success = dlCityBal.InsertRating(dlCity, dlCommentCity);
                //success = db.RegisterProductVote(userId, id, rate);
                avg=Convert.ToInt32(dlCity.AvgRating);
                total = Convert.ToInt32(dlCity.TotalUserRating);
            }
            catch (System.Exception ex)
            {
                // get last error
                if (ex.InnerException != null)
                    while (ex.InnerException != null)
                        ex = ex.InnerException;

                error = ex.Message;
            }

            return Json(new { error = error, success = success, pid = cityId, Avg= avg, Total=total }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult LoadRateProduct(long cityId)
        {
            long userId = 142; // WebSecurity.CurrentUserId;
            bool success = false;
            string error = "";
            int  Avg = 0;
            try
            {
                DL_CommentCityBAL dlCommentCityBal = new DL_CommentCityBAL();
                DL_CityBAL dlCityBal = new DL_CityBAL();

                DL_City dlCity = new DL_City();
                DL_CommentCity dlCommentCity = new DL_CommentCity();
                //{
                //    UserId = userId,
                //    Content = "",
                    
                //    Status = 0,
                //    DL_CityId = cityId,
                //    CreatedDate = DateTime.Now,
                //    UpdatedDate = DateTime.Now,
                //};

                dlCity = dlCityBal.GetByID(cityId);
              
                dlCity.TotalUserRating = dlCity.TotalUserRating;
               

                //success = dlCityBal.InsertRating(dlCity, dlCommentCity);
                //success = db.RegisterProductVote(userId, id, rate);
                Avg = Convert.ToInt32(dlCity.AvgRating);

            }
            catch (System.Exception ex)
            {
                // get last error
                if (ex.InnerException != null)
                    while (ex.InnerException != null)
                        ex = ex.InnerException;

                error = ex.Message;
            }

            return Json(new { error = error, success = success, pid = cityId, avg = Avg }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Detail(long ID)
        {
            DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
            var model = dlPlaceBal.GetListByCity(ID);
            return View(model);
        }

    }
}
