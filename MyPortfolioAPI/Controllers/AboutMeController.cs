using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioAPI.DTOs;
using MyPortfolioAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolioAPI.Controllers
{
    [Route("api/aboutme")]
    [ApiController]
    public class AboutMeController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IFileStorageService fileStorageService;
        private string containerName= "aboutme";

        public AboutMeController(ApplicationDbContext context, IMapper mapper, IFileStorageService fileStorageService)
        {
            this.context = context;
            this.mapper = mapper;
            this.fileStorageService = fileStorageService;
        }

        [HttpGet]
        public async Task<ActionResult<AboutMeDTO>> Get()
        {
            var about=await context.AboutMe.FirstOrDefaultAsync();
            return mapper.Map<AboutMeDTO>(about);
        }
        
        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public async Task<ActionResult> Put([FromForm] AboutMeCreatingDTO creatingDTO)
        {
            var about = await context.AboutMe.FirstOrDefaultAsync();

            about = mapper.Map(creatingDTO, about);
            if(creatingDTO.Photo != null)
            {
                about.Photo = await fileStorageService.EditFile(containerName, creatingDTO.Photo, about.Photo);
            }

            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}
