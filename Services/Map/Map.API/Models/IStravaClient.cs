using IO.Swagger.Model;
using Map.API.Models;
using System;
using System.Collections.Generic;

namespace Map.API.Models
{
    public interface IStravaClient
    {
        IEnumerable<VisualActivity> getAllUserActivities(string accessToken, int id);
        IEnumerable<VisualActivity> getUserActivitiesByIdAfter(string accessToken, User user, DateTime afterDate);
        IEnumerable<Coordinates> getAllUserCoordinatesById(string accessToken, int id);
        IEnumerable<Coordinates> getUserCoordinatesById(string accessToken, User user, DateTime afterDate);
    }
}
