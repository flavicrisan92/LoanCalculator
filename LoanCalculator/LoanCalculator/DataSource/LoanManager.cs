using LoanCalculator.Models;
using System;
using System.Collections.Generic;

namespace LoanCalculator.DataSource
{
    public class LoanManager : ILoanManager
    {
        public PaymentCalculator Calculator { get; set; }

        public LoanManager(LoanDetailsModel loanDetails)
        {
            Calculator = new PaymentCalculator
            {
                PurchasePrice = loanDetails.LoanAmount,
                InterestRate = loanDetails.InterestRate,
                LoanTermMonths = loanDetails.LoanTermMonths,
                DownPayment = 0
            };
        }
        public AmortizationResult GenerateFullAmortization()
        {
            var montlyPayment = Calculator.CalculateMonthlyPayment();
            var amortization = Calculator.GenerateAmortization();

            var calculationResult = new AmortizationResult()
            {
                AmortizationOverview = new Amortization()
                {
                    MonthlyPayment = Math.Round(montlyPayment, 2),
                    TotalInterestPaid = Math.Round(montlyPayment * Calculator.LoanTermMonths - Calculator.LoanAmount, 2),
                    TotalPayment = Math.Round(montlyPayment * Calculator.LoanTermMonths, 2)
                },
                AmortizationDetails = amortization
            };

            return calculationResult;
        }

        public AmortizationResult GenerateAmortizationOverview()
        {
            var montlyPayment = Calculator.CalculateMonthlyPayment();
            //var amortization = Calculator.GenerateAmortization();

            var calculationResult = new AmortizationResult()
            {
                AmortizationOverview = new Amortization()
                {
                    MonthlyPayment = Math.Round(montlyPayment, 2),
                    TotalInterestPaid = Math.Round(montlyPayment * Calculator.LoanTermMonths - Calculator.LoanAmount, 2),
                    TotalPayment = Math.Round(montlyPayment * Calculator.LoanTermMonths, 2)
                }
            };

            return calculationResult;
        }
    }
}
