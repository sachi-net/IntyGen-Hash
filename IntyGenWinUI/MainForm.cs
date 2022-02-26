using IntyGenWinUI.UIControllers;
using IntyGenWinUI.UILayouts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntyGenWinUI
{
    public partial class MainForm : Form
    {
        Color defB = Color.FromArgb(0, 0, 0, 0);
        Color defF = Color.Black;
        Color actB = Color.Gainsboro;
        Color actF = Color.DodgerBlue;

        private Form layout;

        public MainForm()
        {
            InitializeComponent();
            MenuButtonsRenderer.Initialize(actB, actF, defB, defF);
            MenuButtonsRenderer.ResetButtonsIn(pnlMenu);
            lblAppInfo.Text = new ApplicationInfo().GetAppVersion("Version ");
        }

        private void ShowLayout(Form layout)
        {
            layout.TopLevel = false;
            pnlContent.Controls.Add(layout);
            layout.Dock = DockStyle.Fill;
            layout.Show();
        }

        private void CloseCurrentLayout()
        {
            if(layout is not null)
            {
                layout.Close();
                layout.Dispose();
                layout = null;
            }
        }

        private void btnSingleHash_Click(object sender, EventArgs e)
        {
            MenuButtonsRenderer.ActivateButton(sender as Button, pnlMenu);
            CloseCurrentLayout();
            layout = new SingleHashUILayout();
            ShowLayout(layout);
        }

        private void btnMultiHash_Click(object sender, EventArgs e)
        {
            MenuButtonsRenderer.ActivateButton(sender as Button, pnlMenu);
            CloseCurrentLayout();
            layout = new MultiHashUILayout();
            ShowLayout(layout);
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            MenuButtonsRenderer.ActivateButton(sender as Button, pnlMenu);
            CloseCurrentLayout();
            layout = new HashVerifyUILayout();
            ShowLayout(layout);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MenuButtonsRenderer.ActivateButton(sender as Button, pnlMenu);
            CloseCurrentLayout();
            layout = new HelpUILayout();
            ShowLayout(layout);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MenuButtonsRenderer.ActivateButton(sender as Button, pnlMenu);
            CloseCurrentLayout();
            layout = new AboutUILayout();
            ShowLayout(layout);
        }
    }
}
