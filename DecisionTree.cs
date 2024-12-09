using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace курсовая_ппNET
{
    public class DecisionTree
    {
        private Tree_Node root;

        public void BuildTree(DataSet dataSet)
        {
            root = BuildTreeRecursive(dataSet.Features, dataSet.Labels);
        }

        private Tree_Node BuildTreeRecursive(List<double[]> features, List<int> labels)
        {
            // Условие выхода из рекурсии: если нет данных, возвращаем null
            if (features.Count == 0) return null;

            // Условие выхода из рекурсии: если все метки одинаковы, возвращаем лист
            if (AreAllLabelsSame(labels))
            {
                return new Tree_Node { Label = labels[0] };
            }

            // Условие выхода из рекурсии: если размер узла меньше минимально допустимого, возвращаем лист с наиболее частым классом
            if (features.Count < 10) // Пример минимального размера узла
            {
                return new Tree_Node { Label = MostFrequentLabel(labels) };
            }

            int bestFeatureIndex;
            double bestThreshold;
            (bestFeatureIndex, bestThreshold) = ChooseBestFeatureAndThreshold(features, labels);

            List<double[]> leftFeatures = new List<double[]>();
            List<int> leftLabels = new List<int>();
            List<double[]> rightFeatures = new List<double[]>();
            List<int> rightLabels = new List<int>();

            for (int i = 0; i < features.Count; i++)
            {
                if (features[i][bestFeatureIndex] <= bestThreshold)
                {
                    leftFeatures.Add(features[i]);
                    leftLabels.Add(labels[i]);
                }
                else
                {
                    rightFeatures.Add(features[i]);
                    rightLabels.Add(labels[i]);
                }
            }

            Tree_Node node = new Tree_Node
            {
                FeatureIndex = bestFeatureIndex,
                Threshold = bestThreshold,
                LeftChild = BuildTreeRecursive(leftFeatures, leftLabels),
                RightChild = BuildTreeRecursive(rightFeatures, rightLabels)
            };

            return node;
        }

        private bool AreAllLabelsSame(List<int> labels)
        {
            if (labels.Count == 0) return true;
            int firstLabel = labels[0];
            foreach (int label in labels)
            {
                if (label != firstLabel) return false;
            }
            return true;
        }

        private int MostFrequentLabel(List<int> labels)
        {
            Dictionary<int, int> labelCounts = new Dictionary<int, int>();
            foreach (int label in labels)
            {
                if (labelCounts.ContainsKey(label))
                {
                    labelCounts[label]++;
                }
                else
                {
                    labelCounts[label] = 1;
                }
            }

            int mostFrequentLabel = labels[0];
            int maxCount = 0;
            foreach (var kvp in labelCounts)
            {
                if (kvp.Value > maxCount)
                {
                    mostFrequentLabel = kvp.Key;
                    maxCount = kvp.Value;
                }
            }

            return mostFrequentLabel;
        }

        private (int, double) ChooseBestFeatureAndThreshold(List<double[]> features, List<int> labels)
        {
            int bestFeatureIndex = 0;
            double bestThreshold = 0;
            double bestImpurity = double.MaxValue;

            for (int featureIndex = 0; featureIndex < features[0].Length; featureIndex++)
            {
                for (int i = 0; i < features.Count; i++)
                {
                    double threshold = features[i][featureIndex];
                    List<int> leftLabels = new List<int>();
                    List<int> rightLabels = new List<int>();

                    for (int j = 0; j < features.Count; j++)
                    {
                        if (features[j][featureIndex] <= threshold)
                        {
                            leftLabels.Add(labels[j]);
                        }
                        else
                        {
                            rightLabels.Add(labels[j]);
                        }
                    }

                    double impurity = CalculateGiniImpurity(leftLabels) * leftLabels.Count + CalculateGiniImpurity(rightLabels) * rightLabels.Count;
                    impurity /= features.Count;

                    if (impurity < bestImpurity)
                    {
                        bestImpurity = impurity;
                        bestFeatureIndex = featureIndex;
                        bestThreshold = threshold;
                    }
                }
            }

            return (bestFeatureIndex, bestThreshold);
        }

        private double CalculateGiniImpurity(List<int> labels)
        {
            if (labels.Count == 0) return 0;

            Dictionary<int, int> labelCounts = new Dictionary<int, int>();
            foreach (int label in labels)
            {
                if (labelCounts.ContainsKey(label))
                {
                    labelCounts[label]++;
                }
                else
                {
                    labelCounts[label] = 1;
                }
            }

            double impurity = 1;
            foreach (var kvp in labelCounts)
            {
                double probability = (double)kvp.Value / labels.Count;
                impurity -= probability * probability;
            }

            return impurity;
        }

        public Tree_Node GetRoot()
        {
            return root;
        }
    }
}




//namespace курсовая_ппNET
//{
//    public class DecisionTree
//    {
//        private Tree_Node root;

//        public void BuildTree(DataSet dataSet)
//        {
//            root = BuildTreeRecursive(dataSet.Features, dataSet.Labels);
//        }

//        private Tree_Node BuildTreeRecursive(List<double[]> features, List<int> labels)
//        {
//            // Условие выхода из рекурсии: если нет данных, возвращаем null
//            if (features.Count == 0) return null;

//            // Условие выхода из рекурсии: если все метки одинаковы, возвращаем лист
//            if (AreAllLabelsSame(labels))
//            {
//                return new Tree_Node { Label = labels[0] };
//            }

//            int bestFeatureIndex = ChooseFeature(features, labels);
//            double bestThreshold = ChooseThreshold(features, labels, bestFeatureIndex);

//            List<double[]> leftFeatures = new List<double[]>();
//            List<int> leftLabels = new List<int>();
//            List<double[]> rightFeatures = new List<double[]>();
//            List<int> rightLabels = new List<int>();

//            for (int i = 0; i < features.Count; i++)
//            {
//                if (features[i][bestFeatureIndex] <= bestThreshold)
//                {
//                    leftFeatures.Add(features[i]);
//                    leftLabels.Add(labels[i]);
//                }
//                else
//                {
//                    rightFeatures.Add(features[i]);
//                    rightLabels.Add(labels[i]);
//                }
//            }

//            Tree_Node node = new Tree_Node
//            {
//                FeatureIndex = bestFeatureIndex,
//                Threshold = bestThreshold,
//                LeftChild = BuildTreeRecursive(leftFeatures, leftLabels),
//                RightChild = BuildTreeRecursive(rightFeatures, rightLabels)
//            };

//            return node;
//        }

//        private bool AreAllLabelsSame(List<int> labels)
//        {
//            if (labels.Count == 0) return true;
//            int firstLabel = labels[0];
//            foreach (int label in labels)
//            {
//                if (label != firstLabel) return false;
//            }
//            return true;
//        }

//        private int ChooseFeature(List<double[]> features, List<int> labels)
//        {
//            // Пример выбора признака: случайный выбор
//            Random random = new Random();
//            return random.Next(features[0].Length);
//        }

//        private double ChooseThreshold(List<double[]> features, List<int> labels, int featureIndex)
//        {
//            // Пример выбора порога: среднее значение признака
//            double sum = 0;
//            foreach (var feature in features)
//            {
//                sum += feature[featureIndex];
//            }
//            return sum / features.Count;
//        }

//        public Tree_Node GetRoot()
//        {
//            return root;
//        }
//    }
//}