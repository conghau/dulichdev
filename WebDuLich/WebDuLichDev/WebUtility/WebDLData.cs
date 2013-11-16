using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuLichDLL.BAL;
using DuLichDLL.Model;
using DuLichDLL.Utility;
using WebMatrix.WebData;

namespace WebDuLichDev.WebUtility
{
    public class WebDuLichData
    {
        public static List<SelectListItem> ListCity
        {
            get
            {
                DL_CityBAL dlCityBal = new DL_CityBAL();
                List<SelectListItem> listCity = new List<SelectListItem>();

                listCity.Add(new SelectListItem { Text = Resources.Language.ChooseCity +"...", Value = "-1" });

                var dlCity = dlCityBal.GetList();

                foreach (var item in dlCity)
                {
                    listCity.Add(new SelectListItem
                    {
                        Text = item.CityName,
                        Value = item.ID.ToString(),
                    });
                }
                return listCity;
            }
        }

        public static string PathAvatarDefault
        {
            get
            {
                string pathAvatarDefault;
                M_SystemSetting_Config mSystemSetting = new M_SystemSetting_Config();
                M_SystemSettingBAL mSystemSettingBal = new M_SystemSettingBAL();

                mSystemSetting = mSystemSettingBal.GetSystemSetting();
                pathAvatarDefault = mSystemSetting.AVATAR_DEFAULT;

                return pathAvatarDefault;
            }

        }

        //private void SetPath()
        //{
        //    M_SystemSetting_Config mSystemSetting = new M_SystemSetting_Config();
        //    M_SystemSettingBAL mSystemSettingBal = new M_SystemSettingBAL();

        //    mSystemSetting = mSystemSettingBal.GetSystemSetting();
        //    pathAvatarCity = mSystemSetting.PATH_AVATAR_CITY;
        //    pathImageCity = mSystemSetting.PATH_IMAGE_CITY;
        //} 
    }

    public class WebDuLichSecurity
    {
        private static string _userId = "UserId";
        private static string _menu = "Menu";
        public static bool UserIsAdmin = false;

        public static long UserID
        {
            get
            {
                long userId = Utility.ObjectToLong(HttpContext.Current.Session[_userId]);
                return userId;
            }
        }
        //Get main menu
        public static string Menu
        {
            get
            {
                return Utility.ObjectToString(HttpContext.Current.Session[_menu]);
            }
            set
            {
                HttpContext.Current.Session[_menu] = value;
            }
        }

        public static bool Login(string userName, string passWord, bool rememberme)
        {
            if (WebSecurity.Login(userName, passWord, rememberme))
            {
                UserProfileBAL useprofileBal = new UserProfileBAL();
                var userProfile = useprofileBal.GetByUserName(userName);
                HttpContext.Current.Session[_userId] = userProfile.UserId;
                return true;//return RedirectToLocal(returnUrl);
            }
            else
                return false;
        }
    }
}
