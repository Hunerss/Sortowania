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
        private static Main window;

        private static int lang;

        private string CodeText { get; set; }

        public Theory(Main win)
        {
            window = win;
            InitializeComponent();

            CodeText = @"
                def bubble_sort(arr):
                    n = len(arr)
                    for i in range(n):
                        for j in range(0, n-i-1):
                            if arr[j] > arr[j+1]:
                                arr[j], arr[j+1] = arr[j+1], arr[j]
                ";
            DataContext = this;
        }

        private void Navigate(object sender, RoutedEventArgs e)
        {
            string btnName = ((Button)sender).Name;
            name.Text = "Sortowanie ";
            if (btnName == "btn_0")
            {
                name.Text += "bąbelkowe";
                complexity.Text = "O(n^2)";
                description.Text = "Polega na porównywaniu dwóch kolejnych elementów i zamianie ich kolejności, jeżeli zaburza ona porządek, w jakim się sortuje tablicę. Sortowanie kończy się, gdy podczas kolejnego przejścia nie dokonano żadnej zmiany.";


            }
            else if (btnName == "btn_1")
            {
                name.Text += "przez wybór";
                complexity.Text = "O(n^2)";
                description.Text = "Polega na wyszukaniu elementu mającego się znaleźć na żądanej pozycji i zamianie miejscami z tym, który jest tam obecnie. Operacja jest wykonywana dla wszystkich indeksów sortowanej tablicy.";
            }
            else if (btnName == "btn_2")
            {
                name.Text += "przez wstawianie";
                complexity.Text = "O(n^2)";
                description.Text = "Polega na wstawieniu elementu w miejsce na odpowiednie miejsce, zachowując przy tym porządek.";
            }
            else if (btnName == "btn_3")
            {
                name.Text += "przez scalanie";
                complexity.Text = "O(n log n)";
                description.Text = "Polega na podzieleniu zbioru na mniejsze części, posortowaniu ich i połączeniu w jedną posortowaną całość.";

            }
            else if (btnName == "btn_4")
            {
                name.Text += "szybkie";
                complexity.Text = "O(n log n)";
                description.Text = "Polega na wybraniu elemetnu 'pivot' z tablicy i podzału pozostałych elementów na dwie podtablice zależnie od tego czy są mniejsze czy większe od pivota. Następnie podtablice są sortowane rekurencyjnie. ";
            }
            else if (btnName == "btn_5")
            {
                name.Text += "kubełkowe";
                complexity.Text = "O(n + k)";
                description.Text = "Polega na podzieleniu rozdzieleniu elementów tablicy do określonej liczby kubełków i sortowania każdego kubełka indywidualnie za pomocą innego algorytmu albo rekurencyjnie.";
            }
            else
                Console.WriteLine("Theory - Navigate - value error");
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

        private void left_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
