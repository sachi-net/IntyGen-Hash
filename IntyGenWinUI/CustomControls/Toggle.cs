﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace IntyGenWinUI.CustomControls
{
    public class Toggle : CheckBox
    {
        private Color onBackColor = Color.MediumSlateBlue;
        private Color onToggleColor = Color.WhiteSmoke;
        private Color offBackColor = Color.Gray;
        private Color offToggleColor = Color.Gainsboro;
        private bool solidStyle = true;

        [Category("Extra Settings")]
        public Color OnBackColor
        {
            get { return onBackColor; }
            set
            {
                onBackColor = value;
                Invalidate();
            }
        }

        [Category("Extra Settings")]
        public Color OnToggleColor
        {
            get { return onToggleColor; }
            set
            {
                onToggleColor = value;
                Invalidate();
            }
        }

        [Category("Extra Settings")]
        public Color OffBackColor
        {
            get { return offBackColor; }
            set
            {
                offBackColor = value;
                Invalidate();
            }
        }

        [Category("Extra Settings")]
        public Color OffToggleColor
        {
            get { return offToggleColor; }
            set
            {
                offToggleColor = value;
                Invalidate();
            }
        }

        [Browsable(false)]
        public override string Text
        {
            get { return base.Text; }
            set { }
        }

        [Category("Extra Settings")]
        [DefaultValue(true)]
        public bool SolidStyle
        {
            get { return solidStyle; }
            set
            {
                solidStyle = value;
                Invalidate();
            }
        }

        public Toggle()
        {
            MinimumSize = new Size(45, 22);
        }

        private GraphicsPath GetFigurePath()
        {
            int arcSize = this.Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(this.Width - arcSize - 2, 0, arcSize, arcSize);
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            int toggleSize = Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(Parent.BackColor);
            if (Checked) //ON
            {
                //Draw the control surface
                if (solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(onBackColor), GetFigurePath());
                else pevent.Graphics.DrawPath(new Pen(onBackColor, 2), GetFigurePath());
                //Draw the toggle
                pevent.Graphics.FillEllipse(new SolidBrush(onToggleColor),
                  new Rectangle(Width - Height + 1, 2, toggleSize, toggleSize));
            }
            else //OFF
            {
                //Draw the control surface
                if (solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(offBackColor), GetFigurePath());
                else pevent.Graphics.DrawPath(new Pen(offBackColor, 2), GetFigurePath());
                //Draw the toggle
                pevent.Graphics.FillEllipse(new SolidBrush(offToggleColor),
                  new Rectangle(2, 2, toggleSize, toggleSize));
            }
        }
    }
}
