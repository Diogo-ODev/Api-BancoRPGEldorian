using ApiEldorianWebApplication.BancoDeDados;
using ApiEldorianWebApplication.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiEldorianWebApplication.Dtos;

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
        public async Task<ActionResult<Usuario>> PostUsuario(UsuarioDto usuario)
        {
            var novoUsuario = new Usuario(){
                emailUsuario = usuario.emailUsuario,
                nomeUsuario = usuario.nomeUsuario,
                senhaUsuario = usuario.senhaUsuario,
            };

            _context.Usuarios.Add(novoUsuario);
            
            _context.SaveChangesAsync();
            return CreatedAtAction("GetUsuario", new { id = usuario.idUsuario }, usuario);
            //return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuarioDto usuario)
        {

            if (!UsuarioExists(id))
            {
                return BadRequest();
            }

            if (id != usuario.idUsuario)
            {
                return BadRequest();
            }

            var usuarioASerAlterado = _context.Usuarios.Find(id);

            usuarioASerAlterado.emailUsuario = usuario.emailUsuario;
            usuarioASerAlterado.nomeUsuario = usuario.nomeUsuario;
            usuarioASerAlterado.senhaUsuario = usuario.senhaUsuario;

            _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.idUsuario == id);
        }
    }
}
