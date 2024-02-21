using System;
using System.Collections.Generic;

public class PrimAlgorithm
{
    private int V;
    private List<List<(int vertex, int weight)>> graph; // Изменили тип данных на кортеж (вершина, вес)

    public PrimAlgorithm(int v)
    {
        V = v;
        graph = new List<List<(int vertex, int weight)>>(V);
        for (int i = 0; i < V; i++)
            graph.Add(new List<(int vertex, int weight)>());
    }

    public void AddEdge(int src, int dest, int weight)
    {
        graph[src].Add((dest, weight)); // Добавляем вес ребра и конечную вершину в список смежности начальной вершины
        graph[dest].Add((src, weight)); // Добавляем вес ребра и начальную вершину в список смежности конечной вершины
    }

    public void PrimMST()
    {
        bool[] mstSet = new bool[V];
        int[] parent = new int[V];
        int[] key = new int[V];

        for (int i = 0; i < V; i++)
        {
            key[i] = int.MaxValue;
            mstSet[i] = false;
        }

        key[0] = 0;
        parent[0] = -1;

        for (int count = 0; count < V - 1; count++)
        {
            int u = MinKey(key, mstSet);
            mstSet[u] = true;

            foreach (var edge in graph[u])
            {
                int v = edge.vertex;
                int weight = edge.weight;
                if (!mstSet[v] && weight < key[v])
                {
                    parent[v] = u;
                    key[v] = weight;
                }
            }
        }

        Console.WriteLine("Edge \tWeight");
        for (int i = 1; i < V; i++)
            Console.WriteLine($"{parent[i]} - {i}\t{key[i]}");
    }

    private int MinKey(int[] key, bool[] mstSet)
    {
        int min = int.MaxValue;
        int minIndex = -1;

        for (int v = 0; v < V; v++)
        {
            if (mstSet[v] == false && key[v] < min)
            {
                min = key[v];
                minIndex = v;
            }
        }

        return minIndex;
    }
}


