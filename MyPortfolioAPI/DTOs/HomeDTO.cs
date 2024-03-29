﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolioAPI.DTOs
{
    public class HomeDTO
    {
        public int Id { get; set; }
        public string Language { get; set; }
        public string Label { get; set; }
        public string Text { get; set; }
        public string UnderText { get; set; }
        public string Image { get; set; }
        public string Photo { get; set; }
    }
}
