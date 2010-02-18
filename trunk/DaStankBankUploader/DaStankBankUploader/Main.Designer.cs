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
            this.listFiles = new System.Windows.Forms.CheckedListBox();
            this.lblItems = new System.Windows.Forms.Label();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOutputDir = new System.Windows.Forms.TextBox();
            this.btnChooseOutput = new System.Windows.Forms.Button();
            this.pbarCurFileA = new System.Windows.Forms.ProgressBar();
            this.pbarTotal = new System.Windows.Forms.ProgressBar();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRender = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBGImage = new System.Windows.Forms.TextBox();
            this.btnChooseBG = new System.Windows.Forms.Button();
            this.lblHorizLine = new System.Windows.Forms.Label();
            this.pbarCurFileV = new System.Windows.Forms.ProgressBar();
            this.lblAudio = new System.Windows.Forms.Label();
            this.lblVideo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listFiles
            // 
            this.listFiles.BackColor = System.Drawing.SystemColors.Control;
            this.listFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listFiles.CheckOnClick = true;
            this.listFiles.FormattingEnabled = true;
            this.listFiles.HorizontalScrollbar = true;
            this.listFiles.Location = new System.Drawing.Point(12, 51);
            this.listFiles.Name = "listFiles";
            this.listFiles.Size = new System.Drawing.Size(610, 107);
            this.listFiles.TabIndex = 0;
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
            this.btnAddFile.Location = new System.Drawing.Point(324, 12);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(70, 33);
            this.btnAddFile.TabIndex = 2;
            this.btnAddFile.Text = "+ File(s)";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Location = new System.Drawing.Point(400, 12);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(70, 33);
            this.btnAddFolder.TabIndex = 3;
            this.btnAddFolder.Text = "+ Folder";
            this.btnAddFolder.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Output Directory:";
            // 
            // txtOutputDir
            // 
            this.txtOutputDir.BackColor = System.Drawing.SystemColors.Control;
            this.txtOutputDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutputDir.Location = new System.Drawing.Point(184, 211);
            this.txtOutputDir.Name = "txtOutputDir";
            this.txtOutputDir.Size = new System.Drawing.Size(356, 26);
            this.txtOutputDir.TabIndex = 8;
            // 
            // btnChooseOutput
            // 
            this.btnChooseOutput.Location = new System.Drawing.Point(546, 211);
            this.btnChooseOutput.Name = "btnChooseOutput";
            this.btnChooseOutput.Size = new System.Drawing.Size(75, 26);
            this.btnChooseOutput.TabIndex = 9;
            this.btnChooseOutput.Text = "Choose";
            this.btnChooseOutput.UseVisualStyleBackColor = true;
            this.btnChooseOutput.Click += new System.EventHandler(this.btnChooseOutput_Click);
            // 
            // pbarCurFileA
            // 
            this.pbarCurFileA.Location = new System.Drawing.Point(141, 246);
            this.pbarCurFileA.Name = "pbarCurFileA";
            this.pbarCurFileA.Size = new System.Drawing.Size(399, 15);
            this.pbarCurFileA.TabIndex = 11;
            this.pbarCurFileA.Visible = false;
            // 
            // pbarTotal
            // 
            this.pbarTotal.Location = new System.Drawing.Point(103, 283);
            this.pbarTotal.Name = "pbarTotal";
            this.pbarTotal.Size = new System.Drawing.Size(437, 30);
            this.pbarTotal.TabIndex = 12;
            this.pbarTotal.Visible = false;
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Location = new System.Drawing.Point(12, 252);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(85, 18);
            this.lblCurrent.TabIndex = 13;
            this.lblCurrent.Text = "Current File:";
            this.lblCurrent.Visible = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(55, 290);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(42, 18);
            this.lblTotal.TabIndex = 14;
            this.lblTotal.Text = "Total:";
            this.lblTotal.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(546, 245);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 68);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRender
            // 
            this.btnRender.Location = new System.Drawing.Point(12, 245);
            this.btnRender.Name = "btnRender";
            this.btnRender.Size = new System.Drawing.Size(610, 68);
            this.btnRender.TabIndex = 5;
            this.btnRender.Text = "Render+Upload All In List";
            this.btnRender.UseVisualStyleBackColor = true;
            this.btnRender.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(126, 316);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(385, 18);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Make sure you\'ve finished editing each file before uploading!";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(476, 12);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(70, 33);
            this.btnRemove.TabIndex = 16;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(552, 12);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(70, 33);
            this.btnModify.TabIndex = 17;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Default Background Pic:";
            // 
            // txtBGImage
            // 
            this.txtBGImage.BackColor = System.Drawing.SystemColors.Control;
            this.txtBGImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBGImage.Location = new System.Drawing.Point(184, 166);
            this.txtBGImage.Name = "txtBGImage";
            this.txtBGImage.Size = new System.Drawing.Size(356, 26);
            this.txtBGImage.TabIndex = 8;
            // 
            // btnChooseBG
            // 
            this.btnChooseBG.Location = new System.Drawing.Point(546, 166);
            this.btnChooseBG.Name = "btnChooseBG";
            this.btnChooseBG.Size = new System.Drawing.Size(75, 26);
            this.btnChooseBG.TabIndex = 9;
            this.btnChooseBG.Text = "Choose";
            this.btnChooseBG.UseVisualStyleBackColor = true;
            this.btnChooseBG.Click += new System.EventHandler(this.btnChooseBG_Click);
            // 
            // lblHorizLine
            // 
            this.lblHorizLine.AutoSize = true;
            this.lblHorizLine.Location = new System.Drawing.Point(116, 185);
            this.lblHorizLine.Name = "lblHorizLine";
            this.lblHorizLine.Size = new System.Drawing.Size(400, 18);
            this.lblHorizLine.TabIndex = 18;
            this.lblHorizLine.Text = "________________________________________________________";
            this.lblHorizLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbarCurFileV
            // 
            this.pbarCurFileV.Location = new System.Drawing.Point(141, 262);
            this.pbarCurFileV.Name = "pbarCurFileV";
            this.pbarCurFileV.Size = new System.Drawing.Size(399, 15);
            this.pbarCurFileV.TabIndex = 19;
            this.pbarCurFileV.Visible = false;
            // 
            // lblAudio
            // 
            this.lblAudio.AutoSize = true;
            this.lblAudio.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAudio.Location = new System.Drawing.Point(100, 247);
            this.lblAudio.Name = "lblAudio";
            this.lblAudio.Size = new System.Drawing.Size(39, 14);
            this.lblAudio.TabIndex = 20;
            this.lblAudio.Text = "Audio";
            // 
            // lblVideo
            // 
            this.lblVideo.AutoSize = true;
            this.lblVideo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVideo.Location = new System.Drawing.Point(100, 262);
            this.lblVideo.Name = "lblVideo";
            this.lblVideo.Size = new System.Drawing.Size(39, 14);
            this.lblVideo.TabIndex = 21;
            this.lblVideo.Text = "Video";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 340);
            this.Controls.Add(this.pbarCurFileV);
            this.Controls.Add(this.lblVideo);
            this.Controls.Add(this.pbarCurFileA);
            this.Controls.Add(this.lblAudio);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnChooseBG);
            this.Controls.Add(this.btnChooseOutput);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.pbarTotal);
            this.Controls.Add(this.txtBGImage);
            this.Controls.Add(this.txtOutputDir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRender);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnAddFolder);
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.btnAddFile);
            this.Controls.Add(this.listFiles);
            this.Controls.Add(this.lblHorizLine);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Da Stank Bank Video Uploader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox listFiles;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOutputDir;
        private System.Windows.Forms.Button btnChooseOutput;
        private System.Windows.Forms.ProgressBar pbarCurFileA;
        private System.Windows.Forms.ProgressBar pbarTotal;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRender;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBGImage;
        private System.Windows.Forms.Button btnChooseBG;
        private System.Windows.Forms.Label lblHorizLine;
        private System.Windows.Forms.ProgressBar pbarCurFileV;
        private System.Windows.Forms.Label lblAudio;
        private System.Windows.Forms.Label lblVideo;
    }
}