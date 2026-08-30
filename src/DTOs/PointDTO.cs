using System.ComponentModel.DataAnnotations;

namespace SquaresAPI.src.DTOs;

public class PointDTO
{
    [Required]
    public int? X { get; set; }
    [Required]
    public int? Y { get; set; }
}
