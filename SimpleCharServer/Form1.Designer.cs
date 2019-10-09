namespace SimpleCharServer
{
    partial class FormServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormServer));
            this.sendContent = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tsTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.tsButton1 = new System.Windows.Forms.ToolStripButton();
            this.tsState = new System.Windows.Forms.ToolStripTextBox();
            this.charContent = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sendContent
            // 
            this.sendContent.ImeMode = System.Windows.Forms.ImeMode.On;
            this.sendContent.Location = new System.Drawing.Point(0, 186);
            this.sendContent.Multiline = true;
            this.sendContent.Name = "sendContent";
            this.sendContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sendContent.Size = new System.Drawing.Size(302, 75);
            this.sendContent.TabIndex = 6;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLabel2,
            this.tsTextBox2,
            this.tsButton1,
            this.tsState});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(384, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsLabel2
            // 
            this.tsLabel2.Name = "tsLabel2";
            this.tsLabel2.Size = new System.Drawing.Size(32, 22);
            this.tsLabel2.Text = "端口";
            // 
            // tsTextBox2
            // 
            this.tsTextBox2.MaxLength = 5;
            this.tsTextBox2.Name = "tsTextBox2";
            this.tsTextBox2.Size = new System.Drawing.Size(50, 25);
            this.tsTextBox2.Text = "888";
            this.tsTextBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tsTextBox2_KeyPress);
            // 
            // tsButton1
            // 
            this.tsButton1.Image = global::SimpleCharServer.Properties.Resources.一键启动_16_;
            this.tsButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton1.Name = "tsButton1";
            this.tsButton1.Size = new System.Drawing.Size(52, 22);
            this.tsButton1.Text = "启动";
            this.tsButton1.Click += new System.EventHandler(this.tsButton1_Click);
            // 
            // tsState
            // 
            this.tsState.Name = "tsState";
            this.tsState.ReadOnly = true;
            this.tsState.Size = new System.Drawing.Size(100, 25);
            // 
            // charContent
            // 
            this.charContent.Location = new System.Drawing.Point(0, 30);
            this.charContent.Multiline = true;
            this.charContent.Name = "charContent";
            this.charContent.ReadOnly = true;
            this.charContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.charContent.Size = new System.Drawing.Size(384, 150);
            this.charContent.TabIndex = 4;
            this.charContent.Text = "ˇˇˇ聊天内容ˇˇˇ\r\n";
            // 
            // sendButton
            // 
            this.sendButton.Image = global::SimpleCharServer.Properties.Resources.发送_32_;
            this.sendButton.Location = new System.Drawing.Point(309, 186);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 75);
            this.sendButton.TabIndex = 7;
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // FormServer
            // 
            this.AcceptButton = this.sendButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.sendContent);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.charContent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormServer";
            this.Text = "聊天么   ---kala服务器";
            this.Activated += new System.EventHandler(this.FormServer_Activated);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox sendContent;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tsLabel2;
        private System.Windows.Forms.ToolStripTextBox tsTextBox2;
        private System.Windows.Forms.ToolStripButton tsButton1;
        private System.Windows.Forms.TextBox charContent;
        private System.Windows.Forms.ToolStripTextBox tsState;
    }
}

