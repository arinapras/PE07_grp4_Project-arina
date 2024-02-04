using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PE07_grp4_Project.Shared.Domain;
using System.Drawing;

namespace PE07_grp4_Project.Server.Configurations.Entities
{
    public class OrganiserSeedConfiguration : IEntityTypeConfiguration<Organiser>
    {
        public void Configure(EntityTypeBuilder<Organiser> builder)
        {
            builder.HasData(
                    new Organiser
                    {
                        Id = 1,
                        organiserName = "Test Organiser",
                        organiserContact = "12345678",
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        CreatedBy = "System",
                        UpdatedBy = "System"
                    }
                    );
        }
    }
}
