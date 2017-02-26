/*
using UnityEngine;
using GoogleMobileAds.Api;

namespace Serpent {

    public class AdsTest : MonoBehaviour {

        void OnGUI() {
            if (!GUI.Button(new Rect(10, 140, 100, 20), "Show ad"))
                return;

#if UNITY_EDITOR
            string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-2967834121881703/6337349671";
#elif UNITY_IPHONE
        string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
#else
        string adUnitId = "unexpected_platform";
#endif

            // Create a 320x50 banner at the top of the screen.
            BannerView bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder()
                .AddTestDevice(AdRequest.TestDeviceSimulator)
                .AddTestDevice("CE94A30A2574AC8CC4B12982480F9FFE")
                .Build();
            // Load the banner with the request.
            bannerView.LoadAd(request);
        }
    }

} // namespace Serpent
*/
