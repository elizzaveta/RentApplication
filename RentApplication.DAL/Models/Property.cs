using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentApplication.DAL.Models
{
    public class Property
    {
        [Key] public int Id { get; set; }
        [Required] public virtual Client Client { get; set; }
        [Required, MaxLength(200)] public string Type { get; set; }
        [Required] public double Area { get; set; }
        [Required] public int NumOfRooms { get; set; }
        [Required] public int FloorNum { get; set; }
        public int BuildingYear { get; set; }
        [Required, MaxLength(200)] public string Address { get; set; }
        [MaxLength(200)] public string WallsMaterial { get; set; }
        [MaxLength(200)] public string MinCost { get; set; }

        // public virtual Request Request { get; set; }
    }
}