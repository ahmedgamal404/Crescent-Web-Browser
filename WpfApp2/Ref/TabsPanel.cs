using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Windows.Media.Animation;
using System.Threading;

namespace WpfApp2
{

    class TabsPanel : TabPanel
    {
        public TabsPanel()
        {
            
        }
        public void ResizeChildElements(double windoWidth)
        {
            double tabsWidth = 0;
            if (this.Children.Count > 1)
            {
                foreach (TabWebBrowser tab in this.Children)
                {
                    tabsWidth += tab.Width;
                }
            }

            if (tabsWidth < (windoWidth - 100))
            {
                foreach (TabWebBrowser tab in this.Children)
                {
                    tab.Width = tab.Width - 50;
                }
            }

        }

    }
}
