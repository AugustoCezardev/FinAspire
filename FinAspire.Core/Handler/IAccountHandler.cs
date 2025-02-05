using FinAspire.Core.Request.Account;
using FinAspire.Core.Response;

namespace FinAspire.Core.Handler;

public interface IAccountHandler
{
    Task<BaseResponse<string>> LoginAsync(LoginRequest request);
    Task<BaseResponse<string>> RegisterAsync(RegisterRequest request);
    Task LogoutAsync();
}