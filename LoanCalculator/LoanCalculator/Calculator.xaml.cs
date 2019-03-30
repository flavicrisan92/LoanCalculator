using LoanCalculator.Models;
using LoanCalculator.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoanCalculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calculator : ContentPage
    {
        public AmortizationDetailsViewModel AmortizationDetails { get; private set; }

        public Calculator()
        {
            InitializeComponent();
        }

        public async void AmortizationTableAsync(object sender, EventArgs e)
        {
            try
            {
                double.TryParse(loan_amount.Text, out double _loan_amount);
                int.TryParse(duration.Text, out int _duration);
                double.TryParse(interest.Text, out double _interest);

                LoanDetailsModel loanDetails = new LoanDetailsModel()
                {
                    LoanAmount = _loan_amount,
                    LoanTermMonths = _duration,
                    InterestRate = _interest
                };

                await Navigation.PushAsync(new Result(loanDetails));
            }
            catch (Exception)
            {

            }
        }

        private void CalculateLoan(object sender, EventArgs e)
        {
            double.TryParse(loan_amount.Text, out double _loan_amount);
            int.TryParse(duration.Text, out int _duration);
            double.TryParse(interest.Text, out double _interest);

            LoanDetailsModel loanDetails = new LoanDetailsModel()
            {
                LoanAmount = _loan_amount,
                LoanTermMonths = _duration,
                InterestRate = _interest
            };
            AmortizationDetails = new AmortizationDetailsViewModel(loanDetails);

            BindingContext = AmortizationDetails;
        }
    }
}