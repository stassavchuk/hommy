using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Threading;
using CoreGraphics;
using Hommy.Models;
using iAd;
using UIKit;

namespace Hommy
{
	partial class MusicTableViewController : UITableViewController
	{
		public MusicTableViewController (IntPtr handle) : base (handle)
		{
		}

        private List<Radio> _radio;
	    private int _idPlayer = -1;
	    private int _selected = -1;
        private string _cellIdentifier = "TableCellMusic";
	    private NSIndexPath _indexPlayer;
	    private NSIndexPath _indexSelector;

        public override void ViewDidLoad()
	    {
	        base.ViewDidLoad();
            _radio = Data.Instance.Radios;
	    }

	    public override nint RowsInSection(UITableView tableView, nint section)
	    {
	        return _radio.Count;
	    }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            //
            _selected = indexPath.Row;
            if (_indexSelector == null)
                _indexSelector = indexPath;
            else if (indexPath.Equals(_indexSelector))
                _selected = -1;
            NSIndexPath[] indexPaths = { _indexSelector, indexPath };
            if (indexPath.Equals(_indexSelector))
                _indexSelector = null;
            TableView.ReloadRows(indexPaths, UITableViewRowAnimation.Fade);
            //

            /*tableView.DeselectRow(indexPath, true);
            _selected = indexPath.Row;
            NSIndexPath[] indexPaths = { indexPath };
            TableView.ReloadRows(indexPaths, UITableViewRowAnimation.Fade);*/
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
	    {
            var cell = tableView.DequeueReusableCell(_cellIdentifier) ??
                     new UITableViewCell(UITableViewCellStyle.Subtitle, _cellIdentifier);
	        cell.ImageView.Image = 
                UIImage.FromFile(indexPath.Row == _idPlayer 
                    ? "Icons/stop.png" : "Icons/play.png");
            cell.ImageView.UserInteractionEnabled = true;
            cell.ImageView.AddGestureRecognizer(
                new UITapGestureRecognizer(c =>
                {
                    Console.WriteLine(indexPath.Row);
                    _idPlayer = indexPath.Row;
                    if (_indexPlayer == null)
                    {
                        Console.WriteLine("null");
                        _indexPlayer = indexPath;
                    }
                    else if (indexPath.Equals(_indexPlayer))
                        _idPlayer = -1;
                    NSIndexPath[] indexPaths = { _indexPlayer, indexPath };
                    if (indexPath.Equals(_indexPlayer))
                        _indexPlayer = null;
                    TableView.ReloadRows(indexPaths, UITableViewRowAnimation.Fade);
                }));
            

	        cell.TextLabel.Text = _radio[indexPath.Row].Name;

            if (indexPath.Row == _idPlayer)
            {
                _indexPlayer = indexPath;
            }
            
            if (indexPath.Row == _selected)
            {
                _indexSelector = indexPath;
                cell.Accessory = UITableViewCellAccessory.Checkmark;
            }
            else
            {
                cell.Accessory = UITableViewCellAccessory.None;
            }

            return cell;
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 70;
        }
    }
}
