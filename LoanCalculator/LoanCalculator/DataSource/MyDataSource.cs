using LoanCalculator.Models;
using System;
using System.Collections.Generic;

namespace LoanCalculator.DataSource
{
    public class MyDataSource : IDataSource
    {
        public AmortizationResult GetResult(LoanDetailsModel loanDetails)
        {
            var montlyPayment = CalculateLoan(loanDetails);
            List<AmortizationDetails> amortizationDetails = GenerateAmortizationDetails(loanDetails);

            var result = new AmortizationResult()
            {
                AmortizationDetails = amortizationDetails,
                MonthlyPayment = montlyPayment,
                PayoffDate = DateTime.MaxValue,
                TotalInterestPaid = 999,
                TotalPayment = montlyPayment * loanDetails.Duration
            };

            return result;
        }

        private static List<AmortizationDetails> GenerateAmortizationDetails(LoanDetailsModel loanDetails)
        {
            var amortizationDetails = new List<AmortizationDetails>();
            var balance = loanDetails.LoanAmount; // for example
            var periods = loanDetails.Duration; // 30 years
            var monthlyRate = (loanDetails.Interest / 100) / 12;  // 0.065= APR of 6.5% as decimal
            var monthyPayment = (monthlyRate / (1 - (Math.Pow((1 + monthlyRate), -(periods))))) * balance;

            for (var i = 1; i <= periods; i++)
            {
                var interestForMonth = balance * monthlyRate;
                var principalForMonth = monthyPayment - interestForMonth;
                balance += interestForMonth;
                balance -= monthyPayment; // probably should be -= principalForMonth see comments below
                                          // output as necessary.

                amortizationDetails.Add(new AmortizationDetails()
                {
                    Month = i.ToString(),
                    Interest = Math.Round(interestForMonth, 2),
                    Balance = Math.Round(balance, 2),
                    Principal = Math.Round(principalForMonth, 2),

                });
            }
            return amortizationDetails;
        }

        public double CalculateLoan(LoanDetailsModel loanDetails)
        {

            PaymentCalculator calculator = new PaymentCalculator();
            calculator.PurchasePrice = loanDetails.LoanAmount;
            calculator.InterestRate = loanDetails.Interest;
            calculator.LoanTermMonths = loanDetails.Duration;
            calculator.DownPayment = 0;

            return calculator.CalculatePayment();
        }
    }
}
