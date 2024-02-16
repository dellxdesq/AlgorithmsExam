using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgExam
{
    public class Queue
    {
        private StackNode front;
        private StackNode rear;

        public void Enqueue(int data)
        {
            StackNode newNode = new StackNode(data);
            if (rear == null)
            {
                front = newNode;
                rear = newNode;
            }
            else
            {
                rear.Next = newNode;
                newNode.Prev = rear;
                rear = newNode;
            }
        }

        public int Dequeue()
        {
            if (front == null)
            {
                Console.WriteLine("Queue is empty");
                return -1; // or throw an exception
            }
            int data = front.Data;
            front = front.Next;
            if (front != null)
            {
                front.Prev = null;
            }
            else
            {
                rear = null;
            }
            return data;
        }

        public int Peek()
        {
            if (front == null)
            {
                Console.WriteLine("Queue is empty");
                return -1; // or throw an exception
            }
            return front.Data;
        }

        public bool IsEmpty()
        {
            return front == null;
        }

        public void PrintQueue()
        {
            StackNode current = front;
            while (current != null)
            {
                Console.Write(current.Data + " -> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }
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
