using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
namespace Interface
{
    class AccountClient
    {
        public int ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public void GetData(string username)
        {
            AccountClient account = new AccountClient();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:59666/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("appilication/json"));
            HttpResponseMessage response = client.GetAsync("api/account/?username=" + username).Result;
            if (response.IsSuccessStatusCode)
            {
                account = response.Content.ReadAsAsync<AccountClient>().Result;
            }
            this.ID = account.ID;
            this.username = account.username;
            this.password = account.password;
        }
    }
}
