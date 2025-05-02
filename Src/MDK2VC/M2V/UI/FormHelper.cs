using System;
using System.Windows.Forms;

namespace MDK2VC.M2V.UI
{
    public partial class FormHelper : Form
    {
        public FormHelper()
        {
            InitializeComponent();
        }

        private void FormHelper_Load(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }
    }
}
