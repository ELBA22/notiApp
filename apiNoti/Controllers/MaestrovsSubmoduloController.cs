using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiNoti.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace apiNoti.Controllers
{
    public class MaestrovsSubmoduloController :BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public MaestrovsSubmoduloController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MaestrovsSubmoduloDto>>>Get()
        {
            var maestrovsSubmodulos = await _unitOfWork.MaestrovsSubmodulos.GetAllAsync();
            return _mapper.Map<List<MaestrovsSubmoduloDto>>(maestrovsSubmodulos);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MaestrovsSubmoduloDto>>Get(int id)
        {
            var maestrovsSubmodulo = await _unitOfWork.MaestrovsSubmodulos.GetByIdAsync(id);
            if(maestrovsSubmodulo == null)
            {
                return NotFound();
            }
            return _mapper.Map<MaestrovsSubmoduloDto>(maestrovsSubmodulo);
        }
        
        
        
    }
}