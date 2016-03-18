namespace SocketClient
{
    partial class Client
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnContent = new System.Windows.Forms.Button();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.txtPonit = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnContent
            // 
            this.btnContent.Location = new System.Drawing.Point(370, 40);
            this.btnContent.Name = "btnContent";
            this.btnContent.Size = new System.Drawing.Size(75, 23);
            this.btnContent.TabIndex = 0;
            this.btnContent.Text = "连接";
            this.btnContent.UseVisualStyleBackColor = true;
            this.btnContent.Click += new System.EventHandler(this.btnContent_Click);
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(31, 42);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(126, 21);
            this.txtIp.TabIndex = 1;
            this.txtIp.Text = "192.168.1.202";
            // 
            // txtPonit
            // 
            this.txtPonit.Location = new System.Drawing.Point(173, 42);
            this.txtPonit.Name = "txtPonit";
            this.txtPonit.Size = new System.Drawing.Size(126, 21);
            this.txtPonit.TabIndex = 2;
            this.txtPonit.Text = "9050";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(31, 69);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(497, 146);
            this.txtLog.TabIndex = 3;
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(31, 235);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(497, 146);
            this.txtMsg.TabIndex = 4;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(370, 420);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 455);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtPonit);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.btnContent);
            this.Name = "Client";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnContent;
        private System.Windows.Forms.TextBox txtPonit;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtIp;
    }
}

