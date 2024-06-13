using AryarajsinhHarma_0516_Api.JwtAuthHelper;
using AryarajsinhHarma_0516_Models.DbContext;
using AryarajsinhHarma_0516_Models.ViewModels;
using AryarajsinhHarma_0516_Repository.Interfaces;
using AryarajsinhHarma_0516_Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace AryarajsinhHarma_0516_Api.Controllers
{
    [JwtAuthentication]
    public class WalletApiController : ApiController
    {
        IWalletInterface _wallet;
       
        public WalletApiController()
        {

            _wallet = new WalletServices();
        }

        [Route("api/Wallet/TransactionsHistorys")]
        [HttpGet]
        public List<TransitionModel> TransactionsHistorys(int id)
        {
            JwtAuthenticationAttribute.OnAuthorization(HttpContext.Current);
            List<TransitionModel> totalWalletAmount = _wallet.GetAllTtransactonHistory(id);
            return totalWalletAmount;
        }

        [Route("api/Wallet/TotalWalletAmount")]
        [HttpGet]
        public int TotalWalletAmount(int id)
        {
            //JwtAuthenticationAttribute.OnAuthorization(HttpContext.Current);
            int totalWalletAmount = _wallet.GetBalance(id);
            return totalWalletAmount;
        }

        [Route("api/Wallet/GetChance")]
        [HttpGet]
        public int GetChance(int id)
        {
            //JwtAuthenticationAttribute.OnAuthorization(HttpContext.Current);
            int chance = _wallet.GetRemainingChance(id);
            return chance;
        }

        [Route("api/Wallet/GetAmountInOneDay")]
        [HttpGet]
        public int GetAmountInOneDay(int id, int amount)
        {
            //JwtAuthenticationAttribute.OnAuthorization(HttpContext.Current);
            int amountperDay = _wallet.getAmountInOneDay(id, amount);
            return amountperDay;
        }

        [Route("api/Wallet/GetProfitInOneDay")]
        [HttpGet]
        public int GetProfitInOneDay(int id)
        {
            //JwtAuthenticationAttribute.OnAuthorization(HttpContext.Current);
            int amountperDay = _wallet.GetPerDayProfit(id);
            return amountperDay;
        }

        [Route("api/Wallet/GetTotalProfit")]
        [HttpGet]
        public int GetTotalProfit(int id)
        {
            //JwtAuthenticationAttribute.OnAuthorization(HttpContext.Current);
            int amountperDay = _wallet.TotalProfit(id);
            return amountperDay;
        }

        [Route("api/Wallet/GetDebitAmountToday")]
        [HttpGet]
        public int GetDebitAmountToday(int id)
        {
            //JwtAuthenticationAttribute.OnAuthorization(HttpContext.Current);
            int amountperDay = _wallet.TodayDebitedAmount(id);
            return amountperDay;
        }

      
    }
}
