using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgExam
{
    public class DijkstraAlgorithm
    {
        private readonly int V;
        private readonly List<(int vertex, int weight)>[] graph;

        public DijkstraAlgorithm(int v)
        {
            V = v;
            graph = new List<(int vertex, int weight)>[V];
            for (int i = 0; i < V; i++)
                graph[i] = new List<(int vertex, int weight)>();
        }

        public void AddEdge(int src, int dest, int weight)
        {
            graph[src].Add((dest, weight));
            graph[dest].Add((src, weight)); // Если граф ориентированный, эту строку можно закомментировать
        }

        public void DijkstraShortestPath(int src)
        {
            int[] dist = new int[V];
            bool[] sptSet = new bool[V];

            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }

            dist[src] = 0;

            for (int count = 0; count < V - 1; count++)
            {
                int u = MinDistance(dist, sptSet);
                sptSet[u] = true;

                foreach (var (v, weight) in graph[u])
                {
                    if (!sptSet[v] && dist[u] != int.MaxValue && dist[u] + weight < dist[v])
                    {
                        dist[v] = dist[u] + weight;
                    }
                }
            }

            PrintSolution(dist);
        }

        private int MinDistance(int[] dist, bool[] sptSet)
        {
            int min = int.MaxValue;
            int minIndex = -1;

            for (int v = 0; v < V; v++)
            {
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        private void PrintSolution(int[] dist)
        {
            Console.WriteLine("Vertex \t\t Distance from Source");
            for (int i = 0; i < V; i++)
            {
                Console.WriteLine($"{i}\t\t{dist[i]}");
            }
        }
    }
}
