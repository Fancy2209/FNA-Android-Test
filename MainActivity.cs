using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Org.Libsdl.App;

// Big shotout to ppy and the osu! and osu framework contributors
// The source of those projects was really helpful to figure this out
[Activity(
    ConfigurationChanges = 
        ConfigChanges.Keyboard
      | ConfigChanges.KeyboardHidden
      | ConfigChanges.Navigation
      | ConfigChanges.Orientation
      | ConfigChanges.ScreenLayout
      | ConfigChanges.ScreenSize
      | ConfigChanges.SmallestScreenSize
      | ConfigChanges.Touchscreen
      | ConfigChanges.UiMode,
    Exported = true,
    LaunchMode = LaunchMode.SingleInstance,
    MainLauncher = true)]
public class MainActivity : SDLActivity
{
    protected override string[] GetLibraries() => ["SDL3", "FNA3D", "FAudio"];

    protected override void Main()  
    {
        System.Environment.SetEnvironmentVariable("FNA_PLATFORM_BACKEND", "SDL3");
        SpriteBatchTest.Main([""]);
    }
}
