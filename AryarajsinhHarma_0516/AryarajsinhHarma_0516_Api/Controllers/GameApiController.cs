using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AryarajsinhHarma_0516_Api.Controllers
{
    public class GameApiController : ApiController
    {
        private readonly I repo = new UserService();

        [Route("api/GameAPI/GetTotalWalletAmount")]
        [HttpGet]
        public WalletModel GetTotalWalletAmount(int UserId)
        {
            try
            {
                WalletModel walletModel = repo.GetTotalWalletAmount(UserId);
                return walletModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [Route("api/GameAPI/AddTranaction")]
        [HttpPost]
        public bool AddTranaction(TransactionModel transactionModel)
        {
            try
            {
                bool SaveAmount = repo.AddTranaction(transactionModel);
                return SaveAmount;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
