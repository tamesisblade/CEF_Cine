using CEFPeliculas.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CEFPeliculas.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        public GenerosController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<Genero>> Get()
        {
            return await context.Generos.ToListAsync();

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Genero>> Get(int id)
        {
            var genero = await context.Generos.FirstOrDefaultAsync(p => p.Id == id);
            if(genero == null)
            {
                return NotFound();
            }
            return genero;
        }
        [HttpGet("primer")]
        public async Task<ActionResult<Genero>> Primer()
        {
            //buscar el primer registro
            //return await context.Generos.FirstAsync();
            //buscar el primer registro que empieza por
            var genero =  await context.Generos.FirstOrDefaultAsync(p => p.Nombre.StartsWith("C"));
            if (genero == null)
            {
                return NotFound();
            }
            return genero;
        }
        //filtrar
        [HttpGet("filtrar")]
        /* public async Task<IEnumerable<Genero>> Filtrar()
         {
             return await context.Generos.Where(
                 p => p.Nombre.StartsWith("T")
                 || p.Nombre.StartsWith("R")
                 ).ToListAsync();
         }*/
        public async Task<IEnumerable<Genero>> Filtrar(String nombre)
        {
            return await context.Generos
                .Where(p => p.Nombre.Contains(nombre))
                .OrderByDescending(p => p.Nombre)
                .Take(2)
                .ToListAsync();
        }
        [HttpPost("agregar")]
        public async Task<ActionResult> agregar(int id)
        {
            var genero = await context.Generos.AsTracking().FirstOrDefaultAsync(p => p.Id == id);
            if(genero == null)
            {
                return NotFound();
            }
            
                genero.Nombre = "tamesis";
            await context.SaveChangesAsync();
            return Ok();
            
        }
        

    }
}
