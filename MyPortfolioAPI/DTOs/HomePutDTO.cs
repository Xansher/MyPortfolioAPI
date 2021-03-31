using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolioAPI.DTOs
{
    public class HomePutDTO
    {
        public string EnglishLabel { get; set; }
        public string EnglishText { get; set; }
        public string EnglishUnderText { get; set; }
        public string PolishLabel { get; set; }
        public string PolishText { get; set; }
        public string PolishUnderText { get; set; }
        public string Image { get; set; }
        public string Photo { get; set; }
    }
}
