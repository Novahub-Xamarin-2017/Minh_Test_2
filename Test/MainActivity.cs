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
using Android.Content.PM;

namespace Test
{
    [Activity(ScreenOrientation = ScreenOrientation.Landscape, Label = "Test", Theme = "@android:style/Theme.Material.Light.NoActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private OpenWebFragment openWebFragment = new OpenWebFragment();

        private StoriesFragment storiesFragment = new StoriesFragment();

        private ContactFragment contactFragment = new ContactFragment();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            FragmentManager.BeginTransaction().Replace(Resource.Id.framelayout, openWebFragment).Commit();

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

            buttons.ForEach(x => x.Click += OnClick);
        }

        private void OnClick(object sender, System.EventArgs e)
        {
            switch (((View)(sender)).Id)
            {
                case Resource.Id.btn_main:
                    ReplaceFragment(openWebFragment);
                    break;
                case Resource.Id.btn_stories:
                    ReplaceFragment(storiesFragment);
                    break;
                case Resource.Id.btn_contact:
                    ReplaceFragment(contactFragment);
                    break;
            }
        }

        private void ReplaceFragment(Fragment fragment)
        {
            FragmentManager.BeginTransaction().Replace(Resource.Id.framelayout, fragment).Commit();
        }
    }
}

