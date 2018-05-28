using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SemEspera;
using SemEspera.Midia;
using SemEspera.Droid;
using Xamarin.Forms;
using Android.Provider;
using Android.Content;

[assembly: Xamarin.Forms.Dependency(typeof(MainActivity))]
namespace SemEspera.Droid
{
    [Activity(Label = "SemEspera", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, Icamera
    {
        static Java.IO.File arquivoImagem;
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            global::ZXing.Net.Mobile.Forms.Android.Platform.Init();



        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults) { global::ZXing.Net.Mobile.Forms.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults); }

        public void TirarFoto()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            
            arquivoImagem = GetFilepicture(intent);

            var activity = Forms.Context as Activity;
            activity.StartActivityForResult(intent, 0);
        }

        private static Java.IO.File GetFilepicture(Intent intent)
        {
            Java.IO.File arquivoImagem;
            Java.IO.File diretorio = new Java.IO.File(Android.OS.Environment.GetExternalStoragePublicDirectory(
            Android.OS.Environment.DirectoryPictures), "SemEsperaImages");

            if (!diretorio.Exists())
            {
                diretorio.Mkdirs();
            }

            arquivoImagem = new Java.IO.File(diretorio, "UserFoto.jpg");
            intent.PutExtra(MediaStore.ExtraOutput,
                Android.Net.Uri.FromFile(arquivoImagem));
            return arquivoImagem;
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok)
            {
                byte[] ImageBytes;
                using (var stream = new Java.IO.FileInputStream(arquivoImagem))
                {
                    ImageBytes = new byte[arquivoImagem.Length()];

                    stream.Read(ImageBytes);
                }

                MessagingCenter.Send<byte[]>(ImageBytes, "FotoCapturada");
            }

        }
    }
}

