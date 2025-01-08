using ApiEldorianWebApplication.Modelos;

namespace ApiEldorianWebApplication.Dtos
{
    public class UsuarioDto
    {
        public int idUsuario { get; set; }
        public string emailUsuario { get; set; }
        public string senhaUsuario { get; set; }
        public string nomeUsuario { get; set; }
        public int[] Personagens { get; set; } = [];
    }
}
