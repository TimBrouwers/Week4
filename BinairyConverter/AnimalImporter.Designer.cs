namespace AnimalShelterImporter
{
    partial class AnimalInfoReader
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
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.lbCats = new System.Windows.Forms.ListBox();
            this.lbDogs = new System.Windows.Forms.ListBox();
            this.TXTDogs = new System.Windows.Forms.Label();
            this.TXTCats = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(12, 12);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "Open File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // lbCats
            // 
            this.lbCats.FormattingEnabled = true;
            this.lbCats.Location = new System.Drawing.Point(12, 127);
            this.lbCats.Name = "lbCats";
            this.lbCats.Size = new System.Drawing.Size(289, 199);
            this.lbCats.TabIndex = 1;
            // 
            // lbDogs
            // 
            this.lbDogs.FormattingEnabled = true;
            this.lbDogs.Location = new System.Drawing.Point(307, 127);
            this.lbDogs.Name = "lbDogs";
            this.lbDogs.Size = new System.Drawing.Size(268, 199);
            this.lbDogs.TabIndex = 2;
            // 
            // TXTDogs
            // 
            this.TXTDogs.AutoSize = true;
            this.TXTDogs.Location = new System.Drawing.Point(304, 111);
            this.TXTDogs.Name = "TXTDogs";
            this.TXTDogs.Size = new System.Drawing.Size(35, 13);
            this.TXTDogs.TabIndex = 3;
            this.TXTDogs.Text = "Dogs:";
            // 
            // TXTCats
            // 
            this.TXTCats.AutoSize = true;
            this.TXTCats.Location = new System.Drawing.Point(12, 111);
            this.TXTCats.Name = "TXTCats";
            this.TXTCats.Size = new System.Drawing.Size(31, 13);
            this.TXTCats.TabIndex = 4;
            this.TXTCats.Text = "Cats:";
            // 
            // AnimalInfoReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 338);
            this.Controls.Add(this.TXTCats);
            this.Controls.Add(this.TXTDogs);
            this.Controls.Add(this.lbDogs);
            this.Controls.Add(this.lbCats);
            this.Controls.Add(this.btnOpenFile);
            this.Name = "AnimalInfoReader";
            this.Text = "Animal info reader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.ListBox lbCats;
        private System.Windows.Forms.ListBox lbDogs;
        private System.Windows.Forms.Label TXTDogs;
        private System.Windows.Forms.Label TXTCats;
    }
}

