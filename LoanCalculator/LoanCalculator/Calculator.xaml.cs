using LoanCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoanCalculator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Calculator : ContentPage
	{
		public Calculator ()
		{
			InitializeComponent ();
		}

        public async void CalculateLoanAsync(object sender, EventArgs e)
        {
            try
            {
                double.TryParse(loan_amount.Text, out double _loan_amount);
                int.TryParse(duration.Text, out int _duration);
                double.TryParse(interest.Text, out double _interest);

                LoanDetailsModel loanDetails = new LoanDetailsModel()
                {
                    LoanAmount = _loan_amount,
                    Duration = _duration,
                    Interest = _interest
                };

                await Navigation.PushAsync(new Result(loanDetails));
            }catch(Exception ex)
            {
                var xxx = ex;
            }
        }
    }
}