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
    /// Logika interakcji dla klasy Welcome.xaml
    /// </summary>
    public partial class Welcome : UserControl
    {
        private static Main window;
        private static Button clickedButton = new();

        public Welcome(Main win)
        {
            window = win;
            InitializeComponent();
        }

        private void Navigate(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            ColorButtons(btn);
            if (btn.Name == "theory")
                window.frame.NavigationService.Navigate(new Theory(window));
            else if (btn.Name == "practice")
                window.frame.NavigationService.Navigate(new Practice(window));
            else
                window.frame.NavigationService.Navigate(new Welcome(window));
        }

        private void ColorButtons(Button newButton)
        {
            if (clickedButton != newButton)
            {
                clickedButton.Style = (Style)FindResource("BaseButtonStyle");
                newButton.Style = (Style)FindResource("ClickedButtonStyle");
                clickedButton = newButton;
            }
        }
    }
}
