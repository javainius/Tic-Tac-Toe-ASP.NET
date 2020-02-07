using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tic_Tac_Toe.Models
{
    public class Row
    {
        public string FirstElement { get; set; }
        public string SecondElement { get; set; }
        public string ThirdElement { get; set; }
        public Row(string FirstElement, string SecondElement, string ThirdElement)
        {
            this.FirstElement = FirstElement;
            this.SecondElement = SecondElement;
            this.ThirdElement = ThirdElement;
        }
    }
}
