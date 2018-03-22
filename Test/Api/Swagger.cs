using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Test.Models;
using System.Net;
using Newtonsoft.Json;
using Android.Util;

namespace Test.Api
{
    class Swagger
    {
        private string root = "https://sdt-event-app.scapp.io/api";

        private WebClient webClient = new WebClient();

        private static Swagger instance;

        public static Swagger Instance => instance ?? (instance = new Swagger());

        public List<Story> GetStory()
        {
            var respone = webClient.DownloadString(root + "/Story");

            return JsonConvert.DeserializeObject<List<Story>>(respone);
        }

        public void PostContact(Contact contact)
        {
            webClient.Headers["Content-Type"] = "application/json";

            var respone = webClient.UploadString(root + "/Contact",JsonConvert.SerializeObject(contact));
        }
    }
}