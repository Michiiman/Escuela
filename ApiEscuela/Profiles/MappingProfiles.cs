using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEscuela.Dto;
using AutoMapper;
using Domain.Entities;

namespace ApiEscuela.Profiles;
public class MappingProfiles:Profile
{
    public MappingProfiles(){
        CreateMap<Class,ClassDto>().ReverseMap();
    }
    
}