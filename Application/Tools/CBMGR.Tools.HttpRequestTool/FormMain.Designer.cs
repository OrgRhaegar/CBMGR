//-----------------------------------------------------------------------
// <copyright file="FormMain.Designer.cs" company="RGS">
//     Copyright RGS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBMGR.Tools.HttpRequestTool
{
    /// <summary>
    /// Main form designer
    /// </summary>
    public partial class FormMain
    {
        private System.Windows.Forms.Label lbURL;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lbMethod;
        private System.Windows.Forms.GroupBox gbMethod;
        private System.Windows.Forms.RadioButton rbPost;
        private System.Windows.Forms.RadioButton rbGet;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label lbData;
        private System.Windows.Forms.TextBox txtCookie;
        private System.Windows.Forms.Label lbCookie;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.Label lbResponse;
        private System.Windows.Forms.Label lbContentType;
        private System.Windows.Forms.ComboBox cbContentType;

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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.lbURL = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lbMethod = new System.Windows.Forms.Label();
            this.gbMethod = new System.Windows.Forms.GroupBox();
            this.rbPost = new System.Windows.Forms.RadioButton();
            this.rbGet = new System.Windows.Forms.RadioButton();
            this.txtData = new System.Windows.Forms.TextBox();
            this.lbData = new System.Windows.Forms.Label();
            this.txtCookie = new System.Windows.Forms.TextBox();
            this.lbCookie = new System.Windows.Forms.Label();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.lbResponse = new System.Windows.Forms.Label();
            this.lbContentType = new System.Windows.Forms.Label();
            this.cbContentType = new System.Windows.Forms.ComboBox();
            this.gbMethod.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbURL
            // 
            this.lbURL.AutoSize = true;
            this.lbURL.Location = new System.Drawing.Point(38, 9);
            this.lbURL.Name = "lbURL";
            this.lbURL.Size = new System.Drawing.Size(32, 13);
            this.lbURL.TabIndex = 0;
            this.lbURL.Text = "URL:";
            // 
            // txtURL
            // 
            this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtURL.Location = new System.Drawing.Point(76, 6);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(462, 20);
            this.txtURL.TabIndex = 1;
            this.txtURL.Text = "http://";
            this.txtURL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtURL_KeyPress);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(544, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(50, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lbMethod
            // 
            this.lbMethod.AutoSize = true;
            this.lbMethod.Location = new System.Drawing.Point(24, 44);
            this.lbMethod.Name = "lbMethod";
            this.lbMethod.Size = new System.Drawing.Size(46, 13);
            this.lbMethod.TabIndex = 3;
            this.lbMethod.Text = "Method:";
            // 
            // gbMethod
            // 
            this.gbMethod.Controls.Add(this.rbPost);
            this.gbMethod.Controls.Add(this.rbGet);
            this.gbMethod.Location = new System.Drawing.Point(76, 32);
            this.gbMethod.Name = "gbMethod";
            this.gbMethod.Size = new System.Drawing.Size(173, 36);
            this.gbMethod.TabIndex = 4;
            this.gbMethod.TabStop = false;
            this.gbMethod.Text = "Request method";
            // 
            // rbPost
            // 
            this.rbPost.AutoSize = true;
            this.rbPost.Location = new System.Drawing.Point(98, 12);
            this.rbPost.Name = "rbPost";
            this.rbPost.Size = new System.Drawing.Size(54, 17);
            this.rbPost.TabIndex = 10;
            this.rbPost.Text = "POST";
            this.rbPost.UseVisualStyleBackColor = true;
            this.rbPost.CheckedChanged += new System.EventHandler(this.rbPost_CheckedChanged);
            // 
            // rbGet
            // 
            this.rbGet.AutoSize = true;
            this.rbGet.Checked = true;
            this.rbGet.Location = new System.Drawing.Point(22, 12);
            this.rbGet.Name = "rbGet";
            this.rbGet.Size = new System.Drawing.Size(47, 17);
            this.rbGet.TabIndex = 5;
            this.rbGet.TabStop = true;
            this.rbGet.Text = "GET";
            this.rbGet.UseVisualStyleBackColor = true;
            // 
            // txtData
            // 
            this.txtData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtData.Location = new System.Drawing.Point(76, 74);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(518, 96);
            this.txtData.TabIndex = 15;
            // 
            // lbData
            // 
            this.lbData.AutoSize = true;
            this.lbData.Location = new System.Drawing.Point(37, 77);
            this.lbData.Name = "lbData";
            this.lbData.Size = new System.Drawing.Size(33, 13);
            this.lbData.TabIndex = 6;
            this.lbData.Text = "Data:";
            // 
            // txtCookie
            // 
            this.txtCookie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCookie.Location = new System.Drawing.Point(76, 176);
            this.txtCookie.Multiline = true;
            this.txtCookie.Name = "txtCookie";
            this.txtCookie.Size = new System.Drawing.Size(518, 96);
            this.txtCookie.TabIndex = 20;
            // 
            // lbCookie
            // 
            this.lbCookie.AutoSize = true;
            this.lbCookie.Location = new System.Drawing.Point(27, 179);
            this.lbCookie.Name = "lbCookie";
            this.lbCookie.Size = new System.Drawing.Size(43, 13);
            this.lbCookie.TabIndex = 8;
            this.lbCookie.Text = "Cookie:";
            // 
            // txtResponse
            // 
            this.txtResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponse.Location = new System.Drawing.Point(76, 278);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ReadOnly = true;
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResponse.Size = new System.Drawing.Size(518, 250);
            this.txtResponse.TabIndex = 9;
            this.txtResponse.TabStop = false;
            // 
            // lbResponse
            // 
            this.lbResponse.AutoSize = true;
            this.lbResponse.Location = new System.Drawing.Point(12, 281);
            this.lbResponse.Name = "lbResponse";
            this.lbResponse.Size = new System.Drawing.Size(58, 13);
            this.lbResponse.TabIndex = 10;
            this.lbResponse.Text = "Response:";
            // 
            // lbContentType
            // 
            this.lbContentType.AutoSize = true;
            this.lbContentType.Location = new System.Drawing.Point(255, 44);
            this.lbContentType.Name = "lbContentType";
            this.lbContentType.Size = new System.Drawing.Size(71, 13);
            this.lbContentType.TabIndex = 11;
            this.lbContentType.Text = "ContentType:";
            // 
            // cbContentType
            // 
            this.cbContentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbContentType.Enabled = false;
            this.cbContentType.FormattingEnabled = true;
            this.cbContentType.Items.AddRange(new object[] {
            "application/x-www-form-urlencoded",
            "application/json",
            "application/xml",
            "application/octet-stream"});
            this.cbContentType.Location = new System.Drawing.Point(332, 41);
            this.cbContentType.Name = "cbContentType";
            this.cbContentType.Size = new System.Drawing.Size(206, 21);
            this.cbContentType.TabIndex = 12;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 540);
            this.Controls.Add(this.cbContentType);
            this.Controls.Add(this.lbContentType);
            this.Controls.Add(this.lbResponse);
            this.Controls.Add(this.txtResponse);
            this.Controls.Add(this.lbCookie);
            this.Controls.Add(this.txtCookie);
            this.Controls.Add(this.lbData);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.gbMethod);
            this.Controls.Add(this.lbMethod);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.lbURL);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Http Request Test";
            this.gbMethod.ResumeLayout(false);
            this.gbMethod.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}