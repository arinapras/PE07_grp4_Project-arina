using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE07_grp4_Project.Shared.Domain
{
    public class Event : BaseDomainModel, IValidatableObject
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Event Name does not meet length requirements")]
        public string? eventName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? eventDateTime{ get; set; }
        [Required]
        public string? eventLocation { get; set;}
        [Required]
        public int? OrganiserId { get; set; }
        public virtual Organiser? Organiser { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //throw new NotImplementedException();

            if (eventDateTime != null)
            {
                if (eventDateTime <= DateTime.Now)
                {
                    yield return new ValidationResult("Date of Event not possible", new[] { "Date of Event" });
                }
            }
        }
    }
}
