using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.TestWrapper
{
    public class Report
    {
        public string Name { get; set; }
        public IList<Dictionary<string,string>> Headers { get; set; }
        public string Body { get; set; }
    }
}
