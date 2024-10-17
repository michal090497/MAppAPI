using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using MAppAPI.Models.Responses.OnlineEvents;
using MApp.DataAccess.Models.OnlineEvents;
using MAppAPI.Models.Requests.OnlineEvents;
using MApp.DataAccess.Context;

namespace MAppAPI.Controllers.OnlineEventsControllers
{
    [ApiController]
    [Route("[controller]")]
    public class OnlineEventsController : ControllerBase
    {
        private readonly ILogger<OnlineEventsController> _logger;
        MAppDbContext dbContext;

        public OnlineEventsController(ILogger<OnlineEventsController> logger, MAppDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }
        [Authorize]
        [HttpPost]
        public async Task<List<OnlineEventForSending>> ReturnEventsList([FromBody] OnlineEventsFilterRequest filterRequest)
        {
            if (filterRequest == null)
                return new List<OnlineEventForSending>();
            var eventsList = new List<OnlineEvent>();
            if (filterRequest.IsDefaultRequest)
                eventsList = await dbContext.OnlineEvents.Include(x => x.Users).Include(x => x.Category).OrderBy(x => x.EventDateGMT).Where(x => x.SpotsLeft > 0).Take(100).ToListAsync();
            else
            {
                if (filterRequest.Subcategory == string.Empty)
                    eventsList = await dbContext.OnlineEvents.Include(x => x.Users).Include(x => x.Category).OrderBy(x => x.EventDate)
                        .Where(x => x.SpotsLeft > 0 && x.SpotsLeft > filterRequest.SpotsLeftMin && x.Spots < filterRequest.SpotsMax
                        && filterRequest.Categories.Contains(x.Category) && x.EventDate > filterRequest.EventDateFrom && x.EventDate < filterRequest.EventDateTo).Take(100).ToListAsync();
                else
                    eventsList = await dbContext.OnlineEvents.Include(x => x.Users).Include(x => x.Category).OrderBy(x => x.EventDateGMT)
                        .Where(x => x.SpotsLeft > 0 && x.SpotsLeft > filterRequest.SpotsLeftMin && x.Spots < filterRequest.SpotsMax
                        && filterRequest.Categories.Contains(x.Category) && x.EventDateGMT > filterRequest.EventDateFrom && x.EventDateGMT < filterRequest.EventDateTo
                        && x.Subcategory != null && x.Subcategory != string.Empty && filterRequest.Subcategory.Contains(x.Subcategory)).Take(100).ToListAsync();
            }
            return await OnlineEventForSending.CreateList(eventsList);
        }
    }
}
