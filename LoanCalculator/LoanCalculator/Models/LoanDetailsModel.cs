using System;
using System.Collections.Generic;
using System.Text;

namespace LoanCalculator.Models
{
    public class LoanDetailsModel
    {
        public double LoanAmount { get; set; }
        public int Duration { get; set; }
        public double Interest { get; set; }
    }
}
