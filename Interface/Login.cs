using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface
{
    public partial class Login : Form
    {
        //HttpClient client;
        private AccountClient account;
        public Login()
        {
            InitializeComponent();
        }

        /*public void GetAccount(string username)
        {
            client = new HttpClient();
            using (client)
            {
                client.BaseAddress = new Uri("http://localhost:59666/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("api/account/?username=" + username).Result;
                if (response.IsSuccessStatusCode)
                {
                    account = response.Content.ReadAsAsync<AccountClient>().Result;
                    
                }
            }
            
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            account = new AccountClient();
            account.GetData(textBox1.Text);
            if (account != null)
            {
                if (account.password == textBox2.Text)
                {
                    this.Hide();
                    Begin begin = new Begin(account.ID);
                    begin.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                   
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }

       



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
