namespace UniformUI.Frm
{
    partial class Dlg_FloatAndIntParamsSetting
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
            this.tb_ParamName = new frTextbox.frTextBox();
            this.tb_ParamValue = new frTextbox.frTextBox();
            this.lbl_ParamValue = new DevComponents.DotNetBar.LabelX();
            this.lbl_ParamName = new DevComponents.DotNetBar.LabelX();
            this.tb_ParamValue_Max = new frTextbox.frTextBox();
            this.tb_ParamValue_Min = new frTextbox.frTextBox();
            this.lbl_ParamValue_Min = new DevComponents.DotNetBar.LabelX();
            this.lbl_ParamValue_Max = new DevComponents.DotNetBar.LabelX();
            this.lbl_Ok = new DevComponents.DotNetBar.LabelX();
            this.lbl_Cancel = new DevComponents.DotNetBar.LabelX();
            this.tb_Password = new frTextbox.frTextBox();
            this.lbl_Pwd = new DevComponents.DotNetBar.LabelX();
            this.lbl_Title = new DevComponents.DotNetBar.LabelX();
            this.lbl_Tip = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // tb_ParamName
            // 
            this.tb_ParamName.BackColor = System.Drawing.SystemColors.Window;
            this.tb_ParamName.BorderColor = System.Drawing.Color.Gray;
            this.tb_ParamName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ParamName.Location = new System.Drawing.Point(94, 77);
            this.tb_ParamName.Name = "tb_ParamName";
            this.tb_ParamName.Size = new System.Drawing.Size(149, 21);
            this.tb_ParamName.TabIndex = 0;
            // 
            // tb_ParamValue
            // 
            this.tb_ParamValue.AcceptsTab = true;
            this.tb_ParamValue.BorderColor = System.Drawing.Color.Gray;
            this.tb_ParamValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ParamValue.Location = new System.Drawing.Point(94, 111);
            this.tb_ParamValue.Name = "tb_ParamValue";
            this.tb_ParamValue.Size = new System.Drawing.Size(149, 21);
            this.tb_ParamValue.TabIndex = 1;
            this.tb_ParamValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_ParamValue_KeyPress);
            // 
            // lbl_ParamValue
            // 
            // 
            // 
            // 
            this.lbl_ParamValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_ParamValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ParamValue.Location = new System.Drawing.Point(28, 111);
            this.lbl_ParamValue.Name = "lbl_ParamValue";
            this.lbl_ParamValue.Size = new System.Drawing.Size(51, 23);
            this.lbl_ParamValue.TabIndex = 3;
            this.lbl_ParamValue.Text = "参数值";
            // 
            // lbl_ParamName
            // 
            // 
            // 
            // 
            this.lbl_ParamName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_ParamName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ParamName.Location = new System.Drawing.Point(28, 77);
            this.lbl_ParamName.Name = "lbl_ParamName";
            this.lbl_ParamName.Size = new System.Drawing.Size(60, 23);
            this.lbl_ParamName.TabIndex = 3;
            this.lbl_ParamName.Text = "参数名称";
            // 
            // tb_ParamValue_Max
            // 
            this.tb_ParamValue_Max.BorderColor = System.Drawing.Color.Gray;
            this.tb_ParamValue_Max.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ParamValue_Max.Location = new System.Drawing.Point(94, 145);
            this.tb_ParamValue_Max.Name = "tb_ParamValue_Max";
            this.tb_ParamValue_Max.Size = new System.Drawing.Size(149, 21);
            this.tb_ParamValue_Max.TabIndex = 2;
            this.tb_ParamValue_Max.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_ParamValue_Max_KeyPress);
            // 
            // tb_ParamValue_Min
            // 
            this.tb_ParamValue_Min.BorderColor = System.Drawing.Color.Gray;
            this.tb_ParamValue_Min.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ParamValue_Min.Location = new System.Drawing.Point(94, 179);
            this.tb_ParamValue_Min.Name = "tb_ParamValue_Min";
            this.tb_ParamValue_Min.Size = new System.Drawing.Size(149, 21);
            this.tb_ParamValue_Min.TabIndex = 3;
            this.tb_ParamValue_Min.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_ParamValue_Min_KeyPress);
            // 
            // lbl_ParamValue_Min
            // 
            // 
            // 
            // 
            this.lbl_ParamValue_Min.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_ParamValue_Min.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ParamValue_Min.Location = new System.Drawing.Point(28, 179);
            this.lbl_ParamValue_Min.Name = "lbl_ParamValue_Min";
            this.lbl_ParamValue_Min.Size = new System.Drawing.Size(51, 23);
            this.lbl_ParamValue_Min.TabIndex = 3;
            this.lbl_ParamValue_Min.Text = "最小值";
            // 
            // lbl_ParamValue_Max
            // 
            // 
            // 
            // 
            this.lbl_ParamValue_Max.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_ParamValue_Max.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ParamValue_Max.Location = new System.Drawing.Point(28, 145);
            this.lbl_ParamValue_Max.Name = "lbl_ParamValue_Max";
            this.lbl_ParamValue_Max.Size = new System.Drawing.Size(51, 23);
            this.lbl_ParamValue_Max.TabIndex = 3;
            this.lbl_ParamValue_Max.Text = "最大值";
            // 
            // lbl_Ok
            // 
            // 
            // 
            // 
            this.lbl_Ok.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_Ok.BackgroundStyle.BorderBottomWidth = 1;
            this.lbl_Ok.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_Ok.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_Ok.BackgroundStyle.BorderLeftWidth = 1;
            this.lbl_Ok.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_Ok.BackgroundStyle.BorderRightWidth = 1;
            this.lbl_Ok.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_Ok.BackgroundStyle.BorderTopWidth = 1;
            this.lbl_Ok.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_Ok.FocusCuesEnabled = true;
            this.lbl_Ok.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Ok.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_Ok.ImagePosition = DevComponents.DotNetBar.eImagePosition.Bottom;
            this.lbl_Ok.Location = new System.Drawing.Point(-1, 258);
            this.lbl_Ok.Name = "lbl_Ok";
            this.lbl_Ok.SingleLineColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_Ok.Size = new System.Drawing.Size(154, 43);
            this.lbl_Ok.TabIndex = 3;
            this.lbl_Ok.Text = "保存";
            this.lbl_Ok.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lbl_Ok.Click += new System.EventHandler(this.lbl_Ok_Click);
            this.lbl_Ok.MouseEnter += new System.EventHandler(this.lbl_Ok_MouseEnter);
            this.lbl_Ok.MouseLeave += new System.EventHandler(this.lbl_Ok_MouseLeave);
            // 
            // lbl_Cancel
            // 
            // 
            // 
            // 
            this.lbl_Cancel.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_Cancel.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl_Cancel.BackgroundStyle.BorderBottomWidth = 1;
            this.lbl_Cancel.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_Cancel.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_Cancel.BackgroundStyle.BorderLeftWidth = 1;
            this.lbl_Cancel.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_Cancel.BackgroundStyle.BorderRightWidth = 1;
            this.lbl_Cancel.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_Cancel.BackgroundStyle.BorderTopWidth = 1;
            this.lbl_Cancel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_Cancel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Cancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_Cancel.Location = new System.Drawing.Point(152, 258);
            this.lbl_Cancel.Name = "lbl_Cancel";
            this.lbl_Cancel.Size = new System.Drawing.Size(149, 43);
            this.lbl_Cancel.TabIndex = 3;
            this.lbl_Cancel.Text = "取消";
            this.lbl_Cancel.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lbl_Cancel.Click += new System.EventHandler(this.lbl_Cancel_Click);
            this.lbl_Cancel.MouseEnter += new System.EventHandler(this.lbl_Cancel_MouseEnter);
            this.lbl_Cancel.MouseLeave += new System.EventHandler(this.lbl_Cancel_MouseLeave);
            // 
            // tb_Password
            // 
            this.tb_Password.BorderColor = System.Drawing.Color.Gray;
            this.tb_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Password.Location = new System.Drawing.Point(94, 213);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.PasswordChar = '*';
            this.tb_Password.Size = new System.Drawing.Size(149, 21);
            this.tb_Password.TabIndex = 4;
            // 
            // lbl_Pwd
            // 
            // 
            // 
            // 
            this.lbl_Pwd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_Pwd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Pwd.Location = new System.Drawing.Point(28, 213);
            this.lbl_Pwd.Name = "lbl_Pwd";
            this.lbl_Pwd.Size = new System.Drawing.Size(51, 23);
            this.lbl_Pwd.TabIndex = 3;
            this.lbl_Pwd.Text = "授权码";
            // 
            // lbl_Title
            // 
            // 
            // 
            // 
            this.lbl_Title.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_Title.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_Title.Location = new System.Drawing.Point(-1, 16);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(302, 23);
            this.lbl_Title.TabIndex = 3;
            this.lbl_Title.Text = "新增浮点参数";
            this.lbl_Title.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lbl_Tip
            // 
            // 
            // 
            // 
            this.lbl_Tip.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_Tip.ForeColor = System.Drawing.Color.Red;
            this.lbl_Tip.Location = new System.Drawing.Point(-1, 40);
            this.lbl_Tip.Name = "lbl_Tip";
            this.lbl_Tip.Size = new System.Drawing.Size(302, 30);
            this.lbl_Tip.TabIndex = 4;
            this.lbl_Tip.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // Dlg_FloatandIntParamsSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.lbl_Tip);
            this.Controls.Add(this.lbl_ParamValue_Max);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.lbl_ParamName);
            this.Controls.Add(this.lbl_Pwd);
            this.Controls.Add(this.lbl_ParamValue_Min);
            this.Controls.Add(this.lbl_ParamValue);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.tb_ParamValue_Min);
            this.Controls.Add(this.tb_ParamValue_Max);
            this.Controls.Add(this.tb_ParamValue);
            this.Controls.Add(this.tb_ParamName);
            this.Controls.Add(this.lbl_Cancel);
            this.Controls.Add(this.lbl_Ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dlg_FloatandIntParamsSetting";
            this.Text = "Dialog_ParamsSetting";
            this.Load += new System.EventHandler(this.Dialog_ParamsSetting_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Dialog_ParamsSetting_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Dialog_ParamsSetting_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Dialog_ParamsSetting_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private frTextbox.frTextBox tb_ParamName;
        private frTextbox.frTextBox tb_ParamValue;
        private DevComponents.DotNetBar.LabelX lbl_ParamValue;
        private DevComponents.DotNetBar.LabelX lbl_ParamName;
        private frTextbox.frTextBox tb_ParamValue_Max;
        private frTextbox.frTextBox tb_ParamValue_Min;
        private DevComponents.DotNetBar.LabelX lbl_ParamValue_Min;
        private DevComponents.DotNetBar.LabelX lbl_ParamValue_Max;
        private DevComponents.DotNetBar.LabelX lbl_Ok;
        private DevComponents.DotNetBar.LabelX lbl_Cancel;
        private frTextbox.frTextBox tb_Password;
        private DevComponents.DotNetBar.LabelX lbl_Pwd;
        private DevComponents.DotNetBar.LabelX lbl_Tip;
        public DevComponents.DotNetBar.LabelX lbl_Title;

    }
}