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
    public class GenericovsSubmoduloController :BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenericovsSubmoduloController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<GenericovsSubmoduloDto>>>Get()
        {
            var genericovsSubmodulos = await _unitOfWork.GenericovsSubmodulos.GetAllAsync();
            return _mapper.Map<List<GenericovsSubmoduloDto>>(genericovsSubmodulos);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GenericovsSubmoduloDto>>Get(int id)
        {
            var genericovsSubmodulo = await _unitOfWork.GenericovsSubmodulos.GetByIdAsync(id);
            if(genericovsSubmodulo == null)
            {
                return NotFound();
            }
            return _mapper.Map<GenericovsSubmoduloDto>(genericovsSubmodulo);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GenericovsSubmoduloDto>>Post(GenericovsSubmoduloDto genericovsSubmoduloDto)
        {
            var genericovsSubmodulo = _mapper.Map<GenericovsSubmodulo>(genericovsSubmoduloDto);

            if(genericovsSubmoduloDto.FechaCreacion == DateTime.MinValue)
            {
                genericovsSubmoduloDto.FechaCreacion = DateTime.Now; 
            }
            if(genericovsSubmoduloDto.FechaModificacion == DateTime.MinValue)
            {
                genericovsSubmoduloDto.FechaModificacion = DateTime.Now; 
            }
            this._unitOfWork.GenericovsSubmodulos.Add(genericovsSubmodulo);
            await _unitOfWork.SaveAsync();
            
            if(genericovsSubmodulo == null)
            {
                return BadRequest();
            }
            genericovsSubmoduloDto.Id = genericovsSubmodulo.Id;
            return CreatedAtAction(nameof(Post), new {id = genericovsSubmoduloDto.Id}, genericovsSubmoduloDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GenericovsSubmoduloDto>> Put(int id, [FromBody] GenericovsSubmoduloDto genericovsSubmoduloDto)
        {
            if(genericovsSubmoduloDto == null)
            {
                return BadRequest();
            }
            if (genericovsSubmoduloDto.Id == 0)
            {
                genericovsSubmoduloDto.Id = id;
            }
            if(genericovsSubmoduloDto.Id != id)
            {
                return NotFound();
            }
            var genericovsSubmodulos = _mapper.Map<GenericovsSubmodulo>(genericovsSubmoduloDto);
            _unitOfWork.GenericovsSubmodulos.Update(genericovsSubmodulos);
            await _unitOfWork.SaveAsync();
            return genericovsSubmoduloDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult>Delete(int id)
        {
            var genericovsSubmodulo = await _unitOfWork.GenericovsSubmodulos.GetByIdAsync(id);
            if(genericovsSubmodulo == null)
            {
                return NotFound();
            }
            _unitOfWork.GenericovsSubmodulos.Remove(genericovsSubmodulo);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}