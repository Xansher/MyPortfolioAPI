using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioAPI.DTOs;
using MyPortfolioAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolioAPI.Controllers
{
    [ApiController]
    [Route("api/experiences")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public class ExperiencesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ExperiencesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<ExperienceDTO>>> Get()
        {
            var expList = await context.Experiences.OrderByDescending(x=> x.StartDate).ToListAsync();

            return mapper.Map<List<ExperienceDTO>>(expList);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ExperienceDTO>> Get(int id)
        {
            var exp = await context.Experiences.FirstOrDefaultAsync(x=> x.Id == id);
            if (exp == null)
            {
                return NotFound();
            }
            return mapper.Map<ExperienceDTO>(exp);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ExperienceCreatingDTO experienceCreatingDTO)
        {
            var exp = mapper.Map<Experience>(experienceCreatingDTO);
            context.Add(exp);
            await context.SaveChangesAsync();
            return NoContent();
        }
        
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ExperienceCreatingDTO experienceCreatingDTO)
        {
            var exp = await context.Experiences.FirstOrDefaultAsync(x => x.Id == id);
            if (exp == null)
            {
                return NotFound();
            }
            exp = mapper.Map(experienceCreatingDTO, exp);
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exp = await context.Experiences.FirstOrDefaultAsync(x => x.Id == id);
            if (exp == null)
            {
                return NotFound();
            }
            context.Remove(exp);
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}
