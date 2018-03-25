using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using Android.Media;
using Android.Graphics;
using Test.Models.Extension;
using Java.IO;
using System.IO;
using Android.Util;
using static Android.Media.MediaPlayer;
using Java.Lang;
using Android.Net;
using Android.Content.PM;

namespace Test
{
    [Activity(LaunchMode = LaunchMode.SingleInstance, ScreenOrientation = ScreenOrientation.Landscape, Label = "VideoActivity", Theme = "@android:style/Theme.Material.Light.NoActionBar.Fullscreen")]
    public class VideoActivity : Activity, ISurfaceHolderCallback
    {
        private MediaPlayer mediaPlayer;

        public void SurfaceChanged(ISurfaceHolder holder, [GeneratedEnum] Format format, int width, int height)
        {
        }

        public void SurfaceCreated(ISurfaceHolder holder)
        {
            mediaPlayer.SetDisplay(holder);
        }

        public void SurfaceDestroyed(ISurfaceHolder holder)
        {
            mediaPlayer.Stop();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var video = new VideoView(this);
            SetContentView(video);

            var url = Intent.GetStringExtra("uri");
            video.SetVideoPath(url);
            video.SetMediaController(new MediaController(this));
            video.Start();
        }
    }
}