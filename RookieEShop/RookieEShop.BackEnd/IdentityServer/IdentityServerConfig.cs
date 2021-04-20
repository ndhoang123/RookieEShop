// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
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

        public static IEnumerable<Client> Clients =>
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

                    RedirectUris = { "https://rookieshop.azurewebsites.net/signin-oidc" },

                    PostLogoutRedirectUris = { "https://rookieshop.azurewebsites.net/signout-callback-oidc" },

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

                    RedirectUris =           { $"https://rookieeshop.azurewebsites.net/swagger/oauth2-redirect.html" },
                    PostLogoutRedirectUris = { $"https://rookieeshop.azurewebsites.net/swagger/oauth2-redirect.html" },
                    AllowedCorsOrigins =     { $"https://rookieeshop.azurewebsites.net" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "rookieEShop.API"
                    }
                },
            };
    }
}