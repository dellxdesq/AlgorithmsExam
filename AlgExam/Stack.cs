using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgExam
{
    public class Stack
    {
        private StackNode top;

        public void Push(int data)
        {
            StackNode newNode = new StackNode(data);
            if (top == null)
            {
                top = newNode;
            }
            else
            {
                newNode.Next = top;
                top.Prev = newNode;
                top = newNode;
            }
        }

        public int Pop()
        {
            if (top == null)
            {
                Console.WriteLine("Stack is empty");
                return -1; // or throw an exception
            }
            int data = top.Data;
            top = top.Next;
            if (top != null)
            {
                top.Prev = null;
            }
            return data;
        }

        public int Peek()
        {
            if (top == null)
            {
                Console.WriteLine("Stack is empty");
                return -1; // or throw an exception
            }
            return top.Data;
        }

        public bool IsEmpty()
        {
            return top == null;
        }

        public void PrintStack()
        {
            StackNode current = top;
            while (current != null)
            {
                Console.Write(current.Data + " -> ");
                current = current.Next;
            }
            Console.WriteLine("null");
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
