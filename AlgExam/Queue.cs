using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgExam;
    public class Queue
{
    private StackNode front; // Указатель на начало очереди
    private StackNode rear; // Указатель на конец очереди

    // Метод для добавления элемента в очередь
    public void Enqueue(int data)
    {
        StackNode newNode = new StackNode(data); // Создаем новый узел с переданными данными
        if (rear == null) // Если очередь пуста
        {
            front = newNode; // Устанавливаем начало и конец очереди на новый узел
            rear = newNode;
        }
        else
        {
            rear.Next = newNode; // Устанавливаем ссылку на новый узел в конец очереди
            newNode.Prev = rear; // Устанавливаем ссылку на предыдущий узел для нового узла
            rear = newNode; // Перемещаем указатель конца очереди на новый узел
        }
    }

    // Метод для удаления и возврата элемента из начала очереди
    public int Dequeue()
    {
        if (front == null) // Если очередь пуста
        {
            Console.WriteLine("Queue is empty"); // Выводим сообщение об ошибке
            return -1; // Возвращаем -1 или выбрасываем исключение
        }
        int data = front.Data; // Получаем данные первого элемента очереди
        front = front.Next; // Обновляем указатель начала очереди, убирая первый элемент
        if (front != null)
        {
            front.Prev = null; // Если новое начало очереди существует, убираем ссылку на предыдущий элемент
        }
        else
        {
            rear = null; // Если после удаления первого элемента очереди очередь пуста, обнуляем указатель на конец
        }
        return data; // Возвращаем данные удаленного элемента
    }

    // Метод для получения значения первого элемента без удаления
    public int Peek()
    {
        if (front == null) // Если очередь пуста
        {
            Console.WriteLine("Queue is empty"); // Выводим сообщение об ошибке
            return -1; // Возвращаем -1 или выбрасываем исключение
        }
        return front.Data; // Возвращаем данные первого элемента очереди
    }

    // Метод для проверки, пуста ли очередь
    public bool IsEmpty()
    {
        return front == null; // Возвращаем true, если начало очереди равно null
    }

    // Метод для вывода содержимого очереди
    public void PrintQueue()
    {
        StackNode current = front; // Устанавливаем текущий узел на начало очереди
        while (current != null) // Пока не достигнут конец очереди
        {
            Console.Write(current.Data + " -> "); // Выводим данные текущего узла
            current = current.Next; // Переходим к следующему узлу
        }
        Console.WriteLine("null"); // Выводим null, чтобы показать конец очереди
    }

    public class QueuePrint
    {
        public static void Print()
        {
            Queue queue = new Queue();

            Console.WriteLine("Is queue empty? " + queue.IsEmpty());

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Console.WriteLine("Queue:");
            queue.PrintQueue();

            Console.WriteLine("Peek front of queue: " + queue.Peek());

            Console.WriteLine("Dequeue: " + queue.Dequeue());

            Console.WriteLine("Queue after dequeuing:");
            queue.PrintQueue();
        }
    }
}
