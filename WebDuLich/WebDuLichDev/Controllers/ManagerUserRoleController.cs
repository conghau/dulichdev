using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDuLichDev.Models;
using DuLichDLL.Model;
using WebDuLichDev.Filters;
using DuLichDLL.Utility;
using WebDuLichDev.WebUtility;
using DuLichDLL.BAL;
using System.Web.Security;
namespace WebDuLichDev.Controllers
{
    public class ManagerUserRoleController : BaseController
    {
        //
        // GET: /ManagerUserRole/

        public ActionResult Manage()
        {
            webpages_RolesBAL wpRolesBAL = new webpages_RolesBAL();
            var model = wpRolesBAL.GetList();
            return View(model);
        }

        //
        // GET: /ManagerUserRole/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /ManagerUserRole/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ManagerUserRole/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ManagerUserRole/Edit/5

        public ActionResult Edit(int roleId)
        {
            ManagerUserRole manageUserRole = new ManagerUserRole();
            UserProfileBAL userProfileBAL = new UserProfileBAL();
            
            webpages_UsersInRolesBAL wpUserInRolesBAL = new webpages_UsersInRolesBAL();
            var userlist = userProfileBAL.GetList();
            var inrole = wpUserInRolesBAL.GetList();
            webpages_RolesBAL roleBal = new webpages_RolesBAL();
            var roleName = roleBal.GetByID(roleId).RoleName;
            List <DLUserProfile> userlistinrole = new List<DLUserProfile>();
            List <DLUserProfile> userlistnotinrole = new List<DLUserProfile>(); 
            foreach (var user in userlist)
            {               
                var i = 0;
                foreach (var roleitem in inrole)
                {                   
                    if ((roleitem.RoleId==roleId)&(user.UserId == roleitem.UserId))
                    {
                        userlistinrole.Add(user);
                        //i++;
                    }
                    else
                    { 
                        i++; 
                        if (i==inrole.Count())
                            userlistnotinrole.Add(user);
                    }                        
                }
            }
            userlistinrole.ToList();            
            manageUserRole.listUserProfile = userlistinrole;           
            manageUserRole.listwpUserInRoles = wpUserInRolesBAL.GetList();
            manageUserRole.listUserProfileNotInRole = userlistnotinrole;

            ViewBag.RoleId = roleId;
            ViewBag.RoleName = roleName;
            var model = manageUserRole;
            return View(model);
        }
        [HttpPost]
        public ActionResult AddUser(int roleId,int[] UserID)
        {
            //lay duoc userID can gan
            //update lai role cho UserId
            UserProfileBAL userProfileBAL = new UserProfileBAL();  
            webpages_UsersInRolesBAL wpUserInRoleBal = new webpages_UsersInRolesBAL();

            if(null != UserID)
            {
                for(int index =0; index < UserID.Count(); index++)
                {
                    webpages_UsersInRoles userinRole = new webpages_UsersInRoles
                    {
                        UserId = UserID[index],
                        RoleId = roleId,
                    };                   
                    wpUserInRoleBal.UpdateRoleforUser(userinRole);
                }
            }
            return RedirectToAction("Edit", new { roleId = roleId });
        }

        [HttpPost]
        public ActionResult DelUser(long roleId, int[] UserID)
        {
            webpages_UsersInRolesBAL wpUserInRoleBal = new webpages_UsersInRolesBAL();
            if (null != UserID)
            {
                for (int index = 0; index < UserID.Count(); index++)
                {
                 
                    wpUserInRoleBal.Delete(UserID[index]);
                }
            }
            return RedirectToAction("Edit", new { roleId = roleId });
        }
        //
        // POST: /ManagerUserRole/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ManagerUserRole/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /ManagerUserRole/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
