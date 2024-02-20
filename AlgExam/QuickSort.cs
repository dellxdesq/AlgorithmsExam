using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgExam
{
    
    internal class QuickSort
    {
        Stack<string> numbers = new Stack<string>();
        public static int[] Start(int[] array, int min, int max)
        {
            if (min >= max)
                return array;

            static int Sort(int[] array, int first, int last)
            {
                var middle = (first + last) / 2;
                var pivot = array[middle];

                Console.WriteLine($"Берем опорный элемент: {pivot}");

                var i = first;
                var j = last;

                while (i <= j)
                {
                    while (array[i] < pivot)
                    {
                        i++;
                    }

                    while (array[j] > pivot)
                    {
                        j--;
                    }

                    if (i <= j)
                    {
                        Console.WriteLine($"Переставляем элементы: {array[i]} и {array[j]}");
                        (array[i], array[j]) = (array[j], array[i]);
                        i++;
                        j--;
                        Console.WriteLine($"Состояние массива: ");
                        
                    }
                }

                return i;
            }

            var pivot = Sort(array, min, max);
            Start(array, min, pivot - 1);
            Start(array, pivot, max);

            return array;
        }

        
    }
}
