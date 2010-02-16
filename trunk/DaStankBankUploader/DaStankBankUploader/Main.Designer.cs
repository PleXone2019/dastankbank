namespace DaStankBankUploader
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.lblItems = new System.Windows.Forms.Label();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOutputDir = new System.Windows.Forms.TextBox();
            this.btnChooseOutput = new System.Windows.Forms.Button();
            this.menuListRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuListRightClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.SystemColors.Control;
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBox1.ContextMenuStrip = this.menuListRightClick;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.HorizontalScrollbar = true;
            this.checkedListBox1.Location = new System.Drawing.Point(12, 51);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(610, 107);
            this.checkedListBox1.TabIndex = 0;
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItems.Location = new System.Drawing.Point(12, 9);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(163, 39);
            this.lblItems.TabIndex = 1;
            this.lblItems.Text = "Music Files";
            // 
            // btnAddFile
            // 
            this.btnAddFile.Location = new System.Drawing.Point(260, 12);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(100, 33);
            this.btnAddFile.TabIndex = 2;
            this.btnAddFile.Text = "Add File";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Location = new System.Drawing.Point(366, 12);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(100, 33);
            this.btnAddFolder.TabIndex = 3;
            this.btnAddFolder.Text = "Add Folder";
            this.btnAddFolder.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(472, 12);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(150, 33);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "Modify Selected";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(610, 33);
            this.button1.TabIndex = 5;
            this.button1.Text = "Render and Upload";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(385, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Make sure you\'ve finished editing each file before uploading!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Choose Output Directory:";
            // 
            // txtOutputDir
            // 
            this.txtOutputDir.BackColor = System.Drawing.SystemColors.Control;
            this.txtOutputDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutputDir.Location = new System.Drawing.Point(184, 162);
            this.txtOutputDir.Name = "txtOutputDir";
            this.txtOutputDir.Size = new System.Drawing.Size(356, 26);
            this.txtOutputDir.TabIndex = 8;
            // 
            // btnChooseOutput
            // 
            this.btnChooseOutput.Location = new System.Drawing.Point(547, 162);
            this.btnChooseOutput.Name = "btnChooseOutput";
            this.btnChooseOutput.Size = new System.Drawing.Size(75, 26);
            this.btnChooseOutput.TabIndex = 9;
            this.btnChooseOutput.Text = "Choose";
            this.btnChooseOutput.UseVisualStyleBackColor = true;
            this.btnChooseOutput.Click += new System.EventHandler(this.btnChooseOutput_Click);
            // 
            // menuListRightClick
            // 
            this.menuListRightClick.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuListRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.deselectAllToolStripMenuItem});
            this.menuListRightClick.Name = "menuListRightClick";
            this.menuListRightClick.Size = new System.Drawing.Size(153, 70);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // deselectAllToolStripMenuItem
            // 
            this.deselectAllToolStripMenuItem.Name = "deselectAllToolStripMenuItem";
            this.deselectAllToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deselectAllToolStripMenuItem.Text = "Unselect All";
            this.deselectAllToolStripMenuItem.Click += new System.EventHandler(this.deselectAllToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 265);
            this.Controls.Add(this.btnChooseOutput);
            this.Controls.Add(this.txtOutputDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAddFolder);
            this.Controls.Add(this.btnAddFile);
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.checkedListBox1);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Da Stank Bank Video Uploader";
            this.menuListRightClick.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOutputDir;
        private System.Windows.Forms.Button btnChooseOutput;
        private System.Windows.Forms.ContextMenuStrip menuListRightClick;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deselectAllToolStripMenuItem;
    }
}