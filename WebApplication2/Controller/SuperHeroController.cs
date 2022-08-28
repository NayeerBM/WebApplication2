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
            return Ok(supe);
        }
        public async Task<IHttpActionResult> Get(int id)
        {
            var hero = (object)"";
            await Task.Run(() =>
            {
                hero = supe.Find(r => r.id == id);
            });
            if (hero == null)
                return Content(HttpStatusCode.NotFound, $"Id {id} does not exist");
            return
                Ok(hero);
        }

    }
}
