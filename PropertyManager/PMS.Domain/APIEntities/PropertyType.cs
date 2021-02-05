using PMS.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Domain.APIEntities
{
    public class PropertyType
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public PropertyTypeModel Convert() => new PropertyTypeModel
        {
            Id = Id,
            Name = Name
        };
    }
}
