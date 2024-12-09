using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiEldorianWebApplication.Modelos
{
    public class Raca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idRaca { get; set; }
        public string nomeRaca { get; set; }
        public string descricaoRaca { get; set; }
        public string sinergiaStatusRaca { get; set; }
        public string passivaRaca { get; set; }
        public string beneficioRaca { get; set; }
    } // Não tenho certeza se algumas propriedades são bools ou strings... -lobo

}
