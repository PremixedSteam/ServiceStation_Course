using System.ComponentModel.DataAnnotations;

namespace ServiceStationDatabaseImplement.Models
{
    public class WorkMaintence
    {
        public int Id { get; set; }

        [Required]
        public int WorkId { get; set; }

        [Required]
        public int MaintenceId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Work Work { get; set; } = new();

        public virtual Maintenance Maintenance { get; set; } = new();

    }
}
