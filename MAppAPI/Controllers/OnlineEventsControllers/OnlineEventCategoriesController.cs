using MApp.DataAccess.Context;
using MApp.DataAccess.Models.OnlineEvents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MAppAPI.Controllers.OnlineEventsControllers
{
    [ApiController]
    [Route("[controller]")]
    public class OnlineEventCategoriesController : ControllerBase
    {
        private readonly ILogger<OnlineEventCategoriesController> _logger;
        MAppDbContext dbContext;
        public OnlineEventCategoriesController(ILogger<OnlineEventCategoriesController> logger, MAppDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }
        [HttpGet]
        [Authorize]
        public List<OnlineEventCategory> ReturnCategoriesList()
        {
            var categoriesList = dbContext.OnlineEventCategories.ToList();
            return categoriesList;
        }
    }
}
