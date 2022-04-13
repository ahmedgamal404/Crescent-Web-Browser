//................................................................ بسم الله الرحمن الرحيم ...............................
//using CefSharp.Wpf;
using System;
using System.Windows;
using System.Windows.Input;
//using System.Windows.Forms;
using System.Windows.Forms.Integration;     
using CefSharp;
using CefSharp.WinForms;
//using CefSharp.MinimalExample.WinForms.Controls;
using System.Windows.Controls;
//using System.Drawing;
using System.Windows.Media;
using WpfApp2.Ref;
using WpfApp2.Ref.Interface;
using WpfApp2.Ref.HTML;
using System.Windows.Threading;
//using System.Diagnostics;
//using System.Windows.Media.Imaging;
//using System.Collections.Generic;
//using System.Resources;
//using System.Linq;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Threading.Tasks;

namespace WpfApp2
{
    public class TabWebBrowser : TabItem
    {   // Main Controls of Browser
        public ChromiumWebBrowser webBrowser = new ChromiumWebBrowser("",null);
        public readonly WindowsFormsHost host = new WindowsFormsHost();                    // the host of WinForm WebBrowser
        public BrowserSettings webBrowserSettings = new BrowserSettings();
        public UserControl1 userCtrl;  // custom header
        DispatcherTimer timer = new DispatcherTimer();
        /////////////////////////////////////////////////////////////////////////
        private static int _Id;  // just for debugging
        public int id;
        private static int _TabsCount;
        public int tabsCount;
        public double totalWidth;
        public bool isClicked;
        private string currentUrl; // to determine if Condstions and debugging

        string PageText;           // the Text of the page which is loaded
        public string tempsearchBarTxt;   // temp text of the UrlComboSearchBar text when travel to another Tab
        //--------------------------------------------------------------//
        //--------------------------------------------------------------//
        public bool isSuccessLoaded;


        public TabWebBrowser()  // Basic Insialize
        {
            // Al Hamdulellah 
            // WebBrowser events insilazaion
            #region events insilazaion
            webBrowser.IsBrowserInitializedChanged += WebBrowser_IsBrowserInitializedChanged;
            webBrowser.LoadingStateChanged += WebBrowser_LoadingStateChanged;
            webBrowser.ConsoleMessage += WebBrowser_ConsoleMessage;
            webBrowser.TitleChanged += WebBrowser_TitleChanged;
            webBrowser.AddressChanged += WebBrowser_AddressChanged;
            webBrowser.FrameLoadStart += WebBrowser_FrameLoadStart;
            webBrowser.FrameLoadEnd += WebBrowser_FrameLoadEnd;
            #endregion
            this.Content = webBrowser;
            this.Header = "New Page";
        }

        public TabWebBrowser(string webBrowserAddres)  // Standerd Intialize
        {
            // Al Hamdulellah 
            _Id++;
            id = _Id;
            _TabsCount++;
            tabsCount = _TabsCount;

            timer.Interval = new TimeSpan(0, 0, 0, 0, 8);
            timer.Tick += Timer_Tick;

            // Custom UserControl of X Button and Header 
            userCtrl = new UserControl1();

            // WebBrowser events insilazaion
            #region WebBrowser events insilazaion
            webBrowser.IsBrowserInitializedChanged += WebBrowser_IsBrowserInitializedChanged;
            webBrowser.LoadingStateChanged += WebBrowser_LoadingStateChanged;
            webBrowser.ConsoleMessage += WebBrowser_ConsoleMessage;
            webBrowser.TitleChanged += WebBrowser_TitleChanged;
            webBrowser.AddressChanged += WebBrowser_AddressChanged;
            webBrowser.FrameLoadStart += WebBrowser_FrameLoadStart;
            webBrowser.FrameLoadEnd += WebBrowser_FrameLoadEnd;
            webBrowser.LoadError += WebBrowser_LoadError;
            #endregion

            //initializing TabWebBrowser
            this.Header = userCtrl;
            this.AllowDrop = true;

            this.MaxWidth = 190;
            this.MinWidth = 80;

            this.Width = 190;
            this.Height = 29;

            this.TabIndex = 2147483647;

            //ImageBrush imgBrush = new ImageBrush();
            //Uri uri = new Uri("Tab Mask.png",UriKind.Relative);
            //imgBrush.ImageSource = new BitmapImage(uri);
            //OpacityMask = imgBrush;

            // Events:
            this.MouseEnter += TabWebBrowser_MouseEnter;
            this.MouseLeave += TabWebBrowser_MouseLeave;
            this.MouseDown += TabWebBrowser_MouseDown;
            this.MouseUp += TabWebBrowser_MouseUp;
            
            // Insializing Web Browser 
            host.Child = webBrowser;
            Content = host;
            host.AllowDrop = true;
            host.Focusable = true;
            host.TabIndex = 2147483647;
            host.Visibility = Visibility.Visible;
            host.Background = Brushes.White;
            if(!string.IsNullOrWhiteSpace(webBrowserAddres)) webBrowser.Load(webBrowserAddres);
            webBrowser.TabIndex = 2147483647;
            webBrowser.LifeSpanHandler = new ILifeSpanHandlerCustomized();
            webBrowser.DownloadHandler = new IDownloadHandlerCustomized();
            webBrowser.LoadHandler = new ILoadHandlerCustomized();
            webBrowser.BrowserSettings = webBrowserSettings;

            // Browser Settings
            webBrowserSettings.Javascript = CefState.Enabled;
            webBrowserSettings.JavascriptDomPaste = CefState.Enabled;
            //webBrowserSettings.LocalStorage = CefState.Enabled;
            webBrowserSettings.TabToLinks = CefState.Enabled;
            webBrowserSettings.WebGl = CefState.Enabled;
            webBrowserSettings.WebSecurity = CefState.Enabled;
            webBrowserSettings.WindowlessFrameRate = 60;
            webBrowserSettings.Plugins = CefState.Enabled;



            //                              **************************************
            //webBrowser.BrowserSettings = webBrowserSettings;                           **************************************
            //if (webBrowser.BrowserSettings.WindowlessFrameRate == 60)
            //{
            //    MessageBox.Show("Ya Rabby");
            //}
            //webBrowserSettings.JavascriptCloseWindows = CefState.Enabled;
        }



