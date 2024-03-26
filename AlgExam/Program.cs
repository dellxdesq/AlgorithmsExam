﻿using AlgExam;
using System.Collections;

class Program
{
    /*
    Level 1:
        1)BubbleSort    +
        2)InsertionSort +
        3)SelectionSort +
        4)ShakerSort    +
        5)BinarySearch  +

    Level 2:
        6)ShellSort     + 
        7)QuickSort        
        8)Stack        
        9)Queue        
    */
    static void Main()
    {
        /*
        BUBBLE SORT:
        | ОПИСАНИЕ |
        Простейший алгоритм сортировки, который многократно меняет местами соседние элементы, 
        если они расположены в неправильном порядке. Проход по списку повторяется до тех пор,
        пока список не будет отсортирован.
        | Шаги работы |
        1. Берём пару элементов сравниваем их
        2. Если первый больше второго меняем их местами
        3. Повторям 1,2 шаг пока массив не будет отсортирован
        | СЛОЖНОСТЬ |
        Лучший случай: O(n), возникает в случае, если массив уже отсортирован;
        Средний случай: O(n^2), элементы перемешаны в порядке так, что порядок не является должным образов возрастающим или убывающим;
        Худший случай: O(n^2), возникает в случае, когда массив уже отсортирован в обратном порядке;
        */

        //BubbleSort2.Start(10);

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /*
        INSERTION SORT:
        | ОПИСАНИЕ |
        Сортировка вставками является простым алгоритмом сортировки, который работает 
        путем прохода по массиву и "вставки" каждого элемента на свое правильное место. 
        На каждом шаге текущий элемент сравнивается с элементами, уже находящимися в отсортированной части массива.
        | Шаги работы |
        1. Начинаем с предположения, что первый элемент массива уже отсортирован.
        2. Берем следующий элемент и сравниваем его с предыдущим элементом.
        3. Если текущий элемент меньше предыдущего, меняем их местами.
        4. Продолжаем сравнивать текущий элемент с предыдущими элементами, пока не найдем 
        его правильное местоположение в отсортированной части массива или не дойдем до начала массива.
        5. Переходим к следующему элементу и повторяем процесс.
        | СЛОЖНОСТЬ |
        Лучший случай: O(n), возникает в случае, если массив уже отсортирован;
        Средний случай: O(n^2), элементы перемешаны в порядке так, что порядок не является должным образов возрастающим или убывающим;
        Худший случай: O(n^2), возникает в случае, когда массив уже отсортирован в обратном порядке;
        */

        //InsiretionSort2.Start(10);

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /*
        SELECTION SORT:
        | ОПИСАНИЕ |
        Простой алгоритм сортировки, который на каждом шаге ищет минимальный (или максимальный) 
        элемент из неотсортированной части массива и меняет его местами с первым элементом в неотсортированной части.
        | Шаги работы |
        1. Начинаем с того, что весь массив считается неотсортированным.
        2. Проходим по неотсортированной части массива и ищем минимальный элемент.
        3. Меняем минимальный элемент с первым элементом в неотсортированной части массива.
        4. Считаем первый элемент отсортированным и двигаем границу между отсортированной и неотсортированной частью вправо.
        5. Повторяем процесс для оставшейся неотсортированной части массива, пока весь массив не будет отсортирован.
        | СЛОЖНОСТЬ |
        Лучший случай: O(n^2)
        Средний случай: O(n^2)
        Худший случай: O(n^2)
        */

        //SelectionSort2.Start(10);

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /*
        SHAKER SORT:
        | ОПИСАНИЕ |
        Шейкерная сортировка – это вариация сортировки пузырьком, которая двигается в обе стороны.
        Идя вправо по массиву выталкивает наибольше элементы в конец, идя в лево выталкивает наименьшие элементы в начало.
        | Шаги работы |
        1. Начинаем с границы, которая находится на первом и последнем элементах массива.
        2. Повторяем следующие шаги, пока границы не встретятся:
            Проходим по массиву с левой границы до правой, сравнивая соседние элементы и меняя их местами, если необходимо.
            После прохода справа налево, сдвигаем правую границу на один элемент влево.
            Проходим по массиву с правой границы до левой, сравнивая соседние элементы и меняя их местами, если необходимо.
            После прохода слева направо, сдвигаем левую границу на один элемент вправо.
        3. Повторяем процесс, пока необходимо.
        | СЛОЖНОСТЬ |
        Лучший случай: O(n)
        Средний случай: O(n^2)
        Худший случай: O(n^2)
        */

        //ShakerSort.Start(10);
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /*
        BINARY SEARCH:
        | ОПИСАНИЕ |
        Бинарный поиск — это алгоритм поиска элемента в отсортированном массиве путем разделения массива на две части 
        и последующего сокращения диапазона поиска вдвое. Основная идея заключается в том, 
        чтобы на каждом шаге сравнивать искомый элемент с элементом в середине массива 
        и исключать из дальнейшего рассмотрения половину элементов.
        | Шаги работы |
        1. Установить два указателя: левый (начальный) и правый (конечный) границы диапазона поиска.
        2. Найти середину диапазона (средний индекс).
        3. Сравнить искомый элемент с элементом по середине.
        4. Если элемент найден, завершить поиск.
        5. Если искомый элемент меньше элемента по середине, установить правую границу на индексе середины минус один.
        6. Если искомый элемент больше элемента по середине, установить левую границу на индексе середины плюс один.
        7. Повторять процесс с шага 2 до тех пор, пока левая граница не станет больше правой.
        | СЛОЖНОСТЬ |
        O(log (n))
        */

        //BinarySearch.Start(20);

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /*
        SHELL SORT:
        | ОПИСАНИЕ |
        Это улучшенная версия сортировки вставками. Этот алгоритм сначала сортирует элементы, 
        находящиеся на определенном расстоянии друг от друга, а затем уменьшает это расстояние и снова выполняет сортировку. 
        Процесс повторяется, пока расстояние не станет равным 1, и происходит финальная сортировка вставками.
        | Шаги работы |
        1. Начинаем с определенного интервала (расстояния) между элементами массива (например, половина длины массива).
        2. Сравниваем элементы, находящиеся на данном расстоянии друг от друга, и меняем их местами, если это необходимо.
        3. Уменьшаем расстояние и повторяем процесс, пока расстояние не станет равным 1.
        4. После завершения сортировки с интервалом 1, выполняем окончательную сортировку вставками.
        | СЛОЖНОСТЬ |
        Лучший случай: O(n log^2 n)
        Средний случай: зависит от выбранных шагов
        Худший случай: O(n^2)
        */

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //BINARYTREE
        //ОПИСАНИЕ---

        /*BinaryTree tree = new BinaryTree();

        // Добавляем элементы в дерево
        tree.Insert(50);
        tree.Insert(30);
        tree.Insert(20);
        tree.Insert(40);
        tree.Insert(70);
        tree.Insert(60);
        tree.Insert(80);

        // Выводим отсортированные элементы дерева
        Console.WriteLine("Отсортированные элементы дерева:");
        tree.InOrderTraversal();*/


        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //RADIXSORT
        //ОПИСАНИЕ---

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //STACK
        //ОПИСАНИЕ---
        //PrintStack.Print();

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //QUEUE
        //ОПИСАНИЕ---
        //QueuePrint.Print();

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //DFSGraph
        //ОПИСАНИЕ---
        /*DFSGraph g = new DFSGraph(6);
        g.AddEdge(1, 2);
        g.AddEdge(1, 3);
        g.AddEdge(3, 4);
        g.AddEdge(4, 5);
        g.AddEdge(2, 1);
        g.AddEdge(4, 3);
        g.AddEdge(5, 3);
        g.AddEdge(3, 1);

        Console.WriteLine("Обход графа в глубину (DFS) начиная с вершины 1:");
        g.DFS(1);*/

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //BFSGraph
        //ОПИСАНИЕ---
        /*BFSGraph g = new BFSGraph(6);
        g.AddEdge(1, 2);
        g.AddEdge(1, 3);
        g.AddEdge(3, 4);
        g.AddEdge(4, 5);
        g.AddEdge(2, 1);
        g.AddEdge(4, 3);
        g.AddEdge(5, 3);
        g.AddEdge(3, 1);


        Console.WriteLine("Обход графа в ширину (BFS) начиная с вершины 1:");
        g.BFS(1);*/

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //KruskalAlgorithm
        //ОПИСАНИЕ---

        /*int V = 5;  // Количество вершин в графе
          

        KruskalAlgorithm graph = new KruskalAlgorithm(V);

        // Добавляем рёбра в граф
        graph.AddEdge(0, 1, 10);
        graph.AddEdge(0, 2, 6);
        graph.AddEdge(0, 3, 5);
        graph.AddEdge(1, 3, 15);
        graph.AddEdge(2, 3, 4);

        // Находим и выводим минимальное остовное дерево
        graph.KruskalMST();
        Console.WriteLine("----------------------------------");*/
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //PrimAlgorithm
        //ОПИСАНИЕ---
        /*PrimAlgorithm prim = new PrimAlgorithm(5);
        prim.AddEdge(0, 1, 2);
        prim.AddEdge(0, 3, 6);
        prim.AddEdge(1, 2, 3);
        prim.AddEdge(1, 3, 8);
        prim.AddEdge(1, 4, 5);
        prim.AddEdge(2, 4, 7);
        prim.AddEdge(3, 4, 9);

        prim.PrimMST();*/

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //HashTableChains
        //Opisanie---
        /*HashTableWithChaining<int, string> hashtable = new HashTableWithChaining<int, string>(5);

        // Добавляем элементы
        hashtable.Add(1, "Value1");
        hashtable.Add(2, "Value2");
        hashtable.Add(3, "Value3");
        hashtable.Add(4, "Value4");

        // Выводим содержимое хэш-таблицы
        Console.WriteLine("Contents of the hash table after additions:");
        hashtable.Print();
        Console.WriteLine();

        // Попытка получения значения по ключу
        if (hashtable.TryGetValue(2, out string value))
        {
            Console.WriteLine($"Value for key 2: {value}");
        }
        else
        {
            Console.WriteLine("Key 2 not found in the hashtable.");
        }
        Console.WriteLine();

        // Удаляем элемент из хэш-таблицы
        hashtable.Remove(3);

        // Выводим содержимое хэш-таблицы после удаления
        Console.WriteLine("Contents of the hash table after removal:");
        hashtable.Print();*/

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        int V = 5; // Количество вершин в графе
        DijkstraAlgorithm graph = new DijkstraAlgorithm(V);

        // Добавление ребер с их весами
        graph.AddEdge(0, 1, 4);
        graph.AddEdge(0, 2, 1);
        graph.AddEdge(1, 2, 2);
        graph.AddEdge(1, 3, 5);
        graph.AddEdge(2, 3, 2);
        graph.AddEdge(3, 4, 3);

        // Поиск кратчайшего пути из вершины 0
        graph.DijkstraShortestPath(0);

         //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /*HashTableOpen hashtable = new HashTableOpen(10);

        // Добавление элементов
        hashtable.Add(1, "One");
        hashtable.Add(2, "Two");
        hashtable.Add(11, "Eleven");
        hashtable.Add(11, "gavno");
        hashtable.Add(111, "Banana");

        hashtable.Print();

        // Получение элементов
        Console.WriteLine(hashtable.Get(1)); // Выведет "One"
        Console.WriteLine(hashtable.Get(2)); // Выведет "Two"
        Console.WriteLine(hashtable.Get(11)); // Выведет "Eleven"

        // Удаление элемента
        hashtable.Remove(2);
        Console.WriteLine(hashtable.Get(2)); // Выведет null

        hashtable.Print();
        // Получение размера
        Console.WriteLine(hashtable.Size());*/
    }
}
