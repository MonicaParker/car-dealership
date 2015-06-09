using CarDealershipApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealershipApplication.Controllers.Api
{
    public class CarsController : ApiController
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        public CarsController()
        {
            if (_db.Cars.Count() == 0)
            {
                var cars = new List<Car>
                {
                new RollsRoyce { Id = 0, Title = "The Baconator", Price = 80000.00m, 
                    Picture = "http://www.mansory.com/sites/default/files/imagecache/slider/slider/wraith_red_chrome_slid.jpg", 
                    BriefDescription = "Utterly droolworthy.",
                    FullDescription = "The baconator is our finest model, representing the pinnacle of efficiency and taste.",
                    GasMileage = 8,
                    Type = "Rolls-Royce"},
                new RollsRoyce {Id = 1, Title = "Eyesore", Price = 50000.00m, 
                    Picture = "http://www.exoticspotter.com/images/129/128489.jpg", 
                    BriefDescription = "All yours.",
                    FullDescription = "Thanks to the latest advances in color deterrence technology, you never have to worry about car theft ever again.",
                    GasMileage = 15,
                    Type = "Rolls-Royce"},
                new RollsRoyce {Id = 2, Title = "Not Bumblebee", Price = 70000.00m, 
                    Picture = "http://www.rrocncr.net/technical/YrrBumper/YrrCareyCover.JPG", 
                    BriefDescription = "Not a transformer. Sorry.",
                    FullDescription = "This old fashioned car might not be the Bumblebee style vehicle you were looking for, but it's trying really really hard. Cut it some slack.",
                    GasMileage = 10,
                    Type = "Rolls-Royce"},
                new RollsRoyce {Id = 3, Title = "Shadowed Midnight Phantom Ghost Panther", Price = 150000.00m, 
                    Picture = "https://www.limobroker.co.uk/reviews/wp-content/uploads/2014/02/black-rolls-royce-phantom-2.jpg", 
                    BriefDescription = "The pinnacle of cool.",
                    FullDescription = "This car uses every overused car name in the book to hide the fact that it's really just a black car.",
                    GasMileage = 9,
                    Type = "Rolls-Royce"},
                new RollsRoyce {Id = 4, Title = "The Mothership", Price = 80000.00m, 
                    Picture = "http://www.thetorquereport.com/mansory_rolls_royce_ghost.jpg", 
                    BriefDescription = "We know you recognize those colors",
                    FullDescription = "Don't lie. We know these were the colors of your Homeworld fleet. And we know you're dying to bring that dream to life in your very own Rolls-Royce. Go on ahead, nerd out. No one's judgin'.",
                    GasMileage = 12,
                    Type = "Rolls-Royce"},
                new RollsRoyce {Id = 5, Title = "Hipster", Price = 90000.00m, 
                    Picture = "http://www.thetorquereport.com/mansory_rolls_royce_ghost.jpg", 
                    BriefDescription = "The worst color combination; the strangest draw.",
                    FullDescription = "No one in their right minds would possibly buy this color combination on this kind of car. Yet somehow, customers flock to it like flies to sugar water, each one looking for that unique and special car.",
                    GasMileage = 12,
                    Type = "Rolls-Royce"},
                new Tesla {Id = 6, Title = "The Blueberry", Price = 50000.00m, 
                    Picture = "http://www.teslamotorsclub.com/attachment.php?attachmentid=20269&d=1366239534", 
                    BriefDescription = "Tasteful colors.",
                    FullDescription = "You could have any color blue in the world. Instead, why not go for this eye-catching monstrosity?", 
                    Range = 9, ChargeTime = 2,
                    Type = "Tesla"},
                new Tesla {Id = 7, Title = "Totally Ordinary", Price = 60000.00m, 
                    Picture = "http://24.media.tumblr.com/853fc30cc4627ede6228809e61acf20b/tumblr_merzvoru4a1rzyequo1_1280.jpg", 
                    BriefDescription = "So ordinary you could lose it on the street.",
                    FullDescription = "Blend into your humdrum routine even more effectively with this totally ordinary-looking car. Mediocrity never felt so good. (Or expensive).", 
                    Range = 7, ChargeTime = 4,
                    Type = "Tesla"},
                new Tesla {Id = 8, Title = "Dirt Magnet", Price = 50000.00m, 
                    Picture = "http://www.moibibiki.com/gallery/model-801/tesla-model-s-white-7.jpg.html", 
                    BriefDescription = "Support your local car wash.",
                    FullDescription = "A great model for enforcing patterns of cleanliness and regular maintenance. Our paint is specially designed to collect and emphasize every scratch and stain.", 
                    Range = 10, ChargeTime = 3,
                    Type = "Tesla"},
                new Tesla {Id = 9, Title = "Brownie", Price = 40000.00m, 
                    Picture = "http://www.teslamotorsclub.com/attachment.php?attachmentid=30736&d=1379336986", 
                    BriefDescription = "Oddly nice.",
                    FullDescription = "Admit it, brown is not the color that jumps immediately to mind when you think of expensive cars. But it works strangely well.", 
                    Range = 11, ChargeTime = 1,
                    Type = "Tesla"},
                new Tesla {Id = 10, Title = "Amphibian", Price = 70000.00m, 
                    Picture = "http://theirearth.com/uploads/news/1215220983_tesla_roadster_2009_orange.jpg", 
                    BriefDescription = "Car or rainforest frog? No one knows.",
                    FullDescription = "Adapt to any situation by distracting and beguiling your peers with this oddly shaped, strangely colored, tropically sleek looking car.", 
                    Range = 8, ChargeTime = 2,
                    Type = "Tesla"},
                };
                cars.ForEach(c => _db.Cars.Add(c));
                _db.SaveChanges();
            }
        }

        //Search cars
        [Route("API/Cars/GetTesla")]
        public IEnumerable<Car> GetTesla()
        {
            return _db.Cars.Where(t => t.Type == "Tesla").ToList();
        }

        [Route("API/Cars/GetRolls")]
        public IEnumerable<Car> GetRolls()
        {
            return _db.Cars.Where(t => t.Type == "Rolls-Royce").ToList();
        }


        // GET: api/Cars
        public IEnumerable<Car> Get()
        {
            return _db.Cars.ToList();
        }

        // GET: api/Cars/5
        public string Get(int id)
        {
            return "value";
        }

        //Everything below here requires user validation.

        // POST: api/Cars
        [Authorize]
        public HttpResponseMessage Post(Car car)
        {
            if (ModelState.IsValid)
            {
                if (car.Id > 0)
                {
                    var originalCar = _db.Cars.Find(car.Id);
                    originalCar.Title = car.Title;
                    originalCar.Price = car.Price;
                    originalCar.Picture = car.Picture;
                    originalCar.BriefDescription = car.BriefDescription;
                    originalCar.FullDescription = car.FullDescription;
                }
                else
                {
                    _db.Cars.Add(car);
                }
                _db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created, car);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.ModelState);
        }

        // PUT: api/Cars/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        [Authorize]
        // DELETE: api/Cars/5
        public void Delete(int id)
        {
            var originalCar = _db.Cars.Find(id);
            _db.Cars.Remove(originalCar);
            _db.SaveChanges();
        }
    }
}
