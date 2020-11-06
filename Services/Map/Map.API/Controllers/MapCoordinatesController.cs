using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Map.API.Data;
using System.Net;
using Map.API.Models;
using MtbVis.Common;

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
                IEnumerable<Coordinates> coordinates = stravaClient.getAllUserCoordinatesById(accessToken, id);
                
                //Activities without a valid location cannot be mapped
                coordinates = from c in coordinates
                              where !(c.Longitude == null || c.Longitude == null)
                              select c;

                if(user == null)
                {
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
                    //Update UserId if it is not valid
                    if(user.UserId <= 0 && user.UserId != id)
                    {
                        user.UserId = id; 
                    }

                    addCoordinates(user, coordinates);
                }                
            }            
            else
            {                
                var latestCoordinates = stravaClient.getUserCoordinatesByIdAfter(accessToken, user.LastDownload);
                addCoordinates(user, latestCoordinates);                
            }

            return user.StartCoordinates;
        }

        private void addCoordinates(User user, IEnumerable<Coordinates> coordinates)
        {
            if (coordinates != null)
            {
                foreach (var activity in coordinates)
                {
                    //Activities without a valid location cannot be mapped
                    if (activity.Latitude == null || activity.Longitude == null)
                    {
                        continue;
                    }

                    if (!context.Contains(activity))
                    {
                        context.Add(activity);
                        user.StartCoordinates.Add(activity);
                    }
                }
                user.LastDownload = DateTime.Now.Date;
                context.SaveChanges();
            }
        }
    }
}
