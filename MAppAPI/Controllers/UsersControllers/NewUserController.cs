using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MApp.DataAccess.Context;
using MApp.DataAccess.Models.Users;

namespace MAppAPI.Controllers.UsersControllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewUserController : ControllerBase
    {
        private readonly ILogger<NewUserController> _logger;
        MAppDbContext dbContext;

        public NewUserController(ILogger<NewUserController> logger, MAppDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        [HttpPost(Name = "PostNewUserController")]
        public async Task<string> Post([FromBody] UserForRegistration userToBeRegistered)
        {
            if (userToBeRegistered == null || userToBeRegistered.Username == null || userToBeRegistered.Username == string.Empty || userToBeRegistered.EncryptedPassword == null || userToBeRegistered.EncryptedPassword == string.Empty || userToBeRegistered.EMail == null || userToBeRegistered.EMail == string.Empty)
                return "-2";// "Something went wrong with your request";
            var userNameExisting = await dbContext.AllUsers.AnyAsync(x => x.Username == userToBeRegistered.Username);
            var eMailRegistered = await dbContext.AllUsers.AnyAsync(x => x.EMail == userToBeRegistered.EMail);
            if (eMailRegistered)
                return "0";
            else if (userNameExisting)
                return "-1";
            else
            {
                var user = new User(userToBeRegistered.Username, userToBeRegistered.EncryptedPassword, userToBeRegistered.EMail, 1);
                dbContext.AllUsers.Add(user);
                await dbContext.SaveChangesAsync();
                return "ok";
            }
        }
        public class UserForRegistration
        {
            public string Username { get; set; }
            public string EncryptedPassword { get; set; }
            public string EMail { get; set; }
        }
    }
}