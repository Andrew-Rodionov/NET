using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсовая_ппNET
{
    public class Tree_Node
    {
        public int FeatureIndex { get; set; }
        public double Threshold { get; set; }
        public Tree_Node LeftChild { get; set; }
        public Tree_Node RightChild { get; set; }
        public int Label { get; set; } // Добавляем свойство для хранения метки класса в листе
    }
}
