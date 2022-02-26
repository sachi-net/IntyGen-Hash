using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntyGenWinUI.UIControllers
{
    internal static class MenuButtonsRenderer
    {
        private static Color _defaultBackColor;
        private static Color _defaultForeColor;
        private static Color _activeBackColor;
        private static Color _activeForeColor;

        internal static void Initialize(Color activeBackColor, Color activeForeColor, 
            Color defaultBackColor, Color defaultForeColor)
        {
            _activeBackColor = activeBackColor;
            _activeForeColor = activeForeColor;
            _defaultBackColor = defaultBackColor;
            _defaultForeColor = defaultForeColor;
        }

        internal static void ResetButtonsIn(Control parentElement)
        {
            foreach (var control in parentElement.Controls.OfType<Button>())
            {
                control.BackColor = _defaultBackColor;
                control.ForeColor = _defaultForeColor;
                control.Font = new Font(control.Font, FontStyle.Regular);
            }
        }

        internal static void ActivateButton(Button button, Control parentElement = null)
        {
            if (parentElement is not null)
            {
                ResetButtonsIn(parentElement);
            }

            button.BackColor = _activeBackColor;
            button.ForeColor = _activeForeColor;
            button.Font = new Font(button.Font, FontStyle.Bold);
        }
    }
}
