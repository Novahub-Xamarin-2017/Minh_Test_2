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

namespace Test
{
    [Activity(Label = "VideoActivity", Theme = "@android:style/Theme.Material.Light.NoActionBar")]
    public class VideoActivity : Activity, ISurfaceHolderCallback
    {
        private MediaPlayer mediaPlayer;

        private VideoView videoView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Video);

            this.SetButtonBack();

            videoView = FindViewById<VideoView>(Resource.Id.vdv_story);

            var holder = videoView.Holder;
            holder.SetType(SurfaceType.PushBuffers);
            holder.AddCallback(this);

            var descriptor = Assets.OpenFd("OneMinuteOpenWT.mp4");
            mediaPlayer = new MediaPlayer();
            mediaPlayer.SetDataSource(descriptor.FileDescriptor, descriptor.StartOffset, descriptor.Length);
            mediaPlayer.Prepare();
            mediaPlayer.Looping = true;
            mediaPlayer.Start();
        }

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
    }
}