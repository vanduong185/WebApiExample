using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AccountDataAccess;
namespace Webapi.Controllers
{
    public class ProfileController : ApiController
    {
        public IEnumerable<profile> Get()
        {
            using (AccountsEntities entities = new AccountsEntities())
            {
                return entities.profiles.ToList();
            }
        }

        public profile GetProfile(int ID)
        {
            using (AccountsEntities entities = new AccountsEntities())
            {
                return entities.profiles.FirstOrDefault(e => e.ID == ID);
            }
        }
    }
}
