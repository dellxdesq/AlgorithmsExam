using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgExam
{
    public class DijkstraAlgorithm
    {
        private int V; // Количество вершин в графе
        private List<(int, int)>[] adj; // Список смежности для хранения ребер и их весов

        public DijkstraAlgorithm(int vertices)
        {
            V = vertices;
            adj = new List<(int, int)>[V];
            for (int i = 0; i < V; i++)
            {
                adj[i] = new List<(int, int)>();
            }
        }

        // Добавление ребра в граф
        public void AddEdge(int u, int v, int weight)
        {
            adj[u].Add((v, weight));
            adj[v].Add((u, weight)); // Если граф ориентированный, эту строку можно удалить
        }

        // Поиск кратчайшего пути из вершины source до всех остальных вершин с помощью алгоритма Дейкстры
        public void DijkstraShortestPath(int source)
        {
            // Массив для хранения длин путей
            int[] dist = new int[V];
            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
            }

            // Массив для отметки посещенных вершин
            bool[] visited = new bool[V];

            // Инициализация начальной вершины
            dist[source] = 0;

            // Поиск кратчайшего пути
            for (int count = 0; count < V - 1; count++)
            {
                int u = MinDistance(dist, visited);
                visited[u] = true;

                foreach (var edge in adj[u])
                {
                    int v = edge.Item1;
                    int weight = edge.Item2;
                    if (!visited[v] && dist[u] != int.MaxValue && dist[u] + weight < dist[v])
                    {
                        dist[v] = dist[u] + weight;
                    }
                }
            }

            // Вывод результатов
            PrintSolution(dist);
        }

        // Поиск вершины с минимальным расстоянием
        private int MinDistance(int[] dist, bool[] visited)
        {
            int min = int.MaxValue;
            int minIndex = -1;

            for (int v = 0; v < V; v++)
            {
                if (!visited[v] && dist[v] <= min)
                {
                    min = dist[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        // Вывод результатов
        private void PrintSolution(int[] dist)
        {
            Console.WriteLine("Кратчайшие расстояния от начальной вершины:");
            for (int i = 0; i < V; i++)
            {
                Console.WriteLine($"Вершина {i} -> Расстояние: {dist[i]}");
            }
        }

    }
}
