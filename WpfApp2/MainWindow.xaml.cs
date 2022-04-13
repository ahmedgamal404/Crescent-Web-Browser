//*************************************************************بسم الله الرحمن الرحيم******************************************************//
//using CefSharp.Wpf;                                                                    
using CefSharp;
using CefSharp.WinForms;
//using CefSharp.MinimalExample.WinForms.Controls;
//using CefSharp.Event;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.Net;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Forms.Integration;
using WpfApp2.Ref;
using WpfApp2.Ref.HTML;
using WpfApp2.Debugging_Tools;
//using System.Windows.Controls.Primitives;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
//using System.Runtime.InteropServices;

/// <summary>
/////using CefSharp;
/// </summary>

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Properities
        TabWebBrowser mainTabWebBrowser;                               // Tab of Web Browser which contains the webPage itself.
        //List<TabWebBrowser> tabsList = new List<TabWebBrowser>();      // A list enclode all TabWebBrowsers.
        public string InsializeAddress = "www.bing.com";
        public string urlHome = "facebook.com";
        string currentUrl;

        //----------------------------------------------------------------
        // Tab Items proberities
        double tabMaxWidth;
        double tabMinWidth;
        double tabCurrentWidth;
        double totalWidth = 500.0;
        int tabsCount;                  // TabsCount represent the numbre of tabs that TabCtrl has

        //---------------------------------------------------------------
        // Search Engine Properities
        Uri url;
        HttpWebRequest request;
        HttpWebResponse response;
        string responseText;
        string[] items;
        List<string> itemResult;

        //---------------------------------------------------------------
        TraversalRequest focusRequest = new TraversalRequest(FocusNavigationDirection.Last);
        //int Search = 300;
        //int SearchNewWindow = 301;
        //int OpenInNewTab = 302;
        //int OpenInNewWindow = 303;
        //int SavePageAs = 304;
        //int SaveLinkAs = 305;
        //int CopyLink = 306;
        //int Print = 307;
        //private double dragBuffer = 3;
        //private Point startPoint;
        //public const int WM_NCLBUTTONDOWN = 0xA1;
        //public const int HT_CAPTION = 0x2;
        //[DllImportAttribute("user32.dll")]
        //public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        //[DllImportAttribute("user32.dll")]
        //public static extern bool ReleaseCapture();
        //---------------------------------------------------------------
        //---------------------------------------------------------------

        public MainWindow()
        {
            InitializeComponent();
            AddingTab();
            //MessageBox.Show(Application.Current.Windows.Count.ToString());
            itemResult = new List<string>();

            tabMaxWidth = mainTabWebBrowser.MaxWidth;
            tabMinWidth = mainTabWebBrowser.MinWidth;
            tabCurrentWidth = tabMaxWidth;

            #region WebBrowser Event Insializing
            // this will be fired Ones the browser is started
            mainTabWebBrowser.webBrowser.IsBrowserInitializedChanged += WebBrowser_IsBrowserInitializedChanged;
            // This will be fired twice: On loading and On finshing
            mainTabWebBrowser.webBrowser.LoadingStateChanged += WebBrowser_LoadingStateChanged;
            // this is Unkown to me !
            mainTabWebBrowser.webBrowser.ConsoleMessage += WebBrowser_ConsoleMessage;
            //this will be called when the web page title is changed
            mainTabWebBrowser.webBrowser.TitleChanged += WebBrowser_TitleChanged;
            //this will be called when the web page Address is changed
            mainTabWebBrowser.webBrowser.AddressChanged += WebBrowser_AddressChanged;
            //this will be called when the loading if failed
            mainTabWebBrowser.webBrowser.LoadError += WebBrowser_LoadError;
            //this will be called when the loading starts
            mainTabWebBrowser.webBrowser.FrameLoadStart += WebBrowser_FrameLoadStart;
            //this will be called when the loading ends
            mainTabWebBrowser.webBrowser.FrameLoadEnd += WebBrowser_FrameLoadEnd;
            #endregion

            #region UrlBar Event Insialization

            #region UrlTextBox Events Insialization

            //urlBar.urlTextBox.MouseDoubleClick += UrlTextBox_MouseDoubleClick;
            //urlBar.urlTextBox.KeyDown += UrlTextBox_KeyDown;
            //urlBar.urlTextBox.TextChanged += UrlTextBox_TextChanged;

            #endregion

            #region UrlCompBox Event Insialization
            urlBar.urlComboBox.PreviewTextInput += UrlCompoBox_PreviewTextInput;
            urlBar.urlComboBox.KeyDown += UrlCompoBox_KeyDown;
            urlBar.urlComboBox.KeyUp += UrlComboBox_KeyUp;
            urlBar.urlComboBox.MouseDoubleClick += UrlCompoBox_MouseDoubleClick;
            urlBar.urlComboBox.DropDownClosed += UrlComboBox_DropDownClosed;
            //Buttons Events
            urlBar.btn_Navigate.PreviewMouseLeftButtonUp += Btn_Navigate_PreviewMouseLeftButtonUp;
            #endregion

            #endregion

            #region UserControl1 Events

            #endregion

            //CommandBindings.Add(new CommandBinding(ApplicationCommands.New, OpenNewTab));
            //ApplicationCommands.New.Execute();
        }


        private void _MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //AdjustBrowserLayout(new Thickness(-1, 44, -1, -1), new Thickness(-2, 44, -2, 0));
            ExtraFuncs.Adjust_WinFormHost_On_WindowState(this, mainTabWebBrowser.host, new Thickness(-2, 44, -3, -2), new Thickness(0, 44, 0, 0));
        }
        private void _MainWindow_Activated(object sender, EventArgs e)
        {
            Application.Current.MainWindow = this;
        }
        private void _MainWindow_StateChanged(object sender, EventArgs e)
        {
            ExtraFuncs.Adjust_WinFormHost_On_WindowState(this, mainTabWebBrowser.host, new Thickness(-2, 44, -3, -2), new Thickness(0, 44, 0, 0));
            totalWidth = this.ActualWidth - 25;
            ResizeTabs();
        }
        private void _MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            totalWidth = this.ActualWidth - 25;
            ResizeTabs();
        }
        private void _MainWindow_Closed(object sender, EventArgs e)
        {
            ShutdownApp();
        }


        //---------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------
        // TabControl Functions
        // Setting the main WebBrowser to handle after toggling between tabs
        private void tabCtrl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            TabsManager();
            ResizeTabs();
        }
        private void tabCtrl_MouseEnter(object sender, MouseEventArgs e)
        {
            //tabsCount = tabCtrl.Items.Count + 1;
            ResizeTabs();
        }
        private void tabCtrl_MouseLeave(object sender, MouseEventArgs e)
        {
            //tabsCount = tabCtrl.Items.Count + 1;
            ResizeTabs();
        }
        private void tabCtrl_MouseMove(object sender, MouseEventArgs e)
        {
            //DragAmountBuffer(e);
        }
        private void tabCtrl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                if (this.WindowState == WindowState.Normal)
                {
                    this.WindowState = WindowState.Maximized;
                }
                else
                {
                    this.WindowState = WindowState.Normal;
                }
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------

        #region AddingTab Function and it Overloads
        public void AddingTab()
        {
            // setting tabsCount    // TabsCount represent the numbre of tabs that TabCtrl has
            //tabsCount = tabCtrl.Items.Count + 1;
            mainTabWebBrowser = new TabWebBrowser(InsializeAddress);
            mainTabWebBrowser.webBrowser.MenuHandler = new CustomContextMenuHandler();
            tabCtrl.Items.Insert(tabCtrl.Items.Count, mainTabWebBrowser);
            tabCtrl.SelectedItem = mainTabWebBrowser;
            GetUrlAddress();
            ResizeTabs();
        }
        public void AddingTab(string url)
        {
            // setting tabsCount    // TabsCount represent the numbre of tabs that TabCtrl has
            //tabsCount = tabCtrl.Items.Count + 1;
            mainTabWebBrowser = new TabWebBrowser(url);
            mainTabWebBrowser.webBrowser.MenuHandler = new CustomContextMenuHandler();
            tabCtrl.Items.Insert(tabCtrl.Items.Count, mainTabWebBrowser);
            tabCtrl.SelectedItem = mainTabWebBrowser;
            GetUrlAddress();
            ResizeTabs();
        }
        #endregion
        private void ResizeTabs()
        {
            tabsCount = tabCtrl.Items.Count + 1;

            if (tabsCount > 0)
            {
                tabCurrentWidth = totalWidth / tabsCount;
                foreach (TabWebBrowser tab in tabCtrl.Items)
                {
                    tab.Width = tabCurrentWidth;
                    ((UserControl1)tab.Header).txtGridColomn.Width = new GridLength(15); // the Margin of the Tab Text Header
                }
            }
            //MessageBox.Show(totalWidth.ToString());
        }
        public List<TabWebBrowser> GetTabsList()
        {
            List<TabWebBrowser> tabsList = new List<TabWebBrowser>();
            if (tabCtrl.Items.Count > 0)
            {
                foreach (TabWebBrowser tab in tabCtrl.Items)
                {
                    tabsList.Add(tab);
                }
            }
            return tabsList;
        }     // A Method to get all TabWebBrowsers in a list.
        private void TabsManager()
        {
            // TabsCount represent the numbre of tabs that TabCtrl has
            tabsCount = tabCtrl.Items.Count + 1;
            if (tabsCount > 1)
            {
                foreach (TabWebBrowser tab in tabCtrl.Items)
                {
                    tab.ShowSellectedTabFeatures(false);
                }
            }

            mainTabWebBrowser = (TabWebBrowser)tabCtrl.SelectedItem;
            if (mainTabWebBrowser != null)
            {
                mainTabWebBrowser.ShowSellectedTabFeatures(true);
                mainTabWebBrowser.webBrowser.AddressChanged += WebBrowser_AddressChanged;
                GetUrlAddress();
                UIControlsFocus();

                // to adjust the layout of the winFormHost of Browser Position
                ExtraFuncs.Adjust_WinFormHost_On_WindowState(this, mainTabWebBrowser.host, new Thickness(-2, 44, -3, -2), new Thickness(0, 44, 0, 0));
            }
            else if (mainTabWebBrowser == null)
            {
                if (tabsCount > 1)
                {
                    mainTabWebBrowser = (TabWebBrowser)tabCtrl.Items.GetItemAt(tabCtrl.Items.Count - 1);
                    tabCtrl.SelectedItem = mainTabWebBrowser;
                    mainTabWebBrowser.ShowSellectedTabFeatures(true);
                    mainTabWebBrowser.webBrowser.AddressChanged += WebBrowser_AddressChanged;
                    GetUrlAddress();

                    // to adjust the layout of the winFormHost of Browser Position
                    ExtraFuncs.Adjust_WinFormHost_On_WindowState(this, mainTabWebBrowser.host, new Thickness(-2, 44, -3, -2), new Thickness(0, 44, 0, 0));
                }
                else
                {
                    ShutdownApp();
                }
            }
        }
        public void LoadUrl(string url)
        {
            mainTabWebBrowser.webBrowser.Load(url);
        }
        private void GetUrlAddress()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(mainTabWebBrowser.webBrowser.Address))
                {
                    urlBar.urlComboBox.Text = mainTabWebBrowser.tempsearchBarTxt;
                }
                else
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        urlBar.urlComboBox.Text = mainTabWebBrowser.webBrowser.Address;
                        currentUrl = mainTabWebBrowser.webBrowser.Address;  // To Pervent Home URL to be loaded more than one time
                    });
                }
            }
            catch
            {

            }
        }
        private void ShutdownApp()
        {
            if (GetTabsList().Count > 0)
            {
                foreach (TabWebBrowser tab in GetTabsList())
                {
                    tab.webBrowser.Dispose();
                }
            }
            this.Close();
            if (Application.Current.Windows.Count < 1)
            {
                Application.Current.Shutdown();
            }

            //if (Application.Current.Windows.Count <= 1)
            //{
            //    Application.Current.Shutdown();
            //}
            //else;
            //{
            //}
            //Application.Current.Shutdown(); // for Closing the entire App
        }   // A Method to Shutdown the App and Dispose all WebBrowsers clones.
        private void UIControlsFocus()
        {

            Dispatcher.Invoke(() =>
            {
                if (mainTabWebBrowser != null && mainTabWebBrowser.webBrowser.Address.Length > 0)
                {
                    urlBar.MoveFocus(focusRequest);
                }
                else
                {
                    urlBar.urlComboBox.Focus();
                }
            });
          
        }

        /// <summary>
        /// Functions of WebBrowser
        /// Note that the main role is in Web Browser of TabWebBrowser
        /// </summary>
        #region WebBrowser Functions and Events
        private void WebBrowser_IsBrowserInitializedChanged(object sender, EventArgs e)
        {
        }
        private void WebBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            //try
            //{

            //    this.Dispatcher.Invoke(() => {
            //        TabsManager();

            //        if (mainTabWebBrowser.webBrowser.CanGoBack)
            //        {
            //            btn_Back_Image.Opacity = 0.6;
            //            btn_Back.IsEnabled = true;
            //        }
            //        else
            //        {
            //            btn_Back_Image.Opacity = 0.45;
            //            btn_Back.IsEnabled = false;
            //        }
            //        if (mainTabWebBrowser.webBrowser.CanGoForward)
            //        {
            //            btn_Forward.Opacity = 0.75;
            //        }
            //        else
            //        {
            //            btn_Forward.Opacity = 0.45;
            //        }
            //    });
            //}
            //catch { 
            //}
            //throw new NotImplementedException();
        }
        private void WebBrowser_ConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {
            //throw new NotImplementedException();
        }
        private void WebBrowser_TitleChanged(object sender, TitleChangedEventArgs e)  // Done through TabWebBrowser
        {
        }
        private void WebBrowser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            GetUrlAddress();
        }
        private void WebBrowser_LoadError(object sender, LoadErrorEventArgs e)
        {
        }
        private void WebBrowser_FrameLoadStart(object sender, FrameLoadStartEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                if (mainTabWebBrowser.webBrowser.CanFocus)
                {
                    mainTabWebBrowser.webBrowser.Focus();
                    //MessageBox.Show("Browser is FOCUSED");
                }
            });
        }
        private void WebBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {   
        }

        #endregion

        /// <summary>
        /// All Navigations like Back, Forward, Favorate, Home, Reload, ext...
        /// </summary>
        #region Navigation Actions
        /////* Namigations*/////
        private void btn_Home_Click(object sender, RoutedEventArgs e)
        {
            if (!currentUrl.Contains(urlHome))
            {
                LoadUrl(urlHome);
            }
        }
        private void btn_Forward_Click(object sender, RoutedEventArgs e)
        {
            if (mainTabWebBrowser.webBrowser.CanGoForward)
                mainTabWebBrowser.webBrowser.Forward();

        }
        //--------------------- Back Buttons events------------------------------------
        private void btn_Back_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            btn_Back_Image.Opacity = 100;
        }
        private void btn_Back_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            btn_Back_Image.Opacity = 0.5;

            if (mainTabWebBrowser.webBrowser.CanGoBack)
            {
                mainTabWebBrowser.webBrowser.Back();
            }
            else { return; }
        }
        //-------------------------------------------------------------------------------
        private void btn_Refresh_Click(object sender, RoutedEventArgs e)
        {
            mainTabWebBrowser.webBrowser.Reload(true);
        }
        private void _NewTbBtn_Click(object sender, RoutedEventArgs e)
        {
            AddingTab("");
        }
        #endregion

        /// <summary>
        /// UrlTextBox Functions and Events like sellecting all, Load Url...
        /// </summary>
        #region UrlTextBox Functions and Event

        private void debugHTMLBtn_Click(object sender, RoutedEventArgs e)
        {
            DebugWindow debugWin = new DebugWindow();
            debugWin.Show();
        }
        //private void UrlTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        //{
        //    // used for search suggesions ISA  

        //    //urlBar.urlCompoBox.Items.Clear();
        //    //if (!string.IsNullOrWhiteSpace(urlBar.urlTextBox.Text))
        //    //{
        //    //    url = new Uri("http://suggestqueries.google.com/complete/search?output=firefox&q=" + urlBar.urlTextBox.Text);
        //    //    request = (HttpWebRequest)WebRequest.Create(url);
        //    //    response = (HttpWebResponse)request.GetResponse();
        //    //    responseText = (new StreamReader(response.GetResponseStream())).ReadToEnd();
        //    //    items = (from each in responseText.Split(',')
        //    //             select each.Trim('[',']','\"',':','{','}')).ToArray<string>();
        //    //    for (int i = 0; i < items.Length; i++ )
        //    //    {
        //    //        if (items[i].Contains(urlBar.urlTextBox.Text))
        //    //        {
        //    //            urlBar.urlCompoBox.Items.Add(items[i]);
        //    //        }
        //    //    }

        //    //}
        //}
        //private void UrlTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        //{
        //    if (e.Key == Key.Enter)
        //    {
        //        LoadUrl(urlBar.urlTextBox.Text);
        //    }
        //}
        //private void UrlTextBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    urlBar.urlTextBox.SelectAll();
        //}
        #endregion

        #region UrlCompoBox Functions and Events
        private void UrlCompoBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(urlBar.urlComboBox.Text))
            {
                urlBar.urlComboBox.Text = mainTabWebBrowser.webBrowser.Address;
            }
        }
        private void UrlCompoBox_KeyDown(object sender, KeyEventArgs e)
        {
        }
        private void UrlComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (SafeSearch.SearchBarFilter(urlBar.urlComboBox) == true)
                {
                    LoadUrl(urlBar.urlComboBox.Text);
                }
            }
        }
        private void UrlCompoBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (urlBar.urlComboBox.IsDropDownOpen == false && mainTabWebBrowser.webBrowser.IsLoading == false)
            {
                urlBar.urlComboBox.IsDropDownOpen = true;
            }
            mainTabWebBrowser.tempsearchBarTxt = urlBar.urlComboBox.Text;
            itemResult.Clear();

            url = new Uri("http://suggestqueries.google.com/complete/search?output=firefox&q=" + urlBar.urlComboBox.Text);
            request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                responseText = (new StreamReader(response.GetResponseStream())).ReadToEnd();
                items = (from each in responseText.Split(',')
                         select each.Trim('[', ']', '\"', ':', '{', '}')).ToArray<string>();

                for (int i = 0; i < items.Length; i++)
                {
                    itemResult.Add(items[i]);
                    urlBar.urlComboBox.ItemsSource = itemResult.ToArray<string>();
                    //if (items[i].Contains(urlBar.urlCompoBox.Text))
                    //{

                    //}
                }
            }
            catch { }

        }
        private void UrlComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (SafeSearch.SearchBarFilter(urlBar.urlComboBox) == true)
            {
                LoadUrl(urlBar.urlComboBox.Text);
            }
        }
        //------------------------Buttons Functions-------------------------------------//
        private void Btn_Navigate_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            LoadUrl(urlBar.urlComboBox.Text);
        }

        #endregion

        //private void _MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    this.WindowState = WindowState.Normal;
        //    Point newPoint = e.GetPosition(this);
        //    if (e.LeftButton == MouseButtonState.Pressed )
        //    {
        //        this.DragMove();
        //    }
        //    //Point newPoint = e.GetPosition(this);
        //    //if (e.LeftButton == MouseButtonState.Pressed && (Math.Abs(newPoint.X - startPoint.X) > SystemParameters.MinimumHorizontalDragDistance ||
        //    //    Math.Abs(newPoint.Y - startPoint.Y) > SystemParameters.MinimumVerticalDragDistance))
        //    //{
        //    //    this.DragMove();
        //    //}
        //}

        //private void _MainWindow_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    startPoint = e.GetPosition(this);
        //}

        //private void _MainWindow_PreviewMouseMove(object sender, MouseEventArgs e)
        //{

        //}

        //void DragAmountBuffer(MouseEventArgs e)
        //{
        //    if (e.LeftButton == MouseButtonState.Pressed && e.GetPosition(tabCtrl).X >= startPoint.X + dragBuffer)
        //    {
        //        if (((TabWebBrowser)tabCtrl.SelectedItem).isClicked == false)
        //        {
        //            this.WindowState = WindowState.Normal;
        //            this.DragMove();
        //        }
        //    }
        //    else if (e.LeftButton == MouseButtonState.Pressed && e.GetPosition(tabCtrl).X <= startPoint.X - dragBuffer)
        //    {
        //        if (((TabWebBrowser)tabCtrl.SelectedItem).isClicked == false)
        //        {
        //            this.WindowState = WindowState.Normal;
        //            this.DragMove();
        //        }
        //    }
        //    if (e.LeftButton == MouseButtonState.Pressed && e.GetPosition(tabCtrl).Y >= startPoint.Y + dragBuffer)
        //    {
        //        if (((TabWebBrowser)tabCtrl.SelectedItem).isClicked == false)
        //        {
        //            this.WindowState = WindowState.Normal;
        //            this.DragMove();
        //        }
        //    }
        //    else if (e.LeftButton == MouseButtonState.Pressed && e.GetPosition(tabCtrl).Y <= startPoint.Y - dragBuffer)
        //    {
        //        if (((TabWebBrowser)tabCtrl.SelectedItem).isClicked == false)
        //        {
        //            this.WindowState = WindowState.Normal;
        //            this.DragMove();
        //        }
        //    }
        //}

    }


    //Implementation of the context menu handler
    public class CustomContextMenuHandler : DispatcherObject, IContextMenuHandler
    {
        string url; // Paramater URl (Contains: Link Url, Scource Url, Media Url ....)

        int Search = 300;
        int SearchNewWindow = 301;
        int OpenInNewTab = 302;
        int OpenInNewWindow = 303;
        int SavePageAs = 304;
        int SaveLinkAs = 305;
        int CopyLink = 306;
        int Print = 307;

        //This method prepares the context menu
        public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {

            if (parameters.IsEditable)
            {
                model.Clear();
                switch (parameters.DictionarySuggestions.Count)
                {
                    case 0:
                        break;
                    case 1:
                        model.AddItem(CefMenuCommand.SpellCheckSuggestion0, parameters.DictionarySuggestions[0]);
                        model.AddSeparator();
                        break;
                    case 2:
                        model.AddItem(CefMenuCommand.SpellCheckSuggestion0, parameters.DictionarySuggestions[0]);
                        model.AddItem(CefMenuCommand.SpellCheckSuggestion1, parameters.DictionarySuggestions[1]);
                        model.AddSeparator();
                        break;
                    case 3:
                        model.AddItem(CefMenuCommand.SpellCheckSuggestion0, parameters.DictionarySuggestions[0]);
                        model.AddItem(CefMenuCommand.SpellCheckSuggestion1, parameters.DictionarySuggestions[1]);
                        model.AddItem(CefMenuCommand.SpellCheckSuggestion2, parameters.DictionarySuggestions[2]);
                        model.AddSeparator();
                        break;
                    case 4:
                        model.AddItem(CefMenuCommand.SpellCheckSuggestion0, parameters.DictionarySuggestions[0]);
                        model.AddItem(CefMenuCommand.SpellCheckSuggestion1, parameters.DictionarySuggestions[1]);
                        model.AddItem(CefMenuCommand.SpellCheckSuggestion2, parameters.DictionarySuggestions[2]);
                        model.AddItem(CefMenuCommand.SpellCheckSuggestion3, parameters.DictionarySuggestions[3]);
                        model.AddSeparator();
                        break;
                    default:
                        model.AddItem(CefMenuCommand.SpellCheckSuggestion0, parameters.DictionarySuggestions[0]);
                        model.AddItem(CefMenuCommand.SpellCheckSuggestion1, parameters.DictionarySuggestions[1]);
                        model.AddItem(CefMenuCommand.SpellCheckSuggestion2, parameters.DictionarySuggestions[2]);
                        model.AddItem(CefMenuCommand.SpellCheckSuggestion3, parameters.DictionarySuggestions[3]);
                        model.AddSeparator();
                        break;
                }
                model.AddItem(CefMenuCommand.Undo, "Undo");
                model.AddItem(CefMenuCommand.Redo, "Redo");
                model.AddSeparator();
                model.AddItem(CefMenuCommand.Cut, "Cut");
                model.AddItem(CefMenuCommand.Copy, "Copy");
                model.AddItem(CefMenuCommand.Paste, "Paste");
                model.AddItem(CefMenuCommand.Delete, "Delete");
                model.AddItem(CefMenuCommand.SelectAll, "Select All");
                model.AddSeparator();
                if (!string.IsNullOrWhiteSpace(parameters.SelectionText))
                {
                    model.AddItem((CefMenuCommand)Search, "Search for " + "\"" + parameters.SelectionText + "\"");
                    //model.AddItem((CefMenuCommand)SearchNewTab, "Search new tab for " +"\"" +  parameters.SelectionText + "\"");
                    model.AddItem((CefMenuCommand)SearchNewWindow, "Search new window for " + "\"" + parameters.SelectionText + "\"");
                }
            }
            else
            {
                model.Clear();
                model.AddItem(CefMenuCommand.Back, "←← Back");
                model.AddItem(CefMenuCommand.Forward, "Forward →→");
                model.AddItem(CefMenuCommand.Reload, "Reload");
                model.AddSeparator();
                switch (parameters.TypeFlags)
                {
                    case ContextMenuType.Page:
                        model.AddItem((CefMenuCommand)OpenInNewTab, "Open In New Tab");
                        model.AddItem((CefMenuCommand)OpenInNewWindow, "Open In New Window");
                        model.AddItem((CefMenuCommand)CopyLink, "Copy Link");
                        model.AddSeparator();
                        model.AddItem((CefMenuCommand)SavePageAs, "Save Page As...");
                        break;
                    default:
                        switch (parameters.MediaType)
                        {
                            case ContextMenuMediaType.Image:
                                model.Clear();
                                model.AddItem((CefMenuCommand)OpenInNewTab, "View In New Tab");
                                model.AddItem((CefMenuCommand)OpenInNewWindow, "View In New Window");
                                model.AddItem(CefMenuCommand.Copy, "Copy Image");
                                model.AddItem((CefMenuCommand)CopyLink, "Copy Image Link");
                                model.AddSeparator();
                                model.AddItem((CefMenuCommand)SaveLinkAs, "Save Image As...");
                                break;
                            case ContextMenuMediaType.Audio:
                                model.Clear();
                                model.AddItem((CefMenuCommand)OpenInNewTab, "Open In New Tab");
                                model.AddItem((CefMenuCommand)OpenInNewWindow, "Open In New Window");
                                model.AddItem((CefMenuCommand)CopyLink, "Copy Link");
                                model.AddSeparator();
                                model.AddItem((CefMenuCommand)SaveLinkAs, "Save Audio As...");
                                break;
                            case ContextMenuMediaType.Video:
                                model.Clear();
                                model.AddItem((CefMenuCommand)OpenInNewTab, "Open In New Tab");
                                model.AddItem((CefMenuCommand)OpenInNewWindow, "Open In New Window");
                                model.AddItem((CefMenuCommand)CopyLink, "Copy Link");
                                model.AddSeparator();
                                model.AddItem((CefMenuCommand)SaveLinkAs, "Save Video As...");
                                break;
                            case ContextMenuMediaType.File:
                                model.Clear();
                                model.AddItem((CefMenuCommand)OpenInNewTab, "Open In New Tab");
                                model.AddItem((CefMenuCommand)OpenInNewWindow, "Open In New Window");
                                model.AddItem((CefMenuCommand)CopyLink, "Copy Link");
                                model.AddSeparator();
                                model.AddItem((CefMenuCommand)SaveLinkAs, "Save File As...");
                                break;
                            default:
                                model.Clear();
                                model.AddItem((CefMenuCommand)OpenInNewTab, "Open In New Tab");
                                model.AddItem((CefMenuCommand)OpenInNewWindow, "Open In New Window");
                                model.AddItem((CefMenuCommand)CopyLink, "Copy Link");
                                model.AddSeparator();
                                model.AddItem((CefMenuCommand)SaveLinkAs, "Save Link As...");
                                break;
                        }
                        //switch (parameters.TypeFlags)
                        //{
                        //    case ContextMenuType.Link:
                        //        model.Clear();
                        //        model.AddItem((CefMenuCommand)OpenInNewTab, "Open In New Tab");
                        //        model.AddItem((CefMenuCommand)OpenInNewWindow, "Open In New Window");
                        //        model.AddItem((CefMenuCommand)CopyLink, "Copy Link");
                        //        model.AddSeparator();
                        //        model.AddItem((CefMenuCommand)SaveLinkAs, "Save Link As...");
                        //        break;
                        //    case ContextMenuType.Media:
                        //        switch (parameters.MediaType)
                        //        {
                        //            case ContextMenuMediaType.Image:
                        //                model.Clear();
                        //                model.AddItem((CefMenuCommand)OpenInNewTab, "View In New Tab");
                        //                model.AddItem((CefMenuCommand)OpenInNewWindow, "View In New Window");
                        //                model.AddItem(CefMenuCommand.Copy, "Copy Image");
                        //                model.AddItem((CefMenuCommand)CopyLink, "Copy Image Link");
                        //                model.AddSeparator();
                        //                model.AddItem((CefMenuCommand)SaveLinkAs, "Save Image As...");
                        //                break;
                        //            case ContextMenuMediaType.Audio:
                        //                model.Clear();
                        //                model.AddItem((CefMenuCommand)OpenInNewTab, "Open In New Tab");
                        //                model.AddItem((CefMenuCommand)OpenInNewWindow, "Open In New Window");
                        //                model.AddItem((CefMenuCommand)CopyLink, "Copy Link");
                        //                model.AddSeparator();
                        //                model.AddItem((CefMenuCommand)SaveLinkAs, "Save Audio As...");
                        //                break;
                        //            case ContextMenuMediaType.Video:
                        //                model.Clear();
                        //                model.AddItem((CefMenuCommand)OpenInNewTab, "Open In New Tab");
                        //                model.AddItem((CefMenuCommand)OpenInNewWindow, "Open In New Window");
                        //                model.AddItem((CefMenuCommand)CopyLink, "Copy Link");
                        //                model.AddSeparator();
                        //                model.AddItem((CefMenuCommand)SaveLinkAs, "Save Video As...");
                        //                break;
                        //            case ContextMenuMediaType.File:
                        //                model.Clear();
                        //                model.AddItem((CefMenuCommand)OpenInNewTab, "Open In New Tab");
                        //                model.AddItem((CefMenuCommand)OpenInNewWindow, "Open In New Window");
                        //                model.AddItem((CefMenuCommand)CopyLink, "Copy Link");
                        //                model.AddSeparator();
                        //                model.AddItem((CefMenuCommand)SaveLinkAs, "Save File As...");
                        //                break;
                        //        }
                        //        break;
                        //}
                        break;
                }
                model.AddSeparator();
                model.AddItem(CefMenuCommand.SelectAll, "Select All");
                model.AddItem((CefMenuCommand)Print, "Print");
                if (!string.IsNullOrWhiteSpace(parameters.SelectionText))
                {
                    //ApplicationCommands.
                    model.AddSeparator();
                    model.AddItem((CefMenuCommand)Search, "Search for " + "\"" + parameters.SelectionText + "\"");
                    //model.AddItem((CefMenuCommand)SearchNewTab, "Search new tab for " + "\"" + parameters.SelectionText + "\"");
                    model.AddItem((CefMenuCommand)SearchNewWindow, "Search new window for " + "\"" + parameters.SelectionText + "\"");
                }


                ////Enable the button if can go Back and Forward
                model.SetEnabled(CefMenuCommand.Back, browser.CanGoBack);
                model.SetEnabled(CefMenuCommand.Forward, browser.CanGoForward);
                model.SetEnabled(CefMenuCommand.Reload, !browser.IsLoading);

                //model.SetEnabledAt(0, !string.IsNullOrWhiteSpace(parameters.SelectionText));
                //model.AddItem(CefMenuCommand.Find, "Search");
                //model.AddItem(CefMenuCommand.Find, "Search at new tab");
                //model.AddItem(CefMenuCommand.Find, "New Tap");
                //model.AddItem(CefMenuCommand.Print, "Print");
            }
        }
        //This method handles the menu item click
        public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters,
            CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            //If the 'Search' menu item is pressed
            if (commandId == CefMenuCommand.Find)
            {
                //Format the Url with the search query using the 'Bing' service
                string searchAddress = "https://www.bing.com/search?q=" + parameters.SelectionText;
                //And open new popup using the previously formatted Url
                //w.AddingTab();
                frame.ExecuteJavaScriptAsync($"window.open('{searchAddress}', '_blank')");
                //Notify if the context menu click is handled
                return true;
            }
            if (commandId == (CefMenuCommand)Search)
            {
                browserControl.Load("https://www.bing.com/search?q=" + parameters.SelectionText);
            }
            if (commandId == (CefMenuCommand)SearchNewWindow)
            {
                frame.ExecuteJavaScriptAsync($"window.open('{"https://www.bing.com/search?q=" + parameters.SelectionText}', '_blank')");
            }
            if (commandId == (CefMenuCommand)OpenInNewTab)
            {
                switch (parameters.TypeFlags)
                {
                    case ContextMenuType.Page:
                        url = parameters.PageUrl;
                        break;
                    default:
                        switch (parameters.MediaType)
                        {
                            case ContextMenuMediaType.Image:
                                url = parameters.SourceUrl;
                                break;
                            case ContextMenuMediaType.Audio:
                                url = parameters.SourceUrl;
                                break;
                            case ContextMenuMediaType.Video:
                                url = parameters.SourceUrl;
                                break;
                            case ContextMenuMediaType.File:
                                url = parameters.SourceUrl;
                                break;
                            default:
                                url = parameters.LinkUrl;
                                break;
                        }
                        break;
                }
                this.Dispatcher.Invoke(() =>
                {
                    ((MainWindow)Application.Current.MainWindow).AddingTab(url);
                });
            }
            if (commandId == (CefMenuCommand)OpenInNewWindow)
            {
                switch (parameters.TypeFlags)
                {
                    case ContextMenuType.Page:
                        url = parameters.PageUrl;
                        break;
                    default:
                        switch (parameters.MediaType)
                        {
                            case ContextMenuMediaType.Image:
                                url = parameters.SourceUrl;
                                break;
                            case ContextMenuMediaType.Audio:
                                url = parameters.SourceUrl;
                                break;
                            case ContextMenuMediaType.Video:
                                url = parameters.SourceUrl;
                                break;
                            case ContextMenuMediaType.File:
                                url = parameters.SourceUrl;
                                break;
                            default:
                                url = parameters.LinkUrl;
                                break;
                        }
                        break;
                }
                this.Dispatcher.Invoke(() =>
                {
                    MainWindow newWindow = new MainWindow();
                    newWindow.AddingTab(url);
                });
            }
            if (commandId == (CefMenuCommand)SavePageAs)
            {
                browser.GetHost().StartDownload(parameters.PageUrl);
            }
            if (commandId == (CefMenuCommand)SaveLinkAs)
            {
                switch (parameters.MediaType)
                {
                    case ContextMenuMediaType.Image:
                        browser.GetHost().StartDownload(parameters.SourceUrl);
                        break;
                    case ContextMenuMediaType.Audio:
                        browser.GetHost().StartDownload(parameters.SourceUrl);
                        break;
                    case ContextMenuMediaType.Video:
                        browser.GetHost().StartDownload(parameters.SourceUrl);
                        break;
                    case ContextMenuMediaType.File:
                        browser.GetHost().StartDownload(parameters.SourceUrl);
                        break;
                    default:
                        browser.GetHost().StartDownload(parameters.LinkUrl);
                        break;
                }
            }
            if (commandId == (CefMenuCommand)Print)
            {

                //CommandBinding command = new CommandBinding(ApplicationCommands.Open,OpenTab);
                //this.OnContextMenuCommand 
                //browser.GetHost().Print();
            }
             
            //Otherwise, let the default handler to handle the click
            return false;
        }
        public void OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {
        }
        public bool RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            return false;
        }

    }
}
