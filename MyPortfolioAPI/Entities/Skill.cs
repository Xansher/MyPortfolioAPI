using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolioAPI.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="The field with name {0} is required")]
        [StringLength(50)]
        public string Name { get; set; }
        public string EnglishDescription { get; set; }
        public string PolishDescription { get; set; }
        public string Icon { get; set; }
    }
}
