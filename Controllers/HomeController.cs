using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using MvcApplication4.Models;
using MongoDB;
using MvcApplication4.Models;

namespace MvcApplication4.Controllers
{
    public class HomeController : Controller
    {
        
       
        public ActionResult Index()
        {
           
            


            return View();
        }
       

       
        public ActionResult About()
        {
            return View();
        }
        public ActionResult JsonAction()
        {
            
            var mongoServSettings = new MongoDB.Driver.MongoServerSettings();

            mongoServSettings.Server = new MongoDB.Driver.MongoServerAddress("localhost");

            var mongoServer = new MongoDB.Driver.MongoServer(mongoServSettings);

            mongoServer.Connect();

            var db = mongoServer.GetDatabase("monitera");
   
            var collection = db.GetCollection<db>("dbo.post");
           //collection.Insert(new db { gender = "m"});


            var erkek = Query<db>.Where( f => f.gender == "e");
            var kadin = Query<db>.Where( f => f.gender == "k");

            var erk = collection.Count(erkek);
            var k = collection.Count(kadin);


           
            var chartData = (new[]{
                                 new{
                                     Gender = "Male",
                                     value = erk
                                 },

           new {
                Gender = "Female",
                value = k


            }
            }
            );

            return Json(chartData, JsonRequestBehavior.AllowGet);

           
        }

        public ActionResult JsonAction2()
        {

            var mongoServSettings = new MongoDB.Driver.MongoServerSettings();

            mongoServSettings.Server = new MongoDB.Driver.MongoServerAddress("localhost");

            var mongoServer = new MongoDB.Driver.MongoServer(mongoServSettings);

            mongoServer.Connect();

            var db = mongoServer.GetDatabase("monitera");




            var collection = db.GetCollection<db>("dbo.post");
            //collection.Insert(new db { gender = "m"});




            var pozitif = Query<db>.Where(f => f.sentimentid == 1);
            var notr = Query<db>.Where(f => f.sentimentid == 2);
            var negatif = Query<db>.Where(f => f.sentimentid == 3);
            var poznotr = Query<db>.Where(f => f.sentimentid == 4);
            var negnotr = Query<db>.Where(f => f.sentimentid == 5);


            var poz = collection.Count(pozitif);
            var no = collection.Count(notr);
            var ne = collection.Count(negatif);
            var pn = collection.Count(poznotr);
            var nn = collection.Count(negnotr);


            var oranlar = (new[]{
                                 new{
                                     Durum = "Pozitif",
                                     value = poz
                                 },

           new {
                Durum = "Nötr",
                value = no


            },
            new {
                Durum = "Negatif",
                value = ne


            },
            new {
                Durum = "Pozitif - Nötr",
                value = pn


            },
            new {
                Durum = "Negatif - Nötr",
                value = nn


            }
            }
            );




            return Json(oranlar, JsonRequestBehavior.AllowGet);


        }

        public ActionResult JsonAction3()
        {

            var mongoServSettings = new MongoDB.Driver.MongoServerSettings();

            mongoServSettings.Server = new MongoDB.Driver.MongoServerAddress("localhost");

            var mongoServer = new MongoDB.Driver.MongoServer(mongoServSettings);

            mongoServer.Connect();

            var db = mongoServer.GetDatabase("monitera");




            var collection = db.GetCollection<db>("dbo.post");
            //collection.Insert(new db { gender = "m"});




            var cs = Query<db>.Where(f => f.sourceid == 1);
            var cs1 = Query<db>.Where(f => f.sourceid == 2);
            var cs2 = Query<db>.Where(f => f.sourceid == 25);
            var cs3 = Query<db>.Where(f => f.sourceid == 31);
            var cs4 = Query<db>.Where(f => f.sourceid== 19);


            var tw = collection.Count(cs);
            var ff = collection.Count(cs1);
            var face = collection.Count(cs2);
            var rss = collection.Count(cs3);
            var blog = collection.Count(cs4);


            var kaynaklar = (new[]{
                                 new{
                                     Kaynak = "Twitter",
                                     value = tw
                                 },

           new {
               Kaynak = "FriendFeed",
                value = ff


            },
            new {
                Kaynak = "Facebook",
                value = face


            },
            new {
                Kaynak = "HaberRss",
                value = rss


            },
            new {
                Kaynak = "Blog",
                value = blog


            }
            }
            );




            return Json(kaynaklar, JsonRequestBehavior.AllowGet);


        }

      

        
    }
}
