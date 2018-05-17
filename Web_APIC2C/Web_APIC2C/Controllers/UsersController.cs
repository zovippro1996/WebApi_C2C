using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_APIC2CDataAccess;

namespace Web_APIC2C.Controllers
{
    public class UsersController : ApiController
    {
        public IEnumerable<User> Get()
        {
            using (C2CthesisEntities entities = new C2CthesisEntities())
            {
                return entities.Users.ToList();
            }
        }

        public User Get(String phone)
        {
            using (C2CthesisEntities entities = new C2CthesisEntities())
            {
                return entities.Users.FirstOrDefault(e => e.UserPhonenumber == phone);
            }
        }
    }
}
