using AryarajsinhHarma_0516_Models.DbContext;
using AryarajsinhHarma_0516_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AryarajsinhHarma_0516_Helpers
{
    public class ConvertModelHelper
    {
        public static Register ConvertModelToDbModel(RegisterModel db)
        {
            Register _register = new Register();
            _register.name = db.name;
            _register.email = db.email;
            _register.password = db.password;

            return _register;
        }
    }
}
