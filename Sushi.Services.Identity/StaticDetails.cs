using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Sushi.Services.Identity
{
    public class StaticDetails
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>() { new ApiScope("sushi", "Sushi Server") };

        public static IEnumerable<Client> Clients => 
            new List<Client>()
            {
                new Client()
                {
                    ClientId ="client",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "read", "write", "profile" }
                },
                new Client()
                {
                    ClientId ="sushi",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "https://localhost:7294/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:7294/signout-callback-oidc" },
                    AllowedScopes = new List<string>()
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Profile,
                        "sushi"
                    }
                }
            };
    }
}
