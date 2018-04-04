using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AccountDataAccess;
namespace Webapi.Controllers
{
    public class AccountController : ApiController
    {
        public IEnumerable<account> Get()
        {
            using (AccountsEntities entities = new AccountsEntities())
            {
                return entities.accounts.ToList();
            }
        }

        public account GetAccount(string username)
        {
            using (AccountsEntities entities = new AccountsEntities())
            {
                return entities.accounts.FirstOrDefault(e => e.username == username);
            }
        }
    }
}
