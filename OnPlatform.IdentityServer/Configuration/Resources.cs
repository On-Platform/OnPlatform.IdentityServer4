using IdentityServer4.Models;

namespace OnPlatform.IdentityServer.Configuration
{
    public class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string> {"role"}
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource
                {
                    Name = "onShoppingApi",
                    DisplayName = "OnShopping Api",
                    Description = "Allow the application to access OnShopping Api on your behalf",
                    Scopes = new List<string> { "onShoppingApi.read", "onShoppingApi.write"},
                    ApiSecrets = new List<Secret> {new Secret("OnPlatform".Sha256())},
                    UserClaims = new List<string> {"role"}
                }
            };
        }
    }
}
