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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public void TabCloseButton_Click(object sender, RoutedEventArgs e)
        {
            //------------------TabControl---------------------------------TabWebBrowser
            ((TabControl)((TabWebBrowser)this.Parent).Parent).Items.Remove(this.Parent);

            // Dispose the webBrowser
            ((TabWebBrowser)this.Parent).webBrowser.Dispose();

            //((TabControl)((TabWebBrowser)this.Parent).Parent).SelectedIndex =
            //((TabControl)((TabWebBrowser)this.Parent).Parent).Items.Count - 1;
        }
    }
}
