using HashGeneratorLibrary;
using HashGeneratorLibrary.Models;
using IntyGenWinUI.UIControllers;
using IntyGenWinUI.UIControllers.Validations;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntyGenWinUI.UILayouts
{
    public partial class MultiHashUILayout : Form
    {
        #region Backing Fields
        private NameValueCollection _config = ConfigurationManager.AppSettings;
        private IEnumerable<FileInfo> files;
        private ICryptoProcessor processor;
        private string lastProcessedHashType;
        private string lastHashedDirectory;
        private CancellationTokenSource tokenSource = new();
        #endregion

        public MultiHashUILayout()
        {
            InitializeComponent();
            ResetForm();
            cmbHashType.DataSource = HashTypes.Load();
            chkEnableSeperator_CheckedChanged(null, null);
            LayoutColorRenderer.SetForeColor(lstHashResult, "#00d26a");
            LayoutColorRenderer.SetForeColor(lblHashSummary, Color.DodgerBlue);
        }

        #region UI Validations
        private bool ValidateFiles()
        {
            if (files is null)
            {
                ValidationMessage.Show(lblValidationMessage,
                    MessageTemplates.NO_FILES_ADDED, AlertType.Error);
                return false;
            }

            if(files.Count() == 0)
            {
                ValidationMessage.Show(lblValidationMessage,
                    MessageTemplates.DIRECTORY_IS_EMPTY, AlertType.Warning);
                return false;
            }

            var maxFileSize = Convert.ToInt64(_config["maxFileSize"]);
            var skipLargeFiles = chkSkipLargeFiles.Checked;

            if (!skipLargeFiles && files.Any(f => f.Length >= maxFileSize))
            {
                ValidationMessage.Show(lblValidationMessage,
                    MessageTemplates.DIRECTORY_CONTAINS_LARGE_FILES, AlertType.Error);
                return false;
            }

            ValidationMessage.Clear(lblValidationMessage);
            return true;
        }
        #endregion

        #region Utility Functions
        private void ClearFiles()
        {
            files = null;
            txtPath.Clear();
        }

        private void ClearResult()
        {
            lstHashResult.Items.Clear();
            btnExport.Visible = false;
            ValidationMessage.Clear(lblHashSummary);
            progressBar.Value = 0;
        }

        private void OpenDirectory()
        {
            FolderBrowserDialog dialog = new()
            {
                ShowNewFolderButton = false
            };

            var option = dialog.ShowDialog();
            string selectedPath;

            if (option == DialogResult.OK)
            {
                selectedPath = dialog.SelectedPath;
                txtPath.Text = selectedPath;
                ClearResult();
            }
            else
            {
                ClearFiles();
                ClearResult();
                ValidateFiles();
                return;
            }

            files = new DirectoryInfo(selectedPath).GetFiles().ToList();
            ValidateFiles();
        }

        private async Task Generate()
        {
            tokenSource.Dispose();
            tokenSource = new();

            ClearResult();
            lstHashResult.DataSource = null;
            List<CryptoData<Stream>> fileData = new();
            var skipLargeFiles = chkSkipLargeFiles.Checked;
            var maxFileSize = Convert.ToInt64(_config["maxFileSize"]);

            if (ValidateFiles())
            {
                var filesToBeHashed = files.Where(f => f.Length < maxFileSize);
                foreach (var file in filesToBeHashed)
                {
                    CryptoData<Stream> data = new(file.Name, File.OpenRead(file.FullName));
                    fileData.Add(data);
                }

                Progress<int> progress;
                if(filesToBeHashed.Count() > 1)
                {
                    progressBar.Style = ProgressBarStyle.Blocks;
                    progress = new(percentage => { progressBar.Value = percentage; });
                }
                else
                {
                    progressBar.Style = ProgressBarStyle.Marquee;
                    progress = new();
                }

                try
                {
                    btnCancel.Visible = true;
                    processor = HashProcessor.Initialize(cmbHashType.SelectedItem.ToString());
                    var result = await processor.CalculateHash(fileData, progress, tokenSource.Token, chkEnableSeperator.Checked);

                    if (progressBar.Style == ProgressBarStyle.Marquee)
                    {
                        progressBar.Style = ProgressBarStyle.Blocks;
                    }

                    foreach (var data in result)
                    {
                        var line = $"{data.Hash} - {data.DataKey}";
                        lstHashResult.Items.Add(line);
                    }

                    if (lstHashResult.Items.Count > 0)
                    {
                        btnExport.Visible = true;
                    }

                    lastProcessedHashType = cmbHashType.SelectedItem.ToString();
                    lastHashedDirectory = files is not null && files.Count() > 0 ?
                        files.ToList()[0].DirectoryName : "Path";

                    var summary = $"{filesToBeHashed.Count()} of {files.Count()} file(s) processed";
                    ValidationMessage.Show(lblHashSummary, summary, AlertType.Information);
                }
                catch (OperationCanceledException)
                {
                    MessageBox.Show(MessageTemplates.OPERATION_CANCELLED, "System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    progressBar.Value = 0;
                }
                finally
                {
                    btnCancel.Visible = false;
                }
            }
        }

        private void ResetForm()
        {
            ClearFiles();
            ClearResult();
            btnCancel.Visible = false;
            lstHashResult.Items.Clear();
            if (cmbHashType.Items.Count > 0)
                cmbHashType.SelectedIndex = 0;
            ValidationMessage.Clear(lblValidationMessage);
            chkEnableSeperator.Checked = chkSkipLargeFiles.Checked = false;
        }
        
        private async Task ExportFile()
        {
            SaveFileDialog dialog = new()
            {
                Title = "Save Hash Result As...",
                CheckPathExists = true,
                DefaultExt = "txt",
                Filter = "Text file (*.txt)|*txt",
                FileName = $"{_config["exportNamePrefix"]}-{DateTime.Now:yyyyMMddHHmmssffff}"
            };

            var option = dialog.ShowDialog();

            if (option == DialogResult.OK)
            {
                using (var stream = File.CreateText(dialog.FileName))
                {
                    await stream.WriteLineAsync($"Folder: {lastHashedDirectory}");
                    await stream.WriteLineAsync($"Hash Type: {lastProcessedHashType}\n");

                    foreach (var line in lstHashResult.Items)
                    {
                        await stream.WriteLineAsync(line.ToString());
                    }
                }

                MessageBox.Show(MessageTemplates.RESULT_SAVED(dialog.FileName), "System",
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
            OpenDirectory();
        }

        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            await Generate();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private async void btnExport_Click(object sender, EventArgs e)
        {
            await ExportFile();
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            tokenSource.Cancel();
        }
    }
}
