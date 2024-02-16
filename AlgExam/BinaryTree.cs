using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgExam
{
    public class BinaryTree
    {
        private Node root; // Корневой узел дерева

        // Конструктор класса BinaryTree
        public BinaryTree()
        {
            root = null; // Устанавливаем корневой узел как null при создании дерева
        }

        // Метод для вставки нового значения в дерево
        public void Insert(int value)
        {
            // Вызываем рекурсивный метод для вставки значения
            root = InsertRec(root, value);
        }

        // Рекурсивный метод для вставки значения в дерево
        private Node InsertRec(Node root, int value)
        {
            // Если текущий узел пуст (дошли до листа)
            if (root == null)
            {
                // Создаем новый узел с заданным значением
                root = new Node(value);
                return root; // Возвращаем созданный узел
            }

            // Если значение меньше, чем значение текущего узла
            if (value < root.Value)
            {
                // Рекурсивно вызываем метод для вставки в левое поддерево
                root.Left = InsertRec(root.Left, value);
            }
            // Если значение больше, чем значение текущего узла
            else if (value > root.Value)
            {
                // Рекурсивно вызываем метод для вставки в правое поддерево
                root.Right = InsertRec(root.Right, value);
            }

            return root; // Возвращаем текущий узел
        }

        // Метод для выполнения обхода дерева в порядке "левый узел, корень, правый узел"
        public void InOrderTraversal()
        {
            // Вызываем рекурсивный метод для начала обхода с корневого узла
            InOrderTraversalRec(root);
        }

        // Рекурсивный метод обхода дерева в порядке "левый узел, корень, правый узел"
        private void InOrderTraversalRec(Node root)
        {
            // Если текущий узел не пуст
            if (root != null)
            {
                // Рекурсивно вызываем метод для левого поддерева
                InOrderTraversalRec(root.Left);
                // Выводим значение текущего узла
                Console.Write(root.Value + " ");
                // Рекурсивно вызываем метод для правого поддерева
                InOrderTraversalRec(root.Right);
            }
        }
    }
}
