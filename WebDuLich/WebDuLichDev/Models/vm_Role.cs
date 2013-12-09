using DuLichDLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDuLichDev.Models
{
    public class vm_Role
    {
        public webpages_Roles Role { get; set; }
        public List<A_Function> ListFunction { get; set; }
        public List<A_Object> ListObject { get; set; }
        public List<A_ObjectFunction> ListObjectFunction { get; set; }
        public List<A_AssignedPermission> ListAssignPermission { get; set; }
    }

    //public class vm_Function
    //{
    //    public long ID { get; set; }
    //    public long FnName { get; set; }
    //    public bool isChecked { get; set; }
    //}

    //public class vm_Object
    //{
    //    public long ID { get; set; }
    //    public string ObName { get; set; }
    //    public List<vm_Function> ListFunction { get; set; }
    //}

    public class ObjectParent
    {
        public string ObjectParentName { get; set; }
        public List<A_Object> ListObject { get; set; }
    }

    public class vm_EditRole
    {
        public long FunctionId { get; set; }
        public long ObjectId { get; set; }
        public bool Checked { get; set; }
    }
}