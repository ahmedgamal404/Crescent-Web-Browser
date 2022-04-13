using System;
using System.Windows.Forms;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using CefSharp;

namespace WpfApp2.Ref.Interface
{
    class ILoadHandlerCustomized : ILoadHandler
    {

        //
        // Summary:
        //     Called when the browser is done loading a frame. The CefSharp.FrameLoadEndEventArgs.Frame
        //     value will never be empty Check the CefSharp.IFrame.IsMain method to see if this
        //     frame is the main frame. Multiple frames may be loading at the same time. Sub-frames
        //     may start or continue loading after the main frame load has ended. This method
        //     will always be called for all frames irrespective of whether the request completes
        //     successfully. This method will be called on the CEF UI thread. Blocking this
        //     thread will likely cause your UI to become unresponsive and/or hang.
        //
        // Parameters:
        //   chromiumWebBrowser:
        //     the ChromiumWebBrowser control
        //
        //   frameLoadEndArgs:
        //     args
        public void OnFrameLoadEnd(IWebBrowser chromiumWebBrowser, FrameLoadEndEventArgs frameLoadEndArgs)
        {
        }
        //
        // Summary:
        //     Called when the browser begins loading a frame. The CefSharp.FrameLoadEndEventArgs.Frame
        //     value will never be empty Check the CefSharp.IFrame.IsMain method to see if this
        //     frame is the main frame. Multiple frames may be loading at the same time. Sub-frames
        //     may start or continue loading after the main frame load has ended. This method
        //     may not be called for a particular frame if the load request for that frame fails.
        //     For notification of overall browser load status use CefSharp.ILoadHandler.OnLoadingStateChange(CefSharp.IWebBrowser,CefSharp.LoadingStateChangedEventArgs)
        //     instead. This method will be called on the CEF UI thread. Blocking this thread
        //     will likely cause your UI to become unresponsive and/or hang.
        //
        // Parameters:
        //   chromiumWebBrowser:
        //     the ChromiumWebBrowser control
        //
        //   frameLoadStartArgs:
        //     args
        //
        // Remarks:
        //     Whilst thist may seem like a logical place to execute js, it's called before
        //     the DOM has been loaded, implement CefSharp.IRenderProcessMessageHandler.OnContextCreated(CefSharp.IWebBrowser,CefSharp.IBrowser,CefSharp.IFrame)
        //     as it's called when the underlying V8Context is created (Only called for the
        //     main frame at this stage)
        public void OnFrameLoadStart(IWebBrowser chromiumWebBrowser, FrameLoadStartEventArgs frameLoadStartArgs)
        { 
        }
        //
        // Summary:
        //     Called when the resource load for a navigation fails or is canceled. CefSharp.LoadErrorEventArgs.ErrorCode
        //     is the error code number, CefSharp.LoadErrorEventArgs.ErrorText is the error
        //     text and CefSharp.LoadErrorEventArgs.FailedUrl is the URL that failed to load.
        //     See net\base\net_error_list.h for complete descriptions of the error codes. This
        //     method will be called on the CEF UI thread. Blocking this thread will likely
        //     cause your UI to become unresponsive and/or hang.
        //
        // Parameters:
        //   chromiumWebBrowser:
        //     the ChromiumWebBrowser control
        //
        //   loadErrorArgs:
        //     args
        public void OnLoadError(IWebBrowser chromiumWebBrowser, LoadErrorEventArgs loadErrorArgs)
        {
        }
        //
        // Summary:
        //     Called when the loading state has changed. This callback will be executed twice
        //     once when loading is initiated either programmatically or by user action, and
        //     once when loading is terminated due to completion, cancellation of failure. This
        //     method will be called on the CEF UI thread. Blocking this thread will likely
        //     cause your UI to become unresponsive and/or hang.
        //
        // Parameters:
        //   chromiumWebBrowser:
        //     the ChromiumWebBrowser control
        //
        //   loadingStateChangedArgs:
        //     args
        public void OnLoadingStateChange(IWebBrowser chromiumWebBrowser, LoadingStateChangedEventArgs loadingStateChangedArgs)
        { 
        }
    }
}
