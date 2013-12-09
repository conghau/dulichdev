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
    }
    
    
}
