using AryarajsinhHarma_0516_Models.DbContext;
using AryarajsinhHarma_0516_Models.ViewModels;
using AryarajsinhHarma_0516_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AryarajsinhHarma_0516_Repository.Services
{
   public class WalletServices : IWalletInterface
    {
        GameReward_0516Entities _db = new GameReward_0516Entities();
        public bool UpdateWalletAmount(int id, int WalletAmount)
        {
            try
            {
                SqlParameter[] sqlParameter = new SqlParameter[]
                    {
                             new SqlParameter("@user_id",id),
                             new SqlParameter("@CreditAmount",WalletAmount),
                    };

                WalletModel _walletModel = _db.Database.SqlQuery<WalletModel>("exec updateWalletAmount @user_id,@CreditAmount", sqlParameter).FirstOrDefault();

                if (_walletModel != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex; ;
            }
        }

        public List<TransitionModel> GetAllTtransactonHistory(int userid)
        {
            try
            {
                SqlParameter[] HistoryList = new SqlParameter[]
           {
            new SqlParameter("@userid",userid)
           };
                List<TransitionModel> list = _db.Database.SqlQuery<TransitionModel>("Exec GetHistory @userid", HistoryList).ToList();
                return list;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int GetBalance(int userid)
        {
            try
            {
                SqlParameter[] Balanceamount = new SqlParameter[]
            {
            new SqlParameter("@userid",userid)
            };
                int Balanceamounts = _db.Database.SqlQuery<int>("Exec GetBalanceLeft @userid", Balanceamount).FirstOrDefault();
                return Balanceamounts;
            }
            catch( Exception ex)
            {
                throw ex;
            }
        }

        public int GetRemainingChance(int userid)
        {
            try
            {
                SqlParameter[] RemainingChance = new SqlParameter[]
              {
            new SqlParameter("@userid",userid)
              };
                int Remainingchance = _db.Database.SqlQuery<int>("Exec GetRemainingChance @userid", RemainingChance).FirstOrDefault();
                return Remainingchance;
            }
            catch ( Exception ex)
            {
                throw ex;
            }
        }

        public int GetPerDayProfit(int userid)
        {
            try
            {
                SqlParameter[] getTodayProfit = new SqlParameter[]
                  {
            new SqlParameter("@userid",userid)
                   };
                int getTodayProfits = _db.Database.SqlQuery<int>("exec GetPerDayProfit @userid", getTodayProfit).FirstOrDefault();
                return getTodayProfits;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int getAmountInOneDay(int id, int amount)
        {
            try
            {
                SqlParameter[] sqlParameter = new SqlParameter[]
                   {
                  new SqlParameter("@userId",id),
                  new SqlParameter("@creditAmount",amount)
                   };

                int Amount = _db.Database.SqlQuery<int>("exec getAmountInOneDay @userId,@creditAmount", sqlParameter).FirstOrDefault();
                return Amount;
            }
            catch( Exception ex)
            {
                throw ex;
            }
        }

        public int TotalProfit(int id)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@userId" , id),

                };
                int balance = _db.Database.SqlQuery<int>("exec GetTotalProfit  @userId", sqlParameters).FirstOrDefault();
                return balance;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        } 
        public int TodayDebitedAmount(int id)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@userId" , id),

                };
                int balance = _db.Database.SqlQuery<int>("exec GetDebitAmountPerDay  @userId", sqlParameters).FirstOrDefault();
                return balance;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}


