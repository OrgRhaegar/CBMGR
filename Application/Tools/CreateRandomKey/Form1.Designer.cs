namespace CreateRandomKey
{
    partial class Form1
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
            this.cbLowChar = new System.Windows.Forms.CheckBox();
            this.gbChars = new System.Windows.Forms.GroupBox();
            this.cbUpChars = new System.Windows.Forms.CheckBox();
            this.cbNumbers = new System.Windows.Forms.CheckBox();
            this.cbSpecChars = new System.Windows.Forms.CheckBox();
            this.cbOther = new System.Windows.Forms.CheckBox();
            this.txtOther = new System.Windows.Forms.TextBox();
            this.lbLength = new System.Windows.Forms.Label();
            this.tblength = new System.Windows.Forms.TrackBar();
            this.udLength = new System.Windows.Forms.NumericUpDown();
            this.lbResult = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnGener = new System.Windows.Forms.Button();
            this.gbChars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLength)).BeginInit();
            this.SuspendLayout();
            // 
            // cbLowChar
            // 
            this.cbLowChar.AutoSize = true;
            this.cbLowChar.Checked = true;
            this.cbLowChar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLowChar.Location = new System.Drawing.Point(17, 19);
            this.cbLowChar.Name = "cbLowChar";
            this.cbLowChar.Size = new System.Drawing.Size(236, 17);
            this.cbLowChar.TabIndex = 0;
            this.cbLowChar.Text = "a b c d e f g h i j k l m n o p q r s t u v w x y z";
            this.cbLowChar.UseVisualStyleBackColor = true;
            // 
            // gbChars
            // 
            this.gbChars.Controls.Add(this.txtOther);
            this.gbChars.Controls.Add(this.cbOther);
            this.gbChars.Controls.Add(this.cbSpecChars);
            this.gbChars.Controls.Add(this.cbNumbers);
            this.gbChars.Controls.Add(this.cbUpChars);
            this.gbChars.Controls.Add(this.cbLowChar);
            this.gbChars.Location = new System.Drawing.Point(10, 10);
            this.gbChars.Name = "gbChars";
            this.gbChars.Size = new System.Drawing.Size(410, 153);
            this.gbChars.TabIndex = 1;
            this.gbChars.TabStop = false;
            this.gbChars.Text = "Chars";
            // 
            // cbUpChars
            // 
            this.cbUpChars.AutoSize = true;
            this.cbUpChars.Checked = true;
            this.cbUpChars.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUpChars.Location = new System.Drawing.Point(17, 44);
            this.cbUpChars.Name = "cbUpChars";
            this.cbUpChars.Size = new System.Drawing.Size(289, 17);
            this.cbUpChars.TabIndex = 1;
            this.cbUpChars.Text = "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z";
            this.cbUpChars.UseVisualStyleBackColor = true;
            // 
            // cbNumbers
            // 
            this.cbNumbers.AutoSize = true;
            this.cbNumbers.Checked = true;
            this.cbNumbers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNumbers.Location = new System.Drawing.Point(17, 67);
            this.cbNumbers.Name = "cbNumbers";
            this.cbNumbers.Size = new System.Drawing.Size(113, 17);
            this.cbNumbers.TabIndex = 2;
            this.cbNumbers.Text = "1 2 3 4 5 6 7 8 9 0";
            this.cbNumbers.UseVisualStyleBackColor = true;
            // 
            // cbSpecChars
            // 
            this.cbSpecChars.AutoSize = true;
            this.cbSpecChars.Checked = true;
            this.cbSpecChars.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSpecChars.Location = new System.Drawing.Point(17, 92);
            this.cbSpecChars.Name = "cbSpecChars";
            this.cbSpecChars.Size = new System.Drawing.Size(104, 17);
            this.cbSpecChars.TabIndex = 3;
            this.cbSpecChars.Text = "! @ # $ % ^ & * ( )";
            this.cbSpecChars.UseVisualStyleBackColor = true;
            // 
            // cbOther
            // 
            this.cbOther.AutoSize = true;
            this.cbOther.Location = new System.Drawing.Point(17, 117);
            this.cbOther.Name = "cbOther";
            this.cbOther.Size = new System.Drawing.Size(52, 17);
            this.cbOther.TabIndex = 4;
            this.cbOther.Text = "Other";
            this.cbOther.UseVisualStyleBackColor = true;
            this.cbOther.CheckedChanged += new System.EventHandler(this.cbOther_CheckedChanged);
            // 
            // txtOther
            // 
            this.txtOther.Enabled = false;
            this.txtOther.Location = new System.Drawing.Point(75, 114);
            this.txtOther.Name = "txtOther";
            this.txtOther.Size = new System.Drawing.Size(231, 20);
            this.txtOther.TabIndex = 5;
            // 
            // lbLength
            // 
            this.lbLength.AutoSize = true;
            this.lbLength.Location = new System.Drawing.Point(12, 173);
            this.lbLength.Name = "lbLength";
            this.lbLength.Size = new System.Drawing.Size(43, 13);
            this.lbLength.TabIndex = 2;
            this.lbLength.Text = "Length:";
            // 
            // tblength
            // 
            this.tblength.Location = new System.Drawing.Point(113, 169);
            this.tblength.Maximum = 128;
            this.tblength.Minimum = 8;
            this.tblength.Name = "tblength";
            this.tblength.Size = new System.Drawing.Size(311, 42);
            this.tblength.TabIndex = 3;
            this.tblength.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tblength.Value = 32;
            this.tblength.ValueChanged += new System.EventHandler(this.tblength_ValueChanged);
            // 
            // udLength
            // 
            this.udLength.Location = new System.Drawing.Point(61, 169);
            this.udLength.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.udLength.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.udLength.Name = "udLength";
            this.udLength.Size = new System.Drawing.Size(46, 20);
            this.udLength.TabIndex = 4;
            this.udLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udLength.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.udLength.ValueChanged += new System.EventHandler(this.udLength_ValueChanged);
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Location = new System.Drawing.Point(12, 198);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(40, 13);
            this.lbResult.TabIndex = 5;
            this.lbResult.Text = "Result:";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(10, 217);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(410, 101);
            this.txtResult.TabIndex = 6;
            // 
            // btnGener
            // 
            this.btnGener.Location = new System.Drawing.Point(297, 324);
            this.btnGener.Name = "btnGener";
            this.btnGener.Size = new System.Drawing.Size(123, 23);
            this.btnGener.TabIndex = 7;
            this.btnGener.Text = "Generate and copy";
            this.btnGener.UseVisualStyleBackColor = true;
            this.btnGener.Click += new System.EventHandler(this.btnGener_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 355);
            this.Controls.Add(this.btnGener);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.lbResult);
            this.Controls.Add(this.udLength);
            this.Controls.Add(this.tblength);
            this.Controls.Add(this.lbLength);
            this.Controls.Add(this.gbChars);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Key Generator";
            this.gbChars.ResumeLayout(false);
            this.gbChars.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbLowChar;
        private System.Windows.Forms.GroupBox gbChars;
        private System.Windows.Forms.TextBox txtOther;
        private System.Windows.Forms.CheckBox cbOther;
        private System.Windows.Forms.CheckBox cbSpecChars;
        private System.Windows.Forms.CheckBox cbNumbers;
        private System.Windows.Forms.CheckBox cbUpChars;
        private System.Windows.Forms.Label lbLength;
        private System.Windows.Forms.TrackBar tblength;
        private System.Windows.Forms.NumericUpDown udLength;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnGener;
    }
}

