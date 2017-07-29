using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniformUI.RSControl
{
    [ToolboxBitmap(typeof(RSButton))]
    public partial class RSButton : UserControl
    {
        private string m_Text = "Text1";

        [DefaultValue("Text1")]
        public string Text1
        {
            get { return m_Text; }
            set { m_Text = value; labelX2.Text = m_Text.Trim(); }
        } 
        public RSButton()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams//v1.10 
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; //0x20;  // 开启 WS_EX_TRANSPARENT,使控件支持透明
                return cp;
            }
        }

        private void RSButton_MouseEnter(object sender, EventArgs e)
        {
            panel.BackColor = Color.FromArgb(174, 218, 151);
        }

        private void RSButton_MouseLeave(object sender, EventArgs e)
        {
            panel.BackColor = Color.FromArgb(238, 238, 239);
        }

        private void labelX1_MouseEnter(object sender, EventArgs e)
        {
            panel.BackColor = Color.FromArgb(174, 218, 151);
            //labelX1.BackColor = Color.FromArgb(174, 218, 151);
            //labelX2.BackColor = Color.FromArgb(174, 218, 151);
        }

        private void labelX1_MouseLeave(object sender, EventArgs e)
        {
            panel.BackColor = Color.FromArgb(238, 238, 239);
            //labelX1.BackColor = Color.FromArgb(238, 238, 239);
            //labelX2.BackColor = Color.FromArgb(238, 238, 239);
        }

        private void labelX2_MouseEnter(object sender, EventArgs e)
        {
            panel.BackColor = Color.FromArgb(174, 218, 151);
            //labelX1.BackColor = Color.FromArgb(174, 218, 151);
            //labelX2.BackColor = Color.FromArgb(174, 218, 151);
        }

        private void labelX2_MouseLeave(object sender, EventArgs e)
        {
            panel.BackColor = Color.FromArgb(174, 218, 151);
            //labelX1.BackColor = Color.FromArgb(238, 238, 239);
            //labelX2.BackColor = Color.FromArgb(238, 238, 239);
        }

        private void labelX1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("dd");
        }

        private void RSButton_Load(object sender, EventArgs e)
        {
            ///labelX2.Text = m_Text.Trim();
        }

    }
}
