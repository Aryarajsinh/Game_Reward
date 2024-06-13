using AryarajsinhHarma_0516_Models.DbContext;
using AryarajsinhHarma_0516_Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace AryarajsinhHarma_0516.Common
{
    public class LoginApiHelper
    {
        public async Task<Register> Register(RegisterModel db)
        {
            Register _assignments = new Register();
            HttpClient client = new HttpClient();
            string content = JsonConvert.SerializeObject(db);

            client.BaseAddress = new Uri("http://localhost:54627/api/LoginApi/");
            HttpResponseMessage response = await client.PostAsync("Registers", new StringContent(content, System.Text.Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                _assignments = JsonConvert.DeserializeObject<Register>(data);
            }
            return _assignments;
        } 
        public async Task<LoginModel> Login(LoginModel db)
        {
            LoginModel _assignments = new LoginModel();
            HttpClient client = new HttpClient();
            string content = JsonConvert.SerializeObject(db);

            client.BaseAddress = new Uri("http://localhost:54627/api/LoginApi/");
            HttpResponseMessage response = await client.PostAsync("Login", new StringContent(content, System.Text.Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                    var data = await response.Content.ReadAsStringAsync();
                    _assignments = JsonConvert.DeserializeObject<LoginModel>(data);
                    return _assignments;
                
                
            }
            return null;
        }
      
    }
}