using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgExam
{
    public class RadixSort
    {
        // Метод для сортировки массива целых чисел
        public static void Sort(int[] array)
        {
            int i, j; // Переменные для циклов
            int[] tmp = new int[array.Length]; // Временный массив для хранения отсортированных чисел

            // Начало цикла для обхода каждого бита в числах
            for (int shift = sizeof(int) * 8 - 1; shift >= 0; shift--)
            {
                j = 0; // Счетчик для временного массива

                // Цикл для обхода каждого элемента во входном массиве
                for (i = 0; i < array.Length; i++)
                {
                    // Преобразование текущего элемента из десятичной системы в двоичную и сдвиг влево на shift битов
                    var before = Convert.ToString(array[i], toBase: 2);
                    var a = array[i] << shift;
                    var after = Convert.ToString(a, toBase: 2);

                    // Определение, нужно ли перемещать текущий элемент
                    bool move = (a) >= 0;

                    // Перемещение элемента либо в основной массив, либо во временный массив в зависимости от move
                    if (shift == 0 ? !move : move)
                        array[i - j] = array[i];
                    else
                        tmp[j++] = array[i];
                }

                // Копирование временного массива обратно в основной массив
                Array.Copy(tmp, 0, array, array.Length - j, j);
            }
        }
    }
}
