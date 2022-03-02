
namespace IntyGenWinUI.UILayouts
{
    partial class SingleHashUILayout
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtOpen = new System.Windows.Forms.Button();
            this.cmbHashType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkEnableSeperator = new IntyGenWinUI.CustomControls.Toggle();
            this.lblSeperatorPreview = new System.Windows.Forms.Label();
            this.lblValidationMessage = new System.Windows.Forms.Label();
            this.pnlResult = new System.Windows.Forms.Panel();
            this.btnCopyHash = new System.Windows.Forms.Button();
            this.txtHashResult = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(36, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Generate Hash for a Single File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(304, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "You can generate the hash signature for the selected file.\r\nOpen a file from your" +
    " local file system to start.";
            // 
            // txtPath
            // 
            this.txtPath.Cursor = System.Windows.Forms.Cursors.No;
            this.txtPath.Location = new System.Drawing.Point(163, 106);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(318, 23);
            this.txtPath.TabIndex = 8;
            // 
            // txtOpen
            // 
            this.txtOpen.Location = new System.Drawing.Point(487, 106);
            this.txtOpen.Name = "txtOpen";
            this.txtOpen.Size = new System.Drawing.Size(75, 23);
            this.txtOpen.TabIndex = 2;
            this.txtOpen.Text = "Open...";
            this.txtOpen.UseVisualStyleBackColor = true;
            this.txtOpen.Click += new System.EventHandler(this.txtOpen_Click);
            // 
            // cmbHashType
            // 
            this.cmbHashType.FormattingEnabled = true;
            this.cmbHashType.Location = new System.Drawing.Point(36, 106);
            this.cmbHashType.Name = "cmbHashType";
            this.cmbHashType.Size = new System.Drawing.Size(121, 23);
            this.cmbHashType.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hash Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(163, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "File Path";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Enable dash seperator";
            // 
            // chkEnableSeperator
            // 
            this.chkEnableSeperator.AutoSize = true;
            this.chkEnableSeperator.Location = new System.Drawing.Point(198, 159);
            this.chkEnableSeperator.MinimumSize = new System.Drawing.Size(45, 22);
            this.chkEnableSeperator.Name = "chkEnableSeperator";
            this.chkEnableSeperator.OffBackColor = System.Drawing.Color.DarkGray;
            this.chkEnableSeperator.OffToggleColor = System.Drawing.Color.WhiteSmoke;
            this.chkEnableSeperator.OnBackColor = System.Drawing.Color.DodgerBlue;
            this.chkEnableSeperator.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.chkEnableSeperator.Size = new System.Drawing.Size(45, 22);
            this.chkEnableSeperator.TabIndex = 3;
            this.chkEnableSeperator.UseVisualStyleBackColor = true;
            this.chkEnableSeperator.CheckedChanged += new System.EventHandler(this.chkEnableSeperator_CheckedChanged);
            // 
            // lblSeperatorPreview
            // 
            this.lblSeperatorPreview.AutoSize = true;
            this.lblSeperatorPreview.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSeperatorPreview.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblSeperatorPreview.Location = new System.Drawing.Point(249, 164);
            this.lblSeperatorPreview.Name = "lblSeperatorPreview";
            this.lblSeperatorPreview.Size = new System.Drawing.Size(83, 12);
            this.lblSeperatorPreview.TabIndex = 7;
            this.lblSeperatorPreview.Text = "Seperator-Preview";
            // 
            // lblValidationMessage
            // 
            this.lblValidationMessage.AutoSize = true;
            this.lblValidationMessage.ForeColor = System.Drawing.Color.Red;
            this.lblValidationMessage.Location = new System.Drawing.Point(163, 132);
            this.lblValidationMessage.Name = "lblValidationMessage";
            this.lblValidationMessage.Size = new System.Drawing.Size(108, 15);
            this.lblValidationMessage.TabIndex = 5;
            this.lblValidationMessage.Text = "Validation message";
            // 
            // pnlResult
            // 
            this.pnlResult.Controls.Add(this.btnCopyHash);
            this.pnlResult.Controls.Add(this.txtHashResult);
            this.pnlResult.Controls.Add(this.label6);
            this.pnlResult.Location = new System.Drawing.Point(35, 236);
            this.pnlResult.Name = "pnlResult";
            this.pnlResult.Size = new System.Drawing.Size(533, 124);
            this.pnlResult.TabIndex = 8;
            this.pnlResult.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlResult_Paint);
            // 
            // btnCopyHash
            // 
            this.btnCopyHash.Location = new System.Drawing.Point(415, 32);
            this.btnCopyHash.Name = "btnCopyHash";
            this.btnCopyHash.Size = new System.Drawing.Size(75, 23);
            this.btnCopyHash.TabIndex = 6;
            this.btnCopyHash.Text = "Copy";
            this.btnCopyHash.UseVisualStyleBackColor = true;
            this.btnCopyHash.Click += new System.EventHandler(this.btnCopyHash_Click);
            // 
            // txtHashResult
            // 
            this.txtHashResult.Location = new System.Drawing.Point(22, 32);
            this.txtHashResult.Name = "txtHashResult";
            this.txtHashResult.ReadOnly = true;
            this.txtHashResult.Size = new System.Drawing.Size(387, 23);
            this.txtHashResult.TabIndex = 7;
            this.txtHashResult.TextChanged += new System.EventHandler(this.txtHashResult_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Generated Hash Result";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(35, 195);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnClear
            // 
            this.btnClear.ForeColor = System.Drawing.Color.Red;
            this.btnClear.Location = new System.Drawing.Point(116, 195);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // SingleHashUILayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlResult);
            this.Controls.Add(this.lblSeperatorPreview);
            this.Controls.Add(this.chkEnableSeperator);
            this.Controls.Add(this.lblValidationMessage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbHashType);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtOpen);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SingleHashUILayout";
            this.Text = "SingleHashUILayout";
            this.pnlResult.ResumeLayout(false);
            this.pnlResult.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button txtOpen;
        private System.Windows.Forms.ComboBox cmbHashType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private CustomControls.Toggle chkEnableSeperator;
        private System.Windows.Forms.Label lblSeperatorPreview;
        private System.Windows.Forms.Label lblValidationMessage;
        private System.Windows.Forms.Panel pnlResult;
        private System.Windows.Forms.Button btnCopyHash;
        private System.Windows.Forms.TextBox txtHashResult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnClear;
    }
}