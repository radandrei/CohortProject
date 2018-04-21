using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kosmos.Extensions
{
    public static class Constants
    {
        public static class Strings
        {
            public static class JwtClaimIdentifiers
            {
                public const string Role = "role", Id = "id";
            }

            public static class JwtClaims
            {
                public const string Administrator = "Admin";
                public const string Patient = "Patient";
                public const string Assistant = "Assistant";
                public const string Doctor = "Doctor";

            }
        }
    }
}
