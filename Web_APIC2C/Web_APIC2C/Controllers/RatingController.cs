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
        public void Post([FromBody]string value)
        {



        }

        /***
         * public int RatingID { get; set; }
         * public string RatingUserrating { get; set; }
         * public string RatingUserrated { get; set; }
         * public double RatingPoint { get; set; }
         * public System.DateTime RatingDate { get; set; }****/
        //User will submit His phone , Target Phone , Rating.
        public string AddRating(Rating currentInput)
        {
            String UserRatingPhone = "01285799350";
            String UserRatedPhone = " 0962518088";
            using (C2CthesisEntities entities = new C2CthesisEntities())
            {
                Rating newRating = new Rating();// make object of table
                newRating.RatingUserrating = UserRatingPhone;
                newRating.RatingUserrated = UserRatedPhone;
                newRating.RatingPoint = 5;
                newRating.RatingDate = System.DateTime.Now;
                entities.Ratings.Add(newRating);
                entities.SaveChanges();
            }

            return "Done";
        }

        [ResponseType(typeof(Rating))]
        public async Task<IHttpActionResult> PostRating(String newRatingString)
        {

            String UserRatingPhone = "01285799350";
            String UserRatedPhone = "0962518088";

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Rating newRating = new Rating();// make object of table
            using (C2CthesisEntities entities = new C2CthesisEntities())
            {
                
                newRating.RatingUserrating = UserRatingPhone;
                newRating.RatingUserrated = UserRatedPhone;
                newRating.RatingPoint = 5;
                newRating.RatingDate = System.DateTime.Now;
                entities.Ratings.Add(newRating);
                await entities.SaveChangesAsync();
            }

            return CreatedAtRoute("DefaultApi", new { id = newRating.RatingID }, newRating);
        }


    }
}
