using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using CoreGraphics;
using Hommy.Models;
using UIKit;

namespace Hommy
{
	partial class LampsTableViewController : UITableViewController
	{
	    private string _cellIdentifier = "TableCell";
	    private List<Lamp> _lamps;
        

        public LampsTableViewController (IntPtr handle) : base (handle)
		{
            
		}

	    public override void ViewDidLoad()
	    {
	        base.ViewDidLoad();

	        _lamps = Data.Instance.Lamps;

            BackgroundWorker bw = new BackgroundWorker();
	        bw.DoWork += (sender, args) => { Fetch(); };
            bw.RunWorkerAsync();

	        //LightOn();

	    }

	    public override void ViewDidAppear(bool animated)
	    {
	        base.ViewDidAppear(animated);
            //Thread thread = new Thread(Fetch) { Priority = ThreadPriority.Lowest };
            //thread.Start();
        }


        public override nint RowsInSection(UITableView tableView, nint section)
	    {
	        return _lamps.Count;
	    }

	    public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
	    {
            var cell = tableView.DequeueReusableCell(_cellIdentifier) ??
                      new UITableViewCell(UITableViewCellStyle.Subtitle, _cellIdentifier);
	        cell.ImageView.Image = UIImage.FromFile(!_lamps[indexPath.Row].State
                ? "Icons/lampOff.png" : "Icons/lampOn.png");
	        cell.TextLabel.Text = _lamps[indexPath.Row].Name;

            var switchView = new UISwitch(new CGRect(0,0,25,25));
            switchView.SetState(_lamps[indexPath.Row].State, false);
            
	        switchView.ValueChanged += (sender, args) =>
	        {
	            ChangeLampState(indexPath.Row);
	        };

	        cell.AccessoryView = switchView;

	        _lamps[indexPath.Row].Index = indexPath;

	        return cell;
	    }

	    private void ChangeLampState(int lampId)
	    {
	        _lamps[lampId].State = !_lamps[lampId].State;
            NSIndexPath[] indexPaths = {_lamps[lampId].Index};
            InvokeOnMainThread(() => {
                TableView.ReloadRows(indexPaths, UITableViewRowAnimation.Fade);
            });
	    }

	    public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
	    {
	        return 70;
	    }

	    public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
	    {
            tableView.DeselectRow(indexPath, true);
        }

	    private void Fetch()
	    {
	        return;
	        while (true)
	        {
                var r = new Random();
	            int k = r.Next(10);
                int kk = r.Next(10);
                Console.WriteLine(k+" "+kk);
                if (k==kk)
                    ChangeLampState(r.Next(_lamps.Count));
                Thread.Sleep(200);
            }
        }

	    private void LightOn()
	    {
            string uri = Data.Instance.Ip + ":8888/?request=light_on";

            Console.WriteLine("trying to ser request");
            HttpWebRequest webrequest =
	            (HttpWebRequest) WebRequest.Create(uri);
            Console.WriteLine(webrequest);

            //var res = webrequest.GetResponse();
            //Console.WriteLine(res.ContentType);
        }
	}
}
