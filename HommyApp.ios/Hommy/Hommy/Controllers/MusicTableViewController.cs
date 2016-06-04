using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using CoreGraphics;
using Hommy.Models;
using UIKit;

namespace Hommy
{
	partial class MusicTableViewController : UITableViewController
	{
		public MusicTableViewController (IntPtr handle) : base (handle)
		{
		}

        private List<Radio> _radio;
	    private int _idPlayer;
        private string _cellIdentifier = "TableCellMusic";

        public override void ViewDidLoad()
	    {
	        base.ViewDidLoad();
            _radio = Data.Instance.Radios;
	    }

	    public override nint RowsInSection(UITableView tableView, nint section)
	    {
	        return _radio.Count;
	    }

	    public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
	    {
            var cell = tableView.DequeueReusableCell(_cellIdentifier) ??
                     new UITableViewCell(UITableViewCellStyle.Subtitle, _cellIdentifier);
            if (indexPath.Row==)

            return cell;
        }
	}
}
