﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgExam
{
    public class HashTableWithChaining<TKey, TValue>
    {
        private int size; // Размер хэш-таблицы
        private LinkedList<(TKey key, TValue value)>[] buckets; // Массив связных списков для хранения элементов
        private const int primeMultiplier = 31; // Константа для хэш-функции

        // Конструктор, инициализирующий хэш-таблицу заданного размера
        public HashTableWithChaining(int size)
        {
            this.size = size;
            buckets = new LinkedList<(TKey key, TValue value)>[size]; // Создание массива списков
            for (int i = 0; i < size; i++)
            {
                buckets[i] = new LinkedList<(TKey key, TValue value)>(); // Инициализация каждого списка
            }
        }

        // Метод для вычисления хэша ключа
        private int GetHash(TKey key)
        {
            int hashCode = key.GetHashCode(); // Получаем хэш-код ключа
            int hash = 0;
            unchecked
            {
                hash = hashCode * primeMultiplier; // Умножаем хэш-код на простое число
            }
            return Math.Abs(hash) % size; // Возвращаем индекс корзины
        }

        // Метод для добавления элемента в хэш-таблицу
        public void Add(TKey key, TValue value)
        {
            int index = GetHash(key); // Вычисляем индекс корзины для ключа
            var bucket = buckets[index]; // Получаем список элементов по индексу корзины
            foreach (var pair in bucket)
            {
                if (pair.key.Equals(key)) // Проверяем, если ключ уже существует в корзине
                {
                    throw new ArgumentException($"Key '{key}' already exists in the hashtable.");
                }
            }
            bucket.AddLast((key, value)); // Добавляем элемент в конец списка корзины
        }

        // Метод для удаления элемента из хэш-таблицы
        public bool Remove(TKey key)
        {
            int index = GetHash(key); // Вычисляем индекс корзины для ключа
            var bucket = buckets[index]; // Получаем список элементов по индексу корзины
            foreach (var pair in bucket)
            {
                if (pair.key.Equals(key)) // Проверяем каждый элемент списка на соответствие ключу
                {
                    bucket.Remove(pair); // Удаляем элемент из списка, если ключ найден
                    return true; // Возвращаем true, если удаление прошло успешно
                }
            }
            return false; // Возвращаем false, если ключ не найден
        }

        // Метод для получения значения по ключу
        public bool TryGetValue(TKey key, out TValue value)
        {
            int index = GetHash(key); // Вычисляем индекс корзины для ключа
            var bucket = buckets[index]; // Получаем список элементов по индексу корзины
            foreach (var pair in bucket)
            {
                if (pair.key.Equals(key)) // Проверяем каждый элемент списка на соответствие ключу
                {
                    value = pair.value; // Присваиваем значение элемента переменной value
                    return true; // Возвращаем true, если ключ найден
                }
            }
            value = default(TValue); // Присваиваем переменной value значение по умолчанию, если ключ не найден
            return false; // Возвращаем false, если ключ не найден
        }

        // Метод для вывода содержимого хэш-таблицы
        public void Print()
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Bucket {i}: "); // Выводим номер корзины
                foreach (var pair in buckets[i]) // Перебираем элементы списка корзины
                {
                    Console.Write($"({pair.key}, {pair.value}) -> "); // Выводим ключ и значение элемента
                }
                Console.WriteLine("null"); // Выводим null для пустой корзины
            }
        }

    }
}