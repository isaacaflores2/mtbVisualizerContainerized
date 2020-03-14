using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Map.API.Data;
using System.Net;
using Map.API.Models;

namespace Map.API.Controllers
{
    [ApiController]
    [Route("api/v1/map")]    
    public class MapCoordinatesController : ControllerBase
    {
        private readonly ICoordinatesRepository context;
        private readonly IStravaClient stravaClient;        

        public MapCoordinatesController(ICoordinatesRepository context, IStravaClient stravaClient)
        {
            this.context = context;
            this.stravaClient = stravaClient;            
        }

        // GET: api/v1/map/coordinates
        [HttpGet]
        //[Route("coordinates/{id:int}")]
        [Route("coordinates")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(IEnumerable<Coordinates>), (int)HttpStatusCode.OK)]
        public ActionResult<IEnumerable<Coordinates>> CoordinatesById(String accessToken, int id)
        {
            if( String.IsNullOrEmpty(accessToken) || id <= 0)
            {
                return BadRequest();
            }
            
            //Add try block to function
            var coordinates = getUserCoordinates(accessToken, id).ToList();
            
            if (coordinates != null)
            {
                return coordinates;
            }

            return NotFound();
        }

        private IEnumerable<Coordinates> getUserCoordinates(string accessToken, int id)
        {
            var user = context.GetUserById(id);

            if (user == null || user.StartCoordinates == null || user.StartCoordinates.Count == 0)
            {
                var coordinates = stravaClient.getAllUserCoordinatesById(accessToken, id);

                user = new User()
                {
                    StartCoordinates = coordinates.ToList(),
                    UserId = id,
                    LastDownload = DateTime.Now.Date
                };
                context.Add(user);
                context.SaveChanges();
            }
            else
            {                
                var latestCoordinates = stravaClient.getUserCoordinatesById(accessToken, user, user.LastDownload);

                if (latestCoordinates != null)
                {
                    foreach (var activity in latestCoordinates)
                    {       
                        //Activities without a valid location cannot be mapped
                        if(activity.Latitude == null || activity.Longitude == null)
                        {
                            continue;
                        }

                        if (!context.Contains(activity))
                        {
                            context.Add(activity);
                            user.StartCoordinates.Add(activity);
                        }
                    }
                    context.SaveChanges();
                }
            }
            return user.StartCoordinates;
        }

        // GET: api/MapCoordinates/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MapCoordinates
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/MapCoordinates/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
