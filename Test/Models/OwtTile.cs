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
    public class OwtTile
    {
        [JsonProperty("imageUrl")]
        public String Image { set; get; }

        [JsonProperty("documentUrl")]
        public String Content { set; get; }
    }
}