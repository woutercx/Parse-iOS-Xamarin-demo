using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Parse;
using System.Collections.Generic;

namespace ParseiOSStarterProject
{
	public partial class ParseiOSStarterProjectViewController : UIViewController
	{
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public ParseiOSStarterProjectViewController ()
			: base (UserInterfaceIdiomIsPhone ? "ParseiOSStarterProjectViewController_iPhone" : "ParseiOSStarterProjectViewController_iPad", null)
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.

			CallParse();

		}

		public async void CallParse()
		{
			var testObject = new ParseObject ("TestObject");
			testObject ["foo"] = "bar";
			await testObject.SaveAsync();

			var result = await ParseCloud.CallFunctionAsync<string>("hello", new Dictionary<string, object>());

			var x = new UIAlertView ("Title", result,  null, "Cancel", "OK");
			x.Show ();

		}

		[Obsolete]
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			if (UserInterfaceIdiomIsPhone) {
				return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
			} else {
				return true;
			}
		}
	}
}

