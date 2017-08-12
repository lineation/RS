namespace UniformUI.RSControl
{
    partial class UILog
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtLogMsg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtLogMsg
            // 
            this.txtLogMsg.Location = new System.Drawing.Point(0, 0);
            this.txtLogMsg.Multiline = true;
            this.txtLogMsg.Name = "txtLogMsg";
            this.txtLogMsg.Size = new System.Drawing.Size(150, 150);
            this.txtLogMsg.TabIndex = 0;
            this.txtLogMsg.TextChanged += new System.EventHandler(this.txtLogMsg_TextChanged);
            // 
            // UILog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtLogMsg);
            this.Name = "UILog";
            this.Load += new System.EventHandler(this.UILog_Load);
            this.ClientSizeChanged += new System.EventHandler(this.UILog_ClientSizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLogMsg;
    }
}
