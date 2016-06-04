using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using CoreGraphics;
using UIKit;

namespace Hommy
{
	partial class TabBarController : UITabBarController
	{
	    private UINavigationController _lampsNavigationController;
	    private UINavigationController _settingsNavigationController;
        private UINavigationController _musicNavigationController;

        public TabBarController (IntPtr handle) : base (handle)
		{
		}        

	    public override void ViewDidLoad()
	    {
	        base.ViewDidLoad();

	        Title = "Lamps";

            TabBar.AutosizesSubviews = false;
            TabBar.ClipsToBounds = true;

            _lampsNavigationController = Storyboard.InstantiateViewController("LampsNavigationController")
                as UINavigationController;

	        if (_lampsNavigationController != null)
	        {
	            _lampsNavigationController.TabBarItem = new UITabBarItem(
	                "Lamps",
	                UIImage.FromFile("Icons/lampTabBarNonSelected.png"),
	                UIImage.FromFile("Icons/lampTabBarSelected.png"));
	        }

            _settingsNavigationController = Storyboard.InstantiateViewController("SettingsNavigationController")
                as UINavigationController;

            if (_settingsNavigationController != null)
            {
                _settingsNavigationController.TabBarItem = new UITabBarItem(
                    "Settings",
                    UIImage.FromFile("Icons/settingsNonSelected.png"),
                    UIImage.FromFile("Icons/settingsSelected.png"));
            }

            _musicNavigationController = Storyboard.InstantiateViewController("MusicNavigationController")
                as UINavigationController;

            if (_musicNavigationController != null)
            {
                _musicNavigationController.TabBarItem = new UITabBarItem(
                    "Music",
                    UIImage.FromFile("Icons/musicTabBar.png"),
                    UIImage.FromFile("Icons/musicTabBar.png"));
            }

            var tabs = new UIViewController[]{
                _lampsNavigationController, _musicNavigationController, _settingsNavigationController
            };

	        ViewControllers = tabs;

            ViewControllerSelected += (sender, args) => Title = args.ViewController.Title;
        }
	}
}
