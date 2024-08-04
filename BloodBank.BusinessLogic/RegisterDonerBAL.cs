using BloodBank.Comman;
using BloodBank.DataAccess;
using BloodBank.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BloodBank.BusinessLogic
{
    public class RegisterDonerBAL
    {
        private readonly AppDb _appDb;

        public RegisterDonerBAL(AppDb appDb)
        {
            _appDb = appDb;
        }


        public async Task<Response<string>> RegisterDoner(RequestRegisterDonerListDTO objRequestRegisterDonerListDTO)
        {
            Response<string> objResponse = new Response<string>();
            RegisterDonerDAL objRegisterDonerDAL = null;
            SearchAvailableBloodDonerDAL objSearchAvailableBloodDonerDAL =new SearchAvailableBloodDonerDAL(_appDb);
            List<GetBloodGroupListDTO> lstGetBloodGroupListDTO = null;
            List<StatelistDTO> lstStatelistDTO = null;
            List<CityListDTO> lstCityListDTO = null;
            ErrorCodeDAL objErrorCodeDAL = null;
            List<GetErrorMassageByErrroCodeListDTO> lstGetErrorMassageByErrroCode = null;
            RegisterDonerListDTO objRegisterDonerListDTO =new RegisterDonerListDTO();
            long Error = 0;
            int intResult = 0;

            try
            {
                if (objRequestRegisterDonerListDTO != null)
                {
                    if (Error == 0)
                    {

                        if (objRequestRegisterDonerListDTO.Name != null)
                        {
                            if (!Regex.IsMatch(objRequestRegisterDonerListDTO.Name, "^[a-zA-Z\\s]+$"))
                            {
                                Error = 2;
                            }
                            else
                            {
                                objRegisterDonerListDTO.Name = objRequestRegisterDonerListDTO.Name;
                            }
                        }
                        else
                        {
                            Error = 6;
                        }
                    }

                    if (Error == 0)
                    {
                        if (!String.IsNullOrWhiteSpace(objRequestRegisterDonerListDTO.BloodGroup))
                        {
                            lstGetBloodGroupListDTO = await objSearchAvailableBloodDonerDAL.GetBloodGroup();

                            if (lstGetBloodGroupListDTO != null && lstGetBloodGroupListDTO.Count > 0)
                            {
                                var Result = lstGetBloodGroupListDTO.FirstOrDefault(x => x.BloodGroup == objRequestRegisterDonerListDTO.BloodGroup);

                                if (Result != null)
                                {
                                    objRegisterDonerListDTO.BloodGroupId = Result.BloodGroupId;
                                }
                                else
                                {
                                    Error = 8;
                                }
                            }
                        }
                        else
                        {
                            Error = 7;
                        }
                    }

                    if (Error == 0)
                    {
                        if (!String.IsNullOrWhiteSpace(objRequestRegisterDonerListDTO.State))
                        {
                            lstStatelistDTO = await objSearchAvailableBloodDonerDAL.GetState();

                            if (lstStatelistDTO != null && lstStatelistDTO.Count > 0)
                            {
                                var Result = lstStatelistDTO.FirstOrDefault(x => x.State == objRequestRegisterDonerListDTO.State);

                                if (Result != null)
                                {
                                    objRegisterDonerListDTO.StateId = Result.StateId;
                                }
                                else
                                {
                                    Error = 4;
                                }
                            }
                        }
                        else
                        {
                            Error = 9;
                        }
                    }

                    if (Error == 0)
                    {
                        if (!String.IsNullOrWhiteSpace(objRequestRegisterDonerListDTO.City) && objRegisterDonerListDTO.StateId > 0)
                        {
                            lstCityListDTO = await objSearchAvailableBloodDonerDAL.GetCityByStateId(objRegisterDonerListDTO.StateId);

                            if (lstCityListDTO != null && lstCityListDTO.Count > 0)
                            {
                                var Result = lstCityListDTO.FirstOrDefault(x => x.City == objRequestRegisterDonerListDTO.City);

                                if (Result != null)
                                {
                                    objRegisterDonerListDTO.CityId = Result.CityId;
                                }
                                else
                                {
                                    Error = 5;
                                }

                            }
                        }
                    }
                    
                    if (Error == 0)
                    {
                        if (objRequestRegisterDonerListDTO.DateOfBirth != DateTime.MinValue)
                        {
                            if (objRequestRegisterDonerListDTO.DateOfBirth <= DateTime.Now)
                            {
                                if (objRequestRegisterDonerListDTO.DateOfBirth > DateTime.Now.AddYears(-18))
                                {
                                    Error = 11;
                                }
                                else
                                {
                                    objRegisterDonerListDTO.DateOfBirth = objRequestRegisterDonerListDTO.DateOfBirth;
                                }

                            }
                            else
                            {
                                Error = 10;
                            }
                        }
                        else
                        {
                            Error = 12;
                        }
                    }
                    if (Error == 0)
                    {
                        if (objRequestRegisterDonerListDTO.Gender != null)
                        {
                            if ((objRequestRegisterDonerListDTO.Gender).ToLower() == "male")
                            {
                                objRegisterDonerListDTO.Gender = "Male";
                            }
                            else if ((objRequestRegisterDonerListDTO.Gender).ToLower() == "female")
                            {
                                objRegisterDonerListDTO.Gender = "Female";
                            }
                            else if ((objRequestRegisterDonerListDTO.Gender).ToLower() == "other")
                            {
                                objRegisterDonerListDTO.Gender = "other";
                            }
                            else
                            {
                                Error = 13;
                            }
                        }

                    }

                    if (Error == 0)
                    {
                        if (!String.IsNullOrWhiteSpace(objRequestRegisterDonerListDTO.Mobile))
                        {
                            if (!Regex.IsMatch(objRequestRegisterDonerListDTO.Mobile, @"^(?:\+91|91)?[789]\d{9}$"))
                            {
                                Error = 14;
                            }
                            else
                            {
                                objRegisterDonerListDTO.Mobile = objRequestRegisterDonerListDTO.Mobile;
                            }
                        }
                        else
                        {
                            Error = 15;
                        }
                    }

                    if (Error == 0)
                    {
                        if (!String.IsNullOrWhiteSpace(objRequestRegisterDonerListDTO.Email))
                        {
                            if (!Regex.IsMatch(objRequestRegisterDonerListDTO.Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                            {
                                Error = 16;
                            }
                            else
                            {
                                objRegisterDonerListDTO.Email = objRequestRegisterDonerListDTO.Email;
                            }
                        }
                    }
                    if (Error == 0)
                    {
                        if (!String.IsNullOrWhiteSpace(objRequestRegisterDonerListDTO.LastDonationDate.ToString()))
                        {
                            if (objRequestRegisterDonerListDTO.LastDonationDate < DateTime.Now.AddMonths(-6))
                            {
                                objRegisterDonerListDTO.IsAvailable = true;
                                objRegisterDonerListDTO.LastDonationDate = Convert.ToDateTime(objRequestRegisterDonerListDTO.LastDonationDate);
                            }
                            else
                            {
                                objRegisterDonerListDTO.IsAvailable = false;
                                objRegisterDonerListDTO.LastDonationDate = Convert.ToDateTime(objRequestRegisterDonerListDTO.LastDonationDate);
                            }
                        }
                        else
                        {
                            objRegisterDonerListDTO.IsAvailable = true;
                            objRegisterDonerListDTO.LastDonationDate = null;
                        }
                    }
                    if(Error == 0)
                    {
                        if (!String.IsNullOrWhiteSpace(objRequestRegisterDonerListDTO.HighSugarStatus))
                        {
                            if (objRequestRegisterDonerListDTO.HighSugarStatus == (General.HealthStatus.Low).ToString())
                            {
                                objRegisterDonerListDTO.HighSugarStatusId = (int)(General.HealthStatus.Low);
                            }
                            else if (objRequestRegisterDonerListDTO.HighSugarStatus == (General.HealthStatus.Normal).ToString())
                            {
                                objRegisterDonerListDTO.HighSugarStatusId = (int)(General.HealthStatus.Normal);
                            }
                            else if (objRequestRegisterDonerListDTO.HighSugarStatus == (General.HealthStatus.High).ToString())
                            {
                                objRegisterDonerListDTO.HighSugarStatusId = (int)(General.HealthStatus.High);
                            }
                            else
                            {
                                Error = 17;
                            }
                        }
                    }
                    if (Error == 0)
                    {
                        if (!String.IsNullOrWhiteSpace(objRequestRegisterDonerListDTO.HighBPStatus))
                        {
                            if (objRequestRegisterDonerListDTO.HighBPStatus == (General.HealthStatus.Low).ToString())
                            {
                                objRegisterDonerListDTO.HighBPStatusId = (int)(General.HealthStatus.Low);
                            }
                            else if (objRequestRegisterDonerListDTO.HighBPStatus == (General.HealthStatus.Normal).ToString())
                            {
                                objRegisterDonerListDTO.HighBPStatusId = (int)(General.HealthStatus.Normal);
                            }
                            else if (objRequestRegisterDonerListDTO.HighBPStatus == (General.HealthStatus.High).ToString())
                            {
                                objRegisterDonerListDTO.HighBPStatusId = (int)(General.HealthStatus.High);
                            }
                            else
                            {
                                Error = 18;
                            }
                        }
                    }
                    if(Error == 0)
                    {
                        if (!String.IsNullOrWhiteSpace(objRequestRegisterDonerListDTO.Address))
                        {
                            objRegisterDonerListDTO.Address = objRequestRegisterDonerListDTO.Address;
                        }
                    }
                    if(Error == 0)
                    {
                        objRegisterDonerListDTO.IsPublished = true;
                        objRegisterDonerListDTO.PublishedBy = "RegisterDoner API";
                    }


                    if (Error == 0) {

                        objRegisterDonerDAL = new RegisterDonerDAL(_appDb);

                        intResult = await objRegisterDonerDAL.RegisterDoner(objRegisterDonerListDTO);

                        if(intResult == -1)
                        {
                            objResponse.StatusCode = 200;
                            objResponse.Status = "Registration Successful";
                        }
                        else
                        {
                            objResponse.StatusCode = 500; 
                            objResponse.Status = "Registration Failed";
                        }
                    }

                    if (Error > 0)
                    {
                        objErrorCodeDAL = new ErrorCodeDAL(_appDb);

                        lstGetErrorMassageByErrroCode = objErrorCodeDAL.GetErrorMassageByErrroCode(Error);

                        if (lstGetErrorMassageByErrroCode != null && lstGetErrorMassageByErrroCode.Count > 0)
                        {
                            objResponse.StatusCode = lstGetErrorMassageByErrroCode[0].ErrorCode;
                            objResponse.Status = lstGetErrorMassageByErrroCode[0].ErrorMassage;
                        }
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
                objRegisterDonerDAL = null;
                objSearchAvailableBloodDonerDAL = null;
                lstGetBloodGroupListDTO = null;
                lstStatelistDTO = null;
                lstCityListDTO = null;
                objErrorCodeDAL = null;
                lstGetErrorMassageByErrroCode = null;
                objRegisterDonerListDTO = null;
            }

            return objResponse;
        }
    }
}
