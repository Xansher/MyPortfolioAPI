using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolioAPI.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ContactsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ContactDTO>> Get()
        {
            var contact = await context.Contacts.FirstOrDefaultAsync(x => x.Id == 1);
            return mapper.Map<ContactDTO>(contact);
        }
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ContactDTO contactDTO)
        {
            var contact = await context.Contacts.FirstOrDefaultAsync(x => x.Id == 1);
            if(contact == null)
            {
                return NotFound();
            }
            contact = mapper.Map(contactDTO, contact);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
