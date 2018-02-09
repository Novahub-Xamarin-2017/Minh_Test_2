using Android.App;
using Android.Widget;
using Android.OS;
using Com.Joanzapata.Pdfview;
using Android.Webkit;
using Java.IO;
using Android.Net;
using System.Threading.Tasks;
using System.IO;
using Android.Media;
using Android.Views;
using Android.Graphics;
using Test.Models.Extension;
using System.Collections.Generic;
using System.Linq;
using Android.Content;

namespace Test
{
    [Activity(Label = "Test", Theme = "@android:style/Theme.Material.Light.NoActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);
            this.SetButton();
            FindViewById<Button>(Resource.Id.btn_main).SetTextColor(Color.Red);

            var imageButtons = new List<int>()
            {
                Resource.Id.imebtn_discover,
                Resource.Id.imebtn_services,
                Resource.Id.imebtn_numbers,
                Resource.Id.imebtn_people,
                Resource.Id.imebtn_venture
            }.Select(x => FindViewById<ImageButton>(x)).ToList();

            var index = 0;

            new List<string>()
            {
                "OneMinuteOpenWT.mp4",
                "Service Offering.pdf",
                "In the Numbers.pdf",
                "People Behind.pdf",
                "Joint Venture.pdf"
            }.ForEach(x =>
            {
                imageButtons[index].Click += delegate
                {
                    this.StartActivityVideoOrPdf(x);
                };

                index++;
            });
        }
    }
}

