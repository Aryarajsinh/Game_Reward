using AryarajsinhHarma_0516_Models.DbContext;
using AryarajsinhHarma_0516_Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace AryarajsinhHarma_0516.Common
{
    public class WalletApiHelper
    {
        public async static Task<List<TransitionModel>> showTransaction(int userId,string JwtToken)
        {
            List<TransitionModel> transactionsHistory = new List<TransitionModel>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54627/api/Wallet/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            HttpResponseMessage response = await client.GetAsync("TransactionsHistorys?id="+userId);


            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                transactionsHistory = JsonConvert.DeserializeObject<List<TransitionModel>>(data);
            }
            return transactionsHistory;
        }

        public async static Task<int> TotalWalletAmount(int userId, string JwtToken)
        {
            int totalAmount = 0;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54627/api/Wallet/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            HttpResponseMessage response = await client.GetAsync("TotalWalletAmount?id="+userId);


            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                totalAmount = JsonConvert.DeserializeObject<int>(data);
            }
            return totalAmount;
        }

        public async static Task<int> GetAmountInOneDay(int userId, int amount, string JwtToken)
        {
            int totalAmount = 0;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54627/api/Wallet/");
            HttpResponseMessage response = await client.GetAsync($"GetAmountInOneDay?id={userId}&amount={amount}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                totalAmount = JsonConvert.DeserializeObject<int>(data);
            }
            return totalAmount;
        }   
        public async static Task<int> GetTotalAmount(int userId, int amount, string JwtToken)
        {
            int totalAmount = 0;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54627/api/Wallet/");
            HttpResponseMessage response = await client.GetAsync($"GetTotalProfit?id={userId}&amount={amount}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                totalAmount = JsonConvert.DeserializeObject<int>(data);
            }
            return totalAmount;
        }

        public async static Task<int> GetTotalProfitInOneDay(int userId, string JwtToken)
        {
            int totalAmount = 0;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54627/api/Wallet/");
            HttpResponseMessage response = await client.GetAsync($"GetProfitInOneDay?id={userId}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                totalAmount = JsonConvert.DeserializeObject<int>(data);
            }
            return totalAmount;
        }
        public async static Task<int> GetTotalProfit(int userId, string JwtToken)
        {
            int totalAmount = 0;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54627/api/Wallet/");
            HttpResponseMessage response = await client.GetAsync($"GetTotalProfit?id={userId}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);


            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                totalAmount = JsonConvert.DeserializeObject<int>(data);
            }
            return totalAmount;
        } 
        public async static Task<int> GetDebitAmountToday(int userId, string JwtToken)
        {
            int totalAmount = 0;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54627/api/Wallet/");
            HttpResponseMessage response = await client.GetAsync($"GetDebitAmountToday?id={userId}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);


            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                totalAmount = JsonConvert.DeserializeObject<int>(data);
            }
            return totalAmount;
        }

        public async static Task<int> GetRemainingChance(int userId,string JwtToken)
        {
            int totalAmount = 0;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54627/api/Wallet/");
            HttpResponseMessage response = await client.GetAsync($"GetChance?id={userId}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);


            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                totalAmount = JsonConvert.DeserializeObject<int>(data);
            }
            return totalAmount;
        }
    }
}