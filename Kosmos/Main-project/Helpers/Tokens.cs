﻿using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Kosmos.Extensions;
using Kosmos.Helpers;
using Kosmos.Models;
using Newtonsoft.Json;

namespace Kosmos.Helpers
{
    public class Tokens
    {
        public static async Task<string> GenerateJwt(ClaimsIdentity identity, IJwtFactory jwtFactory, string userName, JwtIssuerOptions jwtOptions, JsonSerializerSettings serializerSettings)
        {
            var response = new
            {
                id = identity.Claims.Single(c => c.Type == Constants.Strings.JwtClaimIdentifiers.Id).Value,
                auth_token = await jwtFactory.GenerateEncodedToken(userName, identity),
                expires_in = (int)jwtOptions.ValidFor.TotalSeconds
            };

            return JsonConvert.SerializeObject(response, serializerSettings);
        }
    }
}