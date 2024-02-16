using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgExam
{
    public class StackNode
    {
        public int Data { get; set; }
        public StackNode Prev { get; set; }
        public StackNode Next { get; set; }

        public StackNode(int data)
        {
            Data = data;
            Prev = null;
            Next = null;
        }
    }
}
