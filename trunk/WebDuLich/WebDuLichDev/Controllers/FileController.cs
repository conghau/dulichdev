using DuLichDLL.BAL;
using DuLichDLL.TOOLS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDuLichDev.Controllers
{
    public class FileController : Controller
    {


        //public ActionResult UploadAvatarPlace(IEnumerable<HttpPostedFileBase> fileUpload)
        //{
        //    var serserPath = Server.MapPath("~/Data/Avatar/Place/");
        //    foreach (var file in fileUpload)
        //    {
        //        // Some browsers send file names with full path. We only care about the file name.
        //        var fileName = Path.GetFileName(file.FileName);

        //        var destinationPath = Path.Combine(serserPath, fileName);

        //        file.SaveAs(destinationPath);
        //    }
        //    return Json(new { status = "OK" }, "text/plain");

        //}
        public ActionResult RemoveAvatarPlace(string fileNames)
        {
            ProcessWithFiles processfile = new ProcessWithFiles();
            var destinationPath = Path.Combine(Server.MapPath("~/Data/Avatar/Place/"), fileNames);

            processfile.DeleteFile(destinationPath);

            return Json(new { status = "OK" }, "text/plain");

        }
        public ActionResult UploadAvatarPlace(IEnumerable<HttpPostedFileBase> fileUpload, int ID)
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
        

        public ActionResult UploadImagePlace(IEnumerable<HttpPostedFileBase> fileUpload)
        {
            //var serserPath = Server.MapPath("~/Data/Images/Place/");
            List<string> listfilenameGuid = new List<string>() ;
            
            foreach (var file in fileUpload)
            {
                // Some browsers send file names with full path. We only care about the file name.
                //var fileName = Path.GetFileName(file.FileName);
                var fileName =  Guid.NewGuid() + Path.GetExtension(file.FileName);
                var destinationPath = Path.Combine(Server.MapPath("~/Data/Images/Place/"), fileName);

                file.SaveAs(destinationPath);
                listfilenameGuid.Add(fileName);
            }
            return Json(new {dataname=listfilenameGuid}, "text/plain");

        }
        public ActionResult RemoveImagePlace(string fileNames)
        {
            ProcessWithFiles processfile = new ProcessWithFiles();
            var destinationPath = Path.Combine(Server.MapPath("~/Data/Images/Place/"), fileNames);

            processfile.DeleteFile(destinationPath);

            return Json(new { status = "OK" }, "text/plain");

        }



    }
}
