using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgExam
{
    public class HashTableOpen
{
    private int[] keys; // Массив ключей
    private string[] values; // Массив значений
    private int capacity; // Емкость хэш-таблицы
    private int size; // Текущий размер хэш-таблицы

    public HashTableOpen(int capacity)
    {
        this.capacity = capacity; // Присваиваем переданную емкость
        keys = new int[capacity]; // Инициализируем массив ключей заданной емкостью
        values = new string[capacity]; // Инициализируем массив значений заданной емкостью
        size = 0; // Начальный размер равен 0
    }

    // Хэш-функция для метода открытой адресации
    private int Hash(int key, int attempt)
    {
        return (key + attempt) % capacity; // Вычисляем индекс ячейки по ключу и попытке
    }

    // Метод для добавления элемента в хэш-таблицу
    public void Add(int key, string value)
    {
        if (size == capacity) // Проверяем, заполнена ли хэш-таблица
        {
            Console.WriteLine("Хэш-таблица заполнена!"); // Выводим сообщение и выходим из метода
            return;
        }

        int attempt = 0; // Начальная попытка
        int index = Hash(key, attempt); // Получаем начальный индекс для данного ключа
        while (keys[index] != 0) // Пока не найдена пустая ячейка
        {
            attempt++; // Увеличиваем попытку
            index = Hash(key, attempt); // Получаем новый индекс
        }

        keys[index] = key; // Записываем ключ
        values[index] = value; // Записываем значение
        size++; // Увеличиваем размер
    }

    // Метод для получения значения по ключу
    public string Get(int key)
    {
        int attempt = 0; // Начальная попытка
        int index = Hash(key, attempt); // Получаем начальный индекс для данного ключа
        while (keys[index] != 0) // Пока не найдена пустая ячейка
        {
            if (keys[index] == key) // Если найден ключ
                return values[index]; // Возвращаем соответствующее значение
            attempt++; // Увеличиваем попытку
            index = Hash(key, attempt); // Получаем новый индекс
        }
        return null; // Если ключ не найден, возвращаем null
    }

    // Метод для удаления элемента по ключу
    public void Remove(int key)
    {
        int attempt = 0; // Начальная попытка
        int index = Hash(key, attempt); // Получаем начальный индекс для данного ключа
        while (keys[index] != 0) // Пока не найдена пустая ячейка
        {
            if (keys[index] == key) // Если найден ключ
            {
                keys[index] = 0; // Удаляем ключ
                values[index] = null; // Удаляем значение
                size--; // Уменьшаем размер
                return; // Выходим из метода
            }
            attempt++; // Увеличиваем попытку
            index = Hash(key, attempt); // Получаем новый индекс
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
        for (int i = 0; i < capacity; i++) // Проходим по всем ячейкам
        {
            if (keys[i] != 0) // Если ячейка не пуста
            {
                Console.WriteLine($"Key: {keys[i]}, Value: {values[i]}"); // Выводим ключ и значение
            }
        }
    }
}
}
