using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgExam
{
    public class KruskalAlgorithm
    {
        // Класс, представляющий ребро графа
        public class Edge
        {
            public int Source { get; set; } // Начальная вершина ребра
            public int Destination { get; set; } // Конечная вершина ребра
            public int Weight { get; set; } // Вес ребра
        }

        private int V; // Количество вершин в графе
        private List<Edge> edges; // Список рёбер графа

        public KruskalAlgorithm(int v)
        {
            V = v; // Инициализация количества вершин
            edges = new List<Edge>(); // Инициализация списка рёбер
        }

        // Метод для добавления ребра в список рёбер графа
        public void AddEdge(int src, int dest, int weight)
        {
            edges.Add(new Edge { Source = src, Destination = dest, Weight = weight });
        }

        // Метод для поиска минимального остовного дерева алгоритмом Крускала
        public void KruskalMST()
        {
            // Сортировка рёбер по весу
            edges = edges.OrderBy(edge => edge.Weight).ToList();

            // Создание массива для хранения корней подмножеств
            var parent = Enumerable.Range(0, V).ToArray();

            // Функция для нахождения корня подмножества, к которому принадлежит вершина i
            int Find(int i) => parent[i] == i ? i : (parent[i] = Find(parent[i]));

            // Проход по всем рёбрам и добавление их в остовное дерево, если они не образуют цикл
            foreach (var edge in edges)
            {
                int x = Find(edge.Source); // Находим корень вершины-источника ребра
                int y = Find(edge.Destination); // Находим корень вершины-приёмника ребра
                if (x != y) // Если вершины принадлежат разным подмножествам, то добавляем ребро в остовное дерево
                {
                    Console.WriteLine($"{edge.Source} -- {edge.Destination} == {edge.Weight}");
                    parent[x] = y; // Объединяем подмножества вершин
                }
            }
        }
    }
}
