namespace FinAspire.Core.Request;

public abstract class BasePagedRequest: BaseRequest
{
    public int Page { get; set; } = Configuration.DefaultPageNumber;
    public int PageSize { get; set; } = Configuration.DefaultPageSize;
}