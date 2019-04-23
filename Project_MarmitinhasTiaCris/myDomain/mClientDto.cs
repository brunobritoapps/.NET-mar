using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace www.myDomain
{
    public class myClientDto
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string company { get; set; }
        public string date { get; set; }

        public myClientDto()
        {
            id = "";
            firstName = "";
            lastName = "";
            gender = "";
            company = "";
            date ="";
        }
    }
}
