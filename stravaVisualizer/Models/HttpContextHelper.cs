using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StravaVisualizer.Models
{
    public class HttpContextHelper : IHttpContextHelper
    {
        private readonly HttpContext _context;

        public HttpContextHelper(HttpContext context)
        {
            this._context = context;
        }

        public string getAccessToken()
        {
            return geToken("access_token").Result;
        }

        private async Task<string> geToken(string token)
        {
            return await _context.GetTokenAsync(token);
        }
    }
}
