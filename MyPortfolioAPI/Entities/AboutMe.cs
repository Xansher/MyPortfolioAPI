using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolioAPI.Entities
{
    public class AboutMe
    {
        public int Id { get; set; }
        public string EnglishDescription { get; set; }
        public string PolishDescription { get; set; }
        public string Photo { get; set; }
    }
}
