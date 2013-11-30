using Microsoft.Web.WebPages.OAuth;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDuLichDev.Models;
using WebDuLichDev.WebUtility;
using zingme_sdk;
namespace WebDuLichDev.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            if (!String.IsNullOrEmpty(Request.QueryString["code"]))
            {
                var routeValues = this.RouteData.Values;
                var code = Request.QueryString["code"];
                string signedRequestParam = Request.Params["signed_request"];
                //NameValueCollection pColl = context.Request.Params;
                //pColl.GetValue("signed_request");
                //pColl.GetKey(10);
                int expires = 0;

                ZME_Authentication oauth = new ZME_Authentication(WebDuLichDev.RegisterAuthZing.config());
                var access_token = oauth.getAccessTokenFromCode(code, out expires);
                ZME_Me me = new ZME_Me(WebDuLichDev.RegisterAuthZing.config());
                string id = "id";
                string username = "username";
                string gender = "gender";
                string dob = "dob";
                var user_data_id = me.getInfo(access_token, id); //default id vs username
                Hashtable me_info = me.getInfo(access_token, "id,username,displayname,tinyurl,profile_url,gender,dob");//all
                var user_data_username = me.getInfo(access_token, username);
                string user_name = (string)user_data_username[username];

                long user_id = (long)user_data_id[id];
                var me_friend = me.getFriends(access_token);
                using (UsersContext db = new UsersContext())
                {
                    UserProfile user = db.UserProfiles.FirstOrDefault(u => u.UserName.ToLower() == user_name);
                    // Check if user already exists
                    if (user == null)
                    {
                        // Insert name into the profile table
                        UserProfile newUser = db.UserProfiles.Add(new UserProfile { UserName = user_name });
                       
                        //db.ExternalUsers.Add(new ExternalUserInformation
                        //{
                        //    UserId = newUser.UserId,
                        //    FullName = model.FullName,
                        //    Link = model.Link
                        //});
                        // db.UserProfiles.Add(new UserProfile { UserName = model.UserName });
                        db.SaveChanges();

                        OAuthWebSecurity.CreateOrUpdateAccount("ZingMe", user_id.ToString(), user_name);
                        OAuthWebSecurity.Login("ZingMe", user_id.ToString(), createPersistentCookie: false);

                    }
                    else
                    {
                        ModelState.AddModelError("UserName", "User name already exists. Please enter a different user name.");
                    }
                }
            }
            return View();
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Language(string languageCode)
        {
            try
            {
                string url = Request.UrlReferrer.AbsoluteUri;
                WebDuLichSecurity.LanguageCode = languageCode;
                return Redirect(url);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
