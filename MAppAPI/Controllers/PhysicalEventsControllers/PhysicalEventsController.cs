using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using MAppAPI.Models.Responses.PhysicalEvents;
using MApp.DataAccess.Models.PhysicalEvents;
using MAppAPI.Models.Requests.PhysicalEvents;
using MApp.DataAccess.Context;

namespace MAppAPI.Controllers.PhysicalEventsControllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhysicalEventsController : ControllerBase
    {
        private readonly ILogger<PhysicalEventsController> _logger;
        MAppDbContext dbContext;

        public PhysicalEventsController(ILogger<PhysicalEventsController> logger, MAppDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }
        [Authorize]
        [HttpPost]
        public async Task<List<PhysicalEventForSending>> ReturnEventsList([FromBody] PhysicalEventsFilterRequest filterRequest)
        {
            if (filterRequest == null)
                return new List<PhysicalEventForSending>();
            var eventsList = new List<PhysicalEvent>();
            if (filterRequest.IsDefaultRequest)
                eventsList = await dbContext.PhysicalEvents.Include(x => x.Users).Include(x => x.Category).OrderBy(x => x.EventDateGMT)
                    .Where(x => x.SpotsLeft > 0 && x.Latitude > filterRequest.LatitudeMin && x.Latitude < filterRequest.LatitudeMax
                    && x.Longtitude > filterRequest.LongtitudeMin && x.Longtitude < filterRequest.LongtitudeMax).Take(100).ToListAsync();
            else
            {
                if (filterRequest.Subcategory == string.Empty)
                    eventsList = await dbContext.PhysicalEvents.Include(x => x.Users).Include(x => x.Category).OrderBy(x => x.EventDateGMT)
                        .Where(x => x.SpotsLeft > 0 && x.SpotsLeft > filterRequest.SpotsLeftMin && x.Spots < filterRequest.SpotsMax
                        && filterRequest.Categories.Contains(x.Category) && x.EventDateGMT > filterRequest.EventDateFrom && x.EventDateGMT < filterRequest.EventDateTo
                        && x.Latitude > filterRequest.LatitudeMin && x.Latitude < filterRequest.LatitudeMax
                        && x.Longtitude > filterRequest.LongtitudeMin && x.Longtitude < filterRequest.LongtitudeMax).Take(100).ToListAsync();
                else
                    eventsList = await dbContext.PhysicalEvents.Include(x => x.Users).Include(x => x.Category).OrderBy(x => x.EventDateGMT)
                        .Where(x => x.SpotsLeft > 0 && x.SpotsLeft > filterRequest.SpotsLeftMin && x.Spots < filterRequest.SpotsMax
                        && filterRequest.Categories.Contains(x.Category) && x.EventDateGMT > filterRequest.EventDateFrom && x.EventDateGMT < filterRequest.EventDateTo
                        && x.Subcategory != null && x.Subcategory != string.Empty && filterRequest.Subcategory.Contains(x.Subcategory)
                        && x.Latitude > filterRequest.LatitudeMin && x.Latitude < filterRequest.LatitudeMax
                        && x.Longtitude > filterRequest.LongtitudeMin && x.Longtitude < filterRequest.LongtitudeMax).Take(100).ToListAsync();
            }
            return await PhysicalEventForSending.CreateList(eventsList);
        }
    }
}
