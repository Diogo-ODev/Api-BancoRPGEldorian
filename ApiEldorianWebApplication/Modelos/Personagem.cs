using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiEldorianWebApplication.Modelos
{
    public class Personagem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idPersonagem { get; set; }
        public string nomePersonagem { get; set; }
        public int idNivel{ get; set; } // FK
        public decimal xpAtualPersonagem { get; set; }
        public decimal pesoMaximoPersonagem { get; set; }
        public int idClasse { get; set; } // FK
        public int idRaca { get; set; } // FK
        public virtual Raca Raca { get; set; }
        public int idMagia { get; set; } // FK
        public int idHabilidade { get; set; } // FK
        public int idItemPersonagem { get; set; } // FK
        public int idPet { get; set; } // FK
        public decimal vidaPersonagem { get; set; }
        public decimal manaPersonamge { get; set; }
        public int vigorPersonagem { get; set; }
        public int idAtributo { get; set; } // FK
        public int idEfeito { get; set; } // FK
        public int idUsuario { get; set; } // FK
        public virtual Usuario Usuario { get; set; }
    }
}
