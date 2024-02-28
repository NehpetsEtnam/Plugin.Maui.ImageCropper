namespace ImageCropper.Demo;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private async Task LoadPhotoAsync(FileBase photo)
    {
        // canceled
        if (photo == null)
        {
            return;
        }

        // save the file into local storage
        var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
        await using (var stream = await photo.OpenReadAsync())
        await using (var newStream = File.OpenWrite(newFile))
            await stream.CopyToAsync(newStream);

        var cropper = new Plugin.Maui.ImageCropper.ImageCropper
        {
            CropShape = Plugin.Maui.ImageCropper.ImageCropper.CropShapeType.Rectangle,
            AspectRatioX = 1,
            AspectRatioY = 1,
            CropButtonTitle = "Save",
            PageTitle = "Title",
            Success = (imageFile) =>
            {
                Dispatcher.Dispatch(() =>
                {
                    imageView.Source = ImageSource.FromFile(imageFile);
                });
            },
            Failure = () => {
                Console.WriteLine("Error capturing an image to crop.");
            }
        };

        cropper.Show(newFile);
    }

    private async Task TakePickPhotoAsync(bool isCapturePhoto)
    {
        try
        {
            FileResult? photo;

            if (isCapturePhoto)
            {
                photo = await MediaPicker.CapturePhotoAsync();
            }
            else
            {
                photo = await MediaPicker.PickPhotoAsync();
            }

            await LoadPhotoAsync(photo);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error in TakePickPhotoAsync : {e.Message} \n StackTrace : {e.StackTrace}");
        }
    }

    private async void OnGalleryClicked(System.Object sender, System.EventArgs e)
    {
        await TakePickPhotoAsync(false);
    }

    private async void OnCameraClicked(System.Object sender, System.EventArgs e)
    {
        await TakePickPhotoAsync(true);
    }
}


