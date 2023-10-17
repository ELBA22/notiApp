using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infraestructure.Data;
using Infraestructure.Repositories;
using Infrastructure.Repositories;


namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly notiAppContext _context;
        private AuditoriaRepository _auditorias;
        private BlockChainRepository _blockChains;
        private EstadovsNotificacionRepository _estadoVsNotificaciones;
        private FormatoRepository _formatos;
        private GenericovsSubmoduloRepository _genericoVsSubmodulos;
        private HiloRespuestaRepository _hiloRespuestas;
        private MaestrovsSubmoduloRepository _maestroVsSubmodulos;
        private MMaestroRepository _modulosMaestros;
        private MNotificacionRepository _modulosNotificaciones;
        private PermisoGenericoRepository _permisosGenericos;
        private RadicadoRepository _radicados;
        private RolRepository _roles;
        private RolvsMaestroRepository _rolVsMaestros;
        private SubmoduloRepository _submodulos;
        private TipoNotificacionRepository _tiposNotificaciones;
        private TipoRequerimientoRepository _tiposRequerimientos;

        public IAuditoria Auditorias
        {
            get 
            { 
                if(_auditorias == null)
                {
                    _auditorias = new AuditoriaRepository(_context);
                }
                return _auditorias;
            }
        }
        public IBlockChain BlockChains
        {
            get 
            { 
                if(_blockChains == null)
                {
                    _blockChains = new BlockChainRepository(_context);
                }
                return _blockChains;
            }
        }
        public IEstadovsNotificacion EstadoVsNotificaciones
        {
            get 
            { 
                if(_estadoVsNotificaciones == null)
                {
                    _estadoVsNotificaciones = new EstadovsNotificacionRepository(_context);
                }
                return _estadoVsNotificaciones;
            }
        }
        public IFormato Formatos
        {
            get 
            { 
                if(_formatos == null)
                {
                    _formatos = new FormatoRepository(_context);
                }
                return _formatos;
            }
        }
        public IGenericovsSubmodulo GenericovsSubmodulos
        {
            get 
            { 
                if(_genericoVsSubmodulos == null)
                {
                    _genericoVsSubmodulos = new GenericovsSubmoduloRepository(_context);
                }
                return _genericoVsSubmodulos;
            }
        }
        public IHiloRespuesta HiloRespuestas
        {
            get 
            { 
                if(_hiloRespuestas == null)
                {
                    _hiloRespuestas = new HiloRespuestaRepository(_context);
                }
                return _hiloRespuestas;
            }
        }
        public IMaestrovsSubmodulo MaestrovsSubmodulos
        {
            get 
            { 
                if(_maestroVsSubmodulos == null)
                {
                    _maestroVsSubmodulos = new MaestrovsSubmoduloRepository(_context);
                }
                return _maestroVsSubmodulos;
            }
        }
        public IModuloMaestro ModulosMaestros
        {
            get 
            { 
                if(_modulosMaestros == null)
                {
                    _modulosMaestros = new MMaestroRepository(_context);
                }
                return _modulosMaestros;
            }
        }
        public IModuloNotificacion ModulosNotificaciones
        {
            get 
            { 
                if(_modulosNotificaciones == null)
                {
                    _modulosNotificaciones = new MNotificacionRepository(_context);
                }
                return _modulosNotificaciones;
            }
        }
        public IPermisoGenerico PermisosGenericos
        {
            get 
            { 
                if(_permisosGenericos == null)
                {
                    _permisosGenericos = new PermisoGenericoRepository(_context);
                }
                return _permisosGenericos;
            }
        }
        public IRadicado Radicados
        {
            get 
            { 
                if(_radicados == null)
                {
                    _radicados = new RadicadoRepository(_context);
                }
                return _radicados;
            }
        }
        public IRol Roles
        {
            get 
            { 
                if(_roles == null)
                {
                    _roles = new RolRepository(_context);
                }
                return _roles;
            }
        }
        public IRolvsMaestro RolVsMaestros
        {
            get 
            { 
                if(_rolVsMaestros == null)
                {
                    _rolVsMaestros = new RolvsMaestroRepository(_context);
                }
                return _rolVsMaestros;
            }
        }
        public ISubmodulo Submodulos
        {
            get 
            { 
                if(_submodulos == null)
                {
                    _submodulos = new SubmoduloRepository(_context);
                }
                return _submodulos;
            }
        }
        public ITipoNotificacion TiposNotificaciones
        {
            get
            { 
                if(_tiposNotificaciones == null)
                {
                    _tiposNotificaciones = new TipoNotificacionRepository(_context);
                }
                return _tiposNotificaciones;
            }
        }
        public ITipoRequerimiento TiposRequerimientos
        {
            get 
            { 
                if(_tiposRequerimientos == null)
                {
                    _tiposRequerimientos = new TipoRequerimientoRepository(_context);
                }
                return _tiposRequerimientos;
            }
        }

        public IEstadovsNotificacion EstadovsNotificaciones => throw new NotImplementedException();

        public IRolvsMaestro RolvsMaestros => throw new NotImplementedException();

        public ITipoNotificacion TipoNotificaciones => throw new NotImplementedException();

        public ITipoRequerimiento TipoRequerimientos => throw new NotImplementedException();

        public UnitOfWork (notiAppContext context)
        {
            _context = context;
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}