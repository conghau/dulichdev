using DuLichDLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDuLichDev.WebUtility
{
    public class Helper
    {
        public static List<DL_ImagePlace> ExceptAB(List<DL_ImagePlace> A, List<DL_ImagePlace> B)
        {
            var R=A.Except(B).ToList();
            try
            {                
                return R;
               
            }
            catch (SystemException ex)
            {
                throw new SystemException(ex.Message);
            }
            
        }
        
    }
}