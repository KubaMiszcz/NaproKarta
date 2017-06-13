using Android.App;
using Android.Widget;
using Android.OS;

namespace NaproKartaXamarin
{
	[Activity(Label = "NaproKartaXamarin", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.MainLayout);
			// Set our view from the "main" layout resource
			// SetContentView (Resource.Layout.Main);
		}
	}
}

