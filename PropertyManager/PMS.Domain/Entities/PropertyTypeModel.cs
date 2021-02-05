using PMS.Domain.APIEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Domain.Entities
{
    public sealed class PropertyTypeModel : IConvertModel<PropertyTypeModel, PropertyType>
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public PropertyType Convert() => new PropertyType
        {
            Id = Id,
            Name = Name
        };
    }
}
