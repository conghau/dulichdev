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
using WebDuLichDev.WebUtility;
using zingme_sdk;

namespace WebDuLichDev.Controllers
{

    public class ZingController : BaseController
    {
        public ActionResult Invite()
        {
            ZME_Config zme_config = RegisterAuthZing.config();

            ZME_Social zmeSocial = new ZME_Social(zme_config);
            // zmeSocial.invite();
            return View();
        }
        [HttpPost]
        public ActionResult PostNoticeRate(int rate, string placeName)
        {
            ZME_Config zme_config = RegisterAuthZing.config();
            ZME_Me zmeMe = new ZME_Me(zme_config);
            if(null == ZingClient.access_token)
                return Json(new {result = false});
            Hashtable me_info = zmeMe.getInfo(ZingClient.access_token, "id,username");
            ZME_Social zmeSocial = new ZME_Social(zme_config);
            string title = me_info["username"].ToString() + "rating for " + placeName + "is " + rate.ToString();
            ZME_Feed zmeFeed = new ZME_Feed(me_info["username"].ToString(),title, null,null,null,null);
            zmeSocial.post(ZingClient.access_token, zmeFeed, false);
            return Json(new { result = true});
        }
    }
    
    
}
