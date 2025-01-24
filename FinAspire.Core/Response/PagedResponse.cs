using System.Text.Json.Serialization;

namespace FinAspire.Core.Response;

public class PagedResponse<TData> : BaseResponse<TData>
{
    [JsonConstructor]
    public PagedResponse(TData? data, int totalCount, int page = 1) : base(data)
    {
        Data = data;
        TotalCount = totalCount;
        Page = page;
    }

    public PagedResponse(TData? data, int code = Configuration.DefaultStatusCode, string? message = null) 
        : base(data, message, code) 
    {
        
    }
    
    
    public int Page { get; set; }
    private int PageSize { get; set; } = Configuration.DefaultPageSize;
    public int TotalPages 
        => (int)Math.Ceiling(TotalCount / (double)PageSize);

    public int TotalCount { get; set; }
}