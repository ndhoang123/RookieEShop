using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace RookieEShop.BackEnd.IdentityServer
{
    public static class IdentityServerConfig
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            { 
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("rookieEShop.API", "Rookie EShop API")
            };

        public static IEnumerable<Client> Clients(IConfiguration configuration) =>
            new List<Client>
            {
                // machine to machine client
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // scopes that client has access to
                    AllowedScopes = { "rookieEShop.API" }
                },

                 // interactive ASP.NET Core MVC client
                new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { configuration["ClientUrl:mvc:RedirectUris"] },

                    PostLogoutRedirectUris = { configuration["ClientUrl:mvc:PostLogoutRedirectUris"] },

                    AllowOfflineAccess = true,

                    AccessTokenLifetime = 2592000,

                    IdentityTokenLifetime = 2592000,

                    RefreshTokenExpiration = TokenExpiration.Sliding,

                    SlidingRefreshTokenLifetime = 2592000,

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "rookieEShop.API" //testplace
                    }
                },

                new Client
                {
                    ClientId = "swagger",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,

                    RequireConsent = false,
                    RequirePkce = true,
                    
                    RedirectUris =           { configuration["ClientUrl:swaggerVsCode:RedirectUris"] },
                    PostLogoutRedirectUris = { configuration["ClientUrl:swaggerVsCode:PostLogoutRedirectUris"] },
                    AllowedCorsOrigins =     { configuration["ClientUrl:swaggerVsCode:AllowedCorsOrigins"] },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "rookieEShop.API"
                    }
                },

                new Client
                {
                    ClientId = "oidc-react",
                    ClientUri = "http://localhost:3000",

                    AllowedGrantTypes = GrantTypes.Implicit,
                    RequireClientSecret = false,

                    RedirectUris =           { configuration["ClientUrl:oidc-react:RedirectUris"] },
                    PostLogoutRedirectUris = { configuration["ClientUrl:oidc-react:PostLogoutRedirectUris"] },
                    AllowedCorsOrigins =     { configuration["ClientUrl:oidc-react:AllowedCorsOrigins"] },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "rookieEShop.API"
                    },

                    AllowOfflineAccess = true,

                    AllowAccessTokensViaBrowser = true,

                    AccessTokenLifetime = 2592000,

                    IdentityTokenLifetime = 2592000,

                    RefreshTokenExpiration = TokenExpiration.Sliding,

                    SlidingRefreshTokenLifetime = 2592000
                },
            };
    }
}