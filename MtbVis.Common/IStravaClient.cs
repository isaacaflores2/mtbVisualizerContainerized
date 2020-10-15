using IO.Swagger.Model;
using System;
using System.Collections.Generic;

namespace MtbVis.Common
{
    public interface IStravaClient
    {
        IEnumerable<VisualActivity> getAllUserActivities(string accessToken, int userId);
        IEnumerable<VisualActivity> getUserActivitiesByIdAfter(string accessToken, DateTime afterDate);
        IEnumerable<Coordinates> getAllUserCoordinatesById(string accessToken, int id);
        IEnumerable<Coordinates> getUserCoordinatesByIdAfter(string accessToken, DateTime afterDate);

    }
}
