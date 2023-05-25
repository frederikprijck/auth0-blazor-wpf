using Auth0.OidcClient;
using IdentityModel.Client;
using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Auth0_Blazor_WPF
{
    public class Auth0ClientBridge
    {
        public event Action<ClaimsPrincipal>? UserChanged;

        private readonly Auth0Client auth0Client;

        public Auth0ClientBridge(Auth0Client client)
        {
            auth0Client = client;
        }

        public async Task<LoginResult> LogInAsync()
        {
            var result = await auth0Client.LoginAsync();

            UserChanged(result.User);

            return result;
        }

        public async void LogOut()
        {
            await auth0Client.LogoutAsync();

            UserChanged(new ClaimsPrincipal(new ClaimsIdentity()));
        }
    }
}
