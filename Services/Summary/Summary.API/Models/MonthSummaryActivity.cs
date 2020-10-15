using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Summary.API.Models
{
    public class MonthSummaryActivity
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public long? ActvityID { get; set; }
        public string? Name { get; set; }
        public float? Distance { get; set; }
        public int? ElapsedTime { get; set; }
        public string? Type { get; set; }
        public DateTime? StartDate { get; set; }

        public MonthSummaryActivity()
        {
        }
    }
}
