using HashGeneratorLibrary;
using IntyGenWinUI.UIControllers;
using IntyGenWinUI.UIControllers.Validations;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntyGenWinUI.UILayouts
{
    public partial class SingleHashUILayout : Form
    {
        #region Backing Fields
        private NameValueCollection _config = ConfigurationManager.AppSettings;
        private FileInfo file;
        private ICryptoProcessor processor;
        #endregion

        public SingleHashUILayout()
        {
            InitializeComponent();
            ValidationMessage.Clear(lblValidationMessage);
            cmbHashType.DataSource = HashTypes.Load();
            chkEnableSeperator_CheckedChanged(null, null);
            txtHashResult_TextChanged(null, null);
            LayoutColorRenderer.SetForeColor(txtHashResult, "#00d26a");
        }

        #region UI Validations
        private bool ValidateFileSize(long maxFileSize)
        {
            if (file.Length >= maxFileSize)
            {
                ValidationMessage.Show(lblValidationMessage,
                    MessageTemplates.FILE_TOO_LARGE, AlertType.Error);
                ClearFile();
                return false;
            }
            else
            {
                ValidationMessage.Clear(lblValidationMessage);
                return true;
            }
        }

        private bool ValidateFileIsNullOrEmpty()
        {
            if (file is null)
            {
                ValidationMessage.Show(lblValidationMessage,
                    MessageTemplates.NO_FILE_SELECTED, AlertType.Error);
                return false;
            }
            else
            {
                ValidationMessage.Clear(lblValidationMessage);
                return true;
            }
        }
        #endregion

        #region Utility Functions
        private void ClearFile()
        {
            file = null;
            txtPath.Clear();
        }

        private void OpenFile()
        {
            OpenFileDialog dialog = new()
            {
                Title = "Open File...",
                CheckFileExists = true,
                CheckPathExists = true,
            };

            var option = dialog.ShowDialog();
            string selectedPath;
            var maxFileSize = Convert.ToInt64(_config["maxFileSize"]);

            if (option == DialogResult.OK)
            {
                selectedPath = dialog.FileName;
                txtPath.Text = selectedPath;
            }
            else
            {
                ClearFile();
                txtHashResult.Clear();
                ValidateFileIsNullOrEmpty();
                return;
            }

            file = new(selectedPath);

            ValidateFileSize(maxFileSize);
        }

        private void ResetForm()
        {
            ClearFile();
            txtHashResult.Clear();
            if (cmbHashType.Items.Count > 0)
                cmbHashType.SelectedIndex = 0;
            ValidationMessage.Clear(lblValidationMessage);
            chkEnableSeperator.Checked = false;
        }

        private async Task Generate()
        {
            var maxFileSize = Convert.ToInt64(_config["maxFileSize"]);

            if (file is null)
            {
                ValidateFileIsNullOrEmpty();
                return;
            }

            if (!ValidateFileSize(maxFileSize))
            {
                return;
            }

            processor = HashProcessor.Initialize(cmbHashType.SelectedItem.ToString());
            var result = await processor.CalculateHash(File.OpenRead(file.FullName), chkEnableSeperator.Checked);
            txtHashResult.Text = result;
        }

        private void CopyToClipboard()
        {
            if (!string.IsNullOrEmpty(txtHashResult.Text))
            {
                Clipboard.SetText(txtHashResult.Text);
                MessageBox.Show("Hash result copied to clipboard!", "System", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region UI Events
        private void chkEnableSeperator_CheckedChanged(object sender, EventArgs e)
        {
            lblSeperatorPreview.Text = chkEnableSeperator.Checked ? MessageTemplates.DASHED_HASH_PREVIEW 
                : MessageTemplates.NON_DASHED_HASH_PREVIEW;
        }

        private void pnlResult_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, pnlResult.ClientRectangle, Color.Gainsboro, ButtonBorderStyle.Solid);
        }

        private void txtOpen_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void txtHashResult_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHashResult.Text))
            {
                btnCopyHash.Enabled = false;
            }
            else
            {
                btnCopyHash.Enabled = true;
            }
        }

        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            await Generate();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnCopyHash_Click(object sender, EventArgs e)
        {
            CopyToClipboard();
        }
        #endregion
    }
}
