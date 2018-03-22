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
    class Image
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("imageBase64")]
        public string ImageBase64 { get; set; }
    }
}