using System.ComponentModel.DataAnnotations;
using FinAspire.Core.Enums;

namespace FinAspire.Core.Request.Transactions;

public class UpdateTransactioRequest: BaseRequest
{
    [Required(ErrorMessage = "Id is required")]
    public long Id { get; set; }
    
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Amount is required")]
    public decimal Amount { get; set; }
    
    [Required(ErrorMessage = "Type is required")]
    public ETransactionType Type { get; set; } 
    
    [Required(ErrorMessage = "Transaction date is required")]
    public DateTime? PaidOrReceivedAt { get; set; }

    [Required(ErrorMessage = "Category is required")]
    public long CategoryId { get; set; }
}