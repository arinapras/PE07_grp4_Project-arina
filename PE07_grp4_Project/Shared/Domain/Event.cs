using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE07_grp4_Project.Shared.Domain
{
    public class Event : BaseDomainModel
    {
        public string? eventName { get; set; } 
        public DateTime eventDateTime{ get; set; }
        public string? eventLocation { get; set;}
        public int OrganiserId { get; set; }
        public virtual Organiser? Organiser { get; set; }
    }
}
