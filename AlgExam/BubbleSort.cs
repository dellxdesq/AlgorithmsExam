using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgExam
{
    public class BubbleSort
    {
        public static void Start(int size)
        {
            int[] array = GenerateRandomArray(size);
            Console.WriteLine("| Bubble Sort |");
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
            for (int i = 0; i < array.Length; i++) { array[i] = r.Next(100); }
            return array;
        }
        public static void Sort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    Console.WriteLine($"Сравниваем элементы: [ {array[j]} ] и [ {array[j + 1]} ]");
                    if (array[j] > array[j + 1])
                    {
                        Console.WriteLine($"Переставляем элементы: [ {array[j]} ] и [ {array[j + 1]} ]");
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        Console.WriteLine("Состояние массива: ");
                        Print(array);
                    }
                }
            }
        }
        public static void Print(int[] array)
        {
            Console.Write("[ ");
            foreach (int item in array) Console.Write(item + " ");
            Console.Write("]\n\n");
        }
    }
}
