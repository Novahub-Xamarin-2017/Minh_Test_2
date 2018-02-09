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
using Test.Adapters;
using Newtonsoft.Json;
using Test.Models;
using System.IO;
using Android.Support.V7.Widget;
using Test.Models.Extension;
using Android.Graphics;

namespace Test
{
    [Activity(Label = "StoriesActivity", Theme = "@android:style/Theme.Material.Light.NoActionBar")]
    public class StoriesActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Stories);
            this.SetButton();
            FindViewById<Button>(Resource.Id.btn_stories).SetTextColor(Color.Red);

            using (StreamReader stremReader = new StreamReader(Assets.Open("stories.json")))
            {
                var content = stremReader.ReadToEnd();
                var stories = JsonConvert.DeserializeObject<List<Story>>(content);
                var adapter = new StoriesAdapter(stories);
                var recyclerView = FindViewById<RecyclerView>(Resource.Id.rccv_stories);
                recyclerView.SetLayoutManager(new LinearLayoutManager(this, LinearLayoutManager.Horizontal, false));
                recyclerView.SetAdapter(adapter);

                adapter.StoryClick += (object sender, StoriesAdapterClickEventArgs e) =>
                {
                    this.StartActivityVideoOrPdf(e.Content);
                };
            }
        }
    }
}