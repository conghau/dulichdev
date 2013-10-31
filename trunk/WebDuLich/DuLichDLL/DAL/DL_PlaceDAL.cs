using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DuLichDLL.Model;
using System.Data.SqlClient;
using System.Data;
using DuLichDLL.ExceptionType;
using DuLichDLL.Enum;
using DuLichDLL.TOOLS;
namespace DuLichDLL.DAL
{
    public class DL_PlaceDAL
    {
        private DL_Place ConvertOneRow(DataRow row)
        {
            try
            {
                DL_Place result = new DL_Place();
                result.ID = Utility.Utility.ObjectToLong(row[DL_PlaceColumns.ID.ToString()].ToString());
                result.DL_CityId = Utility.Utility.ObjectToLong(row[DL_PlaceColumns.DL_CityId.ToString()].ToString());
                result.DL_PlaceTypeId = Utility.Utility.ObjectToLong(row[DL_PlaceColumns.DL_PlaceTypeId.ToString()].ToString());
                result.Name = Utility.Utility.ObjectToString(row[DL_PlaceColumns.Name.ToString()].ToString());
                result.Address = Utility.Utility.ObjectToString(row[DL_PlaceColumns.Address.ToString()].ToString());
                result.Avatar = Utility.Utility.ObjectToString(row[DL_PlaceColumns.Avatar.ToString()].ToString());
                result.AvgRating = Utility.Utility.ObjectToInt(row[DL_PlaceColumns.AvgRating.ToString()].ToString());
                result.TotalUserRating = Utility.Utility.ObjectToString(row[DL_PlaceColumns.TotalUserRating.ToString()].ToString());
                result.TotalPointRating = Utility.Utility.ObjectToString(row[DL_PlaceColumns.TotalPointRating.ToString()].ToString());
                result.CreatedDate = Utility.Utility.ObjectToDateTime(row[DL_PlaceColumns.CreatedDate.ToString()].ToString());
                result.CreatedBy = Utility.Utility.ObjectToLong(row[DL_PlaceColumns.CreatedBy.ToString()].ToString());
                result.Status = Utility.Utility.ObjectToInt(row[DL_PlaceColumns.Status.ToString()].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: ConvertOneRow"));
            }
        }
        private List<DL_Place> GetDataObject(DataTable dt)
        {
            List<DL_Place> results = new List<DL_Place>();
            foreach (DataRow item in dt.Rows)
            {
                results.Add(ConvertOneRow(item));
            }
            return results;
        }
        public DL_Place GetByID(long ID)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_PlaceProcedure.p_DL_Place_Get_ByID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<DL_Place> results = GetDataObject(dt);
                DL_Place dL_Place = new DL_Place();
                if (results.Count > 0)
                {
                    dL_Place = results[0];
                }
                return dL_Place;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: GetByID"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<DL_Place> GetList()
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_PlaceProcedure.p_DL_Place_Get_List.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                var results = GetDataObject(dt);
                return results;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: GetList"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<DL_Place> GetListByCity(long cityId)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_PlaceProcedure.p_DL_Place_Get_ByCityID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CityID", SqlDbType.BigInt).Value = cityId;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                var results = GetDataObject(dt);
                return results;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: GetListByCity"));
            }
            finally
            {
                cnn.Close();
            }
        }

        public List<DL_Place> GetListNicePlaceByCity(long cityId)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_PlaceProcedure.p_DL_Place_Get_NicePlaceByCityID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CityID", SqlDbType.BigInt).Value = cityId;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                var results = GetDataObject(dt);
                return results;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: GetListNicePlaceByCity"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<DL_Place> GetListRestautantsByCity(long cityId)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_PlaceProcedure.p_DL_Place_Get_RestaurantByCityID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CityID", SqlDbType.BigInt).Value = cityId;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                var results = GetDataObject(dt);
                return results;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: GetListRestautantsByCity"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<DL_Place> GetListHotelByCity(long cityId)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_PlaceProcedure.p_DL_Place_Get_HotelByCityID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CityID", SqlDbType.BigInt).Value = cityId;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                var results = GetDataObject(dt);
                return results;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: GetListHotelByCity"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(DL_Place dL_Place)
        {
            long id = 0;
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_PlaceProcedure.p_DL_Place_Insert.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DL_CityId", SqlDbType.BigInt).Value = dL_Place.DL_CityId;
                cmd.Parameters.Add("@DL_PlaceTypeId", SqlDbType.BigInt).Value = dL_Place.DL_PlaceTypeId;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = dL_Place.Name;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = dL_Place.Address;
                cmd.Parameters.Add("@Avatar", SqlDbType.NVarChar).Value = dL_Place.Avatar;
                cmd.Parameters.Add("@AvgRating", SqlDbType.Int).Value = dL_Place.AvgRating;
                cmd.Parameters.Add("@TotalUserRating", SqlDbType.Char).Value = dL_Place.TotalUserRating;
                cmd.Parameters.Add("@TotalPointRating", SqlDbType.Char).Value = dL_Place.TotalPointRating;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.BigInt).Value = dL_Place.CreatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_Place.Status;
                SqlParameterCollection parameterValues = cmd.Parameters;
                int i = 0;
                foreach (SqlParameter parameter in parameterValues)
                {
                    if ((parameter.Direction != ParameterDirection.Output) && (parameter.Direction != ParameterDirection.ReturnValue))
                    {
                        if (parameter.Value == null)
                            parameter.Value = DBNull.Value;
                        i++;
                    }
                }
                id = Utility.Utility.ObjectToLong(cmd.ExecuteScalar());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: Insert"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(DL_Place dL_Place, SqlConnection cnn, SqlTransaction tran)
        {
            long id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(DL_PlaceProcedure.p_DL_Place_Insert.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DL_CityId", SqlDbType.BigInt).Value = dL_Place.DL_CityId;
                cmd.Parameters.Add("@DL_PlaceTypeId", SqlDbType.BigInt).Value = dL_Place.DL_PlaceTypeId;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = dL_Place.Name;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = dL_Place.Address;
                cmd.Parameters.Add("@Avatar", SqlDbType.NVarChar).Value = dL_Place.Avatar;
                cmd.Parameters.Add("@AvgRating", SqlDbType.Int).Value = dL_Place.AvgRating;
                cmd.Parameters.Add("@TotalUserRating", SqlDbType.Char).Value = dL_Place.TotalUserRating;
                cmd.Parameters.Add("@TotalPointRating", SqlDbType.Char).Value = dL_Place.TotalPointRating;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.BigInt).Value = dL_Place.CreatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_Place.Status;
                SqlParameterCollection parameterValues = cmd.Parameters;
                foreach (SqlParameter parameter in parameterValues)
                {
                    if ((parameter.Direction != ParameterDirection.Output) && (parameter.Direction != ParameterDirection.ReturnValue))
                    {
                        if (parameter.Value == null)
                            parameter.Value = DBNull.Value;
                    }
                }
                id = Utility.Utility.ObjectToLong(cmd.ExecuteScalar());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: Insert"));
            }
        }
        public long Update(DL_Place dL_Place)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_PlaceProcedure.p_DL_Place_Update.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = dL_Place.ID;
                cmd.Parameters.Add("@DL_CityId", SqlDbType.BigInt).Value = dL_Place.DL_CityId;
                cmd.Parameters.Add("@DL_PlaceTypeId", SqlDbType.BigInt).Value = dL_Place.DL_PlaceTypeId;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = dL_Place.Name;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = dL_Place.Address;
                cmd.Parameters.Add("@Avatar", SqlDbType.NVarChar).Value = dL_Place.Avatar;
                cmd.Parameters.Add("@AvgRating", SqlDbType.Int).Value = dL_Place.AvgRating;
                cmd.Parameters.Add("@TotalUserRating", SqlDbType.Char).Value = dL_Place.TotalUserRating;
                cmd.Parameters.Add("@TotalPointRating", SqlDbType.Char).Value = dL_Place.TotalPointRating;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_Place.Status;
                SqlParameterCollection parameterValues = cmd.Parameters;
                int i = 0;
                foreach (SqlParameter parameter in parameterValues)
                {
                    if ((parameter.Direction != ParameterDirection.Output) && (parameter.Direction != ParameterDirection.ReturnValue))
                    {
                        if (parameter.Value == null)
                            parameter.Value = DBNull.Value;
                        i++;
                    }
                }
                object result = cmd.ExecuteScalar();
                if (result != null)
                    id = Utility.Utility.ObjectToLong(result.ToString());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: Update"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Update(DL_Place dL_Place, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(DL_PlaceProcedure.p_DL_Place_Update.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = dL_Place.ID;
                cmd.Parameters.Add("@DL_CityId", SqlDbType.BigInt).Value = dL_Place.DL_CityId;
                cmd.Parameters.Add("@DL_PlaceTypeId", SqlDbType.BigInt).Value = dL_Place.DL_PlaceTypeId;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = dL_Place.Name;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = dL_Place.Address;
                cmd.Parameters.Add("@Avatar", SqlDbType.NVarChar).Value = dL_Place.Avatar;
                cmd.Parameters.Add("@AvgRating", SqlDbType.Int).Value = dL_Place.AvgRating;
                cmd.Parameters.Add("@TotalUserRating", SqlDbType.Char).Value = dL_Place.TotalUserRating;
                cmd.Parameters.Add("@TotalPointRating", SqlDbType.Char).Value = dL_Place.TotalPointRating;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_Place.Status;
                SqlParameterCollection parameterValues = cmd.Parameters;
                int i = 0;
                foreach (SqlParameter parameter in parameterValues)
                {
                    if ((parameter.Direction != ParameterDirection.Output) && (parameter.Direction != ParameterDirection.ReturnValue))
                    {
                        if (parameter.Value == null)
                            parameter.Value = DBNull.Value;
                        i++;
                    }
                }
                object result = cmd.ExecuteScalar();
                if (result != null)
                    id = Utility.Utility.ObjectToLong(result.ToString());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_PlaceProcedure.p_DL_Place_Delete.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = userID;
                SqlParameterCollection parameterValues = cmd.Parameters;
                int i = 0;
                foreach (SqlParameter parameter in parameterValues)
                {
                    if ((parameter.Direction != ParameterDirection.Output) && (parameter.Direction != ParameterDirection.ReturnValue))
                    {
                        if (parameter.Value == null)
                            parameter.Value = DBNull.Value;
                        i++;
                    }
                }
                object result = cmd.ExecuteScalar();
                if (result != null)
                    id = Utility.Utility.ObjectToLong(result.ToString());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: Delete"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Delete(long ID, long userID, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(DL_PlaceProcedure.p_DL_Place_Delete.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = userID;
                SqlParameterCollection parameterValues = cmd.Parameters;
                int i = 0;
                foreach (SqlParameter parameter in parameterValues)
                {
                    if ((parameter.Direction != ParameterDirection.Output) && (parameter.Direction != ParameterDirection.ReturnValue))
                    {
                        if (parameter.Value == null)
                            parameter.Value = DBNull.Value;
                        i++;
                    }
                }
                object result = cmd.ExecuteScalar();
                if (result != null)
                    id = Utility.Utility.ObjectToLong(result.ToString());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: Delete"));
            }
        }

        public bool InsertNicePlace(DL_Place dlPlace, DL_NicePlaceInfoDetail dlNicePlaceDetail, List<DL_ImagePlace> dlImagePlace)
        {
            SqlConnection cnn = null;
            SqlTransaction tran = null;
            bool result = false;
            try
            {
                DL_NicePlaceInfoDetailDAL dlNicePlaceDetailDAL = new DL_NicePlaceInfoDetailDAL();
                DL_ImagePlaceDAL dlImageDAL = new DL_ImagePlaceDAL();
                long placeId = 0;
                cnn = DataProvider.OpenConnection();
                tran = cnn.BeginTransaction();

                //insert Place
                placeId = Insert(dlPlace, cnn, tran);

                //set DLPlaceID for NicePlaceInfo
                dlNicePlaceDetail.DL_PlaceId = placeId;
                dlNicePlaceDetail.Staus = 0;
                //insert NicePlaceInfo
                dlNicePlaceDetailDAL.Insert(dlNicePlaceDetail, cnn, tran);

                //insert ImagePlace
                if(null != dlImagePlace)
                {
                    for (int index = 0; index < dlImagePlace.Count; index++)
                    {
                        dlImagePlace[index].DL_PlaceID = placeId;
                        dlImagePlace[index].Status = 0;
                        dlImageDAL.Insert(dlImagePlace[index], cnn, tran);
                    }
                }

                tran.Commit();
                return result = true;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
                
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: InsertNicePlace"));
            }
            finally
            {
                tran.Dispose();
                cnn.Close();
            }
        }
    }
}