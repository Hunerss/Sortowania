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
    /// Logika interakcji dla klasy Practice.xaml
    /// </summary>
    public partial class Practice : UserControl
    {

        private static Main window;

        public Practice(Main win)
        {
            window = win;
            InitializeComponent();
            min.Text = "-10";
            max.Text = "10";
            fre.Text = "1";
            FillBefore();
        }

        private void Navigate(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Console.WriteLine(btn.Name);
        }

        private void MainNavigate(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Name == "theory")
                window.frame.NavigationService.Navigate(new Theory(window));
            else if (btn.Name == "practice")
                window.frame.NavigationService.Navigate(new Practice(window));
            else
                window.frame.NavigationService.Navigate(new Welcome(window));
        }

        private void Display(object sender, TextChangedEventArgs e)
        {
            Console.WriteLine(min.Text + " " + fre.Text + " " + max.Text);
            //    if (Check(min.Text) && Check(fre.Text) && Check(max.Text))
            //        FillBefore();
            //    else
            //    {
            //        if (!Check(min.Text))
            //            MessageBox.Show("Wprowadzono nie poprawną wartość do pola \"Od\"");
            //        if (!Check(fre.Text))
            //            MessageBox.Show("Wprowadzono nie poprawną wartość do pola \"Co ile\"");
            //        if (!Check(max.Text))
            //            MessageBox.Show("Wprowadzono nie poprawną wartość do pola \"Do\"");
            //    }
        }

        private void FillBefore()
        {
            for (int i = Convert.ToInt32(min.Text); i <= Convert.ToInt32(max.Text); i += Convert.ToInt32(fre.Text))
                before.Text += i + " ";
        }

        private Boolean Check(string input)
        {
            foreach (char letter in input)
            {
                if(Char.IsLetter(letter))
                    return false;
            }
            return true;
        }
    }
}
