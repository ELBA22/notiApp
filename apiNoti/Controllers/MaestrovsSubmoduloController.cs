using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiNoti.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MaestrovsSubmoduloDto>> Post (MaestrovsSubmoduloDto maestrovsSubmoduloDto)
        {
            var maestrovsSubmodulo = _mapper.Map<MaestrovsSubmodulo>(maestrovsSubmoduloDto);
            if(maestrovsSubmoduloDto.FechaCreacion == DateTime.MinValue)
            {
                maestrovsSubmoduloDto.FechaCreacion = DateTime.Now;
            }
            if(maestrovsSubmoduloDto.FechaModificacion == DateTime.MinValue)
            {
                maestrovsSubmoduloDto.FechaModificacion = DateTime.Now;
            }
            this._unitOfWork.MaestrovsSubmodulos.Add(maestrovsSubmodulo);
            await _unitOfWork.SaveAsync();

            if (maestrovsSubmodulo == null)
            {
                return BadRequest();
            }
            maestrovsSubmoduloDto.Id = maestrovsSubmodulo.Id;
            return CreatedAtAction(nameof(Post), new {id = maestrovsSubmoduloDto.Id}, maestrovsSubmoduloDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MaestrovsSubmoduloDto>> Put(int id, [FromBody] MaestrovsSubmoduloDto maestrovsSubmoduloDto)
        {
            if(maestrovsSubmoduloDto == null)
            {
                return BadRequest();
            }
            if (maestrovsSubmoduloDto.Id == 0)
            {
                maestrovsSubmoduloDto.Id = id;
            }
            if (maestrovsSubmoduloDto.Id != id)
            {
                return NotFound();
            }
            var maestrovsSubmodulos = _mapper.Map<MaestrovsSubmodulo>(maestrovsSubmoduloDto);
            _unitOfWork.MaestrovsSubmodulos.Update(maestrovsSubmodulos);
            await _unitOfWork.SaveAsync();
            return maestrovsSubmoduloDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult>Delete(int id)
        {
            var maestrovsSubmodulo = await _unitOfWork.MaestrovsSubmodulos.GetByIdAsync(id);
            if(maestrovsSubmodulo == null)
            {
                return NotFound();
            }
            _unitOfWork.MaestrovsSubmodulos.Remove(maestrovsSubmodulo);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
        
        
    }
}