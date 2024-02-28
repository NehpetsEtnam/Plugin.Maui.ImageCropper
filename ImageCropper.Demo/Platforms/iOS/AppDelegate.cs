using Foundation;
using UIKit;

namespace ImageCropper.Demo;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        new Plugin.Maui.ImageCropper.Platform().Init();

        return base.FinishedLaunching(application, launchOptions);
    }
}

