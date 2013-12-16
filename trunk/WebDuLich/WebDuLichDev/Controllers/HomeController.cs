using DuLichDLL.ExceptionType;
using Microsoft.Web.WebPages.OAuth;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDuLichDev.Enum;
using WebDuLichDev.Models;
using WebDuLichDev.WebUtility;
using WebMatrix.WebData;
using zingme_sdk;
namespace WebDuLichDev.Controllers
{
    public class HomeController : BaseController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(PlaceController).Name);
        string version = "Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " ";
        public ActionResult Index()
        {
            //ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            try
            {
                if (!String.IsNullOrEmpty(Request.QueryString["code"]))
                {
                    ZME_Authentication oauth = new ZME_Authentication(WebDuLichDev.RegisterAuthZing.config());
                    ZME_Me me = new ZME_Me(WebDuLichDev.RegisterAuthZing.config());
                    int expires = 0;
                    var routeValues = this.RouteData.Values;
                    string id = "id";
                    string username = "username";
                    string gender = "gender";
                    string dob = "dob";
                    var code = Request.QueryString["code"];
                    var access_token1 = oauth.getAccessTokenFromCode(code, out expires);
                    ZingClient.access_token = access_token1;
      

                    var user_data_id = me.getInfo(access_token1, id); //default id vs username
                    Hashtable me_info = me.getInfo(access_token1, "id,username,displayname,tinyurl,profile_url,gender,dob");//all
                    var user_data_username = me.getInfo(access_token1, username);
                    string user_name = (string)user_data_username[username];

                    long user_id = (long)user_data_id[id];
                    var me_friend = me.getFriends(access_token1);
                    using (UsersContext db = new UsersContext())
                    {
                        UserProfile user = db.UserProfiles.FirstOrDefault(u => u.UserName.ToLower() == user_name);
                        // Check if user already exists
                        if (user == null)
                        {
                            // Insert name into the profile table
                            UserProfile newUser = db.UserProfiles.Add(new UserProfile { UserName = user_name });
                            db.SaveChanges();
                            OAuthWebSecurity.CreateOrUpdateAccount("ZingMe", user_id.ToString(), user_name);
                            OAuthWebSecurity.Login("ZingMe", user_id.ToString(), createPersistentCookie: false);
                        }
                        else
                        {
                            OAuthWebSecurity.Login("ZingMe", user_id.ToString(), createPersistentCookie: false);
                            ModelState.AddModelError("UserName", "User name already exists. Please enter a different user name.");
                            OAuthWebSecurity.Login("ZingMe", user_id.ToString(), createPersistentCookie: false);
                        }
                    }
                    return Redirect("./");
                }
                else
                {
                    if (!String.IsNullOrEmpty(Request.Params["signed_request"]))
                    {
                        ZME_Authentication oauth = new ZME_Authentication(WebDuLichDev.RegisterAuthZing.config());
                        ZME_Me me = new ZME_Me(WebDuLichDev.RegisterAuthZing.config());
                        int expires = 0;
                        var routeValues = this.RouteData.Values;
                        string id = "id";
                        string username = "username";
                        string gender = "gender";
                        string dob = "dob";
                        string signedRequestParam = Request.Params["signed_request"];
                        var access_token1 = oauth.getAccessTokenFromSignedRequest(signedRequestParam, out expires);
                        ZingClient.access_token = access_token1;
                        var user_data_id = me.getInfo(access_token1, id); //default id vs username
                        Hashtable me_info = me.getInfo(access_token1, "id,username,displayname,tinyurl,profile_url,gender,dob");//all
                        var user_data_username = me.getInfo(access_token1, username);
                        string user_name = (string)user_data_username[username];

                        long user_id = (long)user_data_id[id];
                        var me_friend = me.getFriends(access_token1);
                        using (UsersContext db = new UsersContext())
                        {
                            UserProfile user = db.UserProfiles.FirstOrDefault(u => u.UserName.ToLower() == user_name);
                            // Check if user already exists
                            if (user == null)
                            {
                                // Insert name into the profile table
                                UserProfile newUser = db.UserProfiles.Add(new UserProfile { UserName = user_name });
                                db.SaveChanges();
                                OAuthWebSecurity.CreateOrUpdateAccount("ZingMe", user_id.ToString(), user_name);
                                OAuthWebSecurity.Login("ZingMe", user_id.ToString(), createPersistentCookie: false);
                            }
                            else
                            {
                                //WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
                                ModelState.AddModelError("UserName", "User name already exists. Please enter a different user name.");
                                OAuthWebSecurity.Login("ZingMe", user_id.ToString(), createPersistentCookie: false);
                            }
                        }

                    }
                }
                return View();
            }
            catch (BusinessException bx)
            {
                log.Error(bx.Message);
                TempData[PageInfo.Message.ToString()] = bx.Message;
                return RedirectToAction("Error", "Home");
            }
            catch (Exception ex)
            {
                //LogBAL.LogEx("BLM_ERR_Common", ex);
                log.Error(ex.Message);
                TempData[PageInfo.Message.ToString()] = "BLM_ERR_Common";
                return RedirectToAction("Error", "Home");
            }

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
