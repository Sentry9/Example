namespace Loans.Application.Base;

public class LoanApplicationModel
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public DateTime BirthDate { get; set; }
    public double? Salary { get; set; }
    public int? TermInYears { get; set; }
    public double? DesiredAmount { get; set; }
}