using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using курсовая_ппNET;

namespace курсовая_ппNET
{
    public class Classifier
    {
        private курсовая_ппNET.Tree_Node root;

        public Classifier(курсовая_ппNET.Tree_Node root)
        {
            this.root = root;
        }

        public Result Classify(double[] feature)
        {
            курсовая_ппNET.Tree_Node currentNode = root;
            while (currentNode.LeftChild != null && currentNode.RightChild != null)
            {
                if (feature[currentNode.FeatureIndex] <= currentNode.Threshold)
                {
                    currentNode = currentNode.LeftChild;
                }
                else
                {
                    currentNode = currentNode.RightChild;
                }
            }

            // Пример определения класса: наиболее часто встречающийся класс в листе
            return new Result { Class = currentNode.Label, Confidence = 1.0 };
        }
    }
}


//namespace курсовая_ппNET
//{
//    public class Classifier
//    {
//        private курсовая_ппNET.Tree_Node root;

//        public Classifier(курсовая_ппNET.Tree_Node root)
//        {
//            this.root = root;
//        }

//        public Result Classify(double[] feature)
//        {
//            курсовая_ппNET.Tree_Node currentNode = root;
//            while (currentNode.LeftChild != null && currentNode.RightChild != null)
//            {
//                if (feature[currentNode.FeatureIndex] <= currentNode.Threshold)
//                {
//                    currentNode = currentNode.LeftChild;
//                }
//                else
//                {
//                    currentNode = currentNode.RightChild;
//                }
//            }

//            // Пример определения класса: наиболее часто встречающийся класс в листе
//            return new Result { Class = currentNode.Label, Confidence = 1.0 };
//        }
//    }
//}
