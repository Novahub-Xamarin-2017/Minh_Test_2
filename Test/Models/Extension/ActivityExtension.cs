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
        public static void StartActivityVideoOrPdf(this Context context, string path)
        {
            var type = path.ToLower().EndsWith(".pdf") ? typeof(PdfActivity) : typeof(VideoActivity);
            var intent = new Intent(context, type);
            intent.PutExtra("uri", path);
            context.StartActivity(intent);
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