using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioAPI.DTOs;
using MyPortfolioAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolioAPI.Controllers
{
    [Route("api/messages")]
    [ApiController]
    public class MessagesController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MessagesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MessageCreatingDTO messageCreatingDTO)
        {
            var message = mapper.Map<Message>(messageCreatingDTO);
            message.Date = DateTime.Now;
            context.Add(message);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
