using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentApplication.DAL.Models
{
    public class Request
    {
        [Key] public int Id { get; set; }
        [Required] public virtual Client Client { get; set; }
        [Required] public virtual Property Property { get; set; }
        [Required] public virtual Realtor Realtor { get; set; }
        public virtual Tenant Tenant { get; set; }
        [Required] public int IsActive { get; set; }
    }
}