using Data.DBContexts;
using Data.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.RepoImplementations
{
    public class AircraftSightingRepository : IAircraftSightingRepository
    {
        private readonly ApplicationDbContext dbContext;

        public AircraftSightingRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Add(AircraftSightingDTO aircraftSighting)
        {
            var sighting = aircraftSighting.Adapt<AircraftSighting>();
            dbContext.AircraftSightings.Add(sighting);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var sighting = dbContext.AircraftSightings.Find(id);
            dbContext.AircraftSightings.Remove(sighting);
            await dbContext.SaveChangesAsync();
        }

        public async Task Edit(AircraftSightingDTO aircraftSighting)
        {
            var sighting = aircraftSighting.Adapt<AircraftSighting>();
            dbContext.AircraftSightings.Update(sighting);
            await dbContext.SaveChangesAsync();
        }

        public async Task<AircraftSightingDTO> Get(int id)
        {
            var sighting = await dbContext.AircraftSightings.FindAsync(id);
            return sighting.Adapt<AircraftSightingDTO>();
        }

        public async Task<List<AircraftSightingDTO>> GetList(string userId)
        {
            var sightings = await dbContext.AircraftSightings
                                                .Include(a => a.Medias)
                                                .Where(x => x.UserId == userId).ToListAsync();

            return sightings.Adapt<List<AircraftSightingDTO>>();
        }
    }
}