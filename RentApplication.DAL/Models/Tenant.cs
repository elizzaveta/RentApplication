using System.ComponentModel.DataAnnotations;

namespace RentApplication.DAL.Models
{
    public class Tenant
    {
        [Key] public int Id { get; set; }
        [Required, MaxLength(200)] public string FirstName { get; set; }
        [Required, MaxLength(200)] public string LastName { get; set; }
        [Required, MaxLength(200)] public string ContactPhone { get; set; }
    }
}