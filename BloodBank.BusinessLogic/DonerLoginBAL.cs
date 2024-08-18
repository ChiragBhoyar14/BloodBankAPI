using BloodBank.Comman;
using BloodBank.DataAccess;
using BloodBank.Properties;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BloodBank.BusinessLogic
{
    public class DonerLoginBAL
    {
        public readonly AppDb _appDb;
        private readonly JWD _jwd;


        public DonerLoginBAL(AppDb appDb, JWD jwd)
        {
            _appDb = appDb;
            _jwd = jwd;
        }
        public async Task<Response<ResponseLoginListDTO>> DonerLogin(LoginListDTO objLoginListDTO)
        {
            int Error = 0;
            Response<ResponseLoginListDTO> objResponse = new Response<ResponseLoginListDTO>();
            List<DonerLoginListDTO> objDonerLoginListDTO = null;
            ResponseLoginListDTO objResponseLoginListDTO = new ResponseLoginListDTO();

            try
            {
                if (Error == 0)
                {
                    if (!string.IsNullOrEmpty(objLoginListDTO.UserName))
                    {
                        if (!Regex.IsMatch(objLoginListDTO.UserName, @"^[a-zA-Z0-9._$@]{3,20}$"))
                        {
                            Error = 22;
                        }
                    }
                }
                else
                {
                    Error = 23;
                }

                if (Error == 0)
                {
                    if (!string.IsNullOrEmpty(objLoginListDTO.Password))
                    {
                        if (!Regex.IsMatch(objLoginListDTO.Password, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=])[^\s]{8,12}$"))
                        {
                            Error = 20;
                        }
                        else
                        {
                            objLoginListDTO.Password = General.EncryptString(objLoginListDTO.Password, _appDb.Key, _appDb.IV);
                        }

                    }
                    else
                    {
                        Error = 19;
                    }

                }

                if (Error == 0)
                {
                    DonerLoginDAL objDonerLoginDAL = new DonerLoginDAL(_appDb);
                    objDonerLoginListDTO = await objDonerLoginDAL.GetLoginDonerDetails(objLoginListDTO);

                    if (objDonerLoginListDTO != null && objDonerLoginListDTO.Count > 0)
                    {
                        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwd.Key));
                        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                        var claims = new[]
                        {
                    new Claim(ClaimTypes.NameIdentifier,objDonerLoginListDTO[0].Name),
                    new Claim(ClaimTypes.Role,objDonerLoginListDTO[0].Role)
                };

                        var token = new JwtSecurityToken(_jwd.Issuer,
                            _jwd.Audience,
                            claims,
                            expires: DateTime.Now.AddMinutes(_jwd.ExpiryTime),
                            signingCredentials: credentials);

                        objResponseLoginListDTO.JWTToken = new JwtSecurityTokenHandler().WriteToken(token);

                        if (!string.IsNullOrEmpty(objResponseLoginListDTO.JWTToken))
                        {
                            objResponse.Status = "Success";
                            objResponse.StatusCode = 200;
                            objResponse.Data = objResponseLoginListDTO;
                        }
                    }
                    else
                    {
                        objResponse.StatusCode = 404;
                        objResponse.Status = "Invalid UserName or Password";
                    }
                }

            }
            catch (Exception ex)
            {
                objResponse.StatusCode = 500;
                objResponse.Status = "An error occurred while processing your request: " + ex.Message;
            }
            finally
            {
                objLoginListDTO = null;
                objDonerLoginListDTO = null;
                objResponseLoginListDTO = null;
            }

            return objResponse;
        }

    }
}
