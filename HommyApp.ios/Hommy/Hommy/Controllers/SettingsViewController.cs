using Foundation;
using System;
using System.CodeDom.Compiler;
using CoreGraphics;
using UIKit;

namespace Hommy
{
	partial class SettingsViewController : UIViewController
	{
		public SettingsViewController (IntPtr handle) : base (handle)
		{
		}

	    private string _noiseKey = "noise";
	    private string _emergencyEmail = "emergency";
	    private string _voiceKey = "voice";

	    public override void ViewDidLoad()
	    {
	        base.ViewDidLoad();
	        NoiseSlider.Value = NSUserDefaults.StandardUserDefaults.FloatForKey(_noiseKey);
            EmailTextField.Text = NSUserDefaults.StandardUserDefaults.StringForKey(_emergencyEmail);
            VoiceSegmantedController.SelectedSegment = NSUserDefaults.StandardUserDefaults.IntForKey(_voiceKey);

            NoiseLabel.Text = "Background noise " 
                + (NoiseSlider.Value * 100).ToString("0.0")+" %";

	        NoiseSlider.ValueChanged += (sender, args) =>
	        {
                NoiseLabel.Text = "Background noise " 
                    + (NoiseSlider.Value * 100).ToString("0.0") + " %";
                NSUserDefaults.StandardUserDefaults.SetFloat(NoiseSlider.Value, _noiseKey);
            };

            EmailTextField.ShouldReturn += field =>
            {
                field.ResignFirstResponder();
                NSUserDefaults.StandardUserDefaults.SetString(EmailTextField.Text, _emergencyEmail);
                return false;
            };

            EmailTextField.KeyboardType = UIKeyboardType.EmailAddress;

	        VoiceSegmantedController.ValueChanged += (sender, args) =>
	        {
                var selected = (sender as UISegmentedControl).SelectedSegment;
                NSUserDefaults.StandardUserDefaults.SetInt(selected, _voiceKey);
            };

	        StartButton.Layer.MasksToBounds = true;
	        StartButton.Layer.CornerRadius = 80;
	        StartButton.TouchUpInside += (sender, args) =>
	        {
                Console.WriteLine("Listen...");
	        };

	    }
	}
}
