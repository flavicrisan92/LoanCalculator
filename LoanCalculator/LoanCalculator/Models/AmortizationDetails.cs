using System;
using System.Collections.Generic;
using System.Text;

namespace LoanCalculator.Models
{
    public class AmortizationDetails
    {
        public string Month { get; set; }
        public double Interest { get; set; }
        public double Principal { get; set; }
        public double Balance { get; set; }
    }
}
