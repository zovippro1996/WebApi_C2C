using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_APIC2CDataAccess;

namespace Web_APIC2C.Controllers
{
    public class RatingController : ApiController
    {
        public IEnumerable<Rating> Get()
        {
            using (C2CthesisEntities entities = new C2CthesisEntities())
            {
                return entities.Ratings.ToList();
            }
        }

        public Rating Get(int id)
        {
            using (C2CthesisEntities entities = new C2CthesisEntities())
            {
                return entities.Ratings.FirstOrDefault(e => e.RatingID == id);
            }
        }
    }
}
