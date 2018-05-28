//using Plugin.Vibrate;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using ZXing.Mobile;
//using ZXing.Net.Mobile.Forms;

//namespace SemEspera.Helpers
//{
//    public  class util
//    {
//        public static void Vibrar() {
//            try
//            {
//                var v = CrossVibrate.Current;
//                v.Vibration();
//            }
//            catch { }
//        }
//        public async static Task<ZXingScannerPage> CapturarCodeAsync(ZXingScannerPage Scanpage, string Titulo, ZXing.BarcodeFormat formato) {

//            if (Scanpage == null)
//            {
//                var options = new ZXing.Mobile.MobileBarcodeScanningOptions();
//                options.PossibleFormats = new List<ZXing.BarcodeFormat>() { formato};

//#if _ANDROID_
//                //fsafdasfa
//               MobileBarcodeScanner.Initialize(Application); 
//#endif
//                Scanpage.Title = Titulo;
//                return Scanpage;
//            }

//        }
//    }
//}
