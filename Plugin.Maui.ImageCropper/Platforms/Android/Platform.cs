using AndroidX.Activity.Result;
using Com.Canhub.Cropper;
using Fragment = AndroidX.Fragment.App.Fragment;
using Object = Java.Lang.Object;

namespace Plugin.Maui.ImageCropper;

public class Platform
{
    public static void SetupActivityResultLauncher(MauiAppCompatActivity activity)
    {
        ImageCropperActivityResultLauncher = activity.RegisterForActivityResult(new CropImageContract(), new ActivityResultCallback());
    }

    public static ActivityResultLauncher ImageCropperActivityResultLauncher { get; set; }
}

public class ActivityResultCallback : Fragment, IActivityResultCallback
{
    public void OnActivityResult(Object cropImageResult)
    {
        if (cropImageResult is CropImage.ActivityResult result)
        {
            if (result.IsSuccessful)
            {
                ImageCropper.Current.Success?.Invoke(result.GetUriFilePath(Microsoft.Maui.ApplicationModel.Platform.AppContext, true));
            }
            else
            {
                ImageCropper.Current.Failure?.Invoke();
            }
        }
        else
        {
            ImageCropper.Current.Failure?.Invoke();
        }
    }
}
