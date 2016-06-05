// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Hommy
{
	[Register ("SettingsViewController")]
	partial class SettingsViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField EmailTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel NoiseLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISlider NoiseSlider { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton StartButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISegmentedControl VoiceSegmantedController { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (EmailTextField != null) {
				EmailTextField.Dispose ();
				EmailTextField = null;
			}
			if (NoiseLabel != null) {
				NoiseLabel.Dispose ();
				NoiseLabel = null;
			}
			if (NoiseSlider != null) {
				NoiseSlider.Dispose ();
				NoiseSlider = null;
			}
			if (StartButton != null) {
				StartButton.Dispose ();
				StartButton = null;
			}
			if (VoiceSegmantedController != null) {
				VoiceSegmantedController.Dispose ();
				VoiceSegmantedController = null;
			}
		}
	}
}
