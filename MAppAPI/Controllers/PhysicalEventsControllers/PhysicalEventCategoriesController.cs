using MApp.DataAccess.Context;
using MApp.DataAccess.Models.PhysicalEvents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MAppAPI.Controllers.PhysicalEventsControllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhysicalEventCategoriesController : ControllerBase
    {
        private readonly ILogger<PhysicalEventCategoriesController> _logger;
        MAppDbContext dbContext;
        public PhysicalEventCategoriesController(ILogger<PhysicalEventCategoriesController> logger, MAppDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }
        [HttpGet]
        [Authorize]
        public List<PhysicalEventCategory> ReturnCategoriesList()
        {
            var categoriesList = dbContext.PhysicalEventCategories.ToList();
            return categoriesList;
        }
    }
}
