using BloodBank.Comman;
using BloodBank.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.DataAccess
{
    public class ErrorCodeDAL
    {
        private readonly AppDb _appDb;

        public ErrorCodeDAL(AppDb appDb)
        {
            _appDb = appDb;
        }

        public List<GetErrorMassageByErrroCodeListDTO> GetErrorMassageByErrroCode(long ErrorCode)
        {
            List<GetErrorMassageByErrroCodeListDTO> lstGetErrorMassageByErrroCodeListDTO = null;
            SqlConnection connection = new SqlConnection(_appDb.Connectionstring);

            using (SqlCommand cmd = new SqlCommand("uspGetErrorMassageByErrorCode", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.BigInt)).Value = ErrorCode;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables.Count > 0) {

                        lstGetErrorMassageByErrroCodeListDTO = ds.Tables[0].ToList<GetErrorMassageByErrroCodeListDTO>();
                    }
                }
                if (lstGetErrorMassageByErrroCodeListDTO != null && lstGetErrorMassageByErrroCodeListDTO.Count > 0)
                {
                    return lstGetErrorMassageByErrroCodeListDTO;
                }
                else
                {
                    return null;
                }
            }

        }
    }
}

