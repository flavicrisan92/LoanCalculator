using LoanCalculator.Models;
using LoanCalculator.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoanCalculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Result : ContentPage
    {
        private LoanDetailsModel loanDetails;

        public AmortizationDetailsViewModel AmortizationDetails { get; private set; }

        public Result(LoanDetailsModel loanDetails)
        {
            this.loanDetails = loanDetails;

            InitializeComponent();
            AmortizationDetails = new AmortizationDetailsViewModel(loanDetails);
            
            BindingContext = AmortizationDetails;
        }
    }
}