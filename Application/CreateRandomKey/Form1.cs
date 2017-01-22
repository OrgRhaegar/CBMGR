using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateRandomKey
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Form event
        private void btnGener_Click(object sender, EventArgs e)
        {
            string keyStr = this.GetKeyCharString();
            if (keyStr.Length > 0)
            {
                char[] keyArray = keyStr.ToArray<char>();
                int charLength = keyArray.Length;
                int keyLenth = this.tblength.Value;
                Random ran = new Random(DateTime.Now.Millisecond);
                StringBuilder keyBuider = new StringBuilder();
                int index = -1;
                for (int i = 0; i < keyLenth; i++)
                {
                    index = ran.Next(charLength);
                    keyBuider.Append(keyArray[index]);
                }

                keyStr = keyBuider.ToString();
                this.txtResult.Text = keyStr;
                Clipboard.SetDataObject(keyStr);
            }
            else
            {
                this.ShowInfo("Please select chars use to generate key.");
            }
        }

        private void cbOther_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbOther.Checked)
            {
                this.txtOther.Enabled = true;
                this.txtOther.Focus();
            }
            else
            {
                this.txtOther.Enabled = false;
            }
        }

        private void udLength_ValueChanged(object sender, EventArgs e)
        {
            this.tblength.Value = (int)this.udLength.Value;
        }

        private void tblength_ValueChanged(object sender, EventArgs e)
        {
            this.udLength.Value = this.tblength.Value;
        }
        #endregion

        #region private method
        private string GetKeyCharString()
        {
            StringBuilder keyBuider = new StringBuilder();
            if (this.cbLowChar.Checked)
            {
                keyBuider.Append("abcdefghijklmnopqrstuvwxyz");
            }

            if (this.cbNumbers.Checked)
            {
                keyBuider.Append("1234567890");
            }

            if (this.cbUpChars.Checked)
            {
                keyBuider.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            }

            if (this.cbSpecChars.Checked)
            {
                keyBuider.Append("!@#$%^&*()");
            }

            string otherStr = this.txtOther.Text.Trim();
            if (this.cbOther.Checked && otherStr.Length > 0)
            {
                keyBuider.Append(otherStr);
            }

            string keyStr = keyBuider.ToString();
            return keyStr;
        }

        private void ShowInfo(string text)
        {
            MessageBox.Show(text, "SysInfo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
}