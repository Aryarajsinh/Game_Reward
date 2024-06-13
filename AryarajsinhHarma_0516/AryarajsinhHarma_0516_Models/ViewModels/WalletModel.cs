using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AryarajsinhHarma_0516_Models.ViewModels
{
   public class WalletModel
    {
        public int Wallet_id { get; set; }
        public Nullable<int> userid { get; set; }
        public Nullable<int> DebitAmount { get; set; }
        public Nullable<int> CreditAmount { get; set; }
        public Nullable<int> TotalAmount { get; set; }
        public Nullable<System.DateTime> DebitDate { get; set; }
    }
}
