namespace FinAspire.Core.Request.Transactions;

public class GetTransactionByPeriodRequest: BasePagedRequest
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}