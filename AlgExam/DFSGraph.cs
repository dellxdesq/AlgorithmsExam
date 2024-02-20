using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgExam
{
    public class DFSGraph
    {
        private int V; // Количество вершин
        private List<int>[] adj; // Список смежности

        public DFSGraph(int vertices)
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

        // Вспомогательный метод для обхода графа в глубину
        private void DFSUtil(int v, bool[] visited)
        {
            visited[v] = true; // Отмечаем текущую вершину как посещенную
            Console.Write(v + " "); // Выводим номер текущей вершины

            // Рекурсивно обходим все смежные вершины
            foreach (var i in adj[v])
            {
                if (!visited[i])
                {
                    DFSUtil(i, visited);
                }
            }
        }

        // Метод для обхода графа в глубину
        public void DFS(int v)
        {
            bool[] visited = new bool[V]; // Массив для отметки посещенных вершин
            DFSUtil(v, visited); // Вызываем вспомогательный метод для обхода графа в глубину
        }
    }
}