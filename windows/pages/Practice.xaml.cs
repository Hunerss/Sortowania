using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Sortowania.windows.pages
{
    /// <summary>
    /// Logika interakcji dla klasy Practice.xaml
    /// </summary>
    public partial class Practice : UserControl
    {

        private static Main window;
        private static int algorithm = 0;

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
            algorithm = Convert.ToInt32(btn.Name.Substring(4));
            Console.WriteLine(btn.Name.Substring(4));
            Sort();
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
            if (!Check(min.Text))
            {
                MessageBox.Show("Wprowadzono nie poprawną wartość do pola \"Od\"");
                min.Text = "-10";
            }
            if (!Check(fre.Text))
            {
                MessageBox.Show("Wprowadzono nie poprawną wartość do pola \"Co ile\"");
                fre.Text = "1";
            }
            if (!Check(max.Text))
            {
                MessageBox.Show("Wprowadzono nie poprawną wartość do pola \"Do\"");
                max.Text = "10";
            }
        }

        private void FillBefore()
        {
            Random rnd = new();
            int minValue = Convert.ToInt32(min.Text);
            int maxValue = Convert.ToInt32(max.Text);
            string tag = (gen.SelectedItem as ComboBoxItem)?.Tag.ToString();
            Console.WriteLine(minValue + " " + maxValue);
            Console.WriteLine(tag);
            if (tag == "kol")
                for (int i = minValue; i <= maxValue; i += Convert.ToInt32(fre.Text))
                    before.Text += i + " ";
            else if (tag == "los")
                for (int i = minValue; i <= maxValue; i++)
                    before.Text += rnd.Next(minValue, maxValue) + " ";
            else
                Console.WriteLine("Practice - FillBefore - select error");
        }

        private int[] ReturnArray()
        {
            if (before != null)
            {
                string numbers = before.Text;
                string[] stringArray = numbers.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine(stringArray.Length);
                int[] intArrat = stringArray.Select(int.Parse).ToArray();
                return intArrat;
            }
            else
            {
                int[] ints = new int[0];
                return ints;
            }
        }

        private Boolean Check(string input)
        {
            foreach (char letter in input)
            {
                if (Char.IsLetter(letter))
                    return false;
            }
            return true;
        }

        private void GenerateNumbers(object sender, SelectionChangedEventArgs e)
        {
            if (before != null)
            {
                before.Text = "";
                FillBefore();
            }
        }

        private void SortNumbers(object sender, SelectionChangedEventArgs e)
        {
            if (before != null)
            {
                before.Text = "";
                FillBefore();
            }
        }


        private void BubbleSort(int[] array)
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
            InsertSortedNumbers(array);
        }

        private void SelectionSort(int[] array)
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
            InsertSortedNumbers(array);
        }

        private void InsertionSort(int[] array)
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
            InsertSortedNumbers(array);
        }

        private void MergeSort(int[] array)
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

                InsertSortedNumbers(array);
            }
        }
        
        private void QuickSort(int[] array, int low, int high)
        {
            var i = low;
            var j = high;
            var pivot = array[(low + high) / 2];

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

            InsertSortedNumbers(array);
        }

        private void BucketSort(int[] array)
        {
            int minValue = array.Min();
            int maxValue = array.Max();
            int offset = Math.Abs(minValue);

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

            InsertSortedNumbers(array);
        }

        private void Sort()
        {
            int[] array = ReturnArray();

            switch (algorithm)
            {
                case 0:
                    BubbleSort(array);
                    break;
                case 1:
                    SelectionSort(array);
                    break;
                case 2:
                    InsertionSort(array);
                    break;
                case 3:
                    MergeSort(array);
                    break;
                case 4:
                    QuickSort(array, 0, array.Length);
                    break;
                case 5:
                    BucketSort(array);
                    break;
                default:
                    Console.WriteLine("Practice - Sort - value error");
                    break;
            }
        }

        private void InsertSortedNumbers(int[] array)
        {
            after.Text = string.Join(" ", array);
        }
    }
}
