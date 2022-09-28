using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class AircraftSightingDTO
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Registration { get; set; }
        public string Location { get; set; }
        public DateTime AddedDate { get; set; }
        public List<MediaDTO>? Medias { get; set; }
        public string UserId { get; set; }
    }
}