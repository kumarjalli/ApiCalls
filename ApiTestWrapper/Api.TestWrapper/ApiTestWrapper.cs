using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Api.TestWrapper
{
    public partial class ApiTestWrapper : Form
    {
        public IList<Report> ReportData { get; set; }
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

            string path = $"{ Application.StartupPath}\\ReportsList.xml";
            //XmlDocument xdoc = new XmlDocument();
            //FileStream rfile = new FileStream(path, FileMode.Open);
            //xdoc.Load(rfile);
            //ReportData = new List<Report>();


            //String address;
            //XmlNodeList list = xdoc.GetElementsByTagName("Report");
            //foreach(XmlElement element in list)
            //{
            //    Report report = new Report();
            //    report.Name = element.SelectNodes("Name")[0].InnerText;
            //    XmlNodeList headers = element.SelectNodes("Headers")[0].SelectNodes("Header");
            //    report.Headers = new List<KeyValuePair<string, string>>();
            //    foreach (XmlNode node in headers)
            //    {
            //        report.Headers.Add(new KeyValuePair<string, string>(node.SelectNodes("Key")[0].InnerText, node.SelectNodes("Value")[0].InnerText));
            //    }
            //    report.Body = element.SelectNodes("Body")[0].InnerText;
            //    reportList.Add(report);
            //}

            //XmlNodeList list = xdoc.GetElementsByTagName("Report");
            //ReportData = list.Cast<XmlNode>().Select(n => new Report
            //{
            //    Name = n.SelectNodes("Name")[0].InnerText,
            //    Headers = n.SelectNodes("Headers")[0].SelectNodes("Header").Cast<XmlNode>().Select(x => new KeyValuePair<string, string>(x.SelectNodes("Key")[0].InnerText, x.SelectNodes("Value")[0].InnerText)).ToList(),
            //    Body = n.SelectNodes("Body")[0].InnerText
            //}).ToList();

            //XmlNodeList list = xdoc.GetElementsByTagName("Report");
            //ReportData = list.Cast<XmlNode>().Select(n => new Report
            //{
            //    Name = n.SelectNodes("Name")[0].InnerText,
            //    Headers = n.SelectNodes("Headers")[0].SelectNodes("Header").Cast<XmlNode>().Select(x => new Header { Key = x.SelectNodes("Key")[0].InnerText, Value = x.SelectNodes("Value")[0].InnerText }).ToList(),
            //    Body = n.SelectNodes("Body")[0].InnerText
            //}).ToList();



            //for (int i = 0; i < list.Count; i++)
            //{
            //    XmlElement cl = (XmlElement)xdoc.GetElementsByTagName("Name")[i];
            //    XmlElement add = (XmlElement)xdoc.GetElementsByTagName("Address")[i];
            //    if ((cl.GetAttribute("Name")) == "abc")
            //    {
            //        address = add.InnerText;
            //        break;
            //    }
            //}


            //rfile.Close();

            XmlSerializer serializer1 = new XmlSerializer(typeof(List<Report>));
            using (FileStream stream = File.OpenRead(path))
            {
                ReportData = (List<Report>)serializer1.Deserialize(stream);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Report>));
            using (TextWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, ReportData);
            }


            //string url = "https://www.sampledomain.com";
            //string data = "{'Id':'5824614'}";
            //BaseApiService apiService = new BaseApiService(url, "7357659-d97d-efr5-4t59-ge4trw43ger5");
            //string result = await apiService.PostAsync(url, "SampleApi", data);



            //HttpResponseMessage httpResponse;
            //using (HttpClient httpClient = new HttpClient())
            //{
            //    httpClient.BaseAddress = new Uri(url);
            //    httpClient.DefaultRequestHeaders.Add("Authorization-Token", "7357659-d97d-efr5-4t59-ge4trw43ger5");
            //    httpClient.DefaultRequestHeaders.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //    StringContent stringContent = new StringContent(JsonHelper.Serialize(data), UnicodeEncoding.UTF8, "application/json");
            //    httpResponse = await httpClient.PostAsync("api/Report/SampleApi", stringContent);
            //    var response = await httpResponse.Content.ReadAsStringAsync();
            //}

        }
    }
}
