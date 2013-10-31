using DuLichDLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDuLichDev.Models
{
    public class NicePlace
    {
        public DL_Place dlPlace { get; set; }
        public DL_NicePlaceInfoDetail dlNicePlaceInfoDetail { get; set; }
        public List<DL_ImagePlace> listImageCity { get; set; }
    }
    public class City
    {
        [AllowHtml]
        public DL_City dlCity { get; set; }
        public DL_CityInfoDetail dlCityInfoDetail { get; set; }
      
    }
}
