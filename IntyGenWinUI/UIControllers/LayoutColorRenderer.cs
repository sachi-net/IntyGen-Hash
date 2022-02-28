using System.Drawing;
using System.Windows.Forms;

namespace IntyGenWinUI.UIControllers
{
    public static class LayoutColorRenderer
    {
        public static void SetForeColor(Control element, string colorHex)
        {
            element.BackColor = element.BackColor;
            element.ForeColor = ColorTranslator.FromHtml(colorHex);
            element.Invalidate();
        }

        public static void SetForeColor(Control element, Color color)
        {
            element.BackColor = element.BackColor;
            element.ForeColor = color;
            element.Invalidate();
        }

        public static void SetBackColor(Control element, string colorHex)
        {
            element.BackColor = ColorTranslator.FromHtml(colorHex);
        }

        public static void SetBackColor(Control element, Color color)
        {
            element.BackColor = color;
        }
    }
}
