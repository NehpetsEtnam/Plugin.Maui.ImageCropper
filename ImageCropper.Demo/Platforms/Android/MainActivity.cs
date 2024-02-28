using Android.App;
using Android.Content.PM;
using Android.OS;

namespace ImageCropper.Demo;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        new Plugin.Maui.ImageCropper.Platform().Init(this);

        base.OnCreate(savedInstanceState);
    }
}

