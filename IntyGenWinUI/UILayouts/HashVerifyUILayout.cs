using HashGeneratorLibrary;
using IntyGenWinUI.UIControllers;
using IntyGenWinUI.UIControllers.Validations;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntyGenWinUI.UILayouts
{
    public partial class HashVerifyUILayout : Form
    {
        #region Backing Fields
        private NameValueCollection _config = ConfigurationManager.AppSettings;
        private FileInfo file;
        private ICryptoProcessor processor;
        #endregion

        public HashVerifyUILayout()
        {
            InitializeComponent();
            ValidationMessage.Clear(lblValidationMessage);
            cmbHashType.DataSource = HashTypes.Load();
            cmbHashType_SelectedIndexChanged(null, null);
            LayoutColorRenderer.SetForeColor(txtHash, Color.DodgerBlue);
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

        private bool ValidateHashIsNullOrEmpty()
        {
            if (string.IsNullOrEmpty(txtHash.Text))
            {
                MessageBox.Show(MessageTemplates.HASH_IS_EMPTY, _config["appTitle"], 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        #endregion

        #region Utility Functions
        private void ClearFile()
        {
            file = null;
            txtPath.Clear();
        }

        private void ClearResult()
        {
            txtIntegrityResult.Clear();
            txtHash.Clear();
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
                ClearResult();
            }
            else
            {
                ClearFile();
                ClearResult();
                txtIntegrityResult.Clear();
                ValidateFileIsNullOrEmpty();
                return;
            }

            file = new(selectedPath);

            ValidateFileSize(maxFileSize);
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

            if (!ValidateHashIsNullOrEmpty())
            {
                return;
            }

            string selectedHashMethod = cmbHashType.SelectedItem.ToString();
            processor = HashProcessor.Initialize(selectedHashMethod);
            var hashMatch = await processor.Compare(txtHash.Text, File.OpenRead(file.FullName));

            StringBuilder text = new();

            if (hashMatch)
            {
                text.Clear();
                text.Append(MessageTemplates.FILE_VERIFIED)
                    .Append($"\r\nFile: {file.FullName}")
                    .Append($"\r\nProvided {selectedHashMethod} Hash: {txtHash.Text}");
                txtIntegrityResult.Text = text.ToString();
                LayoutColorRenderer.SetForeColor(txtIntegrityResult, "#00d26a");
            }
            else
            {
                var expected = await processor.CalculateHash(File.OpenRead(file.FullName), useByteSeperator: false);
                text.Clear();
                text.Append(MessageTemplates.FILE_NOT_VERIFIED)
                    .Append($"\r\nFile: {file.FullName}")
                    .Append($"\r\nProvided {selectedHashMethod} Hash: {txtHash.Text}")
                    .Append($"\r\nExpected {selectedHashMethod} Hash: {expected}");
                txtIntegrityResult.Text = text.ToString();
                LayoutColorRenderer.SetForeColor(txtIntegrityResult, Color.Red);
            }
        }

        private void ResetForm()
        {
            ClearFile();
            ClearResult();
            if (cmbHashType.Items.Count > 0)
                cmbHashType.SelectedIndex = 0;
            ValidationMessage.Clear(lblValidationMessage);
        }
        #endregion

        #region UI Events
        private void cmbHashType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedHash = cmbHashType.SelectedItem.ToString();
            lblHash.Text = $"Enter {selectedHash} hash signature";
        }

        private void pnlResult_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, pnlResult.ClientRectangle, Color.Gainsboro, ButtonBorderStyle.Solid);
        }

        private void txtOpen_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            await Generate();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
        #endregion
    }
}
