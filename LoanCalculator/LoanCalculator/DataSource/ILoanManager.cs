using LoanCalculator.Models;
using LoanCalculator.ViewModel;
using System.Collections.Generic;

namespace LoanCalculator.DataSource
{
    public interface ILoanManager
    {
        AmortizationResult GenerateFullAmortization();
    }
}