using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgExam
{
    public class HashTableOpen
    {
        private int[] keys;
        private string[] values;
        private int capacity;
        private int size;

        public HashTableOpen(int capacity)
        {
            this.capacity = capacity;
            keys = new int[capacity];
            values = new string[capacity];
            size = 0;
        }

        private int Hash(int key, int attempt)
        {
            return (key + attempt) % capacity; // Хэш-функция для метода открытой адресации
        }

        public void Add(int key, string value)
        {
            if (size == capacity)
            {
                Console.WriteLine("Хэш-таблица заполнена!");
                return;
            }

            int attempt = 0;
            int index = Hash(key, attempt);
            while (keys[index] != 0)
            {
                attempt++;
                index = Hash(key, attempt);
            }

            keys[index] = key;
            values[index] = value;
            size++;
        }

        public string Get(int key)
        {
            int attempt = 0;
            int index = Hash(key, attempt);
            while (keys[index] != 0)
            {
                if (keys[index] == key)
                    return values[index];
                attempt++;
                index = Hash(key, attempt);
            }
            return null; // Элемент не найден
        }

        public void Remove(int key)
        {
            int attempt = 0;
            int index = Hash(key, attempt);
            while (keys[index] != 0)
            {
                if (keys[index] == key)
                {
                    keys[index] = 0;
                    values[index] = null;
                    size--;
                    return;
                }
                attempt++;
                index = Hash(key, attempt);
            }
        }

        public int Size()
        {
            return size;
        }

        public void Print()
        {
            for (int i = 0; i < capacity; i++)
            {
                if (keys[i] != 0)
                {
                    Console.WriteLine($"Key: {keys[i]}, Value: {values[i]}");
                }
            }
        }
    }
}
