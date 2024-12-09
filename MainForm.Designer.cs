namespace курсовая_ппNET
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnLoadData = new System.Windows.Forms.Button();
            this.btnBuildTree = new System.Windows.Forms.Button();
            this.btnClassify = new System.Windows.Forms.Button();
            this.treeView = new System.Windows.Forms.TreeView(); // Добавляем TreeView
            this.SuspendLayout();
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(12, 12);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(150, 30);
            this.btnLoadData.TabIndex = 0;
            this.btnLoadData.Text = "Загрузить данные";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // btnBuildTree
            // 
            this.btnBuildTree.Location = new System.Drawing.Point(12, 48);
            this.btnBuildTree.Name = "btnBuildTree";
            this.btnBuildTree.Size = new System.Drawing.Size(150, 30);
            this.btnBuildTree.TabIndex = 1;
            this.btnBuildTree.Text = "Построить дерево";
            this.btnBuildTree.UseVisualStyleBackColor = true;
            this.btnBuildTree.Click += new System.EventHandler(this.btnBuildTree_Click);
            // 
            // btnClassify
            // 
            this.btnClassify.Location = new System.Drawing.Point(12, 84);
            this.btnClassify.Name = "btnClassify";
            this.btnClassify.Size = new System.Drawing.Size(150, 30);
            this.btnClassify.TabIndex = 2;
            this.btnClassify.Text = "Классифицировать";
            this.btnClassify.UseVisualStyleBackColor = true;
            this.btnClassify.Click += new System.EventHandler(this.btnClassify_Click);
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(168, 12);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(200, 200);
            this.treeView.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.btnClassify);
            this.Controls.Add(this.btnBuildTree);
            this.Controls.Add(this.btnLoadData);
            this.Name = "MainForm";
            this.Text = "Дерево решений";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Button btnBuildTree;
        private System.Windows.Forms.Button btnClassify;
        private System.Windows.Forms.TreeView treeView; // Добавляем TreeView
    }
}