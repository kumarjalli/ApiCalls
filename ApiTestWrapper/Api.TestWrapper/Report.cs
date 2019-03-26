using System.Collections.Generic;

namespace Api.TestWrapper
{
    //public class Report
    //{
    //    public string Name { get; set; }
    //    public IList<KeyValuePair<string, string>> Headers { get; set; }
    //    public string Body { get; set; }
    //}

    public class Report
    {
        public string Name { get; set; }
        public List<Header> Headers { get; set; }
        public string Body { get; set; }
    }

    public class Header
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
