using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using RaysHotDogs.Core;

namespace RaysHotDogs
{
	partial class MeatLoversTableViewController : BaseUITableViewController
	{
		HotDogDataService dataService = new HotDogDataService ();

		public MeatLoversTableViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var meatLovers = dataService.GetHotDogsForGroup (1);
			var datasource = new HotDogDataSource (meatLovers, this);

			TableView.Source = datasource;

			this.ParentViewController.NavigationItem.Title = "Meat Lovers";
		}
	}
}
