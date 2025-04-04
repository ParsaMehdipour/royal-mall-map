using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Persistence.Extensions
{
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Set auto-increment (IDENTITY) for all columns named "Id" of type int.
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void AddAutoIncrementForIntIdConvention(this ModelBuilder modelBuilder)
        {
            modelBuilder.AddValueGeneratedOnAddConvention("Id", typeof(int));
        }

        /// <summary>
        /// Set ValueGeneratedOnAdd for specific property name and type.
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <param name="propertyName">Name of property to set ValueGeneratedOnAdd for.</param>
        /// <param name="propertyType">Type of property to set ValueGeneratedOnAdd for.</param>
        public static void AddValueGeneratedOnAddConvention(this ModelBuilder modelBuilder, string propertyName, Type propertyType)
        {
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase) && property.ClrType == propertyType)
                    {
                        // Set ValueGeneratedOnAdd for the property
                        property.ValueGenerated = ValueGenerated.OnAdd;
                    }
                }
            }
        }
    }
}
