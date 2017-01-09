//-----------------------------------------------------------------------
// <copyright file="FormMain.cs" company="RGS">
//     Copyright RGS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBMGR.Tools.HttpRequestTool
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Form main
    /// </summary>
    public partial class FormMain : Form
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the FormMain class.
        /// </summary>
        public FormMain()
        {
            this.InitializeComponent();
            this.cbContentType.SelectedIndex = 0;
        }
        #endregion

        #region UI Eveng
        /// <summary>
        /// Click event of button send.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rbGet.Checked)
                {
                    this.SendGetRequest();
                }
                else
                {
                    this.SendPostRequest();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Checked changed event of radio button POST.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void rbPost_CheckedChanged(object sender, EventArgs e)
        {
            this.cbContentType.Enabled = this.rbPost.Checked;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Send http request var get.
        /// </summary>
        private void SendGetRequest()
        {
            string url = this.txtURL.Text.Trim();
            string data = this.txtData.Text.Trim();
            if (!string.IsNullOrEmpty(data))
            {
                url += "?" + data;
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(responseStream, Encoding.UTF8);
            data = sr.ReadToEnd();
            responseStream.Close();
            response.Close();
            this.txtResponse.Text = data;
        }

        /// <summary>
        /// Send http request var post.
        /// </summary>
        private void SendPostRequest()
        {
            string url = this.txtURL.Text.Trim();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = this.cbContentType.SelectedItem.ToString();
            request.ContentLength = 0;
            string data = this.txtData.Text.Trim();
            if (!string.IsNullOrEmpty(data))
            {
                byte[] dataArray = Encoding.UTF8.GetBytes(data);
                request.ContentLength = dataArray.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(dataArray, 0, dataArray.Length);
                requestStream.Close();
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(responseStream, Encoding.UTF8);
            data = sr.ReadToEnd();
            responseStream.Close();
            response.Close();
            this.txtResponse.Text = data;
        }
        #endregion
    }
}