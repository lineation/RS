namespace UniformUI.Frm
{
    partial class Frm_Welcom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.circularProgressItem1 = new DevComponents.DotNetBar.CircularProgressItem();
            this.circularProgressItem2 = new DevComponents.DotNetBar.CircularProgressItem();
            this.circularProgressItem3 = new DevComponents.DotNetBar.CircularProgressItem();
            this.reflectionLabel1 = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.circularProgress = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // circularProgressItem1
            // 
            this.circularProgressItem1.Name = "circularProgressItem1";
            this.circularProgressItem1.PieBorderLight = System.Drawing.Color.Empty;
            this.circularProgressItem1.ProgressColor = System.Drawing.Color.DarkMagenta;
            this.circularProgressItem1.Text = "Line";
            this.circularProgressItem1.TextPosition = DevComponents.DotNetBar.eTextPosition.Bottom;
            this.circularProgressItem1.Value = 60;
            // 
            // circularProgressItem2
            // 
            this.circularProgressItem2.Name = "circularProgressItem2";
            this.circularProgressItem2.PieBorderLight = System.Drawing.Color.Empty;
            this.circularProgressItem2.ProgressColor = System.Drawing.Color.DarkMagenta;
            this.circularProgressItem2.Text = "Line";
            this.circularProgressItem2.TextPosition = DevComponents.DotNetBar.eTextPosition.Bottom;
            this.circularProgressItem2.Value = 60;
            // 
            // circularProgressItem3
            // 
            this.circularProgressItem3.Name = "circularProgressItem3";
            this.circularProgressItem3.PieBorderLight = System.Drawing.Color.Empty;
            this.circularProgressItem3.ProgressColor = System.Drawing.Color.DarkMagenta;
            this.circularProgressItem3.Text = "Line";
            this.circularProgressItem3.TextPosition = DevComponents.DotNetBar.eTextPosition.Bottom;
            this.circularProgressItem3.Value = 60;
            // 
            // reflectionLabel1
            // 
            // 
            // 
            // 
            this.reflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.reflectionLabel1.Location = new System.Drawing.Point(34, 26);
            this.reflectionLabel1.Name = "reflectionLabel1";
            this.reflectionLabel1.Size = new System.Drawing.Size(175, 70);
            this.reflectionLabel1.TabIndex = 1;
            this.reflectionLabel1.Text = "<b><font size=\"+6\"><i>RS  TECH</i><font color=\"#B02B2C\"><br />Machin Vision </fon" +
    "t></font></b>";
            // 
            // circularProgress
            // 
            // 
            // 
            // 
            this.circularProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.circularProgress.Location = new System.Drawing.Point(613, 373);
            this.circularProgress.Name = "circularProgress";
            this.circularProgress.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(215)))), ((int)(((byte)(150)))));
            this.circularProgress.ProgressText = "Loading";
            this.circularProgress.ProgressTextColor = System.Drawing.Color.Black;
            this.circularProgress.Size = new System.Drawing.Size(81, 46);
            this.circularProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgress.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(631, 431);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Loading";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Frm_Welcom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1050, 523);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.circularProgress);
            this.Controls.Add(this.reflectionLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Welcom";
            this.Text = "Frm_Welcom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.CircularProgressItem circularProgressItem1;
        private DevComponents.DotNetBar.CircularProgressItem circularProgressItem2;
        private DevComponents.DotNetBar.CircularProgressItem circularProgressItem3;
        private DevComponents.DotNetBar.Controls.ReflectionLabel reflectionLabel1;
        private DevComponents.DotNetBar.Controls.CircularProgress circularProgress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;

    }
}