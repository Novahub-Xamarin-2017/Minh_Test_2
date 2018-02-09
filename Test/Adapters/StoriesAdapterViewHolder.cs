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
using Android.Support.V7.Widget;
using Test.Models;
using Android.Graphics.Drawables;

namespace Test.Adapters
{
    public class StoriesAdapterViewHolder : RecyclerView.ViewHolder
    {
        private Story story;

        private ImageButton imageButton;

        public event EventHandler<StoriesAdapterClickEventArgs> StoryClick;

        public Story Story
        {
            set
            {
                imageButton.Background = Drawable.CreateFromStream(ItemView.Context.Assets.Open(value.Image), "");

                story = value;
            }
        }

        public StoriesAdapterViewHolder(View itemView) : base(itemView)
        {
            imageButton = itemView.FindViewById<ImageButton>(Resource.Id.imebtn_story);

            ItemView.FindViewById<ImageButton>(Resource.Id.imebtn_story).Click += (s,e) =>
            {
                StoryClick.Invoke(itemView, new StoriesAdapterClickEventArgs() { Content = story.Content });
            };
        }
    }
}