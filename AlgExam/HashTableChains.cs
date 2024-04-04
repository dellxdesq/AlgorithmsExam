using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgExam
{
    public class HashTableChains
{
    private LinkedList<KeyValuePair<int, string>>[] buckets; // Массив списков (цепочек)
    private int capacity; // Емкость хэш-таблицы
    private int size; // Текущий размер хэш-таблицы

    public HashTableChains(int capacity)
    {
        this.capacity = capacity; // Присваиваем переданную емкость
        buckets = new LinkedList<KeyValuePair<int, string>>[capacity]; // Инициализируем массив списков заданной емкостью
        size = 0; // Начальный размер равен 0
    }

    // Простая хэш-функция для метода цепочек
    private int Hash(int key)
    {
        return key % capacity; // Вычисляем индекс корзины (списка) по ключу
    }

    // Метод для добавления элемента в хэш-таблицу
    public void Add(int key, string value)
    {
        int index = Hash(key); // Получаем индекс корзины для данного ключа
        if (buckets[index] == null) // Если в этой корзине еще нет списка
        {
            buckets[index] = new LinkedList<KeyValuePair<int, string>>(); // Создаем новый список
        }

        foreach (var pair in buckets[index]) // Проверяем, не существует ли уже такой ключ
        {
            if (pair.Key == key)
            {
                Console.WriteLine($"Ключ {key} уже существует в таблице!"); // Выводим сообщение и выходим из метода
                return;
            }
        }

        buckets[index].AddLast(new KeyValuePair<int, string>(key, value)); // Добавляем новую пару ключ-значение в список
        size++; // Увеличиваем размер хэш-таблицы
    }

    // Метод для получения значения по ключу
    public string Get(int key)
    {
        int index = Hash(key); // Получаем индекс корзины для данного ключа
        if (buckets[index] != null) // Если в этой корзине есть список
        {
            foreach (var pair in buckets[index]) // Просматриваем все пары ключ-значение в списке
            {
                if (pair.Key == key) // Если найден ключ
                {
                    return pair.Value; // Возвращаем соответствующее значение
                }
            }
        }
        return null; // Если ключ не найден, возвращаем null
    }

    // Метод для удаления элемента по ключу
    public void Remove(int key)
    {
        int index = Hash(key); // Получаем индекс корзины для данного ключа
        if (buckets[index] != null) // Если в этой корзине есть список
        {
            var node = buckets[index].First; // Получаем первый узел списка
            while (node != null) // Пока не конец списка
            {
                if (node.Value.Key == key) // Если найден ключ
                {
                    buckets[index].Remove(node); // Удаляем узел
                    size--; // Уменьшаем размер хэш-таблицы
                    return; // Выходим из метода
                }
                node = node.Next; // Переходим к следующему узлу
            }
        }
    }

    // Метод для получения текущего размера хэш-таблицы
    public int Size()
    {
        return size; // Возвращаем текущий размер
    }

    // Метод для вывода содержимого хэш-таблицы
    public void Print()
    {
        for (int i = 0; i < capacity; i++) // Проходим по всем корзинам
        {
            if (buckets[i] != null) // Если в текущей корзине есть список
            {
                Console.Write($"Bucket {i}: "); // Выводим номер корзины
                foreach (var pair in buckets[i]) // Просматриваем все пары ключ-значение в списке
                {
                    Console.Write($"({pair.Key}, {pair.Value}) "); // Выводим ключ и значение
                }
                Console.WriteLine(); // Переходим на новую строку
            }
        }
    }
}
}