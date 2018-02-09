using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Test.Models;

namespace Test.Adapters
{
    class StoriesAdapter : RecyclerView.Adapter
    {
        public event EventHandler<StoriesAdapterClickEventArgs> StoryClick;

        private List<Story> stories;

        public StoriesAdapter(List<Story> stories)
        {
            this.stories = stories;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var id = Resource.Layout.Story;
            var itemView = LayoutInflater.From(parent.Context).
                   Inflate(id, parent, false);

            var storiesAdapterViewHoler = new StoriesAdapterViewHolder(itemView);

            storiesAdapterViewHoler.StoryClick += StoryClick;

            return storiesAdapterViewHoler;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            ((StoriesAdapterViewHolder)viewHolder).Story = stories[position];
        }

        public override int ItemCount => stories.Count;
    }
}