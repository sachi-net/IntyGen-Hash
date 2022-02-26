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
    public partial class HashVerifyUILayout : Form
    {
        public HashVerifyUILayout()
        {
            InitializeComponent();
            cmbHashType.DataSource = HashTypes.Load();
            cmbHashType_SelectedIndexChanged(null, null);
            LayoutColorRenderer.SetForeColor(txtHash, Color.DodgerBlue);
        }

        private void cmbHashType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedHash = cmbHashType.SelectedItem.ToString();
            lblHash.Text = $"Enter {selectedHash} hash signature";
        }

        private void pnlResult_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, pnlResult.ClientRectangle, Color.Gainsboro, ButtonBorderStyle.Solid);
        }
    }
}
