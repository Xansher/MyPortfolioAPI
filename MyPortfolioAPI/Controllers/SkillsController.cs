using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioAPI.DTOs;
using MyPortfolioAPI.Entities;
using MyPortfolioAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolioAPI.Controllers
{
    [Route("api/skills")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public class SkillsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IFileStorageService fileStorageService;
        private readonly string containerName = "skills";

        public SkillsController(ApplicationDbContext context, IMapper mapper, IFileStorageService fileStorageService)
        {
            this.context = context;
            this.mapper = mapper;
            this.fileStorageService = fileStorageService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<SkillDTO>>> Get()
        {   
            var skills= await context.Skills.OrderBy(x => x.Order).ToListAsync();
            return mapper.Map<List<SkillDTO>>(skills);      
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SkillDTO>> Get(int id)
        {
            var skill = await context.Skills.FirstOrDefaultAsync(x => x.Id == id);
            if (skill == null)
            {
                return NotFound();
            }
            return mapper.Map<SkillDTO>(skill);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] SkillCreationDTO skillCreationDTO)
        {
            var skill=mapper.Map<Skill>(skillCreationDTO);
            if(skillCreationDTO.Icon!= null)
            {
                skill.Icon = await fileStorageService.SaveFile(containerName, skillCreationDTO.Icon);
            }

            context.Add(skill);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromForm] SkillCreationDTO skillCreationDTO)
        {
            var skill = await context.Skills.FirstOrDefaultAsync(x=>x.Id == id);
            
            if (skill == null)
            {
                return NotFound();
            }

            skill = mapper.Map(skillCreationDTO, skill);

            if (skillCreationDTO.Icon != null)
            {
                skill.Icon = await fileStorageService.EditFile(containerName, skillCreationDTO.Icon, skill.Icon);
            }

            await context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPut("order")]
        public async Task<ActionResult> UpdateOrder([FromBody] List<SkillOrderDTO> skillsOrders)
        {
            var skills = await context.Skills.ToListAsync();
            skillsOrders.ForEach(x =>
            {
                var skill= skills.FirstOrDefault(y => y.Id == x.SkillId);
                skill.Order = x.Order;
            });
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var skill = await context.Skills.FirstOrDefaultAsync(x => x.Id == id);

            if (skill == null)
            {
                return NotFound();
            }

            context.Remove(skill);
            await context.SaveChangesAsync();
            await fileStorageService.DeleteFile(skill.Icon, containerName);

            return NoContent();

        }

    }
}
