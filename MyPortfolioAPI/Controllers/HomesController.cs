using AutoMapper;
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
    [Route("api/homes")]
    [ApiController]
    public class HomesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IFileStorageService fileStorageService;
        private readonly IMapper mapper;
        private readonly string containerName = "homes";

        public HomesController(ApplicationDbContext context, IFileStorageService fileStorageService, IMapper mapper)
        {
            this.context = context;
            this.fileStorageService = fileStorageService;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<HomeDTO>> Get(int id)
        {
            var home=await context.Homes.FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<HomeDTO>(home);

        }

        [HttpGet("putget")]
        public async Task<ActionResult<HomePutDTO>> PostGet()
        {
            var englishHome = await context.Homes.FirstOrDefaultAsync(x => x.Language == "english");
            var polishHome = await context.Homes.FirstOrDefaultAsync(x => x.Language == "polish");
            if (englishHome == null || polishHome == null)
            {
                return NotFound();
            }
            return new HomePutDTO() {
                EnglishLabel = englishHome.Label,
                EnglishText = englishHome.Text,
                EnglishUnderText = englishHome.UnderText,
                Image = englishHome.Image,
                Photo = englishHome.Photo,
                PolishLabel = polishHome.Label,
                PolishText = polishHome.Text,
                PolishUnderText = polishHome.UnderText
            };
        }

        [HttpPut]
        public async Task<ActionResult> Put( [FromForm] HomeCreationDTO homeCreationDTO)
        {
            var englishHome = await context.Homes.FirstOrDefaultAsync(x => x.Language == "english");
            var polishHome = await context.Homes.FirstOrDefaultAsync(x => x.Language == "polish");

            if (englishHome == null || polishHome == null)
            {
                return NotFound();
            }
            englishHome.Label = homeCreationDTO.EnglishLabel;
            englishHome.Text = homeCreationDTO.EnglishText;
            englishHome.UnderText = homeCreationDTO.EnglishUnderText;

            polishHome.Label = homeCreationDTO.PolishLabel;
            polishHome.Text = homeCreationDTO.PolishText;
            polishHome.UnderText = homeCreationDTO.PolishUnderText;

            if (homeCreationDTO.Image != null)
            {
                var route = await fileStorageService.EditFile(containerName, homeCreationDTO.Image, englishHome.Image);
                englishHome.Image = route;
                polishHome.Image = route;
            }
            if (homeCreationDTO.Photo != null)
            {
                var route = await fileStorageService.EditFile(containerName, homeCreationDTO.Photo, englishHome.Photo);
                englishHome.Photo = route;
                polishHome.Photo = route;
            }
            await context.SaveChangesAsync();

            return NoContent();
        }



    }
}
