using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDuLichDev.WebUtility
{
    public class common
    {
        public static void LoadPagingData(System.Web.Mvc.Controller controller, int page, int pageSize, long totalRecords)
        {
            try
            {
                controller.ViewData["Page"] = page;
                controller.ViewData["PageSize"] = pageSize;
                double PageNum = Math.Ceiling((double)totalRecords / pageSize);
                controller.ViewData["PageNum"] = PageNum;
                controller.ViewData["TotalRecord"] = totalRecords;

                if (totalRecords > 0)
                {
                    if (page == PageNum)
                        controller.ViewData["PageInfo"] = string.Format(GetResourceValue("PageInfo"), (((page - 1) * pageSize) + 1).ToString(), totalRecords.ToString(), totalRecords.ToString());
                    else
                        controller.ViewData["PageInfo"] = string.Format(GetResourceValue("PageInfo"), (((page - 1) * pageSize) + 1).ToString(), (pageSize * page).ToString(), totalRecords.ToString());
                }
            }
            catch
            {
                throw;
            }
        }
        public static string GetResourceValue(string resourceName)
        {
            string value = string.Empty;

            value = DuLichDLL.Utility.Utility.ObjectToString(HttpContext.GetGlobalResourceObject("Language", resourceName));
            if (string.IsNullOrWhiteSpace(value))
            {
                value = resourceName;
            }

            return value;
        }
    }
}