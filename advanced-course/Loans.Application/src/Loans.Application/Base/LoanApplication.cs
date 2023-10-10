public class LoanApplication
{
    public Guid LoanId { get; set; }
    public ClientInfoModel ClientInfo { get; set; }
    public decimal Salary { get; set; }
    public decimal DesiredAmount { get; set; }
    public int TermInYears { get; set; }
    public LoanStatus Status { get; set; }
}