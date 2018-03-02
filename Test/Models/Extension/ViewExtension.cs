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
    public static class ViewExtension
    {
        public static void StartActivityVideoOrPdf(this View view, string path)
        {
            var type = path.EndsWith(".pdf") ? typeof(PdfActivity) : typeof(VideoActivity);
            var intent = new Intent(view.Context, type);
            intent.PutExtra("uri", path);
            view.Context.StartActivity(intent);
        }
    }
}