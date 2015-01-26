using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Parser.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnPars_Click(object sender, EventArgs e)
        {
            frmParse frm = new frmParse();
            frm.ShowDialog();
        }
    }
}
