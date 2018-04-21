using System.Security.Claims;
using System.Threading.Tasks;

namespace Kosmos.Helpers
{
    public interface IJwtFactory
    {
        Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);
        ClaimsIdentity GenerateClaimsIdentity(string userName, int id, string role);
    }
}