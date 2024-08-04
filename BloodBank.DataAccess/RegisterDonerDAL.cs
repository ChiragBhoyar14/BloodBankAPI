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
    public class RegisterDonerDAL
    {
        private readonly AppDb _appDb;

        public RegisterDonerDAL(AppDb appDb)
        {
            _appDb = appDb;
        }


        public  async Task<int> RegisterDoner(RegisterDonerListDTO objRegisterDonerListDTO)
        {
            int intReturn = 0;

            SqlConnection connection = new SqlConnection(_appDb.Connectionstring);

            await connection.OpenAsync();

            SqlCommand cmd = new SqlCommand("uspInsertDonerDetails", connection);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = objRegisterDonerListDTO.Name;
            cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = objRegisterDonerListDTO.DateOfBirth;
            cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = objRegisterDonerListDTO.Gender;
            cmd.Parameters.Add("@StateId", SqlDbType.Int).Value = objRegisterDonerListDTO.StateId;
            cmd.Parameters.Add("@CityId", SqlDbType.Int).Value = objRegisterDonerListDTO.CityId;
            cmd.Parameters.Add("@BloodGroupId", SqlDbType.Int).Value = objRegisterDonerListDTO.BloodGroupId;
            cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = objRegisterDonerListDTO.Mobile;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = objRegisterDonerListDTO.Email;
            cmd.Parameters.Add("@IsPublished", SqlDbType.Bit).Value = objRegisterDonerListDTO.IsPublished;
            
            if (string.IsNullOrEmpty(objRegisterDonerListDTO.PublishedBy))
            {
                cmd.Parameters.Add("@PublishedBy", SqlDbType.NVarChar).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add("@PublishedBy", SqlDbType.NVarChar).Value = objRegisterDonerListDTO.PublishedBy;
            }
            if (string.IsNullOrEmpty(objRegisterDonerListDTO.Address))
            {
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = DBNull.Value;
            }
            {
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = objRegisterDonerListDTO.Address;
            }
            if (objRegisterDonerListDTO.LastDonationDate == DateTime.MinValue || objRegisterDonerListDTO.LastDonationDate == null)
            {
                cmd.Parameters.Add("@LastDonationDate", SqlDbType.Date).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add("@LastDonationDate", SqlDbType.Date).Value = objRegisterDonerListDTO.LastDonationDate;
            }
            cmd.Parameters.Add("@HighSugarStatus", SqlDbType.Int).Value = objRegisterDonerListDTO.HighSugarStatusId;
            cmd.Parameters.Add("@HighBPStatus", SqlDbType.Int).Value = objRegisterDonerListDTO.HighBPStatusId;
            cmd.Parameters.Add("@IsAvailable", SqlDbType.Bit).Value = objRegisterDonerListDTO.IsAvailable;


            intReturn = cmd.ExecuteNonQuery();

           await connection.CloseAsync();

            return intReturn;

        }
    }
}
