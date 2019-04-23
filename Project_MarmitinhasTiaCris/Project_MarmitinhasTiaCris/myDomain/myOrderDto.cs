using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace www.myDomain
{
    public class myOrderDto
    {
        public string id { get; set; }
        public string idClient { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string company { get; set; }
        public string note { get; set; }
        public string date { get; set; }
        public string price { get; set; }
        public myClientDto client { get; set; }

        public myOrderDto()
        {
            id = "";
            idClient = "";
            note = "";
            date = "";
            price = "";
        }
    }
}
