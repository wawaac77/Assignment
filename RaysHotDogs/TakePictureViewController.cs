using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using Xamarin.Media;
using System.Threading.Tasks;
using MonoTouch.Dialog;

namespace RaysHotDogs
{
	partial class TakePictureViewController : UIViewController
	{
		private MediaPicker mediaPicker = new MediaPicker();
		private TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
		private DisposingMediaViewController dialogController;

		private UIAlertView alertView;
		private MediaPickerController mediaPickerController;

		public TakePictureViewController (IntPtr handle) : base (handle)
		{

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			TakePictureButton.TouchUpInside += (object sender, EventArgs e) => 
			{
				/*
				if (!mediaPicker.IsCameraAvailable) 
				{
					alertView = new UIAlertView ("Ray's Hot Dogs", "Sadly, you can't take pictures with your device :-(", 
						new UIAlertViewDelegate(), "OK");
					alertView.Show();

					return;
				}
				*/

				mediaPickerController = mediaPicker.GetTakePhotoUI (new StoreCameraMediaOptions 
				{
					Name = "hotdogselfie.jpg",
					Directory = "RaysHotDogsSelfies"
				});

				dialogController.PresentViewController (mediaPickerController, true, null);

				mediaPickerController.GetResultAsync().ContinueWith (t => 
				{
					dialogController.DismissViewController (true, () => 
					{
						if (t.IsCanceled || t.IsFaulted)
							return;

						MediaFile media = t.Result;
						ShowHotDogSelfie (media);
				});
				}, uiScheduler); 
			};
		}

		private void ShowHotDogSelfie (MediaFile media)
		{
			dialogController.Media = media;

			//image = new UIImageView (dialogController.View.Bounds);
			HotDogImage.Image = UIImage.FromFile (media.Path);

//			mediaController = new UIViewController();
//			mediaController.View.AddSubview (image);
//			mediaController.NavigationItem.LeftBarButtonItem = 
//				new UIBarButtonItem (UIBarButtonSystemItem.Done, (s, e) => viewController.PopViewControllerAnimated (true));
//
//			viewController.PushViewController (mediaController, true);
		}
	}

    class DisposingMediaViewController : DialogViewController
	{
		public DisposingMediaViewController (RootElement root)
			: base (root)
		{
		}

		public MediaFile Media
		{
			get;
			set;
		}

		public override void ViewDidAppear (bool animated)
		{
			// When we're done viewing the media, we should clean it up
			if (Media != null) {
				Media.Dispose();
				Media = null;
			}

			base.ViewDidAppear (animated);
		}
	}
}
