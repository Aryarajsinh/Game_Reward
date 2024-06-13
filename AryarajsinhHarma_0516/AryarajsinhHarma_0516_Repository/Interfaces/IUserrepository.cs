using AryarajsinhHarma_0516_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AryarajsinhHarma_0516_Repository.Interfaces
{
    public interface IUserrepository
    {
        WalletModel GetTotalWalletAmount(int UserId);

        bool AddTranaction(TransactionModel transactionModel);

        List<TransactionModel> GetAllList(int WallentId, int UserId);
    }
}
