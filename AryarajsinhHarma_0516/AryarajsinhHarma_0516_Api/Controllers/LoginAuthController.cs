using AryarajsinhHarma_0516_Models.ViewModels;
using AryarajsinhHarma_0516_Repository.Interfaces;
using AryarajsinhHarma_0516_Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AryarajsinhHarma_0516_Api.Controllers
{
    public class LoginAuthController : ApiController
    {
         ILoginAuthInterfaces repo = new RegisterService();

        [Route("api/LoginAuth/AddRegister")]
        [HttpPost]
        public void AddRegister(RegisterModel registerModel)
        {
            try
            {
                repo.AddData(registerModel);
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [Route("api/LoginAuth/ChechUserExist")]
        [HttpPost]
        public RegisterModel ChechUserExist(LoginModel loginModel)
        {
            try
            {
                RegisterModel IsLoginUserExist = repo.CheckUserExist(loginModel);
                return IsLoginUserExist;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
