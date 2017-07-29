namespace UniformUI.Frm
{
    partial class Frm_Vision
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.stc_Vision = new DevComponents.DotNetBar.SuperTabControl();
            this.stcp_Vision = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.lbl_DeleteDevice = new DevComponents.DotNetBar.LabelX();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.lbl_AddDevice = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.dgv_VisionDeviceInfo = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column2 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Column3 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Column4 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Column5 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.stc_Device = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.stcp_Device = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.ep_Vision = new DevComponents.DotNetBar.ExpandablePanel();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.sti_Device = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superTabItem2 = new DevComponents.DotNetBar.SuperTabItem();
            ((System.ComponentModel.ISupportInitialize)(this.stc_Vision)).BeginInit();
            this.stc_Vision.SuspendLayout();
            this.stcp_Vision.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_VisionDeviceInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stc_Device)).BeginInit();
            this.stc_Device.SuspendLayout();
            this.ep_Vision.SuspendLayout();
            this.SuspendLayout();
            // 
            // stc_Vision
            // 
            this.stc_Vision.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            // 
            // 
            // 
            this.stc_Vision.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.stc_Vision.ControlBox.MenuBox.Name = "";
            this.stc_Vision.ControlBox.Name = "";
            this.stc_Vision.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.stc_Vision.ControlBox.MenuBox,
            this.stc_Vision.ControlBox.CloseBox});
            this.stc_Vision.Controls.Add(this.stcp_Vision);
            this.stc_Vision.Controls.Add(this.superTabControlPanel2);
            this.stc_Vision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stc_Vision.ForeColor = System.Drawing.Color.Black;
            this.stc_Vision.Location = new System.Drawing.Point(0, 0);
            this.stc_Vision.Name = "stc_Vision";
            this.stc_Vision.ReorderTabsEnabled = true;
            this.stc_Vision.SelectedTabFont = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold);
            this.stc_Vision.SelectedTabIndex = 0;
            this.stc_Vision.Size = new System.Drawing.Size(1366, 768);
            this.stc_Vision.TabFont = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stc_Vision.TabIndex = 0;
            this.stc_Vision.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.sti_Device,
            this.superTabItem2});
            this.stc_Vision.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.VisualStudio2008Document;
            this.stc_Vision.Text = "stc_Vision";
            // 
            // stcp_Vision
            // 
            this.stcp_Vision.Controls.Add(this.lbl_DeleteDevice);
            this.stcp_Vision.Controls.Add(this.labelX13);
            this.stcp_Vision.Controls.Add(this.labelX12);
            this.stcp_Vision.Controls.Add(this.lbl_AddDevice);
            this.stcp_Vision.Controls.Add(this.labelX10);
            this.stcp_Vision.Controls.Add(this.labelX11);
            this.stcp_Vision.Controls.Add(this.dgv_VisionDeviceInfo);
            this.stcp_Vision.Controls.Add(this.comboBox1);
            this.stcp_Vision.Controls.Add(this.comboBox2);
            this.stcp_Vision.Controls.Add(this.labelX7);
            this.stcp_Vision.Controls.Add(this.stc_Device);
            this.stcp_Vision.Controls.Add(this.ep_Vision);
            this.stcp_Vision.Controls.Add(this.comboBox3);
            this.stcp_Vision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stcp_Vision.Location = new System.Drawing.Point(0, 26);
            this.stcp_Vision.Name = "stcp_Vision";
            this.stcp_Vision.Size = new System.Drawing.Size(1366, 742);
            this.stcp_Vision.TabIndex = 1;
            this.stcp_Vision.TabItem = this.sti_Device;
            this.stcp_Vision.ThemeAware = true;
            // 
            // lbl_DeleteDevice
            // 
            this.lbl_DeleteDevice.BackColor = System.Drawing.SystemColors.ButtonFace;
            // 
            // 
            // 
            this.lbl_DeleteDevice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_DeleteDevice.Location = new System.Drawing.Point(1295, 145);
            this.lbl_DeleteDevice.Name = "lbl_DeleteDevice";
            this.lbl_DeleteDevice.Size = new System.Drawing.Size(52, 52);
            this.lbl_DeleteDevice.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.lbl_DeleteDevice.Symbol = "";
            this.lbl_DeleteDevice.SymbolSize = 30F;
            this.lbl_DeleteDevice.TabIndex = 6;
            this.lbl_DeleteDevice.Text = "  ";
            this.lbl_DeleteDevice.TextAlignment = System.Drawing.StringAlignment.Far;
            this.lbl_DeleteDevice.Click += new System.EventHandler(this.lbl_DeleteDevice_Click);
            this.lbl_DeleteDevice.MouseEnter += new System.EventHandler(this.lbl_DeleteDevice_MouseEnter);
            this.lbl_DeleteDevice.MouseLeave += new System.EventHandler(this.lbl_DeleteDevice_MouseLeave);
            // 
            // labelX13
            // 
            this.labelX13.BackColor = System.Drawing.SystemColors.ButtonFace;
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Location = new System.Drawing.Point(885, 27);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(52, 52);
            this.labelX13.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.labelX13.Symbol = "";
            this.labelX13.SymbolSize = 30F;
            this.labelX13.TabIndex = 7;
            this.labelX13.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX12
            // 
            this.labelX12.BackColor = System.Drawing.SystemColors.ButtonFace;
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Location = new System.Drawing.Point(819, 27);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(52, 52);
            this.labelX12.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.labelX12.Symbol = "";
            this.labelX12.SymbolSize = 30F;
            this.labelX12.TabIndex = 7;
            this.labelX12.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lbl_AddDevice
            // 
            this.lbl_AddDevice.BackColor = System.Drawing.SystemColors.ButtonFace;
            // 
            // 
            // 
            this.lbl_AddDevice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_AddDevice.Location = new System.Drawing.Point(1295, 80);
            this.lbl_AddDevice.Name = "lbl_AddDevice";
            this.lbl_AddDevice.Size = new System.Drawing.Size(52, 52);
            this.lbl_AddDevice.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.lbl_AddDevice.Symbol = "";
            this.lbl_AddDevice.SymbolSize = 30F;
            this.lbl_AddDevice.TabIndex = 7;
            this.lbl_AddDevice.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lbl_AddDevice.Click += new System.EventHandler(this.lbl_AddDevice_Click);
            this.lbl_AddDevice.MouseEnter += new System.EventHandler(this.lbl_AddDevice_MouseEnter);
            this.lbl_AddDevice.MouseLeave += new System.EventHandler(this.lbl_AddDevice_MouseLeave);
            // 
            // labelX10
            // 
            this.labelX10.BackColor = System.Drawing.SystemColors.ButtonFace;
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(1295, 275);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(52, 52);
            this.labelX10.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.labelX10.Symbol = "";
            this.labelX10.SymbolSize = 30F;
            this.labelX10.TabIndex = 8;
            this.labelX10.Text = "  ";
            this.labelX10.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX11
            // 
            this.labelX11.BackColor = System.Drawing.SystemColors.ButtonFace;
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Location = new System.Drawing.Point(1295, 210);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(52, 52);
            this.labelX11.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.labelX11.Symbol = "";
            this.labelX11.SymbolSize = 30F;
            this.labelX11.TabIndex = 9;
            this.labelX11.Text = "  ";
            this.labelX11.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // dgv_VisionDeviceInfo
            // 
            this.dgv_VisionDeviceInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_VisionDeviceInfo.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_VisionDeviceInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_VisionDeviceInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_VisionDeviceInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_VisionDeviceInfo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_VisionDeviceInfo.EnableHeadersVisualStyles = false;
            this.dgv_VisionDeviceInfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_VisionDeviceInfo.Location = new System.Drawing.Point(819, 80);
            this.dgv_VisionDeviceInfo.Name = "dgv_VisionDeviceInfo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_VisionDeviceInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_VisionDeviceInfo.RowHeadersVisible = false;
            this.dgv_VisionDeviceInfo.RowTemplate.Height = 23;
            this.dgv_VisionDeviceInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_VisionDeviceInfo.Size = new System.Drawing.Size(470, 566);
            this.dgv_VisionDeviceInfo.TabIndex = 5;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 21;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Column2.DataPropertyName = "ID";
            this.Column2.HeaderText = "Nr.";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Column2.Width = 23;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Column3.DataPropertyName = "Name";
            this.Column3.HeaderText = "Name";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Column3.Width = 23;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.DataPropertyName = "HardwareInfo";
            this.Column4.HeaderText = "HardwareInfo";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Column5.Checked = true;
            this.Column5.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Column5.CheckValue = null;
            this.Column5.HeaderText = "";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 17;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBox1.Location = new System.Drawing.Point(521, 621);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(277, 20);
            this.comboBox1.TabIndex = 4;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.comboBox2.Location = new System.Drawing.Point(1, 621);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(245, 20);
            this.comboBox2.TabIndex = 4;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(71, 598);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(731, 19);
            this.labelX7.TabIndex = 2;
            this.labelX7.Text = "labelX7";
            // 
            // stc_Device
            // 
            this.stc_Device.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            // 
            // 
            // 
            this.stc_Device.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.stc_Device.ControlBox.MenuBox.Name = "";
            this.stc_Device.ControlBox.Name = "";
            this.stc_Device.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.stc_Device.ControlBox.MenuBox,
            this.stc_Device.ControlBox.CloseBox});
            this.stc_Device.Controls.Add(this.superTabControlPanel1);
            this.stc_Device.Controls.Add(this.stcp_Device);
            this.stc_Device.ForeColor = System.Drawing.Color.Black;
            this.stc_Device.Location = new System.Drawing.Point(69, 8);
            this.stc_Device.Name = "stc_Device";
            this.stc_Device.ReorderTabsEnabled = true;
            this.stc_Device.SelectedTabFont = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold);
            this.stc_Device.SelectedTabIndex = 0;
            this.stc_Device.Size = new System.Drawing.Size(731, 587);
            this.stc_Device.TabFont = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stc_Device.TabIndex = 1;
            this.stc_Device.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
            this.stc_Device.Text = "superTabControl1";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(731, 587);
            this.superTabControlPanel1.TabIndex = 2;
            // 
            // stcp_Device
            // 
            this.stcp_Device.Cursor = System.Windows.Forms.Cursors.Default;
            this.stcp_Device.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.stcp_Device.Location = new System.Drawing.Point(0, 0);
            this.stcp_Device.Name = "stcp_Device";
            this.stcp_Device.Size = new System.Drawing.Size(731, 600);
            this.stcp_Device.TabIndex = 1;
            // 
            // ep_Vision
            // 
            this.ep_Vision.CanvasColor = System.Drawing.SystemColors.Control;
            this.ep_Vision.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft;
            this.ep_Vision.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ep_Vision.Controls.Add(this.labelX2);
            this.ep_Vision.Controls.Add(this.labelX6);
            this.ep_Vision.Controls.Add(this.labelX5);
            this.ep_Vision.Controls.Add(this.labelX4);
            this.ep_Vision.Controls.Add(this.labelX3);
            this.ep_Vision.Controls.Add(this.labelX1);
            this.ep_Vision.DisabledBackColor = System.Drawing.Color.Empty;
            this.ep_Vision.HideControlsWhenCollapsed = true;
            this.ep_Vision.Location = new System.Drawing.Point(0, 0);
            this.ep_Vision.Name = "ep_Vision";
            this.ep_Vision.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ep_Vision.Size = new System.Drawing.Size(66, 617);
            this.ep_Vision.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.ep_Vision.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.ep_Vision.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.ep_Vision.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.ep_Vision.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.ep_Vision.Style.GradientAngle = 90;
            this.ep_Vision.TabIndex = 0;
            this.ep_Vision.Text = "Tool";
            this.ep_Vision.ThemeAware = true;
            this.ep_Vision.TitleHeight = 20;
            this.ep_Vision.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.ep_Vision.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.ep_Vision.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.ep_Vision.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.ep_Vision.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.ep_Vision.TitleStyle.GradientAngle = 90;
            this.ep_Vision.TitleText = "Tool";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(4, 93);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(52, 52);
            this.labelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.labelX2.Symbol = "";
            this.labelX2.SymbolSize = 30F;
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "  ";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.SystemColors.ButtonFace;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(4, 28);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(52, 52);
            this.labelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.labelX6.Symbol = "";
            this.labelX6.SymbolSize = 30F;
            this.labelX6.TabIndex = 3;
            this.labelX6.Text = "  ";
            this.labelX6.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(4, 353);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(52, 52);
            this.labelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.labelX5.Symbol = "";
            this.labelX5.SymbolSize = 30F;
            this.labelX5.TabIndex = 3;
            this.labelX5.Text = "  ";
            this.labelX5.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(4, 288);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(52, 52);
            this.labelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.labelX4.Symbol = "";
            this.labelX4.SymbolSize = 30F;
            this.labelX4.TabIndex = 3;
            this.labelX4.Text = "  ";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(4, 223);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(52, 52);
            this.labelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.labelX3.Symbol = "";
            this.labelX3.SymbolSize = 30F;
            this.labelX3.TabIndex = 3;
            this.labelX3.Text = "  ";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(4, 158);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(52, 52);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.labelX1.Symbol = "";
            this.labelX1.SymbolSize = 30F;
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "  ";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.comboBox3.Location = new System.Drawing.Point(245, 621);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(278, 20);
            this.comboBox3.TabIndex = 4;
            // 
            // sti_Device
            // 
            this.sti_Device.AttachedControl = this.stcp_Vision;
            this.sti_Device.GlobalItem = false;
            this.sti_Device.Name = "sti_Device";
            this.sti_Device.Text = "Device";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 26);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(1366, 742);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.superTabItem2;
            // 
            // superTabItem2
            // 
            this.superTabItem2.AttachedControl = this.superTabControlPanel2;
            this.superTabItem2.GlobalItem = false;
            this.superTabItem2.Name = "superTabItem2";
            this.superTabItem2.Text = "superTabItem2";
            // 
            // Frm_Vision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.stc_Vision);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Vision";
            this.Text = "Frm_Vision";
            this.Load += new System.EventHandler(this.Frm_Vision_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stc_Vision)).EndInit();
            this.stc_Vision.ResumeLayout(false);
            this.stcp_Vision.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_VisionDeviceInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stc_Device)).EndInit();
            this.stc_Device.ResumeLayout(false);
            this.ep_Vision.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperTabControl stc_Vision;
        private DevComponents.DotNetBar.SuperTabControlPanel stcp_Vision;
        private DevComponents.DotNetBar.ExpandablePanel ep_Vision;
        private DevComponents.DotNetBar.SuperTabItem sti_Device;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabItem superTabItem2;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.SuperTabControl stc_Device;
        private DevComponents.DotNetBar.SuperTabControlPanel stcp_Device;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX lbl_DeleteDevice;
        private DevComponents.DotNetBar.LabelX lbl_AddDevice;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.LabelX labelX11;
        public DevComponents.DotNetBar.Controls.DataGridViewX dgv_VisionDeviceInfo;
        private DevComponents.DotNetBar.LabelX labelX13;
        private DevComponents.DotNetBar.LabelX labelX12;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Column2;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Column3;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Column4;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Column5;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;

    }
}