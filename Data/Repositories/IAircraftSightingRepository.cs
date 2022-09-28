using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IAircraftSightingRepository
    {
        Task Add(AircraftSightingDTO aircraftSighting);

        Task<List<AircraftSightingDTO>> GetList(string userId);

        Task<AircraftSightingDTO> Get(int id);

        Task Delete(int id);

        Task Edit(AircraftSightingDTO aircraftSighting);
    }
}