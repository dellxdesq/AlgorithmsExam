using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgExam
{
    public class ShellSort
    {
        public static void Start(int size)
        {
            int[] array = GenerateRandomArray(size);
            Console.WriteLine("| Shell Sort |");
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
            int length = array.Length;
            for (int interval = length / 2; interval > 0; interval /= 2)
            {
                for (int i = interval; i < length; i++)
                {
                    int j = i - interval;
                    Console.WriteLine($"Просматриваем элементы: [ {array[j]} ] и [ {array[j + interval]} ]");
                    for (j = i - interval; j >= 0 && array[j] > array[j + interval]; j -= interval)
                    {
                        if (array[j] <= array[j + interval]) 
                            break;

                        Console.WriteLine($"Переставляем элементы: [ {array[j]} ] и [ {array[j + interval]} ]");
                        (array[j], array[j + interval]) = (array[j + interval], array[j]);
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
