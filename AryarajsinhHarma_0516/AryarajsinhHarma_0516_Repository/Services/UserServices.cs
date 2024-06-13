using AryarajsinhHarma_0516_Models.DbContext;
using AryarajsinhHarma_0516_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AryarajsinhHarma_0516_Repository.Services
{
   public class UserServices
    {
        AryarajsinhHarma_0516Entities1 _context = new AryarajsinhHarma_0516Entities1();
        public WalletModel GetTotalWalletAmount(int UserId)
        {
            try
            {
                Wallet wallet = new Wallet();
                wallet = _context.Wallet.Where(m => m.userid == UserId).FirstOrDefault();

                WalletModel walletModel = new WalletModel
                {
                    Wallet_id = wallet.Wallet_id,
                    userid = (int)wallet.userid,
                    TotalAmount = (int)wallet.TotalAmount
                };

                return walletModel != null ? walletModel : null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool AddTranaction(TransactionModel transactionModel)
        {
            try
            {
                int SaveAmount = 0;

                Wallet wallet = _context.Wallet.FirstOrDefault(m => m.userid == transactionModel.UserId);
                wallet.TotalAmount = wallet.TotalAmount + transactionModel.Amount;
                _context.SaveChanges();

                Transactions transaction = new Transactions
                {
                    WalletId = transactionModel.WalletId,
                    Amount = transactionModel.Amount,
                    IsDebitCredit = transactionModel.IsDebitCredit,
                    Time = DateTime.Now
                };

                _context.Transactions.Add(transaction);
                SaveAmount = _context.SaveChanges();

                return SaveAmount > 0 ? true : false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<TransactionModel> GetAllList(int WallentId, int UserId)
        {
            try
            {
                List<TransactionModel> list = new List<TransactionModel>();
                List<Transactions> transactions = _context.Transactions.Where(m => m.WalletId == WallentId && m.Wallet.UserId == UserId).ToList();
                foreach (var item in transactions)
                {
                    TransactionModel transactionModel = new TransactionModel();

                }
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
