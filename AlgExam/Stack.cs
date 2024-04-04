using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgExam
{
    public class Stack
    {
        private StackNode top; // Верхушка стека

// Метод для добавления элемента в стек
public void Push(int data)
{
    StackNode newNode = new StackNode(data); // Создаем новый узел с переданными данными
    if (top == null) // Если стек пустой
    {
        top = newNode; // Присваиваем верхушке новый узел
    }
    else
    {
        newNode.Next = top; // Устанавливаем следующий элемент нового узла на текущую верхушку
        top.Prev = newNode; // Устанавливаем предыдущий элемент текущей верхушки на новый узел
        top = newNode; // Обновляем верхушку стека
    }
}

// Метод для удаления и возврата верхнего элемента из стека
public int Pop()
{
    if (top == null) // Если стек пуст
    {
        Console.WriteLine("Stack is empty"); // Выводим сообщение об ошибке
        return -1; // Возвращаем -1 или выбрасываем исключение
    }
    int data = top.Data; // Получаем данные верхнего элемента
    top = top.Next; // Обновляем верхушку, убирая верхний элемент из стека
    if (top != null)
    {
        top.Prev = null; // Если новая верхушка существует, убираем ссылку на предыдущий элемент
    }
    return data; // Возвращаем данные удаленного элемента
}

// Метод для получения значения верхнего элемента без удаления
public int Peek()
{
    if (top == null) // Если стек пуст
    {
        Console.WriteLine("Stack is empty"); // Выводим сообщение об ошибке
        return -1; // Возвращаем -1 или выбрасываем исключение
    }
    return top.Data; // Возвращаем данные верхнего элемента
}

// Метод для проверки, пуст ли стек
public bool IsEmpty()
{
    return top == null; // Возвращаем true, если верхушка стека равна null
}

// Метод для вывода содержимого стека
public void PrintStack()
{
    StackNode current = top; // Устанавливаем текущий узел на верхушку стека
    while (current != null) // Пока не достигнут конец стека
    {
        Console.Write(current.Data + " -> "); // Выводим данные текущего узла
        current = current.Next; // Переходим к следующему узлу
    }
    Console.WriteLine("null"); // Выводим null, чтобы показать конец стека
}
    }
    public class PrintStack
    {
        public static void Print()
        {
            Stack stack = new Stack();

            Console.WriteLine("Is stack empty? " + stack.IsEmpty());

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine("Stack:");
            stack.PrintStack();

            Console.WriteLine("Peek top of stack: " + stack.Peek());

            Console.WriteLine("Pop: " + stack.Pop());

            Console.WriteLine("Stack after popping:");
            stack.PrintStack();
        }
    }
}
