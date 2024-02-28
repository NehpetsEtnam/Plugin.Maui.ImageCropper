using Plugin.Maui.ImageCropper.Platforms.iOS;

namespace Plugin.Maui.ImageCropper;

public class Platform
{
    public void Init()
    {
        DependencyService.Register<IImageCropperWrapper, PlatformImageCropper>();
    }
}
