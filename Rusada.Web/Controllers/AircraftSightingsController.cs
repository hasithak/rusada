using Data.Repositories.RepoImplementations;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.VM;
using Services;

namespace Rusada.Web.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class AircraftSightingsController : BaseController
    {
        private readonly IAircraftSightingService aircraftSightingService;

        public AircraftSightingsController(IAircraftSightingService aircraftSightingService)
        {
            this.aircraftSightingService = aircraftSightingService;
        }

        [HttpPost]
        public async Task Add([FromBody] AircraftSightingVM aircraftSightingVM)
        {
            var sighting = aircraftSightingVM.Adapt<AircraftSightingDTO>();
            sighting.UserId = UserId;

            await aircraftSightingService.Add(sighting, aircraftSightingVM.MediaContent);
        }

        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            await aircraftSightingService.Delete(id);
        }

        [HttpPut]
        public async Task Edit([FromBody] AircraftSightingDTO aircraftSighting)
        {
            await aircraftSightingService.Edit(aircraftSighting);
        }

        [HttpGet("{id}")]
        public async Task<AircraftSightingVM> Get([FromRoute] int id)
        {
            var sighting = await aircraftSightingService.Get(id);
            return sighting.Adapt<AircraftSightingVM>();
        }

        [HttpGet]
        public async Task<List<AircraftSightingVM>> Get()
        {
            var sightings = await aircraftSightingService.GetList(UserId);
            return sightings.Adapt<List<AircraftSightingVM>>();
        }
    }
}