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
    public class EstadovsNotificacionController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EstadovsNotificacionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EstadovsNotificacionDto>>>Get()
        {
            var estadoVsNotificaciones = await _unitOfWork.EstadovsNotificaciones.GetAllAsync();
            return _mapper.Map<List<EstadovsNotificacionDto>>(estadoVsNotificaciones);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstadovsNotificacionDto>>Get(int id)
        {
            var estadovsNotificaciones = await _unitOfWork.EstadovsNotificaciones.GetByIdAsync(id);
            if(estadovsNotificaciones == null)
            {
                return NotFound();
            }
            return _mapper.Map<EstadovsNotificacionDto>(estadovsNotificaciones);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EstadovsNotificacionDto>>Post(EstadovsNotificacionDto estadovsNotificacionDto)
        {
            var estadovsNotificacion = _mapper.Map<EstadovsNotificacion>(estadovsNotificacionDto);

            if(estadovsNotificacionDto.FechaCreacion == DateTime.MinValue)
            {
                estadovsNotificacionDto.FechaCreacion = DateTime.Now; 
            }
            if(estadovsNotificacionDto.FechaModificacion == DateTime.MinValue)
            {
                estadovsNotificacionDto.FechaModificacion = DateTime.Now; 
            }
            this._unitOfWork.EstadovsNotificaciones.Add(estadovsNotificacion);
            await _unitOfWork.SaveAsync();
            
            if(estadovsNotificacion == null)
            {
                return BadRequest();
            }
            estadovsNotificacionDto.Id = estadovsNotificacion.Id;
            return CreatedAtAction(nameof(Post), new {id = estadovsNotificacionDto.Id}, estadovsNotificacionDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstadovsNotificacionDto>> Put(int id, [FromBody] EstadovsNotificacionDto estadovsNotificacionDto)
        {
            if(estadovsNotificacionDto == null)
            {
                return BadRequest();
            }
            if (estadovsNotificacionDto.Id == 0)
            {
                estadovsNotificacionDto.Id = id;
            }
            if (estadovsNotificacionDto.Id != id)
            {
                return NotFound();
            }
            var estadovsNotificaciones = _mapper.Map<EstadovsNotificacion>(estadovsNotificacionDto);
            _unitOfWork.EstadovsNotificaciones.Update(estadovsNotificaciones);
            await _unitOfWork.SaveAsync();
            return estadovsNotificacionDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult>Delete(int id)
        {
            var estadovsNotificacion = await _unitOfWork.EstadovsNotificaciones.GetByIdAsync(id);
            if(estadovsNotificacion == null)
            {
                return NotFound();
            }
            _unitOfWork.EstadovsNotificaciones.Remove(estadovsNotificacion);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}