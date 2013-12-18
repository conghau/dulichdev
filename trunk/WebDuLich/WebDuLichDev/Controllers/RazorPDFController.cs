using DotNetOpenAuth.AspNet;
using DotNetOpenAuth.AspNet.Clients;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using zingme_sdk;
using DuLichDLL.BAL;
using WebDuLichDev.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using WebDuLichDev.WebUtility;
using System.Web.Mvc.Html;
using System.Net.Mail;
using iTextSharp.text.html.simpleparser;
using System.Web.UI;
namespace WebDuLichDev.Controllers
{

    public class RazorPDFController : Controller
    {
        private static string placeName="";
        public ActionResult Pdf(long ID)
        {
            DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
            DL_NicePlaceInfoDetailBAL dlNicePlaceInfoDetailBal = new DL_NicePlaceInfoDetailBAL();
            DL_ImagePlaceBAL dlImagePlaceBal = new DL_ImagePlaceBAL();

            var tmp = new vm_NicePlace();
            tmp.dlPlace = dlPlaceBal.GetByID(ID);
            tmp.dlNicePlaceInfoDetail = dlNicePlaceInfoDetailBal.GetByPlaceId(tmp.dlPlace.ID);
            tmp.listImagePlace = dlImagePlaceBal.GetByDLPlaceID(tmp.dlPlace.ID);

            placeName = tmp.dlPlace.Name;

            return View(tmp);
          
        }
        
        
        public ActionResult Pdf_Post(long ID, string urlBase)
        {
            string url = urlBase+"/RazorPDF/pdf/" + ID;
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();
            sr.Close();
            myResponse.Close();

            PDFFactory.GeneratePDF(result, placeName + DateTime.Now.ToShortDateString());
          
            return View();

        }
    }
}

    
