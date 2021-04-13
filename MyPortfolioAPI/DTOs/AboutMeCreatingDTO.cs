using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolioAPI.DTOs
{
    public class AboutMeCreatingDTO
    {
        public string EnglishDescription { get; set; }
        public string PolishDescription { get; set; }
        public IFormFile Photo { get; set; }
    }
}
