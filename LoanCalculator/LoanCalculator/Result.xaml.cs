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
        
        public Result(LoanDetailsModel loanDetails)
        {
            this.loanDetails = loanDetails;

            InitializeComponent();
            BindingContext = new AmortizationDetailsViewModel(loanDetails);
        }
    }
}