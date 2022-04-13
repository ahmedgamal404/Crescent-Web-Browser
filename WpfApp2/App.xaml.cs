using CefSharp;
using CefSharp.WinForms;
using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //For Windows 7 and above, best to include relevant app.manifest entries as well
            Cef.EnableHighDPISupport();


#if !NETCOREAPP
            var settings = new CefSettings();


            settings.CachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Cache");        //By default CefSharp will use an in-memory cache, you need to specify a Cache Folder to persist data

            settings.EnablePrintPreview();                                                                                                          // Printing View 

            //Example of setting a command line argument
            //Enables WebRTC
            // - CEF Doesn't currently support permissions on a per browser basis see https://bitbucket.org/chromiumembedded/cef/issues/2582/allow-run-time-handling-of-media-access
            // - CEF Doesn't currently support displaying a UI for media access permissions
            //
            //NOTE: WebRTC Device Id's aren't persisted as they are in Chrome see https://bitbucket.org/chromiumembedded/cef/issues/2064/persist-webrtc-deviceids-across-restart
            settings.CefCommandLineArgs.Add("enable-media-stream");
            //https://peter.sh/experiments/chromium-command-line-switches/#use-fake-ui-for-media-stream
            settings.CefCommandLineArgs.Add("use-fake-ui-for-media-stream");

            //For screen sharing add (see https://bitbucket.org/chromiumembedded/cef/issues/2582/allow-run-time-handling-of-media-access#comment-58677180)
            settings.CefCommandLineArgs.Add("enable-usermedia-screen-capturing");
            //Disable GPU Acceleration
            //settings.CefCommandLineArgs.Add("disable-gpu", "1");
            settings.CefCommandLineArgs.Add("enable-npapi", "1");
            settings.CefCommandLineArgs.Add("enable-system-flash");







            //settings.CefCommandLineArgs.Add("use-fake-codec-for-peer-connection");
            //settings.CefCommandLineArgs.Add("use-fake-device-for-media-stream");
            //settings.CefCommandLineArgs.Add("disable-accelerated-video-decode");  
            //settings.CefCommandLineArgs.Add("force-overlay-fullscreen-video", "1");
            //settings.CefCommandLineArgs.Add("disable-gpu-compositing");
            //settings.CefCommandLineArgs.Add("ppapi-flash-args");
            //settings.CefCommandLineArgs.Add("ppapi-flash-path");
            //settings.CefCommandLineArgs.Add("ppapi-flash-version");
            //settings.CefCommandLineArgs.Add("no-proxy-server");




            //Perform dependency check to make sure all relevant resources are in our output directory.
            Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);
#endif


            //cefSettings.CefCommandLineArgs.Add("disable-gpu");
            //cefSettings.CefCommandLineArgs.Add("disable-gpu-compositing");
            //cefSettings.CefCommandLineArgs.Add("enable-begin-frame-scheduling");
            //cefSettings.CefCommandLineArgs.Add("disable-gpu-vsync"); //Disable Vsync
            //cefSettings.SetOffScreenRenderingBestPerformanceArgs();
            //settings.BackgroundColor = Cef.ColorSetARGB(255, 255, 255, 255);

        }

        private void Image_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }
    }
}
