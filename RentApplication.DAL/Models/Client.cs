using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentApplication.DAL.Models
{
    public class Client
    {
        [Key] public int Id { get; set; }
        [Required, MaxLength(200)] public string FirstName { get; set; }
        [Required, MaxLength(200)] public string LastName { get; set; }
        [Required, MaxLength(200)] public string ContactPhone { get; set; }
        public virtual IEnumerable<Property> Properties { get; set; } = new List<Property>();
    }
}