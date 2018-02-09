using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

namespace Test.Adapters
{
    public class StoriesAdapterClickEventArgs : EventArgs
    {
        public String Content { get; set; }
    }
}