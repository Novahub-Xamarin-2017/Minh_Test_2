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
using Com.Joanzapata.Pdfview;
using Android.Webkit;
using Test.Models.Extension;

namespace Test
{
    [Activity(Label = "PdfActivity", Theme = "@android:style/Theme.Material.Light.NoActionBar")]
    public class PdfActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Pdf);

            this.SetButtonBack();

            FindViewById<PDFView>(Resource.Id.pdfv_story).FromAsset(Intent.GetStringExtra("uri"))
                    .Load();
        }
    }
}