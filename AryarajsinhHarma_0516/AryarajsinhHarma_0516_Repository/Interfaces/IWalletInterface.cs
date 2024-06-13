using AryarajsinhHarma_0516_Models.DbContext;
using AryarajsinhHarma_0516_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AryarajsinhHarma_0516_Repository.Interfaces
{
   public interface IWalletInterface
    {
        bool UpdateWalletAmount(int id, int WalletAmount);
        List<TransitionModel> GetAllTtransactonHistory(int userid);
        int GetBalance(int userid);
        int GetRemainingChance(int userid);
        int GetPerDayProfit(int userid);
        int getAmountInOneDay(int id, int amount);
        int TodayDebitedAmount(int id);
        int TotalProfit(int id);

    }
}
