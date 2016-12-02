using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using RaysHotDogs.Core;

namespace RaysHotDogs
{
	partial class VeggieTableViewController : BaseUITableViewController
	{
		HotDogDataService dataService = new HotDogDataService ();


		public VeggieTableViewController (IntPtr handle) : base (handle)
		{
			
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			var veggieLovers = dataService.GetHotDogsForGroup (2);
			TableView.Source = new HotDogDataSource (veggieLovers, this);

			this.ParentViewController.NavigationItem.Title = "Veggie Lovers";
		}
	}
}
