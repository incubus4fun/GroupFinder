﻿using GroupFinder.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SpotifyAPI.Web; //Base Namespace
using SpotifyAPI.Web.Auth; //All Authentication-related classes
using SpotifyAPI.Web.Enums; //Enums
using SpotifyAPI.Web.Models;
using System.Web.Script.Serialization;

namespace GroupFinder.Controllers
{
    public class AppController : Controller
    {
        private GROUP_FINDEREntities db = new GROUP_FINDEREntities();
        // GET: App
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(ClassMate classMate)
        {
            var model = from r in db.ClassMates
                        where r.loginhash == classMate.loginhash
                && r.email == classMate.email
                        select r;


            var item = model.FirstOrDefault();
            if (item != null)
            {
                Questions questions = new Questions();
                questions.classmate = item;
                questions.idealSaturdays = db.IdealSaturdays.ToList();
                questions.vacations = db.Vacations.ToList();
                questions.foods = db.Foods.ToList();
                return View("Questions", questions);
            }
            else

            {
                ViewBag.NotValidUser = item;

            }


            return View("login");
        }

        public ActionResult Questions()
        {
            return View();
        }



        public async Task<String> GetSpotifyData(string searchTerm)
        {
            CredentialsAuth auth = new CredentialsAuth("078c7392711e4b978d6a3bd21984c93c", "8b7f7c3b96454fcd8b42193a179ca19b");
            Token token = await auth.GetToken();
            SpotifyWebAPI api = new SpotifyWebAPI() { TokenType = token.TokenType, AccessToken = token.AccessToken };
            SearchItem item =  api.SearchItems(searchTerm, SearchType.All, 10, 0, "US");
            var json = new JavaScriptSerializer().Serialize(item.Artists);
            return json;
        }
    }
}