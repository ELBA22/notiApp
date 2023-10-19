# NOTIAPP.
Es un proyecto de arquitectura de tres capas, creando webApis con .Net.

# CREACION DE PROYECTO.
Para este proyecto se debe crear una carpeta donde guardaremos nuestro proyecto.

```
dotnet new sln 
```

# CREACION PROYECTO CLASSLIB.
```
dotnet new classlib -o Core
dotnet new classlib -o Infraestructure
```

# CREACION PROYECTO WebApi.
```
dotnet new webapi -o apiNoti
```

# AGREGAR PROYECTOS A LA SOLUCION.
```
dotnte sln add apiNoti
dotnet sln add Core
dotnet sln add Infraestructure
```

# AGREGAR REFERENCIA ENTRE PROYECTOS.
```
dotnet add reference ..\Infraestructure
dotnet add reference ..\Core
```

# INSTALACION DE PAQUETES.
## Proyecto WebApi
```
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 7.0.10
dotnet add package Microsoft.EntityFrameworkCore --version 7.0.10
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.10
dotnet add package Microsoft.Extensions.DependencyInjection --version 7.0.0
dotnet add package System.IdentityModel.Tokens.Jwt --version 6.32.3
dotnet add package Serilog.AspNetCore --version 7.0.0
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.1
```
## Proyecto Infraestructure
```
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 7.0.0
dotnet add package Microsoft.EntityFrameworkCore --version 7.0.10
dotnet add package CsvHelper --version 30.0.1
```
# VS CODE.
El proyecto debe verse de esta forma.

![IMAGE](<captura de pantalla notiapp.png>)


# Conexion a la base de datos.
Lo primero que se hace, es establecer paramentros de cadenas de conexion, en el archivo appsettings.Development o json.
Se definen tanto en modo produccion y desarrollo.

![Image](<Captura de pantalla 2023-10-17 192503.png>)

## Inyeccion de conexion a la base de datos (contenedor de dependencias)

![Image](<Captura de pantalla program.png>)

# Context
Seguido de lo anterior, procedemos a la realizacion del Context,es una clase que negocea con la webApi y la base de datos, se crea una carpeta llamada Data en Infraestructure para el Context y se aconseja llamarlo de acuerdo al proyecto.

![Image](<Captura de pantalla context-1.png>)

# Entities
Despues de todos esos pasos, en la carpeta Core, crearemos un carpeta llamada entities, en ella iran todas las entidades.
Base entity : Es la base de todas las entidades la cual hereda a las demas clases o entidades unos atributos.

![Image](<Captura de pantalla 2023-10-17 130329.png>)

# Configuraciones 
En la carpeta de infraestraestructura tenemos Data, en esa misma carpeta creamos un folder llamado configuration, estas clases se crean para configurar cada uno de los atributos de las tablas. 

![Image](<Captura de pantalla 2023-10-17 194812.png>)

Esta carpeta representa las configuraciones de las entidades, utilizando Entity Framework Core, definiendo nombres de tablas,restricciones, propiedades, generacion de claves primarias y columnas.

# Interfaces, IGenericRepository, IUnitOfWork
En la carpeta Core creamos las interfaces junto con una clase llamada IGenericRepository.
```
namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        Task<(int totalRegistros, IEnumerable<T> registros)>GetAllAsync(int pageIndex, int pageSize, string search);
        void Add (T entity );

        void AddRange(IEnumerable<T> entities);
        void Remove (T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Update (T entity);
        
    }
}
```
## IUnitOfWork 
```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IAuditoria Auditorias {get;}
        IBlockChain BlockChains {get;}
        IEstadovsNotificacion EstadovsNotificaciones {get;}
        IFormato Formatos {get;}
        IGenericovsSubmodulo GenericovsSubmodulos {get;}
        IHiloRespuesta HiloRespuestas {get;}
        IMaestrovsSubmodulo MaestrovsSubmodulos {get;}
        IModuloMaestro ModulosMaestros {get;}
        IModuloNotificacion ModulosNotificaciones {get;}
        IPermisoGenerico PermisosGenericos {get;}
        IRadicado Radicados {get;}
        IRol Roles {get;}
        IRolvsMaestro RolvsMaestros {get;}
        ISubmodulo Submodulos {get;}
        ITipoNotificacion TipoNotificaciones {get;}
        ITipoRequerimiento TipoRequerimientos {get;}

        Task<int> SaveAsync();

    }
}
```

# Repositorios, GenericRepository
Siguiendo con los pasos nos vamos a infraestructure y creamos un folder, llamado Repositories en el cual se crearan clases repositorioas para todas las entidades, y un GenericRepository.


