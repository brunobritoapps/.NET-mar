using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace www.myDomain
{
    public class myFoodDto
    {
        public string id { get; set; }
        public string nameFood { get; set; }
        public string  quantum { get; set; }
        public string price { get; set; }

        public myFoodDto()
        {
            id = "";
            nameFood = "";
            quantum = "";
            price = "";
        }
    }
}
