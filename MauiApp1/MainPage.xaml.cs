using System.Diagnostics;
using System.Runtime.InteropServices;
using Un4seen.Bass;

namespace MauiApp1;

public partial class MainPage : ContentPage
{

    public MainPage()
	{
		InitializeComponent();
 
    }

    private async void OnBassClicked(object sender, EventArgs e)
    {
        int bassVersion = 0;
        nint libHandle;

        Trace.WriteLine($"RuntimeInformation.IsOSPlatform(OSPlatform.Windows) {RuntimeInformation.IsOSPlatform(OSPlatform.Windows)}");
        Trace.WriteLine($"System.Environment.Is64BitOperatingSystem : {System.Environment.Is64BitOperatingSystem}");
        Trace.WriteLine($"System.Environment.Is64BitProcess : {System.Environment.Is64BitProcess}");
        Trace.WriteLine($"NativeLibrary.TryLoad(\"Bass.Net.dll\", out libHandle) : {NativeLibrary.TryLoad("Bass.Net.dll", out libHandle)}");
        Trace.WriteLine($"NativeLibrary.TryLoad(\"bass.dll\", out libHandle) : {NativeLibrary.TryLoad("bass.dll", out libHandle)}");
        Trace.WriteLine($"NativeLibrary.TryLoad(\"bass_fx.dll\", out libHandle) : {NativeLibrary.TryLoad("bass_fx.dll", out libHandle)}");

        try
        {
            bassVersion = Bass.BASS_GetVersion();
        }
        catch (Exception ex)
        {
            Trace.WriteLine($"Exception message Bass.BASS_GetVersion() : {ex.Message}");
            Trace.WriteLine($"Exception type Bass.BASS_GetVersion() : {ex.GetType}");
            Trace.WriteLine($"Exception InnerException Bass.BASS_GetVersion() : {ex.InnerException}");
            Trace.WriteLine($"Exception StackTrace Bass.BASS_GetVersion() : {ex.StackTrace}");
            await DisplayAlert("Info", $"Exception Bass.BASS_GetVersion() : {ex.Message}", "OK");
            return;
        }

        Trace.WriteLine($"Bass.BASS_GetVersion() : {bassVersion}");
        await DisplayAlert("Info", "Bass.BASS_GetVersion() : " + bassVersion.ToString(), "OK");
    }

}

