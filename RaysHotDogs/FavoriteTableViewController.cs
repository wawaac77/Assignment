using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using RaysHotDogs.Core;

namespace RaysHotDogs
{
	partial class FavoriteTableViewController : BaseUITableViewController
	{
		HotDogDataService dataService = new HotDogDataService ();
		UIBarButtonItem edit, done, insert;

		public FavoriteTableViewController (IntPtr handle) : base (handle)
		{
			
		}

		public async override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var favorites = dataService.GetFavoriteHotDogs();
			TableView.Source = new HotDogDataSource (favorites, this);


//			done = new UIBarButtonItem(UIBarButtonSystemItem.Done, (s,e)=>{
//				TableView.SetEditing (false, true);
//
//				NavigationItem.RightBarButtonItem = edit;
//			});
//
//			edit = new UIBarButtonItem(UIBarButtonSystemItem.Edit, (s,e)=>{
//				if (TableView.Editing)
//					TableView.SetEditing (false, true); // if we've half-swiped a row
//
//				TableView.SetEditing (true, true);
//				NavigationItem.LeftBarButtonItem = null;
//				NavigationItem.RightBarButtonItem = done;
//
//			});
//			NavigationItem.RightBarButtonItem = edit;
//
//			TableView.SetEditing (true, true);

			this.ParentViewController.NavigationItem.Title = "Ray's Favorites";
		}

//		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
//		{
//			base.PrepareForSegue (segue, sender);
//
//			if (segue.Identifier == "HotDogDetailSegue") 
//			{
//				var hotDogDetailViewController = segue.DestinationViewController as HotDogDetailViewController;
//				if (hotDogDetailViewController != null) 
//				{
//					var source = TableView.Source as HotDogDataSource;
//					var rowPath = TableView.IndexPathForSelectedRow;
//					var item = source.GetItem (rowPath.Row);
//					hotDogDetailViewController.SetSelectedHotDog (this, item);
//				}
//			
//			}
//		}
	}
}
