using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Media : BaseEntity
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public AircraftSighting AircraftSighting { get; set; }
        public int AircraftSightingId { get; set; }
    }
}