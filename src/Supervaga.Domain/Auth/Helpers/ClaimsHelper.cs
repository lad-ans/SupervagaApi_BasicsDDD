using System.Security.Claims;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Supervaga.Domain.Results;
using Supervaga.Domain.Shared.Contracts.Results;
using Supervaga.Domain.Users;

namespace Supervaga.Domain.Auth.Helpers
{
    public static class ClaimsHelper
    {
        public static IResult UserGenerator(ClaimsPrincipal claimsPrincipal)
        {
            var firebase = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == "firebase")?.Value;
            if (firebase == null)
                return new ValidationErrorsResult();

            var name = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value;

            var identitiesJson = JObject.Parse(firebase)["identities"];

            var signInProvider = JObject.Parse(firebase)["sign_in_provider"];

            var firebaseIdentities = JsonConvert.DeserializeObject<FirebaseIdentities>(identitiesJson.ToString());

            var usr = new User()
            {
                Email = firebaseIdentities.email.ElementAt(0),
                Name = name,
                Role = "common",
                Provider = signInProvider.ToString(),
            };

            return new OkResult<User>(true, 1, usr);
        }
    }
    class FirebaseIdentities
    {
        public FirebaseIdentities(IEnumerable<string> email) => this.email = email;
        public IEnumerable<string> email { get; set; }
    }
}
