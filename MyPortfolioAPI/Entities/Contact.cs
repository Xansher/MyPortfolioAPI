using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolioAPI.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string Linkedin { get; set; }
        public string Github { get; set; }
        public string Instagram { get; set; }
        public string Email { get; set; }
    }
}
