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
        int bassVersion;
        nint libHandle;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            await DisplayAlert("Info", "On Windows", "OK");
        else
        {
            await DisplayAlert("Info", "not Windows platform ... test stoped", "OK");
            return;
        }
            
        if (NativeLibrary.TryLoad("Bass.Net.dll", out libHandle))
            await DisplayAlert("Info", "Bass.Net.dll loaded", "OK"); 
        else
            await DisplayAlert("Info", "Bass.Net.dll not loaded", "OK");

        if (NativeLibrary.TryLoad("bass.dll", out libHandle))
            await DisplayAlert("Info", "bass.dll loaded", "OK");
        else
            await DisplayAlert("Info", "bass.dll not loaded", "OK");

        if (NativeLibrary.TryLoad("bass_fx.dll", out libHandle))
            await DisplayAlert("Info", "bass_fx.dll loaded", "OK");
        else
            await DisplayAlert("Info", "bass_fx.dll not loaded", "OK");

        bassVersion = Bass.BASS_GetVersion();

        await DisplayAlert("Info", bassVersion.ToString(), "OK");  
    }

}

