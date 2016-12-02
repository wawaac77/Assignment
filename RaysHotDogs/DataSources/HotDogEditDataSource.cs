using System;
using UIKit;
using RaysHotDogs.Core;
using System.Collections.Generic;
using Foundation;
using System.Linq;

namespace RaysHotDogs
{
	public class HotDogEditDataSource: UITableViewSource
	{
		private List<HotDog> hotDogs;

		//string cellIdentifier = "HotDogCell"; // set in the Storyboard
		NSString cellIdentifier = new NSString("HotDogCell");

		BaseUITableViewController callingController;

		public HotDogEditDataSource (List<HotDog> hotDogs, BaseUITableViewController callingController)
		{
			this.hotDogs = hotDogs;
			this.callingController = callingController;


		}

		public override void CommitEditingStyle (UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
		{
			switch (editingStyle) {
			case UITableViewCellEditingStyle.Delete:
					break;

			case UITableViewCellEditingStyle.Insert:
					break;

			case UITableViewCellEditingStyle.None:
				Console.WriteLine ("CommitEditingStyle:None called");
				break;
			}
		}

		/// <summary>
		/// Called by the table view to determine whether or not the row is editable
		/// </summary>
		public override bool CanEditRow (UITableView tableView, NSIndexPath indexPath)
		{
			return true; // return false if you wish to disable editing for a specific indexPath or for all rows
		}

		/// <summary>
		/// Called by the table view to determine whether or not the row is moveable
		/// </summary>
		public override bool CanMoveRow (UITableView tableView, NSIndexPath indexPath)
		{
			return true;
		}

		/// <summary>
		/// Custom text for delete button
		/// </summary>
		public override string TitleForDeleteConfirmation (UITableView tableView, NSIndexPath indexPath)
		{
			return "Trash (" + hotDogs[indexPath.Row].Name + ")";
		}

		/// <summary>
		/// Called by the table view to determine whether the editing control should be an insert
		/// or a delete.
		/// </summary>
		public override UITableViewCellEditingStyle EditingStyleForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return UITableViewCellEditingStyle.Delete;
		}

		/// <summary>
		/// called by the table view when a row is moved.
		/// </summary>
		public override void MoveRow (UITableView tableView, NSIndexPath sourceIndexPath, NSIndexPath destinationIndexPath)
		{
//			//---- get a reference to the item
//			var item = tableItems[sourceIndexPath.Row];
//			int deleteAt = sourceIndexPath.Row;
//			int insertAt = destinationIndexPath.Row;
//
//			//---- if we're inserting it before, the one to delete will have a higher index 
//			if (destinationIndexPath.Row < sourceIndexPath.Row) {
//				//---- add one to where we delete, because we're increasing the index by inserting
//				deleteAt += 1;
//			} else {
//				//---- add one to where we insert, because we haven't deleted the original yet
//				insertAt += 1;
//			}
//
//			//---- copy the item to the new location
//			tableItems.Insert (insertAt, item);
//
//			//---- remove from the old
//			tableItems.RemoveAt (deleteAt);
		}


		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return hotDogs.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			//regular cell
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier) as UITableViewCell;

			if (cell == null)
			{ 
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier); 
			}

			var hotDog = hotDogs[indexPath.Row];
			cell.TextLabel.Text = hotDog.Name;
			cell.ImageView.Image = UIImage.FromFile ("Images/hotdog" + hotDog.HotDogId + ".jpg");

			return cell;

			//Custom cell			
			//
			//			HotdogListCell cell = tableView.DequeueReusableCell (cellIdentifier) as HotdogListCell;
			//
			//			if (cell == null)
			//				cell = new HotdogListCell (cellIdentifier);
			//
			//			cell.UpdateCell (hotdogs[indexPath.Row].Name
			//				, hotdogs[indexPath.Row].Price.ToString()
			//				, UIImage.FromFile ("Images/hotdog" + hotdogs[indexPath.Row].HotDogId + ".jpg") );
			//
			//			return cell;
		}

		public HotDog GetItem(int id) 
		{
			return hotDogs[id];
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var selectedHotDog = hotDogs[indexPath.Row];
			callingController.HotDogSelected (selectedHotDog);
			tableView.DeselectRow (indexPath, true);
		}
	}
}

