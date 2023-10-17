using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiNoti.Profiles
{
    public class MappingProfiles :Profiles
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
            CreateMap<MMaestro, ModuloMaestroDto>().ReverseMap();
            CreateMap<ModuloNotificacion, ModuloNotificacionDto>().ReverseMap();
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