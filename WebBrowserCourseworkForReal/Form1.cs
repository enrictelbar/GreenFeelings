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
using Newtonsoft.Json;

namespace WebBrowserCourseworkForReal
{
    public partial class Form1 : Form
    {
        // Setup the userdata variable which will have homepage, bookmarks and history
        static dynamic userdata;

        public Form1()
        {
            InitializeComponent();

            // Check if file exists for userdata.json, which contains all user settings for the browser
            if (!File.Exists("userdata.json"))
            {
                // Create and write to file if file doesn't exists 
                File.WriteAllText("userdata.json", "{\"homepage\":\"http://www.google.com\",\"bookmarks\":[],\"history\":[]}");
            }

            using (StreamReader r = new StreamReader("userdata.json"))
            {
                // Read json data to the userdata variable
                string jsonText = r.ReadToEnd();
                r.Close();
                userdata = JsonConvert.DeserializeObject(jsonText);
            }

            // Load up homepage
            textBoxURL.Text = userdata.homepage;
            
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

            // Get the 0th control (it is suppose to be richTextBox) of the current Tab
            RichTextBox selectedRichTextBox = (RichTextBox)tabControl1.SelectedTab.Controls[0];

            // Do Request if valid URI
            if (isUri) {

                // Set up request object
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(textBoxURL.Text);

                HttpStatusCode responseStatusCode;

                // Try getting response
                try
                {
                    // Set current tab name to URL name
                    tabControl1.SelectedTab.Text = textBoxURL.Text;

                    // Setup response object
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    
                    // Get the stream associated with the response.
                    Stream receiveStream = response.GetResponseStream();

                    // Pipes the stream to a higher level stream reader with the required encoding format. 
                    StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

                    // Get the status code
                    responseStatusCode = response.StatusCode;

                    // Send the stream to the RichTextBox1
                    selectedRichTextBox.Text = "Response Code: "+(int)responseStatusCode+"\n-----------------\n"+readStream.ReadToEnd();
                    updateStatusCode(response.StatusCode.ToString(), Color.Green);

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
                            selectedRichTextBox.Text = "Response Code: " + (int)response.StatusCode + "\n--------------\nUnable to make a valid HTTP request, please check the URL";
                            updateStatusCode(response.StatusCode.ToString(), Color.Orange);
                        }
                        else
                        {
                            // no http status code available
                            invalidHTTPResponse(selectedRichTextBox);
                        }
                    }
                    else
                    {
                        // no http status code available
                        invalidHTTPResponse(selectedRichTextBox);
                    }
                }
            }else
            {
                // In case URI is invalid
                selectedRichTextBox.Text = "'"+textBoxURL.Text+"' is not a valid URL, Please enter a valid URL";
                updateStatusCode("---", Color.Gray);
            }

        }

        private void invalidHTTPResponse(RichTextBox selectedRichTextBox)
        {
            // no http status code available
            selectedRichTextBox.Text = "No Response Code\n--------------\nUnable to make a valid HTTP request, please check the URL";
            updateStatusCode("---", Color.Gray);
        }

        private void updateStatusCode(string text, Color color)
        {
            labelStatusCode.Text = text;
            labelStatusCode.ForeColor = color;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void setAsHomePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userdata["homepage"] = textBoxURL.Text;
            Console.WriteLine("Homepage updated to " + userdata["homepage"]);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string title = "TabPage " + (tabControl1.TabCount + 1).ToString();
            RichTextBox richTextBoxTab = new RichTextBox();
            richTextBoxTab.Location = new System.Drawing.Point(0, 0);
            richTextBoxTab.Name = "richTextBoxTab"+(tabControl1.TabCount + 1).ToString();
            richTextBoxTab.Size = new System.Drawing.Size(1179, 646);
            TabPage myTabPage = new TabPage(title);
            tabControl1.TabPages.Add(myTabPage);
            myTabPage.Controls.Add(richTextBoxTab);
            tabControl1.SelectedTab = myTabPage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void OnApplicationExit(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            JsonSerializer seralizer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter("userdata.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                seralizer.Serialize(writer, userdata);
            }
        }
    }
}
