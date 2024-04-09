using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgExam
{
    public class RadixSort
    {
    public static void MSD_RadixSort(string[] strs, int low, int high, int index)
    {
     // Если нижний индекс больше или равен верхнему, возвращаемся
     if (low >= high)
     {
         return;
     }

     // Создаем массив для подсчета
     int[] count = new int[257];
     // Создаем временный словарь
     Dictionary<int, string> temp = new Dictionary<int, string>();

     // Подсчитываем количество символов в каждой строке
     for (int i = low; i <= high; i++)
     {
         var c = Char_at(strs[i], index);
         count[c + 2]++;
     }

     // Суммируем подсчитанные значения
     for (int r = 0; r < 256; r++)
     {
         count[r + 1] += count[r];
     }

     // Заполняем временный словарь
     for (int i = low; i <= high; i++)
     {
         var c = Char_at(strs[i], index);
         temp.Add(count[c + 1]++, strs[i]);
     }

     // Переносим строки обратно в исходный массив
     for (int i = low; i <= high; i++)
     {
         strs[i] = temp[i - low];
     }

     // Вызываем MSD_RadixSort для каждой группы строк
     for (int r = 0; r < 256; r++)
     {
         MSD_RadixSort(strs, low + count[r], low + count[r + 1] - 1, index + 1);
     }
    }

    // Получаем символ из строки по индексу
    private static int Char_at(string str, int index)
    {
        // Если длина строки меньше или равна индексу, возвращаем -1
        if (str.Length <= index)
        {
             return -1;
        }

        // Возвращаем ASCII-код символа по указанному индексу
        return (int)str[index];
 }
}
}
