
namespace IntyGenWinUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.lblAppInfo = new System.Windows.Forms.Label();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnVerify = new System.Windows.Forms.Button();
            this.btnMultiHash = new System.Windows.Forms.Button();
            this.btnSingleHash = new System.Windows.Forms.Button();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlMenu.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlMenu.Controls.Add(this.lblAppInfo);
            this.pnlMenu.Controls.Add(this.btnAbout);
            this.pnlMenu.Controls.Add(this.btnHelp);
            this.pnlMenu.Controls.Add(this.btnVerify);
            this.pnlMenu.Controls.Add(this.btnMultiHash);
            this.pnlMenu.Controls.Add(this.btnSingleHash);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(200, 601);
            this.pnlMenu.TabIndex = 0;
            // 
            // lblAppInfo
            // 
            this.lblAppInfo.AutoSize = true;
            this.lblAppInfo.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblAppInfo.Location = new System.Drawing.Point(12, 577);
            this.lblAppInfo.Name = "lblAppInfo";
            this.lblAppInfo.Size = new System.Drawing.Size(55, 15);
            this.lblAppInfo.TabIndex = 1;
            this.lblAppInfo.Text = "App-Info";
            // 
            // btnAbout
            // 
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Location = new System.Drawing.Point(0, 237);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            this.btnAbout.Size = new System.Drawing.Size(200, 37);
            this.btnAbout.TabIndex = 0;
            this.btnAbout.Text = "About";
            this.btnAbout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Location = new System.Drawing.Point(0, 194);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            this.btnHelp.Size = new System.Drawing.Size(200, 37);
            this.btnHelp.TabIndex = 0;
            this.btnHelp.Text = "Help";
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnVerify
            // 
            this.btnVerify.FlatAppearance.BorderSize = 0;
            this.btnVerify.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnVerify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerify.Location = new System.Drawing.Point(0, 151);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            this.btnVerify.Size = new System.Drawing.Size(200, 37);
            this.btnVerify.TabIndex = 0;
            this.btnVerify.Text = "Verify File Integrity";
            this.btnVerify.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // btnMultiHash
            // 
            this.btnMultiHash.FlatAppearance.BorderSize = 0;
            this.btnMultiHash.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnMultiHash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMultiHash.Location = new System.Drawing.Point(0, 108);
            this.btnMultiHash.Name = "btnMultiHash";
            this.btnMultiHash.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            this.btnMultiHash.Size = new System.Drawing.Size(200, 37);
            this.btnMultiHash.TabIndex = 0;
            this.btnMultiHash.Text = "Multiple File Hashes";
            this.btnMultiHash.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMultiHash.UseVisualStyleBackColor = true;
            this.btnMultiHash.Click += new System.EventHandler(this.btnMultiHash_Click);
            // 
            // btnSingleHash
            // 
            this.btnSingleHash.FlatAppearance.BorderSize = 0;
            this.btnSingleHash.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnSingleHash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSingleHash.Location = new System.Drawing.Point(0, 65);
            this.btnSingleHash.Name = "btnSingleHash";
            this.btnSingleHash.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            this.btnSingleHash.Size = new System.Drawing.Size(200, 37);
            this.btnSingleHash.TabIndex = 0;
            this.btnSingleHash.Text = "Single File Hash";
            this.btnSingleHash.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSingleHash.UseVisualStyleBackColor = true;
            this.btnSingleHash.Click += new System.EventHandler(this.btnSingleHash_Click);
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.SystemColors.Control;
            this.pnlTitle.Controls.Add(this.label2);
            this.pnlTitle.Controls.Add(this.label1);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(200, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(744, 64);
            this.pnlTitle.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "File Hash Processor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "IntyGen®";
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(200, 64);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(744, 537);
            this.pnlContent.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 601);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.pnlMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IntyGen - Hash";
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnSingleHash;
        private System.Windows.Forms.Button btnMultiHash;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Label lblAppInfo;
        private System.Windows.Forms.Button btnAbout;
    }
}

