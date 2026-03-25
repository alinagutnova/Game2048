using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game2048
{
    public class CustomLabel : Label
    {
        public Form Parent;

        public CustomLabel(Form parent, int row, int column)
        {
            Parent = parent;

            BackColor = Color.DimGray;
            Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            ForeColor = Color.White;
            int x = 10 + column * (70 + 5);
            int y = 70 + row* (70 + 5);
            Location = new Point(x,y);
            Size = new Size(70, 70);
            Text = "";
            TextAlign = ContentAlignment.MiddleCenter;

            TextChanged += MyTextChanged;


            Parent.Controls.Add(this);
        }

        private void MyTextChanged(object sender, EventArgs e)
        {
            Label tmp = (Label)sender;
            switch (tmp.Text)
            {
                case "": BackColor = Color.DimGray;break;
                case "2": BackColor = Color.FromArgb(238,228,218); break;
                case "4": BackColor = Color.FromArgb(237, 224, 200); break;
                case "8": BackColor = Color.FromArgb(242, 177, 121); break;
                case "16": BackColor = Color.FromArgb(245, 149, 99); break;
                case "32": BackColor = Color.FromArgb(246, 124, 95); break;
                case "64": BackColor = Color.FromArgb(246, 94, 59); break;
                case "128": BackColor = Color.FromArgb(237, 207, 114); break;
                case "256": BackColor = Color.FromArgb(241, 208, 86); break;
                case "512": BackColor = Color.FromArgb(240, 203, 65); break;
                case "1024": BackColor = Color.FromArgb(242, 201, 39); break;
                case "2048": BackColor = Color.FromArgb(243, 197, 0); break;
            }
        }

    }
}
