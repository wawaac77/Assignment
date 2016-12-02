using System;
using UIKit;
using RaysHotDogs.Core;
using System.Collections.Generic;
using Foundation;
using System.Linq;

namespace RaysHotDogs
{
	public class HotDogGroupedDataSource: UITableViewSource
	{
		private List<HotDog> hotDogs;


		Dictionary<string, List<HotDog>> indexedHotDogs;
		string[] keys;

		//string cellIdentifier = "HotDogCell"; // set in the Storyboard
		NSString cellIdentifier = new NSString("HotDogCell");

		BaseUITableViewController callingController;

		public HotDogGroupedDataSource (List<HotDog> hotDogs, BaseUITableViewController callingController)
		{
			this.hotDogs = hotDogs;
			this.callingController = callingController;

			indexedHotDogs = new Dictionary<string, List<HotDog>> ();
			foreach (var h in hotDogs) 
			{
				if (indexedHotDogs.ContainsKey (h.GroupName)) 
				{
					indexedHotDogs [h.GroupName].Add (h);
				} 
				else 
				{
					indexedHotDogs.Add (h.GroupName, new List<HotDog> (){ h });
				}
			}
			keys = indexedHotDogs.Keys.ToArray ();
		}
			
		public override nint NumberOfSections (UITableView tableView)
		{
			return keys.Length;
		}


		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return indexedHotDogs [keys [section]].Count;
		}

		public override string TitleForHeader (UITableView tableView, nint section)
		{
			return keys [section];
		}

		public override string TitleForFooter (UITableView tableView, nint section)
		{
			return indexedHotDogs [keys [section]].Count + " items";
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			//regular cell
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier) as UITableViewCell;

			if (cell == null)
			{ 
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier); 
			}

			var hotDog = indexedHotDogs[keys[indexPath.Section]][indexPath.Row];
			cell.TextLabel.Text = hotDog.Name;
			cell.ImageView.Image = UIImage.FromFile ("Images/hotdog" + hotDog.HotDogId + ".jpg");

			return cell;
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

