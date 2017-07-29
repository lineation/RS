namespace UniformUI.Frm
{
    partial class Dlg_BoolParamSetting
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
            this.lbl_Title = new DevComponents.DotNetBar.LabelX();
            this.lbl_EditBoolCancel = new DevComponents.DotNetBar.LabelX();
            this.lbl_EditBoolOk = new DevComponents.DotNetBar.LabelX();
            this.lbl_ParamName = new DevComponents.DotNetBar.LabelX();
            this.lbl_Pwd = new DevComponents.DotNetBar.LabelX();
            this.lbl_ParamValue = new DevComponents.DotNetBar.LabelX();
            this.tb_Password = new frTextbox.frTextBox();
            this.tb_BoolParamName = new frTextbox.frTextBox();
            this.switchButton_BoolValue = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.lbl_Tip = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
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
            this.lbl_Title.Location = new System.Drawing.Point(0, 9);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.SingleLineColor = System.Drawing.Color.White;
            this.lbl_Title.Size = new System.Drawing.Size(301, 26);
            this.lbl_Title.TabIndex = 7;
            this.lbl_Title.Text = "编辑布尔参数";
            this.lbl_Title.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lbl_Title.WordWrap = true;
            // 
            // lbl_EditBoolCancel
            // 
            // 
            // 
            // 
            this.lbl_EditBoolCancel.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_EditBoolCancel.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl_EditBoolCancel.BackgroundStyle.BorderBottomWidth = 1;
            this.lbl_EditBoolCancel.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_EditBoolCancel.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_EditBoolCancel.BackgroundStyle.BorderLeftWidth = 1;
            this.lbl_EditBoolCancel.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_EditBoolCancel.BackgroundStyle.BorderRightWidth = 1;
            this.lbl_EditBoolCancel.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_EditBoolCancel.BackgroundStyle.BorderTopWidth = 1;
            this.lbl_EditBoolCancel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_EditBoolCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_EditBoolCancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_EditBoolCancel.Location = new System.Drawing.Point(152, 140);
            this.lbl_EditBoolCancel.Name = "lbl_EditBoolCancel";
            this.lbl_EditBoolCancel.SingleLineColor = System.Drawing.Color.White;
            this.lbl_EditBoolCancel.Size = new System.Drawing.Size(149, 43);
            this.lbl_EditBoolCancel.SymbolColor = System.Drawing.Color.White;
            this.lbl_EditBoolCancel.TabIndex = 8;
            this.lbl_EditBoolCancel.Text = "取消";
            this.lbl_EditBoolCancel.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lbl_EditBoolCancel.Click += new System.EventHandler(this.lbl_EditBoolCancel_Click);
            this.lbl_EditBoolCancel.MouseEnter += new System.EventHandler(this.lbl_EditBoolCancel_MouseEnter);
            this.lbl_EditBoolCancel.MouseLeave += new System.EventHandler(this.lbl_EditBoolCancel_MouseLeave);
            // 
            // lbl_EditBoolOk
            // 
            // 
            // 
            // 
            this.lbl_EditBoolOk.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_EditBoolOk.BackgroundStyle.BorderBottomWidth = 1;
            this.lbl_EditBoolOk.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_EditBoolOk.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_EditBoolOk.BackgroundStyle.BorderLeftWidth = 1;
            this.lbl_EditBoolOk.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_EditBoolOk.BackgroundStyle.BorderRightWidth = 1;
            this.lbl_EditBoolOk.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_EditBoolOk.BackgroundStyle.BorderTopWidth = 1;
            this.lbl_EditBoolOk.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_EditBoolOk.FocusCuesEnabled = true;
            this.lbl_EditBoolOk.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_EditBoolOk.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_EditBoolOk.ImagePosition = DevComponents.DotNetBar.eImagePosition.Bottom;
            this.lbl_EditBoolOk.Location = new System.Drawing.Point(-1, 140);
            this.lbl_EditBoolOk.Name = "lbl_EditBoolOk";
            this.lbl_EditBoolOk.SingleLineColor = System.Drawing.Color.White;
            this.lbl_EditBoolOk.Size = new System.Drawing.Size(154, 43);
            this.lbl_EditBoolOk.TabIndex = 9;
            this.lbl_EditBoolOk.Text = "保存";
            this.lbl_EditBoolOk.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lbl_EditBoolOk.Click += new System.EventHandler(this.lbl_EditBoolOk_Click);
            this.lbl_EditBoolOk.MouseEnter += new System.EventHandler(this.lbl_EditBoolOk_MouseEnter);
            this.lbl_EditBoolOk.MouseLeave += new System.EventHandler(this.lbl_EditBoolOk_MouseLeave);
            // 
            // lbl_ParamName
            // 
            // 
            // 
            // 
            this.lbl_ParamName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_ParamName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ParamName.Location = new System.Drawing.Point(43, 60);
            this.lbl_ParamName.Name = "lbl_ParamName";
            this.lbl_ParamName.Size = new System.Drawing.Size(60, 23);
            this.lbl_ParamName.TabIndex = 12;
            this.lbl_ParamName.Text = "参数名称";
            // 
            // lbl_Pwd
            // 
            // 
            // 
            // 
            this.lbl_Pwd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_Pwd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Pwd.Location = new System.Drawing.Point(43, 110);
            this.lbl_Pwd.Name = "lbl_Pwd";
            this.lbl_Pwd.Size = new System.Drawing.Size(44, 23);
            this.lbl_Pwd.TabIndex = 13;
            this.lbl_Pwd.Text = "授权码";
            // 
            // lbl_ParamValue
            // 
            // 
            // 
            // 
            this.lbl_ParamValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_ParamValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ParamValue.Location = new System.Drawing.Point(43, 85);
            this.lbl_ParamValue.Name = "lbl_ParamValue";
            this.lbl_ParamValue.Size = new System.Drawing.Size(44, 23);
            this.lbl_ParamValue.TabIndex = 14;
            this.lbl_ParamValue.Text = "参数值";
            // 
            // tb_Password
            // 
            this.tb_Password.BorderColor = System.Drawing.Color.Gray;
            this.tb_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Password.Location = new System.Drawing.Point(109, 113);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.PasswordChar = '*';
            this.tb_Password.Size = new System.Drawing.Size(149, 21);
            this.tb_Password.TabIndex = 2;
            // 
            // tb_BoolParamName
            // 
            this.tb_BoolParamName.BackColor = System.Drawing.SystemColors.Window;
            this.tb_BoolParamName.BorderColor = System.Drawing.Color.Gray;
            this.tb_BoolParamName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_BoolParamName.Location = new System.Drawing.Point(109, 60);
            this.tb_BoolParamName.Name = "tb_BoolParamName";
            this.tb_BoolParamName.Size = new System.Drawing.Size(149, 21);
            this.tb_BoolParamName.TabIndex = 0;
            // 
            // switchButton_BoolValue
            // 
            // 
            // 
            // 
            this.switchButton_BoolValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_BoolValue.Location = new System.Drawing.Point(109, 86);
            this.switchButton_BoolValue.Name = "switchButton_BoolValue";
            this.switchButton_BoolValue.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(222)))), ((int)(((byte)(224)))));
            this.switchButton_BoolValue.OffTextColor = System.Drawing.Color.Black;
            this.switchButton_BoolValue.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.switchButton_BoolValue.OnTextColor = System.Drawing.Color.Black;
            this.switchButton_BoolValue.Size = new System.Drawing.Size(149, 22);
            this.switchButton_BoolValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_BoolValue.SwitchBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(204)))), ((int)(((byte)(234)))));
            this.switchButton_BoolValue.TabIndex = 1;
            // 
            // lbl_Tip
            // 
            // 
            // 
            // 
            this.lbl_Tip.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_Tip.ForeColor = System.Drawing.Color.Red;
            this.lbl_Tip.Location = new System.Drawing.Point(-1, 34);
            this.lbl_Tip.Name = "lbl_Tip";
            this.lbl_Tip.Size = new System.Drawing.Size(302, 20);
            this.lbl_Tip.TabIndex = 16;
            this.lbl_Tip.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // Dlg_BoolParamSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(300, 180);
            this.Controls.Add(this.lbl_Tip);
            this.Controls.Add(this.switchButton_BoolValue);
            this.Controls.Add(this.lbl_ParamName);
            this.Controls.Add(this.lbl_Pwd);
            this.Controls.Add(this.lbl_ParamValue);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.tb_BoolParamName);
            this.Controls.Add(this.lbl_EditBoolCancel);
            this.Controls.Add(this.lbl_EditBoolOk);
            this.Controls.Add(this.lbl_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dlg_BoolParamSetting";
            this.Text = "Dlg_BoolParamSetting";
            this.Load += new System.EventHandler(this.Dlg_BoolParamSetting_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Dlg_BoolParamSetting_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Dlg_BoolParamSetting_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Dlg_BoolParamSetting_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lbl_Title;
        private DevComponents.DotNetBar.LabelX lbl_EditBoolCancel;
        private DevComponents.DotNetBar.LabelX lbl_EditBoolOk;
        private DevComponents.DotNetBar.LabelX lbl_ParamName;
        private DevComponents.DotNetBar.LabelX lbl_Pwd;
        private DevComponents.DotNetBar.LabelX lbl_ParamValue;
        private frTextbox.frTextBox tb_Password;
        private frTextbox.frTextBox tb_BoolParamName;
        private DevComponents.DotNetBar.Controls.SwitchButton switchButton_BoolValue;
        private DevComponents.DotNetBar.LabelX lbl_Tip;
    }
}