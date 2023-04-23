using CEFPeliculas.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace CEFPeliculas.Controllers
{
    [ApiController]
    [Route("api/actores")]
    public class AutoresController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        public AutoresController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<Actor>> Get(){
            var actores =  await context.Actores
                .Select(p => new  { Id = p.Id , Nombre = p.Nombre})
                .ToListAsync();
            return Ok(actores);
        }
    }
}
