﻿using System;
using System.Collections.Generic;

public class PrimAlgorithm
{
    private readonly int V; // Объявление переменной V, представляющей количество вершин в графе.
    private readonly List<(int vertex, int weight)>[] graph; // Объявление массива списков, где каждый список содержит пары (вершина, вес), представляющие ребра графа.

    public PrimAlgorithm(int v) // Конструктор класса PrimAlgorithm, принимающий количество вершин графа.
    {
        V = v; // Инициализация переменной V.
        graph = new List<(int vertex, int weight)>[V]; // Инициализация массива графа с количеством вершин V.
        for (int i = 0; i < V; i++) // Цикл инициализации каждого элемента массива графа как пустого списка.
            graph[i] = new List<(int vertex, int weight)>();
    }

    public void AddEdge(int src, int dest, int weight) // Метод для добавления ребра в граф.
    {
        graph[src].Add((dest, weight)); // Добавление ребра из вершины src в вершину dest с заданным весом в список для вершины src.
        graph[dest].Add((src, weight)); // Добавление ребра из вершины dest в вершину src с тем же весом в список для вершины dest.
    }

    public void PrimMST() // Метод для выполнения алгоритма Прима по поиску минимального остовного дерева.
    {
        var mstSet = new bool[V]; // Массив для отслеживания вершин, включенных в остовное дерево.
        var parent = new int[V]; // Массив для хранения родительских вершин каждой вершины в остовном дереве.
        var key = Enumerable.Repeat(int.MaxValue, V).ToArray(); // Массив для хранения минимальных весов ребер, связывающих каждую вершину с остальными.

        key[0] = 0; // Установка ключа для начальной вершины в 0.
        parent[0] = -1; // Установка родительской вершины начальной вершины как -1.

        for (int count = 0; count < V - 1; count++) // Цикл поиска остальных вершин остовного дерева.
        {
            int u = MinKey(key, mstSet); // Находим вершину u с минимальным ключом, которая еще не включена в остовное дерево.
            mstSet[u] = true; // Помечаем вершину u как включенную в остовное дерево.

            foreach (var (v, weight) in graph[u]) // Перебираем соседние вершины для вершины u.
            {
                if (!mstSet[v] && weight < key[v]) // Если вершина v не включена в остовное дерево и вес ребра меньше текущего ключа для v.
                {
                    parent[v] = u; // Устанавливаем родительскую вершину v как u.
                    key[v] = weight; // Устанавливаем ключ для вершины v как вес ребра.
                }
            }
        }

        Console.WriteLine("Edge \tWeight"); // Вывод заголовка таблицы ребер и весов.
        for (int i = 1; i < V; i++) // Цикл вывода ребер остовного дерева и их весов.
            Console.WriteLine($"{parent[i]} - {i}\t{key[i]}"); // Вывод ребра и его веса.
    }

    private int MinKey(int[] key, bool[] mstSet)
    {
        // Инициализация переменных для хранения минимального ключа и его индекса
        int min = int.MaxValue; // Устанавливаем начальное значение минимального ключа на максимально возможное
        int minIndex = -1; // Устанавливаем начальное значение индекса на -1

        // Проходим по всем вершинам графа
        for (int v = 0; v < V; v++)
        {
            // Проверяем, что вершина v еще не включена в остовное дерево и ее ключ меньше текущего минимального ключа
            if (!mstSet[v] && key[v] < min)
            {
                // Если условие выполнено, обновляем минимальный ключ и его индекс
                min = key[v]; // Обновляем минимальный ключ
                minIndex = v; // Обновляем индекс минимального ключа
            }
        }

        // Возвращаем индекс вершины с минимальным ключом
        return minIndex;
    }
}



