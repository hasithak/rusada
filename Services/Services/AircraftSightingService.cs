using Data.Entities;
using Data.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class AircraftSightingService : IAircraftSightingService
    {
        private readonly IAircraftSightingRepository aircraftSightingRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AircraftSightingService(IAircraftSightingRepository aircraftSightingRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            this.aircraftSightingRepository = aircraftSightingRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task Add(AircraftSightingDTO aircraftSighting, string[] medias)
        {
            var savedFileNames = await SaveSightingMedias(medias);

            List<MediaDTO> mediaDTOs = new List<MediaDTO>();
            savedFileNames.ForEach(x =>
            {
                mediaDTOs.Add(new MediaDTO()
                {
                    FileName = x
                });
            });
            aircraftSighting.Medias = mediaDTOs;

            await aircraftSightingRepository.Add(aircraftSighting);
        }

        private async Task<List<string>> SaveSightingMedias(string[] medias)
        {
            List<string> finleNames = new List<string>();

            string webRootPath = webHostEnvironment.WebRootPath;

            string resourcePath = Path.Combine(webRootPath, "resources");

            if (!System.IO.Directory.Exists(resourcePath))
            {
                System.IO.Directory.CreateDirectory(resourcePath);
            }

            foreach (var mediasItem in medias)
            {
                var imageName = $"{Guid.NewGuid().ToString()}.jpg"; ;
                string imgPath = Path.Combine(resourcePath, imageName);

                byte[] imageBytes = Convert.FromBase64String(mediasItem.Substring(mediasItem.LastIndexOf(',') + 1));

                await File.WriteAllBytesAsync(imgPath, imageBytes);

                finleNames.Add(imageName);
            }
            return finleNames;
        }

        public async Task Delete(int id)
        {
            await aircraftSightingRepository.Delete(id);
        }

        public async Task Edit(AircraftSightingDTO aircraftSighting)
        {
            await aircraftSightingRepository.Edit(aircraftSighting);
        }

        public async Task<AircraftSightingDTO> Get(int id)
        {
            return await aircraftSightingRepository.Get(id);
        }

        public async Task<List<AircraftSightingDTO>> GetList(string userId)
        {
            return await aircraftSightingRepository.GetList(userId);
        }
    }
}