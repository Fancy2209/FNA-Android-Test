using Android.App;
using Android.Content.PM;
using SDL3Droid;

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

    // This is only a thing in SDL3, for SDL2, add main to GetLibraries and use the Function from SDL2Droid-CS' libmain
    protected override void Main()  
    {
        // SDL3 is not stable, used here for simplicity.
        Environment.SetEnvironmentVariable("FNA_PLATFORM_BACKEND", "SDL3");
        SpriteBatchTest.Main([""]);
    }
}
