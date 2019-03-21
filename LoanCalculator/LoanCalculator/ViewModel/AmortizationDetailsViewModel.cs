using LoanCalculator.DataSource;
using LoanCalculator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LoanCalculator.ViewModel
{
    public class AmortizationDetailsViewModel
    {
        public string MonthlyPayment { get; set; }
        public string TotalPayment { get; set; }
        public string TotalInterestPaid { get; set; }
        public DateTime PayOffDate { get; set; }

        public string LoanAmount { get; set; }
        public string LoanTermMonths { get; set; }
        public string InterestRate { get; set; }

        private ObservableCollection<AmortizationDetails> amortizationDetails;

        public ObservableCollection<AmortizationDetails> AmortizationDetails
        {
            get { return amortizationDetails; }
            set
            {
                amortizationDetails = value;
            }
        }

        public AmortizationDetailsViewModel(LoanDetailsModel loanDetails)
        {
            AmortizationDetails = new ObservableCollection<AmortizationDetails>();
            var results = new LoanManager(loanDetails).GenerateFullAmortization();

            GetAmortizationOverview(loanDetails, results);

            foreach (var result in results.AmortizationDetails)
            {
                AmortizationDetails.Add(result);
            }
        }

        private void GetAmortizationOverview(LoanDetailsModel loanDetails, AmortizationResult results)
        {
            LoanAmount = loanDetails.LoanAmount.ToString();
            LoanTermMonths = loanDetails.LoanTermMonths.ToString();
            InterestRate = string.Format("{0} %", loanDetails.InterestRate.ToString());

            MonthlyPayment = results.AmortizationOverview.MonthlyPayment.ToString();
            TotalPayment = results.AmortizationOverview.TotalPayment.ToString();
            TotalInterestPaid = results.AmortizationOverview.TotalInterestPaid.ToString();
        }
    }
}
