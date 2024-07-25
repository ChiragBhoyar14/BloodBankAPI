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
    }
}
