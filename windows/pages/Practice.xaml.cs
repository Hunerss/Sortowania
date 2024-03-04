using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Sortowania.windows.pages
{
    /// <summary>
    /// Logika interakcji dla klasy Practice.xaml
    /// </summary>
    public partial class Practice : UserControl
    {

        private static Main window;
        private static int algorithm = 0;
        private static Boolean reversed = false;
        private static Button clickedButton = new();

        public Practice(Main win)
        {
            window = win;
            InitializeComponent();
            min.Text = "-10";
            max.Text = "10";
            fre.Text = "1";
            ColorButtons(btn_0);
            FillBefore();
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

        private void Navigate(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            ColorButtons(btn);
            algorithm = Convert.ToInt32(btn.Name.Substring(4));
            Console.WriteLine(btn.Name.Substring(4));
            Sort();
        }

        private void MainNavigate(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            ColorButtons(btn);
            switch (btn.Name)
            {
                case "theory":
                    window.frame.NavigationService.Navigate(new Theory(window));
                    break;
                case "practice":
                    window.frame.NavigationService.Navigate(new Practice(window));
                    break;
                default:
                    window.frame.NavigationService.Navigate(new Welcome(window));
                    break;
            }
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
            if (tag == "rai")
                for (int i = minValue; i <= maxValue; i += Convert.ToInt32(fre.Text))
                    before.Text += i + " ";
            else if (tag == "dec")
                for (int i = maxValue; i >= minValue; i -= Convert.ToInt32(fre.Text))
                    before.Text += i + " ";
            else if (tag == "ran")
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
                if (Char.IsLetter(letter))
                    return false;
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

        private void Reverse(object sender, SelectionChangedEventArgs e)
        {
            string tag = (way.SelectedItem as ComboBoxItem)?.Tag.ToString();
            reversed = tag != "rai";
        }

        private void BubbleSort(int[] array, Boolean reverse)
        {
            int n = array.Length;
            if (reverse)
                for (int i = 0; i < n - 1; i++)
                    for (int j = 0; j < n - i - 1; j++)
                        if (array[j] < array[j + 1])
                        {
                            int temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                        else { }
            else
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

        private void SelectionSort(int[] array, Boolean reverse)
        {
            int n = array.Length;
            if(reverse)
                for (int i = 0; i < n - 1; i++)
                {
                    int maxIndex = i;
                    for (int j = i + 1; j < n; j++)
                        if (array[j] > array[maxIndex])
                            maxIndex = j;

                    int temp = array[maxIndex];
                    array[maxIndex] = array[i];
                    array[i] = temp;
                }
            else
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

        private void InsertionSort(int[] array, Boolean reverse)
        {
            int n = array.Length;
            if(reverse)
                for (int i = 1; i < n; i++)
                {
                    int key = array[i];
                    int j = i - 1;

                    while (j >= 0 && array[j] < key)
                    {
                        array[j + 1] = array[j];
                        j--;
                    }

                    array[j + 1] = key;
                }
            else
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

        private void MergeSort(int[] array, Boolean reverse)
        {
            if (array.Length > 1)
            {
                int mid = array.Length / 2;
                int[] left = new int[mid];
                int[] right = new int[array.Length - mid];

                Array.Copy(array, 0, left, 0, mid);
                Array.Copy(array, mid, right, 0, array.Length - mid);

                MergeSort(left, reverse);
                MergeSort(right, reverse);

                int i = 0, j = 0, k = 0;

                while (i < left.Length && j < right.Length)
                    if (!reverse)
                        if (left[i] <= right[j])
                            array[k++] = left[i++];
                        else
                            array[k++] = right[j++];
                    else
                        if (left[i] >= right[j])
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
        
        private void QuickSort(int[] array, int low, int high, Boolean reverse)
        {
            int i = low;
            int j = high;
            int pivot = array[(low + high) / 2];

            while (i <= j)
            {
                if (!reverse)
                {
                    while (i <= j && array[i] < pivot)
                        i++;

                    while (j >= 0 && array[j] > pivot)
                        j--;
                }
                else
                {
                    while (i <= j && array[i] > pivot)
                        i++;

                    while (j >= 0 && array[j] < pivot)
                        j--;
                }

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
                QuickSort(array, low, j, reverse);
            if (i < high)
                QuickSort(array, i, high, reverse);

            InsertSortedNumbers(array);
        }

        private void BucketSort(int[] array, Boolean reverse)
        {
            Console.WriteLine(reverse);
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

            if(reverse)
                Array.Reverse(array);
            InsertSortedNumbers(array);
        }

        private void Sort()
        {
            int[] array = ReturnArray();

            switch (algorithm)
            {
                case 0:
                    BubbleSort(array, reversed);
                    break;
                case 1:
                    SelectionSort(array, reversed);
                    break;
                case 2:
                    InsertionSort(array, reversed);
                    break;
                case 3:
                    MergeSort(array, reversed);
                    break;
                case 4:
                    QuickSort(array, 0, array.Length-1, reversed);
                    break;
                case 5:
                    BucketSort(array, reversed);
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
