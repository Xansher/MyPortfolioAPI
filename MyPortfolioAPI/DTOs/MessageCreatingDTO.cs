using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolioAPI.DTOs
{
    public class MessageCreatingDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MessageContent { get; set; }
    }
}
