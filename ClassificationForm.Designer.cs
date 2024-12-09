namespace курсовая_ппNET
{
    partial class ClassificationForm
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
            this.txtFeature1 = new System.Windows.Forms.TextBox();
            this.txtFeature2 = new System.Windows.Forms.TextBox();
            this.txtFeature3 = new System.Windows.Forms.TextBox();
            this.btnClassify = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFeature1
            // 
            this.txtFeature1.Location = new System.Drawing.Point(12, 12);
            this.txtFeature1.Name = "txtFeature1";
            this.txtFeature1.Size = new System.Drawing.Size(100, 20);
            this.txtFeature1.TabIndex = 0;
            // 
            // txtFeature2
            // 
            this.txtFeature2.Location = new System.Drawing.Point(12, 38);
            this.txtFeature2.Name = "txtFeature2";
            this.txtFeature2.Size = new System.Drawing.Size(100, 20);
            this.txtFeature2.TabIndex = 1;
            // 
            // txtFeature3
            // 
            this.txtFeature3.Location = new System.Drawing.Point(12, 64);
            this.txtFeature3.Name = "txtFeature3";
            this.txtFeature3.Size = new System.Drawing.Size(100, 20);
            this.txtFeature3.TabIndex = 2;
            // 
            // btnClassify
            // 
            this.btnClassify.Location = new System.Drawing.Point(12, 90);
            this.btnClassify.Name = "btnClassify";
            this.btnClassify.Size = new System.Drawing.Size(100, 30);
            this.btnClassify.TabIndex = 3;
            this.btnClassify.Text = "Классифицировать";
            this.btnClassify.UseVisualStyleBackColor = true;
            this.btnClassify.Click += new System.EventHandler(this.btnClassify_Click);
            // 
            // ClassificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnClassify);
            this.Controls.Add(this.txtFeature3);
            this.Controls.Add(this.txtFeature2);
            this.Controls.Add(this.txtFeature1);
            this.Name = "ClassificationForm";
            this.Text = "Классификация";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtFeature1;
        private System.Windows.Forms.TextBox txtFeature2;
        private System.Windows.Forms.TextBox txtFeature3;
        private System.Windows.Forms.Button btnClassify;
    }
}