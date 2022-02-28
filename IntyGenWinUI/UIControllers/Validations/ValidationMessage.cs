using System.Drawing;
using System.Windows.Forms;

namespace IntyGenWinUI.UIControllers.Validations
{
    public static class ValidationMessage
    {
        public static void Show(Label label, string message, AlertType alertType)
        {
            label.Text = message;
            SetAlertType(label, alertType);
            label.Visible = true;
        }

        public static void Clear(Label label)
        {
            label.Text = string.Empty;
            label.Visible = false;
        }

        private static void SetAlertType(Label label, AlertType alertType)
        {
            switch (alertType)
            {
                case AlertType.Information:
                    LayoutColorRenderer.SetForeColor(label, Color.DodgerBlue); break;
                case AlertType.Success:
                    LayoutColorRenderer.SetForeColor(label, "00d26a"); break;
                case AlertType.Warning:
                    LayoutColorRenderer.SetForeColor(label, Color.Orange); break;
                case AlertType.Error:
                    LayoutColorRenderer.SetForeColor(label, Color.Red); break;
                case AlertType.Critical:
                    LayoutColorRenderer.SetForeColor(label, Color.White);
                    LayoutColorRenderer.SetBackColor(label, Color.Red); break;
                default:
                    break;
            }
        }
    }
}
