namespace UniformUI.Frm
{
    partial class Frm_LockScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_LockScreen));
            this.pb_LockImage = new System.Windows.Forms.PictureBox();
            this.lbl_UserName = new DevComponents.DotNetBar.LabelX();
            this.lbl_Pwd = new DevComponents.DotNetBar.LabelX();
            this.tb_Password = new frTextbox.frTextBox();
            this.tb_Username = new frTextbox.frTextBox();
            this.rl_CorpName = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.rlbl_logo = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.btn_Unlock = new frButtonA.frButtonA();
            this.touchKeyboard1 = new DevComponents.DotNetBar.Keyboard.TouchKeyboard();
            ((System.ComponentModel.ISupportInitialize)(this.pb_LockImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_LockImage
            // 
            this.pb_LockImage.Image = ((System.Drawing.Image)(resources.GetObject("pb_LockImage.Image")));
            this.pb_LockImage.Location = new System.Drawing.Point(0, 1);
            this.pb_LockImage.Name = "pb_LockImage";
            this.pb_LockImage.Size = new System.Drawing.Size(1076, 521);
            this.pb_LockImage.TabIndex = 19;
            this.pb_LockImage.TabStop = false;
            // 
            // lbl_UserName
            // 
            // 
            // 
            // 
            this.lbl_UserName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_UserName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UserName.Location = new System.Drawing.Point(446, 528);
            this.lbl_UserName.Name = "lbl_UserName";
            this.lbl_UserName.Size = new System.Drawing.Size(60, 23);
            this.lbl_UserName.TabIndex = 22;
            this.lbl_UserName.Text = "用户名";
            // 
            // lbl_Pwd
            // 
            // 
            // 
            // 
            this.lbl_Pwd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_Pwd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Pwd.Location = new System.Drawing.Point(446, 563);
            this.lbl_Pwd.Name = "lbl_Pwd";
            this.lbl_Pwd.Size = new System.Drawing.Size(44, 23);
            this.lbl_Pwd.TabIndex = 23;
            this.lbl_Pwd.Text = "授权码";
            // 
            // tb_Password
            // 
            this.tb_Password.BorderColor = System.Drawing.Color.Gray;
            this.tb_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Password.Location = new System.Drawing.Point(512, 566);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.PasswordChar = '*';
            this.tb_Password.Size = new System.Drawing.Size(149, 21);
            this.tb_Password.TabIndex = 21;
            this.tb_Password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Password_KeyPress);
            // 
            // tb_Username
            // 
            this.tb_Username.BackColor = System.Drawing.SystemColors.Window;
            this.tb_Username.BorderColor = System.Drawing.Color.Gray;
            this.tb_Username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Username.Location = new System.Drawing.Point(512, 528);
            this.tb_Username.Name = "tb_Username";
            this.tb_Username.Size = new System.Drawing.Size(149, 21);
            this.tb_Username.TabIndex = 20;
            this.tb_Username.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Username_KeyPress);
            // 
            // rl_CorpName
            // 
            // 
            // 
            // 
            this.rl_CorpName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rl_CorpName.Location = new System.Drawing.Point(3, 3);
            this.rl_CorpName.Name = "rl_CorpName";
            this.rl_CorpName.Size = new System.Drawing.Size(175, 70);
            this.rl_CorpName.TabIndex = 2;
            this.rl_CorpName.Text = "<b><font size=\"+6\"><i>RS  TECH</i><font color=\"#B02B2C\"><br />Machin Vision </fon" +
    "t></font></b>";
            // 
            // rlbl_logo
            // 
            // 
            // 
            // 
            this.rlbl_logo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rlbl_logo.Location = new System.Drawing.Point(0, 528);
            this.rlbl_logo.Name = "rlbl_logo";
            this.rlbl_logo.Size = new System.Drawing.Size(148, 70);
            this.rlbl_logo.TabIndex = 24;
            this.rlbl_logo.Text = "<b><font size=\"+6\"><i>RS  TECH</i><font color=\"#B02B2C\"><br />Machin Vision </fon" +
    "t></font></b>";
            // 
            // btn_Unlock
            // 
            this.btn_Unlock.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Unlock.BackgroundImage")));
            this.btn_Unlock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Unlock.Caption1 = "";
            this.btn_Unlock.Caption2 = "Unlock";
            this.btn_Unlock.Font1 = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Unlock.Font2 = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Unlock.ForeColor1 = System.Drawing.SystemColors.ControlText;
            this.btn_Unlock.ForeColor2 = System.Drawing.SystemColors.ControlText;
            this.btn_Unlock.Image1 = ((System.Drawing.Bitmap)(resources.GetObject("btn_Unlock.Image1")));
            this.btn_Unlock.Image2 = ((System.Drawing.Bitmap)(resources.GetObject("btn_Unlock.Image2")));
            this.btn_Unlock.IsLabel = false;
            this.btn_Unlock.Location = new System.Drawing.Point(667, 523);
            this.btn_Unlock.MaximumSize = new System.Drawing.Size(300, 300);
            this.btn_Unlock.MinimumSize = new System.Drawing.Size(16, 16);
            this.btn_Unlock.Name = "btn_Unlock";
            this.btn_Unlock.Size = new System.Drawing.Size(65, 65);
            this.btn_Unlock.TabIndex = 25;
            this.btn_Unlock.ButtonClick += new frButtonA.frButtonA.ButtonClickEventHandler(this.btn_Unlock_ButtonClick);
            // 
            // touchKeyboard1
            // 
            this.touchKeyboard1.FloatingLocation = new System.Drawing.Point(0, 0);
            this.touchKeyboard1.FloatingSize = new System.Drawing.Size(740, 250);
            this.touchKeyboard1.Location = new System.Drawing.Point(0, 0);
            this.touchKeyboard1.Size = new System.Drawing.Size(740, 250);
            this.touchKeyboard1.Text = "";
            // 
            // Frm_LockScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1048, 590);
            this.Controls.Add(this.btn_Unlock);
            this.Controls.Add(this.rlbl_logo);
            this.Controls.Add(this.lbl_UserName);
            this.Controls.Add(this.lbl_Pwd);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.tb_Username);
            this.Controls.Add(this.pb_LockImage);
            this.Controls.Add(this.rl_CorpName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_LockScreen";
            this.Text = "Frm_LockScreen";
            ((System.ComponentModel.ISupportInitialize)(this.pb_LockImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_LockImage;
        private DevComponents.DotNetBar.LabelX lbl_UserName;
        private DevComponents.DotNetBar.LabelX lbl_Pwd;
        private frTextbox.frTextBox tb_Password;
        private frTextbox.frTextBox tb_Username;
        private DevComponents.DotNetBar.Controls.ReflectionLabel rl_CorpName;
        private DevComponents.DotNetBar.Controls.ReflectionLabel rlbl_logo;
        private frButtonA.frButtonA btn_Unlock;
        private DevComponents.DotNetBar.Keyboard.TouchKeyboard touchKeyboard1;
    }
}