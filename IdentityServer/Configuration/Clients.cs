using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServer.Configuration
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "onShoppingApi",
                    ClientName = "ASP.NET Core OnShopping Api",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret> {new Secret("OnPlatform".Sha256())},
                    AllowedScopes = new List<string> { "onShoppingApi.read" }
                },
                new Client
                {
                    ClientId = "onShoppingAuth",
                    ClientName = "OnShopping Mobile App",
                    ClientSecrets = new List<Secret> {new Secret("OnPlatform".Sha256())},

                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new List<string> {"onshopping:/authenticated"},
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "role",
                        "onShoppingApi.read"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "onshopping:/signout-callback-oidc",
                    },

                    RequirePkce = true,
                    AllowPlainTextPkce = false
                }
            };
        }
    }
}
