using System.Net.Http.Json;
using System.Text;
using FinAspire.Core.Handler;
using FinAspire.Core.Request.Account;
using FinAspire.Core.Response;

namespace FinAspire.Web.Handlers;

public class AccountHandler(IHttpClientFactory httpClientFactory): IAccountHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
    
    public async Task<BaseResponse<string>> LoginAsync(LoginRequest request)
    {
        try
        {
            var result = await _client.PostAsJsonAsync("/v1/auth/login?useCookies=true", 
                request);
            return result.IsSuccessStatusCode ? 
                new BaseResponse<string>("Login realized with success!", 
                    "Login realized with success!", 200) : 
                new BaseResponse<string>( "Login failed!", "Login failed!", (int)result.StatusCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new BaseResponse<string>( "Login failed!", e.Message, 400);
        }
    }

    public async Task<BaseResponse<string>> RegisterAsync(RegisterRequest request)
    {
        try
        {
            var result = await _client.PostAsJsonAsync("/v1/auth/register", request);
            return result.IsSuccessStatusCode ? 
                new BaseResponse<string>("Register realized!", "Register realized!", 201) :
                new BaseResponse<string>( "Register failed!", "Register failed!", (int)result.StatusCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new BaseResponse<string>( "Register failed!", e.Message, 400);
        }
    }

    public async Task LogoutAsync()
    {
        try
        {
            var emptyContent = new StringContent("{}", Encoding.UTF8 ,"application/json");
            await _client.PostAsJsonAsync("/v1/auth/logout", emptyContent);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}