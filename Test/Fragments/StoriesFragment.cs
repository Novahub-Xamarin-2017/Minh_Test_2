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
using System.IO;
using Newtonsoft.Json;
using Test.Models;
using Test.Adapters;
using Android.Support.V7.Widget;
using Test.Models.Extension;
using Test.Api;

namespace Test.Fragments
{
    public class StoriesFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.StoriesFragment, container, false);

            var stories = Swagger.Instance.GetStory();
            var adapter = new StoriesAdapter(stories);
            var recyclerView = view.FindViewById<RecyclerView>(Resource.Id.rccv_stories);
            recyclerView.SetLayoutManager(new LinearLayoutManager(view.Context, LinearLayoutManager.Horizontal, false));
            recyclerView.SetAdapter(adapter);

            adapter.StoryClick += (object sender, StoriesAdapterClickEventArgs e) =>
            {
                view.StartActivityVideoOrPdf(e.Content);
            };

            return view;
        }
    }
}