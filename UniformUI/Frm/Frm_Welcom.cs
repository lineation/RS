using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniformUI.Frm
{
    public partial class Frm_Welcom : Form
    {
         Frm_Main mainForm = new Frm_Main();
            
        public Frm_Welcom()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            circularProgress.IsRunning = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
           if (mainForm.ShowDialog(this) == DialogResult.OK)
           {
               this.Dispose();
           }
        }
    }
}
