using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE07_grp4_Project.Shared.Domain
{
    public class Organiser : BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Organiser Name does not meet length requirements")]
        public string? organiserName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(6|8|9)\d{7}", ErrorMessage = "Organiser Contact is not a valid phone number")]
        public string? organiserContact { get; set; }
    }
}
