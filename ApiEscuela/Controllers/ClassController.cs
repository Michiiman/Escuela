using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApiEscuela.Dto;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiEscuela.Controllers;
public class ClassController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly  IMapper mapper;

    public ClassController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    /*public async Task<ActionResult<IEnumerable<ClassDto>>> Get()
    {
        var entidad = await unitOfWork.Classes.GetAllAsync();
        //return Ok(entidad);
        return mapper.Map<List<ClassDto>>(entidad);
    }*/
    public async Task<ActionResult<IEnumerable<Class>>> Get()
    {
        var entidad = await unitOfWork.Classes.GetAllAsync();
        return Ok(entidad);
    }
}