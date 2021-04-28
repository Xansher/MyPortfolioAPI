using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolioAPI.DTOs
{
    public class SkillDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EnglishDescription { get; set; }
        public string PolishDescription { get; set; }
        public string Icon { get; set; }
    }
}