![Image](<Captura de pantalla 2023-10-18 004634.png>)

Alli mismo implementamos la carpeta de Unidades de trabajos, se utilizan para agrupar y coordinar operaciones relacionales con la persistencia de datos.

```
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
```

# Dtos.
Luego de haber hecho todos los pasos anteriores, creamos los Dtos en la carpeta api, se usan para especificar la informacion que yo quiero mostrar, o transferir los datos entre los componentes de manera optimizada.
```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiNoti.Dtos
{
    public class AuditoriaDto
    {
        public int Id {get; set;}

        public string NombreUsuario {get; set;}

        public int DesAccion {get; set;}
        public DateTime FechaCreacion {get; set;}

        public DateTime FechaModificacion {get; set;}
    }
}
```
## Configuracion de librerias.
Se agregan los servicios de la libreria en el archivo Program.cs
```
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.ConfigureCors();
builder.Services.AddApplicationServices();
```

# Extensions
Implementación de rate limiting.
```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreRateLimit;
using Core.Interfaces;
using Infrastructure.UnitOfWork;

namespace apiNoti.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static void ConfigureCors(this  IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "CorsPolicy",
                    builder =>
                        builder
                            .AllowAnyOrigin() //WithOrigins("https://domini.com")
                            .AllowAnyMethod() //WithMethods(*GET", "POST")
                            .AllowAnyHeader()
                );
            });
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        public static void ConfigureRatelimiting(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddInMemoryRateLimiting();
            services.Configure<IpRateLimitOptions>(options =>
            {
                options.EnableEndpointRateLimiting = true;
                options.StackBlockedRequests = false;
                options.HttpStatusCode = 429;
                options.RealIpHeader = "X-Real-IP";
                options.GeneralRules = new List<RateLimitRule>
                {
                    new RateLimitRule
                    {
                        Endpoint = "*",
                        Period = "10s",
                        Limit = 2
                    } 
                };
            });
        }
    }
}
```

# Controllers
Se define el CRUD(Crear, leer, actualizar, eliminar) las peticiones.
```
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
    public class AuditoriaController :BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public AuditoriaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AuditoriaDto>>Get(int id)
        {
            var mascota = await _unitOfWork.Auditorias.GetByIdAsync(id);
            if(mascota == null)
            {
                return NotFound();
            }
            return _mapper.Map<AuditoriaDto>(mascota);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AuditoriaDto>>> Get()
        {
            var auditorias = await _unitOfWork.Auditorias.GetAllAsync();
            return _mapper.Map<List<AuditoriaDto>>(auditorias);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuditoriaDto>>Post(AuditoriaDto auditoriaDto)
        {
            var auditoria = _mapper.Map<Auditoria>(auditoriaDto);

            if(auditoriaDto.FechaCreacion == DateTime.MinValue)
            {
                auditoriaDto.FechaCreacion = DateTime.Now; 
            }
            if(auditoriaDto.FechaModificacion == DateTime.MinValue)
            {
                auditoriaDto.FechaModificacion = DateTime.Now; 
            }
            this._unitOfWork.Auditorias.Add(auditoria);
            await _unitOfWork.SaveAsync();
            
            if(auditoria == null)
            {
                return BadRequest();
            }
            auditoriaDto.Id = auditoria.Id;
            return CreatedAtAction(nameof(Post), new {id = auditoriaDto.Id}, auditoriaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AuditoriaDto>> Put(int id, [FromBody] AuditoriaDto auditoriaDto)
        {
            if(auditoriaDto == null)
            {
                return NotFound();
            }
            var auditorias = _mapper.Map<Auditoria>(auditoriaDto);
            _unitOfWork.Auditorias.Update(auditorias);
            await _unitOfWork.SaveAsync();
            return auditoriaDto;
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult>Delete(int id)
        {
            var auditoria = await _unitOfWork.Auditorias.GetByIdAsync(id);
            if(auditoria == null)
            {
                return NotFound();
            }
            _unitOfWork.Auditorias.Remove(auditoria);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
        
    }
}
```
# Profiles.
Contiene el mapeo de entidades.

## MappingProfiles.
```
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
```

# COMANDO MIGRACION.
```
dotnet ef migrations add NombreMigracion --project ./Infraestructure/ --startup-project ./apiNoti/ 
--output-dir ./Data/Migrations 
```
## Comando para actualizar base de datos en la migracion.
```
dotnet ef database update --project ./Infraestructure/ --startup-project ./apiNoti/
```

## Recuerde: 
Para que se puedan permitir las migraciones se necesita instalar el paquete dotnet ef.
```
dotnet ef tool install --global dotnet -ef
```










