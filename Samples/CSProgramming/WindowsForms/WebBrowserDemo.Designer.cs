namespace WindowsForms
{
    partial class WebBrowserDemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebBrowserDemo));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tslBack = new System.Windows.Forms.ToolStripLabel();
            this.tslForward = new System.Windows.Forms.ToolStripLabel();
            this.tslHome = new System.Windows.Forms.ToolStripLabel();
            this.tslRefresh = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(569, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(543, 20);
            this.textBox1.TabIndex = 1;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(12, 56);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(632, 325);
            this.webBrowser1.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowItemReorder = true;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslBack,
            this.tslForward,
            this.tslHome,
            this.tslRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip1.Size = new System.Drawing.Size(656, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tslBack
            // 
            this.tslBack.Image = ((System.Drawing.Image)(resources.GetObject("tslBack.Image")));
            this.tslBack.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tslBack.Name = "tslBack";
            this.tslBack.Size = new System.Drawing.Size(45, 22);
            this.tslBack.Text = "Back";
            this.tslBack.Click += new System.EventHandler(this.tslBack_Click);
            // 
            // tslForward
            // 
            this.tslForward.Image = ((System.Drawing.Image)(resources.GetObject("tslForward.Image")));
            this.tslForward.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tslForward.Name = "tslForward";
            this.tslForward.Size = new System.Drawing.Size(63, 22);
            this.tslForward.Text = "Forward";
            this.tslForward.Click += new System.EventHandler(this.tslForward_Click);
            // 
            // tslHome
            // 
            this.tslHome.Image = ((System.Drawing.Image)(resources.GetObject("tslHome.Image")));
            this.tslHome.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tslHome.Name = "tslHome";
            this.tslHome.Size = new System.Drawing.Size(50, 22);
            this.tslHome.Text = "Home";
            this.tslHome.Click += new System.EventHandler(this.tslHome_Click);
            // 
            // tslRefresh
            // 
            this.tslRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tslRefresh.Image")));
            this.tslRefresh.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tslRefresh.Name = "tslRefresh";
            this.tslRefresh.Size = new System.Drawing.Size(61, 22);
            this.tslRefresh.Text = "Refresh";
            this.tslRefresh.Click += new System.EventHandler(this.tslRefresh_Click);
            // 
            // WebBrowserDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 396);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "WebBrowserDemo";
            this.Text = "WebBrowserDemo";
            this.Load += new System.EventHandler(this.WebBrowserDemo_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tslBack;
        private System.Windows.Forms.ToolStripLabel tslForward;
        private System.Windows.Forms.ToolStripLabel tslHome;
        private System.Windows.Forms.ToolStripLabel tslRefresh;
    }
}