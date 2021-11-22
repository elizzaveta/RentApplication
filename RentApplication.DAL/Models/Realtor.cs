using System.ComponentModel.DataAnnotations;

namespace RentApplication.DAL.Models
{
    public class Realtor
    {
        [Key] public int Id { get; set; }
        [Required, MaxLength(200)] public string FirstName { get; set; }
        [Required, MaxLength(200)] public string LastName { get; set; }
        [Required, MaxLength(200)] public string ContactPhone { get; set; }
        [MaxLength(200)] public string Email { get; set; }
        [MaxLength(200)] public string StartWorkDate { get; set; }
    }
}