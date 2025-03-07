using FinAspire.Core.Models.Account;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using System.Security.Claims;

namespace FinAspire.Web.Security
{
    public class CookieAutheticationStateProvider(IHttpClientFactory clientFactory) :
        AuthenticationStateProvider, 
        ICookieAutheticationStateProvider
    {

        private bool _isAuthenticated = false;

        private readonly HttpClient _httpClient = clientFactory.CreateClient(Configuration.HttpClientName);
        public async Task<bool> CheckAuthenticateAsync()
        {
            await GetAuthenticationStateAsync();
            return _isAuthenticated;
        }
        public void NotifyAythenticationStateChanged() =>
            base.NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            _isAuthenticated = false;

            var user = new ClaimsPrincipal(new ClaimsIdentity());

            var userInfo = await GetUserAsync();

            if (userInfo == null)
                return new AuthenticationState(user);

            var claims = await GetClaimsAsync(userInfo);

            var id = new ClaimsIdentity(claims, nameof(CookieAutheticationStateProvider));
            user = new ClaimsPrincipal(id);

            _isAuthenticated = true;
            return new AuthenticationState(user);
        }

        private async Task<User?> GetUserAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<User>("v1/auth/manage/info");
                return response;
            }
            catch 
            {
                return null;
            }
        }

        private async Task<List<Claim>> GetClaimsAsync(User user)
        {
            var claims = new List<Claim>()
            {
                new(ClaimTypes.Name, user.Email),
                new(ClaimTypes.Email, user.Email)
            };

            claims.AddRange(
                user.Claims.Where(x => x.Key != ClaimTypes.Name && 
                                        x.Key != ClaimTypes.Email)
                .Select(x => new Claim(x.Key, x.Value))
            );

            RoleClaim[]? roles;

            try
            {

                roles = await _httpClient.GetFromJsonAsync<RoleClaim[]>("v1/auth/roles");

            }
            catch
            { 
                return claims;
            }

            claims.AddRange(
                from
                    role
                in
                    roles ?? []
                where
                    !string.IsNullOrWhiteSpace(role.Type) && !string.IsNullOrWhiteSpace(role.Value)
                select
                    new Claim(role.Type, role.Value, role.ValueType, role.OriginalIssuer));

            return claims;
        }
    }
}
