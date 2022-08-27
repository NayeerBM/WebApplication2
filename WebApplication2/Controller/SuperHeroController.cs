using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controller
{
    
    public class SuperHeroController : ApiController
    {
        private static List<SuperHero> supe = new List<SuperHero> {
            new SuperHero{id=0, FirstName="Peter",LastName="Parker",HeroName="Spider-man"},
            new SuperHero{id=1, FirstName="Tony",LastName="Stark",HeroName="Iron Man"}
        };

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            /*var request = HttpContext.Current.Request;
            var authHeader = request.Headers["Authorization"];
            var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);
            var authHeaderParam = authHeaderVal.Parameter;
            test(authHeaderParam);
            
            var n = "test";*/
            return Ok(supe);
        }
        public async Task<IHttpActionResult> Get(int id)
        {
            var hero= supe.Find(r=>r.id==id);
            return Ok(hero);
        }
        public void test(string credentials)
        {
            var encoding = Encoding.GetEncoding("utf-8");
            credentials = encoding.GetString(Convert.FromBase64String(credentials));

            int separator = credentials.IndexOf(':');
            string name = credentials.Substring(0, separator);
            string password = credentials.Substring(separator + 1);
            var test = "";

        }

    }
}
