//-----------------------------------------------------------------------
// <copyright file="FormMain.cs" company="RGS">
//     Copyright RGS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBMGR.Tools.HttpRequestTool
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Form main
    /// </summary>
    public partial class FormMain : Form
    {
        /// <summary>
        /// Http heads.
        /// </summary>
        private BindingList<HeadItem> heads;

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the FormMain class.
        /// </summary>
        public FormMain()
        {
            this.InitializeComponent();
            this.cbContentType.SelectedIndex = 0;
            this.heads = new BindingList<HeadItem>();
            this.dgvHead.DataSource = heads;
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
                this.txtResponse.Text = string.Empty;
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

            int length = this.txtURL.Text.Length;
            if (length >= 7)
            {
                this.txtURL.Select(7, length - 7);
            }

            this.txtURL.Focus();
        }

        /// <summary>
        /// Key press event of textbox url.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void txtURL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.btnSend_Click(sender, e);
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

        /// <summary>
        /// Add head item into request.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void btnAddHead_Click(object sender, EventArgs e)
        {
            this.dgvHead.DataSource = null;
            this.heads.Add(new HeadItem());
            this.dgvHead.DataSource = this.heads;
        }

        /// <summary>
        /// Remove a head item from request.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void brnRemoveHead_Click(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = this.dgvHead.CurrentRow;
            if (currentRow != null)
            {
                int index = this.dgvHead.CurrentRow.Index;
                this.dgvHead.DataSource = null;
                this.heads.RemoveAt(index);
                this.dgvHead.DataSource = this.heads;
            }
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
            request = AddHeadItems(request);
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
            request = AddHeadItems(request);
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

        /// <summary>
        /// Add head item to http request.
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>request</returns>
        private HttpWebRequest AddHeadItems(HttpWebRequest request)
        {
            foreach(HeadItem head in this.heads)
            {
                string key = head.Key;
                string value = head.Value;
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    request.Headers.Add(head.Key, head.Value);
                }
            }

            return request;
        }
        #endregion
    }
}