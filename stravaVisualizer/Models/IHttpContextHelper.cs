using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StravaVisualizer.Models
{
    public interface IHttpContextHelper
    {
         string getAccessToken();
    }
}
