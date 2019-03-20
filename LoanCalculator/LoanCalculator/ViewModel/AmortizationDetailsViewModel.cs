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
        public decimal MonthlyPayment { get; set; }
        public decimal TotalPayment { get; set; }
        public decimal TotalInterestPaid { get; set; }
        public DateTime PayOffDate { get; set; }

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
            IDataSource dataSource = new MyDataSource();
            var results = dataSource.GetResult(loanDetails);
            foreach (var result in results.AmortizationDetails)
            {
                AmortizationDetails.Add(result);

            }
        }

    }
}
