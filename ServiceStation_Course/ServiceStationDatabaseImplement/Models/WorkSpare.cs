using System.ComponentModel.DataAnnotations;

namespace ServiceStationDatabaseImplement.Models
{
    public class WorkSpare
    {
        public int Id { get; set; }

        [Required]
        public int WorkId { get; set; }

        [Required]
        public int SpareId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Work Work { get; set; } = new();

        public virtual Spare Spare { get; set; } = new();

    }
}
