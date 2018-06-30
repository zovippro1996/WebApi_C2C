using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
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

        // POST api/rating
        public String Post([FromBody]string value)
        {
            //ResultInit return the result of API
            String resultReturn = "";

            String UserRatingPhone = "01285799350";
            String UserRatedPhone = "0962518088";
            double RatingPoint = 1;

            resultReturn = resultReturn + UserRatingPhone + UserRatedPhone + RatingPoint + "End Init "; 

            using (C2CthesisEntities entities = new C2CthesisEntities())
            {
                resultReturn = resultReturn + " In Using Entity ";

                //Check if User Rating exist in Database
                if (!entities.Users.Any(o => o.UserPhonenumber.Equals(UserRatingPhone)))
                {
                    resultReturn = resultReturn + " Check User Rating exist Db ";
                    User newRatingUser = new User();
                    newRatingUser.UserPhonenumber = UserRatingPhone;
                    newRatingUser.UserPoint = -1;
                    entities.Users.Add(newRatingUser);
                }

                //Check if User Rated exist in Database
                if (!entities.Users.Any(o => o.UserPhonenumber.Equals(UserRatedPhone)))
                {
                    resultReturn = resultReturn + " Check User Rated exist Db ";
                    User newRatedUser = new User();
                    newRatedUser.UserPhonenumber = UserRatedPhone;
                    newRatedUser.UserPoint = -1;
                    entities.Users.Add(newRatedUser);
                } 

                //Add Rating to Database 
                Rating newRating = new Rating();
                newRating.RatingUserrating = UserRatingPhone;
                newRating.RatingUserrated = UserRatedPhone;
                newRating.RatingPoint = RatingPoint;
                newRating.RatingDate = System.DateTime.Now;
                entities.Ratings.Add(newRating);

                double UserRatedPoint = entities.Users.FirstOrDefault(o => o.UserPhonenumber.Equals(UserRatingPhone)).UserPoint;

                entities.SaveChanges();
                resultReturn = resultReturn + " End Using ";
            }
            resultReturn = resultReturn + " Out";
            return resultReturn;
        }

        //[ResponseType(typeof(Rating))]
        //public async Task<IHttpActionResult> PostRating(String newRatingString)
        //{

        //    String UserRatingPhone = "01285799350";
        //    String UserRatedPhone = "0962518088";

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    Rating newRating = new Rating();// make object of table
        //    using (C2CthesisEntities entities = new C2CthesisEntities())
        //    {

        //        newRating.RatingUserrating = UserRatingPhone;
        //        newRating.RatingUserrated = UserRatedPhone;
        //        newRating.RatingPoint = 5;
        //        newRating.RatingDate = System.DateTime.Now;
        //        entities.Ratings.Add(newRating);
        //        await entities.SaveChangesAsync();
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = newRating.RatingID }, newRating);
        //}
    }
}
