using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuLichDLL.BAL;
using DuLichDLL.Model;

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
}
