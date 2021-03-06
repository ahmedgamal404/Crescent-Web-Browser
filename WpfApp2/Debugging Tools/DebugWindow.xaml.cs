using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2.Debugging_Tools
{
    /// <summary>
    /// Interaction logic for DebugWindow.xaml
    /// </summary>
    public partial class DebugWindow : Window
    {
        public DebugWindow()
        {
            InitializeComponent();
        }

        private void excuteBtn_Click(object sender, RoutedEventArgs e)
        {
            ((TabWebBrowser)((MainWindow)App.Current.MainWindow).tabCtrl.SelectedItem).webBrowser.LoadHtml(debugTxtBlock.Text);
        }

        private void getCodeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.BeginInvoke((Action)(async () =>
            {
                debugTxtBlock.Text = await ((TabWebBrowser)((MainWindow)App.Current.MainWindow).tabCtrl.SelectedItem).webBrowser.GetTextAsync();
            }));

        }
    }
}
