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

        private async void loadResponseToTextBoxFromURL(bool recordToHistory)
        {
            // Check if valid URI
            Uri uriResult;
            bool isUri = Uri.TryCreate(textBoxURL.Text, UriKind.Absolute, out uriResult)
                && uriResult.Scheme == Uri.UriSchemeHttp;

            RichTextBox selectedRichTextBox;

            // Get the 0th control (it is suppose to be richTextBox) of the current Tab
            if (tabControl1.TabCount > 0)
            {
                if (tabControl1.SelectedTab.Controls[0] is RichTextBox)
                {
                    selectedRichTextBox = (RichTextBox)tabControl1.SelectedTab.Controls[0];
                }
                else
                {
                    // If no rich text box is present
                    MessageBox.Show("Please use a different tab");
                    return;
                }
            }
            else
            {
                // If no rich text box is present
                MessageBox.Show("Please add a new tab");
                return;
            }

            // Do Request if valid URI
            if (isUri)
            {

                // Set up request object
                var request = WebRequest.Create(textBoxURL.Text);
                // HttpWebRequest request = (HttpWebRequest)WebRequest.Create(textBoxURL.Text);

                selectedRichTextBox.Text = "Loading...";

                HttpStatusCode responseStatusCode;

                // Try getting response
                try
                {
                    // Set current tab name to URL name
                    tabControl1.SelectedTab.Text = textBoxURL.Text;

                    // Setup response object
                    var response = (HttpWebResponse)await Task.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, null);
                    //HttpWebResponse response = (HttpWebResponse)request.GetResponse();

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
                        if (userPosition != userdata.history.Count - 1 || userPosition != 0)
                        {
                            int j = userdata.history.Count;
                            for (int i = userdata.history.Count - 1; i > userPosition; i--)
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
            MessageBox.Show("Home page has been set to " + userdata["homepage"]);
        }

        private void buttonAddTab_click(object sender, EventArgs e)
        {
            addWebPageTab(userdata.homepage.ToString(), false);
        }

        private void addWebPageTab(string url, Boolean record, Boolean autoNav = true)
        {
            // Set the title
            string title = url;

            // Set up rich text box
            RichTextBox richTextBoxTab = new RichTextBox();
            richTextBoxTab.Location = new System.Drawing.Point(0, 0);
            richTextBoxTab.Name = "richTextBoxTab" + (tabControl1.TabCount + 1).ToString();
            richTextBoxTab.Size = new System.Drawing.Size(1179, 646);

            // Add new tab
            TabPage newTabPage = new TabPage(title);
            tabControl1.TabPages.Add(newTabPage);

            // Add controller
            newTabPage.Controls.Add(richTextBoxTab);
            tabControl1.SelectedTab = newTabPage;

            // Auto-Navigate to url
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
            // Check if history is already open
            foreach (TabPage tabpage in tabControl1.TabPages)
            {
                if (tabpage.Text == "History")
                {
                    MessageBox.Show("A History tab is already open");
                    return;
                }
            }

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
            listViewHistory.ItemActivate += listViewHistory_ItemClick;

            // Load data to list view
            foreach (string item in userdata.history)
            {
                listViewHistory.Items.Add(item);
            }

            // Add control to tabpage
            newTabPage.Controls.Add(listViewHistory);
            tabControl1.SelectedTab = newTabPage;
        }

        private void listViewHistory_ItemClick(Object sender, EventArgs e)
        {
            ListView listView = (ListView)sender;
            textBoxURL.Text = listView.SelectedItems[0].Text;
            addWebPageTab(textBoxURL.Text, false);
        }

        private void addBookmarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userdata.bookmarks.Add(showBookmarkEditDialog(textBoxURL.Text, "Add new bookmark"));
        }

        private void myBookmarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if bookmarks is already open
            foreach (TabPage tabpage in tabControl1.TabPages)
            {
                if(tabpage.Text == "Bookmarks")
                {
                    MessageBox.Show("A Bookmarks tab is already open");
                    return;
                }
            }

            // Setup tab page
            string title = "Bookmarks";
            TabPage newTabPage = new TabPage(title);
            tabControl1.TabPages.Add(newTabPage);

            // Set up view control
            ListView listViewBookmarks = new ListView();
            listViewBookmarks.Location = new System.Drawing.Point(-4, 0);
            listViewBookmarks.Name = "listViewBookmarks";
            listViewBookmarks.Size = new System.Drawing.Size(400, 620);
            listViewBookmarks.UseCompatibleStateImageBehavior = false;
            listViewBookmarks.View = View.Details;
            listViewBookmarks.ItemActivate += listViewBookmarks_ItemClick;
            listViewBookmarks.Columns.Add("Name", 200);
            listViewBookmarks.Columns.Add("URL", 200);
            newTabPage.Controls.Add(listViewBookmarks);

            int itemTop = 20;
            int itemIndex = 0;

            // Load data to list view
            foreach (dynamic item in userdata.bookmarks)
            {
                ListViewItem listItem = new ListViewItem((string)item.name);
                listItem.SubItems.Add((string)item.url);
                Button itemEditButton = new Button() { Text = "Edit Item "+itemIndex, Left = 400, Width = 100, Height = 20, Top = itemTop };
                itemEditButton.Click += bookmarkItemEdit_Click;
                Button itemRemoveButton = new Button() { Text = "Remove Item "+itemIndex, Left = 500, Width = 100, Height = 20, Top = itemTop };
                itemRemoveButton.Click += bookmarkItemRemove_Click;
                itemTop += 20;
                itemIndex++;
                newTabPage.Controls.Add(itemEditButton);
                newTabPage.Controls.Add(itemRemoveButton);
                listViewBookmarks.Items.Add(listItem);
            }

            // Add control to tabpage
            tabControl1.SelectedTab = newTabPage;
        }

        private void bookmarkItemEdit_Click(Object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int itemIndex = Int32.Parse(button.Text.Substring(button.Text.Length-1));
            userdata.bookmarks[itemIndex] = showBookmarkEditDialog((string)userdata.bookmarks[itemIndex].url,"Edit Bookmark",(string)userdata.bookmarks[itemIndex].name);
            button2.PerformClick();
            myBookmarksToolStripMenuItem.PerformClick();
        }

        private void bookmarkItemRemove_Click(Object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int itemIndex = Int32.Parse(button.Text.Substring(button.Text.Length - 1));
            userdata.bookmarks.RemoveAt(itemIndex);
            button2.PerformClick();
            myBookmarksToolStripMenuItem.PerformClick();
        }

        private void listViewBookmarks_ItemClick(Object sender, EventArgs e)
        {
            ListView listView = (ListView)sender;
            textBoxURL.Text = listView.SelectedItems[0].SubItems[1].Text;
            addWebPageTab(textBoxURL.Text, false);
        }

        private void editHomeURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userdata.homepage = ShowEditDialog((string)userdata.homepage, "Edit Homepage");
        }

        public static string ShowEditDialog(string text, string caption)
        {

            // Setup dialog box
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 200;
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 50, Top = 20, Text = caption };
            TextBox inputBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            inputBox.Text = text;
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.ShowDialog();
            return inputBox.Text;
        }

        public static dynamic showBookmarkEditDialog(string url, string caption, string name = "My Bookmark")
        {

            // Setup dialog box
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 200;
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 50, Top = 20, Text = caption };
            TextBox nameInputBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            TextBox urlInputBox = new TextBox() { Left = 50, Top = 70, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 90 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            urlInputBox.Text = url;
            nameInputBox.Text = name;
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(nameInputBox);
            prompt.Controls.Add(urlInputBox);
            prompt.ShowDialog();
            dynamic bookmarkItem = new Newtonsoft.Json.Linq.JObject();
            bookmarkItem.name = nameInputBox.Text;
            bookmarkItem.url = urlInputBox.Text;
            if(bookmarkItem.name == "")
            {
                bookmarkItem.name = name;
            }
            if (bookmarkItem.url == "")
            {
                bookmarkItem.name = url;
            }
            return bookmarkItem;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                buttonGO.PerformClick();
            }

            if(e.KeyCode == Keys.Enter && e.Modifiers == Keys.Control)
            {
                buttonAddTab.PerformClick();
                buttonGO.PerformClick();
            }
        }
    }
}
