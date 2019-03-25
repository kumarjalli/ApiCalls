using Api.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Api.TestWrapper
{
    public partial class ApiTestWrapper : Form
    {
        public ApiTestWrapper()
        {
            InitializeComponent();
        }

        private async void ApiTestWrapper_Load(object sender, EventArgs e)
        {

            comboBox1.Items.Add("POST");
            comboBox1.Items.Add("GET");
            comboBox1.Items.Add("PUT");
            comboBox1.Items.Add("DELETE");
            comboBox1.SelectedIndex = 0;

            string path = $"{ Application.StartupPath}\\ReportsList.xml" ;
            //XmlDocument xdoc = new XmlDocument();
            //FileStream rfile = new FileStream(path, FileMode.Open);
            //xdoc.Load(rfile);



            //String address;
            //XmlNodeList list = xdoc.GetElementsByTagName("Customer");
            //for (int i = 0; i < list.Count; i++)
            //{
            //    XmlElement cl = (XmlElement)xdoc.GetElementsByTagName("Customer")[i];
            //    XmlElement add = (XmlElement)xdoc.GetElementsByTagName("Address")[i];
            //    if ((cl.GetAttribute("Name")) == "abc")
            //    {
            //        address = add.InnerText;
            //        break;
            //    }
            //}
            //rfile.Close();

 

            //string url = "";
            //string data = "";
            //BaseApiService apiService = new BaseApiService(url, "");
            //string result = await apiService.PostAsync(url, "", data);


        }
    }
}
