using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcConciertosExamen.Models
{
    public class CategoriaEvento
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
    }
}
