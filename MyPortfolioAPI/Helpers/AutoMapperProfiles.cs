using AutoMapper;
using MyPortfolioAPI.DTOs;
using MyPortfolioAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolioAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<SkillDTO, Skill>().ReverseMap();
            CreateMap<SkillCreationDTO, Skill>().ForMember(x=>x.Icon, options => options.Ignore());
            CreateMap<HomeDTO, Home>().ReverseMap();
            CreateMap<HomeCreationDTO, Home>().ForMember(x => x.Image, options => options.Ignore())
                .ForMember(x => x.Photo, options => options.Ignore());
            CreateMap<ExperienceCreatingDTO, Experience>();
            CreateMap<ExperienceDTO, Experience>().ReverseMap();
            CreateMap<AboutMeDTO, AboutMe>().ReverseMap();
            CreateMap<AboutMeCreatingDTO, AboutMe>().ForMember(x => x.Photo, options => options.Ignore());
        }
    }
}
