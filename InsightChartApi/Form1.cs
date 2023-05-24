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
using System.Net.Http;
using System.Net.Http.Headers;
using CefSharp.WinForms;

namespace InsightChartApi
{
    public partial class Form1 : Form
    {

        private ChromiumWebBrowser browser;

        public Form1()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();

            HttpContent content = new StringContent(textBox3.Text, Encoding.UTF8, "application/json");
            
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", textBox2.Text);
            client.BaseAddress = new Uri(textBox1.Text);
            
            HttpResponseMessage rm = client.PostAsync(textBox1.Text, content).Result;
            StreamContent sc = rm.Content as StreamContent;
            string s = sc.ReadAsStringAsync().Result;
            int i = s.IndexOf(':');
            i = s.IndexOf('"', i);
            s = s.Substring(i + 1);
            i = s.IndexOf('"');
            s = s.Substring(0, i);
            //webBrowser1.Navigate(s);
            browser.LoadUrl(s);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            browser = new ChromiumWebBrowser();
            panel1.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
        }
    }
}
