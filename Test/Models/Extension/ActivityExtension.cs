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

namespace Test.Models.Extension
{
    public static class ActivityExtension
    {
        public static void StartActivityVideoOrPdf(this Activity activity, string path)
        {
            var type = path.EndsWith(".pdf") ? typeof(PdfActivity) : typeof(VideoActivity);
            var intent = new Intent(activity, type);
            intent.PutExtra("uri", path);
            activity.StartActivity(intent);
        }

        public static void SetButtonBack(this Activity activity)
        {
            activity.FindViewById<ImageButton>(Resource.Id.imebtn_back).Click += delegate
            {
                activity.Finish();
            };
        }
    }
}