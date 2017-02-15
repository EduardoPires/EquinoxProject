using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Equinox.Infra.Data.Extensions;
using Equinox.Domain.Core.Events;


namespace Equinox.Infra.Data.Mappings
{    
    public class StoredEventMap : EntityTypeConfiguration<StoredEvent>
    {
        public override void Map(EntityTypeBuilder<StoredEvent> builder)
        {
            builder.Property(c => c.Timestamp)
                .HasColumnName("CreationDate");

            builder.Property(c => c.MessageType)
                .HasColumnName("Action")
                .HasColumnType("varchar(100)");
  
        }
    }
}