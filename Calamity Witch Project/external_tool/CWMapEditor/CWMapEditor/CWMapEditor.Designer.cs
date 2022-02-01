namespace CWMapEditor
{
    partial class CWMapEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleLabel = new System.Windows.Forms.Label();
            this.loadBlankButton = new System.Windows.Forms.Button();
            this.loadDefaultButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(207, 101);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(395, 37);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Calamity Witch Map Editor";
            // 
            // loadBlankButton
            // 
            this.loadBlankButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadBlankButton.Location = new System.Drawing.Point(104, 168);
            this.loadBlankButton.Name = "loadBlankButton";
            this.loadBlankButton.Size = new System.Drawing.Size(215, 38);
            this.loadBlankButton.TabIndex = 1;
            this.loadBlankButton.Text = "Load Blank Map";
            this.loadBlankButton.UseVisualStyleBackColor = true;
            this.loadBlankButton.Click += new System.EventHandler(this.loadBlankButton_Click);
            // 
            // loadDefaultButton
            // 
            this.loadDefaultButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadDefaultButton.Location = new System.Drawing.Point(473, 168);
            this.loadDefaultButton.Name = "loadDefaultButton";
            this.loadDefaultButton.Size = new System.Drawing.Size(215, 38);
            this.loadDefaultButton.TabIndex = 2;
            this.loadDefaultButton.Text = "Load Default Map";
            this.loadDefaultButton.UseVisualStyleBackColor = true;
            this.loadDefaultButton.Click += new System.EventHandler(this.loadDefaultButton_Click);
            // 
            // CWMapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.loadDefaultButton);
            this.Controls.Add(this.loadBlankButton);
            this.Controls.Add(this.titleLabel);
            this.Name = "CWMapEditor";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.CWMapEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button loadBlankButton;
        private System.Windows.Forms.Button loadDefaultButton;
    }
}

