using banditoth.MAUI.JailbreakDetector;
using banditoth.MAUI.JailbreakDetector.Entities;
using banditoth.MAUI.JailbreakDetector.Interfaces;
using Xamarin.Forms.RootCheck;

namespace MauiRootDetection;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        IJailbreakDetectorConfiguration jailbreakDetectorConfiguration = new JailbreakSettings();
        jailbreakDetectorConfiguration.MaximumPossibilityPercentage = 20;
        jailbreakDetectorConfiguration.MaximumWarningCount = 1;
        jailbreakDetectorConfiguration.CanThrowException = true;

        IJailbreakDetector jailbreakDetector = new JailberakDetectorService(jailbreakDetectorConfiguration);
        //var isRooted = RootCheck.Current.IsDeviceRooted();
        if (jailbreakDetector.IsSupported())
        {
            var isRooted = await jailbreakDetector.IsRootedOrJailbrokenAsync();
            if (isRooted)
            {
                await DisplayAlert("ANDROIDMADS - .NET MAUI", "DEVICE IS ROOTED", "OK");
            }
            else
            {
                await DisplayAlert("ANDROIDMADS - .NET MAUI", "DEVICE IS NOT ROOTED", "OK");
            }
        }
    }
}

