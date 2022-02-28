
namespace IntyGenWinUI.UILayouts
{
    partial class HashVerifyUILayout
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
            this.pnlResult = new System.Windows.Forms.Panel();
            this.txtIntegrityResult = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblValidationMessage = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbHashType = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtOpen = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHash = new System.Windows.Forms.TextBox();
            this.lblHash = new System.Windows.Forms.Label();
            this.pnlResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlResult
            // 
            this.pnlResult.Controls.Add(this.txtIntegrityResult);
            this.pnlResult.Controls.Add(this.label6);
            this.pnlResult.Location = new System.Drawing.Point(35, 237);
            this.pnlResult.Name = "pnlResult";
            this.pnlResult.Size = new System.Drawing.Size(533, 150);
            this.pnlResult.TabIndex = 22;
            this.pnlResult.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlResult_Paint);
            // 
            // txtIntegrityResult
            // 
            this.txtIntegrityResult.Location = new System.Drawing.Point(22, 32);
            this.txtIntegrityResult.Multiline = true;
            this.txtIntegrityResult.Name = "txtIntegrityResult";
            this.txtIntegrityResult.ReadOnly = true;
            this.txtIntegrityResult.Size = new System.Drawing.Size(488, 91);
            this.txtIntegrityResult.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Verification Result";
            // 
            // lblValidationMessage
            // 
            this.lblValidationMessage.AutoSize = true;
            this.lblValidationMessage.ForeColor = System.Drawing.Color.Red;
            this.lblValidationMessage.Location = new System.Drawing.Point(163, 132);
            this.lblValidationMessage.Name = "lblValidationMessage";
            this.lblValidationMessage.Size = new System.Drawing.Size(108, 15);
            this.lblValidationMessage.TabIndex = 18;
            this.lblValidationMessage.Text = "Validation message";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(163, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "File Path";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "Hash Type";
            // 
            // cmbHashType
            // 
            this.cmbHashType.FormattingEnabled = true;
            this.cmbHashType.Location = new System.Drawing.Point(36, 106);
            this.cmbHashType.Name = "cmbHashType";
            this.cmbHashType.Size = new System.Drawing.Size(121, 23);
            this.cmbHashType.TabIndex = 15;
            this.cmbHashType.SelectedIndexChanged += new System.EventHandler(this.cmbHashType_SelectedIndexChanged);
            // 
            // btnClear
            // 
            this.btnClear.ForeColor = System.Drawing.Color.Red;
            this.btnClear.Location = new System.Drawing.Point(116, 196);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(35, 196);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 13;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtOpen
            // 
            this.txtOpen.Location = new System.Drawing.Point(487, 106);
            this.txtOpen.Name = "txtOpen";
            this.txtOpen.Size = new System.Drawing.Size(75, 23);
            this.txtOpen.TabIndex = 14;
            this.txtOpen.Text = "Open...";
            this.txtOpen.UseVisualStyleBackColor = true;
            this.txtOpen.Click += new System.EventHandler(this.txtOpen_Click);
            // 
            // txtPath
            // 
            this.txtPath.Cursor = System.Windows.Forms.Cursors.No;
            this.txtPath.Location = new System.Drawing.Point(163, 106);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(318, 23);
            this.txtPath.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(409, 30);
            this.label2.TabIndex = 9;
            this.label2.Text = "You can verify the integrity of selected file with specified hash signature.\r\nOpe" +
    "n a file from your local file system and enter the hash signature to verify.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(36, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "Verify File Integrity";
            // 
            // txtHash
            // 
            this.txtHash.Location = new System.Drawing.Point(36, 165);
            this.txtHash.Name = "txtHash";
            this.txtHash.Size = new System.Drawing.Size(445, 23);
            this.txtHash.TabIndex = 23;
            // 
            // lblHash
            // 
            this.lblHash.AutoSize = true;
            this.lblHash.Location = new System.Drawing.Point(36, 147);
            this.lblHash.Name = "lblHash";
            this.lblHash.Size = new System.Drawing.Size(61, 15);
            this.lblHash.TabIndex = 17;
            this.lblHash.Text = "Hash Type";
            // 
            // HashVerifyUILayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtHash);
            this.Controls.Add(this.pnlResult);
            this.Controls.Add(this.lblValidationMessage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblHash);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbHashType);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtOpen);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HashVerifyUILayout";
            this.Text = "HashVerifyUILayout";
            this.pnlResult.ResumeLayout(false);
            this.pnlResult.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlResult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblValidationMessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbHashType;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button txtOpen;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHash;
        private System.Windows.Forms.Label lblHash;
        private System.Windows.Forms.TextBox txtIntegrityResult;
    }
}