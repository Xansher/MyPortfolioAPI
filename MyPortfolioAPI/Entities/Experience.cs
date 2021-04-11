using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolioAPI.Entities
{
    public class Experience
    {
        public int Id { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string Company { get; set; }
        public string EnglishDuties { get; set; }
        public string PolishDuties { get; set; }
    }
}
