using U2Actividad1.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata;

namespace U2Actividad1.Models.ViewModels
{
    public class IndexViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;

    }
  
}
