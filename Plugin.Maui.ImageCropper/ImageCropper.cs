namespace Plugin.Maui.ImageCropper;

public class ImageCropper
{
    public static ImageCropper Current { get; set; }

    public ImageCropper()
    {
        Current = this;
    }

    public enum CropShapeType
    {
        Rectangle,
        Oval
    };

    public CropShapeType CropShape { get; set; } = CropShapeType.Rectangle;

    public int AspectRatioX { get; set; } = 0;

    public int AspectRatioY { get; set; } = 0;

    public string PageTitle { get; set; } = null;

    public string CropButtonTitle { get; set; } = "Crop";

    public string CancelButtonTitle { get; set; } = "Cancel";

    public Action<string> Success { get; set; }

    public Action Failure { get; set; }

    public async void Show(string imageFile)
    {
        if (imageFile == null)
        {
            return;
        }

        // small delay
        await Task.Delay(TimeSpan.FromMilliseconds(100));

        DependencyService.Get<IImageCropperWrapper>().ShowFromFile(this, imageFile);
    }
}
