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
using Test.Models;
using Test.Api;
using Square.Picasso;

namespace Test.Fragments
{
    public class OpenWebFragment : Fragment
    {
        private View view;

        private List<OwtTile> owtTiles;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.OpenWebFragment, container, false);

            owtTiles = Swagger.Instance.GetOwtTile();

            new List<int>()
            {
                Resource.Id.imebtn_discover,
                Resource.Id.imebtn_services,
                Resource.Id.imebtn_numbers,
                Resource.Id.imebtn_people,
                Resource.Id.imebtn_venture
            }.ForEach(x => 
            {
                view.FindViewById<ImageButton>(x).Click += OwtTile_Click;
                LoadImageForOwtTile(x);
            });

            return view;
        }

        private void LoadImageForOwtTile(int id)
        {
            var imageButton = view.FindViewById<ImageButton>(id);

            switch (id)
            {
                case Resource.Id.imebtn_discover:
                    LoadImage(owtTiles[0].Image, imageButton);
                    break;
                case Resource.Id.imebtn_people:
                    LoadImage(owtTiles[1].Image, imageButton);
                    break;
                case Resource.Id.imebtn_numbers:
                    LoadImage(owtTiles[2].Image, imageButton);
                    break;
                case Resource.Id.imebtn_services:
                    LoadImage(owtTiles[3].Image, imageButton);
                    break;
                case Resource.Id.imebtn_venture:
                    LoadImage(owtTiles[4].Image, imageButton);
                    break;
            }
        }

        private void LoadImage(string uriImage, ImageButton imageButton)
        {
            Picasso.With(view.Context).Load(uriImage).Fit().Into(imageButton);
        }

        private void OwtTile_Click(object sender, EventArgs e)
        {
            switch (((View)sender).Id)
            {
                case Resource.Id.imebtn_discover:
                    StartActivityVideoOrPdf(owtTiles[0].Content);
                    break;
                case Resource.Id.imebtn_people:
                    StartActivityVideoOrPdf(owtTiles[1].Content);
                    break;
                case Resource.Id.imebtn_numbers:
                    StartActivityVideoOrPdf(owtTiles[2].Content);
                    break;
                case Resource.Id.imebtn_services:
                    StartActivityVideoOrPdf(owtTiles[3].Content);
                    break;
                case Resource.Id.imebtn_venture:
                    StartActivityVideoOrPdf(owtTiles[4].Content);
                    break;
            }
        }

        private void StartActivityVideoOrPdf(string uri)
        {
            view.Context.StartActivityVideoOrPdf(uri);
        }
    }
}