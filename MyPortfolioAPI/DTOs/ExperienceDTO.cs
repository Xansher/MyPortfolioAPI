using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolioAPI.DTOs
{
    public class ExperienceDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public string EnglishDuties { get; set; }
        public string PolishDuties { get; set; }
    }
}
