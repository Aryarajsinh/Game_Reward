using AryarajsinhHarma_0516.Common;
using AryarajsinhHarma_0516.CustomFilter;
using AryarajsinhHarma_0516.Session;
using AryarajsinhHarma_0516_Helpers;
using AryarajsinhHarma_0516_Models.DbContext;
using AryarajsinhHarma_0516_Models.ViewModels;
using AryarajsinhHarma_0516_Repository.Interfaces;
using AryarajsinhHarma_0516_Repository.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AryarajsinhHarma_0516.Controllers
{
    [CustomAuthorize]
    public class GameController : Controller
    {
        readonly IWalletInterface _wallet = new WalletServices();
        public async Task<ActionResult> Index()
        {
            try
            {
                int userid = Convert.ToInt32(Session["UserId"]);
                if (Request.Cookies["jwt"] != null)
                {
                    int Balanceamounts = await WalletApiHelper.TotalWalletAmount(userid, Request.Cookies["jwt"].Value);

                    int RemainingChances = await WalletApiHelper.GetRemainingChance(userid, Request.Cookies["jwt"].Value);

                    int getTodayProfits = await WalletApiHelper.GetTotalProfitInOneDay(userid, Request.Cookies["jwt"].Value);

                    int GetAllProfits = await WalletApiHelper.GetTotalProfit(userid, Request.Cookies["jwt"].Value);

                    int DebitAmountToday = await WalletApiHelper.GetDebitAmountToday(userid, Request.Cookies["jwt"].Value);

                    ViewBag.Balanceamount = Balanceamounts;
                    ViewBag.RemainingChances = RemainingChances;
                    ViewBag.getTodayProfits = getTodayProfits;
                    ViewBag.GetAllProfits = GetAllProfits;
                    ViewBag.DebitAmountToday = DebitAmountToday;
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "LoginAuth");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "LoginAuth");
            }
        }

        public async Task<ActionResult> GamePlay()
        {
            try
            {
                int userid = Convert.ToInt32(Session["UserId"]);
                if (Request.Cookies["jwt"] != null)
                {
                    int Balanceamounts = await WalletApiHelper.TotalWalletAmount(userid, Request.Cookies["jwt"].Value);

                    int chance = await WalletApiHelper.GetRemainingChance(userid, Request.Cookies["jwt"].Value);
                    int getTodayProfits = await WalletApiHelper.GetTotalProfitInOneDay(userid, Request.Cookies["jwt"].Value);

                    ViewBag.Balanceamount = Balanceamounts;
                    ViewBag.getTodayProfits = getTodayProfits;
                    Session["chance"] = chance;
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "LoginAuth");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "LoginAuth");
            }
        }
        public async Task<ActionResult> WalletList(int? pageNumber)
        {
            try
            {
                if (Request.Cookies["jwt"] != null)
                {
                    int userid = Convert.ToInt32(Session["UserId"]);
                    var list = await WalletApiHelper.showTransaction(userid, Request.Cookies["jwt"].Value);
                    Session["userId"] = userid;

                    int Balanceamount = await WalletApiHelper.TotalWalletAmount(userid, Request.Cookies["jwt"].Value);
                    int RemainingChances = await WalletApiHelper.GetRemainingChance(userid, Request.Cookies["jwt"].Value);

                    ViewBag.Balanceamount = Balanceamount;
                    ViewBag.RemainingChances = RemainingChances;
                    ViewBag.username = SessionHelper.LoggedInUser;

                    int page = pageNumber ?? 1;
                    var PaginationList = CustomPagination<TransitionModel>.Pagination(list, page);
                    ViewBag.totalCount = CustomPagination<TransitionModel>.totalCount;
                    ViewBag.page = CustomPagination<TransitionModel>.page;
                    ViewBag.pageSize = CustomPagination<TransitionModel>.pageSize;
                    ViewBag.totalPage = CustomPagination<TransitionModel>.totalPage;

                    return View(PaginationList);
                }
                else
                {
                    return RedirectToAction("Login", "LoginAuth");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "LoginAuth");
            }
        }

        public int updateWalletAmount(int id, int amount)
        {
            try
            {
                int Todayamount = _wallet.getAmountInOneDay(id, amount);
                if (Todayamount == 1)
                {
                    _wallet.UpdateWalletAmount(id, amount);
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}


    



