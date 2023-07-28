using Android.App;
using Android.Content.PM;
using Android.OS;

namespace CollectionViewFilteringUI {
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity {
        protected override void OnCreate(Bundle savedInstanceState) {
            if (App.Current.RequestedTheme == AppTheme.Dark) {
                Window.SetNavigationBarColor(new Android.Graphics.Color(28, 27, 31));
            }
            else
                Window.SetNavigationBarColor(new Android.Graphics.Color(249, 246, 255));
            base.OnCreate(savedInstanceState);
        }
    }
}