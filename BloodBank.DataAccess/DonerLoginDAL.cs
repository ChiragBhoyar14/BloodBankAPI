using BloodBank.Comman;
using BloodBank.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.DataAccess
{
    public class DonerLoginDAL
    {
        private readonly AppDb _appDb;

        public DonerLoginDAL(AppDb appDb)
        {
            _appDb = appDb;
        }

        public async Task<List<DonerLoginListDTO>> GetLoginDonerDetails(LoginListDTO objLoginListDTO)
        {
            List<DonerLoginListDTO> lstDonerLoginListDTO = null;
            SqlConnection connection = new SqlConnection(_appDb.Connectionstring);

            using (SqlCommand cmd = new SqlCommand("uspGetUserCrediantials", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar)).Value = objLoginListDTO.UserName;
                cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar)).Value = objLoginListDTO.Password;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables.Count > 0)
                    {

                        lstDonerLoginListDTO = ds.Tables[0].ToList<DonerLoginListDTO>();
                    }
                }
                if (lstDonerLoginListDTO != null && lstDonerLoginListDTO.Count > 0)
                {
                    return lstDonerLoginListDTO;
                }
                else
                {
                    return null;
                }
            }

        }

    }
}
