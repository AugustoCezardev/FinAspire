using System.ComponentModel.DataAnnotations;

namespace FinAspire.Core.Request.Transactions;

public class DeleteTransactionRequest: BaseRequest
{
    [Required(ErrorMessage = "Id is required")]
    public long Id { get; set; }
}