namespace UniformUI.Frm
{
    partial class Dlg_StringParamSetting
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
            this.lbl_Tip = new DevComponents.DotNetBar.LabelX();
            this.lbl_ParamName = new DevComponents.DotNetBar.LabelX();
            this.lbl_Pwd = new DevComponents.DotNetBar.LabelX();
            this.lbl_ParamValue = new DevComponents.DotNetBar.LabelX();
            this.tb_Password = new frTextbox.frTextBox();
            this.tb_StringParamName = new frTextbox.frTextBox();
            this.lbl_EditStringCancel = new DevComponents.DotNetBar.LabelX();
            this.lbl_EditStringOk = new DevComponents.DotNetBar.LabelX();
            this.lbl_Title = new DevComponents.DotNetBar.LabelX();
            this.tb_StringParamValue = new frTextbox.frTextBox();
            this.SuspendLayout();
            // 
            // lbl_Tip
            // 
            // 
            // 
            // 
            this.lbl_Tip.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_Tip.ForeColor = System.Drawing.Color.Red;
            this.lbl_Tip.Location = new System.Drawing.Point(-1, 36);
            this.lbl_Tip.Name = "lbl_Tip";
            this.lbl_Tip.Size = new System.Drawing.Size(302, 16);
            this.lbl_Tip.TabIndex = 26;
            this.lbl_Tip.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lbl_ParamName
            // 
            // 
            // 
            // 
            this.lbl_ParamName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_ParamName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ParamName.Location = new System.Drawing.Point(43, 58);
            this.lbl_ParamName.Name = "lbl_ParamName";
            this.lbl_ParamName.Size = new System.Drawing.Size(60, 23);
            this.lbl_ParamName.TabIndex = 22;
            this.lbl_ParamName.Text = "参数名称";
            // 
            // lbl_Pwd
            // 
            // 
            // 
            // 
            this.lbl_Pwd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_Pwd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Pwd.Location = new System.Drawing.Point(43, 108);
            this.lbl_Pwd.Name = "lbl_Pwd";
            this.lbl_Pwd.Size = new System.Drawing.Size(44, 23);
            this.lbl_Pwd.TabIndex = 23;
            this.lbl_Pwd.Text = "授权码";
            // 
            // lbl_ParamValue
            // 
            // 
            // 
            // 
            this.lbl_ParamValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_ParamValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ParamValue.Location = new System.Drawing.Point(43, 83);
            this.lbl_ParamValue.Name = "lbl_ParamValue";
            this.lbl_ParamValue.Size = new System.Drawing.Size(44, 23);
            this.lbl_ParamValue.TabIndex = 24;
            this.lbl_ParamValue.Text = "参数值";
            // 
            // tb_Password
            // 
            this.tb_Password.BorderColor = System.Drawing.Color.Gray;
            this.tb_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Password.Location = new System.Drawing.Point(109, 111);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.PasswordChar = '*';
            this.tb_Password.Size = new System.Drawing.Size(149, 21);
            this.tb_Password.TabIndex = 2;
            // 
            // tb_StringParamName
            // 
            this.tb_StringParamName.BackColor = System.Drawing.SystemColors.Window;
            this.tb_StringParamName.BorderColor = System.Drawing.Color.Gray;
            this.tb_StringParamName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_StringParamName.Location = new System.Drawing.Point(109, 58);
            this.tb_StringParamName.Name = "tb_StringParamName";
            this.tb_StringParamName.Size = new System.Drawing.Size(149, 21);
            this.tb_StringParamName.TabIndex = 0;
            // 
            // lbl_EditStringCancel
            // 
            // 
            // 
            // 
            this.lbl_EditStringCancel.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_EditStringCancel.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl_EditStringCancel.BackgroundStyle.BorderBottomWidth = 1;
            this.lbl_EditStringCancel.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_EditStringCancel.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_EditStringCancel.BackgroundStyle.BorderLeftWidth = 1;
            this.lbl_EditStringCancel.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_EditStringCancel.BackgroundStyle.BorderRightWidth = 1;
            this.lbl_EditStringCancel.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_EditStringCancel.BackgroundStyle.BorderTopWidth = 1;
            this.lbl_EditStringCancel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_EditStringCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_EditStringCancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_EditStringCancel.Location = new System.Drawing.Point(152, 138);
            this.lbl_EditStringCancel.Name = "lbl_EditStringCancel";
            this.lbl_EditStringCancel.SingleLineColor = System.Drawing.Color.White;
            this.lbl_EditStringCancel.Size = new System.Drawing.Size(149, 43);
            this.lbl_EditStringCancel.SymbolColor = System.Drawing.Color.White;
            this.lbl_EditStringCancel.TabIndex = 18;
            this.lbl_EditStringCancel.Text = "取消";
            this.lbl_EditStringCancel.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lbl_EditStringCancel.Click += new System.EventHandler(this.lbl_EditStringCancel_Click);
            this.lbl_EditStringCancel.MouseEnter += new System.EventHandler(this.lbl_EditStringCancel_MouseEnter);
            this.lbl_EditStringCancel.MouseLeave += new System.EventHandler(this.lbl_EditStringCancel_MouseLeave);
            // 
            // lbl_EditStringOk
            // 
            // 
            // 
            // 
            this.lbl_EditStringOk.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_EditStringOk.BackgroundStyle.BorderBottomWidth = 1;
            this.lbl_EditStringOk.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_EditStringOk.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_EditStringOk.BackgroundStyle.BorderLeftWidth = 1;
            this.lbl_EditStringOk.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_EditStringOk.BackgroundStyle.BorderRightWidth = 1;
            this.lbl_EditStringOk.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_EditStringOk.BackgroundStyle.BorderTopWidth = 1;
            this.lbl_EditStringOk.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_EditStringOk.FocusCuesEnabled = true;
            this.lbl_EditStringOk.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_EditStringOk.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_EditStringOk.ImagePosition = DevComponents.DotNetBar.eImagePosition.Bottom;
            this.lbl_EditStringOk.Location = new System.Drawing.Point(-1, 138);
            this.lbl_EditStringOk.Name = "lbl_EditStringOk";
            this.lbl_EditStringOk.SingleLineColor = System.Drawing.Color.White;
            this.lbl_EditStringOk.Size = new System.Drawing.Size(154, 43);
            this.lbl_EditStringOk.TabIndex = 19;
            this.lbl_EditStringOk.Text = "保存";
            this.lbl_EditStringOk.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lbl_EditStringOk.Click += new System.EventHandler(this.lbl_EditStringOk_Click);
            this.lbl_EditStringOk.MouseEnter += new System.EventHandler(this.lbl_EditStringOk_MouseEnter);
            this.lbl_EditStringOk.MouseLeave += new System.EventHandler(this.lbl_EditStringOk_MouseLeave);
            // 
            // lbl_Title
            // 
            // 
            // 
            // 
            this.lbl_Title.BackgroundStyle.BorderBottomWidth = 1;
            this.lbl_Title.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_Title.BackgroundStyle.BorderLeftWidth = 1;
            this.lbl_Title.BackgroundStyle.BorderRightWidth = 1;
            this.lbl_Title.BackgroundStyle.BorderTopWidth = 1;
            this.lbl_Title.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_Title.FocusCuesEnabled = true;
            this.lbl_Title.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_Title.ImagePosition = DevComponents.DotNetBar.eImagePosition.Bottom;
            this.lbl_Title.Location = new System.Drawing.Point(0, 7);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.SingleLineColor = System.Drawing.Color.White;
            this.lbl_Title.Size = new System.Drawing.Size(301, 26);
            this.lbl_Title.TabIndex = 17;
            this.lbl_Title.Text = "编辑字符串参数";
            this.lbl_Title.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lbl_Title.WordWrap = true;
            // 
            // tb_StringParamValue
            // 
            this.tb_StringParamValue.BackColor = System.Drawing.SystemColors.Window;
            this.tb_StringParamValue.BorderColor = System.Drawing.Color.Gray;
            this.tb_StringParamValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_StringParamValue.Location = new System.Drawing.Point(109, 85);
            this.tb_StringParamValue.Name = "tb_StringParamValue";
            this.tb_StringParamValue.Size = new System.Drawing.Size(149, 21);
            this.tb_StringParamValue.TabIndex = 1;
            // 
            // Dlg_StringParamSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(300, 180);
            this.Controls.Add(this.tb_StringParamValue);
            this.Controls.Add(this.lbl_Tip);
            this.Controls.Add(this.lbl_ParamName);
            this.Controls.Add(this.lbl_Pwd);
            this.Controls.Add(this.lbl_ParamValue);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.tb_StringParamName);
            this.Controls.Add(this.lbl_EditStringCancel);
            this.Controls.Add(this.lbl_EditStringOk);
            this.Controls.Add(this.lbl_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dlg_StringParamSetting";
            this.Text = "Dlg_StringParamSetting";
            this.Load += new System.EventHandler(this.Dlg_StringParamSetting_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Dlg_StringParamSetting_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Dlg_StringParamSetting_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Dlg_StringParamSetting_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lbl_Tip;
        private DevComponents.DotNetBar.LabelX lbl_ParamName;
        private DevComponents.DotNetBar.LabelX lbl_Pwd;
        private DevComponents.DotNetBar.LabelX lbl_ParamValue;
        private frTextbox.frTextBox tb_Password;
        private frTextbox.frTextBox tb_StringParamName;
        private DevComponents.DotNetBar.LabelX lbl_EditStringCancel;
        private DevComponents.DotNetBar.LabelX lbl_EditStringOk;
        private DevComponents.DotNetBar.LabelX lbl_Title;
        private frTextbox.frTextBox tb_StringParamValue;
    }
}