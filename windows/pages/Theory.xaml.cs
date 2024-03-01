using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        private static int lang = 0;
        private static int alg = 0;

        private string CodeText { get; set; }

        public Theory(Main win)
        {
            window = win;
            InitializeComponent();
            lang = 0;
            alg = 0;
            code.Text = @"
                static void BubbleSortAlgorithm(int[] array)
                {
                    int n = array.Length;
                    for (int i = 0; i < n - 1; i++)
                    {
                        for (int j = 0; j < n - i - 1; j++)
                        {
                            if (array[j] > array[j + 1])
                            {
                                int temp = array[j];
                                array[j] = array[j + 1];
                                array[j + 1] = temp;
                            }
                        }
                    }
                }
                ";
        }

        private void Navigate(object sender, RoutedEventArgs e)
        {
            string btnName = ((Button)sender).Name;
            name.Text = "Nazwa: Sortowanie ";
            complexity.Text = "Złożoność: ";
            if (btnName == "btn_0")
            {
                alg = 0;
                lang = 0;
                name.Text += "bąbelkowe";
                complexity.Text += "O(n^2)";
                description.Text = "Polega na porównywaniu dwóch kolejnych elementów i zamianie ich kolejności, jeżeli zaburza ona porządek, w jakim się sortuje tablicę. Sortowanie kończy się, gdy podczas kolejnego przejścia nie dokonano żadnej zmiany.";
                
            }
            else if (btnName == "btn_1")
            {
                alg = 1;
                lang = 0;
                name.Text += "przez wybór";
                complexity.Text += "O(n^2)";
                description.Text = "Polega na wyszukaniu elementu mającego się znaleźć na żądanej pozycji i zamianie miejscami z tym, który jest tam obecnie. Operacja jest wykonywana dla wszystkich indeksów sortowanej tablicy.";
            }
            else if (btnName == "btn_2")
            {
                alg = 2;
                lang = 0;
                name.Text += "przez wstawianie";
                complexity.Text += "O(n^2)";
                description.Text = "Polega na wstawieniu elementu w miejsce na odpowiednie miejsce, zachowując przy tym porządek.";
            }
            else if (btnName == "btn_3")
            {
                alg = 3;
                lang = 0;
                name.Text += "przez scalanie";
                complexity.Text += "O(n * log(n))";
                description.Text = "Polega na podzieleniu zbioru na mniejsze części, posortowaniu ich i połączeniu w jedną posortowaną całość.";

            }
            else if (btnName == "btn_4")
            {
                alg = 4;
                lang = 0;
                name.Text += "szybkie";
                complexity.Text += "O(n * log(n))";
                description.Text = "Polega na wybraniu elemetnu 'pivot' z tablicy i podzału pozostałych elementów na dwie podtablice zależnie od tego czy są mniejsze czy większe od pivota. Następnie podtablice są sortowane rekurencyjnie. ";
            }
            else if (btnName == "btn_5")
            {
                alg = 5;
                lang = 0;
                name.Text += "kubełkowe";
                complexity.Text += "O(n^k)";
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

        private void LanguageChanging(object sender, RoutedEventArgs e)
        {
            int change = ((Button)sender).Name.ToString() == "right" ? 1 : -1;
            SetLangVariable(change);

            SetCodeLanguage();
        }

        private void SetLangVariable(int change)
        {
            lang += change;
            if (lang > 2)
                lang = 0;
            else if (lang < 0)
                lang = 2;
        }


        private void SetCodeLanguage()
        {
            if (alg == 0)
            {
                if (lang == 0)
                {
                    code.Text = @"
                    static void BubbleSort(int[] array)
                    {
                        int n = array.Length;
                        for (int i = 0; i < n - 1; i++)
                        {
                            for (int j = 0; j < n - i - 1; j++)
                            {
                                if (array[j] > array[j + 1])
                                {
                                    int temp = array[j];
                                    array[j] = array[j + 1];
                                    array[j + 1] = temp;
                                }
                            }
                        }
                    }   
                    ";
                    Console.WriteLine("00");
                }
                else if (lang == 1)
                {
                    code.Text = @"
                    def bubble_sort(array):
                        n = len(array)
                        for i in range(n):
                            for j in range(0, n-i-1):
                                if array[j] > array[j+1]:
                                    array[j], array[j+1] = array[j+1], array[j]
                    ";
                    Console.WriteLine("01");
                }
                else if (lang == 2)
                {
                    code.Text = @"
                    void bubbleSort(int array[], int n) {
                        for (int i = 0; i < n-1; i++) {
                            for (int j = 0; j < n-i-1; j++) {
                                if (array[j] > array[j+1]) {
                                    swap(array[j], array[j+1]);
                                }
                            }
                        }
                    }
                    ";
                    Console.WriteLine("02");
                }
                else
                    Console.WriteLine("Theory - SetCodeLanguage - lang value error");
            }
            else if (alg == 1)
            {
                if (lang == 0)
                    Console.WriteLine("10");
                else if (lang == 1)
                    Console.WriteLine("11");
                else if (lang == 2)
                    Console.WriteLine("12");
                else
                    Console.WriteLine("Theory - SetCodeLanguage - lang value error");
            }
            else if (alg == 2)
            {
                if (lang == 0)
                    Console.WriteLine("20");
                else if (lang == 1)    
                    Console.WriteLine("21");
                else if (lang == 2)    
                    Console.WriteLine("22");
                else
                    Console.WriteLine("Theory - SetCodeLanguage - lang value error");
            }
            else if (alg == 3)
            {
                if (lang == 0)
                    Console.WriteLine("30");
                else if (lang == 1)
                    Console.WriteLine("31");
                else if (lang == 2)
                    Console.WriteLine("32");
                else
                    Console.WriteLine("Theory - SetCodeLanguage - lang value error");
            }
            else if (alg == 4)
            {
                if (lang == 0)
                    Console.WriteLine("40");
                else if (lang == 1)
                    Console.WriteLine("41");
                else if (lang == 2)
                    Console.WriteLine("42");
                else
                    Console.WriteLine("Theory - SetCodeLanguage - lang value error");
            }
            else if (alg == 5)
            {
                if (lang == 0)
                    Console.WriteLine("50");
                else if (lang == 1)
                    Console.WriteLine("51");
                else if (lang == 2)
                    Console.WriteLine("52");
                else
                    Console.WriteLine("Theory - SetCodeLanguage - lang value error");
            }
            else
                Console.WriteLine("Theory - SetCodeLanguage - value error");

        }
    }
}
