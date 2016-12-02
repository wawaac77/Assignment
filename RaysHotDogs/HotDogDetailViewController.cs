using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using RaysHotDogs.Core;

namespace RaysHotDogs
{
	partial class HotDogDetailViewController : UIViewController
	{
		public HotDogDetailViewController () : base ("HotDogDetailViewController", null)
		{
		}

		public HotDogDetailViewController (IntPtr handle) : base (handle)
		{
		}

		public HotDog SelectedHotDog {
			get;
			set;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			DatabindUI ();

			AddToCartButton.TouchUpInside += (object sender, EventArgs e) => 
			{
				AddToCart(SelectedHotDog, Int32.Parse(AmountText.Text));
		
				UIAlertView message = new UIAlertView ("Ray's Hot Dogs", "That hot dog was added to your order", null, "OK", null);
				message.Show ();

				this.DismissModalViewController(true);
			};

			CancelButton.TouchUpInside += (object sender, EventArgs e) => 
			{
				this.DismissModalViewController(true);
				//UIAlertView cancelConfirm = new UIAlertView("Ray's Hot Dogs", "Do you really want to cancel?", null, "OK", null);
				//cancelConfirm.Show();
			};
		}

		private void DatabindUI()
		{
			UIImage img = UIImage.FromFile ("Images/" + SelectedHotDog.ImagePath + ".jpg");
			HotDogImageView.Image = img;
			NameLabel.Text = SelectedHotDog.Name;
			ShortDescriptionLabel.Text = SelectedHotDog.ShortDescription;
			LongDescriptionText.Text = SelectedHotDog.Description;
			PriceLabel.Text = "$" + SelectedHotDog.Price.ToString();
		}

		public void AddToCart(HotDog hotDog, int amount)
		{
			CartDataService cartDataService = new CartDataService ();
			cartDataService.AddCartItem (hotDog, amount);
		}

//		public void SetSelectedHotDog (UIViewController controller, HotDog i)
//		{
//		}
	}
}
