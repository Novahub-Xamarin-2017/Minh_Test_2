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

namespace Test.Fragments
{
    public class StoriesFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.StoriesFragment, container, false);

            using (StreamReader stremReader = new StreamReader(view.Context.Assets.Open("stories.json")))
            {
                var content = stremReader.ReadToEnd();
                var stories = JsonConvert.DeserializeObject<List<Story>>(content);
                var adapter = new StoriesAdapter(stories);
                var recyclerView = view.FindViewById<RecyclerView>(Resource.Id.rccv_stories);
                recyclerView.SetLayoutManager(new LinearLayoutManager(view.Context, LinearLayoutManager.Horizontal, false));
                recyclerView.SetAdapter(adapter);

                adapter.StoryClick += (object sender, StoriesAdapterClickEventArgs e) =>
                {
                    view.StartActivityVideoOrPdf(e.Content);
                };
            }

            return view;
        }
    }
}