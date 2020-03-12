using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using IO.Swagger.Model;

namespace Summary.API.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }
        public DateTime LastDownload { get; set; }
        public ICollection<MonthSummaryActivity> MonthSummaries { get; set; }
    }
}
