using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgExam
{
    public class SelectionSort
    {
        public static void Start(int size)
        {
            //int[] array = GenerateRandomSort(size);
            int[] array = { 62, 51, 58, 37, 74, 9, 80, 81, 90, 79 };
            Console.WriteLine("| Selection Sort |");
            Console.WriteLine("Исходный массив: ");
            Print(array);
            Sort(array);
            Console.WriteLine("Отсортированный массив: ");
            Print(array);
        }
        public static int[] GenerateRandomSort(int size)
        {
            int[] array = new int[size];
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++) { array[i] = rand.Next(100); }
            return array;
        }
        public static void Sort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int min = i;
                Console.WriteLine($"Берем элемент [ {array[min]} ]");
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }
                Console.WriteLine($"Нашли элемент меньше нашего [ {array[min]} ]");
                Console.WriteLine($"Меняем местами элемент [ {array[i]} ] и [ {array[min]} ]");
                (array[i], array[min]) = (array[min], array[i]);
                Console.WriteLine("Состояние массива: ");
                Print(array);
            }
        }
        public static void Print(int[] array)
        {
            Console.Write("[ ");
            foreach (int i in array) Console.Write(i + " ");
            Console.Write("]\n\n");
        }
    }
}
