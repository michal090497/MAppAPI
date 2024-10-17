using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using MApp.DataAccess.Context;
using MAppAPI.Models.Responses.Users;
using MApp.Common.Helpers;

namespace MAppAPI.Controllers.UsersControllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private IConfiguration _config;
        MAppDbContext dbContext;
        JWTHelper jWTHelper;

        public LoginController(ILogger<LoginController> logger, MAppDbContext dbContext, IConfiguration config, JWTHelper jWTHelper)
        {
            _logger = logger;
            this.dbContext = dbContext;
            _config = config;
            this.jWTHelper = jWTHelper;
        }

        [HttpPost(Name = "GetLoginAuthentication")]
        public async Task<string> Post([FromBody] UserForLogin userToBeLogged)
        {
            /*var userFound = database.allUsers.Any(x => x.username == username);
            var isPasswordCorrect = database.allUsers.Any(x => x.username == username && x.encryptedPassword == encryptedPassword);
            if (!userFound)
                return "Account with provided login doesn't exist";
            else if (!isPasswordCorrect) return*/
            if (userToBeLogged == null || userToBeLogged.Username == null || userToBeLogged.Username == string.Empty || userToBeLogged.EncryptedPassword == null || userToBeLogged.EncryptedPassword == string.Empty)
                return "-1";// "Something went wrong with your request";
            var user = await dbContext.AllUsers.FirstOrDefaultAsync(x => x.Username.Equals(userToBeLogged.Username) && x.EncryptedPassword.Equals(userToBeLogged.EncryptedPassword));
            if (user == null)
                return "0";
            var token = jWTHelper.GenerateAndSaveUserToken(user.ID);
            var tempUser = new TempUser(user, token);
            string resp = tempUser != null ? JsonConvert.SerializeObject(tempUser) : "0";//"There is no such an account :(";
            return resp;
        }
        public class UserForLogin
        {
            public string Username { get; set; }
            public string EncryptedPassword { get; set; }
        }
    }
}
