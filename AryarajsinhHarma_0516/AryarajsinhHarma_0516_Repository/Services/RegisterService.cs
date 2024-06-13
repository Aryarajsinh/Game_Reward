using AryarajsinhHarma_0516_Helpers;
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
    public class RegisterService : ILoginAuthInterfaces
    {
        GameReward_0516Entities _db = new GameReward_0516Entities();
        public void AddData(RegisterModel db)
        {
            try
            {
                Register list = ConvertModelHelper.ConvertModelToDbModel(db);
                _db.Register.Add(list);
                _db.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void AddWallet(int id)
        {
            try
            {
                SqlParameter[] sqlparameter = new SqlParameter[]
                {
                new SqlParameter("@userid",id)
                };
                _db.Database.SqlQuery<WalletModel>("Exec WalletAmount @userid", sqlparameter).ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        public void AddNumberIntoWallet(int randomNumber, int UserId)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@RandomNumber" , randomNumber),
                    new SqlParameter("@UserId" , UserId)

                };
                _db.Database.ExecuteSqlCommand("exec Sp_AddRandomNumberIntoWallet @RandomNumber, @UserId", sqlParameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
