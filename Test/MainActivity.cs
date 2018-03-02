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
using Test.Fragments;
using Android.Runtime;
using Android.Content.Res;

namespace Test
{
    [Activity(Label = "Test", Theme = "@android:style/Theme.Material.Light.NoActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            FragmentManager.BeginTransaction().Replace(Resource.Id.framelayout, new OpenWebFragment()).Commit();

            var buttons = new List<int>()
            {
                Resource.Id.btn_main,
                Resource.Id.btn_stories,
                Resource.Id.btn_contact
            }.Select(x => FindViewById<Button>(x)).ToList();
            
            buttons.ForEach(x => x.Click += delegate
            {
                buttons.ForEach(y => y.SetTextColor(Color.Black));
                x.SetTextColor(Color.Red);
            });

            buttons[0].Click += delegate
            {
                FragmentManager.BeginTransaction().Replace(Resource.Id.framelayout, new OpenWebFragment()).Commit();
            };

            buttons[1].Click += delegate
            {
                FragmentManager.BeginTransaction().Replace(Resource.Id.framelayout, new StoriesFragment()).Commit();
            };

            buttons[2].Click += delegate
            {
                FragmentManager.BeginTransaction().Replace(Resource.Id.framelayout, new ContactFragment()).Commit();
            };
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            FindViewById<ImageView>(Resource.Id.imev_card).SetImageBitmap((Bitmap)data.Extras.Get("data"));
        }
    }
}

