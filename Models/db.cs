using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace MvcApplication4.Models
{
    public class db
    {

        public ObjectId Id { get; set; }

        public String gender { get; set; }

        public int sentimentid { get; set; }


        public int sourceid { get; set; }


        public String profileImgUrl { get; set; }
        public String username { get; set; }
        public String title { get; set; }
        public String insertDate { get; set; }

    }
}