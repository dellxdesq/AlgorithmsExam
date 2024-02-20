using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgExam
{
    public class BFSGraph
    {
        private int V; // Количество вершин
        private List<int>[] adj; // Список смежности

        public BFSGraph(int vertices)
        {
            V = vertices;
            adj = new List<int>[V];
            for (int i = 0; i < V; ++i)
            {
                adj[i] = new List<int>();
            }
        }

        // Метод для добавления ребра в граф
        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
        }

        // Метод для обхода графа в ширину
        public void BFS(int s)
        {
            bool[] visited = new bool[V]; // Массив для отметки посещенных вершин

            Queue<int> queue = new Queue<int>(); // Очередь для обхода вершин

            visited[s] = true; // Отмечаем начальную вершину как посещенную
            queue.Enqueue(s); // Добавляем начальную вершину в очередь

            while (queue.Count != 0)
            {
                s = queue.Dequeue(); // Извлекаем вершину из очереди
                Console.Write(s + " ");

                foreach (var v in adj[s])
                {
                    if (!visited[v]) // Если вершина еще не посещена
                    {
                        visited[v] = true; // Отмечаем ее как посещенную
                        queue.Enqueue(v); // Добавляем в очередь для дальнейшего обхода
                    }
                }
            }
        }
    }
}
