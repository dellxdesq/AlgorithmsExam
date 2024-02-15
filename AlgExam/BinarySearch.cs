namespace AlgExam
{
    public class BinarySearch
    {
        public static void Start(int size)
        {
            int[] array = GenerateArray(size);
            Console.WriteLine("| Binary Search |");
            Console.WriteLine("Исходный массив: ");
            Print(array);
            Console.WriteLine("Введите искомый элемент: ");
            int value = int.Parse(Console.ReadLine());
            int index = Search(array, value);
            if (index != -1)
            {
                Console.Write("Искомый элемент: ");
                PrintColored(array, index);
            }
            else
            {
                Console.WriteLine("Элемент не найден.");
            }
        }

        public static int[] GenerateArray(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < array.Length; i++) { array[i] = i * 3; }
            return array;
        }

        public static int Search(int[] array, int value)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                Console.WriteLine($"Находим центр массива: {array[mid]}");

                // Если средний элемент равен целевому, возвращаем его индекс.
                if (array[mid] == value)
                    return mid;

                // Если целевой элемент меньше среднего, ищем в левой половине.
                if (array[mid] > value)
                {
                    Console.WriteLine($"Так как нужное нам число меньше центрального элемента, то меняем границы для поиска");
                    right = mid - 1;
                    Console.WriteLine($"Новые границы для поиска : {string.Join(" ", array.Take(left..(right +1)))}");
                }
                // Если целевой элемент больше среднего, ищем в правой половине.
                else
                {
                    Console.WriteLine($"Так как нужное нам число больше центрального элемента, то меняем границы обхода");
                    left = mid + 1;
                    Console.WriteLine($"Новые границы для поиска : {string.Join(" ", array.Take(left..(right+1)))}");
                }
            }

            // Если элемент не найден.
            return -1;
        }

        public static void Print(int[] array)
        {
            Console.Write("[ ");
            foreach (int i in array) Console.Write(i + " ");
            Console.Write("]\n\n");
        }

        public static void PrintColored(int[] array, int index)
        {
            Console.Write("[ ");
            for (int i = 0; i < array.Length; i++)
            {
                if (i == index)
                { 
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(array[i] + " ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(array[i] + " ");
                }
            }
            Console.WriteLine("]\n");
        }
    }
}
