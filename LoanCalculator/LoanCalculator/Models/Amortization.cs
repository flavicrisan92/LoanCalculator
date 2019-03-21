using System;

namespace LoanCalculator.Models
{
    public class Amortization
    {
        public double MonthlyPayment { get; set; }
        public double TotalPayment { get; set; }
        public double TotalInterestPaid { get; set; }
        public DateTime PayoffDate { get; set; }
    }
}