// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


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

                    RedirectUris = { configuration["ClientAzureUrl:mvc:RedirectUris"] },

                    PostLogoutRedirectUris = { configuration["ClientAzureUrl:mvc:PostLogoutRedirectUris"] },

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
                    
                    RedirectUris =           { configuration["ClientAzureUrl:swagger:RedirectUris"] },
                    PostLogoutRedirectUris = { configuration["ClientAzureUrl:swagger:PostLogoutRedirectUris"] },
                    AllowedCorsOrigins =     { configuration["ClientAzureUrl:swagger:AllowedCorsOrigins"] },

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
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Implicit,
                    RequireClientSecret = false,

                    RedirectUris =           { configuration["ClientAzureUrl:oidc-react:RedirectUris"] },
                    PostLogoutRedirectUris = { configuration["ClientAzureUrl:oidc-react:PostLogoutRedirectUris"] },
                    AllowedCorsOrigins =     { configuration["ClientAzureUrl:oidc-react:AllowedCorsOrigins"] },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "rookieEShop.API"
                    },

                    AllowOfflineAccess = true,
                    AllowAccessTokensViaBrowser = true
                },
            };
    }
}