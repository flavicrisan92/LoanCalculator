using System;
using System.Collections.Generic;
using System.Text;

namespace LoanCalculator.Models
{
    public class LoanDetailsModel
    {
        public double LoanAmount { get; set; }
        public int LoanTermMonths { get; set; }
        public double InterestRate { get; set; }
    }
}
