namespace UniformUI.Frm
{
    partial class Dlg_AddDevice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dlg_AddDevice));
            this.lbl_Title = new DevComponents.DotNetBar.LabelX();
            this.lbl_AddDeviceCancel = new DevComponents.DotNetBar.LabelX();
            this.lbl_AddDeviceOk = new DevComponents.DotNetBar.LabelX();
            this.dgv_VisionDevice = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.lbl_SelectedInfo = new DevComponents.DotNetBar.LabelX();
            this.lbl_SelectedTip = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_VisionDevice)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Title
            // 
            this.lbl_Title.BackColor = System.Drawing.Color.LightSkyBlue;
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
            this.lbl_Title.Location = new System.Drawing.Point(-8, 0);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.SingleLineColor = System.Drawing.Color.White;
            this.lbl_Title.Size = new System.Drawing.Size(301, 26);
            this.lbl_Title.TabIndex = 8;
            this.lbl_Title.Text = "Add Device";
            this.lbl_Title.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lbl_Title.WordWrap = true;
            this.lbl_Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_Title_MouseDown);
            this.lbl_Title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_Title_MouseMove);
            // 
            // lbl_AddDeviceCancel
            // 
            // 
            // 
            // 
            this.lbl_AddDeviceCancel.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_AddDeviceCancel.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl_AddDeviceCancel.BackgroundStyle.BorderBottomWidth = 1;
            this.lbl_AddDeviceCancel.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_AddDeviceCancel.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_AddDeviceCancel.BackgroundStyle.BorderLeftWidth = 1;
            this.lbl_AddDeviceCancel.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_AddDeviceCancel.BackgroundStyle.BorderRightWidth = 1;
            this.lbl_AddDeviceCancel.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_AddDeviceCancel.BackgroundStyle.BorderTopWidth = 1;
            this.lbl_AddDeviceCancel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_AddDeviceCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_AddDeviceCancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_AddDeviceCancel.Location = new System.Drawing.Point(145, 281);
            this.lbl_AddDeviceCancel.Name = "lbl_AddDeviceCancel";
            this.lbl_AddDeviceCancel.SingleLineColor = System.Drawing.Color.White;
            this.lbl_AddDeviceCancel.Size = new System.Drawing.Size(149, 43);
            this.lbl_AddDeviceCancel.SymbolColor = System.Drawing.Color.White;
            this.lbl_AddDeviceCancel.TabIndex = 10;
            this.lbl_AddDeviceCancel.Text = "取消";
            this.lbl_AddDeviceCancel.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lbl_AddDeviceCancel.Click += new System.EventHandler(this.lbl_AddDeviceCancel_Click);
            this.lbl_AddDeviceCancel.MouseEnter += new System.EventHandler(this.lbl_AddDeviceCancel_MouseEnter);
            this.lbl_AddDeviceCancel.MouseLeave += new System.EventHandler(this.lbl_AddDeviceCancel_MouseLeave);
            // 
            // lbl_AddDeviceOk
            // 
            // 
            // 
            // 
            this.lbl_AddDeviceOk.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_AddDeviceOk.BackgroundStyle.BorderBottomWidth = 1;
            this.lbl_AddDeviceOk.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_AddDeviceOk.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_AddDeviceOk.BackgroundStyle.BorderLeftWidth = 1;
            this.lbl_AddDeviceOk.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_AddDeviceOk.BackgroundStyle.BorderRightWidth = 1;
            this.lbl_AddDeviceOk.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lbl_AddDeviceOk.BackgroundStyle.BorderTopWidth = 1;
            this.lbl_AddDeviceOk.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_AddDeviceOk.FocusCuesEnabled = true;
            this.lbl_AddDeviceOk.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_AddDeviceOk.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_AddDeviceOk.ImagePosition = DevComponents.DotNetBar.eImagePosition.Bottom;
            this.lbl_AddDeviceOk.Location = new System.Drawing.Point(-8, 281);
            this.lbl_AddDeviceOk.Name = "lbl_AddDeviceOk";
            this.lbl_AddDeviceOk.SingleLineColor = System.Drawing.Color.White;
            this.lbl_AddDeviceOk.Size = new System.Drawing.Size(154, 43);
            this.lbl_AddDeviceOk.TabIndex = 11;
            this.lbl_AddDeviceOk.Text = "保存";
            this.lbl_AddDeviceOk.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lbl_AddDeviceOk.Click += new System.EventHandler(this.lbl_AddDeviceOk_Click);
            this.lbl_AddDeviceOk.MouseEnter += new System.EventHandler(this.lbl_AddDeviceOk_MouseEnter);
            this.lbl_AddDeviceOk.MouseLeave += new System.EventHandler(this.lbl_AddDeviceOk_MouseLeave);
            // 
            // dgv_VisionDevice
            // 
            this.dgv_VisionDevice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_VisionDevice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_VisionDevice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_VisionDevice.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_VisionDevice.EnableHeadersVisualStyles = false;
            this.dgv_VisionDevice.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_VisionDevice.Location = new System.Drawing.Point(1, 35);
            this.dgv_VisionDevice.Name = "dgv_VisionDevice";
            this.dgv_VisionDevice.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_VisionDevice.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_VisionDevice.RowHeadersVisible = false;
            this.dgv_VisionDevice.RowTemplate.Height = 23;
            this.dgv_VisionDevice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_VisionDevice.Size = new System.Drawing.Size(283, 213);
            this.dgv_VisionDevice.TabIndex = 0;
            this.dgv_VisionDevice.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_VisionDevice_CellContentClick);
            // 
            // lbl_SelectedInfo
            // 
            // 
            // 
            // 
            this.lbl_SelectedInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_SelectedInfo.Location = new System.Drawing.Point(49, 253);
            this.lbl_SelectedInfo.Name = "lbl_SelectedInfo";
            this.lbl_SelectedInfo.Size = new System.Drawing.Size(235, 23);
            this.lbl_SelectedInfo.TabIndex = 12;
            // 
            // lbl_SelectedTip
            // 
            // 
            // 
            // 
            this.lbl_SelectedTip.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_SelectedTip.Location = new System.Drawing.Point(1, 255);
            this.lbl_SelectedTip.Name = "lbl_SelectedTip";
            this.lbl_SelectedTip.Size = new System.Drawing.Size(50, 23);
            this.lbl_SelectedTip.TabIndex = 13;
            this.lbl_SelectedTip.Text = "选中：";
            // 
            // Dlg_AddDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(286, 323);
            this.Controls.Add(this.lbl_SelectedTip);
            this.Controls.Add(this.lbl_SelectedInfo);
            this.Controls.Add(this.lbl_AddDeviceCancel);
            this.Controls.Add(this.lbl_AddDeviceOk);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.dgv_VisionDevice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dlg_AddDevice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add  Device";
            this.Load += new System.EventHandler(this.Dlg_AddDevice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_VisionDevice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lbl_Title;
        private DevComponents.DotNetBar.LabelX lbl_AddDeviceCancel;
        private DevComponents.DotNetBar.LabelX lbl_AddDeviceOk;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_VisionDevice;
        private DevComponents.DotNetBar.LabelX lbl_SelectedInfo;
        private DevComponents.DotNetBar.LabelX lbl_SelectedTip;
    }
}