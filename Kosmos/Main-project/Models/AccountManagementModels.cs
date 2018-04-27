using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Kosmos.Models
{

    /// <summary>
    /// Interface for the class used to replace User anywhere where custom login is used
    /// </summary>
    interface ICustomPrincipal : IPrincipal
    {
        int Id { get; set; }
        string Username { get; set; }
    }

    /// <summary>
    /// Class used to replace User anywhere where custom login is used
    /// </summary>
    public class CustomPrincipal : ICustomPrincipal
    {
        public IIdentity Identity { get; private set; }
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RoleName { get; set; }

        public bool IsInRole(string role) {
            return RoleName.ToLower().Equals(role.ToLower());
        }

    }

    /// <summary>
    /// Serializable model of the CustomPrincipal class
    /// </summary>
    public class CustomPrincipalSerializeModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public int RoleName { get; set; }
    }
}