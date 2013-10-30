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

namespace WebDuLichDev.Controllers
{
    public class CityController : Controller
    {
        //
        // GET: /City/
        static string pathAvatarCity = "";
        static string pathImageCity = "";

        private void SetPath()
        {
            M_SystemSetting_Config mSystemSetting = new M_SystemSetting_Config();
            M_SystemSettingBAL mSystemSettingBal = new M_SystemSettingBAL();

            mSystemSetting = mSystemSettingBal.GetSystemSetting();
            pathAvatarCity = mSystemSetting.PATH_AVATAR_CITY;
            pathImageCity = mSystemSetting.PATH_IMAGE_CITY;
        }
        public ActionResult Index()
        {
            DL_CityBAL dlCityBal = new DL_CityBAL();

            SetPath();

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
            float avg = 0;
            int total = 0;
            try
            {
                DL_CommentCityBAL dlCommentCityBal = new DL_CommentCityBAL();
                DL_CityBAL dlCityBal = new DL_CityBAL();

                DL_City dlCity = new DL_City();
                DL_CommentCity dlCommentCity = new DL_CommentCity
                {
                    UserId = userId,
                    Content = "",
                    Rating = rate,
                    Status = 0,
                    DL_CityId = cityId,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                };

                dlCity = dlCityBal.GetByID(cityId);
                dlCity.TotalPointRating = dlCity.TotalPointRating + rate;
                dlCity.TotalUserRating = dlCity.TotalUserRating + 1;
                avg = (float)dlCity.TotalPointRating / (float)dlCity.TotalUserRating;
                dlCity.AvgRating = avg;

                success = dlCityBal.InsertRating(dlCity, dlCommentCity);
                //success = db.RegisterProductVote(userId, id, rate);
                total = dlCity.TotalUserRating ?? 0;
                ViewBag.AVG = avg;
            }
            catch (System.Exception ex)
            {
                // get last error
                if (ex.InnerException != null)
                    while (ex.InnerException != null)
                        ex = ex.InnerException;

                error = ex.Message;
            }

            return Json(new { error = error, success = success, pid = cityId, Avg = avg, Total = total }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail(long ID)
        {
            DL_CityBAL dlCityBal = new DL_CityBAL();

            SetPath();
            ViewBag.pathAvatarCity = pathAvatarCity;
            ViewBag.pathImageCity = pathImageCity;
            var model = dlCityBal.GetByID(ID);
            return View(model);
        }

        public ActionResult AddCity()
        {
            return View();
        }
        public ActionResult SetCityID(long cityID)
        {
            ViewBag.CityNew = cityID;
            return Redirect("././");
        }
        public ActionResult Restar(long cityId)
        {
            float Avg = 0;
            DL_CommentCityBAL dlCommentCityBal = new DL_CommentCityBAL();
            DL_CityBAL dlCityBal = new DL_CityBAL();

            DL_City dlCity = new DL_City();

            dlCity = dlCityBal.GetByID(cityId);

            dlCity.TotalUserRating = dlCity.TotalUserRating;
            Avg = (float)dlCity.AvgRating;

            return PartialView("~/Views/Shared/_Rate.cshtml", dlCity);

        }
        public ActionResult AddNewCity(DL_City dataRequestCity)
        {

            return View(dataRequestCity);
        }

        public ActionResult SomeAction(EncodeModel myModel)
        {
            var Editor = myModel.Editor;
            Editor = Server.HtmlDecode(Editor);
            //Save to db, etc.
            return View(myModel);
        }

        public ActionResult UploadAvatarCity(IEnumerable<HttpPostedFileBase> fileUpload, int cityId)
        {
            DL_CommentCityBAL dlCommentCityBal = new DL_CommentCityBAL();
            DL_CityBAL dlCityBal = new DL_CityBAL();

            DL_City dlCity = new DL_City();

            dlCity = dlCityBal.GetByID(cityId);
            var id =dlCity;

            var serserPath = Server.MapPath("~/Data/Avatar/City/");
            if (System.IO.File.Exists(serserPath + fileUpload)) //Xóa file có trước nếu đã có trong csdl. Việc up là duy nhất
                System.IO.File.Delete(serserPath + fileUpload);
            foreach (var file in fileUpload)
            {
                // Some browsers send file names with full path. We only care about the file name.
                var fileName = Path.GetFileName(file.FileName);

                var destinationPath = Path.Combine(serserPath, fileName);

                file.SaveAs(destinationPath);
            }
            return Json(new { status = "OK" }, "text/plain");
        }

        public ActionResult RemoveAvatarCity(string fileNames, int cityId)
        {
            ProcessWithFiles processfile = new ProcessWithFiles();
            var destinationPath = Path.Combine(Server.MapPath("~/Data/Avatar/City/"), fileNames);

            processfile.DeleteFile(destinationPath);

            return Json(new { status = "OK" }, "text/plain");

        }
    }
}
