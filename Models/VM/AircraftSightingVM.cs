using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.VM
{
    public class AircraftSightingVM
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Registration { get; set; }
        public string Location { get; set; }
        public DateTime AddedDate { get; set; }
        public string[] MediaContent { get; set; }
        public List<MediaDTO>? Medias { get; set; }
    }
}