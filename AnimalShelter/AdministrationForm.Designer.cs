﻿namespace AnimalShelter
{
    partial class AdministrationForm
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
            this.animalTypeComboBox = new System.Windows.Forms.ComboBox();
            this.createAnimalButton = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbChipregistrationNr = new System.Windows.Forms.TextBox();
            this.dtpBirthdate = new System.Windows.Forms.DateTimePicker();
            this.TXTName = new System.Windows.Forms.Label();
            this.TXTChipnr = new System.Windows.Forms.Label();
            this.TXTBirthdate = new System.Windows.Forms.Label();
            this.rbIsReservedYes = new System.Windows.Forms.RadioButton();
            this.GBIsReserved = new System.Windows.Forms.GroupBox();
            this.rbIsReservedNo = new System.Windows.Forms.RadioButton();
            this.TXTIsReserved = new System.Windows.Forms.Label();
            this.TXTBadhabits = new System.Windows.Forms.Label();
            this.tbBadhabits = new System.Windows.Forms.TextBox();
            this.TXTLastWalk = new System.Windows.Forms.Label();
            this.dtpLastwalk = new System.Windows.Forms.DateTimePicker();
            this.TXTAnimals = new System.Windows.Forms.Label();
            this.btnRemovefromList = new System.Windows.Forms.Button();
            this.btnChangeToReserved = new System.Windows.Forms.Button();
            this.tbSearchWithChipnumber = new System.Windows.Forms.TextBox();
            this.TXTSearch = new System.Windows.Forms.Label();
            this.lbReserved = new System.Windows.Forms.ListBox();
            this.lbNotReserved = new System.Windows.Forms.ListBox();
            this.btnChangeToNotReserved = new System.Windows.Forms.Button();
            this.lbFound = new System.Windows.Forms.ListBox();
            this.GBIsReserved.SuspendLayout();
            this.SuspendLayout();
            // 
            // animalTypeComboBox
            // 
            this.animalTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.animalTypeComboBox.FormattingEnabled = true;
            this.animalTypeComboBox.Items.AddRange(new object[] {
            "Cat",
            "Dog"});
            this.animalTypeComboBox.Location = new System.Drawing.Point(12, 12);
            this.animalTypeComboBox.Name = "animalTypeComboBox";
            this.animalTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.animalTypeComboBox.TabIndex = 0;
            this.animalTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.animalTypeComboBox_SelectedIndexChanged);
            // 
            // createAnimalButton
            // 
            this.createAnimalButton.Location = new System.Drawing.Point(139, 10);
            this.createAnimalButton.Name = "createAnimalButton";
            this.createAnimalButton.Size = new System.Drawing.Size(64, 23);
            this.createAnimalButton.TabIndex = 1;
            this.createAnimalButton.Text = "Create";
            this.createAnimalButton.UseVisualStyleBackColor = true;
            this.createAnimalButton.Click += new System.EventHandler(this.createAnimalButton_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(84, 39);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(200, 20);
            this.tbName.TabIndex = 3;
            // 
            // tbChipregistrationNr
            // 
            this.tbChipregistrationNr.Location = new System.Drawing.Point(84, 66);
            this.tbChipregistrationNr.Name = "tbChipregistrationNr";
            this.tbChipregistrationNr.Size = new System.Drawing.Size(200, 20);
            this.tbChipregistrationNr.TabIndex = 4;
            // 
            // dtpBirthdate
            // 
            this.dtpBirthdate.Location = new System.Drawing.Point(84, 92);
            this.dtpBirthdate.Name = "dtpBirthdate";
            this.dtpBirthdate.Size = new System.Drawing.Size(200, 20);
            this.dtpBirthdate.TabIndex = 5;
            // 
            // TXTName
            // 
            this.TXTName.AutoSize = true;
            this.TXTName.Location = new System.Drawing.Point(13, 39);
            this.TXTName.Name = "TXTName";
            this.TXTName.Size = new System.Drawing.Size(35, 13);
            this.TXTName.TabIndex = 6;
            this.TXTName.Text = "Name";
            // 
            // TXTChipnr
            // 
            this.TXTChipnr.AutoSize = true;
            this.TXTChipnr.Location = new System.Drawing.Point(13, 66);
            this.TXTChipnr.Name = "TXTChipnr";
            this.TXTChipnr.Size = new System.Drawing.Size(63, 13);
            this.TXTChipnr.TabIndex = 6;
            this.TXTChipnr.Text = "Chipnumber";
            // 
            // TXTBirthdate
            // 
            this.TXTBirthdate.AutoSize = true;
            this.TXTBirthdate.Location = new System.Drawing.Point(13, 98);
            this.TXTBirthdate.Name = "TXTBirthdate";
            this.TXTBirthdate.Size = new System.Drawing.Size(49, 13);
            this.TXTBirthdate.TabIndex = 6;
            this.TXTBirthdate.Text = "Birthdate";
            // 
            // rbIsReservedYes
            // 
            this.rbIsReservedYes.AutoSize = true;
            this.rbIsReservedYes.Location = new System.Drawing.Point(6, 19);
            this.rbIsReservedYes.Name = "rbIsReservedYes";
            this.rbIsReservedYes.Size = new System.Drawing.Size(43, 17);
            this.rbIsReservedYes.TabIndex = 7;
            this.rbIsReservedYes.Text = "Yes";
            this.rbIsReservedYes.UseVisualStyleBackColor = true;
            // 
            // GBIsReserved
            // 
            this.GBIsReserved.Controls.Add(this.rbIsReservedNo);
            this.GBIsReserved.Controls.Add(this.rbIsReservedYes);
            this.GBIsReserved.Location = new System.Drawing.Point(84, 118);
            this.GBIsReserved.Name = "GBIsReserved";
            this.GBIsReserved.Size = new System.Drawing.Size(200, 49);
            this.GBIsReserved.TabIndex = 8;
            this.GBIsReserved.TabStop = false;
            // 
            // rbIsReservedNo
            // 
            this.rbIsReservedNo.AutoSize = true;
            this.rbIsReservedNo.Checked = true;
            this.rbIsReservedNo.Location = new System.Drawing.Point(79, 20);
            this.rbIsReservedNo.Name = "rbIsReservedNo";
            this.rbIsReservedNo.Size = new System.Drawing.Size(39, 17);
            this.rbIsReservedNo.TabIndex = 8;
            this.rbIsReservedNo.TabStop = true;
            this.rbIsReservedNo.Text = "No";
            this.rbIsReservedNo.UseVisualStyleBackColor = true;
            // 
            // TXTIsReserved
            // 
            this.TXTIsReserved.AutoSize = true;
            this.TXTIsReserved.Location = new System.Drawing.Point(12, 137);
            this.TXTIsReserved.Name = "TXTIsReserved";
            this.TXTIsReserved.Size = new System.Drawing.Size(61, 13);
            this.TXTIsReserved.TabIndex = 9;
            this.TXTIsReserved.Text = "IsReserved";
            // 
            // TXTBadhabits
            // 
            this.TXTBadhabits.AutoSize = true;
            this.TXTBadhabits.Location = new System.Drawing.Point(13, 180);
            this.TXTBadhabits.Name = "TXTBadhabits";
            this.TXTBadhabits.Size = new System.Drawing.Size(54, 13);
            this.TXTBadhabits.TabIndex = 10;
            this.TXTBadhabits.Text = "Badhabits";
            // 
            // tbBadhabits
            // 
            this.tbBadhabits.Location = new System.Drawing.Point(84, 180);
            this.tbBadhabits.Name = "tbBadhabits";
            this.tbBadhabits.Size = new System.Drawing.Size(200, 20);
            this.tbBadhabits.TabIndex = 11;
            // 
            // TXTLastWalk
            // 
            this.TXTLastWalk.AutoSize = true;
            this.TXTLastWalk.Location = new System.Drawing.Point(13, 180);
            this.TXTLastWalk.Name = "TXTLastWalk";
            this.TXTLastWalk.Size = new System.Drawing.Size(49, 13);
            this.TXTLastWalk.TabIndex = 12;
            this.TXTLastWalk.Text = "Lastwalk";
            // 
            // dtpLastwalk
            // 
            this.dtpLastwalk.Location = new System.Drawing.Point(84, 180);
            this.dtpLastwalk.Name = "dtpLastwalk";
            this.dtpLastwalk.Size = new System.Drawing.Size(200, 20);
            this.dtpLastwalk.TabIndex = 13;
            // 
            // TXTAnimals
            // 
            this.TXTAnimals.AutoSize = true;
            this.TXTAnimals.Location = new System.Drawing.Point(291, 20);
            this.TXTAnimals.Name = "TXTAnimals";
            this.TXTAnimals.Size = new System.Drawing.Size(46, 13);
            this.TXTAnimals.TabIndex = 16;
            this.TXTAnimals.Text = "Animals:";
            // 
            // btnRemovefromList
            // 
            this.btnRemovefromList.Location = new System.Drawing.Point(369, 296);
            this.btnRemovefromList.Name = "btnRemovefromList";
            this.btnRemovefromList.Size = new System.Drawing.Size(166, 23);
            this.btnRemovefromList.TabIndex = 19;
            this.btnRemovefromList.Text = "Remove";
            this.btnRemovefromList.UseVisualStyleBackColor = true;
            this.btnRemovefromList.Click += new System.EventHandler(this.btnRemovefromList_Click);
            // 
            // btnChangeToReserved
            // 
            this.btnChangeToReserved.Location = new System.Drawing.Point(601, 109);
            this.btnChangeToReserved.Name = "btnChangeToReserved";
            this.btnChangeToReserved.Size = new System.Drawing.Size(86, 23);
            this.btnChangeToReserved.TabIndex = 20;
            this.btnChangeToReserved.Text = "<=";
            this.btnChangeToReserved.UseVisualStyleBackColor = true;
            this.btnChangeToReserved.Click += new System.EventHandler(this.btnChangeToReserved_Click);
            // 
            // tbSearchWithChipnumber
            // 
            this.tbSearchWithChipnumber.Location = new System.Drawing.Point(12, 266);
            this.tbSearchWithChipnumber.Name = "tbSearchWithChipnumber";
            this.tbSearchWithChipnumber.Size = new System.Drawing.Size(178, 20);
            this.tbSearchWithChipnumber.TabIndex = 22;
            this.tbSearchWithChipnumber.TextChanged += new System.EventHandler(this.tbSearchWithChipnumber_TextChanged);
            // 
            // TXTSearch
            // 
            this.TXTSearch.AutoSize = true;
            this.TXTSearch.Location = new System.Drawing.Point(15, 247);
            this.TXTSearch.Name = "TXTSearch";
            this.TXTSearch.Size = new System.Drawing.Size(109, 13);
            this.TXTSearch.TabIndex = 23;
            this.TXTSearch.Text = "Search: (Chipnumber)";
            // 
            // lbReserved
            // 
            this.lbReserved.FormattingEnabled = true;
            this.lbReserved.Location = new System.Drawing.Point(294, 39);
            this.lbReserved.Name = "lbReserved";
            this.lbReserved.Size = new System.Drawing.Size(301, 251);
            this.lbReserved.TabIndex = 25;
            this.lbReserved.SelectedIndexChanged += new System.EventHandler(this.lbReserved_SelectedIndexChanged);
            // 
            // lbNotReserved
            // 
            this.lbNotReserved.FormattingEnabled = true;
            this.lbNotReserved.Location = new System.Drawing.Point(693, 39);
            this.lbNotReserved.Name = "lbNotReserved";
            this.lbNotReserved.Size = new System.Drawing.Size(264, 251);
            this.lbNotReserved.TabIndex = 26;
            this.lbNotReserved.SelectedIndexChanged += new System.EventHandler(this.lbNotReserved_SelectedIndexChanged);
            // 
            // btnChangeToNotReserved
            // 
            this.btnChangeToNotReserved.Location = new System.Drawing.Point(601, 138);
            this.btnChangeToNotReserved.Name = "btnChangeToNotReserved";
            this.btnChangeToNotReserved.Size = new System.Drawing.Size(86, 23);
            this.btnChangeToNotReserved.TabIndex = 27;
            this.btnChangeToNotReserved.Text = "=>";
            this.btnChangeToNotReserved.UseVisualStyleBackColor = true;
            this.btnChangeToNotReserved.Click += new System.EventHandler(this.btnChangeToNotReserved_Click);
            // 
            // lbFound
            // 
            this.lbFound.FormattingEnabled = true;
            this.lbFound.Location = new System.Drawing.Point(12, 310);
            this.lbFound.Name = "lbFound";
            this.lbFound.Size = new System.Drawing.Size(242, 186);
            this.lbFound.TabIndex = 28;
            // 
            // AdministrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 516);
            this.Controls.Add(this.lbFound);
            this.Controls.Add(this.btnChangeToNotReserved);
            this.Controls.Add(this.lbNotReserved);
            this.Controls.Add(this.lbReserved);
            this.Controls.Add(this.TXTSearch);
            this.Controls.Add(this.tbSearchWithChipnumber);
            this.Controls.Add(this.btnChangeToReserved);
            this.Controls.Add(this.btnRemovefromList);
            this.Controls.Add(this.TXTAnimals);
            this.Controls.Add(this.dtpLastwalk);
            this.Controls.Add(this.TXTLastWalk);
            this.Controls.Add(this.tbBadhabits);
            this.Controls.Add(this.TXTBadhabits);
            this.Controls.Add(this.TXTIsReserved);
            this.Controls.Add(this.GBIsReserved);
            this.Controls.Add(this.TXTBirthdate);
            this.Controls.Add(this.TXTChipnr);
            this.Controls.Add(this.TXTName);
            this.Controls.Add(this.dtpBirthdate);
            this.Controls.Add(this.tbChipregistrationNr);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.createAnimalButton);
            this.Controls.Add(this.animalTypeComboBox);
            this.Name = "AdministrationForm";
            this.Text = "Form1";
            this.GBIsReserved.ResumeLayout(false);
            this.GBIsReserved.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox animalTypeComboBox;
        private System.Windows.Forms.Button createAnimalButton;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbChipregistrationNr;
        private System.Windows.Forms.DateTimePicker dtpBirthdate;
        private System.Windows.Forms.Label TXTName;
        private System.Windows.Forms.Label TXTChipnr;
        private System.Windows.Forms.Label TXTBirthdate;
        private System.Windows.Forms.RadioButton rbIsReservedYes;
        private System.Windows.Forms.GroupBox GBIsReserved;
        private System.Windows.Forms.RadioButton rbIsReservedNo;
        private System.Windows.Forms.Label TXTIsReserved;
        private System.Windows.Forms.Label TXTBadhabits;
        private System.Windows.Forms.TextBox tbBadhabits;
        private System.Windows.Forms.Label TXTLastWalk;
        private System.Windows.Forms.DateTimePicker dtpLastwalk;
        private System.Windows.Forms.Label TXTAnimals;
        private System.Windows.Forms.Button btnRemovefromList;
        private System.Windows.Forms.Button btnChangeToReserved;
        private System.Windows.Forms.TextBox tbSearchWithChipnumber;
        private System.Windows.Forms.Label TXTSearch;
        private System.Windows.Forms.ListBox lbReserved;
        private System.Windows.Forms.ListBox lbNotReserved;
        private System.Windows.Forms.Button btnChangeToNotReserved;
        private System.Windows.Forms.ListBox lbFound;
    }
}

