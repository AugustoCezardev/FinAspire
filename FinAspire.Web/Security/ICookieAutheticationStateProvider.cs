using Microsoft.AspNetCore.Components.Authorization;

namespace FinAspire.Web.Security
{
    public interface ICookieAutheticationStateProvider
    {
        Task<bool> CheckAuthenticateAsync();
        Task<AuthenticationState> GetAuthenticationStateAsync();
        void NotifyAythenticationStateChanged();
    }
}
