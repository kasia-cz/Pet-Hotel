using System.ComponentModel.DataAnnotations;

namespace PetHotel.Data.Entities
{
    public class PetType
    {
        [Key]
        public string Name { get; set; }
        public int LimitOfPlaces { get; set; }
    }
}
