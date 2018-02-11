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
using Test.Models.Extension;
using Android.Graphics;
using Android.Provider;

namespace Test
{
    [Activity(Label = "ContactActivity", Theme = "@android:style/Theme.Material.Light.NoActionBar")]
    public class ContactActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Contact);
            this.SetButton();
            FindViewById<Button>(Resource.Id.btn_contact).SetTextColor(Color.Red);

            FindViewById<ImageButton>(Resource.Id.imebtn_takecard).Click += delegate
            {
                var intent = new Intent(MediaStore.ActionImageCapture);
                StartActivityForResult(intent, 0);
            };
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            FindViewById<ImageView>(Resource.Id.imev_card).SetImageBitmap((Bitmap)data.Extras.Get("data"));
        }
    }
}