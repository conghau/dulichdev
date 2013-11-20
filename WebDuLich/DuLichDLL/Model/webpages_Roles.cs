using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DuLichDLL.Model
{
    public class webpages_Roles
    {
        private int _roleId;
        public int RoleId
        {
            get { return _roleId; }
            set { _roleId = value; }
        }
        private string _roleName;
        public string RoleName
        {
            get { return _roleName; }
            set { _roleName = value; }
        }
    }
    public enum webpages_RolesColumns
    {
        RoleId,
        RoleName,
    }
    public enum webpages_RolesProcedure
    {
        p_webpages_Roles_Insert,
        p_webpages_Roles_Delete,
        p_webpages_Roles_Update,
        p_webpages_Roles_Get_List,
        p_webpages_Roles_Get_ByID,

    }

}