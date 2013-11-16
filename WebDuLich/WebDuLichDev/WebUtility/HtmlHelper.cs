using DuLichDLL.BAL;
using DuLichDLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

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
        public static bool IsAdmin()
        {
            //if(System.Web.Mvc.AuthorizeAttribute. Roles=="admin"        
            webpages_UsersInRolesBAL userInRoleBal = new webpages_UsersInRolesBAL();
            return userInRoleBal.UserIsAdmin(WebDuLichSecurity.UserID);
        }



    }
}