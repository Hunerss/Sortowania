using System;
using System.Windows;
using System.Windows.Controls;

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
            SetCodeLanguage();
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
                SetCodeLanguage();
            }
            else if (btnName == "btn_1")
            {
                alg = 1;
                lang = 0;
                name.Text += "przez wybór";
                complexity.Text += "O(n^2)";
                description.Text = "Polega na wyszukaniu elementu mającego się znaleźć na żądanej pozycji i zamianie miejscami z tym, który jest tam obecnie. Operacja jest wykonywana dla wszystkich indeksów sortowanej tablicy.";
                SetCodeLanguage();
            }
            else if (btnName == "btn_2")
            {
                alg = 2;
                lang = 0;
                name.Text += "przez wstawianie";
                complexity.Text += "O(n^2)";
                description.Text = "Polega na wstawieniu elementu w miejsce na odpowiednie miejsce, zachowując przy tym porządek.";
                SetCodeLanguage();
            }
            else if (btnName == "btn_3")
            {
                alg = 3;
                lang = 0;
                name.Text += "przez scalanie";
                complexity.Text += "O(n * log(n))";
                description.Text = "Polega na podzieleniu zbioru na mniejsze części, posortowaniu ich i połączeniu w jedną posortowaną całość.";
                SetCodeLanguage();
            }
            else if (btnName == "btn_4")
            {
                alg = 4;
                lang = 0;
                name.Text += "szybkie";
                complexity.Text += "O(n * log(n))";
                description.Text = "Polega na wybraniu elemetnu 'pivot' z tablicy i podzału pozostałych elementów na dwie podtablice zależnie od tego czy są mniejsze czy większe od pivota. Następnie podtablice są sortowane rekurencyjnie. ";
                SetCodeLanguage();
            }
            else if (btnName == "btn_5")
            {
                alg = 5;
                lang = 0;
                name.Text += "kubełkowe";
                complexity.Text += "O(n^k)";
                description.Text = "Polega na podzieleniu rozdzieleniu elementów tablicy do określonej liczby kubełków i sortowania każdego kubełka indywidualnie za pomocą innego algorytmu albo rekurencyjnie.";
                SetCodeLanguage();
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
            if (lang > 1)
                lang = 0;
            else if (lang < 0)
                lang = 1;
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
                            for (int j = 0; j < n - i - 1; j++)
                                if (array[j] > array[j + 1])
                                {
                                    int temp = array[j];
                                    array[j] = array[j + 1];
                                    array[j + 1] = temp;
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
                else
                    Console.WriteLine("Theory - SetCodeLanguage - lang value error");
            }
            else if (alg == 1)
            {
                if (lang == 0)
                {
                    code.Text = @"
                    static void SelectionSort(int[] array)
                    {
                        int n = array.Length;
                        for (int i = 0; i < n - 1; i++)
                        {
                            int minIndex = i;
                            for (int j = i + 1; j < n; j++)
                                if (array[j] < array[minIndex])
                                    minIndex = j;

                            int temp = array[minIndex];
                            array[minIndex] = array[i];
                            array[i] = temp;
                        }
                    }
                    ";
                    Console.WriteLine("10");
                }
                else if (lang == 1)
                {
                    code.Text = @"
                    def selection_sort(array):
                        n = len(array)

                        for i in range(n):
                            min_index = i
                            for j in range(i + 1, n):
                                if array[j] < array[min_index]:
                                    min_index = j

                            array[i], array[min_index] = array[min_index], array[i]
                    ";
                    Console.WriteLine("11");
                }
                else
                    Console.WriteLine("Theory - SetCodeLanguage - lang value error");
            }
            else if (alg == 2)
            {
                if (lang == 0)
                {
                    code.Text = @"
                    static void InsertionSort(int[] array)
                    {
                        int n = array.Length;
                        for (int i = 1; i < n; i++)
                        {
                            int key = array[i];
                            int j = i - 1;

                            while (j >= 0 && array[j] > key)
                            {
                                array[j + 1] = array[j];
                                j--;
                            }

                            array[j + 1] = key;
                        }
                    }
                    ";
                    Console.WriteLine("20");
                }
                else if (lang == 1)
                {
                    code.Text = @"
                    def insertion_sort(array):
                        for i in range(1, len(array)):
                            key = array[i]
                            j = i - 1

                            while j >= 0 and array[j] > key:
                                array[j + 1] = array[j]
                                j -= 1

                            array[j + 1] = key
                    ";
                    Console.WriteLine("21");
                }
                else
                    Console.WriteLine("Theory - SetCodeLanguage - lang value error");
            }
            else if (alg == 3)
            {
                if (lang == 0)
                {
                    code.Text = @"
                    static void MergeSort(int[] array)
                    {
                        if (array.Length > 1)
                        {
                            int mid = array.Length / 2;
                            int[] left = new int[mid];
                            int[] right = new int[array.Length - mid];

                            Array.Copy(array, 0, left, 0, mid);
                            Array.Copy(array, mid, right, 0, array.Length - mid);

                            MergeSort(left);
                            MergeSort(right);

                            int i = 0, j = 0, k = 0;

                            while (i < left.Length && j < right.Length)
                                if (left[i] <= right[j])
                                    array[k++] = left[i++];
                                else
                                    array[k++] = right[j++];

                            while (i < left.Length)
                                array[k++] = left[i++];

                            while (j < right.Length)
                                array[k++] = right[j++];
                        }
                    }
                    ";
                    Console.WriteLine("30");
                }
                else if (lang == 1)
                {
                    code.Text = @"
                    def merge_sort(array):
                        if len(array) > 1:
                            mid = len(array) // 2
                            left_half = array[:mid]
                            right_half = array[mid:]

                            merge_sort(left_half)
                            merge_sort(right_half)

                            i = j = k = 0

                            while i < len(left_half) and j < len(right_half):
                                if left_half[i] < right_half[j]:
                                    array[k] = left_half[i]
                                    i += 1
                                else:
                                    array[k] = right_half[j]
                                    j += 1
                                k += 1

                            while i < len(left_half):
                                array[k] = left_half[i]
                                i += 1
                                k += 1

                            while j < len(right_half):
                                array[k] = right_half[j]
                                j += 1
                                k += 1
                    ";
                    Console.WriteLine("31");
                }
                else
                    Console.WriteLine("Theory - SetCodeLanguage - lang value error");
            }
            else if (alg == 4)
            {
                if (lang == 0)
                {
                    code.Text = @"
                    static void QuickSort(int[] array, int low, int high)
                    {
                        int i = low;
                        int j = high;
                        int pivot = array[(low + high) / 2];

                        while (i <= j)
                        {
                            while (i <= j && array[i] < pivot)
                                i++;

                            while (j >= 0 && array[j] > pivot)
                                j--;

                            if (i <= j)
                            {
                                int temp = array[i];
                                array[i] = array[j];
                                array[j] = temp;
                                i++;
                                j--;
                            }
                        }

                        if (low < j)
                            QuickSort(array, low, j);
                        if (i < high)
                            QuickSort(array, i, high);
                    }
                    ";
                    Console.WriteLine("40");
                }
                else if (lang == 1)
                {
                    code.Text = @"
                    def quickSort(array, low, high):
                        if low < high:
	                    pivot = array[high]
   	                    i = low - 1
 
	                    for j in range(low, high):
        	                    if array[j] <= pivot:
	                                i = i + 1
 	                               (array[i], array[j]) = (array[j], array[i])
    	                    (array[i + 1], array[high]) = (array[high], array[i + 1])
                            pi = i + 1

                            quickSort(array, low, pi - 1)
                            quickSort(array, pi + 1, high)
                    ";
                    Console.WriteLine("41");
                }
                else
                    Console.WriteLine("Theory - SetCodeLanguage - lang value error");
            }
            else if (alg == 5)
            {
                if (lang == 0)
                {
                    code.Text = @"
                    static void BucketSort(int[] array)
                    {
                        int minValue = array.Min();
                        int maxValue = array.Max();

                        List<int>[] buckets = new List<int>[maxValue - minValue + 1];

                        for (int i = 0; i < buckets.Length; i++)
                            buckets[i] = new List<int>();

                        foreach (int num in array)
                            buckets[num - minValue].Add(num);

                        int index = 0;
                        for (int i = 0; i < buckets.Length; i++)
                        {
                            buckets[i].Sort();
                            foreach (int num in buckets[i])
                                array[index++] = num;
                        }
                    }
                    ";
                    Console.WriteLine("50");
                }
                else if (lang == 1)
                {
                    code.Text = @"
                    def bucket_sort(array):
                        buckets = [[] for _ in range(len(array))]

                        for num in array:
                            bucket_index = int(len(array) * num)
                            buckets[bucket_index].append(num)

                        for bucket in buckets:
                            bucket.sort()

                        index = 0
                        for bucket in buckets:
                            for num in bucket:
                                array[index] = num
                                index += 1
                    ";
                    Console.WriteLine("51");
                }
                else
                    Console.WriteLine("Theory - SetCodeLanguage - lang value error");
            }
            else
                Console.WriteLine("Theory - SetCodeLanguage - value error");

        }
    }
}
