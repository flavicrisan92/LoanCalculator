using System;
using System.Collections.Generic;
using System.Text;

namespace LoanCalculator.Models
{
    public class AmortizationResult
    {
        public List<AmortizationDetails> AmortizationDetails;
        public double MonthlyPayment { get; set; }
        public double TotalPayment { get; set; }
        public double TotalInterestPaid { get; set; }
        public DateTime PayoffDate { get; set; }
    }
}
