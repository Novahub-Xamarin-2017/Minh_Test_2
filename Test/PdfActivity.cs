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
using Android.Content.PM;

namespace Test
{
    [Activity(ScreenOrientation = ScreenOrientation.Landscape, LaunchMode = LaunchMode.SingleInstance, Label = "PdfActivity", Theme = "@android:style/Theme.Material.Light.NoActionBar")]
    public class PdfActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var type = Intent.GetStringExtra("type");

            if (type.Equals("1"))
            {
                var webView = new WebView(this);
                webView.Settings.JavaScriptEnabled = true;
                SetContentView(webView);
                var root = "https://drive.google.com/viewerng/viewer?url=";
                var url = root + Intent.GetStringExtra("uri");
                webView.LoadUrl(url);
            }
            else
            {
                SetContentView(Resource.Layout.Pdf);
                this.SetButtonBack();

                FindViewById<PDFView>(Resource.Id.pdfv_story).FromAsset(Intent.GetStringExtra("uri"))
                        .Load();
            }
        }
    }
}