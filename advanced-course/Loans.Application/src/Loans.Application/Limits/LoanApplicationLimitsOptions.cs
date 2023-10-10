namespace Loans.Application.Limits;

public class LoanApplicationLimitsOptions
{
    public decimal MinLoanAmount { get; set; }
    public decimal MaxLoanAmount { get; set; }
    public int MinLoanTermInYears { get; set; }
    public int MaxLoanTermInYears { get; set; }
    public decimal MinSalary { get; set; }
}
