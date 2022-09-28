using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities;

public class AircraftSighting : BaseEntity
{
    public int Id { get; set; }

    [MaxLength(200), Required]
    public string Make { get; set; }

    [MaxLength(200), Required]
    public string Model { get; set; }
    public string Registration { get; set; }

    [Required]
    public string Location { get; set; }

    public User User { get; set; }
    public string UserId { get; set; }

    public DateTime AddedDate { get; set; }
    public List<Media> Medias { get; set; }
}