namespace UniformUI.Frm
{
    partial class Frm_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Login));
            this.fr_Login = new p12_2.frP12_2();
            this.fr_LoginMode = new p12_1.frP12_1();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fr_Login
            // 
            this.fr_Login.AutoSize = true;
            this.fr_Login.BackColor = System.Drawing.SystemColors.Window;
            this.fr_Login.BKColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(239)))));
            this.fr_Login.BtnWidth = 70;
            this.fr_Login.Location = new System.Drawing.Point(684, 3);
            this.fr_Login.MinimumSize = new System.Drawing.Size(200, 260);
            this.fr_Login.Name = "fr_Login";
            this.fr_Login.Radius = ((long)(20));
            this.fr_Login.Size = new System.Drawing.Size(339, 315);
            this.fr_Login.TabIndex = 0;
            this.fr_Login.Text1 = "";
            this.fr_Login.Text2 = "";
            this.fr_Login.ButtonClick += new p12_2.frP12_2.ButtonClickEventHandler(this.fr_Login_ButtonClick);
            // 
            // fr_LoginMode
            // 
            this.fr_LoginMode.BackColor = System.Drawing.SystemColors.Window;
            this.fr_LoginMode.BKColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(239)))));
            this.fr_LoginMode.btnHeight = 70;
            this.fr_LoginMode.Location = new System.Drawing.Point(10, 84);
            this.fr_LoginMode.MinimumSize = new System.Drawing.Size(300, 200);
            this.fr_LoginMode.Name = "fr_LoginMode";
            this.fr_LoginMode.Radius = ((long)(20));
            this.fr_LoginMode.Size = new System.Drawing.Size(654, 448);
            this.fr_LoginMode.TabIndex = 1;
            this.fr_LoginMode.ButtonClick += new p12_1.frP12_1.ButtonClickEventHandler(this.fr_LoginMode_ButtonClick);
            // 
            // label2
            // 
            this.label2.AllowDrop = true;
            this.label2.AutoEllipsis = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(15, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 76);
            this.label2.TabIndex = 3;
            this.label2.Text = "No Alarm";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.AutoEllipsis = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(172, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 76);
            this.label1.TabIndex = 3;
            this.label1.Text = "No Alarm\r\nff";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AllowDrop = true;
            this.label3.AutoEllipsis = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(407, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 76);
            this.label3.TabIndex = 3;
            this.label3.Text = "No Alarm";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AllowDrop = true;
            this.label4.AutoEllipsis = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.Location = new System.Drawing.Point(325, -1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 76);
            this.label4.TabIndex = 3;
            this.label4.Text = "UPH";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1050, 544);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fr_LoginMode);
            this.Controls.Add(this.fr_Login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Login";
            this.Text = "Frm_Login";
            this.Load += new System.EventHandler(this.Frm_Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public p12_2.frP12_2 fr_Login;
        public p12_1.frP12_1 fr_LoginMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

    }
}