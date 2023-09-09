using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorWEB.Models
{
    public class CalculatorModel
    {
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public string Operation { get; set; }
        public double Result { get; set; }
    }

}
