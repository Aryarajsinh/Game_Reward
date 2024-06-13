using AryarajsinhHarma_0516.Session;
using AryarajsinhHarma_0516_Models.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AryarajsinhHarma_0516.CustomFilter
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            try
            {
                GameReward_0516Entities _dbContext = new GameReward_0516Entities();
                Register list = _dbContext.Register.FirstOrDefault(m => m.name == SessionHelper.LoggedInUser);
                if (list != null)
                {
                    return SessionHelper.IsUserLoggedIn;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                 throw e;
             }
           }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            try
            {
                if (!SessionHelper.IsUserLoggedIn)
                {
                    filterContext.Result = new RedirectResult("~/LoginAuth/Login");
                }
                else
                {
                    filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
    }
