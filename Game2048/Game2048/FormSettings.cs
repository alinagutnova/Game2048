using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game2048
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            Class2048.FieldSize = Convert.ToInt32(nudSize.Value);
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            nudSize.Value = Class2048.FieldSize;
        }
    }
}
