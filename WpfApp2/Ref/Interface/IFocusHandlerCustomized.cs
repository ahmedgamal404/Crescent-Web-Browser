using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;

namespace WpfApp2.Ref.Interface
{
    class IFocusHandlerCustomized : IFocusHandler
    {
        //
        // Summary:
        //     Called when the browser component has received focus.
        //
        // Parameters:
        //   chromiumWebBrowser:
        //     the ChromiumWebBrowser control
        //
        //   browser:
        //     the browser object
        public void OnGotFocus(IWebBrowser chromiumWebBrowser, IBrowser browser)
        { 
        }
        //
        // Summary:
        //     Called when the browser component is requesting focus.
        //
        // Parameters:
        //   chromiumWebBrowser:
        //     the ChromiumWebBrowser control
        //
        //   browser:
        //     the browser object, do not keep a reference to this object outside of this method
        //
        //   source:
        //     Indicates where the focus request is originating from.
        //
        // Returns:
        //     Return false to allow the focus to be set or true to cancel setting the focus.
        public bool OnSetFocus(IWebBrowser chromiumWebBrowser, IBrowser browser, CefFocusSource source)
        {
            return false;
        }
        //
        // Summary:
        //     Called when the browser component is about to lose focus. For instance, if focus
        //     was on the last HTML element and the user pressed the TAB key.
        //
        // Parameters:
        //   chromiumWebBrowser:
        //     the ChromiumWebBrowser control
        //
        //   browser:
        //     the browser object
        //
        //   next:
        //     Will be true if the browser is giving focus to the next component and false if
        //     the browser is giving focus to the previous component.
       public void OnTakeFocus(IWebBrowser chromiumWebBrowser, IBrowser browser, bool next)
        {
            
        }
    }
}
