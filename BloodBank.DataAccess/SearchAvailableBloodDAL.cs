using BloodBank.Comman;
using BloodBank.Properties;
using System.Data;
using System.Data.SqlClient;
using System;

namespace BloodBank.DataAccess
{
    public class SearchAvailableBloodDAL
    {
        private readonly AppDb _appDb;

        public SearchAvailableBloodDAL(AppDb appDb)
        {
            _appDb = appDb;
        }

        public async Task<List<AvailableBloodListDTO>> AvailableBlood(Request objRequest)
        {
            List<AvailableBloodListDTO> lstAvailableBloodListDTO = null;

            SqlConnection connection = new SqlConnection(_appDb.Connectionstring);

            await connection.OpenAsync();

            using (SqlCommand cmd = new SqlCommand("uspSearchAvailableBlood", connection))
            {
                cmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = objRequest.State;
                cmd.Parameters.Add("@BloodGroup", SqlDbType.NVarChar).Value = objRequest.BloodGroup;
                cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = objRequest.City;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    lstAvailableBloodListDTO = ds.Tables[0].ToList<AvailableBloodListDTO>();
                }

                if (lstAvailableBloodListDTO != null && lstAvailableBloodListDTO.Count > 0)
                {
                    return lstAvailableBloodListDTO;
                }
                else
                {
                    return null;
                }
            };      
            

        }
    }
}
