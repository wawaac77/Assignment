using System;
using UIKit;
using RaysHotDogs.Core;
using Foundation;
using System.Collections.Generic;

namespace RaysHotDogs
{
	public class CartDataSource: UITableViewSource
	{
		private CartDataService cartDataService;
		private List<CartItem> cartItems;

		string cellIdentifier = "CartItemCell"; 

		public CartDataSource ()
		{
			cartDataService = new CartDataService ();
			cartItems = cartDataService.GetCart ().CartItems;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return cartItems.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);

			if (cell == null)
			{ 
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier); 
			}

			CartItem cartItem = cartItems[indexPath.Row];
			cell.TextLabel.Text = cartItem.HotDog.Name + " (amount: " + cartItem.Amount + ")";

			cell.ImageView.Image = UIImage.FromFile ("Images/hotdog" + cartItems [indexPath.Row].HotDog.HotDogId + ".jpg");
			return cell;
		}

		public CartItem GetItem(int id) 
		{
			return cartItems[id];
		}
	}
}

