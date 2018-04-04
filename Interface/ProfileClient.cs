using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class ProfileClient
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string identityNumber { get; set; }
        public System.DateTime birthday { get; set; }
        public string address { get; set; }
        public string nation { get; set; }
        public string religion { get; set; }

        public void GetData(int ID)
        {

            ProfileClient profile = new ProfileClient();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:59666/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("appilication/json"));
            HttpResponseMessage response = client.GetAsync("/api/profile/" + ID).Result;
            if (response.IsSuccessStatusCode)
            {
                profile = response.Content.ReadAsAsync<ProfileClient>().Result;
            }
            this.ID = profile.ID;
            this.name = profile.name;
            this.identityNumber = profile.identityNumber;
            this.birthday = profile.birthday;
            this.address = profile.address;
            this.nation = profile.nation;
            this.religion = profile.religion;
        }
    }
}
