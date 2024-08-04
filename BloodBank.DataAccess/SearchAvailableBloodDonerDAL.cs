using BloodBank.Comman;
using BloodBank.Properties;
using System.Data;
using System.Data.SqlClient;
using System;

namespace BloodBank.DataAccess
{
    public class SearchAvailableBloodDonerDAL
    {
        private readonly AppDb _appDb;

        public SearchAvailableBloodDonerDAL(AppDb appDb)
        {
            _appDb = appDb;
        }

        #region Search Available Blood Doner

        public async Task<List<SearchAvailableBloodDonerListDTO>> AvailableBloodDoner(Request objRequest)
        {
            List<SearchAvailableBloodDonerListDTO> lstSearchAvailableBloodDonerListDTO = null;

            SqlConnection connection = new SqlConnection(_appDb.Connectionstring);

            await connection.OpenAsync();

            using (SqlCommand cmd = new SqlCommand("uspSearchAvailableBloodDoner", connection))
            {
                cmd.Parameters.Add("@StateId", SqlDbType.BigInt).Value = objRequest.StateId;
                cmd.Parameters.Add("@BloodGroupId", SqlDbType.BigInt).Value = objRequest.BloodGroupId;
                cmd.Parameters.Add("@CityId", SqlDbType.BigInt).Value = objRequest.CityId;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = objRequest.CityId;
                cmd.Parameters.Add("@DonerId", SqlDbType.BigInt).Value = objRequest.CityId;


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    lstSearchAvailableBloodDonerListDTO = ds.Tables[0].ToList<SearchAvailableBloodDonerListDTO>();
                }

                if (lstSearchAvailableBloodDonerListDTO != null && lstSearchAvailableBloodDonerListDTO.Count > 0)
                {
                    return lstSearchAvailableBloodDonerListDTO;
                }
                else
                {
                    return null;
                }
            };      
            

        }
        #endregion Search Available Blood Doner 

        #region Get Blood Group

        public async  Task<List<GetBloodGroupListDTO>> GetBloodGroup()
        {
            List<GetBloodGroupListDTO> lstGetBloodGroupListDTO = null;

            SqlConnection connection = new SqlConnection(_appDb.Connectionstring);

             await connection.OpenAsync();

            using (SqlCommand cmd = new SqlCommand("uspGetGetBloodGroup", connection))
            {
               
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    lstGetBloodGroupListDTO = ds.Tables[0].ToList<GetBloodGroupListDTO>();
                }

                if (lstGetBloodGroupListDTO != null && lstGetBloodGroupListDTO.Count > 0)
                {
                    return lstGetBloodGroupListDTO;
                }
                else
                {
                    return null;
                }
            };


        }
        #endregion Get Blood Group

        #region Get State

        public async Task<List<StatelistDTO>> GetState()
        {
            List<StatelistDTO> lstStatelistDTO = null;

            SqlConnection connection = new SqlConnection(_appDb.Connectionstring);

            await connection.OpenAsync();

            using (SqlCommand cmd = new SqlCommand("uspGetState", connection))
            { 
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    lstStatelistDTO  = ds.Tables[0].ToList<StatelistDTO>();
                }

                if (lstStatelistDTO != null && lstStatelistDTO.Count > 0)
                {
                    return lstStatelistDTO;
                }
                else
                {
                    return null;
                }
            };


        }
        #endregion

        #region Get City

        public async Task<List<CityListDTO>> GetCityByStateId(long StateId)
        {
            List<CityListDTO> lstCityListDTO = null;

            SqlConnection connection = new SqlConnection(_appDb.Connectionstring);

            await connection.OpenAsync();

            using (SqlCommand cmd = new SqlCommand("uspGetCityByStateId", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@StateId", SqlDbType.BigInt).Value = StateId;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    lstCityListDTO = ds.Tables[0].ToList<CityListDTO>();
                }

                if (lstCityListDTO != null && lstCityListDTO.Count > 0)
                {
                    return lstCityListDTO;
                }
                else
                {
                    return null;
                }
            };


        }
        #endregion Search Available Blood Doner 



    }
}
