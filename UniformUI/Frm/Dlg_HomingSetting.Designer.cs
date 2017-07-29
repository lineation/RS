namespace UniformUI.Frm
{
    partial class Dlg_HomingSetting
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
            this.tb_AxisNum = new frTextbox.frTextBox();
            this.lbl_Tip = new DevComponents.DotNetBar.LabelX();
            this.lbl_AxisName = new DevComponents.DotNetBar.LabelX();
            this.lbl_Pwd = new DevComponents.DotNetBar.LabelX();
            this.lbl_AxisNum = new DevComponents.DotNetBar.LabelX();
            this.tb_Password = new frTextbox.frTextBox();
            this.tb_StringParamName = new frTextbox.frTextBox();
            this.lbl_EditHomingCancel = new DevComponents.DotNetBar.LabelX();
            this.lbl_EditHomingOk = new DevComponents.DotNetBar.LabelX();
            this.lbl_Title = new DevComponents.DotNetBar.LabelX();
            this.cb_AxisName = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lbl_lead = new DevComponents.DotNetBar.LabelX();
            this.lbl_HomingMode = new DevComponents.DotNetBar.LabelX();
            this.cb_HomingMode = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbi_HomingModeORG = new DevComponents.Editors.ComboItem();
            this.cbi_HomingModeEL = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.cb_AxisNum = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbi_0 = new DevComponents.Editors.ComboItem();
            this.cbi_1 = new DevComponents.Editors.ComboItem();
            this.cbi_2 = new DevComponents.Editors.ComboItem();
            this.cbi_3 = new DevComponents.Editors.ComboItem();
            this.cbi_4 = new DevComponents.Editors.ComboItem();
            this.cbi_5 = new DevComponents.Editors.ComboItem();
            this.cbi_6 = new DevComponents.Editors.ComboItem();
            this.cbi_7 = new DevComponents.Editors.ComboItem();
            this.lbl_HomingDirection = new DevComponents.DotNetBar.LabelX();
            this.cb_HomingDirection = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.HomingDir_Positive = new DevComponents.Editors.ComboItem();
            this.HomingDir_Negative = new DevComponents.Editors.ComboItem();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbi_Enable = new DevComponents.Editors.ComboItem();
            this.cbi_Disable = new DevComponents.Editors.ComboItem();
            this.lbl_HomingCurve = new DevComponents.DotNetBar.LabelX();
            this.cb_HomingCurve = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbi_S_Curve = new DevComponents.Editors.ComboItem();
            this.cbi_T_Curve = new DevComponents.Editors.ComboItem();
            this.lbl_HomingVelocity = new DevComponents.DotNetBar.LabelX();
            this.tb__HomingVelocity = new frTextbox.frTextBox();
            this.lbl_AccAndDec = new DevComponents.DotNetBar.LabelX();
            this.tb_AccAndDec = new frTextbox.frTextBox();
            this.lbl_HomeOffset = new DevComponents.DotNetBar.LabelX();
            this.tb_HomeOffset = new frTextbox.frTextBox();
            this.lbl_HomingOrder = new DevComponents.DotNetBar.LabelX();
            this.tb_HomingOrder = new frTextbox.frTextBox();
            this.SuspendLayout();
            // 
            // tb_AxisNum
            // 
            this.tb_AxisNum.BackColor = System.Drawing.SystemColors.Window;
            this.tb_AxisNum.BorderColor = System.Drawing.Color.Gray;
            this.tb_AxisNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_AxisNum.Location = new System.Drawing.Point(121, 105);
            this.tb_AxisNum.Name = "tb_AxisNum";
            this.tb_AxisNum.Size = new System.Drawing.Size(149, 21);
            this.tb_AxisNum.TabIndex = 28;
            // 
            // lbl_Tip
            // 
            // 
            // 
            // 
            this.lbl_Tip.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_Tip.ForeColor = System.Drawing.Color.Red;
            this.lbl_Tip.Location = new System.Drawing.Point(-1, 44);
            this.lbl_Tip.Name = "lbl_Tip";
            this.lbl_Tip.Size = new System.Drawing.Size(302, 16);
            this.lbl_Tip.TabIndex = 36;
            this.lbl_Tip.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lbl_AxisName
            // 
            // 
            // 
            // 
            this.lbl_AxisName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_AxisName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_AxisName.Location = new System.Drawing.Point(22, 76);
            this.lbl_AxisName.Name = "lbl_AxisName";
            this.lbl_AxisName.Size = new System.Drawing.Size(60, 23);
            this.lbl_AxisName.TabIndex = 33;
            this.lbl_AxisName.Text = "轴名称";
            // 
            // lbl_Pwd
            // 
            // 
            // 
            // 
            this.lbl_Pwd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_Pwd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Pwd.Location = new System.Drawing.Point(22, 379);
            this.lbl_Pwd.Name = "lbl_Pwd";
            this.lbl_Pwd.Size = new System.Drawing.Size(44, 23);
            this.lbl_Pwd.TabIndex = 34;
            this.lbl_Pwd.Text = "授权码";
            // 
            // lbl_AxisNum
            // 
            // 
            // 
            // 
            this.lbl_AxisNum.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_AxisNum.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_AxisNum.Location = new System.Drawing.Point(22, 105);
            this.lbl_AxisNum.Name = "lbl_AxisNum";
            this.lbl_AxisNum.Size = new System.Drawing.Size(44, 23);
            this.lbl_AxisNum.TabIndex = 35;
            this.lbl_AxisNum.Text = "轴号";
            // 
            // tb_Password
            // 
            this.tb_Password.BorderColor = System.Drawing.Color.Gray;
            this.tb_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Password.Location = new System.Drawing.Point(120, 379);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.PasswordChar = '*';
            this.tb_Password.Size = new System.Drawing.Size(149, 21);
            this.tb_Password.TabIndex = 29;
            // 
            // tb_StringParamName
            // 
            this.tb_StringParamName.BackColor = System.Drawing.SystemColors.Window;
            this.tb_StringParamName.BorderColor = System.Drawing.Color.Gray;
            this.tb_StringParamName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_StringParamName.Location = new System.Drawing.Point(121, 132);
            this.tb_StringParamName.Name = "tb_StringParamName";
            this.tb_StringParamName.Size = new System.Drawing.Size(149, 21);
            this.tb_StringParamName.TabIndex = 27;
            // 
            // lbl_EditHomingCancel
            // 
            // 
            // 
            // 
            this.lbl_EditHomingCancel.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_EditHomingCancel.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl_EditHomingCancel.BackgroundStyle.BorderBottomWidth = 1;
            this.lbl_EditHomingCancel.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_EditHomingCancel.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_EditHomingCancel.BackgroundStyle.BorderLeftWidth = 1;
            this.lbl_EditHomingCancel.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_EditHomingCancel.BackgroundStyle.BorderRightWidth = 1;
            this.lbl_EditHomingCancel.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_EditHomingCancel.BackgroundStyle.BorderTopWidth = 1;
            this.lbl_EditHomingCancel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_EditHomingCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_EditHomingCancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_EditHomingCancel.Location = new System.Drawing.Point(152, 422);
            this.lbl_EditHomingCancel.Name = "lbl_EditHomingCancel";
            this.lbl_EditHomingCancel.SingleLineColor = System.Drawing.Color.White;
            this.lbl_EditHomingCancel.Size = new System.Drawing.Size(149, 43);
            this.lbl_EditHomingCancel.SymbolColor = System.Drawing.Color.White;
            this.lbl_EditHomingCancel.TabIndex = 31;
            this.lbl_EditHomingCancel.Text = "取消";
            this.lbl_EditHomingCancel.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lbl_EditHomingCancel.Click += new System.EventHandler(this.lbl_EditHomingCancel_Click);
            this.lbl_EditHomingCancel.MouseEnter += new System.EventHandler(this.lbl_EditHomingCancel_MouseEnter);
            this.lbl_EditHomingCancel.MouseLeave += new System.EventHandler(this.lbl_EditHomingCancel_MouseLeave);
            // 
            // lbl_EditHomingOk
            // 
            // 
            // 
            // 
            this.lbl_EditHomingOk.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_EditHomingOk.BackgroundStyle.BorderBottomWidth = 1;
            this.lbl_EditHomingOk.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_EditHomingOk.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_EditHomingOk.BackgroundStyle.BorderLeftWidth = 1;
            this.lbl_EditHomingOk.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_EditHomingOk.BackgroundStyle.BorderRightWidth = 1;
            this.lbl_EditHomingOk.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_EditHomingOk.BackgroundStyle.BorderTopWidth = 1;
            this.lbl_EditHomingOk.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_EditHomingOk.FocusCuesEnabled = true;
            this.lbl_EditHomingOk.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_EditHomingOk.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_EditHomingOk.ImagePosition = DevComponents.DotNetBar.eImagePosition.Bottom;
            this.lbl_EditHomingOk.Location = new System.Drawing.Point(-1, 422);
            this.lbl_EditHomingOk.Name = "lbl_EditHomingOk";
            this.lbl_EditHomingOk.SingleLineColor = System.Drawing.Color.White;
            this.lbl_EditHomingOk.Size = new System.Drawing.Size(154, 43);
            this.lbl_EditHomingOk.TabIndex = 32;
            this.lbl_EditHomingOk.Text = "保存";
            this.lbl_EditHomingOk.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lbl_EditHomingOk.Click += new System.EventHandler(this.lbl_EditHomingOk_Click);
            this.lbl_EditHomingOk.MouseEnter += new System.EventHandler(this.lbl_EditHomingOk_MouseEnter);
            this.lbl_EditHomingOk.MouseLeave += new System.EventHandler(this.lbl_EditHomingOk_MouseLeave);
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
            this.lbl_Title.Location = new System.Drawing.Point(-1, 6);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.SingleLineColor = System.Drawing.Color.White;
            this.lbl_Title.Size = new System.Drawing.Size(301, 26);
            this.lbl_Title.TabIndex = 30;
            this.lbl_Title.Text = "编辑字符串参数";
            this.lbl_Title.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lbl_Title.WordWrap = true;
            // 
            // cb_AxisName
            // 
            this.cb_AxisName.DisplayMember = "Text";
            this.cb_AxisName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_AxisName.DropDownColumnsHeaders = "X\r\nY\r\nZ\r\nR";
            this.cb_AxisName.FormattingEnabled = true;
            this.cb_AxisName.ItemHeight = 15;
            this.cb_AxisName.Location = new System.Drawing.Point(121, 76);
            this.cb_AxisName.Name = "cb_AxisName";
            this.cb_AxisName.Size = new System.Drawing.Size(69, 21);
            this.cb_AxisName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_AxisName.TabIndex = 39;
            // 
            // lbl_lead
            // 
            // 
            // 
            // 
            this.lbl_lead.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_lead.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_lead.Location = new System.Drawing.Point(21, 132);
            this.lbl_lead.Name = "lbl_lead";
            this.lbl_lead.Size = new System.Drawing.Size(44, 23);
            this.lbl_lead.TabIndex = 40;
            this.lbl_lead.Text = "导程";
            // 
            // lbl_HomingMode
            // 
            // 
            // 
            // 
            this.lbl_HomingMode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_HomingMode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_HomingMode.Location = new System.Drawing.Point(21, 161);
            this.lbl_HomingMode.Name = "lbl_HomingMode";
            this.lbl_HomingMode.Size = new System.Drawing.Size(73, 23);
            this.lbl_HomingMode.TabIndex = 33;
            this.lbl_HomingMode.Text = "回原点模式";
            // 
            // cb_HomingMode
            // 
            this.cb_HomingMode.DisplayMember = "Text";
            this.cb_HomingMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_HomingMode.DropDownColumnsHeaders = "X\r\nY\r\nZ\r\nR";
            this.cb_HomingMode.FormattingEnabled = true;
            this.cb_HomingMode.ItemHeight = 15;
            this.cb_HomingMode.Items.AddRange(new object[] {
            this.cbi_HomingModeORG,
            this.cbi_HomingModeEL,
            this.comboItem3});
            this.cb_HomingMode.Location = new System.Drawing.Point(121, 159);
            this.cb_HomingMode.Name = "cb_HomingMode";
            this.cb_HomingMode.Size = new System.Drawing.Size(148, 21);
            this.cb_HomingMode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_HomingMode.TabIndex = 39;
            // 
            // cbi_HomingModeORG
            // 
            this.cbi_HomingModeORG.Text = "HOME_MODE_ORG";
            // 
            // cbi_HomingModeEL
            // 
            this.cbi_HomingModeEL.Text = "HOME_MODE_EL";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "comboItem3";
            // 
            // cb_AxisNum
            // 
            this.cb_AxisNum.DisplayMember = "Text";
            this.cb_AxisNum.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_AxisNum.DropDownColumnsHeaders = "X\r\nY\r\nZ\r\nR";
            this.cb_AxisNum.FormattingEnabled = true;
            this.cb_AxisNum.ItemHeight = 15;
            this.cb_AxisNum.Items.AddRange(new object[] {
            this.cbi_0,
            this.cbi_1,
            this.cbi_2,
            this.cbi_3,
            this.cbi_4,
            this.cbi_5,
            this.cbi_6,
            this.cbi_7});
            this.cb_AxisNum.Location = new System.Drawing.Point(200, 76);
            this.cb_AxisNum.Name = "cb_AxisNum";
            this.cb_AxisNum.Size = new System.Drawing.Size(69, 21);
            this.cb_AxisNum.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_AxisNum.TabIndex = 39;
            // 
            // cbi_0
            // 
            this.cbi_0.Text = "0";
            // 
            // cbi_1
            // 
            this.cbi_1.Text = "1";
            // 
            // cbi_2
            // 
            this.cbi_2.Text = "2";
            // 
            // cbi_3
            // 
            this.cbi_3.Text = "3";
            // 
            // cbi_4
            // 
            this.cbi_4.Text = "4";
            // 
            // cbi_5
            // 
            this.cbi_5.Text = "5";
            // 
            // cbi_6
            // 
            this.cbi_6.Text = "6";
            // 
            // cbi_7
            // 
            this.cbi_7.Text = "7";
            // 
            // lbl_HomingDirection
            // 
            // 
            // 
            // 
            this.lbl_HomingDirection.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_HomingDirection.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_HomingDirection.Location = new System.Drawing.Point(21, 186);
            this.lbl_HomingDirection.Name = "lbl_HomingDirection";
            this.lbl_HomingDirection.Size = new System.Drawing.Size(94, 23);
            this.lbl_HomingDirection.TabIndex = 33;
            this.lbl_HomingDirection.Text = "回原点搜索方向";
            // 
            // cb_HomingDirection
            // 
            this.cb_HomingDirection.DisplayMember = "Text";
            this.cb_HomingDirection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_HomingDirection.DropDownColumnsHeaders = "X\r\nY\r\nZ\r\nR";
            this.cb_HomingDirection.FormattingEnabled = true;
            this.cb_HomingDirection.ItemHeight = 15;
            this.cb_HomingDirection.Items.AddRange(new object[] {
            this.HomingDir_Positive,
            this.HomingDir_Negative});
            this.cb_HomingDirection.Location = new System.Drawing.Point(121, 186);
            this.cb_HomingDirection.Name = "cb_HomingDirection";
            this.cb_HomingDirection.Size = new System.Drawing.Size(148, 21);
            this.cb_HomingDirection.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_HomingDirection.TabIndex = 39;
            // 
            // HomingDir_Positive
            // 
            this.HomingDir_Positive.Text = "Positive";
            // 
            // HomingDir_Negative
            // 
            this.HomingDir_Negative.Text = "Negative";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(21, 211);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(94, 23);
            this.labelX1.TabIndex = 33;
            this.labelX1.Text = "回原点Z相信号";
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.DisplayMember = "Text";
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.DropDownColumnsHeaders = "X\r\nY\r\nZ\r\nR";
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ItemHeight = 15;
            this.comboBoxEx1.Items.AddRange(new object[] {
            this.cbi_Enable,
            this.cbi_Disable});
            this.comboBoxEx1.Location = new System.Drawing.Point(121, 213);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(148, 21);
            this.comboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx1.TabIndex = 39;
            // 
            // cbi_Enable
            // 
            this.cbi_Enable.Text = "Enable";
            // 
            // cbi_Disable
            // 
            this.cbi_Disable.Text = "Disable";
            // 
            // lbl_HomingCurve
            // 
            // 
            // 
            // 
            this.lbl_HomingCurve.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_HomingCurve.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_HomingCurve.Location = new System.Drawing.Point(21, 240);
            this.lbl_HomingCurve.Name = "lbl_HomingCurve";
            this.lbl_HomingCurve.Size = new System.Drawing.Size(94, 23);
            this.lbl_HomingCurve.TabIndex = 33;
            this.lbl_HomingCurve.Text = "回原点曲线";
            // 
            // cb_HomingCurve
            // 
            this.cb_HomingCurve.DisplayMember = "Text";
            this.cb_HomingCurve.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_HomingCurve.DropDownColumnsHeaders = "X\r\nY\r\nZ\r\nR";
            this.cb_HomingCurve.FormattingEnabled = true;
            this.cb_HomingCurve.ItemHeight = 15;
            this.cb_HomingCurve.Items.AddRange(new object[] {
            this.cbi_S_Curve,
            this.cbi_T_Curve});
            this.cb_HomingCurve.Location = new System.Drawing.Point(121, 240);
            this.cb_HomingCurve.Name = "cb_HomingCurve";
            this.cb_HomingCurve.Size = new System.Drawing.Size(148, 21);
            this.cb_HomingCurve.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_HomingCurve.TabIndex = 39;
            // 
            // cbi_S_Curve
            // 
            this.cbi_S_Curve.Text = "S_Curve";
            // 
            // cbi_T_Curve
            // 
            this.cbi_T_Curve.Text = "T_curve";
            // 
            // lbl_HomingVelocity
            // 
            // 
            // 
            // 
            this.lbl_HomingVelocity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_HomingVelocity.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_HomingVelocity.Location = new System.Drawing.Point(22, 267);
            this.lbl_HomingVelocity.Name = "lbl_HomingVelocity";
            this.lbl_HomingVelocity.Size = new System.Drawing.Size(72, 23);
            this.lbl_HomingVelocity.TabIndex = 35;
            this.lbl_HomingVelocity.Text = "回原点速度";
            // 
            // tb__HomingVelocity
            // 
            this.tb__HomingVelocity.BackColor = System.Drawing.SystemColors.Window;
            this.tb__HomingVelocity.BorderColor = System.Drawing.Color.Gray;
            this.tb__HomingVelocity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb__HomingVelocity.Location = new System.Drawing.Point(121, 267);
            this.tb__HomingVelocity.Name = "tb__HomingVelocity";
            this.tb__HomingVelocity.Size = new System.Drawing.Size(149, 21);
            this.tb__HomingVelocity.TabIndex = 28;
            // 
            // lbl_AccAndDec
            // 
            // 
            // 
            // 
            this.lbl_AccAndDec.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_AccAndDec.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_AccAndDec.Location = new System.Drawing.Point(22, 294);
            this.lbl_AccAndDec.Name = "lbl_AccAndDec";
            this.lbl_AccAndDec.Size = new System.Drawing.Size(80, 23);
            this.lbl_AccAndDec.TabIndex = 35;
            this.lbl_AccAndDec.Text = "回原点加减速";
            // 
            // tb_AccAndDec
            // 
            this.tb_AccAndDec.BackColor = System.Drawing.SystemColors.Window;
            this.tb_AccAndDec.BorderColor = System.Drawing.Color.Gray;
            this.tb_AccAndDec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_AccAndDec.Location = new System.Drawing.Point(121, 294);
            this.tb_AccAndDec.Name = "tb_AccAndDec";
            this.tb_AccAndDec.Size = new System.Drawing.Size(149, 21);
            this.tb_AccAndDec.TabIndex = 28;
            // 
            // lbl_HomeOffset
            // 
            // 
            // 
            // 
            this.lbl_HomeOffset.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_HomeOffset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_HomeOffset.Location = new System.Drawing.Point(21, 321);
            this.lbl_HomeOffset.Name = "lbl_HomeOffset";
            this.lbl_HomeOffset.Size = new System.Drawing.Size(80, 23);
            this.lbl_HomeOffset.TabIndex = 35;
            this.lbl_HomeOffset.Text = "原点偏移";
            // 
            // tb_HomeOffset
            // 
            this.tb_HomeOffset.BackColor = System.Drawing.SystemColors.Window;
            this.tb_HomeOffset.BorderColor = System.Drawing.Color.Gray;
            this.tb_HomeOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_HomeOffset.Location = new System.Drawing.Point(120, 321);
            this.tb_HomeOffset.Name = "tb_HomeOffset";
            this.tb_HomeOffset.Size = new System.Drawing.Size(149, 21);
            this.tb_HomeOffset.TabIndex = 28;
            // 
            // lbl_HomingOrder
            // 
            // 
            // 
            // 
            this.lbl_HomingOrder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_HomingOrder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_HomingOrder.Location = new System.Drawing.Point(21, 350);
            this.lbl_HomingOrder.Name = "lbl_HomingOrder";
            this.lbl_HomingOrder.Size = new System.Drawing.Size(80, 23);
            this.lbl_HomingOrder.TabIndex = 35;
            this.lbl_HomingOrder.Text = "回原点顺序";
            // 
            // tb_HomingOrder
            // 
            this.tb_HomingOrder.BackColor = System.Drawing.SystemColors.Window;
            this.tb_HomingOrder.BorderColor = System.Drawing.Color.Gray;
            this.tb_HomingOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_HomingOrder.Location = new System.Drawing.Point(120, 350);
            this.tb_HomingOrder.Name = "tb_HomingOrder";
            this.tb_HomingOrder.Size = new System.Drawing.Size(149, 21);
            this.tb_HomingOrder.TabIndex = 28;
            // 
            // Dlg_HomingSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(300, 460);
            this.Controls.Add(this.lbl_lead);
            this.Controls.Add(this.cb_HomingCurve);
            this.Controls.Add(this.comboBoxEx1);
            this.Controls.Add(this.cb_HomingDirection);
            this.Controls.Add(this.cb_HomingMode);
            this.Controls.Add(this.cb_AxisNum);
            this.Controls.Add(this.cb_AxisName);
            this.Controls.Add(this.tb_HomingOrder);
            this.Controls.Add(this.tb_HomeOffset);
            this.Controls.Add(this.tb_AccAndDec);
            this.Controls.Add(this.tb__HomingVelocity);
            this.Controls.Add(this.tb_AxisNum);
            this.Controls.Add(this.lbl_HomingCurve);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.lbl_HomingDirection);
            this.Controls.Add(this.lbl_HomingMode);
            this.Controls.Add(this.lbl_HomingOrder);
            this.Controls.Add(this.lbl_HomeOffset);
            this.Controls.Add(this.lbl_Tip);
            this.Controls.Add(this.lbl_AccAndDec);
            this.Controls.Add(this.lbl_AxisName);
            this.Controls.Add(this.lbl_HomingVelocity);
            this.Controls.Add(this.lbl_Pwd);
            this.Controls.Add(this.lbl_AxisNum);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.tb_StringParamName);
            this.Controls.Add(this.lbl_EditHomingCancel);
            this.Controls.Add(this.lbl_EditHomingOk);
            this.Controls.Add(this.lbl_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dlg_HomingSetting";
            this.Text = "Dlg_HomingSetting";
            this.Load += new System.EventHandler(this.Dlg_HomingSetting_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Dlg_HomingSetting_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private frTextbox.frTextBox tb_AxisNum;
        private DevComponents.DotNetBar.LabelX lbl_Tip;
        private DevComponents.DotNetBar.LabelX lbl_AxisName;
        private DevComponents.DotNetBar.LabelX lbl_Pwd;
        private DevComponents.DotNetBar.LabelX lbl_AxisNum;
        private frTextbox.frTextBox tb_Password;
        private frTextbox.frTextBox tb_StringParamName;
        private DevComponents.DotNetBar.LabelX lbl_EditHomingCancel;
        private DevComponents.DotNetBar.LabelX lbl_EditHomingOk;
        private DevComponents.DotNetBar.LabelX lbl_Title;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cb_AxisName;
        private DevComponents.DotNetBar.LabelX lbl_lead;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX lbl_HomingMode;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cb_HomingMode;
        private DevComponents.Editors.ComboItem cbi_HomingModeORG;
        private DevComponents.Editors.ComboItem cbi_HomingModeEL;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cb_AxisNum;
        private DevComponents.Editors.ComboItem cbi_0;
        private DevComponents.Editors.ComboItem cbi_1;
        private DevComponents.Editors.ComboItem cbi_2;
        private DevComponents.Editors.ComboItem cbi_3;
        private DevComponents.Editors.ComboItem cbi_4;
        private DevComponents.Editors.ComboItem cbi_5;
        private DevComponents.Editors.ComboItem cbi_6;
        private DevComponents.Editors.ComboItem cbi_7;
        private DevComponents.DotNetBar.LabelX lbl_HomingDirection;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cb_HomingDirection;
        private DevComponents.Editors.ComboItem HomingDir_Positive;
        private DevComponents.Editors.ComboItem HomingDir_Negative;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx1;
        private DevComponents.Editors.ComboItem cbi_Enable;
        private DevComponents.Editors.ComboItem cbi_Disable;
        private DevComponents.DotNetBar.LabelX lbl_HomingCurve;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cb_HomingCurve;
        private DevComponents.Editors.ComboItem cbi_S_Curve;
        private DevComponents.Editors.ComboItem cbi_T_Curve;
        private DevComponents.DotNetBar.LabelX lbl_HomingVelocity;
        private frTextbox.frTextBox tb__HomingVelocity;
        private DevComponents.DotNetBar.LabelX lbl_AccAndDec;
        private frTextbox.frTextBox tb_AccAndDec;
        private DevComponents.DotNetBar.LabelX lbl_HomeOffset;
        private frTextbox.frTextBox tb_HomeOffset;
        private DevComponents.DotNetBar.LabelX lbl_HomingOrder;
        private frTextbox.frTextBox tb_HomingOrder;
    }
}