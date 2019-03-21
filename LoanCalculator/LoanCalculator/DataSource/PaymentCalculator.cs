using LoanCalculator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanCalculator.DataSource
{
    /// <summary>
    /// Class to calculate loan payments
    /// </summary>
   public class PaymentCalculator
    {
        private const int MonthsPerYear = 12;

        /// <summary>
        /// The total purchase price of the item being paid for.
        /// </summary>
        public double PurchasePrice { get; set; }

        /// <summary>
        /// The total down payment towards the item being purchased.
        /// </summary>
        public double DownPayment { get; set; }

        /// <summary>
        /// Gets the total loan amount. This is the purchase price less
        /// any down payment.
        /// </summary>
        public double LoanAmount
        {
            get { return (PurchasePrice - DownPayment); }
        }

        /// <summary>
        /// The annual interest rate to be charged on the loan
        /// </summary>
        public double InterestRate { get; set; }

        /// <summary>
        /// The term of the loan in months. This is the number of months
        /// that payments will be made.
        /// </summary>
        public double LoanTermMonths { get; set; }

        /// <summary>
        /// Calculates the monthy payment amount based on current
        /// settings.
        /// </summary>
        /// <returns>Returns the monthly payment amount</returns>
        public double CalculateMonthlyPayment()
        {
            double payment = 0;

            if (LoanTermMonths > 0)
            {
                if (InterestRate != 0)
                {
                    double rate = ((InterestRate / MonthsPerYear) / 100);
                    double factor = (rate + (rate / (Math.Pow(rate + 1, LoanTermMonths) - 1)));
                    payment = (LoanAmount * factor);
                }
                else payment = (LoanAmount / (double)LoanTermMonths);
            }
            return payment;
        }

        public List<AmortizationDetails> GenerateAmortization()
        {
            var amortizationDetails = new List<AmortizationDetails>();
            var balance = LoanAmount;
            var periods = LoanTermMonths;
            var monthlyRate = (InterestRate / 100) / 12;
            var monthyPayment = (monthlyRate / (1 - (Math.Pow((1 + monthlyRate), -(periods))))) * balance;

            for (var i = 1; i <= periods; i++)
            {
                var interestForMonth = balance * monthlyRate;
                var principalForMonth = monthyPayment - interestForMonth;
                balance += interestForMonth;
                balance -= monthyPayment;

                amortizationDetails.Add(new AmortizationDetails()
                {
                    Month = string.Format("#{0}", i.ToString()),
                    Interest = Math.Round(interestForMonth, 2),
                    Balance = Math.Round(balance, 2),
                    Principal = Math.Round(principalForMonth, 2),
                });
            }
            return amortizationDetails;
        }
    }
}
