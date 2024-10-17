using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;

namespace MApp.Common.Extensions
{
    public static class HttpRequestExtension
    {
        public static int GetUserID(this HttpRequest request)
        {
            string token = request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var decodedToken = handler.ReadToken(token) as JwtSecurityToken;
            if (decodedToken == null)
                return -1;
            return int.Parse(decodedToken.Claims.First(claim => claim.Type == "userID").Value);
        }
    }
}
