namespace CWMapEditor
{
    partial class Map
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Map));
            this.mapBackground = new System.Windows.Forms.PictureBox();
            this.treeSquare = new System.Windows.Forms.PictureBox();
            this.waterSquare = new System.Windows.Forms.PictureBox();
            this.boulderSquare = new System.Windows.Forms.PictureBox();
            this.fireSquare = new System.Windows.Forms.PictureBox();
            this.trunkSquare = new System.Windows.Forms.PictureBox();
            this.treeButton = new System.Windows.Forms.Button();
            this.waterButton = new System.Windows.Forms.Button();
            this.boulderButton = new System.Windows.Forms.Button();
            this.fireButton = new System.Windows.Forms.Button();
            this.trunkButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.clearLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mapBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeSquare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waterSquare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boulderSquare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fireSquare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trunkSquare)).BeginInit();
            this.SuspendLayout();
            // 
            // mapBackground
            // 
            this.mapBackground.Image = ((System.Drawing.Image)(resources.GetObject("mapBackground.Image")));
            this.mapBackground.Location = new System.Drawing.Point(0, 0);
            this.mapBackground.Name = "mapBackground";
            this.mapBackground.Size = new System.Drawing.Size(1280, 960);
            this.mapBackground.TabIndex = 0;
            this.mapBackground.TabStop = false;
            this.mapBackground.Click += new System.EventHandler(this.mapBackground_Click);
            // 
            // treeSquare
            // 
            this.treeSquare.BackColor = System.Drawing.Color.ForestGreen;
            this.treeSquare.Location = new System.Drawing.Point(1408, 26);
            this.treeSquare.Name = "treeSquare";
            this.treeSquare.Size = new System.Drawing.Size(64, 64);
            this.treeSquare.TabIndex = 1;
            this.treeSquare.TabStop = false;
            // 
            // waterSquare
            // 
            this.waterSquare.BackColor = System.Drawing.Color.PaleTurquoise;
            this.waterSquare.Location = new System.Drawing.Point(1408, 139);
            this.waterSquare.Name = "waterSquare";
            this.waterSquare.Size = new System.Drawing.Size(64, 64);
            this.waterSquare.TabIndex = 2;
            this.waterSquare.TabStop = false;
            // 
            // boulderSquare
            // 
            this.boulderSquare.BackColor = System.Drawing.Color.SlateGray;
            this.boulderSquare.Location = new System.Drawing.Point(1408, 265);
            this.boulderSquare.Name = "boulderSquare";
            this.boulderSquare.Size = new System.Drawing.Size(64, 64);
            this.boulderSquare.TabIndex = 3;
            this.boulderSquare.TabStop = false;
            // 
            // fireSquare
            // 
            this.fireSquare.BackColor = System.Drawing.Color.OrangeRed;
            this.fireSquare.Location = new System.Drawing.Point(1408, 384);
            this.fireSquare.Name = "fireSquare";
            this.fireSquare.Size = new System.Drawing.Size(64, 64);
            this.fireSquare.TabIndex = 4;
            this.fireSquare.TabStop = false;
            // 
            // trunkSquare
            // 
            this.trunkSquare.BackColor = System.Drawing.Color.Peru;
            this.trunkSquare.Location = new System.Drawing.Point(1408, 512);
            this.trunkSquare.Name = "trunkSquare";
            this.trunkSquare.Size = new System.Drawing.Size(64, 64);
            this.trunkSquare.TabIndex = 5;
            this.trunkSquare.TabStop = false;
            // 
            // treeButton
            // 
            this.treeButton.Location = new System.Drawing.Point(1311, 26);
            this.treeButton.Name = "treeButton";
            this.treeButton.Size = new System.Drawing.Size(64, 64);
            this.treeButton.TabIndex = 6;
            this.treeButton.UseVisualStyleBackColor = true;
            this.treeButton.Click += new System.EventHandler(this.treeButton_Click);
            // 
            // waterButton
            // 
            this.waterButton.Location = new System.Drawing.Point(1311, 139);
            this.waterButton.Name = "waterButton";
            this.waterButton.Size = new System.Drawing.Size(64, 64);
            this.waterButton.TabIndex = 7;
            this.waterButton.UseVisualStyleBackColor = true;
            this.waterButton.Click += new System.EventHandler(this.waterButton_Click);
            // 
            // boulderButton
            // 
            this.boulderButton.Location = new System.Drawing.Point(1311, 265);
            this.boulderButton.Name = "boulderButton";
            this.boulderButton.Size = new System.Drawing.Size(64, 64);
            this.boulderButton.TabIndex = 8;
            this.boulderButton.UseVisualStyleBackColor = true;
            this.boulderButton.Click += new System.EventHandler(this.boulderButton_Click);
            // 
            // fireButton
            // 
            this.fireButton.Location = new System.Drawing.Point(1311, 384);
            this.fireButton.Name = "fireButton";
            this.fireButton.Size = new System.Drawing.Size(64, 64);
            this.fireButton.TabIndex = 9;
            this.fireButton.UseVisualStyleBackColor = true;
            this.fireButton.Click += new System.EventHandler(this.fireButton_Click);
            // 
            // trunkButton
            // 
            this.trunkButton.Location = new System.Drawing.Point(1311, 512);
            this.trunkButton.Name = "trunkButton";
            this.trunkButton.Size = new System.Drawing.Size(64, 64);
            this.trunkButton.TabIndex = 10;
            this.trunkButton.UseVisualStyleBackColor = true;
            this.trunkButton.Click += new System.EventHandler(this.TrunkButton_Click_1);
            // 
            // exportButton
            // 
            this.exportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportButton.Location = new System.Drawing.Point(1311, 741);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(161, 50);
            this.exportButton.TabIndex = 11;
            this.exportButton.Text = "Export Map!";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(1311, 637);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(64, 64);
            this.clearButton.TabIndex = 12;
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // clearLabel
            // 
            this.clearLabel.AutoSize = true;
            this.clearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearLabel.Location = new System.Drawing.Point(1383, 659);
            this.clearLabel.Name = "clearLabel";
            this.clearLabel.Size = new System.Drawing.Size(89, 18);
            this.clearLabel.TabIndex = 13;
            this.clearLabel.Text = "Clear Space";
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 961);
            this.Controls.Add(this.clearLabel);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.trunkButton);
            this.Controls.Add(this.fireButton);
            this.Controls.Add(this.boulderButton);
            this.Controls.Add(this.waterButton);
            this.Controls.Add(this.treeButton);
            this.Controls.Add(this.trunkSquare);
            this.Controls.Add(this.fireSquare);
            this.Controls.Add(this.boulderSquare);
            this.Controls.Add(this.waterSquare);
            this.Controls.Add(this.treeSquare);
            this.Controls.Add(this.mapBackground);
            this.Name = "Map";
            this.Text = "Map";
            this.Load += new System.EventHandler(this.Map_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mapBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeSquare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waterSquare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boulderSquare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fireSquare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trunkSquare)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.PictureBox mapBackground;
        private System.Windows.Forms.PictureBox treeSquare;
        private System.Windows.Forms.PictureBox waterSquare;
        private System.Windows.Forms.PictureBox boulderSquare;
        private System.Windows.Forms.PictureBox fireSquare;
        private System.Windows.Forms.PictureBox trunkSquare;
        private System.Windows.Forms.Button treeButton;
        private System.Windows.Forms.Button waterButton;
        private System.Windows.Forms.Button boulderButton;
        private System.Windows.Forms.Button fireButton;
        private System.Windows.Forms.Button trunkButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label clearLabel;
    }
}