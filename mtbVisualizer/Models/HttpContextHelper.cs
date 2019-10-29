using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace MtbVisualizer.Models
{
    public class HttpContextHelper : IHttpContextHelper
    {
        public HttpContext Context { get; set; }
 
        public string getAccessToken()
        {
            return getToken("access_token").Result;
        }

        private async Task<string> getToken(string token)
        {
            if (Context != null)
                return await Context.GetTokenAsync(token);
            else
                throw new NullReferenceException("Context for HttpContextHelper is null. Assing helper a context.");
        }
    }
}
