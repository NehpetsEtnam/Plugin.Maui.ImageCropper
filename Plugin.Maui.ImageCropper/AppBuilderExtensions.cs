#if ANDROID
using Plugin.Maui.ImageCropper.Platforms.Android;
#endif
#if IOS
using Plugin.Maui.ImageCropper.Platforms.iOS;
#endif

namespace Plugin.Maui.ImageCropper;

public static class AppBuilderExtensions
{
    /// <summary>
    /// Supports Android and iOS only
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static MauiAppBuilder UseImageCropper(this MauiAppBuilder builder)
    {
#if ANDROID || IOS
        DependencyService.Register<IImageCropperWrapper, PlatformImageCropper>();
#endif
        return builder;
    }
}