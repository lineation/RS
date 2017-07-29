namespace UniformUI.Frm
{
    partial class Frm_Main
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
            this.frToolbar1 = new frToolbar.frToolbar();
            this.btn_LockScreen = new System.Windows.Forms.Button();
            this.touchKeyboard1 = new DevComponents.DotNetBar.Keyboard.TouchKeyboard();
            this.btn_TouchKeyBoard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // frToolbar1
            // 
            this.frToolbar1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.frToolbar1.BackColor = System.Drawing.Color.White;
            this.frToolbar1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.frToolbar1.Location = new System.Drawing.Point(0, -1);
            this.frToolbar1.MinimumSize = new System.Drawing.Size(800, 65);
            this.frToolbar1.Name = "frToolbar1";
            this.frToolbar1.Size = new System.Drawing.Size(1354, 86);
            this.frToolbar1.TabIndex = 0;
            this.frToolbar1.ButtonClick += new frToolbar.frToolbar.ButtonClickEventHandler(this.frToolbar1_ButtonClick);
            // 
            // btn_LockScreen
            // 
            this.btn_LockScreen.Location = new System.Drawing.Point(869, 37);
            this.btn_LockScreen.Name = "btn_LockScreen";
            this.btn_LockScreen.Size = new System.Drawing.Size(75, 23);
            this.btn_LockScreen.TabIndex = 2;
            this.btn_LockScreen.Text = "锁屏(&L)";
            this.btn_LockScreen.UseCompatibleTextRendering = true;
            this.btn_LockScreen.UseVisualStyleBackColor = true;
            this.btn_LockScreen.Click += new System.EventHandler(this.btn_LockScreen_Click);
            // 
            // touchKeyboard1
            // 
            this.touchKeyboard1.FloatingLocation = new System.Drawing.Point(0, 0);
            this.touchKeyboard1.FloatingSize = new System.Drawing.Size(740, 250);
            this.touchKeyboard1.Location = new System.Drawing.Point(0, 0);
            this.touchKeyboard1.Size = new System.Drawing.Size(740, 250);
            this.touchKeyboard1.Text = "";
            // 
            // btn_TouchKeyBoard
            // 
            this.btn_TouchKeyBoard.Location = new System.Drawing.Point(806, 13);
            this.btn_TouchKeyBoard.Name = "btn_TouchKeyBoard";
            this.btn_TouchKeyBoard.Size = new System.Drawing.Size(75, 23);
            this.btn_TouchKeyBoard.TabIndex = 5;
            this.btn_TouchKeyBoard.Text = "软键盘(&K)";
            this.btn_TouchKeyBoard.UseVisualStyleBackColor = true;
            this.btn_TouchKeyBoard.Click += new System.EventHandler(this.btn_TouchKeyBoard_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.frToolbar1);
            this.Controls.Add(this.btn_TouchKeyBoard);
            this.Controls.Add(this.btn_LockScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "Frm_Main";
            this.Text = "主窗体";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_ESCKeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        public frToolbar.frToolbar frToolbar1;
        private System.Windows.Forms.Button btn_LockScreen;
        private DevComponents.DotNetBar.Keyboard.TouchKeyboard touchKeyboard1;
        private System.Windows.Forms.Button btn_TouchKeyBoard;




    }
}

