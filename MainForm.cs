using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using курсовая_ппNET;

namespace курсовая_ппNET
{
    public partial class MainForm : Form
    {
        private DataSet dataSet;
        private DecisionTree decisionTree;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                DataLoader dataLoader = new DataLoader();
                try
                {
                    dataSet = dataLoader.LoadData(openFileDialog.FileName);
                    dataLoader.PreprocessData(dataSet);
                    MessageBox.Show("Данные загружены и предобработаны успешно!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
                }
            }
        }

        private void btnBuildTree_Click(object sender, EventArgs e)
        {
            if (dataSet == null)
            {
                MessageBox.Show("Пожалуйста, загрузите данные сначала!");
                return;
            }

            decisionTree = new DecisionTree();
            decisionTree.BuildTree(dataSet);
            MessageBox.Show("Дерево решений построено успешно!");

            // Отображаем дерево решений
            treeView.Nodes.Clear();
            treeView.Nodes.Add(BuildTreeView(decisionTree.GetRoot()));
        }

        private TreeNode BuildTreeView(курсовая_ппNET.Tree_Node node)
        {
            if (node == null) return null;

            TreeNode treeNode = new TreeNode();
            if (node.LeftChild == null && node.RightChild == null)
            {
                treeNode.Text = $"Класс: {node.Label}";
            }
            else
            {
                treeNode.Text = $"Признак: {node.FeatureIndex}, Порог: {node.Threshold}";
                if (node.LeftChild != null)
                {
                    treeNode.Nodes.Add(BuildTreeView(node.LeftChild));
                }
                if (node.RightChild != null)
                {
                    treeNode.Nodes.Add(BuildTreeView(node.RightChild));
                }
            }

            return treeNode;
        }

        private void btnClassify_Click(object sender, EventArgs e)
        {
            if (decisionTree == null)
            {
                MessageBox.Show("Пожалуйста, постройте дерево решений сначала!");
                return;
            }

            ClassificationForm classificationForm = new ClassificationForm(decisionTree.GetRoot());
            classificationForm.ShowDialog();
        }
    }
}


//namespace курсовая_ппNET
//{
//    public partial class MainForm : Form
//    {
//        private DataSet dataSet;
//        private DecisionTree decisionTree;

//        public MainForm()
//        {
//            InitializeComponent();
//        }

//        private void btnLoadData_Click(object sender, EventArgs e)
//        {
//            OpenFileDialog openFileDialog = new OpenFileDialog();
//            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
//            if (openFileDialog.ShowDialog() == DialogResult.OK)
//            {
//                DataLoader dataLoader = new DataLoader();
//                try
//                {
//                    dataSet = dataLoader.LoadData(openFileDialog.FileName);
//                    dataLoader.PreprocessData(dataSet);
//                    MessageBox.Show("Данные загружены и предобработаны успешно!");
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
//                }
//            }
//        }

//        private void btnBuildTree_Click(object sender, EventArgs e)
//        {
//            if (dataSet == null)
//            {
//                MessageBox.Show("Пожалуйста, загрузите данные сначала!");
//                return;
//            }

//            decisionTree = new DecisionTree();
//            decisionTree.BuildTree(dataSet);
//            MessageBox.Show("Дерево решений построено успешно!");

//            // Отображаем дерево решений
//            treeView.Nodes.Clear();
//            treeView.Nodes.Add(BuildTreeView(decisionTree.GetRoot()));
//        }

//        private TreeNode BuildTreeView(курсовая_ппNET.Tree_Node node)
//        {
//            if (node == null) return null;

//            TreeNode treeNode = new TreeNode();
//            if (node.LeftChild == null && node.RightChild == null)
//            {
//                treeNode.Text = $"Класс: {node.Label}";
//            }
//            else
//            {
//                treeNode.Text = $"Признак: {node.FeatureIndex}, Порог: {node.Threshold}";
//                if (node.LeftChild != null)
//                {
//                    treeNode.Nodes.Add(BuildTreeView(node.LeftChild));
//                }
//                if (node.RightChild != null)
//                {
//                    treeNode.Nodes.Add(BuildTreeView(node.RightChild));
//                }
//            }

//            return treeNode;
//        }

//        private void btnClassify_Click(object sender, EventArgs e)
//        {
//            if (decisionTree == null)
//            {
//                MessageBox.Show("Пожалуйста, постройте дерево решений сначала!");
//                return;
//            }

//            ClassificationForm classificationForm = new ClassificationForm(decisionTree.GetRoot());
//            classificationForm.ShowDialog();
//        }
//    }
//}
