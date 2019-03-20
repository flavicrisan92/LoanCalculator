using LoanCalculator.Models;
using LoanCalculator.ViewModel;
using System.Collections.Generic;

namespace LoanCalculator.DataSource
{
    public interface IDataSource
    {
        AmortizationResult GetResult(LoanDetailsModel loadnDetails);
    }
}