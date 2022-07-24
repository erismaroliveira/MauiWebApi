using MauiWebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiWebApi.Services
{
    public class LoginService : ILoginRepository
    {
        public async Task<UserInfo> Login(string userName, string password)
        {
            var userInfo = new List<UserInfo>();
            var client = new HttpClient();

            var url = "https://minhaapi.net/api/userInfos/LoginUser/" + userName + "/" + password;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                userInfo = JsonConvert.DeserializeObject<List<UserInfo>>(content);

                return await Task.FromResult(userInfo.FirstOrDefault());
            }
            else
            {
                return null;
            }
        }
    }
}
