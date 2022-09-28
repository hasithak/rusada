using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IAircraftSightingService
    {
        Task Add(AircraftSightingDTO aircraftSighting, string[] medias);

        Task<List<AircraftSightingDTO>> GetList(string userId);

        Task<AircraftSightingDTO> Get(int id);

        Task Delete(int id);

        Task Edit(AircraftSightingDTO aircraftSighting);
    }
}