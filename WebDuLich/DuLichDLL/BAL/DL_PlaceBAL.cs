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
    public class DL_PlaceBAL
    {
        public DL_Place GetByID(long ID)
        {
            try
            {
                DL_PlaceDAL dL_PlaceDAL = new DL_PlaceDAL();
                return dL_PlaceDAL.GetByID(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceBAL: GetByID"));
            }
        }

        public List<DL_Place> GetListByCity(long CityId)
        {
            try
            {
                DL_PlaceDAL dL_PlaceDAL = new DL_PlaceDAL();
                return dL_PlaceDAL.GetListByCity(CityId);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceBAL: GetListByCity"));
            }
        }

        public List<DL_Place> GetListNicePlaceByCity(long CityId)
        {
            try
            {
                DL_PlaceDAL dL_PlaceDAL = new DL_PlaceDAL();
                return dL_PlaceDAL.GetListNicePlaceByCity(CityId);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceBAL: GetListNicePlaceByCity"));
            }
        }

        public List<DL_Place> GetListRestaurantsPlaceByCity(long CityId)
        {
            try
            {
                DL_PlaceDAL dL_PlaceDAL = new DL_PlaceDAL();
                return dL_PlaceDAL.GetListRestautantsByCity(CityId);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceBAL: GetListRestautantsByCity"));
            }
        }

        public List<DL_Place> GetListHotelByCity(long CityId)
        {
            try
            {
                DL_PlaceDAL dL_PlaceDAL = new DL_PlaceDAL();
                return dL_PlaceDAL.GetListHotelByCity(CityId);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceBAL: GetListHotelByCity"));
            }
        }
        public List<DL_Place> GetList()
        {
            try
            {
                DL_PlaceDAL dL_PlaceDAL = new DL_PlaceDAL();
                var result = dL_PlaceDAL.GetList();
                return result;

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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceBAL: GetList"));
            }
        }

        public List<DL_Place> GetListWithFilter(long cityId, string placeName, long placeType, int page, int pageSize, string orderBy, string orderDirection, out long totalRecords)
        {
            try
            {
                DL_PlaceDAL dL_PlaceDAL = new DL_PlaceDAL();
                var result = dL_PlaceDAL.GetListWithFilter(cityId, placeName, placeType, page, pageSize ,orderBy,orderDirection, out totalRecords);
                return result;

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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceBAL: GetListWithFilter"));
            }
        }

        public long Insert(DL_Place dL_Place)
        {
            try
            {
                DL_PlaceDAL dL_PlaceDAL = new DL_PlaceDAL();
                return dL_PlaceDAL.Insert(dL_Place);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceBAL: Insert"));
            }
        }
        public long Update(DL_Place dL_Place)
        {
            try
            {
                DL_PlaceDAL dL_PlaceDAL = new DL_PlaceDAL();
                return dL_PlaceDAL.Update(dL_Place);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceBAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            try
            {
                DL_PlaceDAL dL_PlaceDAL = new DL_PlaceDAL();
                return dL_PlaceDAL.Delete(ID, userID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceBAL: Delete"));
            }
        }

        public bool InsertNicePlace(DL_Place dlPlace, DL_NicePlaceInfoDetail dlNicePlaceDetail, List<DL_ImagePlace> dlImagePlace)
        {
            try
            {
                DL_PlaceDAL dL_PlaceDAL = new DL_PlaceDAL();
                return dL_PlaceDAL.InsertNicePlace(dlPlace, dlNicePlaceDetail, dlImagePlace);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceBAL: InsertNicePlace"));
            }
        }
    }
}