        private void Timer_Tick(object sender, EventArgs e)
        {
            if (userCtrl.progressBar.Value < 100 && !webBrowser.IsLoading)
            {
                userCtrl.progressBar.Value += timer.Interval.Milliseconds;
            }
            else 
            {
                timer.Stop();
                userCtrl.progressBar.Value = 0;
                userCtrl.progressBar.Visibility = Visibility.Hidden;
            }
        }

        private void TabWebBrowser_MouseLeave(object sender, MouseEventArgs e)
        {
            isClicked = false;
        }
        private void TabWebBrowser_MouseEnter(object sender, MouseEventArgs e)
        {
            isClicked = true;
        }
        private void TabWebBrowser_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // closing tab by mouse wheel click
            if (e.ChangedButton == MouseButton.Middle && e.ButtonState == MouseButtonState.Released)
            {
                ((TabControl)this.Parent).Items.Remove(this);
                webBrowser.Dispose();
            }

            if (e.ChangedButton == MouseButton.Left && e.ButtonState == MouseButtonState.Released)
            {
                isClicked = false;
                //MessageBox.Show(isClicked.ToString());
            }
        }
        private void TabWebBrowser_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isClicked = true;
        }
        public void ShowSellectedTabFeatures(bool isSellected)
        {
            if (isSellected)
            {
                //Background = Brushes.AntiqueWhite;
                userCtrl.userCtrlHeader.Foreground = Brushes.Black;
                userCtrl.TabCloseButton.Foreground = Brushes.DarkRed;

            }
            else
            {
                //Background = Brushes.Black;
                userCtrl.userCtrlHeader.Foreground = Brushes.DarkGray;
                userCtrl.TabCloseButton.Foreground = Brushes.Gray;
                BorderThickness = new Thickness(0);
                BorderBrush = Brushes.Transparent;
            }
        }

        #region WebBrowser event Funcsions
        private void WebBrowser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
        }
        private void WebBrowser_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            try
            {
                this.Dispatcher.Invoke(() =>
                {
                    userCtrl.userCtrlHeader.Text = e.Title; this.ToolTip = e.Title;
                    
                });
            }
            catch 
            { 
            }
        }
        private void WebBrowser_ConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {
            //throw new NotImplementedException();
        }
        private void WebBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (webBrowser.Address != currentUrl)
            {
                this.Dispatcher.Invoke(() =>
                {
                    if (e.IsLoading)
                    {
                        timer.Stop();
                        userCtrl.progressBar.Value = 0;
                        userCtrl.progressBar.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        userCtrl.progressBar.Visibility = Visibility.Visible;
                        timer.Start();
                        currentUrl = webBrowser.Address;
                    }
                });

            }
            //throw new NotImplementedException();
        }
        private void WebBrowser_IsBrowserInitializedChanged(object sender, EventArgs e)
        {
        }
        private void WebBrowser_FrameLoadStart(object sender, FrameLoadStartEventArgs e)
        {
        }
        private void WebBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            // A function to filter the inaproperiate content which is not Islamic at all
            SafeSearch.PageFilter(this, webBrowser, PageText);
        }
        private void WebBrowser_LoadError(object sender, LoadErrorEventArgs e)
        {
            //if (!HasFramContent(PageText))
            //{
            //    webBrowser.LoadHtml(HTMLPages.ErrorLoadingPage(tempsearchBarTxt));
            //}

        }
        #endregion

        #region Extra Custom Functions
        /// <summary>
        /// A function to detect if there was a content in the navigated URL or not
        /// </summary>
        /// <param name="pageTxt">the Text of the page which is loaded</param>
        /// <returns></returns>
        public bool HasFramContent(string pageTxt)
        {
            Dispatcher.BeginInvoke((Action)(async () =>
            {
                pageTxt = await webBrowser.GetTextAsync();
            }));

            if (string.IsNullOrWhiteSpace(pageTxt))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}