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
        static int userPosition;

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
                userPosition = userdata.history.Count - 1;
            }

            // Load up homepage
            textBoxURL.Text = userdata.homepage;
            
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loadResponseToTextBoxFromURL(bool recordToHistory)
        {
            // Check if valid URI
            Uri uriResult;
            bool isUri = Uri.TryCreate(textBoxURL.Text, UriKind.Absolute, out uriResult)
                && uriResult.Scheme == Uri.UriSchemeHttp;

            RichTextBox selectedRichTextBox;

            // Get the 0th control (it is suppose to be richTextBox) of the current Tab
            if(tabControl1.TabCount > 0)
            {
                if (tabControl1.SelectedTab.Controls[0] is RichTextBox)
                {
                    selectedRichTextBox = (RichTextBox)tabControl1.SelectedTab.Controls[0];
                }
                else
                {
                    MessageBox.Show("Please use a different tab");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please add a new tab");
                return;
            }



            // Do Request if valid URI
            if (isUri)
            {

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
                    selectedRichTextBox.Text = "Response Code: " + (int)responseStatusCode + "\n-----------------\n" + readStream.ReadToEnd();
                    updateStatusCode(response.StatusCode.ToString(), Color.Green);

                    // Close response and stream
                    response.Close();
                    readStream.Close();

                    // Record history
                    if (recordToHistory)
                    {
                        if(userPosition != userdata.history.Count - 1 || userPosition != 0)
                        {
                            int j = userdata.history.Count;
                            for(int i = userdata.history.Count-1; i > userPosition; i--)
                            {
                                userdata.history[i].Remove();
                            }
                        }
                        userdata.history.Add(textBoxURL.Text);
                        if (userdata.history.Count == 1)
                        {
                            userPosition = 0;
                        }
                        else
                        {
                            userPosition += 1;
                        }
                    }

                    // Update navigation buttons
                    toggleNavitgationButtons();
                }
                catch (WebException ex)
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
            }
            else
            {
                // In case URI is invalid
                selectedRichTextBox.Text = "'" + textBoxURL.Text + "' is not a valid URL, Please enter a valid URL";
                updateStatusCode("---", Color.Gray);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadResponseToTextBoxFromURL(true);
        }

        private void toggleNavitgationButtons()
        {
            if(userdata.history.Count <= 1)
            {
                goForwardToolStripMenuItem.Enabled = false;
                goBackToolStripMenuItem.Enabled = false;
            }else{
                goForwardToolStripMenuItem.Enabled = userPosition == userdata.history.Count-1 ? false : true;
                goBackToolStripMenuItem.Enabled = userPosition == 1 ? false : true;
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

        private void buttonAddTab_click(object sender, EventArgs e)
        {
            addWebPageTab(userdata.hompage, false);
        }

        private void addWebPageTab(string url, Boolean record)
        {
            string title = url;
            RichTextBox richTextBoxTab = new RichTextBox();
            richTextBoxTab.Location = new System.Drawing.Point(0, 0);
            richTextBoxTab.Name = "richTextBoxTab" + (tabControl1.TabCount + 1).ToString();
            richTextBoxTab.Size = new System.Drawing.Size(1179, 646);
            TabPage newTabPage = new TabPage(title);
            tabControl1.TabPages.Add(newTabPage);
            newTabPage.Controls.Add(richTextBoxTab);
            tabControl1.SelectedTab = newTabPage;
            textBoxURL.Text = url;
            loadResponseToTextBoxFromURL(record);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
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

        private void goBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (userdata.history.Count > 1)
            {
                textBoxURL.Text = userdata.history[userPosition - 1];
                userPosition -= 1;
                loadResponseToTextBoxFromURL(false);
            }
        }

        private void clearHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userdata.history.Clear();
            userPosition = 0;
            goForwardToolStripMenuItem.Enabled = false;
            goBackToolStripMenuItem.Enabled = false;
        }

        private void goForwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (userPosition != userdata.history.Count-1 && userPosition != 0)
            {
                textBoxURL.Text = userdata.history[userPosition + 1];
                userPosition += 1;
                loadResponseToTextBoxFromURL(false);
            }
        }

        private void goHomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxURL.Text = userdata.homepage;
            loadResponseToTextBoxFromURL(true);
        }

        private void viewHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Setup tab page
            string title = "History";
            TabPage newTabPage = new TabPage(title);
            tabControl1.TabPages.Add(newTabPage);

            // Set up view control
            ListView listViewHistory = new ListView();
            listViewHistory.Location = new System.Drawing.Point(-4, 0);
            listViewHistory.Name = "listViewHistory";
            listViewHistory.Size = new System.Drawing.Size(1174, 646);
            listViewHistory.UseCompatibleStateImageBehavior = false;
            listViewHistory.View = View.List;
            listViewHistory.ItemSelectionChanged += listViewHistory_ItemSelectionChanged;

            // Load data to list view
            foreach (string item in userdata.history)
            {
                listViewHistory.Items.Add(item);
            }

            // Add control to tabpage
            newTabPage.Controls.Add(listViewHistory);
            tabControl1.SelectedTab = newTabPage;
        }

        private void listViewHistory_ItemSelectionChanged(Object sender, ListViewItemSelectionChangedEventArgs e)
        {
            textBoxURL.Text = e.Item.Text;
            addWebPageTab(textBoxURL.Text, false);
        }
    }
}
