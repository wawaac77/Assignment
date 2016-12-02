﻿using System;
using UIKit;
using RaysHotDogs.Core;
using System.Collections.Generic;
using Foundation;
using System.Linq;

namespace RaysHotDogs
{
	public class HotDogDataSource: UITableViewSource
	{
		private List<HotDog> hotDogs;
	
		//string cellIdentifier = "HotDogCell"; // set in the Storyboard
		NSString cellIdentifier = new NSString("HotDogCell");

		BaseUITableViewController callingController;

		public HotDogDataSource (List<HotDog> hotDogs, BaseUITableViewController callingController)
		{
			this.hotDogs = hotDogs;
			this.callingController = callingController;


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

