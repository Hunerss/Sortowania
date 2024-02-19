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

namespace Sortowania.windows.pages
{
    /// <summary>
    /// Logika interakcji dla klasy Theory.xaml
    /// </summary>
    public partial class Theory : UserControl
    {
        public Theory()
        {
            InitializeComponent();
        }

        private void Navigate(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Console.WriteLine(btn.Name);
        }
    }
}
