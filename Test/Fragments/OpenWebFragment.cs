using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Test.Models.Extension;

namespace Test.Fragments
{
    public class OpenWebFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.OpenWebFragment, container, false);

            var imageButtons = new List<int>()
            {
                Resource.Id.imebtn_discover,
                Resource.Id.imebtn_services,
                Resource.Id.imebtn_numbers,
                Resource.Id.imebtn_people,
                Resource.Id.imebtn_venture
            }.Select(x => view.FindViewById<ImageButton>(x)).ToList();

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
                    view.StartActivityVideoOrPdf(x);
                };

                index++;
            });

            return view;
        }
    }
}