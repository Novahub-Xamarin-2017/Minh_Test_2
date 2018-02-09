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
        }
    }
}