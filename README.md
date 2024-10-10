# Introduction 
.NET MAUI plugin to crop and rotate photos.

Ported over from : https://github.com/stormlion227/ImageCropper.Forms

[![NuGet](https://img.shields.io/nuget/v/Net.Maui.ImageCropper.svg?maxAge=2592000)](https://www.nuget.org/packages/Net.Maui.ImageCropper) ![NuGet](https://img.shields.io/nuget/dt/Net.Maui.ImageCropper)

Supports Android and iOS.
* Android library from : https://github.com/CanHub/Android-Image-Cropper
* iOS library from : https://github.com/TimOliver/TOCropViewController

## Features

* Cropping image.
* Rotating image.
* Aspect ratio.
* Circle/Rectangle shape.

## Screen-Shots

### Android
![Crop/Rotate image(Rectangle/Android)](./ScreenShots/Android_Rectangle.gif) ![Crop/Rotate image(Circle/Android)](./ScreenShots/Android_Circle.gif)

### iOS
![Crop/Rotate image(Rectangle/iOS)](./ScreenShots/iOS_Rectangle.gif) ![Crop/Rotate image(Circle/iOS)](./ScreenShots/iOS_Circle.gif)


## Setup

### MauiProgram

Add UseImageCropper() to your MauiProgram.cs file
```cs
	var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.UseImageCropper();
```

### Android

Add the following to your AndroidManifest.xml inside the <application> tags:
```xml	
	<activity android:name="com.canhub.cropper.CropImageActivity"
	          android:theme="@style/Base.Theme.AppCompat"/>	
```

In MainActivity.cs file:
```cs
	protected override void OnCreate(Bundle savedInstanceState)
	{
	    Plugin.Maui.ImageCropper.Platform.SetupActivityResultLauncher(this);
	
	    base.OnCreate(savedInstanceState);
	}
```

### iOS

In AppDelegate.cs file:

```cs
	No additional set up for iOS
```
## Usage

Before calling the code below, you should request the required permissions for accessing camera and gallery first.

```cs
    new ImageCropper()
    {
        Success = (imageFile) =>
        {
            Dispatcher.Dispatch(() =>
            {
                imageView.Source = ImageSource.FromFile(imageFile);
            });
        }
    }.Show(imageFileName);
```
### Properties
* PageTitle
* AspectRatioX
* AspectRatioY
* CropShape



# Build and Test
TODO: Describe and show how to build your code and run the tests. 

# Contribute
TODO: Explain how other users and developers can contribute to make your code better. 

