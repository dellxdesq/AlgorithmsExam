using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgExam
{
    public class BinaryTree
    {
        private Node root;

        public BinaryTree()
        {
            root = null;
        }

        public void Insert(int value)
        {
            root = InsertRec(root, value);
        }

        private Node InsertRec(Node root, int value)
        {
            if (root == null)
            {
                root = new Node(value);
                return root;
            }

            if (value < root.Value)
            {
                root.Left = InsertRec(root.Left, value);
            }
            else if (value > root.Value)
            {
                root.Right = InsertRec(root.Right, value);
            }

            return root;
        }

        public void InOrderTraversal()
        {
            InOrderTraversalRec(root);
        }

        private void InOrderTraversalRec(Node root)
        {
            if (root != null)
            {
                InOrderTraversalRec(root.Left);
                Console.Write(root.Value + " ");
                InOrderTraversalRec(root.Right);
            }
        }
    }
}
