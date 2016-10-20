using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace WebBrowserCourseworkForReal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Check if valid URI
            Uri uriResult;
            bool isUri = Uri.TryCreate(textBoxURL.Text, UriKind.Absolute, out uriResult)
                && uriResult.Scheme == Uri.UriSchemeHttp;

            // Do Request if valid URI
            if (isUri) {

                // Set up request object
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(textBoxURL.Text);

                HttpStatusCode responseStatusCode;

                // Try getting response
                try
                {
                    // Setup response object
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    
                    // Get the stream associated with the response.
                    Stream receiveStream = response.GetResponseStream();

                    // Pipes the stream to a higher level stream reader with the required encoding format. 
                    StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

                    // Get the status code
                    responseStatusCode = response.StatusCode;

                    // Send the stream to the RichTextBox1
                    richTextBoxHome.Text = "Response Code: "+(int)responseStatusCode+"\n-----------------\n"+readStream.ReadToEnd();

                    // Close response and stream
                    response.Close();
                    readStream.Close();
                }
                catch(WebException ex)
                {
                    if (ex.Status == WebExceptionStatus.ProtocolError)
                    {
                        var response = ex.Response as HttpWebResponse;
                        if (response != null)
                        {
                            richTextBoxHome.Text = "Response Code: " + (int)response.StatusCode + "\n--------------\nUnable to make a valid HTTP request, please check the URL";
                        }
                        else
                        {
                            // no http status code available
                            richTextBoxHome.Text = "No Response Code\n--------------\nUnable to make a valid HTTP request, please check the URL";
                        }
                    }
                    else
                    {
                        // no http status code available
                        richTextBoxHome.Text = "No Response Code\n--------------\nUnable to make a valid HTTP request, please check the URL";
                    }
                }
            }else
            {
                // In case URI is invalid
                richTextBoxHome.Text = "'"+textBoxURL.Text+"' is not a valid URL, Please enter a valid URL";
            }

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void setAsHomePageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string title = "TabPage " + (tabControl1.TabCount + 1).ToString();
            TabPage myTabPage = new TabPage(title);
            tabControl1.TabPages.Add(myTabPage);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
