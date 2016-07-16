using Microsoft.AdMediator.Core.Models;
using Microsoft.AdMediator.Universal;
using Microsoft.Advertising.WinRT.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PokemonUwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();      
        }    

        InterstitialAd MyVideoAd = new InterstitialAd();
        string MyAppId;
        string MyAdUnitId;
        string add;
        List<string> poke = new List<string>();

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await Onload();
        }
        private async Task Onload()
        {
            AdMediator_BFF56C.AdSdkTimeouts[AdSdkNames.MicrosoftAdvertising] = TimeSpan.FromSeconds(10);
            bool isHardwareButtonsAPIPresent =
                 Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons");

            if (isHardwareButtonsAPIPresent)
            {
                AdMediator_096175.Width = 300;
                AdMediator_5D537D.Width = 300;
                AdMediator_93C6F9.Width = 640;
                AdMediator_BFF56C.Width = 640;

                AdMediator_096175.Height = 50;
                AdMediator_5D537D.Height = 50;
                AdMediator_93C6F9.Height = 100;
                AdMediator_BFF56C.Height = 100;

                    
                MyAppId = "7ad6be47-2daf-45e4-9a42-fdbbccd0f895";
                MyAdUnitId = "11633529";
            }
            else
            {
                MyAppId = "2cdad002-3f40-47c8-9827-80f5b9beaf52";
                MyAdUnitId = "11633528";
            }

            await Get_Gps();
         
            MyVideoAd.AdReady += MyVideoAd_AdReady;
            MyVideoAd.ErrorOccurred += MyVideoAd_ErrorOccurred;
            MyVideoAd.Completed += MyVideoAd_Completed;
            MyVideoAd.Cancelled += MyVideoAd_Cancelled;
            add = "Pikachu";
            poke.Add(add);
            add = "Charmendar";
            poke.Add(add);
            add = "Bulbasaur";
            poke.Add(add);
            add = "pichu";
            poke.Add(add);
            add = "Raichu";
            poke.Add(add);
            add = "Squirtle";
            poke.Add(add);
            add = "Charizard";
            poke.Add(add);
            add = "Diglet";
            poke.Add(add);
            add = "Snorlax";
            poke.Add(add);
            add = "Jigglepuff";
            poke.Add(add);
            lol();


            MyVideoAd.RequestAd(AdType.Video, MyAppId, MyAdUnitId);

            if ((InterstitialAdState.Ready) == (MyVideoAd.State))
            {
                MyVideoAd.Show();
            }

        }

        MapIcon mapIcon1 = new MapIcon();
        private async Task Get_Gps()
        {

            Geolocator geolocator = new Geolocator();
            Geoposition pos = await geolocator.GetGeopositionAsync();
            Geopoint myLocation = pos.Coordinate.Point;

           
            mapIcon1.Location = myLocation;
            mapIcon1.NormalizedAnchorPoint = new Point(0.5, 1.0);
            mapIcon1.Title = "Space Needle";
            mapIcon1.ZIndex = 0;
            MapControl1.MapElements.Add(mapIcon1);
            MapControl1.Center = myLocation;
            MapControl1.ZoomLevel = 16;
        }

        async Task lol()
        {
            Random rnd = new Random();
            int Random = rnd.Next(0, 9);
            mapIcon1.Title = poke[Random];
            await Task.Delay(5000);
            await lol();
        }
            
        void MyVideoAd_AdReady(object sender, object e)
        {
            AdMediator_096175.Pause();
            AdMediator_5D537D.Pause();
            AdMediator_93C6F9.Pause();
            AdMediator_BFF56C.Pause();
            if ((InterstitialAdState.Ready) == (MyVideoAd.State))
            {
                MyVideoAd.Show();
            }
        }

        void MyVideoAd_ErrorOccurred(object sender, AdErrorEventArgs e)
        {
            AdMediator_096175.Resume();
            AdMediator_5D537D.Resume();
            AdMediator_93C6F9.Resume();
            AdMediator_BFF56C.Resume();
        }

       void MyVideoAd_Completed(object sender, object e)
        {
            AdMediator_096175.Resume();
            AdMediator_5D537D.Resume();
            AdMediator_93C6F9.Resume();
            AdMediator_BFF56C.Resume();
        }

        void MyVideoAd_Cancelled(object sender, object e)
        {
            AdMediator_096175.Resume();
            AdMediator_5D537D.Resume();
            AdMediator_93C6F9.Resume();
            AdMediator_BFF56C.Resume();
        }
    }
}
