using IntyGenWinUI.UIControllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntyGenWinUI.UILayouts
{
    public partial class MultiHashUILayout : Form
    {
        public MultiHashUILayout()
        {
            InitializeComponent();
            cmbHashType.DataSource = HashTypes.Load();
            chkEnableSeperator_CheckedChanged(null, null);
            LayoutColorRenderer.SetForeColor(lstHashResult, "#00d26a");
            LayoutColorRenderer.SetForeColor(lblHashSummary, Color.DodgerBlue);
        }

        private void chkEnableSeperator_CheckedChanged(object sender, EventArgs e)
        {
            lblSeperatorPreview.Text = chkEnableSeperator.Checked ? "Looks like XX-XX-XX-XX-XX"
                : "Looks like XXXXXXXXXX";
        }

        private void pnlResult_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, pnlResult.ClientRectangle, Color.Gainsboro, ButtonBorderStyle.Solid);
        }
    }
}
