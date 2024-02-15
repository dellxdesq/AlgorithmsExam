using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgExam
{
    public class ShakerSort
    {
        public static void Start(int size)
        {
            int[] array = GenerateRandomArray(size);
            Console.WriteLine("| Shaker Sort |");
            Console.WriteLine("Исходный массив: ");
            Print(array);
            Sort(array);
            Console.WriteLine("Отсортированный массив: ");
            Print(array);
        }
        public static int[] GenerateRandomArray(int size)
        {
            int[] array = new int[size];
            Random r = new Random();
            for(int i = 0; i < array.Length; i++) { array[i] = r.Next(100); }
            return array;
        }
        public static void Sort(int[] array)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left < right)
            {
                Console.WriteLine("\nПроход слева на право: ");
                for (int i = left; i < right; i++)
                {
                    Console.WriteLine($"Просматриваем элементы {array[i]} и {array[i + 1]}");
                    if (array[i] > array[i + 1])
                    {
                        Console.WriteLine($"Пререставляем элементы {array[i]} и {array[i + 1]}");
                        (array[i], array[i + 1]) = (array[i + 1], array[i]);
                        Console.WriteLine("Состояние массива: ");
                        Print(array);
                    }
                }

                right--;
                Console.WriteLine("\nПроход справа на лево: ");
                for (int i = right; i > left; i--)
                {
                    Console.WriteLine($"Просматриваем элементы {array[i]} и {array[i - 1]}");
                    if (array[i - 1] > array[i])
                    {
                        Console.WriteLine($"Пререставляем элементы {array[i]} и {array[i - 1]}");
                        (array[i], array[i - 1]) = (array[i - 1], array[i]);
                        Console.WriteLine("Состояние массива: ");
                        Print(array);
                    }
                }

                left++;
            }
        }
        public static void Print(int[] array)
        {
        Console.Write("[ ");
        foreach(int item in array) Console.Write(item + " ");
        Console.Write("]\n\n");
        }
    }
}
