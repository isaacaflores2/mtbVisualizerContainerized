using IO.Swagger.Model;
using System;
using System.Collections.Generic;

namespace Summary.API.Models
{
    public interface IStravaClient
    {
        IEnumerable<VisualActivity> getAllUserActivities(string accessToken, int id);
        IEnumerable<VisualActivity> getUserActivitiesByIdAfter(string accessToken, User user, DateTime afterDate);
       
    }
}
