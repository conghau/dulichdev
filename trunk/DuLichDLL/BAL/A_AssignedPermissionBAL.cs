using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DuLichDLL.Model;
using DuLichDLL.DAL;
using DuLichDLL.ExceptionType;
using DuLichDLL.Enum;
using System.Data;
using System.Configuration;
namespace DuLichDLL.BAL
{
public class A_AssignedPermissionBAL
{
public A_AssignedPermission GetByID(long ID)
{
try
{
A_AssignedPermissionDAL a_AssignedPermissionDAL = new A_AssignedPermissionDAL();
return a_AssignedPermissionDAL.GetByID(ID);
}
catch (DataAccessException ex)
{
throw new BusinessException(ex.Message);
}
catch (BusinessException ex)
{
throw new BusinessException(ex.Message);
}
catch (Exception ex)
{
throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_AssignedPermissionBAL: GetByID"));
}
}
public List<A_AssignedPermission> GetList()
{
try
{
A_AssignedPermissionDAL a_AssignedPermissionDAL = new A_AssignedPermissionDAL();
return a_AssignedPermissionDAL.GetList();
}
catch (DataAccessException ex)
{
throw new BusinessException(ex.Message);
}
catch (BusinessException ex)
{
throw new BusinessException(ex.Message);
}
catch (Exception ex)
{
throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_AssignedPermissionBAL: GetList"));
}
}
public long Insert(A_AssignedPermission a_AssignedPermission)
{
try
{
A_AssignedPermissionDAL a_AssignedPermissionDAL = new A_AssignedPermissionDAL();
return a_AssignedPermissionDAL.Insert(a_AssignedPermission);
}
catch (DataAccessException ex)
{
throw new BusinessException(ex.Message);
}
catch (BusinessException ex)
{
throw new BusinessException(ex.Message);
}
catch (Exception ex)
{
throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_AssignedPermissionBAL: Insert"));
}
}
public long Update(A_AssignedPermission a_AssignedPermission)
{
try
{
A_AssignedPermissionDAL a_AssignedPermissionDAL = new A_AssignedPermissionDAL();
return a_AssignedPermissionDAL.Update(a_AssignedPermission);
}
catch (DataAccessException ex)
{
throw new BusinessException(ex.Message);
}
catch (BusinessException ex)
{
throw new BusinessException(ex.Message);
}
catch (Exception ex)
{
throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_AssignedPermissionBAL: Update"));
}
}
public long Delete(long ID,long userID)
{
try
{
A_AssignedPermissionDAL a_AssignedPermissionDAL = new A_AssignedPermissionDAL();
return a_AssignedPermissionDAL.Delete(ID, userID);
}
catch (DataAccessException ex)
{
throw new BusinessException(ex.Message);
}
catch (BusinessException ex)
{
throw new BusinessException(ex.Message);
}
catch (Exception ex)
{
throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_AssignedPermissionBAL: Delete"));
}
}
}
}