using System.Text.Json.Serialization;

namespace FinAspire.Core.Response;

public class BaseResponse<TData>(TData? data, string? message = null, int code = 200)
{

    [JsonConstructor]
    public BaseResponse() : this(default(TData?), null, Configuration.DefaultStatusCode)
    {
    }

    public TData? Data { get; set; } = data;
    public string? Message { get; set; } = message;

    [JsonIgnore]
    public bool IsSuccess => code is >= 200 and <= 299;
}