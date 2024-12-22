using ApiEldorianWebApplication.BancoDeDados;
using ApiEldorianWebApplication.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiEldorianWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly BancoContext _context;
        public UsuariosController(BancoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            
            _context.SaveChangesAsync();
            return CreatedAtAction("GetUsuario", new { id = usuario.idUsuario }, usuario);
        }
    }
}
