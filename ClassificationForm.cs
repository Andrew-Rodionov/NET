using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace курсовая_ппNET
{
    public partial class ClassificationForm : Form
    {
        private курсовая_ппNET.Tree_Node root;

        public ClassificationForm(курсовая_ппNET.Tree_Node root)
        {
            InitializeComponent();
            this.root = root;
        }

        private void btnClassify_Click(object sender, EventArgs e)
        {
            double[] feature = new double[3];
            if (!double.TryParse(txtFeature1.Text, out feature[0]) ||
                !double.TryParse(txtFeature2.Text, out feature[1]) ||
                !double.TryParse(txtFeature3.Text, out feature[2]))
            {
                MessageBox.Show("Пожалуйста, введите корректные значения признаков.");
                return;
            }

            Classifier classifier = new Classifier(root);
            Result result = classifier.Classify(feature);

            MessageBox.Show($"Предсказанный класс: {result.Class}, Уверенность: {result.Confidence}");
        }
    }
}


//namespace курсовая_ппNET
//{
//    public partial class ClassificationForm : Form
//    {
//        private курсовая_ппNET.Tree_Node root;

//        public ClassificationForm(курсовая_ппNET.Tree_Node root)
//        {
//            InitializeComponent();
//            this.root = root;
//        }

//        private void btnClassify_Click(object sender, EventArgs e)
//        {
//            double[] feature = new double[3];
//            if (!double.TryParse(txtFeature1.Text, out feature[0]) ||
//                !double.TryParse(txtFeature2.Text, out feature[1]) ||
//                !double.TryParse(txtFeature3.Text, out feature[2]))
//            {
//                MessageBox.Show("Пожалуйста, введите корректные значения признаков.");
//                return;
//            }

//            Classifier classifier = new Classifier(root);
//            Result result = classifier.Classify(feature);

//            MessageBox.Show($"Предсказанный класс: {result.Class}, Уверенность: {result.Confidence}");
//        }
//    }
//}
