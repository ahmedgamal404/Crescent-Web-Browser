//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
//using System.Windows.Data;
//using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for UrlBar.xaml
    /// </summary>
    public partial class UrlBar : UserControl
    {
        public UrlBar()
        {
            InitializeComponent();
            urlComboBox.AddHandler(TextBoxBase.TextChangedEvent,new TextChangedEventHandler(urlComboBox_TextChanged));
            //urlComboBox.IsSynchronizedWithCurrentItem = true;

        }

        private void urlComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            urlComboBox.ToolTip = urlComboBox.Text;
            if (string.IsNullOrWhiteSpace(urlComboBox.Text))
            {
                urlComboBox.Opacity = 0.4;
            }
            else
            {
                urlComboBox.Opacity = 1;
            }
        }
        private void urlComboBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!urlComboBox.IsDropDownOpen)
            {
                urlComboBox.IsDropDownOpen = true;
            }
        }

        //private void urlComboBox_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        //{
        //    rectangle.Stroke = Brushes.Blue;
        //    rectangle.StrokeThickness = 2.0;
        //}

        //private void urlComboBox_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        //{
        //    rectangle.Stroke = Brushes.Black;
        //    rectangle.StrokeThickness = 1.0;
        //}
    }
}
