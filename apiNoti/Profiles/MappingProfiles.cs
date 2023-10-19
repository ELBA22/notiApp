using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiNoti.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace apiNoti.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Auditoria, AuditoriaDto>().ReverseMap();
            CreateMap<BlockChain, BlockChainDto>().ReverseMap();
            CreateMap<EstadovsNotificacion, EstadovsNotificacionDto>().ReverseMap();
            CreateMap<Formato, FormatoDto>().ReverseMap();
            CreateMap<GenericovsSubmodulo, GenericovsSubmoduloDto>().ReverseMap();
            CreateMap<HiloRespu, HiloRespuDto>().ReverseMap();
            CreateMap<MaestrovsSubmodulo, MaestrovsSubmoduloDto>().ReverseMap();
            CreateMap<MMaestro, MMaestroDto>().ReverseMap();
            CreateMap<MNotificacion, ModuloNotificacionDto>().ReverseMap();
            CreateMap<PermisoGenerico, PermisoGenericoDto>().ReverseMap();
            CreateMap<Radicado, RadicadoDto>().ReverseMap();
            CreateMap<Rol, RolDto>().ReverseMap();
            CreateMap<RolvsMaestro, RolvsMaestroDto>().ReverseMap();
            CreateMap<Submodulo, SubmoduloDto>().ReverseMap();
            CreateMap<TipoNotificacion, TipoNotificacionDto>().ReverseMap();
            CreateMap<TipoRequerimiento, TipoRequerimientoDto>().ReverseMap();
        }
    }
}