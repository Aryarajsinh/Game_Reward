using AryarajsinhHarma_0516.Common;
using AryarajsinhHarma_0516.CustomFilter;
using AryarajsinhHarma_0516.Session;
using AryarajsinhHarma_0516_Models.DbContext;
using AryarajsinhHarma_0516_Models.ViewModels;
using AryarajsinhHarma_0516_Repository.Interfaces;
using AryarajsinhHarma_0516_Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AryarajsinhHarma_0516.Controllers
{
    
    public class LoginAuthController : Controller
    {
        GameReward_0516Entities _DbContext = new GameReward_0516Entities();
        ILoginAuthInterfaces _LoginAuth = new RegisterService();
        LoginApiHelper _LoginApi = new LoginApiHelper();


        public ActionResult Login()
        {
            try
            {
                SessionHelper.Logout();
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        [HttpPost]
        public async Task<ActionResult> Login(LoginModel db)
        {
            try
            {
                
                var userList = _DbContext.Register.FirstOrDefault(m => m.email == db.email);               
                
                if (!SessionHelper.IsUserLoggedIn && await _LoginApi.Login(db) != null)
                {
                    LoginModel isUserexist = await _LoginApi.Login(db);
                    var cookie = new HttpCookie("jwt", isUserexist.Token)
                    {
                        HttpOnly = true,
                        Secure = true,
                        Expires = DateTime.UtcNow.AddMinutes(1)
                    };


                  
                    SessionHelper.LoggedInUser = userList.name;
                    Response.Cookies.Add(cookie);
                    Request.Headers.Add("Authorization", "Bearer " + isUserexist.Token);
                    Session["UserId"] = userList.UserId;
                   
                    Session["Username"] = SessionHelper.LoggedInUser;
                    TempData["login"] = "Login SuccessFully";
               
                    return RedirectToAction("Index", "Game");
                }
                else
                {
                    TempData["Loginfail"] = "Please Fill Currect Credential";
                    return View(db);
                }
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel db)
        {
            try
            {
                var IsEmailExist = _DbContext.Register.Any(m => m.email == db.email);
                if (IsEmailExist)
                {
                    
                    TempData["Registerfail"] = "Email Is Already Exist";
                }
                else if (ModelState.IsValid)
                {
                    await _LoginApi.Register(db);
                    var userList = _DbContext.Register.Where(m => m.email == db.email).FirstOrDefault();


                    _LoginAuth.AddWallet(userList.UserId);

                    TempData["register"] = "Success  Fully Register..!!";
                    return RedirectToAction("Login");
                }

                else
                {
                    TempData["faieldRegister"] = "Please Fill The Value";
                    return View(db);
                }
                return View(db);
            }
            catch(Exception ex)
            {
                throw ex;
            }
         }
        public ActionResult Logout()
        {
            try
            {
              
                SessionHelper.Logout();
                RemoveAllCookies();
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult RemoveAllCookies()
        {
         
            foreach (string cookieName in Request.Cookies.AllKeys)
            {
                HttpCookie cookie = new HttpCookie(cookieName);
                cookie.Expires = DateTime.Now.AddDays(-1); 
                Response.Cookies.Add(cookie);
            }
            return RedirectToAction("Index"); 
        }

    }
}
