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
            for (int i = 0; i < V; i++)
            {
                adj[i] = new List<int>();
            }
        }

        public void AddEdge(int v, int w)
        {
            adj[v].Add(w); // Добавляем вершину w в список смежности вершины v
        }

        public void DFS(int startVertex)
        {
            bool[] visited = new bool[V]; // Массив для отслеживания посещенных вершин

            Stack<int> stack = new Stack<int>(); // Создаем стек для выполнения DFS

            visited[startVertex] = true; // Помечаем начальную вершину как посещенную
            stack.Push(startVertex); // Добавляем начальную вершину в стек

            Console.WriteLine("обход начинается с вершины " + startVertex + ":");

            while (stack.Count != 0)
            {
                int currentVertex = stack.Pop(); // Извлекаем текущую вершину из стека
                Console.Write(currentVertex + " "); // Выводим текущую вершину

                // Перебираем все смежные вершины текущей вершины
                foreach (int adjacentVertex in adj[currentVertex])
                {
                    if (!visited[adjacentVertex]) // Если смежная вершина еще не посещена
                    {
                        visited[adjacentVertex] = true; // Помечаем ее как посещенную
                        stack.Push(adjacentVertex); // Добавляем в стек для последующей обработки
                    }
                }
            }
            Console.WriteLine();
        }
    }
}