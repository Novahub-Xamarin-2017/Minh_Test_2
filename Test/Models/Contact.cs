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
using Newtonsoft.Json;

namespace Test.Models
{
    class Contact
    {
        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("helloTo")]
        public string HelloTo { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("industry")]
        public string Industry { get; set; }

        [JsonProperty("comments")]
        public string Comments { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("images")]
        public List<Image> Images { get; set; }
    }
}