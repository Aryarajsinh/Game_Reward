using AryarajsinhHarma_0516.Session;
using AryarajsinhHarma_0516_Api.JwtAuthHelper;
using AryarajsinhHarma_0516_Helpers;
using AryarajsinhHarma_0516_Models.DbContext;
using AryarajsinhHarma_0516_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace AryarajsinhHarma_0516_Api.Controllers
{
    public class LoginApiController : ApiController
    {
        GameReward_0516Entities _option = new GameReward_0516Entities();
        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/LoginApi/Registers")]
        public Register Registers(RegisterModel db)
        {
            Register _registerUser = new Register();
            _registerUser = ConvertModelHelper.ConvertModelToDbModel(db);
            var isEmailExist = _option.Register.Any(x => x.email == db.email);

            if (!isEmailExist)
            {
                _option.Register.Add(_registerUser);
                _option.SaveChanges();
                return _registerUser;
            }
            else if(isEmailExist){
                ModelState.AddModelError("Email", "Email is Already Exist");
                
                return null;
            }
            else
            {
                return null;
            }
        }

        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/LoginApi/Login")]
        public LoginModel Login(LoginModel user)
        {
            string email = user.email;
            string password = user.password;
            var keepLogin = true;
            bool keepLoginSession;

            keepLoginSession = keepLogin == true;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("", "Please enter valid username and password");

                return null;
            }

            Register appUserInfo = _option.Register.FirstOrDefault(u => u.email == email);

            if (appUserInfo != null && ModelState.IsValid && appUserInfo.email == user.email && appUserInfo.password == user.password )
            {
                string encryptedPwd = password;

                var userPassword = appUserInfo.password;
                var username = appUserInfo.email;
                if (encryptedPwd.Equals(userPassword) && username.Equals(email))
                {
                    var role = appUserInfo.name;
                    var jwtToken = Authentication.GenerateJWTAuthetication(email, role);
                    var validUserName = Authentication.ValidateToken(jwtToken);

                    if (string.IsNullOrEmpty(validUserName))
                    {
                        ModelState.AddModelError("", "Unauthorized login attempt ");

                        return null;
                    }

                    var cookie = new HttpCookie("jwt", jwtToken)
                    {
                        HttpOnly = true,
                        Secure = true, // Uncomment this line if your application is running over HTTPS
                        Expires = DateTime.UtcNow.AddMinutes(1)
                    };
                    HttpContext.Current.Response.Cookies.Add(cookie);
                    user.Token = jwtToken;
                    return user;

                }
            }
            return user;
        }
    }
}
